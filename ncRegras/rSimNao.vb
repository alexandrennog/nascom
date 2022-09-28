Imports ncDados.nsDados
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsRegras

  Public Class rSimNao

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoSimNao

      Dim retorno As ColecaoSimNao

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar SimNao [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoSimNao

      Dim retorno As ColecaoSimNao
      Dim dados As dSimNao

      Try

        retorno = New ColecaoSimNao()

        dados = New dSimNao()
        dados.codigo = "S"
        dados.descricao = "Sim"
        retorno.Add(dados)

        dados = New dSimNao()
        dados.codigo = "N"
        dados.descricao = "Não"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar SimNao [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

  End Class

End Namespace