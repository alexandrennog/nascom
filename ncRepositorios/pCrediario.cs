using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;
using nsCrediario;

namespace ncPersistencia.nsCrediario
{
    public class pCrediario : RepositorioBase, IpCrediario
    {
        public ColecaoCrediario Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dCrediario>(
                        "SELECT cid, controle, usuarioId, clienteId, parcelas AS Parcelas, valortotal AS ValorTotal, valorpago AS ValorPago, saldodevedor AS SaldoDevedor, dataVenda AS DataVenda FROM crediario").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoCrediario();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Crediário [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ConsultarMax()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.QueryFirstOrDefault<int?>("SELECT MAX(controle) FROM crediario") ?? 0;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarMax Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoCrediario Consultar(dCrediario dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != 0) { conditions.Add("cid=@cid"); p.Add("cid", dados.cid); }
                    if (dados.controle != 0) { conditions.Add("controle=@controle"); p.Add("controle", dados.controle); }
                    if (dados.usuarioId != 0) { conditions.Add("usuarioId=@usuarioId"); p.Add("usuarioId", dados.usuarioId); }
                    if (dados.clienteId != 0) { conditions.Add("clienteId=@clienteId"); p.Add("clienteId", dados.clienteId); }
                    if (dados.SaldoDevedor > 0.001m) { conditions.Add("saldodevedor > 0.001"); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, controle, usuarioId, clienteId, parcelas AS Parcelas, valortotal AS ValorTotal, valorpago AS ValorPago, saldodevedor AS SaldoDevedor, dataVenda AS DataVenda FROM crediario {where} ORDER BY YEAR(dataVenda), MONTH(dataVenda)";
                    var lista = conn.Query<dCrediario>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoCrediario();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Crediario[" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dCrediario dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("INSERT INTO crediario (controle, usuarioId, clienteId, observacao, parcelas, valortotal, valorpago, saldodevedor, dataVenda, loja_cid, terminal) VALUES (@controle, @usuarioId, @clienteId, @NotaFiscal, @Parcelas, @ValorTotal, @ValorPago, @SaldoDevedor, @DataVenda, @LojaId, @Terminal)",
                        new { dados.controle, dados.usuarioId, dados.clienteId, dados.NotaFiscal, dados.Parcelas, dados.ValorTotal, dados.ValorPago, dados.SaldoDevedor, dados.DataVenda, dados.LojaId, dados.Terminal });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dCrediario dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE crediario SET controle=@controle, usuarioId=@usuarioId, clienteId=@clienteId, parcelas=@Parcelas, valortotal=@ValorTotal, valorpago=@ValorPago, dataVenda=@DataVenda, saldodevedor=@SaldoDevedor WHERE cid=@cid",
                        new { dados.controle, dados.usuarioId, dados.clienteId, dados.Parcelas, dados.ValorTotal, dados.ValorPago, dados.DataVenda, dados.SaldoDevedor, dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int AlterarControle(dCrediario dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE crediario SET controle=@controle WHERE controle=@cid",
                        new { dados.controle, dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dCrediario dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM crediario WHERE cid=@cid", new { dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirParcelas(dCrediario dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM parcelas WHERE crediarioid=@cid", new { dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir crediario [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
