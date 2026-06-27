using System;
using ncDados.nsVenda;
using ncRegras.nsVenda;
using ncComum.nsExcecao;

namespace ncServicos.nsVenda
{
    public class sPreVendaProduto
    {
        public ColecaoVendaProduto Listar()
        {
            try
            {
                var regra = new rPreVendaProduto();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar PreVendaProduto [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVendaProduto Consultar(dVendaProduto dados)
        {
            try
            {
                var regra = new rPreVendaProduto();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar PreVendaProduto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dVendaProduto dados)
        {
            try
            {
                var regra = new rPreVendaProduto();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir PreVendaProduto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dVendaProduto dados)
        {
            try
            {
                var regra = new rPreVendaProduto();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar PreVendaProduto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dVendaProduto dados)
        {
            try
            {
                var regra = new rPreVendaProduto();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir PreVendaProduto [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
