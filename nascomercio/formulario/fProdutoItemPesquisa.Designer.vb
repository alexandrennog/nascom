<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProdutoItemPesquisa
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.imgLogo = New System.Windows.Forms.PictureBox
        Me.dgvProdutoItem = New System.Windows.Forms.DataGridView
        Me.produtos_cid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descricao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.estoque = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Referencia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tamanho = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valorVenda = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.btoPesquisar = New System.Windows.Forms.Button
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.txtCodigoBarras = New System.Windows.Forms.TextBox
        Me.lblNome = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.btoSair = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtReferencia = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkEstoque = New System.Windows.Forms.CheckBox
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProdutoItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.tipo_de_produto
        Me.imgLogo.Location = New System.Drawing.Point(8, 8)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 147
        Me.imgLogo.TabStop = False
        '
        'dgvProdutoItem
        '
        Me.dgvProdutoItem.AllowUserToAddRows = False
        Me.dgvProdutoItem.AllowUserToDeleteRows = False
        Me.dgvProdutoItem.AllowUserToOrderColumns = True
        Me.dgvProdutoItem.AllowUserToResizeColumns = False
        Me.dgvProdutoItem.AllowUserToResizeRows = False
        Me.dgvProdutoItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProdutoItem.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvProdutoItem.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvProdutoItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProdutoItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvProdutoItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProdutoItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.produtos_cid, Me.Valor, Me.Descricao, Me.estoque, Me.Referencia, Me.Cor, Me.Tamanho, Me.valorVenda})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProdutoItem.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvProdutoItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvProdutoItem.Location = New System.Drawing.Point(7, 157)
        Me.dgvProdutoItem.Name = "dgvProdutoItem"
        Me.dgvProdutoItem.ReadOnly = True
        Me.dgvProdutoItem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProdutoItem.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvProdutoItem.RowHeadersVisible = False
        Me.dgvProdutoItem.Size = New System.Drawing.Size(724, 248)
        Me.dgvProdutoItem.TabIndex = 142
        '
        'produtos_cid
        '
        Me.produtos_cid.FillWeight = 50.0!
        Me.produtos_cid.HeaderText = "CID"
        Me.produtos_cid.MinimumWidth = 50
        Me.produtos_cid.Name = "produtos_cid"
        Me.produtos_cid.ReadOnly = True
        Me.produtos_cid.Visible = False
        '
        'Valor
        '
        Me.Valor.FillWeight = 25.0!
        Me.Valor.HeaderText = "Código Barra"
        Me.Valor.MinimumWidth = 25
        Me.Valor.Name = "Valor"
        Me.Valor.ReadOnly = True
        '
        'Descricao
        '
        Me.Descricao.FillWeight = 35.0!
        Me.Descricao.HeaderText = "Descrição"
        Me.Descricao.MinimumWidth = 35
        Me.Descricao.Name = "Descricao"
        Me.Descricao.ReadOnly = True
        '
        'estoque
        '
        Me.estoque.FillWeight = 15.0!
        Me.estoque.HeaderText = "Estoque"
        Me.estoque.MinimumWidth = 15
        Me.estoque.Name = "estoque"
        Me.estoque.ReadOnly = True
        '
        'Referencia
        '
        Me.Referencia.FillWeight = 20.0!
        Me.Referencia.HeaderText = "Referência"
        Me.Referencia.MinimumWidth = 20
        Me.Referencia.Name = "Referencia"
        Me.Referencia.ReadOnly = True
        '
        'Cor
        '
        Me.Cor.FillWeight = 23.0!
        Me.Cor.HeaderText = "Cor"
        Me.Cor.MinimumWidth = 23
        Me.Cor.Name = "Cor"
        Me.Cor.ReadOnly = True
        '
        'Tamanho
        '
        Me.Tamanho.FillWeight = 15.0!
        Me.Tamanho.HeaderText = "Tamanho"
        Me.Tamanho.MinimumWidth = 15
        Me.Tamanho.Name = "Tamanho"
        Me.Tamanho.ReadOnly = True
        '
        'valorVenda
        '
        Me.valorVenda.FillWeight = 15.0!
        Me.valorVenda.HeaderText = "Valor"
        Me.valorVenda.MinimumWidth = 15
        Me.valorVenda.Name = "valorVenda"
        Me.valorVenda.ReadOnly = True
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(64, 8)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(247, 24)
        Me.lblTitulo.TabIndex = 146
        Me.lblTitulo.Text = "Pesquisar Produto/Item"
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
        Me.btoPesquisar.Location = New System.Drawing.Point(305, 408)
        Me.btoPesquisar.Margin = New System.Windows.Forms.Padding(0)
        Me.btoPesquisar.Name = "btoPesquisar"
        Me.btoPesquisar.Size = New System.Drawing.Size(116, 72)
        Me.btoPesquisar.TabIndex = 3
        Me.btoPesquisar.TabStop = False
        Me.btoPesquisar.Text = "Pesquisar <Enter>"
        Me.btoPesquisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoPesquisar.UseVisualStyleBackColor = False
        '
        'txtDescricao
        '
        Me.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDescricao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescricao.Location = New System.Drawing.Point(143, 96)
        Me.txtDescricao.MaxLength = 50
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(328, 18)
        Me.txtDescricao.TabIndex = 1
        '
        'txtCodigoBarras
        '
        Me.txtCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCodigoBarras.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoBarras.Location = New System.Drawing.Point(143, 72)
        Me.txtCodigoBarras.MaxLength = 20
        Me.txtCodigoBarras.Name = "txtCodigoBarras"
        Me.txtCodigoBarras.Size = New System.Drawing.Size(328, 18)
        Me.txtCodigoBarras.TabIndex = 0
        '
        'lblNome
        '
        Me.lblNome.AutoSize = True
        Me.lblNome.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblNome.Location = New System.Drawing.Point(58, 96)
        Me.lblNome.Name = "lblNome"
        Me.lblNome.Size = New System.Drawing.Size(79, 18)
        Me.lblNome.TabIndex = 169
        Me.lblNome.Text = "Descrição"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblCodigo.Location = New System.Drawing.Point(5, 72)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(132, 18)
        Me.lblCodigo.TabIndex = 168
        Me.lblCodigo.Text = "Código de Barras"
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
        Me.btoSair.Location = New System.Drawing.Point(621, 11)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(88, 72)
        Me.btoSair.TabIndex = 170
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.chkEstoque)
        Me.Panel1.Controls.Add(Me.txtReferencia)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btoSair)
        Me.Panel1.Controls.Add(Me.txtCodigoBarras)
        Me.Panel1.Controls.Add(Me.btoPesquisar)
        Me.Panel1.Controls.Add(Me.dgvProdutoItem)
        Me.Panel1.Controls.Add(Me.txtDescricao)
        Me.Panel1.Controls.Add(Me.lblCodigo)
        Me.Panel1.Controls.Add(Me.lblNome)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(736, 490)
        Me.Panel1.TabIndex = 171
        '
        'txtReferencia
        '
        Me.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtReferencia.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferencia.Location = New System.Drawing.Point(143, 120)
        Me.txtReferencia.MaxLength = 50
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(328, 18)
        Me.txtReferencia.TabIndex = 171
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(51, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 18)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "Referência"
        '
        'chkEstoque
        '
        Me.chkEstoque.AutoSize = True
        Me.chkEstoque.Checked = True
        Me.chkEstoque.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEstoque.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEstoque.Location = New System.Drawing.Point(477, 121)
        Me.chkEstoque.Name = "chkEstoque"
        Me.chkEstoque.Size = New System.Drawing.Size(210, 19)
        Me.chkEstoque.TabIndex = 173
        Me.chkEstoque.Text = "Somente Produtos Com Estoque"
        Me.chkEstoque.UseVisualStyleBackColor = True
        '
        'fProdutoItemPesquisa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(736, 490)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fProdutoItemPesquisa"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ProdutoItemPesquisa"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProdutoItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents dgvProdutoItem As System.Windows.Forms.DataGridView
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents btoPesquisar As System.Windows.Forms.Button
  Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
  Friend WithEvents txtCodigoBarras As System.Windows.Forms.TextBox
  Friend WithEvents lblNome As System.Windows.Forms.Label
  Friend WithEvents lblCodigo As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents produtos_cid As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Descricao As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents estoque As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Referencia As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Cor As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Tamanho As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valorVenda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkEstoque As System.Windows.Forms.CheckBox
End Class
