using System;
using ncDados.nsVenda;
using ncDados;
using ncRegras.nsVenda;
using ncComum.nsExcecao;

namespace ncServicos.nsVenda
{
    public class sVenda
    {
        public ColecaoVenda Listar()
        {
            try
            {
                var regra = new rVenda();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaodVendasNfe ListarVendasNfe(string dataIni, string dataFim)
        {
            try
            {
                var regra = new rVenda();
                return regra.ListarVendasNfe(dataIni, dataFim);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ListarVendasNfe Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaodVendasABC ListarVendasABC(string dataIni, string dataFim, string tipo)
        {
            try
            {
                var regra = new rVenda();
                return regra.ListarVendasABC(dataIni, dataFim, tipo);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ListarVendasABC Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVenda Consultar(dVenda dados)
        {
            try
            {
                var regra = new rVenda();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVenda ConsultarPix(dVenda dados)
        {
            try
            {
                var regra = new rVenda();
                return regra.ConsultarPix(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarPix Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVendasPorVendedor ConsultarVendasPorVendedor(dVendasPorVendedor dados)
        {
            try
            {
                var regra = new rVenda();
                return regra.ConsultarVendasPorVendedor(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarVendasPorVendedor Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVendasPorVendedor ConsultarVendasDaLoja(dVendasPorVendedor dados)
        {
            try
            {
                var regra = new rVenda();
                return regra.ConsultarVendasDaLoja(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarVendasDaLoja Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVenda ConsultarCrediarioPix(dVenda dados)
        {
            try
            {
                var regra = new rVenda();
                return regra.ConsultarCrediarioPix(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarCrediarioPix Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVenda ConsultarTroca(dVenda dados)
        {
            try
            {
                var regra = new rVenda();
                return regra.ConsultarTroca(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarTroca Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public dVenda ConsultarUltimaVenda(int produto_cid)
        {
            try
            {
                var regra = new rVenda();
                return regra.ConsultarUltimaVenda(produto_cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarUltimaVenda Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ConsultarMax()
        {
            try
            {
                var regra = new rVenda();
                return regra.ConsultarMax();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarMax Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dVenda dados, ColecaoVendaProduto dadosProdutos)
        {
            try
            {
                var regra = new rVenda();
                return regra.Incluir(dados, dadosProdutos);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int IncluirnNF(dBasennf dados)
        {
            try
            {
                var regra = new rVenda();
                return regra.IncluirnNF(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em IncluirnNF Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int IncluirTroca(dVenda dados, ColecaoVendaProduto dadosProdutos)
        {
            try
            {
                var regra = new rVenda();
                return regra.IncluirTroca(dados, dadosProdutos);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em IncluirTroca Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int IncluirVale(dVenda dados)
        {
            try
            {
                var regra = new rVenda();
                return regra.IncluirVale(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em IncluirVale Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int IncluirCrediarioPagamento(dVenda dados)
        {
            try
            {
                var regra = new rVenda();
                return regra.IncluirCrediarioPagamento(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em IncluirCrediarioPagamento Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dVenda dados)
        {
            try
            {
                var regra = new rVenda();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(string controle, string chave)
        {
            try
            {
                var regra = new rVenda();
                return regra.Alterar(controle, chave);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int AlterarBaseNnf(dBasennf dados)
        {
            try
            {
                var regra = new rVenda();
                return regra.AlterarBaseNnf(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em AlterarBaseNnf Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dVenda dados)
        {
            try
            {
                var regra = new rVenda();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirVale(dVenda dados)
        {
            try
            {
                var regra = new rVenda();
                return regra.ExcluirVale(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ExcluirVale Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVenda ConsultarFechamento(dVenda dados)
        {
            try
            {
                var regra = new rVenda();
                return regra.ConsultarFechamento(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarFechamento Venda [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
