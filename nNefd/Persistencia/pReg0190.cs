using System;
using System.Data;
using System.Text;
using ncNComum.nsAcessoBD;



namespace nsEfd
{
    public class pReg0190
    {
        public Colecao0190 Consultar(DateTime dataInicio, DateTime dataFim)
        {
            Colecao0190 retorno = null;
            var acessoBanco = new cAcessoBD();
            var comando = new StringBuilder();

            comando.Append(" SELECT DISTINCT ");
            comando.Append(" tmp.efdUnidadeMedidaCodigo as codigo, um.descricao ");
            comando.Append(" FROM ( ");

            comando.Append(" SELECT DISTINCT ");
            comando.Append(" p.efdUnidadeMedidaCodigo ");
            comando.Append(" FROM produtos p ");
            comando.Append(" INNER JOIN vendasprodutos vp on vp.produto = p.cid INNER JOIN vendas v ON v.controle = vp.controle ");
            comando.Append(" WHERE IFNULL(p.efdIntegracao, 1) = 1 AND V.DATA BETWEEN '");
            comando.Append(ncNComum.cFuncoes.FormatarDataUniversal(ncNComum.cFuncoes.FormatarDataBarras(dataInicio.ToString())));
            comando.Append(" 00:00:00.000' AND '");
            comando.Append(ncNComum.cFuncoes.FormatarDataUniversal(ncNComum.cFuncoes.FormatarDataBarras(dataFim.ToString())));
            comando.Append(" 23:59:59.999' ");

            comando.Append(" UNION ALL ");

            comando.Append(" SELECT DISTINCT ");
            comando.Append(" p.efdUnidadeMedidaCodigo ");
            comando.Append(" FROM logestoque le INNER JOIN produtos p ON p.cid = le.produto_cid ");
            comando.Append(" WHERE IFNULL(p.efdIntegracao, 1) = 1 AND le.data BETWEEN '");
            comando.Append(ncNComum.cFuncoes.FormatarDataUniversal(ncNComum.cFuncoes.FormatarDataBarras(dataInicio.ToString())));
            comando.Append(" 00:00:00.000' AND '");
            comando.Append(ncNComum.cFuncoes.FormatarDataUniversal(ncNComum.cFuncoes.FormatarDataBarras(dataFim.ToString())));
            comando.Append(" 23:59:59.999' ");

            comando.Append(" ) AS tmp ");
            comando.Append(" INNER JOIN efdUnidadeMedida um ON um.codigo = tmp.efdUnidadeMedidaCodigo ");
            comando.Append(" WHERE tmp.efdUnidadeMedidaCodigo IS NOT NULL ");

            DataSet ds = acessoBanco.ExecutarDS(comando.ToString());

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    retorno = new Colecao0190();
                    foreach (DataRow linha in dt.Rows)
                    {
                        var item = new dReg0190();
                        item.unid = ncNComum.cFuncoes.RetornarTexto(linha["codigo"]);
                        item.descr = ncNComum.cFuncoes.RetornarTexto(linha["descricao"]);
                        retorno.Add(item);
                    }
                }
            }

            return retorno;
        }
    }
}
