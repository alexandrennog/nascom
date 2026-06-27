using System;
using nsProdutoEtiqueta;

namespace ncPersistencia.nsProdutoEtiqueta
{
    public interface IpProdutoEtiqueta
    {
        ColecaoProdutoEtiqueta Listar(string dataDe, string dataAte, int ImprimeTodos);
        int Alterar(string data, string produto, string codigoBarras);
    }
}
