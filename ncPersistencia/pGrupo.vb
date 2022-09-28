Imports ncDados.nsGrupo
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsGrupo

  Public Class pGrupo

    Public Function Listar() As ColecaoGrupo

      Dim retorno As ColecaoGrupo
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dGrupo
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select cid, nome, situacao From Grupo Order By nome "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoGrupo

              For Each row In dt.Rows
                item = New dGrupo

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.nome = cFuncoes.RetornarTexto(row("nome"))
                item.situacao = cFuncoes.RetornarTexto(row("situacao"))

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
        Throw New ExcecaoNascomercio("Erro em Listar Grupo [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dGrupo) As ColecaoGrupo

      Dim retorno As ColecaoGrupo
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dGrupo
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select cid, nome, situacao "
        sqlWhere = String.Empty
        sqlFrom = " From Grupo "

        '-- cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")

        '-- nome
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.nome, "nome")

        '-- situacao
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.situacao, "situacao")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " Order By nome")

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoGrupo

              For Each row In dt.Rows
                item = New dGrupo

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.nome = cFuncoes.RetornarTexto(row("nome"))
                item.situacao = cFuncoes.RetornarTexto(row("situacao"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar Grupo [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dGrupo) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " INSERT INTO " & _
            " Grupo ( nome, situacao ) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dados.nome) & "," & _
            cFuncoes.PersistirTexto(dados.situacao) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Grupo [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Importar(ByVal dados As dGrupo) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " Grupo ( cid, nome, situacao ) " & _
            " VALUES (" & _
            cFuncoes.PersistirInteiro(dados.cid) & "," & _
            cFuncoes.PersistirTexto(dados.nome) & "," & _
            cFuncoes.PersistirTexto(dados.situacao) & ")"

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Importar Grupo [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Importar = retorno

    End Function

    Public Function Alterar(ByVal dados As dGrupo) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " UPDATE Grupo SET " & _
            " nome = " & cFuncoes.PersistirTexto(dados.nome) & "," & _
            " situacao = " & cFuncoes.PersistirTexto(dados.situacao) & _
            " WHERE " & _
            " cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Grupo [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dGrupo) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM Grupo " & _
            " WHERE cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Grupo [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
