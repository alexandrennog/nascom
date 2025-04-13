Imports ncDados.nsDados
Imports ncDados.nsEFD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEFD

  Public Class rEfdTipoPessoa

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoEfdTipoPessoa

      Dim retorno As ColecaoEfdTipoPessoa

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar EfdTipoPessoa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoEfdTipoPessoa

      Dim retorno As ColecaoEfdTipoPessoa
      Dim dados As dEfdTipoPessoa

      Try

        retorno = New ColecaoEfdTipoPessoa()

        dados = New dEfdTipoPessoa()
        dados.codigo = "F"
        dados.descricao = "Pessoa Física"
        retorno.Add(dados)

        dados = New dEfdTipoPessoa()
        dados.codigo = "J"
        dados.descricao = "Pessoa Jurídica"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar EfdTipoPessoa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

  End Class

End Namespace