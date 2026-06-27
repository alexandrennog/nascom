using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsCobranca;

public class pCobranca
{
    public ColecaoCobranca ListarCobrancas(dCobrancaAutomatica dados)
    {
        ColecaoCobranca retorno = null;
        try
        {
            var acessoBanco = new cAcessoBD();
            string comandoSQL = " SELECT codigocliente, crediarioid, parcelaidid, valor, nome,  " +
                " dddcel, celular, sucesso, pix_code, data_cobranca, datavencimento   " +
                " FROM cobrancas_automaticas WHERE data_cobranca = '" + dados.DataCobranca.ToString("yyyy-MM-dd") + "'";
            var ds = acessoBanco.ExecutarDS(comandoSQL);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    retorno = new ColecaoCobranca();
                    foreach (DataRow row in dt.Rows)
                    {
                        var item = new dCobrancaAutomatica();
                        item.CodigoCliente = RetornarInteiro(row["codigocliente"]);
                        item.CrediarioId = RetornarInteiro(row["crediarioid"]);
                        item.ParcelaIdId = RetornarInteiro(row["parcelaidid"]);
                        item.Valor = RetornarDecimal(row["valor"]);
                        item.Nome = RetornarTexto(row["nome"]);
                        item.DDDCel = RetornarTexto(row["dddcel"]);
                        item.Celular = RetornarTexto(row["celular"]);
                        item.Sucesso = RetornarTexto(row["sucesso"]);
                        item.PixCode = RetornarTexto(row["pix_code"]);
                        item.DataCobranca = RetornarData(row["data_cobranca"]);
                        item.DataVencimento = RetornarData(row["datavencimento"]);
                        retorno.Add(item);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            retorno = null;
            throw new ExcecaoNascomercio("Erro em Listar Cobranças [" + ToString() + "] - " + ex.Message);
        }
        return retorno;
    }
}
