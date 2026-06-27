using System;
using ncDados.nsCliente;
using ncRegras.nsCliente;
using ncComum.nsExcecao;

namespace ncServicos.nsCliente
{
    public class sClienteFinanceiro
    {
        public ColecaoClienteFinanceiro Listar()
        {
            try
            {
                var regra = new rClienteFinanceiro();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar ClienteFinanceiro [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoClienteFinanceiro Consultar(dClienteFinanceiro dados)
        {
            try
            {
                var regra = new rClienteFinanceiro();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ClienteFinanceiro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dClienteFinanceiro dados)
        {
            try
            {
                var regra = new rClienteFinanceiro();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir ClienteFinanceiro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dClienteFinanceiro dados)
        {
            try
            {
                var regra = new rClienteFinanceiro();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar ClienteFinanceiro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirPorCliente(int cliente_cid)
        {
            try
            {
                var regra = new rClienteFinanceiro();
                return regra.ExcluirPorCliente(cliente_cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ExcluirPorCliente ClienteFinanceiro [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
