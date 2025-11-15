using LibNF65.Interfaces;
using LibNF65.Modelo;
using System;
using System.Collections.Generic;

namespace LibNF65.Services
{
    public class InfoProdutoService : IInfoProdutoService
    {
        public void AdicionarInfoProduto(InfoProduto infoProduto, IInfProtRepository repository)
        {
            if (string.IsNullOrWhiteSpace(infoProduto.ChNFe) || infoProduto.ChNFe.Length != 44)
            {
                throw new ArgumentException("Chave da NFe inválida.");
            }

            repository.Add(infoProduto);
        }

        public InfoProduto BuscarPorChNFe(string chNFe, IInfProtRepository repository)
        {
            if (string.IsNullOrWhiteSpace(chNFe))
            {
                throw new ArgumentException("Chave da NFe não pode ser vazia.");
            }

            return repository.GetByChNFe(chNFe);
        }

        public IEnumerable<InfoProduto> BuscarTodos(IInfProtRepository repository)
        {
            return repository.GetAll();
        }

        public void AtualizarInfoProduto(InfoProduto infoProduto, IInfProtRepository repository)
        {
            var existing = repository.GetByChNFe(infoProduto.ChNFe);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Produto com ChNFe {infoProduto.ChNFe} não encontrado para atualização.");
            }

            repository.Update(infoProduto);
        }

        public void RemoverInfoProduto(string chNFe, IInfProtRepository repository)
        {
            repository.Delete(chNFe);
        }
    }
}

