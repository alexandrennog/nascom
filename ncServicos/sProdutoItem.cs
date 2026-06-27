using System;
using ncDados.nsProduto;
using ncPersistencia.nsProduto;
using ncRegras.nsProduto;
using ncComum.nsExcecao;

namespace ncServicos.nsProduto
{
    public class sProdutoItem
    {
        private readonly IpProdutoItem _repo;
        public sProdutoItem(IpProdutoItem repo) { _repo = repo; }

        public ColecaoProdutoItem Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar ProdutoItem [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoProdutoItem Consultar(dProdutoItem dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar ProdutoItem [" + ToString() + "] - " + ex.Message); }
        }

        public int? ConsultarUltimoItem(int produto_cid)
        {
            try { return _repo.ConsultarUltimoItem(produto_cid); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarUltimoItem ProdutoItem [" + ToString() + "] - " + ex.Message); }
        }

        public string ConsultarUltimoCodigoBarras()
        {
            try { return _repo.ConsultarUltimoCodigoBarras(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarUltimoCodigoBarras ProdutoItem [" + ToString() + "] - " + ex.Message); }
        }

        public dProdutoItem Selecionar(dProdutoItem dados)
        {
            try
            {
                var lista = _repo.Consultar(dados);
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Selecionar ProdutoItem [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoProdutoItem ConsultarQuantidadeItem(int produtos_cid)
        {
            try { return _repo.ConsultarQuantidadeItem(produtos_cid); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarQuantidadeItem ProdutoItem [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoProdutoItem ConsultarProdutoItem(string descricao, string codigoBarras, string referencia, bool emEstoque)
        {
            try { return _repo.ConsultarProdutoItem(descricao, codigoBarras, referencia, emEstoque); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarProdutoItem [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoProdutoItem ConsultarPorProduto(int produto_cid)
        {
            try { return _repo.Consultar(new dProdutoItem { produtos_cid = produto_cid }); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarPorProduto ProdutoItem [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dProdutoItem dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir ProdutoItem [" + ToString() + "] - " + ex.Message); }
        }

        public int IncluirListaItem(ColecaoProdutoItem colecao)
        {
            try
            {
                foreach (var item in colecao)
                    _repo.Incluir(item);
                return 1;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em IncluirListaItem ProdutoItem [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dProdutoItem dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar ProdutoItem [" + ToString() + "] - " + ex.Message); }
        }

        // AlterarEstoque não existe em IpProdutoItem — mantém rProdutoItem
        public int AlterarEstoque(string codigoBarras, decimal quantidade)
        {
            try { var regra = new rProdutoItem(); return regra.AlterarEstoque(codigoBarras, quantidade); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em AlterarEstoque ProdutoItem [" + ToString() + "] - " + ex.Message); }
        }

        public int AlterarEstoque(string codigoBarras, decimal quantidade, bool somar)
        {
            try { var regra = new rProdutoItem(); return regra.AlterarEstoque(codigoBarras, quantidade, somar); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em AlterarEstoque ProdutoItem [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dProdutoItem dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir ProdutoItem [" + ToString() + "] - " + ex.Message); }
        }

        public int ExcluirPorProduto(dProdutoItem dados)
        {
            try { return _repo.ExcluirPorProduto(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ExcluirPorProduto ProdutoItem [" + ToString() + "] - " + ex.Message); }
        }

        public int ExcluirPorProduto(int produtos_cid)
        {
            try { return _repo.ExcluirPorProduto(new dProdutoItem { produtos_cid = produtos_cid }); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ExcluirPorProduto ProdutoItem [" + ToString() + "] - " + ex.Message); }
        }
    }
}
