using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoMunicipios : List<dMunicipios>
    {
    }

    public class dMunicipios
    {
        private int? _cid;
        private string _codigo_ibge;
        private string _nome;
        private int _estados_cid;
        private string _situacao;

        public int? cid
        {
            get => _cid;
            set => _cid = value;
        }

        public string codigo_ibge
        {
            get => _codigo_ibge;
            set => _codigo_ibge = value;
        }

        public string nome
        {
            get => _nome;
            set => _nome = value;
        }

        public int estados_cid
        {
            get => _estados_cid;
            set => _estados_cid = value;
        }

        public string situacao
        {
            get => _situacao;
            set => _situacao = value;
        }
    }

}
