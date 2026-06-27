using System;
using ncDados.nsPix;
using ncRegras.nsPix;
using ncComum.nsExcecao;

namespace ncServicos.nsPix
{
    public class sPixConfig
    {
        public int Incluir(dPixConfig dados)
        {
            try
            {
                var regra = new rPixConfig();
                return regra.fIncluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir PixConfig [" + ToString() + "] - " + ex.Message);
            }
        }

        public dPixConfig Consultar()
        {
            try
            {
                var regra = new rPixConfig();
                return regra.fConsultar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar PixConfig [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
