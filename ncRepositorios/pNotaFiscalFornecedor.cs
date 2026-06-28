using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum;
using ncModelos;

namespace ncRepositorios
{
    public class pNotaFiscalFornecedor : RepositorioBase, IpNotaFiscalFornecedor
    {
        private const string SelectNff = @"SELECT nff.cid, nff.numero, nff.serie, nff.fornecedor_cid, nff.dataEmissao, nff.dataInclusao,
            nff.valorBaseIcms, nff.valorIcms, nff.valorBaseIcmsSubstituicao, nff.valorIcmsSubstituicao,
            nff.valorTotalIpi, nff.valorTotalProdutos, nff.valorTotalNota, f.nome AS fornecedorNome,
            nff.tipoFluxo_cid, nff.tipoEmissao_cid, nff.tipoNotaFiscal_cid, nff.situacaoNotaFiscal_cid, nff.tipoPagamento_cid,
            nff.tipoFrete_cid, nff.chaveNotaFiscalEletronica, nff.dataEntrada,
            nff.valorFrete, nff.valorSeguro, nff.valorDesconto, nff.valorOutrasDespesas, nff.valorAbatimento,
            nff.valorTotalPis, nff.valorPisRetidoSubstituicao, nff.valorTotalCofins, nff.valorCofinsRetidoSubstituicao";

