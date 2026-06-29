using System.Collections.Generic;

namespace NEFd
{
    public class Colecao9900 : List<dReg9900> { }

    public class dReg9900
    {
        public string reg { get; set; }
        public string reg_blc { get; set; }
        public int? qtd_reg_blc { get; set; }

        public dReg9900 MontarReg9900(string tipoRegistro, int quantidadeRegistro)
        {
            var registro = new dReg9900();
            registro.reg = "9900";
            registro.reg_blc = tipoRegistro;
            registro.qtd_reg_blc = quantidadeRegistro;
            return registro;
        }
    }
}
