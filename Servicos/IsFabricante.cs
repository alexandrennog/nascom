using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsFabricante
{
    public interface IsFabricante
    {
        public ColecaoFabricante Listar();
        public ColecaoFabricante Consultar(dFabricante dados);
        public dFabricante Consultar(int cid);
        public int Incluir(dFabricante dados);
        public int Alterar(dFabricante dados);
        public int Excluir(dFabricante dados);
    }
}