using nNefd.Persistencia;
using System;
using static Comum.cFuncoes;

namespace NEFd
{
    public class rArquivo
    {
        private dArquivo _arquivo;

        public dArquivo MontarRelatorio(DateTime dataInicio, DateTime dataFim)
        {
            _arquivo = new dArquivo();

            // Registro 0000 -- ABERTURA DO ARQUIVO DIGITAL E IDENTIFICAÇÃO DA ENTIDADE
            MontarReg0000(dataInicio, dataFim);

            // Registro 0001 -- ABERTURA DO BLOCO 0
            MontarReg0001();
            // Registro 0005 -- DADOS COMPLEMENTARES DA ENTIDADE
            MontarReg0005();
            // Registro 0100 -- DADOS DO CONTABILISTA
            MontarReg0100();
            // Registro 0150 -- TABELA DE CADASTRO DO PARTICIPANTE
            MontarReg0150(dataInicio, dataFim);
            // Registro 0190 -- IDENTIFICAÇÃO DAS UNIDADES DE MEDIDA
            MontarReg0190(dataInicio, dataFim);
            // Registro 0200 -- TABELA DE IDENTIFICAÇÃO DO ITEM (PRODUTO E SERVIÇOS)
            MontarReg0200(dataInicio, dataFim);
            // Registro 0990 -- ENCERRAMENTO DO BLOCO 0
            MontarReg0990();

            // Registro C001 -- ABERTURA DO BLOCO C
            MontarRegC001();
            // Registro C100 -- NOTA FISCAL
            MontarRegC100(dataInicio, dataFim);
            // Registro C170 -- ITENS DO DOCUMENTO
            MontarRegC170(dataInicio, dataFim);
            // Registro C190 -- REGISTRO ANALÍTICO DO DOCUMENTO
            MontarRegC190();
            // Registro C990 -- ENCERRAMENTO DO BLOCO C
            MontarRegC990();

            // REGISTRO D001: ABERTURA DO BLOCO D
            MontarRegD001();
            // REGISTRO D990: ENCERRAMENTO DO BLOCO D
            MontarRegD990();

            // REGISTRO E001: ABERTURA DO BLOCO E
            MontarRegE001();
            // REGISTRO E100: PERÍODO DA APURAÇÃO DO ICMS
            MontarRegE100(dataInicio, dataFim);
            // REGISTRO E110: APURAÇÃO DO ICMS – OPERAÇÕES PRÓPRIAS
            MontarRegE110();
            // REGISTRO E990: ENCERRAMENTO DO BLOCO E
            MontarRegE990();

            // REGISTRO G001: ABERTURA DO BLOCO G
            MontarRegG001();
            // REGISTRO G990: ENCERRAMENTO DO BLOCO G
            MontarRegG990();

            // REGISTRO H001: ABERTURA DO BLOCO H
            MontarRegH001();
            // REGISTRO H010: INVENTÁRIO
            MontarRegH010(dataInicio, dataFim);
            // REGISTRO H005: TOTAIS DO INVENTÁRIO
            MontarRegH005(dataFim);
            // REGISTRO H990: ENCERRAMENTO DO BLOCO H
            MontarRegH990();

            // REGISTRO 1001: ABERTURA DO BLOCO 1
            MontarReg1001();
            // REGISTRO 1010: OBRIGATORIEDADE DE REGISTROS DO BLOCO 1
            MontarReg1010();
            // REGISTRO 1990: ENCERRAMENTO DO BLOCO 1
            MontarReg1990();

            // REGISTRO 9001: ABERTURA DO BLOCO 9
            MontarReg9001();
            // REGISTRO 9900: REGISTROS DO ARQUIVO
            MontarReg9900();
            // REGISTRO 9990: ENCERRAMENTO DO BLOCO 9
            MontarReg9990();

            // REGISTRO 9999: ENCERRAMENTO DO ARQUIVO DIGITAL
            MontarReg9999();

            return _arquivo;
        }

