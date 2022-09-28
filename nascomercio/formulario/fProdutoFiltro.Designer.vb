<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProdutoFiltro
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
        Me.lblReferencia = New System.Windows.Forms.Label
        Me.dgvProduto = New System.Windows.Forms.DataGridView
        Me.txtValorVenda = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtValorCompra = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblFabricante = New System.Windows.Forms.Label
        Me.cboFabricante = New System.Windows.Forms.ComboBox
        Me.lblFornecedor = New System.Windows.Forms.Label
        Me.cboFornecedor = New System.Windows.Forms.ComboBox
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.lblTipo = New System.Windows.Forms.Label
        Me.lblSubTitulo = New System.Windows.Forms.Label
        Me.cboTipo = New System.Windows.Forms.ComboBox
        Me.cboSituacao = New System.Windows.Forms.ComboBox
        Me.lblSituacao = New System.Windows.Forms.Label
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.lblNome = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.btoCadastro = New System.Windows.Forms.Button
        Me.btoPesquisar = New System.Windows.Forms.Button
        Me.btoSair = New System.Windows.Forms.Button
        Me.imgLogo = New System.Windows.Forms.PictureBox
        Me.txtReferencia = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtEstoqueMinimo = New System.Windows.Forms.MaskedTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboGrupo = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboCor = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.btoEtiquetaES = New System.Windows.Forms.Button
        Me.btoFabricantes = New System.Windows.Forms.Button
        Me.btoFornecedores = New System.Windows.Forms.Button
        Me.txtAliquota = New System.Windows.Forms.MaskedTextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btoNF = New System.Windows.Forms.Button
        CType(Me.dgvProduto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblReferencia
        '
        Me.lblReferencia.AutoSize = True
        Me.lblReferencia.BackColor = System.Drawing.Color.Transparent
        Me.lblReferencia.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblReferencia.Location = New System.Drawing.Point(352, 68)
        Me.lblReferencia.Name = "lblReferencia"
        Me.lblReferencia.Size = New System.Drawing.Size(86, 18)
        Me.lblReferencia.TabIndex = 183
        Me.lblReferencia.Text = "Referência"
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
        Me.dgvProduto.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvProduto.Location = New System.Drawing.Point(8, 292)
        Me.dgvProduto.Name = "dgvProduto"
        Me.dgvProduto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvProduto.RowHeadersVisible = False
        Me.dgvProduto.Size = New System.Drawing.Size(636, 64)
        Me.dgvProduto.TabIndex = 14
        '
        'txtValorVenda
        '
        Me.txtValorVenda.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorVenda.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorVenda.Location = New System.Drawing.Point(448, 184)
        Me.txtValorVenda.MaxLength = 9
        Me.txtValorVenda.Name = "txtValorVenda"
        Me.txtValorVenda.Size = New System.Drawing.Size(196, 18)
        Me.txtValorVenda.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(332, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 18)
        Me.Label3.TabIndex = 179
        Me.Label3.Text = "Vlr. Venda (R$)"
        '
        'txtValorCompra
        '
        Me.txtValorCompra.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorCompra.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorCompra.Location = New System.Drawing.Point(448, 152)
        Me.txtValorCompra.MaxLength = 9
        Me.txtValorCompra.Name = "txtValorCompra"
        Me.txtValorCompra.Size = New System.Drawing.Size(196, 18)
        Me.txtValorCompra.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(360, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 18)
        Me.Label2.TabIndex = 177
        Me.Label2.Text = "Custo (R$)"
        '
        'lblFabricante
        '
        Me.lblFabricante.AutoSize = True
        Me.lblFabricante.BackColor = System.Drawing.Color.Transparent
        Me.lblFabricante.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblFabricante.Location = New System.Drawing.Point(16, 152)
        Me.lblFabricante.Name = "lblFabricante"
        Me.lblFabricante.Size = New System.Drawing.Size(83, 18)
        Me.lblFabricante.TabIndex = 175
        Me.lblFabricante.Text = "Fabricante"
        '
        'cboFabricante
        '
        Me.cboFabricante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFabricante.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboFabricante.FormattingEnabled = True
        Me.cboFabricante.Location = New System.Drawing.Point(104, 148)
        Me.cboFabricante.Name = "cboFabricante"
        Me.cboFabricante.Size = New System.Drawing.Size(208, 26)
        Me.cboFabricante.TabIndex = 5
        '
        'lblFornecedor
        '
        Me.lblFornecedor.AutoSize = True
        Me.lblFornecedor.BackColor = System.Drawing.Color.Transparent
        Me.lblFornecedor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblFornecedor.Location = New System.Drawing.Point(8, 120)
        Me.lblFornecedor.Name = "lblFornecedor"
        Me.lblFornecedor.Size = New System.Drawing.Size(91, 18)
        Me.lblFornecedor.TabIndex = 173
        Me.lblFornecedor.Text = "Fornecedor"
        '
        'cboFornecedor
        '
        Me.cboFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFornecedor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboFornecedor.FormattingEnabled = True
        Me.cboFornecedor.Location = New System.Drawing.Point(104, 116)
        Me.cboFornecedor.Name = "cboFornecedor"
        Me.cboFornecedor.Size = New System.Drawing.Size(294, 26)
        Me.cboFornecedor.TabIndex = 4
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
        Me.lblTipo.Location = New System.Drawing.Point(60, 240)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(40, 18)
        Me.lblTipo.TabIndex = 170
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
        Me.lblSubTitulo.Size = New System.Drawing.Size(44, 14)
        Me.lblSubTitulo.TabIndex = 169
        Me.lblSubTitulo.Text = "FILTRO"
        '
        'cboTipo
        '
        Me.cboTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTipo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(104, 236)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(208, 26)
        Me.cboTipo.TabIndex = 8
        '
        'cboSituacao
        '
        Me.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboSituacao.FormattingEnabled = True
        Me.cboSituacao.Location = New System.Drawing.Point(448, 236)
        Me.cboSituacao.Name = "cboSituacao"
        Me.cboSituacao.Size = New System.Drawing.Size(196, 26)
        Me.cboSituacao.TabIndex = 13
        '
        'lblSituacao
        '
        Me.lblSituacao.AutoSize = True
        Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
        Me.lblSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblSituacao.Location = New System.Drawing.Point(372, 240)
        Me.lblSituacao.Name = "lblSituacao"
        Me.lblSituacao.Size = New System.Drawing.Size(69, 18)
        Me.lblSituacao.TabIndex = 167
        Me.lblSituacao.Text = "Situação"
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
        Me.lblTitulo.TabIndex = 166
        Me.lblTitulo.Text = "Produtos"
        '
        'lblNome
        '
        Me.lblNome.AutoSize = True
        Me.lblNome.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblNome.Location = New System.Drawing.Point(20, 92)
        Me.lblNome.Name = "lblNome"
        Me.lblNome.Size = New System.Drawing.Size(79, 18)
        Me.lblNome.TabIndex = 165
        Me.lblNome.Text = "Descrição"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblCodigo.Location = New System.Drawing.Point(40, 68)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(59, 18)
        Me.lblCodigo.TabIndex = 164
        Me.lblCodigo.Text = "Código"
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
        Me.btoCadastro.Location = New System.Drawing.Point(680, 84)
        Me.btoCadastro.Name = "btoCadastro"
        Me.btoCadastro.Size = New System.Drawing.Size(124, 72)
        Me.btoCadastro.TabIndex = 13
        Me.btoCadastro.TabStop = False
        Me.btoCadastro.Text = "Incluir <F5>"
        Me.btoCadastro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoCadastro.UseVisualStyleBackColor = False
        '
        'btoPesquisar
        '
        Me.btoPesquisar.BackColor = System.Drawing.Color.Transparent
        Me.btoPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoPesquisar.FlatAppearance.BorderSize = 0
        Me.btoPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoPesquisar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoPesquisar.ForeColor = System.Drawing.Color.Black
        Me.btoPesquisar.Image = Global.nascomercio.My.Resources.Resources.pesquisar
        Me.btoPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoPesquisar.Location = New System.Drawing.Point(332, 368)
        Me.btoPesquisar.Margin = New System.Windows.Forms.Padding(0)
        Me.btoPesquisar.Name = "btoPesquisar"
        Me.btoPesquisar.Size = New System.Drawing.Size(116, 72)
        Me.btoPesquisar.TabIndex = 11
        Me.btoPesquisar.TabStop = False
        Me.btoPesquisar.Text = "Pesquisar <Enter>"
        Me.btoPesquisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoPesquisar.UseVisualStyleBackColor = False
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
        Me.btoSair.Location = New System.Drawing.Point(680, 8)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(124, 72)
        Me.btoSair.TabIndex = 12
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.produtos
        Me.imgLogo.Location = New System.Drawing.Point(8, 8)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 168
        Me.imgLogo.TabStop = False
        '
        'txtReferencia
        '
        Me.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtReferencia.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferencia.Location = New System.Drawing.Point(444, 68)
        Me.txtReferencia.MaxLength = 20
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(200, 18)
        Me.txtReferencia.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(8, 268)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 18)
        Me.Label1.TabIndex = 184
        Me.Label1.Text = "Características"
        '
        'txtEstoqueMinimo
        '
        Me.txtEstoqueMinimo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEstoqueMinimo.Culture = New System.Globalization.CultureInfo("")
        Me.txtEstoqueMinimo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtEstoqueMinimo.Location = New System.Drawing.Point(104, 212)
        Me.txtEstoqueMinimo.Mask = "000000"
        Me.txtEstoqueMinimo.Name = "txtEstoqueMinimo"
        Me.txtEstoqueMinimo.Size = New System.Drawing.Size(88, 18)
        Me.txtEstoqueMinimo.TabIndex = 7
        Me.txtEstoqueMinimo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(8, 212)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 18)
        Me.Label7.TabIndex = 188
        Me.Label7.Text = "Est. Mínimo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(44, 184)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 18)
        Me.Label8.TabIndex = 187
        Me.Label8.Text = "Grupo"
        '
        'cboGrupo
        '
        Me.cboGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboGrupo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(104, 180)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(208, 26)
        Me.cboGrupo.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(404, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 18)
        Me.Label9.TabIndex = 190
        Me.Label9.Text = "Cor"
        '
        'cboCor
        '
        Me.cboCor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboCor.FormattingEnabled = True
        Me.cboCor.Location = New System.Drawing.Point(448, 116)
        Me.cboCor.Name = "cboCor"
        Me.cboCor.Size = New System.Drawing.Size(196, 26)
        Me.cboCor.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(372, 212)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 18)
        Me.Label10.TabIndex = 192
        Me.Label10.Text = "Aliquota"
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
        Me.btoEtiquetaES.Location = New System.Drawing.Point(680, 160)
        Me.btoEtiquetaES.Margin = New System.Windows.Forms.Padding(0)
        Me.btoEtiquetaES.Name = "btoEtiquetaES"
        Me.btoEtiquetaES.Size = New System.Drawing.Size(123, 72)
        Me.btoEtiquetaES.TabIndex = 194
        Me.btoEtiquetaES.TabStop = False
        Me.btoEtiquetaES.Text = "Etiquetas E/S <F6>"
        Me.btoEtiquetaES.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoEtiquetaES.UseVisualStyleBackColor = False
        '
        'btoFabricantes
        '
        Me.btoFabricantes.BackColor = System.Drawing.Color.Transparent
        Me.btoFabricantes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoFabricantes.FlatAppearance.BorderSize = 0
        Me.btoFabricantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoFabricantes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoFabricantes.ForeColor = System.Drawing.Color.Black
        Me.btoFabricantes.Image = Global.nascomercio.My.Resources.Resources.fabricantes
        Me.btoFabricantes.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoFabricantes.Location = New System.Drawing.Point(680, 312)
        Me.btoFabricantes.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFabricantes.Name = "btoFabricantes"
        Me.btoFabricantes.Size = New System.Drawing.Size(123, 72)
        Me.btoFabricantes.TabIndex = 196
        Me.btoFabricantes.TabStop = False
        Me.btoFabricantes.Text = "Fabricantes <F8>"
        Me.btoFabricantes.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFabricantes.UseVisualStyleBackColor = False
        '
        'btoFornecedores
        '
        Me.btoFornecedores.BackColor = System.Drawing.Color.Transparent
        Me.btoFornecedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoFornecedores.FlatAppearance.BorderSize = 0
        Me.btoFornecedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoFornecedores.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoFornecedores.ForeColor = System.Drawing.Color.Black
        Me.btoFornecedores.Image = Global.nascomercio.My.Resources.Resources.fornecedores
        Me.btoFornecedores.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoFornecedores.Location = New System.Drawing.Point(680, 236)
        Me.btoFornecedores.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFornecedores.Name = "btoFornecedores"
        Me.btoFornecedores.Size = New System.Drawing.Size(123, 72)
        Me.btoFornecedores.TabIndex = 195
        Me.btoFornecedores.TabStop = False
        Me.btoFornecedores.Text = "Fornecedores <F7>"
        Me.btoFornecedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFornecedores.UseVisualStyleBackColor = False
        '
        'txtAliquota
        '
        Me.txtAliquota.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAliquota.Culture = New System.Globalization.CultureInfo("")
        Me.txtAliquota.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtAliquota.Location = New System.Drawing.Point(448, 212)
        Me.txtAliquota.Mask = "00"
        Me.txtAliquota.Name = "txtAliquota"
        Me.txtAliquota.Size = New System.Drawing.Size(45, 18)
        Me.txtAliquota.TabIndex = 12
        Me.txtAliquota.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btoNF)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(809, 481)
        Me.Panel1.TabIndex = 198
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
        Me.btoNF.Location = New System.Drawing.Point(676, 383)
        Me.btoNF.Margin = New System.Windows.Forms.Padding(0)
        Me.btoNF.Name = "btoNF"
        Me.btoNF.Size = New System.Drawing.Size(123, 77)
        Me.btoNF.TabIndex = 199
        Me.btoNF.TabStop = False
        Me.btoNF.Text = "Nota Fiscal <F9>"
        Me.btoNF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoNF.UseVisualStyleBackColor = False
        '
        'fProdutoFiltro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(809, 482)
        Me.Controls.Add(Me.txtAliquota)
        Me.Controls.Add(Me.btoFabricantes)
        Me.Controls.Add(Me.btoFornecedores)
        Me.Controls.Add(Me.btoEtiquetaES)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboCor)
        Me.Controls.Add(Me.txtEstoqueMinimo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboGrupo)
        Me.Controls.Add(Me.txtReferencia)
        Me.Controls.Add(Me.btoCadastro)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btoPesquisar)
        Me.Controls.Add(Me.lblReferencia)
        Me.Controls.Add(Me.dgvProduto)
        Me.Controls.Add(Me.txtValorVenda)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtValorCompra)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblFabricante)
        Me.Controls.Add(Me.cboFabricante)
        Me.Controls.Add(Me.lblFornecedor)
        Me.Controls.Add(Me.cboFornecedor)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Me.cboSituacao)
        Me.Controls.Add(Me.lblSituacao)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.lblNome)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fProdutoFiltro"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produtos"
        CType(Me.dgvProduto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
  Friend WithEvents lblReferencia As System.Windows.Forms.Label
  Friend WithEvents dgvProduto As System.Windows.Forms.DataGridView
  Friend WithEvents txtValorVenda As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtValorCompra As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents lblFabricante As System.Windows.Forms.Label
  Friend WithEvents cboFabricante As System.Windows.Forms.ComboBox
  Friend WithEvents lblFornecedor As System.Windows.Forms.Label
  Friend WithEvents cboFornecedor As System.Windows.Forms.ComboBox
  Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
  Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
  Friend WithEvents lblTipo As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
  Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
  Friend WithEvents lblSituacao As System.Windows.Forms.Label
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents lblNome As System.Windows.Forms.Label
  Friend WithEvents lblCodigo As System.Windows.Forms.Label
  Friend WithEvents btoPesquisar As System.Windows.Forms.Button
  Friend WithEvents btoCadastro As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
  Friend WithEvents txtEstoqueMinimo As System.Windows.Forms.MaskedTextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents cboCor As System.Windows.Forms.ComboBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents btoEtiquetaES As System.Windows.Forms.Button
  Friend WithEvents btoFabricantes As System.Windows.Forms.Button
  Friend WithEvents btoFornecedores As System.Windows.Forms.Button
  Friend WithEvents txtAliquota As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btoNF As System.Windows.Forms.Button
End Class
