<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fImportarArquivos
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
    Me.btoSair = New System.Windows.Forms.Button
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.rbtImportarCliente = New System.Windows.Forms.RadioButton
    Me.rbtImportarCrediario = New System.Windows.Forms.RadioButton
    Me.rbtImportarProduto = New System.Windows.Forms.RadioButton
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
    Me.btoFiltro = New System.Windows.Forms.Button
    Me.txtNome = New System.Windows.Forms.TextBox
    Me.lblNome = New System.Windows.Forms.Label
    Me.btoSalvar = New System.Windows.Forms.Button
    Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
    Me.rbtOutros = New System.Windows.Forms.RadioButton
    Me.rbtAbcd = New System.Windows.Forms.RadioButton
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.Panel2 = New System.Windows.Forms.Panel
    Me.Panel3 = New System.Windows.Forms.Panel
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
    Me.btoSair.Location = New System.Drawing.Point(672, 8)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(88, 72)
    Me.btoSair.TabIndex = 9
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
    Me.lblSubTitulo.Size = New System.Drawing.Size(39, 14)
    Me.lblSubTitulo.TabIndex = 91
    Me.lblSubTitulo.Text = "LISTA"
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
    Me.lblTitulo.Size = New System.Drawing.Size(193, 24)
    Me.lblTitulo.TabIndex = 89
    Me.lblTitulo.Text = "Importar Arquivos"
    '
    'rbtImportarCliente
    '
    Me.rbtImportarCliente.AutoSize = True
    Me.rbtImportarCliente.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.rbtImportarCliente.Location = New System.Drawing.Point(3, 3)
    Me.rbtImportarCliente.Name = "rbtImportarCliente"
    Me.rbtImportarCliente.Size = New System.Drawing.Size(244, 23)
    Me.rbtImportarCliente.TabIndex = 5
    Me.rbtImportarCliente.TabStop = True
    Me.rbtImportarCliente.Text = "Importar Arquivo de Clientes"
    Me.rbtImportarCliente.UseVisualStyleBackColor = True
    '
    'rbtImportarCrediario
    '
    Me.rbtImportarCrediario.AutoSize = True
    Me.rbtImportarCrediario.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.rbtImportarCrediario.Location = New System.Drawing.Point(3, 43)
    Me.rbtImportarCrediario.Name = "rbtImportarCrediario"
    Me.rbtImportarCrediario.Size = New System.Drawing.Size(252, 23)
    Me.rbtImportarCrediario.TabIndex = 6
    Me.rbtImportarCrediario.TabStop = True
    Me.rbtImportarCrediario.Text = "Importar Arquivo de Crediário"
    Me.rbtImportarCrediario.UseVisualStyleBackColor = True
    '
    'rbtImportarProduto
    '
    Me.rbtImportarProduto.AutoSize = True
    Me.rbtImportarProduto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.rbtImportarProduto.Location = New System.Drawing.Point(3, 83)
    Me.rbtImportarProduto.Name = "rbtImportarProduto"
    Me.rbtImportarProduto.Size = New System.Drawing.Size(253, 23)
    Me.rbtImportarProduto.TabIndex = 7
    Me.rbtImportarProduto.TabStop = True
    Me.rbtImportarProduto.Text = "Importar Arquivo de Produtos"
    Me.rbtImportarProduto.UseVisualStyleBackColor = True
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.FileName = "OpenFileDialog1"
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
    Me.btoFiltro.Location = New System.Drawing.Point(553, 108)
    Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
    Me.btoFiltro.Name = "btoFiltro"
    Me.btoFiltro.Size = New System.Drawing.Size(100, 72)
    Me.btoFiltro.TabIndex = 4
    Me.btoFiltro.TabStop = False
    Me.btoFiltro.Text = "Pesquisar <F5>"
    Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoFiltro.UseVisualStyleBackColor = False
    '
    'txtNome
    '
    Me.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtNome.Location = New System.Drawing.Point(153, 132)
    Me.txtNome.MaxLength = 100
    Me.txtNome.Name = "txtNome"
    Me.txtNome.ReadOnly = True
    Me.txtNome.Size = New System.Drawing.Size(396, 18)
    Me.txtNome.TabIndex = 3
    '
    'lblNome
    '
    Me.lblNome.AutoSize = True
    Me.lblNome.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblNome.Location = New System.Drawing.Point(97, 132)
    Me.lblNome.Name = "lblNome"
    Me.lblNome.Size = New System.Drawing.Size(49, 18)
    Me.lblNome.TabIndex = 104
    Me.lblNome.Text = "Nome"
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
    Me.btoSalvar.Location = New System.Drawing.Point(344, 344)
    Me.btoSalvar.Name = "btoSalvar"
    Me.btoSalvar.Size = New System.Drawing.Size(108, 72)
    Me.btoSalvar.TabIndex = 8
    Me.btoSalvar.TabStop = False
    Me.btoSalvar.Text = "Importar <Enter>"
    Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSalvar.UseVisualStyleBackColor = False
    '
    'ProgressBar1
    '
    Me.ProgressBar1.Location = New System.Drawing.Point(153, 417)
    Me.ProgressBar1.Name = "ProgressBar1"
    Me.ProgressBar1.Size = New System.Drawing.Size(444, 23)
    Me.ProgressBar1.TabIndex = 106
    '
    'rbtOutros
    '
    Me.rbtOutros.AutoSize = True
    Me.rbtOutros.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.rbtOutros.Location = New System.Drawing.Point(83, 10)
    Me.rbtOutros.Name = "rbtOutros"
    Me.rbtOutros.Size = New System.Drawing.Size(79, 23)
    Me.rbtOutros.TabIndex = 2
    Me.rbtOutros.Text = "Outros"
    Me.rbtOutros.UseVisualStyleBackColor = True
    '
    'rbtAbcd
    '
    Me.rbtAbcd.AutoSize = True
    Me.rbtAbcd.Checked = True
    Me.rbtAbcd.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.rbtAbcd.Location = New System.Drawing.Point(3, 10)
    Me.rbtAbcd.Name = "rbtAbcd"
    Me.rbtAbcd.Size = New System.Drawing.Size(74, 23)
    Me.rbtAbcd.TabIndex = 1
    Me.rbtAbcd.TabStop = True
    Me.rbtAbcd.Text = "ABCD"
    Me.rbtAbcd.UseVisualStyleBackColor = True
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.rbtAbcd)
    Me.Panel1.Controls.Add(Me.rbtOutros)
    Me.Panel1.Location = New System.Drawing.Point(97, 86)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(308, 43)
    Me.Panel1.TabIndex = 0
    '
    'Panel2
    '
    Me.Panel2.Controls.Add(Me.rbtImportarCliente)
    Me.Panel2.Controls.Add(Me.rbtImportarCrediario)
    Me.Panel2.Controls.Add(Me.rbtImportarProduto)
    Me.Panel2.Location = New System.Drawing.Point(97, 156)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(312, 125)
    Me.Panel2.TabIndex = 4
    '
    'Panel3
    '
    Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel3.Location = New System.Drawing.Point(0, 0)
    Me.Panel3.Name = "Panel3"
    Me.Panel3.Size = New System.Drawing.Size(763, 444)
    Me.Panel3.TabIndex = 107
    '
    'fImportarArquivos
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(763, 444)
    Me.Controls.Add(Me.Panel2)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.ProgressBar1)
    Me.Controls.Add(Me.btoSalvar)
    Me.Controls.Add(Me.btoFiltro)
    Me.Controls.Add(Me.txtNome)
    Me.Controls.Add(Me.lblNome)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.Panel3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fImportarArquivos"
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
  Friend WithEvents rbtImportarCliente As System.Windows.Forms.RadioButton
  Friend WithEvents rbtImportarCrediario As System.Windows.Forms.RadioButton
  Friend WithEvents rbtImportarProduto As System.Windows.Forms.RadioButton
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
  Friend WithEvents btoFiltro As System.Windows.Forms.Button
  Friend WithEvents txtNome As System.Windows.Forms.TextBox
  Friend WithEvents lblNome As System.Windows.Forms.Label
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
  Friend WithEvents rbtOutros As System.Windows.Forms.RadioButton
  Friend WithEvents rbtAbcd As System.Windows.Forms.RadioButton
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
