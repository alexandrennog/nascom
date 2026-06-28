using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoProduto : List<dProduto>
    {
    }

    public class dProduto
    {
        private int? _cid;
        private string _codigo;
        private string _descricao;
        private string _situacao;
        private string _dataInclusao;
        private decimal? _valorCompra;
        private decimal? _valorVenda;
        private int? _produtoTipo_cid;
        private int? _fornecedor_cid;
        private int? _fabricante_cid;
        private string _imagem;
        private string _referencia;
        private string _codigoBarras;
        private int? _estoqueMinimo;
        private int? _cor_cid;
        private string _cor;
        private int? _grupo_cid;
        private string _grupo;
        private string _notaFiscalNumero;
        private string _notaFiscalSerie;
        private string _aliquota;
        private string _dataInicio;
        private string _dataFim;
        private string _efdUnidadeMedidaCodigo;
        private string _efdCodigoCategoria;
        private string _efdCategoria;
        private bool? _efdIntegracao;

        public int? cid
        {
            get => _cid;
            set => _cid = value;
        }

        public string codigo
        {
            get => _codigo;
            set => _codigo = value;
        }

        public string descricao
        {
            get => _descricao;
            set => _descricao = value;
        }

        public string situacao
        {
            get => _situacao;
            set => _situacao = value;
        }

        public string dataInclusao
        {
            get => _dataInclusao;
            set => _dataInclusao = value;
        }

        public decimal? valorCompra
        {
            get => _valorCompra;
            set => _valorCompra = value;
        }

        public decimal? valorVenda
        {
            get => _valorVenda;
            set => _valorVenda = value;
        }

        public int? produtoTipo_cid
        {
            get => _produtoTipo_cid;
            set => _produtoTipo_cid = value;
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

        public string imagem
        {
            get => _imagem;
            set => _imagem = value;
        }

        public string referencia
        {
            get => _referencia;
            set => _referencia = value;
        }

        public string codigoBarras
        {
            get => _codigoBarras;
            set => _codigoBarras = value;
        }

        public int? cor_cid
        {
            get => _cor_cid;
            set => _cor_cid = value;
        }

        public string cor
        {
            get => _cor;
            set => _cor = value;
        }

        public int? grupo_cid
        {
            get => _grupo_cid;
            set => _grupo_cid = value;
        }

        public string grupo
        {
            get => _grupo;
            set => _grupo = value;
        }

        public int? estoqueMinimo
        {
            get => _estoqueMinimo;
            set => _estoqueMinimo = value;
        }

        public string aliquota
        {
            get => _aliquota;
            set => _aliquota = value;
        }

        public string notaFiscalNumero
        {
            get => _notaFiscalNumero;
            set => _notaFiscalNumero = value;
        }

        public string notaFiscalSerie
        {
            get => _notaFiscalSerie;
            set => _notaFiscalSerie = value;
        }

        public string dataInicio
        {
            get => _dataInicio;
            set => _dataInicio = value;
        }

        public string dataFinal
        {
            get => _dataFim;
            set => _dataFim = value;
        }

        public string efdUnidadeMedidaCodigo
        {
            get => _efdUnidadeMedidaCodigo;
            set => _efdUnidadeMedidaCodigo = value;
        }

        public string efdCodigoCategoria
        {
            get => _efdCodigoCategoria;
            set => _efdCodigoCategoria = value;
        }

        public string efdCategoria
        {
            get => _efdCategoria;
            set => _efdCategoria = value;
        }

        public bool? efdIntegracao
        {
            get => _efdIntegracao;
            set => _efdIntegracao = value;
        }
    }

}
