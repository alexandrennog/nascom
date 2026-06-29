using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsServico
{
    public interface IsServico
    {
        public ColecaoServico Listar();
        public ColecaoServico Consultar(dServico dados);
        public dServico Consultar(int cid);
        public int Incluir(dServico dados);
        public int Alterar(dServico dados);
        public int Excluir(dServico dados);
    }
}