using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using Comum;
using Modelos;

namespace Repositorios
{
    public class pCliente : RepositorioBase, IpCliente
    {
        public ColecaoCliente Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dCliente>(
                        "SELECT cid, nome, estadoCivil, sexo, nomePai, nomeMae, dataInclusao, situacao, rg, cpf, carteiraProfissional, dataNascimento, naturalidade, nacionalidade, email, foto, ddd, telefone, dddcel, celular, rgOrgaoEmissor, rgUf_cid FROM clientes").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoCliente();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Cliente [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoCliente Consultar(dCliente dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != 0) { conditions.Add("c.cid=@cid"); p.Add("cid", dados.cid); }
                    if (!string.IsNullOrEmpty(dados.nome)) { conditions.Add("nome LIKE @nome"); p.Add("nome", $"%{dados.nome}%"); }
                    if (!string.IsNullOrEmpty(dados.endereco)) { conditions.Add("logradouro LIKE @logradouro"); p.Add("logradouro", $"%{dados.endereco}%"); }
                    if (!string.IsNullOrEmpty(dados.estadoCivil)) { conditions.Add("estadoCivil=@estadoCivil"); p.Add("estadoCivil", dados.estadoCivil); }
                    if (!string.IsNullOrEmpty(dados.sexo)) { conditions.Add("sexo=@sexo"); p.Add("sexo", dados.sexo); }
                    if (!string.IsNullOrEmpty(dados.nomePai)) { conditions.Add("nomePai LIKE @nomePai"); p.Add("nomePai", $"%{dados.nomePai}%"); }
                    if (!string.IsNullOrEmpty(dados.nomeMae)) { conditions.Add("nomeMae LIKE @nomeMae"); p.Add("nomeMae", $"%{dados.nomeMae}%"); }
                    if (!string.IsNullOrEmpty(dados.dataInclusao)) { conditions.Add("dataInclusao=@dataInclusao"); p.Add("dataInclusao", dados.dataInclusao); }
                    if (!string.IsNullOrEmpty(dados.situacao)) { conditions.Add("situacao=@situacao"); p.Add("situacao", dados.situacao); }
                    if (!string.IsNullOrEmpty(dados.rg)) { conditions.Add("rg=@rg"); p.Add("rg", dados.rg); }
                    if (!string.IsNullOrEmpty(dados.cpf)) { conditions.Add("cpf=@cpf"); p.Add("cpf", dados.cpf); }
                    if (!string.IsNullOrEmpty(dados.carteiraProfissional)) { conditions.Add("carteiraProfissional=@carteiraProfissional"); p.Add("carteiraProfissional", dados.carteiraProfissional); }
                    if (!string.IsNullOrEmpty(dados.dataNascimento)) { conditions.Add("dataNascimento=@dataNascimento"); p.Add("dataNascimento", dados.dataNascimento); }
                    if (!string.IsNullOrEmpty(dados.naturalidade)) { conditions.Add("naturalidade LIKE @naturalidade"); p.Add("naturalidade", $"%{dados.naturalidade}%"); }
                    if (!string.IsNullOrEmpty(dados.nacionalidade)) { conditions.Add("nacionalidade=@nacionalidade"); p.Add("nacionalidade", dados.nacionalidade); }
                    if (!string.IsNullOrEmpty(dados.email)) { conditions.Add("email=@email"); p.Add("email", dados.email); }
                    if (!string.IsNullOrEmpty(dados.foto)) { conditions.Add("foto=@foto"); p.Add("foto", dados.foto); }
                    if (!string.IsNullOrEmpty(dados.ddd)) { conditions.Add("ddd=@ddd"); p.Add("ddd", dados.ddd); }
                    if (!string.IsNullOrEmpty(dados.telefone)) { conditions.Add("telefone=@telefone"); p.Add("telefone", dados.telefone); }
                    if (!string.IsNullOrEmpty(dados.veiculo)) { conditions.Add("placa=@placa"); p.Add("placa", dados.veiculo); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $@"SELECT c.cid, nome, e.logradouro AS endereco, estadoCivil, sexo, nomePai, nomeMae, c.dataInclusao, situacao, rg, cpf, carteiraProfissional, dataNascimento, naturalidade, nacionalidade, email, foto, ddd, telefone, dddcel, celular, rgOrgaoEmissor, rgUf_cid
                        FROM clientes c
                        LEFT JOIN veiculo v ON v.clienteid = c.cid
                        LEFT JOIN clienteenderecos e ON e.cliente_cid = c.cid AND tipoEndereco = 'p'
                        {where}";
                    var lista = conn.Query<dCliente>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoCliente();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Cliente [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dCliente dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("INSERT INTO clientes (nome, estadoCivil, sexo, nomePai, nomeMae, dataInclusao, situacao, rg, cpf, carteiraProfissional, dataNascimento, naturalidade, nacionalidade, email, foto, ddd, telefone, dddcel, celular, rgOrgaoEmissor, rgUf_cid) VALUES (@nome, @estadoCivil, @sexo, @nomePai, @nomeMae, @dataInclusao, @situacao, @rg, @cpf, @carteiraProfissional, @dataNascimento, @naturalidade, @nacionalidade, @email, @foto, @ddd, @telefone, @dddcel, @celular, @rgOrgaoEmissor, @rgUf_cid)",
                        new { dados.nome, dados.estadoCivil, dados.sexo, dados.nomePai, dados.nomeMae, dados.dataInclusao, dados.situacao, dados.rg, dados.cpf, dados.carteiraProfissional, dados.dataNascimento, dados.naturalidade, dados.nacionalidade, dados.email, dados.foto, dados.ddd, dados.telefone, dados.dddcel, dados.celular, dados.rgOrgaoEmissor, dados.rgUf_cid });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Cliente [" + ToString() + "] - " + ex.Message);
            }
        }

        public int IncluirCid(dCliente dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("INSERT INTO clientes (cid, nome, estadoCivil, sexo, nomePai, nomeMae, dataInclusao, situacao, rg, cpf, carteiraProfissional, dataNascimento, naturalidade, nacionalidade, email, foto, ddd, telefone, dddcel, celular, rgOrgaoEmissor, rgUf_cid) VALUES (@cid, @nome, @estadoCivil, @sexo, @nomePai, @nomeMae, @dataInclusao, @situacao, @rg, @cpf, @carteiraProfissional, @dataNascimento, @naturalidade, @nacionalidade, @email, @foto, @ddd, @telefone, @dddcel, @celular, @rgOrgaoEmissor, @rgUf_cid)",
                        new { dados.cid, dados.nome, dados.estadoCivil, dados.sexo, dados.nomePai, dados.nomeMae, dados.dataInclusao, dados.situacao, dados.rg, dados.cpf, dados.carteiraProfissional, dados.dataNascimento, dados.naturalidade, dados.nacionalidade, dados.email, dados.foto, dados.ddd, dados.telefone, dados.dddcel, dados.celular, dados.rgOrgaoEmissor, dados.rgUf_cid });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Cliente [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dCliente dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE clientes SET nome=@nome, estadoCivil=@estadoCivil, sexo=@sexo, nomePai=@nomePai, nomeMae=@nomeMae, dataInclusao=@dataInclusao, situacao=@situacao, rg=@rg, cpf=@cpf, carteiraProfissional=@carteiraProfissional, dataNascimento=@dataNascimento, naturalidade=@naturalidade, nacionalidade=@nacionalidade, email=@email, foto=@foto, ddd=@ddd, telefone=@telefone, dddcel=@dddcel, celular=@celular, rgOrgaoEmissor=@rgOrgaoEmissor, rgUf_cid=@rgUf_cid WHERE cid=@cid",
                        new { dados.nome, dados.estadoCivil, dados.sexo, dados.nomePai, dados.nomeMae, dados.dataInclusao, dados.situacao, dados.rg, dados.cpf, dados.carteiraProfissional, dados.dataNascimento, dados.naturalidade, dados.nacionalidade, dados.email, dados.foto, dados.ddd, dados.telefone, dados.dddcel, dados.celular, dados.rgOrgaoEmissor, dados.rgUf_cid, dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Cliente [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dCliente dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM clientes WHERE cid=@cid", new { dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Cliente [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
