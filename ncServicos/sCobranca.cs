using System;
using ncDados.nsCobranca;
using ncRegras.nsCobranca;
using ncComum.nsExcecao;

namespace ncServicos.nsCobranca
{
    public class sCobranca
    {
        public ColecaoCobranca ConsultarCobrancas(dCobrancaAutomatica dados)
        {
            try
            {
                var regra = new rCobranca();
                return regra.ConsultarCobrancas(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarCobrancas Cobranca [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
