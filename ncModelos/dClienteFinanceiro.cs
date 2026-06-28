using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoClienteFinanceiro : List<dClienteFinanceiro>
    {
    }

    public class dClienteFinanceiro
    {
        private decimal? _limite;
        private string _situacaoCrediario;
        private int? _cliente_cid;
        private string _banco1;
        private string _banco2;
        private string _agencia1;
        private string _agencia2;
        private string _conta1;
        private string _conta2;
        private string _gerente1;
        private string _gerente2;
        private string _referencia1;
        private string _referencia2;
        private string _ddd1;
        private string _ddd2;
        private string _telefone1;
        private string _telefone2;
        private string _observacoes;
        private string _dataNegativa;
        private string _motivo;

        public decimal? limite
        {
            get => _limite;
            set => _limite = value;
        }

        public string situacaoCrediario
        {
            get => _situacaoCrediario;
            set => _situacaoCrediario = value;
        }

        public int? cliente_cid
        {
            get => _cliente_cid;
            set => _cliente_cid = value;
        }

        public string banco1
        {
            get => _banco1;
            set => _banco1 = value;
        }

        public string banco2
        {
            get => _banco2;
            set => _banco2 = value;
        }

        public string agencia1
        {
            get => _agencia1;
            set => _agencia1 = value;
        }

        public string agencia2
        {
            get => _agencia2;
            set => _agencia2 = value;
        }

        public string conta1
        {
            get => _conta1;
            set => _conta1 = value;
        }

        public string conta2
        {
            get => _conta2;
            set => _conta2 = value;
        }

        public string gerente1
        {
            get => _gerente1;
            set => _gerente1 = value;
        }

        public string gerente2
        {
            get => _gerente2;
            set => _gerente2 = value;
        }

        public string referencia1
        {
            get => _referencia1;
            set => _referencia1 = value;
        }

        public string referencia2
        {
            get => _referencia2;
            set => _referencia2 = value;
        }

        public string ddd1
        {
            get => _ddd1;
            set => _ddd1 = value;
        }

        public string ddd2
        {
            get => _ddd2;
            set => _ddd2 = value;
        }

        public string telefone1
        {
            get => _telefone1;
            set => _telefone1 = value;
        }

        public string telefone2
        {
            get => _telefone2;
            set => _telefone2 = value;
        }

        public string observacoes
        {
            get => _observacoes;
            set => _observacoes = value;
        }

        public string dataNegativacao
        {
            get => _dataNegativa;
            set => _dataNegativa = value;
        }

        public string motivo
        {
            get => _motivo;
            set => _motivo = value;
        }
    }

}
