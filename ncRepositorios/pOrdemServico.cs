using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;
using nsOrdemServico;

namespace ncPersistencia.nsOrdemServico
{
    public class pOrdemServico : RepositorioBase, IpOrdemServico
    {
        public ColecaoOrdemServico Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dOrdemServico>("SELECT cid, clienteid, veiculoid, observacoes, emissao, vendedor, loja, situacao FROM OrdemServico").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoOrdemServico();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar OS [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoOrdemServico Consultar(dOrdemServico dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != null && dados.cid != 0) { conditions.Add("cid=@cid"); p.Add("cid", dados.cid); }
                    if (!string.IsNullOrEmpty(dados.situacao)) { conditions.Add("situacao=@situacao"); p.Add("situacao", dados.situacao); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, clienteid, veiculoid, observacoes, emissao, vendedor, loja, situacao FROM OrdemServico {where}";
                    var lista = conn.Query<dOrdemServico>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoOrdemServico();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar OS [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ConsultarMax()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.QueryFirstOrDefault<int?>("SELECT MAX(cid) FROM ordemservico") ?? 0;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarMax ordemservico [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dOrdemServico dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("INSERT INTO OrdemServico (clienteid, veiculoid, observacoes, emissao, vendedor, loja, situacao) VALUES (@clienteid, @veiculoid, @observacoes, @emissao, @vendedor, @loja, @situacao)",
                        new { dados.clienteid, dados.veiculoid, dados.observacoes, dados.emissao, dados.vendedor, dados.loja, dados.situacao });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir OS [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dOrdemServico dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE OrdemServico SET clienteid=@clienteid, veiculoid=@veiculoid, observacoes=@observacoes, vendedor=@vendedor, loja=@loja, situacao=@situacao WHERE cid=@cid",
                        new { dados.clienteid, dados.veiculoid, dados.observacoes, dados.vendedor, dados.loja, dados.situacao, dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar OS [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dOrdemServico dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM OrdemServico WHERE cid=@cid", new { dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir OS [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
