using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using ncNComum;

namespace ncNComum.nsAcessoBD
{
    public class cAcessoBD
    {
        private MySqlConnection ConectarBD()
        {
            MySqlConnection con;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection conexao = config.ConnectionStrings;

            try
            {
                con = new MySqlConnection();
                string caminhoBD = conexao.ConnectionStrings["nascomercio"].ConnectionString;
                caminhoBD = ExtrairPass(caminhoBD);
                con.ConnectionString = caminhoBD;
                con.Open();
            }
            catch (Exception ex)
            {
                con = null;
                throw new ExcecaoNascomercio("Problema na conexão com o banco de dados! \r\n\r\n" + ex.Message);
            }

            return con;
        }

        private string ExtrairPass(string strConn)
        {
            var builder = new System.Data.Common.DbConnectionStringBuilder();
            var cripto = new criptografia();

            builder.ConnectionString = strConn;
            string password = builder["Password"].ToString();

            string result = cripto.Descriptografar(password).Split('\0')[0];
            cripto = null;

            strConn = strConn.Replace(password, result);
            return strConn;
        }

        public int ExecutarINT(string comandoSQL)
        {
            MySqlCommand cmd = null;
            int retorno = 0;

            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = ConectarBD();

                if (cmd.Connection != null)
                {
                    cmd.CommandText = comandoSQL;
                    cmd.CommandType = CommandType.Text;
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (ExcecaoNascomercio)
            {
                throw;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("FOREIGN KEY"))
                    throw new ExcecaoNascomercio("NÃO FOI POSSÍVEL EXCLUIR POR EXISTIR REGISTROS RELACIONADOS: " + ex.Message);
                else
                    throw new ExcecaoNascomercio("Erro ao executar comando [" + this.ToString() + "] - " + ex.Message);
            }
            finally
            {
                if (cmd != null && cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }

            return retorno;
        }

        public int ExecutarCID(string comandoSQL)
        {
            MySqlCommand cmd = null;
            int retorno = 0;

            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = ConectarBD();

                if (cmd.Connection != null)
                {
                    cmd.CommandText = comandoSQL;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    retorno = (int)cmd.LastInsertedId;
                }
            }
            catch (ExcecaoNascomercio)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro ao executar comando [" + this.ToString() + "] - " + ex.Message);
            }
            finally
            {
                if (cmd != null && cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }

            return retorno;
        }

        public DataSet ExecutarDS(string comandoSQL)
        {
            return ExecutarDS(comandoSQL, null);
        }

        public DataSet ExecutarDSLongo(string comandoSQL)
        {
            return ExecutarDSLongo(comandoSQL, null, 300);
        }

        public DataSet ExecutarDS(string comandoSQL, MySqlParameterCollection colecaoParametro)
        {
            MySqlCommand cmd = null;
            DataSet retorno = null;

            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = ConectarBD();

                if (cmd.Connection != null)
                {
                    cmd.CommandText = comandoSQL;

                    if (colecaoParametro != null)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (MySqlParameter param in colecaoParametro)
                            cmd.Parameters.Add(param);
                    }
                    else
                    {
                        cmd.CommandType = CommandType.Text;
                    }

                    retorno = new DataSet();
                    var da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(retorno);
                    da.Dispose();
                }

                if (cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();

                cmd.Dispose();
            }
            catch (ExcecaoNascomercio)
            {
                throw;
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro ao executar comando: [" + this.ToString() + "] - " + ex.Message);
            }
            finally
            {
                if (cmd != null && cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }

            return retorno;
        }

        public DataSet ExecutarDSLongo(string comandoSQL, MySqlParameterCollection colecaoParametro, int? timeoutSegundos = null)
        {
            MySqlCommand cmd = null;
            DataSet retorno = null;

            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = ConectarBD();

                if (cmd.Connection != null)
                {
                    cmd.CommandText = comandoSQL;

                    if (timeoutSegundos.HasValue)
                    {
                        if (timeoutSegundos.Value < 0)
                            throw new ArgumentException("O timeout não pode ser negativo.", nameof(timeoutSegundos));
                        cmd.CommandTimeout = timeoutSegundos.Value;
                    }

                    if (colecaoParametro != null)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (MySqlParameter param in colecaoParametro)
                            cmd.Parameters.Add(param);
                    }
                    else
                    {
                        cmd.CommandType = CommandType.Text;
                    }

                    retorno = new DataSet();
                    var da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(retorno);
                    da.Dispose();
                }

                if (cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();

                cmd.Dispose();
            }
            catch (ExcecaoNascomercio)
            {
                throw;
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro ao executar comando: [" + this.ToString() + "] - " + ex.Message);
            }
            finally
            {
                if (cmd != null && cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }

            return retorno;
        }
    }
}
