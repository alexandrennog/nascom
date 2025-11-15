using LibNF65.Modelo;
using System.Collections.Generic;

namespace LibNF65.Interfaces
{
    // A interface do serviço espelha as operações do repositório,
    // mas é aqui que a lógica de negócio seria aplicada.
    public interface IInfoProdutoService
    {
        void AdicionarInfoProduto(InfoProduto infoProduto);
        InfoProduto BuscarPorChNFe(string chNFe);
        IEnumerable<InfoProduto> BuscarTodos();
        void AtualizarInfoProduto(InfoProduto infoProduto);
        void RemoverInfoProduto(string chNFe);
    }
}
