using NFe.Classes.Informacoes.Detalhe;
using NFe.Classes.Informacoes.Emitente;
using NFe.Classes.Informacoes.Identificacao;
using NFe.Classes.Informacoes.Observacoes;
using NFe.Classes.Informacoes.Total;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{
    [XmlRoot(ElementName = "infCFe")]
    public class InfCFe
    {

        [XmlElement(ElementName = "ide")]
        public Ide Ide { get; set; }

        [XmlElement(ElementName = "emit")]
        public Emit Emit { get; set; }

        [XmlElement(ElementName = "dest")]
        public Dest Dest { get; set; }

        [XmlElement(ElementName = "det")]
        public Det Det { get; set; }

        [XmlElement(ElementName = "total")]
        public Total Total { get; set; }

        [XmlElement(ElementName = "pgto")]
        public Pgto Pgto { get; set; }

        [XmlElement(ElementName = "infAdic")]
        public InfAdic InfAdic { get; set; }

        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "versao")]
        public double Versao { get; set; }

        [XmlAttribute(AttributeName = "versaoDadosEnt")]
        public double VersaoDadosEnt { get; set; }

        [XmlAttribute(AttributeName = "versaoSB")]
        public int VersaoSB { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
