using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoVendasPorVendedor : List<dVendasPorVendedor>
    {
    }

    public class dVendasPorVendedor
    {
        private string _nome;
        private int _totalVendas;
        private int _quantidadeProdutos;
        private decimal _valorTotalVendas;
        private decimal _ticketMedio;
        private decimal _percentualAtingimento;
        private DateTime _data;
        private DateTime _dataFim;

        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }

        public int TotalVendas
        {
            get => _totalVendas;
            set => _totalVendas = value;
        }

        public int QuantidadeProdutos
        {
            get => _quantidadeProdutos;
            set => _quantidadeProdutos = value;
        }

        public decimal ValorTotalVendas
        {
            get => _valorTotalVendas;
            set => _valorTotalVendas = value;
        }

        public decimal TicketMedio
        {
            get => _ticketMedio;
            set => _ticketMedio = value;
        }

        public decimal PercentualAtingimento
        {
            get => _percentualAtingimento;
            set => _percentualAtingimento = value;
        }

        public DateTime Data
        {
            get => _data;
            set => _data = value;
        }

        public DateTime DataFim
        {
            get => _dataFim;
            set => _dataFim = value;
        }
    }

}
