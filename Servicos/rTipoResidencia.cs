using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public class rTipoResidencia : IsTipoResidencia
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

