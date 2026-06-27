using System;
using ncDados.nsTipoNotaFiscal;
using ncRegras.nsRegras;
using ncComum.nsExcecao;

namespace ncServicos.nsRegras
{
    public class sTipoNotaFiscal
    {
        public ColecaoTipoNotaFiscal Listar()
        {
            try
            {
                var regra = new rTipoNotaFiscal();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar TipoNotaFiscal [" + ToString() + "] - " + ex.Message);
            }
        }

        public string RetornarCodigo(int cid)
        {
            try
            {
                var regra = new rTipoNotaFiscal();
                return regra.RetornarCodigo(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em RetornarCodigo TipoNotaFiscal [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
