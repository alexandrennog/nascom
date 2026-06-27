using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsParametro;
using nsdParametroEstoque;

namespace ncPersistencia.nsParametro
{
    public class pParametro
    {
        public ColecaoParametro Listar()
        {
            ColecaoParametro retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, descricao, valor From Parametros ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoParametro();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dParametro();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.descricao = RetornarTexto(row["descricao"]);
                            item.valor = RetornarTexto(row["valor"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Parametro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoParametro Consultar(dParametro dados)
        {
            ColecaoParametro retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, descricao, valor ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From Parametros ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.descricao, "descricao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valor, "valor");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoParametro();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dParametro();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.descricao = RetornarTexto(row["descricao"]);
                            item.valor = RetornarTexto(row["valor"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (ExcecaoNascomercio)
            {
                throw;
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Parametro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoParametroEstoque ConsultarEstoque(dParametroEstoque dados)
        {
            ColecaoParametroEstoque retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " SELECT e.fabricante, e.cid, p.descricao, e.referencia, e.item, e.valorCompra, e.valorVenda, e.valor, c.nome as cor";
                string sqlWhere = string.Empty;
                string sqlFrom = " FROM nascomercio.produtos as p ";
                sqlFrom += "  INNER JOIN nascomercio.v_estoque as e ON e.cid = p.cid ";
                sqlFrom += "  INNER Join nascomercio.cor as c ON c.cid = p.cor_cid ";

                if (dados.valor == "1")
                    sqlWhere = sqlWhere + " e.valor > 0";
                else
                    sqlWhere = sqlWhere + " e.valor = 0";

                if (dados.cidGrupo > 0)
                    sqlWhere = sqlWhere + " AND p.grupo_cid = " + dados.cidGrupo.ToString();

                if (dados.cidFornecedor > 0)
                    sqlWhere = sqlWhere + " AND e.fornecedor_cid = " + dados.cidFornecedor.ToString();

                if (dados.cidFabricante > 0)
                    sqlWhere = sqlWhere + " AND e.fabricante_cid = " + dados.cidFabricante.ToString();

                if (!string.IsNullOrEmpty(dados.descricao))
                    sqlWhere = sqlWhere + "AND descricao = '" + dados.descricao + "'";

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " order by p.codigo, e.item");
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoParametroEstoque();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dEstoque();
                            item.Fabricante = RetornarTexto(row["fabricante"]);
                            item.CID = RetornarTexto(row["cid"]);
                            item.Descricao = RetornarTexto(row["descricao"]);
                            item.Referencia = RetornarTexto(row["referencia"]);
                            item.Item = RetornarTexto(row["item"]);
                            item.ValorCompra = (decimal)RetornarDecimal(row["valorCompra"]);
                            item.ValorVenda = (decimal)RetornarDecimal(row["valorVenda"]);
                            item.Valor = (decimal)RetornarDecimal(row["valor"]);
                            item.Cor = RetornarTexto(row["cor"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (ExcecaoNascomercio)
            {
                throw;
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Parametro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dParametro dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " Parametros ( descricao, valor ) " +
                    " VALUES (" +
                    PersistirTexto(dados.descricao) + "," +
                    PersistirTexto(dados.valor) + ")";
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Parametro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dParametro dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE Parametros SET " +
                    " descricao = " + PersistirTexto(dados.descricao) + "," +
                    " valor = " + PersistirTexto(dados.valor) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Parametro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dParametro dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM Parametros " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Parametro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
