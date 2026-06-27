using System;
using ncDados.nsEstadoCivil;
using ncRegras.nsRegras;
using ncComum.nsExcecao;

namespace ncServicos.nsRegras
{
    public class sEstadoCivil
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
