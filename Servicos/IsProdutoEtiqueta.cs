using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsProdutoEtiqueta
{
    public interface IsProdutoEtiqueta
    {
        public ColecaoProdutoEtiqueta Listar(string dataDe, string dataAte, int ImprimeTodos);
        public int Alterar(string data, string produto, string codigoBarras);
    }
}