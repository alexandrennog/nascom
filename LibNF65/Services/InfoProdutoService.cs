using LibNF65.Interfaces;
using LibNF65.Modelo;
using System;
using System.Collections.Generic;

namespace LibNF65.Services
{
    public class InfoProdutoService : IInfoProdutoService
    {
        private readonly IInfProtRepository _repository;

        // Injeção de Dependência do Repositório
        public InfoProdutoService(IInfProtRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void AdicionarInfoProduto(InfoProduto infoProduto)
        {
            // Exemplo de Lógica de Negócio: Validação antes de adicionar
            if (string.IsNullOrWhiteSpace(infoProduto.ChNFe) || infoProduto.ChNFe.Length != 44)
            {
                throw new ArgumentException("Chave da NFe inválida.");
            }

            // Se a lógica de negócio for satisfeita, chama o repositório
            _repository.Add(infoProduto);
        }

        public InfoProduto BuscarPorChNFe(string chNFe)
        {
            // Exemplo de Lógica de Negócio: Formatação ou verificação de permissão
            if (string.IsNullOrWhiteSpace(chNFe))
            {
                throw new ArgumentException("Chave da NFe não pode ser vazia.");
            }

            return _repository.GetByChNFe(chNFe);
        }

        public IEnumerable<InfoProduto> BuscarTodos()
        {
            // Lógica de Negócio: Filtragem, ordenação ou paginação
            return _repository.GetAll();
        }

        public void AtualizarInfoProduto(InfoProduto infoProduto)
        {
            // Exemplo de Lógica de Negócio: Verificação de existência antes de atualizar
            var existing = _repository.GetByChNFe(infoProduto.ChNFe);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Produto com ChNFe {infoProduto.ChNFe} não encontrado para atualização.");
            }

            _repository.Update(infoProduto);
        }

        public void RemoverInfoProduto(string chNFe)
        {
            // Lógica de Negócio: Verificação de dependências antes de remover
            _repository.Delete(chNFe);
        }
    }
}
