using NFe.Classes.Informacoes.Total;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "total")]
    public class Total
    {

        [XmlElement(ElementName = "ICMSTot")]
        public ICMSTot ICMSTot { get; set; }

        [XmlElement(ElementName = "vCFe")]
        public double VCFe { get; set; }

        [XmlElement(ElementName = "vCFeLei12741")]
        public double VCFeLei12741 { get; set; }
    }
}
