Imports System.Transactions

Imports ncDados.nsLoja
Imports ncPersistencia.nsLoja
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsLoja

  Public Class rLoja

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoLoja

      Dim retorno As ColecaoLoja

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Loja [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dLoja) As ColecaoLoja

      Dim retorno As ColecaoLoja

      Try

        retorno = fConsultar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Loja [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal cid As Integer) As dLoja

      Dim retorno As dLoja
      Dim dados As dLoja
      Dim colecao As ColecaoLoja


      Try

        dados = New dLoja()


        dados.cid = cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dLoja

            item = colecao(0)

            retorno = New dLoja()

            retorno.cid = cFuncoes.RetornarInteiro(item.cid)
            retorno.codigo = cFuncoes.RetornarTexto(item.codigo)
            retorno.nomeFantasia = cFuncoes.RetornarTexto(item.nomeFantasia)
            retorno.logradouro = cFuncoes.RetornarTexto(item.logradouro)
            retorno.numero = cFuncoes.RetornarInteiro(item.numero)
            retorno.complemento = cFuncoes.RetornarTexto(item.complemento)
            retorno.bairro = cFuncoes.RetornarTexto(item.bairro)
            retorno.cidade = cFuncoes.RetornarTexto(item.cidade)
            retorno.estado_cid = cFuncoes.RetornarInteiro(item.estado_cid)
            retorno.cep = cFuncoes.RetornarInteiro(item.cep)
            retorno.razaoSocial = cFuncoes.RetornarTexto(item.razaoSocial)
            retorno.cnpj = cFuncoes.RetornarTexto(item.cnpj)
            retorno.ddd = cFuncoes.RetornarInteiro(item.ddd)
            retorno.telefone = cFuncoes.RetornarInteiro(item.telefone)
            retorno.ramal = cFuncoes.RetornarInteiro(item.ramal)
            retorno.nomeContato = cFuncoes.RetornarTexto(item.nomeContato)
            retorno.situacao = cFuncoes.RetornarTexto(item.situacao)
            retorno.spc_codigo_associado = cFuncoes.RetornarTexto(item.spc_codigo_associado)
            retorno.spc_controle_informante = cFuncoes.RetornarTexto(item.spc_controle_informante)
                        retorno.spc_nome_informante = cFuncoes.RetornarTexto(item.spc_nome_informante)
                        retorno.Inscestadual = cFuncoes.RetornarTexto(item.Inscestadual)
                    Else
            retorno = Nothing
          End If
        Else
          retorno = Nothing
        End If

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Loja [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dLoja) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Loja [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dLoja) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Loja [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dLoja) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Loja [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoLoja

      Dim retorno As ColecaoLoja
      Dim persistencia As pLoja
      Dim retornoPersistencia As ColecaoLoja

      Try

        retorno = New ColecaoLoja()

        persistencia = New pLoja
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
        Throw New ExcecaoNascomercio("Erro em fListar Loja [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dLoja) As ColecaoLoja

      Dim retorno As ColecaoLoja
      Dim persistencia As pLoja
      Dim retornoPersistencia As ColecaoLoja

      Try

        retorno = New ColecaoLoja()

        persistencia = New pLoja
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
        Throw New ExcecaoNascomercio("Erro em fConsultar Loja [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dLoja) As Integer

      Dim retorno As Integer
      Dim persistencia As pLoja

      Try

        persistencia = New pLoja
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir Loja [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dLoja) As Integer

      Dim retorno As Integer
      Dim persistencia As pLoja

      Try

        persistencia = New pLoja
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar Loja [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dLoja) As Integer

      Dim retorno As Integer
      Dim persistencia As pLoja

      Try

        persistencia = New pLoja
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir Loja [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
