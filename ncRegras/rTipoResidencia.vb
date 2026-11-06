Imports ncDados.nsDados
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsRegras

  Public Class rTipoResidencia

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoTipoResidencia

      Dim retorno As ColecaoTipoResidencia

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar TipoResidencia [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoTipoResidencia

      Dim retorno As ColecaoTipoResidencia
      Dim dados As dTipoResidencia

      Try

        retorno = New ColecaoTipoResidencia()

        dados = New dTipoResidencia()
        dados.codigo = "P"
        dados.descricao = "Própria"
        retorno.Add(dados)

        dados = New dTipoResidencia()
        dados.codigo = "A"
        dados.descricao = "Alugada"
        retorno.Add(dados)

        dados = New dTipoResidencia()
        dados.codigo = "R"
        dados.descricao = "Parentes"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar TipoResidencia [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListar = retorno

    End Function

  End Class

End Namespace