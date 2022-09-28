<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fNotaFiscalFornecedorForm
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblSubTitulo = New System.Windows.Forms.Label
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.txtNumero = New System.Windows.Forms.TextBox
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.txtSerie = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtValorIcmsSubstituicao = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtValorBaseIcmsSubstituicao = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtValorIcms = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtValorBaseIcms = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtValorTotalProdutos = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtValorTotalIpi = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtValorTotalNota = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtDataEmissao = New System.Windows.Forms.MaskedTextBox
        Me.cboFornecedor = New System.Windows.Forms.ComboBox
        Me.btoSair = New System.Windows.Forms.Button
        Me.btoFiltro = New System.Windows.Forms.Button
        Me.imgLogo = New System.Windows.Forms.PictureBox
        Me.btoSalvar = New System.Windows.Forms.Button
        Me.btoExcluir = New System.Windows.Forms.Button
        Me.btoNovo = New System.Windows.Forms.Button
        Me.btoSelecionar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dgvProdutoItem = New System.Windows.Forms.DataGridView
        Me.produtos_cid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descricao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Referencia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.estoque = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valorCompra = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtValorFrete = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtValorSeguro = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtValorDesconto = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtValorOutrasDespesas = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtDataEntrada = New System.Windows.Forms.MaskedTextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtValorCofinsRetidoSubstituicao = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtValorTotalCofins = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtValorPisRetidoSubstituicao = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtValorTotalPis = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtValorAbatimento = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.cboTipoFluxo = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.cboTipo = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.cboTipoEmissao = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtChaveEletronica = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.cboSituacao = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.cboTipoFrete = New System.Windows.Forms.ComboBox
        Me.cboTipoPagamento = New System.Windows.Forms.ComboBox
        Me.Label29 = New System.Windows.Forms.Label
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvProdutoItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSubTitulo.Location = New System.Drawing.Point(64, 32)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(67, 14)
        Me.lblSubTitulo.TabIndex = 125
        Me.lblSubTitulo.Text = "CADASTRO"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(64, 8)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(121, 24)
        Me.lblTitulo.TabIndex = 123
        Me.lblTitulo.Text = "Nota Fiscal"
        '
        'txtNumero
        '
        Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNumero.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.Location = New System.Drawing.Point(108, 127)
        Me.txtNumero.MaxLength = 20
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(145, 18)
        Me.txtNumero.TabIndex = 1
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblCodigo.Location = New System.Drawing.Point(38, 127)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(64, 18)
        Me.lblCodigo.TabIndex = 129
        Me.lblCodigo.Text = "Número"
        '
        'txtSerie
        '
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSerie.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.Location = New System.Drawing.Point(343, 127)
        Me.txtSerie.MaxLength = 3
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(70, 18)
        Me.txtSerie.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(291, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 18)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "Série"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(12, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 18)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "Fornecedor"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(435, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 18)
        Me.Label3.TabIndex = 135
        Me.Label3.Text = "Data Emissão"
        '
        'txtValorIcmsSubstituicao
        '
        Me.txtValorIcmsSubstituicao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorIcmsSubstituicao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorIcmsSubstituicao.Location = New System.Drawing.Point(148, 303)
        Me.txtValorIcmsSubstituicao.MaxLength = 10
        Me.txtValorIcmsSubstituicao.Name = "txtValorIcmsSubstituicao"
        Me.txtValorIcmsSubstituicao.Size = New System.Drawing.Size(105, 18)
        Me.txtValorIcmsSubstituicao.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(9, 303)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 18)
        Me.Label4.TabIndex = 143
        Me.Label4.Text = "Valor ICMS Subst."
        '
        'txtValorBaseIcmsSubstituicao
        '
        Me.txtValorBaseIcmsSubstituicao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorBaseIcmsSubstituicao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorBaseIcmsSubstituicao.Location = New System.Drawing.Point(148, 279)
        Me.txtValorBaseIcmsSubstituicao.MaxLength = 10
        Me.txtValorBaseIcmsSubstituicao.Name = "txtValorBaseIcmsSubstituicao"
        Me.txtValorBaseIcmsSubstituicao.Size = New System.Drawing.Size(105, 18)
        Me.txtValorBaseIcmsSubstituicao.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(8, 279)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 18)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "Base ICMS Subst."
        '
        'txtValorIcms
        '
        Me.txtValorIcms.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorIcms.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorIcms.Location = New System.Drawing.Point(148, 255)
        Me.txtValorIcms.MaxLength = 10
        Me.txtValorIcms.Name = "txtValorIcms"
        Me.txtValorIcms.Size = New System.Drawing.Size(105, 18)
        Me.txtValorIcms.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(58, 255)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 18)
        Me.Label6.TabIndex = 139
        Me.Label6.Text = "Valor ICMS"
        '
        'txtValorBaseIcms
        '
        Me.txtValorBaseIcms.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorBaseIcms.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorBaseIcms.Location = New System.Drawing.Point(148, 231)
        Me.txtValorBaseIcms.MaxLength = 10
        Me.txtValorBaseIcms.Name = "txtValorBaseIcms"
        Me.txtValorBaseIcms.Size = New System.Drawing.Size(105, 18)
        Me.txtValorBaseIcms.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(57, 231)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 18)
        Me.Label7.TabIndex = 137
        Me.Label7.Text = "Base ICMS"
        '
        'txtValorTotalProdutos
        '
        Me.txtValorTotalProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorTotalProdutos.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorTotalProdutos.Location = New System.Drawing.Point(148, 327)
        Me.txtValorTotalProdutos.MaxLength = 10
        Me.txtValorTotalProdutos.Name = "txtValorTotalProdutos"
        Me.txtValorTotalProdutos.Size = New System.Drawing.Size(105, 18)
        Me.txtValorTotalProdutos.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(31, 327)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 18)
        Me.Label8.TabIndex = 147
        Me.Label8.Text = "Total Produtos"
        '
        'txtValorTotalIpi
        '
        Me.txtValorTotalIpi.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorTotalIpi.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorTotalIpi.Location = New System.Drawing.Point(391, 303)
        Me.txtValorTotalIpi.MaxLength = 10
        Me.txtValorTotalIpi.Name = "txtValorTotalIpi"
        Me.txtValorTotalIpi.Size = New System.Drawing.Size(105, 18)
        Me.txtValorTotalIpi.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(320, 303)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 18)
        Me.Label9.TabIndex = 145
        Me.Label9.Text = "Total IPI"
        '
        'txtValorTotalNota
        '
        Me.txtValorTotalNota.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorTotalNota.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorTotalNota.Location = New System.Drawing.Point(391, 327)
        Me.txtValorTotalNota.MaxLength = 10
        Me.txtValorTotalNota.Name = "txtValorTotalNota"
        Me.txtValorTotalNota.Size = New System.Drawing.Size(105, 18)
        Me.txtValorTotalNota.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(305, 327)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 18)
        Me.Label10.TabIndex = 149
        Me.Label10.Text = "Total Nota"
        '
        'txtDataEmissao
        '
        Me.txtDataEmissao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataEmissao.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataEmissao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataEmissao.Location = New System.Drawing.Point(544, 127)
        Me.txtDataEmissao.Mask = "00/00/0000"
        Me.txtDataEmissao.Name = "txtDataEmissao"
        Me.txtDataEmissao.Size = New System.Drawing.Size(93, 18)
        Me.txtDataEmissao.TabIndex = 4
        Me.txtDataEmissao.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'cboFornecedor
        '
        Me.cboFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFornecedor.FormattingEnabled = True
        Me.cboFornecedor.Location = New System.Drawing.Point(108, 175)
        Me.cboFornecedor.Name = "cboFornecedor"
        Me.cboFornecedor.Size = New System.Drawing.Size(245, 21)
        Me.cboFornecedor.TabIndex = 3
        '
        'btoSair
        '
        Me.btoSair.BackColor = System.Drawing.Color.Transparent
        Me.btoSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoSair.FlatAppearance.BorderSize = 0
        Me.btoSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoSair.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoSair.ForeColor = System.Drawing.Color.Black
        Me.btoSair.Image = Global.nascomercio.My.Resources.Resources.fechar
        Me.btoSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoSair.Location = New System.Drawing.Point(650, 9)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(100, 72)
        Me.btoSair.TabIndex = 12
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'btoFiltro
        '
        Me.btoFiltro.BackColor = System.Drawing.Color.Transparent
        Me.btoFiltro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoFiltro.FlatAppearance.BorderSize = 0
        Me.btoFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoFiltro.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoFiltro.ForeColor = System.Drawing.Color.Black
        Me.btoFiltro.Image = Global.nascomercio.My.Resources.Resources.pesquisar
        Me.btoFiltro.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoFiltro.Location = New System.Drawing.Point(650, 85)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(100, 72)
        Me.btoFiltro.TabIndex = 13
        Me.btoFiltro.TabStop = False
        Me.btoFiltro.Text = "Pesquisa <F5>"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.caixa
        Me.imgLogo.Location = New System.Drawing.Point(8, 8)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 124
        Me.imgLogo.TabStop = False
        '
        'btoSalvar
        '
        Me.btoSalvar.BackColor = System.Drawing.Color.Transparent
        Me.btoSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoSalvar.FlatAppearance.BorderSize = 0
        Me.btoSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoSalvar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoSalvar.ForeColor = System.Drawing.Color.Black
        Me.btoSalvar.Image = Global.nascomercio.My.Resources.Resources.confirmar
        Me.btoSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoSalvar.Location = New System.Drawing.Point(187, 459)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(92, 72)
        Me.btoSalvar.TabIndex = 14
        Me.btoSalvar.TabStop = False
        Me.btoSalvar.Text = "Salvar <Enter>"
        Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSalvar.UseVisualStyleBackColor = False
        '
        'btoExcluir
        '
        Me.btoExcluir.BackColor = System.Drawing.Color.Transparent
        Me.btoExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoExcluir.FlatAppearance.BorderSize = 0
        Me.btoExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoExcluir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoExcluir.ForeColor = System.Drawing.Color.Black
        Me.btoExcluir.Image = Global.nascomercio.My.Resources.Resources.excluir
        Me.btoExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoExcluir.Location = New System.Drawing.Point(488, 459)
        Me.btoExcluir.Name = "btoExcluir"
        Me.btoExcluir.Size = New System.Drawing.Size(84, 72)
        Me.btoExcluir.TabIndex = 17
        Me.btoExcluir.TabStop = False
        Me.btoExcluir.Text = "Excluir <F12>"
        Me.btoExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoExcluir.UseVisualStyleBackColor = False
        '
        'btoNovo
        '
        Me.btoNovo.BackColor = System.Drawing.Color.Transparent
        Me.btoNovo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoNovo.FlatAppearance.BorderSize = 0
        Me.btoNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoNovo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoNovo.ForeColor = System.Drawing.Color.Black
        Me.btoNovo.Image = Global.nascomercio.My.Resources.Resources.incluir
        Me.btoNovo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoNovo.Location = New System.Drawing.Point(285, 459)
        Me.btoNovo.Name = "btoNovo"
        Me.btoNovo.Size = New System.Drawing.Size(84, 72)
        Me.btoNovo.TabIndex = 15
        Me.btoNovo.TabStop = False
        Me.btoNovo.Text = "Novo <F1>"
        Me.btoNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoNovo.UseVisualStyleBackColor = False
        '
        'btoSelecionar
        '
        Me.btoSelecionar.BackColor = System.Drawing.Color.Transparent
        Me.btoSelecionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoSelecionar.FlatAppearance.BorderSize = 0
        Me.btoSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoSelecionar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoSelecionar.ForeColor = System.Drawing.Color.Black
        Me.btoSelecionar.Image = Global.nascomercio.My.Resources.Resources.selecionar
        Me.btoSelecionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoSelecionar.Location = New System.Drawing.Point(375, 459)
        Me.btoSelecionar.Name = "btoSelecionar"
        Me.btoSelecionar.Size = New System.Drawing.Size(107, 72)
        Me.btoSelecionar.TabIndex = 16
        Me.btoSelecionar.TabStop = False
        Me.btoSelecionar.Text = "Selecionar <F4>"
        Me.btoSelecionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSelecionar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dgvProdutoItem)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.btoSalvar)
        Me.Panel1.Controls.Add(Me.btoNovo)
        Me.Panel1.Controls.Add(Me.btoSelecionar)
        Me.Panel1.Controls.Add(Me.btoExcluir)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(759, 536)
        Me.Panel1.TabIndex = 150
        '
        'dgvProdutoItem
        '
        Me.dgvProdutoItem.AllowUserToAddRows = False
        Me.dgvProdutoItem.AllowUserToDeleteRows = False
        Me.dgvProdutoItem.AllowUserToOrderColumns = True
        Me.dgvProdutoItem.AllowUserToResizeColumns = False
        Me.dgvProdutoItem.AllowUserToResizeRows = False
        Me.dgvProdutoItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProdutoItem.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvProdutoItem.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvProdutoItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProdutoItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProdutoItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProdutoItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.produtos_cid, Me.Valor, Me.Descricao, Me.Referencia, Me.estoque, Me.valorCompra})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProdutoItem.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProdutoItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvProdutoItem.Location = New System.Drawing.Point(22, 350)
        Me.dgvProdutoItem.Name = "dgvProdutoItem"
        Me.dgvProdutoItem.ReadOnly = True
        Me.dgvProdutoItem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProdutoItem.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProdutoItem.RowHeadersVisible = False
        Me.dgvProdutoItem.Size = New System.Drawing.Size(724, 103)
        Me.dgvProdutoItem.TabIndex = 187
        '
        'produtos_cid
        '
        Me.produtos_cid.FillWeight = 50.0!
        Me.produtos_cid.HeaderText = "CID"
        Me.produtos_cid.MinimumWidth = 50
        Me.produtos_cid.Name = "produtos_cid"
        Me.produtos_cid.ReadOnly = True
        Me.produtos_cid.Visible = False
        '
        'Valor
        '
        Me.Valor.FillWeight = 25.0!
        Me.Valor.HeaderText = "Código Barra"
        Me.Valor.MinimumWidth = 25
        Me.Valor.Name = "Valor"
        Me.Valor.ReadOnly = True
        '
        'Descricao
        '
        Me.Descricao.FillWeight = 35.0!
        Me.Descricao.HeaderText = "Descrição"
        Me.Descricao.MinimumWidth = 35
        Me.Descricao.Name = "Descricao"
        Me.Descricao.ReadOnly = True
        '
        'Referencia
        '
        Me.Referencia.FillWeight = 20.0!
        Me.Referencia.HeaderText = "Referência"
        Me.Referencia.MinimumWidth = 20
        Me.Referencia.Name = "Referencia"
        Me.Referencia.ReadOnly = True
        '
        'estoque
        '
        Me.estoque.FillWeight = 15.0!
        Me.estoque.HeaderText = "Estoque"
        Me.estoque.MinimumWidth = 15
        Me.estoque.Name = "estoque"
        Me.estoque.ReadOnly = True
        '
        'valorCompra
        '
        Me.valorCompra.FillWeight = 15.0!
        Me.valorCompra.HeaderText = "Valor"
        Me.valorCompra.MinimumWidth = 15
        Me.valorCompra.Name = "valorCompra"
        Me.valorCompra.ReadOnly = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label28.Location = New System.Drawing.Point(19, 203)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(82, 18)
        Me.Label28.TabIndex = 186
        Me.Label28.Text = "Tipo Frete"
        '
        'txtValorFrete
        '
        Me.txtValorFrete.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorFrete.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorFrete.Location = New System.Drawing.Point(391, 204)
        Me.txtValorFrete.MaxLength = 10
        Me.txtValorFrete.Name = "txtValorFrete"
        Me.txtValorFrete.Size = New System.Drawing.Size(105, 18)
        Me.txtValorFrete.TabIndex = 151
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(339, 204)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 18)
        Me.Label11.TabIndex = 152
        Me.Label11.Text = "Frete"
        '
        'txtValorSeguro
        '
        Me.txtValorSeguro.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorSeguro.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorSeguro.Location = New System.Drawing.Point(391, 231)
        Me.txtValorSeguro.MaxLength = 10
        Me.txtValorSeguro.Name = "txtValorSeguro"
        Me.txtValorSeguro.Size = New System.Drawing.Size(105, 18)
        Me.txtValorSeguro.TabIndex = 153
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(325, 231)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 18)
        Me.Label12.TabIndex = 154
        Me.Label12.Text = "Seguro"
        '
        'txtValorDesconto
        '
        Me.txtValorDesconto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorDesconto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorDesconto.Location = New System.Drawing.Point(391, 255)
        Me.txtValorDesconto.MaxLength = 10
        Me.txtValorDesconto.Name = "txtValorDesconto"
        Me.txtValorDesconto.Size = New System.Drawing.Size(105, 18)
        Me.txtValorDesconto.TabIndex = 155
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(309, 255)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 18)
        Me.Label13.TabIndex = 156
        Me.Label13.Text = "Desconto"
        '
        'txtValorOutrasDespesas
        '
        Me.txtValorOutrasDespesas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorOutrasDespesas.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorOutrasDespesas.Location = New System.Drawing.Point(391, 279)
        Me.txtValorOutrasDespesas.MaxLength = 10
        Me.txtValorOutrasDespesas.Name = "txtValorOutrasDespesas"
        Me.txtValorOutrasDespesas.Size = New System.Drawing.Size(105, 18)
        Me.txtValorOutrasDespesas.TabIndex = 157
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(261, 279)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(125, 18)
        Me.Label14.TabIndex = 158
        Me.Label14.Text = "Out. Desp. Aces."
        '
        'txtDataEntrada
        '
        Me.txtDataEntrada.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataEntrada.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataEntrada.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataEntrada.Location = New System.Drawing.Point(544, 151)
        Me.txtDataEntrada.Mask = "00/00/0000"
        Me.txtDataEntrada.Name = "txtDataEntrada"
        Me.txtDataEntrada.Size = New System.Drawing.Size(93, 18)
        Me.txtDataEntrada.TabIndex = 163
        Me.txtDataEntrada.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(439, 151)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(99, 18)
        Me.Label17.TabIndex = 164
        Me.Label17.Text = "Data Entrada"
        '
        'txtValorCofinsRetidoSubstituicao
        '
        Me.txtValorCofinsRetidoSubstituicao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorCofinsRetidoSubstituicao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorCofinsRetidoSubstituicao.Location = New System.Drawing.Point(642, 327)
        Me.txtValorCofinsRetidoSubstituicao.MaxLength = 10
        Me.txtValorCofinsRetidoSubstituicao.Name = "txtValorCofinsRetidoSubstituicao"
        Me.txtValorCofinsRetidoSubstituicao.Size = New System.Drawing.Size(105, 18)
        Me.txtValorCofinsRetidoSubstituicao.TabIndex = 169
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(502, 327)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(134, 18)
        Me.Label18.TabIndex = 174
        Me.Label18.Text = "COFINS Ret. Sub."
        '
        'txtValorTotalCofins
        '
        Me.txtValorTotalCofins.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorTotalCofins.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorTotalCofins.Location = New System.Drawing.Point(642, 303)
        Me.txtValorTotalCofins.MaxLength = 10
        Me.txtValorTotalCofins.Name = "txtValorTotalCofins"
        Me.txtValorTotalCofins.Size = New System.Drawing.Size(105, 18)
        Me.txtValorTotalCofins.TabIndex = 168
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(532, 303)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(105, 18)
        Me.Label19.TabIndex = 173
        Me.Label19.Text = "Total COFINS"
        '
        'txtValorPisRetidoSubstituicao
        '
        Me.txtValorPisRetidoSubstituicao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorPisRetidoSubstituicao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorPisRetidoSubstituicao.Location = New System.Drawing.Point(642, 279)
        Me.txtValorPisRetidoSubstituicao.MaxLength = 10
        Me.txtValorPisRetidoSubstituicao.Name = "txtValorPisRetidoSubstituicao"
        Me.txtValorPisRetidoSubstituicao.Size = New System.Drawing.Size(105, 18)
        Me.txtValorPisRetidoSubstituicao.TabIndex = 167
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(505, 279)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(132, 18)
        Me.Label20.TabIndex = 172
        Me.Label20.Text = "PIS Retido Subst."
        '
        'txtValorTotalPis
        '
        Me.txtValorTotalPis.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorTotalPis.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorTotalPis.Location = New System.Drawing.Point(642, 255)
        Me.txtValorTotalPis.MaxLength = 10
        Me.txtValorTotalPis.Name = "txtValorTotalPis"
        Me.txtValorTotalPis.Size = New System.Drawing.Size(105, 18)
        Me.txtValorTotalPis.TabIndex = 166
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label21.Location = New System.Drawing.Point(565, 255)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(72, 18)
        Me.Label21.TabIndex = 171
        Me.Label21.Text = "Total PIS"
        '
        'txtValorAbatimento
        '
        Me.txtValorAbatimento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorAbatimento.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorAbatimento.Location = New System.Drawing.Point(642, 231)
        Me.txtValorAbatimento.MaxLength = 10
        Me.txtValorAbatimento.Name = "txtValorAbatimento"
        Me.txtValorAbatimento.Size = New System.Drawing.Size(105, 18)
        Me.txtValorAbatimento.TabIndex = 165
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(549, 231)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 18)
        Me.Label22.TabIndex = 170
        Me.Label22.Text = "Abatimento"
        '
        'cboTipoFluxo
        '
        Me.cboTipoFluxo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoFluxo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTipoFluxo.FormattingEnabled = True
        Me.cboTipoFluxo.Location = New System.Drawing.Point(108, 73)
        Me.cboTipoFluxo.Name = "cboTipoFluxo"
        Me.cboTipoFluxo.Size = New System.Drawing.Size(120, 21)
        Me.cboTipoFluxo.TabIndex = 175
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label23.Location = New System.Drawing.Point(55, 73)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(47, 18)
        Me.Label23.TabIndex = 176
        Me.Label23.Text = "Fluxo"
        '
        'cboTipo
        '
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(108, 100)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(145, 21)
        Me.cboTipo.TabIndex = 177
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label24.Location = New System.Drawing.Point(38, 100)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(64, 18)
        Me.Label24.TabIndex = 178
        Me.Label24.Text = "Tipo NF"
        '
        'cboTipoEmissao
        '
        Me.cboTipoEmissao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoEmissao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTipoEmissao.FormattingEnabled = True
        Me.cboTipoEmissao.Location = New System.Drawing.Point(544, 73)
        Me.cboTipoEmissao.Name = "cboTipoEmissao"
        Me.cboTipoEmissao.Size = New System.Drawing.Size(93, 21)
        Me.cboTipoEmissao.TabIndex = 179
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label25.Location = New System.Drawing.Point(435, 73)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(103, 18)
        Me.Label25.TabIndex = 180
        Me.Label25.Text = "Tipo Emissão"
        '
        'txtChaveEletronica
        '
        Me.txtChaveEletronica.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtChaveEletronica.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChaveEletronica.Location = New System.Drawing.Point(108, 151)
        Me.txtChaveEletronica.MaxLength = 50
        Me.txtChaveEletronica.Name = "txtChaveEletronica"
        Me.txtChaveEletronica.Size = New System.Drawing.Size(305, 18)
        Me.txtChaveEletronica.TabIndex = 181
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label26.Location = New System.Drawing.Point(15, 151)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(87, 18)
        Me.Label26.TabIndex = 182
        Me.Label26.Text = "Chave NFe"
        '
        'cboSituacao
        '
        Me.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSituacao.FormattingEnabled = True
        Me.cboSituacao.Location = New System.Drawing.Point(343, 100)
        Me.cboSituacao.Name = "cboSituacao"
        Me.cboSituacao.Size = New System.Drawing.Size(294, 21)
        Me.cboSituacao.TabIndex = 183
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label27.Location = New System.Drawing.Point(268, 100)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(69, 18)
        Me.Label27.TabIndex = 184
        Me.Label27.Text = "Situação"
        '
        'cboTipoFrete
        '
        Me.cboTipoFrete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoFrete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTipoFrete.FormattingEnabled = True
        Me.cboTipoFrete.Location = New System.Drawing.Point(108, 204)
        Me.cboTipoFrete.Name = "cboTipoFrete"
        Me.cboTipoFrete.Size = New System.Drawing.Size(145, 21)
        Me.cboTipoFrete.TabIndex = 185
        '
        'cboTipoPagamento
        '
        Me.cboTipoPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTipoPagamento.FormattingEnabled = True
        Me.cboTipoPagamento.Location = New System.Drawing.Point(505, 175)
        Me.cboTipoPagamento.Name = "cboTipoPagamento"
        Me.cboTipoPagamento.Size = New System.Drawing.Size(132, 21)
        Me.cboTipoPagamento.TabIndex = 187
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label29.Location = New System.Drawing.Point(413, 175)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(89, 18)
        Me.Label29.TabIndex = 188
        Me.Label29.Text = "Tipo Pagto."
        '
        'fNotaFiscalFornecedorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(759, 537)
        Me.Controls.Add(Me.cboTipoPagamento)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.cboTipoFrete)
        Me.Controls.Add(Me.cboSituacao)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.txtChaveEletronica)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.cboTipoEmissao)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.cboTipoFluxo)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtValorCofinsRetidoSubstituicao)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtValorTotalCofins)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtValorPisRetidoSubstituicao)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtValorTotalPis)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtValorAbatimento)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtDataEntrada)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtValorOutrasDespesas)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtValorDesconto)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtValorSeguro)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtValorFrete)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cboFornecedor)
        Me.Controls.Add(Me.txtDataEmissao)
        Me.Controls.Add(Me.txtValorTotalNota)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtValorTotalProdutos)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtValorTotalIpi)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtValorIcmsSubstituicao)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtValorBaseIcmsSubstituicao)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtValorIcms)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtValorBaseIcms)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.btoFiltro)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fNotaFiscalFornecedorForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fNotaFiscalFornecedor"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvProdutoItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents btoFiltro As System.Windows.Forms.Button
  Friend WithEvents txtNumero As System.Windows.Forms.TextBox
  Friend WithEvents lblCodigo As System.Windows.Forms.Label
  Friend WithEvents txtSerie As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtValorIcmsSubstituicao As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtValorBaseIcmsSubstituicao As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents txtValorIcms As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents txtValorBaseIcms As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents txtValorTotalProdutos As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents txtValorTotalIpi As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents txtValorTotalNota As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents txtDataEmissao As System.Windows.Forms.MaskedTextBox
  Friend WithEvents cboFornecedor As System.Windows.Forms.ComboBox
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents btoExcluir As System.Windows.Forms.Button
  Friend WithEvents btoNovo As System.Windows.Forms.Button
  Friend WithEvents btoSelecionar As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents txtValorFrete As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents txtValorSeguro As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents txtValorDesconto As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents txtValorOutrasDespesas As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents txtDataEntrada As System.Windows.Forms.MaskedTextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents txtValorCofinsRetidoSubstituicao As System.Windows.Forms.TextBox
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents txtValorTotalCofins As System.Windows.Forms.TextBox
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents txtValorPisRetidoSubstituicao As System.Windows.Forms.TextBox
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents txtValorTotalPis As System.Windows.Forms.TextBox
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents txtValorAbatimento As System.Windows.Forms.TextBox
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents cboTipoFluxo As System.Windows.Forms.ComboBox
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents cboTipoEmissao As System.Windows.Forms.ComboBox
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents txtChaveEletronica As System.Windows.Forms.TextBox
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents cboTipoFrete As System.Windows.Forms.ComboBox
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents cboTipoPagamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents dgvProdutoItem As System.Windows.Forms.DataGridView
    Friend WithEvents produtos_cid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Referencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents estoque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valorCompra As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
