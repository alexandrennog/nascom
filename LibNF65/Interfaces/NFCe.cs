using LibNF65.Interfaces;
using LibNF65.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using Unimake.Business.DFe;
using Unimake.Business.DFe.Security;
using Unimake.Business.DFe.Servicos;
using Unimake.Business.DFe.Servicos.NFCe;
using Unimake.Business.DFe.Utility;
using Unimake.Business.DFe.Xml.ESocial;
using Unimake.Business.DFe.Xml.NF3e;
using Unimake.Business.DFe.Xml.NFe;
using Unimake.Security.Platform;
using Unimake.Unidanfe.Configurations;
using Configuracao = Unimake.Business.DFe.Servicos.Configuracao;
using DANFe = Unimake.Unidanfe;
using Det = Unimake.Business.DFe.Xml.NFe.Det;
using ServicoNFCe = Unimake.Business.DFe.Servicos.NFCe;
using XmlNFe = Unimake.Business.DFe.Xml.NFe;

namespace LibNF65
{

    public class NasNFCe : INFCe
    {

        public RecepcaoEvento EventoCancelamentoNFCe(string chave, X509Certificate2 x509Cert, string nProt)
        {
            var xml = new XmlNFe.EnvEvento
            {
                Versao = "1.00",
                IdLote = "000000000000001",
                Evento = new List<XmlNFe.Evento>
                {
                    new XmlNFe.Evento
                    {
                        Versao = "1.00",
                        InfEvento = new XmlNFe.InfEvento(new XmlNFe.DetEventoCanc
                        {
                            NProt = nProt,
                            Versao = "1.00",
                            XJust = "Justificativa de teste de cancelamento"
                        })
                        {
                            COrgao = UFBrasil.SP,
                            ChNFe = chave,
                            CNPJ = ConfigurationManager.AppSettings["CNPJ"],
                            DhEvento = DateTime.Now,
                            TpEvento = TipoEventoNFe.Cancelamento,
                            NSeqEvento = 1,
                            VerEvento = "1.00",
                            TpAmb = ConfigurationManager.AppSettings["TipoAmbiente"] == "1" ? TipoAmbiente.Producao : TipoAmbiente.Homologacao
                        }
                    }
                }
            };

            var configuracao = new Configuracao
            {
                TipoDFe = TipoDFe.NFCe,
                CertificadoDigital = x509Cert
            };

            var recepcaoEvento = new ServicoNFCe.RecepcaoEvento(xml, configuracao);
            recepcaoEvento.Executar();

            return recepcaoEvento;

        
        }


        //USO
        public static string GerarQRCode(string chave)
        {
            var dadosNFCe = new DadosQrCodeNFCe
            {
                ChaveAcesso = chave,
                Ambiente = 2, // Homologação
                DataHoraEmissao = DateTime.Now,
                ValorTotal = 150.75m,
                ValorIcms = 25.30m,
                CpfCnpjConsumidor = "36650283000164",
                DigVal = "a1b2c3d4e5f67890"
            };

            try
            {
                var servico = new ServicoQrCodeNFCe();

                // Gerar URL do QR Code
                var url = servico.GerarUrlConsulta(dadosNFCe);

                // Gerar imagem do QR Code
                var imagem = servico.GerarImagemQrCode(dadosNFCe);
                imagem.Save("qrcode_nfce.png", System.Drawing.Imaging.ImageFormat.Png);

                // Gerar Base64 para uso em HTML
                var base64 = servico.GerarQrCodeBase64(dadosNFCe);

                return url;


            }
            catch (Exception ex)
            {
                return "";
            }
        }

        //USO
        public void ImprimirDANFe(string chave)
        {
            string pastaBase = @"C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\";
            string xmlPath = Path.Combine(pastaBase, "NFs", $"{chave}.xml");
            string pdfPath = Path.Combine(pastaBase, "PDFs", $"NFCe_{chave}.pdf");

            // 🧾 Gera o PDF com Unidanfe
            var config = new UnidanfeConfiguration
            {
                Arquivo = xmlPath,
                Visualizar = true,
                Imprimir = false,
                EnviaEmail = false, // 🔧 Vamos enviar manualmente abaixo
                PastaLocalQRCode = pastaBase,
                PastaPDF = Path.Combine(pastaBase, "PDFs"),
                NomePDF = $"NFCe_{chave}.pdf",
                Configuracao = "PAISAGEM"
            };


            DANFe.UnidanfeServices.Execute(config);

           
        }

