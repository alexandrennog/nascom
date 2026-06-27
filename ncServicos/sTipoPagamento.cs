using System;
using ncDados.nsTipoPagamento;
using ncRegras.nsRegras;
using ncComum.nsExcecao;

namespace ncServicos.nsRegras
{
    public class sTipoPagamento
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
