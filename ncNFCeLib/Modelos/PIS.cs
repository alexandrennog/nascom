using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "PIS")]
    public class PIS
    {

        [XmlElement(ElementName = "PISNT")]
        public PISNT PISNT { get; set; }
    }
}
