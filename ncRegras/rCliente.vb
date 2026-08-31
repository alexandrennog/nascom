Imports System.Transactions

Imports ncDados.nsCliente
Imports ncPersistencia.nsCliente
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCliente

    Public Class rCliente

        '-- Métodos de controle ( Várias chamadas; Controle de transação )

        Public Function Listar() As ColecaoCliente

            Dim retorno As ColecaoCliente

            Try

                retorno = fListar()

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Listar Cliente [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dCliente) As ColecaoCliente

            Dim retorno As ColecaoCliente

            Try

                retorno = fConsultar(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Cliente [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Consultar = retorno

        End Function

        Public Function ConsultarPorCID(ByVal cid As Integer) As dCliente

            Dim retorno As dCliente
            Dim dados As dCliente
            Dim colecao As ColecaoCliente

            Try

                dados = New dCliente()

                dados.cid = cid

                colecao = fConsultar(dados)

                If Not colecao Is Nothing Then
                    If colecao.Count > 0 Then
                        Dim item As dCliente

                        item = colecao(0)

                        retorno = New dCliente()

                        retorno.cid = cFuncoes.RetornarInteiro(item.cid)
                        retorno.nome = cFuncoes.RetornarTexto(item.nome)
                        retorno.estadoCivil = cFuncoes.RetornarTexto(item.estadoCivil)
                        retorno.sexo = cFuncoes.RetornarTexto(item.sexo)
                        retorno.nomePai = cFuncoes.RetornarTexto(item.nomePai)
                        retorno.nomeMae = cFuncoes.RetornarTexto(item.nomeMae)
                        retorno.dataInclusao = cFuncoes.RetornarTexto(item.dataInclusao)
                        retorno.situacao = cFuncoes.RetornarTexto(item.situacao)
                        retorno.rg = cFuncoes.RetornarTexto(item.rg)
                        retorno.cpf = cFuncoes.RetornarTexto(item.cpf)
                        retorno.carteiraProfissional = cFuncoes.RetornarTexto(item.carteiraProfissional)
                        retorno.naturalidade = cFuncoes.RetornarTexto(item.naturalidade)
                        retorno.nacionalidade = cFuncoes.RetornarTexto(item.nacionalidade)
                        retorno.email = cFuncoes.RetornarTexto(item.email)
                        retorno.foto = cFuncoes.RetornarTexto(item.foto)
                        retorno.ddd = cFuncoes.RetornarTexto(item.ddd)
                        retorno.telefone = cFuncoes.RetornarTexto(item.telefone)
                        retorno.dddcel = cFuncoes.RetornarTexto(item.dddcel)
                        retorno.celular = cFuncoes.RetornarTexto(item.celular)
                        retorno.dataNascimento = cFuncoes.RetornarTexto(item.dataNascimento)
                        retorno.rgOrgaoEmissor = cFuncoes.RetornarTexto(item.rgOrgaoEmissor)
                        retorno.rgUf_cid = cFuncoes.RetornarInteiro(item.rgUf_cid)
                    Else
                        retorno = Nothing
                    End If
                Else
                    retorno = Nothing
                End If

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Cliente [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            ConsultarPorCID = retorno

        End Function

        Public Function Incluir(ByVal dados As dCliente) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fIncluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Cliente [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Incluir = retorno

        End Function

        Public Function IncluirImportacao(ByVal dados As dCliente) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fIncluirImportacao(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Cliente [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function Alterar(ByVal dados As dCliente) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fAlterar(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Cliente [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dCliente) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fExcluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Cliente [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Excluir = retorno

        End Function

        '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

        Public Function fListar() As ColecaoCliente

            Dim retorno As ColecaoCliente
            Dim persistencia As pCliente
            Dim retornoPersistencia As ColecaoCliente

            Try

                retorno = New ColecaoCliente

                persistencia = New pCliente
                retornoPersistencia = persistencia.Listar()

                If Not retornoPersistencia Is Nothing Then
                    If retornoPersistencia.Count > 0 Then
                        retorno.AddRange(retornoPersistencia)
                    Else
                        retorno = Nothing
                    End If
                Else
                    retorno = Nothing
                End If

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fListar Cliente [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fListar = retorno

        End Function

        Public Function fConsultar(ByVal dados As dCliente) As ColecaoCliente

            Dim retorno As ColecaoCliente
            Dim persistencia As pCliente
            Dim retornoPersistencia As ColecaoCliente

            Try

                retorno = New ColecaoCliente

                persistencia = New pCliente
                retornoPersistencia = persistencia.Consultar(dados)

                If Not retornoPersistencia Is Nothing Then
                    If retornoPersistencia.Count > 0 Then
                        retorno.AddRange(retornoPersistencia)
                    Else
                        retorno = Nothing
                    End If
                Else
                    retorno = Nothing
                End If

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fConsultar Cliente [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fConsultar = retorno

        End Function

        Public Function fIncluir(ByVal dados As dCliente) As Integer

            Dim retorno As Integer
            Dim persistencia As pCliente

            Try

                persistencia = New pCliente
                'If dados.cid.Value > 0 Then
                'retorno = persistencia.IncluirCid(dados)
                'Else
                retorno = persistencia.Incluir(dados)
                'End If

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fIncluir Cliente [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fIncluir = retorno

        End Function

        Public Function fIncluirImportacao(ByVal dados As dCliente) As Integer

            Dim retorno As Integer
            Dim persistencia As pCliente

            Try

                persistencia = New pCliente
                If dados.cid.Value > 0 Then
                    retorno = persistencia.IncluirCid(dados)
                Else
                    retorno = persistencia.Incluir(dados)
                End If

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fIncluir Cliente [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function fAlterar(ByVal dados As dCliente) As Integer

            Dim retorno As Integer
            Dim persistencia As pCliente

            Try

                persistencia = New pCliente
                retorno = persistencia.Alterar(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fAlterar Cliente [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fAlterar = retorno

        End Function

        Public Function fExcluir(ByVal dados As dCliente) As Integer

            Dim retorno As Integer
            Dim persistencia As pCliente
            Dim financeiro As pClienteFinanceiro
            Dim profissional As pClienteProfissional
            Dim endereco As pClienteEndereco

            Try

                persistencia = New pCliente
                financeiro = New pClienteFinanceiro
                profissional = New pClienteProfissional
                endereco = New pClienteEndereco

                financeiro.ExcluirPorCliente(dados.cid)
                profissional.ExcluirPorCliente(dados.cid)
                endereco.ExcluirPorCliente(dados.cid)
                retorno = persistencia.Excluir(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fExcluir Cliente [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fExcluir = retorno

        End Function

    End Class

End Namespace

