using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsEFD;

namespace ncPersistencia.nsEFD
{
    public class pEfdEntidade
    {
        public dEfdEntidade Consultar()
        {
            dEfdEntidade retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select e.nomeEmpresarial, e.tipoPessoa, e.cpfCnpj, m.estados_cid, e.inscricaoEstadual, e.codigoMunicipio, " +
                    " e.inscricaoMunicipal, e.inscricaoSuframa, e.tipoAtividade, e.nomeFantasia, " +
                    " m.codigo_ibge, uf.sigla ";
                string sqlFrom = " From EfdEntidade e " +
                    " left join municipios m " +
                    "   on m.cid = e.codigoMunicipio " +
                    " left join estados uf " +
                    "   on uf.cid = m.estados_cid ";
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new dEfdEntidade();
                        retorno.nomeEmpresarial = RetornarTexto(dt.Rows[0]["nomeEmpresarial"]);
                        retorno.tipoPessoa = RetornarTexto(dt.Rows[0]["tipoPessoa"]);
                        retorno.cpfCnpj = RetornarTexto(dt.Rows[0]["cpfCnpj"]);
                        retorno.estados_cid = RetornarInteiro(dt.Rows[0]["estados_cid"]);
                        retorno.ufSigla = RetornarTexto(dt.Rows[0]["sigla"]);
                        retorno.inscricaoEstadual = RetornarTexto(dt.Rows[0]["inscricaoEstadual"]);
                        retorno.codigoMunicipio = RetornarTexto(dt.Rows[0]["codigoMunicipio"]);
                        retorno.municipioCodigoIbge = RetornarTexto(dt.Rows[0]["codigo_ibge"]);
                        retorno.inscricaoMunicipal = RetornarTexto(dt.Rows[0]["inscricaoMunicipal"]);
                        retorno.inscricaoSuframa = RetornarTexto(dt.Rows[0]["inscricaoSuframa"]);
                        retorno.tipoAtividade = RetornarTexto(dt.Rows[0]["tipoAtividade"]);
                        retorno.nomeFantasia = RetornarTexto(dt.Rows[0]["nomeFantasia"]);
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar EfdEntidade [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir()
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM EfdEntidade ";
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir EfdEntidade [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dEfdEntidade dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " EfdEntidade ( nomeEmpresarial, tipoPessoa, cpfCnpj, uf, inscricaoEstadual, codigoMunicipio, " +
                    " inscricaoMunicipal, inscricaoSuframa, tipoAtividade, nomeFantasia ) " +
                    " VALUES (" +
                    PersistirTexto(dados.nomeEmpresarial) + "," +
                    PersistirTexto(dados.tipoPessoa) + "," +
                    PersistirTexto(dados.cpfCnpj) + "," +
                    PersistirInteiro(dados.estados_cid) + "," +
                    PersistirTexto(dados.inscricaoEstadual) + "," +
                    PersistirTexto(dados.codigoMunicipio) + "," +
                    PersistirTexto(dados.inscricaoMunicipal) + "," +
                    PersistirTexto(dados.inscricaoSuframa) + "," +
                    PersistirTexto(dados.tipoAtividade) + "," +
                    PersistirTexto(dados.nomeFantasia) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir EfdEntidade [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dEfdEntidade dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE EfdEntidade  SET " +
                    " nomeEmpresarial = " + PersistirTexto(dados.nomeEmpresarial) + "," +
                    " tipoPessoa = " + PersistirTexto(dados.tipoPessoa) + "," +
                    " cpfCnpj = " + PersistirTexto(dados.cpfCnpj) + "," +
                    " uf = " + PersistirInteiro(dados.estados_cid) + "," +
                    " inscricaoEstadual = " + PersistirTexto(dados.inscricaoEstadual) + "," +
                    " codigoMunicipio = " + PersistirTexto(dados.codigoMunicipio) + "," +
                    " inscricaoMunicipal = " + PersistirTexto(dados.inscricaoMunicipal) + "," +
                    " inscricaoSuframa = " + PersistirTexto(dados.inscricaoSuframa) + "," +
                    " tipoAtividade = " + PersistirTexto(dados.tipoAtividade) + "," +
                    " nomeFantasia = " + PersistirTexto(dados.nomeFantasia);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar EfdEntidade [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
