using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsEFD;

namespace ncPersistencia.nsEFD
{
    public class pEfdEnderecoContato
    {
        public dEfdEnderecoContato Consultar()
        {
            dEfdEnderecoContato retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select logradouro, numero, " +
                    " complemento, bairro, cep, dddTelefone, dddFax, email ";
                string sqlFrom = " From EfdEnderecoContato ";
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new dEfdEnderecoContato();
                        retorno.logradouro = RetornarTexto(dt.Rows[0]["logradouro"]);
                        retorno.numero = RetornarTexto(dt.Rows[0]["numero"]);
                        retorno.complemento = RetornarTexto(dt.Rows[0]["complemento"]);
                        retorno.bairro = RetornarTexto(dt.Rows[0]["bairro"]);
                        retorno.cep = RetornarTexto(dt.Rows[0]["cep"]);
                        retorno.dddTelefone = RetornarTexto(dt.Rows[0]["dddTelefone"]);
                        retorno.dddFax = RetornarTexto(dt.Rows[0]["dddFax"]);
                        retorno.email = RetornarTexto(dt.Rows[0]["email"]);
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar EfdEnderecoContato [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir()
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM EfdEnderecoContato ";
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir EfdEnderecoContato [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dEfdEnderecoContato dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " EfdEnderecoContato ( logradouro, " +
                    " numero, complemento, bairro, cep, dddTelefone, dddFax, email ) " +
                    " VALUES (" +
                    PersistirTexto(dados.logradouro) + "," +
                    PersistirTexto(dados.numero) + "," +
                    PersistirTexto(dados.complemento) + "," +
                    PersistirTexto(dados.bairro) + "," +
                    PersistirTexto(dados.cep) + "," +
                    PersistirTexto(dados.dddTelefone) + "," +
                    PersistirTexto(dados.dddFax) + "," +
                    PersistirTexto(dados.email) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir EfdEnderecoContato [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dEfdEnderecoContato dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE EfdEnderecoContato SET " +
                    " logradouro = " + PersistirTexto(dados.logradouro) + "," +
                    " numero = " + PersistirTexto(dados.numero) + "," +
                    " complemento = " + PersistirTexto(dados.complemento) + "," +
                    " bairro = " + PersistirTexto(dados.bairro) + "," +
                    " cep = " + PersistirTexto(dados.cep) + "," +
                    " dddTelefone = " + PersistirTexto(dados.dddTelefone) + "," +
                    " dddFax = " + PersistirTexto(dados.dddFax) + "," +
                    " email = " + PersistirTexto(dados.email);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar EfdEnderecoContato [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
