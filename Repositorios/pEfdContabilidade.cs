using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using Comum;
using Modelos;

namespace Repositorios
{
    public class pEfdContabilidade : RepositorioBase, IpEfdContabilidade
    {
        public dEfdContabilidade Consultar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.QueryFirstOrDefault<dEfdContabilidade>(
                        "SELECT c.nomeContador, c.cpfContador AS cpf, c.crcContador AS crc, c.cnpjEscritorio, c.logradouro, c.numero, " +
                        "c.complemento, c.bairro, c.municipio, c.cep, c.dddTelefone, c.dddFax, c.email, c.contaAnaliticaContabil, " +
                        "m.estados_cid, m.codigo_ibge AS municipioCodigoIbge " +
                        "FROM EfdContabilidade c " +
                        "LEFT JOIN municipios m ON m.cid = c.municipio");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar EfdContabilidade [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM EfdContabilidade");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir EfdContabilidade [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dEfdContabilidade dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(
                        "INSERT INTO EfdContabilidade (nomeContador, cpfContador, crcContador, cnpjEscritorio, logradouro, " +
                        "numero, complemento, bairro, municipio, cep, dddTelefone, dddFax, email, contaAnaliticaContabil) " +
                        "VALUES (@nomeContador, @cpf, @crc, @cnpjEscritorio, @logradouro, " +
                        "@numero, @complemento, @bairro, @municipio, @cep, @dddTelefone, @dddFax, @email, @contaAnaliticaContabil)",
                        new {
                            nomeContador = dados.nomeContador, cpf = dados.cpf, crc = dados.crc,
                            cnpjEscritorio = dados.cnpjEscritorio, logradouro = dados.logradouro, numero = dados.numero,
                            complemento = dados.complemento, bairro = dados.bairro, municipio = dados.municipio,
                            cep = dados.cep, dddTelefone = dados.dddTelefone, dddFax = dados.dddFax,
                            email = dados.email, contaAnaliticaContabil = dados.contaAnaliticaContabil
                        });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir EfdContabilidade [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dEfdContabilidade dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute(
                        "UPDATE EfdContabilidade SET nomeContador=@nomeContador, cpfContador=@cpf, crcContador=@crc, " +
                        "cnpjEscritorio=@cnpjEscritorio, logradouro=@logradouro, numero=@numero, complemento=@complemento, " +
                        "bairro=@bairro, municipio=@municipio, cep=@cep, dddTelefone=@dddTelefone, dddFax=@dddFax, " +
                        "email=@email, contaAnaliticaContabil=@contaAnaliticaContabil",
                        new {
                            nomeContador = dados.nomeContador, cpf = dados.cpf, crc = dados.crc,
                            cnpjEscritorio = dados.cnpjEscritorio, logradouro = dados.logradouro, numero = dados.numero,
                            complemento = dados.complemento, bairro = dados.bairro, municipio = dados.municipio,
                            cep = dados.cep, dddTelefone = dados.dddTelefone, dddFax = dados.dddFax,
                            email = dados.email, contaAnaliticaContabil = dados.contaAnaliticaContabil
                        });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar EfdContabilidade [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
