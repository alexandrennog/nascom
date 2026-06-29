using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsProdutoItem
    {
        public ColecaoProdutoItem Listar();
        public ColecaoProdutoItem Consultar(dProdutoItem dados);
        public int? ConsultarUltimoItem(int produto_cid);
        public string ConsultarUltimoCodigoBarras();
        public dProdutoItem Selecionar(dProdutoItem dados);
        public ColecaoProdutoItem ConsultarQuantidadeItem(int produtos_cid);
        public ColecaoProdutoItem ConsultarProdutoItem(string descricao, string codigoBarras, string referencia, bool emEstoque);
        public ColecaoProdutoItem ConsultarPorProduto(int produto_cid);
        public int Incluir(dProdutoItem dados);
        public int IncluirListaItem(ColecaoProdutoItem colecao);
        public int Alterar(dProdutoItem dados);
        public int AlterarEstoque(string codigoBarras, decimal quantidade);
        public int AlterarEstoque(string codigoBarras, decimal quantidade, bool somar);
        public int Excluir(dProdutoItem dados);
        public int ExcluirPorProduto(dProdutoItem dados);
        public int ExcluirPorProduto(int produtos_cid);
    }
}