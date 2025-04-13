<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProdutoEntradaSaidaLista
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.btoPesquisar = New System.Windows.Forms.Button()
        Me.btoTransferir = New System.Windows.Forms.Button()
        Me.btoEstoque = New System.Windows.Forms.Button()
        Me.dgvProduto = New System.Windows.Forms.DataGridView()
        Me.btoBalanco = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorVenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.efdCategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProduto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSubTitulo.Location = New System.Drawing.Point(64, 32)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(38, 14)
        Me.lblSubTitulo.TabIndex = 206
        Me.lblSubTitulo.Text = "LISTA"
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
        Me.lblTitulo.TabIndex = 204
        Me.lblTitulo.Text = "Entrada e Saida de Produtos"
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.entrada_saida_estoque
        Me.imgLogo.Location = New System.Drawing.Point(8, 8)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 205
        Me.imgLogo.TabStop = False
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
        Me.btoSair.Location = New System.Drawing.Point(664, 4)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(0)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(98, 72)
        Me.btoSair.TabIndex = 214
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
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
        Me.btoPesquisar.Location = New System.Drawing.Point(664, 80)
        Me.btoPesquisar.Margin = New System.Windows.Forms.Padding(0)
        Me.btoPesquisar.Name = "btoPesquisar"
        Me.btoPesquisar.Size = New System.Drawing.Size(100, 84)
        Me.btoPesquisar.TabIndex = 215
        Me.btoPesquisar.TabStop = False
        Me.btoPesquisar.Text = "Pesquisar <F5>"
        Me.btoPesquisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoPesquisar.UseVisualStyleBackColor = False
        '
        'btoTransferir
        '
        Me.btoTransferir.BackColor = System.Drawing.Color.Transparent
        Me.btoTransferir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoTransferir.FlatAppearance.BorderSize = 0
        Me.btoTransferir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoTransferir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoTransferir.ForeColor = System.Drawing.Color.Black
        Me.btoTransferir.Image = Global.nascomercio.My.Resources.Resources.entrada_saida_estoque
        Me.btoTransferir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoTransferir.Location = New System.Drawing.Point(252, 420)
        Me.btoTransferir.Margin = New System.Windows.Forms.Padding(0)
        Me.btoTransferir.Name = "btoTransferir"
        Me.btoTransferir.Size = New System.Drawing.Size(121, 73)
        Me.btoTransferir.TabIndex = 216
        Me.btoTransferir.TabStop = False
        Me.btoTransferir.Text = "Transferência <F1>"
        Me.btoTransferir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoTransferir.UseVisualStyleBackColor = False
        '
        'btoEstoque
        '
        Me.btoEstoque.BackColor = System.Drawing.Color.Transparent
        Me.btoEstoque.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoEstoque.FlatAppearance.BorderSize = 0
        Me.btoEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoEstoque.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoEstoque.ForeColor = System.Drawing.Color.Black
        Me.btoEstoque.Image = Global.nascomercio.My.Resources.Resources.tipo_de_produto
        Me.btoEstoque.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoEstoque.Location = New System.Drawing.Point(380, 420)
        Me.btoEstoque.Margin = New System.Windows.Forms.Padding(0)
        Me.btoEstoque.Name = "btoEstoque"
        Me.btoEstoque.Size = New System.Drawing.Size(107, 74)
        Me.btoEstoque.TabIndex = 217
        Me.btoEstoque.TabStop = False
        Me.btoEstoque.Text = "Estoque <Enter>"
        Me.btoEstoque.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoEstoque.UseVisualStyleBackColor = False
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProduto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProduto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cid, Me.Codigo, Me.descricao, Me.referencia, Me.valorCompra, Me.valorVenda, Me.Cor, Me.efdCategoria})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProduto.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProduto.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvProduto.Location = New System.Drawing.Point(24, 65)
        Me.dgvProduto.Name = "dgvProduto"
        Me.dgvProduto.ReadOnly = True
        Me.dgvProduto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProduto.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvProduto.RowHeadersVisible = False
        Me.dgvProduto.Size = New System.Drawing.Size(628, 335)
        Me.dgvProduto.TabIndex = 218
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
        Me.btoBalanco.Location = New System.Drawing.Point(664, 171)
        Me.btoBalanco.Margin = New System.Windows.Forms.Padding(0)
        Me.btoBalanco.Name = "btoBalanco"
        Me.btoBalanco.Size = New System.Drawing.Size(98, 76)
        Me.btoBalanco.TabIndex = 219
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
        Me.Panel1.Size = New System.Drawing.Size(765, 499)
        Me.Panel1.TabIndex = 220
        '
        'cid
        '
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cid.DefaultCellStyle = DataGridViewCellStyle2
        Me.cid.FillWeight = 50.0!
        Me.cid.HeaderText = "CID"
        Me.cid.Name = "cid"
        Me.cid.ReadOnly = True
        Me.cid.Visible = False
        '
        'Codigo
        '
        Me.Codigo.FillWeight = 50.0!
        Me.Codigo.HeaderText = "Código"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        '
        'descricao
        '
        Me.descricao.HeaderText = "Descrição"
        Me.descricao.Name = "descricao"
        Me.descricao.ReadOnly = True
        '
        'referencia
        '
        Me.referencia.FillWeight = 50.0!
        Me.referencia.HeaderText = "Referência"
        Me.referencia.Name = "referencia"
        Me.referencia.ReadOnly = True
        '
        'valorCompra
        '
        Me.valorCompra.FillWeight = 50.0!
        Me.valorCompra.HeaderText = "Valor Compra"
        Me.valorCompra.Name = "valorCompra"
        Me.valorCompra.ReadOnly = True
        '
        'valorVenda
        '
        Me.valorVenda.FillWeight = 50.0!
        Me.valorVenda.HeaderText = "Valor Venda"
        Me.valorVenda.Name = "valorVenda"
        Me.valorVenda.ReadOnly = True
        '
        'Cor
        '
        Me.Cor.FillWeight = 60.0!
        Me.Cor.HeaderText = "Cor"
        Me.Cor.Name = "Cor"
        Me.Cor.ReadOnly = True
        '
        'efdCategoria
        '
        Me.efdCategoria.HeaderText = "Categoria"
        Me.efdCategoria.Name = "efdCategoria"
        Me.efdCategoria.ReadOnly = True
        '
        'fProdutoEntradaSaidaLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(765, 499)
        Me.Controls.Add(Me.btoBalanco)
        Me.Controls.Add(Me.dgvProduto)
        Me.Controls.Add(Me.btoEstoque)
        Me.Controls.Add(Me.btoTransferir)
        Me.Controls.Add(Me.btoPesquisar)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fProdutoEntradaSaidaLista"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ProdutoEntradaSaida"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProduto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents btoPesquisar As System.Windows.Forms.Button
  Friend WithEvents btoTransferir As System.Windows.Forms.Button
  Friend WithEvents btoEstoque As System.Windows.Forms.Button
  Friend WithEvents dgvProduto As System.Windows.Forms.DataGridView
  Friend WithEvents btoBalanco As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents referencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valorCompra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valorVenda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents efdCategoria As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
