using NFe.Classes.Informacoes.Detalhe;
using NFe.Classes.Informacoes.Detalhe.Tributacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "det")]
    public class Det
    {

        [XmlElement(ElementName = "prod")]
        public Prod Prod { get; set; }

        [XmlElement(ElementName = "imposto")]
        public Imposto Imposto { get; set; }

        [XmlAttribute(AttributeName = "nItem")]
        public int NItem { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
