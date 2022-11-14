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

            sqlSelect = " Select txID, Cliente, Cpf, Cnpj, Nome, SolicitacaoPagador, Original "

            sqlWhere = String.Empty
            sqlFrom = " From PIX "

            '-- TxId
            If dados.TxId <> 0 Then
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.TxId, "TxId")
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
                            item.Cliente = cFuncoes.RetornarTexto(row("Cliente"))
                            item.Cpf = cFuncoes.RetornarTexto(row("Cpf"))
                            item.Cnpj = cFuncoes.RetornarTexto(row("Cnpj"))
                            item.Nome = cFuncoes.RetornarTexto(row("Nome"))
                            item.Pagador = cFuncoes.RetornarTexto(row("Pagador"))
                            item.Original = cFuncoes.RetornarDecimal(row("Original"))
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

    Public Function Incluir(ByVal dados As dPix) As Integer

        Dim retorno As Integer
        Dim acessoBanco As cAcessoBD
        Dim comandoSQL As String

        Try

            acessoBanco = New cAcessoBD

            comandoSQL = " INSERT INTO " &
                    " PIX (txID, Cliente, Cpf, Cnpj, Nome, SolicitacaoPagador, Original) " &
                    " VALUES (" &
                            cFuncoes.PersistirTexto(dados.TxId) & "," &
                            cFuncoes.PersistirTexto(dados.Cliente) & "," &
                            cFuncoes.PersistirTexto(dados.Cpf) & "," &
                            cFuncoes.PersistirTexto(dados.Cnpj) & "," &
                            cFuncoes.PersistirInteiro(dados.Nome) & "," &
                            cFuncoes.PersistirDecimal(dados.Pagador) & "," &
                            cFuncoes.PersistirDecimal(dados.Original) & ")"

            retorno = acessoBanco.ExecutarCID(comandoSQL)

        Catch ex As Exception

            retorno = Nothing
            Throw New ExcecaoNascomercio("Erro em Incluir Pix [" & Me.ToString() & "] - " & ex.Message)

        End Try

        Incluir = retorno

    End Function

End Class
