using System.Collections.Generic;

namespace nsEfd
{
    public class Colecao0100 : List<dReg0100> { }

    public class dReg0100
    {
        public string reg { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string crc { get; set; }
        public string cnpj { get; set; }
        public string cep { get; set; }
        public string ende { get; set; }
        public string num { get; set; }
        public string compl { get; set; }
        public string bairro { get; set; }
        public string fone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string cod_mun { get; set; }
    }
}
