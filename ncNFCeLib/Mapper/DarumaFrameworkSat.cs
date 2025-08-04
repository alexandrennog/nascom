using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ncNFCeLib.Mapper
{


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
        public Destinatario Destinatario { get; set; }

        [XmlElement("EMIT")]
        public Emitente Emitente { get; set; }

        [XmlElement("PROD")]
        public Produto Produto { get; set; }

        [XmlElement("IMPOSTO")]
        public Imposto Imposto { get; set; }

        public static DarumaFrameworkSat FromXml(string xml)
        {
            var serializer = new XmlSerializer(typeof(DarumaFrameworkSat));
            using (var reader = new StringReader(xml))
            {
                return (DarumaFrameworkSat)serializer.Deserialize(reader);
            }
        }

        public string ToXml()
        {
            var serializer = new XmlSerializer(typeof(DarumaFrameworkSat));
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, this);
                return stream.ToString();
            }
        }
    }

    public class Configuracao
    {
        [XmlElement("estadoCFe")]
        public int EstadoCFe { get; set; }

        [XmlElement("numeroSessao")]
        public int NumeroSessao { get; set; }

        [XmlElement("codigoDeAtivacao")]
        public string CodigoDeAtivacao { get; set; }

        [XmlElement("ChaveConsulta")]
        public string ChaveConsulta { get; set; }

        [XmlElement("vCFeLei12741")]
        public decimal VCFeLei12741 { get; set; }

        [XmlElement("vCFeLei12741Porcentagem")]
        public decimal VCFeLei12741Porcentagem { get; set; }

        [XmlElement("VersaoDadosEnt")]
        public string VersaoDadosEnt { get; set; }

        [XmlElement("CaracterSeparador")]
        public string CaracterSeparador { get; set; }

        [XmlElement("SeparadorUsoFuturo")]
        public string SeparadorUsoFuturo { get; set; }

        [XmlElement("Logotipo")]
        public string Logotipo { get; set; }

        [XmlElement("Marca")]
        public string Marca { get; set; }

        [XmlElement("LayoutImpressao")]
        public int LayoutImpressao { get; set; }

        [XmlElement("ImprimirMsgQrCode")]
        public int ImprimirMsgQrCode { get; set; }
    }

    public class PgtoCartaoMfe
    {
        [XmlElement("ChaveAcessoValidador")]
        public string ChaveAcessoValidador { get; set; }

        [XmlElement("ChaveRequisicao")]
        public string ChaveRequisicao { get; set; }

        [XmlElement("CodigoMoeda")]
        public string CodigoMoeda { get; set; }

        [XmlElement("IDEstabelecimento")]
        public string IDEstabelecimento { get; set; }

        [XmlElement("EmitirCupomNFCe")]
        public int EmitirCupomNFCe { get; set; }

        [XmlElement("IdFila")]
        public string IdFila { get; set; }

        [XmlElement("HabilitarControleAntiFraude")]
        public int HabilitarControleAntiFraude { get; set; }
    }

    public class LeiDoImposto
    {
        [XmlElement("MsgLeiDoImposto")]
        public string MsgLeiDoImposto { get; set; }

        [XmlElement("Habilitar")]
        public int Habilitar { get; set; }

        [XmlElement("ColunasArquivo")]
        public string ColunasArquivo { get; set; }

        [XmlElement("LocalArquivoNCM")]
        public string LocalArquivoNCM { get; set; }

        [XmlElement("SeparadorArquivo")]
        public string SeparadorArquivo { get; set; }
    }

    public class IdentificacaoCfe
    {
        [XmlElement("CNPJ")]
        public string CNPJ { get; set; }

        [XmlElement("signAC")]
        public string SignAC { get; set; }

        [XmlElement("numeroCaixa")]
        public string NumeroCaixa { get; set; }

        [XmlElement("nNF")]
        public string NNF { get; set; }

        [XmlElement("UrlQrcode")]
        public string UrlQrcode { get; set; }

        [XmlElement("nSerie")]
        public string NSerie { get; set; }

        [XmlElement("DataHoraEmissao")]
        public string DataHoraEmissao { get; set; }

        [XmlElement("vTotalCfe")]
        public decimal VTotalCfe { get; set; }

        [XmlElement("obsFisco")]
        public string ObsFisco { get; set; }
    }

    public class Destinatario
    {
        [XmlElement("CNPJ")]
        public string CNPJ { get; set; }

        [XmlElement("CPF")]
        public string CPF { get; set; }

        [XmlElement("xNome")]
        public string XNome { get; set; }
    }

    public class Emitente
    {
        [XmlElement("CNPJ")]
        public string CNPJ { get; set; }

        [XmlElement("IE")]
        public string IE { get; set; }

        [XmlElement("IM")]
        public string IM { get; set; }

        [XmlElement("UF")]
        public string UF { get; set; }

        [XmlElement("cRegTribISSQN")]
        public string CRegTribISSQN { get; set; }

        [XmlElement("indRatISSQN")]
        public string IndRatISSQN { get; set; }
    }

    public class Produto
    {
        [XmlElement("cEAN")]
        public string CEAN { get; set; }

        [XmlElement("CFOP")]
        public string CFOP { get; set; }

        [XmlElement("indRegra")]
        public string IndRegra { get; set; }

        [XmlElement("NCM")]
        public string NCM { get; set; }
    }

    public class Imposto
    {
        [XmlElement("ICMS")]
        public ICMS ICMS { get; set; }

        [XmlElement("ISSQN")]
        public ISSQN ISSQN { get; set; }

        [XmlElement("PIS")]
        public PIS PIS { get; set; }

        [XmlElement("PISST")]
        public PISST PISST { get; set; }

        [XmlElement("COFINS")]
        public COFINS COFINS { get; set; }

        [XmlElement("COFINSST")]
        public COFINSST COFINSST { get; set; }
    }

    public class ICMS
    {
        [XmlElement("ICMS00")]
        public ICMS00 ICMS00 { get; set; }

        [XmlElement("ICMS40")]
        public ICMS40 ICMS40 { get; set; }

        [XmlElement("ICMSSN102")]
        public ICMSSN102 ICMSSN102 { get; set; }

        [XmlElement("ICMSSN900")]
        public ICMSSN900 ICMSSN900 { get; set; }
    }

    public class ICMS00
    {
        [XmlElement("Orig")]
        public string Orig { get; set; }

        [XmlElement("CST")]
        public string CST { get; set; }
    }

    public class ICMS40
    {
        [XmlElement("Orig")]
        public string Orig { get; set; }

        [XmlElement("CST")]
        public string CST { get; set; }
    }

    public class ICMSSN102
    {
        [XmlElement("Orig")]
        public string Orig { get; set; }

        [XmlElement("CSOSN")]
        public string CSOSN { get; set; }
    }

    public class ICMSSN900
    {
        [XmlElement("Orig")]
        public string Orig { get; set; }

        [XmlElement("CSOSN")]
        public string CSOSN { get; set; }
    }

    public class ISSQN
    {
        [XmlElement("vDeducISSQN")]
        public string VDeducISSQN { get; set; }

        [XmlElement("vAliq")]
        public string VAliq { get; set; }

        [XmlElement("cMunFG")]
        public string CMunFG { get; set; }

        [XmlElement("cListServ")]
        public string CListServ { get; set; }

        [XmlElement("cServTribMun")]
        public string CServTribMun { get; set; }

        [XmlElement("cNatOp")]
        public string CNatOp { get; set; }

        [XmlElement("indIncFisc")]
        public string IndIncFisc { get; set; }
    }

    public class PIS
    {
        [XmlElement("PISALIQ")]
        public PISALIQ PISALIQ { get; set; }

        [XmlElement("PISQTDE")]
        public PISQTDE PISQTDE { get; set; }

        [XmlElement("PISNT")]
        public PISNT PISNT { get; set; }

        [XmlElement("PISSN")]
        public PISSN PISSN { get; set; }

        [XmlElement("PISOUTR")]
        public PISOUTR PISOUTR { get; set; }
    }

    public class PISALIQ
    {
        [XmlElement("CST")]
        public string CST { get; set; }

        [XmlElement("pPIS")]
        public string PPIS { get; set; }
    }

    public class PISQTDE
    {
        [XmlElement("CST")]
        public string CST { get; set; }

        [XmlElement("vAliqProd")]
        public string VAliqProd { get; set; }
    }

    public class PISNT
    {
        [XmlElement("CST")]
        public string CST { get; set; }
    }

    public class PISSN
    {
        [XmlElement("CST")]
        public string CST { get; set; }
    }

    public class PISOUTR
    {
        [XmlElement("CST")]
        public string CST { get; set; }

        [XmlElement("pPIS")]
        public string PPIS { get; set; }

        [XmlElement("vAliqProd")]
        public string VAliqProd { get; set; }

        [XmlElement("TipoAliq")]
        public string TipoAliq { get; set; }
    }

    public class PISST
    {
        [XmlElement("pPIS")]
        public string PPIS { get; set; }

        [XmlElement("vAliqProd")]
        public string VAliqProd { get; set; }

        [XmlElement("TipoAliq")]
        public string TipoAliq { get; set; }
    }

    public class COFINS
    {
        [XmlElement("COFINSALIQ")]
        public COFINSALIQ COFINSALIQ { get; set; }

        [XmlElement("COFINSQTDE")]
        public COFINSQTDE COFINSQTDE { get; set; }

        [XmlElement("COFINSNT")]
        public COFINSNT COFINSNT { get; set; }

        [XmlElement("COFINSSN")]
        public COFINSSN COFINSSN { get; set; }

        [XmlElement("COFINSOUTR")]
        public COFINSOUTR COFINSOUTR { get; set; }
    }

    public class COFINSALIQ
    {
        [XmlElement("CST")]
        public string CST { get; set; }

        [XmlElement("pCOFINS")]
        public string PCOFINS { get; set; }
    }

    public class COFINSQTDE
    {
        [XmlElement("CST")]
        public string CST { get; set; }

        [XmlElement("vAliqProd")]
        public string VAliqProd { get; set; }
    }

    public class COFINSNT
    {
        [XmlElement("CST")]
        public string CST { get; set; }
    }

    public class COFINSSN
    {
        [XmlElement("CST")]
        public string CST { get; set; }
    }

    public class COFINSOUTR
    {
        [XmlElement("CST")]
        public string CST { get; set; }

        [XmlElement("pCOFINS")]
        public string PCOFINS { get; set; }

        [XmlElement("vAliqProd")]
        public string VAliqProd { get; set; }

        [XmlElement("TipoAliq")]
        public string TipoAliq { get; set; }
    }

    public class COFINSST
    {
        [XmlElement("pCOFINS")]
        public string PCOFINS { get; set; }

        [XmlElement("vAliqProd")]
        public string VAliqProd { get; set; }

        [XmlElement("TipoAliq")]
        public string TipoAliq { get; set; }
    }
}
