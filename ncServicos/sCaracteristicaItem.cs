using System;
using ncDados.nsCaracteristica;
using ncRegras.nsCaracteristica;
using ncComum.nsExcecao;

namespace ncServicos.nsCaracteristica
{
    public class sCaracteristicaItem
    {
        public ColecaoCaracteristicaItem Listar()
        {
            try
            {
                var regra = new rCaracteristicaItem();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoCaracteristicaItem Consultar(dCaracteristicaItem dados)
        {
            try
            {
                var regra = new rCaracteristicaItem();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public dCaracteristicaItem ConsultarPorCID(int cid)
        {
            try
            {
                var regra = new rCaracteristicaItem();
                return regra.ConsultarPorCID(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarPorCID CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoCaracteristicaItem ConsultarPorCaracteristica(int caracteristica_cid)
        {
            try
            {
                var regra = new rCaracteristicaItem();
                return regra.ConsultarPorCaracteristica(caracteristica_cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarPorCaracteristica CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dCaracteristicaItem dados)
        {
            try
            {
                var regra = new rCaracteristicaItem();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dCaracteristicaItem dados)
        {
            try
            {
                var regra = new rCaracteristicaItem();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dCaracteristicaItem dados)
        {
            try
            {
                var regra = new rCaracteristicaItem();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirPorCID(int cid)
        {
            try
            {
                var regra = new rCaracteristicaItem();
                return regra.ExcluirPorCID(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ExcluirPorCID CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
