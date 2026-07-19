Imports ncDados.nsDados
Imports ncComum.nsExcecao

Namespace nsRegras

  Public Class rOrigemMercadoria

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoOrigemMercadoria

      Dim retorno As ColecaoOrigemMercadoria

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar OrigemMercadoria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoOrigemMercadoria

      Dim retorno As ColecaoOrigemMercadoria
      Dim dados As dOrigemMercadoria

      Try

        retorno = New ColecaoOrigemMercadoria()

        dados = New dOrigemMercadoria()
        dados.codigo = 0
        dados.descricao = "0 - Nacional"
        retorno.Add(dados)

        dados = New dOrigemMercadoria()
        dados.codigo = 1
        dados.descricao = "1 - Estrangeira"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar OrigemMercadoria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

  End Class

End Namespace
