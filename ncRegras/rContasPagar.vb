Imports System.Transactions

Imports ncDados.nsContasPagar
Imports ncPersistencia.nsContasPagar
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsContasPagar

  Public Class rContasPagar

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoContasPagar

      Dim retorno As ColecaoContasPagar

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar ContasPagar [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dContasPagar) As ColecaoContasPagar

      Dim retorno As ColecaoContasPagar

      Try

        retorno = fConsultar(dados)

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar ContasPagar [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal cid As Integer) As dContasPagar

      Dim retorno As dContasPagar
      Dim dados As dContasPagar
      Dim colecao As ColecaoContasPagar

      Try

        dados = New dContasPagar()

        dados.cid = cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dContasPagar

            item = colecao(0)

            retorno = New dContasPagar()

            retorno.cid = cFuncoes.RetornarInteiro(item.cid)
            retorno.codigo = cFuncoes.RetornarTexto(item.codigo)
            retorno.valor = cFuncoes.RetornarDecimal(item.valor)
            retorno.observacao = cFuncoes.RetornarTexto(item.observacao)
            retorno.aceite = cFuncoes.RetornarBoleano(item.aceite)
            retorno.dataEmissao = cFuncoes.RetornarTexto(item.dataEmissao)
            retorno.dataVencimento = cFuncoes.RetornarTexto(item.dataVencimento)
            retorno.dataPagamento = cFuncoes.RetornarTexto(item.dataPagamento)
            retorno.valorPagamento = cFuncoes.RetornarTexto(item.valorPagamento)
            retorno.codigoBarra = cFuncoes.RetornarTexto(item.codigoBarra)
            retorno.fornecedor_cid = cFuncoes.RetornarInteiro(item.fornecedor_cid)
            retorno.pago = cFuncoes.RetornarBoleano(item.pago)
          Else
            retorno = Nothing
          End If
        Else
          retorno = Nothing
        End If

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar ContasPagar [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dContasPagar) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ContasPagar [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Importar(ByVal dados As dContasPagar) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fImportar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Importar ContasPagar [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Importar = retorno

    End Function

    Public Function Alterar(ByVal dados As dContasPagar) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar ContasPagar [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dContasPagar) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ContasPagar [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoContasPagar

      Dim retorno As ColecaoContasPagar
      Dim persistencia As pContasPagar
      Dim retornoPersistencia As ColecaoContasPagar

      Try

        retorno = New ColecaoContasPagar

        persistencia = New pContasPagar
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
        Throw New ExcecaoNascomercio("Erro em fListar ContasPagar [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dContasPagar) As ColecaoContasPagar

      Dim retorno As ColecaoContasPagar
      Dim persistencia As pContasPagar
      Dim retornoPersistencia As ColecaoContasPagar

      Try

        retorno = New ColecaoContasPagar

        persistencia = New pContasPagar
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

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fConsultar ContasPagar [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dContasPagar) As Integer

      Dim retorno As Integer
      Dim persistencia As pContasPagar

      Try

        persistencia = New pContasPagar
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir ContasPagar [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fImportar(ByVal dados As dContasPagar) As Integer

      Dim retorno As Integer
      Dim persistencia As pContasPagar

      Try

        persistencia = New pContasPagar
        retorno = persistencia.Importar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fImportar ContasPagar [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fImportar = retorno

    End Function

    Public Function fAlterar(ByVal dados As dContasPagar) As Integer

      Dim retorno As Integer
      Dim persistencia As pContasPagar

      Try

        persistencia = New pContasPagar
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar ContasPagar [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dContasPagar) As Integer

      Dim retorno As Integer
      Dim persistencia As pContasPagar

      Try

        persistencia = New pContasPagar
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir ContasPagar [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace