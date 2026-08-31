Imports ncDados.nsVeiculos
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsVeiculos

    Public Class pVeiculos

        Public Function Listar() As ColecaoVeiculos

            Dim retorno As ColecaoVeiculos
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dVeiculos
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " Select cid, clienteid, placa, marca, modelo, cor, ano, combustivel From veiculo"

                ds = acessoBanco.ExecutarDS(comandoSQL)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoVeiculos

                            For Each row In dt.Rows
                                item = New dVeiculos

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.clienteId = cFuncoes.RetornarInteiro(row("clienteid"))
                                item.Placa = cFuncoes.RetornarTexto(row("placa"))
                                item.Marca = cFuncoes.RetornarTexto(row("marca"))
                                item.Modelo = cFuncoes.RetornarTexto(row("modelo"))
                                item.Cor = cFuncoes.RetornarTexto(row("cor"))
                                item.Ano = cFuncoes.RetornarTexto(row("ano"))
                                item.Combustivel = cFuncoes.RetornarTexto(row("combustivel"))

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
                Throw New ExcecaoNascomercio("Erro em Listar Veiculos [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dVeiculos) As ColecaoVeiculos

            Dim retorno As ColecaoVeiculos
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dVeiculos
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String


            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " Select cid, clienteid, placa, marca, modelo, cor, ano, combustivel "

                sqlWhere = String.Empty
                sqlFrom = " From Veiculo "

                '-- cid
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")

                '-- cliente
                If dados.clienteId <> 0 Then
                    sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.clienteId, "clienteid")
                End If

                '-- Placa
                If dados.Placa <> 0 Then
                    sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.Placa, "placa")
                End If

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoVeiculos

                            For Each row In dt.Rows
                                item = New dVeiculos

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.clienteId = cFuncoes.RetornarInteiro(row("clienteid"))
                                item.Placa = cFuncoes.RetornarTexto(row("placa"))
                                item.Marca = cFuncoes.RetornarTexto(row("marca"))
                                item.Modelo = cFuncoes.RetornarTexto(row("modelo"))
                                item.Cor = cFuncoes.RetornarTexto(row("cor"))
                                item.Ano = cFuncoes.RetornarTexto(row("ano"))
                                item.Combustivel = cFuncoes.RetornarTexto(row("combustivel"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar Veiculos[" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Consultar = retorno

        End Function

        Public Function Incluir(ByVal dados As dVeiculos) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " INSERT INTO " & _
                    " Veiculo ( clienteid, placa, marca, modelo, cor, ano, combustivel ) " & _
                    " VALUES (" & _
                            cFuncoes.PersistirInteiro(dados.clienteId) & "," & _
                            cFuncoes.PersistirTexto(dados.Placa) & "," & _
                            cFuncoes.PersistirTexto(dados.Marca) & "," & _
                            cFuncoes.PersistirTexto(dados.Modelo) & "," & _
                            cFuncoes.PersistirTexto(dados.Cor) & "," & _
                            cFuncoes.PersistirTexto(dados.Ano) & "," & _
                            cFuncoes.PersistirTexto(dados.Combustivel) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Veiculos [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dVeiculos) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " UPDATE Veiculo SET " & _
                    " clienteid = " & cFuncoes.PersistirInteiro(dados.clienteId) & "," & _
                    " placa = " & cFuncoes.PersistirTexto(dados.Placa) & "," & _
                    " marca = " & cFuncoes.PersistirTexto(dados.Marca) & "," & _
                    " modelo = " & cFuncoes.PersistirTexto(dados.Modelo) & "," & _
                    " cor = " & cFuncoes.PersistirTexto(dados.Cor) & "," & _
                    " ano = " & cFuncoes.PersistirTexto(dados.Ano) & "," & _
                    " combustivel = " & cFuncoes.PersistirTexto(dados.Combustivel) & _
                    " WHERE " & _
                    " cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Veiculos [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dVeiculos) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM Veiculo " & _
                    " WHERE cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Veiculos [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function ExcluirVeiculosCliente(ByVal dados As dVeiculos) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM Veiculo " & _
                    " WHERE clienteid = " & dados.clienteId.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Veiculos [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

    End Class

End Namespace
