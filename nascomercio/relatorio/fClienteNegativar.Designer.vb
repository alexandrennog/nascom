<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fClienteNegativar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fClienteNegativar))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btoSalvar = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnSelecionar = New System.Windows.Forms.Button()
        Me.btoDesmarcar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvProdutos = New System.Windows.Forms.DataGridView()
        Me.txtDataFinal = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDataInicial = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btoFiltro = New System.Windows.Forms.Button()
        Me.btoMalaDireta = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Telefone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btoSair.Location = New System.Drawing.Point(1015, 15)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(72, 103)
        Me.btoSair.TabIndex = 93
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
        Me.lblSubTitulo.Location = New System.Drawing.Point(85, 39)
        Me.lblSubTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(45, 16)
        Me.lblSubTitulo.TabIndex = 91
        Me.lblSubTitulo.Text = "LISTA"
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.relatorio
        Me.imgLogo.Location = New System.Drawing.Point(11, 10)
        Me.imgLogo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(67, 62)
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
        Me.lblTitulo.Location = New System.Drawing.Point(85, 10)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(270, 32)
        Me.lblTitulo.TabIndex = 89
        Me.lblTitulo.Text = "Clientes Devedores"
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
        Me.btoSalvar.Location = New System.Drawing.Point(449, 620)
        Me.btoSalvar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(92, 101)
        Me.btoSalvar.TabIndex = 95
        Me.btoSalvar.TabStop = False
        Me.btoSalvar.Text = "Negativar <Enter>"
        Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSalvar.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(89, 642)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(171, 18)
        Me.Label20.TabIndex = 176
        Me.Label20.Text = "Selecionar Todos <F1>"
        '
        'btnSelecionar
        '
        Me.btnSelecionar.BackColor = System.Drawing.Color.Transparent
        Me.btnSelecionar.BackgroundImage = CType(resources.GetObject("btnSelecionar.BackgroundImage"), System.Drawing.Image)
        Me.btnSelecionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSelecionar.FlatAppearance.BorderSize = 0
        Me.btnSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelecionar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelecionar.ForeColor = System.Drawing.Color.White
        Me.btnSelecionar.Location = New System.Drawing.Point(55, 636)
        Me.btnSelecionar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSelecionar.Name = "btnSelecionar"
        Me.btnSelecionar.Size = New System.Drawing.Size(33, 31)
        Me.btnSelecionar.TabIndex = 175
        Me.btnSelecionar.TabStop = False
        Me.btnSelecionar.UseVisualStyleBackColor = False
        '
        'btoDesmarcar
        '
        Me.btoDesmarcar.BackColor = System.Drawing.Color.Transparent
        Me.btoDesmarcar.BackgroundImage = CType(resources.GetObject("btoDesmarcar.BackgroundImage"), System.Drawing.Image)
        Me.btoDesmarcar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoDesmarcar.FlatAppearance.BorderSize = 0
        Me.btoDesmarcar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoDesmarcar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoDesmarcar.ForeColor = System.Drawing.Color.White
        Me.btoDesmarcar.Location = New System.Drawing.Point(55, 674)
        Me.btoDesmarcar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btoDesmarcar.Name = "btoDesmarcar"
        Me.btoDesmarcar.Size = New System.Drawing.Size(33, 31)
        Me.btoDesmarcar.TabIndex = 177
        Me.btoDesmarcar.TabStop = False
        Me.btoDesmarcar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 679)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(171, 18)
        Me.Label1.TabIndex = 178
        Me.Label1.Text = "Desmarcar Todos <F2>"
        '
        'dgvProdutos
        '
        Me.dgvProdutos.AllowUserToAddRows = False
        Me.dgvProdutos.AllowUserToDeleteRows = False
        Me.dgvProdutos.AllowUserToOrderColumns = True
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
        Me.dgvProdutos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.check, Me.cid, Me.codigo, Me.nome, Me.Telefone, Me.valor, Me.data})
        Me.dgvProdutos.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvProdutos.Location = New System.Drawing.Point(16, 122)
        Me.dgvProdutos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvProdutos.Name = "dgvProdutos"
        Me.dgvProdutos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvProdutos.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.dgvProdutos.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProdutos.Size = New System.Drawing.Size(1071, 474)
        Me.dgvProdutos.TabIndex = 179
        '
        'txtDataFinal
        '
        Me.txtDataFinal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataFinal.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataFinal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataFinal.Location = New System.Drawing.Point(384, 78)
        Me.txtDataFinal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDataFinal.Mask = "00/00/0000"
        Me.txtDataFinal.Name = "txtDataFinal"
        Me.txtDataFinal.Size = New System.Drawing.Size(113, 22)
        Me.txtDataFinal.TabIndex = 215
        Me.txtDataFinal.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(336, 78)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 22)
        Me.Label2.TabIndex = 214
        Me.Label2.Text = "até"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDataInicial
        '
        Me.txtDataInicial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataInicial.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataInicial.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataInicial.Location = New System.Drawing.Point(215, 78)
        Me.txtDataInicial.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDataInicial.Mask = "00/00/0000"
        Me.txtDataInicial.Name = "txtDataInicial"
        Me.txtDataInicial.Size = New System.Drawing.Size(113, 22)
        Me.txtDataInicial.TabIndex = 213
        Me.txtDataInicial.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(87, 78)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 22)
        Me.Label4.TabIndex = 212
        Me.Label4.Text = "Período: de"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.btoFiltro.Location = New System.Drawing.Point(905, 15)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(101, 103)
        Me.btoFiltro.TabIndex = 216
        Me.btoFiltro.Text = "Pesquisar [F5]"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
        '
        'btoMalaDireta
        '
        Me.btoMalaDireta.BackColor = System.Drawing.Color.Transparent
        Me.btoMalaDireta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoMalaDireta.FlatAppearance.BorderSize = 0
        Me.btoMalaDireta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoMalaDireta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoMalaDireta.ForeColor = System.Drawing.Color.Black
        Me.btoMalaDireta.Image = Global.nascomercio.My.Resources.Resources.relatorio
        Me.btoMalaDireta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoMalaDireta.Location = New System.Drawing.Point(572, 620)
        Me.btoMalaDireta.Margin = New System.Windows.Forms.Padding(0)
        Me.btoMalaDireta.Name = "btoMalaDireta"
        Me.btoMalaDireta.Size = New System.Drawing.Size(135, 101)
        Me.btoMalaDireta.TabIndex = 217
        Me.btoMalaDireta.Text = "Mala Direta <F7>"
        Me.btoMalaDireta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoMalaDireta.UseVisualStyleBackColor = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(16, 603)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1071, 14)
        Me.ProgressBar1.TabIndex = 218
        '
        'check
        '
        Me.check.FillWeight = 50.0!
        Me.check.Frozen = True
        Me.check.HeaderText = ""
        Me.check.Name = "check"
        Me.check.Width = 50
        '
        'cid
        '
        Me.cid.Frozen = True
        Me.cid.HeaderText = "cid"
        Me.cid.Name = "cid"
        Me.cid.Visible = False
        '
        'codigo
        '
        Me.codigo.FillWeight = 150.0!
        Me.codigo.Frozen = True
        Me.codigo.HeaderText = "Código"
        Me.codigo.Name = "codigo"
        '
        'nome
        '
        Me.nome.FillWeight = 91.32093!
        Me.nome.HeaderText = "Nome"
        Me.nome.Name = "nome"
        Me.nome.Width = 300
        '
        'Telefone
        '
        Me.Telefone.HeaderText = "Telefone"
        Me.Telefone.Name = "Telefone"
        Me.Telefone.ReadOnly = True
        '
        'valor
        '
        Me.valor.FillWeight = 80.0!
        Me.valor.HeaderText = "Valor"
        Me.valor.Name = "valor"
        '
        'data
        '
        Me.data.FillWeight = 91.32093!
        Me.data.HeaderText = "Data"
        Me.data.Name = "data"
        Me.data.Width = 130
        '
        'fClienteNegativar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1103, 734)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btoMalaDireta)
        Me.Controls.Add(Me.btoFiltro)
        Me.Controls.Add(Me.txtDataFinal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDataInicial)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgvProdutos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btoDesmarcar)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.btnSelecionar)
        Me.Controls.Add(Me.btoSalvar)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.lblTitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fClienteNegativar"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produtos"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents btnSelecionar As System.Windows.Forms.Button
  Friend WithEvents btoDesmarcar As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents dgvProdutos As System.Windows.Forms.DataGridView
  Friend WithEvents txtDataFinal As System.Windows.Forms.MaskedTextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtDataInicial As System.Windows.Forms.MaskedTextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents btoFiltro As System.Windows.Forms.Button
    Friend WithEvents btoMalaDireta As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents check As DataGridViewCheckBoxColumn
    Friend WithEvents cid As DataGridViewTextBoxColumn
    Friend WithEvents codigo As DataGridViewTextBoxColumn
    Friend WithEvents nome As DataGridViewTextBoxColumn
    Friend WithEvents Telefone As DataGridViewTextBoxColumn
    Friend WithEvents valor As DataGridViewTextBoxColumn
    Friend WithEvents data As DataGridViewTextBoxColumn
End Class
