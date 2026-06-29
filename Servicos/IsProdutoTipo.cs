using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsProduto
{
    public interface IsProdutoTipo
    {
        public ColecaoProdutoTipo Listar();
        public ColecaoProdutoTipo Consultar(dProdutoTipo dados);
        public dProdutoTipo Consultar(int cid);
        public int Incluir(dProdutoTipo dados);
        public int Alterar(dProdutoTipo dados);
        public int Excluir(dProdutoTipo dados);
    }
}