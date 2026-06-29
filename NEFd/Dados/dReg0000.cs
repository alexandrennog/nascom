using System;
using System.Collections.Generic;

namespace NEFd
{
    public class Colecao0000 : List<dReg0000> { }

    public class dReg0000
    {
        public string reg { get; set; }
        public string cod_ver { get; set; }
        public string cod_fin { get; set; }
        public DateTime? dt_ini { get; set; }
        public DateTime? dt_fin { get; set; }
        public string nome { get; set; }
        public string cnpj { get; set; }
        public string cpf { get; set; }
        public string uf { get; set; }
        public string ie { get; set; }
        public string cod_mun { get; set; }
        public string im { get; set; }
        public string suframa { get; set; }
        public string ind_perfil { get; set; }
        public string ind_ativ { get; set; }
        public string tipoPessoa { get; set; }
        public string cpfCnpj { get; set; }
    }
}
