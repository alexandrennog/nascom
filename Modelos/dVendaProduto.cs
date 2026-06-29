using System;
using System.Collections.Generic;

namespace Modelos
{
    public class ColecaoVendaProduto : List<dVendaProduto>
    {
    }

    public class dVendaProduto
    {
        private int _controle;
        private int _produtoId;
        private int _itemId;
        private decimal _quantidade;
        private decimal _valor;
        private string _codigobarras;
        private string _descricao;
        private string _referencia;
        private string _aliquota;

        public int controle
        {
            get => _controle;
            set => _controle = value;
        }

        public int produtoId
        {
            get => _produtoId;
            set => _produtoId = value;
        }

        public int itemId
        {
            get => _itemId;
            set => _itemId = value;
        }

        public decimal quantidade
        {
            get => _quantidade;
            set => _quantidade = value;
        }

        public decimal valor
        {
            get => _valor;
            set => _valor = value;
        }

        public string codigobarras
        {
            get => _codigobarras;
            set => _codigobarras = value;
        }

        public string descricao
        {
            get => _descricao;
            set => _descricao = value;
        }

        public string referencia
        {
            get => _referencia;
            set => _referencia = value;
        }

        public string aliquota
        {
            get => _aliquota;
            set => _aliquota = value;
        }
    }

}
