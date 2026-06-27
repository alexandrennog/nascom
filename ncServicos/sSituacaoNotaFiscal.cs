using System;
using ncDados.nsSituacaoNotaFiscal;
using ncRegras.nsRegras;
using ncComum.nsExcecao;

namespace ncServicos.nsRegras
{
    public class sSituacaoNotaFiscal
    {
        public ColecaoSituacaoNotaFiscal Listar()
        {
            try
            {
                var regra = new rSituacaoNotaFiscal();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar SituacaoNotaFiscal [" + ToString() + "] - " + ex.Message);
            }
        }

        public string RetornarCodigo(int cid)
        {
            try
            {
                var regra = new rSituacaoNotaFiscal();
                return regra.RetornarCodigo(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em RetornarCodigo SituacaoNotaFiscal [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
