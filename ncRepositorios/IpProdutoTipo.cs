using nsProduto;
using System;

namespace ncPersistencia.nsProduto
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
