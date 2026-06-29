using System;
using System.Collections.Generic;

namespace Modelos
{
    public class ColecaoEtiquetaProdutoImpressao : List<dEtiquetaProdutoImpressao>
    {
    }

    public class dEtiquetaProdutoImpressao
    {
        private string _loja;
        private string _fabricante;
        private dProduto _produto;
        private ColecaoProdutoItem _colecaoProdutoItem;
        private string _corNome;
        private string _data;
        private string _produto_cid;
        private string _codigoBarras;

        public string loja
        {
            get => _loja;
            set => _loja = value;
        }

        public string fabricante
        {
            get => _fabricante;
            set => _fabricante = value;
        }

        public dProduto produto
        {
            get => _produto;
            set => _produto = value;
        }

        public ColecaoProdutoItem colecaoProdutoItem
        {
            get => _colecaoProdutoItem;
            set => _colecaoProdutoItem = value;
        }

        public string corNome
        {
            get => _corNome;
            set => _corNome = value;
        }

        public string data
        {
            get => _data;
            set => _data = value;
        }

        public string produto_cid
        {
            get => _produto_cid;
            set => _produto_cid = value;
        }

        public string codigoBarras
        {
            get => _codigoBarras;
            set => _codigoBarras = value;
        }
    }
                    
}