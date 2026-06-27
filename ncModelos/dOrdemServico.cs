using System;
using System.Collections.Generic;

namespace nsOrdemServico
{
    public class ColecaoOrdemServico : List<dOrdemServico>
    {
    }

    public class dOrdemServico
    {
        private int? _cid;
        private int? _clienteid;
        private int? _veiculoid;
        private string _observacoes;
        private string _emissao;
        private string _vendedor;
        private string _loja;
        private string _situacao;

        public int? cid
        {
            get => _cid;
            set => _cid = value;
        }

        public int? clienteid
        {
            get => _clienteid;
            set => _clienteid = value;
        }

        public int? veiculoid
        {
            get => _veiculoid;
            set => _veiculoid = value;
        }

        public string observacoes
        {
            get => _observacoes;
            set => _observacoes = value;
        }

        public string emissao
        {
            get => _emissao;
            set => _emissao = value;
        }

        public string vendedor
        {
            get => _vendedor;
            set => _vendedor = value;
        }

        public string loja
        {
            get => _loja;
            set => _loja = value;
        }

        public string situacao
        {
            get => _situacao;
            set => _situacao = value;
        }
    }
}
