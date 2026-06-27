using System;
using ncDados.nsVenda;
using ncRegras.nsVenda;
using ncComum.nsExcecao;

namespace ncServicos.nsVenda
{
    public class sVendaProduto
    {
        public ColecaoVendaProduto Listar()
        {
            try
            {
                var regra = new rVendaProduto();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar VendaProduto [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVendaProduto Consultar(dVendaProduto dados)
        {
            try
            {
                var regra = new rVendaProduto();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar VendaProduto [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVendaProduto ConsultarTroca(dVendaProduto dados)
        {
            try
            {
                var regra = new rVendaProduto();
                return regra.ConsultarTroca(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarTroca VendaProduto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dVendaProduto dados)
        {
            try
            {
                var regra = new rVendaProduto();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir VendaProduto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dVendaProduto dados)
        {
            try
            {
                var regra = new rVendaProduto();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar VendaProduto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dVendaProduto dados)
        {
            try
            {
                var regra = new rVendaProduto();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir VendaProduto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirTroca(dVendaProduto dados)
        {
            try
            {
                var regra = new rVendaProduto();
                return regra.ExcluirTroca(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ExcluirTroca VendaProduto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirControle(int controle)
        {
            try
            {
                var regra = new rVendaProduto();
                return regra.ExcluirControle(controle);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ExcluirControle VendaProduto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirControleTroca(int controle)
        {
            try
            {
                var regra = new rVendaProduto();
                return regra.ExcluirControleTroca(controle);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ExcluirControleTroca VendaProduto [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
