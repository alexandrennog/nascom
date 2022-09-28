Imports System.Transactions

Imports ncDados.nsGiro
Imports ncPersistencia.nsGiro
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsGiro

  Public Class rGiro

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoGiro

      Dim retorno As ColecaoGiro

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Giro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dGiro) As ColecaoGiro

      Dim retorno As ColecaoGiro

      Try

        retorno = fConsultar(dados)

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Giro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal produto_cid As Integer, ByVal codigoBarras As String) As dGiro

      Dim retorno As dGiro
      Dim dados As dGiro
      Dim colecao As ColecaoGiro

      Try

        dados = New dGiro()

        dados.produto_cid = produto_cid
        dados.codigoBarras = codigoBarras

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dGiro

            item = colecao(0)

            retorno = New dGiro()

            retorno.produto_cid = cFuncoes.RetornarInteiro(item.produto_cid)
            retorno.codigoBarras = cFuncoes.RetornarTexto(item.codigoBarras)
            retorno.dataInicio = cFuncoes.RetornarData(item.dataInicio)
            retorno.dataFim = cFuncoes.RetornarData(item.dataFim)
            retorno.dias = cFuncoes.RetornarInteiro(item.dias)
            retorno.quantidade = cFuncoes.RetornarInteiro(item.quantidade)
            retorno.dataAtual = cFuncoes.RetornarData(item.dataAtual)
            retorno.usuario_cid = cFuncoes.RetornarInteiro(item.usuario_cid)
            retorno.usuario_nomeCompleto = cFuncoes.RetornarTexto(item.usuario_nomeCompleto)
            retorno.situacao = cFuncoes.RetornarTexto(item.situacao)
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
        Throw New ExcecaoNascomercio("Erro em Consultar Giro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dGiro) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Giro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Importar(ByVal dados As dGiro) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fImportar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Importar Giro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Importar = retorno

    End Function

    Public Function Alterar(ByVal dados As dGiro) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Giro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dGiro) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Giro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoGiro

      Dim retorno As ColecaoGiro
      Dim persistencia As pGiro
      Dim retornoPersistencia As ColecaoGiro

      Try

        retorno = New ColecaoGiro

        persistencia = New pGiro
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
        Throw New ExcecaoNascomercio("Erro em fListar Giro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dGiro) As ColecaoGiro

      Dim retorno As ColecaoGiro
      Dim persistencia As pGiro
      Dim retornoPersistencia As ColecaoGiro

      Try

        retorno = New ColecaoGiro

        persistencia = New pGiro
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
        Throw New ExcecaoNascomercio("Erro em fConsultar Giro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dGiro) As Integer

      Dim retorno As Integer
      Dim persistencia As pGiro

      Try

        persistencia = New pGiro
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir Giro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fImportar(ByVal dados As dGiro) As Integer

      Dim retorno As Integer
      Dim persistencia As pGiro

      Try

        persistencia = New pGiro
        retorno = persistencia.Importar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fImportar Giro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fImportar = retorno

    End Function

    Public Function fAlterar(ByVal dados As dGiro) As Integer

      Dim retorno As Integer
      Dim persistencia As pGiro

      Try

        persistencia = New pGiro
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar Giro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dGiro) As Integer

      Dim retorno As Integer
      Dim persistencia As pGiro

      Try

        persistencia = New pGiro
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir Giro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
