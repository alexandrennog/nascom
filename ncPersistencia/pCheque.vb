Imports ncDados.nsCheques
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCheques

  Public Class pCheques

    Public Function Listar() As ColecaoCheques

      Dim retorno As ColecaoCheques
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dCheques
      Dim comandoSQL As String


      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select cid, " & _
                     " dataemissao, datadeposito, valor, numero, vendaid, clienteid, baixado, " & _
                     " bancoCodigo, bancoNome, agencia, conta From cheques"

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoCheques

              For Each row In dt.Rows
                item = New dCheques

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.dataEmissao = cFuncoes.RetornarData(row("dataemissao"))
                item.dataDeposito = cFuncoes.RetornarData(row("datadeposito"))
                item.valor = cFuncoes.RetornarDecimal(row("valor"))
                item.Numero = cFuncoes.RetornarTexto(row("numero"))
                item.vendasId = cFuncoes.RetornarInteiro(row("vendasid"))
                item.clienteId = cFuncoes.RetornarInteiro(row("clienteid"))
                item.baixado = cFuncoes.RetornarTexto(row("baixado"))
                item.bancoCodigo = cFuncoes.RetornarTexto(row("bancoCodigo"))
                item.bancoNome = cFuncoes.RetornarTexto(row("bancoNome"))
                item.agencia = cFuncoes.RetornarTexto(row("agencia"))
                item.conta = cFuncoes.RetornarTexto(row("conta"))

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
        Throw New ExcecaoNascomercio("Erro em Listar Cheques [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dCheques) As ColecaoCheques

      Dim retorno As ColecaoCheques
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dCheques
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String


      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select cid, " & _
                    " dataemissao, datadeposito, valor, numero, vendaid, clienteid, baixado, " & _
                    " bancoCodigo, bancoNome, agencia, conta "

        sqlWhere = String.Empty
        sqlFrom = " From cheques "

        '-- cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")

        '-- Numero
        If dados.Numero <> 0 Then
          sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.Numero, "numero")
        End If

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoCheques

              For Each row In dt.Rows
                item = New dCheques

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.dataEmissao = cFuncoes.RetornarData(row("dataemissao"))
                item.dataDeposito = cFuncoes.RetornarData(row("datadeposito"))
                item.Valor = cFuncoes.RetornarDecimal(row("valor"))
                item.Numero = cFuncoes.RetornarTexto(row("numero"))
                item.vendasId = cFuncoes.RetornarInteiro(row("vendaid"))
                item.clienteId = cFuncoes.RetornarInteiro(row("clienteid"))
                item.baixado = cFuncoes.RetornarTexto(row("baixado"))
                item.bancoCodigo = cFuncoes.RetornarTexto(row("bancoCodigo"))
                item.bancoNome = cFuncoes.RetornarTexto(row("bancoNome"))
                item.agencia = cFuncoes.RetornarTexto(row("agencia"))
                item.conta = cFuncoes.RetornarTexto(row("conta"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar Cheques[" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dCheques) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String


      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " INSERT INTO " & _
            " cheques ( dataemissao, datadeposito, valor, numero, vendaid, clienteid, baixado, " & _
            " bancoCodigo, bancoNome, agencia, conta ) " & _
            " VALUES (" & _
                    cFuncoes.PersistirData(dados.dataEmissao) & "," & _
                    cFuncoes.PersistirData(dados.dataDeposito) & "," & _
                    cFuncoes.PersistirDecimal(dados.valor) & "," & _
                    cFuncoes.PersistirTexto(dados.Numero) & "," & _
                    cFuncoes.PersistirInteiro(dados.vendasId) & "," & _
                    cFuncoes.PersistirInteiro(dados.clienteId) & "," & _
                    cFuncoes.PersistirTexto(dados.baixado) & "," & _
                    cFuncoes.PersistirTexto(dados.bancoCodigo) & "," & _
                    cFuncoes.PersistirTexto(dados.bancoNome) & "," & _
                    cFuncoes.PersistirTexto(dados.agencia) & "," & _
                    cFuncoes.PersistirTexto(dados.conta) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Cheques [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dCheques) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " UPDATE cheques SET " & _
            " dataEmissao = " & cFuncoes.PersistirData(dados.dataEmissao) & "," & _
            " dataDeposito = " & cFuncoes.PersistirData(dados.dataDeposito) & "," & _
            " valor = " & cFuncoes.PersistirDecimal(dados.valor) & "," & _
            " numero = " & cFuncoes.PersistirTexto(dados.Numero) & "," & _
            " vendaid = " & cFuncoes.PersistirInteiro(dados.vendasId) & "," & _
            " clienteid = " & cFuncoes.PersistirInteiro(dados.clienteId) & "," & _
            " baixado = " & cFuncoes.PersistirTexto(dados.baixado) & "," & _
            " bancoCodigo = " & cFuncoes.PersistirTexto(dados.bancoCodigo) & "," & _
            " bancoNome = " & cFuncoes.PersistirTexto(dados.bancoNome) & "," & _
            " agencia = " & cFuncoes.PersistirTexto(dados.agencia) & "," & _
            " conta = " & cFuncoes.PersistirTexto(dados.conta) & _
            " WHERE " & _
            " cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Cheque [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Baixar() As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " UPDATE cheques SET " & _
            " baixado = 'Sim'" & _
            " WHERE (baixado <> 'Sim') AND " & _
            " dataDeposito < '" & Today.ToString("yyyy-MM-dd") & "'"

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Cheque [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Return retorno

    End Function
    Public Function Excluir(ByVal dados As dCheques) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM cheques " & _
            " WHERE cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Cheque [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
