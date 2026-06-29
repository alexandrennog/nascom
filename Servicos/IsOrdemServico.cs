using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsOrdemServico
{
    public interface IsOrdemServico
    {
        public ColecaoOrdemServico Listar();
        public ColecaoOrdemServico Consultar(dOrdemServico dados);
        public int ConsultarMax();
        public int Incluir(dOrdemServico dados);
        public int Alterar(dOrdemServico dados);
        public int Excluir(dOrdemServico dados);
    }
}