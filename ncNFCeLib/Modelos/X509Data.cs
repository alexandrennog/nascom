using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "X509Data")]
    public class X509Data
    {

        [XmlElement(ElementName = "X509Certificate")]
        public string X509Certificate { get; set; }
    }
}
