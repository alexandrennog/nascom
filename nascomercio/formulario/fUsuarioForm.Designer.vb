<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fUsuarioForm
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
    Me.txtUsuario = New System.Windows.Forms.TextBox
    Me.lblUsuario = New System.Windows.Forms.Label
    Me.lblSenha = New System.Windows.Forms.Label
    Me.lblNomeCompleto = New System.Windows.Forms.Label
    Me.lblSituacao = New System.Windows.Forms.Label
    Me.cboSituacao = New System.Windows.Forms.ComboBox
    Me.cboPerfil = New System.Windows.Forms.ComboBox
    Me.lblPerfil = New System.Windows.Forms.Label
    Me.txtSenha = New System.Windows.Forms.TextBox
    Me.txtNomeCompleto = New System.Windows.Forms.TextBox
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.txtConfirmacao = New System.Windows.Forms.TextBox
    Me.lblConfirmacao = New System.Windows.Forms.Label
    Me.btoFiltro = New System.Windows.Forms.Button
    Me.btoExcluir = New System.Windows.Forms.Button
    Me.btoSair = New System.Windows.Forms.Button
    Me.txtDescontoPedido = New System.Windows.Forms.TextBox
    Me.txtDescontoProduto = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.btoSalvar = New System.Windows.Forms.Button
    Me.txtComissao = New System.Windows.Forms.TextBox
    Me.lblComissao = New System.Windows.Forms.Label
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'txtUsuario
    '
    Me.txtUsuario.BackColor = System.Drawing.Color.White
    Me.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtUsuario.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtUsuario.Location = New System.Drawing.Point(136, 80)
    Me.txtUsuario.MaxLength = 20
    Me.txtUsuario.Name = "txtUsuario"
    Me.txtUsuario.Size = New System.Drawing.Size(131, 18)
    Me.txtUsuario.TabIndex = 1
    '
    'lblUsuario
    '
    Me.lblUsuario.AutoSize = True
    Me.lblUsuario.BackColor = System.Drawing.Color.Transparent
    Me.lblUsuario.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblUsuario.Location = New System.Drawing.Point(68, 80)
    Me.lblUsuario.Name = "lblUsuario"
    Me.lblUsuario.Size = New System.Drawing.Size(63, 18)
    Me.lblUsuario.TabIndex = 1
    Me.lblUsuario.Text = "Usuário"
    '
    'lblSenha
    '
    Me.lblSenha.AutoSize = True
    Me.lblSenha.BackColor = System.Drawing.Color.Transparent
    Me.lblSenha.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblSenha.Location = New System.Drawing.Point(76, 128)
    Me.lblSenha.Name = "lblSenha"
    Me.lblSenha.Size = New System.Drawing.Size(53, 18)
    Me.lblSenha.TabIndex = 3
    Me.lblSenha.Text = "Senha"
    '
    'lblNomeCompleto
    '
    Me.lblNomeCompleto.AutoSize = True
    Me.lblNomeCompleto.BackColor = System.Drawing.Color.Transparent
    Me.lblNomeCompleto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblNomeCompleto.Location = New System.Drawing.Point(8, 104)
    Me.lblNomeCompleto.Name = "lblNomeCompleto"
    Me.lblNomeCompleto.Size = New System.Drawing.Size(121, 18)
    Me.lblNomeCompleto.TabIndex = 5
    Me.lblNomeCompleto.Text = "Nome Completo"
    '
    'lblSituacao
    '
    Me.lblSituacao.AutoSize = True
    Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
    Me.lblSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblSituacao.Location = New System.Drawing.Point(60, 208)
    Me.lblSituacao.Name = "lblSituacao"
    Me.lblSituacao.Size = New System.Drawing.Size(69, 18)
    Me.lblSituacao.TabIndex = 8
    Me.lblSituacao.Text = "Situação"
    '
    'cboSituacao
    '
    Me.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboSituacao.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboSituacao.FormattingEnabled = True
    Me.cboSituacao.Location = New System.Drawing.Point(136, 204)
    Me.cboSituacao.Name = "cboSituacao"
    Me.cboSituacao.Size = New System.Drawing.Size(132, 24)
    Me.cboSituacao.TabIndex = 6
    '
    'cboPerfil
    '
    Me.cboPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboPerfil.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboPerfil.FormattingEnabled = True
    Me.cboPerfil.Location = New System.Drawing.Point(136, 176)
    Me.cboPerfil.Name = "cboPerfil"
    Me.cboPerfil.Size = New System.Drawing.Size(172, 24)
    Me.cboPerfil.TabIndex = 5
    '
    'lblPerfil
    '
    Me.lblPerfil.AutoSize = True
    Me.lblPerfil.BackColor = System.Drawing.Color.Transparent
    Me.lblPerfil.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblPerfil.Location = New System.Drawing.Point(84, 180)
    Me.lblPerfil.Name = "lblPerfil"
    Me.lblPerfil.Size = New System.Drawing.Size(46, 18)
    Me.lblPerfil.TabIndex = 10
    Me.lblPerfil.Text = "Perfil"
    '
    'txtSenha
    '
    Me.txtSenha.BackColor = System.Drawing.Color.White
    Me.txtSenha.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtSenha.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtSenha.Location = New System.Drawing.Point(136, 128)
    Me.txtSenha.MaxLength = 20
    Me.txtSenha.Name = "txtSenha"
    Me.txtSenha.Size = New System.Drawing.Size(131, 18)
    Me.txtSenha.TabIndex = 3
    Me.txtSenha.UseSystemPasswordChar = True
    '
    'txtNomeCompleto
    '
    Me.txtNomeCompleto.BackColor = System.Drawing.Color.White
    Me.txtNomeCompleto.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtNomeCompleto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtNomeCompleto.Location = New System.Drawing.Point(136, 104)
    Me.txtNomeCompleto.MaxLength = 100
    Me.txtNomeCompleto.Name = "txtNomeCompleto"
    Me.txtNomeCompleto.Size = New System.Drawing.Size(466, 18)
    Me.txtNomeCompleto.TabIndex = 2
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
    Me.lblSubTitulo.TabIndex = 42
    Me.lblSubTitulo.Text = "CADASTRO"
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
    Me.lblTitulo.TabIndex = 41
    Me.lblTitulo.Text = "Usuários"
    '
    'txtConfirmacao
    '
    Me.txtConfirmacao.BackColor = System.Drawing.Color.White
    Me.txtConfirmacao.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtConfirmacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtConfirmacao.Location = New System.Drawing.Point(136, 152)
    Me.txtConfirmacao.MaxLength = 20
    Me.txtConfirmacao.Name = "txtConfirmacao"
    Me.txtConfirmacao.Size = New System.Drawing.Size(131, 18)
    Me.txtConfirmacao.TabIndex = 4
    Me.txtConfirmacao.UseSystemPasswordChar = True
    '
    'lblConfirmacao
    '
    Me.lblConfirmacao.AutoSize = True
    Me.lblConfirmacao.BackColor = System.Drawing.Color.Transparent
    Me.lblConfirmacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblConfirmacao.Location = New System.Drawing.Point(32, 152)
    Me.lblConfirmacao.Name = "lblConfirmacao"
    Me.lblConfirmacao.Size = New System.Drawing.Size(97, 18)
    Me.lblConfirmacao.TabIndex = 43
    Me.lblConfirmacao.Text = "Confirmação"
    '
    'btoFiltro
    '
    Me.btoFiltro.BackColor = System.Drawing.Color.Transparent
    Me.btoFiltro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
    Me.btoFiltro.FlatAppearance.BorderSize = 0
    Me.btoFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoFiltro.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
    Me.btoFiltro.ForeColor = System.Drawing.Color.Black
    Me.btoFiltro.Image = Global.nascomercio.My.Resources.Resources.pesquisar
    Me.btoFiltro.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoFiltro.Location = New System.Drawing.Point(621, 80)
    Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
    Me.btoFiltro.Name = "btoFiltro"
    Me.btoFiltro.Size = New System.Drawing.Size(99, 72)
    Me.btoFiltro.TabIndex = 11
    Me.btoFiltro.TabStop = False
    Me.btoFiltro.Text = "Pesquisar <F5>"
    Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoFiltro.UseVisualStyleBackColor = False
    '
    'btoExcluir
    '
    Me.btoExcluir.BackColor = System.Drawing.Color.Transparent
    Me.btoExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoExcluir.FlatAppearance.BorderSize = 0
    Me.btoExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoExcluir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
    Me.btoExcluir.ForeColor = System.Drawing.Color.Black
    Me.btoExcluir.Image = Global.nascomercio.My.Resources.Resources.excluir
    Me.btoExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoExcluir.Location = New System.Drawing.Point(364, 264)
    Me.btoExcluir.Margin = New System.Windows.Forms.Padding(0)
    Me.btoExcluir.Name = "btoExcluir"
    Me.btoExcluir.Size = New System.Drawing.Size(85, 73)
    Me.btoExcluir.TabIndex = 13
    Me.btoExcluir.TabStop = False
    Me.btoExcluir.Text = "Excluir <F12>"
    Me.btoExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoExcluir.UseVisualStyleBackColor = False
    '
    'btoSair
    '
    Me.btoSair.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.btoSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
    Me.btoSair.FlatAppearance.BorderSize = 0
    Me.btoSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoSair.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
    Me.btoSair.ForeColor = System.Drawing.Color.Black
    Me.btoSair.Image = Global.nascomercio.My.Resources.Resources.fechar
    Me.btoSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoSair.Location = New System.Drawing.Point(623, 4)
    Me.btoSair.Margin = New System.Windows.Forms.Padding(0)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(96, 71)
    Me.btoSair.TabIndex = 10
    Me.btoSair.TabStop = False
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSair.UseVisualStyleBackColor = False
    '
    'txtDescontoPedido
    '
    Me.txtDescontoPedido.BackColor = System.Drawing.Color.White
    Me.txtDescontoPedido.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDescontoPedido.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtDescontoPedido.Location = New System.Drawing.Point(472, 152)
    Me.txtDescontoPedido.MaxLength = 6
    Me.txtDescontoPedido.Name = "txtDescontoPedido"
    Me.txtDescontoPedido.Size = New System.Drawing.Size(131, 18)
    Me.txtDescontoPedido.TabIndex = 8
    '
    'txtDescontoProduto
    '
    Me.txtDescontoProduto.BackColor = System.Drawing.Color.White
    Me.txtDescontoProduto.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDescontoProduto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtDescontoProduto.Location = New System.Drawing.Point(472, 128)
    Me.txtDescontoProduto.MaxLength = 6
    Me.txtDescontoProduto.Name = "txtDescontoProduto"
    Me.txtDescontoProduto.Size = New System.Drawing.Size(131, 18)
    Me.txtDescontoProduto.TabIndex = 7
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label1.Location = New System.Drawing.Point(292, 128)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(173, 18)
    Me.Label1.TabIndex = 45
    Me.Label1.Text = "Desc. Max. Produto (%)"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.BackColor = System.Drawing.Color.Transparent
    Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label2.Location = New System.Drawing.Point(300, 152)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(166, 18)
    Me.Label2.TabIndex = 47
    Me.Label2.Text = "Desc. Max. Pedido (%)"
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.usuario
    Me.imgLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 40
    Me.imgLogo.TabStop = False
    '
    'btoSalvar
    '
    Me.btoSalvar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.btoSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoSalvar.FlatAppearance.BorderSize = 0
    Me.btoSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoSalvar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
    Me.btoSalvar.ForeColor = System.Drawing.Color.Black
    Me.btoSalvar.Image = Global.nascomercio.My.Resources.Resources.confirmar
    Me.btoSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoSalvar.Location = New System.Drawing.Point(268, 264)
    Me.btoSalvar.Margin = New System.Windows.Forms.Padding(0)
    Me.btoSalvar.Name = "btoSalvar"
    Me.btoSalvar.Size = New System.Drawing.Size(92, 73)
    Me.btoSalvar.TabIndex = 12
    Me.btoSalvar.TabStop = False
    Me.btoSalvar.Text = "Salvar <Enter>"
    Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSalvar.UseVisualStyleBackColor = False
    '
    'txtComissao
    '
    Me.txtComissao.BackColor = System.Drawing.Color.White
    Me.txtComissao.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtComissao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtComissao.Location = New System.Drawing.Point(472, 176)
    Me.txtComissao.MaxLength = 6
    Me.txtComissao.Name = "txtComissao"
    Me.txtComissao.Size = New System.Drawing.Size(131, 18)
    Me.txtComissao.TabIndex = 9
    '
    'lblComissao
    '
    Me.lblComissao.AutoSize = True
    Me.lblComissao.BackColor = System.Drawing.Color.Transparent
    Me.lblComissao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblComissao.Location = New System.Drawing.Point(364, 176)
    Me.lblComissao.Name = "lblComissao"
    Me.lblComissao.Size = New System.Drawing.Size(104, 18)
    Me.lblComissao.TabIndex = 49
    Me.lblComissao.Text = "Comissão (%)"
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(723, 342)
    Me.Panel1.TabIndex = 50
    '
    'fUsuarioForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
    Me.ClientSize = New System.Drawing.Size(723, 342)
    Me.Controls.Add(Me.txtComissao)
    Me.Controls.Add(Me.lblComissao)
    Me.Controls.Add(Me.txtDescontoPedido)
    Me.Controls.Add(Me.txtDescontoProduto)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.btoFiltro)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.btoExcluir)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.txtNomeCompleto)
    Me.Controls.Add(Me.btoSalvar)
    Me.Controls.Add(Me.lblNomeCompleto)
    Me.Controls.Add(Me.lblUsuario)
    Me.Controls.Add(Me.cboPerfil)
    Me.Controls.Add(Me.txtConfirmacao)
    Me.Controls.Add(Me.lblPerfil)
    Me.Controls.Add(Me.txtUsuario)
    Me.Controls.Add(Me.cboSituacao)
    Me.Controls.Add(Me.txtSenha)
    Me.Controls.Add(Me.lblSituacao)
    Me.Controls.Add(Me.lblSenha)
    Me.Controls.Add(Me.lblConfirmacao)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fUsuarioForm"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Usuários"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
  Friend WithEvents lblUsuario As System.Windows.Forms.Label
  Friend WithEvents lblSenha As System.Windows.Forms.Label
  Friend WithEvents lblNomeCompleto As System.Windows.Forms.Label
  Friend WithEvents lblSituacao As System.Windows.Forms.Label
  Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
  Friend WithEvents cboPerfil As System.Windows.Forms.ComboBox
  Friend WithEvents lblPerfil As System.Windows.Forms.Label
  Friend WithEvents txtSenha As System.Windows.Forms.TextBox
  Friend WithEvents txtNomeCompleto As System.Windows.Forms.TextBox
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents txtConfirmacao As System.Windows.Forms.TextBox
  Friend WithEvents lblConfirmacao As System.Windows.Forms.Label
  Friend WithEvents btoFiltro As System.Windows.Forms.Button
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents btoExcluir As System.Windows.Forms.Button
  Friend WithEvents txtDescontoPedido As System.Windows.Forms.TextBox
  Friend WithEvents txtDescontoProduto As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents txtComissao As System.Windows.Forms.TextBox
  Friend WithEvents lblComissao As System.Windows.Forms.Label
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
