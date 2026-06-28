using System;
using ncNComum;
using ncRepositorios;
using ncModelos;

namespace ncServicos
{
    public class rTipoFrete
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
