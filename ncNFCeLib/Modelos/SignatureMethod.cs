using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "SignatureMethod")]
    public class SignatureMethod
    {

        [XmlAttribute(AttributeName = "Algorithm")]
        public string Algorithm { get; set; }
    }
}
