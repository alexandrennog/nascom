using System;
using ncNComum;
using ncRepositorios;
using ncModelos;

namespace ncServicos
{
    public class rEstadoCivil
    {
        public ColecaoEstadoCivil Listar()
        {
            try
            {
                var regra = new rEstadoCivil();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar EstadoCivil [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
