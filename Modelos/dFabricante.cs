using System;
using System.Collections.Generic;

namespace Modelos
{
    public class ColecaoFabricante : List<dFabricante>
    {
    }

    public class dFabricante
    {
        private int? _cid;
        private string _nome;
        private string _situacao;

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
    }

}
