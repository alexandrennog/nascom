<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fParametros
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
        Me.btoSair = New System.Windows.Forms.Button()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.txtJuros = New System.Windows.Forms.TextBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTolerancia = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btoSalvar = New System.Windows.Forms.Button()
        Me.cboIncluir = New System.Windows.Forms.ComboBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.txtTempoParcela = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtMinimoNegativar = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboQuantidade = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboTamanho = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboEtiqueta = New System.Windows.Forms.ComboBox()
        Me.cboSegundaVia = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboCortar = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboCupom = New System.Windows.Forms.ComboBox()
        Me.txtMensagem = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboVenda = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboLojaGrande = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboEhDecimal = New System.Windows.Forms.ComboBox()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.btoSair.Location = New System.Drawing.Point(672, 4)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(88, 72)
        Me.btoSair.TabIndex = 93
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
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
        Me.lblSubTitulo.TabIndex = 91
        Me.lblSubTitulo.Text = "CADASTRO"
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.ferramentas1
        Me.imgLogo.Location = New System.Drawing.Point(8, 8)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 90
        Me.imgLogo.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(64, 8)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(127, 24)
        Me.lblTitulo.TabIndex = 89
        Me.lblTitulo.Text = "Parâmetros"
        '
        'txtJuros
        '
        Me.txtJuros.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtJuros.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJuros.Location = New System.Drawing.Point(145, 8)
        Me.txtJuros.MaxLength = 20
        Me.txtJuros.Name = "txtJuros"
        Me.txtJuros.Size = New System.Drawing.Size(48, 18)
        Me.txtJuros.TabIndex = 94
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblCodigo.Location = New System.Drawing.Point(39, 8)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(100, 18)
        Me.lblCodigo.TabIndex = 95
        Me.lblCodigo.Text = "Juros diários"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(63, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 18)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Crediário:"
        '
        'txtTolerancia
        '
        Me.txtTolerancia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTolerancia.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTolerancia.Location = New System.Drawing.Point(145, 40)
        Me.txtTolerancia.MaxLength = 20
        Me.txtTolerancia.Name = "txtTolerancia"
        Me.txtTolerancia.Size = New System.Drawing.Size(48, 18)
        Me.txtTolerancia.TabIndex = 97
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(24, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 18)
        Me.Label2.TabIndex = 98
        Me.Label2.Text = "Tolerância dias"
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
        Me.btoSalvar.Location = New System.Drawing.Point(330, 422)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(92, 72)
        Me.btoSalvar.TabIndex = 99
        Me.btoSalvar.TabStop = False
        Me.btoSalvar.Text = "Salvar <Enter>"
        Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSalvar.UseVisualStyleBackColor = False
        '
        'cboIncluir
        '
        Me.cboIncluir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboIncluir.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboIncluir.FormattingEnabled = True
        Me.cboIncluir.Items.AddRange(New Object() {"Sim", "Não"})
        Me.cboIncluir.Location = New System.Drawing.Point(376, 40)
        Me.cboIncluir.Name = "cboIncluir"
        Me.cboIncluir.Size = New System.Drawing.Size(62, 26)
        Me.cboIncluir.TabIndex = 100
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblEstado.Location = New System.Drawing.Point(199, 40)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(171, 18)
        Me.lblEstado.TabIndex = 101
        Me.lblEstado.Text = "Cobrar juros tolerância"
        '
        'txtTempoParcela
        '
        Me.txtTempoParcela.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTempoParcela.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTempoParcela.Location = New System.Drawing.Point(145, 72)
        Me.txtTempoParcela.MaxLength = 20
        Me.txtTempoParcela.Name = "txtTempoParcela"
        Me.txtTempoParcela.Size = New System.Drawing.Size(48, 18)
        Me.txtTempoParcela.TabIndex = 102
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(9, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 18)
        Me.Label3.TabIndex = 103
        Me.Label3.Text = "Tempo 1º Parcela"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtMinimoNegativar)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtJuros)
        Me.Panel1.Controls.Add(Me.txtTempoParcela)
        Me.Panel1.Controls.Add(Me.lblCodigo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cboIncluir)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblEstado)
        Me.Panel1.Controls.Add(Me.txtTolerancia)
        Me.Panel1.Location = New System.Drawing.Point(63, 87)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(631, 100)
        Me.Panel1.TabIndex = 104
        '
        'txtMinimoNegativar
        '
        Me.txtMinimoNegativar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMinimoNegativar.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinimoNegativar.Location = New System.Drawing.Point(376, 72)
        Me.txtMinimoNegativar.MaxLength = 20
        Me.txtMinimoNegativar.Name = "txtMinimoNegativar"
        Me.txtMinimoNegativar.Size = New System.Drawing.Size(48, 18)
        Me.txtMinimoNegativar.TabIndex = 104
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(199, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 18)
        Me.Label6.TabIndex = 105
        Me.Label6.Text = "Valor mínimo negativar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(71, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(216, 18)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "Informar quantidade no caixa:"
        '
        'cboQuantidade
        '
        Me.cboQuantidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboQuantidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboQuantidade.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboQuantidade.FormattingEnabled = True
        Me.cboQuantidade.Items.AddRange(New Object() {"Sim", "Não"})
        Me.cboQuantidade.Location = New System.Drawing.Point(297, 196)
        Me.cboQuantidade.Name = "cboQuantidade"
        Me.cboQuantidade.Size = New System.Drawing.Size(62, 26)
        Me.cboQuantidade.TabIndex = 107
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.cboEhDecimal)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.cboTamanho)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.cboEtiqueta)
        Me.Panel2.Controls.Add(Me.cboSegundaVia)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.cboCortar)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.cboCupom)
        Me.Panel2.Controls.Add(Me.txtMensagem)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.cboVenda)
        Me.Panel2.Controls.Add(Me.btoSalvar)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.cboQuantidade)
        Me.Panel2.Controls.Add(Me.cboLojaGrande)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(1, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(761, 499)
        Me.Panel2.TabIndex = 108
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(315, 295)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(138, 18)
        Me.Label13.TabIndex = 126
        Me.Label13.Text = "Tamanho etiqueta:"
        '
        'cboTamanho
        '
        Me.cboTamanho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTamanho.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTamanho.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboTamanho.FormattingEnabled = True
        Me.cboTamanho.Items.AddRange(New Object() {"40x25", "50x70"})
        Me.cboTamanho.Location = New System.Drawing.Point(459, 292)
        Me.cboTamanho.Name = "cboTamanho"
        Me.cboTamanho.Size = New System.Drawing.Size(130, 26)
        Me.cboTamanho.TabIndex = 125
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(71, 295)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(153, 18)
        Me.Label12.TabIndex = 124
        Me.Label12.Text = "Impressora etiqueta:"
        '
        'cboEtiqueta
        '
        Me.cboEtiqueta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEtiqueta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboEtiqueta.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboEtiqueta.FormattingEnabled = True
        Me.cboEtiqueta.Items.AddRange(New Object() {"", "LPT1", "LPT2", "USB1", "USB2", "LAZ"})
        Me.cboEtiqueta.Location = New System.Drawing.Point(230, 292)
        Me.cboEtiqueta.Name = "cboEtiqueta"
        Me.cboEtiqueta.Size = New System.Drawing.Size(79, 26)
        Me.cboEtiqueta.TabIndex = 123
        '
        'cboSegundaVia
        '
        Me.cboSegundaVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSegundaVia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSegundaVia.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboSegundaVia.FormattingEnabled = True
        Me.cboSegundaVia.Items.AddRange(New Object() {"Sim", "Não"})
        Me.cboSegundaVia.Location = New System.Drawing.Point(595, 260)
        Me.cboSegundaVia.Name = "cboSegundaVia"
        Me.cboSegundaVia.Size = New System.Drawing.Size(62, 26)
        Me.cboSegundaVia.TabIndex = 122
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(489, 263)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 18)
        Me.Label11.TabIndex = 121
        Me.Label11.Text = "Segunda via:"
        '
        'cboCortar
        '
        Me.cboCortar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCortar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCortar.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboCortar.FormattingEnabled = True
        Me.cboCortar.Items.AddRange(New Object() {"Sim", "Não"})
        Me.cboCortar.Location = New System.Drawing.Point(421, 260)
        Me.cboCortar.Name = "cboCortar"
        Me.cboCortar.Size = New System.Drawing.Size(62, 26)
        Me.cboCortar.TabIndex = 120
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(315, 263)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 18)
        Me.Label10.TabIndex = 119
        Me.Label10.Text = "Cortar papel:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(71, 263)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(142, 18)
        Me.Label8.TabIndex = 118
        Me.Label8.Text = "Impressora cupom:"
        '
        'cboCupom
        '
        Me.cboCupom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCupom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCupom.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboCupom.FormattingEnabled = True
        Me.cboCupom.Items.AddRange(New Object() {"", "LPT1", "LPT2", "USB1", "USB2", "LAZ"})
        Me.cboCupom.Location = New System.Drawing.Point(230, 260)
        Me.cboCupom.Name = "cboCupom"
        Me.cboCupom.Size = New System.Drawing.Size(79, 26)
        Me.cboCupom.TabIndex = 117
        '
        'txtMensagem
        '
        Me.txtMensagem.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMensagem.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensagem.Location = New System.Drawing.Point(64, 358)
        Me.txtMensagem.MaxLength = 250
        Me.txtMensagem.Multiline = True
        Me.txtMensagem.Name = "txtMensagem"
        Me.txtMensagem.Size = New System.Drawing.Size(626, 58)
        Me.txtMensagem.TabIndex = 115
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(64, 337)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(166, 18)
        Me.Label9.TabIndex = 116
        Me.Label9.Text = "Mensagem impressão:"
        '
        'cboVenda
        '
        Me.cboVenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVenda.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboVenda.FormattingEnabled = True
        Me.cboVenda.Items.AddRange(New Object() {"Sim", "Não"})
        Me.cboVenda.Location = New System.Drawing.Point(297, 228)
        Me.cboVenda.Name = "cboVenda"
        Me.cboVenda.Size = New System.Drawing.Size(62, 26)
        Me.cboVenda.TabIndex = 112
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(71, 231)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(220, 18)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "Fechar tela ao finalizar venda:"
        '
        'cboLojaGrande
        '
        Me.cboLojaGrande.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLojaGrande.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLojaGrande.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboLojaGrande.FormattingEnabled = True
        Me.cboLojaGrande.Items.AddRange(New Object() {"Sim", "Não"})
        Me.cboLojaGrande.Location = New System.Drawing.Point(595, 197)
        Me.cboLojaGrande.Name = "cboLojaGrande"
        Me.cboLojaGrande.Size = New System.Drawing.Size(62, 26)
        Me.cboLojaGrande.TabIndex = 110
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(383, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(206, 18)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Loja com terminal de venda:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(315, 332)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 18)
        Me.Label14.TabIndex = 128
        Me.Label14.Text = "Eh Decimal:"
        '
        'cboEhDecimal
        '
        Me.cboEhDecimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEhDecimal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboEhDecimal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboEhDecimal.FormattingEnabled = True
        Me.cboEhDecimal.Items.AddRange(New Object() {"Sim", "Não"})
        Me.cboEhDecimal.Location = New System.Drawing.Point(459, 324)
        Me.cboEhDecimal.Name = "cboEhDecimal"
        Me.cboEhDecimal.Size = New System.Drawing.Size(130, 26)
        Me.cboEhDecimal.TabIndex = 127
        '
        'fParametros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(763, 502)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fParametros"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produtos"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents txtJuros As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTolerancia As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btoSalvar As System.Windows.Forms.Button
    Friend WithEvents cboIncluir As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents txtTempoParcela As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboQuantidade As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cboLojaGrande As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMinimoNegativar As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboVenda As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMensagem As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboCupom As System.Windows.Forms.ComboBox
    Friend WithEvents cboSegundaVia As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboCortar As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboEtiqueta As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboTamanho As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cboEhDecimal As ComboBox
End Class
