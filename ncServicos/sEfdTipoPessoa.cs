using System;
using ncDados.nsEfd;
using ncRegras.nsEFD;
using ncComum.nsExcecao;

namespace ncServicos.nsEFD
{
    public class sEfdTipoPessoa
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
