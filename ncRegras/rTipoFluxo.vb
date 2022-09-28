Imports ncDados.nsDados
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsRegras

  Public Class rTipoFluxo

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoTipoFluxo

      Dim retorno As ColecaoTipoFluxo

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar TipoFluxo [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoTipoFluxo

      Dim retorno As ColecaoTipoFluxo
      Dim dados As dTipoFluxo

      Try

        retorno = New ColecaoTipoFluxo()

        dados = New dTipoFluxo()
        dados.cid = 1
        dados.codigo = "0"
        dados.descricao = "Entrada"
        retorno.Add(dados)

        dados = New dTipoFluxo()
        dados.cid = 2
        dados.codigo = "1"
        dados.descricao = "Saída"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar TipoFluxo [" & Me.ToString() & "] - " & ex.Message)

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