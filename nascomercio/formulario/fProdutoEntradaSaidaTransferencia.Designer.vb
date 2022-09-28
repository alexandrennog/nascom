<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProdutoEntradaSaidaTransferencia
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
    Me.lblFornecedor = New System.Windows.Forms.Label
    Me.cboOrigem = New System.Windows.Forms.ComboBox
    Me.txtDescricao = New System.Windows.Forms.TextBox
    Me.lblNome = New System.Windows.Forms.Label
    Me.dgvProduto = New System.Windows.Forms.DataGridView
    Me.txtCodigo = New System.Windows.Forms.TextBox
    Me.lblCodigo = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.cboDestino = New System.Windows.Forms.ComboBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.btoFechar = New System.Windows.Forms.Button
    Me.btoPesquisar = New System.Windows.Forms.Button
    Me.btoEstoque = New System.Windows.Forms.Button
    Me.btoTransferir = New System.Windows.Forms.Button
    Me.txtQuantidade = New System.Windows.Forms.MaskedTextBox
    Me.btoBalanco = New System.Windows.Forms.Button
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.dgvProduto, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'lblFornecedor
    '
    Me.lblFornecedor.AutoSize = True
    Me.lblFornecedor.BackColor = System.Drawing.Color.Transparent
    Me.lblFornecedor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblFornecedor.Location = New System.Drawing.Point(12, 288)
    Me.lblFornecedor.Name = "lblFornecedor"
    Me.lblFornecedor.Size = New System.Drawing.Size(104, 18)
    Me.lblFornecedor.TabIndex = 143
    Me.lblFornecedor.Text = "Loja (Origem)"
    '
    'cboOrigem
    '
    Me.cboOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboOrigem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboOrigem.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboOrigem.FormattingEnabled = True
    Me.cboOrigem.Location = New System.Drawing.Point(120, 284)
    Me.cboOrigem.Name = "cboOrigem"
    Me.cboOrigem.Size = New System.Drawing.Size(284, 26)
    Me.cboOrigem.TabIndex = 4
    '
    'txtDescricao
    '
    Me.txtDescricao.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDescricao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtDescricao.Location = New System.Drawing.Point(76, 96)
    Me.txtDescricao.MaxLength = 50
    Me.txtDescricao.Name = "txtDescricao"
    Me.txtDescricao.ReadOnly = True
    Me.txtDescricao.Size = New System.Drawing.Size(568, 18)
    Me.txtDescricao.TabIndex = 2
    Me.txtDescricao.TabStop = False
    '
    'lblNome
    '
    Me.lblNome.AutoSize = True
    Me.lblNome.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblNome.Location = New System.Drawing.Point(8, 96)
    Me.lblNome.Name = "lblNome"
    Me.lblNome.Size = New System.Drawing.Size(65, 18)
    Me.lblNome.TabIndex = 142
    Me.lblNome.Text = "Produto"
    '
    'dgvProduto
    '
    Me.dgvProduto.AllowUserToAddRows = False
    Me.dgvProduto.AllowUserToDeleteRows = False
    Me.dgvProduto.AllowUserToOrderColumns = True
    Me.dgvProduto.AllowUserToResizeColumns = False
    Me.dgvProduto.AllowUserToResizeRows = False
    Me.dgvProduto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
    Me.dgvProduto.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvProduto.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.dgvProduto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    Me.dgvProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgvProduto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
    Me.dgvProduto.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvProduto.Location = New System.Drawing.Point(8, 120)
    Me.dgvProduto.Name = "dgvProduto"
    Me.dgvProduto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    Me.dgvProduto.RowHeadersVisible = False
    Me.dgvProduto.Size = New System.Drawing.Size(636, 152)
    Me.dgvProduto.StandardTab = True
    Me.dgvProduto.TabIndex = 3
    '
    'txtCodigo
    '
    Me.txtCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtCodigo.Location = New System.Drawing.Point(76, 72)
    Me.txtCodigo.MaxLength = 20
    Me.txtCodigo.Name = "txtCodigo"
    Me.txtCodigo.ReadOnly = True
    Me.txtCodigo.Size = New System.Drawing.Size(160, 18)
    Me.txtCodigo.TabIndex = 1
    Me.txtCodigo.TabStop = False
    '
    'lblCodigo
    '
    Me.lblCodigo.AutoSize = True
    Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
    Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCodigo.Location = New System.Drawing.Point(24, 348)
    Me.lblCodigo.Name = "lblCodigo"
    Me.lblCodigo.Size = New System.Drawing.Size(90, 18)
    Me.lblCodigo.TabIndex = 146
    Me.lblCodigo.Text = "Quantidade"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label1.Location = New System.Drawing.Point(8, 320)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(107, 18)
    Me.Label1.TabIndex = 148
    Me.Label1.Text = "Loja (Destino)"
    '
    'cboDestino
    '
    Me.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboDestino.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboDestino.FormattingEnabled = True
    Me.cboDestino.Location = New System.Drawing.Point(120, 316)
    Me.cboDestino.Name = "cboDestino"
    Me.cboDestino.Size = New System.Drawing.Size(284, 26)
    Me.cboDestino.TabIndex = 5
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.BackColor = System.Drawing.Color.Transparent
    Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label2.Location = New System.Drawing.Point(12, 72)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(59, 18)
    Me.Label2.TabIndex = 150
    Me.Label2.Text = "Código"
    '
    'lblSubTitulo
    '
    Me.lblSubTitulo.AutoSize = True
    Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblSubTitulo.Location = New System.Drawing.Point(64, 32)
    Me.lblSubTitulo.Name = "lblSubTitulo"
    Me.lblSubTitulo.Size = New System.Drawing.Size(94, 14)
    Me.lblSubTitulo.TabIndex = 155
    Me.lblSubTitulo.Text = "TRANSFERÊNCIA"
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.entrada_saida_estoque
    Me.imgLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 154
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
    Me.lblTitulo.Size = New System.Drawing.Size(299, 24)
    Me.lblTitulo.TabIndex = 153
    Me.lblTitulo.Text = "Entrada e Saida de Produtos"
    '
    'btoFechar
    '
    Me.btoFechar.BackColor = System.Drawing.Color.Transparent
    Me.btoFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoFechar.FlatAppearance.BorderSize = 0
    Me.btoFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoFechar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoFechar.ForeColor = System.Drawing.Color.Black
    Me.btoFechar.Image = Global.nascomercio.My.Resources.Resources.fechar
    Me.btoFechar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoFechar.Location = New System.Drawing.Point(667, 4)
    Me.btoFechar.Margin = New System.Windows.Forms.Padding(0)
    Me.btoFechar.Name = "btoFechar"
    Me.btoFechar.Size = New System.Drawing.Size(100, 72)
    Me.btoFechar.TabIndex = 8
    Me.btoFechar.TabStop = False
    Me.btoFechar.Text = "Fechar <Esc>"
    Me.btoFechar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoFechar.UseVisualStyleBackColor = False
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
    Me.btoPesquisar.Location = New System.Drawing.Point(667, 80)
    Me.btoPesquisar.Margin = New System.Windows.Forms.Padding(0)
    Me.btoPesquisar.Name = "btoPesquisar"
    Me.btoPesquisar.Size = New System.Drawing.Size(100, 72)
    Me.btoPesquisar.TabIndex = 9
    Me.btoPesquisar.TabStop = False
    Me.btoPesquisar.Text = "Pesquisar <F5>"
    Me.btoPesquisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoPesquisar.UseVisualStyleBackColor = False
    '
    'btoEstoque
    '
    Me.btoEstoque.BackColor = System.Drawing.Color.Transparent
    Me.btoEstoque.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoEstoque.FlatAppearance.BorderSize = 0
    Me.btoEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoEstoque.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoEstoque.ForeColor = System.Drawing.Color.Black
    Me.btoEstoque.Image = Global.nascomercio.My.Resources.Resources.product
    Me.btoEstoque.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoEstoque.Location = New System.Drawing.Point(667, 156)
    Me.btoEstoque.Margin = New System.Windows.Forms.Padding(0)
    Me.btoEstoque.Name = "btoEstoque"
    Me.btoEstoque.Size = New System.Drawing.Size(100, 72)
    Me.btoEstoque.TabIndex = 10
    Me.btoEstoque.TabStop = False
    Me.btoEstoque.Text = "Estoque <F6>"
    Me.btoEstoque.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoEstoque.UseVisualStyleBackColor = False
    '
    'btoTransferir
    '
    Me.btoTransferir.BackColor = System.Drawing.Color.Transparent
    Me.btoTransferir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoTransferir.FlatAppearance.BorderSize = 0
    Me.btoTransferir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoTransferir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoTransferir.ForeColor = System.Drawing.Color.Black
    Me.btoTransferir.Image = Global.nascomercio.My.Resources.Resources.confirmar
    Me.btoTransferir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoTransferir.Location = New System.Drawing.Point(312, 388)
    Me.btoTransferir.Margin = New System.Windows.Forms.Padding(0)
    Me.btoTransferir.Name = "btoTransferir"
    Me.btoTransferir.Size = New System.Drawing.Size(116, 72)
    Me.btoTransferir.TabIndex = 7
    Me.btoTransferir.TabStop = False
    Me.btoTransferir.Text = "Transferir <Enter>"
    Me.btoTransferir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoTransferir.UseVisualStyleBackColor = False
    '
    'txtQuantidade
    '
    Me.txtQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtQuantidade.Culture = New System.Globalization.CultureInfo("")
    Me.txtQuantidade.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtQuantidade.Location = New System.Drawing.Point(120, 348)
    Me.txtQuantidade.Mask = "0000"
    Me.txtQuantidade.Name = "txtQuantidade"
    Me.txtQuantidade.Size = New System.Drawing.Size(56, 18)
    Me.txtQuantidade.TabIndex = 6
    Me.txtQuantidade.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
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
    Me.btoBalanco.Location = New System.Drawing.Point(665, 234)
    Me.btoBalanco.Margin = New System.Windows.Forms.Padding(0)
    Me.btoBalanco.Name = "btoBalanco"
    Me.btoBalanco.Size = New System.Drawing.Size(98, 76)
    Me.btoBalanco.TabIndex = 234
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
    Me.Panel1.Size = New System.Drawing.Size(769, 464)
    Me.Panel1.TabIndex = 235
    '
    'fProdutoEntradaSaidaTransferencia
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(769, 464)
    Me.Controls.Add(Me.btoBalanco)
    Me.Controls.Add(Me.txtQuantidade)
    Me.Controls.Add(Me.btoTransferir)
    Me.Controls.Add(Me.btoEstoque)
    Me.Controls.Add(Me.btoPesquisar)
    Me.Controls.Add(Me.btoFechar)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.cboDestino)
    Me.Controls.Add(Me.txtCodigo)
    Me.Controls.Add(Me.lblCodigo)
    Me.Controls.Add(Me.dgvProduto)
    Me.Controls.Add(Me.lblFornecedor)
    Me.Controls.Add(Me.cboOrigem)
    Me.Controls.Add(Me.txtDescricao)
    Me.Controls.Add(Me.lblNome)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fProdutoEntradaSaidaTransferencia"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "fProdutoEntradaSaidaTransferencia"
    CType(Me.dgvProduto, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lblFornecedor As System.Windows.Forms.Label
  Friend WithEvents cboOrigem As System.Windows.Forms.ComboBox
  Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
  Friend WithEvents lblNome As System.Windows.Forms.Label
  Friend WithEvents dgvProduto As System.Windows.Forms.DataGridView
  Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
  Friend WithEvents lblCodigo As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents cboDestino As System.Windows.Forms.ComboBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents btoFechar As System.Windows.Forms.Button
  Friend WithEvents btoPesquisar As System.Windows.Forms.Button
  Friend WithEvents btoEstoque As System.Windows.Forms.Button
  Friend WithEvents btoTransferir As System.Windows.Forms.Button
    Friend WithEvents txtQuantidade As System.Windows.Forms.MaskedTextBox
  Friend WithEvents btoBalanco As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
