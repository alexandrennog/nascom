using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum;
using ncModelos;

namespace ncRepositorios
{
    public class pProdutoTipoCaracteristica : RepositorioBase, IpProdutoTipoCaracteristica
    {
        public ColecaoProdutoTipoCaracteristica Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dProdutoTipoCaracteristica>(
                        @"SELECT ptc.cid, ptc.produtoTipo_cid, ptc.caracteristica_cid, c.nome AS caracteristica_nome, c.codigo AS caracteristica_codigo
                        FROM produtotipocaracteristica ptc
                        INNER JOIN caracteristicas c ON c.cid = ptc.caracteristica_cid").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoProdutoTipoCaracteristica();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoProdutoTipoCaracteristica ConsultarPorProdutoTipo(int produtoTipo_cid)
        {
            try
            {
                var dados = new dProdutoTipoCaracteristica();
                dados.produtoTipo_cid = produtoTipo_cid;
                return Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoProdutoTipoCaracteristica Consultar(dProdutoTipoCaracteristica dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != 0) { conditions.Add("cid=@cid"); p.Add("cid", dados.cid); }
                    if (dados.produtoTipo_cid != 0) { conditions.Add("produtoTipo_cid=@produtoTipo_cid"); p.Add("produtoTipo_cid", dados.produtoTipo_cid); }
                    if (dados.caracteristica_cid != 0) { conditions.Add("caracteristica_cid=@caracteristica_cid"); p.Add("caracteristica_cid", dados.caracteristica_cid); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $@"SELECT ptc.cid, ptc.produtoTipo_cid, ptc.caracteristica_cid, c.nome AS caracteristica_nome, c.codigo AS caracteristica_codigo,
                        (SELECT COUNT(*) FROM caracteristicaitem WHERE caracteristicas_cid = ptc.caracteristica_cid) AS quantidade
                        FROM produtotipocaracteristica ptc
                        INNER JOIN caracteristicas c ON c.cid = ptc.caracteristica_cid
                        {where} ORDER BY c.nome";
                    var lista = conn.Query<dProdutoTipoCaracteristica>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoProdutoTipoCaracteristica();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dProdutoTipoCaracteristica dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("INSERT INTO produtotipocaracteristica (produtoTipo_cid, caracteristica_cid) VALUES (@produtoTipo_cid, @caracteristica_cid)",
                        new { dados.produtoTipo_cid, dados.caracteristica_cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirPorProdutoTipo(int produtoTipo_cid)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM produtotipocaracteristica WHERE produtoTipo_cid=@produtoTipo_cid", new { produtoTipo_cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirPorCaracteristica(int caracteristica_cid)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM produtotipocaracteristica WHERE caracteristica_cid=@caracteristica_cid", new { caracteristica_cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(int cid)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM produtotipocaracteristica WHERE cid=@cid", new { cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