        public void MontarReg0000(DateTime dataInicio, DateTime dataFim)
        {
            var _pReg0000 = new pReg0000();
            var _dReg0000 = _pReg0000.Consultar();

            if (_dReg0000 != null)
            {
                _arquivo.reg0000 = new dReg0000();
                _arquivo.reg0000.reg = "0000";
                _arquivo.reg0000.cod_ver = _dReg0000.cod_ver;
                _arquivo.reg0000.cod_fin = _dReg0000.cod_fin;
                _arquivo.reg0000.dt_ini = dataInicio;
                _arquivo.reg0000.dt_fin = dataFim;
                _arquivo.reg0000.nome = _dReg0000.nome;
                if (_dReg0000.tipoPessoa == "J")
                    _arquivo.reg0000.cnpj = _dReg0000.cpfCnpj;
                else if (_dReg0000.tipoPessoa == "F")
                    _arquivo.reg0000.cpf = _dReg0000.cpfCnpj;
                _arquivo.reg0000.uf = _dReg0000.uf;
                _arquivo.reg0000.ie = _dReg0000.ie;
                _arquivo.reg0000.cod_mun = _dReg0000.cod_mun;
                _arquivo.reg0000.im = _dReg0000.im;
                _arquivo.reg0000.suframa = _dReg0000.suframa;
                _arquivo.reg0000.ind_perfil = _dReg0000.ind_perfil;
                _arquivo.reg0000.ind_ativ = _dReg0000.ind_ativ;
                _arquivo.reg0000.tipoPessoa = _dReg0000.tipoPessoa;
                _arquivo.reg0000.cpfCnpj = _dReg0000.cpfCnpj;
            }
        }

        public void MontarReg0001()
        {
            _arquivo.reg0001 = new dReg0001();
            _arquivo.reg0001.reg = "0001";
            _arquivo.reg0001.ind_mov = "0";
        }

        public void MontarReg0005()
        {
            var _pReg0005 = new pReg0005();
            var _dReg0005 = _pReg0005.Consultar();

            if (_dReg0005 != null)
            {
                _arquivo.reg0005 = new dReg0005();
                _arquivo.reg0005.reg = "0005";
                _arquivo.reg0005.fantasia = _dReg0005.fantasia;
                _arquivo.reg0005.cep = _dReg0005.cep;
                _arquivo.reg0005.ende = _dReg0005.ende;
                _arquivo.reg0005.num = _dReg0005.num;
                _arquivo.reg0005.compl = _dReg0005.compl;
                _arquivo.reg0005.bairro = _dReg0005.bairro;
                _arquivo.reg0005.fone = _dReg0005.fone;
                _arquivo.reg0005.fax = _dReg0005.fax;
                _arquivo.reg0005.email = _dReg0005.email;
            }
        }

        public void MontarReg0100()
        {
            var _pReg0100 = new pReg0100();
            var _dReg0100 = _pReg0100.Consultar();

            if (_dReg0100 != null)
            {
                _arquivo.reg0100 = new dReg0100();
                _arquivo.reg0100.reg = "0100";
                _arquivo.reg0100.nome = _dReg0100.nome;
                _arquivo.reg0100.cpf = _dReg0100.cpf;
                _arquivo.reg0100.crc = _dReg0100.crc;
                _arquivo.reg0100.cnpj = _dReg0100.cnpj;
                _arquivo.reg0100.cep = _dReg0100.cep;
                _arquivo.reg0100.ende = _dReg0100.ende;
                _arquivo.reg0100.num = _dReg0100.num;
                _arquivo.reg0100.compl = _dReg0100.compl;
                _arquivo.reg0100.bairro = _dReg0100.bairro;
                _arquivo.reg0100.fone = _dReg0100.fone;
                _arquivo.reg0100.fax = _dReg0100.fax;
                _arquivo.reg0100.email = _dReg0100.email;
                _arquivo.reg0100.cod_mun = _dReg0100.cod_mun;
            }
        }

        public void MontarReg0150(DateTime dataInicio, DateTime dataFim)
        {
            var _pReg0150 = new pReg0150();
            var _colecao0150 = _pReg0150.Consultar(dataInicio, dataFim);

            if (_colecao0150 != null && _colecao0150.Count > 0)
            {
                _arquivo.col0150 = new Colecao0150();
                foreach (var item in _colecao0150)
                {
                    var reg = new dReg0150();
                    reg.reg = "0150";
                    reg.cod_part = item.cod_part;
                    reg.nome = item.nome;
                    reg.cod_pais = "1058";
                    reg.cnpj = item.cnpj;
                    reg.cpf = item.cpf;
                    reg.ie = item.ie;
                    reg.cod_mun = item.cod_mun;
                    reg.suframa = item.suframa;
                    reg.ende = item.ende;
                    reg.num = item.num;
                    reg.compl = item.compl;
                    reg.bairro = item.bairro;
                    _arquivo.col0150.Add(reg);
                }
            }
        }

