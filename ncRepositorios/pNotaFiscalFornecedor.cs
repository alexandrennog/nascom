using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsProduto;
using nsNotaFiscalFornecedor;

namespace ncPersistencia.nsNotaFiscalFornecedor
{
    public class pNotaFiscalFornecedor
    {
        public ColecaoNotaFiscalFornecedor Listar()
        {
            ColecaoNotaFiscalFornecedor retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select nff.cid, nff.numero, nff.serie, nff.fornecedor_cid, nff.dataEmissao, nff.dataInclusao, " +
                    " nff.valorBaseIcms, nff.valorIcms, nff.valorBaseIcmsSubstituicao, nff.valorIcmsSubstituicao, " +
                    " nff.valorTotalIpi, nff.valorTotalProdutos, nff.valorTotalNota, f.nome as fornecedor_nome, " +
                    " nff.tipoFluxo_cid, nff.tipoEmissao_cid, nff.tipoNotaFiscal_cid, nff.situacaoNotaFiscal_cid, nff.tipoPagamento_cid, " +
                    " nff.tipoFrete_cid, nff.chaveNotaFiscalEletronica, nff.dataEntrada, " +
                    " nff.valorFrete, nff.valorSeguro, nff.valorDesconto, nff.valorOutrasDespesas, nff.valorAbatimento, " +
                    " nff.valorTotalPis, nff.valorPisRetidoSubstituicao, nff.valorTotalCofins, nff.valorCofinsRetidoSubstituicao " +
                    " From notafiscalfornecedor nff " +
                    " Left Outer Join fornecedores f on f.cid = nff.fornecedor_cid ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoNotaFiscalFornecedor();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dNotaFiscalFornecedor();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.numero = RetornarTexto(row["numero"]);
                            item.serie = RetornarTexto(row["serie"]);
                            item.fornecedor_cid = RetornarInteiro(row["fornecedor_cid"]);
                            item.fornecedorNome = RetornarTexto(row["fornecedor_nome"]);
                            item.dataEmissao = RetornarData(row["dataEmissao"]);
                            item.dataInclusao = RetornarData(row["dataInclusao"]);
                            item.valorBaseIcms = RetornarDecimal(row["valorBaseIcms"]);
                            item.valorIcms = RetornarDecimal(row["valorIcms"]);
                            item.valorBaseIcmsSubstituicao = RetornarDecimal(row["valorBaseIcmsSubstituicao"]);
                            item.valorIcmsSubstituicao = RetornarDecimal(row["valorIcmsSubstituicao"]);
                            item.valorTotalIpi = RetornarDecimal(row["valorTotalIpi"]);
                            item.valorTotalProdutos = RetornarDecimal(row["valorTotalProdutos"]);
                            item.valorTotalNota = RetornarDecimal(row["valorTotalNota"]);
                            item.tipoFluxo_cid = RetornarInteiro(row["tipoFluxo_cid"]);
                            item.tipoEmissao_cid = RetornarInteiro(row["tipoEmissao_cid"]);
                            item.tipoNotaFiscal_cid = RetornarInteiro(row["tipoNotaFiscal_cid"]);
                            item.situacaoNotaFiscal_cid = RetornarInteiro(row["situacaoNotaFiscal_cid"]);
                            item.tipoPagamento_cid = RetornarInteiro(row["tipoPagamento_cid"]);
                            item.tipoFrete_cid = RetornarInteiro(row["tipoFrete_cid"]);
                            item.chaveNotaFiscalEletronica = RetornarTexto(row["chaveNotaFiscalEletronica"]);
                            item.dataEntrada = RetornarData(row["dataEntrada"]);
                            item.valorFrete = RetornarDecimal(row["valorFrete"]);
                            item.valorSeguro = RetornarDecimal(row["valorSeguro"]);
                            item.valorDesconto = RetornarDecimal(row["valorDesconto"]);
                            item.valorOutrasDespesas = RetornarDecimal(row["valorOutrasDespesas"]);
                            item.valorAbatimento = RetornarDecimal(row["valorAbatimento"]);
                            item.valorTotalPis = RetornarDecimal(row["valorTotalPis"]);
                            item.valorPisRetidoSubstituicao = RetornarDecimal(row["valorPisRetidoSubstituicao"]);
                            item.valorTotalCofins = RetornarDecimal(row["valorTotalCofins"]);
                            item.valorCofinsRetidoSubstituicao = RetornarDecimal(row["valorCofinsRetidoSubstituicao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoNotaFiscalFornecedor Consultar(dNotaFiscalFornecedor dados)
        {
            ColecaoNotaFiscalFornecedor retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select distinct nff.cid, nff.numero, nff.serie, nff.fornecedor_cid, nff.dataEmissao, nff.dataInclusao, " +
                    " nff.valorBaseIcms, nff.valorIcms, nff.valorBaseIcmsSubstituicao, nff.valorIcmsSubstituicao, " +
                    " nff.valorTotalIpi, nff.valorTotalProdutos, nff.valorTotalNota, f.nome as fornecedor_nome, " +
                    " nff.tipoFluxo_cid, nff.tipoEmissao_cid, nff.tipoNotaFiscal_cid, nff.situacaoNotaFiscal_cid, nff.tipoPagamento_cid, " +
                    " nff.tipoFrete_cid, nff.chaveNotaFiscalEletronica, nff.dataEntrada, " +
                    " nff.valorFrete, nff.valorSeguro, nff.valorDesconto, nff.valorOutrasDespesas, nff.valorAbatimento, " +
                    " nff.valorTotalPis, nff.valorPisRetidoSubstituicao, nff.valorTotalCofins, nff.valorCofinsRetidoSubstituicao ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From notafiscalfornecedor nff " +
                    " Left Outer Join fornecedores f on f.cid = nff.fornecedor_cid " +
                    " Left Outer Join logestoque l on l.notaFiscalNumero = nff.numero and l.notaFiscalSerie = nff.serie " +
                    " Left Outer Join produtos p on p.cid  = l.produto_cid ";

                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "nff.cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.numero, "nff.numero");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.serie, "nff.serie");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.fornecedor_cid, "nff.fornecedor_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataEmissao, "nff.dataEmissao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataInclusao, "nff.dataInclusao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorBaseIcms, "nff.valorBaseIcms");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorIcms, "nff.valorIcms");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorBaseIcmsSubstituicao, "nff.valorBaseIcmsSubstituicao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorIcmsSubstituicao, "nff.valorIcmsSubstituicao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorTotalIpi, "nff.valorTotalIpi");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorTotalProdutos, "nff.valorTotalProdutos");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorTotalNota, "nff.valorTotalNota");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.tipoEmissao_cid, "nff.tipoEmissao_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.tipoFluxo_cid, "nff.tipoFluxo_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.tipoFrete_cid, "nff.tipoFrete_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.tipoNotaFiscal_cid, "nff.tipoNotaFiscal_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.tipoPagamento_cid, "nff.tipoPagamento_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.situacaoNotaFiscal_cid, "nff.situacaoNotaFiscal_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.chaveNotaFiscalEletronica, "nff.chaveNotaFiscalEletronica");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataEntrada, "nff.dataEntrada");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorFrete, "nff.valorFrete");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorSeguro, "nff.valorSeguro");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorDesconto, "nff.valorDesconto");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorOutrasDespesas, "nff.valorOutrasDespesas");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorAbatimento, "nff.valorAbatimento");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorTotalPis, "nff.valorTotalPis");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorPisRetidoSubstituicao, "nff.valorPisRetidoSubstituicao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorTotalCofins, "nff.valorTotalCofins");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorCofinsRetidoSubstituicao, "nff.valorCofinsRetidoSubstituicao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.produtoCodigo, "p.codigo");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoNotaFiscalFornecedor();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dNotaFiscalFornecedor();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.numero = RetornarTexto(row["numero"]);
                            item.serie = RetornarTexto(row["serie"]);
                            item.fornecedor_cid = RetornarInteiro(row["fornecedor_cid"]);
                            item.fornecedorNome = RetornarTexto(row["fornecedor_nome"]);
                            item.dataEmissao = RetornarData(row["dataEmissao"]);
                            item.dataInclusao = RetornarData(row["dataInclusao"]);
                            item.valorBaseIcms = RetornarDecimal(row["valorBaseIcms"]);
                            item.valorIcms = RetornarDecimal(row["valorIcms"]);
                            item.valorBaseIcmsSubstituicao = RetornarDecimal(row["valorBaseIcmsSubstituicao"]);
                            item.valorIcmsSubstituicao = RetornarDecimal(row["valorIcmsSubstituicao"]);
                            item.valorTotalIpi = RetornarDecimal(row["valorTotalIpi"]);
                            item.valorTotalProdutos = RetornarDecimal(row["valorTotalProdutos"]);
                            item.valorTotalNota = RetornarDecimal(row["valorTotalNota"]);
                            item.tipoFluxo_cid = RetornarInteiro(row["tipoFluxo_cid"]);
                            item.tipoEmissao_cid = RetornarInteiro(row["tipoEmissao_cid"]);
                            item.tipoNotaFiscal_cid = RetornarInteiro(row["tipoNotaFiscal_cid"]);
                            item.situacaoNotaFiscal_cid = RetornarInteiro(row["situacaoNotaFiscal_cid"]);
                            item.tipoPagamento_cid = RetornarInteiro(row["tipoPagamento_cid"]);
                            item.tipoFrete_cid = RetornarInteiro(row["tipoFrete_cid"]);
                            item.chaveNotaFiscalEletronica = RetornarTexto(row["chaveNotaFiscalEletronica"]);
                            item.dataEntrada = RetornarData(row["dataEntrada"]);
                            item.valorFrete = RetornarDecimal(row["valorFrete"]);
                            item.valorSeguro = RetornarDecimal(row["valorSeguro"]);
                            item.valorDesconto = RetornarDecimal(row["valorDesconto"]);
                            item.valorOutrasDespesas = RetornarDecimal(row["valorOutrasDespesas"]);
                            item.valorAbatimento = RetornarDecimal(row["valorAbatimento"]);
                            item.valorTotalPis = RetornarDecimal(row["valorTotalPis"]);
                            item.valorPisRetidoSubstituicao = RetornarDecimal(row["valorPisRetidoSubstituicao"]);
                            item.valorTotalCofins = RetornarDecimal(row["valorTotalCofins"]);
                            item.valorCofinsRetidoSubstituicao = RetornarDecimal(row["valorCofinsRetidoSubstituicao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro ao Consultar NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoNotaFiscalItem ConsultarItemNota(string notaFiscal, string serie)
        {
            ColecaoNotaFiscalItem retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " select p.cid as 'produtos_cid', p.descricao as 'descricao', p.referencia as 'referencia', p.valorcompra as 'valorcompra', " +
                    " pi.valor as 'valor', pi.item as 'item', pi2.quantidade as 'estoque' ";
                string sqlWhere = " c.codigo = 'codigoBarras' ";
                string sqlFrom = " from produtos p " +
                    " inner join produtoitem pi on pi.produtos_cid = p.cid " +
                    " inner join caracteristicas c on c.cid = pi.caracteristicas_cid " +
                    " inner join logestoque pi2 on pi2.produto_cid = p.cid and pi.valor =  produtoItem_codigoBarras ";

                sqlWhere = ncNComum.nsFuncoes.cFuncoes.MontarParametrosSQL(sqlWhere, notaFiscal, "notaFiscalNumero");
                sqlWhere = ncNComum.nsFuncoes.cFuncoes.MontarParametrosSQL(sqlWhere, serie, "notaFiscalSerie");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " order by p.descricao, p.referencia, pi.valor");
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoNotaFiscalItem();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dNotaFiscalItem();
                            item.produtos_descricao = ncNComum.nsFuncoes.cFuncoes.RetornarTexto(row["descricao"]);
                            item.produtos_estoque = ncNComum.nsFuncoes.cFuncoes.RetornarTexto(row["estoque"]);
                            item.produtos_cid = ncNComum.nsFuncoes.cFuncoes.RetornarTexto(row["produtos_cid"]);
                            item.item = ncNComum.nsFuncoes.cFuncoes.RetornarTexto(row["item"]);
                            item.Produtos_Valor = ncNComum.nsFuncoes.cFuncoes.RetornarDecimal(row["ValorCompra"]);
                            item.Produtos_Referencia = ncNComum.nsFuncoes.cFuncoes.RetornarTexto(row["Referencia"]);
                            item.caracteristicas_codigo = ncNComum.nsFuncoes.cFuncoes.RetornarTexto(row["valor"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dNotaFiscalFornecedor dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " notafiscalfornecedor ( numero, serie, fornecedor_cid, dataEmissao, dataInclusao, " +
                    " valorBaseIcms, valorIcms, valorBaseIcmsSubstituicao, valorIcmsSubstituicao, " +
                    " valorTotalIpi, valorTotalProdutos, valorTotalNota, " +
                    " tipoFluxo_cid, tipoEmissao_cid, tipoNotaFiscal_cid, situacaoNotaFiscal_cid, tipoPagamento_cid, " +
                    " tipoFrete_cid, chaveNotaFiscalEletronica, dataEntrada, " +
                    " valorFrete, valorSeguro, valorDesconto, valorOutrasDespesas, valorAbatimento, " +
                    " valorTotalPis, valorPisRetidoSubstituicao, valorTotalCofins, valorCofinsRetidoSubstituicao ) " +
                    " VALUES (" +
                    PersistirTexto(dados.numero) + "," +
                    PersistirTexto(dados.serie) + "," +
                    PersistirInteiro(dados.fornecedor_cid) + "," +
                    PersistirData(dados.dataEmissao) + "," +
                    PersistirData(dados.dataInclusao.Value) + "," +
                    PersistirDecimal(dados.valorBaseIcms) + "," +
                    PersistirDecimal(dados.valorIcms) + "," +
                    PersistirDecimal(dados.valorBaseIcmsSubstituicao) + "," +
                    PersistirDecimal(dados.valorIcmsSubstituicao) + "," +
                    PersistirDecimal(dados.valorTotalIpi) + "," +
                    PersistirDecimal(dados.valorTotalProdutos) + "," +
                    PersistirDecimal(dados.valorTotalNota) + "," +
                    PersistirInteiro(dados.tipoFluxo_cid) + "," +
                    PersistirInteiro(dados.tipoEmissao_cid) + "," +
                    PersistirInteiro(dados.tipoNotaFiscal_cid) + "," +
                    PersistirInteiro(dados.situacaoNotaFiscal_cid) + "," +
                    PersistirInteiro(dados.tipoPagamento_cid) + "," +
                    PersistirInteiro(dados.tipoFrete_cid) + "," +
                    PersistirTexto(dados.chaveNotaFiscalEletronica) + "," +
                    PersistirData(dados.dataEntrada) + "," +
                    PersistirDecimal(dados.valorFrete) + "," +
                    PersistirDecimal(dados.valorSeguro) + "," +
                    PersistirDecimal(dados.valorDesconto) + "," +
                    PersistirDecimal(dados.valorOutrasDespesas) + "," +
                    PersistirDecimal(dados.valorAbatimento) + "," +
                    PersistirDecimal(dados.valorTotalPis) + "," +
                    PersistirDecimal(dados.valorPisRetidoSubstituicao) + "," +
                    PersistirDecimal(dados.valorTotalCofins) + "," +
                    PersistirDecimal(dados.valorCofinsRetidoSubstituicao) + ")";
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dNotaFiscalFornecedor dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE notafiscalfornecedor SET " +
                    " fornecedor_cid = " + PersistirInteiro(dados.fornecedor_cid) + "," +
                    " dataEmissao = " + PersistirData(dados.dataEmissao) + "," +
                    " dataInclusao = " + PersistirData(dados.dataInclusao.Value) + "," +
                    " valorBaseIcms = " + PersistirDecimal(dados.valorBaseIcms) + "," +
                    " valorIcms = " + PersistirDecimal(dados.valorIcms) + "," +
                    " valorBaseIcmsSubstituicao = " + PersistirDecimal(dados.valorBaseIcmsSubstituicao) + "," +
                    " valorIcmsSubstituicao = " + PersistirDecimal(dados.valorIcmsSubstituicao) + "," +
                    " valorTotalIpi = " + PersistirDecimal(dados.valorTotalIpi) + "," +
                    " valorTotalProdutos = " + PersistirDecimal(dados.valorTotalProdutos) + "," +
                    " valorTotalNota = " + PersistirDecimal(dados.valorTotalNota) + "," +
                    " tipoFluxo_cid = " + PersistirInteiro(dados.tipoFluxo_cid) + "," +
                    " tipoEmissao_cid = " + PersistirInteiro(dados.tipoEmissao_cid) + "," +
                    " tipoNotaFiscal_cid = " + PersistirInteiro(dados.tipoNotaFiscal_cid) + "," +
                    " situacaoNotaFiscal_cid = " + PersistirInteiro(dados.situacaoNotaFiscal_cid) + "," +
                    " tipoPagamento_cid = " + PersistirInteiro(dados.tipoPagamento_cid) + "," +
                    " tipoFrete_cid = " + PersistirInteiro(dados.tipoFrete_cid) + "," +
                    " chaveNotaFiscalEletronica = " + PersistirTexto(dados.chaveNotaFiscalEletronica) + "," +
                    " dataEntrada = " + PersistirData(dados.dataEntrada) + "," +
                    " valorFrete = " + PersistirDecimal(dados.valorFrete) + "," +
                    " valorSeguro = " + PersistirDecimal(dados.valorSeguro) + "," +
                    " valorDesconto = " + PersistirDecimal(dados.valorDesconto) + "," +
                    " valorOutrasDespesas = " + PersistirDecimal(dados.valorOutrasDespesas) + "," +
                    " valorAbatimento = " + PersistirDecimal(dados.valorAbatimento) + "," +
                    " valorTotalPis = " + PersistirDecimal(dados.valorTotalPis) + "," +
                    " valorPisRetidoSubstituicao = " + PersistirDecimal(dados.valorPisRetidoSubstituicao) + "," +
                    " valorTotalCofins = " + PersistirDecimal(dados.valorTotalCofins) + "," +
                    " valorCofinsRetidoSubstituicao = " + PersistirDecimal(dados.valorCofinsRetidoSubstituicao) +
                    " WHERE " +
                    " numero = " + PersistirTexto(dados.numero) + " AND " +
                    " serie = " + PersistirTexto(dados.serie);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dNotaFiscalFornecedor dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM notafiscalfornecedor " +
                    " WHERE " +
                    " numero = " + PersistirTexto(dados.numero) + " AND " +
                    " serie = " + PersistirTexto(dados.serie);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
