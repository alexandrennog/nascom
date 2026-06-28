using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum;
using ncModelos;

namespace ncRepositorios
{
    public class pParcela : RepositorioBase, IpParcela
    {
        public ColecaoParcelas Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dParcelas>(
                        "SELECT cid, crediarioid AS crediarioId, codigoBarras, dataemissao AS dataEmissao, datavencimento AS dataVecimento, valor, valorreceber AS valorReceber, valorpago AS valorPago, situacao, observacao FROM Parcelas").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoParcelas();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Crediário [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoParcelas Consultar(dParcelas dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != 0) { conditions.Add("cid=@cid"); p.Add("cid", dados.cid); }
                    if (dados.crediarioId != 0) { conditions.Add("crediarioid=@crediarioId"); p.Add("crediarioId", dados.crediarioId); }
                    if (dados.codigoBarras != null && dados.codigoBarras.Trim() != "") { conditions.Add("codigoBarras=@codigoBarras"); p.Add("codigoBarras", dados.codigoBarras); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, crediarioid AS crediarioId, codigoBarras, dataemissao AS dataEmissao, datavencimento AS dataVecimento, valor, valorreceber AS valorReceber, valorpago AS valorPago, situacao, datapagamento AS dataPagamento, observacao FROM parcelas {where}";
                    var lista = conn.Query<dParcelas>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoParcelas();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Crediario[" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoParcelas ConsultarParcelasCliente(int codCliente)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (codCliente != 0) { conditions.Add("clienteid=@clienteid"); p.Add("clienteid", codCliente); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT parcelas.cid, parcelas.crediarioid AS crediarioId, parcelas.codigoBarras, parcelas.dataemissao AS dataEmissao, parcelas.datavencimento AS dataVecimento, parcelas.valor, parcelas.valorreceber AS valorReceber, parcelas.valorpago AS valorPago, parcelas.situacao, parcelas.datapagamento AS dataPagamento, parcelas.observacao FROM parcelas INNER JOIN crediario ON parcelas.crediarioid = crediario.cid {where}";
                    var lista = conn.Query<dParcelas>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoParcelas();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Crediario[" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoParcelas ConsultarParcelasVencidas(int codCliente)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (codCliente != 0)
                    {
                        conditions.Add("clienteid=@clienteid");
                        p.Add("clienteid", codCliente);
                        conditions.Add("datavencimento < date(now())");
                    }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT parcelas.cid, parcelas.crediarioid AS crediarioId, parcelas.codigoBarras, parcelas.dataemissao AS dataEmissao, parcelas.datavencimento AS dataVecimento, parcelas.valor, parcelas.valorreceber AS valorReceber, parcelas.valorpago AS valorPago, parcelas.situacao, parcelas.datapagamento AS dataPagamento FROM parcelas INNER JOIN crediario ON parcelas.crediarioid = crediario.cid {where} ORDER BY parcelas.datavencimento";
                    var lista = conn.Query<dParcelas>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoParcelas();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Crediario[" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dParcelas dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("INSERT INTO parcelas (crediarioid, codigoBarras, dataemissao, datavencimento, valor, valorreceber, valorpago, datapagamento, situacao, observacao) VALUES (@crediarioId, @codigoBarras, @dataEmissao, @dataVecimento, @valor, @valorReceber, @valorPago, @dataPagamento, @situacao, @observacao)",
                        new { dados.crediarioId, dados.codigoBarras, dados.dataEmissao, dados.dataVecimento, dados.valor, dados.valorReceber, dados.valorPago, dados.dataPagamento, dados.situacao, dados.observacao });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoParcelas ConsultarPagamentos(dParcelas dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.crediarioId != 0) { conditions.Add("parcelasid=@parcelasid"); p.Add("parcelasid", dados.cid); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT parcelasid AS cid, valorpago AS valorPago, datapagamento AS dataPagamento, diasAtraso FROM parcelaspag {where}";
                    var lista = conn.Query<dParcelas>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoParcelas();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Pagamentos[" + ToString() + "] - " + ex.Message);
            }
        }

        public int IncluirPagamento(dParcelas dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("INSERT INTO parcelaspag (parcelasid, valorpago, datapagamento, diasAtraso) VALUES (@cid, @valorPago, @dataPagamento, @diasAtraso)",
                        new { dados.cid, dados.valorPago, dados.dataPagamento, dados.diasAtraso });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Pagamento [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Corrigir()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE parcelas SET valorreceber = 0.0 WHERE situacao = '01' AND valorreceber <= valorpago");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em corrigir parcelas [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dParcelas dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE parcelas SET codigoBarras=@codigoBarras, crediarioId=@crediarioId, dataEmissao=@dataEmissao, dataVencimento=@dataVecimento, valor=@valor, valorreceber=@valorReceber, valorpago=@valorPago, dataPagamento=@dataPagamento, situacao=@situacao, observacao=@observacao WHERE cid=@cid",
                        new { dados.codigoBarras, dados.crediarioId, dados.dataEmissao, dados.dataVecimento, dados.valor, dados.valorReceber, dados.valorPago, dados.dataPagamento, dados.situacao, dados.observacao, dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dParcelas dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM parcelas WHERE cid=@cid", new { dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir crediario [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
