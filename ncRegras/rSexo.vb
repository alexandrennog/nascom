Imports ncDados.nsDados
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsRegras

  Public Class rSexo

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoSexo

      Dim retorno As ColecaoSexo

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Sexo [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoSexo

      Dim retorno As ColecaoSexo
      Dim dados As dSexo

      Try

        retorno = New ColecaoSexo()

        dados = New dSexo()
        dados.codigo = "F"
        dados.descricao = "Feminino"
        retorno.Add(dados)

        dados = New dSexo()
        dados.codigo = "M"
        dados.descricao = "Masculino"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar Sexo [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

  End Class

End Namespace