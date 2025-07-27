using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "obsFisco")]
    public class ObsFisco
    {

        [XmlElement(ElementName = "xTexto")]
        public string XTexto { get; set; }

        [XmlAttribute(AttributeName = "xCampo")]
        public string XCampo { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
