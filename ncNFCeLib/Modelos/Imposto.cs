using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "imposto")]
    public class Imposto
    {

        [XmlElement(ElementName = "ICMS")]
        public ICMS ICMS { get; set; }

        [XmlElement(ElementName = "PIS")]
        public PIS PIS { get; set; }

        [XmlElement(ElementName = "COFINS")]
        public COFINS COFINS { get; set; }
    }
}
