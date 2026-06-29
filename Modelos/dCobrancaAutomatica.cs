using System;
using System.Collections.Generic;

namespace Modelos
{
    public class ColecaoCobranca : List<dCobrancaAutomatica>
    {
    }

    public class dCobrancaAutomatica
    {
        private int _codigocliente;
        private int _crediarioid;
        private int _parcelaidid;
        private decimal _valor;
        private string _nome;
        private string _dddcel;
        private string _celular;
        private string _sucesso;
        private string _pix_code;
        private DateTime _data_cobranca;
        private DateTime _datavencimento;

        public int CodigoCliente
        {
            get => _codigocliente;
            set => _codigocliente = value;
        }

        public int CrediarioId
        {
            get => _crediarioid;
            set => _crediarioid = value;
        }

        public int ParcelaIdId
        {
            get => _parcelaidid;
            set => _parcelaidid = value;
        }

        public decimal Valor
        {
            get => _valor;
            set => _valor = value;
        }

        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }

        public string DDDCel
        {
            get => _dddcel;
            set => _dddcel = value;
        }

        public string Celular
        {
            get => _celular;
            set => _celular = value;
        }

        public string Sucesso
        {
            get => _sucesso;
            set => _sucesso = value;
        }

        public string PixCode
        {
            get => _pix_code;
            set => _pix_code = value;
        }

        public DateTime DataCobranca
        {
            get => _data_cobranca;
            set => _data_cobranca = value;
        }

        public DateTime DataVencimento
        {
            get => _datavencimento;
            set => _datavencimento = value;
        }
    }

}
