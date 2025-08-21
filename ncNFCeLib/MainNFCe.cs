using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncNFCeLib
{
    public class MainNFCe
    {
        public MainNFCe()
        {
                
        }

        public void Start()
        {
            // Initialize NFCe operations here
            Console.WriteLine("NFCe operations started.");

            //var proc = new nfeProc().CarregarDeArquivoXml("Caminho_do_arquivo_XML");
            //proc.NFe.Valida();   

            //var danfe = new DanfeFrNfce(proc, new ConfiguracaoDanfeNfce(NfceDetalheVendaNormal.UmaLinha, NfceDetalheVendaContigencia.UmaLinha, null/*Logomarca em byte[]*/), "00001", "XXXXXXXXXXXXXXXXXXXXXXXXXX");
            //danfe.Visualizar();
        }   
    }
}
