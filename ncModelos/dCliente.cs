using System;
using System.Collections.Generic;

namespace nsCliente
{
    public class ColecaoCliente : List<dCliente>
    {
    }

    public class dCliente
    {
        private int? _cid;
        private string _codigo;
        private string _nome;
        private string _endereco;
        private string _estadoCivil;
        private string _sexo;
        private string _nomePai;
        private string _nomeMae;
        private string _situacao;
        private string _rg;
        private string _rgOrgaoEmissor;
        private int? _rgUf_cid;
        private string _cpf;
        private string _carteiraProfissional;
        private string _dataNascimento;
        private string _naturalidade;
        private string _nacionalidade;
        private string _dataInclusao;
        private string _email;
        private string _foto;
        private string _ddd;
        private string _telefone;
        private string _dddcel;
        private string _celular;
        private string _veiculo;

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

        public string endereco
        {
            get => _endereco;
            set => _endereco = value;
        }

        public string dataNascimento
        {
            get => _dataNascimento;
            set => _dataNascimento = value;
        }

        public string naturalidade
        {
            get => _naturalidade;
            set => _naturalidade = value;
        }

        public string nacionalidade
        {
            get => _nacionalidade;
            set => _nacionalidade = value;
        }

        public string estadoCivil
        {
            get => _estadoCivil;
            set => _estadoCivil = value;
        }

        public string sexo
        {
            get => _sexo;
            set => _sexo = value;
        }

        public string nomePai
        {
            get => _nomePai;
            set => _nomePai = value;
        }

        public string nomeMae
        {
            get => _nomeMae;
            set => _nomeMae = value;
        }

        public string situacao
        {
            get => _situacao;
            set => _situacao = value;
        }

        public string dataInclusao
        {
            get => _dataInclusao;
            set => _dataInclusao = value;
        }

        public string rg
        {
            get => _rg;
            set => _rg = value;
        }

        public string rgOrgaoEmissor
        {
            get => _rgOrgaoEmissor;
            set => _rgOrgaoEmissor = value;
        }

        public int? rgUf_cid
        {
            get => _rgUf_cid;
            set => _rgUf_cid = value;
        }

        public string cpf
        {
            get => _cpf;
            set => _cpf = value;
        }

        public string carteiraProfissional
        {
            get => _carteiraProfissional;
            set => _carteiraProfissional = value;
        }

        public string email
        {
            get => _email;
            set => _email = value;
        }

        public string foto
        {
            get => _foto;
            set => _foto = value;
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

        public string dddcel
        {
            get => _dddcel;
            set => _dddcel = value;
        }

        public string celular
        {
            get => _celular;
            set => _celular = value;
        }

        public string veiculo
        {
            get => _veiculo;
            set => _veiculo = value;
        }
    }
}
