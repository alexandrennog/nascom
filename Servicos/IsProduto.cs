using System;
using System.Transactions;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsProduto
    {
        public ColecaoProduto Listar();
        public ColecaoProduto Consultar(dProduto dados);
        public ColecaoGradeEntrada ConsultarGradeEntrada(dProduto dados);
        public dProduto Consultar(int cid);
        public int ConsultarProximoCID();
        public int Incluir(dProduto dados);
        public int Importar(dProduto dados);
        public int Incluir(dProduto dados, ColecaoItensProdutos colecaoItem, dUsuario usuario);
        public int Alterar(dProduto dados);
        public int Alterar(dProduto dados, ColecaoItensProdutos colecaoItem, dUsuario usuario);
        public int Excluir(dProduto dados, dUsuario usuario);
    }
}