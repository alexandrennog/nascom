using DFe.Classes.Assinatura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "Signature")]
    public class Signature
    {

        [XmlElement(ElementName = "SignedInfo")]
        public SignedInfo SignedInfo { get; set; }

        [XmlElement(ElementName = "SignatureValue")]
        public string SignatureValue { get; set; }

        [XmlElement(ElementName = "KeyInfo")]
        public KeyInfo KeyInfo { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
