using System;
using System.Collections.Generic;

namespace Modelos
{
    public class ColecaoGiro : List<dGiro>
    {
    }

    public class dGiro
    {
        private int? _produto_cid;
        private string _codigoBarras;
        private string _dataInicio;
        private string _dataFim;
        private int? _dias;
        private decimal? _quantidade;
        private string _dataAtual;
        private int? _usuario_cid;
        private string _usuario_nomeCompleto;
        private string _situacao;

        public int? produto_cid
        {
            get => _produto_cid;
            set => _produto_cid = value;
        }

        public string codigoBarras
        {
            get => _codigoBarras;
            set => _codigoBarras = value;
        }

        public string dataInicio
        {
            get => _dataInicio;
            set => _dataInicio = value;
        }

        public string dataFim
        {
            get => _dataFim;
            set => _dataFim = value;
        }

        public int? dias
        {
            get => _dias;
            set => _dias = value;
        }

        public decimal? quantidade
        {
            get => _quantidade;
            set => _quantidade = value;
        }

        public string dataAtual
        {
            get => _dataAtual;
            set => _dataAtual = value;
        }

        public int? usuario_cid
        {
            get => _usuario_cid;
            set => _usuario_cid = value;
        }

        public string usuario_nomeCompleto
        {
            get => _usuario_nomeCompleto;
            set => _usuario_nomeCompleto = value;
        }

        public string situacao
        {
            get => _situacao;
            set => _situacao = value;
        }
    }

}