        public void MontarReg0190(DateTime dataInicio, DateTime dataFim)
        {
            var _pReg0190 = new pReg0190();
            var _colecao0190 = _pReg0190.Consultar(dataInicio, dataFim);

            if (_colecao0190 != null && _colecao0190.Count > 0)
            {
                _arquivo.col0190 = new Colecao0190();
                foreach (var item in _colecao0190)
                {
                    var reg = new dReg0190();
                    reg.reg = "0190";
                    reg.unid = item.unid;
                    reg.descr = item.descr;
                    _arquivo.col0190.Add(reg);
                }
            }
        }

        public void MontarReg0200(DateTime dataInicio, DateTime dataFim)
        {
            var _pReg0200 = new pReg0200();
            var _colecao0200 = _pReg0200.Consultar(dataInicio, dataFim);

            if (_colecao0200 != null && _colecao0200.Count > 0)
            {
                _arquivo.col0200 = new Colecao0200();
                foreach (var item in _colecao0200)
                {
                    var reg = new dReg0200();
                    reg.reg = "0200";
                    reg.cod_item = item.cod_item;
                    reg.descr_item = item.descr_item;
                    reg.cod_barra = item.cod_barra;
                    reg.cod_ant_item = item.cod_ant_item;
                    reg.unid_inv = item.unid_inv;
                    reg.tipo_item = "00";
                    reg.cod_ncm = item.cod_ncm;
                    reg.ex_ipi = item.ex_ipi;
                    reg.cod_gen = item.cod_gen;
                    reg.cod_lst = item.cod_lst;
                    reg.aliq_icms = item.aliq_icms == "FF" ? "0.0" : item.aliq_icms;
                    _arquivo.col0200.Add(reg);
                }
            }
        }

        public void MontarReg0990()
        {
            int qtd = 0;

            _arquivo.reg0990 = new dReg0990();

            if (_arquivo.reg0000 != null) qtd++;
            if (_arquivo.reg0001 != null) qtd++;
            if (_arquivo.reg0005 != null) qtd++;
            if (_arquivo.reg0100 != null) qtd++;
            if (_arquivo.col0150 != null) qtd += _arquivo.col0150.Count;
            if (_arquivo.col0190 != null) qtd += _arquivo.col0190.Count;
            if (_arquivo.col0200 != null) qtd += _arquivo.col0200.Count;

            _arquivo.reg0990.reg = "0990";
            _arquivo.reg0990.qtd_lin_0 = qtd + 1;
        }

        public void MontarRegC001()
        {
            _arquivo.regC001 = new dRegC001();
            _arquivo.regC001.reg = "C001";
            _arquivo.regC001.ind_mov = "0";
        }

        public void MontarRegC100(DateTime dataInicio, DateTime dataFim)
        {
            var _pRegC100 = new pRegC100();
            var _colecaoC100 = _pRegC100.Consultar(dataInicio, dataFim);

            if (_colecaoC100 != null && _colecaoC100.Count > 0)
            {
                _arquivo.colC100 = new ColecaoC100();
                foreach (var item in _colecaoC100)
                {
                    var reg = new dRegC100();
                    reg.reg = "C100";
                    reg.tipoFluxo = item.tipoFluxo;
                    reg.tipoEmissao = item.tipoEmissao;
                    reg.cod_part = item.cod_part;
                    reg.tipoNF = item.tipoNF;
                    reg.situacaoNF = item.situacaoNF;
                    reg.ser = item.ser;
                    reg.num_doc = item.num_doc;
                    reg.chv_nfe = item.chv_nfe;
                    reg.dt_doc = item.dt_doc;
                    reg.dt_e_s = item.dt_e_s;
                    reg.vl_doc = item.vl_doc;
                    reg.vl_abat_nt = item.vl_abat_nt;
                    reg.tipoPagto = item.tipoPagto;
                    reg.vl_desc = item.vl_desc;
                    reg.vl_merc = item.vl_merc;
                    reg.tipoFrete = item.tipoFrete;
                    reg.vl_frt = item.vl_frt;
                    reg.vl_seg = item.vl_seg;
                    reg.vl_out_da = item.vl_out_da;
                    reg.vl_bc_icms = item.vl_bc_icms;
                    reg.vl_icms = item.vl_icms;
                    reg.vl_bc_icms_st = item.vl_bc_icms_st;
                    reg.vl_icms_st = item.vl_icms_st;
                    reg.vl_ipi = item.vl_ipi;
                    reg.vl_pis = item.vl_pis;
                    reg.vl_cofins = item.vl_cofins;
                    reg.vl_pis_st = item.vl_pis_st;
                    reg.vl_cofins_st = item.vl_cofins_st;
                    _arquivo.colC100.Add(reg);
                }
            }
        }

