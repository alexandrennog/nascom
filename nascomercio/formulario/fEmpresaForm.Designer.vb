<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fEmpresaForm
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
    Me.lblRazaoSocial = New System.Windows.Forms.Label
    Me.txtRazaoSocial = New System.Windows.Forms.TextBox
    Me.lblCnpj = New System.Windows.Forms.Label
    Me.txtCnpj = New System.Windows.Forms.MaskedTextBox
    Me.lblUf = New System.Windows.Forms.Label
    Me.cboUf = New System.Windows.Forms.ComboBox
    Me.lblCrt = New System.Windows.Forms.Label
    Me.cboCrt = New System.Windows.Forms.ComboBox
    Me.lblMunicipio = New System.Windows.Forms.Label
    Me.cboMunicipio = New System.Windows.Forms.ComboBox
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.btoFiltro = New System.Windows.Forms.Button
    Me.btoExcluir = New System.Windows.Forms.Button
    Me.btoSalvar = New System.Windows.Forms.Button
    Me.btoSair = New System.Windows.Forms.Button
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'lblRazaoSocial
    '
    Me.lblRazaoSocial.AutoSize = True
    Me.lblRazaoSocial.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblRazaoSocial.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblRazaoSocial.Location = New System.Drawing.Point(24, 80)
    Me.lblRazaoSocial.Name = "lblRazaoSocial"
    Me.lblRazaoSocial.Size = New System.Drawing.Size(112, 18)
    Me.lblRazaoSocial.TabIndex = 101
    Me.lblRazaoSocial.Text = "Raz�o Social"
    '
    'txtRazaoSocial
    '
    Me.txtRazaoSocial.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtRazaoSocial.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtRazaoSocial.Location = New System.Drawing.Point(140, 80)
    Me.txtRazaoSocial.MaxLength = 150
    Me.txtRazaoSocial.Name = "txtRazaoSocial"
    Me.txtRazaoSocial.Size = New System.Drawing.Size(332, 18)
    Me.txtRazaoSocial.TabIndex = 1
    '
    'lblCnpj
    '
    Me.lblCnpj.AutoSize = True
    Me.lblCnpj.BackColor = System.Drawing.Color.Transparent
    Me.lblCnpj.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCnpj.Location = New System.Drawing.Point(24, 104)
    Me.lblCnpj.Name = "lblCnpj"
    Me.lblCnpj.Size = New System.Drawing.Size(62, 18)
    Me.lblCnpj.TabIndex = 102
    Me.lblCnpj.Text = "CNPJ"
    '
    'txtCnpj
    '
    Me.txtCnpj.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCnpj.Culture = New System.Globalization.CultureInfo("")
    Me.txtCnpj.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtCnpj.Location = New System.Drawing.Point(140, 104)
    Me.txtCnpj.Mask = "00.000.000/0000-00"
    Me.txtCnpj.Name = "txtCnpj"
    Me.txtCnpj.Size = New System.Drawing.Size(164, 18)
    Me.txtCnpj.TabIndex = 2
    Me.txtCnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'lblUf
    '
    Me.lblUf.AutoSize = True
    Me.lblUf.BackColor = System.Drawing.Color.Transparent
    Me.lblUf.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblUf.Location = New System.Drawing.Point(320, 104)
    Me.lblUf.Name = "lblUf"
    Me.lblUf.Size = New System.Drawing.Size(30, 18)
    Me.lblUf.TabIndex = 103
    Me.lblUf.Text = "UF"
    '
    'cboUf
    '
    Me.cboUf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboUf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboUf.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboUf.FormattingEnabled = True
    Me.cboUf.Location = New System.Drawing.Point(352, 104)
    Me.cboUf.Name = "cboUf"
    Me.cboUf.Size = New System.Drawing.Size(120, 26)
    Me.cboUf.TabIndex = 3
    '
    'lblCrt
    '
    Me.lblCrt.AutoSize = True
    Me.lblCrt.BackColor = System.Drawing.Color.Transparent
    Me.lblCrt.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCrt.Location = New System.Drawing.Point(24, 132)
    Me.lblCrt.Name = "lblCrt"
    Me.lblCrt.Size = New System.Drawing.Size(40, 18)
    Me.lblCrt.TabIndex = 104
    Me.lblCrt.Text = "CRT"
    '
    'cboCrt
    '
    Me.cboCrt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboCrt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboCrt.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboCrt.FormattingEnabled = True
    Me.cboCrt.Location = New System.Drawing.Point(140, 132)
    Me.cboCrt.Name = "cboCrt"
    Me.cboCrt.Size = New System.Drawing.Size(332, 26)
    Me.cboCrt.TabIndex = 4
    '
    'lblMunicipio
    '
    Me.lblMunicipio.AutoSize = True
    Me.lblMunicipio.BackColor = System.Drawing.Color.Transparent
    Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblMunicipio.Location = New System.Drawing.Point(24, 160)
    Me.lblMunicipio.Name = "lblMunicipio"
    Me.lblMunicipio.Size = New System.Drawing.Size(94, 18)
    Me.lblMunicipio.TabIndex = 105
    Me.lblMunicipio.Text = "Munic�pio"
    '
    'cboMunicipio
    '
    Me.cboMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboMunicipio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboMunicipio.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboMunicipio.FormattingEnabled = True
    Me.cboMunicipio.Location = New System.Drawing.Point(140, 160)
    Me.cboMunicipio.Name = "cboMunicipio"
    Me.cboMunicipio.Size = New System.Drawing.Size(332, 26)
    Me.cboMunicipio.TabIndex = 5
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
    Me.lblSubTitulo.TabIndex = 99
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
    Me.lblTitulo.Size = New System.Drawing.Size(101, 24)
    Me.lblTitulo.TabIndex = 98
    Me.lblTitulo.Text = "Empresas"
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
    Me.btoFiltro.Location = New System.Drawing.Point(376, 194)
    Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
    Me.btoFiltro.Name = "btoFiltro"
    Me.btoFiltro.Size = New System.Drawing.Size(96, 72)
    Me.btoFiltro.TabIndex = 96
    Me.btoFiltro.TabStop = False
    Me.btoFiltro.Text = "Pesquisar <F5>"
    Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoFiltro, "Filtro")
    Me.btoFiltro.UseVisualStyleBackColor = False
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
    Me.btoExcluir.Location = New System.Drawing.Point(236, 194)
    Me.btoExcluir.Name = "btoExcluir"
    Me.btoExcluir.Size = New System.Drawing.Size(92, 72)
    Me.btoExcluir.TabIndex = 94
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
    Me.btoSalvar.Location = New System.Drawing.Point(140, 194)
    Me.btoSalvar.Name = "btoSalvar"
    Me.btoSalvar.Size = New System.Drawing.Size(92, 72)
    Me.btoSalvar.TabIndex = 93
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
    Me.btoSair.Location = New System.Drawing.Point(376, 8)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(96, 72)
    Me.btoSair.TabIndex = 95
    Me.btoSair.TabStop = False
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoSair, "Sair")
    Me.btoSair.UseVisualStyleBackColor = False
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.loja
    Me.imgLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 97
    Me.imgLogo.TabStop = False
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(480, 274)
    Me.Panel1.TabIndex = 106
    '
    'fEmpresaForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(480, 274)
    Me.Controls.Add(Me.btoFiltro)
    Me.Controls.Add(Me.btoExcluir)
    Me.Controls.Add(Me.btoSalvar)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.lblRazaoSocial)
    Me.Controls.Add(Me.txtRazaoSocial)
    Me.Controls.Add(Me.lblCnpj)
    Me.Controls.Add(Me.txtCnpj)
    Me.Controls.Add(Me.lblUf)
    Me.Controls.Add(Me.cboUf)
    Me.Controls.Add(Me.lblCrt)
    Me.Controls.Add(Me.cboCrt)
    Me.Controls.Add(Me.lblMunicipio)
    Me.Controls.Add(Me.cboMunicipio)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fEmpresaForm"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "fEmpresaForm"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lblRazaoSocial As System.Windows.Forms.Label
  Friend WithEvents txtRazaoSocial As System.Windows.Forms.TextBox
  Friend WithEvents lblCnpj As System.Windows.Forms.Label
  Friend WithEvents txtCnpj As System.Windows.Forms.MaskedTextBox
  Friend WithEvents lblUf As System.Windows.Forms.Label
  Friend WithEvents cboUf As System.Windows.Forms.ComboBox
  Friend WithEvents lblCrt As System.Windows.Forms.Label
  Friend WithEvents cboCrt As System.Windows.Forms.ComboBox
  Friend WithEvents lblMunicipio As System.Windows.Forms.Label
  Friend WithEvents cboMunicipio As System.Windows.Forms.ComboBox
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents btoFiltro As System.Windows.Forms.Button
  Friend WithEvents btoExcluir As System.Windows.Forms.Button
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
