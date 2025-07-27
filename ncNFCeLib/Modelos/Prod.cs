using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "prod")]
    public class Prod
    {

        [XmlElement(ElementName = "cProd")]
        public double CProd { get; set; }

        [XmlElement(ElementName = "xProd")]
        public string XProd { get; set; }

        [XmlElement(ElementName = "NCM")]
        public int NCM { get; set; }

        [XmlElement(ElementName = "CFOP")]
        public int CFOP { get; set; }

        [XmlElement(ElementName = "uCom")]
        public string UCom { get; set; }

        [XmlElement(ElementName = "qCom")]
        public double QCom { get; set; }

        [XmlElement(ElementName = "vUnCom")]
        public double VUnCom { get; set; }

        [XmlElement(ElementName = "vProd")]
        public double VProd { get; set; }

        [XmlElement(ElementName = "indRegra")]
        public string IndRegra { get; set; }

        [XmlElement(ElementName = "vItem")]
        public double VItem { get; set; }
    }
}