        private static void EnviarEmailComAnexo(string destinatario, string assunto, string corpo, string caminhoPDF)
        {
            // ⚙️ Configuração do servidor SMTP (exemplo: Gmail)
            using (var smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["nascomercioMail"], ConfigurationManager.AppSettings["nascomercioPass"]);
                
                // ✉️ Monta a mensagem
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(ConfigurationManager.AppSettings["nascomercioMail"], "Sistema de Notas");
                    mail.To.Add(destinatario);
                    mail.Subject = assunto;
                    mail.Body = corpo;

                    if (File.Exists(caminhoPDF))
                        mail.Attachments.Add(new Attachment(caminhoPDF));

                    // 🚀 Envia o e-mail
                    smtp.Send(mail);
                }
            }
        }



        public string ConsultarCupom(Configuracao configuracao, string chaveAcesso)
        {

            configuracao.CodigoUF = 35; // Código da UF (São Paulo - SP). Adapte para a UF do emitente da NFC-e.


            var consSitNFe = new ConsSitNFe
            {
                Versao = "4.00",
                TpAmb = ConfigurationManager.AppSettings["TipoAmbiente"] == "1" ? TipoAmbiente.Producao : TipoAmbiente.Homologacao,
                ChNFe = chaveAcesso
            };

            //var ver = new Unimake.Business.DFe.Servicos.NFCe.ConsultaCadastro. Config.NFCe.Config.xml();


            var servico = new Unimake.Business.DFe.Servicos.NFCe.ConsultaProtocolo(consSitNFe, configuracao);

            // Executa a consulta
            servico.Executar();

            String retornoWs = servico.RetornoWSString; // XML raw de retorno do serviço
            // Verifica o resultado
            if (servico.Result.CStat == 100) // 100 = Autorizado, 150 = Autorizado e Denegado
            {
                retornoWs = servico.RetornoWSString;
            }
            else if (servico.Result.CStat == 217) // 217 = NFC-e não encontrada
            {
                retornoWs = servico.RetornoWSString;
            }
            else if (servico.Result.CStat == 150) // 225 = Chave de Acesso inválida
            {
                retornoWs = servico.RetornoWSString;
            }
            else
            {
                retornoWs = servico.RetornoWSString;
            }

            return retornoWs;
        }
        
        //USO
        public XmlNFe.NFe RecuperarProdutos(List<ProdutoVendido> dVendaProdutos, int nNF, Unimake.Business.DFe.Servicos.Configuracao configuracao, DarumaFrameworkSat configImposto, RetConsCad retConsCad, X509Certificate2 x509Cert, List<MeioPagamentoNascom> meiosPagamentos, string cpf, string controle)
        {

            var infCons = new InfCons
            {
                CNPJ = ConfigurationManager.AppSettings["CNPJ"],
                UF = UFBrasil.SP
            };

            var consCad = new ConsCad
            {
                Versao = "2.00",
                InfCons = infCons
            };

            // 2. Carregar o certificado
            var certificado = new CertificadoDigital
            {

            };


            var endereco = retConsCad.InfCons.InfCad.FirstOrDefault().Ender;

            int cListServInt;
            if (configImposto.Imposto.ISSQN.cListServ is string cListServStr)
            {
                cListServInt = int.TryParse(cListServStr, out var val) ? val : 0;
            }
            else
            {
                cListServInt = Convert.ToInt32(configImposto.Imposto.ISSQN.cListServ);
            }

            var nfe = new XmlNFe.NFe();
            nfe.InfNFe = new List<XmlNFe.InfNFe>();

            double valorTotal = dVendaProdutos.Sum(x => Math.Round((double)x.valor, 2, MidpointRounding.AwayFromZero));
            double valorTotalTributos = dVendaProdutos.Sum(x => Math.Round((double)x.valorTributacao, 2, MidpointRounding.AwayFromZero));


            var infe = new XmlNFe.InfNFe
            {
                //Id = "NFe" + chaveAcesso,
                Versao = "4.00",
                Ide = new XmlNFe.Ide
                {
                    NNF = XMLUtility.GerarCodigoNumerico(nNF),
                    CUF = UFBrasil.SP,
                    NatOp = "VENDA PRODUC.DO ESTABELEC",
                    Mod = ModeloDFe.NFCe,
                    Serie = 1,
                    DhEmi = DateTime.Now,
                    DhSaiEnt = DateTime.Now,
                    TpNF = TipoOperacao.Saida,
                    IdDest = DestinoOperacao.OperacaoInterna,
                    CMunFG = endereco.CMun,
                    TpImp = FormatoImpressaoDANFE.NFCeMensagemEletronica,
                    TpEmis = TipoEmissao.Normal,
                    TpAmb = ConfigurationManager.AppSettings["TipoAmbiente"] == "1" ? TipoAmbiente.Producao : TipoAmbiente.Homologacao,
                    FinNFe = FinalidadeNFe.Normal,
                    IndFinal = SimNao.Sim,
                    IndPres = IndicadorPresenca.OperacaoPresencial,
                    ProcEmi = ProcessoEmissao.AplicativoContribuinte,
                    VerProc = "TESTE 1.00",
                },

                Emit = new XmlNFe.Emit
                {
                    CNPJ = retConsCad.InfCons.CNPJ,
                    XNome = retConsCad.InfCons.InfCad.FirstOrDefault().XNome,
                    XFant = retConsCad.InfCons.InfCad.FirstOrDefault().XFant,
                    EnderEmit = new XmlNFe.EnderEmit
                    {
                        XLgr = endereco.XLgr,
                        Nro = endereco.Nro,
                        XBairro = endereco.XBairro,
                        CMun = endereco.CMun,
                        XMun = endereco.XMun,
                        UF = retConsCad.InfCons.UF,
                        CEP = endereco.CEP,
                        CPais = 1058,
                        XPais = "BRASIL"
                    },
                    IE = retConsCad.InfCons.InfCad.FirstOrDefault().IE,
                    IM = configImposto.Emit.IM,
                    CNAE = retConsCad.InfCons.InfCad.FirstOrDefault().CNAE,
                    CRT = CRT.SimplesNacional

                },


                Dest = RecDest(cpf),


                Det = addProdutos(configImposto, dVendaProdutos),


                Total = new XmlNFe.Total
                {
                    ICMSTot = new XmlNFe.ICMSTot
                    {
                        VBC = 0,
                        VICMS = 0,
                        VICMSDeson = 0,
                        VFCP = 0,
                        VBCST = 0,
                        VST = 0,
                        VFCPST = 0,
                        VFCPSTRet = 0,
                        VProd = valorTotal,
                        VFrete = 0,
                        VSeg = 0,
                        VDesc = 0,
                        VII = 0,
                        VIPI = 0,
                        VIPIDevol = 0,
                        VPIS = 0,
                        VCOFINS = 0,
                        VOutro = 0,
                        VNF = valorTotal,
                        VTotTrib = valorTotalTributos
                    }
                },
                Transp = new XmlNFe.Transp
                {
                    ModFrete = ModalidadeFrete.SemOcorrenciaTransporte
                },

                Pag = AdicionarPagamento(meiosPagamentos),
                InfAdic = RecuperarDadosAdicionais(retConsCad, controle),
                InfRespTec = new XmlNFe.InfRespTec
                {
                    CNPJ = "07925528000110",
                    XContato = "Alexandre Nogueira do Nascimento",
                    Email = "contato@nascom.com.br",
                    Fone = "1122369825"
                }
            };

            //nfe.InfNFeSupl = GerarQrCodeCorreto(infe.Chave);

            nfe.InfNFe.Add(infe);

            return nfe;

        }

        private static XmlNFe.Dest RecDest(string cpf)
        {

            if (string.IsNullOrEmpty(cpf))
            {
                return null;
            }

            return new XmlNFe.Dest
            {
                IndIEDest = IndicadorIEDestinatario.NaoContribuinte,
                CPF = cpf,
                XNome = ConfigurationManager.AppSettings["TipoAmbiente"] == "1" ? "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL" : "",
            };
        }

        private static InfAdic RecuperarDadosAdicionais(RetConsCad retConsCad, string controle)
        {
            string optanteSimples = retConsCad.InfCons.InfCad.FirstOrDefault().XRegApur == "SIMPLES NACIONAL" ? "Empresa optante pelo simples nacional, conforme lei compl. 128 de 19/12/2008;Permite o aproveitamento do credito de ICMS" : "";
            return new XmlNFe.InfAdic
            {
                InfCpl = $";CONTROLE: {controle};  {optanteSimples}"
            };
        }

        private static List<Det> addProdutos(DarumaFrameworkSat configImposto, List<ProdutoVendido> dVendaProdutos)
        {

            var lista = new List<Det>();

            foreach (var produto in dVendaProdutos)
            {

                lista.Add(new XmlNFe.Det
                {

                    NItem = produto.itemId,
                    Prod = new XmlNFe.Prod
                    {
                        CProd = produto.produtoId.ToString(),
                        CEAN = "SEM GTIN",
                        XProd = ConfigurationManager.AppSettings["TipoAmbiente"] == "1" ? produto.descricao : "NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL\r\n",
                        NCM = "84714900",
                        CFOP = "5101",
                        UCom = "LU",
                        QCom = produto.quantidade,
                        VUnCom = Math.Round(produto.valor, 4, MidpointRounding.AwayFromZero),
                        VProd = Math.Round((double)produto.valor, 4, MidpointRounding.AwayFromZero),
                        CEANTrib = "SEM GTIN",
                        UTrib = "LU",
                        QTrib = produto.quantidade,
                        VUnTrib = Math.Round(produto.valor, 4, MidpointRounding.AwayFromZero),
                        IndTot = SimNao.Sim,
                        XPed = produto.controle.ToString()
                    },
                    Imposto = new XmlNFe.Imposto
                    {
                        VTotTrib = Math.Round((double)produto.valorTributacao, 4, MidpointRounding.AwayFromZero),
                        ICMS = new XmlNFe.ICMS
                        {
                            ICMSSN102 = new XmlNFe.ICMSSN102
                            {
                                Orig = OrigemMercadoria.Nacional,
                                CSOSN = "102"
                            },
                        },
                        PIS = new XmlNFe.PIS
                        {
                            PISNT = new XmlNFe.PISNT
                            {
                                CST = configImposto.Imposto.PIS.PISNT.CST ?? "00"
                            },
                        },
                        COFINS = new XmlNFe.COFINS
                        {
                            COFINSNT = new XmlNFe.COFINSNT
                            {
                                CST = configImposto.Imposto.COFINS.COFINSNT.CST ?? "00"
                            },

                        }
                    }
                });
            }
            return lista;
        }

        public RetConsCad ConsultarCadastro(Configuracao configuracao, ConsCad consCad)
        {
            var consultaCadastro = new ConsultaCadastro(consCad, configuracao);
            consultaCadastro.Executar();

            // 4. Interpretando o resultado
            return consultaCadastro.Result;
        }

        public string ConsultarCupomNFCe()
        {
            throw new NotImplementedException();
        }

        public Pag AdicionarPagamento(List<MeioPagamentoNascom> meiosPagamentos)
        {
            var pag = new Pag();

            foreach (var meio in meiosPagamentos)
            {

                switch (meio.CodigoPagamento) 
                {
                    case "01":
                        // EXEMPLO: Dinheiro
                        pag.DetPag.Add(new DetPag
                        {
                            IndPag = IndicadorPagamento.PagamentoVista,
                            TPag = Unimake.Business.DFe.Servicos.MeioPagamento.Dinheiro,   // 01
                            VPag = meio.Valor
                        });

                        break;
                    case "02":
                        // EXEMPLO: Cheque/ cheque pré-datado

                        if (meio.DescricaoPagamento == "cheque")
                        {
                            pag.DetPag.Add(new DetPag
                            {
                                IndPag = IndicadorPagamento.PagamentoPrazo,
                                TPag = Unimake.Business.DFe.Servicos.MeioPagamento.Cheque,     // 02
                                VPag = meio.Valor
                            });
                        }
                        else
                            pag.DetPag.Add(new DetPag
                            {
                                TPag = Unimake.Business.DFe.Servicos.MeioPagamento.Cheque,     // 02
                                VPag = meio.Valor
                            });
                        break;
                    case "03":
                        // EXEMPLO: Cartão de Crédito
                        pag.DetPag.Add(new DetPag
                        {
                            IndPag = IndicadorPagamento.PagamentoPrazo,
                            TPag = Unimake.Business.DFe.Servicos.MeioPagamento.CartaoCredito,  // 03
                            VPag = meio.Valor,
                            Card = new Card
                            {
                                TpIntegra = TipoIntegracaoPagamento.PagamentoNaoIntegrado
                            }
                        });
                        break;
                    case "04":
                        // EXEMPLO: Cartão de Débito
                        pag.DetPag.Add(new DetPag
                        {
                            IndPag = IndicadorPagamento.PagamentoVista,
                            TPag = Unimake.Business.DFe.Servicos.MeioPagamento.CartaoDebito,  // 04
                            VPag = meio.Valor,
                            Card = new Card
                            {
                                TpIntegra = TipoIntegracaoPagamento.PagamentoNaoIntegrado
                            }
                        });
                        break;
                    case "05":
                        // EXEMPLO: Crédito Loja
                        pag.DetPag.Add(new DetPag
                        {
                            TPag = Unimake.Business.DFe.Servicos.MeioPagamento.CreditoLoja,   // 05
                            VPag = meio.Valor
                        });
                        break;
                    case "06":
                        // EXEMPLO: PIX
                        pag.DetPag.Add(new DetPag
                        {
                            IndPag = IndicadorPagamento.PagamentoVista,
                            TPag = Unimake.Business.DFe.Servicos.MeioPagamento.PagamentoInstantaneo,        // 06
                            VPag = meio.Valor,
                            Card = new Card
                            {
                                TpIntegra = TipoIntegracaoPagamento.PagamentoNaoIntegrado
                            }
                        });
                        break;
                    case "99":
                        pag.DetPag.Add(new DetPag
                        {
                            TPag = Unimake.Business.DFe.Servicos.MeioPagamento.ValePresente,        // 06
                            VPag = meio.Valor
                        });
                        break;
                    default:
                        pag.DetPag.Add(new DetPag
                        {
                            TPag = Unimake.Business.DFe.Servicos.MeioPagamento.Outros,        // 06
                            VPag = meio.Valor
                        });
                        break;
                }               

            }

            return pag;
        }


        void INFCe.ImprimirDANFe(string chave)
        {
            ImprimirDANFe(chave);
        }
        private string GerarUrlQrCode(string chaveAcesso, string versaoQrCode, int ambiente, string cIdToken, string csc)
        {
            // Formatar a URL do QR Code conforme padrão da Sefaz
            string urlBase = ambiente == 1 ?
                "http://www.sefaz.rs.gov.br/NFCE/NFCE-COM.aspx?" :
                "http://www.sefaz.rs.gov.br/NFCE/NFCE-COM.aspx?";

            return $"{urlBase}chNFe={chaveAcesso}&nVersao={versaoQrCode}&tpAmb={ambiente}&cIdToken={cIdToken}&cHashQRCode={CalcularHashQrCode(chaveAcesso, versaoQrCode, ambiente, cIdToken, csc)}";
        }

        //USO
        private string CalcularHashQrCode(string chaveAcesso, string versaoQrCode, int ambiente, string cIdToken, string csc)
        {
            // Concatenar os dados para o hash
            string dados = chaveAcesso + "|" + versaoQrCode + "|" + ambiente + "|" + cIdToken;

            // Calcular o SHA1 (exemplo simplificado)
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                var hash = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(dados + csc));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
        // Add a method to generate the URL for the QR Code

    }
}
