Imports ncDados.nsFabricante
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsFabricante

  Public Class pFabricante

    Public Function Listar() As ColecaoFabricante

      Dim retorno As ColecaoFabricante
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dFabricante
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select cid, nome, situacao From Fabricantes order by nome "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoFabricante

              For Each row In dt.Rows
                item = New dFabricante

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
        Throw New ExcecaoNascomercio("Erro em Listar Fabricante [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dFabricante) As ColecaoFabricante

      Dim retorno As ColecaoFabricante
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dFabricante
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select cid, nome, situacao "
        sqlWhere = String.Empty
        sqlFrom = " From Fabricantes "

        '-- cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")

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
              retorno = New ColecaoFabricante

              For Each row In dt.Rows
                item = New dFabricante

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
        Throw New ExcecaoNascomercio("Erro em Consultar Fabricante [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dFabricante) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " Fabricantes ( nome, situacao ) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dados.nome) & "," & _
            cFuncoes.PersistirTexto(dados.situacao) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Fabricante [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dFabricante) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " UPDATE Fabricantes SET " & _
            " nome = " & cFuncoes.PersistirTexto(dados.nome) & "," & _
            " situacao = " & cFuncoes.PersistirTexto(dados.situacao) & _
            " WHERE " & _
            " cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Fabricante [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dFabricante) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM Fabricantes " & _
            " WHERE cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Fabricante [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
