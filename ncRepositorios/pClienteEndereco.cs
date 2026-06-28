using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum;
using ncModelos;

namespace ncRepositorios
{
    public class pClienteEndereco : RepositorioBase, IpClienteEndereco
    {
        public ColecaoClienteEndereco Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dClienteEndereco>(
                        "SELECT logradouro, numero, complemento, cidade, estado_cid, cep, " +
                        "dataInclusao, tipoResidencia, bairro, tipoEndereco, cliente_cid FROM clienteenderecos").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoClienteEndereco();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Cliente - Endereço [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoClienteEndereco Consultar(dClienteEndereco dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (!string.IsNullOrEmpty(dados.logradouro)) { conditions.Add("c.logradouro=@logradouro"); p.Add("logradouro", dados.logradouro); }
                    if (dados.numero != null && dados.numero != 0) { conditions.Add("c.numero=@numero"); p.Add("numero", dados.numero); }
                    if (!string.IsNullOrEmpty(dados.complemento)) { conditions.Add("c.complemento=@complemento"); p.Add("complemento", dados.complemento); }
                    if (!string.IsNullOrEmpty(dados.cidade)) { conditions.Add("c.cidade=@cidade"); p.Add("cidade", dados.cidade); }
                    if (dados.estado_cid != null && dados.estado_cid != 0) { conditions.Add("c.estado_cid=@estado_cid"); p.Add("estado_cid", dados.estado_cid); }
                    if (dados.cep != null && dados.cep != 0) { conditions.Add("c.cep=@cep"); p.Add("cep", dados.cep); }
                    if (!string.IsNullOrEmpty(dados.dataInclusao)) { conditions.Add("c.dataInclusao=@dataInclusao"); p.Add("dataInclusao", dados.dataInclusao); }
                    if (!string.IsNullOrEmpty(dados.tipoResidencia)) { conditions.Add("c.tipoResidencia=@tipoResidencia"); p.Add("tipoResidencia", dados.tipoResidencia); }
                    if (!string.IsNullOrEmpty(dados.bairro)) { conditions.Add("c.bairro=@bairro"); p.Add("bairro", dados.bairro); }
                    if (!string.IsNullOrEmpty(dados.tipoEndereco)) { conditions.Add("c.tipoEndereco=@tipoEndereco"); p.Add("tipoEndereco", dados.tipoEndereco); }
                    if (dados.cliente_cid != null && dados.cliente_cid != 0) { conditions.Add("c.cliente_cid=@cliente_cid"); p.Add("cliente_cid", dados.cliente_cid); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT c.logradouro, c.numero, c.complemento, c.cidade, c.estado_cid, c.cep, " +
                              $"c.dataInclusao, c.tipoResidencia, c.bairro, c.tipoEndereco, c.cliente_cid, e.sigla AS siglaEstado " +
                              $"FROM clienteenderecos c LEFT OUTER JOIN estados e ON c.estado_cid = e.cid {where}";
                    var lista = conn.Query<dClienteEndereco>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoClienteEndereco();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Cliente - Endereço [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dClienteEndereco dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(
                        "INSERT INTO clienteenderecos (logradouro, numero, complemento, cidade, estado_cid, cep, " +
                        "dataInclusao, tipoResidencia, bairro, tipoEndereco, cliente_cid) " +
                        "VALUES (@logradouro, @numero, @complemento, @cidade, @estado_cid, @cep, " +
                        "@dataInclusao, @tipoResidencia, @bairro, @tipoEndereco, @cliente_cid)",
                        new {
                            logradouro = dados.logradouro, numero = dados.numero, complemento = dados.complemento,
                            cidade = dados.cidade, estado_cid = dados.estado_cid, cep = dados.cep,
                            dataInclusao = dados.dataInclusao, tipoResidencia = dados.tipoResidencia,
                            bairro = dados.bairro, tipoEndereco = dados.tipoEndereco, cliente_cid = dados.cliente_cid
                        });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Cliente - Endereço [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirPorCliente(int cliente_cid)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM clienteenderecos WHERE cliente_cid=@cliente_cid", new { cliente_cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Cliente - Endereço [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
