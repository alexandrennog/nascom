Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsEstado
Imports ncRegras.nsEstado
Imports ncDados.nsRegraTributaria
Imports ncRegras.nsRegraTributaria
Imports ncDados.nsProdutoRegraTributaria
Imports ncRegras.nsProdutoRegraTributaria
Imports ncDados.nsImpostoIcms
Imports ncRegras.nsImpostoIcms
Imports ncDados.nsImpostoPis
Imports ncRegras.nsImpostoPis
Imports ncDados.nsImpostoCofins
Imports ncRegras.nsImpostoCofins
Imports ncDados.nsImpostoIpi
Imports ncRegras.nsImpostoIpi
Imports ncDados.nsImpostoIbsCbs
Imports ncRegras.nsImpostoIbsCbs
Imports ncDados.nsRegraCfop
Imports ncRegras.nsRegraCfop
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fImpostoForm

  Public produto_cid As Nullable(Of Integer)

  Private regraAtual As Nullable(Of Integer)

  Private Function Validar() As Boolean
    Try

      If String.IsNullOrEmpty(txtDescricao.Text.Trim()) Then
        MessageBox.Show("� necess�rio informar a Descri��o da regra!")
        Return False
      End If

      If Not cFuncoes.ValidarValor(cboCrt.SelectedValue) Then
        MessageBox.Show("� necess�rio informar o CRT!")
        Return False
      End If

      If Not cFuncoes.ValidarValor(cboTipoOperacao.SelectedValue) Then
        MessageBox.Show("� necess�rio informar o Tipo de Opera��o!")
        Return False
      End If

    Catch ex As Exception
      Return False
    End Try

    Return True
  End Function

  Private Sub Salvar()
    Dim dadosRegra As dRegraTributaria
    Dim regrasRegra As rRegraTributaria
    Dim vinculo As dProdutoRegraTributaria
    Dim regrasVinculo As rProdutoRegraTributaria
    Dim novoCid As Integer

    Try

      If Not Validar() Then
        Exit Sub
      End If

      If MessageBox.Show("Confirma grava��o das informa��es de Impostos?", "IMPOSTOS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

        dadosRegra = New dRegraTributaria
        regrasRegra = New rRegraTributaria

        dadosRegra.cid = regraAtual
        dadosRegra.descricao = cFuncoes.TratarTexto(txtDescricao.Text)
        dadosRegra.crt = CType(cFuncoes.TratarInteiro(cboCrt.SelectedValue), Nullable(Of Byte))
        dadosRegra.ufOrigem = cFuncoes.TratarTexto(cboUfOrigem.SelectedValue)
        dadosRegra.ufDestino = cFuncoes.TratarTexto(cboUfDestino.SelectedValue)
        dadosRegra.tipoOperacao = cFuncoes.TratarTexto(cboTipoOperacao.SelectedValue)
        dadosRegra.modeloDocumento = CType(cFuncoes.TratarInteiro(cboModeloDocumento.SelectedValue), Nullable(Of Byte))

        If dtInicioVigencia.Checked Then
          dadosRegra.inicioVigencia = dtInicioVigencia.Value
        Else
          dadosRegra.inicioVigencia = Nothing
        End If

        If dtFimVigencia.Checked Then
          dadosRegra.fimVigencia = dtFimVigencia.Value
        Else
          dadosRegra.fimVigencia = Nothing
        End If

        dadosRegra.ativo = chkAtivo.Checked

        If Not regraAtual.HasValue Then
          novoCid = regrasRegra.Incluir(dadosRegra)
          regraAtual = novoCid

          vinculo = New dProdutoRegraTributaria
          vinculo.produto_cid = Me.produto_cid
          vinculo.regra_cid = regraAtual

          regrasVinculo = New rProdutoRegraTributaria
          regrasVinculo.Incluir(vinculo)
        Else
          regrasRegra.Alterar(dadosRegra)
        End If

        SalvarIcms(regraAtual.Value)
        SalvarPis(regraAtual.Value)
        SalvarCofins(regraAtual.Value)
        SalvarIpi(regraAtual.Value)
        SalvarIbsCbs(regraAtual.Value)

        HabilitarAbaCfop(True)
        CarregarComboRegra()
        cboRegra.SelectedValue = regraAtual
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na grava��o dos dados de Impostos.")

    End Try
  End Sub

  Private Sub SalvarIcms(ByVal regra_cid As Integer)
    Dim dados As dImpostoIcms
    Dim regras As rImpostoIcms

    dados = New dImpostoIcms
    regras = New rImpostoIcms

    dados.regra_cid = regra_cid
    dados.origem = CType(cFuncoes.TratarInteiro(cboOrigemIcms.SelectedValue), Nullable(Of Byte))
    dados.cst = cFuncoes.TratarTexto(txtCstIcms.Text)
    dados.csosn = cFuncoes.TratarTexto(txtCsosn.Text)
    dados.aliquota = cFuncoes.TratarDecimal(txtAliquotaIcms.Text)
    dados.reducaoBase = cFuncoes.TratarDecimal(txtReducaoBase.Text)
    dados.modalidadeBc = CType(cFuncoes.TratarInteiro(txtModalidadeBc.Text), Nullable(Of Byte))
    dados.aliquotaSt = cFuncoes.TratarDecimal(txtAliquotaSt.Text)
    dados.margemValorAgregado = cFuncoes.TratarDecimal(txtMva.Text)

    If regras.Consultar(regra_cid) Is Nothing Then
      regras.Incluir(dados)
    Else
      regras.Alterar(dados)
    End If
  End Sub

  Private Sub SalvarPis(ByVal regra_cid As Integer)
    Dim dados As dImpostoPis
    Dim regras As rImpostoPis

    dados = New dImpostoPis
    regras = New rImpostoPis

    dados.regra_cid = regra_cid
    dados.cst = cFuncoes.TratarTexto(txtCstPis.Text)
    dados.aliquota = cFuncoes.TratarDecimal(txtAliquotaPis.Text)

    If regras.Consultar(regra_cid) Is Nothing Then
      regras.Incluir(dados)
    Else
      regras.Alterar(dados)
    End If
  End Sub

  Private Sub SalvarCofins(ByVal regra_cid As Integer)
    Dim dados As dImpostoCofins
    Dim regras As rImpostoCofins

    dados = New dImpostoCofins
    regras = New rImpostoCofins

    dados.regra_cid = regra_cid
    dados.cst = cFuncoes.TratarTexto(txtCstCofins.Text)
    dados.aliquota = cFuncoes.TratarDecimal(txtAliquotaCofins.Text)

    If regras.Consultar(regra_cid) Is Nothing Then
      regras.Incluir(dados)
    Else
      regras.Alterar(dados)
    End If
  End Sub

  Private Sub SalvarIpi(ByVal regra_cid As Integer)
    Dim dados As dImpostoIpi
    Dim regras As rImpostoIpi

    dados = New dImpostoIpi
    regras = New rImpostoIpi

    dados.regra_cid = regra_cid
    dados.cst = cFuncoes.TratarTexto(txtCstIpi.Text)
    dados.aliquota = cFuncoes.TratarDecimal(txtAliquotaIpi.Text)
    dados.codigoEnquadramento = cFuncoes.TratarTexto(txtCodigoEnquadramento.Text)

    If regras.Consultar(regra_cid) Is Nothing Then
      regras.Incluir(dados)
    Else
      regras.Alterar(dados)
    End If
  End Sub

  Private Sub SalvarIbsCbs(ByVal regra_cid As Integer)
    Dim dados As dImpostoIbsCbs
    Dim regras As rImpostoIbsCbs

    dados = New dImpostoIbsCbs
    regras = New rImpostoIbsCbs

    dados.regra_cid = regra_cid
    dados.cstIbsCbs = cFuncoes.TratarTexto(txtCstIbsCbs.Text)
    dados.cClassTrib = cFuncoes.TratarTexto(txtCClassTrib.Text)
    dados.aliquotaIbsUf = cFuncoes.TratarDecimal(txtAliquotaIbsUf.Text)
    dados.aliquotaIbsMunicipio = cFuncoes.TratarDecimal(txtAliquotaIbsMunicipio.Text)
    dados.aliquotaCbs = cFuncoes.TratarDecimal(txtAliquotaCbs.Text)

    If regras.Consultar(regra_cid) Is Nothing Then
      regras.Incluir(dados)
    Else
      regras.Alterar(dados)
    End If
  End Sub

  Private Sub Excluir()
    Dim filtro As dProdutoRegraTributaria
    Dim vinculos As ColecaoProdutoRegraTributaria
    Dim regras As rProdutoRegraTributaria

    Try

      If regraAtual.HasValue Then
        If MessageBox.Show("Confirma a REMO��O do v�nculo desta regra fiscal com o produto?", "REMOVER", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

          filtro = New dProdutoRegraTributaria
          filtro.produto_cid = Me.produto_cid
          filtro.regra_cid = regraAtual

          regras = New rProdutoRegraTributaria
          vinculos = regras.Consultar(filtro)

          If Not vinculos Is Nothing Then
            If vinculos.Count > 0 Then
              regras.Excluir(vinculos(0))
            End If
          End If

          regraAtual = Nothing
          LimparCampos()
          CarregarComboRegra()
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na remo��o do v�nculo de Impostos.")

    End Try
  End Sub

  Private Sub CarregarComboCrt()
    Dim regras As rCrt
    Dim colecao As ColecaoCrt

    Try

      cboCrt.DataSource = Nothing
      cboCrt.Items.Clear()

      regras = New rCrt()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then

        cboCrt.ValueMember = "codigo"
        cboCrt.DisplayMember = "descricao"
        cboCrt.DataSource = colecao
        cboCrt.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de CRT.")

    End Try
  End Sub

  Private Sub CarregarComboTipoOperacao()
    Dim regras As rTipoOperacaoFiscal
    Dim colecao As ColecaoTipoOperacaoFiscal

    Try

      cboTipoOperacao.DataSource = Nothing
      cboTipoOperacao.Items.Clear()

      regras = New rTipoOperacaoFiscal()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then

        cboTipoOperacao.ValueMember = "codigo"
        cboTipoOperacao.DisplayMember = "descricao"
        cboTipoOperacao.DataSource = colecao
        cboTipoOperacao.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Tipo de Opera��o.")

    End Try
  End Sub

  Private Sub CarregarComboModeloDocumento()
    Dim regras As rModeloDocumento
    Dim colecao As ColecaoModeloDocumento

    Try

      cboModeloDocumento.DataSource = Nothing
      cboModeloDocumento.Items.Clear()

      regras = New rModeloDocumento()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then

        cboModeloDocumento.ValueMember = "codigo"
        cboModeloDocumento.DisplayMember = "descricao"
        cboModeloDocumento.DataSource = colecao
        cboModeloDocumento.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Modelo de Documento.")

    End Try
  End Sub

  Private Sub CarregarComboOrigemIcms()
    Dim regras As rOrigemMercadoria
    Dim colecao As ColecaoOrigemMercadoria

    Try

      cboOrigemIcms.DataSource = Nothing
      cboOrigemIcms.Items.Clear()

      regras = New rOrigemMercadoria()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then

        cboOrigemIcms.ValueMember = "codigo"
        cboOrigemIcms.DisplayMember = "descricao"
        cboOrigemIcms.DataSource = colecao
        cboOrigemIcms.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Origem da Mercadoria.")

    End Try
  End Sub

  Private Sub CarregarComboUf()
    Dim regras As rEstado
    Dim colecao As ColecaoEstado

    Try

      cboUfOrigem.DataSource = Nothing
      cboUfOrigem.Items.Clear()
      cboUfDestino.DataSource = Nothing
      cboUfDestino.Items.Clear()

      regras = New rEstado()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then
        Dim colecaoOrigem As New ColecaoEstado
        Dim colecaoDestino As New ColecaoEstado

        colecaoOrigem.Add(New dEstado())
        colecaoOrigem.AddRange(colecao)

        colecaoDestino.Add(New dEstado())
        colecaoDestino.AddRange(colecao)

        cboUfOrigem.ValueMember = "sigla"
        cboUfOrigem.DisplayMember = "nome"
        cboUfOrigem.DataSource = colecaoOrigem
        cboUfOrigem.Refresh()

        cboUfDestino.ValueMember = "sigla"
        cboUfDestino.DisplayMember = "nome"
        cboUfDestino.DataSource = colecaoDestino
        cboUfDestino.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Estados.")

    End Try
  End Sub

  Private Sub CarregarComboRegra()
    Dim regrasVinculo As rProdutoRegraTributaria
    Dim regrasRegra As rRegraTributaria
    Dim vinculos As ColecaoProdutoRegraTributaria
    Dim colecao As ColecaoRegraTributaria
    Dim dadosRegra As dRegraTributaria

    Try

      cboRegra.DataSource = Nothing
      cboRegra.Items.Clear()

      colecao = New ColecaoRegraTributaria
      colecao.Add(New dRegraTributaria())

      If Me.produto_cid.HasValue Then
        regrasVinculo = New rProdutoRegraTributaria
        vinculos = regrasVinculo.ListarPorProduto(Me.produto_cid.Value)

        If Not vinculos Is Nothing Then
          regrasRegra = New rRegraTributaria

          For Each vinculo As dProdutoRegraTributaria In vinculos
            dadosRegra = regrasRegra.Consultar(vinculo.regra_cid.Value)

            If Not dadosRegra Is Nothing Then
              colecao.Add(dadosRegra)
            End If
          Next
        End If
      End If

      cboRegra.ValueMember = "cid"
      cboRegra.DisplayMember = "descricao"
      cboRegra.DataSource = colecao
      cboRegra.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta das Regras Tribut�rias do produto.")

    End Try
  End Sub

  Private Sub ExibirRegra(ByVal regra_cid As Nullable(Of Integer))
    Dim regrasRegra As rRegraTributaria
    Dim dadosRegra As dRegraTributaria
    Dim dadosIcms As dImpostoIcms
    Dim dadosPis As dImpostoPis
    Dim dadosCofins As dImpostoCofins
    Dim dadosIpi As dImpostoIpi
    Dim dadosIbsCbs As dImpostoIbsCbs

    Try

      LimparCamposDetalhe()

      If Not regra_cid.HasValue OrElse regra_cid.Value = 0 Then
        regraAtual = Nothing
        HabilitarAbaCfop(False)
        Exit Sub
      End If

      regraAtual = regra_cid

      regrasRegra = New rRegraTributaria
      dadosRegra = regrasRegra.Consultar(regra_cid.Value)

      If Not dadosRegra Is Nothing Then
        txtDescricao.Text = cFuncoes.RetornarTexto(dadosRegra.descricao)

        If cboCrt.Items.Count > 0 Then
          cboCrt.SelectedIndex = 0
        End If
        If cFuncoes.ValidarValor(dadosRegra.crt) Then
          cboCrt.SelectedValue = cFuncoes.RetornarInteiro(dadosRegra.crt)
        End If

        If cboUfOrigem.Items.Count > 0 Then
          cboUfOrigem.SelectedIndex = 0
        End If
        If cFuncoes.ValidarValor(dadosRegra.ufOrigem) Then
          cboUfOrigem.SelectedValue = cFuncoes.RetornarTexto(dadosRegra.ufOrigem)
        End If

        If cboUfDestino.Items.Count > 0 Then
          cboUfDestino.SelectedIndex = 0
        End If
        If cFuncoes.ValidarValor(dadosRegra.ufDestino) Then
          cboUfDestino.SelectedValue = cFuncoes.RetornarTexto(dadosRegra.ufDestino)
        End If

        If cFuncoes.ValidarValor(dadosRegra.tipoOperacao) Then
          cboTipoOperacao.SelectedValue = cFuncoes.RetornarTexto(dadosRegra.tipoOperacao)
        End If

        If cFuncoes.ValidarValor(dadosRegra.modeloDocumento) Then
          cboModeloDocumento.SelectedValue = cFuncoes.RetornarInteiro(dadosRegra.modeloDocumento)
        End If

        If dadosRegra.inicioVigencia.HasValue Then
          dtInicioVigencia.Checked = True
          dtInicioVigencia.Value = dadosRegra.inicioVigencia.Value
        End If

        If dadosRegra.fimVigencia.HasValue Then
          dtFimVigencia.Checked = True
          dtFimVigencia.Value = dadosRegra.fimVigencia.Value
        End If

        chkAtivo.Checked = cFuncoes.ValidarValor(dadosRegra.ativo) AndAlso dadosRegra.ativo.Value
      End If

      dadosIcms = New rImpostoIcms().Consultar(regra_cid.Value)
      If Not dadosIcms Is Nothing Then
        If cFuncoes.ValidarValor(dadosIcms.origem) Then
          cboOrigemIcms.SelectedValue = cFuncoes.RetornarInteiro(dadosIcms.origem)
        End If
        txtCstIcms.Text = cFuncoes.RetornarTexto(dadosIcms.cst)
        txtCsosn.Text = cFuncoes.RetornarTexto(dadosIcms.csosn)
        txtAliquotaIcms.Text = cFuncoes.RetornarTexto(dadosIcms.aliquota)
        txtReducaoBase.Text = cFuncoes.RetornarTexto(dadosIcms.reducaoBase)
        txtModalidadeBc.Text = cFuncoes.RetornarTexto(dadosIcms.modalidadeBc)
        txtAliquotaSt.Text = cFuncoes.RetornarTexto(dadosIcms.aliquotaSt)
        txtMva.Text = cFuncoes.RetornarTexto(dadosIcms.margemValorAgregado)
      End If

      dadosPis = New rImpostoPis().Consultar(regra_cid.Value)
      If Not dadosPis Is Nothing Then
        txtCstPis.Text = cFuncoes.RetornarTexto(dadosPis.cst)
        txtAliquotaPis.Text = cFuncoes.RetornarTexto(dadosPis.aliquota)
      End If

      dadosCofins = New rImpostoCofins().Consultar(regra_cid.Value)
      If Not dadosCofins Is Nothing Then
        txtCstCofins.Text = cFuncoes.RetornarTexto(dadosCofins.cst)
        txtAliquotaCofins.Text = cFuncoes.RetornarTexto(dadosCofins.aliquota)
      End If

      dadosIpi = New rImpostoIpi().Consultar(regra_cid.Value)
      If Not dadosIpi Is Nothing Then
        txtCstIpi.Text = cFuncoes.RetornarTexto(dadosIpi.cst)
        txtAliquotaIpi.Text = cFuncoes.RetornarTexto(dadosIpi.aliquota)
        txtCodigoEnquadramento.Text = cFuncoes.RetornarTexto(dadosIpi.codigoEnquadramento)
      End If

      dadosIbsCbs = New rImpostoIbsCbs().Consultar(regra_cid.Value)
      If Not dadosIbsCbs Is Nothing Then
        txtCstIbsCbs.Text = cFuncoes.RetornarTexto(dadosIbsCbs.cstIbsCbs)
        txtCClassTrib.Text = cFuncoes.RetornarTexto(dadosIbsCbs.cClassTrib)
        txtAliquotaIbsUf.Text = cFuncoes.RetornarTexto(dadosIbsCbs.aliquotaIbsUf)
        txtAliquotaIbsMunicipio.Text = cFuncoes.RetornarTexto(dadosIbsCbs.aliquotaIbsMunicipio)
        txtAliquotaCbs.Text = cFuncoes.RetornarTexto(dadosIbsCbs.aliquotaCbs)
      End If

      CarregarGridCfop(regra_cid.Value)
      HabilitarAbaCfop(True)

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Impostos.")

    End Try
  End Sub

  Private Sub CarregarGridCfop(ByVal regra_cid As Integer)
    Dim regras As rRegraCfop
    Dim colecao As ColecaoRegraCfop
    Dim linha As DataGridViewRow

    Try

      dgvCfop.Rows.Clear()

      regras = New rRegraCfop
      colecao = regras.ListarPorRegra(regra_cid)

      If Not colecao Is Nothing Then
        For Each item As dRegraCfop In colecao
          linha = dgvCfop.Rows(dgvCfop.Rows.Add())
          linha.Cells("colCfopCid").Value = item.cid
          linha.Cells("colCfop").Value = item.cfop
        Next
      End If

      dgvCfop.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos CFOPs da regra.")

    End Try
  End Sub

  Private Sub IncluirCfop()
    Dim dados As dRegraCfop
    Dim regras As rRegraCfop

    Try

      If Not regraAtual.HasValue Then
        MessageBox.Show("Salve a regra fiscal antes de incluir CFOPs.")
        Exit Sub
      End If

      If String.IsNullOrEmpty(txtCfop.Text.Trim()) Then
        Exit Sub
      End If

      dados = New dRegraCfop
      dados.regra_cid = regraAtual
      dados.cfop = cFuncoes.TratarTexto(txtCfop.Text)

      regras = New rRegraCfop
      regras.Incluir(dados)

      txtCfop.Text = String.Empty
      CarregarGridCfop(regraAtual.Value)

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na inclus�o do CFOP.")

    End Try
  End Sub

  Private Sub ExcluirCfop()
    Dim dados As dRegraCfop
    Dim cid As Nullable(Of Integer)
    Dim regras As rRegraCfop

    Try

      If dgvCfop.CurrentRow Is Nothing Then
        Exit Sub
      End If

      cid = cFuncoes.RetornarInteiro(dgvCfop.CurrentRow.Cells("colCfopCid").Value)

      If Not cid.HasValue Then
        Exit Sub
      End If

      dados = New dRegraCfop
      dados.cid = cid

      regras = New rRegraCfop
      regras.Excluir(dados)

      CarregarGridCfop(regraAtual.Value)

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na exclus�o do CFOP.")

    End Try
  End Sub

  Private Sub HabilitarAbaCfop(ByVal habilitar As Boolean)
    txtCfop.Enabled = habilitar
    btoIncluirCfop.Enabled = habilitar
    btoExcluirCfop.Enabled = habilitar
    dgvCfop.Enabled = habilitar
  End Sub

  Private Sub LimparCamposDetalhe()
    txtDescricao.Text = String.Empty
    If cboCrt.Items.Count > 0 Then
      cboCrt.SelectedIndex = 0
    End If
    If cboUfOrigem.Items.Count > 0 Then
      cboUfOrigem.SelectedIndex = 0
    End If
    If cboUfDestino.Items.Count > 0 Then
      cboUfDestino.SelectedIndex = 0
    End If
    If cboTipoOperacao.Items.Count > 0 Then
      cboTipoOperacao.SelectedIndex = 0
    End If
    If cboModeloDocumento.Items.Count > 0 Then
      cboModeloDocumento.SelectedIndex = 0
    End If
    dtInicioVigencia.Checked = False
    dtFimVigencia.Checked = False
    chkAtivo.Checked = True

    If cboOrigemIcms.Items.Count > 0 Then
      cboOrigemIcms.SelectedIndex = 0
    End If
    txtCstIcms.Text = String.Empty
    txtCsosn.Text = String.Empty
    txtAliquotaIcms.Text = String.Empty
    txtReducaoBase.Text = String.Empty
    txtModalidadeBc.Text = String.Empty
    txtAliquotaSt.Text = String.Empty
    txtMva.Text = String.Empty

    txtCstPis.Text = String.Empty
    txtAliquotaPis.Text = String.Empty
    txtCstCofins.Text = String.Empty
    txtAliquotaCofins.Text = String.Empty

    txtCstIpi.Text = String.Empty
    txtAliquotaIpi.Text = String.Empty
    txtCodigoEnquadramento.Text = String.Empty

    txtCstIbsCbs.Text = String.Empty
    txtCClassTrib.Text = String.Empty
    txtAliquotaIbsUf.Text = String.Empty
    txtAliquotaIbsMunicipio.Text = String.Empty
    txtAliquotaCbs.Text = String.Empty

    txtCfop.Text = String.Empty
    dgvCfop.Rows.Clear()
  End Sub

  Private Sub LimparCampos()
    LimparCamposDetalhe()
    HabilitarAbaCfop(False)
  End Sub

  Private Sub NovaRegra()
    regraAtual = Nothing
    LimparCampos()
    If cboRegra.Items.Count > 0 Then
      cboRegra.SelectedIndex = 0
    End If
    TabControl1.SelectedIndex = 0
    txtDescricao.Focus()
  End Sub

  Private Sub Sair()
    If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
      mdiPrincipal.FecharTela()
    End If
  End Sub

  Private Sub cboRegra_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRegra.SelectedIndexChanged
    ExibirRegra(cFuncoes.TratarInteiro(cboRegra.SelectedValue))
  End Sub

  Private Sub btoNovaRegra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoNovaRegra.Click
    NovaRegra()
  End Sub

  Private Sub btoIncluirCfop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoIncluirCfop.Click
    IncluirCfop()
  End Sub

  Private Sub btoExcluirCfop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluirCfop.Click
    ExcluirCfop()
  End Sub

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
    Salvar()
  End Sub

  Private Sub btoExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluir.Click
    Excluir()
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    Sair()
  End Sub

  Private Sub fImpostoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If Not Me.produto_cid.HasValue Then
      MessageBox.Show("Nenhum produto informado para a tela de Impostos.")
      mdiPrincipal.FecharTela()
      Exit Sub
    End If

    LimparCampos()
    CarregarComboCrt()
    CarregarComboUf()
    CarregarComboTipoOperacao()
    CarregarComboModeloDocumento()
    CarregarComboOrigemIcms()
    CarregarComboRegra()

    If cboRegra.Items.Count > 1 Then
      cboRegra.SelectedIndex = 1
    Else
      ExibirRegra(Nothing)
    End If

  End Sub

  Private Sub fImpostoForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        Sair()
    End Select
  End Sub

End Class
