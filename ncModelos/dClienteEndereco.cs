using System;
using System.Collections.Generic;

namespace nsCliente
{
    public class ColecaoClienteEndereco : List<dClienteEndereco>
    {
    }

    public class dClienteEndereco
    {
        private string _logradouro;
        private int? _numero;
        private string _complemento;
        private string _cidade;
        private int? _estado_cid;
        private int? _cep;
        private string _dataInclusao;
        private string _tipoResidencia;
        private string _bairro;
        private string _tipoEndereco;
        private int? _cliente_cid;
        private decimal? _valor;
        private string _tempo;
        private string _siglaEstado;

        public string logradouro
        {
            get => _logradouro;
            set => _logradouro = value;
        }

        public int? numero
        {
            get => _numero;
            set => _numero = value;
        }

        public string complemento
        {
            get => _complemento;
            set => _complemento = value;
        }

        public string cidade
        {
            get => _cidade;
            set => _cidade = value;
        }

        public int? estado_cid
        {
            get => _estado_cid;
            set => _estado_cid = value;
        }

        public int? cep
        {
            get => _cep;
            set => _cep = value;
        }

        public string dataInclusao
        {
            get => _dataInclusao;
            set => _dataInclusao = value;
        }

        public string tipoResidencia
        {
            get => _tipoResidencia;
            set => _tipoResidencia = value;
        }

        public string bairro
        {
            get => _bairro;
            set => _bairro = value;
        }

        public string tipoEndereco
        {
            get => _tipoEndereco;
            set => _tipoEndereco = value;
        }

        public int? cliente_cid
        {
            get => _cliente_cid;
            set => _cliente_cid = value;
        }

        public decimal? valor
        {
            get => _valor;
            set => _valor = value;
        }

        public string tempo
        {
            get => _tempo;
            set => _tempo = value;
        }

        public string siglaEstado
        {
            get => _siglaEstado;
            set => _siglaEstado = value;
        }
    }
}
