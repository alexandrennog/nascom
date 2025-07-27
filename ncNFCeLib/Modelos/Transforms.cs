using DFe.Classes.Assinatura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "Transforms")]
    public class Transforms
    {

        [XmlElement(ElementName = "Transform")]
        public List<Transform> Transform { get; set; }
    }
}
