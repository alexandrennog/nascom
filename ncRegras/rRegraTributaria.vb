Imports System.Transactions

Imports ncDados.nsRegraTributaria
Imports ncPersistencia.nsRegraTributaria
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsRegraTributaria

  Public Class rRegraTributaria

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoRegraTributaria

      Dim retorno As ColecaoRegraTributaria

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dRegraTributaria) As ColecaoRegraTributaria

      Dim retorno As ColecaoRegraTributaria

      Try

        retorno = fConsultar(dados)

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal cid As Integer) As dRegraTributaria

      Dim retorno As dRegraTributaria
      Dim dados As dRegraTributaria
      Dim colecao As ColecaoRegraTributaria


      Try

        dados = New dRegraTributaria()


        dados.cid = cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dRegraTributaria

            item = colecao(0)

            retorno = New dRegraTributaria()

            retorno.cid = cFuncoes.RetornarInteiro(item.cid)
            retorno.descricao = cFuncoes.RetornarTexto(item.descricao)
            retorno.crt = item.crt
            retorno.ufOrigem = cFuncoes.RetornarTexto(item.ufOrigem)
            retorno.ufDestino = cFuncoes.RetornarTexto(item.ufDestino)
            retorno.tipoOperacao = cFuncoes.RetornarTexto(item.tipoOperacao)
            retorno.modeloDocumento = item.modeloDocumento
            retorno.inicioVigencia = item.inicioVigencia
            retorno.fimVigencia = item.fimVigencia
            retorno.ativo = item.ativo
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
        Throw New ExcecaoNascomercio("Erro em Consultar RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dRegraTributaria) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Importar(ByVal dados As dRegraTributaria) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fImportar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Importar RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Importar = retorno

    End Function

    Public Function Alterar(ByVal dados As dRegraTributaria) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dRegraTributaria) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoRegraTributaria

      Dim retorno As ColecaoRegraTributaria
      Dim persistencia As pRegraTributaria
      Dim retornoPersistencia As ColecaoRegraTributaria

      Try

        retorno = New ColecaoRegraTributaria

        persistencia = New pRegraTributaria
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
        Throw New ExcecaoNascomercio("Erro em fListar RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dRegraTributaria) As ColecaoRegraTributaria

      Dim retorno As ColecaoRegraTributaria
      Dim persistencia As pRegraTributaria
      Dim retornoPersistencia As ColecaoRegraTributaria

      Try

        retorno = New ColecaoRegraTributaria

        persistencia = New pRegraTributaria
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
        Throw New ExcecaoNascomercio("Erro em fConsultar RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dRegraTributaria) As Integer

      Dim retorno As Integer
      Dim persistencia As pRegraTributaria

      Try

        persistencia = New pRegraTributaria
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fImportar(ByVal dados As dRegraTributaria) As Integer

      Dim retorno As Integer
      Dim persistencia As pRegraTributaria

      Try

        persistencia = New pRegraTributaria
        retorno = persistencia.Importar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fImportar RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fImportar = retorno

    End Function

    Public Function fAlterar(ByVal dados As dRegraTributaria) As Integer

      Dim retorno As Integer
      Dim persistencia As pRegraTributaria

      Try

        persistencia = New pRegraTributaria
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dRegraTributaria) As Integer

      Dim retorno As Integer
      Dim persistencia As pRegraTributaria

      Try

        persistencia = New pRegraTributaria
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
