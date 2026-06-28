using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum;
using ncModelos;
using ncRepositorios;

public class ColecaoPix : System.Collections.Generic.List<dPix> { }

public class pPix : RepositorioBase, IpPix
{
    public ColecaoPix Consultar(dPix dados)
    {
        try
        {
            using (var conn = CriarConexao())
            {
                var conditions = new List<string>();
                var p = new DynamicParameters();
                if (dados.TxId != "0") { conditions.Add("TxId=@TxId"); p.Add("TxId", dados.TxId); }
                if (dados.Controle != 0) { conditions.Add("controle=@Controle"); p.Add("Controle", dados.Controle); }
                var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                var sql = $"SELECT txID AS TxId, Observacao, SolicitacaoPagador AS Pagador, DataHora, Original, controle AS Controle, Status FROM PIX {where} ORDER BY DataHora DESC";
                var lista = conn.Query<dPix>(sql, p).AsList();
                if (lista.Count == 0) return null;
                var retorno = new ColecaoPix();
                retorno.AddRange(lista);
                return retorno;
            }
        }
        catch (ExcecaoNascomercio) { throw; }
        catch (Exception ex)
        {
            throw new ExcecaoNascomercio("Erro em Consultar Pix[" + ToString() + "] - " + ex.Message);
        }
    }

    public dPix Consultar(string tx)
    {
        try
        {
            using (var conn = CriarConexao())
            {
                var p = new DynamicParameters();
                var where = "";
                if (!string.IsNullOrEmpty(tx)) { where = "WHERE txID=@tx"; p.Add("tx", tx); }
                var sql = $"SELECT ID, txID AS TxId, SolicitacaoPagador AS Pagador, Original, status AS Status, Observacao, DataHora, controle AS Controle, UrlPix FROM PIX {where} ORDER BY DataHora DESC LIMIT 1";
                return conn.QueryFirstOrDefault<dPix>(sql, p);
            }
        }
        catch (ExcecaoNascomercio) { throw; }
        catch (Exception ex)
        {
            throw new ExcecaoNascomercio("Erro em Consultar Pix[" + ToString() + "] - " + ex.Message);
        }
    }

    public dPixConfig ConsultarConfig()
    {
        try
        {
            using (var conn = CriarConexao())
            {
                return conn.QueryFirstOrDefault<dPixConfig>(
                    "SELECT Banco, Cliente, Cpf, Cnpj, Nome, Chave, Client_id AS ClientID, client_secret AS ClientSecret, PathCertificate AS CertPath, PassCertificate AS CertPass, Email FROM pixconfig");
            }
        }
        catch (ExcecaoNascomercio) { throw; }
        catch (Exception ex)
        {
            throw new ExcecaoNascomercio("Erro em Consultar Pix[" + ToString() + "] - " + ex.Message);
        }
    }

    public int Incluir(dPix dados)
    {
        try
        {
            using (var conn = CriarConexao())
            {
                string id = DateTime.Now.ToString("yyyyMMddHHmmss");
                string datahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                conn.Execute("INSERT INTO PIX (ID, SolicitacaoPagador, Original, DataHora, Observacao, controle) VALUES (@id, @Pagador, @Original, @datahora, @Observacao, @Controle)",
                    new { id, dados.Pagador, dados.Original, datahora, dados.Observacao, dados.Controle });
                return conn.QueryFirstOrDefault<int>("SELECT controle FROM pix WHERE datahora = (SELECT MAX(datahora) FROM pix)");
            }
        }
        catch (ExcecaoNascomercio) { throw; }
        catch (Exception ex)
        {
            throw new ExcecaoNascomercio("Erro em Incluir Pix [" + ToString() + "] - " + ex.Message);
        }
    }

    public int IncluirPixConfig(dPixConfig dados)
    {
        try
        {
            using (var conn = CriarConexao())
            {
                conn.Execute("INSERT INTO pixconfig (Banco, Cliente, Cpf, Cnpj, Nome, chave, Client_id, client_secret, PathCertificate, PassCertificate, Email) VALUES (@Banco, @Cliente, @Cpf, @Cnpj, @Nome, @Chave, @ClientID, @ClientSecret, @CertPath, @CertPass, @Email)",
                    new { dados.Banco, dados.Cliente, dados.Cpf, dados.Cnpj, dados.Nome, dados.Chave, dados.ClientID, dados.ClientSecret, dados.CertPath, dados.CertPass, dados.Email });
                return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
            }
        }
        catch (ExcecaoNascomercio) { throw; }
        catch (Exception ex)
        {
            throw new ExcecaoNascomercio("Erro em Incluir Pix [" + ToString() + "] - " + ex.Message);
        }
    }

    public int AlterarPixConfig(dPixConfig dados)
    {
        try
        {
            using (var conn = CriarConexao())
            {
                return conn.Execute("UPDATE pixconfig SET Banco=@Banco, Cpf=@Cpf, Cnpj=@Cnpj, Nome=@Nome, chave=@Chave, Client_id=@ClientID, client_secret=@ClientSecret, PathCertificate=@CertPath, PassCertificate=@CertPass",
                    new { dados.Banco, dados.Cpf, dados.Cnpj, dados.Nome, dados.Chave, dados.ClientID, dados.ClientSecret, dados.CertPath, dados.CertPass });
            }
        }
        catch (ExcecaoNascomercio) { throw; }
        catch (Exception ex)
        {
            throw new ExcecaoNascomercio("Erro em Alterar Configuração pix [" + ToString() + "] - " + ex.Message);
        }
    }
}
