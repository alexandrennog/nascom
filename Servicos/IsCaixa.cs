using System;
using Modelos;
using Repositorios;
using Comum;

namespace Servicos
{
    public interface IsCaixa
    {
        public ColecaoCaixa Listar();
        public ColecaoCaixa Consultar(dCaixa dados);
        public ColecaoFechamento ConsultarFechamento(dCaixa dados);
        public dCaixa Consultar(int cid);
        public int Incluir(dCaixa dados);
        public int Alterar(dCaixa dados);
        public int Excluir(dCaixa dados);
    }
}