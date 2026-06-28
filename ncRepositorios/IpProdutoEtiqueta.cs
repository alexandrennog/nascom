using System;
using ncModelos;

namespace ncRepositorios
{
    public interface IpProdutoEtiqueta
    {
        ColecaoProdutoEtiqueta Listar(string dataDe, string dataAte, int ImprimeTodos);
        int Alterar(string data, string produto, string codigoBarras);
    }
}
