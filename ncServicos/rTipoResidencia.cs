using System;
using ncNComum;
using ncRepositorios;
using ncModelos;

namespace ncServicos
{
    public class rTipoResidencia
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
