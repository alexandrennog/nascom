Imports System.Globalization
Imports ncDados.nsNFCe
Imports ncDados.nsVenda
Imports ncComum.nsAcessoBD
Imports ncComum.nsExcecao

Namespace nsNFCe

    ' Historico de emissao da NFC-e (tabela "basennf", colunas do script
    ' "44 - nfce_historico_emissao.sql"). Todo valor que vai para o SQL passa
    ' por SqlTexto/SqlInteiro/SqlDecimal/SqlDataHora (escape de aspas e barra).
    Public Class pEmissaoNFCe

        ' Situacao "de verdade" de linhas gravadas por versoes antigas do sistema
        ' (sem a coluna situacao preenchida): deduz pela chave gravada
        Private Const SQL_SITUACAO As String =
            " COALESCE(b.situacao, CASE WHEN b.chnfe REGEXP '^[0-9]{44}$' THEN 'A' " &
            "                           WHEN b.chnfe = 'FALHA_EMISSAO' THEN 'F' ELSE 'E' END) "

        ' Script 44 aplicado neste banco?
        Public Function HistoricoDisponivel() As Boolean
            Dim acessoBanco As New cAcessoBD
            Dim ds As DataSet

            Try
                ds = acessoBanco.ExecutarDS(" SELECT COUNT(*) AS qtd FROM information_schema.columns " &
                                            "  WHERE table_schema = DATABASE() AND table_name = 'basennf' AND column_name = 'situacao' ")
                Return Not ds Is Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 AndAlso
                       Convert.ToInt64(ds.Tables(0).Rows(0)("qtd"), CultureInfo.InvariantCulture) > 0
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em HistoricoDisponivel EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        ' Pega o proximo numero da NFC-e (seqNFe) ja gravando de qual venda e,
        ' quem esta emitindo e quando. Devolve o numero.
        Public Function Reservar(ByVal dados As dEmissaoNFCe) As Integer
            Dim acessoBanco As New cAcessoBD

            Try
                Return acessoBanco.ExecutarCID(
                    " INSERT INTO basennf (chnfe, controle, dataEmissao, situacao, valor, cpfConsumidor, terminal, computador, " &
                    "                      usuario_cid, usuarioNome, tentativas, mensagem, dataAtualizacao) " &
                    " VALUES ('temporario', " & SqlInteiro(dados.controle) & ", NOW(), 'E', " &
                    SqlDecimal(dados.valor) & ", " & SqlTexto(dados.cpfConsumidor) & ", " &
                    SqlTexto(dados.terminal) & ", " & SqlTexto(dados.computador) & ", " &
                    SqlInteiro(dados.usuario_cid) & ", " & SqlTexto(dados.usuarioNome) & ", 1, " &
                    "'Emissão em andamento.', NOW()) ")
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Reservar EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        ' Chave gerada e XML gravado no disco (antes de enviar para a SEFAZ)
        Public Sub RegistrarChave(ByVal seqNFe As Integer, ByVal chave As String, ByVal caminhoXml As String)
            Dim acessoBanco As New cAcessoBD

            Try
                acessoBanco.ExecutarINT(
                    " UPDATE basennf SET " &
                    "        chnfe = " & SqlTexto(chave) & ", " &
                    "        caminhoXml = IFNULL(" & SqlTexto(caminhoXml) & ", caminhoXml), " &
                    "        dataAtualizacao = NOW() " &
                    "  WHERE seqNFe = " & SqlInteiro(seqNFe))
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em RegistrarChave EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Sub

        ' Autorizada: protocolo, data e retorno vem da infprot (gravada pela LibNF65)
        Public Sub FinalizarAutorizada(ByVal seqNFe As Integer, ByVal chave As String, ByVal caminhoXml As String)
            Dim acessoBanco As New cAcessoBD
            Dim prot As String = " FROM infprot i WHERE i.chnfe = " & SqlTexto(chave) & " ORDER BY i.dhrecbto DESC LIMIT 1) "

            Try
                acessoBanco.ExecutarINT(
                    " UPDATE basennf SET " &
                    "        chnfe = " & SqlTexto(chave) & ", " &
                    "        caminhoXml = IFNULL(" & SqlTexto(caminhoXml) & ", caminhoXml), " &
                    "        situacao = 'A', " &
                    "        cStat = COALESCE((SELECT i.cstat " & prot & ", 100), " &
                    "        mensagem = COALESCE((SELECT i.xmotivo " & prot & ", 'Autorizado o uso da NF-e'), " &
                    "        protocolo = (SELECT i.nprot " & prot & ", " &
                    "        dataAutorizacao = COALESCE((SELECT i.dhrecbto " & prot & ", NOW()), " &
                    "        dataAtualizacao = NOW() " &
                    "  WHERE seqNFe = " & SqlInteiro(seqNFe))
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em FinalizarAutorizada EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Sub

        ' Rejeitada (R) ou falha (F). Chave e caminho so substituem quando informados.
        Public Sub FinalizarSemSucesso(ByVal seqNFe As Integer, ByVal situacao As String, ByVal cStat As Nullable(Of Integer),
                                       ByVal mensagem As String, ByVal chave As String, ByVal caminhoXml As String)
            Dim acessoBanco As New cAcessoBD

            Try
                acessoBanco.ExecutarINT(
                    " UPDATE basennf SET " &
                    "        chnfe = IFNULL(" & SqlTexto(chave) & ", IF(chnfe = 'temporario', 'FALHA_EMISSAO', chnfe)), " &
                    "        caminhoXml = IFNULL(" & SqlTexto(caminhoXml) & ", caminhoXml), " &
                    "        situacao = " & SqlTexto(situacao) & ", " &
                    "        cStat = " & SqlInteiro(cStat) & ", " &
                    "        mensagem = " & SqlTexto(mensagem) & ", " &
                    "        dataAtualizacao = NOW() " &
                    "  WHERE seqNFe = " & SqlInteiro(seqNFe))
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em FinalizarSemSucesso EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Sub

        ' Resultado de uma consulta da chave na SEFAZ (nota que ja estava autorizada,
        ' ou cancelada). Campos vazios nao apagam o que ja estava gravado.
        Public Sub AtualizarPelaConsulta(ByVal seqNFe As Integer, ByVal situacao As String, ByVal cStat As Nullable(Of Integer),
                                         ByVal mensagem As String, ByVal protocolo As String,
                                         ByVal dataAutorizacao As Nullable(Of DateTime), ByVal caminhoXml As String)
            Dim acessoBanco As New cAcessoBD

            Try
                acessoBanco.ExecutarINT(
                    " UPDATE basennf SET " &
                    "        situacao = " & SqlTexto(situacao) & ", " &
                    "        cStat = " & SqlInteiro(cStat) & ", " &
                    "        mensagem = " & SqlTexto(mensagem) & ", " &
                    "        protocolo = IFNULL(" & SqlTexto(protocolo) & ", protocolo), " &
                    "        dataAutorizacao = IFNULL(" & SqlDataHora(dataAutorizacao) & ", dataAutorizacao), " &
                    "        caminhoXml = IFNULL(" & SqlTexto(caminhoXml) & ", caminhoXml), " &
                    "        dataAtualizacao = NOW() " &
                    "  WHERE seqNFe = " & SqlInteiro(seqNFe))
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em AtualizarPelaConsulta EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Sub

        ' Reemissao: "pega" o numero para este computador. So consegue se ele
        ' ainda estiver com falha/rejeitado (ou interrompido ha mais de
        ' minutosTravada) - dois terminais nunca reemitem o mesmo numero juntos.
        Public Function Assumir(ByVal seqNFe As Integer, ByVal dados As dEmissaoNFCe, ByVal minutosTravada As Integer) As Boolean
            Dim acessoBanco As New cAcessoBD

            Try
                Return acessoBanco.ExecutarINT(
                    " UPDATE basennf SET " &
                    "        situacao = 'E', " &
                    "        dataEmissao = NOW(), " &
                    "        dataAtualizacao = NOW(), " &
                    "        tentativas = tentativas + 1, " &
                    "        cStat = NULL, " &
                    "        mensagem = 'Reemissão em andamento.', " &
                    "        cpfConsumidor = " & SqlTexto(dados.cpfConsumidor) & ", " &
                    "        terminal = " & SqlTexto(dados.terminal) & ", " &
                    "        computador = " & SqlTexto(dados.computador) & ", " &
                    "        usuario_cid = " & SqlInteiro(dados.usuario_cid) & ", " &
                    "        usuarioNome = " & SqlTexto(dados.usuarioNome) &
                    "  WHERE seqNFe = " & SqlInteiro(seqNFe) &
                    "    AND controle IS NOT NULL " &
                    "    AND ( situacao IN ('F', 'R') " &
                    "          OR ( situacao = 'E' AND IFNULL(dataAtualizacao, IFNULL(dataEmissao, '1900-01-01')) " &
                    "                                  < DATE_SUB(NOW(), INTERVAL " & minutosTravada.ToString(CultureInfo.InvariantCulture) & " MINUTE) ) ) ") > 0
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Assumir EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        ' Numero que nao pode ser reaproveitado (SEFAZ recusou por duplicidade):
        ' passa para "substituida" - com a mesma trava do Assumir (um computador por vez).
        ' Mantem a data e o motivo originais.
        Public Function Substituir(ByVal seqNFe As Integer, ByVal minutosTravada As Integer) As Boolean
            Dim acessoBanco As New cAcessoBD

            Try
                Return acessoBanco.ExecutarINT(
                    " UPDATE basennf SET " &
                    "        situacao = 'S', " &
                    "        dataAtualizacao = NOW() " &
                    "  WHERE seqNFe = " & SqlInteiro(seqNFe) &
                    "    AND controle IS NOT NULL " &
                    "    AND ( situacao IN ('F', 'R') " &
                    "          OR ( situacao = 'E' AND IFNULL(dataAtualizacao, IFNULL(dataEmissao, '1900-01-01')) " &
                    "                                  < DATE_SUB(NOW(), INTERVAL " & minutosTravada.ToString(CultureInfo.InvariantCulture) & " MINUTE) ) ) ") > 0
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Substituir EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        ' Liga o numero substituido ao numero novo
        Public Sub LigarSubstituta(ByVal seqAntigo As Integer, ByVal seqNovo As Integer)
            Dim acessoBanco As New cAcessoBD

            Try
                acessoBanco.ExecutarINT(
                    " UPDATE basennf SET " &
                    "        substituidaPor = " & SqlInteiro(seqNovo) & ", " &
                    "        mensagem = CONCAT(IFNULL(mensagem, ''), ' Reemitida com o número " & seqNovo.ToString(CultureInfo.InvariantCulture) & ".'), " &
                    "        dataAtualizacao = NOW() " &
                    "  WHERE seqNFe = " & SqlInteiro(seqAntigo))
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em LigarSubstituta EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Sub

        ' Cancelamento homologado (tela de Consulta de Caixa)
        Public Sub MarcarCancelada(ByVal chave As String, ByVal mensagem As String)
            Dim acessoBanco As New cAcessoBD

            Try
                acessoBanco.ExecutarINT(
                    " UPDATE basennf SET " &
                    "        situacao = 'C', " &
                    "        mensagem = " & SqlTexto(mensagem) & ", " &
                    "        dataAtualizacao = NOW() " &
                    "  WHERE chnfe = " & SqlTexto(chave))
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em MarcarCancelada EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Sub

        Public Sub GravarChaveNaVenda(ByVal controle As Integer, ByVal chave As String)
            Dim acessoBanco As New cAcessoBD

            Try
                acessoBanco.ExecutarINT(" UPDATE vendas SET chave = " & SqlTexto(chave) &
                                        "  WHERE controle = " & SqlInteiro(controle))
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em GravarChaveNaVenda EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Sub

        ' Emissoes do periodo (numeros da basennf) + vendas que ficaram sem NFC-e
        ' e sem numero ligado (falhas antigas). Mais recente primeiro.
        Public Function Listar(ByVal dataInicial As DateTime, ByVal dataFinal As DateTime) As ColecaoEmissaoNFCe
            Dim inicio As String = SqlDataHora(dataInicial.Date)
            Dim fim As String = SqlDataHora(dataFinal.Date.AddDays(1))   ' data final inclusiva

            Dim retorno As ColecaoEmissaoNFCe = Consultar(
                " WHERE COALESCE(b.dataEmissao, v.data) >= " & inicio &
                "   AND COALESCE(b.dataEmissao, v.data) < " & fim)

            retorno.AddRange(VendasSemNota(inicio, fim))
            retorno.Sort(Function(a, b) Comparar(a, b))
            Return retorno
        End Function

        Public Function Consultar(ByVal seqNFe As Integer) As dEmissaoNFCe
            Dim lista As ColecaoEmissaoNFCe = Consultar(" WHERE b.seqNFe = " & SqlInteiro(seqNFe))
            Return If(lista.Count = 0, Nothing, lista(0))
        End Function

        ' Numero mais recente usado por uma venda
        Public Function UltimaDaVenda(ByVal controle As Integer) As dEmissaoNFCe
            Dim lista As ColecaoEmissaoNFCe = Consultar(" WHERE b.controle = " & SqlInteiro(controle) & " ORDER BY b.seqNFe DESC LIMIT 1 ")
            Return If(lista.Count = 0, Nothing, lista(0))
        End Function

        ' Itens da venda no formato que a emissao usa (com a aliquota do produto)
        Public Function ItensDaVenda(ByVal controle As Integer) As ColecaoVendaProduto
            Dim retorno As New ColecaoVendaProduto
            Dim acessoBanco As New cAcessoBD
            Dim ds As DataSet

            Try
                ds = acessoBanco.ExecutarDS(
                    " SELECT v.controle, v.produto, v.item, v.quantidade, v.valor, p.descricao, p.referencia, p.aliquota, " &
                    "        (SELECT pi.valor FROM produtoitem pi " &
                    "          WHERE pi.produtos_cid = v.produto AND pi.item = v.item AND pi.caracteristicas_cid = 1 LIMIT 1) AS codigobarras " &
                    "   FROM vendasprodutos v " &
                    "  INNER JOIN produtos p ON p.cid = v.produto " &
                    "  WHERE v.controle = " & SqlInteiro(controle) &
                    "  ORDER BY v.produto, v.item ")

                If ds Is Nothing OrElse ds.Tables.Count = 0 Then
                    Return retorno
                End If

                For Each row As DataRow In ds.Tables(0).Rows
                    Dim item As New dVendaProduto
                    item.controle = CInt(LerDecimal(row("controle")))
                    item.produtoId = CInt(LerDecimal(row("produto")))
                    item.itemId = CInt(LerDecimal(row("item")))
                    item.quantidade = LerDecimal(row("quantidade"))
                    item.valor = LerDecimal(row("valor"))
                    item.descricao = LerTexto(row("descricao"))
                    item.referencia = LerTexto(row("referencia"))
                    item.aliquota = LerTexto(row("aliquota"))
                    item.codigobarras = LerTexto(row("codigobarras"))
                    retorno.Add(item)
                Next

            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em ItensDaVenda EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try

            Return retorno
        End Function

        Public Function PagamentosDaVenda(ByVal controle As Integer) As dPagamentoVendaNFCe
            Dim acessoBanco As New cAcessoBD
            Dim ds As DataSet

            Try
                ds = acessoBanco.ExecutarDS(
                    " SELECT controle, data, total, dinheiro, troco, Original, cheque, chequePre, cartaoDebito, cartaoCredito, " &
                    "        crediario, troca, desconto, vale, defeito, terminal, chave " &
                    "   FROM vendas WHERE controle = " & SqlInteiro(controle))

                If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                    Return Nothing
                End If

                Dim row As DataRow = ds.Tables(0).Rows(0)
                Dim item As New dPagamentoVendaNFCe
                item.controle = CInt(LerDecimal(row("controle")))
                item.data = LerData(row("data")).GetValueOrDefault()
                item.total = LerDecimal(row("total"))
                item.dinheiro = LerDecimal(row("dinheiro"))
                item.troco = LerDecimal(row("troco"))
                item.pix = LerDecimal(row("Original"))      ' o PIX e gravado na coluna "Original"
                item.cheque = LerDecimal(row("cheque"))
                item.chequePre = LerDecimal(row("chequePre"))
                item.cartaoDebito = LerDecimal(row("cartaoDebito"))
                item.cartaoCredito = LerDecimal(row("cartaoCredito"))
                item.crediario = LerDecimal(row("crediario"))
                item.troca = LerDecimal(row("troca"))
                item.desconto = LerDecimal(row("desconto"))
                item.vale = LerDecimal(row("vale"))
                item.defeito = LerDecimal(row("defeito"))
                item.terminal = LerTexto(row("terminal"))
                item.chave = LerTexto(row("chave"))
                Return item

            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em PagamentosDaVenda EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        Private Function Consultar(ByVal complemento As String) As ColecaoEmissaoNFCe
            Dim retorno As New ColecaoEmissaoNFCe
            Dim acessoBanco As New cAcessoBD
            Dim ds As DataSet

            Try
                ds = acessoBanco.ExecutarDS(
                    " SELECT b.seqNFe, b.chnfe, b.controle, b.dataEmissao, v.data AS dataVenda, " & SQL_SITUACAO & " AS situacao, " &
                    "        b.cStat, b.mensagem, b.protocolo, b.dataAutorizacao, b.caminhoXml, b.cpfConsumidor, " &
                    "        COALESCE(b.valor, v.total) AS valor, COALESCE(b.terminal, v.terminal) AS terminal, b.computador, " &
                    "        b.usuario_cid, b.usuarioNome, b.tentativas, b.substituidaPor, b.dataAtualizacao " &
                    "   FROM basennf b " &
                    "   LEFT JOIN vendas v ON v.controle = b.controle " & complemento)

                If ds Is Nothing OrElse ds.Tables.Count = 0 Then
                    Return retorno
                End If

                For Each row As DataRow In ds.Tables(0).Rows
                    Dim item As New dEmissaoNFCe
                    item.origem = "N"
                    item.seqNFe = LerInteiro(row("seqNFe"))
                    item.chave = LerTexto(row("chnfe"))
                    item.controle = LerInteiro(row("controle"))
                    item.dataEmissao = LerData(row("dataEmissao"))
                    item.dataVenda = LerData(row("dataVenda"))
                    item.situacao = LerTexto(row("situacao"))
                    item.cStat = LerInteiro(row("cStat"))
                    item.mensagem = LerTexto(row("mensagem"))
                    item.protocolo = LerTexto(row("protocolo"))
                    item.dataAutorizacao = LerData(row("dataAutorizacao"))
                    item.caminhoXml = LerTexto(row("caminhoXml"))
                    item.cpfConsumidor = LerTexto(row("cpfConsumidor"))
                    If Not IsDBNull(row("valor")) Then
                        item.valor = LerDecimal(row("valor"))
                    End If
                    item.terminal = LerTexto(row("terminal"))
                    item.computador = LerTexto(row("computador"))
                    item.usuario_cid = LerInteiro(row("usuario_cid"))
                    item.usuarioNome = LerTexto(row("usuarioNome"))
                    item.tentativas = LerInteiro(row("tentativas")).GetValueOrDefault(1)
                    item.substituidaPor = LerInteiro(row("substituidaPor"))
                    item.dataAtualizacao = LerData(row("dataAtualizacao"))
                    retorno.Add(item)
                Next

            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Consultar EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try

            Return retorno
        End Function

        ' Vendas marcadas sem nota que nao tem nenhum numero ligado a elas
        Private Function VendasSemNota(ByVal inicio As String, ByVal fim As String) As ColecaoEmissaoNFCe
            Dim retorno As New ColecaoEmissaoNFCe
            Dim acessoBanco As New cAcessoBD
            Dim ds As DataSet

            Try
                ds = acessoBanco.ExecutarDS(
                    " SELECT v.controle, v.data, v.total, v.terminal " &
                    "   FROM vendas v " &
                    "  WHERE v.chave IN ('FALHA_EMISSAO', 'temporario') " &
                    "    AND v.data >= " & inicio & " AND v.data < " & fim &
                    "    AND NOT EXISTS (SELECT 1 FROM basennf b WHERE b.controle = v.controle) ")

                If ds Is Nothing OrElse ds.Tables.Count = 0 Then
                    Return retorno
                End If

                For Each row As DataRow In ds.Tables(0).Rows
                    Dim item As New dEmissaoNFCe
                    item.origem = "V"
                    item.situacao = "F"
                    item.controle = LerInteiro(row("controle"))
                    item.dataVenda = LerData(row("data"))
                    item.valor = LerDecimal(row("total"))
                    item.terminal = LerTexto(row("terminal"))
                    item.mensagem = "Venda registrada sem NFC-e (falha anterior ao histórico, sem número ligado)."
                    item.tentativas = 1
                    retorno.Add(item)
                Next

            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em VendasSemNota EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try

            Return retorno
        End Function

        Private Shared Function Comparar(ByVal a As dEmissaoNFCe, ByVal b As dEmissaoNFCe) As Integer
            Dim da As DateTime = a.dataReferencia.GetValueOrDefault(DateTime.MinValue)
            Dim db As DateTime = b.dataReferencia.GetValueOrDefault(DateTime.MinValue)
            Dim r As Integer = db.CompareTo(da)
            If r <> 0 Then
                Return r
            End If
            Return b.seqNFe.GetValueOrDefault(0).CompareTo(a.seqNFe.GetValueOrDefault(0))
        End Function

        Private Shared Function SqlTexto(ByVal valor As String) As String
            If valor Is Nothing OrElse valor.Trim().Length = 0 Then
                Return "NULL"
            End If
            Return "'" & valor.Trim().Replace("\", "\\").Replace("'", "''") & "'"
        End Function

        Private Shared Function SqlInteiro(ByVal valor As Nullable(Of Integer)) As String
            If Not valor.HasValue Then
                Return "NULL"
            End If
            Return valor.Value.ToString(CultureInfo.InvariantCulture)
        End Function

        Private Shared Function SqlDecimal(ByVal valor As Nullable(Of Decimal)) As String
            If Not valor.HasValue Then
                Return "NULL"
            End If
            Return valor.Value.ToString("0.00", CultureInfo.InvariantCulture)
        End Function

        Private Shared Function SqlDataHora(ByVal valor As Nullable(Of DateTime)) As String
            If Not valor.HasValue Then
                Return "NULL"
            End If
            Return "'" & valor.Value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "'"
        End Function

        Private Shared Function LerTexto(ByVal valor As Object) As String
            If valor Is Nothing OrElse IsDBNull(valor) Then
                Return ""
            End If
            Return valor.ToString()
        End Function

        Private Shared Function LerInteiro(ByVal valor As Object) As Nullable(Of Integer)
            If valor Is Nothing OrElse IsDBNull(valor) Then
                Return Nothing
            End If
            Return Convert.ToInt32(valor, CultureInfo.InvariantCulture)
        End Function

        Private Shared Function LerDecimal(ByVal valor As Object) As Decimal
            If valor Is Nothing OrElse IsDBNull(valor) Then
                Return 0D
            End If
            Return Convert.ToDecimal(valor, CultureInfo.InvariantCulture)
        End Function

        Private Shared Function LerData(ByVal valor As Object) As Nullable(Of DateTime)
            If valor Is Nothing OrElse IsDBNull(valor) Then
                Return Nothing
            End If
            Try
                Return Convert.ToDateTime(valor, CultureInfo.InvariantCulture)
            Catch
                ' "Allow Zero Datetime" devolve MySqlDateTime: vai pelo texto
                Dim d As DateTime
                If DateTime.TryParse(valor.ToString(), d) Then
                    Return d
                End If
                Return Nothing
            End Try
        End Function

    End Class

End Namespace