        public void MontarRegC170(DateTime dataInicio, DateTime dataFim)
        {
            var _pRegC170 = new pRegC170();

            if (_arquivo.colC100 != null && _arquivo.colC100.Count > 0)
            {
                var _colecaoC170 = _pRegC170.Consultar(dataInicio, dataFim);
                _arquivo.colC170 = new ColecaoC170();

                if (_colecaoC170 != null && _colecaoC170.Count > 0)
                {
                    int contador = 0;
                    foreach (var item in _colecaoC170)
                    {
                        contador++;
                        var reg = new dRegC170();
                        reg.reg = "C170";
                        reg.num_item = contador.ToString();
                        reg.num_doc = item.num_doc;
                        reg.cod_item = item.cod_item;
                        reg.descr_compl = item.descr_compl;
                        reg.qtd = item.qtd;
                        reg.unid = item.unid;
                        reg.vl_item = item.vl_item;
                        reg.ind_mov = "1";
                        reg.cst_icms = "000";
                        reg.cfop = "1102";
                        reg.aliq_icms = item.aliq_icms.ToString() == "FF" ? 0.0m : item.aliq_icms;
                        _arquivo.colC170.Add(reg);
                    }
                }
            }
        }

        public void MontarRegC190()
        {
            decimal _vl_opr = 0, _vl_bc_icms = 0, _vl_icms = 0;
            decimal _vl_bc_icms_st = 0, _vl_icms_st = 0, _vl_ipi = 0;

            if (_arquivo.colC100 != null && _arquivo.colC100.Count > 0)
            {
                if (_arquivo.regC190 == null)
                    _arquivo.regC190 = new dRegC190();

                foreach (var item in _arquivo.colC100)
                {
                    if (item.vl_doc.HasValue) _vl_opr += item.vl_doc.Value;
                    if (item.vl_bc_icms.HasValue) _vl_bc_icms += item.vl_bc_icms.Value;
                    if (item.vl_icms.HasValue) _vl_icms += item.vl_icms.Value;
                    if (item.vl_bc_icms_st.HasValue) _vl_bc_icms_st += item.vl_bc_icms_st.Value;
                    if (item.vl_icms_st.HasValue) _vl_icms_st += item.vl_icms_st.Value;
                    if (item.vl_ipi.HasValue) _vl_ipi += item.vl_ipi.Value;
                }

                _arquivo.regC190.reg = "C190";
                _arquivo.regC190.cst_icms = "000";
                _arquivo.regC190.cfop = "1102";
                _arquivo.regC190.aliq_icms = 0;
                _arquivo.regC190.vl_opr = _vl_opr;
                _arquivo.regC190.vl_bc_icms = _vl_bc_icms;
                _arquivo.regC190.vl_icms = _vl_icms;
                _arquivo.regC190.vl_bc_icms_st = _vl_bc_icms_st;
                _arquivo.regC190.vl_icms_st = _vl_icms_st;
                _arquivo.regC190.vl_red_bc = 0;
                _arquivo.regC190.vl_ipi = _vl_ipi;
                _arquivo.regC190.cod_obs = null;
            }
        }

