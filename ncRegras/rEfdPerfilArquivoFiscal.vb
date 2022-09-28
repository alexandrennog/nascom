Imports ncDados.nsDados
Imports ncDados.nsEFD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEFD

  Public Class rEfdPerfilArquivoFiscal

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoEfdPerfilArquivoFiscal

      Dim retorno As ColecaoEfdPerfilArquivoFiscal

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar EfdPerfilArquivoFiscal [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoEfdPerfilArquivoFiscal

      Dim retorno As ColecaoEfdPerfilArquivoFiscal
      Dim dados As dEfdPerfilArquivoFiscal

      Try

        retorno = New ColecaoEfdPerfilArquivoFiscal()

        dados = New dEfdPerfilArquivoFiscal()
        dados.codigo = "A"
        dados.descricao = "Perfil A"
        retorno.Add(dados)

        dados = New dEfdPerfilArquivoFiscal()
        dados.codigo = "B"
        dados.descricao = "Perfil B"
        retorno.Add(dados)

        dados = New dEfdPerfilArquivoFiscal()
        dados.codigo = "C"
        dados.descricao = "Perfil C"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar EfdPerfilArquivoFiscal [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

  End Class

End Namespace