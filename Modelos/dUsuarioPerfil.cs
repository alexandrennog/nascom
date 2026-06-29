using System;
using System.Collections.Generic;

namespace Modelos
{
    public class ColecaoUsuarioPerfil : List<dUsuarioPerfil>
    {
    }

    public class dUsuarioPerfil
    {
        private int? _cid;
        private string _codigo;
        private string _nome;
        private string _situacao;

        public int? cid
        {
            get => _cid;
            set => _cid = value;
        }

        public string nome
        {
            get => _nome;
            set => _nome = value;
        }

        public string codigo
        {
            get => _codigo;
            set => _codigo = value;
        }

        public string situacao
        {
            get => _situacao;
            set => _situacao = value;
        }
    }

}
