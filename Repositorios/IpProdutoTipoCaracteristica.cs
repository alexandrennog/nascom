using System;
using Modelos;


namespace Repositorios
{
    public interface IpProdutoTipoCaracteristica
    {
        ColecaoProdutoTipoCaracteristica Listar();
        ColecaoProdutoTipoCaracteristica ConsultarPorProdutoTipo(int produtoTipo_cid);
        ColecaoProdutoTipoCaracteristica Consultar(dProdutoTipoCaracteristica dados);
        int Incluir(dProdutoTipoCaracteristica dados);
        int ExcluirPorProdutoTipo(int produtoTipo_cid);
        int ExcluirPorCaracteristica(int caracteristica_cid);
        int Excluir(int cid);
    }
}
