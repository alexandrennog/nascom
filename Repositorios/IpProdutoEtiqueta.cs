using System;
using Modelos;

namespace Repositorios
{
    public interface IpProdutoEtiqueta
    {
        ColecaoProdutoEtiqueta Listar(string dataDe, string dataAte, int ImprimeTodos);
        int Alterar(string data, string produto, string codigoBarras);
    }
}
