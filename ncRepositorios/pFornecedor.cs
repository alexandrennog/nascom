using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;
using nsFornecedor;

namespace ncPersistencia.nsFornecedor
{
    public class pFornecedor : RepositorioBase, IpFornecedor
    {
        public ColecaoFornecedor Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "SELECT cid, nome, logradouro, numero, complemento, bairro, cidade_cid, estado_cid," +
                              " cep, inscricaoEstadual, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao" +
                              " FROM fornecedores ORDER BY nome";
                    var lista = conn.Query<dFornecedor>(sql).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoFornecedor();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Fornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoFornecedor Consultar(dFornecedor dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();

                    if (dados.cid != null && dados.cid != 0) { conditions.Add("cid = @cid"); p.Add("cid", dados.cid); }
                    if (!string.IsNullOrEmpty(dados.codigo)) { conditions.Add("codigo = @codigo"); p.Add("codigo", dados.codigo); }
                    if (!string.IsNullOrEmpty(dados.nome)) { conditions.Add("nome = @nome"); p.Add("nome", dados.nome); }
                    if (!string.IsNullOrEmpty(dados.logradouro)) { conditions.Add("logradouro = @logradouro"); p.Add("logradouro", dados.logradouro); }
                    if (dados.numero != null && dados.numero != 0) { conditions.Add("numero = @numero"); p.Add("numero", dados.numero); }
                    if (!string.IsNullOrEmpty(dados.complemento)) { conditions.Add("complemento = @complemento"); p.Add("complemento", dados.complemento); }
                    if (!string.IsNullOrEmpty(dados.bairro)) { conditions.Add("bairro = @bairro"); p.Add("bairro", dados.bairro); }
                    if (dados.cidade_cid != null && dados.cidade_cid != 0) { conditions.Add("cidade_cid = @cidade_cid"); p.Add("cidade_cid", dados.cidade_cid); }
                    if (dados.estado_cid != null && dados.estado_cid != 0) { conditions.Add("estado_cid = @estado_cid"); p.Add("estado_cid", dados.estado_cid); }
                    if (dados.cep != null && dados.cep != 0) { conditions.Add("cep = @cep"); p.Add("cep", dados.cep); }
                    if (!string.IsNullOrEmpty(dados.inscricaoEstadual)) { conditions.Add("inscricaoEstadual = @inscricaoEstadual"); p.Add("inscricaoEstadual", dados.inscricaoEstadual); }
                    if (!string.IsNullOrEmpty(dados.cnpj)) { conditions.Add("cnpj = @cnpj"); p.Add("cnpj", dados.cnpj); }
                    if (dados.ddd != null && dados.ddd != 0) { conditions.Add("ddd = @ddd"); p.Add("ddd", dados.ddd); }
                    if (!string.IsNullOrEmpty(dados.telefone)) { conditions.Add("telefone = @telefone"); p.Add("telefone", dados.telefone); }
                    if (dados.ramal != null && dados.ramal != 0) { conditions.Add("ramal = @ramal"); p.Add("ramal", dados.ramal); }
                    if (!string.IsNullOrEmpty(dados.nomeContato)) { conditions.Add("nomeContato = @nomeContato"); p.Add("nomeContato", dados.nomeContato); }
                    if (!string.IsNullOrEmpty(dados.situacao)) { conditions.Add("situacao = @situacao"); p.Add("situacao", dados.situacao); }

                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, nome, logradouro, numero, complemento, bairro, cidade_cid, estado_cid," +
                              $" cep, inscricaoEstadual, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao" +
                              $" FROM fornecedores {where}";

                    var lista = conn.Query<dFornecedor>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoFornecedor();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Fornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dFornecedor dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "INSERT INTO fornecedores (nome, logradouro, numero, complemento, bairro, cidade_cid, estado_cid," +
                              " cep, inscricaoEstadual, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao)" +
                              " VALUES (@nome, @logradouro, @numero, @complemento, @bairro, @cidade_cid, @estado_cid," +
                              " @cep, @inscricaoEstadual, @cnpj, @ddd, @telefone, @ramal, @nomeContato, @codigo, @situacao)";
                    conn.Execute(sql, new
                    {
                        nome = dados.nome, logradouro = dados.logradouro, numero = dados.numero,
                        complemento = dados.complemento, bairro = dados.bairro, cidade_cid = dados.cidade_cid,
                        estado_cid = dados.estado_cid, cep = dados.cep, inscricaoEstadual = dados.inscricaoEstadual,
                        cnpj = dados.cnpj, ddd = dados.ddd, telefone = dados.telefone, ramal = dados.ramal,
                        nomeContato = dados.nomeContato, codigo = dados.codigo, situacao = dados.situacao
                    });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Fornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Importar(dFornecedor dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "INSERT INTO fornecedores (cid, nome, logradouro, numero, complemento, bairro, cidade_cid, estado_cid," +
                              " cep, inscricaoEstadual, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao)" +
                              " VALUES (@cid, @nome, @logradouro, @numero, @complemento, @bairro, @cidade_cid, @estado_cid," +
                              " @cep, @inscricaoEstadual, @cnpj, @ddd, @telefone, @ramal, @nomeContato, @codigo, @situacao)";
                    conn.Execute(sql, new
                    {
                        cid = dados.cid, nome = dados.nome, logradouro = dados.logradouro, numero = dados.numero,
                        complemento = dados.complemento, bairro = dados.bairro, cidade_cid = dados.cidade_cid,
                        estado_cid = dados.estado_cid, cep = dados.cep, inscricaoEstadual = dados.inscricaoEstadual,
                        cnpj = dados.cnpj, ddd = dados.ddd, telefone = dados.telefone, ramal = dados.ramal,
                        nomeContato = dados.nomeContato, codigo = dados.codigo, situacao = dados.situacao
                    });
                    return 1;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Importar Fornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dFornecedor dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "UPDATE fornecedores SET" +
                              " nome=@nome, logradouro=@logradouro, numero=@numero, complemento=@complemento," +
                              " bairro=@bairro, cidade_cid=@cidade_cid, estado_cid=@estado_cid, cep=@cep," +
                              " inscricaoEstadual=@inscricaoEstadual, cnpj=@cnpj, ddd=@ddd, telefone=@telefone," +
                              " ramal=@ramal, nomeContato=@nomeContato, codigo=@codigo, situacao=@situacao" +
                              " WHERE cid=@cid";
                    return conn.Execute(sql, new
                    {
                        nome = dados.nome, logradouro = dados.logradouro, numero = dados.numero,
                        complemento = dados.complemento, bairro = dados.bairro, cidade_cid = dados.cidade_cid,
                        estado_cid = dados.estado_cid, cep = dados.cep, inscricaoEstadual = dados.inscricaoEstadual,
                        cnpj = dados.cnpj, ddd = dados.ddd, telefone = dados.telefone, ramal = dados.ramal,
                        nomeContato = dados.nomeContato, codigo = dados.codigo, situacao = dados.situacao,
                        cid = dados.cid
                    });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Fornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dFornecedor dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM fornecedores WHERE cid=@cid", new { cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Fornecedor [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
