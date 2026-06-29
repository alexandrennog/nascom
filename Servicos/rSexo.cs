using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public class rSexo : IsSexo
    {
        public ColecaoSexo Listar()
        {
            try
            {
                var regra = new rSexo();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Sexo [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}

