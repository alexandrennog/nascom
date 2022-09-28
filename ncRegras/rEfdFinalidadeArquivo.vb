Imports ncDados.nsDados
Imports ncDados.nsEFD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEFD

  Public Class rEfdFinalidadeArquivo

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoEfdFinalidadeArquivo

      Dim retorno As ColecaoEfdFinalidadeArquivo

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar EfdFinalidadeArquivo [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoEfdFinalidadeArquivo

      Dim retorno As ColecaoEfdFinalidadeArquivo
      Dim dados As dEfdFinalidadeArquivo

      Try

        retorno = New ColecaoEfdFinalidadeArquivo()

        dados = New dEfdFinalidadeArquivo()
        dados.codigo = "0"
        dados.descricao = "Remessa do arquivo original"
        retorno.Add(dados)

        dados = New dEfdFinalidadeArquivo()
        dados.codigo = "1"
        dados.descricao = "Remessao do arquivo substituto"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar EfdFinalidadeArquivo [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

  End Class

End Namespace