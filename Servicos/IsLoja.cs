using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsLoja
    {
        public ColecaoLoja Listar();
        public ColecaoLoja Consultar(dLoja dados);
        public dLoja Consultar(int cid);
        public int Incluir(dLoja dados);
        public int Alterar(dLoja dados);
        public int Excluir(dLoja dados);
    }
}