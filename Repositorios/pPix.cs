using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using Comum;
using Modelos;

namespace Repositorios
{
    public class pPix : RepositorioBase, IpPix
    {
        public ColecaoPix Consultar(dPix dados)
        {
            try
            {
                using var conn = CriarConexao();
                var lista = conn.Query<dPix>(
                    "SELECT cid, txid, status, valor, dataCriacao, dataAtualizacao, clientes_cid FROM pix WHERE (@txid IS NULL OR txid = @txid) AND (@clientes_cid IS NULL OR clientes_cid = @clientes_cid)",
                    dados).AsList();
                return lista.Count == 0 ? null! : [.. lista];
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Pix - " + ex.Message); }
        }

        public dPix Consultar(string tx)
        {
            try
            {
                using var conn = CriarConexao();
                var lista = conn.Query<dPix>(
                    "SELECT cid, txid, status, valor, dataCriacao, dataAtualizacao, clientes_cid FROM pix WHERE txid = @tx",
                    new { tx }).AsList();
                return lista.Count > 0 ? lista[0] : null!;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Pix por TX - " + ex.Message); }
        }

        public dPixConfig ConsultarConfig()
        {
            try
            {
                using var conn = CriarConexao();
                var lista = conn.Query<dPixConfig>("SELECT * FROM pixconfig LIMIT 1").AsList();
                return lista.Count > 0 ? lista[0] : null!;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarConfig Pix - " + ex.Message); }
        }

        public int Incluir(dPix dados)
        {
            try
            {
                using var conn = CriarConexao();
                return conn.Execute(
                    "INSERT INTO pix (txid, status, valor, dataCriacao, dataAtualizacao, clientes_cid) VALUES (@txid, @status, @valor, @dataCriacao, @dataAtualizacao, @clientes_cid)",
                    dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Pix - " + ex.Message); }
        }

        public int IncluirPixConfig(dPixConfig dados)
        {
            try
            {
                using var conn = CriarConexao();
                return conn.Execute(
                    "INSERT INTO pixconfig (chave, clientId, clientSecret, certificado, ambiente) VALUES (@chave, @clientId, @clientSecret, @certificado, @ambiente)",
                    dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em IncluirPixConfig - " + ex.Message); }
        }

        public int AlterarPixConfig(dPixConfig dados)
        {
            try
            {
                using var conn = CriarConexao();
                return conn.Execute(
                    "UPDATE pixconfig SET chave=@chave, clientId=@clientId, clientSecret=@clientSecret, certificado=@certificado, ambiente=@ambiente WHERE cid=@cid",
                    dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em AlterarPixConfig - " + ex.Message); }
        }
    }
}
