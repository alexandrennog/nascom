Imports ncDados.nsDados
Imports ncDados.nsEFD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEFD

  Public Class rEfdTipoAtividade

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoEfdTipoAtividade

      Dim retorno As ColecaoEfdTipoAtividade

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar EfdTipoAtividade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoEfdTipoAtividade

      Dim retorno As ColecaoEfdTipoAtividade
      Dim dados As dEfdTipoAtividade

      Try

        retorno = New ColecaoEfdTipoAtividade()

        dados = New dEfdTipoAtividade()
        dados.codigo = "0"
        dados.descricao = "Industrial ou equiparado a industrial"
        retorno.Add(dados)

        dados = New dEfdTipoAtividade()
        dados.codigo = "1"
        dados.descricao = "Outros"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar EfdTipoAtividade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

  End Class

End Namespace