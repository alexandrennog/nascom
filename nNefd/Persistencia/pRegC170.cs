using System;
using System.Data;
using System.Text;
using ncNComum.nsAcessoBD;
using static ncNComum.cFuncoes;

namespace nsEfd
{
    public class pRegC170
    {
        public ColecaoC170 Consultar(DateTime dataInicio, DateTime dataFim)
        {
            ColecaoC170 retorno = null;
            var acessoBanco = new cAcessoBD();
            var comando = new StringBuilder();

            comando.Append(" SELECT DISTINCT ");
            comando.Append(" tmp.codigo, tmp.descricao, tmp.aliquotaIcms, tmp.efdUnidadeMedidaCodigo, tmp.quantidade, tmp.valorCompra, notaFiscalNumero  ");
            comando.Append(" FROM ( ");

            comando.Append(" SELECT DISTINCT ");
            comando.Append(" le.produto_cid AS codigo, p.descricao AS descricao, p.valorCompra, ");
            comando.Append(" p.aliquota AS aliquotaIcms, p.efdUnidadeMedidaCodigo, le.quantidade, le.notaFiscalNumero ");
            comando.Append(" FROM logestoque le INNER JOIN produtos p ON p.cid = le.produto_cid AND IFNULL(p.efdIntegracao, 1) = 1 ");
            comando.Append(" INNER JOIN notafiscalfornecedor nff ON le.notaFiscalNumero = nff.numero ");
            comando.Append(" WHERE nff.dataEmissao BETWEEN '");
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataInicio.ToString())));
            comando.Append(" 00:00:00.000' AND '");
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataFim.ToString())));
            comando.Append(" 23:59:59.999' AND notaFiscalNumero is not null ");

            comando.Append(" ORDER BY 1, 2 ");
            comando.Append(" ) AS tmp ");

            DataSet ds = acessoBanco.ExecutarDS(comando.ToString());

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    retorno = new ColecaoC170();
                    foreach (DataRow linha in dt.Rows)
                    {
                        var item = new dRegC170();
                        item.cod_item = RetornarTexto(linha["codigo"]);
                        item.descr_compl = RetornarTexto(linha["descricao"]);
                        item.aliq_icms = RetornarDecimal(linha["aliquotaIcms"]);
                        item.unid = RetornarTexto(linha["efdUnidadeMedidaCodigo"]);
                        item.qtd = RetornarInteiro(linha["quantidade"]);
                        item.vl_item = RetornarDecimal(linha["valorCompra"]);
                        item.num_doc = RetornarTexto(linha["notaFiscalNumero"]);
                        retorno.Add(item);
                    }
                }
            }

            return retorno;
        }
    }
}
