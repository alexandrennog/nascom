using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoGradeEntrada : List<dGradeEntrada>
    {
    }

    public class dGradeEntrada
    {
        private int? _produto_cid;
        private int? _item;
        private string _codigoBarras;
        private string _tamanho;
        private string _entrada_data;
        private int? _entrada_qtde;

        public int? produto_cid
        {
            get => _produto_cid;
            set => _produto_cid = value;
        }

        public int? item
        {
            get => _item;
            set => _item = value;
        }

        public string codigoBarras
        {
            get => _codigoBarras;
            set => _codigoBarras = value;
        }

        public string tamanho
        {
            get => _tamanho;
            set => _tamanho = value;
        }

        public string entrada_data
        {
            get => _entrada_data;
            set => _entrada_data = value;
        }

        public int? entrada_qtde
        {
            get => _entrada_qtde;
            set => _entrada_qtde = value;
        }
    }

}
