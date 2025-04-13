<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProdutoBalancoFiltro
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
    Me.Label9 = New System.Windows.Forms.Label
    Me.cboCor = New System.Windows.Forms.ComboBox
    Me.Label8 = New System.Windows.Forms.Label
    Me.cboGrupo = New System.Windows.Forms.ComboBox
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
    Me.cboSituacao = New System.Windows.Forms.ComboBox
    Me.lblSituacao = New System.Windows.Forms.Label
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.lblNome = New System.Windows.Forms.Label
    Me.lblCodigo = New System.Windows.Forms.Label
    Me.btoPesquisar = New System.Windows.Forms.Button
    Me.btoSair = New System.Windows.Forms.Button
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.btoTransferencia = New System.Windows.Forms.Button
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.BackColor = System.Drawing.Color.Transparent
    Me.Label9.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label9.Location = New System.Drawing.Point(402, 124)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(34, 18)
    Me.Label9.TabIndex = 228
    Me.Label9.Text = "Cor"
    '
    'cboCor
    '
    Me.cboCor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboCor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboCor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboCor.FormattingEnabled = True
    Me.cboCor.Location = New System.Drawing.Point(440, 120)
    Me.cboCor.Name = "cboCor"
    Me.cboCor.Size = New System.Drawing.Size(204, 26)
    Me.cboCor.TabIndex = 227
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.BackColor = System.Drawing.Color.Transparent
    Me.Label8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label8.Location = New System.Drawing.Point(380, 156)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(53, 18)
    Me.Label8.TabIndex = 225
    Me.Label8.Text = "Grupo"
    '
    'cboGrupo
    '
    Me.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboGrupo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboGrupo.FormattingEnabled = True
    Me.cboGrupo.Location = New System.Drawing.Point(440, 152)
    Me.cboGrupo.Name = "cboGrupo"
    Me.cboGrupo.Size = New System.Drawing.Size(204, 26)
    Me.cboGrupo.TabIndex = 223
    '
    'txtReferencia
    '
    Me.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtReferencia.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtReferencia.Location = New System.Drawing.Point(442, 72)
    Me.txtReferencia.MaxLength = 20
    Me.txtReferencia.Name = "txtReferencia"
    Me.txtReferencia.Size = New System.Drawing.Size(200, 18)
    Me.txtReferencia.TabIndex = 198
    '
    'lblReferencia
    '
    Me.lblReferencia.AutoSize = True
    Me.lblReferencia.BackColor = System.Drawing.Color.Transparent
    Me.lblReferencia.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblReferencia.Location = New System.Drawing.Point(350, 72)
    Me.lblReferencia.Name = "lblReferencia"
    Me.lblReferencia.Size = New System.Drawing.Size(86, 18)
    Me.lblReferencia.TabIndex = 221
    Me.lblReferencia.Text = "Referência"
    '
    'lblFabricante
    '
    Me.lblFabricante.AutoSize = True
    Me.lblFabricante.BackColor = System.Drawing.Color.Transparent
    Me.lblFabricante.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblFabricante.Location = New System.Drawing.Point(14, 156)
    Me.lblFabricante.Name = "lblFabricante"
    Me.lblFabricante.Size = New System.Drawing.Size(83, 18)
    Me.lblFabricante.TabIndex = 218
    Me.lblFabricante.Text = "Fabricante"
    '
    'cboFabricante
    '
    Me.cboFabricante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboFabricante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboFabricante.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboFabricante.FormattingEnabled = True
    Me.cboFabricante.Location = New System.Drawing.Point(102, 152)
    Me.cboFabricante.Name = "cboFabricante"
    Me.cboFabricante.Size = New System.Drawing.Size(208, 26)
    Me.cboFabricante.TabIndex = 201
    '
    'lblFornecedor
    '
    Me.lblFornecedor.AutoSize = True
    Me.lblFornecedor.BackColor = System.Drawing.Color.Transparent
    Me.lblFornecedor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblFornecedor.Location = New System.Drawing.Point(6, 124)
    Me.lblFornecedor.Name = "lblFornecedor"
    Me.lblFornecedor.Size = New System.Drawing.Size(91, 18)
    Me.lblFornecedor.TabIndex = 217
    Me.lblFornecedor.Text = "Fornecedor"
    '
    'cboFornecedor
    '
    Me.cboFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboFornecedor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboFornecedor.FormattingEnabled = True
    Me.cboFornecedor.Location = New System.Drawing.Point(102, 120)
    Me.cboFornecedor.Name = "cboFornecedor"
    Me.cboFornecedor.Size = New System.Drawing.Size(208, 26)
    Me.cboFornecedor.TabIndex = 200
    '
    'txtDescricao
    '
    Me.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDescricao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtDescricao.Location = New System.Drawing.Point(102, 96)
    Me.txtDescricao.MaxLength = 50
    Me.txtDescricao.Name = "txtDescricao"
    Me.txtDescricao.Size = New System.Drawing.Size(540, 18)
    Me.txtDescricao.TabIndex = 199
    '
    'txtCodigo
    '
    Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtCodigo.Location = New System.Drawing.Point(102, 72)
    Me.txtCodigo.MaxLength = 20
    Me.txtCodigo.Name = "txtCodigo"
    Me.txtCodigo.Size = New System.Drawing.Size(208, 18)
    Me.txtCodigo.TabIndex = 197
    '
    'lblTipo
    '
    Me.lblTipo.AutoSize = True
    Me.lblTipo.BackColor = System.Drawing.Color.Transparent
    Me.lblTipo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblTipo.Location = New System.Drawing.Point(58, 188)
    Me.lblTipo.Name = "lblTipo"
    Me.lblTipo.Size = New System.Drawing.Size(40, 18)
    Me.lblTipo.TabIndex = 216
    Me.lblTipo.Text = "Tipo"
    '
    'lblSubTitulo
    '
    Me.lblSubTitulo.AutoSize = True
    Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblSubTitulo.Location = New System.Drawing.Point(62, 31)
    Me.lblSubTitulo.Name = "lblSubTitulo"
    Me.lblSubTitulo.Size = New System.Drawing.Size(45, 14)
    Me.lblSubTitulo.TabIndex = 215
    Me.lblSubTitulo.Text = "FILTRO"
    '
    'cboTipo
    '
    Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboTipo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboTipo.FormattingEnabled = True
    Me.cboTipo.Location = New System.Drawing.Point(102, 184)
    Me.cboTipo.Name = "cboTipo"
    Me.cboTipo.Size = New System.Drawing.Size(208, 26)
    Me.cboTipo.TabIndex = 202
    '
    'cboSituacao
    '
    Me.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboSituacao.FormattingEnabled = True
    Me.cboSituacao.Location = New System.Drawing.Point(440, 184)
    Me.cboSituacao.Name = "cboSituacao"
    Me.cboSituacao.Size = New System.Drawing.Size(204, 26)
    Me.cboSituacao.TabIndex = 205
    '
    'lblSituacao
    '
    Me.lblSituacao.AutoSize = True
    Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
    Me.lblSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblSituacao.Location = New System.Drawing.Point(364, 188)
    Me.lblSituacao.Name = "lblSituacao"
    Me.lblSituacao.Size = New System.Drawing.Size(69, 18)
    Me.lblSituacao.TabIndex = 213
    Me.lblSituacao.Text = "Situação"
    '
    'lblTitulo
    '
    Me.lblTitulo.AutoSize = True
    Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblTitulo.Location = New System.Drawing.Point(62, 7)
    Me.lblTitulo.Name = "lblTitulo"
    Me.lblTitulo.Size = New System.Drawing.Size(222, 24)
    Me.lblTitulo.TabIndex = 212
    Me.lblTitulo.Text = "Balanço de Produtos"
    '
    'lblNome
    '
    Me.lblNome.AutoSize = True
    Me.lblNome.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblNome.Location = New System.Drawing.Point(18, 96)
    Me.lblNome.Name = "lblNome"
    Me.lblNome.Size = New System.Drawing.Size(79, 18)
    Me.lblNome.TabIndex = 211
    Me.lblNome.Text = "Descrição"
    '
    'lblCodigo
    '
    Me.lblCodigo.AutoSize = True
    Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
    Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCodigo.Location = New System.Drawing.Point(38, 72)
    Me.lblCodigo.Name = "lblCodigo"
    Me.lblCodigo.Size = New System.Drawing.Size(59, 18)
    Me.lblCodigo.TabIndex = 210
    Me.lblCodigo.Text = "Código"
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
    Me.btoPesquisar.Location = New System.Drawing.Point(330, 292)
    Me.btoPesquisar.Margin = New System.Windows.Forms.Padding(0)
    Me.btoPesquisar.Name = "btoPesquisar"
    Me.btoPesquisar.Size = New System.Drawing.Size(116, 72)
    Me.btoPesquisar.TabIndex = 207
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
    Me.btoSair.Location = New System.Drawing.Point(680, 7)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(88, 72)
    Me.btoSair.TabIndex = 208
    Me.btoSair.TabStop = False
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSair.UseVisualStyleBackColor = False
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.produtos
    Me.imgLogo.Location = New System.Drawing.Point(6, 7)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 214
    Me.imgLogo.TabStop = False
    '
    'btoTransferencia
    '
    Me.btoTransferencia.BackColor = System.Drawing.Color.Transparent
    Me.btoTransferencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoTransferencia.FlatAppearance.BorderSize = 0
    Me.btoTransferencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoTransferencia.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoTransferencia.ForeColor = System.Drawing.Color.Black
    Me.btoTransferencia.Image = Global.nascomercio.My.Resources.Resources.entrada_saida_estoque
    Me.btoTransferencia.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoTransferencia.Location = New System.Drawing.Point(664, 78)
    Me.btoTransferencia.Margin = New System.Windows.Forms.Padding(0)
    Me.btoTransferencia.Name = "btoTransferencia"
    Me.btoTransferencia.Size = New System.Drawing.Size(120, 79)
    Me.btoTransferencia.TabIndex = 229
    Me.btoTransferencia.TabStop = False
    Me.btoTransferencia.Text = "Transferência /Estoque <F8>"
    Me.btoTransferencia.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoTransferencia.UseVisualStyleBackColor = False
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(790, 368)
    Me.Panel1.TabIndex = 230
    '
    'fProdutoBalancoFiltro
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(790, 368)
    Me.Controls.Add(Me.btoTransferencia)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.cboCor)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.cboGrupo)
    Me.Controls.Add(Me.txtReferencia)
    Me.Controls.Add(Me.btoPesquisar)
    Me.Controls.Add(Me.lblReferencia)
    Me.Controls.Add(Me.lblFabricante)
    Me.Controls.Add(Me.cboFabricante)
    Me.Controls.Add(Me.lblFornecedor)
    Me.Controls.Add(Me.cboFornecedor)
    Me.Controls.Add(Me.txtDescricao)
    Me.Controls.Add(Me.txtCodigo)
    Me.Controls.Add(Me.lblTipo)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.cboTipo)
    Me.Controls.Add(Me.cboSituacao)
    Me.Controls.Add(Me.lblSituacao)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.lblNome)
    Me.Controls.Add(Me.lblCodigo)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fProdutoBalancoFiltro"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "fProdutoBalancoFiltro"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents cboCor As System.Windows.Forms.ComboBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
  Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
  Friend WithEvents btoPesquisar As System.Windows.Forms.Button
  Friend WithEvents lblReferencia As System.Windows.Forms.Label
  Friend WithEvents lblFabricante As System.Windows.Forms.Label
  Friend WithEvents cboFabricante As System.Windows.Forms.ComboBox
  Friend WithEvents lblFornecedor As System.Windows.Forms.Label
  Friend WithEvents cboFornecedor As System.Windows.Forms.ComboBox
  Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
  Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
  Friend WithEvents lblTipo As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
  Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
  Friend WithEvents lblSituacao As System.Windows.Forms.Label
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents lblNome As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
  Friend WithEvents btoTransferencia As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
