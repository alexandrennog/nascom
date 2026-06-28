using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum;
using ncModelos;

namespace ncRepositorios
{
    public class pClienteProfissional : RepositorioBase, IpClienteProfissional
    {
        public ColecaoClienteProfissional Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dClienteProfissional>(
                        "SELECT empresa, logradouro, numero, complemento, cidade, estado_cid, cep, " +
                        "bairro, cliente_cid, ddd, telefone, ramal, dataAdmissao, cargo, salario FROM clienteprofissional").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoClienteProfissional();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Cliente - Profissional [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoClienteProfissional Consultar(dClienteProfissional dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (!string.IsNullOrEmpty(dados.empresa)) { conditions.Add("empresa=@empresa"); p.Add("empresa", dados.empresa); }
                    if (!string.IsNullOrEmpty(dados.logradouro)) { conditions.Add("logradouro=@logradouro"); p.Add("logradouro", dados.logradouro); }
                    if (dados.numero != null && dados.numero != 0) { conditions.Add("numero=@numero"); p.Add("numero", dados.numero); }
                    if (!string.IsNullOrEmpty(dados.complemento)) { conditions.Add("complemento=@complemento"); p.Add("complemento", dados.complemento); }
                    if (!string.IsNullOrEmpty(dados.cidade)) { conditions.Add("cidade=@cidade"); p.Add("cidade", dados.cidade); }
                    if (dados.estado_cid != null && dados.estado_cid != 0) { conditions.Add("estado_cid=@estado_cid"); p.Add("estado_cid", dados.estado_cid); }
                    if (dados.cep != null && dados.cep != 0) { conditions.Add("cep=@cep"); p.Add("cep", dados.cep); }
                    if (!string.IsNullOrEmpty(dados.bairro)) { conditions.Add("bairro=@bairro"); p.Add("bairro", dados.bairro); }
                    if (dados.cliente_cid != null && dados.cliente_cid != 0) { conditions.Add("cliente_cid=@cliente_cid"); p.Add("cliente_cid", dados.cliente_cid); }
                    if (!string.IsNullOrEmpty(dados.ddd)) { conditions.Add("ddd=@ddd"); p.Add("ddd", dados.ddd); }
                    if (!string.IsNullOrEmpty(dados.telefone)) { conditions.Add("telefone=@telefone"); p.Add("telefone", dados.telefone); }
                    if (!string.IsNullOrEmpty(dados.ramal)) { conditions.Add("ramal=@ramal"); p.Add("ramal", dados.ramal); }
                    if (!string.IsNullOrEmpty(dados.dataAdmissao)) { conditions.Add("dataAdmissao=@dataAdmissao"); p.Add("dataAdmissao", dados.dataAdmissao); }
                    if (dados.salario != null && dados.salario != 0) { conditions.Add("salario=@salario"); p.Add("salario", dados.salario); }
                    if (!string.IsNullOrEmpty(dados.cargo)) { conditions.Add("cargo=@cargo"); p.Add("cargo", dados.cargo); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT empresa, logradouro, numero, complemento, cidade, estado_cid, cep, " +
                              $"bairro, cliente_cid, ddd, telefone, ramal, dataAdmissao, cargo, salario FROM clienteprofissional {where}";
                    var lista = conn.Query<dClienteProfissional>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoClienteProfissional();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Cliente - Profissional [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dClienteProfissional dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(
                        "INSERT INTO clienteprofissional (empresa, logradouro, numero, complemento, cidade, estado_cid, cep, " +
                        "bairro, cliente_cid, ddd, telefone, ramal, dataAdmissao, cargo, salario) " +
                        "VALUES (@empresa, @logradouro, @numero, @complemento, @cidade, @estado_cid, @cep, " +
                        "@bairro, @cliente_cid, @ddd, @telefone, @ramal, @dataAdmissao, @cargo, @salario)",
                        new {
                            empresa = dados.empresa, logradouro = dados.logradouro, numero = dados.numero,
                            complemento = dados.complemento, cidade = dados.cidade, estado_cid = dados.estado_cid,
                            cep = dados.cep, bairro = dados.bairro, cliente_cid = dados.cliente_cid,
                            ddd = dados.ddd, telefone = dados.telefone, ramal = dados.ramal,
                            dataAdmissao = dados.dataAdmissao, cargo = dados.cargo, salario = dados.salario
                        });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Cliente - Profissional [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dClienteProfissional dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute(
                        "UPDATE clienteprofissional SET empresa=@empresa, logradouro=@logradouro, numero=@numero, " +
                        "complemento=@complemento, cidade=@cidade, estado_cid=@estado_cid, cep=@cep, bairro=@bairro, " +
                        "ddd=@ddd, telefone=@telefone, ramal=@ramal, cargo=@cargo, dataAdmissao=@dataAdmissao, salario=@salario " +
                        "WHERE cliente_cid=@cliente_cid",
                        new {
                            empresa = dados.empresa, logradouro = dados.logradouro, numero = dados.numero,
                            complemento = dados.complemento, cidade = dados.cidade, estado_cid = dados.estado_cid,
                            cep = dados.cep, bairro = dados.bairro, ddd = dados.ddd, telefone = dados.telefone,
                            ramal = dados.ramal, cargo = dados.cargo, dataAdmissao = dados.dataAdmissao,
                            salario = dados.salario, cliente_cid = dados.cliente_cid
                        });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Cliente - Profissional [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirPorCliente(int cliente_cid)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM clienteprofissional WHERE cliente_cid=@cliente_cid", new { cliente_cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Cliente - Profissional [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
