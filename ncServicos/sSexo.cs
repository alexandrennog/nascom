using System;
using ncDados.nsSexo;
using ncRegras.nsRegras;
using ncComum.nsExcecao;

namespace ncServicos.nsRegras
{
    public class sSexo
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
