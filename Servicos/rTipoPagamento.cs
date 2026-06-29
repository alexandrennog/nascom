using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public class rTipoPagamento
    {
        public ColecaoTipoPagamento Listar()
        {
            try
            {
                var regra = new rTipoPagamento();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar TipoPagamento [" + ToString() + "] - " + ex.Message);
            }
        }

        public string RetornarCodigo(int cid)
        {
            try
            {
                var regra = new rTipoPagamento();
                return regra.RetornarCodigo(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em RetornarCodigo TipoPagamento [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
