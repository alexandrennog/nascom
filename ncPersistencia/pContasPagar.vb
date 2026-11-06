Imports ncDados.nsContasPagar
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsContasPagar

  Public Class pContasPagar

    Public Function Listar() As ColecaoContasPagar

      Dim retorno As ColecaoContasPagar
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dContasPagar
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " Select cid, codigo, codigoBarra, valor, aceite, observacao, " & _
                    " dataEmissao, dataVencimento, dataPagamento, valorPagamento, fornecedor_cid, pago " & _
                    " From ContasPagar "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoContasPagar

              For Each row In dt.Rows
                item = New dContasPagar

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.codigo = cFuncoes.RetornarTexto(row("codigo"))
                item.valor = cFuncoes.RetornarDecimal(row("valor"))
                item.observacao = cFuncoes.RetornarTexto(row("observacao"))
                item.aceite = cFuncoes.RetornarBoleano(row("aceite"))
                item.dataEmissao = cFuncoes.RetornarTexto(row("dataEmissao"))
                item.dataVencimento = cFuncoes.RetornarTexto(row("dataVencimento"))
                item.dataPagamento = cFuncoes.RetornarTexto(row("dataPagamento"))
                item.valorPagamento = cFuncoes.RetornarDecimal(row("valorPagamento"))
                item.codigoBarra = cFuncoes.RetornarTexto(row("codigoBarra"))
                item.fornecedor_cid = cFuncoes.RetornarInteiro(row("fornecedor_cid"))
                item.pago = cFuncoes.RetornarBoleano(row("pago"))

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
        Throw New ExcecaoNascomercio("Erro em Listar ContasPagar [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dContasPagar) As ColecaoContasPagar

      Dim retorno As ColecaoContasPagar
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dContasPagar
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD

        sqlSelect = " Select cid, codigo, codigoBarra, valor, aceite, observacao, " & _
                    " dataEmissao, dataVencimento, dataPagamento, valorPagamento, fornecedor_cid, pago "
        sqlWhere = String.Empty
        sqlFrom = " From ContasPagar "

        '-- cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")
        '-- codigo
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.codigo, "codigo")
        '-- codigoBarra
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.codigoBarra, "codigoBarra")
        '-- valor
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.valor, "valor")
        '-- aceite
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.aceite, "aceite")
        '-- observacao
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.observacao, "observacao")
        '-- dataEmissao
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.dataEmissao, "dataEmissao")
        '-- dataPagamento
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.dataPagamento, "dataPagamento")
        '-- dataVencimento
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.dataVencimento, "dataVencimento")
        '-- valorPagamento
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.valorPagamento, "valorPagamento")
        '-- fornecedor_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.fornecedor_cid, "fornecedor_cid")
        '-- aceite
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.pago, "pago")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoContasPagar

              For Each row In dt.Rows
                item = New dContasPagar

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.codigo = cFuncoes.RetornarTexto(row("codigo"))
                item.valor = cFuncoes.RetornarDecimal(row("valor"))
                item.observacao = cFuncoes.RetornarTexto(row("observacao"))
                item.aceite = cFuncoes.RetornarBoleano(row("aceite"))
                item.dataEmissao = cFuncoes.RetornarTexto(row("dataEmissao"))
                item.dataVencimento = cFuncoes.RetornarTexto(row("dataVencimento"))
                item.dataPagamento = cFuncoes.RetornarTexto(row("dataPagamento"))
                item.valorPagamento = cFuncoes.RetornarDecimal(row("valorPagamento"))
                item.codigoBarra = cFuncoes.RetornarTexto(row("codigoBarra"))
                item.fornecedor_cid = cFuncoes.RetornarInteiro(row("fornecedor_cid"))
                item.pago = cFuncoes.RetornarBoleano(row("pago"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar ContasPagar [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dContasPagar) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " INSERT INTO " & _
            " ContasPagar ( codigo, codigoBarra, valor, aceite, observacao, " & _
            " dataEmissao, dataVencimento, dataPagamento, valorPagamento, fornecedor_cid, pago ) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dados.codigo) & "," & _
            cFuncoes.PersistirTexto(dados.codigoBarra) & "," & _
            cFuncoes.PersistirDecimal(dados.valor) & "," & _
            cFuncoes.PersistirBoleano(dados.aceite) & "," & _
            cFuncoes.PersistirTexto(dados.observacao) & "," & _
            cFuncoes.PersistirData(dados.dataEmissao) & "," & _
            cFuncoes.PersistirData(dados.dataVencimento) & "," & _
            cFuncoes.PersistirData(dados.dataPagamento) & "," & _
            cFuncoes.PersistirDecimal(dados.valorPagamento) & "," & _
            cFuncoes.PersistirInteiro(dados.fornecedor_cid) & "," & _
            cFuncoes.PersistirBoleano(dados.pago) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ContasPagar [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Incluir = retorno

    End Function

    Public Function Importar(ByVal dados As dContasPagar) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " INSERT INTO " & _
            " ContasPagar ( cid, codigo, codigoBarra, valor, aceite, observacao, " & _
            " dataEmissao, dataVencimento, dataPagamento, valorPagamento, fornecedor_cid, pago ) " & _
            " VALUES (" & _
            cFuncoes.PersistirInteiro(dados.cid) & _
            cFuncoes.PersistirTexto(dados.codigo) & _
            cFuncoes.PersistirTexto(dados.codigoBarra) & _
            cFuncoes.PersistirDecimal(dados.valor) & _
            cFuncoes.PersistirInteiro(dados.aceite) & _
            cFuncoes.PersistirTexto(dados.observacao) & _
            cFuncoes.PersistirData(dados.dataEmissao) & _
            cFuncoes.PersistirData(dados.dataVencimento) & _
            cFuncoes.PersistirData(dados.dataPagamento) & _
            cFuncoes.PersistirDecimal(dados.valorPagamento) & _
            cFuncoes.PersistirInteiro(dados.fornecedor_cid) & _
            cFuncoes.PersistirInteiro(dados.pago) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Importar ContasPagar [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Importar = retorno

    End Function

    Public Function Alterar(ByVal dados As dContasPagar) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " UPDATE ContasPagar SET " & _
            " codigo = " & cFuncoes.PersistirTexto(dados.codigo) & "," & _
            " codigoBarra = " & cFuncoes.PersistirTexto(dados.codigoBarra) & "," & _
            " valor = " & cFuncoes.PersistirDecimal(dados.valor) & "," & _
            " aceite = " & cFuncoes.PersistirBoleano(dados.aceite) & "," & _
            " observacao = " & cFuncoes.PersistirTexto(dados.observacao) & "," & _
            " dataEmissao = " & cFuncoes.PersistirData(dados.dataEmissao) & "," & _
            " dataVencimento = " & cFuncoes.PersistirData(dados.dataVencimento) & "," & _
            " dataPagamento = " & cFuncoes.PersistirData(dados.dataPagamento) & "," & _
            " valorPagamento = " & cFuncoes.PersistirDecimal(dados.valorPagamento) & "," & _
            " fornecedor_cid = " & cFuncoes.PersistirInteiro(dados.fornecedor_cid) & "," & _
            " pago = " & cFuncoes.PersistirBoleano(dados.pago) & _
            " WHERE " & _
            " cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar ContasPagar [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dContasPagar) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM ContasPagar " & _
            " WHERE cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ContasPagar [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace