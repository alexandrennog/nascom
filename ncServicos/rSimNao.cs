using System;
using ncNComum;
using ncRepositorios;
using ncModelos;

namespace ncServicos
{
    public class rSimNao
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
