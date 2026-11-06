Imports ncDados.nsDados
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsRegras

  Public Class rTipoPagamento

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoTipoPagamento

      Dim retorno As ColecaoTipoPagamento

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar TipoPagamento [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoTipoPagamento

      Dim retorno As ColecaoTipoPagamento
      Dim dados As dTipoPagamento

      Try

        retorno = New ColecaoTipoPagamento()

        dados = New dTipoPagamento()
        dados.cid = 1
        dados.codigo = "0"
        dados.descricao = "À vista"
        retorno.Add(dados)

        dados = New dTipoPagamento()
        dados.cid = 2
        dados.codigo = "1"
        dados.descricao = "À prazo"
        retorno.Add(dados)

        dados = New dTipoPagamento()
        dados.cid = 3
        dados.codigo = "9"
        dados.descricao = "Sem pagamento"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar TipoPagamento [" & Me.ToString() & "] - " & ex.Message, ex)

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
          RetornarCodigo = "9"
      End Select
    End Function

  End Class

End Namespace