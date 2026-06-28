using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoContasPagar : List<dContasPagar>
    {
    }

    public class dContasPagar
    {
        private int? _cid;
        private string _codigo;
        private string _codigoBarra;
        private decimal? _valor;
        private bool? _aceite;
        private string _observacao;
        private string _dataEmissao;
        private string _dataVencimento;
        private string _dataPagamento;
        private decimal? _valorPagamento;
        private int? _fornecedor_cid;
        private bool? _pago;

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

        public string codigoBarra
        {
            get => _codigoBarra;
            set => _codigoBarra = value;
        }

        public decimal? valor
        {
            get => _valor;
            set => _valor = value;
        }

        public bool? aceite
        {
            get => _aceite;
            set => _aceite = value;
        }

        public string observacao
        {
            get => _observacao;
            set => _observacao = value;
        }

        public string dataEmissao
        {
            get => _dataEmissao;
            set => _dataEmissao = value;
        }

        public string dataVencimento
        {
            get => _dataVencimento;
            set => _dataVencimento = value;
        }

        public string dataPagamento
        {
            get => _dataPagamento;
            set => _dataPagamento = value;
        }

        public decimal? valorPagamento
        {
            get => _valorPagamento;
            set => _valorPagamento = value;
        }

        public int? fornecedor_cid
        {
            get => _fornecedor_cid;
            set => _fornecedor_cid = value;
        }

        public bool? pago
        {
            get => _pago;
            set => _pago = value;
        }
    }

}
