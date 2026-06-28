using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum;
using ncModelos;

namespace ncRepositorios
{
    public class pCaracteristicaItem : RepositorioBase, IpCaracteristicaItem
    {
        public ColecaoCaracteristicaItem Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dCaracteristicaItem>("SELECT cid, caracteristicas_cid, valor FROM caracteristicaitem").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoCaracteristicaItem();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoCaracteristicaItem Consultar(dCaracteristicaItem dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != 0) { conditions.Add("cid=@cid"); p.Add("cid", dados.cid); }
                    if (dados.caracteristicas_cid != 0) { conditions.Add("caracteristicas_cid=@caracteristicas_cid"); p.Add("caracteristicas_cid", dados.caracteristicas_cid); }
                    if (!string.IsNullOrEmpty(dados.valor)) { conditions.Add("valor=@valor"); p.Add("valor", dados.valor); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, caracteristicas_cid, valor FROM caracteristicaitem {where}";
                    var lista = conn.Query<dCaracteristicaItem>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoCaracteristicaItem();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dCaracteristicaItem dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("INSERT INTO caracteristicaitem (caracteristicas_cid, valor) VALUES (@caracteristicas_cid, @valor)",
                        new { dados.caracteristicas_cid, dados.valor });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dCaracteristicaItem dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE caracteristicaitem SET caracteristicas_cid=@caracteristicas_cid, valor=@valor WHERE cid=@cid",
                        new { dados.caracteristicas_cid, dados.valor, dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dCaracteristicaItem dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM caracteristicaitem WHERE cid=@cid", new { dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
