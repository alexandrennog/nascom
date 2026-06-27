using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsVeiculos;

namespace ncPersistencia.nsVeiculos
{
    public class pVeiculos
    {
        public ColecaoVeiculos Listar()
        {
            ColecaoVeiculos retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, clienteid, placa, marca, modelo, cor, ano, combustivel From veiculo";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoVeiculos();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dVeiculos();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.clienteId = RetornarInteiro(row["clienteid"]);
                            item.Placa = RetornarTexto(row["placa"]);
                            item.Marca = RetornarTexto(row["marca"]);
                            item.Modelo = RetornarTexto(row["modelo"]);
                            item.Cor = RetornarTexto(row["cor"]);
                            item.Ano = RetornarTexto(row["ano"]);
                            item.Combustivel = RetornarTexto(row["combustivel"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Veiculos [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoVeiculos Consultar(dVeiculos dados)
        {
            ColecaoVeiculos retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, clienteid, placa, marca, modelo, cor, ano, combustivel ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From Veiculo ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
                if (dados.clienteId != 0)
                    sqlWhere = MontarParametrosSQL(sqlWhere, dados.clienteId, "clienteid");
                if (dados.Placa != 0)
                    sqlWhere = MontarParametrosSQL(sqlWhere, dados.Placa, "placa");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoVeiculos();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dVeiculos();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.clienteId = RetornarInteiro(row["clienteid"]);
                            item.Placa = RetornarTexto(row["placa"]);
                            item.Marca = RetornarTexto(row["marca"]);
                            item.Modelo = RetornarTexto(row["modelo"]);
                            item.Cor = RetornarTexto(row["cor"]);
                            item.Ano = RetornarTexto(row["ano"]);
                            item.Combustivel = RetornarTexto(row["combustivel"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Veiculos[" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dVeiculos dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " Veiculo ( clienteid, placa, marca, modelo, cor, ano, combustivel ) " +
                    " VALUES (" +
                    PersistirInteiro(dados.clienteId) + "," +
                    PersistirTexto(dados.Placa) + "," +
                    PersistirTexto(dados.Marca) + "," +
                    PersistirTexto(dados.Modelo) + "," +
                    PersistirTexto(dados.Cor) + "," +
                    PersistirTexto(dados.Ano) + "," +
                    PersistirTexto(dados.Combustivel) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Veiculos [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dVeiculos dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE Veiculo SET " +
                    " clienteid = " + PersistirInteiro(dados.clienteId) + "," +
                    " placa = " + PersistirTexto(dados.Placa) + "," +
                    " marca = " + PersistirTexto(dados.Marca) + "," +
                    " modelo = " + PersistirTexto(dados.Modelo) + "," +
                    " cor = " + PersistirTexto(dados.Cor) + "," +
                    " ano = " + PersistirTexto(dados.Ano) + "," +
                    " combustivel = " + PersistirTexto(dados.Combustivel) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Veiculos [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dVeiculos dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM Veiculo " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Veiculos [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int ExcluirVeiculosCliente(dVeiculos dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM Veiculo " +
                    " WHERE clienteid = " + dados.clienteId.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Veiculos [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
