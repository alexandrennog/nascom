Imports System.Transactions

Imports ncDados.nsProduto
Imports ncDados.nsCaracteristica
Imports ncRegras.nsCaracteristica
Imports ncPersistencia.nsProduto
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsProduto

  Public Class rProdutoItem

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoProdutoItem

      Dim retorno As ColecaoProdutoItem

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dProdutoItem) As ColecaoProdutoItem

      Dim retorno As ColecaoProdutoItem

      Try

        retorno = fConsultar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function ConsultarUltimoItem(ByVal produto_cid As Integer) As Nullable(Of Integer)

      Dim retorno As Nullable(Of Integer) = Nothing

      Try

        retorno = fConsultarUltimoItem(produto_cid)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ConsultarUltimoItem = retorno

    End Function

    Public Function ConsultarUltimoCodigoBarras() As String

      Dim retorno As String

      Try

        retorno = fConsultarUltimoCodigoBarras()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em ConsultarUltimoCodigoBarras ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ConsultarUltimoCodigoBarras = retorno

    End Function

    Public Function Selecionar(ByVal dados As dProdutoItem) As dProdutoItem

      Dim colecao As ColecaoProdutoItem
      Dim retorno As dProdutoItem

      Try

        retorno = Nothing

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            retorno = colecao(0)
          End If
        End If

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Selecionar ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Selecionar = retorno

    End Function

    Public Function ConsultarQuantidadeItem(ByVal produtos_cid As Integer) As ColecaoProdutoItem

      Dim retorno As ColecaoProdutoItem

      Try

        retorno = fConsultarQuantidadeItem(produtos_cid)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ConsultarQuantidadeItem = retorno

    End Function

        Public Function ConsultarProdutoItem(ByVal descricao As String, ByVal codigoBarras As String, ByVal referencia As String, ByVal emEstoque As Boolean) As ColecaoProdutoItem

            Dim retorno As ColecaoProdutoItem

            Try

                retorno = fConsultarProdutoItem(descricao, codigoBarras, referencia,emEstoque)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            ConsultarProdutoItem = retorno

        End Function

    ''' <summary>
    ''' Consultar todos os itens do produto
    ''' </summary>
    ''' <param name="produto_cid">Código do produto</param>
    ''' <returns>Lista de itens do produto</returns>
    ''' <remarks></remarks>
    Public Function ConsultarPorProduto(ByVal produto_cid As Integer) As ColecaoProdutoItem

      Dim retorno As ColecaoProdutoItem
      Dim dados As dProdutoItem

      Try

        dados = New dProdutoItem()

        dados.produtos_cid = produto_cid

        retorno = fConsultar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em ConsultarPorProduto ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ConsultarPorProduto = retorno

    End Function

    Public Function Incluir(ByVal dados As dProdutoItem) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Incluir = retorno

    End Function

    Public Function IncluirListaItem(ByVal colecao As ColecaoProdutoItem) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope

          For Each dados As dProdutoItem In colecao
            retorno = fIncluir(dados)
          Next

          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      IncluirListaItem = retorno

    End Function

    Public Function Alterar(ByVal dados As dProdutoItem) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Alterar = retorno

    End Function

        Public Function AlterarEstoque(ByVal codigoBarras As String, ByVal quantidade As Decimal) As Integer
            AlterarEstoque(codigoBarras, quantidade, True)
        End Function

        Public Function AlterarEstoque(ByVal codigoBarras As String, ByVal quantidade As Decimal, ByVal somar As Boolean) As Integer

            Dim retorno As Integer
            Dim dadosPI As dProdutoItem
            Dim dadosC As dCaracteristica
            Dim regrasC As rCaracteristica
            Dim qtdeAtual As Decimal

            Try

                dadosC = New dCaracteristica()
                regrasC = New rCaracteristica()

                dadosC = regrasC.fConsultarPorCodigo("codigoBarras")

                dadosPI = New dProdutoItem()
                dadosPI.caracteristicas_cid = dadosC.cid
                dadosPI.valor = codigoBarras

                dadosPI = Selecionar(dadosPI)

                If somar = True Then
                    qtdeAtual = fConsultarEstoque(codigoBarras)
                    qtdeAtual = qtdeAtual + quantidade
                Else
                    qtdeAtual = quantidade
                End If

                dadosC = regrasC.fConsultarPorCodigo("estoque")

                dadosPI.valor = qtdeAtual.ToString()
                dadosPI.caracteristicas_cid = dadosC.cid

                retorno = fAlterar(dadosPI)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em AlterarEstoque ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            AlterarEstoque = retorno

        End Function

        Public Function Excluir(ByVal dados As dProdutoItem) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Excluir = retorno

    End Function

    Public Function ExcluirPorProduto(ByVal dados As dProdutoItem) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluirPorProduto(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em ExcluirPorPoduto ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ExcluirPorProduto = retorno

    End Function

    Public Function ExcluirPorProduto(ByVal produtos_cid As Integer) As Integer

      Dim retorno As Integer
      Dim dados As dProdutoItem

      Try

        dados = New dProdutoItem()

        dados.produtos_cid = produtos_cid

        Using ts As New TransactionScope
          retorno = fExcluirPorProduto(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em ExcluirPorProduto ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ExcluirPorProduto = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoProdutoItem

      Dim retorno As ColecaoProdutoItem
      Dim persistencia As pProdutoItem
      Dim retornoPersistencia As ColecaoProdutoItem

      Try

        retorno = New ColecaoProdutoItem

        persistencia = New pProdutoItem
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
        Throw New ExcecaoNascomercio("Erro em fListar ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dProdutoItem) As ColecaoProdutoItem

      Dim retorno As ColecaoProdutoItem
      Dim persistencia As pProdutoItem
      Dim retornoPersistencia As ColecaoProdutoItem

      Try

        retorno = New ColecaoProdutoItem

        persistencia = New pProdutoItem
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
        Throw New ExcecaoNascomercio("Erro em fConsultar ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fConsultar = retorno

    End Function

    Public Function fConsultarUltimoItem(ByVal produto_cid As Integer) As Nullable(Of Integer)

      Dim retorno As Nullable(Of Integer) = Nothing
      Dim persistencia As pProdutoItem

      Try

        persistencia = New pProdutoItem
        retorno = persistencia.ConsultarUltimoItem(produto_cid)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fConsultarUltimoItem ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fConsultarUltimoItem = retorno

    End Function

    Public Function fConsultarUltimoCodigoBarras() As String

      Dim retorno As String
      Dim persistencia As pProdutoItem

      Try

        persistencia = New pProdutoItem
        retorno = persistencia.ConsultarUltimoCodigoBarras()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fConsultarUltimoCodigoBarras ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fConsultarUltimoCodigoBarras = retorno

    End Function

        Public Function fConsultarEstoque(ByVal codigoBarras As String) As Decimal

            Dim retorno As Decimal
            Dim persistencia As pProdutoItem
            Dim retornoPersistencia As Decimal

            Try

                retorno = 0

                persistencia = New pProdutoItem
                retornoPersistencia = persistencia.ConsultarEstoque(codigoBarras)

                retorno = retornoPersistencia

            Catch ex As Exception

                retorno = 0
                Throw New ExcecaoNascomercio("Erro em fConsultarEstoque ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fConsultarEstoque = retorno

        End Function

        Public Function fConsultarQuantidadeItem(ByVal produtos_cid As Integer) As ColecaoProdutoItem

      Dim retorno As ColecaoProdutoItem
      Dim persistencia As pProdutoItem
      Dim retornoPersistencia As ColecaoProdutoItem

      Try

        retorno = New ColecaoProdutoItem

        persistencia = New pProdutoItem
        retornoPersistencia = persistencia.ConsultarQuantidadeItem(produtos_cid)

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
        Throw New ExcecaoNascomercio("Erro em fConsultar ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fConsultarQuantidadeItem = retorno

    End Function

        Public Function fConsultarProdutoItem(ByVal descricao As String, ByVal codigoBarras As String, ByVal referencia As String, ByVal emEstoque As Boolean) As ColecaoProdutoItem

            Dim retorno As ColecaoProdutoItem
            Dim persistencia As pProdutoItem
            Dim retornoPersistencia As ColecaoProdutoItem

            Try

                retorno = New ColecaoProdutoItem

                persistencia = New pProdutoItem
                retornoPersistencia = persistencia.ConsultarProdutoItem(descricao, codigoBarras, referencia, emEstoque)

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
                Throw New ExcecaoNascomercio("Erro em fConsultar ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fConsultarProdutoItem = retorno

        End Function

    Public Function fIncluir(ByVal dados As dProdutoItem) As Integer

      Dim retorno As Integer
      Dim persistencia As pProdutoItem

      Try

        persistencia = New pProdutoItem
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dProdutoItem) As Integer

      Dim retorno As Integer
      Dim persistencia As pProdutoItem

      Try

        persistencia = New pProdutoItem
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dProdutoItem) As Integer

      Dim retorno As Integer
      Dim persistencia As pProdutoItem

      Try

        persistencia = New pProdutoItem
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fExcluir = retorno

    End Function

    Public Function fExcluirPorProduto(ByVal dados As dProdutoItem) As Integer

      Dim retorno As Integer
      Dim persistencia As pProdutoItem

      Try

        persistencia = New pProdutoItem
        retorno = persistencia.ExcluirPorProduto(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluirPorProduto ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fExcluirPorProduto = retorno

    End Function

    Public Function fExcluirPorProduto(ByVal produtos_cid As Integer) As Integer

      Dim retorno As Integer
      Dim persistencia As pProdutoItem
      Dim dados As dProdutoItem

      Try

        dados = New dProdutoItem()
        persistencia = New pProdutoItem

        dados.produtos_cid = produtos_cid

        retorno = persistencia.ExcluirPorProduto(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluirPorProduto ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fExcluirPorProduto = retorno

    End Function

  End Class

End Namespace
