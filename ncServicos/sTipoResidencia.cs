using System;
using ncDados.nsTipoResidencia;
using ncRegras.nsRegras;
using ncComum.nsExcecao;

namespace ncServicos.nsRegras
{
    public class sTipoResidencia
    {
        public ColecaoTipoResidencia Listar()
        {
            try
            {
                var regra = new rTipoResidencia();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar TipoResidencia [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
