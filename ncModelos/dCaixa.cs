using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoCaixa : List<dCaixa>
    {
    }

    public class dCaixa
    {
        private int? _cid;
        private string _nome;
        private string _situacao;
        private DateTime _data;
        private string _usuario;

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

        public DateTime Data
        {
            get => _data;
            set => _data = value;
        }

        public string usuario
        {
            get => _usuario;
            set => _usuario = value;
        }
    }

}
