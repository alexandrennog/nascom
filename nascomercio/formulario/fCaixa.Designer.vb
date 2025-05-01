<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fCaixa
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fCaixa))
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
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblVendas = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblQtd = New System.Windows.Forms.Label()
        Me.txtQuantidade = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblAbrirFechar = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lblOS1 = New System.Windows.Forms.Label()
        Me.lblOS = New System.Windows.Forms.Label()
        Me.btnOS = New System.Windows.Forms.Button()
        Me.cboVendedor = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btoSalvar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btoIncluirItem = New System.Windows.Forms.Button()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
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
        Me.lblTitulo.Size = New System.Drawing.Size(120, 40)
        Me.lblTitulo.TabIndex = 20
        Me.lblTitulo.Text = "CAIXA"
        '
        'dtgProdutos
        '
        Me.dtgProdutos.AllowUserToAddRows = False
        Me.dtgProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgProdutos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgProdutos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dtgProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgProdutos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colDescricao, Me.colReferencia, Me.colValorUnitario, Me.colQuantidade, Me.colValorTotal})
        Me.dtgProdutos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtgProdutos.Location = New System.Drawing.Point(4, 231)
        Me.dtgProdutos.Margin = New System.Windows.Forms.Padding(4)
        Me.dtgProdutos.MultiSelect = False
        Me.dtgProdutos.Name = "dtgProdutos"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgProdutos.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dtgProdutos.RowHeadersWidth = 51
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgProdutos.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dtgProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgProdutos.Size = New System.Drawing.Size(1163, 348)
        Me.dtgProdutos.TabIndex = 8
        '
        'colCodigo
        '
        Me.colCodigo.FillWeight = 103.9449!
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.MinimumWidth = 6
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colDescricao
        '
        Me.colDescricao.FillWeight = 145.5229!
        Me.colDescricao.HeaderText = "Descrição"
        Me.colDescricao.MinimumWidth = 6
        Me.colDescricao.Name = "colDescricao"
        Me.colDescricao.ReadOnly = True
        '
        'colReferencia
        '
        Me.colReferencia.FillWeight = 114.3394!
        Me.colReferencia.HeaderText = "Referência"
        Me.colReferencia.MinimumWidth = 6
        Me.colReferencia.Name = "colReferencia"
        Me.colReferencia.ReadOnly = True
        '
        'colValorUnitario
        '
        Me.colValorUnitario.FillWeight = 93.55045!
        Me.colValorUnitario.HeaderText = "Valor Unitário"
        Me.colValorUnitario.MinimumWidth = 6
        Me.colValorUnitario.Name = "colValorUnitario"
        '
        'colQuantidade
        '
        Me.colQuantidade.FillWeight = 83.15595!
        Me.colQuantidade.HeaderText = "Quantidade"
        Me.colQuantidade.MinimumWidth = 6
        Me.colQuantidade.Name = "colQuantidade"
        '
        'colValorTotal
        '
        Me.colValorTotal.FillWeight = 93.55045!
        Me.colValorTotal.HeaderText = "Valor Total"
        Me.colValorTotal.MinimumWidth = 6
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
        Me.Label5.Location = New System.Drawing.Point(761, 197)
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
        Me.Label7.Location = New System.Drawing.Point(756, 90)
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
        Me.lblEmissao.Location = New System.Drawing.Point(878, 90)
        Me.lblEmissao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmissao.Name = "lblEmissao"
        Me.lblEmissao.Size = New System.Drawing.Size(110, 24)
        Me.lblEmissao.TabIndex = 31
        Me.lblEmissao.Text = "03/06/2009"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(349, 26)
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
        Me.lblLoja.Location = New System.Drawing.Point(427, 26)
        Me.lblLoja.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLoja.Name = "lblLoja"
        Me.lblLoja.Size = New System.Drawing.Size(100, 24)
        Me.lblLoja.TabIndex = 33
        Me.lblLoja.Text = "SAPATEK"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(17, 164)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(189, 24)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Código do Produto"
        '
        'lblSubtotal
        '
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.ForeColor = System.Drawing.Color.Blue
        Me.lblSubtotal.Location = New System.Drawing.Point(836, 638)
        Me.lblSubtotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(88, 24)
        Me.lblSubtotal.TabIndex = 36
        Me.lblSubtotal.Text = "1.123,45"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(691, 639)
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
        Me.lblVendas.Location = New System.Drawing.Point(836, 597)
        Me.lblVendas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVendas.Name = "lblVendas"
        Me.lblVendas.Size = New System.Drawing.Size(88, 24)
        Me.lblVendas.TabIndex = 38
        Me.lblVendas.Text = "1.123,45"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(699, 598)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(117, 24)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Vendas: R$"
        '
        'txtCodigo
        '
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(21, 191)
        Me.txtCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigo.MaxLength = 20
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(392, 35)
        Me.txtCodigo.TabIndex = 1
        '
        'txtCliente
        '
        Me.txtCliente.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(255, 122)
        Me.txtCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(389, 30)
        Me.txtCliente.TabIndex = 4
        Me.txtCliente.Tag = "1"
        Me.txtCliente.Text = "ao consumidor"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(367, 598)
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
        Me.Label21.Location = New System.Drawing.Point(332, 638)
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
        Me.Label23.Location = New System.Drawing.Point(377, 678)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 24)
        Me.Label23.TabIndex = 45
        Me.Label23.Text = "Parcelas:"
        '
        'txtDesconto
        '
        Me.txtDesconto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesconto.Location = New System.Drawing.Point(493, 634)
        Me.txtDesconto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDesconto.Name = "txtDesconto"
        Me.txtDesconto.Size = New System.Drawing.Size(185, 30)
        Me.txtDesconto.TabIndex = 6
        Me.txtDesconto.Text = "0"
        '
        'cboCondicao
        '
        Me.cboCondicao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondicao.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCondicao.FormattingEnabled = True
        Me.cboCondicao.Location = New System.Drawing.Point(493, 593)
        Me.cboCondicao.Margin = New System.Windows.Forms.Padding(4)
        Me.cboCondicao.Name = "cboCondicao"
        Me.cboCondicao.Size = New System.Drawing.Size(185, 32)
        Me.cboCondicao.TabIndex = 5
        '
        'txtParcelas
        '
        Me.txtParcelas.Enabled = False
        Me.txtParcelas.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParcelas.Location = New System.Drawing.Point(493, 673)
        Me.txtParcelas.Margin = New System.Windows.Forms.Padding(4)
        Me.txtParcelas.Name = "txtParcelas"
        Me.txtParcelas.Size = New System.Drawing.Size(185, 30)
        Me.txtParcelas.TabIndex = 7
        Me.txtParcelas.Text = "1"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(43, 676)
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
        Me.Label4.Location = New System.Drawing.Point(83, 636)
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
        Me.Label18.Location = New System.Drawing.Point(68, 597)
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
        Me.lblDefeitos.Location = New System.Drawing.Point(189, 678)
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
        Me.lblTroca.Location = New System.Drawing.Point(189, 598)
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
        Me.lblVale.Location = New System.Drawing.Point(189, 639)
        Me.lblVale.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVale.Name = "lblVale"
        Me.lblVale.Size = New System.Drawing.Size(88, 24)
        Me.lblVale.TabIndex = 133
        Me.lblVale.Text = "1.123,45"
        '
        'txtControle
        '
        Me.txtControle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtControle.Location = New System.Drawing.Point(137, 85)
        Me.txtControle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtControle.MaxLength = 8
        Me.txtControle.Name = "txtControle"
        Me.txtControle.Size = New System.Drawing.Size(197, 30)
        Me.txtControle.TabIndex = 0
        Me.txtControle.Text = "1"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(725, 678)
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
        Me.lblTotal.Location = New System.Drawing.Point(836, 677)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(88, 24)
        Me.lblTotal.TabIndex = 40
        Me.lblTotal.Text = "1.000,00"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(533, 197)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 18)
        Me.Label2.TabIndex = 160
        Me.Label2.Text = "Pesquisar Produtos [F2]"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(189, 777)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 18)
        Me.Label6.TabIndex = 162
        Me.Label6.Text = "Troca [F5]"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(324, 777)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(115, 18)
        Me.Label8.TabIndex = 164
        Me.Label8.Text = "Devolução [F6]"
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Blue
        Me.lblMsg.Location = New System.Drawing.Point(760, 23)
        Me.lblMsg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(158, 29)
        Me.lblMsg.TabIndex = 167
        Me.lblMsg.Text = "Venda Direta"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(44, 777)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(105, 18)
        Me.Label14.TabIndex = 170
        Me.Label14.Text = "Crediário [F3]"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(352, 95)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(363, 18)
        Me.Label16.TabIndex = 171
        Me.Label16.Text = "Vendas pendentes digite Nr de controle e <Enter>"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(762, 132)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(173, 18)
        Me.Label20.TabIndex = 174
        Me.Label20.Text = "Pesquisar Clientes [F1]"
        '
        'lblQtd
        '
        Me.lblQtd.AutoSize = True
        Me.lblQtd.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQtd.Location = New System.Drawing.Point(427, 164)
        Me.lblQtd.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQtd.Name = "lblQtd"
        Me.lblQtd.Size = New System.Drawing.Size(45, 24)
        Me.lblQtd.TabIndex = 176
        Me.lblQtd.Text = "Qtd"
        '
        'txtQuantidade
        '
        Me.txtQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtQuantidade.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantidade.Location = New System.Drawing.Point(427, 191)
        Me.txtQuantidade.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQuantidade.MaxLength = 20
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.Size = New System.Drawing.Size(64, 35)
        Me.txtQuantidade.TabIndex = 2
        Me.txtQuantidade.Text = "1"
        '
        'Panel1
        '
        Me.Panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtIdCliente)
        Me.Panel1.Controls.Add(Me.lblAbrirFechar)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.txtCliente)
        Me.Panel1.Controls.Add(Me.lblOS1)
        Me.Panel1.Controls.Add(Me.lblOS)
        Me.Panel1.Controls.Add(Me.dtgProdutos)
        Me.Panel1.Controls.Add(Me.btnOS)
        Me.Panel1.Controls.Add(Me.cboVendedor)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.btoSalvar)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.lblTotal)
        Me.Panel1.Controls.Add(Me.lblSubtotal)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.lblMsg)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.lblVendas)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.btoSair)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.lblEmissao)
        Me.Panel1.Controls.Add(Me.lblLoja)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1198, 816)
        Me.Panel1.TabIndex = 179
        '
        'lblAbrirFechar
        '
        Me.lblAbrirFechar.AutoSize = True
        Me.lblAbrirFechar.BackColor = System.Drawing.Color.Transparent
        Me.lblAbrirFechar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbrirFechar.Location = New System.Drawing.Point(1028, 777)
        Me.lblAbrirFechar.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAbrirFechar.Name = "lblAbrirFechar"
        Me.lblAbrirFechar.Size = New System.Drawing.Size(139, 18)
        Me.lblAbrirFechar.TabIndex = 186
        Me.lblAbrirFechar.Text = "Fechar Caixa [F12]"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(987, 770)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(33, 31)
        Me.Button3.TabIndex = 185
        Me.Button3.TabStop = False
        Me.Button3.UseVisualStyleBackColor = False
        '
        'lblOS1
        '
        Me.lblOS1.AutoSize = True
        Me.lblOS1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOS1.Location = New System.Drawing.Point(761, 159)
        Me.lblOS1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOS1.Name = "lblOS1"
        Me.lblOS1.Size = New System.Drawing.Size(52, 24)
        Me.lblOS1.TabIndex = 183
        Me.lblOS1.Text = "OS :"
        '
        'lblOS
        '
        Me.lblOS.AutoSize = True
        Me.lblOS.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOS.ForeColor = System.Drawing.Color.Blue
        Me.lblOS.Location = New System.Drawing.Point(839, 159)
        Me.lblOS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOS.Name = "lblOS"
        Me.lblOS.Size = New System.Drawing.Size(21, 24)
        Me.lblOS.TabIndex = 184
        Me.lblOS.Text = "1"
        '
        'btnOS
        '
        Me.btnOS.BackColor = System.Drawing.Color.Transparent
        Me.btnOS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOS.FlatAppearance.BorderSize = 0
        Me.btnOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnOS.ForeColor = System.Drawing.Color.Black
        Me.btnOS.Image = Global.nascomercio.My.Resources.Resources.cliente_financeiro
        Me.btnOS.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOS.Location = New System.Drawing.Point(1068, 90)
        Me.btnOS.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOS.Name = "btnOS"
        Me.btnOS.Size = New System.Drawing.Size(115, 90)
        Me.btnOS.TabIndex = 182
        Me.btnOS.Text = "OS <F11>"
        Me.btnOS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnOS.UseVisualStyleBackColor = False
        '
        'cboVendedor
        '
        Me.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVendedor.FormattingEnabled = True
        Me.cboVendedor.Location = New System.Drawing.Point(932, 191)
        Me.cboVendedor.Margin = New System.Windows.Forms.Padding(4)
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(249, 32)
        Me.cboVendedor.TabIndex = 3
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Transparent
        Me.Button6.BackgroundImage = CType(resources.GetObject("Button6.BackgroundImage"), System.Drawing.Image)
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Location = New System.Drawing.Point(725, 770)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(33, 31)
        Me.Button6.TabIndex = 177
        Me.Button6.TabStop = False
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(749, 777)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 18)
        Me.Label10.TabIndex = 178
        Me.Label10.Text = " Cancelar [F7]"
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Transparent
        Me.Button7.BackgroundImage = CType(resources.GetObject("Button7.BackgroundImage"), System.Drawing.Image)
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.White
        Me.Button7.Location = New System.Drawing.Point(871, 770)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(33, 31)
        Me.Button7.TabIndex = 180
        Me.Button7.TabStop = False
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(900, 777)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 18)
        Me.Label22.TabIndex = 181
        Me.Label22.Text = " Vale [F8]"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), System.Drawing.Image)
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(15, 770)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(33, 31)
        Me.Button4.TabIndex = 169
        Me.Button4.TabStop = False
        Me.Button4.UseVisualStyleBackColor = False
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
        Me.btoSalvar.Location = New System.Drawing.Point(452, 711)
        Me.btoSalvar.Margin = New System.Windows.Forms.Padding(4)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(265, 90)
        Me.btoSalvar.TabIndex = 9
        Me.btoSalvar.TabStop = False
        Me.btoSalvar.Text = "Finalizar Venda / Nova Venda[F10]"
        Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSalvar.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(157, 770)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(33, 31)
        Me.Button1.TabIndex = 161
        Me.Button1.TabStop = False
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(283, 770)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(33, 31)
        Me.Button2.TabIndex = 163
        Me.Button2.TabStop = False
        Me.Button2.UseVisualStyleBackColor = False
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
        Me.btoSair.Location = New System.Drawing.Point(1068, 4)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(4)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(115, 84)
        Me.btoSair.TabIndex = 10
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.BackgroundImage = CType(resources.GetObject("Button5.BackgroundImage"), System.Drawing.Image)
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(652, 122)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(33, 31)
        Me.Button5.TabIndex = 173
        Me.Button5.TabStop = False
        Me.Button5.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.caixa
        Me.imgLogo.Location = New System.Drawing.Point(16, 15)
        Me.imgLogo.Margin = New System.Windows.Forms.Padding(4)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(67, 62)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 168
        Me.imgLogo.TabStop = False
        '
        'btoIncluirItem
        '
        Me.btoIncluirItem.BackColor = System.Drawing.Color.Transparent
        Me.btoIncluirItem.BackgroundImage = CType(resources.GetObject("btoIncluirItem.BackgroundImage"), System.Drawing.Image)
        Me.btoIncluirItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoIncluirItem.FlatAppearance.BorderSize = 0
        Me.btoIncluirItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoIncluirItem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoIncluirItem.ForeColor = System.Drawing.Color.White
        Me.btoIncluirItem.Location = New System.Drawing.Point(501, 191)
        Me.btoIncluirItem.Margin = New System.Windows.Forms.Padding(4)
        Me.btoIncluirItem.Name = "btoIncluirItem"
        Me.btoIncluirItem.Size = New System.Drawing.Size(33, 31)
        Me.btoIncluirItem.TabIndex = 159
        Me.btoIncluirItem.TabStop = False
        Me.btoIncluirItem.UseVisualStyleBackColor = False
        '
        'txtIdCliente
        '
        Me.txtIdCliente.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCliente.Location = New System.Drawing.Point(136, 122)
        Me.txtIdCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdCliente.MaxLength = 8
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.Size = New System.Drawing.Size(111, 30)
        Me.txtIdCliente.TabIndex = 187
        '
        'fCaixa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1200, 817)
        Me.Controls.Add(Me.txtQuantidade)
        Me.Controls.Add(Me.txtControle)
        Me.Controls.Add(Me.txtParcelas)
        Me.Controls.Add(Me.cboCondicao)
        Me.Controls.Add(Me.txtDesconto)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.lblQtd)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btoIncluirItem)
        Me.Controls.Add(Me.lblDefeitos)
        Me.Controls.Add(Me.lblTroca)
        Me.Controls.Add(Me.lblVale)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "fCaixa"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblSubtotal As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblVendas As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btoIncluirItem As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btoSalvar As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents lblQtd As System.Windows.Forms.Label
    Friend WithEvents txtQuantidade As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents btnOS As System.Windows.Forms.Button
    Friend WithEvents lblOS1 As System.Windows.Forms.Label
    Friend WithEvents lblOS As System.Windows.Forms.Label
    Friend WithEvents lblAbrirFechar As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents colCodigo As DataGridViewTextBoxColumn
    Friend WithEvents colDescricao As DataGridViewTextBoxColumn
    Friend WithEvents colReferencia As DataGridViewTextBoxColumn
    Friend WithEvents colValorUnitario As DataGridViewTextBoxColumn
    Friend WithEvents colQuantidade As DataGridViewTextBoxColumn
    Friend WithEvents colValorTotal As DataGridViewTextBoxColumn
    Friend WithEvents txtIdCliente As TextBox
End Class
