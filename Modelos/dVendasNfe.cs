using System;
using System.Collections.Generic;

namespace Modelos
{
    public class ColecaodVendasNfe : List<dVendasNfe>
    {
    }

    public class dVendasNfe
    {
        private string _cupom;
        private string _dataVenda;
        private string _valor;

        public string Cupom
        {
            get => _cupom;
            set => _cupom = value;
        }

        public string DataVenda
        {
            get => _dataVenda;
            set => _dataVenda = value;
        }

        public string Valor
        {
            get => _valor;
            set => _valor = value;
        }
    }

}
