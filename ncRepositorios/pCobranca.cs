using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;
using ncPersistencia;
using nsCobranca;

public class pCobranca : RepositorioBase, IpCobranca
{
    public ColecaoCobranca ListarCobrancas(dCobrancaAutomatica dados)
    {
        try
        {
            using (var conn = CriarConexao())
            {
                var p = new DynamicParameters();
                p.Add("dataCobranca", dados.DataCobranca.ToString("yyyy-MM-dd"));
                var lista = conn.Query<dCobrancaAutomatica>(
                    "SELECT codigocliente AS CodigoCliente, crediarioid AS CrediarioId, parcelaidid AS ParcelaIdId, " +
                    "valor AS Valor, nome AS Nome, dddcel AS DDDCel, celular AS Celular, sucesso AS Sucesso, " +
                    "pix_code AS PixCode, data_cobranca AS DataCobranca, datavencimento AS DataVencimento " +
                    "FROM cobrancas_automaticas WHERE data_cobranca = @dataCobranca", p).AsList();
                if (lista.Count == 0) return null;
                var retorno = new ColecaoCobranca();
                retorno.AddRange(lista);
                return retorno;
            }
        }
        catch (ExcecaoNascomercio) { throw; }
        catch (Exception ex)
        {
            throw new ExcecaoNascomercio("Erro em Listar Cobranças [" + ToString() + "] - " + ex.Message);
        }
    }
}
