<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fUsuarioFiltro
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
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.txtNomeCompleto = New System.Windows.Forms.TextBox
    Me.txtUsuario = New System.Windows.Forms.TextBox
    Me.cboPerfil = New System.Windows.Forms.ComboBox
    Me.lblPerfil = New System.Windows.Forms.Label
    Me.cboSituacao = New System.Windows.Forms.ComboBox
    Me.lblSituacao = New System.Windows.Forms.Label
    Me.lblNomeCompleto = New System.Windows.Forms.Label
    Me.lblUsuario = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.btoCadastro = New System.Windows.Forms.Button
    Me.btoPesquisar = New System.Windows.Forms.Button
    Me.btoSair = New System.Windows.Forms.Button
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'lblTitulo
    '
    Me.lblTitulo.AutoSize = True
    Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblTitulo.Location = New System.Drawing.Point(64, 8)
    Me.lblTitulo.Name = "lblTitulo"
    Me.lblTitulo.Size = New System.Drawing.Size(99, 24)
    Me.lblTitulo.TabIndex = 27
    Me.lblTitulo.Text = "Usuários"
    '
    'txtNomeCompleto
    '
    Me.txtNomeCompleto.BackColor = System.Drawing.Color.White
    Me.txtNomeCompleto.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtNomeCompleto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtNomeCompleto.Location = New System.Drawing.Point(144, 112)
    Me.txtNomeCompleto.MaxLength = 100
    Me.txtNomeCompleto.Name = "txtNomeCompleto"
    Me.txtNomeCompleto.Size = New System.Drawing.Size(440, 18)
    Me.txtNomeCompleto.TabIndex = 2
    '
    'txtUsuario
    '
    Me.txtUsuario.BackColor = System.Drawing.Color.White
    Me.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtUsuario.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtUsuario.Location = New System.Drawing.Point(144, 84)
    Me.txtUsuario.MaxLength = 20
    Me.txtUsuario.Name = "txtUsuario"
    Me.txtUsuario.Size = New System.Drawing.Size(136, 18)
    Me.txtUsuario.TabIndex = 1
    '
    'cboPerfil
    '
    Me.cboPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboPerfil.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboPerfil.FormattingEnabled = True
    Me.cboPerfil.Location = New System.Drawing.Point(144, 140)
    Me.cboPerfil.Name = "cboPerfil"
    Me.cboPerfil.Size = New System.Drawing.Size(144, 24)
    Me.cboPerfil.TabIndex = 3
    '
    'lblPerfil
    '
    Me.lblPerfil.AutoSize = True
    Me.lblPerfil.BackColor = System.Drawing.Color.Transparent
    Me.lblPerfil.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblPerfil.ForeColor = System.Drawing.Color.Black
    Me.lblPerfil.Location = New System.Drawing.Point(88, 144)
    Me.lblPerfil.Name = "lblPerfil"
    Me.lblPerfil.Size = New System.Drawing.Size(46, 18)
    Me.lblPerfil.TabIndex = 34
    Me.lblPerfil.Text = "Perfil"
    '
    'cboSituacao
    '
    Me.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboSituacao.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboSituacao.FormattingEnabled = True
    Me.cboSituacao.Location = New System.Drawing.Point(144, 172)
    Me.cboSituacao.Name = "cboSituacao"
    Me.cboSituacao.Size = New System.Drawing.Size(100, 24)
    Me.cboSituacao.TabIndex = 4
    '
    'lblSituacao
    '
    Me.lblSituacao.AutoSize = True
    Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
    Me.lblSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblSituacao.ForeColor = System.Drawing.Color.Black
    Me.lblSituacao.Location = New System.Drawing.Point(64, 176)
    Me.lblSituacao.Name = "lblSituacao"
    Me.lblSituacao.Size = New System.Drawing.Size(69, 18)
    Me.lblSituacao.TabIndex = 33
    Me.lblSituacao.Text = "Situação"
    '
    'lblNomeCompleto
    '
    Me.lblNomeCompleto.AutoSize = True
    Me.lblNomeCompleto.BackColor = System.Drawing.Color.Transparent
    Me.lblNomeCompleto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblNomeCompleto.ForeColor = System.Drawing.Color.Black
    Me.lblNomeCompleto.Location = New System.Drawing.Point(12, 112)
    Me.lblNomeCompleto.Name = "lblNomeCompleto"
    Me.lblNomeCompleto.Size = New System.Drawing.Size(121, 18)
    Me.lblNomeCompleto.TabIndex = 32
    Me.lblNomeCompleto.Text = "Nome Completo"
    '
    'lblUsuario
    '
    Me.lblUsuario.AutoSize = True
    Me.lblUsuario.BackColor = System.Drawing.Color.Transparent
    Me.lblUsuario.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblUsuario.ForeColor = System.Drawing.Color.Black
    Me.lblUsuario.Location = New System.Drawing.Point(72, 84)
    Me.lblUsuario.Name = "lblUsuario"
    Me.lblUsuario.Size = New System.Drawing.Size(63, 18)
    Me.lblUsuario.TabIndex = 31
    Me.lblUsuario.Text = "Usuário"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.Label1.Location = New System.Drawing.Point(64, 32)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(45, 14)
    Me.Label1.TabIndex = 39
    Me.Label1.Text = "FILTRO"
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
    Me.btoCadastro.Location = New System.Drawing.Point(604, 80)
    Me.btoCadastro.Name = "btoCadastro"
    Me.btoCadastro.Size = New System.Drawing.Size(92, 72)
    Me.btoCadastro.TabIndex = 7
    Me.btoCadastro.TabStop = False
    Me.btoCadastro.Text = "Incluir <F5>"
    Me.btoCadastro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoCadastro, "Cadastro")
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
    Me.btoPesquisar.Location = New System.Drawing.Point(308, 216)
    Me.btoPesquisar.Margin = New System.Windows.Forms.Padding(0)
    Me.btoPesquisar.Name = "btoPesquisar"
    Me.btoPesquisar.Size = New System.Drawing.Size(115, 75)
    Me.btoPesquisar.TabIndex = 5
    Me.btoPesquisar.TabStop = False
    Me.btoPesquisar.Text = "Pesquisar <Enter>"
    Me.btoPesquisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoPesquisar, "Pesquisar")
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
    Me.btoSair.Location = New System.Drawing.Point(604, 4)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(92, 72)
    Me.btoSair.TabIndex = 6
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
    Me.imgLogo.TabIndex = 26
    Me.imgLogo.TabStop = False
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(697, 297)
    Me.Panel1.TabIndex = 40
    '
    'fUsuarioFiltro
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.ClientSize = New System.Drawing.Size(697, 297)
    Me.Controls.Add(Me.txtNomeCompleto)
    Me.Controls.Add(Me.txtUsuario)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.btoCadastro)
    Me.Controls.Add(Me.btoPesquisar)
    Me.Controls.Add(Me.cboPerfil)
    Me.Controls.Add(Me.lblPerfil)
    Me.Controls.Add(Me.cboSituacao)
    Me.Controls.Add(Me.lblSituacao)
    Me.Controls.Add(Me.lblNomeCompleto)
    Me.Controls.Add(Me.lblUsuario)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fUsuarioFiltro"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Usuários"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents btoPesquisar As System.Windows.Forms.Button
  Friend WithEvents txtNomeCompleto As System.Windows.Forms.TextBox
  Friend WithEvents cboPerfil As System.Windows.Forms.ComboBox
    Friend WithEvents lblPerfil As System.Windows.Forms.Label
    Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
    Friend WithEvents lblSituacao As System.Windows.Forms.Label
    Friend WithEvents lblNomeCompleto As System.Windows.Forms.Label
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
  Friend WithEvents btoCadastro As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
