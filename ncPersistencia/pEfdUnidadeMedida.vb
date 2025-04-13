Imports ncDados.nsEFD
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Namespace nsEFD

  Public Class pEfdUnidadeMedida

    Public Function Listar() As ColecaoEfdUnidadeMedida

      Dim retorno As ColecaoEfdUnidadeMedida
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dEfdUnidadeMedida
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " Select codigo, descricao From EfdUnidadeMedida Order By descricao "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoEfdUnidadeMedida

              For Each row In dt.Rows
                item = New dEfdUnidadeMedida

                item.codigo = RetornarTexto(row("codigo"))
                item.descricao = RetornarTexto(row("descricao"))

                retorno.Add(item)
              Next
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
        Throw New ExcecaoNascomercio("Erro em Listar EfdUnidadeMedida [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dEfdUnidadeMedida) As dEfdUnidadeMedida

      Dim retorno As dEfdUnidadeMedida
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD

        sqlSelect = " Select codigo, descricao "
        sqlFrom = " From EfdUnidadeMedida "
        sqlWhere = String.Empty

        '-- codigo
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.codigo, "codigo")

        '-- descricao
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.descricao, "descricao")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " Order By descricao ")

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New dEfdUnidadeMedida

              retorno.codigo = RetornarTexto(dt.Rows(0).Item("codigo"))
              retorno.descricao = RetornarTexto(dt.Rows(0).Item("descricao"))
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
        Throw New ExcecaoNascomercio("Erro em Consultar EfdUnidadeMedida [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Excluir(ByVal dados As dEfdUnidadeMedida) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM EfdUnidadeMedida " & _
            " WHERE codigo = " & PersistirTexto(dados.codigo)

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir EfdUnidadeMedida [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    Public Function Incluir(ByVal dados As dEfdUnidadeMedida) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " INSERT INTO " & _
            " EfdUnidadeMedida ( codigo, descricao ) " & _
            " VALUES (" & _
            PersistirTexto(dados.codigo) & "," & _
            PersistirTexto(dados.descricao) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir EfdUnidadeMedida [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dEfdUnidadeMedida) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " UPDATE EfdUnidadeMedida SET " & _
            " descricao = " & PersistirTexto(dados.descricao) & _
            " WHERE " & _
            " codigo = " & dados.codigo

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar EfdUnidadeMedida [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

  End Class

End Namespace