using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using Comum;
using Modelos;

namespace Repositorios
{
    public class pEfdEnderecoContato : RepositorioBase, IpEfdEnderecoContato
    {
        public dEfdEnderecoContato Consultar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.QueryFirstOrDefault<dEfdEnderecoContato>(
                        "SELECT logradouro, numero, complemento, bairro, cep, dddTelefone, dddFax, email FROM EfdEnderecoContato");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar EfdEnderecoContato [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM EfdEnderecoContato");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir EfdEnderecoContato [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dEfdEnderecoContato dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(
                        "INSERT INTO EfdEnderecoContato (logradouro, numero, complemento, bairro, cep, dddTelefone, dddFax, email) " +
                        "VALUES (@logradouro, @numero, @complemento, @bairro, @cep, @dddTelefone, @dddFax, @email)",
                        new {
                            logradouro = dados.logradouro, numero = dados.numero, complemento = dados.complemento,
                            bairro = dados.bairro, cep = dados.cep, dddTelefone = dados.dddTelefone,
                            dddFax = dados.dddFax, email = dados.email
                        });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir EfdEnderecoContato [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dEfdEnderecoContato dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute(
                        "UPDATE EfdEnderecoContato SET logradouro=@logradouro, numero=@numero, complemento=@complemento, " +
                        "bairro=@bairro, cep=@cep, dddTelefone=@dddTelefone, dddFax=@dddFax, email=@email",
                        new {
                            logradouro = dados.logradouro, numero = dados.numero, complemento = dados.complemento,
                            bairro = dados.bairro, cep = dados.cep, dddTelefone = dados.dddTelefone,
                            dddFax = dados.dddFax, email = dados.email
                        });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar EfdEnderecoContato [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
