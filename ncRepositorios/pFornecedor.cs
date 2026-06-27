using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsFornecedor;

namespace ncPersistencia.nsFornecedor
{
    public class pFornecedor
    {
        public ColecaoFornecedor Listar()
        {
            ColecaoFornecedor retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, nome, logradouro, numero, complemento, bairro, cidade_cid, estado_cid, " +
                    " cep, inscricaoEstadual, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao From fornecedores " +
                    " order by nome ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoFornecedor();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dFornecedor();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.codigo = RetornarTexto(row["codigo"]);
                            item.nome = RetornarTexto(row["nome"]);
                            item.logradouro = RetornarTexto(row["logradouro"]);
                            item.numero = RetornarInteiro(row["numero"]);
                            item.complemento = RetornarTexto(row["complemento"]);
                            item.bairro = RetornarTexto(row["bairro"]);
                            item.cidade_cid = RetornarInteiro(row["cidade_cid"]);
                            item.estado_cid = RetornarInteiro(row["estado_cid"]);
                            item.cep = RetornarInteiro(row["cep"]);
                            item.inscricaoEstadual = RetornarTexto(row["inscricaoEstadual"]);
                            item.cnpj = RetornarTexto(row["cnpj"]);
                            item.ddd = RetornarInteiro(row["ddd"]);
                            item.telefone = RetornarTexto(row["telefone"]);
                            item.ramal = RetornarInteiro(row["ramal"]);
                            item.nomeContato = RetornarTexto(row["nomeContato"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Fornecedor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoFornecedor Consultar(dFornecedor dados)
        {
            ColecaoFornecedor retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, nome, logradouro, numero, complemento, bairro, cidade_cid, estado_cid, " +
                    " cep, inscricaoEstadual, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From fornecedores ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.codigo, "codigo");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.nome, "nome");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.logradouro, "logradouro");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.numero, "numero");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.complemento, "complemento");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.bairro, "bairro");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cidade_cid, "cidade_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.estado_cid, "estado_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cep, "cep");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.inscricaoEstadual, "inscricaoEstadual");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cnpj, "cnpj");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.ddd, "ddd");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.telefone, "telefone");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.ramal, "ramal");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.nomeContato, "nomeContato");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.situacao, "situacao");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoFornecedor();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dFornecedor();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.codigo = RetornarTexto(row["codigo"]);
                            item.nome = RetornarTexto(row["nome"]);
                            item.logradouro = RetornarTexto(row["logradouro"]);
                            item.numero = RetornarInteiro(row["numero"]);
                            item.complemento = RetornarTexto(row["complemento"]);
                            item.bairro = RetornarTexto(row["bairro"]);
                            item.cidade_cid = RetornarInteiro(row["cidade_cid"]);
                            item.estado_cid = RetornarInteiro(row["estado_cid"]);
                            item.cep = RetornarInteiro(row["cep"]);
                            item.inscricaoEstadual = RetornarTexto(row["inscricaoEstadual"]);
                            item.cnpj = RetornarTexto(row["cnpj"]);
                            item.ddd = RetornarInteiro(row["ddd"]);
                            item.telefone = RetornarTexto(row["telefone"]);
                            item.ramal = RetornarInteiro(row["ramal"]);
                            item.nomeContato = RetornarTexto(row["nomeContato"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Fornecedor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dFornecedor dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " fornecedores ( nome, logradouro, numero, complemento, bairro, cidade_cid, estado_cid, " +
                    " cep, inscricaoEstadual, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao ) " +
                    " VALUES (" +
                    PersistirTexto(dados.nome) + "," +
                    PersistirTexto(dados.logradouro) + "," +
                    PersistirInteiro(dados.numero) + "," +
                    PersistirTexto(dados.complemento) + "," +
                    PersistirTexto(dados.bairro) + "," +
                    PersistirInteiro(dados.cidade_cid) + "," +
                    PersistirInteiro(dados.estado_cid) + "," +
                    PersistirInteiro(dados.cep) + "," +
                    PersistirTexto(dados.inscricaoEstadual) + "," +
                    PersistirTexto(dados.cnpj) + "," +
                    PersistirInteiro(dados.ddd) + "," +
                    PersistirTexto(dados.telefone) + "," +
                    PersistirInteiro(dados.ramal) + "," +
                    PersistirTexto(dados.nomeContato) + "," +
                    PersistirTexto(dados.codigo) + "," +
                    PersistirTexto(dados.situacao) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Fornecedor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Importar(dFornecedor dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " fornecedores ( cid, nome, logradouro, numero, complemento, bairro, cidade_cid, estado_cid, " +
                    " cep, inscricaoEstadual, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao ) " +
                    " VALUES (" +
                    PersistirInteiro(dados.cid) + "," +
                    PersistirTexto(dados.nome) + "," +
                    PersistirTexto(dados.logradouro) + "," +
                    PersistirInteiro(dados.numero) + "," +
                    PersistirTexto(dados.complemento) + "," +
                    PersistirTexto(dados.bairro) + "," +
                    PersistirInteiro(dados.cidade_cid) + "," +
                    PersistirInteiro(dados.estado_cid) + "," +
                    PersistirInteiro(dados.cep) + "," +
                    PersistirTexto(dados.inscricaoEstadual) + "," +
                    PersistirTexto(dados.cnpj) + "," +
                    PersistirInteiro(dados.ddd) + "," +
                    PersistirTexto(dados.telefone) + "," +
                    PersistirInteiro(dados.ramal) + "," +
                    PersistirTexto(dados.nomeContato) + "," +
                    PersistirTexto(dados.codigo) + "," +
                    PersistirTexto(dados.situacao) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Importar Fornecedor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dFornecedor dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE fornecedores SET " +
                    " nome = " + PersistirTexto(dados.nome) + "," +
                    " logradouro = " + PersistirTexto(dados.logradouro) + "," +
                    " numero = " + PersistirInteiro(dados.numero) + "," +
                    " complemento = " + PersistirTexto(dados.complemento) + "," +
                    " bairro = " + PersistirTexto(dados.bairro) + "," +
                    " cidade_cid = " + PersistirInteiro(dados.cidade_cid) + "," +
                    " estado_cid = " + PersistirInteiro(dados.estado_cid) + "," +
                    " cep = " + PersistirInteiro(dados.cep) + "," +
                    " inscricaoEstadual = " + PersistirTexto(dados.inscricaoEstadual) + "," +
                    " cnpj = " + PersistirTexto(dados.cnpj) + "," +
                    " ddd = " + PersistirInteiro(dados.ddd) + "," +
                    " telefone = " + PersistirTexto(dados.telefone) + "," +
                    " ramal = " + PersistirInteiro(dados.ramal) + "," +
                    " nomeContato = " + PersistirTexto(dados.nomeContato) + "," +
                    " codigo = " + PersistirTexto(dados.codigo) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Fornecedor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dFornecedor dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM fornecedores " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Fornecedor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
