using System;
using ncNComum;
using ncRepositorios;
using ncModelos;

namespace ncServicos
{
    public class rSexo
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
