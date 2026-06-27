using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsCaixa;


namespace ncPersistencia.nsCaixa
{
    public class pCaixa
    {
        public ColecaoCaixa Listar()
        {
            ColecaoCaixa retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, nome, situacao, data From Caixa Order By nome ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoCaixa();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dCaixa();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.nome = RetornarTexto(row["nome"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.Data = (DateTime)RetornarData(row["data"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Caixa [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoCaixa Consultar(dCaixa dados)
        {
            ColecaoCaixa retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, nome, situacao, data ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From Caixa ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.nome, "nome");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.situacao, "situacao");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " Order By nome");
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoCaixa();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dCaixa();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.nome = RetornarTexto(row["nome"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.Data = (DateTime)RetornarData(row["data"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Caixa [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoFechamento ConsultarFechamento(dCaixa dados)
        {
            ColecaoFechamento retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = "  SELECT DATE_FORMAT(data,'%Y-%m-%d') as dataF, sum(dinheiro) as dinheiro, sum(cheque) as cheque, sum(chequePre) as chequePre, sum(cartaoDebito) as cartaoDebito, sum(cartaoCredito) as cartaoCredito, sum(crediario) as crediario, sum(desconto) as desconto, sum(recebido) as recebido, sum(troco) as troco, sum(total) as total,  sum(troca) as troca, sum(vale) as vale, sum(defeito) as defeito, sum(retirada) as retirada, sum(valeEmitido) as valeEmitido, caixa, sum(crediarioPagamento) as crediarioPagamento  ";
                string sqlWhere = string.Empty;
                string sqlFrom = "  FROM v_fechamento ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.nome, "caixa");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.Data.ToString("yyyy-MM-dd"), $"DATE_FORMAT(data,'%Y-%m-%d')");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " Group By dataF, caixa");
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoFechamento();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dFechamento();
                            item.data = RetornarData(ds.Tables[0].Rows[0]["dataF"]);
                            item.dinheiro = RetornarDecimal(ds.Tables[0].Rows[0]["dinheiro"]);
                            item.cheque = RetornarDecimal(ds.Tables[0].Rows[0]["cheque"]);
                            item.chequePre = RetornarDecimal(ds.Tables[0].Rows[0]["chequePre"]);
                            item.cartaoDebito = RetornarDecimal(ds.Tables[0].Rows[0]["cartaoDebito"]);
                            item.cartaoCredito = RetornarDecimal(ds.Tables[0].Rows[0]["cartaoCredito"]);
                            item.crediario = RetornarDecimal(ds.Tables[0].Rows[0]["crediario"]);
                            item.desconto = RetornarDecimal(ds.Tables[0].Rows[0]["desconto"]);
                            item.recebido = RetornarDecimal(ds.Tables[0].Rows[0]["recebido"]);
                            item.troco = RetornarDecimal(ds.Tables[0].Rows[0]["troco"]);
                            item.total = RetornarDecimal(ds.Tables[0].Rows[0]["total"]);
                            item.troca = RetornarDecimal(ds.Tables[0].Rows[0]["troca"]);
                            item.vale = RetornarDecimal(ds.Tables[0].Rows[0]["vale"]);
                            item.defeito = RetornarDecimal(ds.Tables[0].Rows[0]["defeito"]);
                            item.retirada = RetornarDecimal(ds.Tables[0].Rows[0]["retirada"]);
                            item.valeEmitido = RetornarDecimal(ds.Tables[0].Rows[0]["valeEmitido"]);
                            item.caixa = RetornarTexto(ds.Tables[0].Rows[0]["caixa"]);
                            item.crediarioPagamento = RetornarDecimal(ds.Tables[0].Rows[0]["crediarioPagamento"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Fechamento do Caixa [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dCaixa dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " Caixa ( nome, data, usuario, situacao ) " +
                    " VALUES (" +
                    PersistirTexto(dados.nome) + "," +
                    PersistirData(dados.Data) + "," +
                    PersistirTexto(dados.usuario) + "," +
                    PersistirTexto(dados.situacao) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Caixa [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dCaixa dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE Caixa SET " +
                    " nome = " + PersistirTexto(dados.nome) + "," +
                    " data = " + PersistirData(dados.Data) + "," +
                    " usuario = " + PersistirTexto(dados.usuario) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Caixa [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dCaixa dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM Caixa " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Caixa [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
