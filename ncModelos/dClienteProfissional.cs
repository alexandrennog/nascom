using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoClienteProfissional : List<dClienteProfissional>
    {
    }

    public class dClienteProfissional
    {
        private string _empresa;
        private string _logradouro;
        private int? _numero;
        private string _complemento;
        private string _bairro;
        private string _cidade;
        private int? _estado_cid;
        private int? _cep;
        private string _ddd;
        private string _telefone;
        private string _ramal;
        private string _dataAdmissao;
        private string _cargo;
        private decimal? _salario;
        private int? _cliente_cid;

        public string empresa
        {
            get => _empresa;
            set => _empresa = value;
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

        public string bairro
        {
            get => _bairro;
            set => _bairro = value;
        }

        public int? cliente_cid
        {
            get => _cliente_cid;
            set => _cliente_cid = value;
        }

        public string ddd
        {
            get => _ddd;
            set => _ddd = value;
        }

        public string telefone
        {
            get => _telefone;
            set => _telefone = value;
        }

        public string ramal
        {
            get => _ramal;
            set => _ramal = value;
        }

        public string dataAdmissao
        {
            get => _dataAdmissao;
            set => _dataAdmissao = value;
        }

        public string cargo
        {
            get => _cargo;
            set => _cargo = value;
        }

        public decimal? salario
        {
            get => _salario;
            set => _salario = value;
        }
    }

}
