using System;
using ncDados.nsEfd;
using ncRegras.nsEFD;
using ncComum.nsExcecao;

namespace ncServicos.nsEFD
{
    public class sEfdPerfilArquivoFiscal
    {
        public ColecaoEfdPerfilArquivoFiscal Listar()
        {
            try
            {
                var regra = new rEfdPerfilArquivoFiscal();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar EfdPerfilArquivoFiscal [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
