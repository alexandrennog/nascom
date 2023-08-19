Imports ncComum
Imports ncComum.nsAcessoBD
Imports ncComum.nsExcecao
Imports ncComum.nsFuncoes
Imports ncDados


Public Class ColecaoPix
    Inherits List(Of dPix)
End Class
Public Class pPix

    Public Function Consultar(ByVal dados As dPix) As ColecaoPix

        Dim retorno As ColecaoPix
        Dim acessoBanco As cAcessoBD
        Dim ds As DataSet
        Dim dt As DataTable
        Dim row As DataRow
        Dim item As dPix
        Dim sqlSelect As String
        Dim sqlWhere As String
        Dim sqlFrom As String

        Try

            acessoBanco = New cAcessoBD

            sqlSelect = " Select txID, Observacao, SolicitacaoPagador as pagador, Original, controle "

            sqlWhere = String.Empty
            sqlFrom = " From PIX "

            '-- TxId
            If dados.TxId <> 0 Then
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.TxId, "TxId")
            End If

            '-- TxId
            If dados.Controle <> 0 Then
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.Controle, "controle")
            End If


            If Not sqlWhere.Equals(String.Empty) Then
                sqlWhere = " WHERE " & sqlWhere
            End If

            ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)


            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    dt = ds.Tables(0)

                    If dt.Rows.Count > 0 Then
                        retorno = New ColecaoPix

                        For Each row In dt.Rows
                            item = New dPix
                            item.TxId = cFuncoes.RetornarTexto(row("TxId"))
                            'item.Cliente = cFuncoes.RetornarTexto(row("Cliente"))
                            'item.Cpf = cFuncoes.RetornarTexto(row("Cpf"))
                            'item.Cnpj = cFuncoes.RetornarTexto(row("Cnpj"))
                            item.Observacao = cFuncoes.RetornarTexto(row("Observacao"))
                            item.Pagador = cFuncoes.RetornarTexto(row("pagador"))
                            item.Original = cFuncoes.RetornarDecimal(row("Original"))
                            item.Controle = cFuncoes.RetornarInteiro(row("controle"))
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
            Throw New ExcecaoNascomercio("Erro em Consultar Pix[" & Me.ToString() & "] - " & ex.Message)

        End Try

        Return retorno

    End Function


    Public Function Consultar() As dPix

        Dim retorno As dPix
        Dim acessoBanco As cAcessoBD
        Dim ds As DataSet
        Dim dt As DataTable
        Dim row As DataRow
        Dim item As dPix
        Dim sqlSelect As String
        Dim sqlWhere As String
        Dim sqlFrom As String

        Try

            acessoBanco = New cAcessoBD

            sqlSelect = " Select ID, txID, SolicitacaoPagador, Original, status, Observacao, DataHora, controle   "

            sqlWhere = " order by DataHora desc LIMIT 1;"
            sqlFrom = " From PIX "

            ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)


            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    dt = ds.Tables(0)

                    If dt.Rows.Count > 0 Then
                        retorno = New dPix

                        For Each row In dt.Rows
                            item = New dPix
                            item.ID = cFuncoes.RetornarTexto(row("ID"))
                            item.TxId = cFuncoes.RetornarTexto(row("TxId"))
                            item.Original = cFuncoes.RetornarDecimal(row("Original"))
                            item.Status = cFuncoes.RetornarTexto(row("status"))
                            item.DataHora = cFuncoes.RetornarData(row("DataHora"))
                            item.Observacao = cFuncoes.RetornarTexto(row("Observacao"))
                            item.Controle = cFuncoes.RetornarInteiro(row("controle"))
                            retorno = item
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
            Throw New ExcecaoNascomercio("Erro em Consultar Pix[" & Me.ToString() & "] - " & ex.Message)

        End Try

        Return retorno

    End Function


    Public Function ConsultarConfig() As dPixConfig

        Dim retorno As dPixConfig
        Dim acessoBanco As cAcessoBD
        Dim ds As DataSet
        Dim dt As DataTable
        Dim row As DataRow
        Dim item As dPixConfig
        Dim sqlSelect As String
        Dim sqlWhere As String
        Dim sqlFrom As String

        Try

            acessoBanco = New cAcessoBD
            sqlSelect = " SELECT Cliente, Cpf, Cnpj, Nome, Chave "
            sqlWhere = String.Empty
            sqlFrom = "  FROM pixconfig "

            ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom)

            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    dt = ds.Tables(0)

                    If dt.Rows.Count > 0 Then
                        retorno = New dPixConfig

                        For Each row In dt.Rows
                            item = New dPixConfig
                            item.Cliente = cFuncoes.RetornarTexto(row("Cliente"))
                            item.Cpf = cFuncoes.RetornarTexto(row("Cpf"))
                            item.Cnpj = cFuncoes.RetornarTexto(row("Cnpj"))
                            item.Nome = cFuncoes.RetornarTexto(row("Nome"))
                            item.Chave = cFuncoes.RetornarTexto(row("Chave"))
                        Next
                        retorno = item
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
            Throw New ExcecaoNascomercio("Erro em Consultar Pix[" & Me.ToString() & "] - " & ex.Message)

        End Try

        Return retorno

    End Function

    Public Function Incluir(ByVal dados As dPix) As Integer
        Dim colecaoPRODCOR As ColecaoPix = Nothing
        Dim retorno As Integer
        Dim acessoBanco As cAcessoBD
        Dim comandoSQL As String
        Dim ds As DataSet
        Dim dt As DataTable
        Dim ColecaoPix As List(Of String)
        Dim row As DataRow
        Dim item As String
        Dim ret As ColecaoPix

        Try

            acessoBanco = New cAcessoBD

            comandoSQL = " INSERT INTO PIX (ID, SolicitacaoPagador, Original, DataHora, Observacao, controle)  VALUES ("
            comandoSQL += cFuncoes.PersistirTexto(DateTime.Now.ToString("yyyyMMddHHmmss")) + "," + cFuncoes.PersistirTexto(dados.Pagador) & "," & cFuncoes.PersistirDecimal(dados.Original)
            comandoSQL += "," & cFuncoes.PersistirDataHora(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")) & "," & cFuncoes.PersistirTexto(dados.Observacao) & "," & cFuncoes.PersistirInteiro(dados.Controle) + ")"

            retorno = acessoBanco.ExecutarCID(comandoSQL)

            comandoSQL = " SELECT controle FROM pix where ID = (select MAX(ID) from pix);"
            ds = acessoBanco.ExecutarDS(comandoSQL)

            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    dt = ds.Tables(0)

                    If dt.Rows.Count > 0 Then
                        ret = New ColecaoPix()

                        For Each row In dt.Rows
                            retorno = nsFuncoes.cFuncoes.RetornarTexto(row("controle"))
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
            Throw New ExcecaoNascomercio("Erro em Incluir Pix [" & Me.ToString() & "] - " & ex.Message)

        End Try

        Incluir = retorno

    End Function

End Class
