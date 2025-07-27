using DFe.Classes.Assinatura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "KeyInfo")]
    public class KeyInfo
    {

        [XmlElement(ElementName = "X509Data")]
        public X509Data X509Data { get; set; }
    }
}
