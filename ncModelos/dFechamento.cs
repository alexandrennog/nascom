using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoFechamento : List<dFechamento> { }

    public class dFechamento
    {
        public DateTime data { get; set; }
        public decimal dinheiro { get; set; }
        public decimal cheque { get; set; }
        public decimal chequePre { get; set; }
        public decimal cartaoDebito { get; set; }
        public decimal cartaoCredito { get; set; }
        public decimal crediario { get; set; }
        public decimal desconto { get; set; }
        public decimal recebido { get; set; }
        public decimal troco { get; set; }
        public decimal total { get; set; }
        public decimal troca { get; set; }
        public decimal vale { get; set; }
        public decimal defeito { get; set; }
        public decimal retirada { get; set; }
        public decimal valeEmitido { get; set; }
        public decimal crediarioPagamento { get; set; }
        public string caixa { get; set; }
    }
}
