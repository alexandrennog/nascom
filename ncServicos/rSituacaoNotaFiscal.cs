using System;
using ncNComum;
using ncRepositorios;
using ncModelos;

namespace ncServicos
{
    public class rSituacaoNotaFiscal
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
