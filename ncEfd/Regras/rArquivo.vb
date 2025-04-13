Imports System.Text
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Namespace nsEfd

    Public Class rArquivo

        Private _arquivo As dArquivo

        Public Function MontarRelatorio(ByVal dataInicio As Date, ByVal dataFim As Date) As dArquivo

            _arquivo = New dArquivo()

            '-- Registro 0000 -- ABERTURA DO ARQUIVO DIGITAL E IDENTIFICAÇÃO DA ENTIDADE
            MontarReg0000(dataInicio, dataFim)

            '-- Registro 0001 -- ABERTURA DO BLOCO 0
            MontarReg0001()
            '-- Registro 0005 -- DADOS COMPLEMENTARES DA ENTIDADE
            MontarReg0005()
            '-- Registro 0100 -- DADOS DO CONTABILISTA
            MontarReg0100()
            '-- Registro 0150 -- TABELA DE CADASTRO DO PARTICIPANTE
            MontarReg0150(dataInicio, dataFim)
            '-- Registro 0190 -- IDENTIFICAÇÃO DAS UNIDADES DE MEDIDA
            MontarReg0190(dataInicio, dataFim)
            '-- Registro 0200 -- TABELA DE IDENTIFICAÇÃO DO ITEM (PRODUTO E SERVIÇOS)
            MontarReg0200(dataInicio, dataFim)
            '-- Registro 0990 -- ENCERRAMENTO DO BLOCO 0
            MontarReg0990()

            '-- Registro C001 -- ABERTURA DO BLOCO C
            MontarRegC001()
            '-- Registro C100 -- NOTA FISCAL (CÓDIGO 01), NOTA FISCAL AVULSA (CÓDIGO 1B), NOTA FISCAL DE PRODUTOR (CÓDIGO 04) E NF-e (CÓDIGO 55).
            MontarRegC100(dataInicio, dataFim)
            '-- Registro C170 -- ITENS DO DOCUMENTO (CÓDIGO 01, 1B, 04 e 55).
            MontarRegC170(dataInicio, dataFim)
            '-- Registro C190 -- REGISTRO ANALÍTICO DO DOCUMENTO (CÓDIGO 01, 1B, 04 E 55).
            MontarRegC190()
            '-- Registro C990 -- ENCERRAMENTO DO BLOCO C
            MontarRegC990()

            '-- REGISTRO D001: ABERTURA DO BLOCO D
            MontarRegD001()
            '-- REGISTRO D990: ENCERRAMENTO DO BLOCO D.
            MontarRegD990()

            '-- REGISTRO E001: ABERTURA DO BLOCO E
            MontarRegE001()
            '-- REGISTRO E100: PERÍODO DA APURAÇÃO DO ICMS.
            MontarRegE100(dataInicio, dataFim)
            '-- REGISTRO E110: APURAÇÃO DO ICMS – OPERAÇÕES PRÓPRIAS.
            MontarRegE110()
            '-- REGISTRO E990: ENCERRAMENTO DO BLOCO E
            MontarRegE990()

            '-- REGISTRO G001: ABERTURA DO BLOCO G
            MontarRegG001()
            '-- REGISTRO G990: ENCERRAMENTO DO BLOCO G
            MontarRegG990()

            '-- REGISTRO H001: ABERTURA DO BLOCO H
            MontarRegH001()
            '-- REGISTRO H010: INVENTÁRIO.
            MontarRegH010(dataInicio, dataFim)
            '-- REGISTRO H005: TOTAIS DO INVENTÁRIO
            MontarRegH005(dataFim)
            '-- REGISTRO H990: ENCERRAMENTO DO BLOCO H.
            MontarRegH990()

            '-- REGISTRO 1001: ABERTURA DO BLOCO 1
            MontarReg1001()
            '-- REGISTRO 1010: OBRIGATORIEDADE DE REGISTROS DO BLOCO 1
            MontarReg1010()
            '-- REGISTRO 1990: ENCERRAMENTO DO BLOCO 1
            MontarReg1990()

            '-- REGISTRO 9001: ABERTURA DO BLOCO 9
            MontarReg9001()
            '-- REGISTRO 9900: REGISTROS DO ARQUIVO.
            MontarReg9900()
            '-- REGISTRO 9990: ENCERRAMENTO DO BLOCO 9
            MontarReg9990()

            '-- REGISTRO 9999: ENCERRAMENTO DO ARQUIVO DIGITAL.
            MontarReg9999()

            Return _arquivo

        End Function

        '-- Registro 0000 -- ABERTURA DO ARQUIVO DIGITAL E IDENTIFICAÇÃO DA ENTIDADE
        Public Sub MontarReg0000(ByVal dataInicio As Date, ByVal dataFim As Date)

            Dim _pReg0000 As pReg0000 = New pReg0000()
            Dim _dReg0000 As dReg0000 = New dReg0000()

            _dReg0000 = _pReg0000.Consultar()

            If _dReg0000 IsNot Nothing Then
                _arquivo.reg0000 = New dReg0000()

                _arquivo.reg0000.reg = "0000"
                _arquivo.reg0000.cod_ver = _dReg0000.cod_ver
                _arquivo.reg0000.cod_fin = _dReg0000.cod_fin
                _arquivo.reg0000.dt_ini = dataInicio
                _arquivo.reg0000.dt_fin = dataFim
                _arquivo.reg0000.nome = _dReg0000.nome
                If _dReg0000.tipoPessoa = "J" Then
                    _arquivo.reg0000.cnpj = _dReg0000.cpfCnpj
                ElseIf _dReg0000.tipoPessoa = "F" Then
                    _arquivo.reg0000.cpf = _dReg0000.cpfCnpj
                End If
                _arquivo.reg0000.uf = _dReg0000.uf
                _arquivo.reg0000.ie = _dReg0000.ie
                _arquivo.reg0000.cod_mun = _dReg0000.cod_mun
                _arquivo.reg0000.im = _dReg0000.im
                _arquivo.reg0000.suframa = _dReg0000.suframa
                _arquivo.reg0000.ind_perfil = _dReg0000.ind_perfil
                _arquivo.reg0000.ind_ativ = _dReg0000.ind_ativ

                _arquivo.reg0000.tipoPessoa = _dReg0000.tipoPessoa
                _arquivo.reg0000.cpfCnpj = _dReg0000.cpfCnpj
            End If

        End Sub

        '-- Registro 0001 -- ABERTURA DO BLOCO 0
        Public Sub MontarReg0001()

            _arquivo.reg0001 = New dReg0001()

            _arquivo.reg0001.reg = "0001"
            _arquivo.reg0001.ind_mov = "0"

        End Sub

        '-- Registro 0005 -- DADOS COMPLEMENTARES DA ENTIDADE
        Public Sub MontarReg0005()

            Dim _pReg0005 As pReg0005 = New pReg0005()
            Dim _dReg0005 As dReg0005 = New dReg0005()

            _dReg0005 = _pReg0005.Consultar()

            If _dReg0005 IsNot Nothing Then
                _arquivo.reg0005 = New dReg0005()

                _arquivo.reg0005.reg = "0005"
                _arquivo.reg0005.fantasia = _dReg0005.fantasia
                _arquivo.reg0005.cep = _dReg0005.cep
                _arquivo.reg0005.ende = _dReg0005.ende
                _arquivo.reg0005.num = _dReg0005.num
                _arquivo.reg0005.compl = _dReg0005.compl
                _arquivo.reg0005.bairro = _dReg0005.bairro
                _arquivo.reg0005.fone = _dReg0005.fone
                _arquivo.reg0005.fax = _dReg0005.fax
                _arquivo.reg0005.email = _dReg0005.email
            End If

        End Sub

        Public Sub MontarReg0100()

            Dim _pReg0100 As pReg0100 = New pReg0100()
            Dim _dReg0100 As dReg0100 = New dReg0100()

            _dReg0100 = _pReg0100.Consultar()

            If _dReg0100 IsNot Nothing Then
                _arquivo.reg0100 = New dReg0100()

                _arquivo.reg0100.reg = "0100"
                _arquivo.reg0100.nome = _dReg0100.nome
                _arquivo.reg0100.cpf = _dReg0100.cpf
                _arquivo.reg0100.crc = _dReg0100.crc
                _arquivo.reg0100.cnpj = _dReg0100.cnpj
                _arquivo.reg0100.cep = _dReg0100.cep
                _arquivo.reg0100.ende = _dReg0100.ende
                _arquivo.reg0100.num = _dReg0100.num
                _arquivo.reg0100.compl = _dReg0100.compl
                _arquivo.reg0100.bairro = _dReg0100.bairro
                _arquivo.reg0100.fone = _dReg0100.fone
                _arquivo.reg0100.fax = _dReg0100.fax
                _arquivo.reg0100.email = _dReg0100.email
                _arquivo.reg0100.cod_mun = _dReg0100.cod_mun
            End If

        End Sub

        Public Sub MontarReg0150(ByVal dataInicio As Date, ByVal dataFim As Date)

            Dim _pReg0150 As pReg0150 = New pReg0150()
            Dim _colecao0150 As Colecao0150 = New Colecao0150()

            _colecao0150 = _pReg0150.Consultar(dataInicio, dataFim)

            If _colecao0150 IsNot Nothing Then
                If _colecao0150.Count > 0 Then
                    _arquivo.col0150 = New Colecao0150()

                    For Each item As dReg0150 In _colecao0150
                        Dim _dReg0150 As dReg0150 = New dReg0150()

                        _dReg0150.reg = "0150"
                        _dReg0150.cod_part = item.cod_part
                        _dReg0150.nome = item.nome
                        _dReg0150.cod_pais = "1058"
                        _dReg0150.cnpj = item.cnpj
                        _dReg0150.cpf = item.cpf
                        _dReg0150.ie = item.ie
                        _dReg0150.cod_mun = item.cod_mun
                        _dReg0150.suframa = item.suframa
                        _dReg0150.ende = item.ende
                        _dReg0150.num = item.num
                        _dReg0150.compl = item.compl
                        _dReg0150.bairro = item.bairro

                        _arquivo.col0150.Add(_dReg0150)
                    Next
                End If
            End If

        End Sub

        Public Sub MontarReg0190(ByVal dataInicio As Date, ByVal dataFim As Date)

            Dim _pReg0190 As pReg0190 = New pReg0190()
            Dim _colecao0190 As Colecao0190 = New Colecao0190()

            _colecao0190 = _pReg0190.Consultar(dataInicio, dataFim)

            If _colecao0190 IsNot Nothing Then
                If _colecao0190.Count > 0 Then
                    _arquivo.col0190 = New Colecao0190()

                    For Each item As dReg0190 In _colecao0190
                        Dim _dReg0190 As dReg0190 = New dReg0190()

                        _dReg0190.reg = "0190"
                        _dReg0190.unid = item.unid
                        _dReg0190.descr = item.descr

                        _arquivo.col0190.Add(_dReg0190)
                    Next
                End If
            End If

        End Sub

        Public Sub MontarReg0200(ByVal dataInicio As Date, ByVal dataFim As Date)

            Dim _pReg0200 As pReg0200 = New pReg0200()
            Dim _colecao0200 As Colecao0200 = New Colecao0200()

            _colecao0200 = _pReg0200.Consultar(dataInicio, dataFim)

            If _colecao0200 IsNot Nothing Then
                If _colecao0200.Count > 0 Then
                    _arquivo.col0200 = New Colecao0200()

                    For Each item As dReg0200 In _colecao0200
                        Dim _dReg0200 As dReg0200 = New dReg0200()

                        _dReg0200.reg = "0200"
                        _dReg0200.cod_item = item.cod_item
                        _dReg0200.descr_item = item.descr_item
                        _dReg0200.cod_barra = item.cod_barra
                        _dReg0200.cod_ant_item = item.cod_ant_item
                        _dReg0200.unid_inv = item.unid_inv
                        _dReg0200.tipo_item = "00"
                        _dReg0200.cod_ncm = item.cod_ncm
                        _dReg0200.ex_ipi = item.ex_ipi
                        _dReg0200.cod_gen = item.cod_gen
                        _dReg0200.cod_lst = item.cod_lst
                        _dReg0200.aliq_icms = IIf(item.aliq_icms = "FF", 0.0, item.aliq_icms)

                        _arquivo.col0200.Add(_dReg0200)
                    Next
                End If
            End If

        End Sub

        Public Sub MontarReg0990()

            Dim qtd As Integer = 0

            _arquivo.reg0990 = New dReg0990()

            If _arquivo.reg0000 IsNot Nothing Then
                qtd = qtd + 1
            End If
            If _arquivo.reg0001 IsNot Nothing Then
                qtd = qtd + 1
            End If
            If _arquivo.reg0005 IsNot Nothing Then
                qtd = qtd + 1
            End If
            If _arquivo.reg0100 IsNot Nothing Then
                qtd = qtd + 1
            End If
            If _arquivo.col0150 IsNot Nothing Then
                qtd = qtd + _arquivo.col0150.Count
            End If
            If _arquivo.col0190 IsNot Nothing Then
                qtd = qtd + _arquivo.col0190.Count
            End If
            If _arquivo.col0200 IsNot Nothing Then
                qtd = qtd + _arquivo.col0200.Count
            End If

            _arquivo.reg0990.reg = "0990"
            _arquivo.reg0990.qtd_lin_0 = qtd + 1

        End Sub

        Public Sub MontarRegC001()

            _arquivo.regC001 = New dRegC001()

            _arquivo.regC001.reg = "C001"
            _arquivo.regC001.ind_mov = "0"

        End Sub

        Public Sub MontarRegC100(ByVal dataInicio As Date, ByVal dataFim As Date)

            Dim _pRegC100 As pRegC100 = New pRegC100()
            Dim _colecaoC100 As ColecaoC100 = New ColecaoC100()

            _colecaoC100 = _pRegC100.Consultar(dataInicio, dataFim)

            If _colecaoC100 IsNot Nothing Then
                If _colecaoC100.Count > 0 Then
                    _arquivo.colC100 = New ColecaoC100()

                    For Each item As dRegC100 In _colecaoC100
                        Dim _dRegC100 As dRegC100 = New dRegC100()

                        _dRegC100.reg = "C100"
                        _dRegC100.tipoFluxo = item.tipoFluxo
                        _dRegC100.tipoEmissao = item.tipoEmissao
                        _dRegC100.cod_part = item.cod_part
                        _dRegC100.tipoNF = item.tipoNF
                        _dRegC100.situacaoNF = item.situacaoNF
                        _dRegC100.ser = item.ser
                        _dRegC100.num_doc = item.num_doc
                        _dRegC100.chv_nfe = item.chv_nfe
                        _dRegC100.dt_doc = item.dt_doc
                        _dRegC100.dt_e_s = item.dt_e_s
                        _dRegC100.vl_doc = item.vl_doc
                        _dRegC100.vl_abat_nt = item.vl_abat_nt
                        _dRegC100.tipoPagto = item.tipoPagto
                        _dRegC100.vl_desc = item.vl_desc
                        _dRegC100.vl_merc = item.vl_merc
                        _dRegC100.tipoFrete = item.tipoFrete
                        _dRegC100.vl_frt = item.vl_frt
                        _dRegC100.vl_seg = item.vl_seg
                        _dRegC100.vl_out_da = item.vl_out_da
                        _dRegC100.vl_bc_icms = item.vl_bc_icms
                        _dRegC100.vl_icms = item.vl_icms
                        _dRegC100.vl_bc_icms_st = item.vl_bc_icms_st
                        _dRegC100.vl_icms_st = item.vl_icms_st
                        _dRegC100.vl_ipi = item.vl_ipi
                        _dRegC100.vl_pis = item.vl_pis
                        _dRegC100.vl_cofins = item.vl_cofins
                        _dRegC100.vl_pis_st = item.vl_pis_st
                        _dRegC100.vl_cofins_st = item.vl_cofins_st

                        _arquivo.colC100.Add(_dRegC100)

                    Next
                End If
            End If

        End Sub

        Public Sub MontarRegC170(ByVal dataInicio As Date, ByVal dataFim As Date)

            Dim _pRegC170 As New pRegC170()
            Dim _colecaoC170 As New ColecaoC170

            If _arquivo.colC100 IsNot Nothing Then
                If _arquivo.colC100.Count > 0 Then

                    _colecaoC170 = _pRegC170.Consultar(dataInicio, dataFim)
                    _arquivo.colC170 = New ColecaoC170()

                    If _colecaoC170 IsNot Nothing Then
                        If _colecaoC170.Count > 0 Then

                            Dim contador As Integer = 0

                            For Each item As dRegC170 In _colecaoC170

                                Dim _dRegC170 As New dRegC170()

                                contador += 1
                                _dRegC170.reg = "C170"
                                _dRegC170.num_item = contador
                                _dRegC170.num_doc = item.num_doc
                                _dRegC170.cod_item = item.cod_item
                                _dRegC170.descr_compl = item.descr_compl
                                _dRegC170.qtd = item.qtd
                                _dRegC170.unid = item.unid
                                _dRegC170.vl_item = item.vl_item
                                _dRegC170.ind_mov = 1
                                _dRegC170.cst_icms = "000"
                                _dRegC170.cfop = "1102"
                                _dRegC170.aliq_icms = IIf(item.aliq_icms.ToString() = "FF", 0.0, item.aliq_icms)

                                _arquivo.colC170.Add(_dRegC170)
                            Next

                        End If
                    End If

                End If
            End If

        End Sub

        Public Sub MontarRegC190()

            Dim _vl_opr As Decimal = 0
            Dim _vl_bc_icms As Decimal = 0
            Dim _vl_icms As Decimal = 0
            Dim _vl_bc_icms_st As Decimal = 0
            Dim _vl_icms_st As Decimal = 0
            Dim _vl_ipi As Decimal = 0

            If _arquivo.colC100 IsNot Nothing Then
                If _arquivo.colC100.Count > 0 Then
                    If _arquivo.regC190 Is Nothing Then
                        _arquivo.regC190 = New dRegC190()
                    End If

                    For Each item As dRegC100 In _arquivo.colC100
                        If Not item.vl_doc.Equals(Nothing) Then
                            _vl_opr = _vl_opr + item.vl_doc
                        End If
                        If Not item.vl_bc_icms.Equals(Nothing) Then
                            _vl_bc_icms = _vl_bc_icms + item.vl_bc_icms
                        End If
                        If Not item.vl_icms.Equals(Nothing) Then
                            _vl_icms = _vl_icms + item.vl_icms
                        End If
                        If Not item.vl_bc_icms_st.Equals(Nothing) Then
                            _vl_bc_icms_st = _vl_bc_icms_st + item.vl_bc_icms_st
                        End If
                        If Not item.vl_icms_st.Equals(Nothing) Then
                            _vl_icms_st = _vl_icms_st + item.vl_icms_st
                        End If
                        If Not item.vl_ipi.Equals(Nothing) Then
                            _vl_ipi = _vl_ipi + item.vl_ipi
                        End If
                    Next

                    _arquivo.regC190.reg = "C190"
                    _arquivo.regC190.cst_icms = "000"
                    _arquivo.regC190.cfop = "1102"
                    _arquivo.regC190.aliq_icms = 0
                    _arquivo.regC190.vl_opr = _vl_opr
                    _arquivo.regC190.vl_bc_icms = _vl_bc_icms
                    _arquivo.regC190.vl_icms = _vl_icms
                    _arquivo.regC190.vl_bc_icms_st = _vl_bc_icms_st
                    _arquivo.regC190.vl_icms_st = _vl_icms_st
                    _arquivo.regC190.vl_red_bc = 0
                    _arquivo.regC190.vl_ipi = _vl_ipi
                    _arquivo.regC190.cod_obs = Nothing
                End If
            End If

        End Sub


        Public Sub MontarRegC990()

            Dim qtd As Integer = 0

            _arquivo.regC990 = New dRegC990()

            If _arquivo.regC001 IsNot Nothing Then
                qtd = qtd + 1
            End If
            If _arquivo.colC100 IsNot Nothing Then
                qtd = qtd + _arquivo.colC100.Count
            End If
            If _arquivo.colC170 IsNot Nothing Then
                qtd = qtd + _arquivo.colC170.Count
            End If
            If _arquivo.regC190 IsNot Nothing Then
                qtd = qtd + 1
            End If

            _arquivo.regC990.reg = "C990"
            _arquivo.regC990.qtd_lin_c = qtd + 1

        End Sub

        Public Sub MontarRegD001()

            _arquivo.regD001 = New dRegD001()

            _arquivo.regD001.reg = "D001"
            _arquivo.regD001.ind_mov = "1"

        End Sub

        Public Sub MontarRegD990()

            Dim qtd As Integer = 0

            _arquivo.regD990 = New dRegD990()

            If _arquivo.regD001 IsNot Nothing Then
                qtd = qtd + 1
            End If

            _arquivo.regD990.reg = "D990"
            _arquivo.regD990.qtd_lin_d = qtd + 1

        End Sub

        Public Sub MontarRegE001()

            _arquivo.regE001 = New dRegE001()

            _arquivo.regE001.reg = "E001"
            _arquivo.regE001.ind_mov = "0"

        End Sub

        Public Sub MontarRegE100(ByVal dataInicio As Date, ByVal dataFim As Date)

            _arquivo.regE100 = New dRegE100()

            _arquivo.regE100.reg = "E100"
            _arquivo.regE100.dt_ini = dataInicio
            _arquivo.regE100.dt_fin = dataFim

        End Sub

        Public Sub MontarRegE110()

            Dim totalDebito As Decimal = 0
            Dim totalCredito As Decimal = 0

            _arquivo.regE110 = New dRegE110()

            _arquivo.regE110.vl_tot_debitos = 0
            _arquivo.regE110.vl_aj_debitos = 0
            _arquivo.regE110.vl_tot_aj_debitos = 0
            _arquivo.regE110.vl_estornos_cred = 0
            _arquivo.regE110.vl_tot_creditos = 0
            _arquivo.regE110.vl_aj_creditos = 0
            _arquivo.regE110.vl_tot_aj_creditos = 0
            _arquivo.regE110.vl_estornos_deb = 0
            _arquivo.regE110.vl_sld_credor_ant = 0
            _arquivo.regE110.vl_sld_apurado = 0
            _arquivo.regE110.vl_tot_ded = 0
            _arquivo.regE110.vl_icms_recolher = 0
            _arquivo.regE110.vl_sld_credor_transportar = 0
            _arquivo.regE110.deb_esp = 0

            If _arquivo.regC190 IsNot Nothing Then
                _arquivo.regE110.vl_tot_creditos = _arquivo.regC190.vl_icms
            End If

            ' debitos
            totalDebito = totalDebito + _arquivo.regE110.vl_tot_debitos
            totalDebito = totalDebito + _arquivo.regE110.vl_aj_debitos
            totalDebito = totalDebito + _arquivo.regE110.vl_tot_aj_debitos
            totalDebito = totalDebito + _arquivo.regE110.vl_estornos_cred

            ' creditos
            totalCredito = totalCredito + _arquivo.regE110.vl_tot_creditos
            totalCredito = totalCredito + _arquivo.regE110.vl_aj_creditos
            totalCredito = totalCredito + _arquivo.regE110.vl_tot_aj_creditos
            totalCredito = totalCredito + _arquivo.regE110.vl_estornos_deb
            totalCredito = totalCredito + _arquivo.regE110.vl_sld_credor_ant

            If (totalDebito - totalCredito) >= 0 Then
                _arquivo.regE110.vl_sld_apurado = totalDebito - totalCredito
                _arquivo.regE110.vl_sld_credor_transportar = 0
            Else
                _arquivo.regE110.vl_sld_apurado = 0
                _arquivo.regE110.vl_sld_credor_transportar = (totalDebito - totalCredito) * -1
            End If

            _arquivo.regE110.reg = "E110"

        End Sub

        Public Sub MontarRegE990()

            Dim qtd As Integer = 0

            _arquivo.regE990 = New dRegE990()

            If _arquivo.regE001 IsNot Nothing Then
                qtd = qtd + 1
            End If
            If _arquivo.regE100 IsNot Nothing Then
                qtd = qtd + 1
            End If
            If _arquivo.regE110 IsNot Nothing Then
                qtd = qtd + 1
            End If

            _arquivo.regE990.reg = "E990"
            _arquivo.regE990.qtd_lin_e = qtd + 1

        End Sub

        Public Sub MontarRegG001()

            _arquivo.regG001 = New dRegG001()

            _arquivo.regG001.reg = "G001"
            _arquivo.regG001.ind_mov = "1"

        End Sub

        Public Sub MontarRegG990()

            Dim qtd As Integer = 0

            _arquivo.regG990 = New dRegG990()

            If _arquivo.regG001 IsNot Nothing Then
                qtd = qtd + 1
            End If

            _arquivo.regG990.reg = "G990"
            _arquivo.regG990.qtd_lin_g = qtd + 1

        End Sub

        Public Sub MontarRegH001()

            _arquivo.regH001 = New dRegH001()

            _arquivo.regH001.reg = "H001"
            _arquivo.regH001.ind_mov = "0"

        End Sub

        Public Sub MontarRegH005(ByVal dataFim As Date)

            Dim valor As Decimal = 0

            If _arquivo.colH010 IsNot Nothing Then
                If _arquivo.colH010.Count > 0 Then
                    For Each item As dRegH010 In _arquivo.colH010
                        If Not item.vl_item.Equals(Nothing) Then
                            valor = valor + item.vl_item
                        End If
                    Next
                End If
            End If

            _arquivo.regH005 = New dRegH005()

            _arquivo.regH005.reg = "H005"
            _arquivo.regH005.dt_inv = dataFim
            _arquivo.regH005.vl_inv = valor
            _arquivo.regH005.mot_inv = "01"

        End Sub

        Public Sub MontarRegH010(ByVal dataInicio As Date, ByVal dataFim As Date)

            Dim _pRegH010 As pRegH010 = New pRegH010()
            Dim _colecaoH010 As ColecaoH010 = New ColecaoH010()

            _colecaoH010 = _pRegH010.Consultar(dataInicio, dataFim)

            If _colecaoH010 IsNot Nothing Then
                If _colecaoH010.Count > 0 Then
                    _arquivo.colH010 = New ColecaoH010()

                    For Each item As dRegH010 In _colecaoH010
                        Dim _dRegH010 As dRegH010 = New dRegH010()

                        _dRegH010.reg = "H010"
                        _dRegH010.cod_item = item.cod_item
                        _dRegH010.unid = item.unid
                        _dRegH010.qtd = item.qtd
                        _dRegH010.vl_unit = item.vl_unit
                        _dRegH010.vl_item = item.vl_item
                        _dRegH010.ind_prop = "0"
                        _dRegH010.cod_part = item.cod_part
                        _dRegH010.txt_compl = item.txt_compl
                        _dRegH010.cod_cta = item.cod_cta
                        _dRegH010.vl_item_ir = item.vl_item

                        _arquivo.colH010.Add(_dRegH010)
                    Next
                End If
            End If

        End Sub

        Public Sub MontarRegH990()

            Dim qtd As Integer = 0

            _arquivo.regH990 = New dRegH990()

            If _arquivo.regH001 IsNot Nothing Then
                qtd = qtd + 1
            End If
            If _arquivo.regH005 IsNot Nothing Then
                qtd = qtd + 1
            End If
            If _arquivo.colH010 IsNot Nothing Then
                qtd = qtd + _arquivo.colH010.Count
            End If

            _arquivo.regH990.reg = "H990"
            _arquivo.regH990.qtd_lin_h = qtd + 1

        End Sub

        Public Sub MontarReg1001()

            _arquivo.reg1001 = New dReg1001()

            _arquivo.reg1001.reg = "1001"
            _arquivo.reg1001.ind_mov = "0"

        End Sub

        Public Sub MontarReg1010()

            _arquivo.reg1010 = New dReg1010()

            _arquivo.reg1010.reg = "1010"
            _arquivo.reg1010.ind_exp = "N"
            _arquivo.reg1010.ind_ccrf = "N"
            _arquivo.reg1010.ind_comb = "N"
            _arquivo.reg1010.ind_usina = "N"
            _arquivo.reg1010.ind_va = "N"
            _arquivo.reg1010.ind_ee = "N"
            _arquivo.reg1010.ind_cart = "N"
            _arquivo.reg1010.ind_form = "N"
            _arquivo.reg1010.ind_aer = "N"

        End Sub

        Public Sub MontarReg1990()

            Dim qtd As Integer = 0

            _arquivo.reg1990 = New dReg1990()

            If _arquivo.reg1001 IsNot Nothing Then
                qtd = qtd + 1
            End If
            If _arquivo.reg1010 IsNot Nothing Then
                qtd = qtd + 1
            End If

            _arquivo.reg1990.reg = "1990"
            _arquivo.reg1990.qtd_lin_1 = qtd + 1

        End Sub

        Public Sub MontarReg9001()

            _arquivo.reg9001 = New dReg9001()

            _arquivo.reg9001.reg = "9001"
            _arquivo.reg9001.ind_mov = "0"

        End Sub

        Public Sub MontarReg9900()

            Dim _dReg9900 As dReg9900 = New dReg9900()
            _arquivo.col9900 = New Colecao9900()

            '-- Registro 0000 -- ABERTURA DO ARQUIVO DIGITAL E IDENTIFICAÇÃO DA ENTIDADE
            If _arquivo.reg0000 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("0000", 1))
            End If
            '-- Registro 0001 -- ABERTURA DO BLOCO 0
            If _arquivo.reg0001 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("0001", 1))
            End If
            '-- Registro 0005 -- DADOS COMPLEMENTARES DA ENTIDADE
            If _arquivo.reg0005 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("0005", 1))
            End If
            '-- Registro 0100 -- DADOS DO CONTABILISTA
            If _arquivo.reg0100 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("0100", 1))
            End If
            '-- Registro 0150 -- TABELA DE CADASTRO DO PARTICIPANTE
            If _arquivo.col0150 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("0150", _arquivo.col0150.Count))
            End If
            '-- Registro 0190 -- IDENTIFICAÇÃO DAS UNIDADES DE MEDIDA
            If _arquivo.col0190 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("0190", _arquivo.col0190.Count))
            End If
            '-- Registro 0200 -- TABELA DE IDENTIFICAÇÃO DO ITEM (PRODUTO E SERVIÇOS)
            If _arquivo.col0200 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("0200", _arquivo.col0200.Count))
            End If
            '-- Registro 0990 -- ENCERRAMENTO DO BLOCO 0
            If _arquivo.reg0990 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("0990", 1))
            End If
            '-- Registro C001 -- ABERTURA DO BLOCO C
            If _arquivo.regC001 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("C001", 1))
            End If
            '-- Registro C100 -- NOTA FISCAL (CÓDIGO 01), NOTA FISCAL AVULSA (CÓDIGO 1B), NOTA FISCAL DE PRODUTOR (CÓDIGO 04) E NF-e (CÓDIGO 55).
            If _arquivo.colC100 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("C100", _arquivo.colC100.Count))
            End If
            '-- Registro C170 -- ITENS DO DOCUMENTO (CÓDIGO 01, 1B, 04 e 55).
            If _arquivo.colC170 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("C170", _arquivo.colC170.Count))
            End If
            '-- Registro C190 -- REGISTRO ANALÍTICO DO DOCUMENTO (CÓDIGO 01, 1B, 04 E 55).
            If _arquivo.regC190 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("C190", 1))
            End If
            '-- Registro C990 -- ENCERRAMENTO DO BLOCO C
            If _arquivo.regC990 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("C990", 1))
            End If
            '-- REGISTRO D001: ABERTURA DO BLOCO D
            If _arquivo.regD001 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("D001", 1))
            End If
            '-- REGISTRO D990: ENCERRAMENTO DO BLOCO D.
            If _arquivo.regD990 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("D990", 1))
            End If
            '-- REGISTRO E001: ABERTURA DO BLOCO E
            If _arquivo.regE001 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("E001", 1))
            End If
            '-- REGISTRO E100: PERÍODO DA APURAÇÃO DO ICMS.
            If _arquivo.regE100 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("E100", 1))
            End If
            '-- REGISTRO E110: APURAÇÃO DO ICMS – OPERAÇÕES PRÓPRIAS.
            If _arquivo.regE110 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("E110", 1))
            End If
            '-- REGISTRO E990: ENCERRAMENTO DO BLOCO E
            If _arquivo.regE990 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("E990", 1))
            End If
            '-- REGISTRO G001: ABERTURA DO BLOCO G
            If _arquivo.regG001 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("G001", 1))
            End If
            '-- REGISTRO G990: ENCERRAMENTO DO BLOCO G
            If _arquivo.regG990 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("G990", 1))
            End If
            '-- REGISTRO H001: ABERTURA DO BLOCO H
            If _arquivo.regH001 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("H001", 1))
            End If
            '-- REGISTRO H005: TOTAIS DO INVENTÁRIO
            If _arquivo.regH005 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("H005", 1))
            End If
            '-- REGISTRO H010: INVENTÁRIO.
            If _arquivo.colH010 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("H010", _arquivo.colH010.Count))
            End If
            '-- REGISTRO H990: ENCERRAMENTO DO BLOCO H.
            If _arquivo.regH990 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("H990", 1))
            End If
            '-- REGISTRO 1001: ABERTURA DO BLOCO 1
            If _arquivo.reg1001 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("1001", 1))
            End If
            '-- REGISTRO 1010: OBRIGATORIEDADE DE REGISTROS DO BLOCO 1
            If _arquivo.reg1010 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("1010", 1))
            End If
            '-- REGISTRO 1990: ENCERRAMENTO DO BLOCO 1
            If _arquivo.reg1990 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("1990", 1))
            End If
            '-- REGISTRO 9001: ABERTURA DO BLOCO 9
            If _arquivo.reg9001 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("9001", 1))
            End If
            '-- REGISTRO 9900: REGISTROS DO ARQUIVO.
            If _arquivo.col9900 IsNot Nothing Then
                _arquivo.col9900.Add(_dReg9900.MontarReg9900("9900", _arquivo.col9900.Count + 3))
            End If
            '-- REGISTRO 9990: ENCERRAMENTO DO BLOCO 9
            'If _arquivo.reg9990 IsNot Nothing Then
            _arquivo.col9900.Add(_dReg9900.MontarReg9900("9990", 1))
            'End If
            '-- REGISTRO 9999: ENCERRAMENTO DO ARQUIVO DIGITAL.
            'If _arquivo.reg9999 IsNot Nothing Then
            _arquivo.col9900.Add(_dReg9900.MontarReg9900("9999", 1))
            'End If

        End Sub

        Public Sub MontarReg9990()

            Dim qtd As Integer = 0

            _arquivo.reg9990 = New dReg9990()

            If _arquivo.reg9001 IsNot Nothing Then
                qtd = qtd + 1
            End If
            If _arquivo.col9900 IsNot Nothing Then
                qtd = qtd + _arquivo.col9900.Count
            End If
            'reg9990
            qtd = qtd + 1
            'reg9999
            qtd = qtd + 1

            _arquivo.reg9990.reg = "9990"
            _arquivo.reg9990.qtd_lin_9 = qtd

        End Sub

        Public Sub MontarReg9999()

            Dim qtd As Integer = 0

            _arquivo.reg9999 = New dReg9999()

            If _arquivo.reg0990 IsNot Nothing Then
                If Not _arquivo.reg0990.qtd_lin_0.Equals(Nothing) Then
                    qtd = qtd + Convert.ToInt32(_arquivo.reg0990.qtd_lin_0)
                End If
            End If
            If _arquivo.regC990 IsNot Nothing Then
                If Not _arquivo.regC990.qtd_lin_c.Equals(Nothing) Then
                    qtd = qtd + Convert.ToInt32(_arquivo.regC990.qtd_lin_c)
                End If
            End If
            If _arquivo.regD990 IsNot Nothing Then
                If Not _arquivo.regD990.qtd_lin_d.Equals(Nothing) Then
                    qtd = qtd + Convert.ToInt32(_arquivo.regD990.qtd_lin_d)
                End If
            End If
            If _arquivo.regE990 IsNot Nothing Then
                If Not _arquivo.regE990.qtd_lin_e.Equals(Nothing) Then
                    qtd = qtd + Convert.ToInt32(_arquivo.regE990.qtd_lin_e)
                End If
            End If
            If _arquivo.regG990 IsNot Nothing Then
                If Not _arquivo.regG990.qtd_lin_g.Equals(Nothing) Then
                    qtd = qtd + Convert.ToInt32(_arquivo.regG990.qtd_lin_g)
                End If
            End If
            If _arquivo.regH990 IsNot Nothing Then
                If Not _arquivo.regH990.qtd_lin_h.Equals(Nothing) Then
                    qtd = qtd + Convert.ToInt32(_arquivo.regH990.qtd_lin_h)
                End If
            End If
            If _arquivo.reg1990 IsNot Nothing Then
                If Not _arquivo.reg1990.qtd_lin_1.Equals(Nothing) Then
                    qtd = qtd + Convert.ToInt32(_arquivo.reg1990.qtd_lin_1)
                End If
            End If
            If _arquivo.reg9990 IsNot Nothing Then
                If Not _arquivo.reg9990.qtd_lin_9.Equals(Nothing) Then
                    qtd = qtd + Convert.ToInt32(_arquivo.reg9990.qtd_lin_9)
                End If
            End If

            _arquivo.reg9999.reg = "9999"
            _arquivo.reg9999.qtd_lin = qtd

        End Sub

    End Class

End Namespace