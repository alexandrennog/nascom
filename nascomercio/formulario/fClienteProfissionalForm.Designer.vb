<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fClienteProfissionalForm
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
    Me.cboEstado = New System.Windows.Forms.ComboBox
    Me.lblCliSubTitulo = New System.Windows.Forms.Label
    Me.txtSalario = New System.Windows.Forms.TextBox
    Me.txtCargo = New System.Windows.Forms.TextBox
    Me.txtComplemento = New System.Windows.Forms.TextBox
    Me.txtTelefone = New System.Windows.Forms.MaskedTextBox
    Me.txtDDD = New System.Windows.Forms.MaskedTextBox
    Me.txtBairro = New System.Windows.Forms.TextBox
    Me.txtCEP = New System.Windows.Forms.MaskedTextBox
    Me.txtCidade = New System.Windows.Forms.TextBox
    Me.txtLogradouro = New System.Windows.Forms.TextBox
    Me.txtEmpresa = New System.Windows.Forms.TextBox
    Me.Label30 = New System.Windows.Forms.Label
    Me.Label29 = New System.Windows.Forms.Label
    Me.Label28 = New System.Windows.Forms.Label
    Me.Label27 = New System.Windows.Forms.Label
    Me.Label26 = New System.Windows.Forms.Label
    Me.Label25 = New System.Windows.Forms.Label
    Me.Label24 = New System.Windows.Forms.Label
    Me.Label23 = New System.Windows.Forms.Label
    Me.Label22 = New System.Windows.Forms.Label
    Me.Label21 = New System.Windows.Forms.Label
    Me.Label20 = New System.Windows.Forms.Label
    Me.Label19 = New System.Windows.Forms.Label
    Me.Label18 = New System.Windows.Forms.Label
    Me.Label17 = New System.Windows.Forms.Label
    Me.txtNome = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.btoFiltro = New System.Windows.Forms.Button
    Me.btoSalvar = New System.Windows.Forms.Button
    Me.imgCliLogo = New System.Windows.Forms.PictureBox
    Me.btoSair = New System.Windows.Forms.Button
    Me.lblCliCadastro = New System.Windows.Forms.Label
    Me.btoFinanceiro = New System.Windows.Forms.Button
    Me.btoCadastro = New System.Windows.Forms.Button
    Me.btoEndereco = New System.Windows.Forms.Button
    Me.txtNumero = New System.Windows.Forms.MaskedTextBox
    Me.txtDataAdmissao = New System.Windows.Forms.MaskedTextBox
    Me.txtRamal = New System.Windows.Forms.MaskedTextBox
    Me.btoCrediario = New System.Windows.Forms.Button
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'cboEstado
    '
    Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboEstado.FormattingEnabled = True
    Me.cboEstado.Location = New System.Drawing.Point(544, 188)
    Me.cboEstado.Name = "cboEstado"
    Me.cboEstado.Size = New System.Drawing.Size(64, 26)
    Me.cboEstado.TabIndex = 8
    '
    'lblCliSubTitulo
    '
    Me.lblCliSubTitulo.AutoSize = True
    Me.lblCliSubTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblCliSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblCliSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblCliSubTitulo.Location = New System.Drawing.Point(64, 32)
    Me.lblCliSubTitulo.Name = "lblCliSubTitulo"
    Me.lblCliSubTitulo.Size = New System.Drawing.Size(67, 14)
    Me.lblCliSubTitulo.TabIndex = 165
    Me.lblCliSubTitulo.Text = "CADASTRO"
    '
    'txtSalario
    '
    Me.txtSalario.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtSalario.Location = New System.Drawing.Point(508, 296)
    Me.txtSalario.MaxLength = 9
    Me.txtSalario.Name = "txtSalario"
    Me.txtSalario.Size = New System.Drawing.Size(100, 18)
    Me.txtSalario.TabIndex = 15
    '
    'txtCargo
    '
    Me.txtCargo.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCargo.Location = New System.Drawing.Point(124, 296)
    Me.txtCargo.MaxLength = 100
    Me.txtCargo.Name = "txtCargo"
    Me.txtCargo.Size = New System.Drawing.Size(300, 18)
    Me.txtCargo.TabIndex = 14
    '
    'txtComplemento
    '
    Me.txtComplemento.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtComplemento.Location = New System.Drawing.Point(316, 144)
    Me.txtComplemento.MaxLength = 100
    Me.txtComplemento.Name = "txtComplemento"
    Me.txtComplemento.Size = New System.Drawing.Size(292, 18)
    Me.txtComplemento.TabIndex = 5
    '
    'txtTelefone
    '
    Me.txtTelefone.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtTelefone.Culture = New System.Globalization.CultureInfo("")
    Me.txtTelefone.Location = New System.Drawing.Point(268, 240)
    Me.txtTelefone.Mask = "0000-0000"
    Me.txtTelefone.Name = "txtTelefone"
    Me.txtTelefone.Size = New System.Drawing.Size(92, 18)
    Me.txtTelefone.TabIndex = 11
    Me.txtTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'txtDDD
    '
    Me.txtDDD.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDDD.Culture = New System.Globalization.CultureInfo("")
    Me.txtDDD.Location = New System.Drawing.Point(124, 240)
    Me.txtDDD.Mask = "000"
    Me.txtDDD.Name = "txtDDD"
    Me.txtDDD.Size = New System.Drawing.Size(46, 18)
    Me.txtDDD.TabIndex = 10
    Me.txtDDD.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'txtBairro
    '
    Me.txtBairro.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtBairro.Location = New System.Drawing.Point(124, 168)
    Me.txtBairro.MaxLength = 100
    Me.txtBairro.Name = "txtBairro"
    Me.txtBairro.Size = New System.Drawing.Size(336, 18)
    Me.txtBairro.TabIndex = 6
    '
    'txtCEP
    '
    Me.txtCEP.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCEP.Culture = New System.Globalization.CultureInfo("")
    Me.txtCEP.Location = New System.Drawing.Point(124, 216)
    Me.txtCEP.Mask = "00000-000"
    Me.txtCEP.Name = "txtCEP"
    Me.txtCEP.Size = New System.Drawing.Size(87, 18)
    Me.txtCEP.TabIndex = 9
    Me.txtCEP.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'txtCidade
    '
    Me.txtCidade.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCidade.Location = New System.Drawing.Point(124, 192)
    Me.txtCidade.MaxLength = 100
    Me.txtCidade.Name = "txtCidade"
    Me.txtCidade.Size = New System.Drawing.Size(336, 18)
    Me.txtCidade.TabIndex = 7
    '
    'txtLogradouro
    '
    Me.txtLogradouro.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtLogradouro.Location = New System.Drawing.Point(124, 120)
    Me.txtLogradouro.MaxLength = 100
    Me.txtLogradouro.Name = "txtLogradouro"
    Me.txtLogradouro.Size = New System.Drawing.Size(484, 18)
    Me.txtLogradouro.TabIndex = 3
    '
    'txtEmpresa
    '
    Me.txtEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtEmpresa.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtEmpresa.Location = New System.Drawing.Point(124, 96)
    Me.txtEmpresa.MaxLength = 100
    Me.txtEmpresa.Name = "txtEmpresa"
    Me.txtEmpresa.Size = New System.Drawing.Size(484, 18)
    Me.txtEmpresa.TabIndex = 2
    '
    'Label30
    '
    Me.Label30.AutoSize = True
    Me.Label30.Location = New System.Drawing.Point(444, 296)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(57, 18)
    Me.Label30.TabIndex = 150
    Me.Label30.Text = "Salário"
    '
    'Label29
    '
    Me.Label29.AutoSize = True
    Me.Label29.Location = New System.Drawing.Point(8, 268)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(111, 18)
    Me.Label29.TabIndex = 149
    Me.Label29.Text = "Data Admissão"
    '
    'Label28
    '
    Me.Label28.AutoSize = True
    Me.Label28.Location = New System.Drawing.Point(68, 296)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(51, 18)
    Me.Label28.TabIndex = 148
    Me.Label28.Text = "Cargo"
    '
    'Label27
    '
    Me.Label27.AutoSize = True
    Me.Label27.Location = New System.Drawing.Point(380, 240)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(51, 18)
    Me.Label27.TabIndex = 147
    Me.Label27.Text = "Ramal"
    '
    'Label26
    '
    Me.Label26.AutoSize = True
    Me.Label26.Location = New System.Drawing.Point(192, 240)
    Me.Label26.Name = "Label26"
    Me.Label26.Size = New System.Drawing.Size(72, 18)
    Me.Label26.TabIndex = 146
    Me.Label26.Text = "Telefone"
    '
    'Label25
    '
    Me.Label25.AutoSize = True
    Me.Label25.Location = New System.Drawing.Point(76, 240)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(41, 18)
    Me.Label25.TabIndex = 145
    Me.Label25.Text = "DDD"
    '
    'Label24
    '
    Me.Label24.AutoSize = True
    Me.Label24.Location = New System.Drawing.Point(80, 216)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(37, 18)
    Me.Label24.TabIndex = 144
    Me.Label24.Text = "Cep"
    '
    'Label23
    '
    Me.Label23.AutoSize = True
    Me.Label23.Location = New System.Drawing.Point(480, 192)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(57, 18)
    Me.Label23.TabIndex = 143
    Me.Label23.Text = "Estado"
    '
    'Label22
    '
    Me.Label22.AutoSize = True
    Me.Label22.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label22.Location = New System.Drawing.Point(60, 192)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(58, 18)
    Me.Label22.TabIndex = 142
    Me.Label22.Text = "Cidade"
    '
    'Label21
    '
    Me.Label21.AutoSize = True
    Me.Label21.Location = New System.Drawing.Point(68, 168)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(52, 18)
    Me.Label21.TabIndex = 141
    Me.Label21.Text = "Bairro"
    '
    'Label20
    '
    Me.Label20.AutoSize = True
    Me.Label20.Location = New System.Drawing.Point(204, 144)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(106, 18)
    Me.Label20.TabIndex = 140
    Me.Label20.Text = "Complemento"
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.Location = New System.Drawing.Point(56, 144)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(64, 18)
    Me.Label19.TabIndex = 139
    Me.Label19.Text = "Numero"
    '
    'Label18
    '
    Me.Label18.AutoSize = True
    Me.Label18.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label18.Location = New System.Drawing.Point(40, 120)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(77, 18)
    Me.Label18.TabIndex = 138
    Me.Label18.Text = "Endereço"
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label17.Location = New System.Drawing.Point(48, 96)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(70, 18)
    Me.Label17.TabIndex = 137
    Me.Label17.Text = "Empresa"
    '
    'txtNome
    '
    Me.txtNome.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtNome.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    Me.txtNome.Location = New System.Drawing.Point(124, 68)
    Me.txtNome.Name = "txtNome"
    Me.txtNome.ReadOnly = True
    Me.txtNome.Size = New System.Drawing.Size(482, 18)
    Me.txtNome.TabIndex = 1
    Me.txtNome.TabStop = False
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label3.ForeColor = System.Drawing.Color.Gray
    Me.Label3.Location = New System.Drawing.Point(68, 68)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(49, 18)
    Me.Label3.TabIndex = 117
    Me.Label3.Text = "Nome"
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
    Me.btoFiltro.Location = New System.Drawing.Point(688, 84)
    Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
    Me.btoFiltro.Name = "btoFiltro"
    Me.btoFiltro.Size = New System.Drawing.Size(106, 70)
    Me.btoFiltro.TabIndex = 19
    Me.btoFiltro.TabStop = False
    Me.btoFiltro.Text = "Pesquisar <F5>"
    Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoFiltro.UseVisualStyleBackColor = False
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
    Me.btoSalvar.Location = New System.Drawing.Point(336, 400)
    Me.btoSalvar.Name = "btoSalvar"
    Me.btoSalvar.Size = New System.Drawing.Size(96, 71)
    Me.btoSalvar.TabIndex = 16
    Me.btoSalvar.TabStop = False
    Me.btoSalvar.Text = "Salvar <Enter>"
    Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSalvar.UseVisualStyleBackColor = False
    '
    'imgCliLogo
    '
    Me.imgCliLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgCliLogo.Image = Global.nascomercio.My.Resources.Resources.cliente_profissional
    Me.imgCliLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgCliLogo.Name = "imgCliLogo"
    Me.imgCliLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgCliLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgCliLogo.TabIndex = 152
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
    Me.btoSair.Location = New System.Drawing.Point(688, 8)
    Me.btoSair.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(106, 70)
    Me.btoSair.TabIndex = 18
    Me.btoSair.TabStop = False
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSair.UseVisualStyleBackColor = False
    '
    'lblCliCadastro
    '
    Me.lblCliCadastro.AutoSize = True
    Me.lblCliCadastro.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.lblCliCadastro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblCliCadastro.Location = New System.Drawing.Point(64, 8)
    Me.lblCliCadastro.Name = "lblCliCadastro"
    Me.lblCliCadastro.Size = New System.Drawing.Size(229, 24)
    Me.lblCliCadastro.TabIndex = 171
    Me.lblCliCadastro.Text = "Clientes - Profissional"
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
    Me.btoFinanceiro.Location = New System.Drawing.Point(688, 308)
    Me.btoFinanceiro.Margin = New System.Windows.Forms.Padding(0)
    Me.btoFinanceiro.Name = "btoFinanceiro"
    Me.btoFinanceiro.Size = New System.Drawing.Size(106, 70)
    Me.btoFinanceiro.TabIndex = 22
    Me.btoFinanceiro.TabStop = False
    Me.btoFinanceiro.Text = "Financeiro <F8>"
    Me.btoFinanceiro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoFinanceiro.UseVisualStyleBackColor = False
    '
    'btoCadastro
    '
    Me.btoCadastro.BackColor = System.Drawing.Color.Transparent
    Me.btoCadastro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoCadastro.FlatAppearance.BorderSize = 0
    Me.btoCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoCadastro.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoCadastro.ForeColor = System.Drawing.Color.Black
    Me.btoCadastro.Image = Global.nascomercio.My.Resources.Resources.cliente
    Me.btoCadastro.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoCadastro.Location = New System.Drawing.Point(688, 157)
    Me.btoCadastro.Margin = New System.Windows.Forms.Padding(0)
    Me.btoCadastro.Name = "btoCadastro"
    Me.btoCadastro.Size = New System.Drawing.Size(106, 70)
    Me.btoCadastro.TabIndex = 20
    Me.btoCadastro.TabStop = False
    Me.btoCadastro.Text = "Cadastro <F6>"
    Me.btoCadastro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoCadastro.UseVisualStyleBackColor = False
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
    Me.btoEndereco.Location = New System.Drawing.Point(688, 232)
    Me.btoEndereco.Margin = New System.Windows.Forms.Padding(0)
    Me.btoEndereco.Name = "btoEndereco"
    Me.btoEndereco.Size = New System.Drawing.Size(106, 70)
    Me.btoEndereco.TabIndex = 21
    Me.btoEndereco.TabStop = False
    Me.btoEndereco.Text = "Endereço <F7>"
    Me.btoEndereco.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoEndereco.UseVisualStyleBackColor = False
    '
    'txtNumero
    '
    Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtNumero.Culture = New System.Globalization.CultureInfo("")
    Me.txtNumero.Location = New System.Drawing.Point(124, 144)
    Me.txtNumero.Mask = "00000"
    Me.txtNumero.Name = "txtNumero"
    Me.txtNumero.Size = New System.Drawing.Size(57, 18)
    Me.txtNumero.TabIndex = 4
    Me.txtNumero.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'txtDataAdmissao
    '
    Me.txtDataAdmissao.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDataAdmissao.Culture = New System.Globalization.CultureInfo("")
    Me.txtDataAdmissao.Location = New System.Drawing.Point(125, 269)
    Me.txtDataAdmissao.Mask = "00/00/0000"
    Me.txtDataAdmissao.Name = "txtDataAdmissao"
    Me.txtDataAdmissao.Size = New System.Drawing.Size(87, 18)
    Me.txtDataAdmissao.TabIndex = 13
    Me.txtDataAdmissao.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'txtRamal
    '
    Me.txtRamal.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtRamal.Culture = New System.Globalization.CultureInfo("")
    Me.txtRamal.Location = New System.Drawing.Point(436, 240)
    Me.txtRamal.Mask = "00000"
    Me.txtRamal.Name = "txtRamal"
    Me.txtRamal.Size = New System.Drawing.Size(57, 18)
    Me.txtRamal.TabIndex = 12
    Me.txtRamal.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
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
    Me.btoCrediario.Location = New System.Drawing.Point(688, 384)
    Me.btoCrediario.Margin = New System.Windows.Forms.Padding(0)
    Me.btoCrediario.Name = "btoCrediario"
    Me.btoCrediario.Size = New System.Drawing.Size(106, 70)
    Me.btoCrediario.TabIndex = 178
    Me.btoCrediario.TabStop = False
    Me.btoCrediario.Text = "Crediário <F9>"
    Me.btoCrediario.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoCrediario.UseVisualStyleBackColor = False
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(803, 480)
    Me.Panel1.TabIndex = 179
    '
    'fClienteProfissionalForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(803, 480)
    Me.Controls.Add(Me.btoCrediario)
    Me.Controls.Add(Me.txtNumero)
    Me.Controls.Add(Me.txtDataAdmissao)
    Me.Controls.Add(Me.txtRamal)
    Me.Controls.Add(Me.btoFinanceiro)
    Me.Controls.Add(Me.btoCadastro)
    Me.Controls.Add(Me.btoEndereco)
    Me.Controls.Add(Me.lblCliCadastro)
    Me.Controls.Add(Me.cboEstado)
    Me.Controls.Add(Me.btoFiltro)
    Me.Controls.Add(Me.btoSalvar)
    Me.Controls.Add(Me.lblCliSubTitulo)
    Me.Controls.Add(Me.txtSalario)
    Me.Controls.Add(Me.txtCargo)
    Me.Controls.Add(Me.txtComplemento)
    Me.Controls.Add(Me.txtTelefone)
    Me.Controls.Add(Me.txtDDD)
    Me.Controls.Add(Me.txtBairro)
    Me.Controls.Add(Me.txtCEP)
    Me.Controls.Add(Me.txtCidade)
    Me.Controls.Add(Me.txtLogradouro)
    Me.Controls.Add(Me.imgCliLogo)
    Me.Controls.Add(Me.txtEmpresa)
    Me.Controls.Add(Me.Label30)
    Me.Controls.Add(Me.Label29)
    Me.Controls.Add(Me.Label28)
    Me.Controls.Add(Me.Label27)
    Me.Controls.Add(Me.Label26)
    Me.Controls.Add(Me.Label25)
    Me.Controls.Add(Me.Label24)
    Me.Controls.Add(Me.Label23)
    Me.Controls.Add(Me.Label22)
    Me.Controls.Add(Me.Label21)
    Me.Controls.Add(Me.Label20)
    Me.Controls.Add(Me.Label19)
    Me.Controls.Add(Me.Label18)
    Me.Controls.Add(Me.Label17)
    Me.Controls.Add(Me.txtNome)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.Name = "fClienteProfissionalForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Clientes - Profissional"
    CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
  Friend WithEvents btoFiltro As System.Windows.Forms.Button
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents lblCliSubTitulo As System.Windows.Forms.Label
  Friend WithEvents txtSalario As System.Windows.Forms.TextBox
  Friend WithEvents txtCargo As System.Windows.Forms.TextBox
  Friend WithEvents txtComplemento As System.Windows.Forms.TextBox
  Friend WithEvents txtTelefone As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtDDD As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtBairro As System.Windows.Forms.TextBox
  Friend WithEvents txtCEP As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtCidade As System.Windows.Forms.TextBox
  Friend WithEvents txtLogradouro As System.Windows.Forms.TextBox
  Friend WithEvents imgCliLogo As System.Windows.Forms.PictureBox
  Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents txtNome As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents lblCliCadastro As System.Windows.Forms.Label
  Friend WithEvents btoFinanceiro As System.Windows.Forms.Button
  Friend WithEvents btoCadastro As System.Windows.Forms.Button
  Friend WithEvents btoEndereco As System.Windows.Forms.Button
  Friend WithEvents txtNumero As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtDataAdmissao As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtRamal As System.Windows.Forms.MaskedTextBox
  Friend WithEvents btoCrediario As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
