using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsCliente;

namespace ncPersistencia.nsCliente
{
    public class pClienteProfissional
    {
        public ColecaoClienteProfissional Listar()
        {
            ColecaoClienteProfissional retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select empresa, logradouro, numero, complemento, cidade, estado_cid, cep, " +
                    " bairro, cliente_cid, ddd, telefone, ramal, dataAdmissao, cargo, salario From clienteprofissional ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoClienteProfissional();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dClienteProfissional();
                            item.empresa = RetornarTexto(row["empresa"]);
                            item.logradouro = RetornarTexto(row["logradouro"]);
                            item.numero = RetornarInteiro(row["numero"]);
                            item.complemento = RetornarTexto(row["complemento"]);
                            item.cidade = RetornarTexto(row["cidade"]);
                            item.estado_cid = RetornarInteiro(row["estado_cid"]);
                            item.cep = RetornarInteiro(row["cep"]);
                            item.bairro = RetornarTexto(row["bairro"]);
                            item.cliente_cid = RetornarInteiro(row["cliente_cid"]);
                            item.telefone = RetornarInteiro(row["telefone"]);
                            item.ddd = RetornarInteiro(row["ddd"]);
                            item.ramal = RetornarInteiro(row["ramal"]);
                            item.dataAdmissao = RetornarTexto(row["dataAdmissao"]);
                            item.salario = RetornarDecimal(row["salario"]);
                            item.cargo = RetornarInteiro(row["cargo"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Cliente - Profissional [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoClienteProfissional Consultar(dClienteProfissional dados)
        {
            ColecaoClienteProfissional retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select empresa, logradouro, numero, complemento, cidade, estado_cid, cep, " +
                    " bairro, cliente_cid, ddd, telefone, ramal, dataAdmissao, cargo, salario ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From clienteprofissional ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.empresa, "empresa");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.logradouro, "logradouro");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.numero, "numero");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.complemento, "complemento");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cidade, "cidade");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.estado_cid, "estado_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cep, "cep");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.bairro, "bairro");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cliente_cid, "cliente_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.ddd, "ddd");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.telefone, "telefone");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.ramal, "ramal");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataAdmissao, "dataAdmissao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.salario, "salario");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cargo, "cargo");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoClienteProfissional();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dClienteProfissional();
                            item.empresa = RetornarTexto(row["empresa"]);
                            item.logradouro = RetornarTexto(row["logradouro"]);
                            item.numero = RetornarInteiro(row["numero"]);
                            item.complemento = RetornarTexto(row["complemento"]);
                            item.cidade = RetornarTexto(row["cidade"]);
                            item.estado_cid = RetornarInteiro(row["estado_cid"]);
                            item.cep = RetornarInteiro(row["cep"]);
                            item.bairro = RetornarTexto(row["bairro"]);
                            item.cliente_cid = RetornarInteiro(row["cliente_cid"]);
                            item.telefone = RetornarTexto(row["telefone"]);
                            item.ddd = RetornarTexto(row["ddd"]);
                            item.ramal = RetornarTexto(row["ramal"]);
                            item.dataAdmissao = RetornarTexto(row["dataAdmissao"]);
                            item.salario = RetornarDecimal(row["salario"]);
                            item.cargo = RetornarTexto(row["cargo"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Cliente - Profissional [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dClienteProfissional dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " clienteprofissional (empresa, logradouro, numero, complemento, cidade, estado_cid, cep, " +
                    " bairro, cliente_cid, ddd, telefone, ramal, dataAdmissao, cargo, salario) " +
                    " VALUES (" +
                    PersistirTexto(dados.empresa) + "," +
                    PersistirTexto(dados.logradouro) + "," +
                    PersistirInteiro(dados.numero) + "," +
                    PersistirTexto(dados.complemento) + "," +
                    PersistirTexto(dados.cidade) + "," +
                    PersistirInteiro(dados.estado_cid) + "," +
                    PersistirInteiro(dados.cep) + "," +
                    PersistirTexto(dados.bairro) + "," +
                    PersistirInteiro(dados.cliente_cid) + "," +
                    PersistirTexto(dados.ddd) + "," +
                    PersistirTexto(dados.telefone) + "," +
                    PersistirTexto(dados.ramal) + "," +
                    PersistirData(dados.dataAdmissao) + "," +
                    PersistirTexto(dados.cargo) + "," +
                    PersistirDecimal(dados.salario) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Cliente - Profissional [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dClienteProfissional dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE clienteprofissional SET " +
                    " empresa = " + PersistirTexto(dados.empresa) + "," +
                    " logradouro = " + PersistirTexto(dados.logradouro) + "," +
                    " numero = " + PersistirInteiro(dados.numero) + "," +
                    " complemento = " + PersistirTexto(dados.complemento) + "," +
                    " cidade = " + PersistirTexto(dados.cidade) + "," +
                    " estado_cid = " + PersistirInteiro(dados.estado_cid) + "," +
                    " cep = " + PersistirInteiro(dados.cep) + "," +
                    " bairro = " + PersistirTexto(dados.bairro) + "," +
                    " ddd = " + PersistirTexto(dados.ddd) + "," +
                    " telefone = " + PersistirTexto(dados.telefone) + "," +
                    " ramal = " + PersistirTexto(dados.ramal) + "," +
                    " cargo = " + PersistirTexto(dados.cargo) + "," +
                    " dataAdmissao = " + PersistirData(dados.dataAdmissao) + "," +
                    " salario = " + PersistirDecimal(dados.salario) +
                    " WHERE " +
                    " cliente_cid = " + PersistirInteiro(dados.cliente_cid);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Cliente - Profissional [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int ExcluirPorCliente(int cliente_cid)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM clienteprofissional " +
                    " WHERE cliente_cid = " + cliente_cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Cliente - Profissional [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
