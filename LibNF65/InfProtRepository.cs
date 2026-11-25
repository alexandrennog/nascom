using Dapper;
using LibNF65.Interfaces;
using LibNF65.Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unimake.Business.DFe;
using Unimake.Business.DFe.Xml.NFe;

namespace LibNF65
{
    public class InfProtRepository : IInfProtRepository
    {

        private readonly string _connectionString;

        public InfProtRepository()
        {
            _connectionString = ExtrairPass(ConfigurationManager.ConnectionStrings["nascomercio"].ConnectionString);
            //_connectionString = ConfigurationManager.ConnectionStrings["nascomercio"].ConnectionString;

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("A string de conexão 'MySqlConnection' não foi encontrada no App.config.");
            }
        }

        private string ExtrairPass(string strConn)
        {
            var builder = new System.Data.Common.DbConnectionStringBuilder();
            var cripto = new Criptografia();

            builder.ConnectionString = strConn;

            string password = builder["Password"].ToString();

            string descriptografado = cripto.Descriptografar(password);

            string result = descriptografado.Split('\0')[0]; // '\0' = vbNullChar

            cripto = null;

            strConn = strConn.Replace(password, result);

            return strConn;
        }

        public PixConfig GetPixConfig()
        {

            string sql = $"SELECT Banco, Cliente,Cpf ,Cnpj,Nome, Chave, Client_id, client_secret, PathCertificate, PassCertificate FROM pixconfig";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<PixConfig>(sql).FirstOrDefault();
            }
        }

        private IDbConnection Connection
        {
            get { return new MySqlConnection(_connectionString); }
        }

        public void Add(InfoProduto infoProduto)
        {
            const string sql = @"
                INSERT INTO infprot (VerAplic, ChNFe, DhRecbto, NProt, DigVal, CStat, XMotivo, CMsg, XMsg)
                VALUES (@VerAplic, @ChNFe, @DhRecbto, @NProt, @DigVal, @CStat, @XMotivo, @CMsg, @XMsg)";

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute(sql, infoProduto);
            }
        }

        public InfoProduto GetByChNFe(string chNFe)
        {
            // A mesma chave pode ter mais de uma linha: o GerarNF grava a resposta da
            // SEFAZ também quando ela REJEITA, e a reemissão no mesmo número/mês gera a
            // mesma chave. Quem lê isto (cancelamento) precisa do protocolo da
            // AUTORIZAÇÃO: autorizada (100/150) primeiro, depois a mais recente.
            const string sql = "SELECT * FROM infprot WHERE ChNFe = @ChNFe " +
                               "ORDER BY (cstat IN (100, 150)) DESC, dhrecbto DESC";

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<InfoProduto>(sql, new { ChNFe = chNFe }).FirstOrDefault();
            }
        }

        public IEnumerable<InfoProduto> GetAll()
        {
            const string sql = "SELECT * FROM infprot";

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<InfoProduto>(sql);
            }
        }

        public void Update(InfoProduto infoProduto)
        {
            const string sql = @"
                UPDATE infprot SET
                    VerAplic = @VerAplic,
                    DhRecbto = @DhRecbto,
                    NProt = @NProt,
                    DigVal = @DigVal,
                    CStat = @CStat,
                    XMotivo = @XMotivo,
                    CMsg = @CMsg,
                    XMsg = @XMsg
                WHERE ChNFe = @ChNFe";

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute(sql, infoProduto);
            }
        }

        public void UpdateEvent(string ChNFe, string xEvento, string NProt)
        {
            const string sql = @"
                UPDATE infprot SET
                    NProt = @NProt,
                    xEvento = @xEvento
                WHERE ChNFe = @ChNFe";

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute(sql, new
                {
                    ChNFe = ChNFe,
                    xEvento = xEvento,
                    NProt = NProt
                });
            }            
        }

        public void Delete(string chNFe)
        {
            const string sql = "DELETE FROM infprot WHERE ChNFe = @ChNFe";

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute(sql, new { ChNFe = chNFe });
            }
        }
    }
}
