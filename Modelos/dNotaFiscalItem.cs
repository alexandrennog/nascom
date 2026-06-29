using System;
using System.Collections.Generic;

namespace Modelos
{
    public class ColecaoNotaFiscalItem : List<dNotaFiscalItem>
    {
    }

    public class dNotaFiscalItem
    {
        private int? _produtos_cid;
        private string _produtos_descricao;
        private string _produtos_estoque;
        private decimal _produtos_valor;
        private string _produtos_referencia;
        private int? _item;
        private int? _caracteristicas_cid;
        private string _caracteristicas_nome;
        private string _caracteristicas_codigo;

        public int? produtos_cid
        {
            get => _produtos_cid;
            set => _produtos_cid = value;
        }

        public string produtos_descricao
        {
            get => _produtos_descricao;
            set => _produtos_descricao = value;
        }

        public string produtos_estoque
        {
            get => _produtos_estoque;
            set => _produtos_estoque = value;
        }

        public int? item
        {
            get => _item;
            set => _item = value;
        }

        public int? caracteristicas_cid
        {
            get => _caracteristicas_cid;
            set => _caracteristicas_cid = value;
        }

        public string caracteristicas_nome
        {
            get => _caracteristicas_nome;
            set => _caracteristicas_nome = value;
        }

        public string caracteristicas_codigo
        {
            get => _caracteristicas_codigo;
            set => _caracteristicas_codigo = value;
        }

        public decimal Produtos_Valor
        {
            get => _produtos_valor;
            set => _produtos_valor = value;
        }

        public string Produtos_Referencia
        {
            get => _produtos_referencia;
            set => _produtos_referencia = value;
        }
    }

}
