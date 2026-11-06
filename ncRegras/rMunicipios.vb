Imports System.Transactions

Imports ncDados.nsMunicipios
Imports ncPersistencia.nsMunicipios
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsMunicipios

  Public Class rMunicipios

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoMunicipios

      Dim retorno As ColecaoMunicipios

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar municipios [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    Public Function ListarPorEstados(ByVal estados_cid As Integer) As ColecaoMunicipios

      Dim retorno As ColecaoMunicipios

      Try

        retorno = fListarPorEstado(estados_cid)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em ListarPorEstados municipios [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ListarPorEstados = retorno

    End Function

    Public Function Consultar(ByVal dados As dMunicipios) As ColecaoMunicipios

      Dim retorno As ColecaoMunicipios

      Try

        retorno = fConsultar(dados)

      Catch nex As ExcecaoNascomercio

        Throw

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar municipios [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal cid As Integer) As dMunicipios

      Dim retorno As dMunicipios
      Dim dados As dMunicipios
      Dim colecao As ColecaoMunicipios


      Try

        dados = New dMunicipios()


        dados.cid = cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dMunicipios

            item = colecao(0)

            retorno = New dMunicipios()

            retorno.cid = cFuncoes.RetornarInteiro(item.cid)
            retorno.codigo_ibge = cFuncoes.RetornarTexto(item.codigo_ibge)
            retorno.nome = cFuncoes.RetornarTexto(item.nome)
            retorno.estados_cid = cFuncoes.RetornarInteiro(item.estados_cid)
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
        Throw New ExcecaoNascomercio("Erro em Consultar municipios [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dMunicipios) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir municipios [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Incluir = retorno

    End Function

    Public Function Importar(ByVal dados As dMunicipios) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fImportar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Importar municipios [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Importar = retorno

    End Function

    Public Function Alterar(ByVal dados As dMunicipios) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar municipios [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dMunicipios) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir municipios [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoMunicipios

      Dim retorno As ColecaoMunicipios
      Dim persistencia As pMunicipios
      Dim retornoPersistencia As ColecaoMunicipios

      Try

        retorno = New ColecaoMunicipios

        persistencia = New pMunicipios
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
        Throw New ExcecaoNascomercio("Erro em fListar municipios [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListar = retorno

    End Function

    Public Function fListarPorEstado(ByVal estados_cid As Integer) As ColecaoMunicipios

      Dim retorno As ColecaoMunicipios
      Dim persistencia As pMunicipios
      Dim retornoPersistencia As ColecaoMunicipios

      Try

        retorno = New ColecaoMunicipios

        persistencia = New pMunicipios
        retornoPersistencia = persistencia.ListarPorEstado(estados_cid)

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
        Throw New ExcecaoNascomercio("Erro em fListarPorEstado municipios [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListarPorEstado = retorno

    End Function

    Public Function fConsultar(ByVal dados As dMunicipios) As ColecaoMunicipios

      Dim retorno As ColecaoMunicipios
      Dim persistencia As pMunicipios
      Dim retornoPersistencia As ColecaoMunicipios

      Try

        retorno = New ColecaoMunicipios

        persistencia = New pMunicipios
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
        Throw New ExcecaoNascomercio("Erro em fConsultar municipios [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dMunicipios) As Integer

      Dim retorno As Integer
      Dim persistencia As pMunicipios

      Try

        persistencia = New pMunicipios
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir municipios [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fIncluir = retorno

    End Function

    Public Function fImportar(ByVal dados As dMunicipios) As Integer

      Dim retorno As Integer
      Dim persistencia As pMunicipios

      Try

        persistencia = New pMunicipios
        retorno = persistencia.Importar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fImportar municipios [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fImportar = retorno

    End Function

    Public Function fAlterar(ByVal dados As dMunicipios) As Integer

      Dim retorno As Integer
      Dim persistencia As pMunicipios

      Try

        persistencia = New pMunicipios
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar municipios [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dMunicipios) As Integer

      Dim retorno As Integer
      Dim persistencia As pMunicipios

      Try

        persistencia = New pMunicipios
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir municipios [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
