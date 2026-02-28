Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports ncComum.nsAcessoBD
Imports ncComum.nsExcecao
Imports ncComum.nsFuncoes
Imports ncDados
Imports ncDados.nsVenda

Namespace nsVenda

    Public Class pVenda

        Public Function Listar() As ColecaoVenda

            Dim retorno As ColecaoVenda
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dVenda
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " Select controle, usuarioId, clienteId, data, dinheiro, cheque, " &
                             "chequePre, cartaoDebito, cartaoCredito, crediario, " &
                             "parcelas, desconto, condicao, recebido, troco, troca, vale, defeito, terminal, total, Original, txID From Vendas"

                ds = acessoBanco.ExecutarDS(comandoSQL)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoVenda

                            For Each row In dt.Rows
                                item = New dVenda

                                item.controle = cFuncoes.RetornarInteiro(row("controle"))
                                item.usuarioId = cFuncoes.RetornarInteiro(row("usuarioId"))
                                item.clienteId = cFuncoes.RetornarInteiro(row("clienteId"))
                                item.Data = cFuncoes.RetornarTexto(row("data"))
                                item.Dinheiro = cFuncoes.RetornarDecimal(row("dinheiro"))
                                item.Cheque = cFuncoes.RetornarDecimal(row("cheque"))
                                item.ChequePre = cFuncoes.RetornarDecimal(row("chequepre"))
                                item.CartaoDebito = cFuncoes.RetornarDecimal(row("cartaodebito"))
                                item.CartaoCredito = cFuncoes.RetornarDecimal(row("cartaocredito"))
                                item.Crediario = cFuncoes.RetornarDecimal(row("crediario"))
                                item.Parcelas = cFuncoes.RetornarInteiro(row("parcelas"))
                                item.Desconto = cFuncoes.RetornarDecimal(row("desconto"))
                                item.Condicao = cFuncoes.RetornarInteiro(row("condicao"))
                                item.Recebido = cFuncoes.RetornarDecimal(row("recebido"))
                                item.Troco = cFuncoes.RetornarDecimal(row("troco"))
                                item.Troca = cFuncoes.RetornarDecimal(row("troca"))
                                item.Vale = cFuncoes.RetornarDecimal(row("vale"))
                                item.Defeito = cFuncoes.RetornarDecimal(row("defeito"))
                                item.Terminal = cFuncoes.RetornarDecimal(row("terminal"))
                                item.Total = cFuncoes.RetornarDecimal(row("total"))
                                item.Pix = cFuncoes.RetornarDecimal(row("Original"))
                                item.TXID = cFuncoes.RetornarTexto(row("txID"))
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
                Throw New ExcecaoNascomercio("Erro em Listar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Listar = retorno

        End Function

        Public Function ListarVendasNfe(ByVal dataIni As String, ByVal dataFim As String) As ColecaodVendasNfe

            Dim retorno As ColecaodVendasNfe
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dVendasNfe
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " SELECT SUBSTRING(chNFe, 25, 9) as cupom, DATE_FORMAT(dhrecbto, '%d/%m/%Y') as datavenda, total  " &
                             "FROM nascomercio.vendas INNER JOIN nascomercio.infprot ON chNFe = chave and cstat = 100 " &
                             $"where chave is not null and data >= '{dataIni}' and data <= '{dataFim}'"

                ds = acessoBanco.ExecutarDS(comandoSQL)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaodVendasNfe

                            For Each row In dt.Rows
                                item = New dVendasNfe

                                item.Cupom = cFuncoes.RetornarInteiro(row("cupom"))
                                item.DataVenda = cFuncoes.RetornarInteiro(row("datavenda"))
                                item.Valor = cFuncoes.RetornarInteiro(row("total"))

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
                Throw New ExcecaoNascomercio("Erro em ListarVendasNfe Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ListarVendasNfe = retorno

        End Function

        Public Function Consultar(ByVal dados As dVenda) As ColecaoVenda

            Dim retorno As ColecaoVenda
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dVenda
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String


            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " Select controle, usuarioId, clienteId, data, dinheiro, cheque, " &
                             "chequePre, cartaoDebito, cartaoCredito, crediario, vendedor, " &
                             "parcelas, desconto, condicao, recebido, troco, troca, vale, defeito, terminal, total, ordemservico, Original, txID, chave "

                sqlWhere = String.Empty
                sqlFrom = " From vendas "

                '-- controle
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.controle, "controle")

                '-- usuarioId
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.usuarioId, "usuarioId")

                '-- clienteId
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.clienteId, "clienteId")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoVenda

                            For Each row In dt.Rows
                                item = New dVenda

                                item.controle = cFuncoes.RetornarInteiro(row("controle"))
                                item.usuarioId = cFuncoes.RetornarInteiro(row("usuarioId"))
                                item.clienteId = cFuncoes.RetornarInteiro(row("clienteId"))
                                item.Vendedor = cFuncoes.RetornarTexto(row("vendedor"))
                                item.Data = cFuncoes.RetornarTexto(row("data"))
                                item.Dinheiro = cFuncoes.RetornarDecimal(row("dinheiro"))
                                item.Cheque = cFuncoes.RetornarDecimal(row("cheque"))
                                item.ChequePre = cFuncoes.RetornarDecimal(row("chequepre"))
                                item.CartaoDebito = cFuncoes.RetornarDecimal(row("cartaodebito"))
                                item.CartaoCredito = cFuncoes.RetornarDecimal(row("cartaocredito"))
                                item.Crediario = cFuncoes.RetornarDecimal(row("crediario"))
                                item.Parcelas = cFuncoes.RetornarInteiro(row("parcelas"))
                                item.Desconto = cFuncoes.RetornarDecimal(row("desconto"))
                                item.Condicao = cFuncoes.RetornarInteiro(row("condicao"))
                                item.Recebido = cFuncoes.RetornarDecimal(row("recebido"))
                                item.Troco = cFuncoes.RetornarDecimal(row("troco"))
                                item.Troca = cFuncoes.RetornarDecimal(row("troca"))
                                item.Vale = cFuncoes.RetornarDecimal(row("vale"))
                                item.Defeito = cFuncoes.RetornarDecimal(row("defeito"))
                                item.Terminal = cFuncoes.RetornarTexto(row("terminal"))
                                item.Total = cFuncoes.RetornarDecimal(row("total"))
                                item.Pix = cFuncoes.RetornarDecimal(row("Original"))
                                item.ordemServicoId = cFuncoes.RetornarTexto(row("ordemservico"))
                                item.TXID = cFuncoes.RetornarTexto(row("txID"))
                                item.Chave = cFuncoes.RetornarTexto(row("chave"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function ConsultarPix(ByVal dados As dVenda) As ColecaoVenda

            Dim retorno As ColecaoVenda
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dVenda
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String


            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " Select controle, usuarioId, clienteId, data, dinheiro, cheque, " &
                             "chequePre, cartaoDebito, cartaoCredito, crediario, vendedor, " &
                             "parcelas, desconto, condicao, recebido, troco, troca, vale, defeito, terminal, total, ordemservico, Original, txID "

                sqlWhere = String.Empty
                sqlFrom = " From vendas "


                '-- data
                sqlWhere = sqlWhere & " data between '" & cFuncoes.FormatarDataUniversal(dados.Data) & "' AND '" & cFuncoes.FormatarDataUniversal(dados.DataFim) & "'"

                '-- terminal
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.Caixa, "caixa")

                '-- data
                sqlWhere = sqlWhere & " AND  Original > 0 "

                '-- clienteId
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.clienteId, "clienteId")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoVenda

                            For Each row In dt.Rows
                                item = New dVenda

                                item.controle = cFuncoes.RetornarInteiro(row("controle"))
                                item.usuarioId = cFuncoes.RetornarInteiro(row("usuarioId"))
                                item.clienteId = cFuncoes.RetornarInteiro(row("clienteId"))
                                item.Vendedor = cFuncoes.RetornarTexto(row("vendedor"))
                                item.Data = cFuncoes.RetornarTexto(row("data"))
                                item.Dinheiro = cFuncoes.RetornarDecimal(row("dinheiro"))
                                item.Cheque = cFuncoes.RetornarDecimal(row("cheque"))
                                item.ChequePre = cFuncoes.RetornarDecimal(row("chequepre"))
                                item.CartaoDebito = cFuncoes.RetornarDecimal(row("cartaodebito"))
                                item.CartaoCredito = cFuncoes.RetornarDecimal(row("cartaocredito"))
                                item.Crediario = cFuncoes.RetornarDecimal(row("crediario"))
                                item.Parcelas = cFuncoes.RetornarInteiro(row("parcelas"))
                                item.Desconto = cFuncoes.RetornarDecimal(row("desconto"))
                                item.Condicao = cFuncoes.RetornarInteiro(row("condicao"))
                                item.Recebido = cFuncoes.RetornarDecimal(row("recebido"))
                                item.Troco = cFuncoes.RetornarDecimal(row("troco"))
                                item.Troca = cFuncoes.RetornarDecimal(row("troca"))
                                item.Vale = cFuncoes.RetornarDecimal(row("vale"))
                                item.Defeito = cFuncoes.RetornarDecimal(row("defeito"))
                                item.Terminal = cFuncoes.RetornarTexto(row("terminal"))
                                item.Total = cFuncoes.RetornarDecimal(row("total"))
                                item.Pix = cFuncoes.RetornarDecimal(row("Original"))
                                item.TXID = cFuncoes.RetornarTexto(row("txID"))
                                item.ordemServicoId = cFuncoes.RetornarTexto(row("ordemservico"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function
        Public Function ConsultarVendasPorVendedor(ByVal dados As dVendasPorVendedor) As ColecaoVendasPorVendedor

            Dim retorno As ColecaoVendasPorVendedor
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dVendasPorVendedor
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String


            Try

                acessoBanco = New cAcessoBD
                sqlWhere = String.Empty
                sqlFrom = ""

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                If dados.Nome = "Todos" Then
                    ds = acessoBanco.ExecutarDS($"call sp_recuperavendas(null, '{dados.Data.ToString("yyyy-MM-dd") + " 00:00:00"}' , '{dados.DataFim.ToString("yyyy-MM-dd") + " 23:59:59"}');")
                Else
                    ds = acessoBanco.ExecutarDS($"call sp_recuperavendas('{dados.Nome}', '{dados.Data.ToString("yyyy-MM-dd") + " 00:00:00"}' , '{dados.DataFim.ToString("yyyy-MM-dd") + " 23:59:59"}');")
                End If


                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 And ds.Tables(0).Rows(0).ItemArray(1) > -1 Then
                            retorno = New ColecaoVendasPorVendedor

                            For Each row In dt.Rows
                                item = New dVendasPorVendedor

                                item.Nome = cFuncoes.RetornarTexto(row("vendedor"))
                                item.TotalVendas = cFuncoes.RetornarInteiro(row("totalvendas"))
                                item.QuantidadeProdutos = cFuncoes.RetornarInteiro(row("qtdprod"))
                                item.ValorTotalVendas = cFuncoes.RetornarDecimal(row("valor"))
                                item.TicketMedio = cFuncoes.RetornarDecimal(row("ticket"))
                                item.PercentualAtingimento = cFuncoes.RetornarDecimal(row("pa"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function
        Public Function ConsultarVendasDaLoja(ByVal dados As dVendasPorVendedor) As ColecaoVendasPorVendedor

            Dim retorno As ColecaoVendasPorVendedor
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dVendasPorVendedor
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD

                sqlWhere = String.Empty
                sqlFrom = ""
                Dim mensagem As String

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS($"call sp_recuperavendasloja('{dados.Data.ToString("yyyy-MM-dd") + " 00:00:00"}' , '{dados.DataFim.ToString("yyyy-MM-dd") + " 23:59:59"}');")

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 And ds.Tables(0).Rows(0).ItemArray(0) > -1 Then
                            retorno = New ColecaoVendasPorVendedor

                            For Each row In dt.Rows
                                item = New dVendasPorVendedor

                                item.Nome = cFuncoes.RetornarTexto("")
                                item.TotalVendas = cFuncoes.RetornarInteiro(row("totalvendas"))
                                item.QuantidadeProdutos = cFuncoes.RetornarInteiro(row("qtdprod"))
                                item.ValorTotalVendas = cFuncoes.RetornarDecimal(row("valor"))
                                item.TicketMedio = cFuncoes.RetornarDecimal(row("ticket"))
                                item.PercentualAtingimento = cFuncoes.RetornarDecimal(row("pa"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function ConsultarCrediarioPix(ByVal dados As dVenda) As ColecaoVenda

            Dim retorno As ColecaoVenda
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dVenda
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String


            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " Select controle, usuarioId, clienteId, data, dinheiro, cheque, " &
                             "chequePre, cartaoDebito, cartaoCredito, crediario, crediariopagamento, parcelas, desconto,  " &
                             "condicao, recebido, troco, troca, vale, defeito, terminal, total, Original, txID "

                sqlWhere = String.Empty
                sqlFrom = " From credpag "


                '-- data
                sqlWhere = sqlWhere & " data between '" & cFuncoes.FormatarDataUniversal(dados.Data) & "' AND '" & cFuncoes.FormatarDataUniversal(dados.DataFim) & "'"

                '-- terminal
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.Caixa, "caixa")

                '-- data
                ' sqlWhere = sqlWhere & " AND  Original > 0 "

                '-- clienteId
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.clienteId, "clienteId")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoVenda

                            For Each row In dt.Rows
                                item = New dVenda

                                item.controle = cFuncoes.RetornarInteiro(row("controle"))
                                item.usuarioId = cFuncoes.RetornarInteiro(row("usuarioId"))
                                item.clienteId = cFuncoes.RetornarInteiro(row("clienteId"))
                                item.Data = cFuncoes.RetornarTexto(row("data"))
                                item.Dinheiro = cFuncoes.RetornarDecimal(row("dinheiro"))
                                item.Cheque = cFuncoes.RetornarDecimal(row("cheque"))
                                item.ChequePre = cFuncoes.RetornarDecimal(row("chequepre"))
                                item.CartaoDebito = cFuncoes.RetornarDecimal(row("cartaodebito"))
                                item.CartaoCredito = cFuncoes.RetornarDecimal(row("cartaocredito"))
                                item.Crediario = cFuncoes.RetornarDecimal(row("crediario"))
                                item.CrediarioPagamento = cFuncoes.RetornarDecimal(row("crediariopagamento"))
                                item.Parcelas = cFuncoes.RetornarInteiro(row("parcelas"))
                                item.Desconto = cFuncoes.RetornarDecimal(row("desconto"))
                                item.Condicao = cFuncoes.RetornarInteiro(row("condicao"))
                                item.Recebido = cFuncoes.RetornarDecimal(row("recebido"))
                                item.Troco = cFuncoes.RetornarDecimal(row("troco"))
                                item.Troca = cFuncoes.RetornarDecimal(row("troca"))
                                item.Vale = cFuncoes.RetornarDecimal(row("vale"))
                                item.Defeito = cFuncoes.RetornarDecimal(row("defeito"))
                                item.Terminal = cFuncoes.RetornarTexto(row("terminal"))
                                item.Total = cFuncoes.RetornarDecimal(row("total"))
                                item.Pix = cFuncoes.RetornarDecimal(row("Original"))
                                item.TXID = cFuncoes.RetornarTexto(row("txID"))
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
                Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function ConsultarTroca(ByVal dados As dVenda) As ColecaoVenda

            Dim retorno As ColecaoVenda
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dVenda
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String


            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " Select controle, usuarioId, clienteId, data, dinheiro, cheque, " &
                             "chequePre, cartaoDebito, cartaoCredito, crediario, vendedor, " &
                             "parcelas, desconto, condicao, recebido, troco, troca, vale, defeito, terminal, total, txID"

                sqlWhere = String.Empty
                sqlFrom = " From vales "

                '-- controle
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.controle, "controle")

                '-- usuarioId
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.usuarioId, "usuarioId")

                '-- clienteId
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.clienteId, "clienteId")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoVenda

                            For Each row In dt.Rows
                                item = New dVenda

                                item.controle = cFuncoes.RetornarInteiro(row("controle"))
                                item.usuarioId = cFuncoes.RetornarInteiro(row("usuarioId"))
                                item.clienteId = cFuncoes.RetornarInteiro(row("clienteId"))
                                item.Vendedor = cFuncoes.RetornarTexto(row("vendedor"))
                                item.Data = cFuncoes.RetornarTexto(row("data"))
                                item.Dinheiro = cFuncoes.RetornarDecimal(row("dinheiro"))
                                item.Cheque = cFuncoes.RetornarDecimal(row("cheque"))
                                item.ChequePre = cFuncoes.RetornarDecimal(row("chequepre"))
                                item.CartaoDebito = cFuncoes.RetornarDecimal(row("cartaodebito"))
                                item.CartaoCredito = cFuncoes.RetornarDecimal(row("cartaocredito"))
                                item.Crediario = cFuncoes.RetornarDecimal(row("crediario"))
                                item.Parcelas = cFuncoes.RetornarInteiro(row("parcelas"))
                                item.Desconto = cFuncoes.RetornarDecimal(row("desconto"))
                                item.Condicao = cFuncoes.RetornarInteiro(row("condicao"))
                                item.Recebido = cFuncoes.RetornarDecimal(row("recebido"))
                                item.Troco = cFuncoes.RetornarDecimal(row("troco"))
                                item.Troca = cFuncoes.RetornarDecimal(row("troca"))
                                item.Vale = cFuncoes.RetornarDecimal(row("vale"))
                                item.Defeito = cFuncoes.RetornarDecimal(row("defeito"))
                                item.Terminal = cFuncoes.RetornarTexto(row("terminal"))
                                item.Total = cFuncoes.RetornarDecimal(row("total"))
                                item.TXID = cFuncoes.RetornarTexto(row("txID"))
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
                Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function ConsultarUltimaVenda(ByVal produtos_cid As Integer) As dVenda

            Dim retorno As dVenda
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim sqlSelect As String
            Dim sqlSelect2 As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " SELECT " & _
                              " v.*, vp.valor as valorProduto, p.valorCompra as valorCusto "
                sqlWhere = String.Empty
                sqlFrom = " FROM " & _
                            " vendasprodutos vp " & _
                          " INNER JOIN vendas v " & _
                            " ON v.controle = vp.controle " & _
                          " INNER JOIN produtos p " & _
                            " ON p.cid = vp.produto "
                sqlSelect2 = " ORDER BY " & _
                               " v.data DESC " & _
                             " LIMIT 1 "

                '-- produto_cid
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, produtos_cid, "vp.produto")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " " & sqlSelect2)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New dVenda

                            row = dt.Rows(0)

                            retorno.controle = cFuncoes.RetornarInteiro(row("controle"))
                            retorno.usuarioId = cFuncoes.RetornarInteiro(row("usuarioId"))
                            retorno.clienteId = cFuncoes.RetornarInteiro(row("clienteId"))
                            retorno.Data = cFuncoes.RetornarData(row("data"))
                            retorno.Dinheiro = cFuncoes.RetornarDecimal(row("dinheiro"))
                            retorno.Cheque = cFuncoes.RetornarDecimal(row("cheque"))
                            retorno.ChequePre = cFuncoes.RetornarDecimal(row("chequepre"))
                            retorno.CartaoDebito = cFuncoes.RetornarDecimal(row("cartaodebito"))
                            retorno.CartaoCredito = cFuncoes.RetornarDecimal(row("cartaocredito"))
                            retorno.Crediario = cFuncoes.RetornarDecimal(row("crediario"))
                            retorno.Parcelas = cFuncoes.RetornarInteiro(row("parcelas"))
                            retorno.Desconto = cFuncoes.RetornarDecimal(row("desconto"))
                            retorno.Condicao = cFuncoes.RetornarInteiro(row("condicao"))
                            retorno.Recebido = cFuncoes.RetornarDecimal(row("recebido"))
                            retorno.Troco = cFuncoes.RetornarDecimal(row("troco"))
                            retorno.Troca = cFuncoes.RetornarDecimal(row("troca"))
                            retorno.Vale = cFuncoes.RetornarDecimal(row("vale"))
                            retorno.Defeito = cFuncoes.RetornarDecimal(row("defeito"))
                            retorno.Terminal = cFuncoes.RetornarTexto(row("terminal"))
                            retorno.Total = cFuncoes.RetornarDecimal(row("total"))
                            retorno.valorProduto = cFuncoes.RetornarDecimal(row("valorProduto"))
                            retorno.valorCusto = cFuncoes.RetornarDecimal(row("valorCusto"))
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
                Throw New ExcecaoNascomercio("Erro em ConsultarUltimaVenda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ConsultarUltimaVenda = retorno

        End Function

        Public Function ConsultarMax() As Integer

            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim sqlSelect As String
            Dim sqlFrom As String
            Dim retorno As Integer

            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " Select MAX(controle) as controle"
                sqlFrom = " From vendas "

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then

                            For Each row In dt.Rows
                                retorno = IIf(row("controle") Is DBNull.Value, 0, cFuncoes.RetornarInteiro(row("controle")))
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
                Throw New ExcecaoNascomercio("Erro em ConsultarMax Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ConsultarMax = retorno

        End Function

        Public Function Incluir(ByVal dados As dVenda) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " INSERT INTO " &
                    " vendas (controle, usuarioId, clienteId, data, dinheiro, cheque, " &
                             "chequePre, cartaoDebito, cartaoCredito, crediario, crediariopagamento, " &
                             "parcelas, desconto, condicao, recebido, troco, troca, " &
                             "vale, valeEmitido, defeito, retirada, terminal, ordemServico, vendedor, caixa, total, Original, txID ) " &
                    " VALUES (" &
                            cFuncoes.PersistirInteiro(dados.controle) & "," &
                            cFuncoes.PersistirTexto(dados.usuarioId) & "," &
                            cFuncoes.PersistirTexto(dados.clienteId) & "," &
                            cFuncoes.PersistirDataHora(dados.Data) & "," &
                            cFuncoes.PersistirDecimal(dados.Dinheiro) & "," &
                            cFuncoes.PersistirDecimal(dados.Cheque) & "," &
                            cFuncoes.PersistirDecimal(dados.ChequePre) & "," &
                            cFuncoes.PersistirDecimal(dados.CartaoDebito) & "," &
                            cFuncoes.PersistirDecimal(dados.CartaoCredito) & "," &
                            cFuncoes.PersistirDecimal(dados.Crediario) & "," &
                            cFuncoes.PersistirDecimal(dados.CrediarioPagamento) & "," &
                            cFuncoes.PersistirInteiro(dados.Parcelas) & "," &
                            cFuncoes.PersistirDecimal(dados.Desconto) & "," &
                            cFuncoes.PersistirInteiro(dados.Condicao) & "," &
                            cFuncoes.PersistirDecimal(dados.Recebido) & "," &
                            cFuncoes.PersistirDecimal(dados.Troco) & "," &
                            cFuncoes.PersistirDecimal(dados.Troca) & "," &
                            cFuncoes.PersistirDecimal(dados.Vale) & "," &
                            cFuncoes.PersistirDecimal(dados.ValeEmitido) & "," &
                            cFuncoes.PersistirDecimal(dados.Defeito) & "," &
                            cFuncoes.PersistirDecimal(dados.Retirada) & "," &
                            cFuncoes.PersistirTexto(dados.Terminal) & "," &
                            cFuncoes.PersistirTexto(dados.ordemServicoId) & "," &
                            cFuncoes.PersistirTexto(dados.Vendedor) & "," &
                            cFuncoes.PersistirTexto(dados.Caixa) & "," &
                            cFuncoes.PersistirDecimal(dados.Total) & "," &
                            cFuncoes.PersistirDecimal(dados.Pix) & "," &
                            cFuncoes.PersistirTexto(dados.TXID) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function IncluirVale(ByVal dados As dVenda) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " INSERT INTO " &
                    " vales (usuarioId, clienteId, data, dinheiro, cheque, " &
                             "chequePre, cartaoDebito, cartaoCredito, crediario, crediariopagamento, " &
                             "parcelas, desconto, condicao, recebido, troco, troca, " &
                             "vale, valeEmitido, defeito, retirada, terminal, vendedor, caixa, total, Original ) " &
                    " VALUES (" &
                            cFuncoes.PersistirTexto(dados.usuarioId) & "," &
                            cFuncoes.PersistirTexto(dados.clienteId) & "," &
                            cFuncoes.PersistirDataHora(dados.Data) & "," &
                            cFuncoes.PersistirDecimal(dados.Dinheiro) & "," &
                            cFuncoes.PersistirDecimal(dados.Cheque) & "," &
                            cFuncoes.PersistirDecimal(dados.ChequePre) & "," &
                            cFuncoes.PersistirDecimal(dados.CartaoDebito) & "," &
                            cFuncoes.PersistirDecimal(dados.CartaoCredito) & "," &
                            cFuncoes.PersistirDecimal(dados.Crediario) & "," &
                            cFuncoes.PersistirDecimal(dados.CrediarioPagamento) & "," &
                            cFuncoes.PersistirInteiro(dados.Parcelas) & "," &
                            cFuncoes.PersistirDecimal(dados.Desconto) & "," &
                            cFuncoes.PersistirInteiro(dados.Condicao) & "," &
                            cFuncoes.PersistirDecimal(dados.Recebido) & "," &
                            cFuncoes.PersistirDecimal(dados.Troco) & "," &
                            cFuncoes.PersistirDecimal(dados.Troca) & "," &
                            cFuncoes.PersistirDecimal(dados.Vale) & "," &
                            cFuncoes.PersistirDecimal(dados.ValeEmitido) & "," &
                            cFuncoes.PersistirDecimal(dados.Defeito) & "," &
                            cFuncoes.PersistirDecimal(dados.Retirada) & "," &
                            cFuncoes.PersistirTexto(dados.Terminal) & "," &
                            cFuncoes.PersistirTexto(dados.Vendedor) & "," &
                            cFuncoes.PersistirTexto(dados.Caixa) & "," &
                            cFuncoes.PersistirDecimal(dados.Total) & "," &
                            cFuncoes.PersistirDecimal(dados.Pix) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Vale [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function
        Public Function IncluirnNF(ByVal dados As dBasennf) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " INSERT INTO " &
                    " basennf (chnfe) " &
                    " VALUES (" & cFuncoes.PersistirTexto(dados.chnfe) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            IncluirnNF = retorno

        End Function
        Public Function IncluirCrediarioPagamento(ByVal dados As dVenda) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " INSERT INTO " &
                    " credpag (usuarioId, clienteId, data, dinheiro, cheque, " &
                             "chequePre, cartaoDebito, cartaoCredito, crediario, crediariopagamento, " &
                             "parcelas, desconto, condicao, recebido, troco, troca, " &
                             "vale, valeEmitido, defeito, retirada, terminal, vendedor, caixa, total, txID,  Original ) " &
                    " VALUES (" &
                            cFuncoes.PersistirTexto(dados.usuarioId) & "," &
                            cFuncoes.PersistirTexto(dados.clienteId) & "," &
                            cFuncoes.PersistirDataHora(dados.Data) & "," &
                            cFuncoes.PersistirDecimal(dados.Dinheiro) & "," &
                            cFuncoes.PersistirDecimal(dados.Cheque) & "," &
                            cFuncoes.PersistirDecimal(dados.ChequePre) & "," &
                            cFuncoes.PersistirDecimal(dados.CartaoDebito) & "," &
                            cFuncoes.PersistirDecimal(dados.CartaoCredito) & "," &
                            cFuncoes.PersistirDecimal(dados.Crediario) & "," &
                            cFuncoes.PersistirDecimal(dados.CrediarioPagamento) & "," &
                            cFuncoes.PersistirInteiro(dados.Parcelas) & "," &
                            cFuncoes.PersistirDecimal(dados.Desconto) & "," &
                            cFuncoes.PersistirInteiro(dados.Condicao) & "," &
                            cFuncoes.PersistirDecimal(dados.Recebido) & "," &
                            cFuncoes.PersistirDecimal(dados.Troco) & "," &
                            cFuncoes.PersistirDecimal(dados.Troca) & "," &
                            cFuncoes.PersistirDecimal(dados.Vale) & "," &
                            cFuncoes.PersistirDecimal(dados.ValeEmitido) & "," &
                            cFuncoes.PersistirDecimal(dados.Defeito) & "," &
                            cFuncoes.PersistirDecimal(dados.Retirada) & "," &
                            cFuncoes.PersistirTexto(dados.Terminal) & "," &
                            cFuncoes.PersistirTexto(dados.Vendedor) & "," &
                            cFuncoes.PersistirTexto(dados.Caixa) & "," &
                            cFuncoes.PersistirDecimal(dados.Total) & "," &
                            cFuncoes.PersistirTexto(dados.TXID) & "," &
                            cFuncoes.PersistirDecimal(dados.Pix) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Vale [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function Alterar(ByVal dados As dVenda) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " UPDATE vendas SET " &
                    " usuarioId = " & cFuncoes.PersistirTexto(dados.usuarioId) & "," &
                    " clienteId = " & cFuncoes.PersistirTexto(dados.clienteId) & "," &
                    " data = " & cFuncoes.PersistirData(dados.Data) & "," &
                    " dinheiro = " & cFuncoes.PersistirDecimal(dados.Dinheiro) & "," &
                    " cheque = " & cFuncoes.PersistirDecimal(dados.Cheque) & "," &
                    " chequepre = " & cFuncoes.PersistirDecimal(dados.ChequePre) & "," &
                    " cartaodebito = " & cFuncoes.PersistirDecimal(dados.CartaoDebito) & "," &
                    " cartaocredito = " & cFuncoes.PersistirDecimal(dados.CartaoCredito) & "," &
                    " crediario = " & cFuncoes.PersistirDecimal(dados.Crediario) & "," &
                    " parcelas = " & cFuncoes.PersistirInteiro(dados.Parcelas) & "," &
                    " desconto = " & cFuncoes.PersistirDecimal(dados.Desconto) & "," &
                    " condicao = " & cFuncoes.PersistirInteiro(dados.Condicao) & "," &
                    " recebido = " & cFuncoes.PersistirDecimal(dados.Recebido) & "," &
                    " troco = " & cFuncoes.PersistirDecimal(dados.Troco) & "," &
                    " troca = " & cFuncoes.PersistirDecimal(dados.Troca) & "," &
                    " vale = " & cFuncoes.PersistirDecimal(dados.Vale) & "," &
                    " defeito = " & cFuncoes.PersistirDecimal(dados.Defeito) & "," &
                    " ordemservico = " & cFuncoes.PersistirTexto(dados.ordemServicoId) & "," &
                    " terminal = " & cFuncoes.PersistirTexto(dados.Terminal) &
                    " total = " & cFuncoes.PersistirDecimal(dados.Total) &
                    " txID = " & cFuncoes.PersistirTexto(dados.TXID) &
                    " WHERE " &
                    " controle = " & dados.controle.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

        Public Function Alterar(ByVal controle As String, ByVal chave As String) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " UPDATE vendas SET " &
                    " chave = " & cFuncoes.PersistirTexto(chave) &
                    " WHERE " &
                    " controle = " & controle.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function
        Public Function AlterarBaseNnf(ByVal dados As dBasennf) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " UPDATE basennf SET " &
                    " chnfe = " & cFuncoes.PersistirTexto(dados.chnfe) &
                    " WHERE " &
                    " seqNFe = " & cFuncoes.PersistirTexto(dados.SeqNFe)

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar basennf [" & Me.ToString() & "] - " & ex.Message)

            End Try

            AlterarBaseNnf = retorno

        End Function

        Public Function Excluir(ByVal dados As dVenda) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM vendas " & _
                    " WHERE controle = " & dados.controle.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function ExcluirVale(ByVal dados As dVenda) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM vales " & _
                    " WHERE controle = " & dados.controle.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Vale [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function ConsultarFechamento(ByVal dados As dVenda) As ColecaoVenda

            Dim retorno As ColecaoVenda
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dVenda
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String


            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " Select controle, usuarioId, clienteId, data, dinheiro, cheque, " &
                             "chequePre, cartaoDebito, cartaoCredito, crediario, vendedor, " &
                             "parcelas, desconto, condicao, recebido, troco, troca, vale, defeito, terminal, total, ordemservico, txID, Original "

                sqlWhere = String.Empty
                sqlFrom = " From vendas "

                '-- data
                sqlWhere = sqlWhere & " data between '" & cFuncoes.FormatarDataUniversal(dados.Data) & "' AND '" & cFuncoes.FormatarDataUniversal(dados.DataFim) & "'"

                '-- terminal
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.Terminal, "terminal")


                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoVenda

                            For Each row In dt.Rows
                                item = New dVenda

                                item.controle = cFuncoes.RetornarInteiro(row("controle"))
                                item.usuarioId = cFuncoes.RetornarInteiro(row("usuarioId"))
                                item.clienteId = cFuncoes.RetornarInteiro(row("clienteId"))
                                item.Vendedor = cFuncoes.RetornarTexto(row("vendedor"))
                                item.Data = cFuncoes.RetornarTexto(row("data"))
                                item.Dinheiro = cFuncoes.RetornarDecimal(row("dinheiro"))
                                item.Cheque = cFuncoes.RetornarDecimal(row("cheque"))
                                item.ChequePre = cFuncoes.RetornarDecimal(row("chequepre"))
                                item.CartaoDebito = cFuncoes.RetornarDecimal(row("cartaodebito"))
                                item.CartaoCredito = cFuncoes.RetornarDecimal(row("cartaocredito"))
                                item.Crediario = cFuncoes.RetornarDecimal(row("crediario"))
                                item.Parcelas = cFuncoes.RetornarInteiro(row("parcelas"))
                                item.Desconto = cFuncoes.RetornarDecimal(row("desconto"))
                                item.Condicao = cFuncoes.RetornarInteiro(row("condicao"))
                                item.Recebido = cFuncoes.RetornarDecimal(row("recebido"))
                                item.Troco = cFuncoes.RetornarDecimal(row("troco"))
                                item.Troca = cFuncoes.RetornarDecimal(row("troca"))
                                item.Vale = cFuncoes.RetornarDecimal(row("vale"))
                                item.Defeito = cFuncoes.RetornarDecimal(row("defeito"))
                                item.Terminal = cFuncoes.RetornarTexto(row("terminal"))
                                item.Total = cFuncoes.RetornarDecimal(row("total"))
                                item.ordemServicoId = cFuncoes.RetornarTexto(row("ordemservico"))
                                item.TXID = cFuncoes.RetornarTexto(row("txID"))
                                item.valorOriginal = cFuncoes.RetornarDecimal(row("Original"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

    End Class

End Namespace
