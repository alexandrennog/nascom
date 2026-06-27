using System.Data;
using System.Text;
using ncNComum.nsAcessoBD;
using ncNComum.nsFuncoes;

namespace nsEfd
{
    public class pReg0100
    {
        public dReg0100 Consultar()
        {
            dReg0100 retorno = null;
            var acessoBanco = new cAcessoBD();
            var comando = new StringBuilder();

            comando.Append(" SELECT ");
            comando.Append(" c.nomeContador, c.cpfContador, c.crcContador, c.cnpjEscritorio, c.logradouro, c.numero, ");
            comando.Append(" c.complemento, c.bairro, c.cep, c.dddTelefone, c.dddFax, c.email, m.codigo_ibge ");
            comando.Append(" FROM EfdContabilidade c INNER JOIN municipios m ON m.cid = c.municipio ");

            DataSet ds = acessoBanco.ExecutarDS(comando.ToString());

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    retorno = new dReg0100();
                    retorno.nome = cFuncoes.RetornarTexto(dt.Rows[0]["nomeContador"]);
                    retorno.cpf = cFuncoes.RetornarTexto(dt.Rows[0]["cpfContador"]);
                    retorno.crc = cFuncoes.RetornarTexto(dt.Rows[0]["crcContador"]);
                    retorno.cnpj = cFuncoes.RetornarTexto(dt.Rows[0]["cnpjEscritorio"]);
                    retorno.cep = cFuncoes.RetornarTexto(dt.Rows[0]["cep"]);
                    retorno.ende = cFuncoes.RetornarTexto(dt.Rows[0]["logradouro"]);
                    retorno.num = cFuncoes.RetornarTexto(dt.Rows[0]["numero"]);
                    retorno.compl = cFuncoes.RetornarTexto(dt.Rows[0]["complemento"]);
                    retorno.bairro = cFuncoes.RetornarTexto(dt.Rows[0]["bairro"]);
                    retorno.fone = cFuncoes.RetornarTexto(dt.Rows[0]["dddTelefone"]);
                    retorno.fax = cFuncoes.RetornarTexto(dt.Rows[0]["dddFax"]);
                    retorno.email = cFuncoes.RetornarTexto(dt.Rows[0]["email"]);
                    retorno.cod_mun = cFuncoes.RetornarTexto(dt.Rows[0]["codigo_ibge"]);
                }
            }

            return retorno;
        }
    }
}
