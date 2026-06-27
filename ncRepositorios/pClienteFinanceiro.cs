using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;
using nsCliente;

namespace ncPersistencia.nsCliente
{
    public class pClienteFinanceiro : RepositorioBase, IpClienteFinanceiro
    {
        public ColecaoClienteFinanceiro Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dClienteFinanceiro>(
                        "SELECT limite, situacaoCrediario, cliente_cid, " +
                        "banco1, banco2, agencia1, agencia2, conta1, conta2, gerente1, gerente2, referencia1, referencia2, ddd1, ddd2, telefone1, telefone2, observacoes " +
                        "FROM clientefinanceiro").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoClienteFinanceiro();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Cliente - Financeiro [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoClienteFinanceiro Consultar(dClienteFinanceiro dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.limite != null && dados.limite != 0) { conditions.Add("limite=@limite"); p.Add("limite", dados.limite); }
                    if (!string.IsNullOrEmpty(dados.situacaoCrediario)) { conditions.Add("situacaoCrediario=@situacaoCrediario"); p.Add("situacaoCrediario", dados.situacaoCrediario); }
                    if (dados.cliente_cid != null && dados.cliente_cid != 0) { conditions.Add("cliente_cid=@cliente_cid"); p.Add("cliente_cid", dados.cliente_cid); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT limite, situacaoCrediario, cliente_cid, " +
                              $"banco1, banco2, agencia1, agencia2, conta1, conta2, gerente1, gerente2, referencia1, referencia2, ddd1, ddd2, telefone1, telefone2, observacoes " +
                              $"FROM clientefinanceiro {where}";
                    var lista = conn.Query<dClienteFinanceiro>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoClienteFinanceiro();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Cliente - Financeiro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dClienteFinanceiro dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(
                        "INSERT INTO clientefinanceiro (limite, situacaoCrediario, cliente_cid, " +
                        "banco1, banco2, agencia1, agencia2, conta1, conta2, gerente1, gerente2, referencia1, referencia2, ddd1, ddd2, telefone1, telefone2, observacoes) " +
                        "VALUES (@limite, @situacaoCrediario, @cliente_cid, " +
                        "@banco1, @banco2, @agencia1, @agencia2, @conta1, @conta2, @gerente1, @gerente2, @referencia1, @referencia2, @ddd1, @ddd2, @telefone1, @telefone2, @observacoes)",
                        new {
                            limite = dados.limite, situacaoCrediario = dados.situacaoCrediario, cliente_cid = dados.cliente_cid,
                            banco1 = dados.banco1, banco2 = dados.banco2, agencia1 = dados.agencia1, agencia2 = dados.agencia2,
                            conta1 = dados.conta1, conta2 = dados.conta2, gerente1 = dados.gerente1, gerente2 = dados.gerente2,
                            referencia1 = dados.referencia1, referencia2 = dados.referencia2, ddd1 = dados.ddd1, ddd2 = dados.ddd2,
                            telefone1 = dados.telefone1, telefone2 = dados.telefone2, observacoes = dados.observacoes
                        });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Cliente - Financeiro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dClienteFinanceiro dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute(
                        "UPDATE clientefinanceiro SET limite=@limite, situacaoCrediario=@situacaoCrediario, " +
                        "banco1=@banco1, banco2=@banco2, agencia1=@agencia1, agencia2=@agencia2, " +
                        "conta1=@conta1, conta2=@conta2, gerente1=@gerente1, gerente2=@gerente2, " +
                        "referencia1=@referencia1, referencia2=@referencia2, ddd1=@ddd1, ddd2=@ddd2, " +
                        "telefone1=@telefone1, telefone2=@telefone2, observacoes=@observacoes " +
                        "WHERE cliente_cid=@cliente_cid",
                        new {
                            limite = dados.limite, situacaoCrediario = dados.situacaoCrediario,
                            banco1 = dados.banco1, banco2 = dados.banco2, agencia1 = dados.agencia1, agencia2 = dados.agencia2,
                            conta1 = dados.conta1, conta2 = dados.conta2, gerente1 = dados.gerente1, gerente2 = dados.gerente2,
                            referencia1 = dados.referencia1, referencia2 = dados.referencia2, ddd1 = dados.ddd1, ddd2 = dados.ddd2,
                            telefone1 = dados.telefone1, telefone2 = dados.telefone2, observacoes = dados.observacoes,
                            cliente_cid = dados.cliente_cid
                        });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Cliente - Financeiro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirPorCliente(int cliente_cid)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM clientefinanceiro WHERE cliente_cid=@cliente_cid", new { cliente_cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Cliente - Financeiro [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
