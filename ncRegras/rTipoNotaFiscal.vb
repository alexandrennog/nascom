Imports ncDados.nsDados
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsRegras

  Public Class rTipoNotaFiscal

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoTipoNotaFiscal

      Dim retorno As ColecaoTipoNotaFiscal

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar TipoNotaFiscal [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoTipoNotaFiscal

      Dim retorno As ColecaoTipoNotaFiscal
      Dim dados As dTipoNotaFiscal

      Try

        retorno = New ColecaoTipoNotaFiscal()

        dados = New dTipoNotaFiscal()
        dados.cid = 1
        dados.codigo = "01"
        dados.descricao = "Nota Fiscal"
        dados.modelo = "1/1A"
        dados.modeloDescricao = "01 - Nota Fiscal - 1/1A"
        retorno.Add(dados)

        dados = New dTipoNotaFiscal()
        dados.cid = 2
        dados.codigo = "1B"
        dados.descricao = "Nota Fiscal Avulsa"
        dados.modeloDescricao = "1B - Nota Fiscal Avulsa"
        retorno.Add(dados)

        dados = New dTipoNotaFiscal()
        dados.cid = 3
        dados.codigo = "04"
        dados.descricao = "Nota Fiscal de Produtor"
        dados.modelo = "4"
        dados.modeloDescricao = "04 - Nota Fiscal de Produtor - 4"
        retorno.Add(dados)

        dados = New dTipoNotaFiscal()
        dados.cid = 4
        dados.codigo = "55"
        dados.descricao = "Nota Fiscal Eletrônica"
        dados.modeloDescricao = "55 - Nota Fiscal Eletrônica"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar TipoNotaFiscal [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListar = retorno

    End Function

    Public Function RetornarCodigo(ByVal cid As Integer) As String
      RetornarCodigo = ""

      Select Case cid
        Case 1
          RetornarCodigo = "01"
        Case 2
          RetornarCodigo = "1B"
        Case 3
          RetornarCodigo = "04"
        Case 4
          RetornarCodigo = "55"
      End Select
    End Function

  End Class

End Namespace