using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsCurvaABC;
using nsVenda;

namespace ncPersistencia.nsVenda
{
    public class pVenda
    {
        public ColecaoVenda Listar()
        {
            ColecaoVenda retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select controle, usuarioId, clienteId, data, dinheiro, cheque, " +
                    "chequePre, cartaoDebito, cartaoCredito, crediario, " +
                    "parcelas, desconto, condicao, recebido, troco, troca, vale, defeito, terminal, total, Original, txID From Vendas";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoVenda();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dVenda();
                            item.controle = (int)RetornarInteiro(row["controle"]);
                            item.usuarioId = (int)RetornarInteiro(row["usuarioId"]);
                            item.clienteId = (int)RetornarInteiro(row["clienteId"]);
                            item.Data = RetornarDataValida(row["data"].ToString());
                            item.Dinheiro = (decimal)RetornarDecimal(row["dinheiro"]);
                            item.Cheque = (decimal)RetornarDecimal(row["cheque"]);
                            item.ChequePre = (decimal)RetornarDecimal(row["chequepre"]);
                            item.CartaoDebito = (decimal)RetornarDecimal(row["cartaodebito"]);
                            item.CartaoCredito = (decimal)RetornarDecimal(row["cartaocredito"]);
                            item.Crediario = (decimal)RetornarDecimal(row["crediario"]);
                            item.Parcelas = (int)RetornarInteiro(row["parcelas"]);
                            item.Desconto = (decimal)RetornarDecimal(row["desconto"]);
                            item.Condicao = (int)RetornarInteiro(row["condicao"]);
                            item.Recebido = (decimal)RetornarDecimal(row["recebido"]);
                            item.Troco = (decimal)RetornarDecimal(row["troco"]);
                            item.Troca = (decimal)RetornarDecimal(row["troca"]);
                            item.Vale = (decimal)RetornarDecimal(row["vale"]);
                            item.Defeito = (decimal)RetornarDecimal(row["defeito"]);
                            item.Terminal = row["terminal"].ToString();
                            item.Total = (decimal)RetornarDecimal(row["total"]);
                            item.Pix = (decimal)RetornarDecimal(row["Original"]);
                            item.TXID = RetornarTexto(row["txID"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaodVendasNfe ListarVendasNfe(string dataIni, string dataFim)
        {
            ColecaodVendasNfe retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " SELECT SUBSTRING(chNFe, 25, 9) as cupom, DATE_FORMAT(dhrecbto, '%d/%m/%Y') as datavenda, total  " +
                    "FROM nascomercio.vendas INNER JOIN nascomercio.infprot ON chNFe = chave and cstat = 100 " +
                    $"where chave is not null and data >= '{dataIni}' and data <= '{dataFim}'";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaodVendasNfe();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dVendasNfe();
                            item.Cupom = RetornarTexto(row["cupom"]);
                            item.DataVenda = RetornarTexto(row["datavenda"]);
                            item.Valor = RetornarTexto(row["total"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em ListarVendasNfe Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaodVendasABC ListarVendasABC(string dataIni, string dataFim, string tipo)
        {
            ColecaodVendasABC retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL;
                if (tipo == "V")
                {
                    acessoBanco.ExecutarDSLongo($"call sp_curva_abc_fornecedores('{dataIni}','{dataFim}')");
                    comandoSQL = " select * from ranking_resultado_valor;";
                }
                else
                {
                    acessoBanco.ExecutarDSLongo($"call sp_curva_abc_fornecedores_quantidade('{dataIni}','{dataFim}')");
                    comandoSQL = " select * from ranking_resultado_quantidade;";
                }
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaodVendasABC();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dCurvaAbc();
                            item.PeriodoIni = RetornarTexto(row["data_inicio"]);
                            item.PeriodoFim = RetornarTexto(row["data_fim"]);
                            item.Fabricante = RetornarTexto(row["fabricante"]);
                            item.valor = RetornarTexto(row["valor"]);
                            item.PercReceita = (decimal)RetornarDecimal(row["individual"]);
                            item.PercAcumulado = (decimal)RetornarDecimal(row["acumulado"]);
                            item.ClasseAbc = RetornarTexto(row["classificacao_abc"]);
                            item.Estrategia = RetornarTexto(row["estrategia_sugerida"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em ListarVendasABC Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoVenda Consultar(dVenda dados)
        {
            ColecaoVenda retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select controle, usuarioId, clienteId, data, dinheiro, cheque, " +
                    "chequePre, cartaoDebito, cartaoCredito, crediario, vendedor, " +
                    "parcelas, desconto, condicao, recebido, troco, troca, vale, defeito, terminal, total, ordemservico, Original, txID, chave ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From vendas ";

                sqlWhere = MontarParametrosSQL(sqlWhere, dados.controle, "controle");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoVenda();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dVenda();
                            item.controle = (int)RetornarInteiro(row["controle"]);
                            item.usuarioId = (int)RetornarInteiro(row["usuarioId"]);
                            item.clienteId = (int)RetornarInteiro(row["clienteId"]);
                            item.Vendedor = RetornarTexto(row["vendedor"]);
                            item.Data = RetornarDataValida(row["data"].ToString());
                            item.Dinheiro = (decimal)RetornarDecimal(row["dinheiro"]);
                            item.Cheque = (decimal)RetornarDecimal(row["cheque"]);
                            item.ChequePre = (decimal)RetornarDecimal(row["chequepre"]);
                            item.CartaoDebito = (decimal)RetornarDecimal(row["cartaodebito"]);
                            item.CartaoCredito = (decimal)RetornarDecimal(row["cartaocredito"]);
                            item.Crediario = (decimal)RetornarDecimal(row["crediario"]);
                            item.Parcelas = (int)RetornarInteiro(row["parcelas"]);
                            item.Desconto = (decimal)RetornarDecimal(row["desconto"]);
                            item.Condicao = (int)RetornarInteiro(row["condicao"]);
                            item.Recebido = (decimal)RetornarDecimal(row["recebido"]);
                            item.Troco = (decimal)RetornarDecimal(row["troco"]);
                            item.Troca = (decimal)RetornarDecimal(row["troca"]);
                            item.Vale = (decimal)RetornarDecimal(row["vale"]);
                            item.Defeito = (decimal)RetornarDecimal(row["defeito"]);
                            item.Terminal = RetornarTexto(row["terminal"]);
                            item.Total = (decimal)RetornarDecimal(row["total"]);
                            item.Pix = (decimal)RetornarDecimal(row["Original"]);
                            item.ordemServicoId = RetornarTexto(row["ordemservico"]);
                            item.TXID = RetornarTexto(row["txID"]);
                            item.Chave = RetornarTexto(row["chave"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoVenda ConsultarPix(dVenda dados)
        {
            ColecaoVenda retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select controle, usuarioId, clienteId, data, dinheiro, cheque, " +
                    "chequePre, cartaoDebito, cartaoCredito, crediario, vendedor, " +
                    "parcelas, desconto, condicao, recebido, troco, troca, vale, defeito, terminal, total, ordemservico, Original, txID ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From vendas ";

                sqlWhere = sqlWhere + " data between '" + FormatarDataUniversal(dados.Data.ToString()) + "' AND '" + FormatarDataUniversal(dados.DataFim.ToString()) + "'";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.Caixa, "caixa");
                sqlWhere = sqlWhere + " AND  Original > 0 ";

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoVenda();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dVenda();
                            item.controle = (int)RetornarInteiro(row["controle"]);
                            item.usuarioId = (int)RetornarInteiro(row["usuarioId"]);
                            item.clienteId = (int)RetornarInteiro(row["clienteId"]);
                            item.Vendedor = RetornarTexto(row["vendedor"]);
                            item.Data = RetornarDataValida(row["data"].ToString());
                            item.Dinheiro = (decimal)RetornarDecimal(row["dinheiro"]);
                            item.Cheque = (decimal)RetornarDecimal(row["cheque"]);
                            item.ChequePre = (decimal)RetornarDecimal(row["chequepre"]);
                            item.CartaoDebito = (decimal)RetornarDecimal(row["cartaodebito"]);
                            item.CartaoCredito = (decimal)RetornarDecimal(row["cartaocredito"]);
                            item.Crediario = (decimal)RetornarDecimal(row["crediario"]);
                            item.Parcelas = (int)RetornarInteiro(row["parcelas"]);
                            item.Desconto = (decimal)RetornarDecimal(row["desconto"]);
                            item.Condicao = (int)RetornarInteiro(row["condicao"]);
                            item.Recebido = (decimal)RetornarDecimal(row["recebido"]);
                            item.Troco = (decimal)RetornarDecimal(row["troco"]);
                            item.Troca = (decimal)RetornarDecimal(row["troca"]);
                            item.Vale = (decimal)RetornarDecimal(row["vale"]);
                            item.Defeito = (decimal)RetornarDecimal(row["defeito"]);
                            item.Terminal = RetornarTexto(row["terminal"]);
                            item.Total = (decimal)RetornarDecimal(row["total"]);
                            item.Pix = (decimal)RetornarDecimal(row["Original"]);
                            item.TXID = RetornarTexto(row["txID"]);
                            item.ordemServicoId = RetornarTexto(row["ordemservico"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoVendasPorVendedor ConsultarVendasPorVendedor(dVendasPorVendedor dados)
        {
            ColecaoVendasPorVendedor retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                DataSet ds;
                if (dados.Nome == "Todos")
                    ds = acessoBanco.ExecutarDS($"call sp_recuperavendas(null, '{dados.Data.ToString("yyyy-MM-dd") + " 00:00:00"}' , '{dados.DataFim.ToString("yyyy-MM-dd") + " 00:00:00"}');");
                else
                    ds = acessoBanco.ExecutarDS($"call sp_recuperavendas('{dados.Nome}', '{dados.Data.ToString("yyyy-MM-dd") + " 00:00:00"}' , '{dados.DataFim.ToString("yyyy-MM-dd") + " 00:00:00"}');");

                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0 && Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[1]) > -1)
                    {
                        retorno = new ColecaoVendasPorVendedor();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dVendasPorVendedor();
                            item.Nome = RetornarTexto(row["vendedor"]);
                            item.TotalVendas = (int)RetornarInteiro(row["totalvendas"]);
                            item.QuantidadeProdutos = (int)RetornarInteiro(row["qtdprod"]);
                            item.ValorTotalVendas = (decimal)RetornarDecimal(row["valor"]);
                            item.TicketMedio = (decimal)RetornarDecimal(row["ticket"]);
                            item.PercentualAtingimento = (decimal)RetornarDecimal(row["pa"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoVendasPorVendedor ConsultarVendasDaLoja(dVendasPorVendedor dados)
        {
            ColecaoVendasPorVendedor retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                var ds = acessoBanco.ExecutarDS($"call sp_recuperavendasloja('{dados.Data.ToString("yyyy-MM-dd") + " 00:00:00"}' , '{dados.DataFim.ToString("yyyy-MM-dd") + " 00:00:00"}');");
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0 && Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]) > -1)
                    {
                        retorno = new ColecaoVendasPorVendedor();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dVendasPorVendedor();
                            item.Nome = RetornarTexto("");
                            item.TotalVendas = (int)RetornarInteiro(row["totalvendas"]);
                            item.QuantidadeProdutos = (int)RetornarInteiro(row["qtdprod"]);
                            item.ValorTotalVendas = (decimal)RetornarDecimal(row["valor"]);
                            item.TicketMedio = (decimal)RetornarDecimal(row["ticket"]);
                            item.PercentualAtingimento = (decimal)RetornarDecimal(row["pa"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoVenda ConsultarCrediarioPix(dVenda dados)
        {
            ColecaoVenda retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select controle, usuarioId, clienteId, data, dinheiro, cheque, " +
                    "chequePre, cartaoDebito, cartaoCredito, crediario, crediariopagamento, parcelas, desconto,  " +
                    "condicao, recebido, troco, troca, vale, defeito, terminal, total, Original, txID ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From credpag ";

                sqlWhere = sqlWhere + " data between '" + FormatarDataUniversal(dados.Data.ToString()) + "' AND '" + FormatarDataUniversal(dados.DataFim.ToString()) + "'";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.Caixa, "caixa");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoVenda();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dVenda();
                            item.controle = (int)RetornarInteiro(row["controle"]);
                            item.usuarioId = (int)RetornarInteiro(row["usuarioId"]);
                            item.clienteId = (int)RetornarInteiro(row["clienteId"]);
                            item.Data = RetornarDataValida(row["data"].ToString());
                            item.Dinheiro = (decimal)RetornarDecimal(row["dinheiro"]);
                            item.Cheque = (decimal)RetornarDecimal(row["cheque"]);
                            item.ChequePre = (decimal)RetornarDecimal(row["chequepre"]);
                            item.CartaoDebito = (decimal)RetornarDecimal(row["cartaodebito"]);
                            item.CartaoCredito = (decimal)RetornarDecimal(row["cartaocredito"]);
                            item.Crediario = (decimal)RetornarDecimal(row["crediario"]);
                            item.CrediarioPagamento = (decimal)RetornarDecimal(row["crediariopagamento"]);
                            item.Parcelas = (int)RetornarInteiro(row["parcelas"]);
                            item.Desconto = (decimal)RetornarDecimal(row["desconto"]);
                            item.Condicao = (int)RetornarInteiro(row["condicao"]);
                            item.Recebido = (decimal)RetornarDecimal(row["recebido"]);
                            item.Troco = (decimal)RetornarDecimal(row["troco"]);
                            item.Troca = (decimal)RetornarDecimal(row["troca"]);
                            item.Vale = (decimal)RetornarDecimal(row["vale"]);
                            item.Defeito = (decimal)RetornarDecimal(row["defeito"]);
                            item.Terminal = RetornarTexto(row["terminal"]);
                            item.Total = (decimal)RetornarDecimal(row["total"]);
                            item.Pix = (decimal)RetornarDecimal(row["Original"]);
                            item.TXID = RetornarTexto(row["txID"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoVenda ConsultarTroca(dVenda dados)
        {
            ColecaoVenda retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select controle, usuarioId, clienteId, data, dinheiro, cheque, " +
                    "chequePre, cartaoDebito, cartaoCredito, crediario, vendedor, " +
                    "parcelas, desconto, condicao, recebido, troco, troca, vale, defeito, terminal, total, txID";
                string sqlWhere = string.Empty;
                string sqlFrom = " From vales ";

                sqlWhere = MontarParametrosSQL(sqlWhere, dados.controle, "controle");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoVenda();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dVenda();
                            item.controle = (int)RetornarInteiro(row["controle"]);
                            item.usuarioId = (int)RetornarInteiro(row["usuarioId"]);
                            item.clienteId = (int)RetornarInteiro(row["clienteId"]);
                            item.Vendedor = RetornarTexto(row["vendedor"]);
                            item.Data = RetornarDataValida(row["data"].ToString());
                            item.Dinheiro = (decimal)RetornarDecimal(row["dinheiro"]);
                            item.Cheque = (decimal)RetornarDecimal(row["cheque"]);
                            item.ChequePre = (decimal)RetornarDecimal(row["chequepre"]);
                            item.CartaoDebito = (decimal)RetornarDecimal(row["cartaodebito"]);
                            item.CartaoCredito = (decimal)RetornarDecimal(row["cartaocredito"]);
                            item.Crediario = (decimal)RetornarDecimal(row["crediario"]);
                            item.Parcelas = (int)RetornarInteiro(row["parcelas"]);
                            item.Desconto = (decimal)RetornarDecimal(row["desconto"]);
                            item.Condicao = (int)RetornarInteiro(row["condicao"]);
                            item.Recebido = (decimal)RetornarDecimal(row["recebido"]);
                            item.Troco = (decimal)RetornarDecimal(row["troco"]);
                            item.Troca = (decimal)RetornarDecimal(row["troca"]);
                            item.Vale = (decimal)RetornarDecimal(row["vale"]);
                            item.Defeito = (decimal)RetornarDecimal(row["defeito"]);
                            item.Terminal = RetornarTexto(row["terminal"]);
                            item.Total = (decimal)RetornarDecimal(row["total"]);
                            item.TXID = RetornarTexto(row["txID"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public dVenda ConsultarUltimaVenda(int produtos_cid)
        {
            dVenda retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " SELECT v.*, vp.valor as valorProduto, p.valorCompra as valorCusto ";
                string sqlWhere = string.Empty;
                string sqlFrom = " FROM vendasprodutos vp " +
                    " INNER JOIN vendas v ON v.controle = vp.controle " +
                    " INNER JOIN produtos p ON p.cid = vp.produto ";
                string sqlSelect2 = " ORDER BY v.data DESC LIMIT 1 ";

                sqlWhere = MontarParametrosSQL(sqlWhere, produtos_cid, "vp.produto");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " " + sqlSelect2);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new dVenda();
                        DataRow row = dt.Rows[0];
                        retorno.controle = (int)RetornarInteiro(row["controle"]);
                        retorno.usuarioId = (int)RetornarInteiro(row["usuarioId"]);
                        retorno.clienteId = (int)RetornarInteiro(row["clienteId"]);
                        retorno.Data = RetornarDataValida(row["data"].ToString());
                        retorno.Dinheiro = (decimal)RetornarDecimal(row["dinheiro"]);
                        retorno.Cheque = (decimal)RetornarDecimal(row["cheque"]);
                        retorno.ChequePre = (decimal)RetornarDecimal(row["chequepre"]);
                        retorno.CartaoDebito = (decimal)RetornarDecimal(row["cartaodebito"]);
                        retorno.CartaoCredito = (decimal)RetornarDecimal(row["cartaocredito"]);
                        retorno.Crediario = (decimal)RetornarDecimal(row["crediario"]);
                        retorno.Parcelas = (int)RetornarInteiro(row["parcelas"]);
                        retorno.Desconto = (decimal)RetornarDecimal(row["desconto"]);
                        retorno.Condicao = (int)RetornarInteiro(row["condicao"]);
                        retorno.Recebido = (decimal)RetornarDecimal(row["recebido"]);
                        retorno.Troco = (decimal)RetornarDecimal(row["troco"]);
                        retorno.Troca = (decimal)RetornarDecimal(row["troca"]);
                        retorno.Vale = (decimal)RetornarDecimal(row["vale"]);
                        retorno.Defeito = (decimal)RetornarDecimal(row["defeito"]);
                        retorno.Terminal = RetornarTexto(row["terminal"]);
                        retorno.Total = (decimal)RetornarDecimal(row["total"]);
                        retorno.valorProduto = (decimal)RetornarDecimal(row["valorProduto"]);
                        retorno.valorCusto = (decimal)RetornarDecimal(row["valorCusto"]);
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em ConsultarUltimaVenda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int ConsultarMax()
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select MAX(controle) as controle";
                string sqlFrom = " From vendas ";
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                            retorno = row["controle"] == DBNull.Value ? 0 : (int)RetornarInteiro(row["controle"]);
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em ConsultarMax Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dVenda dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " vendas (controle, usuarioId, clienteId, data, dinheiro, cheque, " +
                    "chequePre, cartaoDebito, cartaoCredito, crediario, crediariopagamento, " +
                    "parcelas, desconto, condicao, recebido, troco, troca, " +
                    "vale, valeEmitido, defeito, retirada, terminal, ordemServico, vendedor, caixa, total, Original, txID ) " +
                    " VALUES (" +
                    PersistirInteiro(dados.controle) + "," +
                    PersistirTexto(dados.usuarioId.ToString()) + "," +
                    PersistirTexto(dados.clienteId.ToString()) + "," +
                    PersistirDataHora(dados.Data) + "," +
                    PersistirDecimal(dados.Dinheiro) + "," +
                    PersistirDecimal(dados.Cheque) + "," +
                    PersistirDecimal(dados.ChequePre) + "," +
                    PersistirDecimal(dados.CartaoDebito) + "," +
                    PersistirDecimal(dados.CartaoCredito) + "," +
                    PersistirDecimal(dados.Crediario) + "," +
                    PersistirDecimal(dados.CrediarioPagamento) + "," +
                    PersistirInteiro(dados.Parcelas) + "," +
                    PersistirDecimal(dados.Desconto) + "," +
                    PersistirInteiro(dados.Condicao) + "," +
                    PersistirDecimal(dados.Recebido) + "," +
                    PersistirDecimal(dados.Troco) + "," +
                    PersistirDecimal(dados.Troca) + "," +
                    PersistirDecimal(dados.Vale) + "," +
                    PersistirDecimal(dados.ValeEmitido) + "," +
                    PersistirDecimal(dados.Defeito) + "," +
                    PersistirDecimal(dados.Retirada) + "," +
                    PersistirTexto(dados.Terminal) + "," +
                    PersistirTexto(dados.ordemServicoId) + "," +
                    PersistirTexto(dados.Vendedor) + "," +
                    PersistirTexto(dados.Caixa) + "," +
                    PersistirDecimal(dados.Total) + "," +
                    PersistirDecimal(dados.Pix) + "," +
                    PersistirTexto(dados.TXID) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int IncluirVale(dVenda dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " vales (usuarioId, clienteId, data, dinheiro, cheque, " +
                    "chequePre, cartaoDebito, cartaoCredito, crediario, crediariopagamento, " +
                    "parcelas, desconto, condicao, recebido, troco, troca, " +
                    "vale, valeEmitido, defeito, retirada, terminal, vendedor, caixa, total, Original ) " +
                    " VALUES (" +
                    PersistirTexto(dados.usuarioId.ToString()) + "," +
                    PersistirTexto(dados.clienteId.ToString()) + "," +
                    PersistirDataHora(dados.Data) + "," +
                    PersistirDecimal(dados.Dinheiro) + "," +
                    PersistirDecimal(dados.Cheque) + "," +
                    PersistirDecimal(dados.ChequePre) + "," +
                    PersistirDecimal(dados.CartaoDebito) + "," +
                    PersistirDecimal(dados.CartaoCredito) + "," +
                    PersistirDecimal(dados.Crediario) + "," +
                    PersistirDecimal(dados.CrediarioPagamento) + "," +
                    PersistirInteiro(dados.Parcelas) + "," +
                    PersistirDecimal(dados.Desconto) + "," +
                    PersistirInteiro(dados.Condicao) + "," +
                    PersistirDecimal(dados.Recebido) + "," +
                    PersistirDecimal(dados.Troco) + "," +
                    PersistirDecimal(dados.Troca) + "," +
                    PersistirDecimal(dados.Vale) + "," +
                    PersistirDecimal(dados.ValeEmitido) + "," +
                    PersistirDecimal(dados.Defeito) + "," +
                    PersistirDecimal(dados.Retirada) + "," +
                    PersistirTexto(dados.Terminal) + "," +
                    PersistirTexto(dados.Vendedor) + "," +
                    PersistirTexto(dados.Caixa) + "," +
                    PersistirDecimal(dados.Total) + "," +
                    PersistirDecimal(dados.Pix) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Vale [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int IncluirnNF(dBasennf dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " basennf (chnfe) " +
                    " VALUES (" + PersistirTexto(dados.chnfe) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int IncluirCrediarioPagamento(dVenda dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " credpag (usuarioId, clienteId, data, dinheiro, cheque, " +
                    "chequePre, cartaoDebito, cartaoCredito, crediario, crediariopagamento, " +
                    "parcelas, desconto, condicao, recebido, troco, troca, " +
                    "vale, valeEmitido, defeito, retirada, terminal, vendedor, caixa, total, txID,  Original ) " +
                    " VALUES (" +
                    PersistirTexto(dados.usuarioId.ToString()) + "," +
                    PersistirTexto(dados.clienteId.ToString()) + "," +
                    PersistirDataHora(dados.Data) + "," +
                    PersistirDecimal(dados.Dinheiro) + "," +
                    PersistirDecimal(dados.Cheque) + "," +
                    PersistirDecimal(dados.ChequePre) + "," +
                    PersistirDecimal(dados.CartaoDebito) + "," +
                    PersistirDecimal(dados.CartaoCredito) + "," +
                    PersistirDecimal(dados.Crediario) + "," +
                    PersistirDecimal(dados.CrediarioPagamento) + "," +
                    PersistirInteiro(dados.Parcelas) + "," +
                    PersistirDecimal(dados.Desconto) + "," +
                    PersistirInteiro(dados.Condicao) + "," +
                    PersistirDecimal(dados.Recebido) + "," +
                    PersistirDecimal(dados.Troco) + "," +
                    PersistirDecimal(dados.Troca) + "," +
                    PersistirDecimal(dados.Vale) + "," +
                    PersistirDecimal(dados.ValeEmitido) + "," +
                    PersistirDecimal(dados.Defeito) + "," +
                    PersistirDecimal(dados.Retirada) + "," +
                    PersistirTexto(dados.Terminal) + "," +
                    PersistirTexto(dados.Vendedor) + "," +
                    PersistirTexto(dados.Caixa) + "," +
                    PersistirDecimal(dados.Total) + "," +
                    PersistirTexto(dados.TXID) + "," +
                    PersistirDecimal(dados.Pix) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Vale [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dVenda dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE vendas SET " +
                    " usuarioId = " + PersistirTexto(dados.usuarioId.ToString()) + "," +
                    " clienteId = " + PersistirTexto(dados.clienteId.ToString()) + "," +
                    " data = " + PersistirData(dados.Data) + "," +
                    " dinheiro = " + PersistirDecimal(dados.Dinheiro) + "," +
                    " cheque = " + PersistirDecimal(dados.Cheque) + "," +
                    " chequepre = " + PersistirDecimal(dados.ChequePre) + "," +
                    " cartaodebito = " + PersistirDecimal(dados.CartaoDebito) + "," +
                    " cartaocredito = " + PersistirDecimal(dados.CartaoCredito) + "," +
                    " crediario = " + PersistirDecimal(dados.Crediario) + "," +
                    " parcelas = " + PersistirInteiro(dados.Parcelas) + "," +
                    " desconto = " + PersistirDecimal(dados.Desconto) + "," +
                    " condicao = " + PersistirInteiro(dados.Condicao) + "," +
                    " recebido = " + PersistirDecimal(dados.Recebido) + "," +
                    " troco = " + PersistirDecimal(dados.Troco) + "," +
                    " troca = " + PersistirDecimal(dados.Troca) + "," +
                    " vale = " + PersistirDecimal(dados.Vale) + "," +
                    " defeito = " + PersistirDecimal(dados.Defeito) + "," +
                    " ordemservico = " + PersistirTexto(dados.ordemServicoId) + "," +
                    " terminal = " + PersistirTexto(dados.Terminal) +
                    " total = " + PersistirDecimal(dados.Total) +
                    " txID = " + PersistirTexto(dados.TXID) +
                    " WHERE " +
                    " controle = " + dados.controle.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(string controle, string chave)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE vendas SET " +
                    " chave = " + PersistirTexto(chave) +
                    " WHERE " +
                    " controle = " + controle.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int AlterarBaseNnf(dBasennf dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE basennf SET " +
                    " chnfe = " + PersistirTexto(dados.chnfe) +
                    " WHERE " +
                    " seqNFe = " + PersistirTexto(dados.SeqNFe.ToString());
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar basennf [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dVenda dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM vendas " +
                    " WHERE controle = " + dados.controle.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int ExcluirVale(dVenda dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM vales " +
                    " WHERE controle = " + dados.controle.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Vale [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoVenda ConsultarFechamento(dVenda dados)
        {
            ColecaoVenda retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select controle, usuarioId, clienteId, data, dinheiro, cheque, " +
                    "chequePre, cartaoDebito, cartaoCredito, crediario, vendedor, " +
                    "parcelas, desconto, condicao, recebido, troco, troca, vale, defeito, terminal, total, ordemservico, txID, Original ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From vendas ";

                sqlWhere = sqlWhere + " data between '" + FormatarDataUniversal(dados.Data.ToString()) + "' AND '" + FormatarDataUniversal(dados.DataFim.ToString()) + "'";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.Terminal, "terminal");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoVenda();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dVenda();
                            item.controle = (int)RetornarInteiro(row["controle"]);
                            item.usuarioId = (int)RetornarInteiro(row["usuarioId"]);
                            item.clienteId = (int)RetornarInteiro(row["clienteId"]);
                            item.Vendedor = RetornarTexto(row["vendedor"]);
                            item.Data = RetornarDataValida(row["data"].ToString());
                            item.Dinheiro = (decimal)RetornarDecimal(row["dinheiro"]);
                            item.Cheque = (decimal)RetornarDecimal(row["cheque"]);
                            item.ChequePre = (decimal)RetornarDecimal(row["chequepre"]);
                            item.CartaoDebito = (decimal)RetornarDecimal(row["cartaodebito"]);
                            item.CartaoCredito = (decimal)RetornarDecimal(row["cartaocredito"]);
                            item.Crediario = (decimal)RetornarDecimal(row["crediario"]);
                            item.Parcelas = (int)RetornarInteiro(row["parcelas"]);
                            item.Desconto = (decimal)RetornarDecimal(row["desconto"]);
                            item.Condicao = (int)RetornarInteiro(row["condicao"]);
                            item.Recebido = (decimal)RetornarDecimal(row["recebido"]);
                            item.Troco = (decimal)RetornarDecimal(row["troco"]);
                            item.Troca = (decimal)RetornarDecimal(row["troca"]);
                            item.Vale = (decimal)RetornarDecimal(row["vale"]);
                            item.Defeito = (decimal)RetornarDecimal(row["defeito"]);
                            item.Terminal = RetornarTexto(row["terminal"]);
                            item.Total = (decimal)RetornarDecimal(row["total"]);
                            item.ordemServicoId = RetornarTexto(row["ordemservico"]);
                            item.TXID = RetornarTexto(row["txID"]);
                            item.valorOriginal = (decimal)RetornarDecimal(row["Original"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
