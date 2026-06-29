using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public class rTipoEmissao : IsTipoEmissao
    {
        public ColecaoTipoEmissao Listar()
        {
            try
            {
                var regra = new rTipoEmissao();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar TipoEmissao [" + ToString() + "] - " + ex.Message);
            }
        }

        public string RetornarCodigo(int cid)
        {
            try
            {
                var regra = new rTipoEmissao();
                return regra.RetornarCodigo(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em RetornarCodigo TipoEmissao [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}

