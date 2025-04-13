Imports System.Transactions

Imports ncDados.nsNotaFiscalFornecedor
Imports ncPersistencia.nsNotaFiscalFornecedor
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Namespace nsNotaFiscalFornecedor

    Public Class rNotaFiscalFornecedor

        '-- Métodos de controle ( Várias chamadas; Controle de transação )

        Public Function Listar() As ColecaoNotaFiscalFornecedor

            Dim retorno As ColecaoNotaFiscalFornecedor

            Try

                retorno = fListar()

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Listar NotaFiscalFornecedor [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dNotaFiscalFornecedor) As ColecaoNotaFiscalFornecedor

            Dim retorno As ColecaoNotaFiscalFornecedor

            Try

                retorno = fConsultar(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar NotaFiscalFornecedor [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Consultar = retorno

        End Function

        Public Function Selecionar(ByVal numero As String, ByVal serie As String) As dNotaFiscalFornecedor
            Dim retorno As dNotaFiscalFornecedor
            Dim dados As dNotaFiscalFornecedor
            Dim colecao As ColecaoNotaFiscalFornecedor

            Try
                dados = New dNotaFiscalFornecedor()

                dados.numero = numero
                dados.serie = serie

                colecao = fConsultar(dados)

                If Not colecao Is Nothing Then
                    If colecao.Count > 0 Then
                        Dim item As dNotaFiscalFornecedor

                        item = colecao(0)

                        retorno = New dNotaFiscalFornecedor()

                        retorno.cid = RetornarInteiro(item.cid)
                        retorno.numero = RetornarTexto(item.numero)
                        retorno.serie = RetornarTexto(item.serie)
                        retorno.fornecedor_cid = RetornarInteiro(item.fornecedor_cid)
                        retorno.fornecedorNome = RetornarTexto(item.fornecedorNome)
                        retorno.dataEmissao = RetornarData(item.dataEmissao)
                        retorno.dataInclusao = RetornarData(item.dataInclusao)
                        retorno.valorBaseIcms = RetornarDecimal(item.valorBaseIcms)
                        retorno.valorIcms = RetornarDecimal(item.valorIcms)
                        retorno.valorBaseIcmsSubstituicao = RetornarDecimal(item.valorBaseIcmsSubstituicao)
                        retorno.valorIcmsSubstituicao = RetornarDecimal(item.valorIcmsSubstituicao)
                        retorno.valorTotalIpi = RetornarDecimal(item.valorTotalIpi)
                        retorno.valorTotalProdutos = RetornarDecimal(item.valorTotalProdutos)
                        retorno.valorTotalNota = RetornarDecimal(item.valorTotalNota)

                        retorno.tipoFrete_cid = RetornarInteiro(item.tipoFrete_cid)
                        retorno.tipoEmissao_cid = RetornarInteiro(item.tipoEmissao_cid)
                        retorno.tipoFluxo_cid = RetornarInteiro(item.tipoFluxo_cid)
                        retorno.tipoNotaFiscal_cid = RetornarInteiro(item.tipoNotaFiscal_cid)
                        retorno.tipoPagamento_cid = RetornarInteiro(item.tipoPagamento_cid)
                        retorno.situacaoNotaFiscal_cid = RetornarInteiro(item.situacaoNotaFiscal_cid)

                        retorno.chaveNotaFiscalEletronica = RetornarTexto(item.chaveNotaFiscalEletronica)
                        retorno.dataEntrada = RetornarData(item.dataEntrada)

                        retorno.valorAbatimento = RetornarDecimal(item.valorAbatimento)
                        retorno.valorDesconto = RetornarDecimal(item.valorDesconto)
                        retorno.valorFrete = RetornarDecimal(item.valorFrete)
                        retorno.valorSeguro = RetornarDecimal(item.valorSeguro)
                        retorno.valorOutrasDespesas = RetornarDecimal(item.valorOutrasDespesas)
                        retorno.valorPisRetidoSubstituicao = RetornarDecimal(item.valorPisRetidoSubstituicao)
                        retorno.valorTotalPis = RetornarDecimal(item.valorTotalPis)
                        retorno.valorCofinsRetidoSubstituicao = RetornarDecimal(item.valorCofinsRetidoSubstituicao)
                        retorno.valorTotalCofins = RetornarDecimal(item.valorTotalCofins)
                    Else
                        retorno = Nothing
                    End If
                Else
                    retorno = Nothing
                End If

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Selecionar NotaFiscalFornecedor [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Selecionar = retorno

        End Function

        Public Function Incluir(ByVal dados As dNotaFiscalFornecedor) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fIncluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir NotaFiscalFornecedor [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dNotaFiscalFornecedor) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fAlterar(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar NotaFiscalFornecedor [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dNotaFiscalFornecedor) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fExcluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir NotaFiscalFornecedor [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Excluir = retorno

        End Function

        '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

        Public Function fListar() As ColecaoNotaFiscalFornecedor

            Dim retorno As ColecaoNotaFiscalFornecedor
            Dim persistencia As pNotaFiscalFornecedor
            Dim retornoPersistencia As ColecaoNotaFiscalFornecedor

            Try

                retorno = New ColecaoNotaFiscalFornecedor()

                persistencia = New pNotaFiscalFornecedor
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
                Throw New ExcecaoNascomercio("Erro em fListar NotaFiscalFornecedor [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fListar = retorno

        End Function

        Public Function fConsultar(ByVal dados As dNotaFiscalFornecedor) As ColecaoNotaFiscalFornecedor

            Dim retorno As ColecaoNotaFiscalFornecedor
            Dim persistencia As pNotaFiscalFornecedor
            Dim retornoPersistencia As ColecaoNotaFiscalFornecedor

            Try

                retorno = New ColecaoNotaFiscalFornecedor()

                persistencia = New pNotaFiscalFornecedor
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
                Throw New ExcecaoNascomercio("Erro em fConsultar NotaFiscalFornecedor [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fConsultar = retorno

        End Function

        Public Function fConsultarItemNota(ByVal notaFiscal As String, ByVal serie As String) As ColecaoNotaFiscalItem

            Dim retorno As ColecaoNotaFiscalItem
            Dim persistencia As pNotaFiscalFornecedor
            Dim retornoPersistencia As ColecaoNotaFiscalItem

            Try

                retorno = New ColecaoNotaFiscalItem

                persistencia = New pNotaFiscalFornecedor
                retornoPersistencia = persistencia.ConsultarItemNota(notaFiscal, serie)

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
                Throw New ExcecaoNascomercio("Erro em fConsultar ProdutoItem [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function fIncluir(ByVal dados As dNotaFiscalFornecedor) As Integer

            Dim retorno As Integer
            Dim persistencia As pNotaFiscalFornecedor

            Try

                persistencia = New pNotaFiscalFornecedor
                retorno = persistencia.Incluir(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fIncluir NotaFiscalFornecedor [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fIncluir = retorno

        End Function

        Public Function fAlterar(ByVal dados As dNotaFiscalFornecedor) As Integer

            Dim retorno As Integer
            Dim persistencia As pNotaFiscalFornecedor

            Try

                persistencia = New pNotaFiscalFornecedor
                retorno = persistencia.Alterar(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fAlterar NotaFiscalFornecedor [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fAlterar = retorno

        End Function

        Public Function fExcluir(ByVal dados As dNotaFiscalFornecedor) As Integer

            Dim retorno As Integer
            Dim persistencia As pNotaFiscalFornecedor

            Try

                persistencia = New pNotaFiscalFornecedor
                retorno = persistencia.Excluir(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fExcluir NotaFiscalFornecedor [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fExcluir = retorno

        End Function

    End Class

End Namespace