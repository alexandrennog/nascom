using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsEstado
    {
        public ColecaoEstado Listar();
        public ColecaoEstado Consultar(dEstado dados);
        public dEstado Consultar(int cid);
        public int Incluir(dEstado dados);
        public int Alterar(dEstado dados);
        public int Excluir(dEstado dados);
    }
}