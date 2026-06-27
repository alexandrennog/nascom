using System;
using ncDados.nsSimNao;
using ncRegras.nsRegras;
using ncComum.nsExcecao;

namespace ncServicos.nsRegras
{
    public class sSimNao
    {
        public ColecaoSimNao Listar()
        {
            try
            {
                var regra = new rSimNao();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar SimNao [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
