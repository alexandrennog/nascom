using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using Comum;
using Modelos;

namespace Repositorios
{
    public class pEfdUnidadeMedida : RepositorioBase, IpEfdUnidadeMedida
    {
        public ColecaoEfdUnidadeMedida Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dEfdUnidadeMedida>(
                        "SELECT codigo, descricao FROM EfdUnidadeMedida ORDER BY descricao").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoEfdUnidadeMedida();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar EfdUnidadeMedida [" + ToString() + "] - " + ex.Message);
            }
        }

        public dEfdUnidadeMedida Consultar(dEfdUnidadeMedida dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (!string.IsNullOrEmpty(dados.codigo)) { conditions.Add("codigo=@codigo"); p.Add("codigo", dados.codigo); }
                    if (!string.IsNullOrEmpty(dados.descricao)) { conditions.Add("descricao=@descricao"); p.Add("descricao", dados.descricao); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT codigo, descricao FROM EfdUnidadeMedida {where} ORDER BY descricao";
                    return conn.QueryFirstOrDefault<dEfdUnidadeMedida>(sql, p);
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar EfdUnidadeMedida [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dEfdUnidadeMedida dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM EfdUnidadeMedida WHERE codigo=@codigo", new { codigo = dados.codigo });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir EfdUnidadeMedida [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dEfdUnidadeMedida dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(
                        "INSERT INTO EfdUnidadeMedida (codigo, descricao) VALUES (@codigo, @descricao)",
                        new { codigo = dados.codigo, descricao = dados.descricao });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir EfdUnidadeMedida [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dEfdUnidadeMedida dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute(
                        "UPDATE EfdUnidadeMedida SET descricao=@descricao WHERE codigo=@codigo",
                        new { descricao = dados.descricao, codigo = dados.codigo });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar EfdUnidadeMedida [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
