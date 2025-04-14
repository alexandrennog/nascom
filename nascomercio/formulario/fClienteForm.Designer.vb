<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fClienteForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblCliCadastro = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCPF = New System.Windows.Forms.MaskedTextBox()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.txtNacionalidade = New System.Windows.Forms.TextBox()
        Me.txtNaturalidade = New System.Windows.Forms.TextBox()
        Me.txtRG = New System.Windows.Forms.MaskedTextBox()
        Me.txtOrgaoEmissor = New System.Windows.Forms.TextBox()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.txtNomePai = New System.Windows.Forms.TextBox()
        Me.txtNomeMae = New System.Windows.Forms.TextBox()
        Me.txtCarteiraProfissional = New System.Windows.Forms.TextBox()
        Me.cboEstadoCivil = New System.Windows.Forms.ComboBox()
        Me.cboSexo = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtDDD = New System.Windows.Forms.MaskedTextBox()
        Me.txtTelefone = New System.Windows.Forms.MaskedTextBox()
        Me.lblCliSubTitulo = New System.Windows.Forms.Label()
        Me.cboSituacao = New System.Windows.Forms.ComboBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDataNascimento = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btoCamera = New System.Windows.Forms.Button()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnLoadImage = New System.Windows.Forms.Button()
        Me.btoContrato = New System.Windows.Forms.Button()
        Me.btoVeiculos = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtDddCelular = New System.Windows.Forms.MaskedTextBox()
        Me.txtCelular = New System.Windows.Forms.MaskedTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btoVendas = New System.Windows.Forms.Button()
        Me.btoCheques = New System.Windows.Forms.Button()
        Me.btoSalvar = New System.Windows.Forms.Button()
        Me.btoExcluir = New System.Windows.Forms.Button()
        Me.btoCrediario = New System.Windows.Forms.Button()
        Me.btoFinanceiro = New System.Windows.Forms.Button()
        Me.btoProfissional = New System.Windows.Forms.Button()
        Me.btoEndereco = New System.Windows.Forms.Button()
        Me.picImagem = New System.Windows.Forms.PictureBox()
        Me.btoFiltro = New System.Windows.Forms.Button()
        Me.imgCliLogo = New System.Windows.Forms.PictureBox()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.picImagem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCliCadastro
        '
        Me.lblCliCadastro.AutoSize = True
        Me.lblCliCadastro.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblCliCadastro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCliCadastro.Location = New System.Drawing.Point(64, 8)
        Me.lblCliCadastro.Name = "lblCliCadastro"
        Me.lblCliCadastro.Size = New System.Drawing.Size(121, 32)
        Me.lblCliCadastro.TabIndex = 50
        Me.lblCliCadastro.Text = "Clientes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(371, 440)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 19)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Data Nasc."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 19)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Nacionalidade"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 19)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Naturalidade"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(279, 173)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 22)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Sexo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(0, 304)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 19)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "Nome da Mãe"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(628, 741)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 22)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "Situação"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(23, 280)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 19)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Cart. Prof."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(70, 226)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 19)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "R.G."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(61, 201)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 19)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "C.P.F."
        '
        'txtCPF
        '
        Me.txtCPF.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCPF.Culture = New System.Globalization.CultureInfo("")
        Me.txtCPF.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtCPF.Location = New System.Drawing.Point(125, 201)
        Me.txtCPF.Mask = "000.000.000-00"
        Me.txtCPF.Name = "txtCPF"
        Me.txtCPF.Size = New System.Drawing.Size(136, 22)
        Me.txtCPF.TabIndex = 6
        Me.txtCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtNome
        '
        Me.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtNome.Location = New System.Drawing.Point(125, 94)
        Me.txtNome.MaxLength = 100
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(564, 22)
        Me.txtNome.TabIndex = 1
        '
        'txtNacionalidade
        '
        Me.txtNacionalidade.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNacionalidade.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtNacionalidade.Location = New System.Drawing.Point(125, 142)
        Me.txtNacionalidade.MaxLength = 100
        Me.txtNacionalidade.Name = "txtNacionalidade"
        Me.txtNacionalidade.Size = New System.Drawing.Size(336, 22)
        Me.txtNacionalidade.TabIndex = 3
        '
        'txtNaturalidade
        '
        Me.txtNaturalidade.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNaturalidade.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtNaturalidade.Location = New System.Drawing.Point(125, 118)
        Me.txtNaturalidade.MaxLength = 100
        Me.txtNaturalidade.Name = "txtNaturalidade"
        Me.txtNaturalidade.Size = New System.Drawing.Size(338, 22)
        Me.txtNaturalidade.TabIndex = 2
        '
        'txtRG
        '
        Me.txtRG.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRG.Culture = New System.Globalization.CultureInfo("")
        Me.txtRG.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtRG.Location = New System.Drawing.Point(125, 224)
        Me.txtRG.Name = "txtRG"
        Me.txtRG.Size = New System.Drawing.Size(200, 22)
        Me.txtRG.TabIndex = 7
        Me.txtRG.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtOrgaoEmissor
        '
        Me.txtOrgaoEmissor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOrgaoEmissor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtOrgaoEmissor.Location = New System.Drawing.Point(125, 248)
        Me.txtOrgaoEmissor.MaxLength = 10
        Me.txtOrgaoEmissor.Name = "txtOrgaoEmissor"
        Me.txtOrgaoEmissor.Size = New System.Drawing.Size(56, 22)
        Me.txtOrgaoEmissor.TabIndex = 8
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(379, 214)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(77, 30)
        Me.cboEstado.TabIndex = 9
        '
        'txtNomePai
        '
        Me.txtNomePai.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNomePai.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtNomePai.Location = New System.Drawing.Point(125, 332)
        Me.txtNomePai.MaxLength = 100
        Me.txtNomePai.Name = "txtNomePai"
        Me.txtNomePai.Size = New System.Drawing.Size(340, 22)
        Me.txtNomePai.TabIndex = 12
        '
        'txtNomeMae
        '
        Me.txtNomeMae.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNomeMae.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtNomeMae.Location = New System.Drawing.Point(125, 304)
        Me.txtNomeMae.MaxLength = 100
        Me.txtNomeMae.Name = "txtNomeMae"
        Me.txtNomeMae.Size = New System.Drawing.Size(338, 22)
        Me.txtNomeMae.TabIndex = 11
        '
        'txtCarteiraProfissional
        '
        Me.txtCarteiraProfissional.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCarteiraProfissional.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtCarteiraProfissional.Location = New System.Drawing.Point(125, 276)
        Me.txtCarteiraProfissional.MaxLength = 30
        Me.txtCarteiraProfissional.Name = "txtCarteiraProfissional"
        Me.txtCarteiraProfissional.Size = New System.Drawing.Size(348, 22)
        Me.txtCarteiraProfissional.TabIndex = 10
        '
        'cboEstadoCivil
        '
        Me.cboEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstadoCivil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboEstadoCivil.FormattingEnabled = True
        Me.cboEstadoCivil.Location = New System.Drawing.Point(125, 169)
        Me.cboEstadoCivil.Name = "cboEstadoCivil"
        Me.cboEstadoCivil.Size = New System.Drawing.Size(136, 30)
        Me.cboEstadoCivil.TabIndex = 4
        '
        'cboSexo
        '
        Me.cboSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSexo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSexo.FormattingEnabled = True
        Me.cboSexo.Location = New System.Drawing.Point(340, 169)
        Me.cboSexo.Name = "cboSexo"
        Me.cboSexo.Size = New System.Drawing.Size(123, 30)
        Me.cboSexo.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(384, 407)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(77, 19)
        Me.Label16.TabIndex = 77
        Me.Label16.Text = "Situação"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(173, 404)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(74, 19)
        Me.Label26.TabIndex = 87
        Me.Label26.Text = "Telefone"
        '
        'txtDDD
        '
        Me.txtDDD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDDD.Culture = New System.Globalization.CultureInfo("")
        Me.txtDDD.Location = New System.Drawing.Point(111, 404)
        Me.txtDDD.Mask = "000"
        Me.txtDDD.Name = "txtDDD"
        Me.txtDDD.Size = New System.Drawing.Size(46, 22)
        Me.txtDDD.TabIndex = 14
        Me.txtDDD.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtTelefone
        '
        Me.txtTelefone.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTelefone.Culture = New System.Globalization.CultureInfo("")
        Me.txtTelefone.Location = New System.Drawing.Point(255, 404)
        Me.txtTelefone.Mask = "0000-0000"
        Me.txtTelefone.Name = "txtTelefone"
        Me.txtTelefone.Size = New System.Drawing.Size(96, 22)
        Me.txtTelefone.TabIndex = 15
        Me.txtTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'lblCliSubTitulo
        '
        Me.lblCliSubTitulo.AutoSize = True
        Me.lblCliSubTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblCliSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCliSubTitulo.Location = New System.Drawing.Point(64, 32)
        Me.lblCliSubTitulo.Name = "lblCliSubTitulo"
        Me.lblCliSubTitulo.Size = New System.Drawing.Size(83, 16)
        Me.lblCliSubTitulo.TabIndex = 107
        Me.lblCliSubTitulo.Text = "CADASTRO"
        '
        'cboSituacao
        '
        Me.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSituacao.FormattingEnabled = True
        Me.cboSituacao.Location = New System.Drawing.Point(467, 404)
        Me.cboSituacao.Name = "cboSituacao"
        Me.cboSituacao.Size = New System.Drawing.Size(97, 30)
        Me.cboSituacao.TabIndex = 19
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEmail.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtEmail.Location = New System.Drawing.Point(125, 360)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(340, 22)
        Me.txtEmail.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 356)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 19)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "E-Mail"
        '
        'txtDataNascimento
        '
        Me.txtDataNascimento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataNascimento.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataNascimento.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataNascimento.Location = New System.Drawing.Point(471, 440)
        Me.txtDataNascimento.Mask = "00/00/0000"
        Me.txtDataNascimento.Name = "txtDataNascimento"
        Me.txtDataNascimento.Size = New System.Drawing.Size(93, 22)
        Me.txtDataNascimento.TabIndex = 18
        Me.txtDataNascimento.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(60, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 19)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Nome"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 173)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 19)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "Estado Civil"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(57, 404)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(45, 19)
        Me.Label25.TabIndex = 121
        Me.Label25.Text = "DDD"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 332)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 19)
        Me.Label9.TabIndex = 120
        Me.Label9.Text = "Nome do Pai"
        '
        'btoCamera
        '
        Me.btoCamera.BackColor = System.Drawing.Color.Transparent
        Me.btoCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoCamera.FlatAppearance.BorderSize = 0
        Me.btoCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoCamera.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoCamera.ForeColor = System.Drawing.Color.Black
        Me.btoCamera.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoCamera.Location = New System.Drawing.Point(475, 325)
        Me.btoCamera.Name = "btoCamera"
        Me.btoCamera.Size = New System.Drawing.Size(96, 20)
        Me.btoCamera.TabIndex = 122
        Me.btoCamera.TabStop = False
        Me.btoCamera.Text = "Camera <F1>"
        Me.btoCamera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoCamera.UseVisualStyleBackColor = False
        '
        'txtCodigo
        '
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtCodigo.Location = New System.Drawing.Point(125, 67)
        Me.txtCodigo.MaxLength = 100
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(91, 22)
        Me.txtCodigo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(49, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 19)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "Código"
        '
        'Panel1
        '
        Me.Panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtCodigo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnLoadImage)
        Me.Panel1.Controls.Add(Me.btoContrato)
        Me.Panel1.Controls.Add(Me.txtDataNascimento)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.btoCamera)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.cboSexo)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.cboEstadoCivil)
        Me.Panel1.Controls.Add(Me.txtEmail)
        Me.Panel1.Controls.Add(Me.btoVeiculos)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.txtDddCelular)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtCelular)
        Me.Panel1.Controls.Add(Me.txtCPF)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtCarteiraProfissional)
        Me.Panel1.Controls.Add(Me.txtRG)
        Me.Panel1.Controls.Add(Me.cboEstado)
        Me.Panel1.Controls.Add(Me.txtOrgaoEmissor)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtDDD)
        Me.Panel1.Controls.Add(Me.txtNomeMae)
        Me.Panel1.Controls.Add(Me.txtTelefone)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.txtNomePai)
        Me.Panel1.Controls.Add(Me.cboSituacao)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(830, 550)
        Me.Panel1.TabIndex = 303
        '
        'btnLoadImage
        '
        Me.btnLoadImage.BackColor = System.Drawing.Color.Transparent
        Me.btnLoadImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLoadImage.FlatAppearance.BorderSize = 0
        Me.btnLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadImage.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadImage.ForeColor = System.Drawing.Color.Black
        Me.btnLoadImage.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLoadImage.Location = New System.Drawing.Point(577, 325)
        Me.btnLoadImage.Name = "btnLoadImage"
        Me.btnLoadImage.Size = New System.Drawing.Size(96, 20)
        Me.btnLoadImage.TabIndex = 311
        Me.btnLoadImage.TabStop = False
        Me.btnLoadImage.Text = "Foto <F2>"
        Me.btnLoadImage.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLoadImage.UseVisualStyleBackColor = False
        '
        'btoContrato
        '
        Me.btoContrato.BackColor = System.Drawing.Color.Transparent
        Me.btoContrato.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoContrato.FlatAppearance.BorderSize = 0
        Me.btoContrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoContrato.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoContrato.ForeColor = System.Drawing.Color.Black
        Me.btoContrato.Image = Global.nascomercio.My.Resources.Resources.novo
        Me.btoContrato.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoContrato.Location = New System.Drawing.Point(475, 470)
        Me.btoContrato.Margin = New System.Windows.Forms.Padding(0)
        Me.btoContrato.Name = "btoContrato"
        Me.btoContrato.Size = New System.Drawing.Size(112, 70)
        Me.btoContrato.TabIndex = 310
        Me.btoContrato.TabStop = False
        Me.btoContrato.Text = "Contrato <F3>"
        Me.btoContrato.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoContrato.UseVisualStyleBackColor = False
        '
        'btoVeiculos
        '
        Me.btoVeiculos.BackColor = System.Drawing.Color.Transparent
        Me.btoVeiculos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoVeiculos.FlatAppearance.BorderSize = 0
        Me.btoVeiculos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoVeiculos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoVeiculos.ForeColor = System.Drawing.Color.Black
        Me.btoVeiculos.Image = Global.nascomercio.My.Resources.Resources.iconeveiculos3
        Me.btoVeiculos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoVeiculos.Location = New System.Drawing.Point(597, 385)
        Me.btoVeiculos.Margin = New System.Windows.Forms.Padding(0)
        Me.btoVeiculos.Name = "btoVeiculos"
        Me.btoVeiculos.Size = New System.Drawing.Size(112, 70)
        Me.btoVeiculos.TabIndex = 28
        Me.btoVeiculos.TabStop = False
        Me.btoVeiculos.Text = "Veículos <F4>"
        Me.btoVeiculos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoVeiculos.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(57, 440)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 19)
        Me.Label18.TabIndex = 309
        Me.Label18.Text = "DDD"
        '
        'txtDddCelular
        '
        Me.txtDddCelular.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDddCelular.Culture = New System.Globalization.CultureInfo("")
        Me.txtDddCelular.Location = New System.Drawing.Point(110, 440)
        Me.txtDddCelular.Mask = "000"
        Me.txtDddCelular.Name = "txtDddCelular"
        Me.txtDddCelular.Size = New System.Drawing.Size(46, 22)
        Me.txtDddCelular.TabIndex = 16
        Me.txtDddCelular.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtCelular
        '
        Me.txtCelular.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCelular.Culture = New System.Globalization.CultureInfo("")
        Me.txtCelular.Location = New System.Drawing.Point(255, 440)
        Me.txtCelular.Mask = "00000-0000"
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(96, 22)
        Me.txtCelular.TabIndex = 17
        Me.txtCelular.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(173, 440)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 19)
        Me.Label19.TabIndex = 308
        Me.Label19.Text = "Celular"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(41, 244)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 19)
        Me.Label17.TabIndex = 305
        Me.Label17.Text = "Emissor"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(338, 222)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 22)
        Me.Label11.TabIndex = 304
        Me.Label11.Text = "UF"
        '
        'btoVendas
        '
        Me.btoVendas.BackColor = System.Drawing.Color.Transparent
        Me.btoVendas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoVendas.FlatAppearance.BorderSize = 0
        Me.btoVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoVendas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoVendas.ForeColor = System.Drawing.Color.Black
        Me.btoVendas.Image = Global.nascomercio.My.Resources.Resources.caixa
        Me.btoVendas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoVendas.Location = New System.Drawing.Point(598, 468)
        Me.btoVendas.Margin = New System.Windows.Forms.Padding(0)
        Me.btoVendas.Name = "btoVendas"
        Me.btoVendas.Size = New System.Drawing.Size(112, 70)
        Me.btoVendas.TabIndex = 29
        Me.btoVendas.TabStop = False
        Me.btoVendas.Text = "Vendas <F11>"
        Me.btoVendas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoVendas.UseVisualStyleBackColor = False
        '
        'btoCheques
        '
        Me.btoCheques.BackColor = System.Drawing.Color.Transparent
        Me.btoCheques.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoCheques.FlatAppearance.BorderSize = 0
        Me.btoCheques.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoCheques.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoCheques.ForeColor = System.Drawing.Color.Black
        Me.btoCheques.Image = Global.nascomercio.My.Resources.Resources.cheque
        Me.btoCheques.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoCheques.Location = New System.Drawing.Point(710, 468)
        Me.btoCheques.Margin = New System.Windows.Forms.Padding(0)
        Me.btoCheques.Name = "btoCheques"
        Me.btoCheques.Size = New System.Drawing.Size(112, 70)
        Me.btoCheques.TabIndex = 27
        Me.btoCheques.TabStop = False
        Me.btoCheques.Text = "Cheques <F10>"
        Me.btoCheques.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoCheques.UseVisualStyleBackColor = False
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
        Me.btoSalvar.Location = New System.Drawing.Point(185, 466)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(96, 72)
        Me.btoSalvar.TabIndex = 20
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
        Me.btoExcluir.Location = New System.Drawing.Point(292, 466)
        Me.btoExcluir.Name = "btoExcluir"
        Me.btoExcluir.Size = New System.Drawing.Size(84, 72)
        Me.btoExcluir.TabIndex = 21
        Me.btoExcluir.TabStop = False
        Me.btoExcluir.Text = "Excluir <F12>"
        Me.btoExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoExcluir.UseVisualStyleBackColor = False
        '
        'btoCrediario
        '
        Me.btoCrediario.BackColor = System.Drawing.Color.Transparent
        Me.btoCrediario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoCrediario.FlatAppearance.BorderSize = 0
        Me.btoCrediario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoCrediario.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoCrediario.ForeColor = System.Drawing.Color.Black
        Me.btoCrediario.Image = Global.nascomercio.My.Resources.Resources.cheque
        Me.btoCrediario.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoCrediario.Location = New System.Drawing.Point(708, 384)
        Me.btoCrediario.Margin = New System.Windows.Forms.Padding(0)
        Me.btoCrediario.Name = "btoCrediario"
        Me.btoCrediario.Size = New System.Drawing.Size(116, 72)
        Me.btoCrediario.TabIndex = 26
        Me.btoCrediario.TabStop = False
        Me.btoCrediario.Text = "Crediário <F9>"
        Me.btoCrediario.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoCrediario.UseVisualStyleBackColor = False
        '
        'btoFinanceiro
        '
        Me.btoFinanceiro.BackColor = System.Drawing.Color.Transparent
        Me.btoFinanceiro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoFinanceiro.FlatAppearance.BorderSize = 0
        Me.btoFinanceiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoFinanceiro.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoFinanceiro.ForeColor = System.Drawing.Color.Black
        Me.btoFinanceiro.Image = Global.nascomercio.My.Resources.Resources.cliente_financeiro
        Me.btoFinanceiro.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoFinanceiro.Location = New System.Drawing.Point(708, 308)
        Me.btoFinanceiro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFinanceiro.Name = "btoFinanceiro"
        Me.btoFinanceiro.Size = New System.Drawing.Size(116, 70)
        Me.btoFinanceiro.TabIndex = 25
        Me.btoFinanceiro.TabStop = False
        Me.btoFinanceiro.Text = "Financeiro <F8>"
        Me.btoFinanceiro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFinanceiro.UseVisualStyleBackColor = False
        '
        'btoProfissional
        '
        Me.btoProfissional.BackColor = System.Drawing.Color.Transparent
        Me.btoProfissional.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoProfissional.FlatAppearance.BorderSize = 0
        Me.btoProfissional.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoProfissional.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoProfissional.ForeColor = System.Drawing.Color.Black
        Me.btoProfissional.Image = Global.nascomercio.My.Resources.Resources.cliente_profissional
        Me.btoProfissional.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoProfissional.Location = New System.Drawing.Point(708, 232)
        Me.btoProfissional.Margin = New System.Windows.Forms.Padding(0)
        Me.btoProfissional.Name = "btoProfissional"
        Me.btoProfissional.Size = New System.Drawing.Size(116, 70)
        Me.btoProfissional.TabIndex = 24
        Me.btoProfissional.TabStop = False
        Me.btoProfissional.Text = "Profissional <F7>"
        Me.btoProfissional.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoProfissional.UseVisualStyleBackColor = False
        '
        'btoEndereco
        '
        Me.btoEndereco.BackColor = System.Drawing.Color.Transparent
        Me.btoEndereco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoEndereco.FlatAppearance.BorderSize = 0
        Me.btoEndereco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoEndereco.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoEndereco.ForeColor = System.Drawing.Color.Black
        Me.btoEndereco.Image = Global.nascomercio.My.Resources.Resources.home_icon2
        Me.btoEndereco.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoEndereco.Location = New System.Drawing.Point(708, 156)
        Me.btoEndereco.Margin = New System.Windows.Forms.Padding(0)
        Me.btoEndereco.Name = "btoEndereco"
        Me.btoEndereco.Size = New System.Drawing.Size(116, 70)
        Me.btoEndereco.TabIndex = 23
        Me.btoEndereco.TabStop = False
        Me.btoEndereco.Text = "Endereço <F6>"
        Me.btoEndereco.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoEndereco.UseVisualStyleBackColor = False
        '
        'picImagem
        '
        Me.picImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImagem.Location = New System.Drawing.Point(476, 118)
        Me.picImagem.Name = "picImagem"
        Me.picImagem.Size = New System.Drawing.Size(208, 212)
        Me.picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagem.TabIndex = 114
        Me.picImagem.TabStop = False
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
        Me.btoFiltro.Location = New System.Drawing.Point(708, 80)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(116, 70)
        Me.btoFiltro.TabIndex = 22
        Me.btoFiltro.TabStop = False
        Me.btoFiltro.Text = "Pesquisar <F5>"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
        '
        'imgCliLogo
        '
        Me.imgCliLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgCliLogo.Image = Global.nascomercio.My.Resources.Resources.cliente
        Me.imgCliLogo.Location = New System.Drawing.Point(8, 8)
        Me.imgCliLogo.Name = "imgCliLogo"
        Me.imgCliLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgCliLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCliLogo.TabIndex = 93
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
        Me.btoSair.Location = New System.Drawing.Point(708, 4)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(116, 70)
        Me.btoSair.TabIndex = 30
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.CheckPathExists = False
        '
        'fClienteForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(830, 550)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.picImagem)
        Me.Controls.Add(Me.txtNaturalidade)
        Me.Controls.Add(Me.txtNacionalidade)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btoVendas)
        Me.Controls.Add(Me.btoCheques)
        Me.Controls.Add(Me.btoSalvar)
        Me.Controls.Add(Me.btoExcluir)
        Me.Controls.Add(Me.btoCrediario)
        Me.Controls.Add(Me.btoFinanceiro)
        Me.Controls.Add(Me.btoProfissional)
        Me.Controls.Add(Me.btoEndereco)
        Me.Controls.Add(Me.btoFiltro)
        Me.Controls.Add(Me.lblCliSubTitulo)
        Me.Controls.Add(Me.imgCliLogo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblCliCadastro)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "fClienteForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picImagem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents lblCliCadastro As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCPF As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents txtNacionalidade As System.Windows.Forms.TextBox
    Friend WithEvents txtNaturalidade As System.Windows.Forms.TextBox
    Friend WithEvents txtRG As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNomePai As System.Windows.Forms.TextBox
    Friend WithEvents txtNomeMae As System.Windows.Forms.TextBox
    Friend WithEvents txtCarteiraProfissional As System.Windows.Forms.TextBox
    Friend WithEvents cboEstadoCivil As System.Windows.Forms.ComboBox
    Friend WithEvents cboSexo As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents imgCliLogo As System.Windows.Forms.PictureBox
    Friend WithEvents txtDDD As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTelefone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCliSubTitulo As System.Windows.Forms.Label
    Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
    Friend WithEvents btoExcluir As System.Windows.Forms.Button
    Friend WithEvents btoSalvar As System.Windows.Forms.Button
    Friend WithEvents btoFiltro As System.Windows.Forms.Button
    Friend WithEvents picImagem As System.Windows.Forms.PictureBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btoEndereco As System.Windows.Forms.Button
    Friend WithEvents btoProfissional As System.Windows.Forms.Button
    Friend WithEvents btoFinanceiro As System.Windows.Forms.Button
    Friend WithEvents txtDataNascimento As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btoCrediario As System.Windows.Forms.Button
    Friend WithEvents btoCamera As System.Windows.Forms.Button
    Friend WithEvents btoVendas As System.Windows.Forms.Button
    Friend WithEvents btoCheques As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtOrgaoEmissor As System.Windows.Forms.TextBox
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtDddCelular As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCelular As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btoVeiculos As System.Windows.Forms.Button
    Friend WithEvents btoContrato As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents btnLoadImage As Button
End Class
