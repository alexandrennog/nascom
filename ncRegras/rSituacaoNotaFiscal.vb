Imports ncDados.nsDados
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsRegras

  Public Class rSituacaoNotaFiscal

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoSituacaoNotaFiscal

      Dim retorno As ColecaoSituacaoNotaFiscal

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar SituacaoNotaFiscal [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoSituacaoNotaFiscal

      Dim retorno As ColecaoSituacaoNotaFiscal
      Dim dados As dSituacaoNotaFiscal

      Try

        retorno = New ColecaoSituacaoNotaFiscal()

        dados = New dSituacaoNotaFiscal()
        dados.cid = 1
        dados.codigo = "00"
        dados.descricao = "Documento regular"
        retorno.Add(dados)

        dados = New dSituacaoNotaFiscal()
        dados.cid = 2
        dados.codigo = "01"
        dados.descricao = "Documento regular extemporâneo"
        retorno.Add(dados)

        dados = New dSituacaoNotaFiscal()
        dados.cid = 3
        dados.codigo = "02"
        dados.descricao = "Documento cancelado"
        retorno.Add(dados)

        dados = New dSituacaoNotaFiscal()
        dados.cid = 4
        dados.codigo = "03"
        dados.descricao = "Documento cancelado extemporâneo"
        retorno.Add(dados)

        dados = New dSituacaoNotaFiscal()
        dados.cid = 5
        dados.codigo = "04"
        dados.descricao = "NFe denegada"
        retorno.Add(dados)

        dados = New dSituacaoNotaFiscal()
        dados.cid = 6
        dados.codigo = "05"
        dados.descricao = "NFe - Numeração inutilizada"
        retorno.Add(dados)

        dados = New dSituacaoNotaFiscal()
        dados.cid = 7
        dados.codigo = "06"
        dados.descricao = "Documento Fiscal Complementar"
        retorno.Add(dados)

        dados = New dSituacaoNotaFiscal()
        dados.cid = 8
        dados.codigo = "07"
        dados.descricao = "Documento Fiscal Complementar extemporâneo"
        retorno.Add(dados)

        dados = New dSituacaoNotaFiscal()
        dados.cid = 9
        dados.codigo = "08"
        dados.descricao = "Documento Fiscal emitido com base em Regime Especial ou Norma Específica"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar SituacaoNotaFiscal [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListar = retorno

    End Function

    Public Function RetornarCodigo(ByVal cid As Integer) As String
      RetornarCodigo = ""

      Select Case cid
        Case 1
          RetornarCodigo = "00"
        Case 2
          RetornarCodigo = "01"
        Case 3
          RetornarCodigo = "02"
        Case 4
          RetornarCodigo = "03"
        Case 5
          RetornarCodigo = "04"
        Case 6
          RetornarCodigo = "05"
        Case 7
          RetornarCodigo = "06"
        Case 8
          RetornarCodigo = "07"
        Case 9
          RetornarCodigo = "08"
      End Select
    End Function

  End Class

End Namespace