using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "MP")]
    public class MP
    {

        [XmlElement(ElementName = "cMP")]
        public int CMP { get; set; }

        [XmlElement(ElementName = "vMP")]
        public double VMP { get; set; }
    }
}
