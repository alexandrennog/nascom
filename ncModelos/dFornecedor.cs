using System;
using System.Collections.Generic;

namespace nsFornecedor
{
    public class ColecaoFornecedor : List<dFornecedor>
    {
    }

    public class dFornecedor
    {
        private int? _cid;
        private string _codigo;
        private string _nome;
        private string _logradouro;
        private int? _numero;
        private string _complemento;
        private string _bairro;
        private int? _cidade_cid;
        private string _municipioCodigoIbge;
        private int? _estado_cid;
        private int? _cep;
        private string _inscricaoEstadual;
        private string _cnpj;
        private int? _ddd;
        private string _telefone;
        private int? _ramal;
        private string _nomeContato;
        private string _situacao;

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

        public string nome
        {
            get => _nome;
            set => _nome = value;
        }

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

        public string bairro
        {
            get => _bairro;
            set => _bairro = value;
        }

        public int? cidade_cid
        {
            get => _cidade_cid;
            set => _cidade_cid = value;
        }

        public string municipioCodigoIbge
        {
            get => _municipioCodigoIbge;
            set => _municipioCodigoIbge = value;
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

        public string inscricaoEstadual
        {
            get => _inscricaoEstadual;
            set => _inscricaoEstadual = value;
        }

        public string cnpj
        {
            get => _cnpj;
            set => _cnpj = value;
        }

        public int? ddd
        {
            get => _ddd;
            set => _ddd = value;
        }

        public string telefone
        {
            get => _telefone;
            set => _telefone = value;
        }

        public int? ramal
        {
            get => _ramal;
            set => _ramal = value;
        }

        public string nomeContato
        {
            get => _nomeContato;
            set => _nomeContato = value;
        }

        public string situacao
        {
            get => _situacao;
            set => _situacao = value;
        }
    }
}
