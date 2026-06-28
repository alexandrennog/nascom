using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoEfdItem : List<dEfdItem>
    {
    }

    public class dEfdItem
    {
        private string _produtoCodigo;
        private string _produtoItem;
        private string _codigoEfd;
        private string _descricao;
        private string _codigoBarras;
        private string _aliquotaIcms;
        private string _quantidade;
        private string _unidadeMedidaCodigo;
        private string _valorUnitario;

        public string codigo
        {
            get => _produtoCodigo;
            set => _produtoCodigo = value;
        }

        public string item
        {
            get => _produtoItem;
            set => _produtoItem = value;
        }

        public string codigoEfd
        {
            get => _codigoEfd;
            set => _codigoEfd = value;
        }

        public string descricao
        {
            get => _descricao;
            set => _descricao = value;
        }

        public string codigoBarras
        {
            get => _codigoBarras;
            set => _codigoBarras = value;
        }

        public string aliquotaIcms
        {
            get => _aliquotaIcms;
            set => _aliquotaIcms = value;
        }

        public string quantidade
        {
            get => _quantidade;
            set => _quantidade = value;
        }

        public string unidadeMedidaCodigo
        {
            get => _unidadeMedidaCodigo;
            set => _unidadeMedidaCodigo = value;
        }

        public string valorUnitario
        {
            get => _valorUnitario;
            set => _valorUnitario = value;
        }
    }

}
