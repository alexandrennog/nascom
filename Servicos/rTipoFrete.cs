using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public class rTipoFrete : IsTipoFrete
    {
        public ColecaoTipoFrete Listar()
        {
            try
            {
                var regra = new rTipoFrete();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar TipoFrete [" + ToString() + "] - " + ex.Message);
            }
        }

        public string RetornarCodigo(int cid)
        {
            try
            {
                var regra = new rTipoFrete();
                return regra.RetornarCodigo(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em RetornarCodigo TipoFrete [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}

