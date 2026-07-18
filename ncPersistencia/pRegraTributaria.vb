Imports ncDados.nsRegraTributaria
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsRegraTributaria

  Public Class pRegraTributaria

    Public Function Listar() As ColecaoRegraTributaria

      Dim retorno As ColecaoRegraTributaria
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dRegraTributaria
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select id_regra as cid, descricao, crt, uf_origem, uf_destino, tipo_operacao, modelo_documento, inicio_vigencia, fim_vigencia, ativo From regra_tributaria Order By descricao "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoRegraTributaria

              For Each row In dt.Rows
                item = New dRegraTributaria

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.descricao = cFuncoes.RetornarTexto(row("descricao"))
                item.crt = CType(cFuncoes.RetornarInteiro(row("crt")), Nullable(Of Byte))
                item.ufOrigem = cFuncoes.RetornarTexto(row("uf_origem"))
                item.ufDestino = cFuncoes.RetornarTexto(row("uf_destino"))
                item.tipoOperacao = cFuncoes.RetornarTexto(row("tipo_operacao"))
                item.modeloDocumento = CType(cFuncoes.RetornarInteiro(row("modelo_documento")), Nullable(Of Byte))
                item.inicioVigencia = cFuncoes.RetornarData(row("inicio_vigencia"))
                item.fimVigencia = cFuncoes.RetornarData(row("fim_vigencia"))
                item.ativo = cFuncoes.RetornarBoleano(row("ativo"))

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
        Throw New ExcecaoNascomercio("Erro em Listar RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dRegraTributaria) As ColecaoRegraTributaria

      Dim retorno As ColecaoRegraTributaria
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dRegraTributaria
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select id_regra as cid, descricao, crt, uf_origem, uf_destino, tipo_operacao, modelo_documento, inicio_vigencia, fim_vigencia, ativo "
        sqlWhere = String.Empty
        sqlFrom = " From regra_tributaria "

        '-- cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "id_regra")

        '-- descricao
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.descricao, "descricao", True)

        '-- crt
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.crt, "crt")

        '-- ufOrigem
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.ufOrigem, "uf_origem")

        '-- ufDestino
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.ufDestino, "uf_destino")

        '-- tipoOperacao
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.tipoOperacao, "tipo_operacao")

        '-- modeloDocumento
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.modeloDocumento, "modelo_documento")

        '-- ativo
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.ativo, "ativo")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " Order By descricao")

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoRegraTributaria

              For Each row In dt.Rows
                item = New dRegraTributaria

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.descricao = cFuncoes.RetornarTexto(row("descricao"))
                item.crt = CType(cFuncoes.RetornarInteiro(row("crt")), Nullable(Of Byte))
                item.ufOrigem = cFuncoes.RetornarTexto(row("uf_origem"))
                item.ufDestino = cFuncoes.RetornarTexto(row("uf_destino"))
                item.tipoOperacao = cFuncoes.RetornarTexto(row("tipo_operacao"))
                item.modeloDocumento = CType(cFuncoes.RetornarInteiro(row("modelo_documento")), Nullable(Of Byte))
                item.inicioVigencia = cFuncoes.RetornarData(row("inicio_vigencia"))
                item.fimVigencia = cFuncoes.RetornarData(row("fim_vigencia"))
                item.ativo = cFuncoes.RetornarBoleano(row("ativo"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dRegraTributaria) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " regra_tributaria ( descricao, crt, uf_origem, uf_destino, tipo_operacao, modelo_documento, inicio_vigencia, fim_vigencia, ativo ) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dados.descricao) & "," & _
            cFuncoes.PersistirInteiro(dados.crt) & "," & _
            cFuncoes.PersistirTexto(dados.ufOrigem) & "," & _
            cFuncoes.PersistirTexto(dados.ufDestino) & "," & _
            cFuncoes.PersistirTexto(dados.tipoOperacao) & "," & _
            cFuncoes.PersistirInteiro(dados.modeloDocumento) & "," & _
            cFuncoes.PersistirData(dados.inicioVigencia) & "," & _
            cFuncoes.PersistirData(dados.fimVigencia) & "," & _
            cFuncoes.PersistirBoleano(dados.ativo) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Importar(ByVal dados As dRegraTributaria) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " regra_tributaria ( id_regra, descricao, crt, uf_origem, uf_destino, tipo_operacao, modelo_documento, inicio_vigencia, fim_vigencia, ativo ) " & _
            " VALUES (" & _
            cFuncoes.PersistirInteiro(dados.cid) & "," & _
            cFuncoes.PersistirTexto(dados.descricao) & "," & _
            cFuncoes.PersistirInteiro(dados.crt) & "," & _
            cFuncoes.PersistirTexto(dados.ufOrigem) & "," & _
            cFuncoes.PersistirTexto(dados.ufDestino) & "," & _
            cFuncoes.PersistirTexto(dados.tipoOperacao) & "," & _
            cFuncoes.PersistirInteiro(dados.modeloDocumento) & "," & _
            cFuncoes.PersistirData(dados.inicioVigencia) & "," & _
            cFuncoes.PersistirData(dados.fimVigencia) & "," & _
            cFuncoes.PersistirBoleano(dados.ativo) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Importar RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Importar = retorno

    End Function

    Public Function Alterar(ByVal dados As dRegraTributaria) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " UPDATE regra_tributaria SET " & _
            " descricao = " & cFuncoes.PersistirTexto(dados.descricao) & "," & _
            " crt = " & cFuncoes.PersistirInteiro(dados.crt) & "," & _
            " uf_origem = " & cFuncoes.PersistirTexto(dados.ufOrigem) & "," & _
            " uf_destino = " & cFuncoes.PersistirTexto(dados.ufDestino) & "," & _
            " tipo_operacao = " & cFuncoes.PersistirTexto(dados.tipoOperacao) & "," & _
            " modelo_documento = " & cFuncoes.PersistirInteiro(dados.modeloDocumento) & "," & _
            " inicio_vigencia = " & cFuncoes.PersistirData(dados.inicioVigencia) & "," & _
            " fim_vigencia = " & cFuncoes.PersistirData(dados.fimVigencia) & "," & _
            " ativo = " & cFuncoes.PersistirBoleano(dados.ativo) & _
            " WHERE " & _
            " id_regra = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dRegraTributaria) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM regra_tributaria " & _
            " WHERE id_regra = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir RegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
