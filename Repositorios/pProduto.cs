using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using Comum;
using Modelos;

namespace Repositorios
{
    public class pProduto : RepositorioBase, IpProduto
    {
        public ColecaoProduto Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dProduto>(
                        "SELECT cid, codigo, descricao, situacao, produtoTipo_cid, fornecedor_cid, fabricante_cid, dataInclusao, valorCompra, valorVenda, referencia, imagem, estoqueMinimo, cor_cid, grupo_cid, aliquota, efdUnidadeMedidaCodigo, efdIntegracao FROM produtos").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoProduto();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Produto [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoProduto Consultar(dProduto dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != null && dados.cid != 0) { conditions.Add("p.cid=@cid"); p.Add("cid", dados.cid); }
                    if (!string.IsNullOrEmpty(dados.codigo)) { conditions.Add("p.codigo=@codigo"); p.Add("codigo", dados.codigo); }
                    if (!string.IsNullOrEmpty(dados.descricao)) { conditions.Add("p.descricao LIKE @descricao"); p.Add("descricao", $"%{dados.descricao}%"); }
                    if (!string.IsNullOrEmpty(dados.situacao)) { conditions.Add("p.situacao=@situacao"); p.Add("situacao", dados.situacao); }
                    if (!string.IsNullOrEmpty(dados.dataInclusao)) { conditions.Add("p.dataInclusao=@dataInclusao"); p.Add("dataInclusao", dados.dataInclusao); }
                    if (dados.valorCompra != 0) { conditions.Add("p.valorCompra=@valorCompra"); p.Add("valorCompra", dados.valorCompra); }
                    if (dados.valorVenda != 0) { conditions.Add("p.valorVenda=@valorVenda"); p.Add("valorVenda", dados.valorVenda); }
                    if (dados.fornecedor_cid != null && dados.fornecedor_cid != 0) { conditions.Add("p.fornecedor_cid=@fornecedor_cid"); p.Add("fornecedor_cid", dados.fornecedor_cid); }
                    if (dados.fabricante_cid != null && dados.fabricante_cid != 0) { conditions.Add("p.fabricante_cid=@fabricante_cid"); p.Add("fabricante_cid", dados.fabricante_cid); }
                    if (!string.IsNullOrEmpty(dados.referencia)) { conditions.Add("p.referencia=@referencia"); p.Add("referencia", dados.referencia); }
                    if (!string.IsNullOrEmpty(dados.imagem)) { conditions.Add("p.imagem=@imagem"); p.Add("imagem", dados.imagem); }
                    if (dados.cor_cid != null && dados.cor_cid != 0) { conditions.Add("p.cor_cid=@cor_cid"); p.Add("cor_cid", dados.cor_cid); }
                    if (dados.grupo_cid != null && dados.grupo_cid != 0) { conditions.Add("p.grupo_cid=@grupo_cid"); p.Add("grupo_cid", dados.grupo_cid); }
                    if (!string.IsNullOrEmpty(dados.aliquota)) { conditions.Add("p.aliquota=@aliquota"); p.Add("aliquota", dados.aliquota); }
                    if (dados.estoqueMinimo != null && dados.estoqueMinimo != 0) { conditions.Add("p.estoqueMinimo=@estoqueMinimo"); p.Add("estoqueMinimo", dados.estoqueMinimo); }
                    if (!string.IsNullOrEmpty(dados.codigoBarras)) { conditions.Add("pi.valor=@codigoBarras"); p.Add("codigoBarras", dados.codigoBarras); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $@"SELECT DISTINCT p.cid, p.codigo, p.descricao, p.situacao, p.produtoTipo_cid, p.fornecedor_cid, p.fabricante_cid,
                        p.dataInclusao, p.valorCompra, p.valorVenda, p.referencia, p.imagem, p.estoqueMinimo, p.cor_cid,
                        p.grupo_cid, p.aliquota, c.nome AS cor, g.nome AS grupo, p.efdUnidadeMedidaCodigo, p.efdCodigoCategoria, p.efdIntegracao, ct.nome AS efdCategoria
                        FROM produtos p
                        LEFT OUTER JOIN produtoitem pi ON pi.produtos_cid = p.cid AND pi.caracteristicas_cid = 1
                        LEFT OUTER JOIN cor c ON c.cid = p.cor_cid
                        LEFT OUTER JOIN categoria ct ON ct.cid = p.efdCodigoCategoria
                        LEFT OUTER JOIN grupo g ON g.cid = p.grupo_cid
                        {where}";
                    var lista = conn.Query<dProduto>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoProduto();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Produto [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoGradeEntrada ConsultarGradeEntrada(dProduto dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    conditions.Add($"(DATE_FORMAT(le.data,'%Y-%m-%d') BETWEEN '{dados.dataInicio}' AND '{dados.dataFinal}')");
                    if (dados.cid != null && dados.cid != 0) { conditions.Add("le.produto_cid=@cid"); p.Add("cid", dados.cid); }
                    var where = "WHERE " + string.Join(" AND ", conditions);
                    var sql = $@"SELECT
                        le.produto_cid AS produto_cid,
                        le.produtoitem_codigobarras AS codigoBarras,
                        DATE_FORMAT(le.data,'%Y-%m-%d') AS entrada_data,
                        pi.item AS item,
                        (SELECT pi2.valor FROM produtoitem pi2 WHERE pi2.produtos_cid = produto_cid AND pi2.item = pi.item AND pi2.caracteristicas_cid = 3) AS tamanho,
                        SUM(le.quantidade) AS entrada_qtde
                        FROM logestoque le
                        INNER JOIN produtoitem pi ON (pi.valor = le.produtoitem_codigobarras AND pi.caracteristicas_cid = 1)
                        {where}
                        GROUP BY le.produto_cid, le.produtoitem_codigobarras, entrada_data, item, tamanho
                        ORDER BY produto_cid, entrada_data, produtoitem_codigobarras";
                    var lista = conn.Query<dGradeEntrada>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoGradeEntrada();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Grade Entrada [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ConsultarProximoCID()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.QueryFirstOrDefault<int?>("SELECT MAX(cid) FROM produtos") ?? 0;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarProximoCID Produto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dProduto dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("INSERT INTO produtos (codigo, descricao, produtoTipo_cid, fornecedor_cid, fabricante_cid, valorCompra, valorVenda, referencia, imagem, situacao, cor_cid, grupo_cid, estoqueMinimo, aliquota, dataInclusao, efdUnidadeMedidaCodigo, efdCodigoCategoria, efdIntegracao) VALUES (@codigo, @descricao, @produtoTipo_cid, @fornecedor_cid, @fabricante_cid, @valorCompra, @valorVenda, @referencia, @imagem, @situacao, @cor_cid, @grupo_cid, @estoqueMinimo, @aliquota, @dataInclusao, @efdUnidadeMedidaCodigo, @efdCodigoCategoria, @efdIntegracao)",
                        new { dados.codigo, dados.descricao, dados.produtoTipo_cid, dados.fornecedor_cid, dados.fabricante_cid, dados.valorCompra, dados.valorVenda, dados.referencia, dados.imagem, dados.situacao, dados.cor_cid, dados.grupo_cid, dados.estoqueMinimo, dados.aliquota, dados.dataInclusao, dados.efdUnidadeMedidaCodigo, dados.efdCodigoCategoria, dados.efdIntegracao });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Produto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Importar(dProduto dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("INSERT INTO produtos (cid, codigo, descricao, produtoTipo_cid, fornecedor_cid, fabricante_cid, valorCompra, valorVenda, referencia, imagem, situacao, cor_cid, grupo_cid, estoqueMinimo, aliquota, dataInclusao) VALUES (@cid, @codigo, @descricao, @produtoTipo_cid, @fornecedor_cid, @fabricante_cid, @valorCompra, @valorVenda, @referencia, @imagem, @situacao, @cor_cid, @grupo_cid, @estoqueMinimo, @aliquota, @dataInclusao)",
                        new { dados.cid, dados.codigo, dados.descricao, dados.produtoTipo_cid, dados.fornecedor_cid, dados.fabricante_cid, dados.valorCompra, dados.valorVenda, dados.referencia, dados.imagem, dados.situacao, dados.cor_cid, dados.grupo_cid, dados.estoqueMinimo, dados.aliquota, dados.dataInclusao });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Importar Produto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dProduto dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE produtos SET codigo=@codigo, descricao=@descricao, produtoTipo_cid=@produtoTipo_cid, fornecedor_cid=@fornecedor_cid, fabricante_cid=@fabricante_cid, valorCompra=@valorCompra, valorVenda=@valorVenda, imagem=@imagem, referencia=@referencia, situacao=@situacao, cor_cid=@cor_cid, grupo_cid=@grupo_cid, estoqueMinimo=@estoqueMinimo, aliquota=@aliquota, dataInclusao=@dataInclusao, efdUnidadeMedidaCodigo=@efdUnidadeMedidaCodigo, efdCodigoCategoria=@efdCodigoCategoria, efdIntegracao=@efdIntegracao WHERE cid=@cid",
                        new { dados.codigo, dados.descricao, dados.produtoTipo_cid, dados.fornecedor_cid, dados.fabricante_cid, dados.valorCompra, dados.valorVenda, dados.imagem, dados.referencia, dados.situacao, dados.cor_cid, dados.grupo_cid, dados.estoqueMinimo, dados.aliquota, dados.dataInclusao, dados.efdUnidadeMedidaCodigo, dados.efdCodigoCategoria, dados.efdIntegracao, dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Produto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dProduto dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM produtos WHERE cid=@cid", new { dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Produto [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
