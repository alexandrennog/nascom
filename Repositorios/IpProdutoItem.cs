using System;
using Modelos;


namespace Repositorios
{
    public interface IpProdutoItem
    {
        ColecaoProdutoItem Listar();
        ColecaoProdutoItem Consultar(dProdutoItem dados);
        ColecaoProdutoItem ConsultarProdutoItem(string descricao, string codigoBarras, string referencia, bool emEstoque);
        decimal ConsultarEstoque(string codigoBarras);
        ColecaoProdutoItem ConsultarQuantidadeItem(int produto_cid);
        int? ConsultarUltimoItem(int produto_cid);
        string ConsultarUltimoCodigoBarras();
        int Incluir(dProdutoItem dados);
        int Alterar(dProdutoItem dados);
        int AlterarEstoque(string codigoBarras, decimal quantidade, bool somar);
        int Excluir(dProdutoItem dados);
        int ExcluirPorProduto(dProdutoItem dados);
    }
}
