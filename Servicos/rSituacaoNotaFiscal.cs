using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public class rSituacaoNotaFiscal : IsSituacaoNotaFiscal
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

