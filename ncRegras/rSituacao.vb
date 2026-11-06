Imports ncDados.nsDados
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsRegras

  Public Class rSituacao

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoSituacao

      Dim retorno As ColecaoSituacao

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Situacao [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    Public Function ListarFinan() As ColecaoSituacao

      Dim retorno As ColecaoSituacao

      Try

        retorno = fListarFinan()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Situacao Financeira [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Return retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoSituacao

      Dim retorno As ColecaoSituacao
      Dim dados As dSituacao

      Try

        retorno = New ColecaoSituacao()

        dados = New dSituacao()
        dados.codigo = "A"
        dados.descricao = "Ativo"
        retorno.Add(dados)

        dados = New dSituacao()
        dados.codigo = "I"
        dados.descricao = "Inativo"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar Situacao [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListar = retorno

    End Function


    Public Function fListarFinan() As ColecaoSituacao

      Dim retorno As ColecaoSituacao
      Dim dados As dSituacao

      Try

        retorno = New ColecaoSituacao()

        dados = New dSituacao()
        dados.codigo = "A"
        dados.descricao = "Ativo"
        retorno.Add(dados)

        dados = New dSituacao()
        dados.codigo = "N"
        dados.descricao = "Negativo"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar Situacao [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Return retorno

    End Function

  End Class

End Namespace