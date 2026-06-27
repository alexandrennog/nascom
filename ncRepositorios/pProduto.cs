using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsProduto;
using nsGradeItem;
using nsGradeEntrada;

namespace ncPersistencia.nsProduto
{
    public class pProduto
    {
        public ColecaoProduto Listar()
        {
            ColecaoProduto retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, codigo, descricao, situacao, produtoTipo_cid, fornecedor_cid, fabricante_cid, " +
                    " dataInclusao, valorCompra, valorVenda, referencia, imagem, estoqueMinimo, cor_cid, " +
                    " grupo_cid, aliquota, efdUnidadeMedidaCodigo, efdIntegracao " +
                    " From produtos ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoProduto();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dProduto();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.codigo = RetornarTexto(row["codigo"]);
                            item.descricao = RetornarTexto(row["descricao"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.dataInclusao = RetornarTexto(row["dataInclusao"]);
                            item.valorCompra = RetornarDecimal(row["valorCompra"]);
                            item.valorVenda = RetornarDecimal(row["valorVenda"]);
                            item.produtoTipo_cid = RetornarInteiro(row["produtoTipo_cid"]);
                            item.fornecedor_cid = RetornarInteiro(row["fornecedor_cid"]);
                            item.fabricante_cid = RetornarInteiro(row["fabricante_cid"]);
                            item.referencia = RetornarTexto(row["referencia"]);
                            item.imagem = RetornarTexto(row["imagem"]);
                            item.cor_cid = RetornarInteiro(row["cor_cid"]);
                            item.grupo_cid = RetornarInteiro(row["grupo_cid"]);
                            item.aliquota = RetornarTexto(row["aliquota"]);
                            item.estoqueMinimo = RetornarInteiro(row["estoqueMinimo"]);
                            item.efdUnidadeMedidaCodigo = RetornarTexto(row["efdUnidadeMedidaCodigo"]);
                            item.efdIntegracao = RetornarBoleano(row["efdIntegracao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Produto [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoProduto Consultar(dProduto dados)
        {
            ColecaoProduto retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select Distinct p.cid, p.codigo, p.descricao, p.situacao, p.produtoTipo_cid, p.fornecedor_cid, p.fabricante_cid, " +
                    " p.dataInclusao, p.valorCompra, p.valorVenda, p.referencia, p.imagem, p.estoqueMinimo, p.cor_cid, " +
                    " p.grupo_cid, p.aliquota, c.nome as cor, g.nome as grupo, p.efdUnidadeMedidaCodigo, p.efdCodigoCategoria, p.efdIntegracao, ct.nome as categoria ";
                string sqlFrom = " From produtos p " +
                    " Left Outer Join produtoitem pi On pi.produtos_cid = p.cid " +
                    " And pi.caracteristicas_cid = 1 " +
                    " Left Outer Join cor c On c.cid = p.cor_cid " +
                    " Left Outer Join categoria ct On ct.cid = p.efdCodigoCategoria " +
                    " Left Outer Join grupo g On g.cid = p.grupo_cid ";
                string sqlWhere = string.Empty;

                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "p.cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.codigo, "p.codigo");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.descricao, "p.descricao", true);
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.situacao, "p.situacao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataInclusao, "p.dataInclusao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorCompra, "p.valorCompra");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valorVenda, "p.valorVenda");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.fornecedor_cid, "p.fornecedor_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.fabricante_cid, "p.fabricante_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.referencia, "p.referencia");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.imagem, "p.imagem");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cor_cid, "p.cor_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.grupo_cid, "p.grupo_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.aliquota, "p.aliquota");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.estoqueMinimo, "p.estoqueMinimo");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.codigoBarras, "pi.valor");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoProduto();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dProduto();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.codigo = RetornarTexto(row["codigo"]);
                            item.descricao = RetornarTexto(row["descricao"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.dataInclusao = RetornarTexto(row["dataInclusao"]);
                            item.valorCompra = RetornarDecimal(row["valorCompra"]);
                            item.valorVenda = RetornarDecimal(row["valorVenda"]);
                            item.produtoTipo_cid = RetornarInteiro(row["produtoTipo_cid"]);
                            item.fornecedor_cid = RetornarInteiro(row["fornecedor_cid"]);
                            item.fabricante_cid = RetornarInteiro(row["fabricante_cid"]);
                            item.referencia = RetornarTexto(row["referencia"]);
                            item.imagem = RetornarTexto(row["imagem"]);
                            item.cor_cid = RetornarInteiro(row["cor_cid"]);
                            item.cor = RetornarTexto(row["cor"]);
                            item.grupo_cid = RetornarInteiro(row["grupo_cid"]);
                            item.grupo = RetornarTexto(row["grupo"]);
                            item.aliquota = RetornarTexto(row["aliquota"]);
                            item.estoqueMinimo = RetornarInteiro(row["estoqueMinimo"]);
                            item.efdUnidadeMedidaCodigo = RetornarTexto(row["efdUnidadeMedidaCodigo"]);
                            item.efdCodigoCategoria = RetornarTexto(row["efdCodigoCategoria"]);
                            item.efdIntegracao = RetornarBoleano(row["efdIntegracao"]);
                            item.efdCategoria = RetornarTexto(row["categoria"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Produto [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoGradeEntrada ConsultarGradeEntrada(dProduto dados)
        {
            ColecaoGradeEntrada retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect1 = " select " +
                    "   le.produto_cid as 'produto', " +
                    "   le.produtoitem_codigobarras as 'codigoBarras', " +
                    "   DATE_FORMAT(le.data,'%Y-%m-%d') as 'entrada_data', " +
                    "   pi.item as 'item', " +
                    "   ( " +
                    "     select pi2.valor " +
                    "     from produtoitem pi2 " +
                    "     where pi2.produtos_cid = produto_cid " +
                    "       and pi2.item = pi.item " +
                    "       and pi2.caracteristicas_cid = 3 " +
                    "   ) as 'tamanho', " +
                    "   sum(le.quantidade) as 'entrada_qtde' " +
                    " from " +
                    "   logestoque le " +
                    "   inner join produtoitem pi " +
                    "     on " +
                    "       ( " +
                    "         pi.valor = le.produtoitem_codigobarras " +
                    "         and " +
                    "         pi.caracteristicas_cid = 1 " +
                    "       ) ";

                string sqlSelect2 = " group by " +
                    "   le.produto_cid, le.produtoitem_codigobarras, entrada_data, item, tamanho " +
                    " order by " +
                    "   produto_cid, entrada_data, produtoitem_codigobarras ; ";

                string sqlWhere = string.Empty;

                sqlWhere = sqlWhere + " ( DATE_FORMAT(le.data,'%Y-%m-%d') between '" + dados.dataInicio + "' and '" + dados.dataFinal + "' ) ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "le.produto_cid");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " where " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect1 + " " + sqlWhere + " " + sqlSelect2);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoGradeEntrada();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dGradeEntrada();
                            item.produto_cid = RetornarInteiro(row["produto"]);
                            item.item = RetornarInteiro(row["item"]);
                            item.codigoBarras = RetornarTexto(row["codigoBarras"]);
                            item.tamanho = RetornarTexto(row["tamanho"]);
                            item.entrada_data = RetornarTexto(row["entrada_data"]);
                            item.entrada_qtde = RetornarInteiro(row["entrada_qtde"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Grade Entrada [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int ConsultarProximoCID()
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " select max(p.cid) as cid from produtos p ";
                var ds = acessoBanco.ExecutarDS(sqlSelect);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["cid"] != DBNull.Value)
                            retorno = RetornarInteiro(dt.Rows[0]["cid"]);
                        else
                            retorno = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em ConsultarProximoCID Produto [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dProduto dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " produtos (codigo, descricao, produtoTipo_cid, fornecedor_cid, fabricante_cid, valorCompra, valorVenda, " +
                    " referencia, imagem, situacao, cor_cid, grupo_cid, estoqueMinimo, aliquota, dataInclusao, " +
                    " efdUnidadeMedidaCodigo, efdCodigoCategoria, efdIntegracao ) " +
                    " VALUES (" +
                    PersistirTexto(dados.codigo) + "," +
                    PersistirTexto(dados.descricao) + "," +
                    PersistirInteiro(dados.produtoTipo_cid) + "," +
                    PersistirInteiro(dados.fornecedor_cid) + "," +
                    PersistirInteiro(dados.fabricante_cid) + "," +
                    PersistirDecimal(dados.valorCompra) + "," +
                    PersistirDecimal(dados.valorVenda) + "," +
                    PersistirTexto(dados.referencia) + "," +
                    PersistirTexto(dados.imagem) + "," +
                    PersistirTexto(dados.situacao) + "," +
                    PersistirInteiro(dados.cor_cid) + "," +
                    PersistirInteiro(dados.grupo_cid) + "," +
                    PersistirInteiro(dados.estoqueMinimo) + "," +
                    PersistirTexto(dados.aliquota) + "," +
                    PersistirTexto(dados.dataInclusao) + "," +
                    PersistirTexto(dados.efdUnidadeMedidaCodigo) + "," +
                    PersistirTexto(dados.efdCodigoCategoria) + "," +
                    PersistirBoleano(dados.efdIntegracao) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Produto [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Importar(dProduto dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " produtos (cid, codigo, descricao, produtoTipo_cid, fornecedor_cid, fabricante_cid, valorCompra, valorVenda, " +
                    " referencia, imagem, situacao, cor_cid, grupo_cid, estoqueMinimo, aliquota, dataInclusao ) " +
                    " VALUES (" +
                    PersistirInteiro(dados.cid) + "," +
                    PersistirTexto(dados.codigo) + "," +
                    PersistirTexto(dados.descricao) + "," +
                    PersistirInteiro(dados.produtoTipo_cid) + "," +
                    PersistirInteiro(dados.fornecedor_cid) + "," +
                    PersistirInteiro(dados.fabricante_cid) + "," +
                    PersistirDecimal(dados.valorCompra) + "," +
                    PersistirDecimal(dados.valorVenda) + "," +
                    PersistirTexto(dados.referencia) + "," +
                    PersistirTexto(dados.imagem) + "," +
                    PersistirTexto(dados.situacao) + "," +
                    PersistirInteiro(dados.cor_cid) + "," +
                    PersistirInteiro(dados.grupo_cid) + "," +
                    PersistirInteiro(dados.estoqueMinimo) + "," +
                    PersistirTexto(dados.aliquota) + "," +
                    PersistirTexto(dados.dataInclusao) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Importar Produto [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dProduto dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE produtos SET " +
                    " codigo = " + PersistirTexto(dados.codigo) + "," +
                    " descricao = " + PersistirTexto(dados.descricao) + "," +
                    " produtoTipo_cid = " + PersistirInteiro(dados.produtoTipo_cid) + "," +
                    " fornecedor_cid = " + PersistirInteiro(dados.fornecedor_cid) + "," +
                    " fabricante_cid = " + PersistirInteiro(dados.fabricante_cid) + "," +
                    " valorCompra = " + PersistirDecimal(dados.valorCompra) + "," +
                    " valorVenda = " + PersistirDecimal(dados.valorVenda) + "," +
                    " imagem = " + PersistirTexto(dados.imagem) + "," +
                    " referencia = " + PersistirTexto(dados.referencia) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) + "," +
                    " cor_cid = " + PersistirInteiro(dados.cor_cid) + "," +
                    " grupo_cid = " + PersistirInteiro(dados.grupo_cid) + "," +
                    " estoqueMinimo = " + PersistirInteiro(dados.estoqueMinimo) + "," +
                    " aliquota = " + PersistirTexto(dados.aliquota) + "," +
                    " dataInclusao = " + PersistirTexto(dados.dataInclusao) + "," +
                    " efdUnidadeMedidaCodigo = " + PersistirTexto(dados.efdUnidadeMedidaCodigo) + "," +
                    " efdCodigoCategoria = " + PersistirTexto(dados.efdCodigoCategoria) + "," +
                    " efdIntegracao = " + PersistirBoleano(dados.efdIntegracao) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Produto [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dProduto dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM produtos " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Produto [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
