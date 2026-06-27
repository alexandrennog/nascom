using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsEFD;

namespace ncPersistencia.nsEFD
{
    public class pEfdArquivo
    {
        public dEfdArquivo Consultar()
        {
            dEfdArquivo retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select versaoLeiaute, finalidadeArquivo, perfilArquivoFiscal ";
                string sqlFrom = " From EfdArquivo ";
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new dEfdArquivo();
                        retorno.versaoLeiaute = RetornarTexto(dt.Rows[0]["versaoLeiaute"]);
                        retorno.finalidadeArquivo = RetornarTexto(dt.Rows[0]["finalidadeArquivo"]);
                        retorno.perfilArquivoFiscal = RetornarTexto(dt.Rows[0]["perfilArquivoFiscal"]);
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar EfdArquivo [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir()
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM EfdArquivo ";
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir EfdArquivo [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dEfdArquivo dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " EfdArquivo ( versaoLeiaute, finalidadeArquivo, perfilArquivoFiscal ) " +
                    " VALUES (" +
                    PersistirTexto(dados.versaoLeiaute) + "," +
                    PersistirTexto(dados.finalidadeArquivo) + "," +
                    PersistirTexto(dados.perfilArquivoFiscal) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir EfdArquivo [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dEfdArquivo dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE EfdArquivo SET " +
                    " versaoLeiaute = " + PersistirTexto(dados.versaoLeiaute) + "," +
                    " finalidadeArquivo = " + PersistirTexto(dados.finalidadeArquivo) + "," +
                    " perfilArquivoFiscal = " + PersistirTexto(dados.perfilArquivoFiscal);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar EfdArquivo [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
