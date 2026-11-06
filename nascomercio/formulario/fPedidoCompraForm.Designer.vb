<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPedidoCompraForm
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
        Dim DataGridViewCellStyleEditavel As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyleValorEditavel As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyleValor As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btoSalvar = New System.Windows.Forms.Button()
        Me.btoCancelarPedido = New System.Windows.Forms.Button()
        Me.btoExcluir = New System.Windows.Forms.Button()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.lblFabricante = New System.Windows.Forms.Label()
        Me.cboFabricante = New System.Windows.Forms.ComboBox()
        Me.lblData = New System.Windows.Forms.Label()
        Me.txtData = New System.Windows.Forms.MaskedTextBox()
        Me.lblPrevisao = New System.Windows.Forms.Label()
        Me.txtPrevisao = New System.Windows.Forms.MaskedTextBox()
        Me.lblDesconto = New System.Windows.Forms.Label()
        Me.txtDescontoPerc = New System.Windows.Forms.TextBox()
        Me.lblDescontoValor = New System.Windows.Forms.Label()
        Me.txtDescontoValor = New System.Windows.Forms.TextBox()
        Me.lblSituacaoTitulo = New System.Windows.Forms.Label()
        Me.lblSituacaoValor = New System.Windows.Forms.Label()
        Me.lblObservacao = New System.Windows.Forms.Label()
        Me.txtObservacao = New System.Windows.Forms.TextBox()
        Me.lblProduto = New System.Windows.Forms.Label()
        Me.cboProduto = New System.Windows.Forms.ComboBox()
        Me.lblValorUnitario = New System.Windows.Forms.Label()
        Me.txtValorUnitario = New System.Windows.Forms.TextBox()
        Me.btoAdicionar = New System.Windows.Forms.Button()
        Me.dgvItens = New System.Windows.Forms.DataGridView()
        Me.cid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.produtos_cid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigoBarras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tamanho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Entregue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Falta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btoRemoverItem = New System.Windows.Forms.Button()
        Me.lblTotais = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblSubTitulo.Size = New System.Drawing.Size(70, 14)
        Me.lblSubTitulo.TabIndex = 0
        Me.lblSubTitulo.Text = "CADASTRO"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(64, 10)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(180, 24)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Pedido de Compra"
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
        Me.btoSalvar.Location = New System.Drawing.Point(636, 3)
        Me.btoSalvar.Margin = New System.Windows.Forms.Padding(0)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(84, 72)
        Me.btoSalvar.TabIndex = 3
        Me.btoSalvar.TabStop = False
        Me.btoSalvar.Text = "Salvar <F2>"
        Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btoSalvar.UseVisualStyleBackColor = False
        '
        'btoCancelarPedido
        '
        Me.btoCancelarPedido.BackColor = System.Drawing.Color.Transparent
        Me.btoCancelarPedido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoCancelarPedido.FlatAppearance.BorderSize = 0
        Me.btoCancelarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoCancelarPedido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoCancelarPedido.ForeColor = System.Drawing.Color.Black
        Me.btoCancelarPedido.Image = Global.nascomercio.My.Resources.Resources.icoCancelar
        Me.btoCancelarPedido.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoCancelarPedido.Location = New System.Drawing.Point(722, 3)
        Me.btoCancelarPedido.Margin = New System.Windows.Forms.Padding(0)
        Me.btoCancelarPedido.Name = "btoCancelarPedido"
        Me.btoCancelarPedido.Size = New System.Drawing.Size(92, 72)
        Me.btoCancelarPedido.TabIndex = 4
        Me.btoCancelarPedido.TabStop = False
        Me.btoCancelarPedido.Text = "Cancelar <F8>"
        Me.btoCancelarPedido.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoCancelarPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btoCancelarPedido.UseVisualStyleBackColor = False
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
        Me.btoExcluir.Location = New System.Drawing.Point(816, 3)
        Me.btoExcluir.Margin = New System.Windows.Forms.Padding(0)
        Me.btoExcluir.Name = "btoExcluir"
        Me.btoExcluir.Size = New System.Drawing.Size(92, 72)
        Me.btoExcluir.TabIndex = 5
        Me.btoExcluir.TabStop = False
        Me.btoExcluir.Text = "Excluir <F12>"
        Me.btoExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btoExcluir.UseVisualStyleBackColor = False
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
        Me.btoSair.Location = New System.Drawing.Point(910, 3)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(0)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(84, 72)
        Me.btoSair.TabIndex = 6
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Voltar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.BackColor = System.Drawing.Color.Transparent
        Me.lblNumero.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblNumero.Location = New System.Drawing.Point(8, 82)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(83, 18)
        Me.lblNumero.TabIndex = 7
        Me.lblNumero.Text = "Nº Pedido"
        '
        'txtNumero
        '
        Me.txtNumero.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtNumero.Location = New System.Drawing.Point(98, 79)
        Me.txtNumero.MaxLength = 30
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(120, 25)
        Me.txtNumero.TabIndex = 8
        '
        'lblFabricante
        '
        Me.lblFabricante.AutoSize = True
        Me.lblFabricante.BackColor = System.Drawing.Color.Transparent
        Me.lblFabricante.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblFabricante.Location = New System.Drawing.Point(230, 82)
        Me.lblFabricante.Name = "lblFabricante"
        Me.lblFabricante.Size = New System.Drawing.Size(86, 18)
        Me.lblFabricante.TabIndex = 9
        Me.lblFabricante.Text = "Fabricante"
        '
        'cboFabricante
        '
        Me.cboFabricante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFabricante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFabricante.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboFabricante.FormattingEnabled = True
        Me.cboFabricante.Location = New System.Drawing.Point(320, 78)
        Me.cboFabricante.Name = "cboFabricante"
        Me.cboFabricante.Size = New System.Drawing.Size(240, 26)
        Me.cboFabricante.TabIndex = 10
        '
        'lblData
        '
        Me.lblData.AutoSize = True
        Me.lblData.BackColor = System.Drawing.Color.Transparent
        Me.lblData.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblData.Location = New System.Drawing.Point(574, 82)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(42, 18)
        Me.lblData.TabIndex = 11
        Me.lblData.Text = "Data"
        '
        'txtData
        '
        Me.txtData.Culture = New System.Globalization.CultureInfo("")
        Me.txtData.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtData.Location = New System.Drawing.Point(620, 79)
        Me.txtData.Mask = "00/00/0000"
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(95, 25)
        Me.txtData.TabIndex = 12
        Me.txtData.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        '
        'lblPrevisao
        '
        Me.lblPrevisao.AutoSize = True
        Me.lblPrevisao.BackColor = System.Drawing.Color.Transparent
        Me.lblPrevisao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblPrevisao.Location = New System.Drawing.Point(728, 82)
        Me.lblPrevisao.Name = "lblPrevisao"
        Me.lblPrevisao.Size = New System.Drawing.Size(153, 18)
        Me.lblPrevisao.TabIndex = 13
        Me.lblPrevisao.Text = "Previsão de entrega"
        '
        'txtPrevisao
        '
        Me.txtPrevisao.Culture = New System.Globalization.CultureInfo("")
        Me.txtPrevisao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtPrevisao.Location = New System.Drawing.Point(886, 79)
        Me.txtPrevisao.Mask = "00/00/0000"
        Me.txtPrevisao.Name = "txtPrevisao"
        Me.txtPrevisao.Size = New System.Drawing.Size(106, 25)
        Me.txtPrevisao.TabIndex = 14
        Me.txtPrevisao.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        '
        'lblDesconto
        '
        Me.lblDesconto.AutoSize = True
        Me.lblDesconto.BackColor = System.Drawing.Color.Transparent
        Me.lblDesconto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblDesconto.Location = New System.Drawing.Point(8, 117)
        Me.lblDesconto.Name = "lblDesconto"
        Me.lblDesconto.Size = New System.Drawing.Size(97, 18)
        Me.lblDesconto.TabIndex = 15
        Me.lblDesconto.Text = "Desconto %"
        '
        'txtDescontoPerc
        '
        Me.txtDescontoPerc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDescontoPerc.Location = New System.Drawing.Point(108, 114)
        Me.txtDescontoPerc.Name = "txtDescontoPerc"
        Me.txtDescontoPerc.Size = New System.Drawing.Size(62, 25)
        Me.txtDescontoPerc.TabIndex = 16
        Me.txtDescontoPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescontoValor
        '
        Me.lblDescontoValor.AutoSize = True
        Me.lblDescontoValor.BackColor = System.Drawing.Color.Transparent
        Me.lblDescontoValor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblDescontoValor.Location = New System.Drawing.Point(176, 117)
        Me.lblDescontoValor.Name = "lblDescontoValor"
        Me.lblDescontoValor.Size = New System.Drawing.Size(42, 18)
        Me.lblDescontoValor.TabIndex = 17
        Me.lblDescontoValor.Text = "ou R$"
        '
        'txtDescontoValor
        '
        Me.txtDescontoValor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDescontoValor.Location = New System.Drawing.Point(226, 114)
        Me.txtDescontoValor.Name = "txtDescontoValor"
        Me.txtDescontoValor.Size = New System.Drawing.Size(100, 25)
        Me.txtDescontoValor.TabIndex = 18
        Me.txtDescontoValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSituacaoTitulo
        '
        Me.lblSituacaoTitulo.AutoSize = True
        Me.lblSituacaoTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSituacaoTitulo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblSituacaoTitulo.Location = New System.Drawing.Point(340, 117)
        Me.lblSituacaoTitulo.Name = "lblSituacaoTitulo"
        Me.lblSituacaoTitulo.Size = New System.Drawing.Size(77, 18)
        Me.lblSituacaoTitulo.TabIndex = 19
        Me.lblSituacaoTitulo.Text = "Situação:"
        '
        'lblSituacaoValor
        '
        Me.lblSituacaoValor.AutoSize = True
        Me.lblSituacaoValor.BackColor = System.Drawing.Color.Transparent
        Me.lblSituacaoValor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblSituacaoValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSituacaoValor.Location = New System.Drawing.Point(420, 117)
        Me.lblSituacaoValor.Name = "lblSituacaoValor"
        Me.lblSituacaoValor.Size = New System.Drawing.Size(44, 18)
        Me.lblSituacaoValor.TabIndex = 20
        Me.lblSituacaoValor.Text = "Novo"
        '
        'lblObservacao
        '
        Me.lblObservacao.AutoSize = True
        Me.lblObservacao.BackColor = System.Drawing.Color.Transparent
        Me.lblObservacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblObservacao.Location = New System.Drawing.Point(574, 117)
        Me.lblObservacao.Name = "lblObservacao"
        Me.lblObservacao.Size = New System.Drawing.Size(40, 18)
        Me.lblObservacao.TabIndex = 21
        Me.lblObservacao.Text = "Obs."
        '
        'txtObservacao
        '
        Me.txtObservacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtObservacao.Location = New System.Drawing.Point(620, 114)
        Me.txtObservacao.MaxLength = 500
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(372, 25)
        Me.txtObservacao.TabIndex = 22
        '
        'lblProduto
        '
        Me.lblProduto.AutoSize = True
        Me.lblProduto.BackColor = System.Drawing.Color.Transparent
        Me.lblProduto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblProduto.Location = New System.Drawing.Point(8, 155)
        Me.lblProduto.Name = "lblProduto"
        Me.lblProduto.Size = New System.Drawing.Size(66, 18)
        Me.lblProduto.TabIndex = 23
        Me.lblProduto.Text = "Produto"
        '
        'cboProduto
        '
        Me.cboProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboProduto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboProduto.FormattingEnabled = True
        Me.cboProduto.Location = New System.Drawing.Point(98, 151)
        Me.cboProduto.MaxDropDownItems = 20
        Me.cboProduto.Name = "cboProduto"
        Me.cboProduto.Size = New System.Drawing.Size(462, 26)
        Me.cboProduto.TabIndex = 24
        '
        'lblValorUnitario
        '
        Me.lblValorUnitario.AutoSize = True
        Me.lblValorUnitario.BackColor = System.Drawing.Color.Transparent
        Me.lblValorUnitario.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblValorUnitario.Location = New System.Drawing.Point(574, 155)
        Me.lblValorUnitario.Name = "lblValorUnitario"
        Me.lblValorUnitario.Size = New System.Drawing.Size(102, 18)
        Me.lblValorUnitario.TabIndex = 25
        Me.lblValorUnitario.Text = "Valor par R$"
        '
        'txtValorUnitario
        '
        Me.txtValorUnitario.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtValorUnitario.Location = New System.Drawing.Point(680, 152)
        Me.txtValorUnitario.Name = "txtValorUnitario"
        Me.txtValorUnitario.Size = New System.Drawing.Size(90, 25)
        Me.txtValorUnitario.TabIndex = 26
        Me.txtValorUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btoAdicionar
        '
        Me.btoAdicionar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btoAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btoAdicionar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btoAdicionar.ForeColor = System.Drawing.Color.Black
        Me.btoAdicionar.Location = New System.Drawing.Point(782, 149)
        Me.btoAdicionar.Name = "btoAdicionar"
        Me.btoAdicionar.Size = New System.Drawing.Size(210, 30)
        Me.btoAdicionar.TabIndex = 27
        Me.btoAdicionar.Text = "Adicionar grade <F3>"
        Me.btoAdicionar.UseVisualStyleBackColor = False
        '
        'dgvItens
        '
        Me.dgvItens.AllowUserToAddRows = False
        Me.dgvItens.AllowUserToDeleteRows = False
        Me.dgvItens.AllowUserToResizeRows = False
        Me.dgvItens.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvItens.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvItens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItens.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cid, Me.produtos_cid, Me.codigoBarras, Me.Referencia, Me.Descricao, Me.Cor, Me.Tamanho, Me.Quantidade, Me.ValorUnitario, Me.Total, Me.Entregue, Me.Falta})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItens.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvItens.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgvItens.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvItens.Location = New System.Drawing.Point(8, 188)
        Me.dgvItens.MultiSelect = False
        Me.dgvItens.Name = "dgvItens"
        Me.dgvItens.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvItens.RowHeadersVisible = False
        Me.dgvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvItens.Size = New System.Drawing.Size(984, 336)
        Me.dgvItens.TabIndex = 28
        '
        DataGridViewCellStyleNumero.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyleNumero.Format = "N0"
        DataGridViewCellStyleEditavel.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyleEditavel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer))
        DataGridViewCellStyleEditavel.Format = "N0"
        DataGridViewCellStyleValorEditavel.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyleValorEditavel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer))
        DataGridViewCellStyleValorEditavel.Format = "N2"
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
        'produtos_cid
        '
        Me.produtos_cid.HeaderText = "Produto"
        Me.produtos_cid.Name = "produtos_cid"
        Me.produtos_cid.ReadOnly = True
        Me.produtos_cid.Visible = False
        '
        'codigoBarras
        '
        Me.codigoBarras.HeaderText = "Cód. Barras"
        Me.codigoBarras.Name = "codigoBarras"
        Me.codigoBarras.ReadOnly = True
        Me.codigoBarras.Visible = False
        '
        'Referencia
        '
        Me.Referencia.HeaderText = "Referência"
        Me.Referencia.Name = "Referencia"
        Me.Referencia.ReadOnly = True
        Me.Referencia.Width = 100
        '
        'Descricao
        '
        Me.Descricao.HeaderText = "Descrição"
        Me.Descricao.Name = "Descricao"
        Me.Descricao.ReadOnly = True
        Me.Descricao.Width = 230
        '
        'Cor
        '
        Me.Cor.HeaderText = "Cor"
        Me.Cor.Name = "Cor"
        Me.Cor.ReadOnly = True
        Me.Cor.Width = 110
        '
        'Tamanho
        '
        Me.Tamanho.HeaderText = "Tam."
        Me.Tamanho.Name = "Tamanho"
        Me.Tamanho.ReadOnly = True
        Me.Tamanho.Width = 60
        '
        'Quantidade
        '
        Me.Quantidade.DefaultCellStyle = DataGridViewCellStyleEditavel
        Me.Quantidade.HeaderText = "Pares"
        Me.Quantidade.Name = "Quantidade"
        Me.Quantidade.Width = 75
        '
        'ValorUnitario
        '
        Me.ValorUnitario.DefaultCellStyle = DataGridViewCellStyleValorEditavel
        Me.ValorUnitario.HeaderText = "Valor par"
        Me.ValorUnitario.Name = "ValorUnitario"
        Me.ValorUnitario.Width = 95
        '
        'Total
        '
        Me.Total.DefaultCellStyle = DataGridViewCellStyleValor
        Me.Total.HeaderText = "Total bruto"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Width = 110
        '
        'Entregue
        '
        Me.Entregue.DefaultCellStyle = DataGridViewCellStyleNumero
        Me.Entregue.HeaderText = "Entregue"
        Me.Entregue.Name = "Entregue"
        Me.Entregue.ReadOnly = True
        Me.Entregue.Width = 80
        '
        'Falta
        '
        Me.Falta.DefaultCellStyle = DataGridViewCellStyleNumero
        Me.Falta.HeaderText = "Falta"
        Me.Falta.Name = "Falta"
        Me.Falta.ReadOnly = True
        Me.Falta.Width = 70
        '
        'btoRemoverItem
        '
        Me.btoRemoverItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btoRemoverItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btoRemoverItem.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btoRemoverItem.ForeColor = System.Drawing.Color.Black
        Me.btoRemoverItem.Location = New System.Drawing.Point(8, 534)
        Me.btoRemoverItem.Name = "btoRemoverItem"
        Me.btoRemoverItem.Size = New System.Drawing.Size(160, 30)
        Me.btoRemoverItem.TabIndex = 29
        Me.btoRemoverItem.Text = "Remover item <Del>"
        Me.btoRemoverItem.UseVisualStyleBackColor = False
        '
        'lblTotais
        '
        Me.lblTotais.BackColor = System.Drawing.Color.Transparent
        Me.lblTotais.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblTotais.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotais.Location = New System.Drawing.Point(180, 530)
        Me.lblTotais.Name = "lblTotais"
        Me.lblTotais.Size = New System.Drawing.Size(812, 64)
        Me.lblTotais.TabIndex = 30
        Me.lblTotais.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 600)
        Me.Panel1.TabIndex = 31
        '
        'fPedidoCompraForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1000, 600)
        Me.Controls.Add(Me.lblTotais)
        Me.Controls.Add(Me.btoRemoverItem)
        Me.Controls.Add(Me.dgvItens)
        Me.Controls.Add(Me.btoAdicionar)
        Me.Controls.Add(Me.txtValorUnitario)
        Me.Controls.Add(Me.lblValorUnitario)
        Me.Controls.Add(Me.cboProduto)
        Me.Controls.Add(Me.lblProduto)
        Me.Controls.Add(Me.txtObservacao)
        Me.Controls.Add(Me.lblObservacao)
        Me.Controls.Add(Me.lblSituacaoValor)
        Me.Controls.Add(Me.lblSituacaoTitulo)
        Me.Controls.Add(Me.txtDescontoValor)
        Me.Controls.Add(Me.lblDescontoValor)
        Me.Controls.Add(Me.txtDescontoPerc)
        Me.Controls.Add(Me.lblDesconto)
        Me.Controls.Add(Me.txtPrevisao)
        Me.Controls.Add(Me.lblPrevisao)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.lblData)
        Me.Controls.Add(Me.cboFabricante)
        Me.Controls.Add(Me.lblFabricante)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.lblNumero)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.btoExcluir)
        Me.Controls.Add(Me.btoCancelarPedido)
        Me.Controls.Add(Me.btoSalvar)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fPedidoCompraForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fPedidoCompraForm"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btoSalvar As System.Windows.Forms.Button
    Friend WithEvents btoCancelarPedido As System.Windows.Forms.Button
    Friend WithEvents btoExcluir As System.Windows.Forms.Button
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents lblFabricante As System.Windows.Forms.Label
    Friend WithEvents cboFabricante As System.Windows.Forms.ComboBox
    Friend WithEvents lblData As System.Windows.Forms.Label
    Friend WithEvents txtData As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblPrevisao As System.Windows.Forms.Label
    Friend WithEvents txtPrevisao As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDesconto As System.Windows.Forms.Label
    Friend WithEvents txtDescontoPerc As System.Windows.Forms.TextBox
    Friend WithEvents lblDescontoValor As System.Windows.Forms.Label
    Friend WithEvents txtDescontoValor As System.Windows.Forms.TextBox
    Friend WithEvents lblSituacaoTitulo As System.Windows.Forms.Label
    Friend WithEvents lblSituacaoValor As System.Windows.Forms.Label
    Friend WithEvents lblObservacao As System.Windows.Forms.Label
    Friend WithEvents txtObservacao As System.Windows.Forms.TextBox
    Friend WithEvents lblProduto As System.Windows.Forms.Label
    Friend WithEvents cboProduto As System.Windows.Forms.ComboBox
    Friend WithEvents lblValorUnitario As System.Windows.Forms.Label
    Friend WithEvents txtValorUnitario As System.Windows.Forms.TextBox
    Friend WithEvents btoAdicionar As System.Windows.Forms.Button
    Friend WithEvents dgvItens As System.Windows.Forms.DataGridView
    Friend WithEvents cid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents produtos_cid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigoBarras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Referencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tamanho As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Entregue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Falta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btoRemoverItem As System.Windows.Forms.Button
    Friend WithEvents lblTotais As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
