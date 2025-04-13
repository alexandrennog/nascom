Imports ncDados.nsEFD
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEFD

  Public Class pEfdEntidade

    Public Function Consultar() As dEfdEntidade

      Dim retorno As dEfdEntidade
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim sqlSelect As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD

                sqlSelect = " Select e.nomeEmpresarial, e.tipoPessoa, e.cpfCnpj, m.estados_cid, e.inscricaoEstadual, e.codigoMunicipio, " & _
                  " e.inscricaoMunicipal, e.inscricaoSuframa, e.tipoAtividade, e.nomeFantasia, " & _
                  " m.codigo_ibge, uf.sigla "
                sqlFrom = " From EfdEntidade e " & _
                  " left join municipios m " & _
                  "   on m.cid = e.codigoMunicipio " & _
                  " left join estados uf " & _
                  "   on uf.cid = m.estados_cid "



                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New dEfdEntidade

                            retorno.nomeEmpresarial = cFuncoes.RetornarTexto(dt.Rows(0).Item("nomeEmpresarial"))
                            retorno.tipoPessoa = cFuncoes.RetornarTexto(dt.Rows(0).Item("tipoPessoa"))
                            retorno.cpfCnpj = cFuncoes.RetornarTexto(dt.Rows(0).Item("cpfCnpj"))
                            retorno.estados_cid = cFuncoes.RetornarInteiro(dt.Rows(0).Item("estados_cid"))
                            retorno.ufSigla = cFuncoes.RetornarTexto(dt.Rows(0).Item("sigla"))
                            retorno.inscricaoEstadual = cFuncoes.RetornarTexto(dt.Rows(0).Item("inscricaoEstadual"))
                            retorno.codigoMunicipio = cFuncoes.RetornarTexto(dt.Rows(0).Item("codigoMunicipio"))
                            retorno.municipioCodigoIbge = cFuncoes.RetornarTexto(dt.Rows(0).Item("codigo_ibge"))
                            retorno.inscricaoMunicipal = cFuncoes.RetornarTexto(dt.Rows(0).Item("inscricaoMunicipal"))
                            retorno.inscricaoSuframa = cFuncoes.RetornarTexto(dt.Rows(0).Item("inscricaoSuframa"))
                            retorno.tipoAtividade = cFuncoes.RetornarTexto(dt.Rows(0).Item("tipoAtividade"))
                            retorno.nomeFantasia = cFuncoes.RetornarTexto(dt.Rows(0).Item("nomeFantasia"))
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
                Throw New ExcecaoNascomercio("Erro em Consultar EfdEntidade [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Consultar = retorno

        End Function

        Public Function Excluir() As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM EfdEntidade "

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir EfdEntidade [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Excluir = retorno

        End Function

        Public Function Incluir(ByVal dados As dEfdEntidade) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " INSERT INTO " & _
                    " EfdEntidade ( nomeEmpresarial, tipoPessoa, cpfCnpj, uf, inscricaoEstadual, codigoMunicipio, " & _
                  " inscricaoMunicipal, inscricaoSuframa, tipoAtividade, nomeFantasia ) " & _
                    " VALUES (" & _
                    cFuncoes.PersistirTexto(dados.nomeEmpresarial) & "," & _
                    cFuncoes.PersistirTexto(dados.tipoPessoa) & "," & _
                    cFuncoes.PersistirTexto(dados.cpfCnpj) & "," & _
                    cFuncoes.PersistirInteiro(dados.estados_cid) & "," & _
                    cFuncoes.PersistirTexto(dados.inscricaoEstadual) & "," & _
                    cFuncoes.PersistirTexto(dados.codigoMunicipio) & "," & _
                    cFuncoes.PersistirTexto(dados.inscricaoMunicipal) & "," & _
                    cFuncoes.PersistirTexto(dados.inscricaoSuframa) & "," & _
                    cFuncoes.PersistirTexto(dados.tipoAtividade) & "," & _
                    cFuncoes.PersistirTexto(dados.nomeFantasia) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir EfdEntidade [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dEfdEntidade) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " UPDATE EfdEntidade  SET " & _
                    " nomeEmpresarial = " & cFuncoes.PersistirTexto(dados.nomeEmpresarial) & "," & _
                    " tipoPessoa = " & cFuncoes.PersistirTexto(dados.tipoPessoa) & "," & _
                    " cpfCnpj = " & cFuncoes.PersistirTexto(dados.cpfCnpj) & "," & _
                    " uf = " & cFuncoes.PersistirInteiro(dados.estados_cid) & "," & _
                    " inscricaoEstadual = " & cFuncoes.PersistirTexto(dados.inscricaoEstadual) & "," & _
                    " codigoMunicipio = " & cFuncoes.PersistirTexto(dados.codigoMunicipio) & "," & _
                    " inscricaoMunicipal = " & cFuncoes.PersistirTexto(dados.inscricaoMunicipal) & "," & _
                    " inscricaoSuframa = " & cFuncoes.PersistirTexto(dados.inscricaoSuframa) & "," & _
                    " tipoAtividade = " & cFuncoes.PersistirTexto(dados.tipoAtividade) & "," & _
                    " nomeFantasia = " & cFuncoes.PersistirTexto(dados.nomeFantasia)

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar EfdEntidade [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

  End Class

End Namespace