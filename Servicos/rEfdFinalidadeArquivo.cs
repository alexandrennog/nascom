using System;
using Comum;
using Repositorios;
using Modelos;


namespace Servicos
{
    public class rEfdFinalidadeArquivo
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
