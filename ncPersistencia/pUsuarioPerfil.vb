Imports ncDados.nsUsuarioPerfil
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsUsuarioPerfil

  Public Class pUsuarioPerfil

    Public Function Listar() As colecaoUsuarioPerfil

      Dim retorno As colecaoUsuarioPerfil
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dUsuarioPerfil
      Dim comandoSQL As String


      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select cid, codigo, nome, situacao From usuarioperfil "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New colecaoUsuarioPerfil

              For Each row In dt.Rows
                item = New dUsuarioPerfil

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.codigo = cFuncoes.RetornarTexto(row("codigo"))
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
        Throw New ExcecaoNascomercio("Erro em Listar UsuarioPerfil [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dUsuarioPerfil) As colecaoUsuarioPerfil

      Dim retorno As colecaoUsuarioPerfil
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dUsuarioPerfil
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String


      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select cid, codigo, nome, situacao "
        sqlWhere = String.Empty
        sqlFrom = " From usuarioperfil "

        '-- cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")

        '-- codigo
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.codigo, "codigo")

        '-- nome
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.nome, "nome")

        '-- situacao
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.situacao, "situacao")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New colecaoUsuarioPerfil

              For Each row In dt.Rows
                item = New dUsuarioPerfil

                item.cid = Convert.ToInt32(row("cid"))
                item.nome = cFuncoes.RetornarTexto(row("nome"))
                item.codigo = cFuncoes.RetornarTexto(row("codigo"))
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
        Throw New ExcecaoNascomercio("Erro em Consultar UsuarioPerfil [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dUsuarioPerfil) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String


      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " usuarioperfil (codigo, nome, situacao) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dados.codigo) & "," & _
            cFuncoes.PersistirTexto(dados.nome) & "," & _
            cFuncoes.PersistirTexto(dados.situacao) & ")"

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir UsuarioPerfil [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dUsuarioPerfil) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String


      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " UPDATE usuarioperfil SET " & _
            " codigo = " & cFuncoes.PersistirTexto(dados.codigo) & "," & _
            " nome = " & cFuncoes.PersistirTexto(dados.nome) & "," & _
            " situacao = " & cFuncoes.PersistirTexto(dados.situacao) & _
            " WHERE " & _
            " cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar UsuarioPerfil [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dUsuarioPerfil) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM usuarioperfil " & _
            " WHERE cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir UsuarioPerfil [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace

