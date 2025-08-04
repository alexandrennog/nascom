using ncNFCeLib.Mapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ncNFCeLib.Modelos
{

    public class NCFe
    {
        private DarumaFrameworkSat sat;
        public NCFe()
        {
            //InfNFe = new InfNFe();
            //Signature = new Signature();
            //InfNFeSupl = new InfNFeSupl();

            sat = RecuperarConfiguracao();
        }

        public CFe RecuperarCFe() { 
            XmlSerializer serializer = new XmlSerializer(typeof(CFe));
            using (StringReader reader = new StringReader("xml"))
            {
                return (CFe)serializer.Deserialize(reader);
            }
        }

        public void SalvarCFe(CFe cfe)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CFe));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, cfe);
                string xml = writer.ToString();
                // Aqui você pode salvar o XML em um arquivo ou fazer outra coisa com ele
            }
        }
        private DarumaFrameworkSat RecuperarConfiguracao()
        {
            string xmlContent = File.ReadAllText("arquivo.xml");
            DarumaFrameworkSat sat = DarumaFrameworkSat.FromXml(xmlContent);

            return sat;
        }
    }
}
