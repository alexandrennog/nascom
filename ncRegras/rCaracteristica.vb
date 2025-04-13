Imports System.Transactions

Imports ncDados.nsCaracteristica
Imports ncPersistencia.nsCaracteristica
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCaracteristica

  Public Class rCaracteristica

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoCaracteristica

      Dim retorno As ColecaoCaracteristica

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dCaracteristica) As ColecaoCaracteristica

      Dim retorno As ColecaoCaracteristica

      Try

        retorno = fConsultar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function ConsultarPorCID(ByVal cid As Integer) As dCaracteristica

      Dim retorno As dCaracteristica

      Try

        retorno = fConsultarPorCID(cid)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em ConsultarPorCID Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ConsultarPorCID = retorno

    End Function

    Public Function ConsultarPorNome(ByVal nome As String) As dCaracteristica

      Dim retorno As dCaracteristica

      Try

        retorno = fConsultarPorNome(nome)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em ConsultarPorNome Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ConsultarPorNome = retorno

    End Function

    Public Function ConsultarPorCodigo(ByVal codigo As String) As dCaracteristica

      Dim retorno As dCaracteristica

      Try

        retorno = fConsultarPorCodigo(codigo)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em ConsultarPorNome Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ConsultarPorCodigo = retorno

    End Function

    Public Function Incluir(ByVal dados As dCaracteristica) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dCaracteristica) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dCaracteristica) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoCaracteristica

      Dim retorno As ColecaoCaracteristica
      Dim persistencia As pCaracteristica
      Dim retornoPersistencia As ColecaoCaracteristica

      Try

        retorno = New ColecaoCaracteristica

        persistencia = New pCaracteristica
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
        Throw New ExcecaoNascomercio("Erro em fListar Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dCaracteristica) As ColecaoCaracteristica

      Dim retorno As ColecaoCaracteristica
      Dim persistencia As pCaracteristica
      Dim retornoPersistencia As ColecaoCaracteristica

      Try

        retorno = New ColecaoCaracteristica

        persistencia = New pCaracteristica
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
        Throw New ExcecaoNascomercio("Erro em fConsultar Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fConsultarPorCID(ByVal cid As Integer) As dCaracteristica

      Dim retorno As dCaracteristica
      Dim persistencia As pCaracteristica
      Dim retornoPersistencia As ColecaoCaracteristica
      Dim dados As dCaracteristica


      Try

        retorno = New dCaracteristica()
        dados = New dCaracteristica()
        persistencia = New pCaracteristica()


        dados.cid = cid

        retornoPersistencia = persistencia.Consultar(dados)

        If Not retornoPersistencia Is Nothing Then
          If retornoPersistencia.Count > 0 Then
            dados = retornoPersistencia(0)

            retorno.cid = cFuncoes.RetornarInteiro(dados.cid)
            retorno.nome = cFuncoes.RetornarTexto(dados.nome)
            retorno.situacao = cFuncoes.RetornarTexto(dados.situacao)
            retorno.codigo = cFuncoes.RetornarTexto(dados.codigo)
          Else
            retorno = Nothing
          End If
        Else
          retorno = Nothing
        End If

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fConsultarPorCID Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultarPorCID = retorno

    End Function

    Public Function fConsultarPorNome(ByVal nome As String) As dCaracteristica

      Dim retorno As dCaracteristica
      Dim persistencia As pCaracteristica
      Dim retornoPersistencia As ColecaoCaracteristica
      Dim dados As dCaracteristica


      Try

        retorno = New dCaracteristica()
        dados = New dCaracteristica()
        persistencia = New pCaracteristica()


        dados.nome = nome

        retornoPersistencia = persistencia.Consultar(dados)

        If Not retornoPersistencia Is Nothing Then
          If retornoPersistencia.Count > 0 Then
            dados = retornoPersistencia(0)

            retorno.cid = cFuncoes.RetornarInteiro(dados.cid)
            retorno.nome = cFuncoes.RetornarTexto(dados.nome)
            retorno.situacao = cFuncoes.RetornarTexto(dados.situacao)
            retorno.codigo = cFuncoes.RetornarTexto(dados.codigo)
          Else
            retorno = Nothing
          End If
        Else
          retorno = Nothing
        End If

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fConsultarPorNome Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultarPorNome = retorno

    End Function

    Public Function fConsultarPorCodigo(ByVal codigo As String) As dCaracteristica

      Dim retorno As dCaracteristica
      Dim persistencia As pCaracteristica
      Dim retornoPersistencia As ColecaoCaracteristica
      Dim dados As dCaracteristica


      Try

        retorno = New dCaracteristica()
        dados = New dCaracteristica()
        persistencia = New pCaracteristica()


        dados.codigo = codigo

        retornoPersistencia = persistencia.Consultar(dados)

        If Not retornoPersistencia Is Nothing Then
          If retornoPersistencia.Count > 0 Then
            dados = retornoPersistencia(0)

            retorno.cid = cFuncoes.RetornarInteiro(dados.cid)
            retorno.nome = cFuncoes.RetornarTexto(dados.nome)
            retorno.situacao = cFuncoes.RetornarTexto(dados.situacao)
            retorno.codigo = cFuncoes.RetornarTexto(dados.codigo)
          Else
            retorno = Nothing
          End If
        Else
          retorno = Nothing
        End If

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fConsultarPorNome Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultarPorCodigo = retorno

    End Function

    Public Function fIncluir(ByVal dados As dCaracteristica) As Integer

      Dim retorno As Integer
      Dim persistencia As pCaracteristica

      Try

        persistencia = New pCaracteristica
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dCaracteristica) As Integer

      Dim retorno As Integer
      Dim persistencia As pCaracteristica

      Try

        persistencia = New pCaracteristica
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dCaracteristica) As Integer

      Dim retorno As Integer
      Dim persistencia As pCaracteristica

      Try

        persistencia = New pCaracteristica
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
