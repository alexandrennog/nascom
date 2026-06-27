using System;
using ncDados.nsProduto;
using ncRegras.nsProduto;
using ncComum.nsExcecao;

namespace ncServicos.nsProduto
{
    public class sProdutoTipo
    {
        public ColecaoProdutoTipo Listar()
        {
            try
            {
                var regra = new rProdutoTipo();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar ProdutoTipo [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoProdutoTipo Consultar(dProdutoTipo dados)
        {
            try
            {
                var regra = new rProdutoTipo();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoTipo [" + ToString() + "] - " + ex.Message);
            }
        }

        public dProdutoTipo Consultar(int cid)
        {
            try
            {
                var regra = new rProdutoTipo();
                return regra.Consultar(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoTipo [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dProdutoTipo dados)
        {
            try
            {
                var regra = new rProdutoTipo();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir ProdutoTipo [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dProdutoTipo dados)
        {
            try
            {
                var regra = new rProdutoTipo();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar ProdutoTipo [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dProdutoTipo dados)
        {
            try
            {
                var regra = new rProdutoTipo();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir ProdutoTipo [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
