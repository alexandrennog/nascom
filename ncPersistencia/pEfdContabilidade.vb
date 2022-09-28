Imports ncDados.nsEFD
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEFD

    Public Class pEfdContabilidade

        Public Function Consultar() As dEfdContabilidade

            Dim retorno As dEfdContabilidade
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim sqlSelect As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " Select c.nomeContador, c.cpfContador, c.crcContador, c.cnpjEscritorio, c.logradouro, c.numero, " & _
                  " c.complemento, c.bairro, c.municipio, c.cep, c.dddTelefone, c.dddFax, c.email, c.contaAnaliticaContabil, m.estados_cid, " & _
                  " m.codigo_ibge "
                sqlFrom = " From EfdContabilidade c " & _
                  " left join municipios m " & _
                  "   on m.cid = c.municipio "

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New dEfdContabilidade

                            retorno.nomeContador = cFuncoes.RetornarTexto(dt.Rows(0).Item("nomeContador"))
                            retorno.cpf = cFuncoes.RetornarTexto(dt.Rows(0).Item("cpfContador"))
                            retorno.crc = cFuncoes.RetornarTexto(dt.Rows(0).Item("crcContador"))
                            retorno.cnpjEscritorio = cFuncoes.RetornarTexto(dt.Rows(0).Item("cnpjEscritorio"))
                            retorno.logradouro = cFuncoes.RetornarTexto(dt.Rows(0).Item("logradouro"))
                            retorno.numero = cFuncoes.RetornarTexto(dt.Rows(0).Item("numero"))
                            retorno.complemento = cFuncoes.RetornarTexto(dt.Rows(0).Item("complemento"))
                            retorno.bairro = cFuncoes.RetornarTexto(dt.Rows(0).Item("bairro"))
                            retorno.municipio = cFuncoes.RetornarTexto(dt.Rows(0).Item("municipio"))
                            retorno.municipioCodigoIbge = cFuncoes.RetornarTexto(dt.Rows(0).Item("codigo_ibge"))
                            retorno.cep = cFuncoes.RetornarTexto(dt.Rows(0).Item("cep"))
                            retorno.dddTelefone = cFuncoes.RetornarTexto(dt.Rows(0).Item("dddTelefone"))
                            retorno.dddFax = cFuncoes.RetornarTexto(dt.Rows(0).Item("dddFax"))
                            retorno.email = cFuncoes.RetornarTexto(dt.Rows(0).Item("email"))
                            retorno.contaAnaliticaContabil = cFuncoes.RetornarTexto(dt.Rows(0).Item("contaAnaliticaContabil"))
                            retorno.estados_cid = cFuncoes.RetornarInteiro(dt.Rows(0).Item("estados_cid"))
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
                Throw New ExcecaoNascomercio("Erro em Consultar EfdContabilidade [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Consultar = retorno

        End Function

        Public Function Excluir() As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM EfdContabilidade "

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir EfdContabilidade [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Excluir = retorno

        End Function

        Public Function Incluir(ByVal dados As dEfdContabilidade) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " INSERT INTO " & _
                    " EfdContabilidade ( nomeContador, cpfContador, crcContador, cnpjEscritorio, logradouro, " & _
                    " numero, complemento, bairro, municipio, cep, dddTelefone, dddFax, email, contaAnaliticaContabil " & _
                    " ) " & _
                    " VALUES (" & _
                    cFuncoes.PersistirTexto(dados.nomeContador) & "," & _
                    cFuncoes.PersistirTexto(dados.cpf) & "," & _
                    cFuncoes.PersistirTexto(dados.crc) & "," & _
                    cFuncoes.PersistirTexto(dados.cnpjEscritorio) & "," & _
                    cFuncoes.PersistirTexto(dados.logradouro) & "," & _
                    cFuncoes.PersistirTexto(dados.numero) & "," & _
                    cFuncoes.PersistirTexto(dados.complemento) & "," & _
                    cFuncoes.PersistirTexto(dados.bairro) & "," & _
                    cFuncoes.PersistirTexto(dados.municipio) & "," & _
                    cFuncoes.PersistirTexto(dados.cep) & "," & _
                    cFuncoes.PersistirTexto(dados.dddTelefone) & "," & _
                    cFuncoes.PersistirTexto(dados.dddFax) & "," & _
                    cFuncoes.PersistirTexto(dados.email) & "," & _
                    cFuncoes.PersistirTexto(dados.contaAnaliticaContabil) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir EfdContabilidade [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dEfdContabilidade) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " UPDATE EfdContabilidade SET " & _
                    " nomeContador = " & cFuncoes.PersistirTexto(dados.nomeContador) & "," & _
                    " cpfContador = " & cFuncoes.PersistirTexto(dados.cpf) & "," & _
                    " crcContador = " & cFuncoes.PersistirTexto(dados.crc) & "," & _
                    " cnpjEscritorio = " & cFuncoes.PersistirTexto(dados.cnpjEscritorio) & "," & _
                    " logradouro = " & cFuncoes.PersistirTexto(dados.logradouro) & "," & _
                    " numero = " & cFuncoes.PersistirTexto(dados.numero) & "," & _
                    " complemento = " & cFuncoes.PersistirTexto(dados.complemento) & "," & _
                    " bairro = " & cFuncoes.PersistirTexto(dados.bairro) & "," & _
                    " municipio = " & cFuncoes.PersistirTexto(dados.municipio) & "," & _
                    " cep = " & cFuncoes.PersistirTexto(dados.cep) & "," & _
                    " dddTelefone = " & cFuncoes.PersistirTexto(dados.dddTelefone) & "," & _
                    " dddFax = " & cFuncoes.PersistirTexto(dados.dddFax) & "," & _
                    " email = " & cFuncoes.PersistirTexto(dados.email) & "," & _
                    " contaAnaliticaContabil = " & cFuncoes.PersistirTexto(dados.contaAnaliticaContabil)

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar EfdContabilidade [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

    End Class

End Namespace