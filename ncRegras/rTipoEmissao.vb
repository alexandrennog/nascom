Imports ncDados.nsDados
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsRegras

  Public Class rTipoEmissao

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoTipoEmissao

      Dim retorno As ColecaoTipoEmissao

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar TipoEmissao [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoTipoEmissao

      Dim retorno As ColecaoTipoEmissao
      Dim dados As dTipoEmissao

      Try

        retorno = New ColecaoTipoEmissao()

        dados = New dTipoEmissao()
        dados.cid = 1
        dados.codigo = "0"
        dados.descricao = "Emissão Própria"
        retorno.Add(dados)

        dados = New dTipoEmissao()
        dados.cid = 2
        dados.codigo = "1"
        dados.descricao = "Terceiros"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar TipoEmissao [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListar = retorno

    End Function

    Public Function RetornarCodigo(ByVal cid As Integer) As String
      RetornarCodigo = ""

      Select Case cid
        Case 1
          RetornarCodigo = "0"
        Case 2
          RetornarCodigo = "1"
      End Select
    End Function

  End Class

End Namespace