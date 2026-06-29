using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsContasPagar
    {
        public ColecaoContasPagar Listar();
        public ColecaoContasPagar Consultar(dContasPagar dados);
        public dContasPagar Consultar(int cid);
        public int Incluir(dContasPagar dados);
        public int Importar(dContasPagar dados);
        public int Alterar(dContasPagar dados);
        public int Excluir(dContasPagar dados);
    }
}