using System;
using ncDados.nsVeiculos;
using ncRegras.nsVeiculos;
using ncComum.nsExcecao;

namespace ncServicos.nsVeiculos
{
    public class sVeiculos
    {
        public ColecaoVeiculos Listar()
        {
            try
            {
                var regra = new rVeiculos();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Veiculos [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVeiculos Consultar(dVeiculos dados)
        {
            try
            {
                var regra = new rVeiculos();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Veiculos [" + ToString() + "] - " + ex.Message);
            }
        }

        public dVeiculos ConsultarPorCID(int cid)
        {
            try
            {
                var regra = new rVeiculos();
                return regra.ConsultarPorCID(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarPorCID Veiculos [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(ColecaoVeiculos dadosVeiculos)
        {
            try
            {
                var regra = new rVeiculos();
                return regra.Incluir(dadosVeiculos);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Veiculos [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dVeiculos dados)
        {
            try
            {
                var regra = new rVeiculos();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Veiculos [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(ColecaoVeiculos dadosVeiculos)
        {
            try
            {
                var regra = new rVeiculos();
                return regra.Alterar(dadosVeiculos);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Veiculos [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dVeiculos dados)
        {
            try
            {
                var regra = new rVeiculos();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Veiculos [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirVeiculosCliente(dVeiculos dados)
        {
            try
            {
                var regra = new rVeiculos();
                return regra.ExcluirVeiculosCliente(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ExcluirVeiculosCliente Veiculos [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
