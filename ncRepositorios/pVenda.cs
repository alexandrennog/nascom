using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;
using nsCurvaABC;
using nsVenda;

namespace ncPersistencia.nsVenda
{
    public class pVenda : RepositorioBase, IpVenda
    {
        private const string SelectVenda = @"SELECT controle, usuarioId, clienteId, data AS Data, dinheiro AS Dinheiro, cheque AS Cheque,
            chequePre AS ChequePre, cartaoDebito AS CartaoDebito, cartaoCredito AS CartaoCredito, crediario AS Crediario,
            parcelas AS Parcelas, desconto AS Desconto, condicao AS Condicao, recebido AS Recebido, troco AS Troco, troca AS Troca,
            vale AS Vale, defeito AS Defeito, terminal AS Terminal, total AS Total, Original AS Pix, txID AS TXID";

        public ColecaoVenda Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dVenda>(
                        SelectVenda + " FROM Vendas").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoVenda();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaodVendasNfe ListarVendasNfe(string dataIni, string dataFim)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var p = new DynamicParameters();
                    p.Add("dataIni", dataIni);
                    p.Add("dataFim", dataFim);
                    var sql = "SELECT SUBSTRING(chNFe, 25, 9) AS Cupom, DATE_FORMAT(dhrecbto, '%d/%m/%Y') AS DataVenda, total AS Valor FROM nascomercio.vendas INNER JOIN nascomercio.infprot ON chNFe = chave AND cstat = 100 WHERE chave IS NOT NULL AND data >= @dataIni AND data <= @dataFim";
                    var lista = conn.Query<dVendasNfe>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaodVendasNfe();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ListarVendasNfe Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaodVendasABC ListarVendasABC(string dataIni, string dataFim, string tipo)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    string resultTable;
                    if (tipo == "V")
                    {
                        conn.Execute($"call sp_curva_abc_fornecedores('{dataIni}','{dataFim}')", commandTimeout: 300);
                        resultTable = "ranking_resultado_valor";
                    }
                    else
                    {
                        conn.Execute($"call sp_curva_abc_fornecedores_quantidade('{dataIni}','{dataFim}')", commandTimeout: 300);
                        resultTable = "ranking_resultado_quantidade";
                    }
                    var lista = conn.Query<dCurvaAbc>($"SELECT data_inicio AS PeriodoIni, data_fim AS PeriodoFim, fabricante AS Fabricante, valor, individual AS PercReceita, acumulado AS PercAcumulado, classificacao_abc AS ClasseAbc, estrategia_sugerida AS Estrategia FROM {resultTable}").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaodVendasABC();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ListarVendasABC Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVenda Consultar(dVenda dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.controle != 0) { conditions.Add("controle=@controle"); p.Add("controle", dados.controle); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $@"{SelectVenda}, vendedor AS Vendedor, ordemservico AS ordemServicoId, chave AS Chave FROM vendas {where}";
                    var lista = conn.Query<dVenda>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoVenda();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVenda ConsultarPix(dVenda dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    conditions.Add("data BETWEEN @dataIni AND @dataFim");
                    p.Add("dataIni", dados.Data.ToString("yyyy-MM-dd"));
                    p.Add("dataFim", dados.DataFim.ToString("yyyy-MM-dd"));
                    if (!string.IsNullOrEmpty(dados.Caixa)) { conditions.Add("caixa=@Caixa"); p.Add("Caixa", dados.Caixa); }
                    conditions.Add("Original > 0");
                    var where = "WHERE " + string.Join(" AND ", conditions);
                    var sql = $@"{SelectVenda}, vendedor AS Vendedor, ordemservico AS ordemServicoId FROM vendas {where}";
                    var lista = conn.Query<dVenda>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoVenda();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVendasPorVendedor ConsultarVendasPorVendedor(dVendasPorVendedor dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    string sql;
                    DynamicParameters p = new DynamicParameters();
                    string dataIni = dados.Data.ToString("yyyy-MM-dd") + " 00:00:00";
                    string dataFim = dados.DataFim.ToString("yyyy-MM-dd") + " 00:00:00";
                    if (dados.Nome == "Todos")
                        sql = $"CALL sp_recuperavendas(null, '{dataIni}', '{dataFim}')";
                    else
                        sql = $"CALL sp_recuperavendas('{dados.Nome}', '{dataIni}', '{dataFim}')";
                    var lista = conn.Query<dVendasPorVendedor>(sql).AsList();
                    if (lista.Count == 0 || Convert.ToInt32(lista[0].TotalVendas) <= -1) return null;
                    var retorno = new ColecaoVendasPorVendedor();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVendasPorVendedor ConsultarVendasDaLoja(dVendasPorVendedor dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    string dataIni = dados.Data.ToString("yyyy-MM-dd") + " 00:00:00";
                    string dataFim = dados.DataFim.ToString("yyyy-MM-dd") + " 00:00:00";
                    var lista = conn.Query<dVendasPorVendedor>($"CALL sp_recuperavendasloja('{dataIni}', '{dataFim}')").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoVendasPorVendedor();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVenda ConsultarCrediarioPix(dVenda dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    conditions.Add("data BETWEEN @dataIni AND @dataFim");
                    p.Add("dataIni", dados.Data.ToString("yyyy-MM-dd"));
                    p.Add("dataFim", dados.DataFim.ToString("yyyy-MM-dd"));
                    if (!string.IsNullOrEmpty(dados.Caixa)) { conditions.Add("caixa=@Caixa"); p.Add("Caixa", dados.Caixa); }
                    var where = "WHERE " + string.Join(" AND ", conditions);
                    var sql = $@"SELECT controle, usuarioId, clienteId, data AS Data, dinheiro AS Dinheiro, cheque AS Cheque,
                        chequePre AS ChequePre, cartaoDebito AS CartaoDebito, cartaoCredito AS CartaoCredito, crediario AS Crediario,
                        crediariopagamento AS CrediarioPagamento, parcelas AS Parcelas, desconto AS Desconto, condicao AS Condicao,
                        recebido AS Recebido, troco AS Troco, troca AS Troca, vale AS Vale, defeito AS Defeito, terminal AS Terminal,
                        total AS Total, Original AS Pix, txID AS TXID FROM credpag {where}";
                    var lista = conn.Query<dVenda>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoVenda();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVenda ConsultarTroca(dVenda dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.controle != 0) { conditions.Add("controle=@controle"); p.Add("controle", dados.controle); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $@"SELECT controle, usuarioId, clienteId, data AS Data, dinheiro AS Dinheiro, cheque AS Cheque,
                        chequePre AS ChequePre, cartaoDebito AS CartaoDebito, cartaoCredito AS CartaoCredito, crediario AS Crediario,
                        vendedor AS Vendedor, parcelas AS Parcelas, desconto AS Desconto, condicao AS Condicao, recebido AS Recebido,
                        troco AS Troco, troca AS Troca, vale AS Vale, defeito AS Defeito, terminal AS Terminal, total AS Total, txID AS TXID
                        FROM vales {where}";
                    var lista = conn.Query<dVenda>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoVenda();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public dVenda ConsultarUltimaVenda(int produtos_cid)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var p = new DynamicParameters();
                    p.Add("produto", produtos_cid);
                    var sql = @"SELECT v.controle, v.usuarioId, v.clienteId, v.data AS Data, v.dinheiro AS Dinheiro, v.cheque AS Cheque,
                        v.chequePre AS ChequePre, v.cartaoDebito AS CartaoDebito, v.cartaoCredito AS CartaoCredito, v.crediario AS Crediario,
                        v.parcelas AS Parcelas, v.desconto AS Desconto, v.condicao AS Condicao, v.recebido AS Recebido, v.troco AS Troco,
                        v.troca AS Troca, v.vale AS Vale, v.defeito AS Defeito, v.terminal AS Terminal, v.total AS Total,
                        vp.valor AS valorProduto, p.valorCompra AS valorCusto
                        FROM vendasprodutos vp
                        INNER JOIN vendas v ON v.controle = vp.controle
                        INNER JOIN produtos p ON p.cid = vp.produto
                        WHERE vp.produto=@produto
                        ORDER BY v.data DESC LIMIT 1";
                    return conn.QueryFirstOrDefault<dVenda>(sql, p);
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarUltimaVenda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ConsultarMax()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.QueryFirstOrDefault<int?>("SELECT MAX(controle) FROM vendas") ?? 0;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarMax Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dVenda dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(@"INSERT INTO vendas (controle, usuarioId, clienteId, data, dinheiro, cheque, chequePre, cartaoDebito, cartaoCredito, crediario, crediariopagamento,
                        parcelas, desconto, condicao, recebido, troco, troca, vale, valeEmitido, defeito, retirada, terminal, ordemServico, vendedor, caixa, total, Original, txID)
                        VALUES (@controle, @usuarioId, @clienteId, @Data, @Dinheiro, @Cheque, @ChequePre, @CartaoDebito, @CartaoCredito, @Crediario, @CrediarioPagamento,
                        @Parcelas, @Desconto, @Condicao, @Recebido, @Troco, @Troca, @Vale, @ValeEmitido, @Defeito, @Retirada, @Terminal, @ordemServicoId, @Vendedor, @Caixa, @Total, @Pix, @TXID)",
                        new { dados.controle, dados.usuarioId, dados.clienteId, dados.Data, dados.Dinheiro, dados.Cheque, dados.ChequePre, dados.CartaoDebito, dados.CartaoCredito, dados.Crediario, dados.CrediarioPagamento,
                            dados.Parcelas, dados.Desconto, dados.Condicao, dados.Recebido, dados.Troco, dados.Troca, dados.Vale, dados.ValeEmitido, dados.Defeito, dados.Retirada, dados.Terminal, dados.ordemServicoId, dados.Vendedor, dados.Caixa, dados.Total, dados.Pix, dados.TXID });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int IncluirVale(dVenda dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(@"INSERT INTO vales (usuarioId, clienteId, data, dinheiro, cheque, chequePre, cartaoDebito, cartaoCredito, crediario, crediariopagamento,
                        parcelas, desconto, condicao, recebido, troco, troca, vale, valeEmitido, defeito, retirada, terminal, vendedor, caixa, total, Original)
                        VALUES (@usuarioId, @clienteId, @Data, @Dinheiro, @Cheque, @ChequePre, @CartaoDebito, @CartaoCredito, @Crediario, @CrediarioPagamento,
                        @Parcelas, @Desconto, @Condicao, @Recebido, @Troco, @Troca, @Vale, @ValeEmitido, @Defeito, @Retirada, @Terminal, @Vendedor, @Caixa, @Total, @Pix)",
                        new { dados.usuarioId, dados.clienteId, dados.Data, dados.Dinheiro, dados.Cheque, dados.ChequePre, dados.CartaoDebito, dados.CartaoCredito, dados.Crediario, dados.CrediarioPagamento,
                            dados.Parcelas, dados.Desconto, dados.Condicao, dados.Recebido, dados.Troco, dados.Troca, dados.Vale, dados.ValeEmitido, dados.Defeito, dados.Retirada, dados.Terminal, dados.Vendedor, dados.Caixa, dados.Total, dados.Pix });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Vale [" + ToString() + "] - " + ex.Message);
            }
        }

        public int IncluirnNF(dBasennf dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("INSERT INTO basennf (chnfe) VALUES (@chnfe)", new { dados.chnfe });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int IncluirCrediarioPagamento(dVenda dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(@"INSERT INTO credpag (usuarioId, clienteId, data, dinheiro, cheque, chequePre, cartaoDebito, cartaoCredito, crediario, crediariopagamento,
                        parcelas, desconto, condicao, recebido, troco, troca, vale, valeEmitido, defeito, retirada, terminal, vendedor, caixa, total, txID, Original)
                        VALUES (@usuarioId, @clienteId, @Data, @Dinheiro, @Cheque, @ChequePre, @CartaoDebito, @CartaoCredito, @Crediario, @CrediarioPagamento,
                        @Parcelas, @Desconto, @Condicao, @Recebido, @Troco, @Troca, @Vale, @ValeEmitido, @Defeito, @Retirada, @Terminal, @Vendedor, @Caixa, @Total, @TXID, @Pix)",
                        new { dados.usuarioId, dados.clienteId, dados.Data, dados.Dinheiro, dados.Cheque, dados.ChequePre, dados.CartaoDebito, dados.CartaoCredito, dados.Crediario, dados.CrediarioPagamento,
                            dados.Parcelas, dados.Desconto, dados.Condicao, dados.Recebido, dados.Troco, dados.Troca, dados.Vale, dados.ValeEmitido, dados.Defeito, dados.Retirada, dados.Terminal, dados.Vendedor, dados.Caixa, dados.Total, dados.TXID, dados.Pix });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Vale [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dVenda dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute(@"UPDATE vendas SET usuarioId=@usuarioId, clienteId=@clienteId, data=@Data, dinheiro=@Dinheiro, cheque=@Cheque,
                        chequepre=@ChequePre, cartaodebito=@CartaoDebito, cartaocredito=@CartaoCredito, crediario=@Crediario, parcelas=@Parcelas,
                        desconto=@Desconto, condicao=@Condicao, recebido=@Recebido, troco=@Troco, troca=@Troca, vale=@Vale, defeito=@Defeito,
                        ordemservico=@ordemServicoId, terminal=@Terminal, total=@Total, txID=@TXID
                        WHERE controle=@controle",
                        new { dados.usuarioId, dados.clienteId, dados.Data, dados.Dinheiro, dados.Cheque, dados.ChequePre, dados.CartaoDebito, dados.CartaoCredito, dados.Crediario,
                            dados.Parcelas, dados.Desconto, dados.Condicao, dados.Recebido, dados.Troco, dados.Troca, dados.Vale, dados.Defeito, dados.ordemServicoId, dados.Terminal, dados.Total, dados.TXID, dados.controle });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(string controle, string chave)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE vendas SET chave=@chave WHERE controle=@controle", new { chave, controle });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int AlterarBaseNnf(dBasennf dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE basennf SET chnfe=@chnfe WHERE seqNFe=@SeqNFe", new { dados.chnfe, dados.SeqNFe });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar basennf [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dVenda dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM vendas WHERE controle=@controle", new { dados.controle });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirVale(dVenda dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM vales WHERE controle=@controle", new { dados.controle });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Vale [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVenda ConsultarFechamento(dVenda dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    conditions.Add("data BETWEEN @dataIni AND @dataFim");
                    p.Add("dataIni", dados.Data.ToString("yyyy-MM-dd"));
                    p.Add("dataFim", dados.DataFim.ToString("yyyy-MM-dd"));
                    if (!string.IsNullOrEmpty(dados.Terminal)) { conditions.Add("terminal=@Terminal"); p.Add("Terminal", dados.Terminal); }
                    var where = "WHERE " + string.Join(" AND ", conditions);
                    var sql = $@"SELECT controle, usuarioId, clienteId, data AS Data, dinheiro AS Dinheiro, cheque AS Cheque,
                        chequePre AS ChequePre, cartaoDebito AS CartaoDebito, cartaoCredito AS CartaoCredito, crediario AS Crediario,
                        vendedor AS Vendedor, parcelas AS Parcelas, desconto AS Desconto, condicao AS Condicao, recebido AS Recebido,
                        troco AS Troco, troca AS Troca, vale AS Vale, defeito AS Defeito, terminal AS Terminal, total AS Total,
                        ordemservico AS ordemServicoId, txID AS TXID, Original AS valorOriginal FROM vendas {where}";
                    var lista = conn.Query<dVenda>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoVenda();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
