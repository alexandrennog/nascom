Imports System.Transactions

Imports ncDados.nsImpostoCofins
Imports ncPersistencia.nsImpostoCofins
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsImpostoCofins

  Public Class rImpostoCofins

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoImpostoCofins

      Dim retorno As ColecaoImpostoCofins

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar ImpostoCofins [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dImpostoCofins) As ColecaoImpostoCofins

      Dim retorno As ColecaoImpostoCofins

      Try

        retorno = fConsultar(dados)

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar ImpostoCofins [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal regra_cid As Integer) As dImpostoCofins

      Dim retorno As dImpostoCofins
      Dim dados As dImpostoCofins
      Dim colecao As ColecaoImpostoCofins


      Try

        dados = New dImpostoCofins()


        dados.regra_cid = regra_cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dImpostoCofins

            item = colecao(0)

            retorno = New dImpostoCofins()

            retorno.regra_cid = cFuncoes.RetornarInteiro(item.regra_cid)
            retorno.cst = cFuncoes.RetornarTexto(item.cst)
            retorno.aliquota = item.aliquota
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
        Throw New ExcecaoNascomercio("Erro em Consultar ImpostoCofins [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dImpostoCofins) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ImpostoCofins [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dImpostoCofins) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar ImpostoCofins [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dImpostoCofins) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ImpostoCofins [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoImpostoCofins

      Dim retorno As ColecaoImpostoCofins
      Dim persistencia As pImpostoCofins
      Dim retornoPersistencia As ColecaoImpostoCofins

      Try

        retorno = New ColecaoImpostoCofins

        persistencia = New pImpostoCofins
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
        Throw New ExcecaoNascomercio("Erro em fListar ImpostoCofins [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dImpostoCofins) As ColecaoImpostoCofins

      Dim retorno As ColecaoImpostoCofins
      Dim persistencia As pImpostoCofins
      Dim retornoPersistencia As ColecaoImpostoCofins

      Try

        retorno = New ColecaoImpostoCofins

        persistencia = New pImpostoCofins
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
        Throw New ExcecaoNascomercio("Erro em fConsultar ImpostoCofins [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dImpostoCofins) As Integer

      Dim retorno As Integer
      Dim persistencia As pImpostoCofins

      Try

        persistencia = New pImpostoCofins
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir ImpostoCofins [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dImpostoCofins) As Integer

      Dim retorno As Integer
      Dim persistencia As pImpostoCofins

      Try

        persistencia = New pImpostoCofins
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar ImpostoCofins [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dImpostoCofins) As Integer

      Dim retorno As Integer
      Dim persistencia As pImpostoCofins

      Try

        persistencia = New pImpostoCofins
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir ImpostoCofins [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
