using LibNF65.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using Unimake.Business.DFe;
using Unimake.Business.DFe.Security;
using Unimake.Business.DFe.Servicos;
using Unimake.Business.DFe.Servicos.NFCe;
using Unimake.Business.DFe.Utility;
using Unimake.Business.DFe.Xml.NFe;
using Unimake.Security.Platform;
using Configuracao = Unimake.Business.DFe.Servicos.Configuracao;
using DANFe = Unimake.Unidanfe;
using ServicoNFCe = Unimake.Business.DFe.Servicos.NFCe;
using XmlNFe = Unimake.Business.DFe.Xml.NFe;

namespace LibNF65
{
    //X509Certificate2 x509Cert;
    //static string chaveAcesso = string.Empty;
    public class NasNFCe : INFCe
    {


        public void EventoCancelamentoNFCe(string chave, X509Certificate2 x509Cert)
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
                            NProt = "141190000660363",
                            Versao = "1.00",
                            XJust = "Justificativa de teste de cancelamento"
                        })
                        {
                            COrgao = UFBrasil.SP,
                            ChNFe = chave,
                            CNPJ = "36650283000164",
                            DhEvento = DateTime.Now,
                            TpEvento = TipoEventoNFe.Cancelamento,
                            NSeqEvento = 1,
                            VerEvento = "1.00",
                            TpAmb = TipoAmbiente.Homologacao
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

            if (recepcaoEvento.Result.CStat == 128) //Lote de evento processado com sucesso
            {
                switch (recepcaoEvento.Result.RetEvento[0].InfEvento.CStat)
                {
                    case 135: //Evento homologado
                    case 155: //Evento homologado fora do prazo permitido
                        recepcaoEvento.GravarXmlDistribuicao(@"d:\testenfe");
                        break;

                    default:
                        //Tratamentos necessários quando o evento é rejeitado
                        break;
                }
            }
        }

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

        // Fix for CS0117 and CS0234

        // Assuming that the correct configuration class is available in the Unimake.Unidanfe.Configurations namespace
        // and that the property name is different, you need to replace the incorrect usage with the correct one.

        public void ImprimirDANFe(string chave)
        {
            var config = new DANFe.Configurations.UnidanfeConfiguration
            {
                Arquivo = "C:\\Users\\jjail\\Projetos\\NFCeProject\\bin\\Debug\\net8.0\\35251036650283000164650011234798751297237815-procnfe.xml",
                Visualizar = true,
                Imprimir = false,
                EnviaEmail = false,
                PastaLocalQRCode = "C:\\Users\\jjail\\Projetos\\NFCeProject\\bin\\Debug\\net8.0\\",
                Configuracao = "PAISAGEM"
            };

            DANFe.UnidanfeServices.Execute(config);
        }
        public string ImprimirPDF(string chaveNFCe)
        {

            //var impressaoService = new ImpressaoCupomConsulta();

            //if (chaveNFCe.Length == 44)
            //{
            //    impressaoService.ConsultarEImprimirCupom(chaveNFCe);
            //}
            //else
            //{

            //}

            return "";

        }

        public string ConsultarCupom(Configuracao configuracao, string chaveAcesso)
        {

            configuracao.CodigoUF = 35; // Código da UF (São Paulo - SP). Adapte para a UF do emitente da NFC-e.


            var consSitNFe = new ConsSitNFe
            {
                Versao = "4.00",
                TpAmb = TipoAmbiente.Homologacao,
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
        public XmlNFe.NFe RecuperarProdutos(List<ProdutoVendido> dVendaProdutos, int nNF, Unimake.Business.DFe.Servicos.Configuracao configuracao, DarumaFrameworkSat configImposto)
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

            X509Certificate2 x509Cert = certificado.CarregarCertificadoDigitalA1(configuracao.CertificadoArquivo, configuracao.CertificadoSenha);

            // 3. Executando a consulta
            var consultaCadastro = new ConsultaCadastro(consCad, configuracao);
            consultaCadastro.Executar();

            // 4. Interpretando o resultado
            var resultado = consultaCadastro.Result; // Retorno do objeto
            var retornoWs = consultaCadastro.RetornoWSString; // XML raw

            var endereco = resultado.InfCons.InfCad.FirstOrDefault().Ender;

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

            double valorTotal = 0;

            foreach (var produto in dVendaProdutos)
            {
                valorTotal += double.Parse(produto.valor.ToString());

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
                        TpAmb = TipoAmbiente.Homologacao,
                        FinNFe = FinalidadeNFe.Normal,
                        IndFinal = SimNao.Sim,
                        IndPres = IndicadorPresenca.OperacaoPresencial,
                        ProcEmi = ProcessoEmissao.AplicativoContribuinte,
                        VerProc = "TESTE 1.00",
                    },

                    Emit = new XmlNFe.Emit
                    {
                        CNPJ = resultado.InfCons.CNPJ,
                        XNome = resultado.InfCons.InfCad.FirstOrDefault().XNome,
                        XFant = resultado.InfCons.InfCad.FirstOrDefault().XFant,
                        EnderEmit = new XmlNFe.EnderEmit
                        {
                            XLgr = endereco.XLgr,
                            Nro = endereco.Nro,
                            XBairro = endereco.XBairro,
                            CMun = endereco.CMun,
                            XMun = endereco.XMun,
                            UF = resultado.InfCons.UF,
                            CEP = endereco.CEP,
                            CPais = 1058,
                            XPais = "BRASIL"
                        },
                        IE = resultado.InfCons.InfCad.FirstOrDefault().IE,
                        IM = "14018",
                        CNAE = resultado.InfCons.InfCad.FirstOrDefault().CNAE,
                        CRT = CRT.SimplesNacional

                    },
                    Dest = new XmlNFe.Dest
                    {
                        IndIEDest = IndicadorIEDestinatario.NaoContribuinte,
                        CNPJ = "22016905000192",
                        XNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL",
                        EnderDest = new XmlNFe.EnderDest
                        {
                            XLgr = "AVENIDA TESTE",
                            Nro = "9999",
                            XBairro = "CENTRO",
                            CMun = 3550308,
                            XMun = "SAO PAULO",
                            UF = UFBrasil.SP,
                            CEP = "01001000",
                            CPais = 1058,
                            XPais = "BRASIL"
                        },
                        Email = ""
                    },
                    Det = new List<XmlNFe.Det> {
                                    new XmlNFe.Det
                                    {

                                        NItem = 1,
                                        Prod = new XmlNFe.Prod
                                        {
                                            CProd = produto.produtoId.ToString(),
                                            CEAN = produto.codigobarras,
                                            XProd = produto.descricao,
                                            NCM = "84714900", 
                                            CFOP = "5101",
                                            UCom = "LU",
                                            QCom = produto.quantidade,
                                            VUnCom = decimal.Parse(produto.valor.ToString()),
                                            VProd = double.Parse(produto.valor.ToString()),
                                            CEANTrib = "SEM GTIN",
                                            UTrib = "LU",
                                            QTrib = 1.00m,
                                            VUnTrib = 84.9000000000M,
                                            IndTot = SimNao.Sim,
                                            XPed = "300474",
                                            NItemPed = produto.itemId.ToString()
                                        },
                                        Imposto = new XmlNFe.Imposto
                                        {
                                            VTotTrib = 12.63,
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
                                    }
                                },

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
                            VTotTrib = 12.63
                        }
                    },
                    Transp = new XmlNFe.Transp
                    {
                        ModFrete = ModalidadeFrete.SemOcorrenciaTransporte
                    },

                    Pag = new XmlNFe.Pag
                    {
                        DetPag = new List<XmlNFe.DetPag>
                                    {
                                            new XmlNFe.DetPag
                                            {
                                                IndPag = IndicadorPagamento.PagamentoVista,
                                                TPag = MeioPagamento.PagamentoInstantaneo,
                                                VPag = valorTotal,
                                                Card = new Card()
                                                {
                                                    TpIntegra = TipoIntegracaoPagamento.PagamentoNaoIntegrado
                                                }
                                            }
                                    }
                    },
                    InfAdic = new XmlNFe.InfAdic
                    {
                        InfCpl = ";CONTROLE: 0000241197;PEDIDO(S) ATENDIDO(S): 300474;Empresa optante pelo simples nacional, conforme lei compl. 128 de 19/12/2008;Permite o aproveitamento do credito de ICMS no valor de R$ 2,40, correspondente ao percentual de 2,83% . Nos termos do Art. 23 - LC 123/2006 (Resolucoes CGSN n. 10/2007 e 53/2008);Voce pagou aproximadamente: R$ 6,69 trib. federais / R$ 5,94 trib. estaduais / R$ 0,00 trib. municipais. Fonte: IBPT/empresometro.com.br 18.2.B A3S28F;",
                    },
                    InfRespTec = new XmlNFe.InfRespTec
                    {
                        CNPJ = "07925528000110",
                        XContato = "Alexandre Nogueira do Nascimento",
                        Email = "contato@nascom.com.br",
                        Fone = "(11)2236-9825"
                    }
                };

                //nfe.InfNFeSupl = GerarQrCodeCorreto(infe.Chave);

                nfe.InfNFe.Add(infe);
            }



            return nfe;

        }

        public InfNFeSupl GerarQrCodeCorreto(string chave)
        {
            string chaveAcesso = chave;
            int tpAmb = 2; // Homologação
            string versaoQrCode = "2";

            // Formato CORRETO para QR Code NFCe
            string qrCode = GerarUrlQrCodeNFCe(chaveAcesso, tpAmb, versaoQrCode);

            return new InfNFeSupl
            {
                QrCode = DanfeQrCodeGenerator.GerarDanfeComQrCode(),
            };
        }

        private string GerarUrlQrCodeNFCe(string chaveAcesso, int tpAmb, string versaoQrCode)
        {
            // Formato 1: Padrão nacional (recomendado)
            string urlQrCode = $"https://dfe-portal.svrs.rs.gov.br/nfce/qrcode?p={chaveAcesso}|{versaoQrCode}|{tpAmb}|1|12";

            // Formato 2: Alternativo para algumas UFs
            // string urlQrCode = $"http://dec.fazenda.df.gov.br/NFCE/NFCE-COM.aspx?p={chaveAcesso}|{versaoQrCode}|{tpAmb}|1|12";

            return urlQrCode;
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

        public void EnviarNFCe(string caminhoCertificado, string senhaCertificado, string cnpjEmissor, List<ProdutoVendido> Produtos)
        {
            var configuracao = new Unimake.Business.DFe.Servicos.Configuracao
            {
                TipoDFe = TipoDFe.NFCe,
                CertificadoArquivo = caminhoCertificado,
                CertificadoSenha = senhaCertificado,
                TipoAmbiente = TipoAmbiente.Homologacao,
                UsaCertificadoDigital = true,
                CSC = "HCJBIRTWGCQ3HVQN7DCA0ZY0P2NYT6FVLPJG",
                CSCIDToken = 2,
                SchemaVersao = "4.00"
            };
            var infCons = new InfCons
            {
                CNPJ = cnpjEmissor,
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

            X509Certificate2 x509Cert = certificado.CarregarCertificadoDigitalA1(caminhoCertificado, senhaCertificado);

            // 3. Executando a consulta
            var consultaCadastro = new ConsultaCadastro(consCad, configuracao);
            consultaCadastro.Executar();

            // 4. Interpretando o resultado
            var resultado = consultaCadastro.Result; // Retorno do objeto
            var retornoWs = consultaCadastro.RetornoWSString; // XML raw

            var endereco = resultado.InfCons.InfCad.FirstOrDefault().Ender;

            string cUF = "35"; // Código da UF do emitente (SP = 35)
            DateTime dhEmi = DateTime.Now; // Data e hora de emissão
            string cnpjEmitente = resultado.InfCons.CNPJ; // CNPJ do emitente (14 dígitos)


            int serie = 1; // Série da nota fiscal
            int nNF = 123456789; // Número da nota fiscal
            int cNF = XMLUtility.GerarCodigoNumerico(nNF); // Código Numérico Aleatório (cNF)

            var conteudoChave = new XMLUtility.ConteudoChaveDFe
            {

            };
            conteudoChave.UFEmissor = (UFBrasil)Enum.Parse(typeof(UFBrasil), cUF);
            conteudoChave.TipoEmissao = TipoEmissao.Normal;
            conteudoChave.Modelo = ModeloDFe.NFCe;
            conteudoChave.Serie = serie;
            conteudoChave.CodigoNumerico = XMLUtility.GerarCodigoNumerico(nNF).ToString();
            conteudoChave.CNPJCPFEmissor = cnpjEmitente;
            conteudoChave.NumeroDoctoFiscal = nNF;
            conteudoChave.AnoEmissao = DateTime.Now.ToString("yy");
            conteudoChave.MesEmissao = DateTime.Now.ToString("MM");

            // Gerar chave de acesso
            var chaveAcesso = XMLUtility.MontarChaveNFe(ref conteudoChave);
            double valorTotal = 0;

            var lista = new List<XmlNFe.Det>
                {
                new XmlNFe.Det()
            };
            foreach (var prod in Produtos)
            {
                // Processar produtos

                var det = new XmlNFe.Det
                {

                    NItem = 1,
                    Prod = new XmlNFe.Prod
                    {
                        CProd = prod.produtoId.ToString(),
                        CEAN = prod.codigobarras,
                        XProd = prod.descricao,
                        //NCM = prod.valor ,
                        //CFOP = prod.CFOP,
                        //UCom = prod.UCom,
                        //QCom = prod.QCom,
                        //VUnCom = prod.VUnCom,
                        //VProd = prod.VProd,
                        //CEANTrib = prod.CEANTrib,
                        //UTrib = prod.UTrib,
                        //QTrib = prod.QTrib,
                        //VUnTrib = prod.VUnTrib,
                        //IndTot = prod.IndTot,
                        //XPed = prod.XPed,
                        NItemPed = prod.itemId.ToString()
                    },
                    Imposto = new XmlNFe.Imposto
                    {
                        VTotTrib = 12.63,
                        ICMS = new XmlNFe.ICMS
                        {
                            ICMSSN102 = new XmlNFe.ICMSSN102
                            {
                                Orig = OrigemMercadoria.Nacional,
                                CSOSN = "102"
                            }
                        },
                        PIS = new XmlNFe.PIS
                        {
                            PISOutr = new XmlNFe.PISOutr
                            {
                                CST = "99",
                                VBC = 0.00,
                                PPIS = 0.00,
                                VPIS = 0.00
                            }
                        },
                        COFINS = new XmlNFe.COFINS
                        {
                            COFINSOutr = new XmlNFe.COFINSOutr
                            {
                                CST = "99",
                                VBC = 0.00,
                                PCOFINS = 0.00,
                                VCOFINS = 0.00
                            }
                        }
                    }
                };


                lista.Add(det);

                valorTotal += double.Parse(prod.valor.ToString());
            }
            var xml = new XmlNFe.EnviNFe
            {
                Versao = "4.00",
                IdLote = "000000000000001",
                IndSinc = SimNao.Sim,
                NFe = new List<XmlNFe.NFe>
                {
                    new XmlNFe.NFe
                    {
                        InfNFe = new List<XmlNFe.InfNFe>
                        {
                            new XmlNFe.InfNFe
                            {
                                Versao = "4.00",
                                Ide = new XmlNFe.Ide
                                {
                                    CUF = UFBrasil.SP,
                                    NatOp = "VENDA PRODUC.DO ESTABELEC",
                                    Mod = ModeloDFe.NFCe,
                                    Serie = 1,
                                    NNF = 57980,
                                    DhEmi = DateTime.Now,
                                    DhSaiEnt = DateTime.Now,
                                    TpNF = TipoOperacao.Saida,
                                    IdDest = DestinoOperacao.OperacaoInterna,
                                    CMunFG = endereco.CMun,
                                    TpImp = FormatoImpressaoDANFE.NFCeMensagemEletronica,
                                    TpEmis = TipoEmissao.Normal,
                                    TpAmb = TipoAmbiente.Homologacao,
                                    FinNFe = FinalidadeNFe.Normal,
                                    IndFinal = SimNao.Sim,
                                    IndPres = IndicadorPresenca.OperacaoPresencial,
                                    ProcEmi = ProcessoEmissao.AplicativoContribuinte,
                                    VerProc = "TESTE 1.00"
                                },

                                Emit = new XmlNFe.Emit
                                {
                                    CNPJ = resultado.InfCons.CNPJ,
                                    XNome = resultado.InfCons.InfCad.FirstOrDefault().XNome,
                                    XFant = resultado.InfCons.InfCad.FirstOrDefault().XFant,
                                    EnderEmit = new XmlNFe.EnderEmit
                                    {
                                        XLgr = endereco.XLgr,
                                        Nro = endereco.Nro,
                                        XBairro = endereco.XBairro,
                                        CMun = endereco.CMun,
                                        XMun = endereco.XMun,
                                        UF = resultado.InfCons.UF,
                                        CEP = endereco.CEP,
                                        CPais = 1058,
                                        XPais = "BRASIL"
                                    },
                                    IE = resultado.InfCons.InfCad.FirstOrDefault().IE,
                                    IM = "14018",
                                    CNAE = resultado.InfCons.InfCad.FirstOrDefault().CNAE,
                                    CRT = CRT.SimplesNacional
                                },
                                Det = lista,

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
                                        VTotTrib = 12.63
                                    }
                                },
                                Transp = new XmlNFe.Transp
                                {
                                    ModFrete = ModalidadeFrete.SemOcorrenciaTransporte
                                },
                                Pag = new XmlNFe.Pag
                                {
                                    DetPag = new List<XmlNFe.DetPag>
                                    {
                                            new XmlNFe.DetPag
                                            {
                                                IndPag = IndicadorPagamento.PagamentoVista,
                                                TPag = MeioPagamento.PagamentoInstantaneo,
                                                VPag = 84.90,
                                                Card = new Card()
                                                {
                                                    TpIntegra = TipoIntegracaoPagamento.PagamentoNaoIntegrado
                                                }
                                            }
                                    }
                                },
                                InfAdic = new XmlNFe.InfAdic
                                {
                                    InfCpl = ";CONTROLE: 0000241197;PEDIDO(S) ATENDIDO(S): 300474;Empresa optante pelo simples nacional, conforme lei compl. 128 de 19/12/2008;Permite o aproveitamento do credito de ICMS no valor de R$ 2,40, correspondente ao percentual de 2,83% . Nos termos do Art. 23 - LC 123/2006 (Resolucoes CGSN n. 10/2007 e 53/2008);Voce pagou aproximadamente: R$ 6,69 trib. federais / R$ 5,94 trib. estaduais / R$ 0,00 trib. municipais. Fonte: IBPT/empresometro.com.br 18.2.B A3S28F;",
                                },
                                InfRespTec = new XmlNFe.InfRespTec
                                {
                                    CNPJ = "07925528000110",
                                    XContato = "Alexandre Nogueira do Nascimento",
                                    Email = "contato@nascom.com.br",
                                    Fone = "1122369825"
                                }
                            }
                        }
                    }
                }
            };



            var xmlString = XMLUtility.Serializar<XmlNFe.NFe>(xml.NFe.First());

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString.InnerXml);

            AssinaturaDigital.Assinar(xmlDoc, "infNFe", x509Cert, AlgorithmType.Sha1, false);

            bool validar = true;
            if (validar)
            {
                var validador = new ValidarSchema();
                validador.Validar(xmlString, "NFCe");
            }


            var autorizacao = new ServicoNFCe.Autorizacao(xml, configuracao);
            autorizacao.Executar();


            if (autorizacao.Result.ProtNFe != null)
            {
                switch (autorizacao.Result.ProtNFe.InfProt.CStat)
                {
                    case 100: //Autorizado o uso da NFe
                    case 110: //Uso Denegado
                    case 150: //Autorizado o uso da NF-e, autorização fora de prazo
                    case 205: //NF-e está denegada na base de dados da SEFAZ [nRec:999999999999999]
                    case 301: //Uso Denegado: Irregularidade fiscal do emitente
                    case 302: //Uso Denegado: Irregularidade fiscal do destinatário
                    case 303: //Uso Denegado: Destinatário não habilitado a operar na UF
                        autorizacao.GravarXmlDistribuicao(@"c:\testenfe\");
                        //var docProcNFe = autorizacao.NfeProcResult.GerarXML(); //Gerar o Objeto para pegar a string e gravar em banco de dados

                        //Como é assíncrono, tenho que prever a possibilidade de ter mais de uma NFe no lote, então teremos vários XMLs com protocolos.
                        //Se no seu caso vc enviar sempre uma única nota, só vai passar uma única vez no foreach
                        foreach (var item in autorizacao.NfeProcResults.Values)
                        {
                            var docProcNFe = item.GerarXML();
                            var stringXml = docProcNFe.OuterXml;
                        }

                        break;

                    default:
                        //NF Rejeitada
                        break;
                }
            }
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
