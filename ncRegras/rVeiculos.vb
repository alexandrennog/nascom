Imports System.Transactions

Imports ncDados.nsVeiculos
Imports ncPersistencia.nsVeiculos
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsVeiculos

    Public Class rVeiculos

        '-- Métodos de controle ( Várias chamadas; Controle de transação )

        Public Function Listar() As ColecaoVeiculos

            Dim retorno As ColecaoVeiculos
            Dim persistencia As pVeiculos
            Dim retornoPersistencia As ColecaoVeiculos

            Try

                retorno = New ColecaoVeiculos

                persistencia = New pVeiculos
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
                Throw New ExcecaoNascomercio("Erro em Listar Veiculos [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dVeiculos) As ColecaoVeiculos

            Dim retorno As ColecaoVeiculos
            Dim persistencia As pVeiculos
            Dim retornoPersistencia As ColecaoVeiculos

            Try

                retorno = New ColecaoVeiculos

                persistencia = New pVeiculos
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
                Throw New ExcecaoNascomercio("Erro em Consultar Veiculos [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Consultar = retorno

        End Function

        Public Function ConsultarPorCID(ByVal cid As Integer) As dVeiculos

            Dim retorno As dVeiculos
            Dim dados As dVeiculos
            Dim colecao As ColecaoVeiculos

            Try

                dados = New dVeiculos()

                dados.cid = cid

                colecao = Consultar(dados)

                If Not colecao Is Nothing Then
                    If colecao.Count > 0 Then
                        Dim item As dVeiculos

                        item = colecao(0)

                        retorno = New dVeiculos()

                        retorno.cid = cFuncoes.RetornarInteiro(item.cid)
                        retorno.clienteId = cFuncoes.RetornarInteiro(item.clienteId)
                        retorno.Ano = cFuncoes.RetornarTexto(item.Ano)
                        retorno.Combustivel = cFuncoes.RetornarTexto(item.Combustivel)
                        retorno.Cor = cFuncoes.RetornarTexto(item.Cor)
                        retorno.Marca = cFuncoes.RetornarTexto(item.Marca)
                        retorno.Modelo = cFuncoes.RetornarTexto(item.Modelo)
                        retorno.Placa = cFuncoes.RetornarTexto(item.Placa)
                    Else
                        retorno = Nothing
                    End If
                Else
                    retorno = Nothing
                End If

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Veiculos [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            ConsultarPorCID = retorno

        End Function

        Public Function Incluir(ByVal dadosVeiculos As ColecaoVeiculos) As Integer

            Dim retorno As Integer
            Dim persistenciaVeiculos As pVeiculos

            Try

                Using ts As New TransactionScope

                    persistenciaVeiculos = New pVeiculos()
                    For Each Veiculos As dVeiculos In dadosVeiculos
                        persistenciaVeiculos.Incluir(Veiculos)
                    Next

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Veiculos [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Incluir = retorno

        End Function

        Public Function Incluir(ByVal dados As dVeiculos) As Integer

            Dim retorno As Integer
            Dim persistenciaVeiculos As pVeiculos

            Try

                Using ts As New TransactionScope

                    persistenciaVeiculos = New pVeiculos()
                    persistenciaVeiculos.Incluir(dados)

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Veiculos [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dadosVeiculos As ColecaoVeiculos) As Integer

            Dim retorno As Integer
            Dim persistenciaVeiculos As pVeiculos

            Try

                Using ts As New TransactionScope
                    persistenciaVeiculos = New pVeiculos()
                    For Each Veiculos As dVeiculos In dadosVeiculos
                        persistenciaVeiculos.Alterar(Veiculos)
                    Next
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Veiculos [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Alterar = retorno

        End Function

  
        Public Function Excluir(ByVal dados As dVeiculos) As Integer

            Dim retorno As Integer
            Dim persistencia As pVeiculos

            Try

                Using ts As New TransactionScope
                    persistencia = New pVeiculos
                    retorno = persistencia.Excluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Veiculos [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function ExcluirVeiculosCliente(ByVal dados As dVeiculos) As Integer

            Dim retorno As Integer
            Dim persistencia As pVeiculos

            Try

                Using ts As New TransactionScope
                    persistencia = New pVeiculos
                    retorno = persistencia.ExcluirVeiculosCliente(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Veiculos [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

    End Class

End Namespace
