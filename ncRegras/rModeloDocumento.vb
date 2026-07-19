Imports ncDados.nsDados
Imports ncComum.nsExcecao

Namespace nsRegras

  Public Class rModeloDocumento

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoModeloDocumento

      Dim retorno As ColecaoModeloDocumento

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar ModeloDocumento [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoModeloDocumento

      Dim retorno As ColecaoModeloDocumento
      Dim dados As dModeloDocumento

      Try

        retorno = New ColecaoModeloDocumento()

        dados = New dModeloDocumento()
        dados.codigo = 55
        dados.descricao = "55 - NF-e"
        retorno.Add(dados)

        dados = New dModeloDocumento()
        dados.codigo = 65
        dados.descricao = "65 - NFC-e"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar ModeloDocumento [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

  End Class

End Namespace
