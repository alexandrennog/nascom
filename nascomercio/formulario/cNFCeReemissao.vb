Imports System.Security.Cryptography.X509Certificates
Imports LibNF65
Imports LibNF65.Modelo
Imports ncComum.nsExcecao
Imports ncDados.nsNFCe
Imports ncRegras.nsNFCe

' Reemissao de NFC-e que falhou, foi rejeitada ou ficou interrompida
' (relatorio "NFC-e Emitidas"). Monta a nota de novo a partir da venda gravada
' (itens + formas de pagamento), do mesmo jeito que a tela de Pagamento.
'
' Seguranca contra nota em dobro:
'  1. Se ja existe chave gerada para aquele numero, consulta a SEFAZ antes:
'     se ela ja estiver autorizada (a comunicacao caiu depois da autorizacao),
'     so registra - nao emite de novo.
'  2. Se a SEFAZ nao responder a consulta, nao reemite.
'  3. So um computador por vez consegue "pegar" o numero (rEmissaoNFCe.Assumir).
'  4. Reaproveita o mesmo numero (nao abre buraco na numeracao).
'  5. Se a SEFAZ recusou o numero por duplicidade (ja existe nota autorizada com
'     ele), quem decide e o usuario: normalmente e a nota DESTA venda cuja
'     resposta se perdeu (registra, nao emite outra); se for de outra venda,
'     emite com numero novo e o antigo fica "Substituida".
Public Class NFCeReemissao

    ' Rejeicoes por numero ja usado: nao adianta tentar o mesmo numero de novo
    Private Shared ReadOnly CStatDuplicidade As Integer() = {204, 539}

    Public Class Resultado
        Public Property sucesso As Boolean
        Public Property jaEstavaAutorizada As Boolean
        Public Property numero As Integer
        Public Property chave As String
        Public Property mensagem As String
        Public Property avisoImpressao As String
        ' o usuario desistiu (pergunta da duplicidade) - nada foi feito
        Public Property cancelado As Boolean
    End Class

    ' Chave de acesso que a SEFAZ devolve na rejeicao 539 ("... [chNFe:3526...]")
    Public Shared Function ChaveNaMensagem(ByVal mensagem As String, ByVal ignorar As String) As String
        If String.IsNullOrEmpty(mensagem) Then
            Return ""
        End If
        For Each m As System.Text.RegularExpressions.Match In System.Text.RegularExpressions.Regex.Matches(mensagem, "[0-9]{44}")
            If m.Value <> ignorar Then
                Return m.Value
            End If
        Next
        Return ""
    End Function

    Public Shared Function CarregarCertificado() As X509Certificate2
        Dim config As PixConfig = NFCe65.ConsultarConfig()
        If config Is Nothing OrElse String.IsNullOrWhiteSpace(config.PathCertificate) Then
            Throw New ExcecaoNascomercio("Certificado digital não configurado neste computador.")
        End If
        If Not IO.File.Exists(config.PathCertificate) Then
            Throw New ExcecaoNascomercio("Certificado digital não encontrado em '" & config.PathCertificate & "'.")
        End If
        Return New Unimake.Business.Security.CertificadoDigital().CarregarCertificadoDigitalA1(config.PathCertificate, config.PassCertificate)
    End Function

    ' Mesmas formas de pagamento (e mesma ordem/codigos) da tela de Pagamento
    Public Shared Function MontarMeiosPagamento(ByVal p As dPagamentoVendaNFCe) As List(Of MeioPagamentoNascom)
        Dim meios As New List(Of MeioPagamentoNascom)

        If p.dinheiro > 0.001D Then
            meios.Add(New MeioPagamentoNascom With {.CodigoPagamento = "01", .DescricaoPagamento = "Dinheiro",
                                                    .Valor = CDbl(p.dinheiro), .Troco = CDbl(p.troco)})
        End If
        Adicionar(meios, p.cheque, "02", "Cheque")
        Adicionar(meios, p.chequePre, "02", "Cheque")
        Adicionar(meios, p.cartaoDebito, "04", "Cartão de Débito")
        Adicionar(meios, p.cartaoCredito, "03", "Cartão de Crédito")
        Adicionar(meios, p.crediario, "05", "Crédito Loja")
        Adicionar(meios, p.pix, "06", "PIX")
        Adicionar(meios, p.troca, "99", "Troca")
        Adicionar(meios, p.desconto, "99", "Desconto")
        Adicionar(meios, p.vale, "99", "Vale")
        Adicionar(meios, p.defeito, "99", "Defeitos")

        Return meios
    End Function

    Private Shared Sub Adicionar(ByVal meios As List(Of MeioPagamentoNascom), ByVal valor As Decimal, ByVal codigo As String, ByVal descricao As String)
        If valor > 0.001D Then
            meios.Add(New MeioPagamentoNascom With {.CodigoPagamento = codigo, .DescricaoPagamento = descricao, .Valor = CDbl(valor)})
        End If
    End Sub

    ' Consulta a chave na SEFAZ e acerta o historico (autorizada / cancelada).
    ' Devolve a situacao devolvida pela SEFAZ.
    Public Shared Function ConsultarEAtualizar(ByVal item As dEmissaoNFCe, ByVal certificado As X509Certificate2) As NFCe65.SituacaoNFCe
        If Not item.temChave OrElse Not item.seqNFe.HasValue Then
            Throw New ExcecaoNascomercio("Este registro não tem chave de acesso para consultar na SEFAZ.")
        End If

        Dim situacao As NFCe65.SituacaoNFCe = NFCe65.ConsultarSituacao(item.chave, certificado)
        Dim regras As New rEmissaoNFCe

        If situacao.Autorizada Then
            regras.AtualizarPelaConsulta(item.seqNFe.Value, "A", situacao.CStat, situacao.XMotivo, situacao.Protocolo,
                                         situacao.DataAutorizacao, situacao.CaminhoXml)
            If item.controle.HasValue Then
                regras.GravarChaveNaVenda(item.controle.Value, item.chave)
            End If
        ElseIf situacao.Cancelada Then
            regras.AtualizarPelaConsulta(item.seqNFe.Value, "C", situacao.CStat, "Cancelada na SEFAZ: " & situacao.XMotivo,
                                         situacao.Protocolo, situacao.DataAutorizacao, situacao.CaminhoXml)
        End If

        Return situacao
    End Function

    ' decidirDuplicidade: so e chamado quando a SEFAZ recusou o numero por duplicidade.
    ' Recebe a chave que ja existe na SEFAZ ("" se a mensagem nao trouxe) e devolve
    ' True = e a nota desta venda (registrar) | False = emitir com numero novo |
    ' Nothing = cancelar.
    Public Shared Function Reemitir(ByVal item As dEmissaoNFCe, ByVal cpf As String, ByVal imprimir As Boolean,
                                    ByVal aoTentarNovamente As Action(Of Integer, Integer), ByVal aoAguardar As Action,
                                    ByVal decidirDuplicidade As Func(Of String, Nullable(Of Boolean))) As Resultado
        Dim regras As New rEmissaoNFCe
        Dim r As New Resultado

        If Not item.podeReemitir Then
            Throw New ExcecaoNascomercio("Esta NFC-e não pode ser reemitida (situação: " & item.situacaoDescricao & ").")
        End If

        Dim controle As Integer = item.controle.Value

        ' Venda e itens
        Dim pagamento As dPagamentoVendaNFCe = regras.PagamentosDaVenda(controle)
        If pagamento Is Nothing Then
            Throw New ExcecaoNascomercio("A venda " & controle.ToString() & " não existe mais (foi excluída?). Não há o que reemitir.")
        End If
        If dEmissaoNFCe.ChaveValida(pagamento.chave) AndAlso pagamento.chave <> item.chave Then
            Throw New ExcecaoNascomercio("A venda " & controle.ToString() & " já tem outra NFC-e autorizada (chave " & pagamento.chave & ")." & vbCrLf &
                                         "Atualize o relatório.")
        End If

        Dim itens As ncDados.nsVenda.ColecaoVendaProduto = regras.ItensDaVenda(controle)
        If itens Is Nothing OrElse itens.Count = 0 Then
            Throw New ExcecaoNascomercio("A venda " & controle.ToString() & " não tem produtos gravados. Não é possível montar a NFC-e.")
        End If

        Dim certificado As X509Certificate2 = CarregarCertificado()

        ' 1. Ja existe chave para esse numero: a nota pode ter sido autorizada
        '    mesmo com a falha de comunicacao. Confere antes de emitir de novo.
        If item.origem = "N" AndAlso item.temChave Then
            Dim situacao As NFCe65.SituacaoNFCe
            Try
                situacao = ConsultarEAtualizar(item, certificado)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Não foi possível consultar a SEFAZ para saber se a NFC-e nº " & item.seqNFe.Value.ToString() &
                                             " já tinha sido autorizada. Por segurança ela NÃO foi reemitida - tente de novo mais tarde." &
                                             vbCrLf & vbCrLf & "Detalhe: " & ex.Message, ex)
            End Try

            If situacao.Autorizada Then
                r.sucesso = True
                r.jaEstavaAutorizada = True
                r.numero = item.seqNFe.Value
                r.chave = item.chave
                r.mensagem = "A NFC-e nº " & r.numero.ToString() & " JÁ ESTAVA AUTORIZADA na SEFAZ (a falha foi só na resposta)." & vbCrLf &
                             "Ela foi registrada como autorizada - não foi emitida outra."
                If imprimir Then
                    Try
                        NFCe65.Reimprimir(item.chave)
                    Catch exImp As Exception
                        r.avisoImpressao = exImp.Message
                    End Try
                End If
                Return r
            End If

            If situacao.Cancelada Then
                Throw New ExcecaoNascomercio("A NFC-e nº " & item.seqNFe.Value.ToString() & " consta como CANCELADA na SEFAZ (" &
                                             situacao.CStat.ToString() & " - " & situacao.XMotivo & "). Ela não foi reemitida.")
            End If

            ' 217 = nao existe na SEFAZ: pode emitir. Rejeitada antes: tambem nao existe.
            If Not situacao.NaoExiste AndAlso item.situacao <> "R" Then
                Throw New ExcecaoNascomercio("A SEFAZ respondeu """ & situacao.CStat.ToString() & " - " & situacao.XMotivo &
                                             """ para a chave desta nota. Por segurança ela não foi reemitida. Fale com o suporte.")
            End If
        End If

        ' 2. Numero
        Dim dados As New dEmissaoNFCe
        dados.controle = controle
        dados.valor = pagamento.total
        dados.cpfConsumidor = cpf
        dados.terminal = Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL")
        dados.computador = Environment.MachineName
        dados.usuario_cid = mdiPrincipal.gUsuario.cid
        dados.usuarioNome = mdiPrincipal.gUsuario.nomeCompleto

        Dim numero As Integer
        If item.origem = "N" AndAlso item.seqNFe.HasValue Then
            Dim seqAntigo As Integer = item.seqNFe.Value
            Dim duplicidade As Boolean = item.cStat.HasValue AndAlso Array.IndexOf(CStatDuplicidade, item.cStat.Value) >= 0

            If duplicidade Then
                Dim chaveExistente As String = ChaveNaMensagem(item.mensagem, item.chave)
                Dim decisao As Nullable(Of Boolean) = If(decidirDuplicidade Is Nothing, Nothing, decidirDuplicidade(chaveExistente))
                If Not decisao.HasValue Then
                    r.cancelado = True
                    r.mensagem = "Nada foi feito."
                    Return r
                End If

                If decisao.Value Then
                    Return RegistrarNotaExistente(item, chaveExistente, certificado, dados, imprimir)
                End If

                ' outra venda usou esse numero: emite com um numero novo
                If Not regras.Substituir(seqAntigo) Then
                    Throw New ExcecaoNascomercio("A NFC-e nº " & seqAntigo.ToString() & " já está sendo reemitida em outro computador " &
                                                 "(ou já foi resolvida). Atualize o relatório.")
                End If
                Try
                    numero = regras.Reservar(dados)
                Catch
                    ' sem numero novo: o antigo volta como estava
                    regras.AtualizarPelaConsulta(seqAntigo, item.situacao, item.cStat, item.mensagem, Nothing, Nothing, Nothing)
                    Throw
                End Try
                regras.LigarSubstituta(seqAntigo, numero)
            Else
                If Not regras.Assumir(seqAntigo, dados) Then
                    Throw New ExcecaoNascomercio("A NFC-e nº " & seqAntigo.ToString() & " já está sendo reemitida em outro computador " &
                                                 "(ou já foi resolvida). Atualize o relatório.")
                End If
                numero = seqAntigo
            End If
        Else
            ' venda sem numero ligado (falha antiga)
            If regras.UltimaDaVenda(controle) IsNot Nothing Then
                Throw New ExcecaoNascomercio("Já existe uma NFC-e ligada à venda " & controle.ToString() & ". Atualize o relatório.")
            End If
            numero = regras.Reservar(dados)
        End If

        ' 3. Emite (mesma rotina da venda; com novas tentativas automaticas)
        Dim chaveGerada As String = Nothing
        Dim avisoImpressao As String = Nothing
        r.numero = numero

        Try
            Dim chave As String = NFCe65.GerarNF(fPagamento.ConverterLista(New List(Of ncDados.nsVenda.dVendaProduto)(itens)), certificado, MontarMeiosPagamento(pagamento),
                                                 rEmissaoNFCe.SomenteDigitos(cpf), controle.ToString(), numero,
                                                 aoTentarNovamente, aoAguardar,
                                                 Sub(exImpressao) avisoImpressao = exImpressao.Message,
                                                 Sub(chaveNova)
                                                     chaveGerada = chaveNova
                                                     regras.TentarRegistrarChave(numero, chaveNova, NFCe65.LocalizarXml(chaveNova))
                                                 End Sub,
                                                 imprimir)

            regras.TentarFinalizarAutorizada(numero, chave, NFCe65.LocalizarXml(chave))

            r.sucesso = True
            r.chave = chave
            r.avisoImpressao = avisoImpressao
            r.mensagem = "NFC-e nº " & numero.ToString() & " AUTORIZADA para a venda " & controle.ToString() & "."

            ' A nota ja esta autorizada: um erro aqui nao pode virar "falha" no historico
            Try
                regras.GravarChaveNaVenda(controle, chave)
            Catch exVenda As Exception
                r.mensagem &= vbCrLf & vbCrLf & "Atenção: não foi possível gravar a chave na venda (" & exVenda.Message & ")." &
                              " A nota vale normalmente; avise o suporte."
            End Try

        Catch exRejeicao As NFCeRejeitadaException
            Dim chaveFalha As String = If(chaveGerada, exRejeicao.ChaveAcesso)
            regras.TentarFinalizarSemSucesso(numero, True, exRejeicao.CStat, exRejeicao.Message, chaveFalha, NFCe65.LocalizarXml(chaveFalha))
            r.sucesso = False
            r.chave = chaveFalha
            r.mensagem = "A SEFAZ REJEITOU a NFC-e nº " & numero.ToString() & " (venda " & controle.ToString() & ")." & vbCrLf & vbCrLf &
                         "Motivo: " & exRejeicao.CStat.ToString() & " - " & exRejeicao.XMotivo & vbCrLf & vbCrLf &
                         "É um erro nos dados fiscais (cadastro do produto, CFOP, NCM...) - corrija antes de reemitir."

        Catch ex As Exception
            regras.TentarFinalizarSemSucesso(numero, False, Nothing, ex.Message, chaveGerada, NFCe65.LocalizarXml(chaveGerada))
            r.sucesso = False
            r.chave = chaveGerada
            r.mensagem = "Não foi possível emitir a NFC-e nº " & numero.ToString() & " (venda " & controle.ToString() & ")." & vbCrLf & vbCrLf &
                         "Normalmente é a SEFAZ fora do ar ou lenta - tente de novo mais tarde." & vbCrLf & vbCrLf &
                         "Detalhe: " & ex.Message
        End Try

        Return r
    End Function

    ' Duplicidade em que o usuario confirmou que a nota que ja existe na SEFAZ e
    ' desta venda: confere que ela esta autorizada e registra (nao emite outra)
    Private Shared Function RegistrarNotaExistente(ByVal item As dEmissaoNFCe, ByVal chaveExistente As String,
                                                   ByVal certificado As X509Certificate2, ByVal dados As dEmissaoNFCe,
                                                   ByVal imprimir As Boolean) As Resultado
        Dim regras As New rEmissaoNFCe
        Dim r As New Resultado
        Dim seq As Integer = item.seqNFe.Value

        If Not dEmissaoNFCe.ChaveValida(chaveExistente) Then
            Throw New ExcecaoNascomercio("A SEFAZ não informou a chave da nota que já existe com o número " & seq.ToString() & "." & vbCrLf &
                                         "Não dá para registrar - consulte a nota no portal da SEFAZ ou fale com o suporte.")
        End If

        Dim situacao As NFCe65.SituacaoNFCe
        Try
            situacao = NFCe65.ConsultarSituacao(chaveExistente, certificado)
        Catch ex As Exception
            Throw New ExcecaoNascomercio("Não foi possível consultar a chave " & chaveExistente & " na SEFAZ. Tente de novo mais tarde." &
                                         vbCrLf & vbCrLf & "Detalhe: " & ex.Message, ex)
        End Try

        If Not situacao.Autorizada Then
            Throw New ExcecaoNascomercio("A chave " & chaveExistente & " não está autorizada na SEFAZ (" & situacao.CStat.ToString() & " - " &
                                         situacao.XMotivo & "). Nada foi registrado.")
        End If

        If Not regras.Assumir(seq, dados) Then
            Throw New ExcecaoNascomercio("A NFC-e nº " & seq.ToString() & " já está sendo reemitida em outro computador " &
                                         "(ou já foi resolvida). Atualize o relatório.")
        End If

        ' chave + situacao no mesmo UPDATE (nunca "autorizada" com a chave antiga)
        regras.AtualizarPelaConsulta(seq, "A", situacao.CStat, situacao.XMotivo, situacao.Protocolo, situacao.DataAutorizacao,
                                     situacao.CaminhoXml, chaveExistente)
        regras.GravarChaveNaVenda(item.controle.Value, chaveExistente)

        r.sucesso = True
        r.jaEstavaAutorizada = True
        r.numero = seq
        r.chave = chaveExistente
        r.mensagem = "A NFC-e nº " & seq.ToString() & " (chave " & chaveExistente & ") foi registrada como a nota desta venda." & vbCrLf &
                     "Não foi emitida outra."
        If imprimir Then
            Try
                NFCe65.Reimprimir(chaveExistente)
            Catch exImp As Exception
                r.avisoImpressao = exImp.Message
            End Try
        End If
        Return r
    End Function

End Class
