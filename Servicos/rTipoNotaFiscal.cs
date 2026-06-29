using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public class rTipoNotaFiscal
    {
        public ColecaoTipoNotaFiscal Listar()
        {
            try
            {
                var regra = new rTipoNotaFiscal();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar TipoNotaFiscal [" + ToString() + "] - " + ex.Message);
            }
        }

        public string RetornarCodigo(int cid)
        {
            try
            {
                var regra = new rTipoNotaFiscal();
                return regra.RetornarCodigo(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em RetornarCodigo TipoNotaFiscal [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
