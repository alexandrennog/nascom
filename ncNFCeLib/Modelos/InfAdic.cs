using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "infAdic")]
    public class InfAdic
    {

        [XmlElement(ElementName = "infCpl")]
        public string InfCpl { get; set; }

        [XmlElement(ElementName = "obsFisco")]
        public ObsFisco ObsFisco { get; set; }
    }
}
