using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoItensProdutos : List<ColecaoProdutoItem>
    {
    }

    public class ColecaoProdutoItem : List<dProdutoItem>
    {
    }

    public class dProdutoItem
    {
        private int? _produtos_cid;
        private string _produtos_descricao;
        private string _produtos_estoque;
        private string _produtos_tamanho;
        private decimal _produtos_valorVenda;
        private string _produtos_referencia;
        private string _produtos_cor;
        private int? _item;
        private int? _caracteristicas_cid;
        private string _caracteristicas_nome;
        private string _caracteristicas_codigo;
        private string _valor;

        public int? produtos_cid
        {
            get => _produtos_cid;
            set => _produtos_cid = value;
        }

        public string produtos_descricao
        {
            get => _produtos_descricao;
            set => _produtos_descricao = value;
        }

        public string produtos_estoque
        {
            get => _produtos_estoque;
            set => _produtos_estoque = value;
        }

        public int? item
        {
            get => _item;
            set => _item = value;
        }

        public int? caracteristicas_cid
        {
            get => _caracteristicas_cid;
            set => _caracteristicas_cid = value;
        }

        public string caracteristicas_nome
        {
            get => _caracteristicas_nome;
            set => _caracteristicas_nome = value;
        }

        public string caracteristicas_codigo
        {
            get => _caracteristicas_codigo;
            set => _caracteristicas_codigo = value;
        }

        public string valor
        {
            get => _valor;
            set => _valor = value;
        }

        public decimal Produtos_ValorVenda
        {
            get => _produtos_valorVenda;
            set => _produtos_valorVenda = value;
        }

        public string Produtos_Tamanho
        {
            get => _produtos_tamanho;
            set => _produtos_tamanho = value;
        }

        public string Produtos_Referencia
        {
            get => _produtos_referencia;
            set => _produtos_referencia = value;
        }

        public string Produtos_Cor
        {
            get => _produtos_cor;
            set => _produtos_cor = value;
        }
    }

}
