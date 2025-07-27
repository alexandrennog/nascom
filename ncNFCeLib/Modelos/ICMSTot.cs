using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "ICMSTot")]
    public class ICMSTot
    {

        [XmlElement(ElementName = "vICMS")]
        public double VICMS { get; set; }

        [XmlElement(ElementName = "vProd")]
        public double VProd { get; set; }

        [XmlElement(ElementName = "vDesc")]
        public double VDesc { get; set; }

        [XmlElement(ElementName = "vPIS")]
        public double VPIS { get; set; }

        [XmlElement(ElementName = "vCOFINS")]
        public double VCOFINS { get; set; }

        [XmlElement(ElementName = "vPISST")]
        public double VPISST { get; set; }

        [XmlElement(ElementName = "vCOFINSST")]
        public double VCOFINSST { get; set; }

        [XmlElement(ElementName = "vOutro")]
        public double VOutro { get; set; }
    }
}
