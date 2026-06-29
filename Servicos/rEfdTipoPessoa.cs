using System;


using Comum;
using Repositorios;
using Modelos;


namespace Servicos
{
    public class rEfdTipoPessoa
    {
        public ColecaoEfdTipoPessoa Listar()
        {
            try
            {
                var regra = new rEfdTipoPessoa();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar EfdTipoPessoa [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
