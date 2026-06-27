using System;
using ncDados.nsEfd;
using ncRegras.nsEFD;
using ncComum.nsExcecao;

namespace ncServicos.nsEFD
{
    public class sEfdFinalidadeArquivo
    {
        public ColecaoEfdFinalidadeArquivo Listar()
        {
            try
            {
                var regra = new rEfdFinalidadeArquivo();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar EfdFinalidadeArquivo [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
