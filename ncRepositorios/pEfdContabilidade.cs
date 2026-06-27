using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsEFD;

namespace ncPersistencia.nsEFD
{
    public class pEfdContabilidade
    {
        public dEfdContabilidade Consultar()
        {
            dEfdContabilidade retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select c.nomeContador, c.cpfContador, c.crcContador, c.cnpjEscritorio, c.logradouro, c.numero, " +
                    " c.complemento, c.bairro, c.municipio, c.cep, c.dddTelefone, c.dddFax, c.email, c.contaAnaliticaContabil, m.estados_cid, " +
                    " m.codigo_ibge ";
                string sqlFrom = " From EfdContabilidade c " +
                    " left join municipios m " +
                    "   on m.cid = c.municipio ";
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new dEfdContabilidade();
                        retorno.nomeContador = RetornarTexto(dt.Rows[0]["nomeContador"]);
                        retorno.cpf = RetornarTexto(dt.Rows[0]["cpfContador"]);
                        retorno.crc = RetornarTexto(dt.Rows[0]["crcContador"]);
                        retorno.cnpjEscritorio = RetornarTexto(dt.Rows[0]["cnpjEscritorio"]);
                        retorno.logradouro = RetornarTexto(dt.Rows[0]["logradouro"]);
                        retorno.numero = RetornarTexto(dt.Rows[0]["numero"]);
                        retorno.complemento = RetornarTexto(dt.Rows[0]["complemento"]);
                        retorno.bairro = RetornarTexto(dt.Rows[0]["bairro"]);
                        retorno.municipio = RetornarTexto(dt.Rows[0]["municipio"]);
                        retorno.municipioCodigoIbge = RetornarTexto(dt.Rows[0]["codigo_ibge"]);
                        retorno.cep = RetornarTexto(dt.Rows[0]["cep"]);
                        retorno.dddTelefone = RetornarTexto(dt.Rows[0]["dddTelefone"]);
                        retorno.dddFax = RetornarTexto(dt.Rows[0]["dddFax"]);
                        retorno.email = RetornarTexto(dt.Rows[0]["email"]);
                        retorno.contaAnaliticaContabil = RetornarTexto(dt.Rows[0]["contaAnaliticaContabil"]);
                        retorno.estados_cid = RetornarInteiro(dt.Rows[0]["estados_cid"]);
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar EfdContabilidade [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir()
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM EfdContabilidade ";
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir EfdContabilidade [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dEfdContabilidade dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " EfdContabilidade ( nomeContador, cpfContador, crcContador, cnpjEscritorio, logradouro, " +
                    " numero, complemento, bairro, municipio, cep, dddTelefone, dddFax, email, contaAnaliticaContabil " +
                    " ) " +
                    " VALUES (" +
                    PersistirTexto(dados.nomeContador) + "," +
                    PersistirTexto(dados.cpf) + "," +
                    PersistirTexto(dados.crc) + "," +
                    PersistirTexto(dados.cnpjEscritorio) + "," +
                    PersistirTexto(dados.logradouro) + "," +
                    PersistirTexto(dados.numero) + "," +
                    PersistirTexto(dados.complemento) + "," +
                    PersistirTexto(dados.bairro) + "," +
                    PersistirTexto(dados.municipio) + "," +
                    PersistirTexto(dados.cep) + "," +
                    PersistirTexto(dados.dddTelefone) + "," +
                    PersistirTexto(dados.dddFax) + "," +
                    PersistirTexto(dados.email) + "," +
                    PersistirTexto(dados.contaAnaliticaContabil) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir EfdContabilidade [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dEfdContabilidade dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE EfdContabilidade SET " +
                    " nomeContador = " + PersistirTexto(dados.nomeContador) + "," +
                    " cpfContador = " + PersistirTexto(dados.cpf) + "," +
                    " crcContador = " + PersistirTexto(dados.crc) + "," +
                    " cnpjEscritorio = " + PersistirTexto(dados.cnpjEscritorio) + "," +
                    " logradouro = " + PersistirTexto(dados.logradouro) + "," +
                    " numero = " + PersistirTexto(dados.numero) + "," +
                    " complemento = " + PersistirTexto(dados.complemento) + "," +
                    " bairro = " + PersistirTexto(dados.bairro) + "," +
                    " municipio = " + PersistirTexto(dados.municipio) + "," +
                    " cep = " + PersistirTexto(dados.cep) + "," +
                    " dddTelefone = " + PersistirTexto(dados.dddTelefone) + "," +
                    " dddFax = " + PersistirTexto(dados.dddFax) + "," +
                    " email = " + PersistirTexto(dados.email) + "," +
                    " contaAnaliticaContabil = " + PersistirTexto(dados.contaAnaliticaContabil);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar EfdContabilidade [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
