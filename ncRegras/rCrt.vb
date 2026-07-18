Imports ncDados.nsDados
Imports ncComum.nsExcecao

Namespace nsRegras

  Public Class rCrt

    '-- M�todos de controle ( V�rias chamadas; Controle de transa��o )

    Public Function Listar() As ColecaoCrt

      Dim retorno As ColecaoCrt

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Crt [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    '-- M�todos padr�o ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoCrt

      Dim retorno As ColecaoCrt
      Dim dados As dCrt

      Try

        retorno = New ColecaoCrt()

        dados = New dCrt()
        dados.codigo = 1
        dados.descricao = "1 - Simples Nacional"
        retorno.Add(dados)

        dados = New dCrt()
        dados.codigo = 2
        dados.descricao = "2 - Simples Nacional excesso sublimite"
        retorno.Add(dados)

        dados = New dCrt()
        dados.codigo = 3
        dados.descricao = "3 - Regime Normal"
        retorno.Add(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fListar Crt [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

  End Class

End Namespace
