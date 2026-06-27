using System;
using System.Data;
using System.Text;
using ncNComum.nsAcessoBD;
using static ncNComum.nsFuncoes.cFuncoes;

namespace nsEfd
{
    public class pRegH010
    {
        public ColecaoH010 Consultar(DateTime dataInicio, DateTime dataFim)
        {
            ColecaoH010 retorno = null;
            var acessoBanco = new cAcessoBD();
            var comando = new StringBuilder();

            comando.Append(" SELECT DISTINCT ");
            comando.Append(" tmp.codigo AS codigoEfd, ");
            comando.Append(" sum(pi.valor) AS quantidade, tmp.unidadeMedidaCodigo, tmp.valorVenda AS valorUnitario,");
            comando.Append(" CONVERT(sum(ABS(pi.valor)) * tmp.valorVenda, DECIMAL(10,2))  AS valorItem, ");
            comando.Append(" ec.contaAnaliticaContabil ");
            comando.Append(" FROM ( ");

            comando.Append(" SELECT DISTINCT ");
            comando.Append(" p.cid as codigo, vp.item AS item, p.efdUnidadeMedidaCodigo AS unidadeMedidaCodigo, p.valorVenda ");
            comando.Append(" FROM produtos p INNER JOIN vendasprodutos vp ON vp.produto = p.cid ");
            comando.Append(" INNER JOIN vendas v ON v.controle = vp.controle INNER JOIN produtoitem pi ON pi.produtos_cid = p.cid AND pi.item = vp.item AND pi.caracteristicas_cid = 1 ");
            comando.Append(" WHERE v.data BETWEEN '");
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataInicio)));
            comando.Append(" 00:00:00.000' AND '");
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataFim)));
            comando.Append(" 23:59:59.999' AND IFNULL(p.efdIntegracao, 1) = 1 ");

            comando.Append(" UNION ALL ");

            comando.Append(" SELECT DISTINCT ");
            comando.Append(" le.produto_cid AS codigo, pt.item AS item, p.efdUnidadeMedidaCodigo AS unidadeMedidaCodigo, p.valorVenda ");
            comando.Append(" FROM logestoque le ");
            comando.Append(" INNER JOIN produtos p ON p.cid = le.produto_cid AND IFNULL(p.efdIntegracao, 1) = 1 ");
            comando.Append(" INNER JOIN produtoitem pt ON pt.produtos_cid = p.cid AND pt.caracteristicas_cid = 1 AND pt.valor = le.produtoItem_codigoBarras ");
            comando.Append(" WHERE le.data BETWEEN '");
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataInicio)));
            comando.Append(" 00:00:00.000' AND '");
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataFim)));
            comando.Append(" 23:59:59.999' AND IFNULL(p.efdIntegracao, 1) = 1 ");

            comando.Append(" ORDER BY 1, 2 ");
            comando.Append(" ) AS tmp ");
            comando.Append(" INNER JOIN produtoitem pi ON pi.produtos_cid = tmp.codigo AND pi.item = tmp.item AND pi.caracteristicas_cid = 2, ");
            comando.Append(" efdcontabilidade AS ec GROUP BY tmp.codigo");

            DataSet ds = acessoBanco.ExecutarDS(comando.ToString());

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    retorno = new ColecaoH010();
                    foreach (DataRow linha in dt.Rows)
                    {
                        var item = new dRegH010();
                        item.cod_item = RetornarTexto(linha["codigoEfd"]);
                        item.unid = RetornarTexto(linha["unidadeMedidaCodigo"]);
                        item.qtd = RetornarInteiro(linha["quantidade"]);
                        item.vl_unit = RetornarDecimal(linha["valorUnitario"]);
                        item.vl_item = RetornarDecimal(linha["valorItem"]);
                        item.cod_cta = RetornarTexto(linha["contaAnaliticaContabil"]);
                        retorno.Add(item);
                    }
                }
            }

            return retorno;
        }
    }
}
