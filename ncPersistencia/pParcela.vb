Imports ncDados.nsCrediario
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCrediario

    Public Class pParcela

        Public Function Listar() As ColecaoParcelas

            Dim retorno As ColecaoParcelas
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dParcelas
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " Select cid, crediarioid, codigoBarras, " & _
                             "dataemissao, datavencimento, valor, valorreceber, valorpago, situacao, observacao From Parcelas"

                ds = acessoBanco.ExecutarDS(comandoSQL)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoParcelas

                            For Each row In dt.Rows
                                item = New dParcelas

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.codigoBarras = cFuncoes.RetornarTexto(row("codigoBarras"))
                                item.crediarioId = cFuncoes.RetornarInteiro(row("crediarioid"))
                                item.dataEmissao = cFuncoes.RetornarData(row("dataemissao"))
                                item.dataVecimento = cFuncoes.RetornarData(row("datavencimento"))
                                item.valor = cFuncoes.RetornarDecimal(row("valor"))
                                item.valorReceber = cFuncoes.RetornarDecimal(row("valorreceber"))
                                item.valorPago = cFuncoes.RetornarDecimal(row("valorpago"))
                                item.situacao = cFuncoes.RetornarTexto(row("situacao"))
                                item.observacao = cFuncoes.RetornarTexto(row("observacao"))

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
                Throw New ExcecaoNascomercio("Erro em Listar Crediário [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dParcelas) As ColecaoParcelas

            Dim retorno As ColecaoParcelas
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dParcelas
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String


            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " Select cid, crediarioid, codigoBarras, " & _
                             "dataemissao, datavencimento, valor, valorreceber, valorpago, situacao, datapagamento, observacao "

                sqlWhere = String.Empty
                sqlFrom = " From parcelas "

                '-- data
                'If dados.cid <> 0 Then
                '  sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados., "cid")
                'End If

                '-- cid
                If dados.cid <> 0 Then
                    sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")
                End If

                '-- crediarioid
                If dados.crediarioId <> 0 Then
                    sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.crediarioId, "crediarioid")
                End If

                '-- codigoBarras
                If Not IsNothing(dados.codigoBarras) Then
                    If dados.codigoBarras.Trim <> "" Then
                        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.codigoBarras, "codigoBarras")
                    End If
                End If

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoParcelas

                            For Each row In dt.Rows
                                item = New dParcelas

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.codigoBarras = cFuncoes.RetornarTexto(row("codigoBarras"))
                                item.crediarioId = cFuncoes.RetornarInteiro(row("crediarioid"))
                                item.dataEmissao = cFuncoes.RetornarData(row("dataemissao"))
                                item.dataVecimento = cFuncoes.RetornarData(row("datavencimento"))
                                item.valor = cFuncoes.RetornarDecimal(row("valor"))
                                item.valorReceber = cFuncoes.RetornarDecimal(row("valorreceber"))
                                item.valorPago = cFuncoes.RetornarDecimal(row("valorpago"))
                                item.dataPagamento = cFuncoes.RetornarData(row("datapagamento"))
                                item.situacao = cFuncoes.RetornarTexto(row("situacao"))
                                item.observacao = cFuncoes.RetornarTexto(row("observacao"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar Crediario[" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Consultar = retorno

        End Function

        Public Function ConsultarParcelasCliente(ByVal codCliente As Integer) As ColecaoParcelas

            Dim retorno As ColecaoParcelas
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dParcelas
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " Select parcelas.cid, parcelas.crediarioid, parcelas.codigoBarras, " & _
                             "parcelas.dataemissao, parcelas.datavencimento, parcelas.valor," & _
                             "parcelas.valorreceber, parcelas.valorpago, parcelas.situacao, parcelas.datapagamento, parcelas.observacao "

                sqlWhere = String.Empty
                sqlFrom = " From parcelas inner join crediario on parcelas.crediarioid = crediario.cid"

                '-- codCliente
                If codCliente <> 0 Then
                    sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, codCliente, "clienteid")
                End If

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoParcelas

                            For Each row In dt.Rows
                                item = New dParcelas

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.codigoBarras = cFuncoes.RetornarTexto(row("codigoBarras"))
                                item.crediarioId = cFuncoes.RetornarInteiro(row("crediarioid"))
                                item.dataEmissao = cFuncoes.RetornarData(row("dataemissao"))
                                item.dataVecimento = cFuncoes.RetornarData(row("datavencimento"))
                                item.valor = cFuncoes.RetornarDecimal(row("valor"))
                                item.valorReceber = cFuncoes.RetornarDecimal(row("valorreceber"))
                                item.valorPago = cFuncoes.RetornarDecimal(row("valorpago"))
                                item.dataPagamento = cFuncoes.RetornarData(row("datapagamento"))
                                item.situacao = cFuncoes.RetornarTexto(row("situacao"))
                                item.observacao = cFuncoes.RetornarTexto(row("observacao"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar Crediario[" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function ConsultarParcelasVencidas(ByVal codCliente As Integer) As ColecaoParcelas

            Dim retorno As ColecaoParcelas
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dParcelas
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " Select parcelas.cid, parcelas.crediarioid, parcelas.codigoBarras, " & _
                             "parcelas.dataemissao, parcelas.datavencimento, parcelas.valor," & _
                             "parcelas.valorreceber, parcelas.valorpago, parcelas.situacao, parcelas.datapagamento "

                sqlWhere = String.Empty
                sqlFrom = " From parcelas inner join crediario on parcelas.crediarioid = crediario.cid"

                '-- codCliente
                If codCliente <> 0 Then
                    sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, codCliente, "clienteid")
                End If

                '-- data vencimento
                If codCliente <> 0 Then
                    sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, " datavencimento < date(now()) ")
                End If

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " order by parcelas.datavencimento ")

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoParcelas

                            For Each row In dt.Rows
                                item = New dParcelas

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.codigoBarras = cFuncoes.RetornarTexto(row("codigoBarras"))
                                item.crediarioId = cFuncoes.RetornarInteiro(row("crediarioid"))
                                item.dataEmissao = cFuncoes.RetornarData(row("dataemissao"))
                                item.dataVecimento = cFuncoes.RetornarData(row("datavencimento"))
                                item.valor = cFuncoes.RetornarDecimal(row("valor"))
                                item.valorReceber = cFuncoes.RetornarDecimal(row("valorreceber"))
                                item.valorPago = cFuncoes.RetornarDecimal(row("valorpago"))
                                item.dataPagamento = cFuncoes.RetornarData(row("datapagamento"))
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
                Throw New ExcecaoNascomercio("Erro em Consultar Crediario[" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function Incluir(ByVal dados As dParcelas) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " INSERT INTO " & _
                    " parcelas (crediarioid, codigoBarras, " & _
                             "dataemissao, datavencimento, valor, valorreceber, valorpago, datapagamento, situacao, observacao) " & _
                    " VALUES (" & _
                            cFuncoes.PersistirInteiro(dados.crediarioId) & "," & _
                            cFuncoes.PersistirTexto(dados.codigoBarras) & "," & _
                            cFuncoes.PersistirData(dados.dataEmissao) & "," & _
                            cFuncoes.PersistirData(dados.dataVecimento) & "," & _
                            cFuncoes.PersistirDecimal(dados.valor) & "," & _
                            cFuncoes.PersistirDecimal(dados.valorReceber) & "," & _
                            cFuncoes.PersistirDecimal(dados.valorPago) & "," & _
                            cFuncoes.PersistirData(dados.dataPagamento) & "," & _
                            cFuncoes.PersistirTexto(dados.situacao) & "," & _
                            cFuncoes.PersistirTexto(dados.observacao) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Crediario [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function ConsultarPagamentos(ByVal dados As dParcelas) As ColecaoParcelas

            Dim retorno As ColecaoParcelas
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dParcelas
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String


            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " Select parcelasid, valorpago, datapagamento, diasAtraso " 

                sqlWhere = String.Empty
                sqlFrom = " From parcelaspag "

                '-- parcelasid
                If dados.crediarioId <> 0 Then
                    sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "parcelasid")
                End If

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoParcelas

                            For Each row In dt.Rows
                                item = New dParcelas

                                item.cid = cFuncoes.RetornarInteiro(row("parcelasid"))
                                item.valorPago = cFuncoes.RetornarDecimal(row("valorpago"))
                                item.dataPagamento = cFuncoes.RetornarData(row("datapagamento"))
                                item.diasAtraso = cFuncoes.RetornarInteiro(row("diasAtraso"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar Pagamentos[" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function IncluirPagamento(ByVal dados As dParcelas) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " INSERT INTO " & _
                    " parcelaspag (parcelasid, valorpago, datapagamento, diasAtraso) " & _
                    " VALUES (" & _
                            cFuncoes.PersistirInteiro(dados.cid) & "," & _
                            cFuncoes.PersistirDecimal(dados.valorPago) & "," & _
                            cFuncoes.PersistirData(dados.dataPagamento) & "," & _
                            cFuncoes.PersistirInteiro(dados.diasAtraso) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Pagamento [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function Corrigir() As Integer
            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try
                acessoBanco = New cAcessoBD

                comandoSQL = "update parcelas set valorreceber = 0.0 where situacao = '01' and valorreceber <= valorpago;"

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em corrigir parcelas [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function Alterar(ByVal dados As dParcelas) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " UPDATE parcelas SET " & _
                    " codigoBarras = " & cFuncoes.PersistirTexto(dados.codigoBarras) & "," & _
                    " crediarioId = " & cFuncoes.PersistirInteiro(dados.crediarioId) & "," & _
                    " dataEmissao = " & cFuncoes.PersistirData(dados.dataEmissao) & "," & _
                    " dataVencimento = " & cFuncoes.PersistirData(dados.dataVecimento) & "," & _
                    " valor = " & cFuncoes.PersistirDecimal(dados.valor) & "," & _
                    " valorreceber = " & cFuncoes.PersistirDecimal(dados.valorReceber) & "," & _
                    " valorpago = " & cFuncoes.PersistirDecimal(dados.valorPago) & "," & _
                    " dataPagamento = " & cFuncoes.PersistirData(dados.dataPagamento) & "," & _
                    " situacao = " & cFuncoes.PersistirTexto(dados.situacao) & "," & _
                    " observacao = " & cFuncoes.PersistirTexto(dados.observacao) & _
                    " WHERE " & _
                    " cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar crediario [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function Excluir(ByVal dados As dParcelas) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM parcelas " & _
                    " WHERE cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir crediario [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Excluir = retorno

        End Function

    End Class

End Namespace
