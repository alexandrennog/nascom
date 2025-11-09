using LibNF65.Modelo;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unimake.Business.DFe.Xml.NFe;
using Configuracao = Unimake.Business.DFe.Servicos.Configuracao;
using XmlNFe = Unimake.Business.DFe.Xml.NFe;


namespace LibNF65
{
    public interface INFCe
    {
        void EventoCancelamentoNFCe(string chave, X509Certificate2 x509Cert);
        void ImprimirDANFe(string chave);
        string ConsultarCupom(Configuracao configuracao, string chaveAcesso);
        RetConsCad ConsultarCadastro(Unimake.Business.DFe.Servicos.Configuracao configuracao, ConsCad consCad);

        XmlNFe.NFe RecuperarProdutos(List<ProdutoVendido> dVendaProdutos, int nNF, Unimake.Business.DFe.Servicos.Configuracao configuracao, DarumaFrameworkSat configImposto, RetConsCad retConsCad);

        void EnviarNFCe(string caminhoCertificado, string senhaCertificado, string cnpjEmissor, List<ProdutoVendido> Produtos);
        string ConsultarCupomNFCe();

    }
}
