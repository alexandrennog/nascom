using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "enderEmit")]
    public class EnderEmit
    {

        [XmlElement(ElementName = "xLgr")]
        public string XLgr { get; set; }

        [XmlElement(ElementName = "nro")]
        public int Nro { get; set; }

        [XmlElement(ElementName = "xCpl")]
        public string XCpl { get; set; }

        [XmlElement(ElementName = "xBairro")]
        public string XBairro { get; set; }

        [XmlElement(ElementName = "xMun")]
        public string XMun { get; set; }

        [XmlElement(ElementName = "CEP")]
        public int CEP { get; set; }
    }
}
