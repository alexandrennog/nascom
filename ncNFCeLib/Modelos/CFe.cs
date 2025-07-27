using DFe.Classes.Assinatura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "CFe")]
    public class CFe
    {

        [XmlElement(ElementName = "infCFe")]
        public InfCFe InfCFe { get; set; }

        [XmlElement(ElementName = "Signature")]
        public Signature Signature { get; set; }
    }
}
