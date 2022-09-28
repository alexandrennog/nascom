<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fClienteMalaDireta
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fClienteMalaDireta))
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.btoSair = New System.Windows.Forms.Button
    Me.btoFiltro = New System.Windows.Forms.Button
    Me.dgvCliente = New System.Windows.Forms.DataGridView
    Me.check = New System.Windows.Forms.DataGridViewCheckBoxColumn
    Me.cid = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Cpf = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Rg = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Situacao = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Ddd = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Telefone = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Label1 = New System.Windows.Forms.Label
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.imprimirArgoxRadioButton = New System.Windows.Forms.RadioButton
    Me.imprimirEJT30RadioButton = New System.Windows.Forms.RadioButton
    Me.imprimirEJT20RadioButton = New System.Windows.Forms.RadioButton
    Me.Label3 = New System.Windows.Forms.Label
    Me.btoDesmarcar = New System.Windows.Forms.Button
    Me.Label20 = New System.Windows.Forms.Label
    Me.btnSelecionar = New System.Windows.Forms.Button
    Me.btoImprimir = New System.Windows.Forms.Button
    Me.txtCliente = New System.Windows.Forms.TextBox
    Me.lblCliente = New System.Windows.Forms.Label
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgvCliente, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'lblSubTitulo
    '
    Me.lblSubTitulo.AutoSize = True
    Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblSubTitulo.Location = New System.Drawing.Point(-159, -51)
    Me.lblSubTitulo.Name = "lblSubTitulo"
    Me.lblSubTitulo.Size = New System.Drawing.Size(39, 14)
    Me.lblSubTitulo.TabIndex = 79
    Me.lblSubTitulo.Text = "LISTA"
    '
    'lblTitulo
    '
    Me.lblTitulo.AutoSize = True
    Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblTitulo.Location = New System.Drawing.Point(-162, -75)
    Me.lblTitulo.Name = "lblTitulo"
    Me.lblTitulo.Size = New System.Drawing.Size(151, 24)
    Me.lblTitulo.TabIndex = 77
    Me.lblTitulo.Text = "Fornecedores"
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.usuarios
    Me.imgLogo.Location = New System.Drawing.Point(-217, -74)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 78
    Me.imgLogo.TabStop = False
    '
    'btoSair
    '
    Me.btoSair.BackColor = System.Drawing.Color.Transparent
    Me.btoSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoSair.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btoSair.FlatAppearance.BorderSize = 0
    Me.btoSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoSair.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoSair.ForeColor = System.Drawing.Color.Black
    Me.btoSair.Image = Global.nascomercio.My.Resources.Resources.fechar
    Me.btoSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoSair.Location = New System.Drawing.Point(688, 8)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(100, 72)
    Me.btoSair.TabIndex = 4
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSair.UseVisualStyleBackColor = False
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
    Me.btoFiltro.Location = New System.Drawing.Point(687, 82)
    Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
    Me.btoFiltro.Name = "btoFiltro"
    Me.btoFiltro.Size = New System.Drawing.Size(100, 72)
    Me.btoFiltro.TabIndex = 6
    Me.btoFiltro.Text = "Pesquisar <F6>"
    Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoFiltro.UseVisualStyleBackColor = False
    '
    'dgvCliente
    '
    Me.dgvCliente.AllowUserToAddRows = False
    Me.dgvCliente.AllowUserToDeleteRows = False
    Me.dgvCliente.AllowUserToResizeColumns = False
    Me.dgvCliente.AllowUserToResizeRows = False
    Me.dgvCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
    Me.dgvCliente.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvCliente.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.dgvCliente.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dgvCliente.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
    Me.dgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgvCliente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.check, Me.cid, Me.Nome, Me.Cpf, Me.Rg, Me.Situacao, Me.Ddd, Me.Telefone, Me.Email})
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
    DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.dgvCliente.DefaultCellStyle = DataGridViewCellStyle4
    Me.dgvCliente.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvCliente.Location = New System.Drawing.Point(11, 107)
    Me.dgvCliente.Name = "dgvCliente"
    Me.dgvCliente.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    Me.dgvCliente.RowHeadersVisible = False
    Me.dgvCliente.Size = New System.Drawing.Size(664, 249)
    Me.dgvCliente.TabIndex = 2
    '
    'check
    '
    Me.check.HeaderText = ""
    Me.check.Name = "check"
    Me.check.Width = 5
    '
    'cid
    '
    Me.cid.HeaderText = "CID"
    Me.cid.Name = "cid"
    Me.cid.Width = 53
    '
    'Nome
    '
    Me.Nome.HeaderText = "Nome"
    Me.Nome.Name = "Nome"
    Me.Nome.Width = 68
    '
    'Cpf
    '
    Me.Cpf.HeaderText = "CPF"
    Me.Cpf.Name = "Cpf"
    Me.Cpf.Width = 57
    '
    'Rg
    '
    Me.Rg.HeaderText = "RG"
    Me.Rg.Name = "Rg"
    Me.Rg.Width = 50
    '
    'Situacao
    '
    Me.Situacao.HeaderText = "Situção"
    Me.Situacao.Name = "Situacao"
    Me.Situacao.Width = 79
    '
    'Ddd
    '
    Me.Ddd.HeaderText = "DDD"
    Me.Ddd.Name = "Ddd"
    Me.Ddd.Width = 58
    '
    'Telefone
    '
    Me.Telefone.HeaderText = "Telefone"
    Me.Telefone.Name = "Telefone"
    Me.Telefone.Width = 87
    '
    'Email
    '
    Me.Email.HeaderText = "E-mail"
    Me.Email.Name = "Email"
    Me.Email.Width = 71
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.Label1.Location = New System.Drawing.Point(64, 32)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(67, 14)
    Me.Label1.TabIndex = 82
    Me.Label1.Text = "Mala Direta"
    '
    'PictureBox1
    '
    Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
    Me.PictureBox1.Image = Global.nascomercio.My.Resources.Resources.cliente
    Me.PictureBox1.Location = New System.Drawing.Point(8, 8)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.PictureBox1.TabIndex = 81
    Me.PictureBox1.TabStop = False
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.BackColor = System.Drawing.Color.Transparent
    Me.Label2.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.Label2.Location = New System.Drawing.Point(64, 8)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(91, 24)
    Me.Label2.TabIndex = 80
    Me.Label2.Text = "Clientes"
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Controls.Add(Me.imprimirArgoxRadioButton)
    Me.Panel1.Controls.Add(Me.imprimirEJT30RadioButton)
    Me.Panel1.Controls.Add(Me.imprimirEJT20RadioButton)
    Me.Panel1.Controls.Add(Me.Label3)
    Me.Panel1.Controls.Add(Me.btoDesmarcar)
    Me.Panel1.Controls.Add(Me.Label20)
    Me.Panel1.Controls.Add(Me.btnSelecionar)
    Me.Panel1.Controls.Add(Me.btoImprimir)
    Me.Panel1.Controls.Add(Me.btoFiltro)
    Me.Panel1.Controls.Add(Me.txtCliente)
    Me.Panel1.Controls.Add(Me.lblCliente)
    Me.Panel1.Controls.Add(Me.dgvCliente)
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(793, 444)
    Me.Panel1.TabIndex = 83
    '
    'imprimirArgoxRadioButton
    '
    Me.imprimirArgoxRadioButton.AutoSize = True
    Me.imprimirArgoxRadioButton.Location = New System.Drawing.Point(390, 82)
    Me.imprimirArgoxRadioButton.Name = "imprimirArgoxRadioButton"
    Me.imprimirArgoxRadioButton.Size = New System.Drawing.Size(52, 17)
    Me.imprimirArgoxRadioButton.TabIndex = 184
    Me.imprimirArgoxRadioButton.Text = "Argox"
    Me.imprimirArgoxRadioButton.UseVisualStyleBackColor = True
    '
    'imprimirEJT30RadioButton
    '
    Me.imprimirEJT30RadioButton.AutoSize = True
    Me.imprimirEJT30RadioButton.Location = New System.Drawing.Point(390, 63)
    Me.imprimirEJT30RadioButton.Name = "imprimirEJT30RadioButton"
    Me.imprimirEJT30RadioButton.Size = New System.Drawing.Size(192, 17)
    Me.imprimirEJT30RadioButton.TabIndex = 183
    Me.imprimirEJT30RadioButton.Text = "Jato de Tinta 30 etiquetas por folha"
    Me.imprimirEJT30RadioButton.UseVisualStyleBackColor = True
    '
    'imprimirEJT20RadioButton
    '
    Me.imprimirEJT20RadioButton.AutoSize = True
    Me.imprimirEJT20RadioButton.Checked = True
    Me.imprimirEJT20RadioButton.ForeColor = System.Drawing.SystemColors.Desktop
    Me.imprimirEJT20RadioButton.Location = New System.Drawing.Point(390, 40)
    Me.imprimirEJT20RadioButton.Name = "imprimirEJT20RadioButton"
    Me.imprimirEJT20RadioButton.Size = New System.Drawing.Size(192, 17)
    Me.imprimirEJT20RadioButton.TabIndex = 182
    Me.imprimirEJT20RadioButton.TabStop = True
    Me.imprimirEJT20RadioButton.Text = "Jato de Tinta 20 etiquetas por folha"
    Me.imprimirEJT20RadioButton.UseVisualStyleBackColor = True
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.BackColor = System.Drawing.Color.Transparent
    Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(37, 407)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(139, 15)
    Me.Label3.TabIndex = 180
    Me.Label3.Text = "Desmarcar Todos <F2>"
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
    Me.btoDesmarcar.Location = New System.Drawing.Point(11, 403)
    Me.btoDesmarcar.Name = "btoDesmarcar"
    Me.btoDesmarcar.Size = New System.Drawing.Size(25, 25)
    Me.btoDesmarcar.TabIndex = 179
    Me.btoDesmarcar.TabStop = False
    Me.btoDesmarcar.UseVisualStyleBackColor = False
    '
    'Label20
    '
    Me.Label20.AutoSize = True
    Me.Label20.BackColor = System.Drawing.Color.Transparent
    Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.Location = New System.Drawing.Point(37, 377)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(136, 15)
    Me.Label20.TabIndex = 178
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
    Me.btnSelecionar.Location = New System.Drawing.Point(11, 372)
    Me.btnSelecionar.Name = "btnSelecionar"
    Me.btnSelecionar.Size = New System.Drawing.Size(25, 25)
    Me.btnSelecionar.TabIndex = 177
    Me.btnSelecionar.TabStop = False
    Me.btnSelecionar.UseVisualStyleBackColor = False
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
    Me.btoImprimir.Location = New System.Drawing.Point(678, 154)
    Me.btoImprimir.Margin = New System.Windows.Forms.Padding(0)
    Me.btoImprimir.Name = "btoImprimir"
    Me.btoImprimir.Size = New System.Drawing.Size(109, 72)
    Me.btoImprimir.TabIndex = 84
    Me.btoImprimir.Text = "Imprimir <Enter>"
    Me.btoImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoImprimir.UseVisualStyleBackColor = False
    '
    'txtCliente
    '
    Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCliente.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtCliente.Location = New System.Drawing.Point(83, 72)
    Me.txtCliente.MaxLength = 20
    Me.txtCliente.Name = "txtCliente"
    Me.txtCliente.Size = New System.Drawing.Size(264, 18)
    Me.txtCliente.TabIndex = 1
    '
    'lblCliente
    '
    Me.lblCliente.AutoSize = True
    Me.lblCliente.BackColor = System.Drawing.Color.Transparent
    Me.lblCliente.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCliente.Location = New System.Drawing.Point(11, 72)
    Me.lblCliente.Name = "lblCliente"
    Me.lblCliente.Size = New System.Drawing.Size(63, 18)
    Me.lblCliente.TabIndex = 144
    Me.lblCliente.Text = "Cliente:"
    '
    'fClienteMalaDireta
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.CancelButton = Me.btoSair
    Me.ClientSize = New System.Drawing.Size(793, 444)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.Panel1)
    Me.ForeColor = System.Drawing.Color.Black
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.Name = "fClienteMalaDireta"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Clientes"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvCliente, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents btoFiltro As System.Windows.Forms.Button
  Friend WithEvents dgvCliente As System.Windows.Forms.DataGridView
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents txtCliente As System.Windows.Forms.TextBox
  Friend WithEvents lblCliente As System.Windows.Forms.Label
  Friend WithEvents btoImprimir As System.Windows.Forms.Button
  Friend WithEvents check As System.Windows.Forms.DataGridViewCheckBoxColumn
  Friend WithEvents cid As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Nome As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Cpf As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Rg As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Situacao As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Ddd As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Telefone As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents btnSelecionar As System.Windows.Forms.Button
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents btoDesmarcar As System.Windows.Forms.Button
  Friend WithEvents imprimirArgoxRadioButton As System.Windows.Forms.RadioButton
  Friend WithEvents imprimirEJT30RadioButton As System.Windows.Forms.RadioButton
  Friend WithEvents imprimirEJT20RadioButton As System.Windows.Forms.RadioButton
End Class
