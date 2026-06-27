using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsGiro;

namespace ncPersistencia.nsGiro
{
    public class pGiro
    {
        public ColecaoGiro Listar()
        {
            ColecaoGiro retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select produto_cid, codigoBarras, dataInicio, dataFim, dias, quantidade, dataAtual, " +
                    " usuario_cid, usuario_nomeCompleto, situacao From Giro ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoGiro();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dGiro();
                            item.produto_cid = RetornarInteiro(row["produto_cid"]);
                            item.codigoBarras = RetornarTexto(row["codigoBarras"]);
                            item.dataInicio = RetornarTexto(row["dataInicio"]);
                            item.dataFim = RetornarTexto(row["dataFim"]);
                            item.dias = RetornarInteiro(row["dias"]);
                            item.quantidade = RetornarDecimal(row["quantidade"]);
                            item.dataAtual = RetornarTexto(row["dataAtual"]);
                            item.usuario_cid = RetornarInteiro(row["usuario_cid"]);
                            item.usuario_nomeCompleto = RetornarTexto(row["usuario_nomeCompleto"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Giro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoGiro Consultar(dGiro dados)
        {
            ColecaoGiro retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select produto_cid, codigoBarras, dataInicio, dataFim, dias, quantidade, dataAtual, " +
                    " usuario_cid, usuario_nomeCompleto, situacao ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From Giro ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.produto_cid, "produto_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.codigoBarras, "codigoBarras");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataInicio, "dataInicio");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataFim, "dataFim");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dias, "dias");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.quantidade, "quantidade");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.usuario_cid, "usuario_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.usuario_nomeCompleto, "usuario_nomeCompleto");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.situacao, "situacao");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoGiro();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dGiro();
                            item.produto_cid = RetornarInteiro(row["produto_cid"]);
                            item.codigoBarras = RetornarTexto(row["codigoBarras"]);
                            item.dataInicio = RetornarTexto(row["dataInicio"]);
                            item.dataFim = RetornarTexto(row["dataFim"]);
                            item.dias = RetornarInteiro(row["dias"]);
                            item.quantidade = RetornarDecimal(row["quantidade"]);
                            item.dataAtual = RetornarTexto(row["dataAtual"]);
                            item.usuario_cid = RetornarInteiro(row["usuario_cid"]);
                            item.usuario_nomeCompleto = RetornarTexto(row["usuario_nomeCompleto"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Giro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dGiro dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " Giro ( produto_cid, codigoBarras, dataInicio, dataFim, dias, quantidade, dataAtual, " +
                    " usuario_cid, usuario_nomeCompleto, situacao ) " +
                    " VALUES (" +
                    PersistirInteiro(dados.produto_cid) + "," +
                    PersistirTexto(dados.codigoBarras) + "," +
                    PersistirData(dados.dataInicio) + "," +
                    PersistirData(dados.dataFim) + "," +
                    PersistirInteiro(dados.dias) + "," +
                    PersistirDecimal(dados.quantidade) + "," +
                    PersistirData(dados.dataAtual) + "," +
                    PersistirInteiro(dados.usuario_cid) + "," +
                    PersistirTexto(dados.usuario_nomeCompleto) + "," +
                    PersistirTexto(dados.situacao) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Giro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Importar(dGiro dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " Giro ( produto_cid, codigoBarras, dataInicio, dataFim, dias, quantidade, dataAtual, " +
                    " usuario_cid, usuario_nomeCompleto, situacao ) " +
                    " VALUES (" +
                    PersistirInteiro(dados.produto_cid) + "," +
                    PersistirTexto(dados.codigoBarras) + "," +
                    PersistirData(dados.dataInicio) + "," +
                    PersistirData(dados.dataFim) + "," +
                    PersistirInteiro(dados.dias) + "," +
                    PersistirDecimal(dados.quantidade) + "," +
                    PersistirData(dados.dataAtual) + "," +
                    PersistirInteiro(dados.usuario_cid) + "," +
                    PersistirTexto(dados.usuario_nomeCompleto) + "," +
                    PersistirTexto(dados.situacao) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Importar Giro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dGiro dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE Giro SET " +
                    " dataInicio = " + PersistirData(dados.dataInicio) + "," +
                    " dataFim = " + PersistirData(dados.dataFim) + "," +
                    " dias = " + PersistirInteiro(dados.dias) + "," +
                    " quantidade= " + PersistirDecimal(dados.quantidade) + "," +
                    " dataAtual = " + PersistirData(dados.dataAtual) + "," +
                    " usuario_cid = " + PersistirInteiro(dados.usuario_cid) + "," +
                    " usuario_nomeCompleto = " + PersistirTexto(dados.usuario_nomeCompleto) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) + " " +
                    " WHERE " +
                    " produto_cid = " + PersistirInteiro(dados.produto_cid) + " AND " +
                    " codigoBarras = " + PersistirTexto(dados.codigoBarras);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Giro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dGiro dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM Giro " +
                    " WHERE " +
                    " produto_cid = " + PersistirInteiro(dados.produto_cid) + " AND " +
                    " codigoBarras = " + PersistirTexto(dados.codigoBarras);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Giro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
