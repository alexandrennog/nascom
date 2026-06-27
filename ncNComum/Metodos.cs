using System;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Text;

namespace ncNComum.DFW
{
    public class Declaracoes
    {
        public static int iRetorno;
        public static string sBuffer = string.Empty;
        public static string Str_LabelInputBox, Str_TextoInputBox, Str_Retorno_InputBox;
        public static string Str_Aleatorio;
        public static int iAleatorio;

        public static string InputBox(string LB_stringInputBox, string TB_InputBox)
        {
            Str_LabelInputBox = string.Empty;
            Str_TextoInputBox = string.Empty;
            Str_Retorno_InputBox = string.Empty;
            Str_LabelInputBox = LB_stringInputBox;
            Str_TextoInputBox = TB_InputBox;
            return Str_Retorno_InputBox;
        }

        public static string TrataRetorno(int intRetorno)
        {
            var Str_Msg_Retorno_Metodo = new StringBuilder(" ", 300);
            var Str_Msg_NumErro = new StringBuilder(" ", 300);
            var Str_Msg_NumAviso = new StringBuilder(" ", 300);

            if (ConfigurationManager.AppSettings["FISCAL"] == "ECF")
            {
                eRetornarAvisoErroUltimoCMD_ECF_Daruma(Str_Msg_NumAviso, Str_Msg_NumErro);
                eInterpretarRetorno_ECF_Daruma(intRetorno, Str_Msg_Retorno_Metodo);
                return Str_Msg_Retorno_Metodo.ToString() + "\r\n" + "Num.Erro = " + Str_Msg_NumErro.ToString() + "\r\n" + "Num.Aviso= " + Str_Msg_NumAviso.ToString();
            }
            else if (ConfigurationManager.AppSettings["FISCAL"] == "SAT")
            {
                return NaoFiscal_Mostrar_Retorno(intRetorno);
            }
            else
            {
                return intRetorno.ToString();
            }
        }

        #region Métodos DarumaFramework

        [DllImport("DarumaFrameWork.dll")]
        public static extern int eDefinirProduto_Daruma(string sProduto);

        [DllImport("DarumaFrameWork.dll")]
        public static extern int regSintegra_ECF_Daruma(string sChave, string sValor);

        #endregion

        #region Métodos DUAL

        public static string NaoFiscal_Mostrar_Retorno(int iRetorno)
        {
            if (iRetorno != 1)
            {
                switch (iRetorno)
                {
                    case 0: return "[0] - Método não executado/ Tag inválida/ Não foi possível comunicar com impressora";
                    case -6: return "[-6] - TimeOut, erro de comunicação com o SAT";
                    case -7: return "[-7] - Erro ao abrir comunicação com o SAT";
                    case -40: return "[-40] - Tag XML inválida";
                    case -50: return "[-50] - Impressora off-Line";
                    case -51: return "[-51] - Impressora sem papel";
                    case -99: return "[-99] - Parâmetro inválido ou ponteiro nulo de parâmetro";
                    case -120: return "[-120] - Encontrada tag inválida";
                    case -121: return "[-121] - Estrutura Invalida";
                    case -122: return "[-122] - Tag obrigatória não foi informada";
                    case -123: return "[-123] - Tag obrigatória não tem valor preenchido";
                    case -130: return "[-130] - CFe já aberto";
                    case -131: return "[-131] - CFe não aberto";
                    case -132: return "[-132] - CFe não em fase de venda";
                    case -133: return "[-133] - CFe não em fase de totalização";
                    case -134: return "[-134] - CFe não em fase de pagamento";
                    case -135: return "[-135] - CFe não em fase de encerramento";
                    case -136: return "[-136] - CFe em estado inválido para operação";
                    case -140: return "[-140] - Biblioteca auxiliar SAT.dll não foi encontrada/carregada";
                    case -141: return "[-141] - Impressora inválida (modelo deve ser DR700 ou versão incompativel)";
                    case -142: return "[-142] - Resposta Incompleta do SAT";
                    case 1084: return "[1084] - Formato do Certificado Inválido";
                    case 1085: return "[1085] - Assinatura do Aplicativo Comercial não confere";
                    case 1218: return "[1218] - CF-e-SAT Já está cancelado";
                    case 1412: return "[1412] - CFe de cancelamento não corresponde a um CFe emitido nos 30 minutos anteriores ao pedido de cancelamento";
                    case 1999: return "[1999] - Erro desconhecido";
                    case 6001: return "[6001] - Código de ativação inválido";
                    case 6002: return "[6002] - SAT ainda não ativado";
                    case 6003: return "[6003] - SAT não vinculado ao AC";
                    case 6004: return "[6004] - Vinculação do AC não confere";
                    case 6005: return "[6005] - Tamanho do CFe superior a 1500KB";
                    case 6006: return "[6006] - SAT bloqueado pelo contribuinte";
                    case 6007: return "[6007] - SAT bloqueado pela SEFAZ";
                    case 6008: return "[6008] - SAT bloqueado por falta de comunicação";
                    case 6009: return "[6009] - SAT bloqueado, código de ativação incorreto";
                    case 6010: return "[6010] - Erro de validação do conteúdo";
                    case 6098: return "[6098] - SAT em processamento. Tente novamente";
                    case 6099: return "[6099] - Erro desconhecido";
                    case 7001: return "[7001] - Código de ativação inválido";
                    case 7002: return "[7002] - Cupom Inválido";
                    case 7003: return "[7003] - SAT bloqueado pelo contribuinte";
                    case 7004: return "[7004] - SAT bloqueado pela SEFAZ";
                    case 7005: return "[7005] - SAT bloqueado por falta de comunicação";
                    case 7006: return "[7006] - SAT bloqueado, código de ativação incorreto";
                    case 7007: return "[7007] - Erro de validação do conteúdo";
                    case 7098: return "[7098] - SAT em processamento. Tente novamente";
                    case 7099: return "[7099] - Erro desconhecido";
                    case 8098: return "[8098] - SAT em processamento. Tente novamente";
                    case 8099: return "[8099] - Erro desconhecido";
                    case 10001: return "[10001] - Código de ativação inválido";
                    case 10098: return "[10098] - SAT em processamento. Tente novamente";
                    case 10099: return "[10099] - Erro desconhecido";
                    case 13001: return "[13001] - Código de ativação inválido";
                    case 13002: return "[13002] - Erro de comunicação com a SEFAZ";
                    case 13003: return "[13003] - Assinatura fora do padrão informado";
                    case 13098: return "[13098] - SAT em processamento. Tente novamente";
                    case 13099: return "[13099] - Erro desconhecido";
                    default: return "Retorno não esperado!";
                }
            }
            return string.Empty;
        }

