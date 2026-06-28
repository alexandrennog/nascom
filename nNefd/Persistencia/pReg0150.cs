using System;
using System.Data;
using System.Text;
using ncNComum.nsAcessoBD;
using nsEfd;


namespace nNefd.Persistencia
{
    public class pReg0150
    {
        public Colecao0150 Consultar(DateTime dataInicio, DateTime dataFim)
        {
            Colecao0150 retorno = null;
            var acessoBanco = new cAcessoBD();
            var comando = new StringBuilder();

            comando.Append(" SELECT ");
            comando.Append(" f.cid, f.nome, f.cnpj, f.inscricaoEstadual, m.codigo_ibge, ");
            comando.Append(" f.logradouro, f.numero, f.complemento, f.bairro ");
            comando.Append(" FROM fornecedores f ");
            comando.Append(" INNER JOIN notafiscalfornecedor nff ON nff.fornecedor_cid = f.cid ");
            comando.Append(" INNER JOIN municipios m ON m.cid = f.cidade_cid ");
            comando.Append(" WHERE nff.dataEmissao BETWEEN '");
            comando.Append(ncNComum.cFuncoes.FormatarDataUniversal(ncNComum.cFuncoes.FormatarDataBarras(dataInicio.ToString())));
            comando.Append(" 00:00:00.000' AND '");
            comando.Append(ncNComum.cFuncoes.FormatarDataUniversal(ncNComum.cFuncoes.FormatarDataBarras(dataFim.ToString())));
            comando.Append(" 23:59:59.999' ");
            comando.Append(" ORDER BY f.cid ");

            DataSet ds = acessoBanco.ExecutarDS(comando.ToString());

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    retorno = new Colecao0150();
                    foreach (DataRow linha in dt.Rows)
                    {
                        var item = new dReg0150();
                        item.cod_part = ncNComum.cFuncoes.RetornarTexto(linha["cid"]);
                        item.nome = ncNComum.cFuncoes.RetornarTexto(linha["nome"]);
                        item.cnpj = ncNComum.cFuncoes.RetornarTexto(linha["cnpj"]);
                        item.ie = ncNComum.cFuncoes.RetornarTexto(linha["inscricaoEstadual"]);
                        item.cod_mun = ncNComum.cFuncoes.RetornarTexto(linha["codigo_ibge"]);
                        item.ende = ncNComum.cFuncoes.RetornarTexto(linha["logradouro"]);
                        item.num = ncNComum.cFuncoes.RetornarTexto(linha["numero"]);
                        item.compl = ncNComum.cFuncoes.RetornarTexto(linha["complemento"]);
                        item.bairro = ncNComum.cFuncoes.RetornarTexto(linha["bairro"]);
                        retorno.Add(item);
                    }
                }
            }

            return retorno;
        }
    }
}
