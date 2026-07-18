Imports ncDados.nsEmpresa
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEmpresa

  Public Class pEmpresa

    Public Function Listar() As ColecaoEmpresa

      Dim retorno As ColecaoEmpresa
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dEmpresa
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select id_empresa as cid, cnpj, razao_social, crt, uf, municipio, created_at From empresa Order By razao_social "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoEmpresa

              For Each row In dt.Rows
                item = New dEmpresa

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.cnpj = cFuncoes.RetornarTexto(row("cnpj"))
                item.razaoSocial = cFuncoes.RetornarTexto(row("razao_social"))
                item.crt = CType(cFuncoes.RetornarInteiro(row("crt")), Nullable(Of Byte))
                item.uf = cFuncoes.RetornarTexto(row("uf"))
                item.municipio = cFuncoes.RetornarInteiro(row("municipio"))
                item.createdAt = cFuncoes.RetornarData(row("created_at"))

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
        Throw New ExcecaoNascomercio("Erro em Listar Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dEmpresa) As ColecaoEmpresa

      Dim retorno As ColecaoEmpresa
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dEmpresa
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select id_empresa as cid, cnpj, razao_social, crt, uf, municipio, created_at "
        sqlWhere = String.Empty
        sqlFrom = " From empresa "

        '-- cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "id_empresa")

        '-- cnpj
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cnpj, "cnpj")

        '-- razaoSocial
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.razaoSocial, "razao_social", True)

        '-- crt
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.crt, "crt")

        '-- uf
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.uf, "uf")

        '-- municipio
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.municipio, "municipio")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " Order By razao_social")

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoEmpresa

              For Each row In dt.Rows
                item = New dEmpresa

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.cnpj = cFuncoes.RetornarTexto(row("cnpj"))
                item.razaoSocial = cFuncoes.RetornarTexto(row("razao_social"))
                item.crt = CType(cFuncoes.RetornarInteiro(row("crt")), Nullable(Of Byte))
                item.uf = cFuncoes.RetornarTexto(row("uf"))
                item.municipio = cFuncoes.RetornarInteiro(row("municipio"))
                item.createdAt = cFuncoes.RetornarData(row("created_at"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dEmpresa) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " empresa ( cnpj, razao_social, crt, uf, municipio ) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dados.cnpj) & "," & _
            cFuncoes.PersistirTexto(dados.razaoSocial) & "," & _
            cFuncoes.PersistirInteiro(dados.crt) & "," & _
            cFuncoes.PersistirTexto(dados.uf) & "," & _
            cFuncoes.PersistirInteiro(dados.municipio) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Importar(ByVal dados As dEmpresa) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " empresa ( id_empresa, cnpj, razao_social, crt, uf, municipio, created_at ) " & _
            " VALUES (" & _
            cFuncoes.PersistirInteiro(dados.cid) & "," & _
            cFuncoes.PersistirTexto(dados.cnpj) & "," & _
            cFuncoes.PersistirTexto(dados.razaoSocial) & "," & _
            cFuncoes.PersistirInteiro(dados.crt) & "," & _
            cFuncoes.PersistirTexto(dados.uf) & "," & _
            cFuncoes.PersistirInteiro(dados.municipio) & "," & _
            cFuncoes.PersistirDataHora(dados.createdAt) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Importar Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Importar = retorno

    End Function

    Public Function Alterar(ByVal dados As dEmpresa) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " UPDATE empresa SET " & _
            " cnpj = " & cFuncoes.PersistirTexto(dados.cnpj) & "," & _
            " razao_social = " & cFuncoes.PersistirTexto(dados.razaoSocial) & "," & _
            " crt = " & cFuncoes.PersistirInteiro(dados.crt) & "," & _
            " uf = " & cFuncoes.PersistirTexto(dados.uf) & "," & _
            " municipio = " & cFuncoes.PersistirInteiro(dados.municipio) & _
            " WHERE " & _
            " id_empresa = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dEmpresa) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM empresa " & _
            " WHERE id_empresa = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Empresa [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
