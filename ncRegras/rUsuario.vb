Imports System.Transactions

Imports ncDados.nsUsuario
Imports ncPersistencia.nsUsuario
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsUsuario

  Public Class rUsuario

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As colecaoUsuario

      Dim retorno As colecaoUsuario

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Usuario [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

        Public Function Consultar(ByVal dados As dUsuario) As colecaoUsuario

            Dim retorno As colecaoUsuario

            Try

                retorno = fConsultar(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw ex
                Throw New ExcecaoNascomercio("Erro em Consultar Usuario [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Consultar = retorno

        End Function

        Public Function ConsultarPorADM(ByVal dados As dUsuario) As ColecaoUsuario

            Dim retorno As ColecaoUsuario

            Try

                retorno = fConsultar(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw ex
                Throw New ExcecaoNascomercio("Erro em Consultar Usuario [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ConsultarPorADM = retorno

        End Function
        Public Function ConsultarPorCid(ByVal cid As Integer) As dUsuario

      Dim retorno As dUsuario
      Dim dados As dUsuario
      Dim colecao As ColecaoUsuario


      Try

        dados = New dUsuario()


        dados.cid = cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dUsuario

            item = colecao(0)

            retorno = New dUsuario()

                        retorno.cid = cFuncoes.RetornarInteiro(item.cid)
                        retorno.nomeCompleto = cFuncoes.RetornarTexto(item.nomeCompleto)
                        retorno.senha = cFuncoes.RetornarTexto(item.senha)
                        retorno.situacao = cFuncoes.RetornarTexto(item.situacao)
                        retorno.usuario = cFuncoes.RetornarTexto(item.usuario)
                        retorno.descontoProduto = cFuncoes.RetornarDecimal(item.descontoProduto)
                        retorno.descontoPedido = cFuncoes.RetornarDecimal(item.descontoPedido)
                        retorno.comissao = cFuncoes.RetornarDecimal(item.comissao)
                        retorno.usuarioPerfil_cid = cFuncoes.RetornarInteiro(item.usuarioPerfil_cid)
                        retorno.Email = cFuncoes.RetornarTexto(item.Email)
                    Else
            retorno = Nothing
          End If
        Else
          retorno = Nothing
        End If

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Usuario [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Return retorno

    End Function

    Public Function Incluir(ByVal dados As dUsuario) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Usuario [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dUsuario) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Usuario [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dUsuario) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Usuario [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoUsuario

      Dim retorno As ColecaoUsuario
      Dim persistencia As pUsuario
      Dim retornoPersistencia As ColecaoUsuario

      Try

        retorno = New ColecaoUsuario

        persistencia = New pUsuario
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
        Throw New ExcecaoNascomercio("Erro em fListar Usuario [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dUsuario) As ColecaoUsuario

      Dim retorno As colecaoUsuario
      Dim persistencia As pUsuario
      Dim retornoPersistencia As colecaoUsuario

      Try

        retorno = New colecaoUsuario

        persistencia = New pUsuario
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
        Throw ex
        Throw New ExcecaoNascomercio("Erro em fConsultar Usuario [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function
        Public Function fConsultarADM(ByVal perfil As String) As ColecaoUsuario

            Dim retorno As ColecaoUsuario
            Dim persistencia As pUsuario
            Dim retornoPersistencia As ColecaoUsuario

            Try

                retorno = New ColecaoUsuario

                persistencia = New pUsuario
                retornoPersistencia = persistencia.ConsultarADM(perfil)

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
                Throw ex
                Throw New ExcecaoNascomercio("Erro em fConsultar Usuario [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fConsultarADM = retorno

        End Function
        Public Function fIncluir(ByVal dados As dUsuario) As Integer

      Dim retorno As Integer
      Dim persistencia As pUsuario

      Try

        persistencia = New pUsuario
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir Usuario [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dUsuario) As Integer

      Dim retorno As Integer
      Dim persistencia As pUsuario

      Try

        persistencia = New pUsuario
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar Usuario [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dUsuario) As Integer

      Dim retorno As Integer
      Dim persistencia As pUsuario

      Try

        persistencia = New pUsuario
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir Usuario [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
