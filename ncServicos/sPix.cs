using System;
using ncDados.nsPix;
using ncRegras.nsPix;
using ncComum.nsExcecao;

namespace ncServicos.nsPix
{
    public class sPix
    {
        public int Incluir(dPix dados)
        {
            try
            {
                var regra = new rPix();
                return regra.fIncluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Pix [" + ToString() + "] - " + ex.Message);
            }
        }

        public dPix Consultar(string tx)
        {
            try
            {
                var regra = new rPix();
                return regra.Consultar(tx);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Pix [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoPix Consultar(dPix dados)
        {
            try
            {
                var regra = new rPix();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Pix [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
