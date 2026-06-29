using System;
using Comum;
using Repositorios;
using Modelos;


namespace Servicos
{
    public class rEfdTipoAtividade : IsEfdTipoAtividade
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

