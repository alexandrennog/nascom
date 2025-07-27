using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "COFINSNT")]
    public class COFINSNT
    {

        [XmlElement(ElementName = "CST")]
        public int CST { get; set; }
    }
}
