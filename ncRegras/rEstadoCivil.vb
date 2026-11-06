Imports ncDados.nsDados
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsRegras

  Public Class rEstadoCivil

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoEstadoCivil

      Dim retorno As ColecaoEstadoCivil

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar EstadoCivil [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoEstadoCivil

      Dim retorno As ColecaoEstadoCivil
      Dim dados As dEstadoCivil

      Try

        retorno = New ColecaoEstadoCivil()

        dados = New dEstadoCivil()
        dados.codigo = "S"
        dados.descricao = "Solteiro(a)"
        retorno.Add(dados)

        dados = New dEstadoCivil()
        dados.codigo = "C"
        dados.descricao = "Casado(a)"
        retorno.Add(dados)

        dados = New dEstadoCivil()
        dados.codigo = "D"
        dados.descricao = "Divorciado(a)"
        retorno.Add(dados)

        dados = New dEstadoCivil()
        dados.codigo = "V"
        dados.descricao = "Viúvo(a)"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar EstadoCivil [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListar = retorno

    End Function

  End Class

End Namespace