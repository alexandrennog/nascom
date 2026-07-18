Imports ncDados.nsImpostoIcms
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsImpostoIcms

  Public Class pImpostoIcms

    Public Function Listar() As ColecaoImpostoIcms

      Dim retorno As ColecaoImpostoIcms
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dImpostoIcms
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select id_regra as regra_cid, origem, cst, csosn, aliquota, reducao_base, modalidade_bc, aliquota_st, margem_valor_agregado From imposto_icms Order By id_regra "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoImpostoIcms

              For Each row In dt.Rows
                item = New dImpostoIcms

                item.regra_cid = cFuncoes.RetornarInteiro(row("regra_cid"))
                item.origem = CType(cFuncoes.RetornarInteiro(row("origem")), Nullable(Of Byte))
                item.cst = cFuncoes.RetornarTexto(row("cst"))
                item.csosn = cFuncoes.RetornarTexto(row("csosn"))
                item.aliquota = cFuncoes.RetornarDecimal(row("aliquota"))
                item.reducaoBase = cFuncoes.RetornarDecimal(row("reducao_base"))
                item.modalidadeBc = CType(cFuncoes.RetornarInteiro(row("modalidade_bc")), Nullable(Of Byte))
                item.aliquotaSt = cFuncoes.RetornarDecimal(row("aliquota_st"))
                item.margemValorAgregado = cFuncoes.RetornarDecimal(row("margem_valor_agregado"))

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
        Throw New ExcecaoNascomercio("Erro em Listar ImpostoIcms [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dImpostoIcms) As ColecaoImpostoIcms

      Dim retorno As ColecaoImpostoIcms
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dImpostoIcms
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select id_regra as regra_cid, origem, cst, csosn, aliquota, reducao_base, modalidade_bc, aliquota_st, margem_valor_agregado "
        sqlWhere = String.Empty
        sqlFrom = " From imposto_icms "

        '-- regra_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.regra_cid, "id_regra")

        '-- cst
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cst, "cst")

        '-- csosn
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.csosn, "csosn")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " Order By id_regra")

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoImpostoIcms

              For Each row In dt.Rows
                item = New dImpostoIcms

                item.regra_cid = cFuncoes.RetornarInteiro(row("regra_cid"))
                item.origem = CType(cFuncoes.RetornarInteiro(row("origem")), Nullable(Of Byte))
                item.cst = cFuncoes.RetornarTexto(row("cst"))
                item.csosn = cFuncoes.RetornarTexto(row("csosn"))
                item.aliquota = cFuncoes.RetornarDecimal(row("aliquota"))
                item.reducaoBase = cFuncoes.RetornarDecimal(row("reducao_base"))
                item.modalidadeBc = CType(cFuncoes.RetornarInteiro(row("modalidade_bc")), Nullable(Of Byte))
                item.aliquotaSt = cFuncoes.RetornarDecimal(row("aliquota_st"))
                item.margemValorAgregado = cFuncoes.RetornarDecimal(row("margem_valor_agregado"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar ImpostoIcms [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dImpostoIcms) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " imposto_icms ( id_regra, origem, cst, csosn, aliquota, reducao_base, modalidade_bc, aliquota_st, margem_valor_agregado ) " & _
            " VALUES (" & _
            cFuncoes.PersistirInteiro(dados.regra_cid) & "," & _
            cFuncoes.PersistirInteiro(dados.origem) & "," & _
            cFuncoes.PersistirTexto(dados.cst) & "," & _
            cFuncoes.PersistirTexto(dados.csosn) & "," & _
            cFuncoes.PersistirDecimal(dados.aliquota) & "," & _
            cFuncoes.PersistirDecimal(dados.reducaoBase) & "," & _
            cFuncoes.PersistirInteiro(dados.modalidadeBc) & "," & _
            cFuncoes.PersistirDecimal(dados.aliquotaSt) & "," & _
            cFuncoes.PersistirDecimal(dados.margemValorAgregado) & ")"

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ImpostoIcms [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dImpostoIcms) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " UPDATE imposto_icms SET " & _
            " origem = " & cFuncoes.PersistirInteiro(dados.origem) & "," & _
            " cst = " & cFuncoes.PersistirTexto(dados.cst) & "," & _
            " csosn = " & cFuncoes.PersistirTexto(dados.csosn) & "," & _
            " aliquota = " & cFuncoes.PersistirDecimal(dados.aliquota) & "," & _
            " reducao_base = " & cFuncoes.PersistirDecimal(dados.reducaoBase) & "," & _
            " modalidade_bc = " & cFuncoes.PersistirInteiro(dados.modalidadeBc) & "," & _
            " aliquota_st = " & cFuncoes.PersistirDecimal(dados.aliquotaSt) & "," & _
            " margem_valor_agregado = " & cFuncoes.PersistirDecimal(dados.margemValorAgregado) & _
            " WHERE " & _
            " id_regra = " & dados.regra_cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar ImpostoIcms [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dImpostoIcms) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM imposto_icms " & _
            " WHERE id_regra = " & dados.regra_cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ImpostoIcms [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
