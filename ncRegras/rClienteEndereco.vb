Imports System.Transactions

Imports ncDados.nsCliente
Imports ncPersistencia.nsCliente
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCliente

  Public Class rClienteEndereco

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoClienteEndereco

      Dim retorno As ColecaoClienteEndereco

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Cliente - Endereço [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dClienteEndereco) As ColecaoClienteEndereco

      Dim retorno As ColecaoClienteEndereco

      Try

        retorno = fConsultar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Cliente - Endereço [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function ConsultarPorCID(ByVal cid As Integer) As dClienteEndereco

      Dim retorno As dClienteEndereco
      Dim dados As dClienteEndereco
      Dim colecao As ColecaoClienteEndereco

      Try

        dados = New dClienteEndereco()

        dados.cliente_cid = cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dClienteEndereco

            item = colecao(0)

            retorno = New dClienteEndereco()

            retorno.bairro = cFuncoes.RetornarTexto(item.bairro)
            retorno.cep = cFuncoes.RetornarInteiro(item.cep)
            retorno.cidade = cFuncoes.RetornarTexto(item.cidade)
            retorno.complemento = cFuncoes.RetornarTexto(item.complemento)
            retorno.estado_cid = cFuncoes.RetornarInteiro(item.estado_cid)
            retorno.logradouro = cFuncoes.RetornarTexto(item.logradouro)
            retorno.numero = cFuncoes.RetornarInteiro(item.numero)
            retorno.siglaEstado = cFuncoes.RetornarTexto(item.siglaEstado)

          Else
            retorno = Nothing
          End If
        Else
          retorno = Nothing
        End If

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar ClienteEndereco [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ConsultarPorCID = retorno

    End Function

    Public Function Incluir(ByVal dados As dClienteEndereco) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Cliente - Endereço [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Incluir = retorno

    End Function

    Public Function ExcluirPorCliente(ByVal cliente_cid As Integer) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluirPorCliente(cliente_cid)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Cliente - Endereço [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ExcluirPorCliente = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoClienteEndereco

      Dim retorno As ColecaoClienteEndereco
      Dim persistencia As pClienteEndereco
      Dim retornoPersistencia As ColecaoClienteEndereco

      Try

        retorno = New ColecaoClienteEndereco

        persistencia = New pClienteEndereco
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
        Throw New ExcecaoNascomercio("Erro em fListar Cliente - Endereço [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dClienteEndereco) As ColecaoClienteEndereco

      Dim retorno As ColecaoClienteEndereco
      Dim persistencia As pClienteEndereco
      Dim retornoPersistencia As ColecaoClienteEndereco

      Try

        retorno = New ColecaoClienteEndereco

        persistencia = New pClienteEndereco
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
        Throw New ExcecaoNascomercio("Erro em fConsultar Cliente - Endereço [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dClienteEndereco) As Integer

      Dim retorno As Integer
      Dim persistencia As pClienteEndereco

      Try

        persistencia = New pClienteEndereco
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir Cliente - Endereço [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fIncluir = retorno

    End Function

    Public Function fExcluirPorCliente(ByVal cliente_cid As Integer) As Integer

      Dim retorno As Integer
      Dim persistencia As pClienteEndereco

      Try

        persistencia = New pClienteEndereco
        retorno = persistencia.ExcluirPorCliente(cliente_cid)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir Cliente - Endereço [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fExcluirPorCliente = retorno

    End Function

  End Class

End Namespace

