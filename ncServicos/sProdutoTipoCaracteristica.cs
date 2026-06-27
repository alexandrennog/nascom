using System;
using ncDados.nsProduto;
using ncRegras.nsProduto;
using ncComum.nsExcecao;

namespace ncServicos.nsProduto
{
    public class sProdutoTipoCaracteristica
    {
        public ColecaoProdutoTipoCaracteristica Listar()
        {
            try
            {
                var regra = new rProdutoTipoCaracteristica();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoProdutoTipoCaracteristica Consultar(dProdutoTipoCaracteristica dados)
        {
            try
            {
                var regra = new rProdutoTipoCaracteristica();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoProdutoTipoCaracteristica ConsultarPorProdutoTipo(int produtoTipo_cid)
        {
            try
            {
                var regra = new rProdutoTipoCaracteristica();
                return regra.ConsultarPorProdutoTipo(produtoTipo_cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarPorProdutoTipo ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dProdutoTipoCaracteristica dados)
        {
            try
            {
                var regra = new rProdutoTipoCaracteristica();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirPorProdutoTipo(int produtoTipo_cid)
        {
            try
            {
                var regra = new rProdutoTipoCaracteristica();
                return regra.ExcluirPorProdutoTipo(produtoTipo_cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ExcluirPorProdutoTipo ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirPorCaracteristica(int caracteristica_cid)
        {
            try
            {
                var regra = new rProdutoTipoCaracteristica();
                return regra.ExcluirPorCaracteristica(caracteristica_cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ExcluirPorCaracteristica ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(int cid)
        {
            try
            {
                var regra = new rProdutoTipoCaracteristica();
                return regra.Excluir(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
