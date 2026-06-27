using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;
using nsCaixa;


namespace ncPersistencia.nsCaixa
{
    public class pCaixa : RepositorioBase, IpCaixa
    {
        public ColecaoCaixa Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "SELECT cid, nome, situacao, data FROM Caixa ORDER BY nome";
                    var lista = conn.Query<dCaixa>(sql).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoCaixa();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Caixa [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoCaixa Consultar(dCaixa dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();

                    if (dados.cid != null && dados.cid != 0) { conditions.Add("cid = @cid"); p.Add("cid", dados.cid); }
                    if (!string.IsNullOrEmpty(dados.nome)) { conditions.Add("nome = @nome"); p.Add("nome", dados.nome); }
                    if (!string.IsNullOrEmpty(dados.situacao)) { conditions.Add("situacao = @situacao"); p.Add("situacao", dados.situacao); }

                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, nome, situacao, data FROM Caixa {where} ORDER BY nome";

                    var lista = conn.Query<dCaixa>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoCaixa();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Caixa [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoFechamento ConsultarFechamento(dCaixa dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();

                    if (!string.IsNullOrEmpty(dados.nome)) { conditions.Add("caixa = @caixa"); p.Add("caixa", dados.nome); }
                    var dataStr = dados.Data.ToString("yyyy-MM-dd");
                    conditions.Add("DATE_FORMAT(data,'%Y-%m-%d') = @dataStr"); p.Add("dataStr", dataStr);

                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT DATE_FORMAT(data,'%Y-%m-%d') AS data, sum(dinheiro) AS dinheiro, sum(cheque) AS cheque, sum(chequePre) AS chequePre, sum(cartaoDebito) AS cartaoDebito, sum(cartaoCredito) AS cartaoCredito, sum(crediario) AS crediario, sum(desconto) AS desconto, sum(recebido) AS recebido, sum(troco) AS troco, sum(total) AS total, sum(troca) AS troca, sum(vale) AS vale, sum(defeito) AS defeito, sum(retirada) AS retirada, sum(valeEmitido) AS valeEmitido, caixa, sum(crediarioPagamento) AS crediarioPagamento FROM v_fechamento {where} GROUP BY DATE_FORMAT(data,'%Y-%m-%d'), caixa";

                    var lista = conn.Query<dFechamento>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoFechamento();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Fechamento do Caixa [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dCaixa dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "INSERT INTO Caixa (nome, data, usuario, situacao) VALUES (@nome, @data, @usuario, @situacao)";
                    conn.Execute(sql, new { nome = dados.nome, data = dados.Data, usuario = dados.usuario, situacao = dados.situacao });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Caixa [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dCaixa dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "UPDATE Caixa SET nome=@nome, data=@data, usuario=@usuario, situacao=@situacao WHERE cid=@cid";
                    return conn.Execute(sql, new { nome = dados.nome, data = dados.Data, usuario = dados.usuario, situacao = dados.situacao, cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Caixa [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dCaixa dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM Caixa WHERE cid=@cid", new { cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Caixa [" + ToString() + "] - " + ex.Message); }
        }
    }
}
