using System;
using ncDados.nsProduto;
using ncRegras.nsProduto;
using ncComum.nsExcecao;

namespace ncServicos.nsProduto
{
    public class sProdutoItem
    {
        public ColecaoProdutoItem Listar()
        {
            try
            {
                var regra = new rProdutoItem();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoProdutoItem Consultar(dProdutoItem dados)
        {
            try
            {
                var regra = new rProdutoItem();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int? ConsultarUltimoItem(int produto_cid)
        {
            try
            {
                var regra = new rProdutoItem();
                return regra.ConsultarUltimoItem(produto_cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarUltimoItem ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public string ConsultarUltimoCodigoBarras()
        {
            try
            {
                var regra = new rProdutoItem();
                return regra.ConsultarUltimoCodigoBarras();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarUltimoCodigoBarras ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public dProdutoItem Selecionar(dProdutoItem dados)
        {
            try
            {
                var regra = new rProdutoItem();
                return regra.Selecionar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Selecionar ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoProdutoItem ConsultarQuantidadeItem(int produtos_cid)
        {
            try
            {
                var regra = new rProdutoItem();
                return regra.ConsultarQuantidadeItem(produtos_cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarQuantidadeItem ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoProdutoItem ConsultarProdutoItem(string descricao, string codigoBarras, string referencia, bool emEstoque)
        {
            try
            {
                var regra = new rProdutoItem();
                return regra.ConsultarProdutoItem(descricao, codigoBarras, referencia, emEstoque);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoProdutoItem ConsultarPorProduto(int produto_cid)
        {
            try
            {
                var regra = new rProdutoItem();
                return regra.ConsultarPorProduto(produto_cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarPorProduto ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dProdutoItem dados)
        {
            try
            {
                var regra = new rProdutoItem();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int IncluirListaItem(ColecaoProdutoItem colecao)
        {
            try
            {
                var regra = new rProdutoItem();
                return regra.IncluirListaItem(colecao);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em IncluirListaItem ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dProdutoItem dados)
        {
            try
            {
                var regra = new rProdutoItem();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int AlterarEstoque(string codigoBarras, decimal quantidade)
        {
            try
            {
                var regra = new rProdutoItem();
                return regra.AlterarEstoque(codigoBarras, quantidade);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em AlterarEstoque ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int AlterarEstoque(string codigoBarras, decimal quantidade, bool somar)
        {
            try
            {
                var regra = new rProdutoItem();
                return regra.AlterarEstoque(codigoBarras, quantidade, somar);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em AlterarEstoque ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dProdutoItem dados)
        {
            try
            {
                var regra = new rProdutoItem();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirPorProduto(dProdutoItem dados)
        {
            try
            {
                var regra = new rProdutoItem();
                return regra.ExcluirPorProduto(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ExcluirPorProduto ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirPorProduto(int produtos_cid)
        {
            try
            {
                var regra = new rProdutoItem();
                return regra.ExcluirPorProduto(produtos_cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ExcluirPorProduto ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
