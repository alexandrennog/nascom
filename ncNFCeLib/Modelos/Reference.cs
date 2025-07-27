using DFe.Classes.Assinatura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "Reference")]
    public class Reference
    {

        [XmlElement(ElementName = "Transforms")]
        public Transforms Transforms { get; set; }

        [XmlElement(ElementName = "DigestMethod")]
        public DigestMethod DigestMethod { get; set; }

        [XmlElement(ElementName = "DigestValue")]
        public string DigestValue { get; set; }

        [XmlAttribute(AttributeName = "URI")]
        public string URI { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
