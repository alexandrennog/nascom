using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum;
using ncModelos;

namespace ncRepositorios
{
    public class pLoja : RepositorioBase, IpLoja
    {
        public ColecaoLoja Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dLoja>(
                        "SELECT cid, nomeFantasia, logradouro, numero, complemento, bairro, cidade, " +
                        "estado_cid, cep, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao, razaoSocial, " +
                        "spc_codigo_associado, spc_controle_informante, spc_nome_informante, Inscestadual FROM lojas").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoLoja();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Loja [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoLoja Consultar(dLoja dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != null && dados.cid != 0) { conditions.Add("cid=@cid"); p.Add("cid", dados.cid); }
                    if (!string.IsNullOrEmpty(dados.nomeFantasia)) { conditions.Add("nomeFantasia=@nomeFantasia"); p.Add("nomeFantasia", dados.nomeFantasia); }
                    if (!string.IsNullOrEmpty(dados.codigo)) { conditions.Add("codigo=@codigo"); p.Add("codigo", dados.codigo); }
                    if (!string.IsNullOrEmpty(dados.situacao)) { conditions.Add("situacao=@situacao"); p.Add("situacao", dados.situacao); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, nomeFantasia, logradouro, numero, complemento, bairro, cidade, " +
                              $"estado_cid, cep, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao, razaoSocial, " +
                              $"spc_codigo_associado, spc_controle_informante, spc_nome_informante, Inscestadual FROM lojas {where}";
                    var lista = conn.Query<dLoja>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoLoja();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Loja [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dLoja dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(
                        "INSERT INTO lojas (nomeFantasia, logradouro, numero, complemento, bairro, cidade, estado_cid, cep, cnpj, " +
                        "ddd, telefone, ramal, nomeContato, codigo, situacao, razaoSocial, " +
                        "spc_codigo_associado, spc_controle_informante, spc_nome_informante, Inscestadual) " +
                        "VALUES (@nomeFantasia, @logradouro, @numero, @complemento, @bairro, @cidade, @estado_cid, @cep, @cnpj, " +
                        "@ddd, @telefone, @ramal, @nomeContato, @codigo, @situacao, @razaoSocial, " +
                        "@spc_codigo_associado, @spc_controle_informante, @spc_nome_informante, @Inscestadual)",
                        new {
                            nomeFantasia = dados.nomeFantasia, logradouro = dados.logradouro, numero = dados.numero,
                            complemento = dados.complemento, bairro = dados.bairro, cidade = dados.cidade,
                            estado_cid = dados.estado_cid, cep = dados.cep, cnpj = dados.cnpj,
                            ddd = dados.ddd, telefone = dados.telefone, ramal = dados.ramal,
                            nomeContato = dados.nomeContato, codigo = dados.codigo, situacao = dados.situacao,
                            razaoSocial = dados.razaoSocial, spc_codigo_associado = dados.spc_codigo_associado,
                            spc_controle_informante = dados.spc_controle_informante, spc_nome_informante = dados.spc_nome_informante,
                            Inscestadual = dados.Inscestadual
                        });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Loja [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dLoja dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute(
                        "UPDATE lojas SET nomeFantasia=@nomeFantasia, logradouro=@logradouro, numero=@numero, " +
                        "complemento=@complemento, bairro=@bairro, cidade=@cidade, estado_cid=@estado_cid, cep=@cep, cnpj=@cnpj, " +
                        "ddd=@ddd, telefone=@telefone, ramal=@ramal, nomeContato=@nomeContato, codigo=@codigo, situacao=@situacao, " +
                        "razaoSocial=@razaoSocial, spc_codigo_associado=@spc_codigo_associado, " +
                        "spc_controle_informante=@spc_controle_informante, spc_nome_informante=@spc_nome_informante, " +
                        "Inscestadual=@Inscestadual WHERE cid=@cid",
                        new {
                            nomeFantasia = dados.nomeFantasia, logradouro = dados.logradouro, numero = dados.numero,
                            complemento = dados.complemento, bairro = dados.bairro, cidade = dados.cidade,
                            estado_cid = dados.estado_cid, cep = dados.cep, cnpj = dados.cnpj,
                            ddd = dados.ddd, telefone = dados.telefone, ramal = dados.ramal,
                            nomeContato = dados.nomeContato, codigo = dados.codigo, situacao = dados.situacao,
                            razaoSocial = dados.razaoSocial, spc_codigo_associado = dados.spc_codigo_associado,
                            spc_controle_informante = dados.spc_controle_informante, spc_nome_informante = dados.spc_nome_informante,
                            Inscestadual = dados.Inscestadual, cid = dados.cid
                        });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Loja [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dLoja dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM lojas WHERE cid=@cid", new { cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Loja [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
