using System.IO;
using System.Xml.Serialization;

namespace LibNF65.Modelo
{

    // Classes que representam a estrutura do XML
    [XmlRoot("DARUMAFRAMEWORKSAT")]
    public class DarumaFrameworkSat
    {
        [XmlElement("CONFIGURACAO")]
        public Configuracao Configuracao { get; set; }

        [XmlElement("PGTOCARTAOMFE")]
        public PgtoCartaoMfe PgtoCartaoMfe { get; set; }

        [XmlElement("LEIDOIMPOSTO")]
        public LeiDoImposto LeiDoImposto { get; set; }

        [XmlElement("IDENTIFICACAO_CFE")]
        public IdentificacaoCfe IdentificacaoCfe { get; set; }

        [XmlElement("DEST")]
        public Destinatario Dest { get; set; }

        [XmlElement("EMIT")]
        public Emitente Emit { get; set; }

        [XmlElement("PROD")]
        public Produto Prod { get; set; }

        [XmlElement("IMPOSTO")]
        public Imposto Imposto { get; set; }

        // Método para desserializar o XML
        public static DarumaFrameworkSat FromXml(string xml)
        {
            var serializer = new XmlSerializer(typeof(DarumaFrameworkSat));
            using (var reader = new StringReader(xml))
            {
                return (DarumaFrameworkSat)serializer.Deserialize(reader);
            }
        }
    }

    public class Configuracao
    {
        public int estadoCFe { get; set; }
        public int numeroSessao { get; set; }
        public string codigoDeAtivacao { get; set; }
        public string ChaveConsulta { get; set; }
        public decimal vCFeLei12741 { get; set; }
        public decimal vCFeLei12741Porcentagem { get; set; }
        public string VersaoDadosEnt { get; set; }
        public string CaracterSeparador { get; set; }
        public string SeparadorUsoFuturo { get; set; }
        public string Logotipo { get; set; }
        public string Marca { get; set; }
        public int LayoutImpressao { get; set; }
        public int ImprimirMsgQrCode { get; set; }
    }

    public class PgtoCartaoMfe
    {
        public string ChaveAcessoValidador { get; set; }
        public string ChaveRequisicao { get; set; }
        public string CodigoMoeda { get; set; }
        public string IDEstabelecimento { get; set; }
        public int EmitirCupomNFCe { get; set; }
        public string IdFila { get; set; }
        public int HabilitarControleAntiFraude { get; set; }
    }

    public class LeiDoImposto
    {
        public string MsgLeiDoImposto { get; set; }
        public int Habilitar { get; set; }
        public string ColunasArquivo { get; set; }
        public string LocalArquivoNCM { get; set; }
        public string SeparadorArquivo { get; set; }
    }

    public class IdentificacaoCfe
    {
        public string CNPJ { get; set; }
        public string signAC { get; set; }
        public string numeroCaixa { get; set; }
        public string nNF { get; set; }
        public string UrlQrcode { get; set; }
        public string nSerie { get; set; }
        public string DataHoraEmissao { get; set; }
        public decimal vTotalCfe { get; set; }
        public string obsFisco { get; set; }
    }

    public class Destinatario
    {
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string xNome { get; set; }
    }

    public class Emitente
    {
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public string IM { get; set; }
        public string UF { get; set; }
        public string cRegTribISSQN { get; set; }
        public string indRatISSQN { get; set; }
    }

    public class Produto
    {
        public string cEAN { get; set; }
        public string CFOP { get; set; }
        public string indRegra { get; set; }
        public string NCM { get; set; }
    }

    public class Imposto
    {
        public ICMS ICMS { get; set; }
        public ISSQN ISSQN { get; set; }
        public PIS PIS { get; set; }
        public PISST PISST { get; set; }
        public COFINS COFINS { get; set; }
        public COFINSST COFINSST { get; set; }
        public IBSCBS IBSCBS { get; set; }
    }

    public class ICMS
    {
        public ICMS00 ICMS00 { get; set; }
        public ICMS40 ICMS40 { get; set; }
        public ICMSSN102 ICMSSN102 { get; set; }
        public ICMSSN900 ICMSSN900 { get; set; }
    }

