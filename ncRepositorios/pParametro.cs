using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;
using nsParametro;
using nsdParametroEstoque;

namespace ncPersistencia.nsParametro
{
    public class pParametro : RepositorioBase, IpParametro
    {
        public ColecaoParametro Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dParametro>("SELECT cid, descricao, valor FROM Parametros").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoParametro();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Parametro [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoParametro Consultar(dParametro dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != null && dados.cid != 0) { conditions.Add("cid=@cid"); p.Add("cid", dados.cid); }
                    if (!string.IsNullOrEmpty(dados.descricao)) { conditions.Add("descricao=@descricao"); p.Add("descricao", dados.descricao); }
                    if (!string.IsNullOrEmpty(dados.valor)) { conditions.Add("valor=@valor"); p.Add("valor", dados.valor); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, descricao, valor FROM Parametros {where}";
                    var lista = conn.Query<dParametro>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoParametro();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Parametro [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoParametroEstoque ConsultarEstoque(dParametroEstoque dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    conditions.Add(dados.valor == "1" ? "e.valor > 0" : "e.valor = 0");
                    if (dados.cidGrupo > 0) { conditions.Add("p.grupo_cid = @grupo"); p.Add("grupo", dados.cidGrupo); }
                    if (dados.cidFornecedor > 0) { conditions.Add("e.fornecedor_cid = @fornecedor"); p.Add("fornecedor", dados.cidFornecedor); }
                    if (dados.cidFabricante > 0) { conditions.Add("e.fabricante_cid = @fabricante"); p.Add("fabricante", dados.cidFabricante); }
                    if (!string.IsNullOrEmpty(dados.descricao)) { conditions.Add("descricao = @descricao"); p.Add("descricao", dados.descricao); }
                    var where = "WHERE " + string.Join(" AND ", conditions);
                    var sql = $"SELECT e.fabricante AS Fabricante, e.cid AS CID, p.descricao AS Descricao, e.referencia AS Referencia, " +
                              $"e.item AS Item, e.valorCompra AS ValorCompra, e.valorVenda AS ValorVenda, e.valor AS Valor, c.nome AS Cor " +
                              $"FROM nascomercio.produtos AS p " +
                              $"INNER JOIN nascomercio.v_estoque AS e ON e.cid = p.cid " +
                              $"INNER JOIN nascomercio.cor AS c ON c.cid = p.cor_cid " +
                              $"{where} ORDER BY p.codigo, e.item";
                    var lista = conn.Query<dEstoque>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoParametroEstoque();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Parametro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dParametro dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("INSERT INTO Parametros (descricao, valor) VALUES (@descricao, @valor)",
                        new { descricao = dados.descricao, valor = dados.valor });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Parametro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dParametro dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE Parametros SET descricao=@descricao, valor=@valor WHERE cid=@cid",
                        new { descricao = dados.descricao, valor = dados.valor, cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Parametro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dParametro dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM Parametros WHERE cid=@cid", new { cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Parametro [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
