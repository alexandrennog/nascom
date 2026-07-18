Imports System.Transactions

Imports ncDados.nsImpostoIcms
Imports ncPersistencia.nsImpostoIcms
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsImpostoIcms

  Public Class rImpostoIcms

    '-- M�todos de controle ( V�rias chamadas; Controle de transa��o )

    Public Function Listar() As ColecaoImpostoIcms

      Dim retorno As ColecaoImpostoIcms

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar ImpostoIcms [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dImpostoIcms) As ColecaoImpostoIcms

      Dim retorno As ColecaoImpostoIcms

      Try

        retorno = fConsultar(dados)

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar ImpostoIcms [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal regra_cid As Integer) As dImpostoIcms

      Dim retorno As dImpostoIcms
      Dim dados As dImpostoIcms
      Dim colecao As ColecaoImpostoIcms


      Try

        dados = New dImpostoIcms()


        dados.regra_cid = regra_cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dImpostoIcms

            item = colecao(0)

            retorno = New dImpostoIcms()

            retorno.regra_cid = cFuncoes.RetornarInteiro(item.regra_cid)
            retorno.origem = item.origem
            retorno.cst = cFuncoes.RetornarTexto(item.cst)
            retorno.csosn = cFuncoes.RetornarTexto(item.csosn)
            retorno.aliquota = item.aliquota
            retorno.reducaoBase = item.reducaoBase
            retorno.modalidadeBc = item.modalidadeBc
            retorno.aliquotaSt = item.aliquotaSt
            retorno.margemValorAgregado = item.margemValorAgregado
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
        Throw New ExcecaoNascomercio("Erro em Consultar ImpostoIcms [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dImpostoIcms) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ImpostoIcms [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dImpostoIcms) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar ImpostoIcms [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dImpostoIcms) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ImpostoIcms [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    '-- M�todos padr�o ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoImpostoIcms

      Dim retorno As ColecaoImpostoIcms
      Dim persistencia As pImpostoIcms
      Dim retornoPersistencia As ColecaoImpostoIcms

      Try

        retorno = New ColecaoImpostoIcms

        persistencia = New pImpostoIcms
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
        Throw New ExcecaoNascomercio("Erro em fListar ImpostoIcms [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dImpostoIcms) As ColecaoImpostoIcms

      Dim retorno As ColecaoImpostoIcms
      Dim persistencia As pImpostoIcms
      Dim retornoPersistencia As ColecaoImpostoIcms

      Try

        retorno = New ColecaoImpostoIcms

        persistencia = New pImpostoIcms
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
        Throw New ExcecaoNascomercio("Erro em fConsultar ImpostoIcms [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dImpostoIcms) As Integer

      Dim retorno As Integer
      Dim persistencia As pImpostoIcms

      Try

        persistencia = New pImpostoIcms
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir ImpostoIcms [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dImpostoIcms) As Integer

      Dim retorno As Integer
      Dim persistencia As pImpostoIcms

      Try

        persistencia = New pImpostoIcms
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar ImpostoIcms [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dImpostoIcms) As Integer

      Dim retorno As Integer
      Dim persistencia As pImpostoIcms

      Try

        persistencia = New pImpostoIcms
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir ImpostoIcms [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
