Imports System.Transactions

Imports ncDados.nsFornecedor
Imports ncPersistencia.nsFornecedor
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsFornecedor

  Public Class rFornecedor

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoFornecedor

      Dim retorno As ColecaoFornecedor

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dFornecedor) As ColecaoFornecedor

      Dim retorno As ColecaoFornecedor

      Try

        retorno = fConsultar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal cid As Integer) As dFornecedor

      Dim retorno As dFornecedor
      Dim dados As dFornecedor
      Dim colecao As ColecaoFornecedor


      Try

        dados = New dFornecedor()


        dados.cid = cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dFornecedor

            item = colecao(0)

            retorno = New dFornecedor()

            retorno.cid = cFuncoes.RetornarInteiro(item.cid)
            retorno.codigo = cFuncoes.RetornarTexto(item.codigo)
            retorno.nome = cFuncoes.RetornarTexto(item.nome)
            retorno.logradouro = cFuncoes.RetornarTexto(item.logradouro)
            retorno.numero = cFuncoes.RetornarInteiro(item.numero)
            retorno.complemento = cFuncoes.RetornarTexto(item.complemento)
            retorno.bairro = cFuncoes.RetornarTexto(item.bairro)
            retorno.cidade_cid = cFuncoes.RetornarInteiro(item.cidade_cid)
            retorno.estado_cid = cFuncoes.RetornarInteiro(item.estado_cid)
            retorno.cep = cFuncoes.RetornarInteiro(item.cep)
            retorno.inscricaoEstadual = cFuncoes.RetornarTexto(item.inscricaoEstadual)
            retorno.cnpj = cFuncoes.RetornarTexto(item.cnpj)
            retorno.ddd = cFuncoes.RetornarInteiro(item.ddd)
            retorno.telefone = cFuncoes.RetornarTexto(item.telefone)
            retorno.ramal = cFuncoes.RetornarInteiro(item.ramal)
            retorno.nomeContato = cFuncoes.RetornarTexto(item.nomeContato)
            retorno.situacao = cFuncoes.RetornarTexto(item.situacao)
          Else
            retorno = Nothing
          End If
        Else
          retorno = Nothing
        End If

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dFornecedor) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Importar(ByVal dados As dFornecedor) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fImportar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Importar Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Importar = retorno

    End Function

    Public Function Alterar(ByVal dados As dFornecedor) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dFornecedor) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoFornecedor

      Dim retorno As ColecaoFornecedor
      Dim persistencia As pFornecedor
      Dim retornoPersistencia As ColecaoFornecedor

      Try

        retorno = New ColecaoFornecedor()

        persistencia = New pFornecedor
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
        Throw New ExcecaoNascomercio("Erro em fListar Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dFornecedor) As ColecaoFornecedor

      Dim retorno As ColecaoFornecedor
      Dim persistencia As pFornecedor
      Dim retornoPersistencia As ColecaoFornecedor

      Try

        retorno = New ColecaoFornecedor()

        persistencia = New pFornecedor
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
        Throw New ExcecaoNascomercio("Erro em fConsultar Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dFornecedor) As Integer

      Dim retorno As Integer
      Dim persistencia As pFornecedor

      Try

        persistencia = New pFornecedor
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fImportar(ByVal dados As dFornecedor) As Integer

      Dim retorno As Integer
      Dim persistencia As pFornecedor

      Try

        persistencia = New pFornecedor
        retorno = persistencia.Importar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fImportar Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fImportar = retorno

    End Function

    Public Function fAlterar(ByVal dados As dFornecedor) As Integer

      Dim retorno As Integer
      Dim persistencia As pFornecedor

      Try

        persistencia = New pFornecedor
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dFornecedor) As Integer

      Dim retorno As Integer
      Dim persistencia As pFornecedor

      Try

        persistencia = New pFornecedor
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
