Imports ncDados.nsDados
Imports ncComum.nsExcecao

Namespace nsRegras

  Public Class rTipoOperacaoFiscal

    '-- M�todos de controle ( V�rias chamadas; Controle de transa��o )

    Public Function Listar() As ColecaoTipoOperacaoFiscal

      Dim retorno As ColecaoTipoOperacaoFiscal

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar TipoOperacaoFiscal [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    '-- M�todos padr�o ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoTipoOperacaoFiscal

      Dim retorno As ColecaoTipoOperacaoFiscal
      Dim dados As dTipoOperacaoFiscal

      Try

        retorno = New ColecaoTipoOperacaoFiscal()

        dados = New dTipoOperacaoFiscal()
        dados.codigo = "E"
        dados.descricao = "E - Entrada"
        retorno.Add(dados)

        dados = New dTipoOperacaoFiscal()
        dados.codigo = "S"
        dados.descricao = "S - Sa�da"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar TipoOperacaoFiscal [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

  End Class

End Namespace
