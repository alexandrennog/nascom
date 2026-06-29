using System;
using Comum;
using Repositorios;
using Modelos;


namespace Servicos
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
