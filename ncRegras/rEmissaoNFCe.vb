Imports ncDados.nsNFCe
Imports ncDados.nsVenda
Imports ncPersistencia.nsNFCe
Imports ncComum.nsExcecao

Namespace nsNFCe

    ' Regras do historico de emissao da NFC-e (tabela basennf + script 44).
    '
    ' Os metodos "Tentar..." sao os usados DURANTE a venda (tela de Pagamento):
    ' o historico nunca pode atrapalhar a venda nem a emissao, entao um erro ao
    ' gravar o historico e engolido ali. O resto (relatorio, reemissao) lanca
    ' ExcecaoNascomercio normalmente.
    Public Class rEmissaoNFCe

        Private Const TamanhoMensagem As Integer = 1000

        ' Depois que o script 44 foi aplicado nao precisa conferir de novo
        Private Shared historicoConfirmado As Boolean = False

        Public Function HistoricoDisponivel() As Boolean
            If historicoConfirmado Then
                Return True
            End If
            Try
                historicoConfirmado = New pEmissaoNFCe().HistoricoDisponivel()
                Return historicoConfirmado
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em HistoricoDisponivel EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        ' Proximo numero da NFC-e para a venda. Devolve 0 quando o historico nao
        ' existe neste banco (script 44 nao aplicado) ou deu erro ao gravar - a
        ' tela de Pagamento entao pega o numero do jeito antigo.
        Public Function TentarReservar(ByVal controle As Integer, ByVal valor As Decimal, ByVal cpf As String,
                                       ByVal terminal As String, ByVal computador As String,
                                       ByVal usuario_cid As Nullable(Of Integer), ByVal usuarioNome As String) As Integer
            Try
                If Not HistoricoDisponivel() Then
                    Return 0
                End If
                Dim dados As New dEmissaoNFCe
                dados.controle = controle
                dados.valor = valor
                dados.cpfConsumidor = SomenteDigitos(cpf)
                dados.terminal = terminal
                dados.computador = computador
                dados.usuario_cid = usuario_cid
                dados.usuarioNome = usuarioNome
                Return New pEmissaoNFCe().Reservar(dados)
            Catch
                Return 0
            End Try
        End Function

        Public Sub TentarRegistrarChave(ByVal seqNFe As Integer, ByVal chave As String, ByVal caminhoXml As String)
            Try
                If seqNFe > 0 AndAlso Not String.IsNullOrEmpty(chave) Then
                    Call New pEmissaoNFCe().RegistrarChave(seqNFe, chave, caminhoXml)
                End If
            Catch
                ' historico nao pode atrapalhar a emissao
            End Try
        End Sub

        Public Sub TentarFinalizarAutorizada(ByVal seqNFe As Integer, ByVal chave As String, ByVal caminhoXml As String)
            Try
                If seqNFe > 0 Then
                    Call New pEmissaoNFCe().FinalizarAutorizada(seqNFe, chave, caminhoXml)
                End If
            Catch
                ' historico nao pode atrapalhar a emissao
            End Try
        End Sub

        ' rejeitada = a SEFAZ respondeu e recusou (R); senao e falha (F)
        Public Sub TentarFinalizarSemSucesso(ByVal seqNFe As Integer, ByVal rejeitada As Boolean, ByVal cStat As Nullable(Of Integer),
                                             ByVal mensagem As String, ByVal chave As String, ByVal caminhoXml As String)
            Try
                If seqNFe > 0 Then
                    Call New pEmissaoNFCe().FinalizarSemSucesso(seqNFe, If(rejeitada, "R", "F"), cStat, Cortar(mensagem),
                                                            If(dEmissaoNFCe.ChaveValida(chave), chave, Nothing), caminhoXml)
                End If
            Catch
                ' historico nao pode atrapalhar a emissao
            End Try
        End Sub

        Public Sub TentarMarcarCancelada(ByVal chave As String, ByVal mensagem As String)
            Try
                If dEmissaoNFCe.ChaveValida(chave) AndAlso HistoricoDisponivel() Then
                    Call New pEmissaoNFCe().MarcarCancelada(chave, Cortar(mensagem))
                End If
            Catch
                ' o cancelamento ja foi feito na SEFAZ; o historico e secundario
            End Try
        End Sub

        ' ---------------------------------------------------------------------
        ' Relatorio e reemissao
        ' ---------------------------------------------------------------------

        Public Function Listar(ByVal dataInicial As DateTime, ByVal dataFinal As DateTime, ByVal situacao As String) As ColecaoEmissaoNFCe
            Try
                Dim lista As ColecaoEmissaoNFCe = New pEmissaoNFCe().Listar(dataInicial, dataFinal)
                If String.IsNullOrEmpty(situacao) Then
                    Return lista
                End If

                ' mesmos codigos do relatorio (dEmissaoNFCe.AtendeFiltro)
                Dim filtrada As New ColecaoEmissaoNFCe
                For Each item As dEmissaoNFCe In lista
                    If item.AtendeFiltro(situacao) Then
                        filtrada.Add(item)
                    End If
                Next
                Return filtrada
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Listar EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        Public Function Consultar(ByVal seqNFe As Integer) As dEmissaoNFCe
            Try
                Return New pEmissaoNFCe().Consultar(seqNFe)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Consultar EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        Public Function UltimaDaVenda(ByVal controle As Integer) As dEmissaoNFCe
            Try
                Return New pEmissaoNFCe().UltimaDaVenda(controle)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em UltimaDaVenda EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        Public Function ItensDaVenda(ByVal controle As Integer) As ColecaoVendaProduto
            Try
                Return New pEmissaoNFCe().ItensDaVenda(controle)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em ItensDaVenda EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        Public Function PagamentosDaVenda(ByVal controle As Integer) As dPagamentoVendaNFCe
            Try
                Return New pEmissaoNFCe().PagamentosDaVenda(controle)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em PagamentosDaVenda EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        ' Novo numero para reemitir uma venda (quando o numero antigo nao pode ser reaproveitado)
        Public Function Reservar(ByVal dados As dEmissaoNFCe) As Integer
            Try
                dados.cpfConsumidor = SomenteDigitos(dados.cpfConsumidor)
                Return New pEmissaoNFCe().Reservar(dados)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Reservar EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        ' Reemissao no mesmo numero: so um computador por vez consegue
        Public Function Assumir(ByVal seqNFe As Integer, ByVal dados As dEmissaoNFCe) As Boolean
            Try
                dados.cpfConsumidor = SomenteDigitos(dados.cpfConsumidor)
                Return New pEmissaoNFCe().Assumir(seqNFe, dados, dEmissaoNFCe.MinutosEmissaoTravada)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Assumir EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        ' Numero recusado por duplicidade: vira "substituida" (so um computador por vez)
        Public Function Substituir(ByVal seqNFe As Integer) As Boolean
            Try
                Return New pEmissaoNFCe().Substituir(seqNFe, dEmissaoNFCe.MinutosEmissaoTravada)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Substituir EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        Public Sub LigarSubstituta(ByVal seqAntigo As Integer, ByVal seqNovo As Integer)
            Try
                Call New pEmissaoNFCe().LigarSubstituta(seqAntigo, seqNovo)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em LigarSubstituta EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Sub

        Public Sub AtualizarPelaConsulta(ByVal seqNFe As Integer, ByVal situacao As String, ByVal cStat As Nullable(Of Integer),
                                         ByVal mensagem As String, ByVal protocolo As String,
                                         ByVal dataAutorizacao As Nullable(Of DateTime), ByVal caminhoXml As String)
            Try
                Call New pEmissaoNFCe().AtualizarPelaConsulta(seqNFe, situacao, cStat, Cortar(mensagem), protocolo, dataAutorizacao, caminhoXml)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em AtualizarPelaConsulta EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Sub

        Public Sub GravarChaveNaVenda(ByVal controle As Integer, ByVal chave As String)
            Try
                Call New pEmissaoNFCe().GravarChaveNaVenda(controle, chave)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em GravarChaveNaVenda EmissaoNFCe [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Sub

        Public Shared Function SomenteDigitos(ByVal texto As String) As String
            If String.IsNullOrEmpty(texto) Then
                Return ""
            End If
            Dim sb As New System.Text.StringBuilder()
            For Each c As Char In texto
                If Char.IsDigit(c) Then
                    sb.Append(c)
                End If
            Next
            Return sb.ToString()
        End Function

        Private Shared Function Cortar(ByVal texto As String) As String
            If texto Is Nothing Then
                Return Nothing
            End If
            texto = texto.Replace(vbCr, " ").Replace(vbLf, " ").Trim()
            If texto.Length > TamanhoMensagem Then
                Return texto.Substring(0, TamanhoMensagem)
            End If
            Return texto
        End Function

    End Class

End Namespace
