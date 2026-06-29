using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsCategoria
{
    public interface IsCategoria
    {
        public ColecaoCategoria Listar();
        public ColecaoCategoria Consultar(dCategoria dados);
        public dCategoria Consultar(int cid);
        public int Incluir(dCategoria dados);
        public int Importar(dCategoria dados);
        public int Alterar(dCategoria dados);
        public int Excluir(dCategoria dados);
    }
}