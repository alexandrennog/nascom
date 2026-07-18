Imports ncDados.nsImpostoIbsCbs
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsImpostoIbsCbs

  Public Class pImpostoIbsCbs

    Public Function Listar() As ColecaoImpostoIbsCbs

      Dim retorno As ColecaoImpostoIbsCbs
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dImpostoIbsCbs
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select id_regra as regra_cid, cst_ibs_cbs, c_class_trib, aliquota_ibs_uf, aliquota_ibs_municipio, aliquota_cbs From imposto_ibs_cbs Order By id_regra "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoImpostoIbsCbs

              For Each row In dt.Rows
                item = New dImpostoIbsCbs

                item.regra_cid = cFuncoes.RetornarInteiro(row("regra_cid"))
                item.cstIbsCbs = cFuncoes.RetornarTexto(row("cst_ibs_cbs"))
                item.cClassTrib = cFuncoes.RetornarTexto(row("c_class_trib"))
                item.aliquotaIbsUf = cFuncoes.RetornarDecimal(row("aliquota_ibs_uf"))
                item.aliquotaIbsMunicipio = cFuncoes.RetornarDecimal(row("aliquota_ibs_municipio"))
                item.aliquotaCbs = cFuncoes.RetornarDecimal(row("aliquota_cbs"))

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
        Throw New ExcecaoNascomercio("Erro em Listar ImpostoIbsCbs [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dImpostoIbsCbs) As ColecaoImpostoIbsCbs

      Dim retorno As ColecaoImpostoIbsCbs
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dImpostoIbsCbs
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select id_regra as regra_cid, cst_ibs_cbs, c_class_trib, aliquota_ibs_uf, aliquota_ibs_municipio, aliquota_cbs "
        sqlWhere = String.Empty
        sqlFrom = " From imposto_ibs_cbs "

        '-- regra_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.regra_cid, "id_regra")

        '-- cstIbsCbs
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cstIbsCbs, "cst_ibs_cbs")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " Order By id_regra")

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoImpostoIbsCbs

              For Each row In dt.Rows
                item = New dImpostoIbsCbs

                item.regra_cid = cFuncoes.RetornarInteiro(row("regra_cid"))
                item.cstIbsCbs = cFuncoes.RetornarTexto(row("cst_ibs_cbs"))
                item.cClassTrib = cFuncoes.RetornarTexto(row("c_class_trib"))
                item.aliquotaIbsUf = cFuncoes.RetornarDecimal(row("aliquota_ibs_uf"))
                item.aliquotaIbsMunicipio = cFuncoes.RetornarDecimal(row("aliquota_ibs_municipio"))
                item.aliquotaCbs = cFuncoes.RetornarDecimal(row("aliquota_cbs"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar ImpostoIbsCbs [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dImpostoIbsCbs) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " imposto_ibs_cbs ( id_regra, cst_ibs_cbs, c_class_trib, aliquota_ibs_uf, aliquota_ibs_municipio, aliquota_cbs ) " & _
            " VALUES (" & _
            cFuncoes.PersistirInteiro(dados.regra_cid) & "," & _
            cFuncoes.PersistirTexto(dados.cstIbsCbs) & "," & _
            cFuncoes.PersistirTexto(dados.cClassTrib) & "," & _
            cFuncoes.PersistirDecimal(dados.aliquotaIbsUf) & "," & _
            cFuncoes.PersistirDecimal(dados.aliquotaIbsMunicipio) & "," & _
            cFuncoes.PersistirDecimal(dados.aliquotaCbs) & ")"

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ImpostoIbsCbs [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dImpostoIbsCbs) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " UPDATE imposto_ibs_cbs SET " & _
            " cst_ibs_cbs = " & cFuncoes.PersistirTexto(dados.cstIbsCbs) & "," & _
            " c_class_trib = " & cFuncoes.PersistirTexto(dados.cClassTrib) & "," & _
            " aliquota_ibs_uf = " & cFuncoes.PersistirDecimal(dados.aliquotaIbsUf) & "," & _
            " aliquota_ibs_municipio = " & cFuncoes.PersistirDecimal(dados.aliquotaIbsMunicipio) & "," & _
            " aliquota_cbs = " & cFuncoes.PersistirDecimal(dados.aliquotaCbs) & _
            " WHERE " & _
            " id_regra = " & dados.regra_cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar ImpostoIbsCbs [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dImpostoIbsCbs) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM imposto_ibs_cbs " & _
            " WHERE id_regra = " & dados.regra_cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ImpostoIbsCbs [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
