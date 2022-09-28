<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fServicoFiltro
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
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.cboSituacao = New System.Windows.Forms.ComboBox
    Me.lblSituacao = New System.Windows.Forms.Label
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.txtNome = New System.Windows.Forms.TextBox
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.btoCadastro = New System.Windows.Forms.Button
    Me.btoPesquisar = New System.Windows.Forms.Button
    Me.lblNome = New System.Windows.Forms.Label
    Me.btoSair = New System.Windows.Forms.Button
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.btoProdutos = New System.Windows.Forms.Button
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.txtValor = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'lblSubTitulo
    '
    Me.lblSubTitulo.AutoSize = True
    Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblSubTitulo.Location = New System.Drawing.Point(64, 33)
    Me.lblSubTitulo.Name = "lblSubTitulo"
    Me.lblSubTitulo.Size = New System.Drawing.Size(44, 14)
    Me.lblSubTitulo.TabIndex = 124
    Me.lblSubTitulo.Text = "FILTRO"
    '
    'cboSituacao
    '
    Me.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboSituacao.FormattingEnabled = True
    Me.cboSituacao.Location = New System.Drawing.Point(82, 127)
    Me.cboSituacao.Name = "cboSituacao"
    Me.cboSituacao.Size = New System.Drawing.Size(100, 26)
    Me.cboSituacao.TabIndex = 115
    '
    'lblSituacao
    '
    Me.lblSituacao.AutoSize = True
    Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
    Me.lblSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblSituacao.Location = New System.Drawing.Point(7, 130)
    Me.lblSituacao.Name = "lblSituacao"
    Me.lblSituacao.Size = New System.Drawing.Size(69, 18)
    Me.lblSituacao.TabIndex = 121
    Me.lblSituacao.Text = "Situação"
    '
    'lblTitulo
    '
    Me.lblTitulo.AutoSize = True
    Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblTitulo.Location = New System.Drawing.Point(64, 9)
    Me.lblTitulo.Name = "lblTitulo"
    Me.lblTitulo.Size = New System.Drawing.Size(99, 24)
    Me.lblTitulo.TabIndex = 120
    Me.lblTitulo.Text = "Serviços"
    '
    'txtNome
    '
    Me.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtNome.Location = New System.Drawing.Point(83, 80)
    Me.txtNome.MaxLength = 100
    Me.txtNome.Name = "txtNome"
    Me.txtNome.Size = New System.Drawing.Size(340, 18)
    Me.txtNome.TabIndex = 114
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
    Me.btoCadastro.Location = New System.Drawing.Point(484, 89)
    Me.btoCadastro.Name = "btoCadastro"
    Me.btoCadastro.Size = New System.Drawing.Size(96, 72)
    Me.btoCadastro.TabIndex = 118
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
    Me.btoPesquisar.Location = New System.Drawing.Point(160, 208)
    Me.btoPesquisar.Margin = New System.Windows.Forms.Padding(0)
    Me.btoPesquisar.Name = "btoPesquisar"
    Me.btoPesquisar.Size = New System.Drawing.Size(120, 76)
    Me.btoPesquisar.TabIndex = 116
    Me.btoPesquisar.TabStop = False
    Me.btoPesquisar.Text = "Pesquisar <Enter>"
    Me.btoPesquisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoPesquisar, "Pesquisar")
    Me.btoPesquisar.UseVisualStyleBackColor = False
    '
    'lblNome
    '
    Me.lblNome.AutoSize = True
    Me.lblNome.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblNome.Location = New System.Drawing.Point(28, 80)
    Me.lblNome.Name = "lblNome"
    Me.lblNome.Size = New System.Drawing.Size(49, 18)
    Me.lblNome.TabIndex = 122
    Me.lblNome.Text = "Nome"
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
    Me.btoSair.Location = New System.Drawing.Point(484, 11)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(96, 72)
    Me.btoSair.TabIndex = 117
    Me.btoSair.TabStop = False
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSair.UseVisualStyleBackColor = False
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.cliente_financeiro
    Me.imgLogo.Location = New System.Drawing.Point(8, 9)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 119
    Me.imgLogo.TabStop = False
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
    Me.btoProdutos.Location = New System.Drawing.Point(487, 164)
    Me.btoProdutos.Margin = New System.Windows.Forms.Padding(0)
    Me.btoProdutos.Name = "btoProdutos"
    Me.btoProdutos.Size = New System.Drawing.Size(96, 72)
    Me.btoProdutos.TabIndex = 125
    Me.btoProdutos.TabStop = False
    Me.btoProdutos.Text = "Produtos <F6>"
    Me.btoProdutos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoProdutos.UseVisualStyleBackColor = False
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Controls.Add(Me.txtValor)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Controls.Add(Me.btoProdutos)
    Me.Panel1.Controls.Add(Me.cboSituacao)
    Me.Panel1.Controls.Add(Me.lblSituacao)
    Me.Panel1.Controls.Add(Me.btoSair)
    Me.Panel1.Controls.Add(Me.btoCadastro)
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(592, 290)
    Me.Panel1.TabIndex = 126
    '
    'txtValor
    '
    Me.txtValor.BackColor = System.Drawing.Color.White
    Me.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtValor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtValor.Location = New System.Drawing.Point(82, 103)
    Me.txtValor.MaxLength = 6
    Me.txtValor.Name = "txtValor"
    Me.txtValor.Size = New System.Drawing.Size(131, 18)
    Me.txtValor.TabIndex = 126
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label1.Location = New System.Drawing.Point(27, 103)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(43, 18)
    Me.Label1.TabIndex = 127
    Me.Label1.Text = "Valor"
    '
    'fServicoFiltro
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(593, 290)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.btoPesquisar)
    Me.Controls.Add(Me.txtNome)
    Me.Controls.Add(Me.lblNome)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fServicoFiltro"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "fFabricanteFiltro"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
  Friend WithEvents lblSituacao As System.Windows.Forms.Label
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents btoCadastro As System.Windows.Forms.Button
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents btoPesquisar As System.Windows.Forms.Button
  Friend WithEvents txtNome As System.Windows.Forms.TextBox
  Friend WithEvents lblNome As System.Windows.Forms.Label
  Friend WithEvents btoProdutos As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
