Imports ncDados.nsGiro
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsGiro

  Public Class pGiro

    Public Function Listar() As ColecaoGiro

      Dim retorno As ColecaoGiro
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dGiro
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " Select produto_cid, codigoBarras, dataInicio, dataFim, dias, quantidade, dataAtual, " & _
            " usuario_cid, usuario_nomeCompleto, situacao From Giro "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoGiro

              For Each row In dt.Rows
                item = New dGiro

                item.produto_cid = cFuncoes.RetornarInteiro(row("produto_cid"))
                item.codigoBarras = cFuncoes.RetornarTexto(row("codigoBarras"))
                item.dataInicio = cFuncoes.RetornarTexto(row("dataInicio"))
                item.dataFim = cFuncoes.RetornarTexto(row("dataFim"))
                item.dias = cFuncoes.RetornarInteiro(row("dias"))
                                item.quantidade = cFuncoes.RetornarDecimal(row("quantidade"))
                                item.dataAtual = cFuncoes.RetornarTexto(row("dataAtual"))
                item.usuario_cid = cFuncoes.RetornarInteiro(row("usuario_cid"))
                item.usuario_nomeCompleto = cFuncoes.RetornarTexto(row("usuario_nomeCompleto"))
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
        Throw New ExcecaoNascomercio("Erro em Listar Giro [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dGiro) As ColecaoGiro

      Dim retorno As ColecaoGiro
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dGiro
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD

        sqlSelect = " Select produto_cid, codigoBarras, dataInicio, dataFim, dias, quantidade, dataAtual, " & _
            " usuario_cid, usuario_nomeCompleto, situacao "
        sqlWhere = String.Empty
        sqlFrom = " From Giro "

        '-- produto_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.produto_cid, "produto_cid")

        '-- codigoBarras
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.codigoBarras, "codigoBarras")

        '-- dataInicio
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.dataInicio, "dataInicio")

        '-- dataFim
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.dataFim, "dataFim")

        '-- dias
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.dias, "dias")

        '-- quantidade
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.quantidade, "quantidade")

        '-- usuario_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.usuario_cid, "usuario_cid")

        '-- usuario_nomeCompleto
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.usuario_nomeCompleto, "usuario_nomeCompleto")

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
              retorno = New ColecaoGiro

              For Each row In dt.Rows
                item = New dGiro

                item.produto_cid = cFuncoes.RetornarInteiro(row("produto_cid"))
                item.codigoBarras = cFuncoes.RetornarTexto(row("codigoBarras"))
                item.dataInicio = cFuncoes.RetornarTexto(row("dataInicio"))
                item.dataFim = cFuncoes.RetornarTexto(row("dataFim"))
                item.dias = cFuncoes.RetornarInteiro(row("dias"))
                                item.quantidade = cFuncoes.RetornarDecimal(row("quantidade"))
                                item.dataAtual = cFuncoes.RetornarTexto(row("dataAtual"))
                item.usuario_cid = cFuncoes.RetornarInteiro(row("usuario_cid"))
                item.usuario_nomeCompleto = cFuncoes.RetornarTexto(row("usuario_nomeCompleto"))
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
        Throw New ExcecaoNascomercio("Erro em Consultar Giro [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dGiro) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

                comandoSQL = " INSERT INTO " &
            " Giro ( produto_cid, codigoBarras, dataInicio, dataFim, dias, quantidade, dataAtual, " &
            " usuario_cid, usuario_nomeCompleto, situacao ) " &
            " VALUES (" &
            cFuncoes.PersistirInteiro(dados.produto_cid) & "," &
            cFuncoes.PersistirTexto(dados.codigoBarras) & "," &
            cFuncoes.PersistirData(dados.dataInicio) & "," &
            cFuncoes.PersistirData(dados.dataFim) & "," &
            cFuncoes.PersistirInteiro(dados.dias) & "," &
            cFuncoes.PersistirDecimal(dados.quantidade) & "," &
            cFuncoes.PersistirData(dados.dataAtual) & "," &
            cFuncoes.PersistirInteiro(dados.usuario_cid) & "," &
            cFuncoes.PersistirTexto(dados.usuario_nomeCompleto) & "," &
            cFuncoes.PersistirTexto(dados.situacao) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Giro [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Incluir = retorno

    End Function

    Public Function Importar(ByVal dados As dGiro) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

                comandoSQL = " INSERT INTO " &
            " Giro ( produto_cid, codigoBarras, dataInicio, dataFim, dias, quantidade, dataAtual, " &
            " usuario_cid, usuario_nomeCompleto, situacao ) " &
            " VALUES (" &
            cFuncoes.PersistirInteiro(dados.produto_cid) & "," &
            cFuncoes.PersistirTexto(dados.codigoBarras) & "," &
            cFuncoes.PersistirData(dados.dataInicio) & "," &
            cFuncoes.PersistirData(dados.dataFim) & "," &
            cFuncoes.PersistirInteiro(dados.dias) & "," &
            cFuncoes.PersistirDecimal(dados.quantidade) & "," &
            cFuncoes.PersistirData(dados.dataAtual) & "," &
            cFuncoes.PersistirInteiro(dados.usuario_cid) & "," &
            cFuncoes.PersistirTexto(dados.usuario_nomeCompleto) & "," &
            cFuncoes.PersistirTexto(dados.situacao) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Importar Giro [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Importar = retorno

    End Function

    Public Function Alterar(ByVal dados As dGiro) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

                comandoSQL = " UPDATE Giro SET " &
            " dataInicio = " & cFuncoes.PersistirData(dados.dataInicio) & "," &
            " dataFim = " & cFuncoes.PersistirData(dados.dataFim) & "," &
            " dias = " & cFuncoes.PersistirInteiro(dados.dias) & "," &
            " quantidade= " & cFuncoes.PersistirDecimal(dados.quantidade) & "," &
            " dataAtual = " & cFuncoes.PersistirData(dados.dataAtual) & "," &
            " usuario_cid = " & cFuncoes.PersistirInteiro(dados.usuario_cid) & "," &
            " usuario_nomeCompleto = " & cFuncoes.PersistirTexto(dados.usuario_nomeCompleto) & "," &
            " situacao = " & cFuncoes.PersistirTexto(dados.situacao) & " " &
            " WHERE " &
            " produto_cid = " & cFuncoes.PersistirInteiro(dados.produto_cid) & " AND " &
            " codigoBarras = " & cFuncoes.PersistirTexto(dados.codigoBarras)

                retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Giro [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dGiro) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM Giro " & _
            " WHERE " & _
            " produto_cid = " & cFuncoes.PersistirInteiro(dados.produto_cid) & " AND " & _
            " codigoBarras = " & cFuncoes.PersistirTexto(dados.codigoBarras)

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Giro [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
