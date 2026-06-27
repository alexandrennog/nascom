using System;
using System.Collections.Generic;

namespace nsProduto
{
    public class ColecaoProdutoTipoCaracteristica : List<dProdutoTipoCaracteristica>
    {
    }

    public class dProdutoTipoCaracteristica
    {
        private int? _cid;
        private int? _produtoTipo_cid;
        private int? _caracteristica_cid;
        private string _caracteristica_nome;
        private string _caracteristica_codigo;
        private decimal? _quantidade;

        public int? cid
        {
            get => _cid;
            set => _cid = value;
        }

        public int? produtoTipo_cid
        {
            get => _produtoTipo_cid;
            set => _produtoTipo_cid = value;
        }

        public int? caracteristica_cid
        {
            get => _caracteristica_cid;
            set => _caracteristica_cid = value;
        }

        public string caracteristica_nome
        {
            get => _caracteristica_nome;
            set => _caracteristica_nome = value;
        }

        public string caracteristica_codigo
        {
            get => _caracteristica_codigo;
            set => _caracteristica_codigo = value;
        }

        public decimal? quantidade
        {
            get => _quantidade;
            set => _quantidade = value;
        }
    }
}
