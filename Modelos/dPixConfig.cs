using System;

namespace Modelos
{
    public class dPixConfig
    {
        private string _banco;
        private int _cliente;
        private string _cpf;
        private string _cnpj;
        private string _nome;
        private string _chave;
        private string _appKey;
        private string _ClientID;
        private string _ClientSecret;
        private string _certPath;
        private string _certPass;
        private string _email;

        public string Banco
        {
            get => _banco;
            set => _banco = value;
        }

        public int Cliente
        {
            get => _cliente;
            set => _cliente = value;
        }

        public string Cpf
        {
            get => _cpf;
            set => _cpf = value;
        }

        public string Cnpj
        {
            get => _cnpj;
            set => _cnpj = value;
        }

        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }

        public string AppKey
        {
            get => _appKey;
            set => _appKey = value;
        }

        public string Chave
        {
            get => _chave;
            set => _chave = value;
        }

        public string ClientID
        {
            get => _ClientID;
            set => _ClientID = value;
        }

        public string ClientSecret
        {
            get => _ClientSecret;
            set => _ClientSecret = value;
        }

        public string CertPath
        {
            get => _certPath;
            set => _certPath = value;
        }

        public string CertPass
        {
            get => _certPass;
            set => _certPass = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }
    }

}
