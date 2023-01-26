Imports ncDados.nsVenda
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsVenda

    Public Class pPreVenda

        Public Function Listar() As ColecaoVenda

            Dim retorno As ColecaoVenda
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dVenda
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " Select controle, usuarioId, clienteId, data, " &
                             "dinheiro, cheque, chequepre, cartaodebito, cartaocredito, crediario, terminal, " &
                             "parcelas, desconto, condicao, troca, vale, defeito, total, Original From prevendas"

                ds = acessoBanco.ExecutarDS(comandoSQL)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoVenda

                            For Each row In dt.Rows
                                item = New dVenda

                                item.controle = cFuncoes.RetornarInteiro(row("controle"))
                                item.usuarioId = cFuncoes.RetornarInteiro(row("usuarioId"))
                                item.clienteId = cFuncoes.RetornarInteiro(row("clienteId"))
                                item.Data = cFuncoes.RetornarData(row("data"))
                                item.Dinheiro = cFuncoes.RetornarDecimal(row("dinheiro"))
                                item.Pix = cFuncoes.RetornarDecimal(row("Original"))
                                item.Cheque = cFuncoes.RetornarDecimal(row("cheque"))
                                item.ChequePre = cFuncoes.RetornarDecimal(row("chequepre"))
                                item.CartaoDebito = cFuncoes.RetornarDecimal(row("cartaodedito"))
                                item.CartaoCredito = cFuncoes.RetornarDecimal(row("cartaocredito"))
                                item.Crediario = cFuncoes.RetornarDecimal(row("crediario"))
                                item.Terminal = cFuncoes.RetornarTexto(row("terminal"))
                                item.Parcelas = cFuncoes.RetornarInteiro(row("parcelas"))
                                item.Desconto = cFuncoes.RetornarDecimal(row("desconto"))
                                item.Condicao = cFuncoes.RetornarInteiro(row("condicao"))
                                item.Troca = cFuncoes.RetornarDecimal(row("troca"))
                                item.Vale = cFuncoes.RetornarDecimal(row("vale"))
                                item.Defeito = cFuncoes.RetornarDecimal(row("defeito"))
                                item.Total = cFuncoes.RetornarDecimal(row("total"))

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
                Throw New ExcecaoNascomercio("Erro em Listar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dVenda) As ColecaoVenda

            Dim retorno As ColecaoVenda
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dVenda
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String


            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " Select controle, usuarioId, clienteId, data, vendedor, " &
                             "dinheiro, cheque, chequepre, cartaodebito, cartaocredito, crediario, terminal, " &
                             "parcelas, desconto, condicao, troca, vale, defeito, total, vendedor, ordemservico, Original "

                sqlWhere = String.Empty
                sqlFrom = " From prevendas "

                '-- controle
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.controle, "controle")

                '-- usuarioId
                If dados.Terminal <> "" Then
                    sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.Terminal, "terminal")
                End If

                '-- clienteId
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.clienteId, "clienteId")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoVenda

                            For Each row In dt.Rows
                                item = New dVenda

                                item.controle = cFuncoes.RetornarInteiro(row("controle"))
                                item.usuarioId = cFuncoes.RetornarInteiro(row("usuarioId"))
                                item.clienteId = cFuncoes.RetornarInteiro(row("clienteId"))
                                item.Vendedor = cFuncoes.RetornarTexto(row("vendedor"))
                                item.Data = cFuncoes.RetornarData(row("data"))
                                item.Dinheiro = cFuncoes.RetornarDecimal(row("dinheiro"))
                                item.Pix = cFuncoes.RetornarDecimal(row("Original"))
                                item.Cheque = cFuncoes.RetornarDecimal(row("cheque"))
                                item.ChequePre = cFuncoes.RetornarDecimal(row("chequepre"))
                                item.CartaoDebito = cFuncoes.RetornarDecimal(row("cartaodebito"))
                                item.CartaoCredito = cFuncoes.RetornarDecimal(row("cartaocredito"))
                                item.Crediario = cFuncoes.RetornarDecimal(row("crediario"))
                                item.Terminal = cFuncoes.RetornarTexto(row("terminal"))
                                item.Parcelas = cFuncoes.RetornarInteiro(row("parcelas"))
                                item.Desconto = cFuncoes.RetornarDecimal(row("desconto"))
                                item.Condicao = cFuncoes.RetornarInteiro(row("condicao"))
                                item.Troca = cFuncoes.RetornarDecimal(row("troca"))
                                item.Vale = cFuncoes.RetornarDecimal(row("vale"))
                                item.Defeito = cFuncoes.RetornarDecimal(row("defeito"))
                                item.Total = cFuncoes.RetornarDecimal(row("total"))
                                item.Vendedor = cFuncoes.RetornarTexto(row("vendedor"))
                                item.ordemServicoId = cFuncoes.RetornarTexto(row("ordemservico"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Consultar = retorno

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
                sqlFrom = " From prevendas "

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

            ConsultarMax = retorno

        End Function

        Public Function Incluir(ByVal dados As dVenda) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " INSERT INTO " &
                    " prevendas (controle, usuarioId, clienteId, data, " &
                             "dinheiro, cheque, chequepre, cartaodebito, cartaocredito, crediario, terminal, ordemServico, " &
                             "parcelas, desconto, condicao, troca, vale, defeito, total, Original) " &
                    " VALUES (" &
                            cFuncoes.PersistirInteiro(dados.controle) & "," &
                            cFuncoes.PersistirInteiro(dados.usuarioId) & "," &
                            cFuncoes.PersistirInteiro(dados.clienteId) & "," &
                            cFuncoes.PersistirData(dados.Data) & "," &
                            cFuncoes.PersistirDecimal(dados.Dinheiro) & "," &
                            cFuncoes.PersistirDecimal(dados.Cheque) & "," &
                            cFuncoes.PersistirDecimal(dados.ChequePre) & "," &
                            cFuncoes.PersistirDecimal(dados.CartaoDebito) & "," &
                            cFuncoes.PersistirDecimal(dados.CartaoCredito) & "," &
                            cFuncoes.PersistirDecimal(dados.Crediario) & "," &
                            cFuncoes.PersistirTexto(dados.Terminal) & "," &
                            cFuncoes.PersistirTexto(dados.ordemServicoId) & "," &
                            cFuncoes.PersistirInteiro(dados.Parcelas) & "," &
                            cFuncoes.PersistirDecimal(dados.Desconto) & "," &
                            cFuncoes.PersistirInteiro(dados.Condicao) & "," &
                            cFuncoes.PersistirDecimal(dados.Troca) & "," &
                            cFuncoes.PersistirDecimal(dados.Vale) & "," &
                            cFuncoes.PersistirDecimal(dados.Defeito) & "," &
                            cFuncoes.PersistirDecimal(dados.Total) & "," &
                            cFuncoes.PersistirDecimal(dados.Pix) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dVenda) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " UPDATE prevendas SET " &
                    " usuarioId = " & cFuncoes.PersistirTexto(dados.usuarioId) & "," &
                    " clienteId = " & cFuncoes.PersistirTexto(dados.clienteId) & "," &
                    " data = " & cFuncoes.PersistirData(dados.Data) & "," &
                    " dinheiro = " & cFuncoes.PersistirDecimal(dados.Dinheiro) & "," &
                    " cheque = " & cFuncoes.PersistirDecimal(dados.Cheque) & "," &
                    " chequepre = " & cFuncoes.PersistirDecimal(dados.ChequePre) & "," &
                    " cartaodebito = " & cFuncoes.PersistirDecimal(dados.CartaoDebito) & "," &
                    " cartaocredito = " & cFuncoes.PersistirDecimal(dados.CartaoCredito) & "," &
                    " crediario = " & cFuncoes.PersistirDecimal(dados.Crediario) & "," &
                    " terminal = " & cFuncoes.PersistirTexto(dados.Terminal) & "," &
                    " ordemservico = " & cFuncoes.PersistirTexto(dados.ordemServicoId) & "," &
                    " parcelas = " & cFuncoes.PersistirInteiro(dados.Parcelas) & "," &
                    " desconto = " & cFuncoes.PersistirDecimal(dados.Desconto) & "," &
                    " condicao = " & cFuncoes.PersistirInteiro(dados.Condicao) & "," &
                    " troca = " & cFuncoes.PersistirDecimal(dados.Troca) & "," &
                    " vale = " & cFuncoes.PersistirDecimal(dados.Vale) & "," &
                    " defeito = " & cFuncoes.PersistirDecimal(dados.Defeito) & "," &
                    " vendedor = " & cFuncoes.PersistirTexto(dados.Vendedor) & "," &
                     " Original = " & cFuncoes.PersistirDecimal(dados.Pix) & "," &
                    " total = " & cFuncoes.PersistirDecimal(dados.Total) &
                    " WHERE " &
                    " controle = " & dados.controle.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dVenda) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM prevendas " & _
                    " WHERE controle = " & dados.controle.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Excluir = retorno

        End Function

    End Class

End Namespace
