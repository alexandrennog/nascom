using System;
using System.Collections.Generic;

namespace Modelos
{
    public class ColecaoParcelas : List<dParcelas>
    {
    }

    public class dParcelas
    {
        private int _cid;
        private int _crediarioId;
        private DateTime _dataEmissao;
        private DateTime _dataVencimento;
        private decimal _valor;
        private decimal _valorpago;
        private decimal _valorreceber;
        private string _situacao;
        private string _codigoBarras;
        private DateTime? _dataPagamento;
        private string _observacao;
        private int _diasAtraso;

        public int cid
        {
            get => _cid;
            set => _cid = value;
        }

        public int crediarioId
        {
            get => _crediarioId;
            set => _crediarioId = value;
        }

        public DateTime dataEmissao
        {
            get => _dataEmissao;
            set => _dataEmissao = value;
        }

        public DateTime dataVecimento
        {
            get => _dataVencimento;
            set => _dataVencimento = value;
        }

        public decimal valor
        {
            get => _valor;
            set => _valor = value;
        }

        public decimal valorPago
        {
            get => _valorpago;
            set => _valorpago = value;
        }

        public decimal valorReceber
        {
            get => _valorreceber;
            set => _valorreceber = value;
        }

        public string situacao
        {
            get => _situacao;
            set => _situacao = value;
        }

        public string codigoBarras
        {
            get => _codigoBarras;
            set => _codigoBarras = value;
        }

        public DateTime? dataPagamento
        {
            get => _dataPagamento;
            set => _dataPagamento = value;
        }

        public string observacao
        {
            get => _observacao;
            set => _observacao = value;
        }

        public int diasAtraso
        {
            get => _diasAtraso;
            set => _diasAtraso = value;
        }
    }

}
