<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fUsuarioPerfilForm
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
    Me.cboSituacao = New System.Windows.Forms.ComboBox
    Me.lblSituacao = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.lblNome = New System.Windows.Forms.Label
    Me.lblCodigo = New System.Windows.Forms.Label
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.btoExcluir = New System.Windows.Forms.Button
    Me.btoSalvar = New System.Windows.Forms.Button
    Me.btoFiltro = New System.Windows.Forms.Button
    Me.btoSair = New System.Windows.Forms.Button
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.txtNome = New System.Windows.Forms.TextBox
    Me.txtCodigo = New System.Windows.Forms.TextBox
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'cboSituacao
    '
    Me.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboSituacao.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    Me.cboSituacao.FormattingEnabled = True
    Me.cboSituacao.Location = New System.Drawing.Point(84, 124)
    Me.cboSituacao.Name = "cboSituacao"
    Me.cboSituacao.Size = New System.Drawing.Size(100, 24)
    Me.cboSituacao.TabIndex = 4
    '
    'lblSituacao
    '
    Me.lblSituacao.AutoSize = True
    Me.lblSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblSituacao.Location = New System.Drawing.Point(8, 128)
    Me.lblSituacao.Name = "lblSituacao"
    Me.lblSituacao.Size = New System.Drawing.Size(69, 18)
    Me.lblSituacao.TabIndex = 20
    Me.lblSituacao.Text = "Situação"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.BackColor = System.Drawing.Color.Transparent
    Me.Label4.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.Label4.Location = New System.Drawing.Point(64, 8)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(169, 24)
    Me.Label4.TabIndex = 19
    Me.Label4.Text = "Usuários - Perfil"
    '
    'lblNome
    '
    Me.lblNome.AutoSize = True
    Me.lblNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblNome.Location = New System.Drawing.Point(28, 100)
    Me.lblNome.Name = "lblNome"
    Me.lblNome.Size = New System.Drawing.Size(49, 18)
    Me.lblNome.TabIndex = 16
    Me.lblNome.Text = "Nome"
    '
    'lblCodigo
    '
    Me.lblCodigo.AutoSize = True
    Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCodigo.Location = New System.Drawing.Point(20, 76)
    Me.lblCodigo.Name = "lblCodigo"
    Me.lblCodigo.Size = New System.Drawing.Size(59, 18)
    Me.lblCodigo.TabIndex = 14
    Me.lblCodigo.Text = "Código"
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
    Me.btoExcluir.Location = New System.Drawing.Point(252, 184)
    Me.btoExcluir.Name = "btoExcluir"
    Me.btoExcluir.Size = New System.Drawing.Size(84, 74)
    Me.btoExcluir.TabIndex = 6
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
    Me.btoSalvar.Location = New System.Drawing.Point(153, 184)
    Me.btoSalvar.Name = "btoSalvar"
    Me.btoSalvar.Size = New System.Drawing.Size(95, 74)
    Me.btoSalvar.TabIndex = 5
    Me.btoSalvar.TabStop = False
    Me.btoSalvar.Text = "Salvar <Enter>"
    Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoSalvar, "Salvar")
    Me.btoSalvar.UseVisualStyleBackColor = False
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
    Me.btoFiltro.Location = New System.Drawing.Point(384, 80)
    Me.btoFiltro.Name = "btoFiltro"
    Me.btoFiltro.Size = New System.Drawing.Size(100, 72)
    Me.btoFiltro.TabIndex = 8
    Me.btoFiltro.TabStop = False
    Me.btoFiltro.Text = "Pesquisar <F5>"
    Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoFiltro, "Filtro")
    Me.btoFiltro.UseVisualStyleBackColor = False
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
    Me.btoSair.Location = New System.Drawing.Point(384, 4)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(100, 72)
    Me.btoSair.TabIndex = 7
    Me.btoSair.TabStop = False
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoSair, "Sair")
    Me.btoSair.UseVisualStyleBackColor = False
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.usuario
    Me.imgLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 41
    Me.imgLogo.TabStop = False
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
    Me.lblSubTitulo.TabIndex = 43
    Me.lblSubTitulo.Text = "CADASTRO"
    '
    'txtNome
    '
    Me.txtNome.BackColor = System.Drawing.Color.White
    Me.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtNome.Location = New System.Drawing.Point(84, 100)
    Me.txtNome.MaxLength = 20
    Me.txtNome.Name = "txtNome"
    Me.txtNome.Size = New System.Drawing.Size(253, 18)
    Me.txtNome.TabIndex = 3
    '
    'txtCodigo
    '
    Me.txtCodigo.BackColor = System.Drawing.Color.White
    Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtCodigo.Location = New System.Drawing.Point(84, 76)
    Me.txtCodigo.MaxLength = 3
    Me.txtCodigo.Name = "txtCodigo"
    Me.txtCodigo.Size = New System.Drawing.Size(100, 18)
    Me.txtCodigo.TabIndex = 2
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(485, 262)
    Me.Panel1.TabIndex = 44
    '
    'fUsuarioPerfilForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
    Me.ClientSize = New System.Drawing.Size(485, 262)
    Me.Controls.Add(Me.txtNome)
    Me.Controls.Add(Me.btoExcluir)
    Me.Controls.Add(Me.txtCodigo)
    Me.Controls.Add(Me.btoSalvar)
    Me.Controls.Add(Me.cboSituacao)
    Me.Controls.Add(Me.btoFiltro)
    Me.Controls.Add(Me.lblCodigo)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.lblNome)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.lblSituacao)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fUsuarioPerfilForm"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Usuários - Perfil"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
  Friend WithEvents lblSituacao As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents lblNome As System.Windows.Forms.Label
  Friend WithEvents lblCodigo As System.Windows.Forms.Label
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents btoExcluir As System.Windows.Forms.Button
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents btoFiltro As System.Windows.Forms.Button
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents txtNome As System.Windows.Forms.TextBox
  Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
