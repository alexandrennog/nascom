using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "pgto")]
    public class Pgto
    {

        [XmlElement(ElementName = "MP")]
        public MP MP { get; set; }

        [XmlElement(ElementName = "vTroco")]
        public double VTroco { get; set; }
    }
}
