<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPedidoCompraLista
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
        Dim DataGridViewCellStyleNumero As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyleValor As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblFabricante = New System.Windows.Forms.Label()
        Me.cboFabricante = New System.Windows.Forms.ComboBox()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.txtDataInicial = New System.Windows.Forms.MaskedTextBox()
        Me.lblAte = New System.Windows.Forms.Label()
        Me.txtDataFinal = New System.Windows.Forms.MaskedTextBox()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.cboSituacao = New System.Windows.Forms.ComboBox()
        Me.btoFiltro = New System.Windows.Forms.Button()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.dgvPedido = New System.Windows.Forms.DataGridView()
        Me.cid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fabricante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pares = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Entregues = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Faltam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorLiquido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Situacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btoCadastro = New System.Windows.Forms.Button()
        Me.btoAbrir = New System.Windows.Forms.Button()
        Me.btoRelatorio = New System.Windows.Forms.Button()
        Me.lblResumo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPedido, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblSubTitulo.Size = New System.Drawing.Size(39, 14)
        Me.lblSubTitulo.TabIndex = 0
        Me.lblSubTitulo.Text = "LISTA"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(64, 10)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(196, 24)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Pedidos de Compra"
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.fornecedores
        Me.imgLogo.Location = New System.Drawing.Point(8, 10)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 2
        Me.imgLogo.TabStop = False
        '
        'lblFabricante
        '
        Me.lblFabricante.AutoSize = True
        Me.lblFabricante.BackColor = System.Drawing.Color.Transparent
        Me.lblFabricante.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblFabricante.Location = New System.Drawing.Point(8, 80)
        Me.lblFabricante.Name = "lblFabricante"
        Me.lblFabricante.Size = New System.Drawing.Size(86, 18)
        Me.lblFabricante.TabIndex = 3
        Me.lblFabricante.Text = "Fabricante"
        '
        'cboFabricante
        '
        Me.cboFabricante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFabricante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFabricante.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboFabricante.FormattingEnabled = True
        Me.cboFabricante.Location = New System.Drawing.Point(98, 76)
        Me.cboFabricante.Name = "cboFabricante"
        Me.cboFabricante.Size = New System.Drawing.Size(220, 26)
        Me.cboFabricante.TabIndex = 4
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.BackColor = System.Drawing.Color.Transparent
        Me.lblPeriodo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblPeriodo.Location = New System.Drawing.Point(330, 80)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(90, 18)
        Me.lblPeriodo.TabIndex = 5
        Me.lblPeriodo.Text = "Período: de"
        '
        'txtDataInicial
        '
        Me.txtDataInicial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataInicial.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataInicial.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataInicial.Location = New System.Drawing.Point(424, 80)
        Me.txtDataInicial.Mask = "00/00/0000"
        Me.txtDataInicial.Name = "txtDataInicial"
        Me.txtDataInicial.Size = New System.Drawing.Size(85, 18)
        Me.txtDataInicial.TabIndex = 6
        Me.txtDataInicial.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        '
        'lblAte
        '
        Me.lblAte.AutoSize = True
        Me.lblAte.BackColor = System.Drawing.Color.Transparent
        Me.lblAte.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblAte.Location = New System.Drawing.Point(514, 80)
        Me.lblAte.Name = "lblAte"
        Me.lblAte.Size = New System.Drawing.Size(30, 18)
        Me.lblAte.TabIndex = 7
        Me.lblAte.Text = "até"
        '
        'txtDataFinal
        '
        Me.txtDataFinal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataFinal.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataFinal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataFinal.Location = New System.Drawing.Point(548, 80)
        Me.txtDataFinal.Mask = "00/00/0000"
        Me.txtDataFinal.Name = "txtDataFinal"
        Me.txtDataFinal.Size = New System.Drawing.Size(85, 18)
        Me.txtDataFinal.TabIndex = 8
        Me.txtDataFinal.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        '
        'lblSituacao
        '
        Me.lblSituacao.AutoSize = True
        Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
        Me.lblSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblSituacao.Location = New System.Drawing.Point(644, 80)
        Me.lblSituacao.Name = "lblSituacao"
        Me.lblSituacao.Size = New System.Drawing.Size(73, 18)
        Me.lblSituacao.TabIndex = 9
        Me.lblSituacao.Text = "Situação"
        '
        'cboSituacao
        '
        Me.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboSituacao.FormattingEnabled = True
        Me.cboSituacao.Location = New System.Drawing.Point(720, 76)
        Me.cboSituacao.Name = "cboSituacao"
        Me.cboSituacao.Size = New System.Drawing.Size(124, 26)
        Me.cboSituacao.TabIndex = 10
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
        Me.btoFiltro.Location = New System.Drawing.Point(852, 6)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(74, 84)
        Me.btoFiltro.TabIndex = 11
        Me.btoFiltro.Text = "Pesquisar [F6]"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
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
        Me.btoSair.Location = New System.Drawing.Point(930, 6)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(62, 84)
        Me.btoSair.TabIndex = 12
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'dgvPedido
        '
        Me.dgvPedido.AllowUserToAddRows = False
        Me.dgvPedido.AllowUserToDeleteRows = False
        Me.dgvPedido.AllowUserToResizeRows = False
        Me.dgvPedido.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvPedido.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPedido.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPedido.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPedido.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cid, Me.Numero, Me.Data, Me.Fabricante, Me.Pares, Me.Entregues, Me.Faltam, Me.ValorLiquido, Me.Situacao})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPedido.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPedido.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvPedido.Location = New System.Drawing.Point(8, 112)
        Me.dgvPedido.MultiSelect = False
        Me.dgvPedido.Name = "dgvPedido"
        Me.dgvPedido.ReadOnly = True
        Me.dgvPedido.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvPedido.RowHeadersVisible = False
        Me.dgvPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPedido.Size = New System.Drawing.Size(984, 410)
        Me.dgvPedido.TabIndex = 13
        '
        DataGridViewCellStyleNumero.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyleNumero.Format = "N0"
        DataGridViewCellStyleValor.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyleValor.Format = "N2"
        '
        'cid
        '
        Me.cid.HeaderText = "CID"
        Me.cid.Name = "cid"
        Me.cid.ReadOnly = True
        Me.cid.Visible = False
        '
        'Numero
        '
        Me.Numero.HeaderText = "Nº Pedido"
        Me.Numero.Name = "Numero"
        Me.Numero.ReadOnly = True
        Me.Numero.Width = 100
        '
        'Data
        '
        Me.Data.HeaderText = "Data"
        Me.Data.Name = "Data"
        Me.Data.ReadOnly = True
        Me.Data.Width = 95
        '
        'Fabricante
        '
        Me.Fabricante.HeaderText = "Fabricante"
        Me.Fabricante.Name = "Fabricante"
        Me.Fabricante.ReadOnly = True
        Me.Fabricante.Width = 230
        '
        'Pares
        '
        Me.Pares.DefaultCellStyle = DataGridViewCellStyleNumero
        Me.Pares.HeaderText = "Pares"
        Me.Pares.Name = "Pares"
        Me.Pares.ReadOnly = True
        Me.Pares.Width = 80
        '
        'Entregues
        '
        Me.Entregues.DefaultCellStyle = DataGridViewCellStyleNumero
        Me.Entregues.HeaderText = "Entregues"
        Me.Entregues.Name = "Entregues"
        Me.Entregues.ReadOnly = True
        Me.Entregues.Width = 90
        '
        'Faltam
        '
        Me.Faltam.DefaultCellStyle = DataGridViewCellStyleNumero
        Me.Faltam.HeaderText = "Faltam"
        Me.Faltam.Name = "Faltam"
        Me.Faltam.ReadOnly = True
        Me.Faltam.Width = 80
        '
        'ValorLiquido
        '
        Me.ValorLiquido.DefaultCellStyle = DataGridViewCellStyleValor
        Me.ValorLiquido.HeaderText = "Vl. Líquido"
        Me.ValorLiquido.Name = "ValorLiquido"
        Me.ValorLiquido.ReadOnly = True
        Me.ValorLiquido.Width = 130
        '
        'Situacao
        '
        Me.Situacao.HeaderText = "Situação"
        Me.Situacao.Name = "Situacao"
        Me.Situacao.ReadOnly = True
        Me.Situacao.Width = 110
        '
        'btoCadastro
        '
        Me.btoCadastro.BackColor = System.Drawing.Color.Transparent
        Me.btoCadastro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoCadastro.FlatAppearance.BorderSize = 0
        Me.btoCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoCadastro.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoCadastro.ForeColor = System.Drawing.Color.Black
        Me.btoCadastro.Image = Global.nascomercio.My.Resources.Resources.incluir
        Me.btoCadastro.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoCadastro.Location = New System.Drawing.Point(8, 526)
        Me.btoCadastro.Name = "btoCadastro"
        Me.btoCadastro.Size = New System.Drawing.Size(110, 70)
        Me.btoCadastro.TabIndex = 14
        Me.btoCadastro.Text = "Novo Pedido <F5>"
        Me.btoCadastro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoCadastro.UseVisualStyleBackColor = False
        '
        'btoAbrir
        '
        Me.btoAbrir.BackColor = System.Drawing.Color.Transparent
        Me.btoAbrir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoAbrir.FlatAppearance.BorderSize = 0
        Me.btoAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoAbrir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoAbrir.ForeColor = System.Drawing.Color.Black
        Me.btoAbrir.Image = Global.nascomercio.My.Resources.Resources.selecionar
        Me.btoAbrir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoAbrir.Location = New System.Drawing.Point(124, 526)
        Me.btoAbrir.Name = "btoAbrir"
        Me.btoAbrir.Size = New System.Drawing.Size(110, 70)
        Me.btoAbrir.TabIndex = 15
        Me.btoAbrir.Text = "Abrir <Enter>"
        Me.btoAbrir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoAbrir.UseVisualStyleBackColor = False
        '
        'btoRelatorio
        '
        Me.btoRelatorio.BackColor = System.Drawing.Color.Transparent
        Me.btoRelatorio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoRelatorio.FlatAppearance.BorderSize = 0
        Me.btoRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoRelatorio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoRelatorio.ForeColor = System.Drawing.Color.Black
        Me.btoRelatorio.Image = Global.nascomercio.My.Resources.Resources.relatorio
        Me.btoRelatorio.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoRelatorio.Location = New System.Drawing.Point(240, 526)
        Me.btoRelatorio.Name = "btoRelatorio"
        Me.btoRelatorio.Size = New System.Drawing.Size(110, 70)
        Me.btoRelatorio.TabIndex = 16
        Me.btoRelatorio.Text = "Relatório <F8>"
        Me.btoRelatorio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoRelatorio.UseVisualStyleBackColor = False
        '
        'lblResumo
        '
        Me.lblResumo.BackColor = System.Drawing.Color.Transparent
        Me.lblResumo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblResumo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblResumo.Location = New System.Drawing.Point(366, 540)
        Me.lblResumo.Name = "lblResumo"
        Me.lblResumo.Size = New System.Drawing.Size(626, 44)
        Me.lblResumo.TabIndex = 17
        Me.lblResumo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 600)
        Me.Panel1.TabIndex = 18
        '
        'fPedidoCompraLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1000, 600)
        Me.Controls.Add(Me.lblResumo)
        Me.Controls.Add(Me.btoRelatorio)
        Me.Controls.Add(Me.btoAbrir)
        Me.Controls.Add(Me.btoCadastro)
        Me.Controls.Add(Me.dgvPedido)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.btoFiltro)
        Me.Controls.Add(Me.cboSituacao)
        Me.Controls.Add(Me.lblSituacao)
        Me.Controls.Add(Me.txtDataFinal)
        Me.Controls.Add(Me.lblAte)
        Me.Controls.Add(Me.txtDataInicial)
        Me.Controls.Add(Me.lblPeriodo)
        Me.Controls.Add(Me.cboFabricante)
        Me.Controls.Add(Me.lblFabricante)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fPedidoCompraLista"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fPedidoCompraLista"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblFabricante As System.Windows.Forms.Label
    Friend WithEvents cboFabricante As System.Windows.Forms.ComboBox
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents txtDataInicial As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblAte As System.Windows.Forms.Label
    Friend WithEvents txtDataFinal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblSituacao As System.Windows.Forms.Label
    Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
    Friend WithEvents btoFiltro As System.Windows.Forms.Button
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents dgvPedido As System.Windows.Forms.DataGridView
    Friend WithEvents cid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fabricante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pares As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Entregues As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Faltam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorLiquido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Situacao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btoCadastro As System.Windows.Forms.Button
    Friend WithEvents btoAbrir As System.Windows.Forms.Button
    Friend WithEvents btoRelatorio As System.Windows.Forms.Button
    Friend WithEvents lblResumo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
