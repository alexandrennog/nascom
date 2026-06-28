using System;
using System.Data;
using System.Text;
using ncNComum.nsAcessoBD;
using ncNComum;
using nsEfd;

namespace nNefd.Persistencia
{
    public class pReg0000
    {
        public dReg0000 Consultar()
        {
            dReg0000 retorno = null;
            var acessoBanco = new cAcessoBD();
            var comando = new StringBuilder();

            comando.Append(" SELECT ");
            comando.Append(" a.versaoLeiaute, a.finalidadeArquivo, e.nomeEmpresarial, e.tipoPessoa, e.cpfCnpj, uf.sigla, e.inscricaoEstadual, ");
            comando.Append(" m.codigo_ibge, e.inscricaoMunicipal, e.inscricaoSuframa, a.perfilArquivoFiscal, e.tipoAtividade ");
            comando.Append(" FROM EfdEntidade e ");
            comando.Append(" INNER JOIN municipios m ON m.cid = e.codigoMunicipio ");
            comando.Append(" INNER JOIN estados uf ON uf.cid = m.estados_cid");
            comando.Append(" , EfdArquivo a ");

            DataSet ds = acessoBanco.ExecutarDS(comando.ToString());

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    retorno = new dReg0000();
                    retorno.cod_ver = cFuncoes.RetornarTexto(dt.Rows[0]["versaoLeiaute"]);
                    retorno.cod_fin = cFuncoes.RetornarTexto(dt.Rows[0]["finalidadeArquivo"]);
                    retorno.nome = cFuncoes.RetornarTexto(dt.Rows[0]["nomeEmpresarial"]);
                    retorno.cpfCnpj = cFuncoes.RetornarTexto(dt.Rows[0]["cpfCnpj"]);
                    retorno.uf = cFuncoes.RetornarTexto(dt.Rows[0]["sigla"]);
                    retorno.ie = cFuncoes.RetornarTexto(dt.Rows[0]["inscricaoEstadual"]);
                    retorno.cod_mun = cFuncoes.RetornarTexto(dt.Rows[0]["codigo_ibge"]);
                    retorno.im = cFuncoes.RetornarTexto(dt.Rows[0]["inscricaoMunicipal"]);
                    retorno.suframa = cFuncoes.RetornarTexto(dt.Rows[0]["inscricaoSuframa"]);
                    retorno.ind_perfil = cFuncoes.RetornarTexto(dt.Rows[0]["perfilArquivoFiscal"]);
                    retorno.ind_ativ = cFuncoes.RetornarTexto(dt.Rows[0]["tipoAtividade"]);
                    retorno.tipoPessoa = cFuncoes.RetornarTexto(dt.Rows[0]["tipoPessoa"]);
                }
            }

            return retorno;
        }
    }
}
