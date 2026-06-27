using System;
using ncDados.nsEfd;
using ncRegras.nsEFD;
using ncComum.nsExcecao;

namespace ncServicos.nsEFD
{
    public class sEfdTipoAtividade
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
