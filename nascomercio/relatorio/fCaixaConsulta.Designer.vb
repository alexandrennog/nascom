<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fCaixaConsulta
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.dtgProdutos = New System.Windows.Forms.DataGridView()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReferencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValorUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValorTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblEmissao = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblLoja = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblVendas = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.lblVendedor = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtDesconto = New System.Windows.Forms.TextBox()
        Me.cboCondicao = New System.Windows.Forms.ComboBox()
        Me.txtParcelas = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblDefeitos = New System.Windows.Forms.Label()
        Me.lblTroca = New System.Windows.Forms.Label()
        Me.lblVale = New System.Windows.Forms.Label()
        Me.txtControle = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnExcluirUltima = New System.Windows.Forms.Button()
        Me.lblOS1 = New System.Windows.Forms.Label()
        Me.lblOS = New System.Windows.Forms.Label()
        Me.btoSalvar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        CType(Me.dtgProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(91, 15)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(136, 40)
        Me.lblTitulo.TabIndex = 20
        Me.lblTitulo.Text = "VENDA"
        '
        'dtgProdutos
        '
        Me.dtgProdutos.AllowUserToAddRows = False
        Me.dtgProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgProdutos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgProdutos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgProdutos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colDescricao, Me.colReferencia, Me.colValorUnitario, Me.colQuantidade, Me.colValorTotal})
        Me.dtgProdutos.Location = New System.Drawing.Point(20, 162)
        Me.dtgProdutos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtgProdutos.Name = "dtgProdutos"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgProdutos.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgProdutos.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dtgProdutos.Size = New System.Drawing.Size(1163, 348)
        Me.dtgProdutos.TabIndex = 8
        '
        'colCodigo
        '
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        '
        'colDescricao
        '
        Me.colDescricao.FillWeight = 140.0!
        Me.colDescricao.HeaderText = "Descrição"
        Me.colDescricao.Name = "colDescricao"
        Me.colDescricao.ReadOnly = True
        '
        'colReferencia
        '
        Me.colReferencia.FillWeight = 110.0!
        Me.colReferencia.HeaderText = "Referência"
        Me.colReferencia.Name = "colReferencia"
        Me.colReferencia.ReadOnly = True
        '
        'colValorUnitario
        '
        Me.colValorUnitario.FillWeight = 90.0!
        Me.colValorUnitario.HeaderText = "Valor Unitário"
        Me.colValorUnitario.Name = "colValorUnitario"
        Me.colValorUnitario.ReadOnly = True
        '
        'colQuantidade
        '
        Me.colQuantidade.FillWeight = 80.0!
        Me.colQuantidade.HeaderText = "Quantidade"
        Me.colQuantidade.Name = "colQuantidade"
        Me.colQuantidade.ReadOnly = True
        '
        'colValorTotal
        '
        Me.colValorTotal.FillWeight = 90.0!
        Me.colValorTotal.HeaderText = "Valor Total"
        Me.colValorTotal.Name = "colValorTotal"
        Me.colValorTotal.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 91)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 24)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Controle :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(33, 128)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 24)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Cliente :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(753, 129)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(150, 24)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Vendedor [F9]:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(749, 30)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 24)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Emissão :"
        '
        'lblEmissao
        '
        Me.lblEmissao.AutoSize = True
        Me.lblEmissao.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmissao.ForeColor = System.Drawing.Color.Blue
        Me.lblEmissao.Location = New System.Drawing.Point(871, 30)
        Me.lblEmissao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmissao.Name = "lblEmissao"
        Me.lblEmissao.Size = New System.Drawing.Size(110, 24)
        Me.lblEmissao.TabIndex = 31
        Me.lblEmissao.Text = "01/01/1901"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(349, 30)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 24)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Loja :"
        '
        'lblLoja
        '
        Me.lblLoja.AutoSize = True
        Me.lblLoja.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoja.ForeColor = System.Drawing.Color.Blue
        Me.lblLoja.Location = New System.Drawing.Point(427, 30)
        Me.lblLoja.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLoja.Name = "lblLoja"
        Me.lblLoja.Size = New System.Drawing.Size(50, 24)
        Me.lblLoja.TabIndex = 33
        Me.lblLoja.Text = "Loja"
        '
        'lblSubtotal
        '
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.ForeColor = System.Drawing.Color.Blue
        Me.lblSubtotal.Location = New System.Drawing.Point(879, 567)
        Me.lblSubtotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(49, 24)
        Me.lblSubtotal.TabIndex = 36
        Me.lblSubtotal.Text = "0,00"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(732, 567)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(127, 24)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Subtotal: R$"
        '
        'lblVendas
        '
        Me.lblVendas.AutoSize = True
        Me.lblVendas.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendas.ForeColor = System.Drawing.Color.Blue
        Me.lblVendas.Location = New System.Drawing.Point(879, 527)
        Me.lblVendas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVendas.Name = "lblVendas"
        Me.lblVendas.Size = New System.Drawing.Size(49, 24)
        Me.lblVendas.TabIndex = 38
        Me.lblVendas.Text = "0,00"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(740, 527)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(117, 24)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Vendas: R$"
        '
        'txtCliente
        '
        Me.txtCliente.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(137, 124)
        Me.txtCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(389, 30)
        Me.txtCliente.TabIndex = 3
        Me.txtCliente.Tag = "1"
        Me.txtCliente.Text = "ao consumidor"
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendedor.ForeColor = System.Drawing.Color.Blue
        Me.lblVendedor.Location = New System.Drawing.Point(925, 129)
        Me.lblVendedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(35, 24)
        Me.lblVendedor.TabIndex = 49
        Me.lblVendedor.Text = "Eu"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(408, 527)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 24)
        Me.Label19.TabIndex = 41
        Me.Label19.Text = "Condicao:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(375, 567)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(138, 24)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "Desconto: R$"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(419, 607)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 24)
        Me.Label23.TabIndex = 45
        Me.Label23.Text = "Parcelas:"
        '
        'txtDesconto
        '
        Me.txtDesconto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesconto.Location = New System.Drawing.Point(535, 562)
        Me.txtDesconto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDesconto.Name = "txtDesconto"
        Me.txtDesconto.ReadOnly = True
        Me.txtDesconto.Size = New System.Drawing.Size(185, 30)
        Me.txtDesconto.TabIndex = 5
        Me.txtDesconto.Text = "0"
        '
        'cboCondicao
        '
        Me.cboCondicao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondicao.Enabled = False
        Me.cboCondicao.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCondicao.FormattingEnabled = True
        Me.cboCondicao.Location = New System.Drawing.Point(535, 522)
        Me.cboCondicao.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboCondicao.Name = "cboCondicao"
        Me.cboCondicao.Size = New System.Drawing.Size(185, 32)
        Me.cboCondicao.TabIndex = 4
        '
        'txtParcelas
        '
        Me.txtParcelas.Enabled = False
        Me.txtParcelas.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParcelas.Location = New System.Drawing.Point(535, 602)
        Me.txtParcelas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtParcelas.Name = "txtParcelas"
        Me.txtParcelas.ReadOnly = True
        Me.txtParcelas.Size = New System.Drawing.Size(185, 30)
        Me.txtParcelas.TabIndex = 6
        Me.txtParcelas.Text = "1"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(85, 606)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(126, 24)
        Me.Label12.TabIndex = 132
        Me.Label12.Text = "Defeitos: R$"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(125, 566)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 24)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "Vale: R$"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(111, 527)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(102, 24)
        Me.Label18.TabIndex = 130
        Me.Label18.Text = "Troca: R$"
        '
        'lblDefeitos
        '
        Me.lblDefeitos.AutoSize = True
        Me.lblDefeitos.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefeitos.ForeColor = System.Drawing.Color.Blue
        Me.lblDefeitos.Location = New System.Drawing.Point(231, 607)
        Me.lblDefeitos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDefeitos.Name = "lblDefeitos"
        Me.lblDefeitos.Size = New System.Drawing.Size(49, 24)
        Me.lblDefeitos.TabIndex = 135
        Me.lblDefeitos.Text = "0,00"
        '
        'lblTroca
        '
        Me.lblTroca.AutoSize = True
        Me.lblTroca.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTroca.ForeColor = System.Drawing.Color.Blue
        Me.lblTroca.Location = New System.Drawing.Point(231, 527)
        Me.lblTroca.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTroca.Name = "lblTroca"
        Me.lblTroca.Size = New System.Drawing.Size(49, 24)
        Me.lblTroca.TabIndex = 134
        Me.lblTroca.Text = "0,00"
        '
        'lblVale
        '
        Me.lblVale.AutoSize = True
        Me.lblVale.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVale.ForeColor = System.Drawing.Color.Blue
        Me.lblVale.Location = New System.Drawing.Point(231, 567)
        Me.lblVale.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVale.Name = "lblVale"
        Me.lblVale.Size = New System.Drawing.Size(49, 24)
        Me.lblVale.TabIndex = 133
        Me.lblVale.Text = "0,00"
        '
        'txtControle
        '
        Me.txtControle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtControle.Location = New System.Drawing.Point(137, 85)
        Me.txtControle.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtControle.MaxLength = 8
        Me.txtControle.Name = "txtControle"
        Me.txtControle.Size = New System.Drawing.Size(197, 30)
        Me.txtControle.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(767, 607)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(95, 24)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "Total: R$"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Blue
        Me.lblTotal.Location = New System.Drawing.Point(879, 607)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(49, 24)
        Me.lblTotal.TabIndex = 40
        Me.lblTotal.Text = "0,00"
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Blue
        Me.lblMsg.Location = New System.Drawing.Point(573, 126)
        Me.lblMsg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(158, 29)
        Me.lblMsg.TabIndex = 167
        Me.lblMsg.Text = "Venda Direta"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(352, 95)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(283, 18)
        Me.Label16.TabIndex = 171
        Me.Label16.Text = "Vendas digite Nr de controle e <Enter>"
        '
        'Panel1
        '
        Me.Panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnExcluirUltima)
        Me.Panel1.Controls.Add(Me.lblOS1)
        Me.Panel1.Controls.Add(Me.lblOS)
        Me.Panel1.Controls.Add(Me.lblMsg)
        Me.Panel1.Controls.Add(Me.lblDefeitos)
        Me.Panel1.Controls.Add(Me.btoSalvar)
        Me.Panel1.Controls.Add(Me.lblTroca)
        Me.Panel1.Controls.Add(Me.btnExcluir)
        Me.Panel1.Controls.Add(Me.lblVale)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.txtParcelas)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cboCondicao)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtDesconto)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.lblTotal)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.lblSubtotal)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.lblVendas)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.btoSair)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.lblEmissao)
        Me.Panel1.Controls.Add(Me.lblLoja)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.lblVendedor)
        Me.Panel1.Controls.Add(Me.dtgProdutos)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1199, 734)
        Me.Panel1.TabIndex = 179
        '
        'btnExcluirUltima
        '
        Me.btnExcluirUltima.BackColor = System.Drawing.Color.Transparent
        Me.btnExcluirUltima.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExcluirUltima.FlatAppearance.BorderSize = 0
        Me.btnExcluirUltima.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcluirUltima.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluirUltima.ForeColor = System.Drawing.Color.Black
        Me.btnExcluirUltima.Image = Global.nascomercio.My.Resources.Resources.excluir
        Me.btnExcluirUltima.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExcluirUltima.Location = New System.Drawing.Point(725, 639)
        Me.btnExcluirUltima.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcluirUltima.Name = "btnExcluirUltima"
        Me.btnExcluirUltima.Size = New System.Drawing.Size(196, 90)
        Me.btnExcluirUltima.TabIndex = 187
        Me.btnExcluirUltima.TabStop = False
        Me.btnExcluirUltima.Text = "Excluir Última[F8]"
        Me.btnExcluirUltima.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExcluirUltima.UseVisualStyleBackColor = False
        '
        'lblOS1
        '
        Me.lblOS1.AutoSize = True
        Me.lblOS1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOS1.Location = New System.Drawing.Point(753, 94)
        Me.lblOS1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOS1.Name = "lblOS1"
        Me.lblOS1.Size = New System.Drawing.Size(52, 24)
        Me.lblOS1.TabIndex = 185
        Me.lblOS1.Text = "OS :"
        '
        'lblOS
        '
        Me.lblOS.AutoSize = True
        Me.lblOS.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOS.ForeColor = System.Drawing.Color.Blue
        Me.lblOS.Location = New System.Drawing.Point(831, 94)
        Me.lblOS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOS.Name = "lblOS"
        Me.lblOS.Size = New System.Drawing.Size(21, 24)
        Me.lblOS.TabIndex = 186
        Me.lblOS.Text = "1"
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
        Me.btoSalvar.Location = New System.Drawing.Point(276, 644)
        Me.btoSalvar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(265, 90)
        Me.btoSalvar.TabIndex = 172
        Me.btoSalvar.TabStop = False
        Me.btoSalvar.Text = "Imprimir Venda[F10]"
        Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSalvar.UseVisualStyleBackColor = False
        '
        'btnExcluir
        '
        Me.btnExcluir.BackColor = System.Drawing.Color.Transparent
        Me.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExcluir.FlatAppearance.BorderSize = 0
        Me.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcluir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluir.ForeColor = System.Drawing.Color.Black
        Me.btnExcluir.Image = Global.nascomercio.My.Resources.Resources.excluir
        Me.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExcluir.Location = New System.Drawing.Point(491, 644)
        Me.btnExcluir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(265, 90)
        Me.btnExcluir.TabIndex = 180
        Me.btnExcluir.TabStop = False
        Me.btnExcluir.Text = "Excluir Venda[F7]"
        Me.btnExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExcluir.UseVisualStyleBackColor = False
        '
        'btoSair
        '
        Me.btoSair.BackColor = System.Drawing.Color.Transparent
        Me.btoSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoSair.FlatAppearance.BorderSize = 0
        Me.btoSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoSair.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoSair.ForeColor = System.Drawing.Color.Black
        Me.btoSair.Image = Global.nascomercio.My.Resources.Resources.fechar
        Me.btoSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoSair.Location = New System.Drawing.Point(1068, 14)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(115, 84)
        Me.btoSair.TabIndex = 48
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.caixa
        Me.imgLogo.Location = New System.Drawing.Point(16, 15)
        Me.imgLogo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(67, 62)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 168
        Me.imgLogo.TabStop = False
        '
        'fCaixaConsulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1200, 735)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.txtControle)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "fCaixaConsulta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fCaixa"
        CType(Me.dtgProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents dtgProdutos As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblEmissao As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblLoja As System.Windows.Forms.Label
    Friend WithEvents lblSubtotal As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblVendas As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblVendedor As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtDesconto As System.Windows.Forms.TextBox
    Friend WithEvents cboCondicao As System.Windows.Forms.ComboBox
    Friend WithEvents txtParcelas As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblDefeitos As System.Windows.Forms.Label
    Friend WithEvents lblTroca As System.Windows.Forms.Label
    Friend WithEvents lblVale As System.Windows.Forms.Label
    Friend WithEvents txtControle As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btoSalvar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReferencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colValorUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colValorTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnExcluir As System.Windows.Forms.Button
    Friend WithEvents lblOS1 As System.Windows.Forms.Label
    Friend WithEvents lblOS As System.Windows.Forms.Label
    Friend WithEvents btnExcluirUltima As System.Windows.Forms.Button
End Class
