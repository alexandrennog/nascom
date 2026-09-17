Imports ncDados.nsDashboardCompras
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsDashboardCompras

    Public Class pDashboardCompras

        Public Function ConsultarResumo(ByVal dataIni As String, ByVal dataFim As String) As dDashboardResumo

            Dim retorno As dDashboardResumo
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                ' dataIni/dataFim chegam no formato ddMMyyyy (cFuncoes.FormatarData a
                ' partir do texto "dd/MM/yyyy" da tela). DataSqlSegura converte direto
                ' para um literal SQL seguro - ver comentario na propria funcao, no fim
                ' deste arquivo, sobre por que cFuncoes.PersistirData nao serve aqui.
                comandoSQL = "CALL sp_dashboard_compras_resumo(" &
                    DataSqlSegura(dataIni) & ", " &
                    DataSqlSegura(dataFim) & ")"

                ds = acessoBanco.ExecutarDSLongo(comandoSQL, 300)

                retorno = Nothing

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            row = dt.Rows(0)

                            retorno = New dDashboardResumo
                            retorno.periodoInicio = cFuncoes.RetornarTexto(row("periodo_inicio"))
                            retorno.periodoFim = cFuncoes.RetornarTexto(row("periodo_fim"))
                            retorno.qtdVendas = cFuncoes.RetornarInteiro(row("qtd_vendas")).GetValueOrDefault()
                            retorno.faturamentoTotal = cFuncoes.RetornarDecimal(row("faturamento_total")).GetValueOrDefault()
                            retorno.ticketMedio = cFuncoes.RetornarDecimal(row("ticket_medio")).GetValueOrDefault()
                            retorno.marcaCampeaValor = cFuncoes.RetornarTexto(row("marca_campea_valor"))
                            retorno.marcaCampeaValorTotal = cFuncoes.RetornarDecimal(row("marca_campea_valor_total")).GetValueOrDefault()
                            retorno.marcaCampeaQuantidade = cFuncoes.RetornarTexto(row("marca_campea_quantidade"))
                            retorno.marcaCampeaQuantidadeTotal = cFuncoes.RetornarDecimal(row("marca_campea_quantidade_total")).GetValueOrDefault()
                        End If
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em ConsultarResumo DashboardCompras [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            ConsultarResumo = retorno

        End Function

        Public Function ListarReposicao(ByVal dataIni As String, ByVal dataFim As String) As ColecaoDashboardReposicao

            Dim retorno As ColecaoDashboardReposicao
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dDashboardReposicaoItem
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = "CALL sp_dashboard_compras_reposicao(" &
                    DataSqlSegura(dataIni) & ", " &
                    DataSqlSegura(dataFim) & ")"

                ds = acessoBanco.ExecutarDSLongo(comandoSQL, 300)

                retorno = Nothing

                ' sp_dashboard_compras_reposicao faz "CALL sp_curva_abc(...)" por dentro,
                ' e sp_curva_abc termina com um SELECT proprio (linha final do script 33).
                ' O MySQL devolve esse SELECT interno como um resultset A PARTE, antes do
                ' resultset final de sp_dashboard_compras_reposicao - entao ds.Tables(0)
                ' aqui seria o resultado BRUTO da Curva ABC (sem a coluna
                ' "quantidade_vendida", por exemplo), nao a lista de reposicao filtrada.
                ' O resultset certo e sempre o ULTIMO devolvido, nao o primeiro.
                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(ds.Tables.Count - 1)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoDashboardReposicao

                            For Each row In dt.Rows
                                item = New dDashboardReposicaoItem
                                item.referencia = cFuncoes.RetornarTexto(row("referencia"))
                                item.descricao = cFuncoes.RetornarTexto(row("descricao"))
                                item.fabricante = cFuncoes.RetornarTexto(row("fabricante"))
                                item.quantidadeVendida = cFuncoes.RetornarDecimal(row("quantidade_vendida")).GetValueOrDefault()
                                item.estoqueAtual = cFuncoes.RetornarDecimal(row("estoque_atual")).GetValueOrDefault()
                                item.classeAbc = cFuncoes.RetornarTexto(row("classe_abc"))

                                retorno.Add(item)
                            Next
                        End If
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em ListarReposicao DashboardCompras [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            ListarReposicao = retorno

        End Function

        ' Converte uma data no formato ddMMyyyy (8 digitos, sem separador - o que
        ' cFuncoes.FormatarData devolve a partir de um texto "dd/MM/yyyy") direto para
        ' um literal SQL seguro ('yyyy-MM-dd'), ou NULL se vier vazia/invalida.
        '
        ' Por que nao usar cFuncoes.PersistirData: ela foi feita para receber o texto
        ' CRU da tela (com "/"), nao o resultado ja processado por FormatarData.
        ' Encadear FormatarData -> PersistirData (que seria o padrao "esperado" olhando
        ' o resto do sistema) devolve "NULL" silenciosamente, porque FormatarData muda
        ' o formato de saida dependendo se recebe entrada com "/" ou sem: com "/" ela
        ' devolve ddMMyyyy (sem separador); sem "/" ela devolve yyyy-MM-dd (com
        ' separador). PersistirData reaplica FormatarData internamente esperando
        ' sempre voltar ddMMyyyy - quando quem chamou ja tinha convertido antes (nosso
        ' caso), ela recebe yyyy-MM-dd de volta e monta uma data invalida.
        ' ParseExact aqui so aceita exatamente ddMMyyyy - qualquer outra coisa vira
        ' NULL, o que tambem fecha qualquer brecha de SQL injection por essa via.
        Private Function DataSqlSegura(ByVal dataDDMMAAAA As String) As String

            Dim dataConvertida As DateTime

            If String.IsNullOrWhiteSpace(dataDDMMAAAA) OrElse dataDDMMAAAA.Length <> 8 Then
                Return "NULL"
            End If

            If DateTime.TryParseExact(dataDDMMAAAA, "ddMMyyyy",
                                       System.Globalization.CultureInfo.InvariantCulture,
                                       System.Globalization.DateTimeStyles.None,
                                       dataConvertida) Then
                Return "'" & dataConvertida.ToString("yyyy-MM-dd") & "'"
            End If

            Return "NULL"

        End Function

    End Class

End Namespace
