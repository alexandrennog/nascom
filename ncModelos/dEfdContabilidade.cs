using System;

namespace ncModelos
{
    public class dEfdContabilidade
    {
        private string _nomeContador;
        private string _cpf;
        private string _crc;
        private string _cnpjEscritorio;
        private string _logradouro;
        private string _numero;
        private string _complemento;
        private string _bairro;
        private int? _estados_cid;
        private string _municipio;
        private string _municipioCodigoIbge;
        private string _cep;
        private string _dddTelefone;
        private string _dddFax;
        private string _email;
        private string _contaAnaliticaContabil;

        public string nomeContador
        {
            get => _nomeContador;
            set => _nomeContador = value;
        }

        public string cpf
        {
            get => _cpf;
            set => _cpf = value;
        }

        public string crc
        {
            get => _crc;
            set => _crc = value;
        }

        public string cnpjEscritorio
        {
            get => _cnpjEscritorio;
            set => _cnpjEscritorio = value;
        }

        public string logradouro
        {
            get => _logradouro;
            set => _logradouro = value;
        }

        public string numero
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

        public int? estados_cid
        {
            get => _estados_cid;
            set => _estados_cid = value;
        }

        public string municipio
        {
            get => _municipio;
            set => _municipio = value;
        }

        public string municipioCodigoIbge
        {
            get => _municipioCodigoIbge;
            set => _municipioCodigoIbge = value;
        }

        public string cep
        {
            get => _cep;
            set => _cep = value;
        }

        public string dddTelefone
        {
            get => _dddTelefone;
            set => _dddTelefone = value;
        }

        public string dddFax
        {
            get => _dddFax;
            set => _dddFax = value;
        }

        public string email
        {
            get => _email;
            set => _email = value;
        }

        public string contaAnaliticaContabil
        {
            get => _contaAnaliticaContabil;
            set => _contaAnaliticaContabil = value;
        }
    }

}
