using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using Comum;
using Modelos;

namespace Repositorios
{
    public abstract class RepositorioBase
    {
        // Definido uma vez na inicialização da aplicação (ex: Program.cs)
        public static string? ConnectionString { get; set; }

        protected MySqlConnection CriarConexao()
        {
            try
            {
                string connStr;
                if (!string.IsNullOrEmpty(ConnectionString))
                {
                    connStr = ConnectionString;
                }
                else
                {
                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    connStr = config.ConnectionStrings.ConnectionStrings["nascomercio"].ConnectionString;
                    connStr = ExtrairSenha(connStr);
                }
                var conn = new MySqlConnection(connStr);
                conn.Open();
                return conn;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Problema na conexão com o banco de dados! \r\n\r\n" + ex.Message);
            }
        }

        private string ExtrairSenha(string connStr)
        {
            var builder = new System.Data.Common.DbConnectionStringBuilder();
            builder.ConnectionString = connStr;
            string password = builder["Password"].ToString();
            var cripto = new Comum.criptografia();
            string result = cripto.Descriptografar(password).Split('\0')[0];
            return connStr.Replace(password, result);
        }
    }
}
