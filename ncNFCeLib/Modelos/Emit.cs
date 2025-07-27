using NFe.Classes.Informacoes.Emitente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "emit")]
    public class Emit
    {

        [XmlElement(ElementName = "CNPJ")]
        public double CNPJ { get; set; }

        [XmlElement(ElementName = "xNome")]
        public string XNome { get; set; }

        [XmlElement(ElementName = "enderEmit")]
        public EnderEmit EnderEmit { get; set; }

        [XmlElement(ElementName = "IE")]
        public double IE { get; set; }

        [XmlElement(ElementName = "cRegTrib")]
        public int CRegTrib { get; set; }

        [XmlElement(ElementName = "cRegTribISSQN")]
        public int CRegTribISSQN { get; set; }

        [XmlElement(ElementName = "indRatISSQN")]
        public string IndRatISSQN { get; set; }
    }

}