        public void MontarRegC990()
        {
            int qtd = 0;
            _arquivo.regC990 = new dRegC990();

            if (_arquivo.regC001 != null) qtd++;
            if (_arquivo.colC100 != null) qtd += _arquivo.colC100.Count;
            if (_arquivo.colC170 != null) qtd += _arquivo.colC170.Count;
            if (_arquivo.regC190 != null) qtd++;

            _arquivo.regC990.reg = "C990";
            _arquivo.regC990.qtd_lin_c = qtd + 1;
        }

        public void MontarRegD001()
        {
            _arquivo.regD001 = new dRegD001();
            _arquivo.regD001.reg = "D001";
            _arquivo.regD001.ind_mov = "1";
        }

        public void MontarRegD990()
        {
            int qtd = 0;
            _arquivo.regD990 = new dRegD990();
            if (_arquivo.regD001 != null) qtd++;
            _arquivo.regD990.reg = "D990";
            _arquivo.regD990.qtd_lin_d = qtd + 1;
        }

        public void MontarRegE001()
        {
            _arquivo.regE001 = new dRegE001();
            _arquivo.regE001.reg = "E001";
            _arquivo.regE001.ind_mov = "0";
        }

        public void MontarRegE100(DateTime dataInicio, DateTime dataFim)
        {
            _arquivo.regE100 = new dRegE100();
            _arquivo.regE100.reg = "E100";
            _arquivo.regE100.dt_ini = dataInicio;
            _arquivo.regE100.dt_fin = dataFim;
        }

        public void MontarRegE110()
        {
            decimal totalDebito = 0, totalCredito = 0;

            _arquivo.regE110 = new dRegE110();
            _arquivo.regE110.vl_tot_debitos = 0;
            _arquivo.regE110.vl_aj_debitos = 0;
            _arquivo.regE110.vl_tot_aj_debitos = 0;
            _arquivo.regE110.vl_estornos_cred = 0;
            _arquivo.regE110.vl_tot_creditos = 0;
            _arquivo.regE110.vl_aj_creditos = 0;
            _arquivo.regE110.vl_tot_aj_creditos = 0;
            _arquivo.regE110.vl_estornos_deb = 0;
            _arquivo.regE110.vl_sld_credor_ant = 0;
            _arquivo.regE110.vl_sld_apurado = 0;
            _arquivo.regE110.vl_tot_ded = 0;
            _arquivo.regE110.vl_icms_recolher = 0;
            _arquivo.regE110.vl_sld_credor_transportar = 0;
            _arquivo.regE110.deb_esp = 0;

            if (_arquivo.regC190 != null)
                _arquivo.regE110.vl_tot_creditos = _arquivo.regC190.vl_icms;

            totalDebito += _arquivo.regE110.vl_tot_debitos ?? 0;
            totalDebito += _arquivo.regE110.vl_aj_debitos ?? 0;
            totalDebito += _arquivo.regE110.vl_tot_aj_debitos ?? 0;
            totalDebito += _arquivo.regE110.vl_estornos_cred ?? 0;

            totalCredito += _arquivo.regE110.vl_tot_creditos ?? 0;
            totalCredito += _arquivo.regE110.vl_aj_creditos ?? 0;
            totalCredito += _arquivo.regE110.vl_tot_aj_creditos ?? 0;
            totalCredito += _arquivo.regE110.vl_estornos_deb ?? 0;
            totalCredito += _arquivo.regE110.vl_sld_credor_ant ?? 0;

            if ((totalDebito - totalCredito) >= 0)
            {
                _arquivo.regE110.vl_sld_apurado = totalDebito - totalCredito;
                _arquivo.regE110.vl_sld_credor_transportar = 0;
            }
            else
            {
                _arquivo.regE110.vl_sld_apurado = 0;
                _arquivo.regE110.vl_sld_credor_transportar = (totalDebito - totalCredito) * -1;
            }

            _arquivo.regE110.reg = "E110";
        }

        public void MontarRegE990()
        {
            int qtd = 0;
            _arquivo.regE990 = new dRegE990();
            if (_arquivo.regE001 != null) qtd++;
            if (_arquivo.regE100 != null) qtd++;
            if (_arquivo.regE110 != null) qtd++;
            _arquivo.regE990.reg = "E990";
            _arquivo.regE990.qtd_lin_e = qtd + 1;
        }

