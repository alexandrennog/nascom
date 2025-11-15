using Dapper;
using LibNF65.Interfaces;
using LibNF65.Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibNF65
{
    public class InfProtRepository : IInfProtRepository
    {

        private readonly string _connectionString;

        public InfProtRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["nascomercio"].ConnectionString;
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("A string de conexão 'MySqlConnection' não foi encontrada no App.config.");
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
