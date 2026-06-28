using System;

namespace ncModelos
{
    public class dEfdEnderecoContato
    {
        private string _logradouro;
        private string _numero;
        private string _complemento;
        private string _bairro;
        private string _cep;
        private string _dddTelefone;
        private string _dddFax;
        private string _email;

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
    }

}
