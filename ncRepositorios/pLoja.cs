using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsLoja;

namespace ncPersistencia.nsLoja
{
    public class pLoja
    {
        public ColecaoLoja Listar()
        {
            ColecaoLoja retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, nomeFantasia, logradouro, numero, complemento, bairro, cidade, " +
                    " estado_cid, cep, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao, razaoSocial, " +
                    " spc_codigo_associado, spc_controle_informante, spc_nome_informante, Inscestadual From lojas ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoLoja();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dLoja();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.nomeFantasia = RetornarTexto(row["nomeFantasia"]);
                            item.logradouro = RetornarTexto(row["logradouro"]);
                            item.numero = RetornarTexto(row["numero"]);
                            item.complemento = RetornarTexto(row["complemento"]);
                            item.bairro = RetornarTexto(row["bairro"]);
                            item.cidade = RetornarTexto(row["cidade"]);
                            item.estado_cid = RetornarInteiro(row["estado_cid"]);
                            item.cep = RetornarTexto(row["cep"]);
                            item.cnpj = RetornarTexto(row["cnpj"]);
                            item.ddd = RetornarTexto(row["ddd"]);
                            item.telefone = RetornarTexto(row["telefone"]);
                            item.ramal = RetornarTexto(row["ramal"]);
                            item.nomeContato = RetornarTexto(row["nomeContato"]);
                            item.codigo = RetornarTexto(row["codigo"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.razaoSocial = RetornarTexto(row["razaoSocial"]);
                            item.spc_codigo_associado = RetornarTexto(row["spc_codigo_associado"]);
                            item.spc_controle_informante = RetornarTexto(row["spc_controle_informante"]);
                            item.spc_nome_informante = RetornarTexto(row["spc_nome_informante"]);
                            item.Inscestadual = RetornarTexto(row["Inscestadual"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Loja [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoLoja Consultar(dLoja dados)
        {
            ColecaoLoja retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, nomeFantasia, logradouro, numero, complemento, bairro, cidade, " +
                    " estado_cid, cep, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao, razaoSocial, " +
                    " spc_codigo_associado, spc_controle_informante, spc_nome_informante, Inscestadual ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From lojas ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.nomeFantasia, "nomeFantasia");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.codigo, "codigo");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.situacao, "situacao");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoLoja();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dLoja();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.nomeFantasia = RetornarTexto(row["nomeFantasia"]);
                            item.logradouro = RetornarTexto(row["logradouro"]);
                            item.numero = RetornarTexto(row["numero"]);
                            item.complemento = RetornarTexto(row["complemento"]);
                            item.bairro = RetornarTexto(row["bairro"]);
                            item.cidade = RetornarTexto(row["cidade"]);
                            item.estado_cid = RetornarInteiro(row["estado_cid"]);
                            item.cep = RetornarTexto(row["cep"]);
                            item.cnpj = RetornarTexto(row["cnpj"]);
                            item.ddd = RetornarTexto(row["ddd"]);
                            item.telefone = RetornarTexto(row["telefone"]);
                            item.ramal = RetornarTexto(row["ramal"]);
                            item.nomeContato = RetornarTexto(row["nomeContato"]);
                            item.codigo = RetornarTexto(row["codigo"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.razaoSocial = RetornarTexto(row["razaoSocial"]);
                            item.spc_codigo_associado = RetornarTexto(row["spc_codigo_associado"]);
                            item.spc_controle_informante = RetornarTexto(row["spc_controle_informante"]);
                            item.spc_nome_informante = RetornarTexto(row["spc_nome_informante"]);
                            item.Inscestadual = RetornarTexto(row["Inscestadual"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Loja [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dLoja dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO lojas " +
                    " ( nomeFantasia, logradouro, numero, complemento, bairro, cidade, estado_cid, cep, cnpj, " +
                    " ddd, telefone, ramal, nomeContato, codigo, situacao, razaoSocial, " +
                    " spc_codigo_associado, spc_controle_informante, spc_nome_informante, Inscestadual ) " +
                    " VALUES (" +
                    PersistirTexto(dados.nomeFantasia) + "," +
                    PersistirTexto(dados.logradouro) + "," +
                    PersistirTexto(dados.numero) + "," +
                    PersistirTexto(dados.complemento) + "," +
                    PersistirTexto(dados.bairro) + "," +
                    PersistirTexto(dados.cidade) + "," +
                    PersistirInteiro(dados.estado_cid) + "," +
                    PersistirTexto(dados.cep) + "," +
                    PersistirTexto(dados.cnpj) + "," +
                    PersistirTexto(dados.ddd) + "," +
                    PersistirTexto(dados.telefone) + "," +
                    PersistirTexto(dados.ramal) + "," +
                    PersistirTexto(dados.nomeContato) + "," +
                    PersistirTexto(dados.codigo) + "," +
                    PersistirTexto(dados.situacao) + "," +
                    PersistirTexto(dados.razaoSocial) + "," +
                    PersistirTexto(dados.spc_codigo_associado) + "," +
                    PersistirTexto(dados.spc_controle_informante) + "," +
                    PersistirTexto(dados.spc_nome_informante) + "," +
                    PersistirTexto(dados.Inscestadual) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Loja [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dLoja dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE lojas SET " +
                    " nomeFantasia = " + PersistirTexto(dados.nomeFantasia) + "," +
                    " logradouro = " + PersistirTexto(dados.logradouro) + "," +
                    " numero = " + PersistirTexto(dados.numero) + "," +
                    " complemento = " + PersistirTexto(dados.complemento) + "," +
                    " bairro = " + PersistirTexto(dados.bairro) + "," +
                    " cidade = " + PersistirTexto(dados.cidade) + "," +
                    " estado_cid = " + PersistirInteiro(dados.estado_cid) + "," +
                    " cep = " + PersistirTexto(dados.cep) + "," +
                    " cnpj = " + PersistirTexto(dados.cnpj) + "," +
                    " ddd = " + PersistirTexto(dados.ddd) + "," +
                    " telefone = " + PersistirTexto(dados.telefone) + "," +
                    " ramal = " + PersistirTexto(dados.ramal) + "," +
                    " nomeContato = " + PersistirTexto(dados.nomeContato) + "," +
                    " codigo = " + PersistirTexto(dados.codigo) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) + "," +
                    " razaoSocial = " + PersistirTexto(dados.razaoSocial) + "," +
                    " spc_codigo_associado = " + PersistirTexto(dados.spc_codigo_associado) + "," +
                    " spc_controle_informante = " + PersistirTexto(dados.spc_controle_informante) + "," +
                    " spc_nome_informante = " + PersistirTexto(dados.spc_nome_informante) + "," +
                    " Inscestadual = " + PersistirTexto(dados.Inscestadual) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Loja [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dLoja dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM lojas " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Loja [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
