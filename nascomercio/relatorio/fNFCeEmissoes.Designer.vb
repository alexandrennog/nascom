<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fNFCeEmissoes
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyleValor As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyleCentro As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyleChave As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.components = New System.ComponentModel.Container()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btoFiltro = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.cboSituacao = New System.Windows.Forms.ComboBox()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.txtDataFinal = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDataInicial = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblKpiTotal = New System.Windows.Forms.Label()
        Me.lblKpiAutorizadas = New System.Windows.Forms.Label()
        Me.lblKpiRejeitadas = New System.Windows.Forms.Label()
        Me.lblKpiFalhas = New System.Windows.Forms.Label()
        Me.lblKpiValor = New System.Windows.Forms.Label()
        Me.tabPrincipal = New System.Windows.Forms.TabControl()
        Me.tabNotas = New System.Windows.Forms.TabPage()
        Me.dgvNotas = New System.Windows.Forms.DataGridView()
        Me.colDataHora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSituacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRetorno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTerminal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colXml = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colChave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTentativas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDetalhe = New System.Windows.Forms.TextBox()
        Me.btoReemitir = New System.Windows.Forms.Button()
        Me.btoConsultar = New System.Windows.Forms.Button()
        Me.btoMostrarXml = New System.Windows.Forms.Button()
        Me.btoReimprimir = New System.Windows.Forms.Button()
        Me.chkImprimir = New System.Windows.Forms.CheckBox()
        Me.lblDica = New System.Windows.Forms.Label()
        Me.tabImpressao = New System.Windows.Forms.TabPage()
        Me.rptRelatorio = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPrincipal.SuspendLayout()
        Me.tabNotas.SuspendLayout()
        CType(Me.dgvNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabImpressao.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSubTitulo.Location = New System.Drawing.Point(64, 34)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(75, 14)
        Me.lblSubTitulo.TabIndex = 138
        Me.lblSubTitulo.Text = "RELATÓRIO"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(64, 10)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(160, 24)
        Me.lblTitulo.TabIndex = 136
        Me.lblTitulo.Text = "NFC-e Emitidas"
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
        Me.btoFiltro.Location = New System.Drawing.Point(847, 12)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(71, 84)
        Me.btoFiltro.TabIndex = 139
        Me.btoFiltro.Text = "Pesquisar [F5]"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.relatorio
        Me.imgLogo.Location = New System.Drawing.Point(8, 10)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 137
        Me.imgLogo.TabStop = False
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
        Me.btoSair.Location = New System.Drawing.Point(945, 12)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(54, 84)
        Me.btoSair.TabIndex = 134
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'cboSituacao
        '
        Me.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboSituacao.FormattingEnabled = True
        Me.cboSituacao.Location = New System.Drawing.Point(412, 75)
        Me.cboSituacao.Name = "cboSituacao"
        Me.cboSituacao.Size = New System.Drawing.Size(260, 26)
        Me.cboSituacao.TabIndex = 141
        '
        'lblSituacao
        '
        Me.lblSituacao.AutoSize = True
        Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
        Me.lblSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblSituacao.Location = New System.Drawing.Point(336, 78)
        Me.lblSituacao.Name = "lblSituacao"
        Me.lblSituacao.Size = New System.Drawing.Size(72, 18)
        Me.lblSituacao.TabIndex = 142
        Me.lblSituacao.Text = "Situação"
        '
        'txtDataFinal
        '
        Me.txtDataFinal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataFinal.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataFinal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataFinal.Location = New System.Drawing.Point(235, 78)
        Me.txtDataFinal.Mask = "00/00/0000"
        Me.txtDataFinal.Name = "txtDataFinal"
        Me.txtDataFinal.Size = New System.Drawing.Size(85, 18)
        Me.txtDataFinal.TabIndex = 211
        Me.txtDataFinal.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(199, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 18)
        Me.Label1.TabIndex = 210
        Me.Label1.Text = "até"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDataInicial
        '
        Me.txtDataInicial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataInicial.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataInicial.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataInicial.Location = New System.Drawing.Point(108, 78)
        Me.txtDataInicial.Mask = "00/00/0000"
        Me.txtDataInicial.Name = "txtDataInicial"
        Me.txtDataInicial.Size = New System.Drawing.Size(85, 18)
        Me.txtDataInicial.TabIndex = 209
        Me.txtDataInicial.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(12, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 18)
        Me.Label4.TabIndex = 208
        Me.Label4.Text = "Período de"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKpiTotal
        '
        Me.lblKpiTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblKpiTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKpiTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblKpiTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblKpiTotal.Location = New System.Drawing.Point(12, 106)
        Me.lblKpiTotal.Name = "lblKpiTotal"
        Me.lblKpiTotal.Size = New System.Drawing.Size(190, 40)
        Me.lblKpiTotal.TabIndex = 220
        Me.lblKpiTotal.Text = "NFC-e no período" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-"
        Me.lblKpiTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKpiAutorizadas
        '
        Me.lblKpiAutorizadas.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.lblKpiAutorizadas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKpiAutorizadas.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblKpiAutorizadas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.lblKpiAutorizadas.Location = New System.Drawing.Point(211, 106)
        Me.lblKpiAutorizadas.Name = "lblKpiAutorizadas"
        Me.lblKpiAutorizadas.Size = New System.Drawing.Size(190, 40)
        Me.lblKpiAutorizadas.TabIndex = 221
        Me.lblKpiAutorizadas.Text = "Autorizadas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-"
        Me.lblKpiAutorizadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKpiRejeitadas
        '
        Me.lblKpiRejeitadas.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lblKpiRejeitadas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKpiRejeitadas.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblKpiRejeitadas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblKpiRejeitadas.Location = New System.Drawing.Point(410, 106)
        Me.lblKpiRejeitadas.Name = "lblKpiRejeitadas"
        Me.lblKpiRejeitadas.Size = New System.Drawing.Size(190, 40)
        Me.lblKpiRejeitadas.TabIndex = 222
        Me.lblKpiRejeitadas.Text = "Rejeitadas pela SEFAZ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-"
        Me.lblKpiRejeitadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKpiFalhas
        '
        Me.lblKpiFalhas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblKpiFalhas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKpiFalhas.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblKpiFalhas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblKpiFalhas.Location = New System.Drawing.Point(609, 106)
        Me.lblKpiFalhas.Name = "lblKpiFalhas"
        Me.lblKpiFalhas.Size = New System.Drawing.Size(190, 40)
        Me.lblKpiFalhas.TabIndex = 223
        Me.lblKpiFalhas.Text = "Falhas / sem nota" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-"
        Me.lblKpiFalhas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKpiValor
        '
        Me.lblKpiValor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblKpiValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKpiValor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblKpiValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblKpiValor.Location = New System.Drawing.Point(808, 106)
        Me.lblKpiValor.Name = "lblKpiValor"
        Me.lblKpiValor.Size = New System.Drawing.Size(191, 40)
        Me.lblKpiValor.TabIndex = 224
        Me.lblKpiValor.Text = "Valor autorizado" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-"
        Me.lblKpiValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabPrincipal
        '
        Me.tabPrincipal.Controls.Add(Me.tabNotas)
        Me.tabPrincipal.Controls.Add(Me.tabImpressao)
        Me.tabPrincipal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tabPrincipal.Location = New System.Drawing.Point(12, 152)
        Me.tabPrincipal.Name = "tabPrincipal"
        Me.tabPrincipal.SelectedIndex = 0
        Me.tabPrincipal.Size = New System.Drawing.Size(987, 438)
        Me.tabPrincipal.TabIndex = 230
        '
        'tabNotas
        '
        Me.tabNotas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.tabNotas.Controls.Add(Me.dgvNotas)
        Me.tabNotas.Controls.Add(Me.txtDetalhe)
        Me.tabNotas.Controls.Add(Me.btoReemitir)
        Me.tabNotas.Controls.Add(Me.btoConsultar)
        Me.tabNotas.Controls.Add(Me.btoMostrarXml)
        Me.tabNotas.Controls.Add(Me.btoReimprimir)
        Me.tabNotas.Controls.Add(Me.chkImprimir)
        Me.tabNotas.Controls.Add(Me.lblDica)
        Me.tabNotas.Location = New System.Drawing.Point(4, 24)
        Me.tabNotas.Name = "tabNotas"
        Me.tabNotas.Padding = New System.Windows.Forms.Padding(3)
        Me.tabNotas.Size = New System.Drawing.Size(979, 410)
        Me.tabNotas.TabIndex = 0
        Me.tabNotas.Text = "Notas (reemitir / consultar)"
        '
        'dgvNotas
        '
        Me.dgvNotas.AllowUserToAddRows = False
        Me.dgvNotas.AllowUserToDeleteRows = False
        Me.dgvNotas.AllowUserToResizeRows = False
        Me.dgvNotas.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvNotas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvNotas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNotas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDataHora, Me.colNumero, Me.colVenda, Me.colValor, Me.colSituacao, Me.colRetorno, Me.colTerminal, Me.colUsuario, Me.colXml, Me.colChave, Me.colTentativas})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvNotas.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvNotas.Location = New System.Drawing.Point(3, 3)
        Me.dgvNotas.MultiSelect = False
        Me.dgvNotas.Name = "dgvNotas"
        Me.dgvNotas.ReadOnly = True
        Me.dgvNotas.RowHeadersVisible = False
        Me.dgvNotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvNotas.Size = New System.Drawing.Size(830, 300)
        Me.dgvNotas.TabIndex = 0
        DataGridViewCellStyleValor.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyleValor.Format = "N2"
        DataGridViewCellStyleCentro.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyleChave.Font = New System.Drawing.Font("Consolas", 8.25!)
        '
        'colDataHora
        '
        Me.colDataHora.HeaderText = "Data / hora"
        Me.colDataHora.Name = "colDataHora"
        Me.colDataHora.ReadOnly = True
        Me.colDataHora.Width = 112
        '
        'colNumero
        '
        Me.colNumero.DefaultCellStyle = DataGridViewCellStyleCentro
        Me.colNumero.HeaderText = "Nº NFC-e"
        Me.colNumero.Name = "colNumero"
        Me.colNumero.ReadOnly = True
        Me.colNumero.Width = 62
        '
        'colVenda
        '
        Me.colVenda.DefaultCellStyle = DataGridViewCellStyleCentro
        Me.colVenda.HeaderText = "Venda"
        Me.colVenda.Name = "colVenda"
        Me.colVenda.ReadOnly = True
        Me.colVenda.Width = 62
        '
        'colValor
        '
        Me.colValor.DefaultCellStyle = DataGridViewCellStyleValor
        Me.colValor.HeaderText = "Valor"
        Me.colValor.Name = "colValor"
        Me.colValor.ReadOnly = True
        Me.colValor.Width = 75
        '
        'colSituacao
        '
        Me.colSituacao.DefaultCellStyle = DataGridViewCellStyleCentro
        Me.colSituacao.HeaderText = "Situação"
        Me.colSituacao.Name = "colSituacao"
        Me.colSituacao.ReadOnly = True
        Me.colSituacao.Width = 110
        '
        'colRetorno
        '
        Me.colRetorno.HeaderText = "Retorno da SEFAZ / motivo"
        Me.colRetorno.Name = "colRetorno"
        Me.colRetorno.ReadOnly = True
        Me.colRetorno.Width = 300
        '
        'colTerminal
        '
        Me.colTerminal.HeaderText = "Terminal"
        Me.colTerminal.Name = "colTerminal"
        Me.colTerminal.ReadOnly = True
        Me.colTerminal.Width = 85
        '
        'colUsuario
        '
        Me.colUsuario.HeaderText = "Usuário"
        Me.colUsuario.Name = "colUsuario"
        Me.colUsuario.ReadOnly = True
        Me.colUsuario.Width = 110
        '
        'colXml
        '
        Me.colXml.DefaultCellStyle = DataGridViewCellStyleCentro
        Me.colXml.HeaderText = "XML aqui"
        Me.colXml.Name = "colXml"
        Me.colXml.ReadOnly = True
        Me.colXml.Width = 70
        '
        'colChave
        '
        Me.colChave.DefaultCellStyle = DataGridViewCellStyleChave
        Me.colChave.HeaderText = "Chave de acesso"
        Me.colChave.Name = "colChave"
        Me.colChave.ReadOnly = True
        Me.colChave.Width = 330
        '
        'colTentativas
        '
        Me.colTentativas.DefaultCellStyle = DataGridViewCellStyleCentro
        Me.colTentativas.HeaderText = "Tentativas"
        Me.colTentativas.Name = "colTentativas"
        Me.colTentativas.ReadOnly = True
        Me.colTentativas.Width = 75
        '
        'txtDetalhe
        '
        Me.txtDetalhe.BackColor = System.Drawing.Color.White
        Me.txtDetalhe.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtDetalhe.Location = New System.Drawing.Point(3, 308)
        Me.txtDetalhe.Multiline = True
        Me.txtDetalhe.Name = "txtDetalhe"
        Me.txtDetalhe.ReadOnly = True
        Me.txtDetalhe.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDetalhe.Size = New System.Drawing.Size(830, 98)
        Me.txtDetalhe.TabIndex = 1
        Me.txtDetalhe.TabStop = False
        '
        'btoReemitir
        '
        Me.btoReemitir.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.btoReemitir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoReemitir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoReemitir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btoReemitir.Location = New System.Drawing.Point(839, 3)
        Me.btoReemitir.Name = "btoReemitir"
        Me.btoReemitir.Size = New System.Drawing.Size(136, 48)
        Me.btoReemitir.TabIndex = 2
        Me.btoReemitir.Text = "Reemitir NFC-e [F6]"
        Me.btoReemitir.UseVisualStyleBackColor = False
        '
        'btoConsultar
        '
        Me.btoConsultar.BackColor = System.Drawing.Color.White
        Me.btoConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoConsultar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoConsultar.Location = New System.Drawing.Point(839, 57)
        Me.btoConsultar.Name = "btoConsultar"
        Me.btoConsultar.Size = New System.Drawing.Size(136, 40)
        Me.btoConsultar.TabIndex = 3
        Me.btoConsultar.Text = "Consultar na SEFAZ [F7]"
        Me.btoConsultar.UseVisualStyleBackColor = False
        '
        'btoMostrarXml
        '
        Me.btoMostrarXml.BackColor = System.Drawing.Color.White
        Me.btoMostrarXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoMostrarXml.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoMostrarXml.Location = New System.Drawing.Point(839, 103)
        Me.btoMostrarXml.Name = "btoMostrarXml"
        Me.btoMostrarXml.Size = New System.Drawing.Size(136, 40)
        Me.btoMostrarXml.TabIndex = 4
        Me.btoMostrarXml.Text = "Mostrar o XML [F8]"
        Me.btoMostrarXml.UseVisualStyleBackColor = False
        '
        'btoReimprimir
        '
        Me.btoReimprimir.BackColor = System.Drawing.Color.White
        Me.btoReimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoReimprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoReimprimir.Location = New System.Drawing.Point(839, 149)
        Me.btoReimprimir.Name = "btoReimprimir"
        Me.btoReimprimir.Size = New System.Drawing.Size(136, 40)
        Me.btoReimprimir.TabIndex = 5
        Me.btoReimprimir.Text = "Reimprimir cupom [F9]"
        Me.btoReimprimir.UseVisualStyleBackColor = False
        '
        'chkImprimir
        '
        Me.chkImprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.chkImprimir.Location = New System.Drawing.Point(841, 195)
        Me.chkImprimir.Name = "chkImprimir"
        Me.chkImprimir.Size = New System.Drawing.Size(134, 36)
        Me.chkImprimir.TabIndex = 6
        Me.chkImprimir.Text = "Imprimir o cupom ao reemitir"
        Me.chkImprimir.UseVisualStyleBackColor = True
        '
        'lblDica
        '
        Me.lblDica.Font = New System.Drawing.Font("Arial", 7.5!)
        Me.lblDica.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.lblDica.Location = New System.Drawing.Point(839, 236)
        Me.lblDica.Name = "lblDica"
        Me.lblDica.Size = New System.Drawing.Size(136, 170)
        Me.lblDica.TabIndex = 7
        Me.lblDica.Text = "Reemitir: só para falha, rejeitada, interrompida ou venda sem nota. Antes de emitir de novo o sistema confere na SEFAZ se a nota já não foi autorizada." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "O XML fica na pasta NFs do computador que emitiu."
        '
        'tabImpressao
        '
        Me.tabImpressao.Controls.Add(Me.rptRelatorio)
        Me.tabImpressao.Location = New System.Drawing.Point(4, 24)
        Me.tabImpressao.Name = "tabImpressao"
        Me.tabImpressao.Padding = New System.Windows.Forms.Padding(3)
        Me.tabImpressao.Size = New System.Drawing.Size(979, 410)
        Me.tabImpressao.TabIndex = 1
        Me.tabImpressao.Text = "Relatório para imprimir"
        Me.tabImpressao.UseVisualStyleBackColor = True
        '
        'rptRelatorio
        '
        Me.rptRelatorio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptRelatorio.LocalReport.ReportEmbeddedResource = "nascomercio.NFCeEmissoes.rdlc"
        Me.rptRelatorio.Location = New System.Drawing.Point(3, 3)
        Me.rptRelatorio.Name = "rptRelatorio"
        Me.rptRelatorio.Size = New System.Drawing.Size(973, 404)
        Me.rptRelatorio.TabIndex = 0
        '
        'fNFCeEmissoes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1011, 596)
        Me.Controls.Add(Me.tabPrincipal)
        Me.Controls.Add(Me.lblKpiValor)
        Me.Controls.Add(Me.lblKpiFalhas)
        Me.Controls.Add(Me.lblKpiRejeitadas)
        Me.Controls.Add(Me.lblKpiAutorizadas)
        Me.Controls.Add(Me.lblKpiTotal)
        Me.Controls.Add(Me.txtDataFinal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDataInicial)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboSituacao)
        Me.Controls.Add(Me.lblSituacao)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.btoFiltro)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.btoSair)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fNFCeEmissoes"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fNFCeEmissoes"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPrincipal.ResumeLayout(False)
        Me.tabNotas.ResumeLayout(False)
        Me.tabNotas.PerformLayout()
        CType(Me.dgvNotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabImpressao.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents btoFiltro As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
    Friend WithEvents lblSituacao As System.Windows.Forms.Label
    Friend WithEvents txtDataFinal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDataInicial As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblKpiTotal As System.Windows.Forms.Label
    Friend WithEvents lblKpiAutorizadas As System.Windows.Forms.Label
    Friend WithEvents lblKpiRejeitadas As System.Windows.Forms.Label
    Friend WithEvents lblKpiFalhas As System.Windows.Forms.Label
    Friend WithEvents lblKpiValor As System.Windows.Forms.Label
    Friend WithEvents tabPrincipal As System.Windows.Forms.TabControl
    Friend WithEvents tabNotas As System.Windows.Forms.TabPage
    Friend WithEvents tabImpressao As System.Windows.Forms.TabPage
    Friend WithEvents dgvNotas As System.Windows.Forms.DataGridView
    Friend WithEvents colDataHora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVenda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colValor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSituacao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRetorno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTerminal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colXml As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colChave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTentativas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtDetalhe As System.Windows.Forms.TextBox
    Friend WithEvents btoReemitir As System.Windows.Forms.Button
    Friend WithEvents btoConsultar As System.Windows.Forms.Button
    Friend WithEvents btoMostrarXml As System.Windows.Forms.Button
    Friend WithEvents btoReimprimir As System.Windows.Forms.Button
    Friend WithEvents chkImprimir As System.Windows.Forms.CheckBox
    Friend WithEvents lblDica As System.Windows.Forms.Label
    Friend WithEvents rptRelatorio As Microsoft.Reporting.WinForms.ReportViewer
End Class
