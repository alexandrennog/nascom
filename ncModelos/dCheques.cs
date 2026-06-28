using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoCheques : List<dCheques>
    {
    }

    public class dCheques
    {
        private int _cid;
        private DateTime _dataEmissao;
        private DateTime _dataDeposito;
        private decimal _valor;
        private string _numero;
        private int _vendaId;
        private int _clienteId;
        private string _baixado;
        private string _bancoCodigo;
        private string _bancoNome;
        private string _agencia;
        private string _conta;

        public int cid
        {
            get => _cid;
            set => _cid = value;
        }

        public DateTime dataEmissao
        {
            get => _dataEmissao;
            set => _dataEmissao = value;
        }

        public DateTime dataDeposito
        {
            get => _dataDeposito;
            set => _dataDeposito = value;
        }

        public decimal valor
        {
            get => _valor;
            set => _valor = value;
        }

        public string Numero
        {
            get => _numero;
            set => _numero = value;
        }

        public int vendasId
        {
            get => _vendaId;
            set => _vendaId = value;
        }

        public int clienteId
        {
            get => _clienteId;
            set => _clienteId = value;
        }

        public string baixado
        {
            get => _baixado;
            set => _baixado = value;
        }

        public string bancoCodigo
        {
            get => _bancoCodigo;
            set => _bancoCodigo = value;
        }

        public string bancoNome
        {
            get => _bancoNome;
            set => _bancoNome = value;
        }

        public string agencia
        {
            get => _agencia;
            set => _agencia = value;
        }

        public string conta
        {
            get => _conta;
            set => _conta = value;
        }
    }

}
