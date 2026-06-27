using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsMunicipios;

namespace ncPersistencia.nsMunicipios
{
    public class pMunicipios
    {
        public ColecaoMunicipios Listar()
        {
            ColecaoMunicipios retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, codigo_ibge, nome, estados_cid, situacao From municipios Order By nome ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoMunicipios();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dMunicipios();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.codigo_ibge = RetornarTexto(row["codigo_ibge"]);
                            item.nome = RetornarTexto(row["nome"]);
                            item.estados_cid = RetornarInteiro(row["estados_cid"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar municipios [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoMunicipios ListarPorEstado(int estados_cid)
        {
            ColecaoMunicipios retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, codigo_ibge, nome, estados_cid, situacao ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From municipios ";
                sqlWhere = MontarParametrosSQL(sqlWhere, estados_cid.ToString(), "estados_cid");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " Order By nome");
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoMunicipios();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dMunicipios();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.codigo_ibge = RetornarTexto(row["codigo_ibge"]);
                            item.nome = RetornarTexto(row["nome"]);
                            item.estados_cid = RetornarInteiro(row["estados_cid"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar municipios [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoMunicipios Consultar(dMunicipios dados)
        {
            ColecaoMunicipios retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, nome, situacao, codigo_ibge, estados_cid ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From municipios ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.codigo_ibge, "codigo_ibge");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.nome, "nome");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " Order By nome");
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoMunicipios();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dMunicipios();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.codigo_ibge = RetornarTexto(row["codigo_ibge"]);
                            item.nome = RetornarTexto(row["nome"]);
                            item.estados_cid = RetornarInteiro(row["estados_cid"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar municipios [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dMunicipios dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " municipios ( codigo_ibge, nome, estados_cid, situacao ) " +
                    " VALUES (" +
                    PersistirTexto(dados.codigo_ibge) + "," +
                    PersistirTexto(dados.nome) + "," +
                    PersistirTexto(dados.estados_cid) + ",'A')";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir municipios [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Importar(dMunicipios dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " municipios ( cid, codigo_ibge, nome, estados_cid, situacao ) " +
                    " VALUES (" +
                    PersistirInteiro(dados.cid) + "," +
                    PersistirTexto(dados.codigo_ibge) + "," +
                    PersistirTexto(dados.nome) + "," +
                    PersistirInteiro(dados.estados_cid) + ",'A')";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Importar municipios [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dMunicipios dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE municipios SET " +
                    " codigo_ibge = " + PersistirTexto(dados.codigo_ibge) + "," +
                    " nome = " + PersistirTexto(dados.nome) + "," +
                    " estados_cid = " + PersistirTexto(dados.estados_cid) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar municipios [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dMunicipios dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM municipios " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir municipios [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