        public ColecaoNotaFiscalFornecedor Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dNotaFiscalFornecedor>(
                        SelectNff + " FROM notafiscalfornecedor nff LEFT OUTER JOIN fornecedores f ON f.cid = nff.fornecedor_cid").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoNotaFiscalFornecedor();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoNotaFiscalFornecedor Consultar(dNotaFiscalFornecedor dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != 0) { conditions.Add("nff.cid=@cid"); p.Add("cid", dados.cid); }
                    if (!string.IsNullOrEmpty(dados.numero)) { conditions.Add("nff.numero=@numero"); p.Add("numero", dados.numero); }
                    if (!string.IsNullOrEmpty(dados.serie)) { conditions.Add("nff.serie=@serie"); p.Add("serie", dados.serie); }
                    if (dados.fornecedor_cid != 0) { conditions.Add("nff.fornecedor_cid=@fornecedor_cid"); p.Add("fornecedor_cid", dados.fornecedor_cid); }
                    if (dados.dataEmissao != null) { conditions.Add("nff.dataEmissao=@dataEmissao"); p.Add("dataEmissao", dados.dataEmissao); }
                    if (dados.dataInclusao != null) { conditions.Add("nff.dataInclusao=@dataInclusao"); p.Add("dataInclusao", dados.dataInclusao); }
                    if (dados.valorBaseIcms != 0) { conditions.Add("nff.valorBaseIcms=@valorBaseIcms"); p.Add("valorBaseIcms", dados.valorBaseIcms); }
                    if (dados.valorIcms != 0) { conditions.Add("nff.valorIcms=@valorIcms"); p.Add("valorIcms", dados.valorIcms); }
                    if (dados.valorBaseIcmsSubstituicao != 0) { conditions.Add("nff.valorBaseIcmsSubstituicao=@valorBaseIcmsSubstituicao"); p.Add("valorBaseIcmsSubstituicao", dados.valorBaseIcmsSubstituicao); }
                    if (dados.valorIcmsSubstituicao != 0) { conditions.Add("nff.valorIcmsSubstituicao=@valorIcmsSubstituicao"); p.Add("valorIcmsSubstituicao", dados.valorIcmsSubstituicao); }
                    if (dados.valorTotalIpi != 0) { conditions.Add("nff.valorTotalIpi=@valorTotalIpi"); p.Add("valorTotalIpi", dados.valorTotalIpi); }
                    if (dados.valorTotalProdutos != 0) { conditions.Add("nff.valorTotalProdutos=@valorTotalProdutos"); p.Add("valorTotalProdutos", dados.valorTotalProdutos); }
                    if (dados.valorTotalNota != 0) { conditions.Add("nff.valorTotalNota=@valorTotalNota"); p.Add("valorTotalNota", dados.valorTotalNota); }
                    if (dados.tipoEmissao_cid != 0) { conditions.Add("nff.tipoEmissao_cid=@tipoEmissao_cid"); p.Add("tipoEmissao_cid", dados.tipoEmissao_cid); }
                    if (dados.tipoFluxo_cid != 0) { conditions.Add("nff.tipoFluxo_cid=@tipoFluxo_cid"); p.Add("tipoFluxo_cid", dados.tipoFluxo_cid); }
                    if (dados.tipoFrete_cid != 0) { conditions.Add("nff.tipoFrete_cid=@tipoFrete_cid"); p.Add("tipoFrete_cid", dados.tipoFrete_cid); }
                    if (dados.tipoNotaFiscal_cid != 0) { conditions.Add("nff.tipoNotaFiscal_cid=@tipoNotaFiscal_cid"); p.Add("tipoNotaFiscal_cid", dados.tipoNotaFiscal_cid); }
                    if (dados.tipoPagamento_cid != 0) { conditions.Add("nff.tipoPagamento_cid=@tipoPagamento_cid"); p.Add("tipoPagamento_cid", dados.tipoPagamento_cid); }
                    if (dados.situacaoNotaFiscal_cid != 0) { conditions.Add("nff.situacaoNotaFiscal_cid=@situacaoNotaFiscal_cid"); p.Add("situacaoNotaFiscal_cid", dados.situacaoNotaFiscal_cid); }
                    if (!string.IsNullOrEmpty(dados.chaveNotaFiscalEletronica)) { conditions.Add("nff.chaveNotaFiscalEletronica=@chaveNotaFiscalEletronica"); p.Add("chaveNotaFiscalEletronica", dados.chaveNotaFiscalEletronica); }
                    if (dados.dataEntrada != null) { conditions.Add("nff.dataEntrada=@dataEntrada"); p.Add("dataEntrada", dados.dataEntrada); }
                    if (dados.valorFrete != 0) { conditions.Add("nff.valorFrete=@valorFrete"); p.Add("valorFrete", dados.valorFrete); }
                    if (dados.valorSeguro != 0) { conditions.Add("nff.valorSeguro=@valorSeguro"); p.Add("valorSeguro", dados.valorSeguro); }
                    if (dados.valorDesconto != 0) { conditions.Add("nff.valorDesconto=@valorDesconto"); p.Add("valorDesconto", dados.valorDesconto); }
                    if (dados.valorOutrasDespesas != 0) { conditions.Add("nff.valorOutrasDespesas=@valorOutrasDespesas"); p.Add("valorOutrasDespesas", dados.valorOutrasDespesas); }
                    if (dados.valorAbatimento != 0) { conditions.Add("nff.valorAbatimento=@valorAbatimento"); p.Add("valorAbatimento", dados.valorAbatimento); }
                    if (dados.valorTotalPis != 0) { conditions.Add("nff.valorTotalPis=@valorTotalPis"); p.Add("valorTotalPis", dados.valorTotalPis); }
                    if (dados.valorPisRetidoSubstituicao != 0) { conditions.Add("nff.valorPisRetidoSubstituicao=@valorPisRetidoSubstituicao"); p.Add("valorPisRetidoSubstituicao", dados.valorPisRetidoSubstituicao); }
                    if (dados.valorTotalCofins != 0) { conditions.Add("nff.valorTotalCofins=@valorTotalCofins"); p.Add("valorTotalCofins", dados.valorTotalCofins); }
                    if (dados.valorCofinsRetidoSubstituicao != 0) { conditions.Add("nff.valorCofinsRetidoSubstituicao=@valorCofinsRetidoSubstituicao"); p.Add("valorCofinsRetidoSubstituicao", dados.valorCofinsRetidoSubstituicao); }
                    if (!string.IsNullOrEmpty(dados.produtoCodigo)) { conditions.Add("p.codigo=@produtoCodigo"); p.Add("produtoCodigo", dados.produtoCodigo); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $@"SELECT DISTINCT {SelectNff.Substring(SelectNff.IndexOf("nff.cid"))}
                        FROM notafiscalfornecedor nff
                        LEFT OUTER JOIN fornecedores f ON f.cid = nff.fornecedor_cid
                        LEFT OUTER JOIN logestoque l ON l.notaFiscalNumero = nff.numero AND l.notaFiscalSerie = nff.serie
                        LEFT OUTER JOIN produtos p ON p.cid = l.produto_cid
                        {where}";
                    var lista = conn.Query<dNotaFiscalFornecedor>(SelectNff + $@"
                        FROM notafiscalfornecedor nff
                        LEFT OUTER JOIN fornecedores f ON f.cid = nff.fornecedor_cid
                        LEFT OUTER JOIN logestoque l ON l.notaFiscalNumero = nff.numero AND l.notaFiscalSerie = nff.serie
                        LEFT OUTER JOIN produtos p ON p.cid = l.produto_cid
                        {where}", p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoNotaFiscalFornecedor();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro ao Consultar NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoNotaFiscalItem ConsultarItemNota(string notaFiscal, string serie)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var p = new DynamicParameters();
                    p.Add("notaFiscal", notaFiscal);
                    p.Add("serie", serie);
                    var sql = @"SELECT p.cid AS produtos_cid, p.descricao AS produtos_descricao, p.referencia AS Produtos_Referencia, p.valorcompra AS Produtos_Valor,
                        pi.valor AS caracteristicas_codigo, pi.item, pi2.quantidade AS produtos_estoque
                        FROM produtos p
                        INNER JOIN produtoitem pi ON pi.produtos_cid = p.cid
                        INNER JOIN caracteristicas c ON c.cid = pi.caracteristicas_cid
                        INNER JOIN logestoque pi2 ON pi2.produto_cid = p.cid AND pi.valor = produtoItem_codigoBarras
                        WHERE c.codigo = 'codigoBarras' AND notaFiscalNumero=@notaFiscal AND notaFiscalSerie=@serie
                        ORDER BY p.descricao, p.referencia, pi.valor";
                    var lista = conn.Query<dNotaFiscalItem>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoNotaFiscalItem();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dNotaFiscalFornecedor dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute(@"INSERT INTO notafiscalfornecedor (numero, serie, fornecedor_cid, dataEmissao, dataInclusao,
                        valorBaseIcms, valorIcms, valorBaseIcmsSubstituicao, valorIcmsSubstituicao,
                        valorTotalIpi, valorTotalProdutos, valorTotalNota,
                        tipoFluxo_cid, tipoEmissao_cid, tipoNotaFiscal_cid, situacaoNotaFiscal_cid, tipoPagamento_cid,
                        tipoFrete_cid, chaveNotaFiscalEletronica, dataEntrada,
                        valorFrete, valorSeguro, valorDesconto, valorOutrasDespesas, valorAbatimento,
                        valorTotalPis, valorPisRetidoSubstituicao, valorTotalCofins, valorCofinsRetidoSubstituicao)
                        VALUES (@numero, @serie, @fornecedor_cid, @dataEmissao, @dataInclusao,
                        @valorBaseIcms, @valorIcms, @valorBaseIcmsSubstituicao, @valorIcmsSubstituicao,
                        @valorTotalIpi, @valorTotalProdutos, @valorTotalNota,
                        @tipoFluxo_cid, @tipoEmissao_cid, @tipoNotaFiscal_cid, @situacaoNotaFiscal_cid, @tipoPagamento_cid,
                        @tipoFrete_cid, @chaveNotaFiscalEletronica, @dataEntrada,
                        @valorFrete, @valorSeguro, @valorDesconto, @valorOutrasDespesas, @valorAbatimento,
                        @valorTotalPis, @valorPisRetidoSubstituicao, @valorTotalCofins, @valorCofinsRetidoSubstituicao)",
                        new { dados.numero, dados.serie, dados.fornecedor_cid, dados.dataEmissao, dataInclusao = dados.dataInclusao.Value,
                            dados.valorBaseIcms, dados.valorIcms, dados.valorBaseIcmsSubstituicao, dados.valorIcmsSubstituicao,
                            dados.valorTotalIpi, dados.valorTotalProdutos, dados.valorTotalNota,
                            dados.tipoFluxo_cid, dados.tipoEmissao_cid, dados.tipoNotaFiscal_cid, dados.situacaoNotaFiscal_cid, dados.tipoPagamento_cid,
                            dados.tipoFrete_cid, dados.chaveNotaFiscalEletronica, dados.dataEntrada,
                            dados.valorFrete, dados.valorSeguro, dados.valorDesconto, dados.valorOutrasDespesas, dados.valorAbatimento,
                            dados.valorTotalPis, dados.valorPisRetidoSubstituicao, dados.valorTotalCofins, dados.valorCofinsRetidoSubstituicao });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dNotaFiscalFornecedor dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute(@"UPDATE notafiscalfornecedor SET
                        fornecedor_cid=@fornecedor_cid, dataEmissao=@dataEmissao, dataInclusao=@dataInclusao,
                        valorBaseIcms=@valorBaseIcms, valorIcms=@valorIcms, valorBaseIcmsSubstituicao=@valorBaseIcmsSubstituicao, valorIcmsSubstituicao=@valorIcmsSubstituicao,
                        valorTotalIpi=@valorTotalIpi, valorTotalProdutos=@valorTotalProdutos, valorTotalNota=@valorTotalNota,
                        tipoFluxo_cid=@tipoFluxo_cid, tipoEmissao_cid=@tipoEmissao_cid, tipoNotaFiscal_cid=@tipoNotaFiscal_cid,
                        situacaoNotaFiscal_cid=@situacaoNotaFiscal_cid, tipoPagamento_cid=@tipoPagamento_cid, tipoFrete_cid=@tipoFrete_cid,
                        chaveNotaFiscalEletronica=@chaveNotaFiscalEletronica, dataEntrada=@dataEntrada,
                        valorFrete=@valorFrete, valorSeguro=@valorSeguro, valorDesconto=@valorDesconto, valorOutrasDespesas=@valorOutrasDespesas,
                        valorAbatimento=@valorAbatimento, valorTotalPis=@valorTotalPis, valorPisRetidoSubstituicao=@valorPisRetidoSubstituicao,
                        valorTotalCofins=@valorTotalCofins, valorCofinsRetidoSubstituicao=@valorCofinsRetidoSubstituicao
                        WHERE numero=@numero AND serie=@serie",
                        new { dados.fornecedor_cid, dados.dataEmissao, dataInclusao = dados.dataInclusao.Value,
                            dados.valorBaseIcms, dados.valorIcms, dados.valorBaseIcmsSubstituicao, dados.valorIcmsSubstituicao,
                            dados.valorTotalIpi, dados.valorTotalProdutos, dados.valorTotalNota,
                            dados.tipoFluxo_cid, dados.tipoEmissao_cid, dados.tipoNotaFiscal_cid, dados.situacaoNotaFiscal_cid, dados.tipoPagamento_cid, dados.tipoFrete_cid,
                            dados.chaveNotaFiscalEletronica, dados.dataEntrada,
                            dados.valorFrete, dados.valorSeguro, dados.valorDesconto, dados.valorOutrasDespesas, dados.valorAbatimento,
                            dados.valorTotalPis, dados.valorPisRetidoSubstituicao, dados.valorTotalCofins, dados.valorCofinsRetidoSubstituicao,
                            dados.numero, dados.serie });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dNotaFiscalFornecedor dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM notafiscalfornecedor WHERE numero=@numero AND serie=@serie",
                        new { dados.numero, dados.serie });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
