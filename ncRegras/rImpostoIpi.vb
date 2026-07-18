Imports System.Transactions

Imports ncDados.nsImpostoIpi
Imports ncPersistencia.nsImpostoIpi
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsImpostoIpi

  Public Class rImpostoIpi

    '-- M�todos de controle ( V�rias chamadas; Controle de transa��o )

    Public Function Listar() As ColecaoImpostoIpi

      Dim retorno As ColecaoImpostoIpi

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar ImpostoIpi [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dImpostoIpi) As ColecaoImpostoIpi

      Dim retorno As ColecaoImpostoIpi

      Try

        retorno = fConsultar(dados)

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar ImpostoIpi [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal regra_cid As Integer) As dImpostoIpi

      Dim retorno As dImpostoIpi
      Dim dados As dImpostoIpi
      Dim colecao As ColecaoImpostoIpi


      Try

        dados = New dImpostoIpi()


        dados.regra_cid = regra_cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dImpostoIpi

            item = colecao(0)

            retorno = New dImpostoIpi()

            retorno.regra_cid = cFuncoes.RetornarInteiro(item.regra_cid)
            retorno.cst = cFuncoes.RetornarTexto(item.cst)
            retorno.aliquota = item.aliquota
            retorno.codigoEnquadramento = cFuncoes.RetornarTexto(item.codigoEnquadramento)
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
        Throw New ExcecaoNascomercio("Erro em Consultar ImpostoIpi [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dImpostoIpi) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ImpostoIpi [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dImpostoIpi) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar ImpostoIpi [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dImpostoIpi) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ImpostoIpi [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    '-- M�todos padr�o ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoImpostoIpi

      Dim retorno As ColecaoImpostoIpi
      Dim persistencia As pImpostoIpi
      Dim retornoPersistencia As ColecaoImpostoIpi

      Try

        retorno = New ColecaoImpostoIpi

        persistencia = New pImpostoIpi
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
        Throw New ExcecaoNascomercio("Erro em fListar ImpostoIpi [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dImpostoIpi) As ColecaoImpostoIpi

      Dim retorno As ColecaoImpostoIpi
      Dim persistencia As pImpostoIpi
      Dim retornoPersistencia As ColecaoImpostoIpi

      Try

        retorno = New ColecaoImpostoIpi

        persistencia = New pImpostoIpi
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
        Throw New ExcecaoNascomercio("Erro em fConsultar ImpostoIpi [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dImpostoIpi) As Integer

      Dim retorno As Integer
      Dim persistencia As pImpostoIpi

      Try

        persistencia = New pImpostoIpi
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir ImpostoIpi [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dImpostoIpi) As Integer

      Dim retorno As Integer
      Dim persistencia As pImpostoIpi

      Try

        persistencia = New pImpostoIpi
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar ImpostoIpi [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dImpostoIpi) As Integer

      Dim retorno As Integer
      Dim persistencia As pImpostoIpi

      Try

        persistencia = New pImpostoIpi
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir ImpostoIpi [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
