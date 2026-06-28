using System;

using ncRegras;
using ncNComum;
using ncRepositorios;
using ncModelos;


namespace ncServicos
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
