<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fNotaFiscalFornecedorLista
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
        Me.cboFornecedor = New System.Windows.Forms.ComboBox
        Me.txtDataEmissao = New System.Windows.Forms.MaskedTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSerie = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNumero = New System.Windows.Forms.TextBox
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.lblSubTitulo = New System.Windows.Forms.Label
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.btoSair = New System.Windows.Forms.Button
        Me.btoCadastro = New System.Windows.Forms.Button
        Me.imgLogo = New System.Windows.Forms.PictureBox
        Me.dgvNF = New System.Windows.Forms.DataGridView
        Me.numero = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.serie = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fornecedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataEmissao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valorTotalNota = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btoSelecionar = New System.Windows.Forms.Button
        Me.btoPesquisar = New System.Windows.Forms.Button
        Me.btoAlterar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboFornecedor
        '
        Me.cboFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFornecedor.FormattingEnabled = True
        Me.cboFornecedor.Location = New System.Drawing.Point(109, 108)
        Me.cboFornecedor.Name = "cboFornecedor"
        Me.cboFornecedor.Size = New System.Drawing.Size(138, 21)
        Me.cboFornecedor.TabIndex = 3
        '
        'txtDataEmissao
        '
        Me.txtDataEmissao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataEmissao.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataEmissao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataEmissao.Location = New System.Drawing.Point(379, 111)
        Me.txtDataEmissao.Mask = "00/00/0000"
        Me.txtDataEmissao.Name = "txtDataEmissao"
        Me.txtDataEmissao.Size = New System.Drawing.Size(93, 18)
        Me.txtDataEmissao.TabIndex = 4
        Me.txtDataEmissao.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(270, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 18)
        Me.Label3.TabIndex = 162
        Me.Label3.Text = "Data Emissão"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(12, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 18)
        Me.Label2.TabIndex = 161
        Me.Label2.Text = "Fornecedor"
        '
        'txtSerie
        '
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSerie.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.Location = New System.Drawing.Point(237, 83)
        Me.txtSerie.MaxLength = 10
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(46, 18)
        Me.txtSerie.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(185, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 18)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "Série"
        '
        'txtNumero
        '
        Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNumero.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.Location = New System.Drawing.Point(82, 84)
        Me.txtNumero.MaxLength = 20
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(98, 18)
        Me.txtNumero.TabIndex = 1
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblCodigo.Location = New System.Drawing.Point(12, 84)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(64, 18)
        Me.lblCodigo.TabIndex = 158
        Me.lblCodigo.Text = "Número"
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
        Me.lblSubTitulo.TabIndex = 154
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
        Me.lblTitulo.Size = New System.Drawing.Size(121, 24)
        Me.lblTitulo.TabIndex = 152
        Me.lblTitulo.Text = "Nota Fiscal"
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
        Me.btoSair.Location = New System.Drawing.Point(649, 9)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(100, 72)
        Me.btoSair.TabIndex = 6
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
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
        Me.btoCadastro.Location = New System.Drawing.Point(649, 86)
        Me.btoCadastro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoCadastro.Name = "btoCadastro"
        Me.btoCadastro.Size = New System.Drawing.Size(100, 72)
        Me.btoCadastro.TabIndex = 7
        Me.btoCadastro.TabStop = False
        Me.btoCadastro.Text = "Cadastro <F5>"
        Me.btoCadastro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoCadastro.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.caixa
        Me.imgLogo.Location = New System.Drawing.Point(8, 8)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 153
        Me.imgLogo.TabStop = False
        '
        'dgvNF
        '
        Me.dgvNF.AllowUserToAddRows = False
        Me.dgvNF.AllowUserToDeleteRows = False
        Me.dgvNF.AllowUserToOrderColumns = True
        Me.dgvNF.AllowUserToResizeColumns = False
        Me.dgvNF.AllowUserToResizeRows = False
        Me.dgvNF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvNF.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvNF.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvNF.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNF.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvNF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNF.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.numero, Me.serie, Me.fornecedor, Me.dataEmissao, Me.valorTotalNota})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvNF.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvNF.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvNF.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvNF.Location = New System.Drawing.Point(8, 135)
        Me.dgvNF.Name = "dgvNF"
        Me.dgvNF.ReadOnly = True
        Me.dgvNF.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvNF.RowHeadersVisible = False
        Me.dgvNF.Size = New System.Drawing.Size(628, 172)
        Me.dgvNF.TabIndex = 5
        '
        'numero
        '
        Me.numero.FillWeight = 75.58846!
        Me.numero.HeaderText = "Número"
        Me.numero.Name = "numero"
        Me.numero.ReadOnly = True
        '
        'serie
        '
        Me.serie.FillWeight = 69.41515!
        Me.serie.HeaderText = "Série"
        Me.serie.Name = "serie"
        Me.serie.ReadOnly = True
        '
        'fornecedor
        '
        Me.fornecedor.HeaderText = "Fornecedor"
        Me.fornecedor.Name = "fornecedor"
        Me.fornecedor.ReadOnly = True
        '
        'dataEmissao
        '
        Me.dataEmissao.FillWeight = 112.8644!
        Me.dataEmissao.HeaderText = "Data Emissão"
        Me.dataEmissao.Name = "dataEmissao"
        Me.dataEmissao.ReadOnly = True
        '
        'valorTotalNota
        '
        Me.valorTotalNota.FillWeight = 142.132!
        Me.valorTotalNota.HeaderText = "Valor Total da Nota"
        Me.valorTotalNota.Name = "valorTotalNota"
        Me.valorTotalNota.ReadOnly = True
        '
        'btoSelecionar
        '
        Me.btoSelecionar.BackColor = System.Drawing.Color.Transparent
        Me.btoSelecionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoSelecionar.FlatAppearance.BorderSize = 0
        Me.btoSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoSelecionar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoSelecionar.ForeColor = System.Drawing.Color.Black
        Me.btoSelecionar.Image = Global.nascomercio.My.Resources.Resources.selecionar
        Me.btoSelecionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoSelecionar.Location = New System.Drawing.Point(335, 316)
        Me.btoSelecionar.Name = "btoSelecionar"
        Me.btoSelecionar.Size = New System.Drawing.Size(101, 72)
        Me.btoSelecionar.TabIndex = 9
        Me.btoSelecionar.TabStop = False
        Me.btoSelecionar.Text = "Selecionar <F4>"
        Me.btoSelecionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSelecionar.UseVisualStyleBackColor = False
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
        Me.btoPesquisar.Location = New System.Drawing.Point(211, 316)
        Me.btoPesquisar.Margin = New System.Windows.Forms.Padding(0)
        Me.btoPesquisar.Name = "btoPesquisar"
        Me.btoPesquisar.Size = New System.Drawing.Size(120, 72)
        Me.btoPesquisar.TabIndex = 8
        Me.btoPesquisar.TabStop = False
        Me.btoPesquisar.Text = "Pesquisar <ENTER>"
        Me.btoPesquisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoPesquisar.UseVisualStyleBackColor = False
        '
        'btoAlterar
        '
        Me.btoAlterar.BackColor = System.Drawing.Color.Transparent
        Me.btoAlterar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoAlterar.FlatAppearance.BorderSize = 0
        Me.btoAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoAlterar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoAlterar.ForeColor = System.Drawing.Color.Black
        Me.btoAlterar.Image = Global.nascomercio.My.Resources.Resources.confirmar
        Me.btoAlterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoAlterar.Location = New System.Drawing.Point(442, 316)
        Me.btoAlterar.Name = "btoAlterar"
        Me.btoAlterar.Size = New System.Drawing.Size(89, 72)
        Me.btoAlterar.TabIndex = 10
        Me.btoAlterar.TabStop = False
        Me.btoAlterar.Text = "Alterar <F8>"
        Me.btoAlterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoAlterar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtCodigo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtSerie)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(762, 397)
        Me.Panel1.TabIndex = 163
        '
        'txtCodigo
        '
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(415, 83)
        Me.txtCodigo.MaxLength = 20
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(220, 18)
        Me.txtCodigo.TabIndex = 119
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(289, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 18)
        Me.Label4.TabIndex = 120
        Me.Label4.Text = "Código Produto"
        '
        'fNotaFiscalFornecedorLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(762, 397)
        Me.Controls.Add(Me.btoAlterar)
        Me.Controls.Add(Me.btoPesquisar)
        Me.Controls.Add(Me.btoSelecionar)
        Me.Controls.Add(Me.dgvNF)
        Me.Controls.Add(Me.cboFornecedor)
        Me.Controls.Add(Me.txtDataEmissao)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.btoCadastro)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fNotaFiscalFornecedorLista"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fNotaFiscalFornecedorLista"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
  Friend WithEvents cboFornecedor As System.Windows.Forms.ComboBox
  Friend WithEvents txtDataEmissao As System.Windows.Forms.MaskedTextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtSerie As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtNumero As System.Windows.Forms.TextBox
  Friend WithEvents lblCodigo As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents btoCadastro As System.Windows.Forms.Button
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents dgvNF As System.Windows.Forms.DataGridView
  Friend WithEvents btoSelecionar As System.Windows.Forms.Button
  Friend WithEvents btoPesquisar As System.Windows.Forms.Button
  Friend WithEvents numero As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents serie As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents fornecedor As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents dataEmissao As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents valorTotalNota As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents btoAlterar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
