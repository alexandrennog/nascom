<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProdutoEtiquetaES
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.dgvProdutos = New System.Windows.Forms.DataGridView()
        Me.check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.produto_cid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.produtoItem_codigoBarras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.impressao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.btoImprimir = New System.Windows.Forms.Button()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDataDe = New System.Windows.Forms.MaskedTextBox()
        Me.txtDataAte = New System.Windows.Forms.MaskedTextBox()
        Me.btoPesquisar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpImprimir = New System.Windows.Forms.GroupBox()
        Me.rdbTodos = New System.Windows.Forms.RadioButton()
        Me.rdbNaoImpresso = New System.Windows.Forms.RadioButton()
        Me.chkMarcarTodos = New System.Windows.Forms.CheckBox()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.grpImprimir.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSubTitulo.Location = New System.Drawing.Point(85, 39)
        Me.lblSubTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(91, 16)
        Me.lblSubTitulo.TabIndex = 131
        Me.lblSubTitulo.Text = "IMPRESSÃO"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(85, 10)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(189, 32)
        Me.lblTitulo.TabIndex = 129
        Me.lblTitulo.Text = "Etiquetas E/S"
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.print_design
        Me.imgLogo.Location = New System.Drawing.Point(11, 10)
        Me.imgLogo.Margin = New System.Windows.Forms.Padding(4)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(67, 62)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 130
        Me.imgLogo.TabStop = False
        '
        'dgvProdutos
        '
        Me.dgvProdutos.AllowUserToAddRows = False
        Me.dgvProdutos.AllowUserToDeleteRows = False
        Me.dgvProdutos.AllowUserToOrderColumns = True
        Me.dgvProdutos.AllowUserToResizeColumns = False
        Me.dgvProdutos.AllowUserToResizeRows = False
        Me.dgvProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvProdutos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvProdutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProdutos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProdutos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.check, Me.data, Me.produto_cid, Me.produtoItem_codigoBarras, Me.Referencia, Me.Cor, Me.quantidade, Me.impressao})
        Me.dgvProdutos.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvProdutos.Location = New System.Drawing.Point(11, 133)
        Me.dgvProdutos.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvProdutos.Name = "dgvProdutos"
        Me.dgvProdutos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvProdutos.RowHeadersVisible = False
        Me.dgvProdutos.RowHeadersWidth = 51
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.dgvProdutos.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvProdutos.Size = New System.Drawing.Size(1015, 443)
        Me.dgvProdutos.TabIndex = 132
        '
        'check
        '
        Me.check.FillWeight = 50.0!
        Me.check.Frozen = True
        Me.check.HeaderText = ""
        Me.check.MinimumWidth = 6
        Me.check.Name = "check"
        Me.check.Width = 6
        '
        'data
        '
        Me.data.FillWeight = 130.0!
        Me.data.Frozen = True
        Me.data.HeaderText = "Data"
        Me.data.MinimumWidth = 6
        Me.data.Name = "data"
        Me.data.ReadOnly = True
        Me.data.Width = 74
        '
        'produto_cid
        '
        Me.produto_cid.FillWeight = 150.0!
        Me.produto_cid.Frozen = True
        Me.produto_cid.HeaderText = "Código Produto"
        Me.produto_cid.MinimumWidth = 6
        Me.produto_cid.Name = "produto_cid"
        Me.produto_cid.ReadOnly = True
        Me.produto_cid.Visible = False
        Me.produto_cid.Width = 150
        '
        'produtoItem_codigoBarras
        '
        Me.produtoItem_codigoBarras.FillWeight = 170.0!
        Me.produtoItem_codigoBarras.Frozen = True
        Me.produtoItem_codigoBarras.HeaderText = "Código Barras"
        Me.produtoItem_codigoBarras.MinimumWidth = 6
        Me.produtoItem_codigoBarras.Name = "produtoItem_codigoBarras"
        Me.produtoItem_codigoBarras.ReadOnly = True
        Me.produtoItem_codigoBarras.Width = 139
        '
        'Referencia
        '
        Me.Referencia.Frozen = True
        Me.Referencia.HeaderText = "Ref."
        Me.Referencia.MinimumWidth = 6
        Me.Referencia.Name = "Referencia"
        Me.Referencia.Width = 69
        '
        'Cor
        '
        Me.Cor.FillWeight = 110.0!
        Me.Cor.Frozen = True
        Me.Cor.HeaderText = "Cor"
        Me.Cor.MinimumWidth = 6
        Me.Cor.Name = "Cor"
        Me.Cor.Width = 67
        '
        'quantidade
        '
        Me.quantidade.FillWeight = 91.32093!
        Me.quantidade.Frozen = True
        Me.quantidade.HeaderText = "Quantidade"
        Me.quantidade.MinimumWidth = 6
        Me.quantidade.Name = "quantidade"
        Me.quantidade.ReadOnly = True
        Me.quantidade.Width = 128
        '
        'impressao
        '
        Me.impressao.FillWeight = 80.0!
        Me.impressao.Frozen = True
        Me.impressao.HeaderText = "Impresso"
        Me.impressao.MinimumWidth = 6
        Me.impressao.Name = "impressao"
        Me.impressao.ReadOnly = True
        Me.impressao.Width = 110
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
        Me.btoSair.Location = New System.Drawing.Point(555, 591)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(4)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(117, 89)
        Me.btoSair.TabIndex = 133
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <ESC>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'btoImprimir
        '
        Me.btoImprimir.BackColor = System.Drawing.Color.Transparent
        Me.btoImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoImprimir.FlatAppearance.BorderSize = 0
        Me.btoImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoImprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoImprimir.ForeColor = System.Drawing.Color.Black
        Me.btoImprimir.Image = Global.nascomercio.My.Resources.Resources.print_design
        Me.btoImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoImprimir.Location = New System.Drawing.Point(421, 591)
        Me.btoImprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.btoImprimir.Name = "btoImprimir"
        Me.btoImprimir.Size = New System.Drawing.Size(128, 89)
        Me.btoImprimir.TabIndex = 134
        Me.btoImprimir.TabStop = False
        Me.btoImprimir.Text = "Imprimir <F5>"
        Me.btoImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoImprimir.UseVisualStyleBackColor = False
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblCodigo.Location = New System.Drawing.Point(197, 94)
        Me.lblCodigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(35, 22)
        Me.lblCodigo.TabIndex = 136
        Me.lblCodigo.Text = "De"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(389, 94)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 22)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "Até"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(11, 94)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 22)
        Me.Label2.TabIndex = 139
        Me.Label2.Text = "Data de Entrada"
        '
        'txtDataDe
        '
        Me.txtDataDe.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataDe.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataDe.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataDe.Location = New System.Drawing.Point(240, 94)
        Me.txtDataDe.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDataDe.Mask = "00/00/0000"
        Me.txtDataDe.Name = "txtDataDe"
        Me.txtDataDe.Size = New System.Drawing.Size(123, 22)
        Me.txtDataDe.TabIndex = 140
        Me.txtDataDe.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtDataDe.ValidatingType = GetType(Date)
        '
        'txtDataAte
        '
        Me.txtDataAte.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataAte.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataAte.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataAte.Location = New System.Drawing.Point(437, 94)
        Me.txtDataAte.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDataAte.Mask = "00/00/0000"
        Me.txtDataAte.Name = "txtDataAte"
        Me.txtDataAte.Size = New System.Drawing.Size(123, 22)
        Me.txtDataAte.TabIndex = 141
        Me.txtDataAte.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtDataAte.ValidatingType = GetType(Date)
        '
        'btoPesquisar
        '
        Me.btoPesquisar.BackColor = System.Drawing.Color.Transparent
        Me.btoPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoPesquisar.FlatAppearance.BorderSize = 0
        Me.btoPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoPesquisar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoPesquisar.ForeColor = System.Drawing.Color.Black
        Me.btoPesquisar.Image = Global.nascomercio.My.Resources.Resources.confirmar
        Me.btoPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoPesquisar.Location = New System.Drawing.Point(256, 591)
        Me.btoPesquisar.Margin = New System.Windows.Forms.Padding(4)
        Me.btoPesquisar.Name = "btoPesquisar"
        Me.btoPesquisar.Size = New System.Drawing.Size(160, 89)
        Me.btoPesquisar.TabIndex = 142
        Me.btoPesquisar.TabStop = False
        Me.btoPesquisar.Text = "Pesquisar <Enter>"
        Me.btoPesquisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoPesquisar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.grpImprimir)
        Me.Panel1.Controls.Add(Me.chkMarcarTodos)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1035, 685)
        Me.Panel1.TabIndex = 143
        '
        'grpImprimir
        '
        Me.grpImprimir.Controls.Add(Me.rdbTodos)
        Me.grpImprimir.Controls.Add(Me.rdbNaoImpresso)
        Me.grpImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpImprimir.Location = New System.Drawing.Point(598, 38)
        Me.grpImprimir.Name = "grpImprimir"
        Me.grpImprimir.Size = New System.Drawing.Size(334, 86)
        Me.grpImprimir.TabIndex = 146
        Me.grpImprimir.TabStop = False
        Me.grpImprimir.Text = "Imprimir"
        '
        'rdbTodos
        '
        Me.rdbTodos.AutoSize = True
        Me.rdbTodos.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.rdbTodos.Location = New System.Drawing.Point(202, 42)
        Me.rdbTodos.Name = "rdbTodos"
        Me.rdbTodos.Size = New System.Drawing.Size(90, 26)
        Me.rdbTodos.TabIndex = 1
        Me.rdbTodos.Text = "Todos"
        Me.rdbTodos.UseVisualStyleBackColor = True
        '
        'rdbNaoImpresso
        '
        Me.rdbNaoImpresso.AutoSize = True
        Me.rdbNaoImpresso.Checked = True
        Me.rdbNaoImpresso.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.rdbNaoImpresso.Location = New System.Drawing.Point(19, 42)
        Me.rdbNaoImpresso.Name = "rdbNaoImpresso"
        Me.rdbNaoImpresso.Size = New System.Drawing.Size(159, 26)
        Me.rdbNaoImpresso.TabIndex = 0
        Me.rdbNaoImpresso.TabStop = True
        Me.rdbNaoImpresso.Text = "Não Impresso"
        Me.rdbNaoImpresso.UseVisualStyleBackColor = True
        '
        'chkMarcarTodos
        '
        Me.chkMarcarTodos.AutoSize = True
        Me.chkMarcarTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMarcarTodos.Location = New System.Drawing.Point(10, 606)
        Me.chkMarcarTodos.Name = "chkMarcarTodos"
        Me.chkMarcarTodos.Size = New System.Drawing.Size(120, 20)
        Me.chkMarcarTodos.TabIndex = 0
        Me.chkMarcarTodos.Text = "Marcar todos"
        Me.chkMarcarTodos.UseVisualStyleBackColor = True
        '
        'fProdutoEtiquetaES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1037, 686)
        Me.Controls.Add(Me.btoPesquisar)
        Me.Controls.Add(Me.txtDataAte)
        Me.Controls.Add(Me.txtDataDe)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.btoImprimir)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.dgvProdutos)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fProdutoEtiquetaES"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fProdutoESEtiqueta"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpImprimir.ResumeLayout(False)
        Me.grpImprimir.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents dgvProdutos As System.Windows.Forms.DataGridView
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents btoImprimir As System.Windows.Forms.Button
  Friend WithEvents lblCodigo As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtDataDe As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtDataAte As System.Windows.Forms.MaskedTextBox
  Friend WithEvents btoPesquisar As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents check As System.Windows.Forms.DataGridViewCheckBoxColumn
  Friend WithEvents data As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents produto_cid As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents produtoItem_codigoBarras As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Referencia As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Cor As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents quantidade As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents impressao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkMarcarTodos As CheckBox
    Friend WithEvents grpImprimir As GroupBox
    Friend WithEvents rdbTodos As RadioButton
    Friend WithEvents rdbNaoImpresso As RadioButton
End Class
