<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProdutoEntradaSaidaFiltro
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
    Me.txtReferencia = New System.Windows.Forms.TextBox
    Me.lblReferencia = New System.Windows.Forms.Label
    Me.lblFabricante = New System.Windows.Forms.Label
    Me.cboFabricante = New System.Windows.Forms.ComboBox
    Me.lblFornecedor = New System.Windows.Forms.Label
    Me.cboFornecedor = New System.Windows.Forms.ComboBox
    Me.txtDescricao = New System.Windows.Forms.TextBox
    Me.txtCodigo = New System.Windows.Forms.TextBox
    Me.lblTipo = New System.Windows.Forms.Label
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.cboTipo = New System.Windows.Forms.ComboBox
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.lblNome = New System.Windows.Forms.Label
    Me.lblCodigo = New System.Windows.Forms.Label
    Me.txtCodigoBarras = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.btoPesquisar = New System.Windows.Forms.Button
    Me.btoSair = New System.Windows.Forms.Button
    Me.btoBalanco = New System.Windows.Forms.Button
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'txtReferencia
    '
    Me.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtReferencia.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtReferencia.Location = New System.Drawing.Point(108, 148)
    Me.txtReferencia.MaxLength = 20
    Me.txtReferencia.Name = "txtReferencia"
    Me.txtReferencia.Size = New System.Drawing.Size(192, 18)
    Me.txtReferencia.TabIndex = 3
    '
    'lblReferencia
    '
    Me.lblReferencia.AutoSize = True
    Me.lblReferencia.BackColor = System.Drawing.Color.Transparent
    Me.lblReferencia.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblReferencia.Location = New System.Drawing.Point(16, 148)
    Me.lblReferencia.Name = "lblReferencia"
    Me.lblReferencia.Size = New System.Drawing.Size(86, 18)
    Me.lblReferencia.TabIndex = 209
    Me.lblReferencia.Text = "Referência"
    '
    'lblFabricante
    '
    Me.lblFabricante.AutoSize = True
    Me.lblFabricante.BackColor = System.Drawing.Color.Transparent
    Me.lblFabricante.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblFabricante.Location = New System.Drawing.Point(332, 148)
    Me.lblFabricante.Name = "lblFabricante"
    Me.lblFabricante.Size = New System.Drawing.Size(83, 18)
    Me.lblFabricante.TabIndex = 206
    Me.lblFabricante.Text = "Fabricante"
    '
    'cboFabricante
    '
    Me.cboFabricante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboFabricante.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboFabricante.FormattingEnabled = True
    Me.cboFabricante.Location = New System.Drawing.Point(420, 144)
    Me.cboFabricante.Name = "cboFabricante"
    Me.cboFabricante.Size = New System.Drawing.Size(188, 26)
    Me.cboFabricante.TabIndex = 6
    '
    'lblFornecedor
    '
    Me.lblFornecedor.AutoSize = True
    Me.lblFornecedor.BackColor = System.Drawing.Color.Transparent
    Me.lblFornecedor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblFornecedor.Location = New System.Drawing.Point(324, 116)
    Me.lblFornecedor.Name = "lblFornecedor"
    Me.lblFornecedor.Size = New System.Drawing.Size(91, 18)
    Me.lblFornecedor.TabIndex = 205
    Me.lblFornecedor.Text = "Fornecedor"
    '
    'cboFornecedor
    '
    Me.cboFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboFornecedor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboFornecedor.FormattingEnabled = True
    Me.cboFornecedor.Location = New System.Drawing.Point(420, 112)
    Me.cboFornecedor.Name = "cboFornecedor"
    Me.cboFornecedor.Size = New System.Drawing.Size(188, 26)
    Me.cboFornecedor.TabIndex = 5
    '
    'txtDescricao
    '
    Me.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDescricao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtDescricao.Location = New System.Drawing.Point(108, 88)
    Me.txtDescricao.MaxLength = 50
    Me.txtDescricao.Name = "txtDescricao"
    Me.txtDescricao.Size = New System.Drawing.Size(500, 18)
    Me.txtDescricao.TabIndex = 1
    '
    'txtCodigo
    '
    Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtCodigo.Location = New System.Drawing.Point(108, 116)
    Me.txtCodigo.MaxLength = 20
    Me.txtCodigo.Name = "txtCodigo"
    Me.txtCodigo.Size = New System.Drawing.Size(192, 18)
    Me.txtCodigo.TabIndex = 2
    '
    'lblTipo
    '
    Me.lblTipo.AutoSize = True
    Me.lblTipo.BackColor = System.Drawing.Color.Transparent
    Me.lblTipo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblTipo.Location = New System.Drawing.Point(376, 180)
    Me.lblTipo.Name = "lblTipo"
    Me.lblTipo.Size = New System.Drawing.Size(40, 18)
    Me.lblTipo.TabIndex = 204
    Me.lblTipo.Text = "Tipo"
    '
    'lblSubTitulo
    '
    Me.lblSubTitulo.AutoSize = True
    Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblSubTitulo.Location = New System.Drawing.Point(64, 32)
    Me.lblSubTitulo.Name = "lblSubTitulo"
    Me.lblSubTitulo.Size = New System.Drawing.Size(44, 14)
    Me.lblSubTitulo.TabIndex = 203
    Me.lblSubTitulo.Text = "FILTRO"
    '
    'cboTipo
    '
    Me.cboTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboTipo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboTipo.FormattingEnabled = True
    Me.cboTipo.Location = New System.Drawing.Point(420, 176)
    Me.cboTipo.Name = "cboTipo"
    Me.cboTipo.Size = New System.Drawing.Size(188, 26)
    Me.cboTipo.TabIndex = 7
    '
    'lblTitulo
    '
    Me.lblTitulo.AutoSize = True
    Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblTitulo.Location = New System.Drawing.Point(64, 8)
    Me.lblTitulo.Name = "lblTitulo"
    Me.lblTitulo.Size = New System.Drawing.Size(299, 24)
    Me.lblTitulo.TabIndex = 200
    Me.lblTitulo.Text = "Entrada e Saida de Produtos"
    '
    'lblNome
    '
    Me.lblNome.AutoSize = True
    Me.lblNome.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblNome.Location = New System.Drawing.Point(24, 88)
    Me.lblNome.Name = "lblNome"
    Me.lblNome.Size = New System.Drawing.Size(79, 18)
    Me.lblNome.TabIndex = 199
    Me.lblNome.Text = "Descrição"
    '
    'lblCodigo
    '
    Me.lblCodigo.AutoSize = True
    Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
    Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCodigo.Location = New System.Drawing.Point(44, 116)
    Me.lblCodigo.Name = "lblCodigo"
    Me.lblCodigo.Size = New System.Drawing.Size(59, 18)
    Me.lblCodigo.TabIndex = 198
    Me.lblCodigo.Text = "Código"
    '
    'txtCodigoBarras
    '
    Me.txtCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCodigoBarras.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtCodigoBarras.Location = New System.Drawing.Point(108, 180)
    Me.txtCodigoBarras.MaxLength = 20
    Me.txtCodigoBarras.Name = "txtCodigoBarras"
    Me.txtCodigoBarras.Size = New System.Drawing.Size(192, 18)
    Me.txtCodigoBarras.TabIndex = 4
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label1.Location = New System.Drawing.Point(12, 180)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(92, 18)
    Me.Label1.TabIndex = 211
    Me.Label1.Text = "Cod. Barras"
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.entrada_saida_estoque
    Me.imgLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 202
    Me.imgLogo.TabStop = False
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
    Me.btoPesquisar.Location = New System.Drawing.Point(308, 244)
    Me.btoPesquisar.Margin = New System.Windows.Forms.Padding(0)
    Me.btoPesquisar.Name = "btoPesquisar"
    Me.btoPesquisar.Size = New System.Drawing.Size(117, 74)
    Me.btoPesquisar.TabIndex = 8
    Me.btoPesquisar.TabStop = False
    Me.btoPesquisar.Text = "Pesquisar <Enter>"
    Me.btoPesquisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
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
    Me.btoSair.Location = New System.Drawing.Point(632, 4)
    Me.btoSair.Margin = New System.Windows.Forms.Padding(0)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(93, 71)
    Me.btoSair.TabIndex = 9
    Me.btoSair.TabStop = False
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSair.UseVisualStyleBackColor = False
    '
    'btoBalanco
    '
    Me.btoBalanco.BackColor = System.Drawing.Color.Transparent
    Me.btoBalanco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
    Me.btoBalanco.FlatAppearance.BorderSize = 0
    Me.btoBalanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoBalanco.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoBalanco.ForeColor = System.Drawing.Color.Black
    Me.btoBalanco.Image = Global.nascomercio.My.Resources.Resources.balanco
    Me.btoBalanco.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoBalanco.Location = New System.Drawing.Point(623, 80)
    Me.btoBalanco.Margin = New System.Windows.Forms.Padding(0)
    Me.btoBalanco.Name = "btoBalanco"
    Me.btoBalanco.Size = New System.Drawing.Size(98, 76)
    Me.btoBalanco.TabIndex = 212
    Me.btoBalanco.TabStop = False
    Me.btoBalanco.Text = "Balanço <F8>"
    Me.btoBalanco.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoBalanco.UseVisualStyleBackColor = False
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(730, 323)
    Me.Panel1.TabIndex = 213
    '
    'fProdutoEntradaSaidaFiltro
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(730, 323)
    Me.Controls.Add(Me.btoBalanco)
    Me.Controls.Add(Me.btoPesquisar)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.txtCodigoBarras)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtReferencia)
    Me.Controls.Add(Me.lblReferencia)
    Me.Controls.Add(Me.lblFabricante)
    Me.Controls.Add(Me.cboFabricante)
    Me.Controls.Add(Me.lblFornecedor)
    Me.Controls.Add(Me.cboFornecedor)
    Me.Controls.Add(Me.txtDescricao)
    Me.Controls.Add(Me.txtCodigo)
    Me.Controls.Add(Me.lblTipo)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.cboTipo)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.lblNome)
    Me.Controls.Add(Me.lblCodigo)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fProdutoEntradaSaidaFiltro"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "ProdutoEstoque"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
  Friend WithEvents lblReferencia As System.Windows.Forms.Label
  Friend WithEvents lblFabricante As System.Windows.Forms.Label
  Friend WithEvents cboFabricante As System.Windows.Forms.ComboBox
  Friend WithEvents lblFornecedor As System.Windows.Forms.Label
  Friend WithEvents cboFornecedor As System.Windows.Forms.ComboBox
  Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
  Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
  Friend WithEvents lblTipo As System.Windows.Forms.Label
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents lblNome As System.Windows.Forms.Label
  Friend WithEvents lblCodigo As System.Windows.Forms.Label
  Friend WithEvents txtCodigoBarras As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents btoPesquisar As System.Windows.Forms.Button
    Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents btoBalanco As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
