using System;

namespace ncModelos
{
    public class dEfdArquivo
    {
        private string _versaoLeiaute;
        private string _finalidadeArquivo;
        private string _perfilArquivoFiscal;

        public string versaoLeiaute
        {
            get => _versaoLeiaute;
            set => _versaoLeiaute = value;
        }

        public string finalidadeArquivo
        {
            get => _finalidadeArquivo;
            set => _finalidadeArquivo = value;
        }

        public string perfilArquivoFiscal
        {
            get => _perfilArquivoFiscal;
            set => _perfilArquivoFiscal = value;
        }
    }

}
