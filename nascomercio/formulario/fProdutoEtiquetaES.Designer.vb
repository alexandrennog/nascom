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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.dgvProdutos = New System.Windows.Forms.DataGridView
    Me.btoSair = New System.Windows.Forms.Button
    Me.btoImprimir = New System.Windows.Forms.Button
    Me.lblCodigo = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtDataDe = New System.Windows.Forms.MaskedTextBox
    Me.txtDataAte = New System.Windows.Forms.MaskedTextBox
    Me.btoPesquisar = New System.Windows.Forms.Button
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.check = New System.Windows.Forms.DataGridViewCheckBoxColumn
    Me.data = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.produto_cid = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.produtoItem_codigoBarras = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Referencia = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Cor = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.quantidade = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.impressao = New System.Windows.Forms.DataGridViewTextBoxColumn
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.lblSubTitulo.Size = New System.Drawing.Size(70, 14)
    Me.lblSubTitulo.TabIndex = 131
    Me.lblSubTitulo.Text = "IMPRESSÃO"
    '
    'lblTitulo
    '
    Me.lblTitulo.AutoSize = True
    Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblTitulo.Location = New System.Drawing.Point(64, 8)
    Me.lblTitulo.Name = "lblTitulo"
    Me.lblTitulo.Size = New System.Drawing.Size(145, 24)
    Me.lblTitulo.TabIndex = 129
    Me.lblTitulo.Text = "Etiquetas E/S"
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.print_design
    Me.imgLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
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
    Me.dgvProdutos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.dgvProdutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dgvProdutos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgvProdutos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.check, Me.data, Me.produto_cid, Me.produtoItem_codigoBarras, Me.Referencia, Me.Cor, Me.quantidade, Me.impressao})
    Me.dgvProdutos.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvProdutos.Location = New System.Drawing.Point(8, 108)
    Me.dgvProdutos.Name = "dgvProdutos"
    Me.dgvProdutos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    Me.dgvProdutos.RowHeadersVisible = False
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    Me.dgvProdutos.RowsDefaultCellStyle = DataGridViewCellStyle2
    Me.dgvProdutos.Size = New System.Drawing.Size(761, 360)
    Me.dgvProdutos.TabIndex = 132
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
    Me.btoSair.Location = New System.Drawing.Point(416, 480)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(88, 72)
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
    Me.btoImprimir.Location = New System.Drawing.Point(316, 480)
    Me.btoImprimir.Name = "btoImprimir"
    Me.btoImprimir.Size = New System.Drawing.Size(96, 72)
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
    Me.lblCodigo.Location = New System.Drawing.Point(148, 76)
    Me.lblCodigo.Name = "lblCodigo"
    Me.lblCodigo.Size = New System.Drawing.Size(28, 18)
    Me.lblCodigo.TabIndex = 136
    Me.lblCodigo.Text = "De"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label1.Location = New System.Drawing.Point(292, 76)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(31, 18)
    Me.Label1.TabIndex = 138
    Me.Label1.Text = "Até"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.BackColor = System.Drawing.Color.Transparent
    Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label2.Location = New System.Drawing.Point(8, 76)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(121, 18)
    Me.Label2.TabIndex = 139
    Me.Label2.Text = "Data de Entrada"
    '
    'txtDataDe
    '
    Me.txtDataDe.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDataDe.Culture = New System.Globalization.CultureInfo("")
    Me.txtDataDe.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtDataDe.Location = New System.Drawing.Point(180, 76)
    Me.txtDataDe.Mask = "00/00/0000"
    Me.txtDataDe.Name = "txtDataDe"
    Me.txtDataDe.Size = New System.Drawing.Size(92, 18)
    Me.txtDataDe.TabIndex = 140
    Me.txtDataDe.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    Me.txtDataDe.ValidatingType = GetType(Date)
    '
    'txtDataAte
    '
    Me.txtDataAte.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDataAte.Culture = New System.Globalization.CultureInfo("")
    Me.txtDataAte.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtDataAte.Location = New System.Drawing.Point(328, 76)
    Me.txtDataAte.Mask = "00/00/0000"
    Me.txtDataAte.Name = "txtDataAte"
    Me.txtDataAte.Size = New System.Drawing.Size(92, 18)
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
    Me.btoPesquisar.Location = New System.Drawing.Point(192, 480)
    Me.btoPesquisar.Name = "btoPesquisar"
    Me.btoPesquisar.Size = New System.Drawing.Size(120, 72)
    Me.btoPesquisar.TabIndex = 142
    Me.btoPesquisar.TabStop = False
    Me.btoPesquisar.Text = "Pesquisar <Enter>"
    Me.btoPesquisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoPesquisar.UseVisualStyleBackColor = False
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(777, 557)
    Me.Panel1.TabIndex = 143
    '
    'check
    '
    Me.check.FillWeight = 50.0!
    Me.check.Frozen = True
    Me.check.HeaderText = ""
    Me.check.Name = "check"
    Me.check.Width = 50
    '
    'data
    '
    Me.data.FillWeight = 130.0!
    Me.data.Frozen = True
    Me.data.HeaderText = "Data"
    Me.data.Name = "data"
    Me.data.ReadOnly = True
    Me.data.Width = 130
    '
    'produto_cid
    '
    Me.produto_cid.FillWeight = 150.0!
    Me.produto_cid.Frozen = True
    Me.produto_cid.HeaderText = "Código Produto"
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
    Me.produtoItem_codigoBarras.Name = "produtoItem_codigoBarras"
    Me.produtoItem_codigoBarras.ReadOnly = True
    Me.produtoItem_codigoBarras.Width = 170
    '
    'Referencia
    '
    Me.Referencia.Frozen = True
    Me.Referencia.HeaderText = "Ref."
    Me.Referencia.Name = "Referencia"
    '
    'Cor
    '
    Me.Cor.FillWeight = 110.0!
    Me.Cor.Frozen = True
    Me.Cor.HeaderText = "Cor"
    Me.Cor.Name = "Cor"
    Me.Cor.Width = 110
    '
    'quantidade
    '
    Me.quantidade.FillWeight = 91.32093!
    Me.quantidade.Frozen = True
    Me.quantidade.HeaderText = "Quantidade"
    Me.quantidade.Name = "quantidade"
    Me.quantidade.ReadOnly = True
    Me.quantidade.Width = 118
    '
    'impressao
    '
    Me.impressao.FillWeight = 80.0!
    Me.impressao.Frozen = True
    Me.impressao.HeaderText = "Impresso"
    Me.impressao.Name = "impressao"
    Me.impressao.ReadOnly = True
    Me.impressao.Width = 80
    '
    'fProdutoEtiquetaES
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(778, 557)
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
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fProdutoEtiquetaES"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "fProdutoESEtiqueta"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
