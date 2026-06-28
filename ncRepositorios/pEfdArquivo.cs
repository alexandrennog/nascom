using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum;
using ncModelos;

namespace ncRepositorios
{
    public class pEfdArquivo : RepositorioBase, IpEfdArquivo
    {
        public dEfdArquivo Consultar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.QueryFirstOrDefault<dEfdArquivo>(
                        "SELECT versaoLeiaute, finalidadeArquivo, perfilArquivoFiscal FROM EfdArquivo");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar EfdArquivo [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM EfdArquivo");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir EfdArquivo [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dEfdArquivo dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(
                        "INSERT INTO EfdArquivo (versaoLeiaute, finalidadeArquivo, perfilArquivoFiscal) " +
                        "VALUES (@versaoLeiaute, @finalidadeArquivo, @perfilArquivoFiscal)",
                        new { versaoLeiaute = dados.versaoLeiaute, finalidadeArquivo = dados.finalidadeArquivo, perfilArquivoFiscal = dados.perfilArquivoFiscal });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir EfdArquivo [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dEfdArquivo dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute(
                        "UPDATE EfdArquivo SET versaoLeiaute=@versaoLeiaute, finalidadeArquivo=@finalidadeArquivo, perfilArquivoFiscal=@perfilArquivoFiscal",
                        new { versaoLeiaute = dados.versaoLeiaute, finalidadeArquivo = dados.finalidadeArquivo, perfilArquivoFiscal = dados.perfilArquivoFiscal });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar EfdArquivo [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
