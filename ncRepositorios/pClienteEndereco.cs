using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsCliente;

namespace ncPersistencia.nsCliente
{
    public class pClienteEndereco
    {
        public ColecaoClienteEndereco Listar()
        {
            ColecaoClienteEndereco retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select logradouro, numero, complemento, cidade, estado_cid, cep, " +
                    " dataInclusao, tipoResidencia, bairro, tipoEndereco, cliente_cid From clienteenderecos ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoClienteEndereco();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dClienteEndereco();
                            item.logradouro = RetornarTexto(row["logradouro"]);
                            item.numero = RetornarInteiro(row["numero"]);
                            item.complemento = RetornarTexto(row["complemento"]);
                            item.cidade = RetornarTexto(row["cidade"]);
                            item.estado_cid = RetornarInteiro(row["estado_cid"]);
                            item.cep = RetornarInteiro(row["cep"]);
                            item.dataInclusao = RetornarTexto(row["dataInclusao"]);
                            item.tipoResidencia = RetornarTexto(row["tipoResidencia"]);
                            item.bairro = RetornarTexto(row["bairro"]);
                            item.tipoEndereco = RetornarTexto(row["tipoEndereco"]);
                            item.cliente_cid = RetornarInteiro(row["cliente_cid"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Cliente - Endereço [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoClienteEndereco Consultar(dClienteEndereco dados)
        {
            ColecaoClienteEndereco retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " SELECT c.logradouro, c.numero, c.complemento, c.cidade, c.estado_cid, c.cep, " +
                    " c.dataInclusao, c.tipoResidencia, c.bairro, c.tipoEndereco, c.cliente_cid, e.sigla ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From clienteenderecos c LEFT OUTER JOIN estados e ON c.estado_cid = e.cid ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.logradouro, "c.logradouro");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.numero, "c.numero");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.complemento, "c.complemento");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cidade, "c.cidade");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.estado_cid, "c.estado_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cep, "c.cep");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataInclusao, "c.dataInclusao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.tipoResidencia, "c.tipoResidencia");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.bairro, "c.bairro");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.tipoEndereco, "c.tipoEndereco");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cliente_cid, "c.cliente_cid");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoClienteEndereco();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dClienteEndereco();
                            item.logradouro = RetornarTexto(row["logradouro"]);
                            item.numero = RetornarInteiro(row["numero"]);
                            item.complemento = RetornarTexto(row["complemento"]);
                            item.cidade = RetornarTexto(row["cidade"]);
                            item.estado_cid = RetornarInteiro(row["estado_cid"]);
                            item.cep = RetornarInteiro(row["cep"]);
                            item.dataInclusao = RetornarTexto(row["dataInclusao"]);
                            item.tipoResidencia = RetornarTexto(row["tipoResidencia"]);
                            item.bairro = RetornarTexto(row["bairro"]);
                            item.tipoEndereco = RetornarTexto(row["tipoEndereco"]);
                            item.cliente_cid = RetornarInteiro(row["cliente_cid"]);
                            item.siglaEstado = RetornarTexto(row["sigla"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Cliente - Endereço [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dClienteEndereco dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " clienteenderecos (logradouro, numero, complemento, cidade, estado_cid, cep, " +
                    " dataInclusao, tipoResidencia, bairro, tipoEndereco, cliente_cid) " +
                    " VALUES (" +
                    PersistirTexto(dados.logradouro) + "," +
                    PersistirInteiro(dados.numero) + "," +
                    PersistirTexto(dados.complemento) + "," +
                    PersistirTexto(dados.cidade) + "," +
                    PersistirInteiro(dados.estado_cid) + "," +
                    PersistirInteiro(dados.cep) + "," +
                    PersistirTexto(dados.dataInclusao) + "," +
                    PersistirTexto(dados.tipoResidencia) + "," +
                    PersistirTexto(dados.bairro) + "," +
                    PersistirTexto(dados.tipoEndereco) + "," +
                    PersistirInteiro(dados.cliente_cid) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Cliente - Endereço [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int ExcluirPorCliente(int cliente_cid)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM clienteenderecos " +
                    " WHERE cliente_cid = " + cliente_cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Cliente - Endereço [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
