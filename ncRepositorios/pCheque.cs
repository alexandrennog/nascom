using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;
using nsCheques;

namespace ncPersistencia.nsCheques
{
    public class pCheques : RepositorioBase, IpCheques
    {
        public ColecaoCheques Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dCheques>(
                        "SELECT cid, emitente, valor, dataEmissao, dataDeposito, banco, agencia, conta, numero, baixado FROM cheques").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoCheques();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Cheques [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoCheques Consultar(dCheques dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != null && dados.cid != 0) { conditions.Add("cid=@cid"); p.Add("cid", dados.cid); }
                    if (dados.valor != null && dados.valor != 0) { conditions.Add("valor=@valor"); p.Add("valor", dados.valor); }
                    if (dados.dataEmissao != default(DateTime)) { conditions.Add("dataEmissao=@dataEmissao"); p.Add("dataEmissao", dados.dataEmissao); }
                    if (dados.dataDeposito != default(DateTime)) { conditions.Add("dataDeposito=@dataDeposito"); p.Add("dataDeposito", dados.dataDeposito); }
                    if (!string.IsNullOrEmpty(dados.bancoCodigo)) { conditions.Add("banco=@banco"); p.Add("banco", dados.bancoCodigo); }
                    if (!string.IsNullOrEmpty(dados.agencia)) { conditions.Add("agencia=@agencia"); p.Add("agencia", dados.agencia); }
                    if (!string.IsNullOrEmpty(dados.conta)) { conditions.Add("conta=@conta"); p.Add("conta", dados.conta); }
                    if (!string.IsNullOrEmpty(dados.Numero)) { conditions.Add("numero=@numero"); p.Add("numero", dados.Numero); }
                    if (!string.IsNullOrEmpty(dados.baixado)) { conditions.Add("baixado=@baixado"); p.Add("baixado", dados.baixado); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, emitente, valor, dataEmissao, dataDeposito, banco, agencia, conta, numero, baixado FROM cheques {where}";
                    var lista = conn.Query<dCheques>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoCheques();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Cheques [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dCheques dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(
                        "INSERT INTO cheques (emitente, valor, dataEmissao, dataDeposito, banco, agencia, conta, numero, baixado) " +
                        "VALUES (@emitente, @valor, @dataEmissao, @dataDeposito, @banco, @agencia, @conta, @numero, @baixado)",
                        new {
                            emitente = dados.cid, valor = dados.valor, dataEmissao = dados.dataEmissao,
                            dataDeposito = dados.dataDeposito, banco = dados.bancoCodigo, agencia = dados.agencia,
                            conta = dados.conta, numero = dados.Numero, baixado = dados.baixado
                        });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Cheques [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dCheques dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute(
                        "UPDATE cheques SET emitente=@emitente, valor=@valor, dataEmissao=@dataEmissao, dataDeposito=@dataDeposito, " +
                        "banco=@banco, agencia=@agencia, conta=@conta, numero=@numero, baixado=@baixado WHERE cid=@cid",
                        new {
                            emitente = dados.cid, valor = dados.valor, dataEmissao = dados.dataEmissao,
                            dataDeposito = dados.dataDeposito, banco = dados.bancoCodigo, agencia = dados.agencia,
                            conta = dados.conta, numero = dados.Numero, baixado = dados.baixado, cid = dados.cid
                        });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Cheques [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Baixar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE cheques SET baixado='Sim' WHERE dataDeposito < date(now())");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Baixar Cheques [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dCheques dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM cheques WHERE cid=@cid", new { cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Cheques [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
