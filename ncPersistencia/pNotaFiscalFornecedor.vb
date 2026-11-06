Imports ncDados.nsProduto
Imports ncDados.nsNotaFiscalFornecedor
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Namespace nsNotaFiscalFornecedor

    Public Class pNotaFiscalFornecedor

        Public Function Listar() As ColecaoNotaFiscalFornecedor

            Dim retorno As ColecaoNotaFiscalFornecedor
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dNotaFiscalFornecedor
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " Select nff.cid, nff.numero, nff.serie, nff.fornecedor_cid, nff.dataEmissao, nff.dataInclusao, " & _
                    " nff.valorBaseIcms, nff.valorIcms, nff.valorBaseIcmsSubstituicao, nff.valorIcmsSubstituicao, " & _
                    " nff.valorTotalIpi, nff.valorTotalProdutos, nff.valorTotalNota, f.nome as fornecedor_nome, " & _
                    " nff.tipoFluxo_cid, nff.tipoEmissao_cid, nff.tipoNotaFiscal_cid, nff.situacaoNotaFiscal_cid, nff.tipoPagamento_cid, " & _
                    " nff.tipoFrete_cid, nff.chaveNotaFiscalEletronica, nff.dataEntrada, " & _
                    " nff.valorFrete, nff.valorSeguro, nff.valorDesconto, nff.valorOutrasDespesas, nff.valorAbatimento, " & _
                    " nff.valorTotalPis, nff.valorPisRetidoSubstituicao, nff.valorTotalCofins, nff.valorCofinsRetidoSubstituicao " & _
                    " From notafiscalfornecedor nff " & _
                    " Left Outer Join fornecedores f on f.cid = nff.fornecedor_cid "

                ds = acessoBanco.ExecutarDS(comandoSQL)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoNotaFiscalFornecedor

                            For Each row In dt.Rows
                                item = New dNotaFiscalFornecedor

                                item.cid = RetornarInteiro(row("cid"))
                                item.numero = RetornarTexto(row("numero"))
                                item.serie = RetornarTexto(row("serie"))
                                item.fornecedor_cid = RetornarInteiro(row("fornecedor_cid"))
                                item.fornecedorNome = RetornarTexto(row("fornecedor_nome"))
                                item.dataEmissao = RetornarData(row("dataEmissao"))
                                item.dataInclusao = RetornarData(row("dataInclusao"))
                                item.valorBaseIcms = RetornarDecimal(row("valorBaseIcms"))
                                item.valorIcms = RetornarDecimal(row("valorIcms"))
                                item.valorBaseIcmsSubstituicao = RetornarDecimal(row("valorBaseIcmsSubstituicao"))
                                item.valorIcmsSubstituicao = RetornarDecimal(row("valorIcmsSubstituicao"))
                                item.valorTotalIpi = RetornarDecimal(row("valorTotalIpi"))
                                item.valorTotalProdutos = RetornarDecimal(row("valorTotalProdutos"))
                                item.valorTotalNota = RetornarDecimal(row("valorTotalNota"))

                                item.tipoFluxo_cid = RetornarInteiro(row("tipoFluxo_cid"))
                                item.tipoEmissao_cid = RetornarInteiro(row("tipoEmissao_cid"))
                                item.tipoNotaFiscal_cid = RetornarInteiro(row("tipoNotaFiscal_cid"))
                                item.situacaoNotaFiscal_cid = RetornarInteiro(row("situacaoNotaFiscal_cid"))
                                item.tipoPagamento_cid = RetornarInteiro(row("tipoPagamento_cid"))
                                item.tipoFrete_cid = RetornarInteiro(row("tipoFrete_cid"))
                                item.chaveNotaFiscalEletronica = RetornarTexto(row("chaveNotaFiscalEletronica"))
                                item.dataEntrada = RetornarData(row("dataEntrada"))

                                item.valorFrete = RetornarDecimal(row("valorFrete"))
                                item.valorSeguro = RetornarDecimal(row("valorSeguro"))
                                item.valorDesconto = RetornarDecimal(row("valorDesconto"))
                                item.valorOutrasDespesas = RetornarDecimal(row("valorOutrasDespesas"))
                                item.valorAbatimento = RetornarDecimal(row("valorAbatimento"))
                                item.valorTotalPis = RetornarDecimal(row("valorTotalPis"))
                                item.valorPisRetidoSubstituicao = RetornarDecimal(row("valorPisRetidoSubstituicao"))
                                item.valorTotalCofins = RetornarDecimal(row("valorTotalCofins"))
                                item.valorCofinsRetidoSubstituicao = RetornarDecimal(row("valorCofinsRetidoSubstituicao"))

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
                Throw New ExcecaoNascomercio("Erro em Listar NotaFiscalFornecedor [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dNotaFiscalFornecedor) As ColecaoNotaFiscalFornecedor

            Dim retorno As ColecaoNotaFiscalFornecedor
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dNotaFiscalFornecedor
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " Select distinct nff.cid, nff.numero, nff.serie, nff.fornecedor_cid, nff.dataEmissao, nff.dataInclusao, " & _
                    " nff.valorBaseIcms, nff.valorIcms, nff.valorBaseIcmsSubstituicao, nff.valorIcmsSubstituicao, " & _
                    " nff.valorTotalIpi, nff.valorTotalProdutos, nff.valorTotalNota, f.nome as fornecedor_nome, " & _
                    " nff.tipoFluxo_cid, nff.tipoEmissao_cid, nff.tipoNotaFiscal_cid, nff.situacaoNotaFiscal_cid, nff.tipoPagamento_cid, " & _
                    " nff.tipoFrete_cid, nff.chaveNotaFiscalEletronica, nff.dataEntrada, " & _
                    " nff.valorFrete, nff.valorSeguro, nff.valorDesconto, nff.valorOutrasDespesas, nff.valorAbatimento, " & _
                    " nff.valorTotalPis, nff.valorPisRetidoSubstituicao, nff.valorTotalCofins, nff.valorCofinsRetidoSubstituicao "
                sqlWhere = String.Empty
                sqlFrom = " From notafiscalfornecedor nff " & _
                    " Left Outer Join fornecedores f on f.cid = nff.fornecedor_cid " & _
                    " Left Outer Join logestoque l on l.notaFiscalNumero = nff.numero and l.notaFiscalSerie = nff.serie " & _
                    " Left Outer Join produtos p on p.cid  = l.produto_cid "

                '-- cid
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "nff.cid")
                '-- numero
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.numero, "nff.numero")
                '-- serie
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.serie, "nff.serie")
                '-- fornecedor_cid
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.fornecedor_cid, "nff.fornecedor_cid")
                '-- dataEmissao
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataEmissao, "nff.dataEmissao")
                '-- dataInclusao
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataInclusao, "nff.dataInclusao")
                '-- baseCalculoICMS
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorBaseIcms, "nff.valorBaseIcms")
                '-- valorICMS
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorIcms, "nff.valorIcms")
                '-- baseCalculoICMSSubstituicao
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorBaseIcmsSubstituicao, "nff.valorBaseIcmsSubstituicao")
                '-- valorICMSSubstituicao
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorIcmsSubstituicao, "nff.valorIcmsSubstituicao")
                '-- valorTotalIPI
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorTotalIpi, "nff.valorTotalIpi")
                '-- valorTotalProdutos
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorTotalProdutos, "nff.valorTotalProdutos")
                '-- valorTotalNota
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorTotalNota, "nff.valorTotalNota")

                '-- tipoEmissao_cid
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.tipoEmissao_cid, "nff.tipoEmissao_cid")
                '-- tipoFluxo_cid
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.tipoFluxo_cid, "nff.tipoFluxo_cid")
                '-- tipoFrete_cid
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.tipoFrete_cid, "nff.tipoFrete_cid")
                '-- tipoNotaFiscal_cid
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.tipoNotaFiscal_cid, "nff.tipoNotaFiscal_cid")
                '-- tipoPagamento_cid
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.tipoPagamento_cid, "nff.tipoPagamento_cid")
                '-- situacaoNotaFiscal_cid
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.situacaoNotaFiscal_cid, "nff.situacaoNotaFiscal_cid")
                '-- chaveNotaFiscalEletronica
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.chaveNotaFiscalEletronica, "nff.chaveNotaFiscalEletronica")
                '-- dataEntrada
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataEntrada, "nff.dataEntrada")
                '-- valorFrete
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorFrete, "nff.valorFrete")
                '-- valorSeguro
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorSeguro, "nff.valorSeguro")
                '-- valorDesconto
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorDesconto, "nff.valorDesconto")
                '-- valorOutrasDespesas
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorOutrasDespesas, "nff.valorOutrasDespesas")
                '-- valorAbatimento
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorAbatimento, "nff.valorAbatimento")
                '-- valorTotalPis
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorTotalPis, "nff.valorTotalPis")
                '-- valorPisRetidoSubstituicao
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorPisRetidoSubstituicao, "nff.valorPisRetidoSubstituicao")
                '-- valorTotalCofins
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorTotalCofins, "nff.valorTotalCofins")
                '-- valorCofinsRetidoSubstituicao
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorCofinsRetidoSubstituicao, "nff.valorCofinsRetidoSubstituicao")

                '-- fornecedor_cid
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.produtoCodigo, "p.codigo")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoNotaFiscalFornecedor

                            For Each row In dt.Rows
                                item = New dNotaFiscalFornecedor

                                item.cid = RetornarInteiro(row("cid"))
                                item.numero = RetornarTexto(row("numero"))
                                item.serie = RetornarTexto(row("serie"))
                                item.fornecedor_cid = RetornarInteiro(row("fornecedor_cid"))
                                item.fornecedorNome = RetornarTexto(row("fornecedor_nome"))
                                item.dataEmissao = RetornarData(row("dataEmissao"))
                                item.dataInclusao = RetornarData(row("dataInclusao"))
                                item.valorBaseIcms = RetornarDecimal(row("valorBaseIcms"))
                                item.valorIcms = RetornarDecimal(row("valorIcms"))
                                item.valorBaseIcmsSubstituicao = RetornarDecimal(row("valorBaseIcmsSubstituicao"))
                                item.valorIcmsSubstituicao = RetornarDecimal(row("valorIcmsSubstituicao"))
                                item.valorTotalIpi = RetornarDecimal(row("valorTotalIpi"))
                                item.valorTotalProdutos = RetornarDecimal(row("valorTotalProdutos"))
                                item.valorTotalNota = RetornarDecimal(row("valorTotalNota"))

                                item.tipoFluxo_cid = RetornarInteiro(row("tipoFluxo_cid"))
                                item.tipoEmissao_cid = RetornarInteiro(row("tipoEmissao_cid"))
                                item.tipoNotaFiscal_cid = RetornarInteiro(row("tipoNotaFiscal_cid"))
                                item.situacaoNotaFiscal_cid = RetornarInteiro(row("situacaoNotaFiscal_cid"))
                                item.tipoPagamento_cid = RetornarInteiro(row("tipoPagamento_cid"))
                                item.tipoFrete_cid = RetornarInteiro(row("tipoFrete_cid"))
                                item.chaveNotaFiscalEletronica = RetornarTexto(row("chaveNotaFiscalEletronica"))
                                item.dataEntrada = RetornarData(row("dataEntrada"))

                                item.valorFrete = RetornarDecimal(row("valorFrete"))
                                item.valorSeguro = RetornarDecimal(row("valorSeguro"))
                                item.valorDesconto = RetornarDecimal(row("valorDesconto"))
                                item.valorOutrasDespesas = RetornarDecimal(row("valorOutrasDespesas"))
                                item.valorAbatimento = RetornarDecimal(row("valorAbatimento"))
                                item.valorTotalPis = RetornarDecimal(row("valorTotalPis"))
                                item.valorPisRetidoSubstituicao = RetornarDecimal(row("valorPisRetidoSubstituicao"))
                                item.valorTotalCofins = RetornarDecimal(row("valorTotalCofins"))
                                item.valorCofinsRetidoSubstituicao = RetornarDecimal(row("valorCofinsRetidoSubstituicao"))

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
                Throw New ExcecaoNascomercio("Erro ao Consultar NotaFiscalFornecedor [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Consultar = retorno

        End Function

        Public Function ConsultarItemNota(ByVal notaFiscal As String, ByVal serie As String) As ColecaoNotaFiscalItem

            Dim retorno As ColecaoNotaFiscalItem
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dNotaFiscalItem
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " select p.cid as 'produtos_cid', p.descricao as 'descricao', p.referencia as 'referencia', p.valorcompra as 'valorcompra', " & _
                    " pi.valor as 'valor', pi.item as 'item', pi2.quantidade as 'estoque' "
                sqlWhere = " c.codigo = 'codigoBarras' "
                sqlFrom = " from produtos p " & _
                    " inner join produtoitem pi on pi.produtos_cid = p.cid " & _
                    " inner join caracteristicas c on c.cid = pi.caracteristicas_cid " & _
                    " inner join logestoque pi2 on pi2.produto_cid = p.cid and pi.valor =  produtoItem_codigoBarras "

                '-- produtoItem - NF
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, notaFiscal, "notaFiscalNumero")
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, serie, "notaFiscalSerie")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " order by p.descricao, p.referencia, pi.valor")

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoNotaFiscalItem

                            For Each row In dt.Rows
                                item = New dNotaFiscalItem

                                item.produtos_descricao = cFuncoes.RetornarTexto(row("descricao"))
                                item.produtos_estoque = cFuncoes.RetornarTexto(row("estoque"))
                                item.produtos_cid = cFuncoes.RetornarTexto(row("produtos_cid"))
                                item.item = cFuncoes.RetornarTexto(row("item"))
                                item.Produtos_Valor = cFuncoes.RetornarDecimal(row("ValorCompra"))
                                item.Produtos_Referencia = cFuncoes.RetornarTexto(row("Referencia"))
                                item.caracteristicas_codigo = cFuncoes.RetornarTexto(row("valor"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar ProdutoItem [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function Incluir(ByVal dados As dNotaFiscalFornecedor) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " INSERT INTO " & _
                    " notafiscalfornecedor ( numero, serie, fornecedor_cid, dataEmissao, dataInclusao, " & _
                    " valorBaseIcms, valorIcms, valorBaseIcmsSubstituicao, valorIcmsSubstituicao, " & _
                    " valorTotalIpi, valorTotalProdutos, valorTotalNota, " & _
                    " tipoFluxo_cid, tipoEmissao_cid, tipoNotaFiscal_cid, situacaoNotaFiscal_cid, tipoPagamento_cid, " & _
                    " tipoFrete_cid, chaveNotaFiscalEletronica, dataEntrada, " & _
                    " valorFrete, valorSeguro, valorDesconto, valorOutrasDespesas, valorAbatimento, " & _
                    " valorTotalPis, valorPisRetidoSubstituicao, valorTotalCofins, valorCofinsRetidoSubstituicao ) " & _
                    " VALUES (" & _
                    PersistirTexto(dados.numero) & "," & _
                    PersistirTexto(dados.serie) & "," & _
                    PersistirInteiro(dados.fornecedor_cid) & "," & _
                    PersistirData(dados.dataEmissao) & "," & _
                    PersistirData(dados.dataInclusao.Value) & "," & _
                    PersistirDecimal(dados.valorBaseIcms) & "," & _
                    PersistirDecimal(dados.valorIcms) & "," & _
                    PersistirDecimal(dados.valorBaseIcmsSubstituicao) & "," & _
                    PersistirDecimal(dados.valorIcmsSubstituicao) & "," & _
                    PersistirDecimal(dados.valorTotalIpi) & "," & _
                    PersistirDecimal(dados.valorTotalProdutos) & "," & _
                    PersistirDecimal(dados.valorTotalNota) & "," & _
                    PersistirInteiro(dados.tipoFluxo_cid) & "," & _
                    PersistirInteiro(dados.tipoEmissao_cid) & "," & _
                    PersistirInteiro(dados.tipoNotaFiscal_cid) & "," & _
                    PersistirInteiro(dados.situacaoNotaFiscal_cid) & "," & _
                    PersistirInteiro(dados.tipoPagamento_cid) & "," & _
                    PersistirInteiro(dados.tipoFrete_cid) & "," & _
                    PersistirTexto(dados.chaveNotaFiscalEletronica) & "," & _
                    PersistirData(dados.dataEntrada) & "," & _
                    PersistirDecimal(dados.valorFrete) & "," & _
                    PersistirDecimal(dados.valorSeguro) & "," & _
                    PersistirDecimal(dados.valorDesconto) & "," & _
                    PersistirDecimal(dados.valorOutrasDespesas) & "," & _
                    PersistirDecimal(dados.valorAbatimento) & "," & _
                    PersistirDecimal(dados.valorTotalPis) & "," & _
                    PersistirDecimal(dados.valorPisRetidoSubstituicao) & "," & _
                    PersistirDecimal(dados.valorTotalCofins) & "," & _
                    PersistirDecimal(dados.valorCofinsRetidoSubstituicao) & ")"

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir NotaFiscalFornecedor [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dNotaFiscalFornecedor) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " UPDATE notafiscalfornecedor SET " & _
                    " fornecedor_cid = " & PersistirInteiro(dados.fornecedor_cid) & "," & _
                    " dataEmissao = " & PersistirData(dados.dataEmissao) & "," & _
                    " dataInclusao = " & PersistirData(dados.dataInclusao.Value) & "," & _
                    " valorBaseIcms = " & PersistirDecimal(dados.valorBaseIcms) & "," & _
                    " valorIcms = " & PersistirDecimal(dados.valorIcms) & "," & _
                    " valorBaseIcmsSubstituicao = " & PersistirDecimal(dados.valorBaseIcmsSubstituicao) & "," & _
                    " valorIcmsSubstituicao = " & PersistirDecimal(dados.valorIcmsSubstituicao) & "," & _
                    " valorTotalIpi = " & PersistirDecimal(dados.valorTotalIpi) & "," & _
                    " valorTotalProdutos = " & PersistirDecimal(dados.valorTotalProdutos) & "," & _
                    " valorTotalNota = " & PersistirDecimal(dados.valorTotalNota) & "," & _
                    " tipoFluxo_cid = " & PersistirInteiro(dados.tipoFluxo_cid) & "," & _
                    " tipoEmissao_cid = " & PersistirInteiro(dados.tipoEmissao_cid) & "," & _
                    " tipoNotaFiscal_cid = " & PersistirInteiro(dados.tipoNotaFiscal_cid) & "," & _
                    " situacaoNotaFiscal_cid = " & PersistirInteiro(dados.situacaoNotaFiscal_cid) & "," & _
                    " tipoPagamento_cid = " & PersistirInteiro(dados.tipoPagamento_cid) & "," & _
                    " tipoFrete_cid = " & PersistirInteiro(dados.tipoFrete_cid) & "," & _
                    " chaveNotaFiscalEletronica = " & PersistirTexto(dados.chaveNotaFiscalEletronica) & "," & _
                    " dataEntrada = " & PersistirData(dados.dataEntrada) & "," & _
                    " valorFrete = " & PersistirDecimal(dados.valorFrete) & "," & _
                    " valorSeguro = " & PersistirDecimal(dados.valorSeguro) & "," & _
                    " valorDesconto = " & PersistirDecimal(dados.valorDesconto) & "," & _
                    " valorOutrasDespesas = " & PersistirDecimal(dados.valorOutrasDespesas) & "," & _
                    " valorAbatimento = " & PersistirDecimal(dados.valorAbatimento) & "," & _
                    " valorTotalPis = " & PersistirDecimal(dados.valorTotalPis) & "," & _
                    " valorPisRetidoSubstituicao = " & PersistirDecimal(dados.valorPisRetidoSubstituicao) & "," & _
                    " valorTotalCofins = " & PersistirDecimal(dados.valorTotalCofins) & "," & _
                    " valorCofinsRetidoSubstituicao = " & PersistirDecimal(dados.valorCofinsRetidoSubstituicao) & _
                    " WHERE " & _
                    " numero = " & PersistirTexto(dados.numero) & " AND " & _
                    " serie = " & PersistirTexto(dados.serie)

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar NotaFiscalFornecedor [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dNotaFiscalFornecedor) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM notafiscalfornecedor " & _
                    " WHERE " & _
                    " numero = " & PersistirTexto(dados.numero) & " AND " & _
                    " serie = " & PersistirTexto(dados.serie)

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir NotaFiscalFornecedor [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Excluir = retorno

        End Function

    End Class

End Namespace