        public void MontarRegG001()
        {
            _arquivo.regG001 = new dRegG001();
            _arquivo.regG001.reg = "G001";
            _arquivo.regG001.ind_mov = "1";
        }

        public void MontarRegG990()
        {
            int qtd = 0;
            _arquivo.regG990 = new dRegG990();
            if (_arquivo.regG001 != null) qtd++;
            _arquivo.regG990.reg = "G990";
            _arquivo.regG990.qtd_lin_g = qtd + 1;
        }

        public void MontarRegH001()
        {
            _arquivo.regH001 = new dRegH001();
            _arquivo.regH001.reg = "H001";
            _arquivo.regH001.ind_mov = "0";
        }

        public void MontarRegH005(DateTime dataFim)
        {
            decimal valor = 0;

            if (_arquivo.colH010 != null && _arquivo.colH010.Count > 0)
            {
                foreach (var item in _arquivo.colH010)
                    if (item.vl_item.HasValue) valor += item.vl_item.Value;
            }

            _arquivo.regH005 = new dRegH005();
            _arquivo.regH005.reg = "H005";
            _arquivo.regH005.dt_inv = dataFim;
            _arquivo.regH005.vl_inv = valor;
            _arquivo.regH005.mot_inv = "01";
        }

        public void MontarRegH010(DateTime dataInicio, DateTime dataFim)
        {
            var _pRegH010 = new pRegH010();
            var _colecaoH010 = _pRegH010.Consultar(dataInicio, dataFim);

            if (_colecaoH010 != null && _colecaoH010.Count > 0)
            {
                _arquivo.colH010 = new ColecaoH010();
                foreach (var item in _colecaoH010)
                {
                    var reg = new dRegH010();
                    reg.reg = "H010";
                    reg.cod_item = item.cod_item;
                    reg.unid = item.unid;
                    reg.qtd = item.qtd;
                    reg.vl_unit = item.vl_unit;
                    reg.vl_item = item.vl_item;
                    reg.ind_prop = "0";
                    reg.cod_part = item.cod_part;
                    reg.txt_compl = item.txt_compl;
                    reg.cod_cta = item.cod_cta;
                    reg.vl_item_ir = item.vl_item;
                    _arquivo.colH010.Add(reg);
                }
            }
        }

        public void MontarRegH990()
        {
            int qtd = 0;
            _arquivo.regH990 = new dRegH990();
            if (_arquivo.regH001 != null) qtd++;
            if (_arquivo.regH005 != null) qtd++;
            if (_arquivo.colH010 != null) qtd += _arquivo.colH010.Count;
            _arquivo.regH990.reg = "H990";
            _arquivo.regH990.qtd_lin_h = qtd + 1;
        }

        public void MontarReg1001()
        {
            _arquivo.reg1001 = new dReg1001();
            _arquivo.reg1001.reg = "1001";
            _arquivo.reg1001.ind_mov = "0";
        }

        public void MontarReg1010()
        {
            _arquivo.reg1010 = new dReg1010();
            _arquivo.reg1010.reg = "1010";
            _arquivo.reg1010.ind_exp = "N";
            _arquivo.reg1010.ind_ccrf = "N";
            _arquivo.reg1010.ind_comb = "N";
            _arquivo.reg1010.ind_usina = "N";
            _arquivo.reg1010.ind_va = "N";
            _arquivo.reg1010.ind_ee = "N";
            _arquivo.reg1010.ind_cart = "N";
            _arquivo.reg1010.ind_form = "N";
            _arquivo.reg1010.ind_aer = "N";
        }

        public void MontarReg1990()
        {
            int qtd = 0;
            _arquivo.reg1990 = new dReg1990();
            if (_arquivo.reg1001 != null) qtd++;
            if (_arquivo.reg1010 != null) qtd++;
            _arquivo.reg1990.reg = "1990";
            _arquivo.reg1990.qtd_lin_1 = qtd + 1;
        }

        public void MontarReg9001()
        {
            _arquivo.reg9001 = new dReg9001();
            _arquivo.reg9001.reg = "9001";
            _arquivo.reg9001.ind_mov = "0";
        }

