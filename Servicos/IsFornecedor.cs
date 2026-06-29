using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsFornecedor
{
    public interface IsFornecedor
    {
        public ColecaoFornecedor Listar();
        public ColecaoFornecedor Consultar(dFornecedor dados);
        public dFornecedor Consultar(int cid);
        public int Incluir(dFornecedor dados);
        public int Importar(dFornecedor dados);
        public int Alterar(dFornecedor dados);
        public int Excluir(dFornecedor dados);
    }
}