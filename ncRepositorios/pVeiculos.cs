using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;
using nsVeiculos;

namespace ncPersistencia.nsVeiculos
{
    public class pVeiculos : RepositorioBase, IpVeiculos
    {
        public ColecaoVeiculos Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dVeiculos>(
                        "SELECT cid, clienteid AS clienteId, placa AS Placa, marca AS Marca, modelo AS Modelo, cor AS Cor, ano AS Ano, combustivel AS Combustivel FROM veiculo").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoVeiculos();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Veiculos [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVeiculos Consultar(dVeiculos dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != 0) { conditions.Add("cid=@cid"); p.Add("cid", dados.cid); }
                    if (dados.clienteId != 0) { conditions.Add("clienteid=@clienteId"); p.Add("clienteId", dados.clienteId); }
                    if (!string.IsNullOrEmpty(dados.Placa)) { conditions.Add("placa=@placa"); p.Add("placa", dados.Placa); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, clienteid AS clienteId, placa AS Placa, marca AS Marca, modelo AS Modelo, cor AS Cor, ano AS Ano, combustivel AS Combustivel FROM Veiculo {where}";
                    var lista = conn.Query<dVeiculos>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoVeiculos();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Veiculos[" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dVeiculos dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("INSERT INTO Veiculo (clienteid, placa, marca, modelo, cor, ano, combustivel) VALUES (@clienteId, @Placa, @Marca, @Modelo, @Cor, @Ano, @Combustivel)",
                        new { dados.clienteId, dados.Placa, dados.Marca, dados.Modelo, dados.Cor, dados.Ano, dados.Combustivel });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Veiculos [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dVeiculos dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE Veiculo SET clienteid=@clienteId, placa=@Placa, marca=@Marca, modelo=@Modelo, cor=@Cor, ano=@Ano, combustivel=@Combustivel WHERE cid=@cid",
                        new { dados.clienteId, dados.Placa, dados.Marca, dados.Modelo, dados.Cor, dados.Ano, dados.Combustivel, dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Veiculos [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dVeiculos dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM Veiculo WHERE cid=@cid", new { dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Veiculos [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirVeiculosCliente(dVeiculos dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM Veiculo WHERE clienteid=@clienteId", new { dados.clienteId });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Veiculos [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
