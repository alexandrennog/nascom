using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum;
using ncModelos;

namespace ncRepositorios
{
    public class pUsuarioPerfil : RepositorioBase, IpUsuarioPerfil
    {
        public ColecaoUsuarioPerfil Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dUsuarioPerfil>("SELECT cid, codigo, nome, situacao FROM usuarioperfil").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoUsuarioPerfil();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar UsuarioPerfil [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoUsuarioPerfil Consultar(dUsuarioPerfil dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != 0) { conditions.Add("cid=@cid"); p.Add("cid", dados.cid); }
                    if (!string.IsNullOrEmpty(dados.codigo)) { conditions.Add("codigo=@codigo"); p.Add("codigo", dados.codigo); }
                    if (!string.IsNullOrEmpty(dados.nome)) { conditions.Add("nome=@nome"); p.Add("nome", dados.nome); }
                    if (!string.IsNullOrEmpty(dados.situacao)) { conditions.Add("situacao=@situacao"); p.Add("situacao", dados.situacao); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, codigo, nome, situacao FROM usuarioperfil {where}";
                    var lista = conn.Query<dUsuarioPerfil>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoUsuarioPerfil();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar UsuarioPerfil [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dUsuarioPerfil dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("INSERT INTO usuarioperfil (codigo, nome, situacao) VALUES (@codigo, @nome, @situacao)",
                        new { dados.codigo, dados.nome, dados.situacao });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir UsuarioPerfil [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dUsuarioPerfil dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE usuarioperfil SET codigo=@codigo, nome=@nome, situacao=@situacao WHERE cid=@cid",
                        new { dados.codigo, dados.nome, dados.situacao, dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar UsuarioPerfil [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dUsuarioPerfil dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM usuarioperfil WHERE cid=@cid", new { dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir UsuarioPerfil [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
