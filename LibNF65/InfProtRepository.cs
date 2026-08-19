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
using Unimake.Business.DFe.Xml.NFSe.NACIONAL;


namespace LibNF65
{
    public class InfProtRepository : IInfProtRepository
    {

        private readonly string _connectionString;
        private string strConn = string.Empty;

        public InfProtRepository()
        {            
            var connStr = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);  //ConfigurationManager.ConnectionStrings["nascomercio"].ConnectionString;
            _connectionString = ExtrairPass(connStr.ConnectionStrings.ConnectionStrings["nascomercio"].ConnectionString);
      
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("A string de conexão 'MySqlConnection' não foi encontrada no App.config.");
            }
        }

        private string ExtrairPass(string strConn)
        {
            var builder = new MySqlConnectionStringBuilder(strConn);
            string password = builder.Password; // "15mysql"


            var cripto = new Criptografia();
            string descriptografado = string.Empty;



            if (!string.IsNullOrEmpty(password) && password.Length > 10)
            {
                descriptografado = cripto.Descriptografar(password).Split('\0')[0];
                cripto = null;
            }
            else
            {
                descriptografado = password?.Split('\0')[0];
            }

            cripto = null;

            strConn = strConn.Replace(password, descriptografado);

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
            const string sql = "SELECT * FROM infprot WHERE ChNFe = @ChNFe";

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
