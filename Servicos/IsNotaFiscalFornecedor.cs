using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsNotaFiscalFornecedor
    {
        public ColecaoNotaFiscalFornecedor Listar();
        public ColecaoNotaFiscalFornecedor Consultar(dNotaFiscalFornecedor dados);
        public dNotaFiscalFornecedor Selecionar(string numero, string serie);
        public int Incluir(dNotaFiscalFornecedor dados);
        public int Alterar(dNotaFiscalFornecedor dados);
        public int Excluir(dNotaFiscalFornecedor dados);
    }
}