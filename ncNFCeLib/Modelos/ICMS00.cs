using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "ICMS00")]
    public class ICMS00
    {

        [XmlElement(ElementName = "Orig")]
        public int Orig { get; set; }

        [XmlElement(ElementName = "CST")]
        public int CST { get; set; }

        [XmlElement(ElementName = "pICMS")]
        public double PICMS { get; set; }

        [XmlElement(ElementName = "vICMS")]
        public double VICMS { get; set; }
    }
}
