<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fLojaForm
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
    Me.txtContato = New System.Windows.Forms.TextBox
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.btoExcluir = New System.Windows.Forms.Button
    Me.btoSalvar = New System.Windows.Forms.Button
    Me.btoSair = New System.Windows.Forms.Button
    Me.btoFiltro = New System.Windows.Forms.Button
    Me.txtCidade = New System.Windows.Forms.TextBox
    Me.txtBairro = New System.Windows.Forms.TextBox
    Me.txtComplemento = New System.Windows.Forms.TextBox
    Me.txtLogradouro = New System.Windows.Forms.TextBox
    Me.txtRazaoSocial = New System.Windows.Forms.TextBox
    Me.txtNomeFantasia = New System.Windows.Forms.TextBox
    Me.txtCodigo = New System.Windows.Forms.TextBox
    Me.lblContato = New System.Windows.Forms.Label
    Me.lblRamal = New System.Windows.Forms.Label
    Me.lblTelefone = New System.Windows.Forms.Label
    Me.lblDDD = New System.Windows.Forms.Label
    Me.lblInscricaoEstadual = New System.Windows.Forms.Label
    Me.lblCnpj = New System.Windows.Forms.Label
    Me.lblCEP = New System.Windows.Forms.Label
    Me.lblCidade = New System.Windows.Forms.Label
    Me.lblBairro = New System.Windows.Forms.Label
    Me.lblComplemento = New System.Windows.Forms.Label
    Me.lblNumero = New System.Windows.Forms.Label
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.cboEstado = New System.Windows.Forms.ComboBox
    Me.lblEstado = New System.Windows.Forms.Label
    Me.cboSituacao = New System.Windows.Forms.ComboBox
    Me.lblSituacao = New System.Windows.Forms.Label
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.lblLogradouro = New System.Windows.Forms.Label
    Me.lblNome = New System.Windows.Forms.Label
    Me.lblCodigo = New System.Windows.Forms.Label
    Me.txtCnpj = New System.Windows.Forms.MaskedTextBox
    Me.txtNumero = New System.Windows.Forms.MaskedTextBox
    Me.txtCep = New System.Windows.Forms.MaskedTextBox
    Me.txtDDD = New System.Windows.Forms.MaskedTextBox
    Me.txtTelefone = New System.Windows.Forms.MaskedTextBox
    Me.txtRamal = New System.Windows.Forms.MaskedTextBox
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.txtSpcCodigoAssociado = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.txtSpcNomeInformante = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtSpcControleInformante = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'txtContato
    '
    Me.txtContato.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtContato.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtContato.Location = New System.Drawing.Point(124, 296)
    Me.txtContato.MaxLength = 100
    Me.txtContato.Name = "txtContato"
    Me.txtContato.Size = New System.Drawing.Size(466, 18)
    Me.txtContato.TabIndex = 15
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
    Me.btoExcluir.Location = New System.Drawing.Point(392, 436)
    Me.btoExcluir.Name = "btoExcluir"
    Me.btoExcluir.Size = New System.Drawing.Size(84, 72)
    Me.btoExcluir.TabIndex = 18
    Me.btoExcluir.TabStop = False
    Me.btoExcluir.Text = "Excluir <F12>"
    Me.btoExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoExcluir, "Excluir")
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
    Me.btoSalvar.Location = New System.Drawing.Point(296, 436)
    Me.btoSalvar.Name = "btoSalvar"
    Me.btoSalvar.Size = New System.Drawing.Size(92, 72)
    Me.btoSalvar.TabIndex = 17
    Me.btoSalvar.TabStop = False
    Me.btoSalvar.Text = "Salvar <Enter>"
    Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoSalvar, "Salvar")
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
    Me.btoSair.Location = New System.Drawing.Point(636, 4)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(100, 72)
    Me.btoSair.TabIndex = 19
    Me.btoSair.TabStop = False
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoSair, "Sair")
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
    Me.btoFiltro.Location = New System.Drawing.Point(636, 80)
    Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
    Me.btoFiltro.Name = "btoFiltro"
    Me.btoFiltro.Size = New System.Drawing.Size(100, 72)
    Me.btoFiltro.TabIndex = 20
    Me.btoFiltro.TabStop = False
    Me.btoFiltro.Text = "Pesquisar <F5>"
    Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoFiltro, "Filtro")
    Me.btoFiltro.UseVisualStyleBackColor = False
    '
    'txtCidade
    '
    Me.txtCidade.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCidade.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtCidade.Location = New System.Drawing.Point(124, 244)
    Me.txtCidade.MaxLength = 100
    Me.txtCidade.Name = "txtCidade"
    Me.txtCidade.Size = New System.Drawing.Size(356, 18)
    Me.txtCidade.TabIndex = 10
    '
    'txtBairro
    '
    Me.txtBairro.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtBairro.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtBairro.Location = New System.Drawing.Point(124, 216)
    Me.txtBairro.MaxLength = 100
    Me.txtBairro.Name = "txtBairro"
    Me.txtBairro.Size = New System.Drawing.Size(356, 18)
    Me.txtBairro.TabIndex = 8
    '
    'txtComplemento
    '
    Me.txtComplemento.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtComplemento.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtComplemento.Location = New System.Drawing.Point(356, 192)
    Me.txtComplemento.MaxLength = 100
    Me.txtComplemento.Name = "txtComplemento"
    Me.txtComplemento.Size = New System.Drawing.Size(296, 18)
    Me.txtComplemento.TabIndex = 7
    '
    'txtLogradouro
    '
    Me.txtLogradouro.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtLogradouro.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtLogradouro.Location = New System.Drawing.Point(124, 168)
    Me.txtLogradouro.MaxLength = 100
    Me.txtLogradouro.Name = "txtLogradouro"
    Me.txtLogradouro.Size = New System.Drawing.Size(466, 18)
    Me.txtLogradouro.TabIndex = 5
    '
    'txtRazaoSocial
    '
    Me.txtRazaoSocial.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtRazaoSocial.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtRazaoSocial.Location = New System.Drawing.Point(124, 120)
    Me.txtRazaoSocial.MaxLength = 100
    Me.txtRazaoSocial.Name = "txtRazaoSocial"
    Me.txtRazaoSocial.Size = New System.Drawing.Size(468, 18)
    Me.txtRazaoSocial.TabIndex = 3
    '
    'txtNomeFantasia
    '
    Me.txtNomeFantasia.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtNomeFantasia.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtNomeFantasia.Location = New System.Drawing.Point(124, 96)
    Me.txtNomeFantasia.MaxLength = 100
    Me.txtNomeFantasia.Name = "txtNomeFantasia"
    Me.txtNomeFantasia.Size = New System.Drawing.Size(466, 18)
    Me.txtNomeFantasia.TabIndex = 2
    '
    'txtCodigo
    '
    Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtCodigo.Location = New System.Drawing.Point(124, 72)
    Me.txtCodigo.MaxLength = 10
    Me.txtCodigo.Name = "txtCodigo"
    Me.txtCodigo.Size = New System.Drawing.Size(135, 18)
    Me.txtCodigo.TabIndex = 1
    '
    'lblContato
    '
    Me.lblContato.AutoSize = True
    Me.lblContato.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblContato.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblContato.Location = New System.Drawing.Point(56, 296)
    Me.lblContato.Name = "lblContato"
    Me.lblContato.Size = New System.Drawing.Size(64, 18)
    Me.lblContato.TabIndex = 123
    Me.lblContato.Text = "Contato"
    '
    'lblRamal
    '
    Me.lblRamal.AutoSize = True
    Me.lblRamal.BackColor = System.Drawing.Color.Transparent
    Me.lblRamal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblRamal.Location = New System.Drawing.Point(420, 272)
    Me.lblRamal.Name = "lblRamal"
    Me.lblRamal.Size = New System.Drawing.Size(51, 18)
    Me.lblRamal.TabIndex = 133
    Me.lblRamal.Text = "Ramal"
    '
    'lblTelefone
    '
    Me.lblTelefone.AutoSize = True
    Me.lblTelefone.BackColor = System.Drawing.Color.Transparent
    Me.lblTelefone.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblTelefone.Location = New System.Drawing.Point(200, 272)
    Me.lblTelefone.Name = "lblTelefone"
    Me.lblTelefone.Size = New System.Drawing.Size(72, 18)
    Me.lblTelefone.TabIndex = 131
    Me.lblTelefone.Text = "Telefone"
    '
    'lblDDD
    '
    Me.lblDDD.AutoSize = True
    Me.lblDDD.BackColor = System.Drawing.Color.Transparent
    Me.lblDDD.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblDDD.Location = New System.Drawing.Point(76, 272)
    Me.lblDDD.Name = "lblDDD"
    Me.lblDDD.Size = New System.Drawing.Size(41, 18)
    Me.lblDDD.TabIndex = 129
    Me.lblDDD.Text = "DDD"
    '
    'lblInscricaoEstadual
    '
    Me.lblInscricaoEstadual.AutoSize = True
    Me.lblInscricaoEstadual.BackColor = System.Drawing.Color.Transparent
    Me.lblInscricaoEstadual.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblInscricaoEstadual.Location = New System.Drawing.Point(20, 120)
    Me.lblInscricaoEstadual.Name = "lblInscricaoEstadual"
    Me.lblInscricaoEstadual.Size = New System.Drawing.Size(99, 18)
    Me.lblInscricaoEstadual.TabIndex = 128
    Me.lblInscricaoEstadual.Text = "Razão Social"
    '
    'lblCnpj
    '
    Me.lblCnpj.AutoSize = True
    Me.lblCnpj.BackColor = System.Drawing.Color.Transparent
    Me.lblCnpj.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCnpj.Location = New System.Drawing.Point(56, 144)
    Me.lblCnpj.Name = "lblCnpj"
    Me.lblCnpj.Size = New System.Drawing.Size(64, 18)
    Me.lblCnpj.TabIndex = 126
    Me.lblCnpj.Text = "C.N.P.J."
    '
    'lblCEP
    '
    Me.lblCEP.AutoSize = True
    Me.lblCEP.BackColor = System.Drawing.Color.Transparent
    Me.lblCEP.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCEP.Location = New System.Drawing.Point(508, 216)
    Me.lblCEP.Name = "lblCEP"
    Me.lblCEP.Size = New System.Drawing.Size(51, 18)
    Me.lblCEP.TabIndex = 130
    Me.lblCEP.Text = "C.E.P."
    '
    'lblCidade
    '
    Me.lblCidade.AutoSize = True
    Me.lblCidade.BackColor = System.Drawing.Color.Transparent
    Me.lblCidade.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCidade.Location = New System.Drawing.Point(60, 244)
    Me.lblCidade.Name = "lblCidade"
    Me.lblCidade.Size = New System.Drawing.Size(58, 18)
    Me.lblCidade.TabIndex = 132
    Me.lblCidade.Text = "Cidade"
    '
    'lblBairro
    '
    Me.lblBairro.AutoSize = True
    Me.lblBairro.BackColor = System.Drawing.Color.Transparent
    Me.lblBairro.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblBairro.Location = New System.Drawing.Point(68, 216)
    Me.lblBairro.Name = "lblBairro"
    Me.lblBairro.Size = New System.Drawing.Size(52, 18)
    Me.lblBairro.TabIndex = 127
    Me.lblBairro.Text = "Bairro"
    '
    'lblComplemento
    '
    Me.lblComplemento.AutoSize = True
    Me.lblComplemento.BackColor = System.Drawing.Color.Transparent
    Me.lblComplemento.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblComplemento.Location = New System.Drawing.Point(244, 192)
    Me.lblComplemento.Name = "lblComplemento"
    Me.lblComplemento.Size = New System.Drawing.Size(106, 18)
    Me.lblComplemento.TabIndex = 124
    Me.lblComplemento.Text = "Complemento"
    '
    'lblNumero
    '
    Me.lblNumero.AutoSize = True
    Me.lblNumero.BackColor = System.Drawing.Color.Transparent
    Me.lblNumero.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblNumero.Location = New System.Drawing.Point(56, 192)
    Me.lblNumero.Name = "lblNumero"
    Me.lblNumero.Size = New System.Drawing.Size(64, 18)
    Me.lblNumero.TabIndex = 125
    Me.lblNumero.Text = "Número"
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
    Me.lblSubTitulo.TabIndex = 122
    Me.lblSubTitulo.Text = "CADASTRO"
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.loja
    Me.imgLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 121
    Me.imgLogo.TabStop = False
    '
    'cboEstado
    '
    Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboEstado.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboEstado.FormattingEnabled = True
    Me.cboEstado.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27"})
    Me.cboEstado.Location = New System.Drawing.Point(564, 240)
    Me.cboEstado.Name = "cboEstado"
    Me.cboEstado.Size = New System.Drawing.Size(86, 26)
    Me.cboEstado.TabIndex = 11
    '
    'lblEstado
    '
    Me.lblEstado.AutoSize = True
    Me.lblEstado.BackColor = System.Drawing.Color.Transparent
    Me.lblEstado.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblEstado.Location = New System.Drawing.Point(500, 244)
    Me.lblEstado.Name = "lblEstado"
    Me.lblEstado.Size = New System.Drawing.Size(57, 18)
    Me.lblEstado.TabIndex = 120
    Me.lblEstado.Text = "Estado"
    '
    'cboSituacao
    '
    Me.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboSituacao.FormattingEnabled = True
    Me.cboSituacao.Items.AddRange(New Object() {"S", "N"})
    Me.cboSituacao.Location = New System.Drawing.Point(124, 320)
    Me.cboSituacao.Name = "cboSituacao"
    Me.cboSituacao.Size = New System.Drawing.Size(100, 26)
    Me.cboSituacao.TabIndex = 16
    '
    'lblSituacao
    '
    Me.lblSituacao.AutoSize = True
    Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
    Me.lblSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblSituacao.Location = New System.Drawing.Point(48, 324)
    Me.lblSituacao.Name = "lblSituacao"
    Me.lblSituacao.Size = New System.Drawing.Size(69, 18)
    Me.lblSituacao.TabIndex = 119
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
    Me.lblTitulo.Size = New System.Drawing.Size(53, 24)
    Me.lblTitulo.TabIndex = 118
    Me.lblTitulo.Text = "Loja"
    '
    'lblLogradouro
    '
    Me.lblLogradouro.AutoSize = True
    Me.lblLogradouro.BackColor = System.Drawing.Color.Transparent
    Me.lblLogradouro.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblLogradouro.Location = New System.Drawing.Point(40, 168)
    Me.lblLogradouro.Name = "lblLogradouro"
    Me.lblLogradouro.Size = New System.Drawing.Size(77, 18)
    Me.lblLogradouro.TabIndex = 117
    Me.lblLogradouro.Text = "Endereço"
    '
    'lblNome
    '
    Me.lblNome.AutoSize = True
    Me.lblNome.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblNome.Location = New System.Drawing.Point(8, 96)
    Me.lblNome.Name = "lblNome"
    Me.lblNome.Size = New System.Drawing.Size(112, 18)
    Me.lblNome.TabIndex = 116
    Me.lblNome.Text = "Nome Fantasia"
    '
    'lblCodigo
    '
    Me.lblCodigo.AutoSize = True
    Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
    Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCodigo.Location = New System.Drawing.Point(60, 72)
    Me.lblCodigo.Name = "lblCodigo"
    Me.lblCodigo.Size = New System.Drawing.Size(59, 18)
    Me.lblCodigo.TabIndex = 115
    Me.lblCodigo.Text = "Código"
    '
    'txtCnpj
    '
    Me.txtCnpj.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCnpj.Culture = New System.Globalization.CultureInfo("")
    Me.txtCnpj.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtCnpj.Location = New System.Drawing.Point(124, 144)
    Me.txtCnpj.Mask = "000.000.000/0000-00"
    Me.txtCnpj.Name = "txtCnpj"
    Me.txtCnpj.Size = New System.Drawing.Size(156, 18)
    Me.txtCnpj.TabIndex = 4
    Me.txtCnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'txtNumero
    '
    Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtNumero.Culture = New System.Globalization.CultureInfo("")
    Me.txtNumero.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtNumero.Location = New System.Drawing.Point(124, 192)
    Me.txtNumero.Mask = "00000"
    Me.txtNumero.Name = "txtNumero"
    Me.txtNumero.Size = New System.Drawing.Size(64, 18)
    Me.txtNumero.TabIndex = 6
    Me.txtNumero.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'txtCep
    '
    Me.txtCep.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCep.Culture = New System.Globalization.CultureInfo("")
    Me.txtCep.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtCep.Location = New System.Drawing.Point(564, 216)
    Me.txtCep.Mask = "00000-000"
    Me.txtCep.Name = "txtCep"
    Me.txtCep.Size = New System.Drawing.Size(88, 18)
    Me.txtCep.TabIndex = 9
    Me.txtCep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'txtDDD
    '
    Me.txtDDD.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDDD.Culture = New System.Globalization.CultureInfo("")
    Me.txtDDD.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtDDD.Location = New System.Drawing.Point(124, 272)
    Me.txtDDD.Mask = "000"
    Me.txtDDD.Name = "txtDDD"
    Me.txtDDD.Size = New System.Drawing.Size(48, 18)
    Me.txtDDD.TabIndex = 12
    Me.txtDDD.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'txtTelefone
    '
    Me.txtTelefone.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtTelefone.Culture = New System.Globalization.CultureInfo("")
    Me.txtTelefone.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtTelefone.Location = New System.Drawing.Point(276, 272)
    Me.txtTelefone.Mask = "0000-0000"
    Me.txtTelefone.Name = "txtTelefone"
    Me.txtTelefone.Size = New System.Drawing.Size(116, 18)
    Me.txtTelefone.TabIndex = 13
    Me.txtTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'txtRamal
    '
    Me.txtRamal.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtRamal.Culture = New System.Globalization.CultureInfo("")
    Me.txtRamal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtRamal.Location = New System.Drawing.Point(476, 272)
    Me.txtRamal.Mask = "00000"
    Me.txtRamal.Name = "txtRamal"
    Me.txtRamal.Size = New System.Drawing.Size(64, 18)
    Me.txtRamal.TabIndex = 14
    Me.txtRamal.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(739, 513)
    Me.Panel1.TabIndex = 134
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.txtSpcControleInformante)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.txtSpcNomeInformante)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.txtSpcCodigoAssociado)
    Me.GroupBox1.Controls.Add(Me.Label1)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Black
    Me.GroupBox1.Location = New System.Drawing.Point(32, 352)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(644, 81)
    Me.GroupBox1.TabIndex = 137
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "SPC"
    '
    'txtSpcCodigoAssociado
    '
    Me.txtSpcCodigoAssociado.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtSpcCodigoAssociado.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtSpcCodigoAssociado.Location = New System.Drawing.Point(170, 22)
    Me.txtSpcCodigoAssociado.MaxLength = 8
    Me.txtSpcCodigoAssociado.Name = "txtSpcCodigoAssociado"
    Me.txtSpcCodigoAssociado.Size = New System.Drawing.Size(94, 18)
    Me.txtSpcCodigoAssociado.TabIndex = 137
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label1.Location = New System.Drawing.Point(7, 22)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(157, 18)
    Me.Label1.TabIndex = 138
    Me.Label1.Text = "Codigo do Associado"
    '
    'txtSpcNomeInformante
    '
    Me.txtSpcNomeInformante.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtSpcNomeInformante.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtSpcNomeInformante.Location = New System.Drawing.Point(170, 50)
    Me.txtSpcNomeInformante.MaxLength = 35
    Me.txtSpcNomeInformante.Name = "txtSpcNomeInformante"
    Me.txtSpcNomeInformante.Size = New System.Drawing.Size(447, 18)
    Me.txtSpcNomeInformante.TabIndex = 139
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.BackColor = System.Drawing.Color.Transparent
    Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label2.Location = New System.Drawing.Point(7, 50)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(151, 18)
    Me.Label2.TabIndex = 140
    Me.Label2.Text = "Nome do Informante"
    '
    'txtSpcControleInformante
    '
    Me.txtSpcControleInformante.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtSpcControleInformante.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtSpcControleInformante.Location = New System.Drawing.Point(523, 22)
    Me.txtSpcControleInformante.MaxLength = 10
    Me.txtSpcControleInformante.Name = "txtSpcControleInformante"
    Me.txtSpcControleInformante.Size = New System.Drawing.Size(94, 18)
    Me.txtSpcControleInformante.TabIndex = 141
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.BackColor = System.Drawing.Color.Transparent
    Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label3.Location = New System.Drawing.Point(345, 22)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(172, 18)
    Me.Label3.TabIndex = 142
    Me.Label3.Text = "Controle do Informante"
    '
    'fLojaForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(739, 513)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.txtRamal)
    Me.Controls.Add(Me.txtTelefone)
    Me.Controls.Add(Me.txtDDD)
    Me.Controls.Add(Me.txtCep)
    Me.Controls.Add(Me.txtNumero)
    Me.Controls.Add(Me.txtCnpj)
    Me.Controls.Add(Me.txtContato)
    Me.Controls.Add(Me.txtCidade)
    Me.Controls.Add(Me.txtBairro)
    Me.Controls.Add(Me.txtComplemento)
    Me.Controls.Add(Me.txtLogradouro)
    Me.Controls.Add(Me.txtRazaoSocial)
    Me.Controls.Add(Me.txtNomeFantasia)
    Me.Controls.Add(Me.txtCodigo)
    Me.Controls.Add(Me.btoExcluir)
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
    Me.Controls.Add(Me.btoSalvar)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.btoFiltro)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.cboEstado)
    Me.Controls.Add(Me.lblEstado)
    Me.Controls.Add(Me.cboSituacao)
    Me.Controls.Add(Me.lblSituacao)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.lblLogradouro)
    Me.Controls.Add(Me.lblNome)
    Me.Controls.Add(Me.lblCodigo)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fLojaForm"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Loja"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents txtContato As System.Windows.Forms.TextBox
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents btoExcluir As System.Windows.Forms.Button
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents btoFiltro As System.Windows.Forms.Button
  Friend WithEvents txtCidade As System.Windows.Forms.TextBox
  Friend WithEvents txtBairro As System.Windows.Forms.TextBox
  Friend WithEvents txtComplemento As System.Windows.Forms.TextBox
  Friend WithEvents txtLogradouro As System.Windows.Forms.TextBox
  Friend WithEvents txtRazaoSocial As System.Windows.Forms.TextBox
  Friend WithEvents txtNomeFantasia As System.Windows.Forms.TextBox
  Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
  Friend WithEvents lblContato As System.Windows.Forms.Label
  Friend WithEvents lblRamal As System.Windows.Forms.Label
  Friend WithEvents lblTelefone As System.Windows.Forms.Label
  Friend WithEvents lblDDD As System.Windows.Forms.Label
  Friend WithEvents lblInscricaoEstadual As System.Windows.Forms.Label
  Friend WithEvents lblCnpj As System.Windows.Forms.Label
  Friend WithEvents lblCEP As System.Windows.Forms.Label
  Friend WithEvents lblCidade As System.Windows.Forms.Label
  Friend WithEvents lblBairro As System.Windows.Forms.Label
  Friend WithEvents lblComplemento As System.Windows.Forms.Label
  Friend WithEvents lblNumero As System.Windows.Forms.Label
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
  Friend WithEvents lblEstado As System.Windows.Forms.Label
  Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
  Friend WithEvents lblSituacao As System.Windows.Forms.Label
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents lblLogradouro As System.Windows.Forms.Label
  Friend WithEvents lblNome As System.Windows.Forms.Label
  Friend WithEvents lblCodigo As System.Windows.Forms.Label
  Friend WithEvents txtCnpj As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtNumero As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtCep As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtDDD As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtTelefone As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtRamal As System.Windows.Forms.MaskedTextBox
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents txtSpcControleInformante As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtSpcNomeInformante As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtSpcCodigoAssociado As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
