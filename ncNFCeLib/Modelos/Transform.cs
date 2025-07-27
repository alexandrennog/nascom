using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "Transform")]
    public class Transform
    {

        [XmlAttribute(AttributeName = "Algorithm")]
        public string Algorithm { get; set; }
    }
}
