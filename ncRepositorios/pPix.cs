using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;


public class ColecaoPix : System.Collections.Generic.List<dPix> { }

public class pPix
{
    public ColecaoPix Consultar(dPix dados)
    {
        ColecaoPix retorno = null;
        try
        {
            var acessoBanco = new cAcessoBD();
            string sqlSelect = " Select txID, Observacao, SolicitacaoPagador as pagador, DataHora, Original, controle, Status ";
            string sqlFrom = " From PIX ";
            string sqlWhere = string.Empty;

            if (dados.TxId != "0")
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.TxId, "TxId");

            if (dados.Controle != 0)
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.Controle, "controle");

            if (!sqlWhere.Equals(string.Empty))
                sqlWhere = " WHERE " + sqlWhere;

            sqlWhere = sqlWhere + " order by DataHora desc ";

            var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    retorno = new ColecaoPix();
                    foreach (DataRow row in dt.Rows)
                    {
                        var item = new dPix();
                        item.TxId = RetornarTexto(row["TxId"]);
                        item.Observacao = RetornarTexto(row["Observacao"]);
                        item.Pagador = RetornarTexto(row["pagador"]);
                        item.Original = (decimal)RetornarDecimal(row["Original"]);
                        item.Controle = (int)RetornarInteiro(row["controle"]);
                        item.Status = RetornarTexto(row["Status"]);
                        item.DataHora = RetornarDataValida(row["DataHora"].ToString());
                        retorno.Add(item);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            retorno = null;
            throw new ExcecaoNascomercio("Erro em Consultar Pix[" + ToString() + "] - " + ex.Message);
        }
        return retorno;
    }

    public dPix Consultar(string tx)
    {
        dPix retorno = null;
        try
        {
            var acessoBanco = new cAcessoBD();
            string sqlSelect = " Select ID, txID, SolicitacaoPagador, Original, status, Observacao, DataHora, controle, UrlPix   ";
            string sqlWhere = "";

            if (!string.IsNullOrEmpty(tx))
                sqlWhere = $" WHERE txID = '{tx}'";

            sqlWhere = sqlWhere + " order by DataHora desc LIMIT 1;";
            string sqlFrom = " From PIX ";

            var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    retorno = new dPix();
                    foreach (DataRow row in dt.Rows)
                    {
                        var item = new dPix();
                        item.ID = RetornarTexto(row["ID"]);
                        item.TxId = RetornarTexto(row["TxId"]);
                        item.Original = (decimal)RetornarDecimal(row["Original"]);
                        item.Status = RetornarTexto(row["status"]);
                        item.DataHora = RetornarDataValida(row["DataHora"].ToString());
                        item.Observacao = RetornarTexto(row["Observacao"]);
                        item.Controle = (int)RetornarInteiro(row["controle"]);
                        item.UrlPix = RetornarTexto(row["UrlPix"]);
                        retorno = item;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            retorno = null;
            throw new ExcecaoNascomercio("Erro em Consultar Pix[" + ToString() + "] - " + ex.Message);
        }
        return retorno;
    }

    public dPixConfig ConsultarConfig()
    {
        dPixConfig retorno = null;
        dPixConfig item = null;
        try
        {
            var acessoBanco = new cAcessoBD();
            string sqlSelect = " SELECT Banco, Cliente, Cpf, Cnpj, Nome, Chave, Client_id, client_secret, PathCertificate, PassCertificate, Email";
            string sqlFrom = "  FROM pixconfig ";

            var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    retorno = new dPixConfig();
                    foreach (DataRow row in dt.Rows)
                    {
                        item = new dPixConfig();
                        item.Banco = RetornarTexto(row["Banco"]);
                        item.Cliente = (int)RetornarInteiro(row["Cliente"]);
                        item.Cpf = RetornarTexto(row["Cpf"]);
                        item.Cnpj = RetornarTexto(row["Cnpj"]);
                        item.Nome = RetornarTexto(row["Nome"]);
                        item.Chave = RetornarTexto(row["Chave"]);
                        item.ClientID = RetornarTexto(row["Client_id"]);
                        item.ClientSecret = RetornarTexto(row["client_secret"]);
                        item.CertPath = RetornarTexto(row["PathCertificate"]);
                        item.CertPass = RetornarTexto(row["PassCertificate"]);
                        item.Email = RetornarTexto(row["Email"]);
                    }
                    retorno = item;
                }
            }
        }
        catch (Exception ex)
        {
            retorno = null;
            throw new ExcecaoNascomercio("Erro em Consultar Pix[" + ToString() + "] - " + ex.Message);
        }
        return retorno;
    }

    public int Incluir(dPix dados)
    {
        int retorno = 0;
        try
        {
            var acessoBanco = new cAcessoBD();
            string comandoSQL = " INSERT INTO PIX (ID, SolicitacaoPagador, Original, DataHora, Observacao, controle)  VALUES (";
            comandoSQL += PersistirTexto(DateTime.Now.ToString("yyyyMMddHHmmss")) + "," + PersistirTexto(dados.Pagador) + "," + PersistirDecimal(dados.Original);
            comandoSQL += "," + PersistirDataHora(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")) + "," + PersistirTexto(dados.Observacao) + "," + PersistirInteiro(dados.Controle) + ")";

            retorno = acessoBanco.ExecutarCID(comandoSQL);

            comandoSQL = " SELECT controle FROM pix where datahora = (select MAX(datahora) from pix);";
            var ds = acessoBanco.ExecutarDS(comandoSQL);

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        retorno = (int)RetornarInteiro(row["controle"].ToString());
                    }
                }
                else
                {
                    retorno = 0;
                }
            }
            else
            {
                retorno = 0;
            }
        }
        catch (Exception ex)
        {
            retorno = 0;
            throw new ExcecaoNascomercio("Erro em Incluir Pix [" + ToString() + "] - " + ex.Message);
        }
        return retorno;
    }

    public int IncluirPixConfig(dPixConfig dados)
    {
        int retorno = 0;
        try
        {
            var acessoBanco = new cAcessoBD();
            string comandoSQL = " INSERT INTO pixconfig (Banco, Cliente, Cpf, Cnpj, Nome, chave, Client_id, client_secret, PathCertificate, PassCertificate, Email)  VALUES (";
            comandoSQL += PersistirTexto(dados.Banco) + "," + PersistirInteiro(dados.Cliente) + "," +
                PersistirTexto(dados.Cpf) + "," + PersistirTexto(dados.Cnpj) + "," + PersistirTexto(dados.Nome) + "," +
                PersistirTexto(dados.Chave) + "," + PersistirTexto(dados.ClientID) + "," + PersistirTexto(dados.ClientSecret) + "," +
                PersistirTexto(dados.CertPath) + "," + PersistirTexto(dados.CertPass) + "," + PersistirTexto(dados.Email) + ")";
            retorno = acessoBanco.ExecutarCID(comandoSQL);
        }
        catch (Exception ex)
        {
            retorno = 0;
            throw new ExcecaoNascomercio("Erro em Incluir Pix [" + ToString() + "] - " + ex.Message);
        }
        return retorno;
    }

    public int AlterarPixConfig(dPixConfig dados)
    {
        int retorno = 0;
        try
        {
            var acessoBanco = new cAcessoBD();
            string comandoSQL = " UPDATE pixconfig SET " +
                " Banco = " + PersistirTexto(dados.Banco) + "," +
                " Cpf = " + PersistirTexto(dados.Cpf) + "," +
                " Cnpj = " + PersistirTexto(dados.Cnpj) + "," +
                " Nome = " + PersistirTexto(dados.Nome) + "," +
                " chave = " + PersistirTexto(dados.Chave) + "," +
                " Client_id = " + PersistirData(dados.ClientID) + "," +
                " client_secret = " + PersistirTexto(dados.ClientSecret) + "," +
                " PathCertificate = " + PersistirTexto(dados.CertPath) + "," +
                " PassCertificate = " + PersistirTexto(dados.CertPass);
            retorno = acessoBanco.ExecutarINT(comandoSQL);
        }
        catch (Exception ex)
        {
            retorno = 0;
            throw new ExcecaoNascomercio("Erro em Alterar Configuração pix [" + ToString() + "] - " + ex.Message);
        }
        return retorno;
    }
}
