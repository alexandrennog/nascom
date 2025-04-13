<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fFornecedorFiltro
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
    Me.components = New System.ComponentModel.Container
    Me.cboEstado = New System.Windows.Forms.ComboBox
    Me.lblEstado = New System.Windows.Forms.Label
    Me.cboSituacao = New System.Windows.Forms.ComboBox
    Me.lblSituacao = New System.Windows.Forms.Label
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.lblCodigo = New System.Windows.Forms.Label
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.txtCodigo = New System.Windows.Forms.TextBox
    Me.txtNome = New System.Windows.Forms.TextBox
    Me.txtLogradouro = New System.Windows.Forms.TextBox
    Me.lblNumero = New System.Windows.Forms.Label
    Me.lblComplemento = New System.Windows.Forms.Label
    Me.txtBairro = New System.Windows.Forms.TextBox
    Me.lblBairro = New System.Windows.Forms.Label
    Me.lblCidade = New System.Windows.Forms.Label
    Me.lblCEP = New System.Windows.Forms.Label
    Me.lblCnpj = New System.Windows.Forms.Label
    Me.lblInscricaoEstadual = New System.Windows.Forms.Label
    Me.lblDDD = New System.Windows.Forms.Label
    Me.lblTelefone = New System.Windows.Forms.Label
    Me.lblRamal = New System.Windows.Forms.Label
    Me.txtContato = New System.Windows.Forms.TextBox
    Me.lblContato = New System.Windows.Forms.Label
    Me.btoCadastro = New System.Windows.Forms.Button
    Me.btoSair = New System.Windows.Forms.Button
    Me.btoPesquisar = New System.Windows.Forms.Button
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.txtRamal = New System.Windows.Forms.MaskedTextBox
    Me.txtInscricaoEstadual = New System.Windows.Forms.TextBox
    Me.lblNome = New System.Windows.Forms.Label
    Me.txtDDD = New System.Windows.Forms.MaskedTextBox
    Me.lblLogradouro = New System.Windows.Forms.Label
    Me.txtCep = New System.Windows.Forms.MaskedTextBox
    Me.txtComplemento = New System.Windows.Forms.TextBox
    Me.txtNumero = New System.Windows.Forms.MaskedTextBox
    Me.txtCnpj = New System.Windows.Forms.MaskedTextBox
    Me.btoProdutos = New System.Windows.Forms.Button
    Me.txtTelefone = New System.Windows.Forms.TextBox
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.cboMunicipio = New System.Windows.Forms.ComboBox
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'cboEstado
    '
    Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboEstado.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboEstado.FormattingEnabled = True
    Me.cboEstado.Location = New System.Drawing.Point(93, 216)
    Me.cboEstado.Name = "cboEstado"
    Me.cboEstado.Size = New System.Drawing.Size(161, 26)
    Me.cboEstado.TabIndex = 10
    '
    'lblEstado
    '
    Me.lblEstado.AutoSize = True
    Me.lblEstado.BackColor = System.Drawing.Color.Transparent
    Me.lblEstado.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblEstado.Location = New System.Drawing.Point(31, 219)
    Me.lblEstado.Name = "lblEstado"
    Me.lblEstado.Size = New System.Drawing.Size(57, 18)
    Me.lblEstado.TabIndex = 22
    Me.lblEstado.Text = "Estado"
    '
    'cboSituacao
    '
    Me.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboSituacao.FormattingEnabled = True
    Me.cboSituacao.Items.AddRange(New Object() {"Ativo", "Inativo"})
    Me.cboSituacao.Location = New System.Drawing.Point(92, 320)
    Me.cboSituacao.Name = "cboSituacao"
    Me.cboSituacao.Size = New System.Drawing.Size(100, 26)
    Me.cboSituacao.TabIndex = 16
    '
    'lblSituacao
    '
    Me.lblSituacao.AutoSize = True
    Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
    Me.lblSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblSituacao.Location = New System.Drawing.Point(16, 324)
    Me.lblSituacao.Name = "lblSituacao"
    Me.lblSituacao.Size = New System.Drawing.Size(69, 18)
    Me.lblSituacao.TabIndex = 20
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
    Me.lblTitulo.Size = New System.Drawing.Size(151, 24)
    Me.lblTitulo.TabIndex = 19
    Me.lblTitulo.Text = "Fornecedores"
    '
    'lblCodigo
    '
    Me.lblCodigo.AutoSize = True
    Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
    Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCodigo.Location = New System.Drawing.Point(28, 72)
    Me.lblCodigo.Name = "lblCodigo"
    Me.lblCodigo.Size = New System.Drawing.Size(59, 18)
    Me.lblCodigo.TabIndex = 14
    Me.lblCodigo.Text = "Código"
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
    Me.lblSubTitulo.TabIndex = 40
    Me.lblSubTitulo.Text = "FILTRO"
    '
    'txtCodigo
    '
    Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtCodigo.Location = New System.Drawing.Point(93, 72)
    Me.txtCodigo.MaxLength = 20
    Me.txtCodigo.Name = "txtCodigo"
    Me.txtCodigo.Size = New System.Drawing.Size(136, 18)
    Me.txtCodigo.TabIndex = 1
    '
    'txtNome
    '
    Me.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtNome.Location = New System.Drawing.Point(92, 96)
    Me.txtNome.MaxLength = 100
    Me.txtNome.Name = "txtNome"
    Me.txtNome.Size = New System.Drawing.Size(466, 18)
    Me.txtNome.TabIndex = 2
    '
    'txtLogradouro
    '
    Me.txtLogradouro.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtLogradouro.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtLogradouro.Location = New System.Drawing.Point(92, 144)
    Me.txtLogradouro.MaxLength = 100
    Me.txtLogradouro.Name = "txtLogradouro"
    Me.txtLogradouro.Size = New System.Drawing.Size(466, 18)
    Me.txtLogradouro.TabIndex = 5
    '
    'lblNumero
    '
    Me.lblNumero.AutoSize = True
    Me.lblNumero.BackColor = System.Drawing.Color.Transparent
    Me.lblNumero.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblNumero.Location = New System.Drawing.Point(24, 168)
    Me.lblNumero.Name = "lblNumero"
    Me.lblNumero.Size = New System.Drawing.Size(64, 18)
    Me.lblNumero.TabIndex = 48
    Me.lblNumero.Text = "Número"
    '
    'lblComplemento
    '
    Me.lblComplemento.AutoSize = True
    Me.lblComplemento.BackColor = System.Drawing.Color.Transparent
    Me.lblComplemento.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblComplemento.Location = New System.Drawing.Point(212, 168)
    Me.lblComplemento.Name = "lblComplemento"
    Me.lblComplemento.Size = New System.Drawing.Size(106, 18)
    Me.lblComplemento.TabIndex = 48
    Me.lblComplemento.Text = "Complemento"
    '
    'txtBairro
    '
    Me.txtBairro.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtBairro.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtBairro.Location = New System.Drawing.Point(92, 192)
    Me.txtBairro.MaxLength = 100
    Me.txtBairro.Name = "txtBairro"
    Me.txtBairro.Size = New System.Drawing.Size(376, 18)
    Me.txtBairro.TabIndex = 8
    '
    'lblBairro
    '
    Me.lblBairro.AutoSize = True
    Me.lblBairro.BackColor = System.Drawing.Color.Transparent
    Me.lblBairro.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblBairro.Location = New System.Drawing.Point(36, 192)
    Me.lblBairro.Name = "lblBairro"
    Me.lblBairro.Size = New System.Drawing.Size(52, 18)
    Me.lblBairro.TabIndex = 50
    Me.lblBairro.Text = "Bairro"
    '
    'lblCidade
    '
    Me.lblCidade.AutoSize = True
    Me.lblCidade.BackColor = System.Drawing.Color.Transparent
    Me.lblCidade.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCidade.Location = New System.Drawing.Point(260, 219)
    Me.lblCidade.Name = "lblCidade"
    Me.lblCidade.Size = New System.Drawing.Size(58, 18)
    Me.lblCidade.TabIndex = 52
    Me.lblCidade.Text = "Cidade"
    '
    'lblCEP
    '
    Me.lblCEP.AutoSize = True
    Me.lblCEP.BackColor = System.Drawing.Color.Transparent
    Me.lblCEP.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCEP.Location = New System.Drawing.Point(36, 248)
    Me.lblCEP.Name = "lblCEP"
    Me.lblCEP.Size = New System.Drawing.Size(49, 18)
    Me.lblCEP.TabIndex = 50
    Me.lblCEP.Text = "C.E.P."
    '
    'lblCnpj
    '
    Me.lblCnpj.AutoSize = True
    Me.lblCnpj.BackColor = System.Drawing.Color.Transparent
    Me.lblCnpj.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCnpj.Location = New System.Drawing.Point(24, 120)
    Me.lblCnpj.Name = "lblCnpj"
    Me.lblCnpj.Size = New System.Drawing.Size(62, 18)
    Me.lblCnpj.TabIndex = 48
    Me.lblCnpj.Text = "C.N.P.J."
    '
    'lblInscricaoEstadual
    '
    Me.lblInscricaoEstadual.AutoSize = True
    Me.lblInscricaoEstadual.BackColor = System.Drawing.Color.Transparent
    Me.lblInscricaoEstadual.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblInscricaoEstadual.Location = New System.Drawing.Point(280, 120)
    Me.lblInscricaoEstadual.Name = "lblInscricaoEstadual"
    Me.lblInscricaoEstadual.Size = New System.Drawing.Size(137, 18)
    Me.lblInscricaoEstadual.TabIndex = 50
    Me.lblInscricaoEstadual.Text = "Inscrição Estadual"
    '
    'lblDDD
    '
    Me.lblDDD.AutoSize = True
    Me.lblDDD.BackColor = System.Drawing.Color.Transparent
    Me.lblDDD.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblDDD.Location = New System.Drawing.Point(44, 272)
    Me.lblDDD.Name = "lblDDD"
    Me.lblDDD.Size = New System.Drawing.Size(41, 18)
    Me.lblDDD.TabIndex = 50
    Me.lblDDD.Text = "DDD"
    '
    'lblTelefone
    '
    Me.lblTelefone.AutoSize = True
    Me.lblTelefone.BackColor = System.Drawing.Color.Transparent
    Me.lblTelefone.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblTelefone.Location = New System.Drawing.Point(168, 272)
    Me.lblTelefone.Name = "lblTelefone"
    Me.lblTelefone.Size = New System.Drawing.Size(71, 18)
    Me.lblTelefone.TabIndex = 52
    Me.lblTelefone.Text = "Telefone"
    '
    'lblRamal
    '
    Me.lblRamal.AutoSize = True
    Me.lblRamal.BackColor = System.Drawing.Color.Transparent
    Me.lblRamal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblRamal.Location = New System.Drawing.Point(388, 272)
    Me.lblRamal.Name = "lblRamal"
    Me.lblRamal.Size = New System.Drawing.Size(51, 18)
    Me.lblRamal.TabIndex = 54
    Me.lblRamal.Text = "Ramal"
    '
    'txtContato
    '
    Me.txtContato.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtContato.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtContato.Location = New System.Drawing.Point(92, 296)
    Me.txtContato.MaxLength = 100
    Me.txtContato.Name = "txtContato"
    Me.txtContato.Size = New System.Drawing.Size(466, 18)
    Me.txtContato.TabIndex = 15
    '
    'lblContato
    '
    Me.lblContato.AutoSize = True
    Me.lblContato.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblContato.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblContato.Location = New System.Drawing.Point(24, 296)
    Me.lblContato.Name = "lblContato"
    Me.lblContato.Size = New System.Drawing.Size(64, 18)
    Me.lblContato.TabIndex = 47
    Me.lblContato.Text = "Contato"
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
    Me.btoCadastro.Location = New System.Drawing.Point(656, 84)
    Me.btoCadastro.Name = "btoCadastro"
    Me.btoCadastro.Size = New System.Drawing.Size(96, 72)
    Me.btoCadastro.TabIndex = 19
    Me.btoCadastro.TabStop = False
    Me.btoCadastro.Text = "Incluir <F5>"
    Me.btoCadastro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoCadastro, "Cadastro")
    Me.btoCadastro.UseVisualStyleBackColor = False
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
    Me.btoSair.Location = New System.Drawing.Point(656, 8)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(96, 72)
    Me.btoSair.TabIndex = 18
    Me.btoSair.TabStop = False
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoSair, "Sair")
    Me.btoSair.UseVisualStyleBackColor = False
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
    Me.btoPesquisar.Location = New System.Drawing.Point(288, 368)
    Me.btoPesquisar.Margin = New System.Windows.Forms.Padding(0)
    Me.btoPesquisar.Name = "btoPesquisar"
    Me.btoPesquisar.Size = New System.Drawing.Size(120, 72)
    Me.btoPesquisar.TabIndex = 17
    Me.btoPesquisar.TabStop = False
    Me.btoPesquisar.Text = "Pesquisar <Enter>"
    Me.btoPesquisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoPesquisar, "Pesquisar")
    Me.btoPesquisar.UseVisualStyleBackColor = False
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.fornecedores
    Me.imgLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 27
    Me.imgLogo.TabStop = False
    '
    'txtRamal
    '
    Me.txtRamal.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtRamal.Culture = New System.Globalization.CultureInfo("")
    Me.txtRamal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtRamal.Location = New System.Drawing.Point(444, 272)
    Me.txtRamal.Mask = "00000"
    Me.txtRamal.Name = "txtRamal"
    Me.txtRamal.Size = New System.Drawing.Size(80, 18)
    Me.txtRamal.TabIndex = 14
    Me.txtRamal.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'txtInscricaoEstadual
    '
    Me.txtInscricaoEstadual.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtInscricaoEstadual.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtInscricaoEstadual.Location = New System.Drawing.Point(420, 120)
    Me.txtInscricaoEstadual.MaxLength = 20
    Me.txtInscricaoEstadual.Name = "txtInscricaoEstadual"
    Me.txtInscricaoEstadual.Size = New System.Drawing.Size(196, 18)
    Me.txtInscricaoEstadual.TabIndex = 4
    '
    'lblNome
    '
    Me.lblNome.AutoSize = True
    Me.lblNome.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblNome.Location = New System.Drawing.Point(36, 96)
    Me.lblNome.Name = "lblNome"
    Me.lblNome.Size = New System.Drawing.Size(49, 18)
    Me.lblNome.TabIndex = 110
    Me.lblNome.Text = "Nome"
    '
    'txtDDD
    '
    Me.txtDDD.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDDD.Culture = New System.Globalization.CultureInfo("")
    Me.txtDDD.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtDDD.Location = New System.Drawing.Point(92, 272)
    Me.txtDDD.Mask = "000"
    Me.txtDDD.Name = "txtDDD"
    Me.txtDDD.Size = New System.Drawing.Size(56, 18)
    Me.txtDDD.TabIndex = 12
    Me.txtDDD.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'lblLogradouro
    '
    Me.lblLogradouro.AutoSize = True
    Me.lblLogradouro.BackColor = System.Drawing.Color.Transparent
    Me.lblLogradouro.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblLogradouro.Location = New System.Drawing.Point(8, 144)
    Me.lblLogradouro.Name = "lblLogradouro"
    Me.lblLogradouro.Size = New System.Drawing.Size(77, 18)
    Me.lblLogradouro.TabIndex = 111
    Me.lblLogradouro.Text = "Endereço"
    '
    'txtCep
    '
    Me.txtCep.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCep.Culture = New System.Globalization.CultureInfo("")
    Me.txtCep.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtCep.Location = New System.Drawing.Point(91, 247)
    Me.txtCep.Mask = "00000-000"
    Me.txtCep.Name = "txtCep"
    Me.txtCep.Size = New System.Drawing.Size(93, 18)
    Me.txtCep.TabIndex = 11
    Me.txtCep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'txtComplemento
    '
    Me.txtComplemento.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtComplemento.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtComplemento.Location = New System.Drawing.Point(324, 168)
    Me.txtComplemento.MaxLength = 100
    Me.txtComplemento.Name = "txtComplemento"
    Me.txtComplemento.Size = New System.Drawing.Size(296, 18)
    Me.txtComplemento.TabIndex = 7
    '
    'txtNumero
    '
    Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtNumero.Culture = New System.Globalization.CultureInfo("")
    Me.txtNumero.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtNumero.Location = New System.Drawing.Point(92, 168)
    Me.txtNumero.Mask = "000000"
    Me.txtNumero.Name = "txtNumero"
    Me.txtNumero.Size = New System.Drawing.Size(64, 18)
    Me.txtNumero.TabIndex = 6
    Me.txtNumero.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'txtCnpj
    '
    Me.txtCnpj.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCnpj.Culture = New System.Globalization.CultureInfo("")
    Me.txtCnpj.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtCnpj.Location = New System.Drawing.Point(92, 120)
    Me.txtCnpj.Mask = "00.000.000/0000-00"
    Me.txtCnpj.Name = "txtCnpj"
    Me.txtCnpj.Size = New System.Drawing.Size(164, 18)
    Me.txtCnpj.TabIndex = 3
    Me.txtCnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'btoProdutos
    '
    Me.btoProdutos.BackColor = System.Drawing.Color.Transparent
    Me.btoProdutos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoProdutos.FlatAppearance.BorderSize = 0
    Me.btoProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoProdutos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoProdutos.ForeColor = System.Drawing.Color.Black
    Me.btoProdutos.Image = Global.nascomercio.My.Resources.Resources.produtos
    Me.btoProdutos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoProdutos.Location = New System.Drawing.Point(653, 160)
    Me.btoProdutos.Margin = New System.Windows.Forms.Padding(0)
    Me.btoProdutos.Name = "btoProdutos"
    Me.btoProdutos.Size = New System.Drawing.Size(96, 72)
    Me.btoProdutos.TabIndex = 118
    Me.btoProdutos.TabStop = False
    Me.btoProdutos.Text = "Produtos <F6>"
    Me.btoProdutos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoProdutos.UseVisualStyleBackColor = False
    '
    'txtTelefone
    '
    Me.txtTelefone.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtTelefone.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtTelefone.Location = New System.Drawing.Point(246, 272)
    Me.txtTelefone.MaxLength = 100
    Me.txtTelefone.Name = "txtTelefone"
    Me.txtTelefone.Size = New System.Drawing.Size(121, 18)
    Me.txtTelefone.TabIndex = 13
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(758, 448)
    Me.Panel1.TabIndex = 120
    '
    'cboMunicipio
    '
    Me.cboMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboMunicipio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboMunicipio.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboMunicipio.FormattingEnabled = True
    Me.cboMunicipio.Location = New System.Drawing.Point(324, 216)
    Me.cboMunicipio.Name = "cboMunicipio"
    Me.cboMunicipio.Size = New System.Drawing.Size(296, 26)
    Me.cboMunicipio.TabIndex = 121
    '
    'fFornecedorFiltro
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(758, 448)
    Me.Controls.Add(Me.cboMunicipio)
    Me.Controls.Add(Me.txtCodigo)
    Me.Controls.Add(Me.txtTelefone)
    Me.Controls.Add(Me.btoProdutos)
    Me.Controls.Add(Me.txtRamal)
    Me.Controls.Add(Me.txtInscricaoEstadual)
    Me.Controls.Add(Me.lblNome)
    Me.Controls.Add(Me.txtDDD)
    Me.Controls.Add(Me.lblLogradouro)
    Me.Controls.Add(Me.txtCep)
    Me.Controls.Add(Me.txtComplemento)
    Me.Controls.Add(Me.txtNumero)
    Me.Controls.Add(Me.txtCnpj)
    Me.Controls.Add(Me.txtContato)
    Me.Controls.Add(Me.txtBairro)
    Me.Controls.Add(Me.txtLogradouro)
    Me.Controls.Add(Me.txtNome)
    Me.Controls.Add(Me.lblContato)
    Me.Controls.Add(Me.lblRamal)
    Me.Controls.Add(Me.lblTelefone)
    Me.Controls.Add(Me.lblDDD)
    Me.Controls.Add(Me.lblInscricaoEstadual)
    Me.Controls.Add(Me.lblCnpj)
    Me.Controls.Add(Me.lblCEP)
    Me.Controls.Add(Me.lblCidade)
    Me.Controls.Add(Me.lblBairro)
    Me.Controls.Add(Me.lblComplemento)
    Me.Controls.Add(Me.lblNumero)
    Me.Controls.Add(Me.btoCadastro)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.btoPesquisar)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.cboEstado)
    Me.Controls.Add(Me.lblEstado)
    Me.Controls.Add(Me.cboSituacao)
    Me.Controls.Add(Me.lblSituacao)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.lblCodigo)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fFornecedorFiltro"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Sistema - Fornecedores"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
  Friend WithEvents lblEstado As System.Windows.Forms.Label
  Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
  Friend WithEvents lblSituacao As System.Windows.Forms.Label
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents lblCodigo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents btoPesquisar As System.Windows.Forms.Button
  Friend WithEvents btoCadastro As System.Windows.Forms.Button
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
  Friend WithEvents txtNome As System.Windows.Forms.TextBox
  Friend WithEvents txtLogradouro As System.Windows.Forms.TextBox
  Friend WithEvents lblNumero As System.Windows.Forms.Label
  Friend WithEvents lblComplemento As System.Windows.Forms.Label
  Friend WithEvents txtBairro As System.Windows.Forms.TextBox
  Friend WithEvents lblBairro As System.Windows.Forms.Label
  Friend WithEvents lblCidade As System.Windows.Forms.Label
  Friend WithEvents lblCEP As System.Windows.Forms.Label
  Friend WithEvents lblCnpj As System.Windows.Forms.Label
  Friend WithEvents lblInscricaoEstadual As System.Windows.Forms.Label
  Friend WithEvents lblDDD As System.Windows.Forms.Label
  Friend WithEvents lblTelefone As System.Windows.Forms.Label
  Friend WithEvents lblRamal As System.Windows.Forms.Label
  Friend WithEvents txtContato As System.Windows.Forms.TextBox
    Friend WithEvents lblContato As System.Windows.Forms.Label
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents txtRamal As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtInscricaoEstadual As System.Windows.Forms.TextBox
  Friend WithEvents lblNome As System.Windows.Forms.Label
  Friend WithEvents txtDDD As System.Windows.Forms.MaskedTextBox
  Friend WithEvents lblLogradouro As System.Windows.Forms.Label
  Friend WithEvents txtCep As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtComplemento As System.Windows.Forms.TextBox
  Friend WithEvents txtNumero As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtCnpj As System.Windows.Forms.MaskedTextBox
  Friend WithEvents btoProdutos As System.Windows.Forms.Button
  Friend WithEvents txtTelefone As System.Windows.Forms.TextBox
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents cboMunicipio As System.Windows.Forms.ComboBox
End Class
