<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProdutoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fProdutoForm))
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblNome = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.cboSituacao = New System.Windows.Forms.ComboBox()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.lblFornecedor = New System.Windows.Forms.Label()
        Me.cboFornecedor = New System.Windows.Forms.ComboBox()
        Me.lblFabricante = New System.Windows.Forms.Label()
        Me.cboFabricante = New System.Windows.Forms.ComboBox()
        Me.txtValorCompra = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtValorVenda = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvProduto = New System.Windows.Forms.DataGridView()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.lblReferencia = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblExcluirItem = New System.Windows.Forms.Label()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.txtEstoqueTotal = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboCor = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEstoqueMinimo = New System.Windows.Forms.MaskedTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btoFornecedores = New System.Windows.Forms.Button()
        Me.btoFabricantes = New System.Windows.Forms.Button()
        Me.btoCor = New System.Windows.Forms.Button()
        Me.btoGrade = New System.Windows.Forms.Button()
        Me.btoCadastro = New System.Windows.Forms.Button()
        Me.btoEtiquetaES = New System.Windows.Forms.Button()
        Me.btoEtiqueta = New System.Windows.Forms.Button()
        Me.btoExcluirItem = New System.Windows.Forms.Button()
        Me.btoIncluirItem = New System.Windows.Forms.Button()
        Me.btoExcluir = New System.Windows.Forms.Button()
        Me.btoSalvar = New System.Windows.Forms.Button()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.btoFiltro = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btoNotaFiscal = New System.Windows.Forms.Button()
        Me.txtAliquota = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNotaFiscalNumero = New System.Windows.Forms.TextBox()
        Me.txtNotaFiscalSerie = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btoNF = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btoCategoria = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.cboEfdUnidadeMedida = New System.Windows.Forms.ComboBox()
        Me.btoGrupo = New System.Windows.Forms.Button()
        Me.btoImpostos = New System.Windows.Forms.Button()
        CType(Me.dgvProduto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDescricao
        '
        Me.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDescricao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescricao.Location = New System.Drawing.Point(104, 92)
        Me.txtDescricao.MaxLength = 50
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(540, 18)
        Me.txtDescricao.TabIndex = 3
        '
        'txtCodigo
        '
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(104, 68)
        Me.txtCodigo.MaxLength = 20
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(208, 18)
        Me.txtCodigo.TabIndex = 1
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.BackColor = System.Drawing.Color.Transparent
        Me.lblTipo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.Location = New System.Drawing.Point(405, 205)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(40, 18)
        Me.lblTipo.TabIndex = 129
        Me.lblTipo.Text = "Tipo"
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
        Me.lblTitulo.Size = New System.Drawing.Size(103, 24)
        Me.lblTitulo.TabIndex = 121
        Me.lblTitulo.Text = "Produtos"
        '
        'lblNome
        '
        Me.lblNome.AutoSize = True
        Me.lblNome.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblNome.Location = New System.Drawing.Point(20, 92)
        Me.lblNome.Name = "lblNome"
        Me.lblNome.Size = New System.Drawing.Size(83, 18)
        Me.lblNome.TabIndex = 119
        Me.lblNome.Text = "Descri��o"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblCodigo.Location = New System.Drawing.Point(40, 68)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(60, 18)
        Me.lblCodigo.TabIndex = 118
        Me.lblCodigo.Text = "C�digo"
        '
        'cboSituacao
        '
        Me.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboSituacao.FormattingEnabled = True
        Me.cboSituacao.Location = New System.Drawing.Point(103, 235)
        Me.cboSituacao.Name = "cboSituacao"
        Me.cboSituacao.Size = New System.Drawing.Size(188, 26)
        Me.cboSituacao.TabIndex = 11
        '
        'cboTipo
        '
        Me.cboTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTipo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(455, 207)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(188, 26)
        Me.cboTipo.TabIndex = 10
        '
        'lblFornecedor
        '
        Me.lblFornecedor.AutoSize = True
        Me.lblFornecedor.BackColor = System.Drawing.Color.Transparent
        Me.lblFornecedor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblFornecedor.Location = New System.Drawing.Point(8, 120)
        Me.lblFornecedor.Name = "lblFornecedor"
        Me.lblFornecedor.Size = New System.Drawing.Size(91, 18)
        Me.lblFornecedor.TabIndex = 139
        Me.lblFornecedor.Text = "Fornecedor"
        '
        'cboFornecedor
        '
        Me.cboFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFornecedor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboFornecedor.FormattingEnabled = True
        Me.cboFornecedor.Location = New System.Drawing.Point(104, 116)
        Me.cboFornecedor.Name = "cboFornecedor"
        Me.cboFornecedor.Size = New System.Drawing.Size(519, 26)
        Me.cboFornecedor.TabIndex = 4
        '
        'lblFabricante
        '
        Me.lblFabricante.AutoSize = True
        Me.lblFabricante.BackColor = System.Drawing.Color.Transparent
        Me.lblFabricante.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblFabricante.Location = New System.Drawing.Point(16, 152)
        Me.lblFabricante.Name = "lblFabricante"
        Me.lblFabricante.Size = New System.Drawing.Size(83, 18)
        Me.lblFabricante.TabIndex = 141
        Me.lblFabricante.Text = "Fabricante"
        '
        'cboFabricante
        '
        Me.cboFabricante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFabricante.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboFabricante.FormattingEnabled = True
        Me.cboFabricante.Location = New System.Drawing.Point(104, 148)
        Me.cboFabricante.Name = "cboFabricante"
        Me.cboFabricante.Size = New System.Drawing.Size(215, 26)
        Me.cboFabricante.TabIndex = 5
        '
        'txtValorCompra
        '
        Me.txtValorCompra.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorCompra.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorCompra.Location = New System.Drawing.Point(103, 179)
        Me.txtValorCompra.MaxLength = 9
        Me.txtValorCompra.Name = "txtValorCompra"
        Me.txtValorCompra.Size = New System.Drawing.Size(188, 18)
        Me.txtValorCompra.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(14, 179)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 18)
        Me.Label2.TabIndex = 150
        Me.Label2.Text = "Custo (R$)"
        '
        'txtValorVenda
        '
        Me.txtValorVenda.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorVenda.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorVenda.Location = New System.Drawing.Point(455, 183)
        Me.txtValorVenda.MaxLength = 9
        Me.txtValorVenda.Name = "txtValorVenda"
        Me.txtValorVenda.Size = New System.Drawing.Size(188, 18)
        Me.txtValorVenda.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(361, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 18)
        Me.Label3.TabIndex = 152
        Me.Label3.Text = "Venda (R$)"
        '
        'dgvProduto
        '
        Me.dgvProduto.AllowUserToAddRows = False
        Me.dgvProduto.AllowUserToDeleteRows = False
        Me.dgvProduto.AllowUserToOrderColumns = True
        Me.dgvProduto.AllowUserToResizeColumns = False
        Me.dgvProduto.AllowUserToResizeRows = False
        Me.dgvProduto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProduto.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvProduto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvProduto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProduto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvProduto.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvProduto.Location = New System.Drawing.Point(10, 335)
        Me.dgvProduto.Name = "dgvProduto"
        Me.dgvProduto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvProduto.RowHeadersVisible = False
        Me.dgvProduto.Size = New System.Drawing.Size(636, 130)
        Me.dgvProduto.TabIndex = 16
        Me.dgvProduto.TabStop = False
        '
        'txtReferencia
        '
        Me.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtReferencia.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferencia.Location = New System.Drawing.Point(443, 67)
        Me.txtReferencia.MaxLength = 20
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(200, 18)
        Me.txtReferencia.TabIndex = 2
        '
        'lblReferencia
        '
        Me.lblReferencia.AutoSize = True
        Me.lblReferencia.BackColor = System.Drawing.Color.Transparent
        Me.lblReferencia.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblReferencia.Location = New System.Drawing.Point(352, 68)
        Me.lblReferencia.Name = "lblReferencia"
        Me.lblReferencia.Size = New System.Drawing.Size(87, 18)
        Me.lblReferencia.TabIndex = 156
        Me.lblReferencia.Text = "Refer�ncia"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(128, 476)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 14)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Incluir Item <F3>"
        '
        'lblExcluirItem
        '
        Me.lblExcluirItem.AutoSize = True
        Me.lblExcluirItem.BackColor = System.Drawing.Color.Transparent
        Me.lblExcluirItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExcluirItem.Location = New System.Drawing.Point(256, 476)
        Me.lblExcluirItem.Name = "lblExcluirItem"
        Me.lblExcluirItem.Size = New System.Drawing.Size(98, 14)
        Me.lblExcluirItem.TabIndex = 162
        Me.lblExcluirItem.Text = "Excluir Item <F4>"
        '
        'lblSituacao
        '
        Me.lblSituacao.AutoSize = True
        Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
        Me.lblSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblSituacao.Location = New System.Drawing.Point(28, 236)
        Me.lblSituacao.Name = "lblSituacao"
        Me.lblSituacao.Size = New System.Drawing.Size(73, 18)
        Me.lblSituacao.TabIndex = 163
        Me.lblSituacao.Text = "Situa��o"
        '
        'txtEstoqueTotal
        '
        Me.txtEstoqueTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtEstoqueTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEstoqueTotal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstoqueTotal.Location = New System.Drawing.Point(544, 472)
        Me.txtEstoqueTotal.MaxLength = 20
        Me.txtEstoqueTotal.Name = "txtEstoqueTotal"
        Me.txtEstoqueTotal.ReadOnly = True
        Me.txtEstoqueTotal.Size = New System.Drawing.Size(100, 18)
        Me.txtEstoqueTotal.TabIndex = 170
        Me.txtEstoqueTotal.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(432, 472)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 18)
        Me.Label6.TabIndex = 171
        Me.Label6.Text = "Estoque Total"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(45, 205)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 18)
        Me.Label8.TabIndex = 176
        Me.Label8.Text = "Grupo"
        '
        'cboGrupo
        '
        Me.cboGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboGrupo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(102, 203)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(189, 26)
        Me.cboGrupo.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(411, 157)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 18)
        Me.Label9.TabIndex = 179
        Me.Label9.Text = "Cor"
        '
        'cboCor
        '
        Me.cboCor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboCor.FormattingEnabled = True
        Me.cboCor.Location = New System.Drawing.Point(455, 151)
        Me.cboCor.Name = "cboCor"
        Me.cboCor.Size = New System.Drawing.Size(167, 26)
        Me.cboCor.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(459, 239)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 18)
        Me.Label7.TabIndex = 181
        Me.Label7.Text = "Est. M�nimo"
        '
        'txtEstoqueMinimo
        '
        Me.txtEstoqueMinimo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEstoqueMinimo.Culture = New System.Globalization.CultureInfo("")
        Me.txtEstoqueMinimo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtEstoqueMinimo.Location = New System.Drawing.Point(555, 239)
        Me.txtEstoqueMinimo.Mask = "000000"
        Me.txtEstoqueMinimo.Name = "txtEstoqueMinimo"
        Me.txtEstoqueMinimo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtEstoqueMinimo.Size = New System.Drawing.Size(88, 18)
        Me.txtEstoqueMinimo.TabIndex = 12
        Me.txtEstoqueMinimo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(436, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 18)
        Me.Label10.TabIndex = 184
        Me.Label10.Text = "Al�quota"
        '
        'btoFornecedores
        '
        Me.btoFornecedores.BackColor = System.Drawing.Color.Transparent
        Me.btoFornecedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoFornecedores.FlatAppearance.BorderSize = 0
        Me.btoFornecedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoFornecedores.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoFornecedores.ForeColor = System.Drawing.Color.Black
        Me.btoFornecedores.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoFornecedores.Location = New System.Drawing.Point(620, 121)
        Me.btoFornecedores.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFornecedores.Name = "btoFornecedores"
        Me.btoFornecedores.Size = New System.Drawing.Size(40, 20)
        Me.btoFornecedores.TabIndex = 185
        Me.btoFornecedores.TabStop = False
        Me.btoFornecedores.Text = "<F9>"
        Me.btoFornecedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btoFornecedores.UseVisualStyleBackColor = False
        '
        'btoFabricantes
        '
        Me.btoFabricantes.BackColor = System.Drawing.Color.Transparent
        Me.btoFabricantes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoFabricantes.FlatAppearance.BorderSize = 0
        Me.btoFabricantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoFabricantes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoFabricantes.ForeColor = System.Drawing.Color.Black
        Me.btoFabricantes.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoFabricantes.Location = New System.Drawing.Point(321, 151)
        Me.btoFabricantes.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFabricantes.Name = "btoFabricantes"
        Me.btoFabricantes.Size = New System.Drawing.Size(48, 20)
        Me.btoFabricantes.TabIndex = 186
        Me.btoFabricantes.TabStop = False
        Me.btoFabricantes.Text = "<F10>"
        Me.btoFabricantes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btoFabricantes.UseVisualStyleBackColor = False
        '
        'btoCor
        '
        Me.btoCor.BackColor = System.Drawing.Color.Transparent
        Me.btoCor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoCor.FlatAppearance.BorderSize = 0
        Me.btoCor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoCor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoCor.ForeColor = System.Drawing.Color.Black
        Me.btoCor.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoCor.Location = New System.Drawing.Point(618, 151)
        Me.btoCor.Margin = New System.Windows.Forms.Padding(0)
        Me.btoCor.Name = "btoCor"
        Me.btoCor.Size = New System.Drawing.Size(48, 20)
        Me.btoCor.TabIndex = 187
        Me.btoCor.TabStop = False
        Me.btoCor.Text = "<F11>"
        Me.btoCor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btoCor.UseVisualStyleBackColor = False
        '
        'btoGrade
        '
        Me.btoGrade.BackColor = System.Drawing.Color.Transparent
        Me.btoGrade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btoGrade.FlatAppearance.BorderSize = 0
        Me.btoGrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoGrade.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoGrade.ForeColor = System.Drawing.Color.Black
        Me.btoGrade.Image = Global.nascomercio.My.Resources.Resources.grade1
        Me.btoGrade.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoGrade.Location = New System.Drawing.Point(674, 312)
        Me.btoGrade.Margin = New System.Windows.Forms.Padding(0)
        Me.btoGrade.Name = "btoGrade"
        Me.btoGrade.Size = New System.Drawing.Size(119, 68)
        Me.btoGrade.TabIndex = 27
        Me.btoGrade.TabStop = False
        Me.btoGrade.Text = "Grade <F8>"
        Me.btoGrade.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoGrade.UseVisualStyleBackColor = False
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
        Me.btoCadastro.Location = New System.Drawing.Point(351, 492)
        Me.btoCadastro.Name = "btoCadastro"
        Me.btoCadastro.Size = New System.Drawing.Size(76, 72)
        Me.btoCadastro.TabIndex = 21
        Me.btoCadastro.TabStop = False
        Me.btoCadastro.Text = "Novo <F1>"
        Me.btoCadastro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoCadastro.UseVisualStyleBackColor = False
        '
        'btoEtiquetaES
        '
        Me.btoEtiquetaES.BackColor = System.Drawing.Color.Transparent
        Me.btoEtiquetaES.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoEtiquetaES.FlatAppearance.BorderSize = 0
        Me.btoEtiquetaES.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoEtiquetaES.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoEtiquetaES.ForeColor = System.Drawing.Color.Black
        Me.btoEtiquetaES.Image = Global.nascomercio.My.Resources.Resources.print_design
        Me.btoEtiquetaES.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoEtiquetaES.Location = New System.Drawing.Point(674, 236)
        Me.btoEtiquetaES.Margin = New System.Windows.Forms.Padding(0)
        Me.btoEtiquetaES.Name = "btoEtiquetaES"
        Me.btoEtiquetaES.Size = New System.Drawing.Size(119, 72)
        Me.btoEtiquetaES.TabIndex = 26
        Me.btoEtiquetaES.TabStop = False
        Me.btoEtiquetaES.Text = "Etiquetas E/S <F7>"
        Me.btoEtiquetaES.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoEtiquetaES.UseVisualStyleBackColor = False
        '
        'btoEtiqueta
        '
        Me.btoEtiqueta.BackColor = System.Drawing.Color.Transparent
        Me.btoEtiqueta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoEtiqueta.FlatAppearance.BorderSize = 0
        Me.btoEtiqueta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoEtiqueta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoEtiqueta.ForeColor = System.Drawing.Color.Black
        Me.btoEtiqueta.Image = Global.nascomercio.My.Resources.Resources.print_design
        Me.btoEtiqueta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoEtiqueta.Location = New System.Drawing.Point(674, 160)
        Me.btoEtiqueta.Margin = New System.Windows.Forms.Padding(0)
        Me.btoEtiqueta.Name = "btoEtiqueta"
        Me.btoEtiqueta.Size = New System.Drawing.Size(119, 72)
        Me.btoEtiqueta.TabIndex = 25
        Me.btoEtiqueta.TabStop = False
        Me.btoEtiqueta.Text = "Etiqs. Avulsas <F6>"
        Me.btoEtiqueta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoEtiqueta.UseVisualStyleBackColor = False
        '
        'btoExcluirItem
        '
        Me.btoExcluirItem.BackColor = System.Drawing.Color.Transparent
        Me.btoExcluirItem.BackgroundImage = CType(resources.GetObject("btoExcluirItem.BackgroundImage"), System.Drawing.Image)
        Me.btoExcluirItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoExcluirItem.FlatAppearance.BorderSize = 0
        Me.btoExcluirItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoExcluirItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoExcluirItem.ForeColor = System.Drawing.Color.White
        Me.btoExcluirItem.Location = New System.Drawing.Point(232, 468)
        Me.btoExcluirItem.Name = "btoExcluirItem"
        Me.btoExcluirItem.Size = New System.Drawing.Size(25, 25)
        Me.btoExcluirItem.TabIndex = 19
        Me.btoExcluirItem.TabStop = False
        Me.btoExcluirItem.UseVisualStyleBackColor = False
        '
        'btoIncluirItem
        '
        Me.btoIncluirItem.BackColor = System.Drawing.Color.Transparent
        Me.btoIncluirItem.BackgroundImage = CType(resources.GetObject("btoIncluirItem.BackgroundImage"), System.Drawing.Image)
        Me.btoIncluirItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoIncluirItem.FlatAppearance.BorderSize = 0
        Me.btoIncluirItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoIncluirItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoIncluirItem.ForeColor = System.Drawing.Color.White
        Me.btoIncluirItem.Location = New System.Drawing.Point(104, 468)
        Me.btoIncluirItem.Name = "btoIncluirItem"
        Me.btoIncluirItem.Size = New System.Drawing.Size(25, 25)
        Me.btoIncluirItem.TabIndex = 17
        Me.btoIncluirItem.TabStop = False
        Me.btoIncluirItem.UseVisualStyleBackColor = False
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
        Me.btoExcluir.Location = New System.Drawing.Point(433, 492)
        Me.btoExcluir.Name = "btoExcluir"
        Me.btoExcluir.Size = New System.Drawing.Size(88, 72)
        Me.btoExcluir.TabIndex = 22
        Me.btoExcluir.TabStop = False
        Me.btoExcluir.Text = "Excluir <F12>"
        Me.btoExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoExcluir.UseVisualStyleBackColor = False
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
        Me.btoSalvar.Location = New System.Drawing.Point(249, 492)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(96, 72)
        Me.btoSalvar.TabIndex = 20
        Me.btoSalvar.TabStop = False
        Me.btoSalvar.Text = "Salvar <Enter>"
        Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSalvar.UseVisualStyleBackColor = False
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
        Me.btoSair.Location = New System.Drawing.Point(674, 8)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(119, 72)
        Me.btoSair.TabIndex = 23
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <ESC>"
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
        Me.btoFiltro.Location = New System.Drawing.Point(674, 84)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(119, 72)
        Me.btoFiltro.TabIndex = 24
        Me.btoFiltro.TabStop = False
        Me.btoFiltro.Text = "Pesquisar <F5>"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.produtos
        Me.imgLogo.Location = New System.Drawing.Point(8, 8)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 124
        Me.imgLogo.TabStop = False
        '
        'btoNotaFiscal
        '
        Me.btoNotaFiscal.BackColor = System.Drawing.Color.Transparent
        Me.btoNotaFiscal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoNotaFiscal.FlatAppearance.BorderSize = 0
        Me.btoNotaFiscal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoNotaFiscal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoNotaFiscal.ForeColor = System.Drawing.Color.Black
        Me.btoNotaFiscal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoNotaFiscal.Location = New System.Drawing.Point(365, 1)
        Me.btoNotaFiscal.Margin = New System.Windows.Forms.Padding(0)
        Me.btoNotaFiscal.Name = "btoNotaFiscal"
        Me.btoNotaFiscal.Size = New System.Drawing.Size(68, 22)
        Me.btoNotaFiscal.TabIndex = 202
        Me.btoNotaFiscal.TabStop = False
        Me.btoNotaFiscal.Tag = ""
        Me.btoNotaFiscal.Text = "<ALT+F2>"
        Me.btoNotaFiscal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoNotaFiscal.UseVisualStyleBackColor = False
        '
        'txtAliquota
        '
        Me.txtAliquota.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAliquota.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAliquota.Location = New System.Drawing.Point(507, 5)
        Me.txtAliquota.MaxLength = 9
        Me.txtAliquota.Name = "txtAliquota"
        Me.txtAliquota.Size = New System.Drawing.Size(97, 18)
        Me.txtAliquota.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(28, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 18)
        Me.Label5.TabIndex = 205
        Me.Label5.Text = "Nota Fiscal"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(259, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 18)
        Me.Label11.TabIndex = 207
        Me.Label11.Text = "S�rie"
        '
        'txtNotaFiscalNumero
        '
        Me.txtNotaFiscalNumero.BackColor = System.Drawing.Color.White
        Me.txtNotaFiscalNumero.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNotaFiscalNumero.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotaFiscalNumero.Location = New System.Drawing.Point(120, 5)
        Me.txtNotaFiscalNumero.MaxLength = 20
        Me.txtNotaFiscalNumero.Name = "txtNotaFiscalNumero"
        Me.txtNotaFiscalNumero.Size = New System.Drawing.Size(133, 18)
        Me.txtNotaFiscalNumero.TabIndex = 13
        '
        'txtNotaFiscalSerie
        '
        Me.txtNotaFiscalSerie.BackColor = System.Drawing.Color.White
        Me.txtNotaFiscalSerie.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNotaFiscalSerie.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotaFiscalSerie.Location = New System.Drawing.Point(311, 5)
        Me.txtNotaFiscalSerie.MaxLength = 20
        Me.txtNotaFiscalSerie.Name = "txtNotaFiscalSerie"
        Me.txtNotaFiscalSerie.Size = New System.Drawing.Size(59, 18)
        Me.txtNotaFiscalSerie.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btoNF)
        Me.Panel1.Controls.Add(Me.cboGrupo)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.dgvProduto)
        Me.Panel1.Controls.Add(Me.btoSalvar)
        Me.Panel1.Controls.Add(Me.btoCadastro)
        Me.Panel1.Controls.Add(Me.btoExcluir)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.lblSituacao)
        Me.Panel1.Controls.Add(Me.cboCor)
        Me.Panel1.Controls.Add(Me.btoGrupo)
        Me.Panel1.Controls.Add(Me.btoFornecedores)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtEstoqueMinimo)
        Me.Panel1.Controls.Add(Me.btoFabricantes)
        Me.Panel1.Controls.Add(Me.btoCor)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtReferencia)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtValorVenda)
        Me.Panel1.Controls.Add(Me.txtValorCompra)
        Me.Panel1.Controls.Add(Me.cboSituacao)
        Me.Panel1.Controls.Add(Me.lblTipo)
        Me.Panel1.Controls.Add(Me.cboTipo)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(802, 569)
        Me.Panel1.TabIndex = 28
        '
        'btoNF
        '
        Me.btoNF.BackColor = System.Drawing.Color.Transparent
        Me.btoNF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoNF.FlatAppearance.BorderSize = 0
        Me.btoNF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoNF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoNF.ForeColor = System.Drawing.Color.Black
        Me.btoNF.Image = Global.nascomercio.My.Resources.Resources.iconeCadastroPro
        Me.btoNF.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoNF.Location = New System.Drawing.Point(669, 379)
        Me.btoNF.Margin = New System.Windows.Forms.Padding(0)
        Me.btoNF.Name = "btoNF"
        Me.btoNF.Size = New System.Drawing.Size(123, 77)
        Me.btoNF.TabIndex = 28
        Me.btoNF.TabStop = False
        Me.btoNF.Text = "Nota Fiscal <F2>"
        Me.btoNF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoNF.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btoCategoria)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.btoNotaFiscal)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.cboCategoria)
        Me.Panel2.Controls.Add(Me.txtAliquota)
        Me.Panel2.Controls.Add(Me.txtNotaFiscalSerie)
        Me.Panel2.Controls.Add(Me.txtNotaFiscalNumero)
        Me.Panel2.Controls.Add(Me.cboEfdUnidadeMedida)
        Me.Panel2.Location = New System.Drawing.Point(11, 266)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(635, 63)
        Me.Panel2.TabIndex = 212
        '
        'btoCategoria
        '
        Me.btoCategoria.BackColor = System.Drawing.Color.Transparent
        Me.btoCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoCategoria.FlatAppearance.BorderSize = 0
        Me.btoCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoCategoria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoCategoria.ForeColor = System.Drawing.Color.Black
        Me.btoCategoria.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoCategoria.Location = New System.Drawing.Point(562, 29)
        Me.btoCategoria.Margin = New System.Windows.Forms.Padding(0)
        Me.btoCategoria.Name = "btoCategoria"
        Me.btoCategoria.Size = New System.Drawing.Size(66, 20)
        Me.btoCategoria.TabIndex = 216
        Me.btoCategoria.TabStop = False
        Me.btoCategoria.Text = "<ALT F4>"
        Me.btoCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btoCategoria.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(317, 36)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 18)
        Me.Label14.TabIndex = 215
        Me.Label14.Text = "Categoria"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(610, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(17, 16)
        Me.Label13.TabIndex = 177
        Me.Label13.Text = "%"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(13, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 18)
        Me.Label4.TabIndex = 209
        Me.Label4.Text = "Unid. Medida"
        '
        'cboCategoria
        '
        Me.cboCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCategoria.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Location = New System.Drawing.Point(400, 29)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(158, 26)
        Me.cboCategoria.TabIndex = 17
        '
        'cboEfdUnidadeMedida
        '
        Me.cboEfdUnidadeMedida.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboEfdUnidadeMedida.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboEfdUnidadeMedida.FormattingEnabled = True
        Me.cboEfdUnidadeMedida.Location = New System.Drawing.Point(120, 29)
        Me.cboEfdUnidadeMedida.Name = "cboEfdUnidadeMedida"
        Me.cboEfdUnidadeMedida.Size = New System.Drawing.Size(187, 26)
        Me.cboEfdUnidadeMedida.TabIndex = 16
        '
        'btoGrupo
        '
        Me.btoGrupo.BackColor = System.Drawing.Color.Transparent
        Me.btoGrupo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoGrupo.FlatAppearance.BorderSize = 0
        Me.btoGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoGrupo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoGrupo.ForeColor = System.Drawing.Color.Black
        Me.btoGrupo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoGrupo.Location = New System.Drawing.Point(292, 205)
        Me.btoGrupo.Margin = New System.Windows.Forms.Padding(0)
        Me.btoGrupo.Name = "btoGrupo"
        Me.btoGrupo.Size = New System.Drawing.Size(68, 22)
        Me.btoGrupo.TabIndex = 203
        Me.btoGrupo.TabStop = False
        Me.btoGrupo.Tag = ""
        Me.btoGrupo.Text = "<ALT+F3>"
        Me.btoGrupo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoGrupo.UseVisualStyleBackColor = False
        '
        'btoImpostos
        '
        Me.btoImpostos.BackColor = System.Drawing.Color.Transparent
        Me.btoImpostos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoImpostos.FlatAppearance.BorderSize = 0
        Me.btoImpostos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoImpostos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoImpostos.ForeColor = System.Drawing.Color.Black
        Me.btoImpostos.Image = Global.nascomercio.My.Resources.Resources.cifrao_peq
        Me.btoImpostos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoImpostos.Location = New System.Drawing.Point(527, 492)
        Me.btoImpostos.Name = "btoImpostos"
        Me.btoImpostos.Size = New System.Drawing.Size(140, 72)
        Me.btoImpostos.TabIndex = 29
        Me.btoImpostos.TabStop = False
        Me.btoImpostos.Text = "Impostos"
        Me.btoImpostos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoImpostos.UseVisualStyleBackColor = False
        '
        'fProdutoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(802, 569)
        Me.Controls.Add(Me.btoGrade)
        Me.Controls.Add(Me.btoEtiquetaES)
        Me.Controls.Add(Me.txtEstoqueTotal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btoEtiqueta)
        Me.Controls.Add(Me.lblExcluirItem)
        Me.Controls.Add(Me.btoExcluirItem)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btoIncluirItem)
        Me.Controls.Add(Me.lblReferencia)
        Me.Controls.Add(Me.lblFabricante)
        Me.Controls.Add(Me.cboFabricante)
        Me.Controls.Add(Me.lblFornecedor)
        Me.Controls.Add(Me.cboFornecedor)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.btoFiltro)
        Me.Controls.Add(Me.btoImpostos)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.lblNome)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fProdutoForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produtos"
        CType(Me.dgvProduto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents btoExcluir As System.Windows.Forms.Button
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents btoSalvar As System.Windows.Forms.Button
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents btoFiltro As System.Windows.Forms.Button
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblNome As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lblFornecedor As System.Windows.Forms.Label
    Friend WithEvents cboFornecedor As System.Windows.Forms.ComboBox
    Friend WithEvents lblFabricante As System.Windows.Forms.Label
    Friend WithEvents cboFabricante As System.Windows.Forms.ComboBox
    Friend WithEvents txtValorCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtValorVenda As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvProduto As System.Windows.Forms.DataGridView
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents lblReferencia As System.Windows.Forms.Label
    Friend WithEvents btoIncluirItem As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblExcluirItem As System.Windows.Forms.Label
    Friend WithEvents btoExcluirItem As System.Windows.Forms.Button
    Friend WithEvents lblSituacao As System.Windows.Forms.Label
    Friend WithEvents btoEtiqueta As System.Windows.Forms.Button
    Friend WithEvents txtEstoqueTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btoEtiquetaES As System.Windows.Forms.Button
    Friend WithEvents btoCadastro As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboCor As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtEstoqueMinimo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btoFornecedores As System.Windows.Forms.Button
    Friend WithEvents btoFabricantes As System.Windows.Forms.Button
    Friend WithEvents btoCor As System.Windows.Forms.Button
    Friend WithEvents btoGrade As System.Windows.Forms.Button
    Friend WithEvents btoNotaFiscal As System.Windows.Forms.Button
    Friend WithEvents txtAliquota As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNotaFiscalNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtNotaFiscalSerie As System.Windows.Forms.TextBox
    Friend WithEvents btoGrupo As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cboEfdUnidadeMedida As System.Windows.Forms.ComboBox
    Friend WithEvents btoNF As System.Windows.Forms.Button
    Friend WithEvents btoImpostos As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents btoCategoria As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
