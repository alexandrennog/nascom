using System;
using ncDados.nsTipoFluxo;
using ncRegras.nsRegras;
using ncComum.nsExcecao;

namespace ncServicos.nsRegras
{
    public class sTipoFluxo
    {
        public ColecaoTipoFluxo Listar()
        {
            try
            {
                var regra = new rTipoFluxo();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar TipoFluxo [" + ToString() + "] - " + ex.Message);
            }
        }

        public string RetornarCodigo(int cid)
        {
            try
            {
                var regra = new rTipoFluxo();
                return regra.RetornarCodigo(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em RetornarCodigo TipoFluxo [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
