using System;
using ncNComum;
using ncRepositorios;
using ncModelos;


namespace ncServicos
{
    public class rEfdTipoAtividade
    {
        public ColecaoEfdTipoAtividade Listar()
        {
            try
            {
                var regra = new rEfdTipoAtividade();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar EfdTipoAtividade [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
