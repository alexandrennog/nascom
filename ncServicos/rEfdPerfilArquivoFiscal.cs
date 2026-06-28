using System;
using ncNComum;
using ncRepositorios;
using ncModelos;


namespace ncServicos
{
    public class rEfdPerfilArquivoFiscal
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
