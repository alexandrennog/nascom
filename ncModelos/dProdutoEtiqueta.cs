using System;
using System.Collections.Generic;

namespace nsProdutoEtiqueta
{
    public class ColecaoProdutoEtiqueta : List<dProdutoEtiqueta>
    {
    }

    public class dProdutoEtiqueta
    {
        private DateTime? _data;
        private int? _usuario_cid;
        private string _usuario_nomeCompleto;
        private int? _produto_cid;
        private string _produtoItem_codigoBarras;
        private decimal? _quantidade;
        private string _impressao;
        private string _referencia;
        private string _cor;

        public DateTime? data
        {
            get => _data;
            set => _data = value;
        }

        public int? usuario_cid
        {
            get => _usuario_cid;
            set => _usuario_cid = value;
        }

        public string usuario_nomeCompleto
        {
            get => _usuario_nomeCompleto;
            set => _usuario_nomeCompleto = value;
        }

        public int? produto_cid
        {
            get => _produto_cid;
            set => _produto_cid = value;
        }

        public string produtoItem_codigoBarras
        {
            get => _produtoItem_codigoBarras;
            set => _produtoItem_codigoBarras = value;
        }

        public decimal? quantidade
        {
            get => _quantidade;
            set => _quantidade = value;
        }

        public string impressao
        {
            get => _impressao;
            set => _impressao = value;
        }

        public string referencia
        {
            get => _referencia;
            set => _referencia = value;
        }

        public string cor
        {
            get => _cor;
            set => _cor = value;
        }
    }
}
