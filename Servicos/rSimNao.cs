using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
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
