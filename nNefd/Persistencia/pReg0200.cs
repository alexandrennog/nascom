using System;
using System.Data;
using System.Text;
using ncNComum.nsAcessoBD;
using static ncNComum.nsFuncoes.cFuncoes;

namespace nsEfd
{
    public class pReg0200
    {
        public Colecao0200 Consultar(DateTime dataInicio, DateTime dataFim)
        {
            Colecao0200 retorno = null;
            var acessoBanco = new cAcessoBD();
            var comando = new StringBuilder();

            comando.Append(" SELECT DISTINCT ");
            comando.Append(" tmp.codigo, tmp.descricao, tmp.aliquotaIcms, tmp.efdUnidadeMedidaCodigo ");
            comando.Append(" FROM ( ");

            comando.Append(" SELECT DISTINCT ");
            comando.Append(" p.cid as codigo, p.descricao AS descricao, ");
            comando.Append(" p.aliquota AS aliquotaIcms, p.efdUnidadeMedidaCodigo ");
            comando.Append(" FROM produtos p INNER JOIN vendasprodutos vp ON vp.produto = p.cid INNER JOIN vendas v ON v.controle = vp.controle ");
            comando.Append(" INNER JOIN produtoitem pi ON pi.produtos_cid = p.cid AND pi.item = vp.item AND pi.caracteristicas_cid = 1 ");
            comando.Append(" WHERE v.data BETWEEN '");
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataInicio)));
            comando.Append("  00:00:00.000' AND ' ");
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataFim)));
            comando.Append("  23:59:59.999' AND IFNULL(p.efdIntegracao, 1) = 1 AND pi.valor > 0");

            comando.Append(" UNION ALL ");

            comando.Append(" SELECT DISTINCT ");
            comando.Append(" le.produto_cid AS codigo, p.descricao AS descricao,  ");
            comando.Append(" p.aliquota AS aliquotaIcms, p.efdUnidadeMedidaCodigo ");
            comando.Append(" FROM logestoque le INNER JOIN produtos p ON p.cid = le.produto_cid ");
            comando.Append(" INNER JOIN produtoitem pt ON pt.produtos_cid = p.cid AND pt.caracteristicas_cid = 1 AND pt.valor = le.produtoItem_codigoBarras ");
            comando.Append(" WHERE le.data BETWEEN '");
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataInicio)));
            comando.Append(" 00:00:00.000' AND '");
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataFim)));
            comando.Append(" 23:59:59.999' AND IFNULL(p.efdIntegracao, 1) = 1 AND pt.valor > 0 ");

            comando.Append(" ORDER BY 1, 2 ");
            comando.Append(" ) AS tmp ");

            DataSet ds = acessoBanco.ExecutarDS(comando.ToString());

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    retorno = new Colecao0200();
                    foreach (DataRow linha in dt.Rows)
                    {
                        var item = new dReg0200();
                        item.cod_item = RetornarTexto(linha["codigo"]);
                        item.descr_item = RetornarTexto(linha["descricao"]);
                        item.aliq_icms = RetornarTexto(linha["aliquotaIcms"]);
                        item.unid_inv = RetornarTexto(linha["efdUnidadeMedidaCodigo"]);
                        retorno.Add(item);
                    }
                }
            }

            return retorno;
        }
    }
}
