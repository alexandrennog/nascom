using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public class rTipoFluxo
    {
        public ColecaoTipoFluxo Listar()
        {
            try
            {
                var regra = new rTipoFluxo();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar TipoFluxo [" + ToString() + "] - " + ex.Message);
            }
        }

        public string RetornarCodigo(int cid)
        {
            try
            {
                var regra = new rTipoFluxo();
                return regra.RetornarCodigo(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em RetornarCodigo TipoFluxo [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
