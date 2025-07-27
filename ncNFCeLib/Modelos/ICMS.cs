using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "ICMS")]
    public class ICMS
    {

        [XmlElement(ElementName = "ICMS00")]
        public ICMS00 ICMS00 { get; set; }
    }
}
