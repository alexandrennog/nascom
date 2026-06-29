using System.Data;
using System.Text;
using Comum.nsAcessoBD;
using Comum;
using NEFd;

namespace nNefd.Persistencia
{
    public class pReg0005
    {
        public dReg0005 Consultar()
        {
            dReg0005 retorno = null;
            var acessoBanco = new cAcessoBD();
            var comando = new StringBuilder();

            comando.Append(" SELECT ");
            comando.Append(" e.nomeFantasia, c.logradouro, c.numero, c.complemento, c.bairro, c.cep, c.dddTelefone, c.dddFax, c.email ");
            comando.Append(" FROM EfdEntidade e, EfdEnderecoContato c ");

            DataSet ds = acessoBanco.ExecutarDS(comando.ToString());

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    retorno = new dReg0005();
                    retorno.fantasia = cFuncoes.RetornarTexto(dt.Rows[0]["nomeFantasia"]);
                    retorno.cep = cFuncoes.RetornarTexto(dt.Rows[0]["cep"]);
                    retorno.ende = cFuncoes.RetornarTexto(dt.Rows[0]["logradouro"]);
                    retorno.num = cFuncoes.RetornarTexto(dt.Rows[0]["numero"]);
                    retorno.compl = cFuncoes.RetornarTexto(dt.Rows[0]["complemento"]);
                    retorno.bairro = cFuncoes.RetornarTexto(dt.Rows[0]["bairro"]);
                    retorno.fone = cFuncoes.RetornarTexto(dt.Rows[0]["dddTelefone"]);
                    retorno.fax = cFuncoes.RetornarTexto(dt.Rows[0]["dddFax"]);
                    retorno.email = cFuncoes.RetornarTexto(dt.Rows[0]["email"]);
                }
            }

            return retorno;
        }
    }
}
