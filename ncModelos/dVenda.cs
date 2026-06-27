using System;
using System.Collections.Generic;

namespace nsVenda
{
    public class ColecaoVenda : List<dVenda>
    {
    }

    public class dVenda
    {
        private int _controle;
        private int _usuarioId;
        private int _clienteId;
        private string _ordemServicoId;
        private DateTime _data;
        private DateTime _dataFim;
        private decimal _dinheiro;
        private decimal _pix;
        private decimal _cheque;
        private decimal _chequePre;
        private decimal _cartaoDebito;
        private decimal _cartaoCredito;
        private decimal _crediario;
        private decimal _crediarioPagamento;
        private int _parcelas;
        private decimal _desconto;
        private int _condicao;
        private decimal _recebido;
        private decimal _troco;
        private decimal _total;
        private decimal _troca;
        private decimal _vale;
        private decimal _defeito;
        private decimal _retirada;
        private string _terminal;
        private decimal _valeEmitido;
        private string _vendedor;
        private string _caixa;
        private string _txID;
        private decimal? _valorProduto;
        private decimal? _valorCusto;
        private decimal _original;
        private string _chave;

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

        public string ordemServicoId
        {
            get => _ordemServicoId;
            set => _ordemServicoId = value;
        }

        public DateTime Data
        {
            get => _data;
            set => _data = value;
        }

        public DateTime DataFim
        {
            get => _dataFim;
            set => _dataFim = value;
        }

        public decimal Dinheiro
        {
            get => _dinheiro;
            set => _dinheiro = value;
        }

        public decimal Pix
        {
            get => _pix;
            set => _pix = value;
        }

        public decimal Cheque
        {
            get => _cheque;
            set => _cheque = value;
        }

        public decimal ChequePre
        {
            get => _chequePre;
            set => _chequePre = value;
        }

        public decimal CartaoDebito
        {
            get => _cartaoDebito;
            set => _cartaoDebito = value;
        }

        public decimal CartaoCredito
        {
            get => _cartaoCredito;
            set => _cartaoCredito = value;
        }

        public decimal Crediario
        {
            get => _crediario;
            set => _crediario = value;
        }

        public decimal CrediarioPagamento
        {
            get => _crediarioPagamento;
            set => _crediarioPagamento = value;
        }

        public int Parcelas
        {
            get => _parcelas;
            set => _parcelas = value;
        }

        public decimal Desconto
        {
            get => _desconto;
            set => _desconto = value;
        }

        public int Condicao
        {
            get => _condicao;
            set => _condicao = value;
        }

        public decimal Recebido
        {
            get => _recebido;
            set => _recebido = value;
        }

        public decimal Troco
        {
            get => _troco;
            set => _troco = value;
        }

        public decimal Total
        {
            get => _total;
            set => _total = value;
        }

        public decimal Troca
        {
            get => _troca;
            set => _troca = value;
        }

        public decimal Vale
        {
            get => _vale;
            set => _vale = value;
        }

        public decimal ValeEmitido
        {
            get => _valeEmitido;
            set => _valeEmitido = value;
        }

        public decimal Defeito
        {
            get => _defeito;
            set => _defeito = value;
        }

        public decimal Retirada
        {
            get => _retirada;
            set => _retirada = value;
        }

        public string Terminal
        {
            get => _terminal;
            set => _terminal = value;
        }

        public string Vendedor
        {
            get => _vendedor;
            set => _vendedor = value;
        }

        public string Caixa
        {
            get => _caixa;
            set => _caixa = value;
        }

        public string TXID
        {
            get => _txID;
            set => _txID = value;
        }

        public decimal? valorProduto
        {
            get => _valorProduto;
            set => _valorProduto = value;
        }

        public decimal? valorCusto
        {
            get => _valorCusto;
            set => _valorCusto = value;
        }

        public decimal valorOriginal
        {
            get => _original;
            set => _original = value;
        }

        public string Chave
        {
            get => _chave;
            set => _chave = value;
        }
    }
}