    public class ICMS00
    {
        public string Orig { get; set; }
        public string CST { get; set; }
    }

    public class ICMS40
    {
        public string Orig { get; set; }
        public string CST { get; set; }
    }

    public class ICMSSN102
    {
        public string orig { get; set; }
        public string CSOSN { get; set; }
    }

    public class ICMSSN900
    {
        public string Orig { get; set; }
        public string CSOSN { get; set; }
    }

    public class ISSQN
    {
        public string vDeducISSQN { get; set; }
        public string vAliq { get; set; }
        public string cMunFG { get; set; }
        public string cListServ { get; set; }
        public string cServTribMun { get; set; }
        public string cNatOp { get; set; }
        public string indIncFisc { get; set; }
    }

    public class PIS
    {
        public PISALIQ PISALIQ { get; set; }
        public PISQTDE PISQTDE { get; set; }
        public PISNT PISNT { get; set; }
        public PISSN PISSN { get; set; }
        public PISOUTR PISOUTR { get; set; }
    }

    public class PISALIQ
    {
        public string CST { get; set; }
        public string pPIS { get; set; }
    }

    public class PISQTDE
    {
        public string CST { get; set; }
        public string vAliqProd { get; set; }
    }

    public class PISNT
    {
        public string CST { get; set; }
    }

    public class PISSN
    {
        public string CST { get; set; }
    }

    public class PISOUTR
    {
        public string CST { get; set; }
        public string pPIS { get; set; }
        public string vAliqProd { get; set; }
        public string TipoAliq { get; set; }
    }

    public class PISST
    {
        public string pPIS { get; set; }
        public string vAliqProd { get; set; }
        public string TipoAliq { get; set; }
    }

    public class COFINS
    {
        public COFINSALIQ COFINSALIQ { get; set; }
        public COFINSQTDE COFINSQTDE { get; set; }
        public COFINSNT COFINSNT { get; set; }
        public COFINSSN COFINSSN { get; set; }
        public COFINSOUTR COFINSOUTR { get; set; }
    }

    public class COFINSALIQ
    {
        public string CST { get; set; }
        public string pCOFINS { get; set; }
    }

    public class COFINSQTDE
    {
        public string CST { get; set; }
        public string vAliqProd { get; set; }
    }

    public class COFINSNT
    {
        public string CST { get; set; }
    }

    public class COFINSSN
    {
        public string CST { get; set; }
    }

    public class COFINSOUTR
    {
        public string CST { get; set; }
        public string pCOFINS { get; set; }
        public string vAliqProd { get; set; }
        public string TipoAliq { get; set; }
    }

    public class COFINSST
    {
        public string pCOFINS { get; set; }
        public string vAliqProd { get; set; }
        public string TipoAliq { get; set; }
    }


    [XmlRoot("IBSCBS")]
    public class IBSCBS
    {
        [XmlElement("CST")]
        public string CST { get; set; }

        [XmlElement("cClassTrib")]
        public string CClassTrib { get; set; }

        [XmlElement("gIBSCBS")]
        public GIBSCBS GIBSCBS { get; set; }
    }

    public class GIBSCBS
    {
        [XmlElement("vBC")]
        public decimal VBC { get; set; }

        [XmlElement("gIBSUF")]
        public GIBSUF GIBSUF { get; set; }

        [XmlElement("gIBSMun")]
        public GIBSMun GIBSMun { get; set; }

        [XmlElement("vIBS")]
        public decimal VIBS { get; set; }

        [XmlElement("gCBS")]
        public GCBS GCBS { get; set; }
    }

    public class GIBSUF
    {
        [XmlElement("pIBSUF")]
        public decimal PIBSUF { get; set; }

        [XmlElement("vIBSUF")]
        public decimal VIBSUF { get; set; }
    }

    public class GIBSMun
    {
        [XmlElement("pIBSMun")]
        public decimal PIBSMun { get; set; }

        [XmlElement("vIBSMun")]
        public decimal VIBSMun { get; set; }
    }

    public class GCBS
    {
        [XmlElement("pCBS")]
        public decimal PCBS { get; set; }

        [XmlElement("vCBS")]
        public decimal VCBS { get; set; }
    }
}
