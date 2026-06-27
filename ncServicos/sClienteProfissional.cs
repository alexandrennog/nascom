using System;
using ncDados.nsCliente;
using ncRegras.nsCliente;
using ncComum.nsExcecao;

namespace ncServicos.nsCliente
{
    public class sClienteProfissional
    {
        public ColecaoClienteProfissional Listar()
        {
            try
            {
                var regra = new rClienteProfissional();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar ClienteProfissional [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoClienteProfissional Consultar(dClienteProfissional dados)
        {
            try
            {
                var regra = new rClienteProfissional();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ClienteProfissional [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dClienteProfissional dados)
        {
            try
            {
                var regra = new rClienteProfissional();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir ClienteProfissional [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dClienteProfissional dados)
        {
            try
            {
                var regra = new rClienteProfissional();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar ClienteProfissional [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirPorCliente(int cliente_cid)
        {
            try
            {
                var regra = new rClienteProfissional();
                return regra.ExcluirPorCliente(cliente_cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ExcluirPorCliente ClienteProfissional [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
