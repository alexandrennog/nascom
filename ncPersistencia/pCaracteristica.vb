Imports ncDados.nsCaracteristica
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCaracteristica

  Public Class pCaracteristica

    Public Function Listar() As ColecaoCaracteristica

      Dim retorno As ColecaoCaracteristica
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dCaracteristica
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select cid, nome, situacao, codigo From Caracteristicas "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoCaracteristica

              For Each row In dt.Rows
                item = New dCaracteristica

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.nome = cFuncoes.RetornarTexto(row("nome"))
                item.situacao = cFuncoes.RetornarTexto(row("situacao"))
                item.codigo = cFuncoes.RetornarTexto(row("codigo"))

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
        Throw New ExcecaoNascomercio("Erro em Listar Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dCaracteristica) As ColecaoCaracteristica

      Dim retorno As ColecaoCaracteristica
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dCaracteristica
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select cid, nome, situacao, codigo "
        sqlWhere = String.Empty
        sqlFrom = " From Caracteristicas "

        '-- cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")

        '-- nome
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.nome, "nome")

        '-- situacao
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.situacao, "situacao")

        '-- codigo
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.codigo, "codigo")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoCaracteristica

              For Each row In dt.Rows
                item = New dCaracteristica

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.nome = cFuncoes.RetornarTexto(row("nome"))
                item.situacao = cFuncoes.RetornarTexto(row("situacao"))
                item.codigo = cFuncoes.RetornarTexto(row("codigo"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dCaracteristica) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " Caracteristicas ( nome, codigo, situacao ) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dados.nome) & "," & _
            cFuncoes.PersistirTexto(dados.codigo) & "," & _
            cFuncoes.PersistirTexto(dados.situacao) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dCaracteristica) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " UPDATE Caracteristicas SET " & _
            " nome = " & cFuncoes.PersistirTexto(dados.nome) & "," & _
            " situacao = " & cFuncoes.PersistirTexto(dados.situacao) & _
            " WHERE " & _
            " cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dCaracteristica) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM Caracteristicas " & _
            " WHERE cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Caracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
