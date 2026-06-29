using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using Comum;
using Modelos;

namespace Repositorios
{
    public class pMunicipios : RepositorioBase, IpMunicipios
    {
        public ColecaoMunicipios Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dMunicipios>(
                        "SELECT cid, codigo_ibge, nome, estados_cid, situacao FROM municipios ORDER BY nome").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoMunicipios();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar municipios [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoMunicipios ListarPorEstado(int estados_cid)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var p = new DynamicParameters();
                    p.Add("estados_cid", estados_cid);
                    var lista = conn.Query<dMunicipios>(
                        "SELECT cid, codigo_ibge, nome, estados_cid, situacao FROM municipios WHERE estados_cid=@estados_cid ORDER BY nome", p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoMunicipios();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar municipios [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoMunicipios Consultar(dMunicipios dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != null && dados.cid != 0) { conditions.Add("cid=@cid"); p.Add("cid", dados.cid); }
                    if (!string.IsNullOrEmpty(dados.codigo_ibge)) { conditions.Add("codigo_ibge=@codigo_ibge"); p.Add("codigo_ibge", dados.codigo_ibge); }
                    if (!string.IsNullOrEmpty(dados.nome)) { conditions.Add("nome=@nome"); p.Add("nome", dados.nome); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, nome, situacao, codigo_ibge, estados_cid FROM municipios {where} ORDER BY nome";
                    var lista = conn.Query<dMunicipios>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoMunicipios();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar municipios [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dMunicipios dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(
                        "INSERT INTO municipios (codigo_ibge, nome, estados_cid, situacao) VALUES (@codigo_ibge, @nome, @estados_cid, 'A')",
                        new { codigo_ibge = dados.codigo_ibge, nome = dados.nome, estados_cid = dados.estados_cid });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir municipios [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Importar(dMunicipios dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(
                        "INSERT INTO municipios (cid, codigo_ibge, nome, estados_cid, situacao) VALUES (@cid, @codigo_ibge, @nome, @estados_cid, 'A')",
                        new { cid = dados.cid, codigo_ibge = dados.codigo_ibge, nome = dados.nome, estados_cid = dados.estados_cid });
                    return 1;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Importar municipios [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dMunicipios dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute(
                        "UPDATE municipios SET codigo_ibge=@codigo_ibge, nome=@nome, estados_cid=@estados_cid, situacao=@situacao WHERE cid=@cid",
                        new { codigo_ibge = dados.codigo_ibge, nome = dados.nome, estados_cid = dados.estados_cid, situacao = dados.situacao, cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar municipios [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dMunicipios dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM municipios WHERE cid=@cid", new { cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir municipios [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
