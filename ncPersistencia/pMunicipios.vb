Imports ncDados.nsMunicipios
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsMunicipios

  Public Class pMunicipios

    Public Function Listar() As ColecaoMunicipios

      Dim retorno As ColecaoMunicipios
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dMunicipios
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select cid, codigo_ibge, nome, estados_cid, situacao From municipios Order By nome "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoMunicipios

              For Each row In dt.Rows
                item = New dMunicipios

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.codigo_ibge = cFuncoes.RetornarTexto(row("codigo_ibge"))
                item.nome = cFuncoes.RetornarTexto(row("nome"))
                item.estados_cid = cFuncoes.RetornarInteiro(row("estados_cid"))
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
        Throw New ExcecaoNascomercio("Erro em Listar municipios [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function ListarPorEstado(ByVal estados_cid As Integer) As ColecaoMunicipios

      Dim retorno As ColecaoMunicipios
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dMunicipios
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD

        sqlSelect = " Select cid, codigo_ibge, nome, estados_cid, situacao "
        sqlWhere = String.Empty
        sqlFrom = " From municipios "

        '-- cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, estados_cid.ToString(), "estados_cid")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " Order By nome")

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoMunicipios

              For Each row In dt.Rows
                item = New dMunicipios

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.codigo_ibge = cFuncoes.RetornarTexto(row("codigo_ibge"))
                item.nome = cFuncoes.RetornarTexto(row("nome"))
                item.estados_cid = cFuncoes.RetornarInteiro(row("estados_cid"))
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
        Throw New ExcecaoNascomercio("Erro em Listar municipios [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ListarPorEstado = retorno

    End Function

    Public Function Consultar(ByVal dados As dMunicipios) As ColecaoMunicipios

      Dim retorno As ColecaoMunicipios
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dMunicipios
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select cid, nome, situacao, codigo_ibge, estados_cid "
        sqlWhere = String.Empty
        sqlFrom = " From municipios "

        '-- cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")

        '-- codigo_ibge
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.codigo_ibge, "codigo_ibge")

        '-- nome
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.nome, "nome")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " Order By nome")

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoMunicipios

              For Each row In dt.Rows
                item = New dMunicipios

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.codigo_ibge = cFuncoes.RetornarTexto(row("codigo_ibge"))
                item.nome = cFuncoes.RetornarTexto(row("nome"))
                item.estados_cid = cFuncoes.RetornarInteiro(row("estados_cid"))
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
        Throw New ExcecaoNascomercio("Erro em Consultar municipios [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dMunicipios) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " municipios ( codigo_ibge, nome, estados_cid, situacao ) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dados.codigo_ibge) & "," & _
            cFuncoes.PersistirTexto(dados.nome) & "," & _
            cFuncoes.PersistirTexto(dados.estados_cid) & ",'A')"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir municipios [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Importar(ByVal dados As dMunicipios) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " municipios ( cid, codigo_ibge, nome, estados_cid, situacao ) " & _
            " VALUES (" & _
            cFuncoes.PersistirInteiro(dados.cid) & "," & _
            cFuncoes.PersistirTexto(dados.codigo_ibge) & "," & _
            cFuncoes.PersistirTexto(dados.nome) & "," & _
            cFuncoes.PersistirInteiro(dados.estados_cid) & ",'A')"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Importar municipios [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Importar = retorno

    End Function

    Public Function Alterar(ByVal dados As dMunicipios) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " UPDATE municipios SET " & _
            " codigo_ibge = " & cFuncoes.PersistirTexto(dados.codigo_ibge) & "," & _
            " nome = " & cFuncoes.PersistirTexto(dados.nome) & "," & _
            " estados_cid = " & cFuncoes.PersistirTexto(dados.estados_cid) & "," & _
            " situacao = " & cFuncoes.PersistirTexto(dados.situacao) & _
            " WHERE " & _
            " cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar municipios [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dMunicipios) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM municipios " & _
            " WHERE cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir municipios [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace