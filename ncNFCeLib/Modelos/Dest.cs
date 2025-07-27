using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "dest")]
    public class Dest
    {

        [XmlElement(ElementName = "CPF")]
        public double CPF { get; set; }
    }
}
