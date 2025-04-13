Imports ncDados.nsEFD
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEFD

  Public Class pEfdArquivo

    Public Function Consultar() As dEfdArquivo

      Dim retorno As dEfdArquivo
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim sqlSelect As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD

        sqlSelect = " Select versaoLeiaute, finalidadeArquivo, perfilArquivoFiscal "
        sqlFrom = " From EfdArquivo "

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New dEfdArquivo

              retorno.versaoLeiaute = cFuncoes.RetornarTexto(dt.Rows(0).Item("versaoLeiaute"))
              retorno.finalidadeArquivo = cFuncoes.RetornarTexto(dt.Rows(0).Item("finalidadeArquivo"))
              retorno.perfilArquivoFiscal = cFuncoes.RetornarTexto(dt.Rows(0).Item("perfilArquivoFiscal"))
            Else
              retorno = Nothing
            End If
          Else
            retorno = Nothing
          End If
        Else
          retorno = Nothing
        End If

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar EfdArquivo [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Excluir() As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM EfdArquivo "

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir EfdArquivo [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    Public Function Incluir(ByVal dados As dEfdArquivo) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " INSERT INTO " & _
            " EfdArquivo ( versaoLeiaute, finalidadeArquivo, perfilArquivoFiscal ) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dados.versaoLeiaute) & "," & _
            cFuncoes.PersistirTexto(dados.finalidadeArquivo) & "," & _
            cFuncoes.PersistirTexto(dados.perfilArquivoFiscal) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir EfdArquivo [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dEfdArquivo) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " UPDATE EfdArquivo SET " & _
            " versaoLeiaute = " & cFuncoes.PersistirTexto(dados.versaoLeiaute) & "," & _
            " finalidadeArquivo = " & cFuncoes.PersistirTexto(dados.finalidadeArquivo) & "," & _
            " perfilArquivoFiscal = " & cFuncoes.PersistirTexto(dados.perfilArquivoFiscal)

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar EfdArquivo [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

  End Class

End Namespace