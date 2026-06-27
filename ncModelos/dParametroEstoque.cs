using System;
using System.Collections.Generic;

namespace nsdParametroEstoque
{
    public class ColecaoParametroEstoque : List<dEstoque>
    {
    }

    public class dParametroEstoque
    {
        private int? _cidFornecedor;
        private int? _cidFabricante;
        private int? _cidGrupo;
        private string _descricao;
        private string _valor;

        public int? cidFornecedor
        {
            get => _cidFornecedor;
            set => _cidFornecedor = value;
        }

        public int? cidFabricante
        {
            get => _cidFabricante;
            set => _cidFabricante = value;
        }

        public int? cidGrupo
        {
            get => _cidGrupo;
            set => _cidGrupo = value;
        }

        public string descricao
        {
            get => _descricao;
            set => _descricao = value;
        }

        public string valor
        {
            get => _valor;
            set => _valor = value;
        }
    }
}
