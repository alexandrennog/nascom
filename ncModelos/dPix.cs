using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoPix : List<dPix> { }

    public class dPix
    {
        public string ID { get; set; }
        public string TxId { get; set; }
        public int Cliente { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Pagador { get; set; }
        public decimal Original { get; set; }
        public string Observacao { get; set; }
        public string Status { get; set; }
        public DateTime DataHora { get; set; }
        public int Controle { get; set; }
        public string UrlPix { get; set; }
    }

}
