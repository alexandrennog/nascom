using System;
using ncModelos;

namespace ncRepositorios
{
    public interface IpProdutoTipo
    {
        ColecaoProdutoTipo Listar();
        ColecaoProdutoTipo Consultar(dProdutoTipo dados);
        int Incluir(dProdutoTipo dados);
        int Alterar(dProdutoTipo dados);
        int Excluir(dProdutoTipo dados);
    }
}
