using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoTipoEmissao : List<dTipoEmissao>
    {
    }

    public class dTipoEmissao
    {
        private int _cid;
        private string _codigo;
        private string _descricao;

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
    }

}
