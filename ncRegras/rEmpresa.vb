Imports System.Transactions

Imports ncDados.nsEmpresa
Imports ncPersistencia.nsEmpresa
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEmpresa

  Public Class rEmpresa

    '-- M�todos de controle ( V�rias chamadas; Controle de transa��o )

    Public Function Listar() As ColecaoEmpresa

      Dim retorno As ColecaoEmpresa

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dEmpresa) As ColecaoEmpresa

      Dim retorno As ColecaoEmpresa

      Try

        retorno = fConsultar(dados)

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal cid As Integer) As dEmpresa

      Dim retorno As dEmpresa
      Dim dados As dEmpresa
      Dim colecao As ColecaoEmpresa


      Try

        dados = New dEmpresa()


        dados.cid = cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dEmpresa

            item = colecao(0)

            retorno = New dEmpresa()

            retorno.cid = cFuncoes.RetornarInteiro(item.cid)
            retorno.cnpj = cFuncoes.RetornarTexto(item.cnpj)
            retorno.razaoSocial = cFuncoes.RetornarTexto(item.razaoSocial)
            retorno.crt = item.crt
            retorno.uf = cFuncoes.RetornarTexto(item.uf)
            retorno.municipio = cFuncoes.RetornarInteiro(item.municipio)
            retorno.createdAt = item.createdAt
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
        Throw New ExcecaoNascomercio("Erro em Consultar Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dEmpresa) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Importar(ByVal dados As dEmpresa) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fImportar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Importar Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Importar = retorno

    End Function

    Public Function Alterar(ByVal dados As dEmpresa) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dEmpresa) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    '-- M�todos padr�o ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoEmpresa

      Dim retorno As ColecaoEmpresa
      Dim persistencia As pEmpresa
      Dim retornoPersistencia As ColecaoEmpresa

      Try

        retorno = New ColecaoEmpresa

        persistencia = New pEmpresa
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
        Throw New ExcecaoNascomercio("Erro em fListar Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dEmpresa) As ColecaoEmpresa

      Dim retorno As ColecaoEmpresa
      Dim persistencia As pEmpresa
      Dim retornoPersistencia As ColecaoEmpresa

      Try

        retorno = New ColecaoEmpresa

        persistencia = New pEmpresa
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
        Throw New ExcecaoNascomercio("Erro em fConsultar Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dEmpresa) As Integer

      Dim retorno As Integer
      Dim persistencia As pEmpresa

      Try

        persistencia = New pEmpresa
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fImportar(ByVal dados As dEmpresa) As Integer

      Dim retorno As Integer
      Dim persistencia As pEmpresa

      Try

        persistencia = New pEmpresa
        retorno = persistencia.Importar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fImportar Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fImportar = retorno

    End Function

    Public Function fAlterar(ByVal dados As dEmpresa) As Integer

      Dim retorno As Integer
      Dim persistencia As pEmpresa

      Try

        persistencia = New pEmpresa
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dEmpresa) As Integer

      Dim retorno As Integer
      Dim persistencia As pEmpresa

      Try

        persistencia = New pEmpresa
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
