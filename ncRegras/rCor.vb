Imports System.Transactions

Imports ncDados.nsCor
Imports ncPersistencia.nsCor
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCor

  Public Class rCor

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoCor

      Dim retorno As ColecaoCor

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Cor [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dCor) As ColecaoCor

      Dim retorno As ColecaoCor

      Try

        retorno = fConsultar(dados)

      Catch nex As ExcecaoNascomercio

        Throw

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Cor [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal cid As Integer) As dCor

      Dim retorno As dCor
      Dim dados As dCor
      Dim colecao As ColecaoCor


      Try

        dados = New dCor()


        dados.cid = cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dCor

            item = colecao(0)

            retorno = New dCor()

            retorno.cid = cFuncoes.RetornarInteiro(item.cid)
            retorno.nome = cFuncoes.RetornarTexto(item.nome)
            retorno.situacao = cFuncoes.RetornarTexto(item.situacao)
          Else
            retorno = Nothing
          End If
        Else
          retorno = Nothing
        End If

      Catch nex As ExcecaoNascomercio

        Throw

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Cor [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dCor) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Cor [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Incluir = retorno

    End Function

    Public Function Importar(ByVal dados As dCor) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fImportar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Importar Cor [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Importar = retorno

    End Function

    Public Function Alterar(ByVal dados As dCor) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Cor [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dCor) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Cor [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoCor

      Dim retorno As ColecaoCor
      Dim persistencia As pCor
      Dim retornoPersistencia As ColecaoCor

      Try

        retorno = New ColecaoCor

        persistencia = New pCor
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
        Throw New ExcecaoNascomercio("Erro em fListar Cor [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dCor) As ColecaoCor

      Dim retorno As ColecaoCor
      Dim persistencia As pCor
      Dim retornoPersistencia As ColecaoCor

      Try

        retorno = New ColecaoCor

        persistencia = New pCor
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

        Throw

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fConsultar Cor [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dCor) As Integer

      Dim retorno As Integer
      Dim persistencia As pCor

      Try

        persistencia = New pCor
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir Cor [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fIncluir = retorno

    End Function

    Public Function fImportar(ByVal dados As dCor) As Integer

      Dim retorno As Integer
      Dim persistencia As pCor

      Try

        persistencia = New pCor
        retorno = persistencia.Importar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fImportar Cor [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fImportar = retorno

    End Function

    Public Function fAlterar(ByVal dados As dCor) As Integer

      Dim retorno As Integer
      Dim persistencia As pCor

      Try

        persistencia = New pCor
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar Cor [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dCor) As Integer

      Dim retorno As Integer
      Dim persistencia As pCor

      Try

        persistencia = New pCor
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir Cor [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
