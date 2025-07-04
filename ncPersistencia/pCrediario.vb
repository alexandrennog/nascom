Imports ncDados.nsCrediario
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCrediario

    Public Class pCrediario

        Public Function Listar() As ColecaoCrediario

            Dim retorno As ColecaoCrediario
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dCrediario
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " Select cid, controle, usuarioId, clienteId, " & _
                             "parcelas, valortotal, valorpago, saldodevedor, dataVenda From crediario"

                ds = acessoBanco.ExecutarDS(comandoSQL)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoCrediario

                            For Each row In dt.Rows
                                item = New dCrediario

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.controle = cFuncoes.RetornarInteiro(row("controle"))
                                item.ValorTotal = cFuncoes.PersistirDecimal(row("valortotal"))
                                item.ValorTotal = cFuncoes.PersistirDecimal(row("valorpago"))
                                item.ValorTotal = cFuncoes.PersistirDecimal(row("saldodevedor"))
                                item.usuarioId = cFuncoes.RetornarInteiro(row("usuarioId"))
                                item.clienteId = cFuncoes.RetornarInteiro(row("clienteId"))
                                item.Parcelas = cFuncoes.PersistirInteiro(row("parcelas"))
                                item.DataVenda = cFuncoes.RetornarData(row("dataVenda"))

                                retorno.Add(item)
                            Next
                        Else
                            retorno = Nothing
                        End If
                    Else
                        retorno = Nothing
                    End If
                Else
                    retorno = Nothing
                End If

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Listar Crediário [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Listar = retorno

        End Function

        Public Function ConsultarMax() As Integer

            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim sqlSelect As String
            Dim sqlFrom As String
            Dim retorno As Integer

            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " Select MAX(controle) as controle"
                sqlFrom = " From crediario "

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then

                            For Each row In dt.Rows
                                retorno = IIf(row("controle") Is DBNull.Value, 0, cFuncoes.RetornarInteiro(row("controle")))
                            Next
                        Else
                            retorno = Nothing
                        End If
                    Else
                        retorno = Nothing
                    End If
                Else
                    retorno = Nothing
                End If

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em ConsultarMax Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function Consultar(ByVal dados As dCrediario) As ColecaoCrediario

            Dim retorno As ColecaoCrediario
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dCrediario
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String


            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " Select cid, controle, usuarioId, clienteId, " & _
                             "parcelas, valortotal, valorpago, saldodevedor, dataVenda "

                sqlWhere = String.Empty
                sqlFrom = " From crediario "

                '-- cid
                If dados.cid <> 0 Then
                    sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")
                End If

                '-- controle
                If dados.controle <> 0 Then
                    sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.controle, "controle")
                End If

                '-- usuarioId
                If dados.usuarioId <> 0 Then
                    sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.usuarioId, "usuarioId")
                End If

                '-- clienteId
                If dados.clienteId <> 0 Then
                    sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.clienteId, "clienteId")
                End If

                '-- saldo devedor
                If dados.SaldoDevedor > 0.001 Then
                    If Not sqlWhere.Equals(String.Empty) Then
                        sqlWhere += " AND saldodevedor > 0.001 "
                    Else
                        sqlWhere = " saldodevedor > 0.001 "
                    End If
                End If

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " order by year(dataVenda), month(dataVenda)")

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoCrediario

                            For Each row In dt.Rows
                                item = New dCrediario

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.controle = cFuncoes.RetornarInteiro(row("controle"))
                                item.usuarioId = cFuncoes.RetornarInteiro(row("usuarioId"))
                                item.clienteId = cFuncoes.RetornarInteiro(row("clienteId"))
                                item.Parcelas = cFuncoes.RetornarInteiro(row("parcelas"))
                                item.ValorTotal = cFuncoes.RetornarDecimal(row("valortotal"))
                                item.ValorPago = cFuncoes.RetornarDecimal(row("valorpago"))
                                item.SaldoDevedor = cFuncoes.RetornarDecimal(row("saldodevedor"))
                                item.DataVenda = cFuncoes.RetornarData(row("dataVenda"))

                                retorno.Add(item)
                            Next
                        Else
                            retorno = Nothing
                        End If
                    Else
                        retorno = Nothing
                    End If
                Else
                    retorno = Nothing
                End If

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Crediario[" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function Incluir(ByVal dados As dCrediario) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " INSERT INTO " & _
                    " crediario (controle, usuarioId, clienteId, observacao, " & _
                             "parcelas, valortotal, valorpago, saldodevedor, dataVenda, loja_cid, terminal) " & _
                    " VALUES (" & _
                            cFuncoes.PersistirTexto(dados.controle) & "," & _
                            cFuncoes.PersistirTexto(dados.usuarioId) & "," & _
                            cFuncoes.PersistirTexto(dados.clienteId) & "," & _
                            cFuncoes.PersistirTexto(dados.NotaFiscal) & "," & _
                            cFuncoes.PersistirInteiro(dados.Parcelas) & "," & _
                            cFuncoes.PersistirDecimal(dados.ValorTotal) & "," & _
                            cFuncoes.PersistirDecimal(dados.ValorPago) & "," & _
                            cFuncoes.PersistirDecimal(dados.SaldoDevedor) & "," & _
                            cFuncoes.PersistirData(dados.DataVenda) & "," & _
                            cFuncoes.PersistirInteiro(dados.LojaId) & "," & _
                            cFuncoes.PersistirTexto(dados.Terminal) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Crediario [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dCrediario) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " UPDATE crediario SET " & _
                    " controle = " & cFuncoes.PersistirInteiro(dados.controle) & "," & _
                    " usuarioId = " & cFuncoes.PersistirTexto(dados.usuarioId) & "," & _
                    " clienteId = " & cFuncoes.PersistirTexto(dados.clienteId) & "," & _
                    " parcelas = " & cFuncoes.PersistirInteiro(dados.Parcelas) & "," & _
                    " valortotal = " & cFuncoes.PersistirDecimal(dados.ValorTotal) & "," & _
                    " valorpago = " & cFuncoes.PersistirDecimal(dados.ValorPago) & "," & _
                    " dataVenda = " & cFuncoes.PersistirData(dados.DataVenda) & "," & _
                    " saldodevedor = " & cFuncoes.PersistirDecimal(dados.SaldoDevedor) & _
                    " WHERE " & _
                    " cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar crediario [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

        Public Function AlterarControle(ByVal dados As dCrediario) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " UPDATE crediario SET " & _
                    " controle = " & cFuncoes.PersistirInteiro(dados.controle) & _
                    " WHERE " & _
                    " controle = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar crediario [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function Excluir(ByVal dados As dCrediario) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM crediario " & _
                    " WHERE cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir crediario [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Excluir = retorno

        End Function


        Public Function ExcluirParcelas(ByVal dados As dCrediario) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM parcelas " & _
                    " WHERE crediarioid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir crediario [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

    End Class


End Namespace
