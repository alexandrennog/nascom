using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoVeiculos : List<dVeiculos>
    {
    }

    public class dVeiculos
    {
        private int? _cid;
        private int _clienteId;
        private string _placa;
        private string _marca;
        private string _modelo;
        private string _cor;
        private string _ano;
        private string _combustivel;

        public int? cid
        {
            get => _cid;
            set => _cid = value;
        }

        public int clienteId
        {
            get => _clienteId;
            set => _clienteId = value;
        }

        public string Placa
        {
            get => _placa;
            set => _placa = value;
        }

        public string Marca
        {
            get => _marca;
            set => _marca = value;
        }

        public string Modelo
        {
            get => _modelo;
            set => _modelo = value;
        }

        public string Cor
        {
            get => _cor;
            set => _cor = value;
        }

        public string Ano
        {
            get => _ano;
            set => _ano = value;
        }

        public string Combustivel
        {
            get => _combustivel;
            set => _combustivel = value;
        }
    }

}
