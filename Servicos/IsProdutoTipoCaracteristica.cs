using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsProdutoTipoCaracteristica
    {
        public ColecaoProdutoTipoCaracteristica Listar();
        public ColecaoProdutoTipoCaracteristica Consultar(dProdutoTipoCaracteristica dados);
        public ColecaoProdutoTipoCaracteristica ConsultarPorProdutoTipo(int produtoTipo_cid);
        public int Incluir(dProdutoTipoCaracteristica dados);
        public int ExcluirPorProdutoTipo(int produtoTipo_cid);
        public int ExcluirPorCaracteristica(int caracteristica_cid);
        public int Excluir(int cid);
    }
}