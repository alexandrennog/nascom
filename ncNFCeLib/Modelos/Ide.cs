using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{

    [XmlRoot(ElementName = "ide")]
    public class Ide
    {

        [XmlElement(ElementName = "cUF")]
        public int CUF { get; set; }

        [XmlElement(ElementName = "cNF")]
        public int CNF { get; set; }

        [XmlElement(ElementName = "mod")]
        public int Mod { get; set; }

        [XmlElement(ElementName = "nserieSAT")]
        public int NserieSAT { get; set; }

        [XmlElement(ElementName = "nCFe")]
        public int NCFe { get; set; }

        [XmlElement(ElementName = "dEmi")]
        public int DEmi { get; set; }

        [XmlElement(ElementName = "hEmi")]
        public int HEmi { get; set; }

        [XmlElement(ElementName = "cDV")]
        public int CDV { get; set; }

        [XmlElement(ElementName = "tpAmb")]
        public int TpAmb { get; set; }

        [XmlElement(ElementName = "CNPJ")]
        public double CNPJ { get; set; }

        [XmlElement(ElementName = "signAC")]
        public string SignAC { get; set; }

        [XmlElement(ElementName = "assinaturaQRCODE")]
        public string AssinaturaQRCODE { get; set; }

        [XmlElement(ElementName = "numeroCaixa")]
        public int NumeroCaixa { get; set; }
    }
}
