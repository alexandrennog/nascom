using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "PISNT")]
    public class PISNT
    {

        [XmlElement(ElementName = "CST")]
        public int CST { get; set; }
    }
}
