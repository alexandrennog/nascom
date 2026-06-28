using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoEfdTipoPessoa : List<dEfdTipoPessoa>
    {
    }

    public class dEfdTipoPessoa
    {
        private string _codigo;
        private string _descricao;

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
