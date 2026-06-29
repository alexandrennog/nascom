using System;
using System.Transactions;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public class rVenda : IsVenda
    {
        private readonly IpVenda _venda;
        private readonly IpVendaProduto _vendaProduto;

        public rVenda(IpVenda venda, IpVendaProduto vendaProduto)
        {
            _venda = venda;
            _vendaProduto = vendaProduto;
        }

        public ColecaoVenda Listar()
        {
            try { return _venda.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Venda [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaodVendasNfe ListarVendasNfe(string dataIni, string dataFim)
        {
            try { return _venda.ListarVendasNfe(dataIni, dataFim); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ListarVendasNfe Venda [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaodVendasABC ListarVendasABC(string dataIni, string dataFim, string tipo)
        {
            try { return _venda.ListarVendasABC(dataIni, dataFim, tipo); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ListarVendasABC Venda [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoVenda Consultar(dVenda dados)
        {
            try { return _venda.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoVenda ConsultarPix(dVenda dados)
        {
            try { return _venda.ConsultarPix(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarPix Venda [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoVendasPorVendedor ConsultarVendasPorVendedor(dVendasPorVendedor dados)
        {
            try { return _venda.ConsultarVendasPorVendedor(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarVendasPorVendedor Venda [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoVendasPorVendedor ConsultarVendasDaLoja(dVendasPorVendedor dados)
        {
            try { return _venda.ConsultarVendasDaLoja(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarVendasDaLoja Venda [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoVenda ConsultarCrediarioPix(dVenda dados)
        {
            try { return _venda.ConsultarCrediarioPix(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarCrediarioPix Venda [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoVenda ConsultarTroca(dVenda dados)
        {
            try { return _venda.ConsultarTroca(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarTroca Venda [" + ToString() + "] - " + ex.Message); }
        }

        public dVenda ConsultarUltimaVenda(int produto_cid)
        {
            try { return _venda.ConsultarUltimaVenda(produto_cid); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarUltimaVenda Venda [" + ToString() + "] - " + ex.Message); }
        }

        public int ConsultarMax()
        {
            try { return _venda.ConsultarMax(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarMax Venda [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dVenda dados, ColecaoVendaProduto dadosProdutos)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    int retorno = _venda.Incluir(dados);
                    if (dadosProdutos != null)
                        foreach (var produto in dadosProdutos)
                        {
                            produto.controle = retorno;
                            _vendaProduto.Incluir(produto);
                        }
                    ts.Complete();
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Venda [" + ToString() + "] - " + ex.Message); }
        }

        public int IncluirnNF(dBasennf dados)
        {
            try { return _venda.IncluirnNF(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em IncluirnNF Venda [" + ToString() + "] - " + ex.Message); }
        }

        public int IncluirTroca(dVenda dados, ColecaoVendaProduto dadosProdutos)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    int retorno = _venda.IncluirVale(dados);
                    if (dadosProdutos != null)
                        foreach (var produto in dadosProdutos)
                        {
                            produto.controle = retorno;
                            _vendaProduto.IncluirTroca(produto);
                        }
                    ts.Complete();
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em IncluirTroca Venda [" + ToString() + "] - " + ex.Message); }
        }

        public int IncluirVale(dVenda dados)
        {
            try { return _venda.IncluirVale(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em IncluirVale Venda [" + ToString() + "] - " + ex.Message); }
        }

        public int IncluirCrediarioPagamento(dVenda dados)
        {
            try { return _venda.IncluirCrediarioPagamento(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em IncluirCrediarioPagamento Venda [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dVenda dados)
        {
            try { return _venda.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Venda [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(string controle, string chave)
        {
            try { return _venda.Alterar(controle, chave); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Venda [" + ToString() + "] - " + ex.Message); }
        }

        public int AlterarBaseNnf(dBasennf dados)
        {
            try { return _venda.AlterarBaseNnf(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em AlterarBaseNnf Venda [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dVenda dados)
        {
            try { return _venda.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Venda [" + ToString() + "] - " + ex.Message); }
        }

        public int ExcluirVale(dVenda dados)
        {
            try { return _venda.ExcluirVale(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ExcluirVale Venda [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoVenda ConsultarFechamento(dVenda dados)
        {
            try { return _venda.ConsultarFechamento(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarFechamento Venda [" + ToString() + "] - " + ex.Message); }
        }
    }
}

