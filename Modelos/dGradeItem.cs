using System;
using System.Collections.Generic;

namespace Modelos
{
    public class ColecaoGradeItem : List<dGradeItem>
    {
    }

    public class dGradeItem
    {
        private int? _produto_cid;
        private int? _item;
        private string _descricao;
        private string _referencia;
        private DateTime? _dataUltimaVenda;
        private string _corMaterial;
        private string _tamanho;
        private string _estoque;
        private string _codigoBarras;
        private DateTime? _dataEntrada;
        private decimal? _quantidade;
        private int? _fornecedor_cid;
        private int? _fabricante_cid;
        private int? _grupo_cid;
        private bool _ordem;

        public int? produto_cid
        {
            get => _produto_cid;
            set => _produto_cid = value;
        }

        public int? item
        {
            get => _item;
            set => _item = value;
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

        public DateTime? dataUltimaVenda
        {
            get => _dataUltimaVenda;
            set => _dataUltimaVenda = value;
        }

        public string corMaterial
        {
            get => _corMaterial;
            set => _corMaterial = value;
        }

        public string tamanho
        {
            get => _tamanho;
            set => _tamanho = value;
        }

        public string estoque
        {
            get => _estoque;
            set => _estoque = value;
        }

        public string codigoBarras
        {
            get => _codigoBarras;
            set => _codigoBarras = value;
        }

        public DateTime? dataEntrada
        {
            get => _dataEntrada;
            set => _dataEntrada = value;
        }

        public decimal? quantidade
        {
            get => _quantidade;
            set => _quantidade = value;
        }

        public int? fornecedor_cid
        {
            get => _fornecedor_cid;
            set => _fornecedor_cid = value;
        }

        public int? fabricante_cid
        {
            get => _fabricante_cid;
            set => _fabricante_cid = value;
        }

        public int? grupo_cid
        {
            get => _grupo_cid;
            set => _grupo_cid = value;
        }

        public bool ordem
        {
            get => _ordem;
            set => _ordem = value;
        }
    }

}
