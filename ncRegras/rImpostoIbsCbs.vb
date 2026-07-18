Imports System.Transactions

Imports ncDados.nsImpostoIbsCbs
Imports ncPersistencia.nsImpostoIbsCbs
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsImpostoIbsCbs

  Public Class rImpostoIbsCbs

    '-- M�todos de controle ( V�rias chamadas; Controle de transa��o )

    Public Function Listar() As ColecaoImpostoIbsCbs

      Dim retorno As ColecaoImpostoIbsCbs

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar ImpostoIbsCbs [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dImpostoIbsCbs) As ColecaoImpostoIbsCbs

      Dim retorno As ColecaoImpostoIbsCbs

      Try

        retorno = fConsultar(dados)

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar ImpostoIbsCbs [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal regra_cid As Integer) As dImpostoIbsCbs

      Dim retorno As dImpostoIbsCbs
      Dim dados As dImpostoIbsCbs
      Dim colecao As ColecaoImpostoIbsCbs


      Try

        dados = New dImpostoIbsCbs()


        dados.regra_cid = regra_cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dImpostoIbsCbs

            item = colecao(0)

            retorno = New dImpostoIbsCbs()

            retorno.regra_cid = cFuncoes.RetornarInteiro(item.regra_cid)
            retorno.cstIbsCbs = cFuncoes.RetornarTexto(item.cstIbsCbs)
            retorno.cClassTrib = cFuncoes.RetornarTexto(item.cClassTrib)
            retorno.aliquotaIbsUf = item.aliquotaIbsUf
            retorno.aliquotaIbsMunicipio = item.aliquotaIbsMunicipio
            retorno.aliquotaCbs = item.aliquotaCbs
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
        Throw New ExcecaoNascomercio("Erro em Consultar ImpostoIbsCbs [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dImpostoIbsCbs) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ImpostoIbsCbs [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dImpostoIbsCbs) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar ImpostoIbsCbs [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dImpostoIbsCbs) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ImpostoIbsCbs [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    '-- M�todos padr�o ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoImpostoIbsCbs

      Dim retorno As ColecaoImpostoIbsCbs
      Dim persistencia As pImpostoIbsCbs
      Dim retornoPersistencia As ColecaoImpostoIbsCbs

      Try

        retorno = New ColecaoImpostoIbsCbs

        persistencia = New pImpostoIbsCbs
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
        Throw New ExcecaoNascomercio("Erro em fListar ImpostoIbsCbs [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dImpostoIbsCbs) As ColecaoImpostoIbsCbs

      Dim retorno As ColecaoImpostoIbsCbs
      Dim persistencia As pImpostoIbsCbs
      Dim retornoPersistencia As ColecaoImpostoIbsCbs

      Try

        retorno = New ColecaoImpostoIbsCbs

        persistencia = New pImpostoIbsCbs
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
        Throw New ExcecaoNascomercio("Erro em fConsultar ImpostoIbsCbs [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dImpostoIbsCbs) As Integer

      Dim retorno As Integer
      Dim persistencia As pImpostoIbsCbs

      Try

        persistencia = New pImpostoIbsCbs
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir ImpostoIbsCbs [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dImpostoIbsCbs) As Integer

      Dim retorno As Integer
      Dim persistencia As pImpostoIbsCbs

      Try

        persistencia = New pImpostoIbsCbs
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar ImpostoIbsCbs [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dImpostoIbsCbs) As Integer

      Dim retorno As Integer
      Dim persistencia As pImpostoIbsCbs

      Try

        persistencia = New pImpostoIbsCbs
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir ImpostoIbsCbs [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
