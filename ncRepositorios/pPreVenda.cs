using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;
using nsVenda;

namespace ncPersistencia.nsVenda
{
    public class pPreVenda : RepositorioBase, IpPreVenda
    {
        public ColecaoVenda Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dVenda>(
                        "SELECT controle, usuarioId, clienteId, data AS Data, dinheiro AS Dinheiro, cheque AS Cheque, chequepre AS ChequePre, cartaodebito AS CartaoDebito, cartaocredito AS CartaoCredito, crediario AS Crediario, terminal AS Terminal, parcelas AS Parcelas, desconto AS Desconto, condicao AS Condicao, troca AS Troca, vale AS Vale, defeito AS Defeito, total AS Total, Original AS Pix FROM prevendas").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoVenda();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVenda Consultar(dVenda dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.controle != 0) { conditions.Add("controle=@controle"); p.Add("controle", dados.controle); }
                    if (dados.Terminal != "") { conditions.Add("terminal=@terminal"); p.Add("terminal", dados.Terminal); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT controle, usuarioId, clienteId, data AS Data, vendedor AS Vendedor, dinheiro AS Dinheiro, cheque AS Cheque, chequepre AS ChequePre, cartaodebito AS CartaoDebito, cartaocredito AS CartaoCredito, crediario AS Crediario, terminal AS Terminal, parcelas AS Parcelas, desconto AS Desconto, condicao AS Condicao, troca AS Troca, vale AS Vale, defeito AS Defeito, total AS Total, Original AS Pix, ordemservico AS ordemServicoId FROM prevendas {where}";
                    var lista = conn.Query<dVenda>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoVenda();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ConsultarMax()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.QueryFirstOrDefault<int?>("SELECT MAX(controle) FROM prevendas") ?? 0;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarMax Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dVenda dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("INSERT INTO prevendas (controle, usuarioId, clienteId, data, dinheiro, cheque, chequepre, cartaodebito, cartaocredito, crediario, terminal, ordemServico, parcelas, desconto, condicao, troca, vale, defeito, total, Original) VALUES (@controle, @usuarioId, @clienteId, @Data, @Dinheiro, @Cheque, @ChequePre, @CartaoDebito, @CartaoCredito, @Crediario, @Terminal, @ordemServicoId, @Parcelas, @Desconto, @Condicao, @Troca, @Vale, @Defeito, @Total, @Pix)",
                        new { dados.controle, dados.usuarioId, dados.clienteId, dados.Data, dados.Dinheiro, dados.Cheque, dados.ChequePre, dados.CartaoDebito, dados.CartaoCredito, dados.Crediario, dados.Terminal, dados.ordemServicoId, dados.Parcelas, dados.Desconto, dados.Condicao, dados.Troca, dados.Vale, dados.Defeito, dados.Total, dados.Pix });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dVenda dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE prevendas SET usuarioId=@usuarioId, clienteId=@clienteId, data=@Data, dinheiro=@Dinheiro, cheque=@Cheque, chequepre=@ChequePre, cartaodebito=@CartaoDebito, cartaocredito=@CartaoCredito, crediario=@Crediario, terminal=@Terminal, ordemservico=@ordemServicoId, parcelas=@Parcelas, desconto=@Desconto, condicao=@Condicao, troca=@Troca, vale=@Vale, defeito=@Defeito, vendedor=@Vendedor, Original=@Pix, total=@Total WHERE controle=@controle",
                        new { dados.usuarioId, dados.clienteId, dados.Data, dados.Dinheiro, dados.Cheque, dados.ChequePre, dados.CartaoDebito, dados.CartaoCredito, dados.Crediario, dados.Terminal, dados.ordemServicoId, dados.Parcelas, dados.Desconto, dados.Condicao, dados.Troca, dados.Vale, dados.Defeito, dados.Vendedor, dados.Pix, dados.Total, dados.controle });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dVenda dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM prevendas WHERE controle=@controle", new { dados.controle });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Venda [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
