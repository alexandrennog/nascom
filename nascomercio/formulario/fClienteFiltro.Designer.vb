<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fClienteFiltro
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing AndAlso components IsNot Nothing Then
      components.Dispose()
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
        Me.lblCliSubTitulo = New System.Windows.Forms.Label()
        Me.lblCliCadastro = New System.Windows.Forms.Label()
        Me.imgCliLogo = New System.Windows.Forms.PictureBox()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.btoPesquisar = New System.Windows.Forms.Button()
        Me.btoCadastro = New System.Windows.Forms.Button()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSituacao = New System.Windows.Forms.ComboBox()
        Me.txtTelefone = New System.Windows.Forms.MaskedTextBox()
        Me.txtDDD = New System.Windows.Forms.MaskedTextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboSexo = New System.Windows.Forms.ComboBox()
        Me.cboEstadoCivil = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCarteiraProfissional = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtNomeMae = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNomePai = New System.Windows.Forms.TextBox()
        Me.txtRG = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNaturalidade = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtNacionalidade = New System.Windows.Forms.TextBox()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCPF = New System.Windows.Forms.MaskedTextBox()
        Me.txtDataNascimento = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtVeiculo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCliSubTitulo
        '
        Me.lblCliSubTitulo.AutoSize = True
        Me.lblCliSubTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblCliSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCliSubTitulo.Location = New System.Drawing.Point(85, 39)
        Me.lblCliSubTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCliSubTitulo.Name = "lblCliSubTitulo"
        Me.lblCliSubTitulo.Size = New System.Drawing.Size(56, 16)
        Me.lblCliSubTitulo.TabIndex = 169
        Me.lblCliSubTitulo.Text = "FILTRO"
        '
        'lblCliCadastro
        '
        Me.lblCliCadastro.AutoSize = True
        Me.lblCliCadastro.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblCliCadastro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCliCadastro.Location = New System.Drawing.Point(85, 10)
        Me.lblCliCadastro.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCliCadastro.Name = "lblCliCadastro"
        Me.lblCliCadastro.Size = New System.Drawing.Size(121, 32)
        Me.lblCliCadastro.TabIndex = 115
        Me.lblCliCadastro.Text = "Clientes"
        '
        'imgCliLogo
        '
        Me.imgCliLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgCliLogo.Image = Global.nascomercio.My.Resources.Resources.cliente
        Me.imgCliLogo.Location = New System.Drawing.Point(11, 10)
        Me.imgCliLogo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.imgCliLogo.Name = "imgCliLogo"
        Me.imgCliLogo.Size = New System.Drawing.Size(67, 62)
        Me.imgCliLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCliLogo.TabIndex = 155
        Me.imgCliLogo.TabStop = False
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
        Me.btoSair.Location = New System.Drawing.Point(928, 10)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(128, 89)
        Me.btoSair.TabIndex = 17
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
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
        Me.btoPesquisar.Location = New System.Drawing.Point(469, 453)
        Me.btoPesquisar.Margin = New System.Windows.Forms.Padding(0)
        Me.btoPesquisar.Name = "btoPesquisar"
        Me.btoPesquisar.Size = New System.Drawing.Size(155, 89)
        Me.btoPesquisar.TabIndex = 16
        Me.btoPesquisar.TabStop = False
        Me.btoPesquisar.Text = "Pesquisar <Enter>"
        Me.btoPesquisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoPesquisar.UseVisualStyleBackColor = False
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
        Me.btoCadastro.Location = New System.Drawing.Point(928, 103)
        Me.btoCadastro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btoCadastro.Name = "btoCadastro"
        Me.btoCadastro.Size = New System.Drawing.Size(128, 89)
        Me.btoCadastro.TabIndex = 18
        Me.btoCadastro.TabStop = False
        Me.btoCadastro.Text = "Cadastrar <F5>"
        Me.btoCadastro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoCadastro.UseVisualStyleBackColor = False
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEmail.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtEmail.Location = New System.Drawing.Point(160, 364)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(752, 22)
        Me.txtEmail.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(85, 364)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 22)
        Me.Label1.TabIndex = 202
        Me.Label1.Text = "E-Mail"
        '
        'cboSituacao
        '
        Me.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboSituacao.FormattingEnabled = True
        Me.cboSituacao.Location = New System.Drawing.Point(784, 394)
        Me.cboSituacao.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboSituacao.Name = "cboSituacao"
        Me.cboSituacao.Size = New System.Drawing.Size(128, 30)
        Me.cboSituacao.TabIndex = 15
        '
        'txtTelefone
        '
        Me.txtTelefone.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTelefone.Culture = New System.Globalization.CultureInfo("")
        Me.txtTelefone.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtTelefone.Location = New System.Drawing.Point(352, 399)
        Me.txtTelefone.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTelefone.Mask = "0000-0000"
        Me.txtTelefone.Name = "txtTelefone"
        Me.txtTelefone.Size = New System.Drawing.Size(128, 22)
        Me.txtTelefone.TabIndex = 14
        Me.txtTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtDDD
        '
        Me.txtDDD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDDD.Culture = New System.Globalization.CultureInfo("")
        Me.txtDDD.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDDD.Location = New System.Drawing.Point(160, 399)
        Me.txtDDD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDDD.Mask = "###"
        Me.txtDDD.Name = "txtDDD"
        Me.txtDDD.Size = New System.Drawing.Size(61, 22)
        Me.txtDDD.TabIndex = 13
        Me.txtDDD.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label26.Location = New System.Drawing.Point(251, 399)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(90, 22)
        Me.Label26.TabIndex = 197
        Me.Label26.Text = "Telefone"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label25.Location = New System.Drawing.Point(96, 399)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(52, 22)
        Me.Label25.TabIndex = 196
        Me.Label25.Text = "DDD"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(683, 399)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 22)
        Me.Label16.TabIndex = 195
        Me.Label16.Text = "Situação"
        '
        'cboSexo
        '
        Me.cboSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSexo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSexo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboSexo.FormattingEnabled = True
        Me.cboSexo.Location = New System.Drawing.Point(443, 207)
        Me.cboSexo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboSexo.Name = "cboSexo"
        Me.cboSexo.Size = New System.Drawing.Size(200, 30)
        Me.cboSexo.TabIndex = 6
        '
        'cboEstadoCivil
        '
        Me.cboEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstadoCivil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboEstadoCivil.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboEstadoCivil.FormattingEnabled = True
        Me.cboEstadoCivil.Location = New System.Drawing.Point(160, 207)
        Me.cboEstadoCivil.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboEstadoCivil.Name = "cboEstadoCivil"
        Me.cboEstadoCivil.Size = New System.Drawing.Size(183, 30)
        Me.cboEstadoCivil.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(379, 212)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 22)
        Me.Label8.TabIndex = 181
        Me.Label8.Text = "Sexo"
        '
        'txtCarteiraProfissional
        '
        Me.txtCarteiraProfissional.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCarteiraProfissional.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtCarteiraProfissional.Location = New System.Drawing.Point(160, 276)
        Me.txtCarteiraProfissional.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCarteiraProfissional.MaxLength = 30
        Me.txtCarteiraProfissional.Name = "txtCarteiraProfissional"
        Me.txtCarteiraProfissional.Size = New System.Drawing.Size(448, 22)
        Me.txtCarteiraProfissional.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(27, 212)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 22)
        Me.Label7.TabIndex = 180
        Me.Label7.Text = "Estado Civil"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(48, 276)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(103, 22)
        Me.Label15.TabIndex = 175
        Me.Label15.Text = "Cart. Prof."
        '
        'txtNomeMae
        '
        Me.txtNomeMae.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNomeMae.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtNomeMae.Location = New System.Drawing.Point(160, 305)
        Me.txtNomeMae.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNomeMae.MaxLength = 100
        Me.txtNomeMae.Name = "txtNomeMae"
        Me.txtNomeMae.Size = New System.Drawing.Size(752, 22)
        Me.txtNomeMae.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(16, 305)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(135, 22)
        Me.Label10.TabIndex = 183
        Me.Label10.Text = "Nome da Mãe"
        '
        'txtNomePai
        '
        Me.txtNomePai.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNomePai.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtNomePai.Location = New System.Drawing.Point(160, 335)
        Me.txtNomePai.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNomePai.MaxLength = 100
        Me.txtNomePai.Name = "txtNomePai"
        Me.txtNomePai.Size = New System.Drawing.Size(752, 22)
        Me.txtNomePai.TabIndex = 11
        '
        'txtRG
        '
        Me.txtRG.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRG.Culture = New System.Globalization.CultureInfo("")
        Me.txtRG.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtRG.Location = New System.Drawing.Point(443, 246)
        Me.txtRG.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRG.Name = "txtRG"
        Me.txtRG.Size = New System.Drawing.Size(200, 22)
        Me.txtRG.TabIndex = 8
        Me.txtRG.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(21, 335)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 22)
        Me.Label9.TabIndex = 182
        Me.Label9.Text = "Nome do Pai"
        '
        'txtNaturalidade
        '
        Me.txtNaturalidade.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNaturalidade.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtNaturalidade.Location = New System.Drawing.Point(160, 148)
        Me.txtNaturalidade.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNaturalidade.MaxLength = 100
        Me.txtNaturalidade.Name = "txtNaturalidade"
        Me.txtNaturalidade.Size = New System.Drawing.Size(448, 22)
        Me.txtNaturalidade.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(384, 246)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 22)
        Me.Label13.TabIndex = 173
        Me.Label13.Text = "R.G."
        '
        'txtNacionalidade
        '
        Me.txtNacionalidade.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNacionalidade.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtNacionalidade.Location = New System.Drawing.Point(160, 177)
        Me.txtNacionalidade.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNacionalidade.MaxLength = 100
        Me.txtNacionalidade.Name = "txtNacionalidade"
        Me.txtNacionalidade.Size = New System.Drawing.Size(448, 22)
        Me.txtNacionalidade.TabIndex = 4
        '
        'txtNome
        '
        Me.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtNome.Location = New System.Drawing.Point(160, 91)
        Me.txtNome.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNome.MaxLength = 100
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(752, 22)
        Me.txtNome.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(21, 148)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 22)
        Me.Label6.TabIndex = 179
        Me.Label6.Text = "Naturalidade"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(11, 177)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 22)
        Me.Label5.TabIndex = 178
        Me.Label5.Text = "Nacionalidade"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(85, 246)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 22)
        Me.Label14.TabIndex = 174
        Me.Label14.Text = "C.P.F."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(85, 89)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 22)
        Me.Label3.TabIndex = 176
        Me.Label3.Text = "Nome"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(43, 118)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 22)
        Me.Label4.TabIndex = 177
        Me.Label4.Text = "Data Nasc."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCPF
        '
        Me.txtCPF.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCPF.Culture = New System.Globalization.CultureInfo("")
        Me.txtCPF.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtCPF.Location = New System.Drawing.Point(160, 246)
        Me.txtCPF.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCPF.Mask = "000.000.000-00"
        Me.txtCPF.Name = "txtCPF"
        Me.txtCPF.Size = New System.Drawing.Size(181, 22)
        Me.txtCPF.TabIndex = 7
        Me.txtCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtDataNascimento
        '
        Me.txtDataNascimento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataNascimento.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataNascimento.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataNascimento.Location = New System.Drawing.Point(160, 118)
        Me.txtDataNascimento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDataNascimento.Mask = "00/00/0000"
        Me.txtDataNascimento.Name = "txtDataNascimento"
        Me.txtDataNascimento.Size = New System.Drawing.Size(113, 22)
        Me.txtDataNascimento.TabIndex = 2
        Me.txtDataNascimento.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtVeiculo)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtCodigo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1065, 547)
        Me.Panel1.TabIndex = 204
        '
        'txtVeiculo
        '
        Me.txtVeiculo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVeiculo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtVeiculo.Location = New System.Drawing.Point(157, 427)
        Me.txtVeiculo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtVeiculo.MaxLength = 100
        Me.txtVeiculo.Name = "txtVeiculo"
        Me.txtVeiculo.Size = New System.Drawing.Size(188, 22)
        Me.txtVeiculo.TabIndex = 179
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(69, 427)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 22)
        Me.Label11.TabIndex = 180
        Me.Label11.Text = "Veículo"
        '
        'txtCodigo
        '
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtCodigo.Location = New System.Drawing.Point(159, 62)
        Me.txtCodigo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCodigo.MaxLength = 10
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(121, 22)
        Me.txtCodigo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(73, 62)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 22)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "Código"
        '
        'fClienteFiltro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1065, 548)
        Me.Controls.Add(Me.txtDataNascimento)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboSituacao)
        Me.Controls.Add(Me.txtTelefone)
        Me.Controls.Add(Me.txtDDD)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cboSexo)
        Me.Controls.Add(Me.cboEstadoCivil)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCarteiraProfissional)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtNomeMae)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNomePai)
        Me.Controls.Add(Me.txtRG)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNaturalidade)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtNacionalidade)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCPF)
        Me.Controls.Add(Me.btoCadastro)
        Me.Controls.Add(Me.btoPesquisar)
        Me.Controls.Add(Me.lblCliSubTitulo)
        Me.Controls.Add(Me.imgCliLogo)
        Me.Controls.Add(Me.lblCliCadastro)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "fClienteFiltro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes"
        CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCliSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgCliLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblCliCadastro As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents btoPesquisar As System.Windows.Forms.Button
  Friend WithEvents btoCadastro As System.Windows.Forms.Button
  Friend WithEvents txtEmail As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
  Friend WithEvents txtTelefone As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtDDD As System.Windows.Forms.MaskedTextBox
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents cboSexo As System.Windows.Forms.ComboBox
  Friend WithEvents cboEstadoCivil As System.Windows.Forms.ComboBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents txtCarteiraProfissional As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents txtNomeMae As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents txtNomePai As System.Windows.Forms.TextBox
  Friend WithEvents txtRG As System.Windows.Forms.MaskedTextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents txtNaturalidade As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents txtNacionalidade As System.Windows.Forms.TextBox
  Friend WithEvents txtNome As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtCPF As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtDataNascimento As System.Windows.Forms.MaskedTextBox
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVeiculo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
