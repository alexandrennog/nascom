using System;
using System.Collections.Generic;

namespace nsLoja
{
    public class ColecaoLoja : List<dLoja>
    {
    }

    public class dLoja
    {
        private int? _cid;
        private string _codigo;
        private string _nomeFantasia;
        private string _logradouro;
        private int? _numero;
        private string _complemento;
        private string _bairro;
        private string _cidade;
        private int? _estado_cid;
        private int? _cep;
        private string _cnpj;
        private int? _ddd;
        private int? _telefone;
        private int? _ramal;
        private string _nomeContato;
        private string _razaoSocial;
        private string _situacao;
        private string _spc_codigo_associado;
        private string _spc_nome_informante;
        private string _spc_controle_informante;
        private string _inscestadual;

        public int? cid
        {
            get => _cid;
            set => _cid = value;
        }

        public string nomeFantasia
        {
            get => _nomeFantasia;
            set => _nomeFantasia = value;
        }

        public string codigo
        {
            get => _codigo;
            set => _codigo = value;
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

        public int? telefone
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

        public string razaoSocial
        {
            get => _razaoSocial;
            set => _razaoSocial = value;
        }

        public string situacao
        {
            get => _situacao;
            set => _situacao = value;
        }

        public string spc_codigo_associado
        {
            get => _spc_codigo_associado;
            set => _spc_codigo_associado = value;
        }

        public string spc_nome_informante
        {
            get => _spc_nome_informante;
            set => _spc_nome_informante = value;
        }

        public string spc_controle_informante
        {
            get => _spc_controle_informante;
            set => _spc_controle_informante = value;
        }

        public string Inscestadual
        {
            get => _inscestadual;
            set => _inscestadual = value;
        }
    }
}
