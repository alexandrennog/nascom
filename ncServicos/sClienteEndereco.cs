using System;
using ncDados.nsCliente;
using ncRegras.nsCliente;
using ncComum.nsExcecao;

namespace ncServicos.nsCliente
{
    public class sClienteEndereco
    {
        public ColecaoClienteEndereco Listar()
        {
            try
            {
                var regra = new rClienteEndereco();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar ClienteEndereco [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoClienteEndereco Consultar(dClienteEndereco dados)
        {
            try
            {
                var regra = new rClienteEndereco();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ClienteEndereco [" + ToString() + "] - " + ex.Message);
            }
        }

        public dClienteEndereco ConsultarPorCID(int cid)
        {
            try
            {
                var regra = new rClienteEndereco();
                return regra.ConsultarPorCID(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarPorCID ClienteEndereco [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dClienteEndereco dados)
        {
            try
            {
                var regra = new rClienteEndereco();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir ClienteEndereco [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirPorCliente(int cliente_cid)
        {
            try
            {
                var regra = new rClienteEndereco();
                return regra.ExcluirPorCliente(cliente_cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ExcluirPorCliente ClienteEndereco [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
