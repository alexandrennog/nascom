Imports ncDados.nsEFD
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEFD

  Public Class pEfdEnderecoContato

    Public Function Consultar() As dEfdEnderecoContato

      Dim retorno As dEfdEnderecoContato
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim sqlSelect As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD

        sqlSelect = " Select logradouro, numero, " & _
          " complemento, bairro, cep, dddTelefone, dddFax, email "
        sqlFrom = " From EfdEnderecoContato "

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New dEfdEnderecoContato

              retorno.logradouro = cFuncoes.RetornarTexto(dt.Rows(0).Item("logradouro"))
              retorno.numero = cFuncoes.RetornarTexto(dt.Rows(0).Item("numero"))
              retorno.complemento = cFuncoes.RetornarTexto(dt.Rows(0).Item("complemento"))
              retorno.bairro = cFuncoes.RetornarTexto(dt.Rows(0).Item("bairro"))
              retorno.cep = cFuncoes.RetornarTexto(dt.Rows(0).Item("cep"))
              retorno.dddTelefone = cFuncoes.RetornarTexto(dt.Rows(0).Item("dddTelefone"))
              retorno.dddFax = cFuncoes.RetornarTexto(dt.Rows(0).Item("dddFax"))
              retorno.email = cFuncoes.RetornarTexto(dt.Rows(0).Item("email"))
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
        Throw New ExcecaoNascomercio("Erro em Consultar EfdEnderecoContato [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Excluir() As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM EfdEnderecoContato "

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir EfdEnderecoContato [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Excluir = retorno

    End Function

    Public Function Incluir(ByVal dados As dEfdEnderecoContato) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " INSERT INTO " & _
            " EfdEnderecoContato ( logradouro, " & _
            " numero, complemento, bairro, cep, dddTelefone, dddFax, email ) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dados.logradouro) & "," & _
            cFuncoes.PersistirTexto(dados.numero) & "," & _
            cFuncoes.PersistirTexto(dados.complemento) & "," & _
            cFuncoes.PersistirTexto(dados.bairro) & "," & _
            cFuncoes.PersistirTexto(dados.cep) & "," & _
            cFuncoes.PersistirTexto(dados.dddTelefone) & "," & _
            cFuncoes.PersistirTexto(dados.dddFax) & "," & _
            cFuncoes.PersistirTexto(dados.email) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir EfdEnderecoContato [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dEfdEnderecoContato) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " UPDATE EfdEnderecoContato SET " & _
            " logradouro = " & cFuncoes.PersistirTexto(dados.logradouro) & "," & _
            " numero = " & cFuncoes.PersistirTexto(dados.numero) & "," & _
            " complemento = " & cFuncoes.PersistirTexto(dados.complemento) & "," & _
            " bairro = " & cFuncoes.PersistirTexto(dados.bairro) & "," & _
            " cep = " & cFuncoes.PersistirTexto(dados.cep) & "," & _
            " dddTelefone = " & cFuncoes.PersistirTexto(dados.dddTelefone) & "," & _
            " dddFax = " & cFuncoes.PersistirTexto(dados.dddFax) & "," & _
            " email = " & cFuncoes.PersistirTexto(dados.email)

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar EfdEnderecoContato [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Alterar = retorno

    End Function

  End Class

End Namespace