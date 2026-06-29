using System;
using System.Collections.Generic;

namespace Modelos
{
    public class ColecaoCrediario : List<dCrediario>
    {
    }

    public class dCrediario
    {
        private int _cid;
        private int _controle;
        private int _usuarioId;
        private int _clienteId;
        private int _parcelas;
        private decimal _valortotal;
        private decimal _valorpago;
        private decimal _valorvenda;
        private decimal _saldodevedor;
        private DateTime _dataVenda;
        private int _lojaId;
        private string _terminal;
        private string _notafiscal;

        public int cid
        {
            get => _cid;
            set => _cid = value;
        }

        public int controle
        {
            get => _controle;
            set => _controle = value;
        }

        public int usuarioId
        {
            get => _usuarioId;
            set => _usuarioId = value;
        }

        public int clienteId
        {
            get => _clienteId;
            set => _clienteId = value;
        }

        public int Parcelas
        {
            get => _parcelas;
            set => _parcelas = value;
        }

        public decimal ValorTotal
        {
            get => _valortotal;
            set => _valortotal = value;
        }

        public decimal ValorPago
        {
            get => _valorpago;
            set => _valorpago = value;
        }

        public decimal ValorVenda
        {
            get => _valorvenda;
            set => _valorvenda = value;
        }

        public decimal SaldoDevedor
        {
            get => _saldodevedor;
            set => _saldodevedor = value;
        }

        public DateTime DataVenda
        {
            get => _dataVenda;
            set => _dataVenda = value;
        }

        public int LojaId
        {
            get => _lojaId;
            set => _lojaId = value;
        }

        public string Terminal
        {
            get => _terminal;
            set => _terminal = value;
        }

        public string NotaFiscal
        {
            get => _notafiscal;
            set => _notafiscal = value;
        }
    }

}
