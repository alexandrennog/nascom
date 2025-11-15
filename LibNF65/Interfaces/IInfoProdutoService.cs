using LibNF65.Modelo;
using System.Collections.Generic;

namespace LibNF65.Interfaces
{
    // A interface do serviço espelha as operações do repositório,
    // mas é aqui que a lógica de negócio seria aplicada.
    public interface IInfoProdutoService
    {
        void AdicionarInfoProduto(InfoProduto infoProduto, IInfProtRepository repository);
        InfoProduto BuscarPorChNFe(string chNFe, IInfProtRepository repository);
        IEnumerable<InfoProduto> BuscarTodos(IInfProtRepository repository);
        void AtualizarInfoProduto(InfoProduto infoProduto, IInfProtRepository repository);
        void RemoverInfoProduto(string chNFe, IInfProtRepository repository);
    }


}