        [DllImport("DarumaFrameWork.dll")] public static extern int iEnviarBMP_DUAL_DarumaFramework(string stArqOrigem);
        [DllImport("DarumaFrameWork.dll")] public static extern int iImprimirArquivo_DUAL_DarumaFramework(string stPath);
        [DllImport("DarumaFrameWork.dll")] public static extern int eAcionarGaveta_DUAL_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int rStatusGaveta_DUAL_DarumaFramework(ref int iStatusGaveta);
        [DllImport("DarumaFrameWork.dll")] public static extern int rStatusDocumento_DUAL_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int rStatusImpressora_DUAL_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int regVelocidade_DUAL_DarumaFramework(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regTermica_DUAL_DarumaFramework(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regTabulacao_DUAL_DarumaFramework(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regPortaComunicacao_DUAL_DarumaFramework(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regModoGaveta_DUAL_DarumaFramework(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regLinhasGuilhotina_DUAL_DarumaFramework(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regEnterFinal_DUAL_DarumaFramework(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regAguardarProcesso_DUAL_DarumaFramework(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int iImprimirTexto_DUAL_DarumaFramework(string stTexto, int iTam);
        [DllImport("DarumaFrameWork.dll")] public static extern int iAutenticarDocumento_DUAL_DarumaFramework(string stTexto, string stLocal, string stTimeOut);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCodePageAutomatico_DUAL_DarumaFramework(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regZeroCortado_DUAL_DarumaFramework(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int eBuscarPortaVelocidade_DUAL_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int rConsultaStatusImpressora_DUAL_DarumaFramework(string pszIndice, string pszTipoRetorno, StringBuilder pszRetornar);
        [DllImport("DarumaFrameWork.dll")] public static extern int rStatusGuilhotina_DUAL_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int iImprimirBMP_DUAL_DarumaFramework(string pszArqOrigem);
        [DllImport("DarumaFrameWork.dll")] public static extern int eGerarQrCodeArquivo_DUAL_DarumaFramework(string pszPath, string pszDados);
        [DllImport("DarumaFrameWork.dll")] public static extern int iConfigurarGuilhotina_DUAL_DarumaFramework(int iHabilitar, int iQtdeLinha);

        #endregion

        #region Métodos TA2000

        [DllImport("DarumaFrameWork.dll")] public static extern int iEnviarDadosFormatados_TA2000_Daruma(string szTexto, StringBuilder szRetorno);
        [DllImport("DarumaFrameWork.dll")] public static extern int regPorta_TA2000_Daruma(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regAuditoria_TA2000_Daruma(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regMensagemBoasVindasLinha1_TA2000_Daruma(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regMensagemBoasVindasLinha2_TA2000_Daruma(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regMarcadorOpcao_TA2000_Daruma(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regMascara_TA2000_Daruma(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regMascaraLetra_TA2000_Daruma(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regMascaraNumero_TA2000_Daruma(string stParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regMascaraEco_TA2000_Daruma(string stParametro);

        #endregion

        #region Métodos Modem

        [DllImport("DarumaFrameWork.dll")] public static extern int regLerApagar_MODEM_DarumaFramework(string sParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regPorta_MODEM_DarumaFramework(string sParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regThread_MODEM_DarumaFramework(string sParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regVelocidade_MODEM_DarumaFramework(string sParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regTempoAlertar_MODEM_DarumaFramework(string sParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCaptionWinAPP_MODEM_DarumaFramework(string sParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regBandejaInicio_MODEM_DarumaFramework(string sParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int eInicializar_MODEM_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int eTrocarBandeja_MODEM_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int eApagarSms_MODEM_DarumaFramework(string iNumeroSMS);
        [DllImport("DarumaFrameWork.dll")] public static extern int rListarSms_MODEM_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int rListarSMSTelefone_MODEM_DarumaFramework(string sTelefone);
        [DllImport("DarumaFrameWork.dll")] public static extern int rNivelSinalRecebido_MODEM_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int rReceberSmsIndice_MODEM_DarumaFramework(StringBuilder sIndiceSMS, StringBuilder sNumFone, StringBuilder sData, StringBuilder sHora, StringBuilder sMsg);
        [DllImport("DarumaFrameWork.dll")] public static extern int rRetornarIDSIM_MODEM_DarumaFramework(StringBuilder sIDSIM);
        [DllImport("DarumaFrameWork.dll")] public static extern int rReceberSms_MODEM_DarumaFramework(StringBuilder sIndiceSMS, StringBuilder sNumFone, StringBuilder sData, StringBuilder sHora, StringBuilder sMsg);
        [DllImport("DarumaFrameWork.dll")] public static extern int rRetornarImei_MODEM_DarumaFramework(StringBuilder sImei);
        [DllImport("DarumaFrameWork.dll")] public static extern int rRetornarOperadora_MODEM_DarumaFramework(StringBuilder sOperadora);
        [DllImport("DarumaFrameWork.dll")] public static extern int rSmsIndices_MODEM_DarumaFramework(int Int_TipoSMS, string Str_Separador, StringBuilder Str_Indices);
        [DllImport("DarumaFrameWork.dll")] public static extern int tEnviarSms_MODEM_DarumaFramework(string sNumeroTelefone, string sMensagem);
        [DllImport("DarumaFrameWork.dll")] public static extern int tEnviarDadosCsd_MODEM_DarumaFramework(string sParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int rReceberDadosCsd_MODEM_DarumaFramework(string sParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int eAtivarConexaoCsd_MODEM_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int eFinalizarChamadaCsd_MODEM_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int eRealizarChamadaCsd_MODEM_DarumaFramework(string sParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int eBuscarPortaVelocidade_MODEM_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int eReiniciar_MODEM_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int tEnviarSmsOperadora_MODEM_DarumaFramework(string sNumeroTelefone, string sOperadora, string sMensagem);
        [DllImport("DarumaFrameWork.dll")] public static extern int rInfoEstendida_MODEM_DarumaFramework(StringBuilder sInfoEstendida);
        [DllImport("DarumaFrameWork.dll")] public static extern int rTotalSms_MODEM_DarumaFramework(int iTipoSMS, ref int iQuantSMS);
        [DllImport("DarumaFrameWork.dll")] public static extern int rLerSmsConfirmacao_MODEM_DarumaFramework(int iIndiceMsg, StringBuilder sMsg);
        [DllImport("DarumaFrameWork.dll")] public static extern int rReceberNotificacao_MODEM_DarumaFramework(string sNumeroOperadora, StringBuilder sRetorno);
        [DllImport("DarumaFrameWork.dll")] public static extern int rRetornarNumeroChamada_MODEM_DarumaFramework(ref StringBuilder sResposta);
        [DllImport("DarumaFrameWork.dll")] public static extern int eConfigurarServidorGprs_MODEM_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int eAtivarServidorGprs_MODEM_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int eAguardarConexaoGprs_MODEM_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int eConfigurarClienteGprs_MODEM_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int eRealizarConexaoClienteGprs_MODEM_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int rObterStatusConexaoGprs_MODEM_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int eFinalizarConexaoGprs_MODEM_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int rObterIpConexaoGprs_MODEM_DarumaFramework(StringBuilder sIpConexao);
        [DllImport("DarumaFrameWork.dll")] public static extern int rReceberDadosGprs_MODEM_DarumaFramework(StringBuilder sRespostaGprs);
        [DllImport("DarumaFrameWork.dll")] public static extern int tEnviarDadosGprs_MODEM_DarumaFramework(string sDados);

        #endregion

        #region Display

        [DllImport("DarumaFrameWork.dll")] public static extern int iCursorLigar_DSP_DarumaFramework(int iHabilitar);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCursorMover_DSP_DarumaFramework(int iPosicoes);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCursorMoverAbaixo_DSP_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCursorMoverAcima_DSP_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCursorPosicionar_DSP_DarumaFramework(int iX, int iY);
        [DllImport("DarumaFrameWork.dll")] public static extern int iLimpar_DSP_DarumaFramework(int iLinha);
        [DllImport("DarumaFrameWork.dll")] public static extern int iResetar_DSP_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int iIniciarMsgPromo_DSP_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int iEncerrarMsgPromo_DSP_DarumaFramework();
        [DllImport("DarumaFrameWork.dll")] public static extern int iEnviarTexto_DSP_DarumaFramework(string sTexto);

        #endregion

        #region Generico

        [DllImport("DarumaFrameWork.dll")] public static extern int eAbrirSerial_Daruma(string sPorta, string sVelocidade);
        [DllImport("DarumaFrameWork.dll")] public static extern int eFecharSerial_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int tEnviarDados_Daruma(string sBytes, int iTamBytes);
        [DllImport("DarumaFrameWork.dll")] public static extern int rReceberDados_Daruma(ref StringBuilder sBufferEntrada);

        #endregion

        #region Métodos Impressora Fiscal

        [DllImport("DarumaFrameWork.dll")] public static extern int eInterpretarErro_ECF_Daruma(int iErro, StringBuilder pszDescErro);
        [DllImport("DarumaFrameWork.dll")] public static extern int eInterpretarAviso_ECF_Daruma(int iAviso, StringBuilder pszDescAviso);
        [DllImport("DarumaFrameWork.dll")] public static extern int eRetornarAvisoErroUltimoCMD_ECF_Daruma(StringBuilder sAviso, StringBuilder sErro);
        [DllImport("DarumaFrameWork.dll")] public static extern int eInterpretarRetorno_ECF_Daruma(int iRetorno, StringBuilder pszDescRet);
        [DllImport("DarumaFrameWork.dll")] public static extern int eAguardarRecepcao_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int eAuditar_Daruma(string cAuditoria, int iFlag);
        [DllImport("DarumaFrameWork.dll")] public static extern int eAuditar(string pszAuditoria, int iFlag);
        [DllImport("DarumaFrameWork.dll")] public static extern int eCancelaComunicacao_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int eDefinirProduto(string pszProduto);
        [DllImport("DarumaFrameWork.dll")] public static extern int eDefinirModoRegistro_Daruma(int intiTipo);
        [DllImport("DarumaFrameWork.dll")] public static extern int eVerificarVersaoDLL_Daruma(StringBuilder pszRet);
        [DllImport("DarumaFrameWork.dll", EntryPoint = "eVerificarVersaoDLL_Daruma")] public static extern int eVerificarVersaoDLL_Daruma2(string pszRet);
        [DllImport("DarumaFrameWork.dll")] public static extern int regLogin_Daruma(string pszPDV);
        [DllImport("DarumaFrameWork.dll")] public static extern int regLogin(string pszPDV);
        [DllImport("DarumaFrameWork.dll")] public static extern int regRetornaValorChave_DarumaFramework(string pszProduto, string pszChave, StringBuilder pszValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int regRetornaValorChave(string pszProduto, string pszChave, string pszValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int regAlteraValorChave_DarumaFramework(string pszProduto, string pszChave, string pszValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int regAlteraValorChave(string pszProduto, string pszChave, string pszValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int regAlterarValor_Daruma(string pszChave, string pszValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int regAtoCotepe_Daruma(string pszChave, string pszValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int rCFVrImposto_ECF_Daruma(string pszNumItem, StringBuilder pszNCM);
        [DllImport("DarumaFrameWork.dll")] public static extern int confCFNCM_ECF_Daruma(string pszCodigoNCM, string pszTipo);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFAbrir_ECF_Daruma(string pszCPF, string pszNome, string pszEndereco);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFAbrirPadrao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFVender_ECF_Daruma(string pszCargaTributaria, string pszQuantidade, string pszPrecoUnitario, string pszTipoDescAcresc, string pszValorDescAcresc, string pszCodigoItem, string pszUnidadeMedida, string pszDescricaoItem);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFVenderSemDesc_ECF_Daruma(string pszCargaTributaria, string pszQuantidade, string pszPrecoUnitario, string pszCodigoItem, string pszUnidadeMedida, string pszDescricaoItem);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFVenderResumido_ECF_Daruma(string pszCargaTributaria, string pszPrecoUnitario, string pszCodigoItem, string pszDescricaoItem);
        [DllImport("DarumaFrameWork.dll")] public static extern int fnCFLancarDescAcrescItem_ECF_Daruma(string pszNumItem, string pszTipoDescAcresc, string pszValorDescAcresc);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFLancarAcrescimoItem_ECF_Daruma(string pszNumItem, string pszTipoDescAcresc, string pszValorDescAcresc);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFLancarDescontoItem_ECF_Daruma(string pszNumItem, string pszTipoDescAcresc, string pszValorDescAcresc);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFLancarAcrescimoUltimoItem_ECF_Daruma(string pszTipoDescAcresc, string pszValorDescAcresc);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFLancarDescontoUltimoItem_ECF_Daruma(string pszTipoDescAcresc, string pszValorDescAcresc);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFCancelarItem_ECF_Daruma(string pszNumItem);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFCancelarUltimoItem_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFCancelarItemParcial_ECF_Daruma(string pszNumItem, string pszQuantidade);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFCancelarUltimoItemParcial_ECF_Daruma(string pszQuantidade);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFCancelarDescontoItem_ECF_Daruma(string pszNumItem);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFCancelarDescUltimoItem_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFCancelarAcrescimoItem_ECF_Daruma(string pszNumItem);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFCancelarAcrescimoUltimoItem_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFTotalizarCupom_ECF_Daruma(string pszTipoDescAcresc, string pszValorDescAcresc);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFTotalizarCupomPadrao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFCancelarDescontoSubtotal_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFCancelarAcrescimoSubtotal_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFEfetuarPagamentoPadrao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFEfetuarPagamentoFormatado_ECF_Daruma(string pszFormaPgto, string pszValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFEfetuarPagamento_ECF_Daruma(string pszFormaPgto, string pszValor, string pszInfoAdicional);
        [DllImport("DarumaFrameWork.dll")] public static extern int rCFSaldoAPagar_ECF_Daruma(StringBuilder pszValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int rCFSubTotal_ECF_Daruma(StringBuilder pszValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFEncerrarPadrao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFEncerrarConfigMsg_ECF_Daruma(string pszMensagem);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFEncerrar_ECF_Daruma(string pszCupomAdicional, string pszMensagem);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFEncerrarResumido_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFEmitirCupomAdicional_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFCancelar_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int rCFVerificarStatus_ECF_Daruma(StringBuilder cStatusCF, ref int piStatusCF);
        [DllImport("DarumaFrameWork.dll")] public static extern int rCFVerificarStatusInt_ECF_Daruma(ref int iStatusCF);
        [DllImport("DarumaFrameWork.dll")] public static extern int rRGVerificarStatus_ECF_Daruma(StringBuilder sStatusRG, int iStatusRG);
        [DllImport("DarumaFrameWork.dll")] public static extern int rCFVerificarStatusStr_ECF_Daruma(StringBuilder cStatusCF);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFIdentificarConsumidor_ECF_Daruma(string pszNome, string pszEndereco, string pszDoc);
        [DllImport("DarumaFrameWork.dll")] public static extern int rCMEfetuarCalculo_ECF_Daruma(StringBuilder pszISS, StringBuilder pszICMS);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFBPAbrir_ECF_Daruma(string pszOrigem, string pszDestino, string pszUFDestino, string pszPercurso, string pszPrestadora, string pszPlataforma, string pszPoltrona, string pszModalidadetransp, string pszCategoriaTransp, string pszDataEmbarque, string pszRGPassageiro, string pszNomePassageiro, string pszEnderecoPassageiro);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCFBPVender_ECF_Daruma(string pszAliquota, string pszValor, string pszTipoDescAcresc, string pszValorDescAcresc, string pszDescricao);
        [DllImport("DarumaFrameWork.dll")] public static extern int confCFBPProgramarUF_ECF_Daruma(string pszUF);
        [DllImport("DarumaFrameWork.dll")] public static extern int rEfetuarDownloadMFD_ECF_Daruma(string pszTipo, string pszInicial, string pszFinal, string pszNomeArquivo);
        [DllImport("DarumaFrameWork.dll")] public static extern int rGerarEspelhoMFD_ECF_Daruma(string pszTipo, string pszInicial, string pszFinal);
        [DllImport("DarumaFrameWork.dll")] public static extern int rEfetuarDownloadMF_ECF_Daruma(string pszNomeArquivo);
        [DllImport("DarumaFrameWork.dll")] public static extern int rEfetuarDownloadTDM_ECF_Daruma(string pszTipo, string pszInicial, string pszFinal, string pszNomeArquivo);
        [DllImport("DarumaFrameWork.dll")] public static extern int rGerarRelatorio_ECF_Daruma(string pszRelatorio, string pszTipo, string pszInicial, string pszFinal);
        [DllImport("DarumaFrameWork.dll")] public static extern int rGerarMapaResumo_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int rGerarMF_ECF_Daruma(string sTipo, string pszInicial, string pszFinal);
        [DllImport("DarumaFrameWork.dll")] public static extern int rGerarMFD_ECF_Daruma(string pszTipo, string pszInicial, string pszFinal);
        [DllImport("DarumaFrameWork.dll")] public static extern int rGerarTDM_ECF_Daruma(string pszTipo, string pszInicial, string pszFinal);
        [DllImport("DarumaFrameWork.dll")] public static extern int rGerarSPED_ECF_Daruma(string pszTipo, string pszInicial, string pszFinal);
        [DllImport("DarumaFrameWork.dll")] public static extern int rGerarSINTEGRA_ECF_Daruma(string pszTipo, string pszInicial, string pszFinal);
        [DllImport("DarumaFrameWork.dll")] public static extern int rGerarNFP_ECF_Daruma(string pszTipo, string pszInicial, string pszFinal);
        [DllImport("DarumaFrameWork.dll")] public static extern int rGerarRelatorioOffline_ECF_Daruma(string szRelatorio, string szTipo, string szInicial, string szFinal, string szArquivo_MF, string szArquivo_MFD, string szArquivo_INF);
        [DllImport("DarumaFrameWork.dll")] public static extern int rAssinarRSA_ECF_Daruma(string pszPathArquivo, string pszChavePrivada, StringBuilder pszAssinaturaGerada);
        [DllImport("DarumaFrameWork.dll")] public static extern int rCalcularMD5_ECF_Daruma(string pszPathArquivo, StringBuilder pszMD5GeradoHex, StringBuilder pszMD5GeradoAscii);
        [DllImport("DarumaFrameWork.dll")] public static extern int rRetornarGTCodificado_ECF_Daruma(StringBuilder pszGTCodificado);
        [DllImport("DarumaFrameWork.dll")] public static extern int rVerificarGTCodificado_ECF_Daruma(string pszGTCodificado);
        [DllImport("DarumaFrameWork.dll")] public static extern int eRSAAssinarArquivo_ECF_Daruma(string arquivo, string chave);
        [DllImport("DarumaFrameWork.dll")] public static extern int rRSAChavePublica_ECF_Daruma(string sChavePrivada, StringBuilder sChavePublica, StringBuilder szExpoente);
        [DllImport("DarumaFrameWork.dll")] public static extern int eMemoriaFiscal_ECF_Daruma(string sInicial, string sFinal, bool sCompleta, string sTipo);
        [DllImport("DarumaFrameWork.dll")] public static extern int confModoPAF_ECF_Daruma(string sAtivar, string sChaveRSA, string sArquivos);
        [DllImport("DarumaFrameWork.dll")] public static extern int ePAFCadastrar_ECF_Daruma(string sNomeArquivo, string sChave, string sNumSerieECF, string sGT);
        [DllImport("DarumaFrameWork.dll")] public static extern int ePAFAtualizarGT_ECF_Daruma(string sNomeArquivo, string sChave, string sNumSerieECF, string sGT);
        [DllImport("DarumaFrameWork.dll")] public static extern int rLerArqRegistroPAF_ECF_Daruma(string sCaminho, string sChave, StringBuilder sReturn);
        [DllImport("DarumaFrameWork.dll")] public static extern int ePAFValidarDados_ECF_Daruma(string sNomeArquivo, string sChave, string sNumSerieECF, string sGT);
        [DllImport("DarumaFrameWork.dll")] public static extern int rCodigoModeloFiscal_ECF_Daruma(StringBuilder sValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int iImprimirCodigoBarras_ECF_Daruma(string pszTipo, string pszLargura, string pszAltura, string pszImprTexto, string pszCodigo, string pszOrientacao, string pszTextoLivre);
        [DllImport("DarumaFrameWork.dll")] public static extern int iRGAbrir_ECF_Daruma(string pszNomeRG);
        [DllImport("DarumaFrameWork.dll")] public static extern int iRGAbrirIndice_ECF_Daruma(int iIndiceRG);
        [DllImport("DarumaFrameWork.dll")] public static extern int iRGAbrirPadrao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iRGImprimirTexto_ECF_Daruma(string pszTexto);
        [DllImport("DarumaFrameWork.dll")] public static extern int iRGImprimirArquivo_ECF_Daruma(string pszCaminho);
        [DllImport("DarumaFrameWork.dll")] public static extern int iRGFechar_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCCDAbrir_ECF_Daruma(string pszFormaPgto, string pszParcelas, string pszDocOrigem, string pszValor, string pszCPF, string pszNome, string pszEndereco);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCCDAbrirSimplificado_ECF_Daruma(string pszFormaPgto, string pszParcelas, string pszDocOrigem, string pszValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCCDAbrirPadrao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCCDImprimirTexto_ECF_Daruma(string pszTexto);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCCDImprimirArquivo_ECF_Daruma(string pszArqOrigem);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCCDFechar_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCCDEstornarPadrao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCCDEstornar_ECF_Daruma(string pszCOO, string pszCPF, string pszNome, string pszEndereco);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCCDSegundaVia_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iTEF_ImprimirResposta_ECF_Daruma(string szArquivo, bool bTravarTeclado);
        [DllImport("DarumaFrameWork.dll")] public static extern int iTEF_ImprimirRespostaCartao_ECF_Daruma(string szArquivo, bool bTravarTeclado, string szForma, string szValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int iTEF_Fechar_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int eTEF_EsperarArquivo_ECF_Daruma(string szArquivo, int iTempo, bool bTravar);
        [DllImport("DarumaFrameWork.dll")] public static extern int eTEF_TravarTeclado_ECF_Daruma(bool bTravar);
        [DllImport("DarumaFrameWork.dll")] public static extern int eTEF_SetarFoco_ECF_Daruma(string szNomeTela);
        [DllImport("DarumaFrameWork.dll")] public static extern int iMFLerSerial_ECF_Daruma(string pszInicial, string pszFinal);
        [DllImport("DarumaFrameWork.dll")] public static extern int iMFLer_ECF_Daruma(string pszInicial, string pszFinal);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFAbrir_ECF_Daruma(string pszCPF, string pszNome, string pszEndereco);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFAbrirPadrao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFReceber_ECF_Daruma(string pszIndice, string pszValor, string pszTipoDescAcresc, string pszValorDescAcresc);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFReceberSemDesc_ECF_Daruma(string pszIndice, string pszValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFCancelarItem_ECF_Daruma(string pszNumItem);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFCancelarUltimoItem_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFCancelarAcrescimoItem_ECF_Daruma(string pszNumItem);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFCancelarAcrescUltimoItem_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFCancelarDescontoItem_ECF_Daruma(string pszNumItem);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFCancelarDescUltimoItem_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFTotalizarComprovante_ECF_Daruma(string pszTipoDescAcresc, string pszValorDescAcresc);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFTotalizarComprovantePadrao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFCancelarAcrescimoSubtotal_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFCancelarDescontoSubtotal_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFEfetuarPagamento_ECF_Daruma(string pszFormaPgto, string pszValor, string pszInfoAdicional);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFEfetuarPagamentoFormatado_ECF_Daruma(string pszFormaPgto, string pszValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFEfetuarPagamentoPadrao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFEncerrar_ECF_Daruma(string pszMensagem);
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFEncerrarPadrao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iCNFCancelar_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iEjetarCheque_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iImprimir_CHEQUE_Daruma(string pszNumeroBanco, string pszCidade, string pszData, string pszNomeFavorecido, string pszTextoFrente, string pszValorCheque);
        [DllImport("DarumaFrameWork.dll")] public static extern int iImprimirVertical_CHEQUE_Daruma(string pszNumeroBanco, string pszCidade, string pszData, string pszNomeFavorecido, string pszTextoFrente, string pszValorCheque);
        [DllImport("DarumaFrameWork.dll")] public static extern int iImprimirVerso_CHEQUE_Daruma(string pszTexto);
        [DllImport("DarumaFrameWork.dll")] public static extern int confCorrigirGeometria_CHEQUE_Daruma(string pszNumeroBanco, string pszDistValorNumerico, string pszColunaValorNumerico, string pszDistPrimExtenso, string pszColunaPrimExtenso, string pszDistSegExtenso, string pszColunaSegExtenso, string pszDistFavorecido, string pszColunaFavorecido, string pszDistCidade, string pszColunaCidade, string pszColunaDia, string pszColunaMes, string pszColunaAno, string pszLinhaAutenticacao, string pszColunaAutenticacao);
        [DllImport("DarumaFrameWork.dll")] public static extern int iAutenticar_CHEQUE_Daruma(string pszPosicao, string psztexto);
        [DllImport("DarumaFrameWork.dll")] public static extern int iAtributo_CHEQUE_Daruma(string pszModo);
        [DllImport("DarumaFrameWork.dll")] public static extern int eEjetarCheque_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iEstornarPagamento_ECF_Daruma(string pszFormaPgtoEstornado, string pszFormaPgtoEfetivado, string pszValor, string pszInfoAdicional);
        [DllImport("DarumaFrameWork.dll")] public static extern int eAcionarGuilhotina_ECF_Daruma(string pszTipoCorte);
        [DllImport("DarumaFrameWork.dll")] public static extern int eCarregarBitmapPromocional_ECF_Daruma(string sPathLogotipo, string NumBitmap, string Orientacao);
        [DllImport("DarumaFrameWork.dll")] public static extern int fnLeituraX_ECF_Daruma(int iTipo, string pszCaminho);
        [DllImport("DarumaFrameWork.dll")] public static extern int iLeituraX_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int rLeituraX_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int rLeituraXCustomizada_ECF_Daruma(string pszCaminho);
        [DllImport("DarumaFrameWork.dll")] public static extern int iSangriaPadrao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iSangria_ECF_Daruma(string pszValor, string pszMensagem);
        [DllImport("DarumaFrameWork.dll")] public static extern int iSuprimentoPadrao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iSuprimento_ECF_Daruma(string pszValor, string pszMensagem);
        [DllImport("DarumaFrameWork.dll")] public static extern int iReducaoZ_ECF_Daruma(string param1, string param2);
        [DllImport("DarumaFrameWork.dll")] public static extern int eAbrirGaveta_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int rStatusGaveta_ECF_Daruma(ref int iStatus);
        [DllImport("DarumaFrameWork.dll")] public static extern int confCadastrarPadrao_ECF_Daruma(string pszCadastrar, string pszValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int confCadastrar_ECF_Daruma(string pszCadastrar, string pszValor, string pszSeparador);
        [DllImport("DarumaFrameWork.dll")] public static extern int confHabilitarHorarioVerao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int confDesabilitarHorarioVerao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int confProgramarOperador_ECF_Daruma(string pszValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int confProgramarIDLoja_ECF_Daruma(string pszValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int confProgramarAvancoPapel_ECF_Daruma(string pszSepEntreLinhas, string pszSepEntreDoc, string pszLinhasGuilhotina, string pszGuilhotina, string pszImpClicheAntecipada);
        [DllImport("DarumaFrameWork.dll")] public static extern int confHabilitarModoPreVenda_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int confDesabilitarModoPreVenda_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int eWsStatus_ECF_Daruma(ref int iRespostaWS);
        [DllImport("DarumaFrameWork.dll")] public static extern int eWsEnviarCupom_ECF_Daruma(string pszCPF, string pszNomeFantasia, string pszIndiceSegmento, string pszCCF, string szData, string pszHora, string pszValor, string pszISS, string pszICMS, string pszReservado, int iSyncAssync, ref int iRespostaWS);
        [DllImport("DarumaFrameWork.dll")] public static extern int rLerAliquotas_ECF_Daruma(StringBuilder cAliquotas);
        [DllImport("DarumaFrameWork.dll")] public static extern int rLerMeiosPagto_ECF_Daruma(StringBuilder pszRelatorios);
        [DllImport("DarumaFrameWork.dll")] public static extern int rLerRG_ECF_Daruma(StringBuilder pszRelatorios);
        [DllImport("DarumaFrameWork.dll")] public static extern int rLerDecimais_ECF_Daruma(StringBuilder pszDecimalQtde, StringBuilder pszDecimalValor, ref int piDecimalQtde, ref int piDecimalValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int rLerCNF_ECF_Daruma(StringBuilder pszDecimalQtde);
        [DllImport("DarumaFrameWork.dll")] public static extern int rLerDecimaisInt_ECF_Daruma(ref int piDecimalQtde, ref int piDecimalValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int rLerDecimaisStr_ECF_Daruma(StringBuilder pszDecimalQtde, StringBuilder pszDecimalValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int rDataHoraImpressora_ECF_Daruma(StringBuilder pszData, StringBuilder pszHora);
        [DllImport("DarumaFrameWork.dll")] public static extern int rVerificarImpressoraLigada_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int rStatusImpressora_ECF_Daruma(StringBuilder pszStatus);
        [DllImport("DarumaFrameWork.dll")] public static extern int rStatusImpressoraStr_ECF_Daruma(StringBuilder pszStatus);
        [DllImport("DarumaFrameWork.dll")] public static extern int rStatusImpressoraInt_ECF_Daruma(ref int piStatusEcf);
        [DllImport("DarumaFrameWork.dll")] public static extern int rInfoEstentida1_ECF_Daruma(StringBuilder cInfoEx);
        [DllImport("DarumaFrameWork.dll")] public static extern int rInfoEstentida2_ECF_Daruma(StringBuilder cInfoEx);
        [DllImport("DarumaFrameWork.dll")] public static extern int rInfoEstentida3_ECF_Daruma(StringBuilder cInfoEx);
        [DllImport("DarumaFrameWork.dll")] public static extern int rInfoEstentida4_ECF_Daruma(StringBuilder cInfoEx);
        [DllImport("DarumaFrameWork.dll")] public static extern int rInfoEstentida5_ECF_Daruma(StringBuilder cInfoEx);
        [DllImport("DarumaFrameWork.dll")] public static extern int rVerificarReducaoZ_ECF_Daruma(StringBuilder zPendente);
        [DllImport("DarumaFrameWork.dll")] public static extern int rRetornarVendaBruta_ECF_Daruma(StringBuilder sRetorno);
        [DllImport("DarumaFrameWork.dll")] public static extern int rRetornarVendaLiquida_ECF_Daruma(StringBuilder sVendaLiquida);
        [DllImport("DarumaFrameWork.dll")] public static extern int rMinasLegal_ECF_Daruma(StringBuilder sRetorno);
        [DllImport("DarumaFrameWork.dll")] public static extern int rCompararDataHora_ECF_Daruma(ref int iDiferenca);
        [DllImport("DarumaFrameWork.dll")] public static extern int rInfoCNF_ECF_Daruma(StringBuilder sRetorno);
        [DllImport("DarumaFrameWork.dll")] public static extern int rStatusUltimoCmd_ECF_Daruma(StringBuilder pszErro, StringBuilder pszAviso, ref int piErro, ref int piAviso);
        [DllImport("DarumaFrameWork.dll")] public static extern int rStatusUltimoCmdInt_ECF_Daruma(ref int piErro, ref int piAviso);
        [DllImport("DarumaFrameWork.dll")] public static extern int rUltimoCMDEnviado_ECF_Daruma(StringBuilder ultimoCMD);
        [DllImport("DarumaFrameWork.dll")] public static extern int rTipoUltimoDocumentoStr_ECF_Daruma(StringBuilder ultimoDOC);
        [DllImport("DarumaFrameWork.dll")] public static extern int rTipoUltimoDocumentoInt_ECF_Daruma(StringBuilder ultimoDOC);
        [DllImport("DarumaFrameWork.dll")] public static extern int iRelatorioConfiguracao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int rConsultaStatusImpressoraInt_ECF_Daruma(int iIndice, ref int IStatus);
        [DllImport("DarumaFrameWork.dll")] public static extern int rConsultaStatusImpressoraStr_ECF_Daruma(int iIndice, StringBuilder StrStatus);
        [DllImport("DarumaFrameWork.dll")] public static extern int rStatusImpressoraBinario_ECF_Daruma(StringBuilder Status);
        [DllImport("DarumaFrameWork.dll")] public static extern int rRetornarInformacaoSeparador_ECF_Daruma(string pszIndice, string pszVSignificativo, StringBuilder pszRetornar);
        [DllImport("DarumaFrameWork.dll")] public static extern int rStatusUltimoCmdStr_ECF_Daruma(StringBuilder cErro, StringBuilder cAviso);
        [DllImport("DarumaFrameWork.dll")] public static extern int rRetornarInformacao_ECF_Daruma(string pszIndice, StringBuilder pszRetornar);
        [DllImport("DarumaFrameWork.dll")] public static extern int rRetornarNumeroSerieCodificado_ECF_Daruma(StringBuilder pszSerialCriptografado);
        [DllImport("DarumaFrameWork.dll")] public static extern int rVerificarNumeroSerieCodificado_ECF_Daruma(string pszSerialCriptografado);
        [DllImport("DarumaFrameWork.dll")] public static extern int rCarregarNumeroSerie_ECF_Daruma(StringBuilder pszSerial);
        [DllImport("DarumaFrameWork.dll")] public static extern int rRetornarDadosReducaoZ_ECF_Daruma(StringBuilder pszDados);
        [DllImport("DarumaFrameWork.dll")] public static extern int rRegistrarNumeroSerie_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int eAguardarCompactacao_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int eBuscarPortaVelocidade_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int eEnviarComando_ECF_Daruma(string cComando, int iTamanhoComando, int iType);
        [DllImport("DarumaFrameWork.dll")] public static extern int eRetornarAviso_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int eRetornarErro_ECF_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int eRetornarPortasCOM_ECF_Daruma(StringBuilder PortasCOM);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCCDDocOrigem_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCCDFormaPgto_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCCDLinhasTEF_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCCDParcelas_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCCDValor_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCFFormaPgto_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCFMensagemPromocional_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCFQuantidade_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCFTamanhoMinimoDescricao_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCFTipoDescAcresc_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCFUnidadeMedida_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCFValorDescAcresc_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCFCupomAdicional_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCFCupomMania(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCFCupomAdicionalDllConfig_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCFCupomAdicionalDllTitulo_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regChequeXLinha1_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regChequeXLinha2_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regChequeXLinha3_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regChequeYLinha1_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regChequeYLinha2_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regChequeYLinha3_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regCompatStatusFuncao_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regMaxFechamentoAutomatico_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regECFAguardarImpressao_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regECFArquivoLeituraX_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regECFAuditoria_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regECFCaracterSeparador_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regECFMaxFechamentoAutomatico_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regECFReceberAvisoEmArquivo_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regECFReceberErroEmArquivo_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regECFReceberInfoEstendida_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regECFReceberInfoEstendidaEmArquivo_ECF_Daruma(string pszParametro);
        [DllImport("DarumaFrameWork.dll")] public static extern int regAtocotepe_ECF_Daruma(string pszParametro1, string pszParametro2);
        [DllImport("DarumaFrameWork.dll")] public static extern int eDefinirModoRegistro_Daruma(string pszParametro);

        #endregion

        #region Métodos SAT

        [DllImport("DarumaFrameWork.dll")] public static extern int aCFAbrir_SAT_Daruma(string strCPF, string strNome, string strEndereco);
        [DllImport("DarumaFrameWork.dll")] public static extern int aCFVender_SAT_Daruma(string strCargaTributaria, string strQuantidade, string strPrecoUnitario, string strTipoDescAcresc, string strValorDescAcresc, string strCodigoItem, string strUnidadeMedida, string strDescricaoItem);
        [DllImport("DarumaFrameWork.dll")] public static extern int aCFTotalizar_SAT_Daruma(string strTipoDescAcresc, string strValorDescAcresc);
        [DllImport("DarumaFrameWork.dll")] public static extern int aCFEfetuarPagamento_SAT_Daruma(string strFormaPgto, string strValor, string strInfoAdicional);
        [DllImport("DarumaFrameWork.dll")] public static extern int tCFEncerrar_SAT_Daruma(string strCupomAdicional, string strInfoAdic);
        [DllImport("DarumaFrameWork.dll")] public static extern int tCFeCancelar_SAT_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int tCFeCancelarParametrizado_SAT_Daruma(string szCpfCnpjConsumidor, string szChaveConsulta);
        [DllImport("DarumaFrameWork.dll")] public static extern int aCFeCancelarItem_SAT_Daruma(int iNumItem);
        [DllImport("DarumaFrameWork.dll")] public static extern int aCFeCancelarFormaPagamento_SAT_Daruma(int iNumFormaPagamento);
        [DllImport("DarumaFrameWork.dll")] public static extern int aCFEstornarPagamento_SAT_Daruma(string strFormaPgtoEstorno, string strFormaPgtoEfetivado, string strValor);
        [DllImport("DarumaFrameWork.dll")] public static extern int rVerificarComunicacao_SAT_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int rConsultarStatus_SAT_Daruma(StringBuilder strRetornoSAT);
        [DllImport("DarumaFrameWork.dll")] public static extern int rConsultarStatusEspecifico_SAT_Daruma(string strCampo, StringBuilder strRetornoSAT);
        [DllImport("DarumaFrameWork.dll")] public static extern int rConsultarArqCopSeguranca_SAT_Daruma(StringBuilder strArqCopSeg);
        [DllImport("DarumaFrameWork.dll")] public static extern int rInfoEstendida_SAT_Daruma(string strIndice, StringBuilder strRetorno);
        [DllImport("DarumaFrameWork.dll")] public static extern int iReimprimirUltimoCFe_SAT_Daruma();
        [DllImport("DarumaFrameWork.dll")] public static extern int iImprimirCFe_SAT_Daruma(string strPathXmlSAT, string strTipo);
        [DllImport("DarumaFrameWork.dll")] public static extern int tCFeAssociarAssinatura_SAT_Daruma(string strTagsSAT);
        [DllImport("DarumaFrameWork.dll")] public static extern int regAlterarValor_SAT_Daruma(string strTagSAT, string strValorTagSAT);
        [DllImport("DarumaFrameWork.dll")] public static extern int regRetornarValor_SAT_Daruma(string strTagSAT, StringBuilder strValorRetTagSAT);

        #endregion
    }
}
