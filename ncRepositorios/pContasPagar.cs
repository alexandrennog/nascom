using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;
using nsContasPagar;

namespace ncPersistencia.nsContasPagar
{
    public class pContasPagar : RepositorioBase, IpContasPagar
    {
        public ColecaoContasPagar Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dContasPagar>(
                        "SELECT cid, descricao, valor, dataEmissao, dataVencimento, dataPagamento, situacao, fornecedor FROM ContasPagar").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoContasPagar();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar ContasPagar [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoContasPagar Consultar(dContasPagar dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != null && dados.cid != 0) { conditions.Add("cid=@cid"); p.Add("cid", dados.cid); }
                    if (!string.IsNullOrEmpty(dados.observacao)) { conditions.Add("descricao=@descricao"); p.Add("descricao", dados.observacao); }
                    if (dados.valor != null && dados.valor != 0) { conditions.Add("valor=@valor"); p.Add("valor", dados.valor); }
                    if (!string.IsNullOrEmpty(dados.dataEmissao)) { conditions.Add("dataEmissao=@dataEmissao"); p.Add("dataEmissao", dados.dataEmissao); }
                    if (!string.IsNullOrEmpty(dados.dataVencimento)) { conditions.Add("dataVencimento=@dataVencimento"); p.Add("dataVencimento", dados.dataVencimento); }
                    if (!string.IsNullOrEmpty(dados.dataPagamento)) { conditions.Add("dataPagamento=@dataPagamento"); p.Add("dataPagamento", dados.dataPagamento); }
                    if (dados.pago.HasValue && dados.pago.Value)
                    {
                        conditions.Add("situacao=@situacao");
                        p.Add("situacao", dados.pago);
                    }
                    if (dados.fornecedor_cid != null && dados.fornecedor_cid != 0)
                    {
                        conditions.Add("fornecedor=@fornecedor");
                        p.Add("fornecedor", dados.fornecedor_cid);
                    }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, descricao, valor, dataEmissao, dataVencimento, dataPagamento, situacao, fornecedor FROM ContasPagar {where}";
                    var lista = conn.Query<dContasPagar>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoContasPagar();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ContasPagar [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dContasPagar dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(
                        "INSERT INTO ContasPagar (descricao, valor, dataEmissao, dataVencimento, dataPagamento, situacao, fornecedor) " +
                        "VALUES (@descricao, @valor, @dataEmissao, @dataVencimento, @dataPagamento, @situacao, @fornecedor)",
                        new {
                            descricao = dados.observacao, valor = dados.valor, dataEmissao = dados.dataEmissao,
                            dataVencimento = dados.dataVencimento, dataPagamento = dados.dataPagamento,
                            situacao = dados.pago, fornecedor = dados.fornecedor_cid
                        });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir ContasPagar [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Importar(dContasPagar dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(
                        "INSERT INTO ContasPagar (cid, descricao, valor, dataEmissao, dataVencimento, dataPagamento, situacao, fornecedor) " +
                        "VALUES (@cid, @descricao, @valor, @dataEmissao, @dataVencimento, @dataPagamento, @situacao, @fornecedor)",
                        new {
                            cid = dados.cid, descricao = dados.observacao, valor = dados.valor,
                            dataEmissao = dados.dataEmissao, dataVencimento = dados.dataVencimento,
                            dataPagamento = dados.dataPagamento, situacao = dados.pago, fornecedor = dados.fornecedor_cid
                        });
                    return 1;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Importar ContasPagar [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dContasPagar dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute(
                        "UPDATE ContasPagar SET descricao=@descricao, valor=@valor, dataEmissao=@dataEmissao, " +
                        "dataVencimento=@dataVencimento, dataPagamento=@dataPagamento, situacao=@situacao, fornecedor=@fornecedor " +
                        "WHERE cid=@cid",
                        new {
                            descricao = dados.observacao, valor = dados.valor, dataEmissao = dados.dataEmissao,
                            dataVencimento = dados.dataVencimento, dataPagamento = dados.dataPagamento,
                            situacao = dados.pago, fornecedor = dados.fornecedor_cid, cid = dados.cid
                        });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar ContasPagar [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dContasPagar dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM ContasPagar WHERE cid=@cid", new { cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir ContasPagar [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
