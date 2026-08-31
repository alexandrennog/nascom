Imports ncDados.nsDados
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsRegras

  Public Class rTipoFrete

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoTipoFrete

      Dim retorno As ColecaoTipoFrete

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar TipoFrete [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoTipoFrete

      Dim retorno As ColecaoTipoFrete
      Dim dados As dTipoFrete

      Try

        retorno = New ColecaoTipoFrete()

        dados = New dTipoFrete()
        dados.cid = 1
        dados.codigo = "0"
        dados.descricao = "Por conta de terceiros"
        retorno.Add(dados)

        dados = New dTipoFrete()
        dados.cid = 2
        dados.codigo = "1"
        dados.descricao = "Por conta do emitente"
        retorno.Add(dados)

        dados = New dTipoFrete()
        dados.cid = 3
        dados.codigo = "2"
        dados.descricao = "Por conta do destinatário"
        retorno.Add(dados)

        dados = New dTipoFrete()
        dados.cid = 4
        dados.codigo = "9"
        dados.descricao = "Sem cobrança de frete"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar TipoFrete [" & Me.ToString() & "] - " & ex.Message, ex)

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
        Case 3
          RetornarCodigo = "2"
        Case 4
          RetornarCodigo = "9"
      End Select
    End Function

  End Class

End Namespace