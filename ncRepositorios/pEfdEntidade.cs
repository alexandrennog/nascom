using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum;
using ncModelos;

namespace ncRepositorios
{
    public class pEfdEntidade : RepositorioBase, IpEfdEntidade
    {
        public dEfdEntidade Consultar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.QueryFirstOrDefault<dEfdEntidade>(
                        "SELECT e.nomeEmpresarial, e.tipoPessoa, e.cpfCnpj, m.estados_cid, e.inscricaoEstadual, e.codigoMunicipio, " +
                        "e.inscricaoMunicipal, e.inscricaoSuframa, e.tipoAtividade, e.nomeFantasia, " +
                        "m.codigo_ibge AS municipioCodigoIbge, uf.sigla AS ufSigla " +
                        "FROM EfdEntidade e " +
                        "LEFT JOIN municipios m ON m.cid = e.codigoMunicipio " +
                        "LEFT JOIN estados uf ON uf.cid = m.estados_cid");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar EfdEntidade [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM EfdEntidade");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir EfdEntidade [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dEfdEntidade dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(
                        "INSERT INTO EfdEntidade (nomeEmpresarial, tipoPessoa, cpfCnpj, uf, inscricaoEstadual, codigoMunicipio, " +
                        "inscricaoMunicipal, inscricaoSuframa, tipoAtividade, nomeFantasia) " +
                        "VALUES (@nomeEmpresarial, @tipoPessoa, @cpfCnpj, @estados_cid, @inscricaoEstadual, @codigoMunicipio, " +
                        "@inscricaoMunicipal, @inscricaoSuframa, @tipoAtividade, @nomeFantasia)",
                        new {
                            nomeEmpresarial = dados.nomeEmpresarial, tipoPessoa = dados.tipoPessoa, cpfCnpj = dados.cpfCnpj,
                            estados_cid = dados.estados_cid, inscricaoEstadual = dados.inscricaoEstadual,
                            codigoMunicipio = dados.codigoMunicipio, inscricaoMunicipal = dados.inscricaoMunicipal,
                            inscricaoSuframa = dados.inscricaoSuframa, tipoAtividade = dados.tipoAtividade, nomeFantasia = dados.nomeFantasia
                        });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir EfdEntidade [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dEfdEntidade dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute(
                        "UPDATE EfdEntidade SET nomeEmpresarial=@nomeEmpresarial, tipoPessoa=@tipoPessoa, cpfCnpj=@cpfCnpj, " +
                        "uf=@estados_cid, inscricaoEstadual=@inscricaoEstadual, codigoMunicipio=@codigoMunicipio, " +
                        "inscricaoMunicipal=@inscricaoMunicipal, inscricaoSuframa=@inscricaoSuframa, " +
                        "tipoAtividade=@tipoAtividade, nomeFantasia=@nomeFantasia",
                        new {
                            nomeEmpresarial = dados.nomeEmpresarial, tipoPessoa = dados.tipoPessoa, cpfCnpj = dados.cpfCnpj,
                            estados_cid = dados.estados_cid, inscricaoEstadual = dados.inscricaoEstadual,
                            codigoMunicipio = dados.codigoMunicipio, inscricaoMunicipal = dados.inscricaoMunicipal,
                            inscricaoSuframa = dados.inscricaoSuframa, tipoAtividade = dados.tipoAtividade, nomeFantasia = dados.nomeFantasia
                        });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar EfdEntidade [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
