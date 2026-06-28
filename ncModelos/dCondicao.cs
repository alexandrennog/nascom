using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoCondicao : List<dCondicao>
    {
    }

    public class dCondicao
    {
        private int? _cid;
        private string _nome;
        private string _situacao;
        private decimal _desconto;

        public int? cid
        {
            get => _cid;
            set => _cid = value;
        }

        public string nome
        {
            get => _nome;
            set => _nome = value;
        }

        public string situacao
        {
            get => _situacao;
            set => _situacao = value;
        }

        public decimal desconto
        {
            get => _desconto;
            set => _desconto = value;
        }
    }

}