        public void MontarReg9900()
        {
            var _dReg9900 = new dReg9900();
            _arquivo.col9900 = new Colecao9900();

            if (_arquivo.reg0000 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("0000", 1));
            if (_arquivo.reg0001 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("0001", 1));
            if (_arquivo.reg0005 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("0005", 1));
            if (_arquivo.reg0100 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("0100", 1));
            if (_arquivo.col0150 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("0150", _arquivo.col0150.Count));
            if (_arquivo.col0190 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("0190", _arquivo.col0190.Count));
            if (_arquivo.col0200 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("0200", _arquivo.col0200.Count));
            if (_arquivo.reg0990 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("0990", 1));
            if (_arquivo.regC001 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("C001", 1));
            if (_arquivo.colC100 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("C100", _arquivo.colC100.Count));
            if (_arquivo.colC170 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("C170", _arquivo.colC170.Count));
            if (_arquivo.regC190 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("C190", 1));
            if (_arquivo.regC990 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("C990", 1));
            if (_arquivo.regD001 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("D001", 1));
            if (_arquivo.regD990 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("D990", 1));
            if (_arquivo.regE001 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("E001", 1));
            if (_arquivo.regE100 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("E100", 1));
            if (_arquivo.regE110 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("E110", 1));
            if (_arquivo.regE990 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("E990", 1));
            if (_arquivo.regG001 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("G001", 1));
            if (_arquivo.regG990 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("G990", 1));
            if (_arquivo.regH001 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("H001", 1));
            if (_arquivo.regH005 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("H005", 1));
            if (_arquivo.colH010 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("H010", _arquivo.colH010.Count));
            if (_arquivo.regH990 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("H990", 1));
            if (_arquivo.reg1001 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("1001", 1));
            if (_arquivo.reg1010 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("1010", 1));
            if (_arquivo.reg1990 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("1990", 1));
            if (_arquivo.reg9001 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("9001", 1));
            if (_arquivo.col9900 != null) _arquivo.col9900.Add(_dReg9900.MontarReg9900("9900", _arquivo.col9900.Count + 3));
            _arquivo.col9900.Add(_dReg9900.MontarReg9900("9990", 1));
            _arquivo.col9900.Add(_dReg9900.MontarReg9900("9999", 1));
        }

        public void MontarReg9990()
        {
            int qtd = 0;
            _arquivo.reg9990 = new dReg9990();
            if (_arquivo.reg9001 != null) qtd++;
            if (_arquivo.col9900 != null) qtd += _arquivo.col9900.Count;
            qtd++; // reg9990
            qtd++; // reg9999
            _arquivo.reg9990.reg = "9990";
            _arquivo.reg9990.qtd_lin_9 = qtd;
        }

        public void MontarReg9999()
        {
            int qtd = 0;
            _arquivo.reg9999 = new dReg9999();

            if (_arquivo.reg0990?.qtd_lin_0.HasValue == true) qtd += Convert.ToInt32(_arquivo.reg0990.qtd_lin_0);
            if (_arquivo.regC990?.qtd_lin_c.HasValue == true) qtd += Convert.ToInt32(_arquivo.regC990.qtd_lin_c);
            if (_arquivo.regD990?.qtd_lin_d.HasValue == true) qtd += Convert.ToInt32(_arquivo.regD990.qtd_lin_d);
            if (_arquivo.regE990?.qtd_lin_e.HasValue == true) qtd += Convert.ToInt32(_arquivo.regE990.qtd_lin_e);
            if (_arquivo.regG990?.qtd_lin_g.HasValue == true) qtd += Convert.ToInt32(_arquivo.regG990.qtd_lin_g);
            if (_arquivo.regH990?.qtd_lin_h.HasValue == true) qtd += Convert.ToInt32(_arquivo.regH990.qtd_lin_h);
            if (_arquivo.reg1990?.qtd_lin_1.HasValue == true) qtd += Convert.ToInt32(_arquivo.reg1990.qtd_lin_1);
            if (_arquivo.reg9990?.qtd_lin_9.HasValue == true) qtd += Convert.ToInt32(_arquivo.reg9990.qtd_lin_9);

            _arquivo.reg9999.reg = "9999";
            _arquivo.reg9999.qtd_lin = qtd;
        }
    }
}
