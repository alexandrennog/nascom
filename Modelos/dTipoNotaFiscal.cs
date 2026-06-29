using System;
using System.Collections.Generic;

namespace Modelos
{
    public class ColecaoTipoNotaFiscal : List<dTipoNotaFiscal>
    {
    }

    public class dTipoNotaFiscal
    {
        private int _cid;
        private string _codigo;
        private string _descricao;
        private string _modelo;
        private string _modeloDescricao;

        public int cid
        {
            get => _cid;
            set => _cid = value;
        }

        public string codigo
        {
            get => _codigo;
            set => _codigo = value;
        }

        public string descricao
        {
            get => _descricao;
            set => _descricao = value;
        }

        public string modelo
        {
            get => _modelo;
            set => _modelo = value;
        }

        public string modeloDescricao
        {
            get => _modeloDescricao;
            set => _modeloDescricao = value;
        }
    }

}
