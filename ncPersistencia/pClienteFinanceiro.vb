Imports ncDados.nsCliente
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCliente

  Public Class pClienteFinanceiro

    Public Function Listar() As ColecaoClienteFinanceiro

      Dim retorno As ColecaoClienteFinanceiro
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dClienteFinanceiro
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " Select limite, situacaoCrediario, cliente_cid, " & _
                      "banco1, banco2, agencia1, agencia2, conta1, conta2, gerente1, gerente2, referencia1, referencia2, ddd1, ddd2, telefone1, telefone2, observacoes " & _
                      " From clientefinanceiro "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoClienteFinanceiro

              For Each row In dt.Rows
                item = New dClienteFinanceiro

                item.limite = cFuncoes.RetornarDecimal(row("limite"))
                item.situacaoCrediario = cFuncoes.RetornarTexto(row("situacaoCrediario"))
                item.cliente_cid = cFuncoes.RetornarInteiro(row("cliente_cid"))
                item.banco1 = cFuncoes.RetornarTexto(row("banco1"))
                item.banco2 = cFuncoes.RetornarTexto(row("banco2"))
                item.agencia1 = cFuncoes.RetornarTexto(row("agencia1"))
                item.agencia2 = cFuncoes.RetornarTexto(row("agencia2"))
                item.conta1 = cFuncoes.RetornarTexto(row("conta1"))
                item.conta2 = cFuncoes.RetornarTexto(row("conta2"))
                item.gerente1 = cFuncoes.RetornarTexto(row("gerente1"))
                item.gerente2 = cFuncoes.RetornarTexto(row("gerente2"))
                item.referencia1 = cFuncoes.RetornarTexto(row("referencia1"))
                item.referencia2 = cFuncoes.RetornarTexto(row("referencia2"))
                item.telefone1 = cFuncoes.RetornarTexto(row("telefone1"))
                item.telefone2 = cFuncoes.RetornarTexto(row("telefone2"))
                item.ddd1 = cFuncoes.RetornarTexto(row("ddd1"))
                item.ddd2 = cFuncoes.RetornarTexto(row("ddd2"))
                item.observacoes = cFuncoes.RetornarTexto(row("observacoes"))

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
        Throw New ExcecaoNascomercio("Erro em Listar Cliente - Financeiro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dClienteFinanceiro) As ColecaoClienteFinanceiro

      Dim retorno As ColecaoClienteFinanceiro
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dClienteFinanceiro
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD

        sqlSelect = " Select limite, situacaoCrediario, cliente_cid, " & _
                      "banco1, banco2, agencia1, agencia2, conta1, conta2, gerente1, gerente2, referencia1, referencia2, ddd1, ddd2, telefone1, telefone2, observacoes "
        sqlWhere = String.Empty
        sqlFrom = " From clientefinanceiro "

        '-- limite
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.limite, "limite")

        '-- situacaoCredito
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.situacaoCrediario, "situacaoCrediario")

        '-- cliente_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cliente_cid, "cliente_cid")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoClienteFinanceiro

              For Each row In dt.Rows
                item = New dClienteFinanceiro

                item.limite = cFuncoes.RetornarDecimal(row("limite"))
                item.situacaoCrediario = cFuncoes.RetornarTexto(row("situacaoCrediario"))
                item.cliente_cid = cFuncoes.RetornarInteiro(row("cliente_cid"))
                item.banco1 = cFuncoes.RetornarTexto(row("banco1"))
                item.banco2 = cFuncoes.RetornarTexto(row("banco2"))
                item.agencia1 = cFuncoes.RetornarTexto(row("agencia1"))
                item.agencia2 = cFuncoes.RetornarTexto(row("agencia2"))
                item.conta1 = cFuncoes.RetornarTexto(row("conta1"))
                item.conta2 = cFuncoes.RetornarTexto(row("conta2"))
                item.gerente1 = cFuncoes.RetornarTexto(row("gerente1"))
                item.gerente2 = cFuncoes.RetornarTexto(row("gerente2"))
                item.referencia1 = cFuncoes.RetornarTexto(row("referencia1"))
                item.referencia2 = cFuncoes.RetornarTexto(row("referencia2"))
                item.telefone1 = cFuncoes.RetornarTexto(row("telefone1"))
                item.telefone2 = cFuncoes.RetornarTexto(row("telefone2"))
                item.ddd1 = cFuncoes.RetornarTexto(row("ddd1"))
                item.ddd2 = cFuncoes.RetornarTexto(row("ddd2"))
                item.observacoes = cFuncoes.RetornarTexto(row("observacoes"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar Cliente - Financeiro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dClienteFinanceiro) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " INSERT INTO " & _
            " clientefinanceiro (limite, situacaoCrediario, cliente_cid, " & _
            " banco1, banco2, agencia1, agencia2, conta1, conta2, gerente1, gerente2, referencia1, referencia2, ddd1, ddd2, telefone1, telefone2, observacoes) " & _
            " VALUES (" & _
            cFuncoes.PersistirDecimal(dados.limite) & "," & _
            cFuncoes.PersistirTexto(dados.situacaoCrediario) & "," & _
            cFuncoes.PersistirInteiro(dados.cliente_cid) & "," & _
            cFuncoes.PersistirTexto(dados.banco1) & "," & _
            cFuncoes.PersistirTexto(dados.banco2) & "," & _
            cFuncoes.PersistirTexto(dados.agencia1) & "," & _
            cFuncoes.PersistirTexto(dados.agencia2) & "," & _
            cFuncoes.PersistirTexto(dados.conta1) & "," & _
            cFuncoes.PersistirTexto(dados.conta2) & "," & _
            cFuncoes.PersistirTexto(dados.gerente1) & "," & _
            cFuncoes.PersistirTexto(dados.gerente2) & "," & _
            cFuncoes.PersistirTexto(dados.referencia1) & "," & _
            cFuncoes.PersistirTexto(dados.referencia2) & "," & _
            cFuncoes.PersistirTexto(dados.ddd1) & "," & _
            cFuncoes.PersistirTexto(dados.ddd2) & "," & _
            cFuncoes.PersistirTexto(dados.telefone1) & "," & _
            cFuncoes.PersistirTexto(dados.telefone2) & "," & _
            cFuncoes.PersistirTexto(dados.observacoes) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Cliente - Financeiro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dClienteFinanceiro) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " UPDATE clientefinanceiro SET " & _
            " limite = " & cFuncoes.PersistirDecimal(dados.limite) & "," & _
            " situacaoCrediario = " & cFuncoes.PersistirTexto(dados.situacaoCrediario) & "," & _
            " banco1 = " & cFuncoes.PersistirTexto(dados.banco1) & "," & _
            " banco2 = " & cFuncoes.PersistirTexto(dados.banco2) & "," & _
            " agencia1 = " & cFuncoes.PersistirTexto(dados.agencia1) & "," & _
            " agencia2 = " & cFuncoes.PersistirTexto(dados.agencia2) & "," & _
            " conta1 = " & cFuncoes.PersistirTexto(dados.conta1) & "," & _
            " conta2 = " & cFuncoes.PersistirTexto(dados.conta2) & "," & _
            " gerente1 = " & cFuncoes.PersistirTexto(dados.gerente1) & "," & _
            " gerente2 = " & cFuncoes.PersistirTexto(dados.gerente2) & "," & _
            " referencia1 = " & cFuncoes.PersistirTexto(dados.referencia1) & "," & _
            " referencia2 = " & cFuncoes.PersistirTexto(dados.referencia2) & "," & _
            " ddd1 = " & cFuncoes.PersistirTexto(dados.ddd1) & "," & _
            " ddd2 = " & cFuncoes.PersistirTexto(dados.ddd2) & "," & _
            " telefone1 = " & cFuncoes.PersistirTexto(dados.telefone1) & "," & _
            " telefone2 = " & cFuncoes.PersistirTexto(dados.telefone2) & "," & _
            " observacoes = " & cFuncoes.PersistirTexto(dados.observacoes) & _
            " WHERE " & _
            " cliente_cid = " & cFuncoes.PersistirInteiro(dados.cliente_cid)

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Cliente - Financeiro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function ExcluirPorCliente(ByVal cliente_cid As Integer) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM clientefinanceiro " & _
            " WHERE cliente_cid = " & cliente_cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Cliente - Financeiro [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ExcluirPorCliente = retorno

    End Function

  End Class

End Namespace
