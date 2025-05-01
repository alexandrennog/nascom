<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fClienteLista
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.btoFiltro = New System.Windows.Forms.Button()
        Me.dgvCliente = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btoCadastro = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCPF = New System.Windows.Forms.TextBox()
        Me.lblCPF = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.btoMalaDireta = New System.Windows.Forms.Button()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.cid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Endereço = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cpf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Situacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ddd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Telefone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dddcel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Celular = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.lblSubTitulo.Location = New System.Drawing.Point(-212, -63)
        Me.lblSubTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(44, 16)
        Me.lblSubTitulo.TabIndex = 79
        Me.lblSubTitulo.Text = "LISTA"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(-216, -92)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(196, 32)
        Me.lblTitulo.TabIndex = 77
        Me.lblTitulo.Text = "Fornecedores"
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.usuarios
        Me.imgLogo.Location = New System.Drawing.Point(-289, -91)
        Me.imgLogo.Margin = New System.Windows.Forms.Padding(4)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(67, 62)
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
        Me.btoSair.Location = New System.Drawing.Point(917, 10)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(4)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(133, 89)
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
        Me.btoFiltro.Location = New System.Drawing.Point(917, 197)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(133, 89)
        Me.btoFiltro.TabIndex = 6
        Me.btoFiltro.Text = "Pesquisar <F6>"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
        '
        'dgvCliente
        '
        Me.dgvCliente.AllowUserToAddRows = False
        Me.dgvCliente.AllowUserToDeleteRows = False
        Me.dgvCliente.AllowUserToOrderColumns = True
        Me.dgvCliente.AllowUserToResizeColumns = False
        Me.dgvCliente.AllowUserToResizeRows = False
        Me.dgvCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvCliente.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvCliente.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCliente.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCliente.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCliente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cid, Me.Nome, Me.Endereço, Me.Cpf, Me.Rg, Me.Situacao, Me.Ddd, Me.Telefone, Me.Dddcel, Me.Celular, Me.Email})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCliente.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCliente.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvCliente.Location = New System.Drawing.Point(15, 132)
        Me.dgvCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvCliente.Name = "dgvCliente"
        Me.dgvCliente.ReadOnly = True
        Me.dgvCliente.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvCliente.RowHeadersVisible = False
        Me.dgvCliente.RowHeadersWidth = 51
        Me.dgvCliente.Size = New System.Drawing.Size(885, 399)
        Me.dgvCliente.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(85, 39)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 16)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "LISTA"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.nascomercio.My.Resources.Resources.cliente
        Me.PictureBox1.Location = New System.Drawing.Point(11, 10)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(67, 62)
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
        Me.Label2.Location = New System.Drawing.Point(85, 10)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 32)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Clientes"
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
        Me.btoCadastro.Location = New System.Drawing.Point(917, 103)
        Me.btoCadastro.Margin = New System.Windows.Forms.Padding(4)
        Me.btoCadastro.Name = "btoCadastro"
        Me.btoCadastro.Size = New System.Drawing.Size(133, 89)
        Me.btoCadastro.TabIndex = 5
        Me.btoCadastro.Text = "Incluir <F5>"
        Me.btoCadastro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoCadastro.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtCPF)
        Me.Panel1.Controls.Add(Me.lblCPF)
        Me.Panel1.Controls.Add(Me.txtCodigo)
        Me.Panel1.Controls.Add(Me.lblCodigo)
        Me.Panel1.Controls.Add(Me.btoMalaDireta)
        Me.Panel1.Controls.Add(Me.txtCliente)
        Me.Panel1.Controls.Add(Me.lblCliente)
        Me.Panel1.Controls.Add(Me.dgvCliente)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1057, 546)
        Me.Panel1.TabIndex = 83
        '
        'txtCPF
        '
        Me.txtCPF.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCPF.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtCPF.Location = New System.Drawing.Point(732, 87)
        Me.txtCPF.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCPF.MaxLength = 100
        Me.txtCPF.Name = "txtCPF"
        Me.txtCPF.Size = New System.Drawing.Size(168, 22)
        Me.txtCPF.TabIndex = 181
        '
        'lblCPF
        '
        Me.lblCPF.AutoSize = True
        Me.lblCPF.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblCPF.Location = New System.Drawing.Point(675, 87)
        Me.lblCPF.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCPF.Name = "lblCPF"
        Me.lblCPF.Size = New System.Drawing.Size(49, 22)
        Me.lblCPF.TabIndex = 182
        Me.lblCPF.Text = "CPF"
        '
        'txtCodigo
        '
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtCodigo.Location = New System.Drawing.Point(107, 87)
        Me.txtCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigo.MaxLength = 10
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(121, 22)
        Me.txtCodigo.TabIndex = 1
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblCodigo.Location = New System.Drawing.Point(15, 87)
        Me.lblCodigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(84, 22)
        Me.lblCodigo.TabIndex = 145
        Me.lblCodigo.Text = "Código:"
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
        Me.btoMalaDireta.Location = New System.Drawing.Point(904, 284)
        Me.btoMalaDireta.Margin = New System.Windows.Forms.Padding(0)
        Me.btoMalaDireta.Name = "btoMalaDireta"
        Me.btoMalaDireta.Size = New System.Drawing.Size(145, 89)
        Me.btoMalaDireta.TabIndex = 84
        Me.btoMalaDireta.Text = "Mala Direta <F7>"
        Me.btoMalaDireta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoMalaDireta.UseVisualStyleBackColor = False
        '
        'txtCliente
        '
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCliente.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(315, 87)
        Me.txtCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCliente.MaxLength = 20
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(352, 22)
        Me.txtCliente.TabIndex = 2
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.BackColor = System.Drawing.Color.Transparent
        Me.lblCliente.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblCliente.Location = New System.Drawing.Point(236, 87)
        Me.lblCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(70, 22)
        Me.lblCliente.TabIndex = 144
        Me.lblCliente.Text = "Nome:"
        '
        'cid
        '
        Me.cid.HeaderText = "CID"
        Me.cid.MinimumWidth = 6
        Me.cid.Name = "cid"
        Me.cid.ReadOnly = True
        Me.cid.Width = 66
        '
        'Nome
        '
        Me.Nome.HeaderText = "Nome"
        Me.Nome.MinimumWidth = 6
        Me.Nome.Name = "Nome"
        Me.Nome.ReadOnly = True
        Me.Nome.Width = 83
        '
        'Endereço
        '
        Me.Endereço.HeaderText = "Endereço"
        Me.Endereço.MinimumWidth = 6
        Me.Endereço.Name = "Endereço"
        Me.Endereço.ReadOnly = True
        Me.Endereço.Width = 113
        '
        'Cpf
        '
        Me.Cpf.HeaderText = "CPF"
        Me.Cpf.MinimumWidth = 6
        Me.Cpf.Name = "Cpf"
        Me.Cpf.ReadOnly = True
        Me.Cpf.Width = 71
        '
        'Rg
        '
        Me.Rg.HeaderText = "RG"
        Me.Rg.MinimumWidth = 6
        Me.Rg.Name = "Rg"
        Me.Rg.ReadOnly = True
        Me.Rg.Width = 63
        '
        'Situacao
        '
        Me.Situacao.HeaderText = "Situção"
        Me.Situacao.MinimumWidth = 6
        Me.Situacao.Name = "Situacao"
        Me.Situacao.ReadOnly = True
        Me.Situacao.Width = 97
        '
        'Ddd
        '
        Me.Ddd.HeaderText = "DDD"
        Me.Ddd.MinimumWidth = 6
        Me.Ddd.Name = "Ddd"
        Me.Ddd.ReadOnly = True
        Me.Ddd.Width = 74
        '
        'Telefone
        '
        Me.Telefone.HeaderText = "Telefone"
        Me.Telefone.MinimumWidth = 6
        Me.Telefone.Name = "Telefone"
        Me.Telefone.ReadOnly = True
        Me.Telefone.Width = 103
        '
        'Dddcel
        '
        Me.Dddcel.HeaderText = "DDD"
        Me.Dddcel.MinimumWidth = 6
        Me.Dddcel.Name = "Dddcel"
        Me.Dddcel.ReadOnly = True
        Me.Dddcel.Width = 74
        '
        'Celular
        '
        Me.Celular.HeaderText = "Celular"
        Me.Celular.MinimumWidth = 6
        Me.Celular.Name = "Celular"
        Me.Celular.ReadOnly = True
        Me.Celular.Width = 93
        '
        'Email
        '
        Me.Email.HeaderText = "E-mail"
        Me.Email.MinimumWidth = 6
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        Me.Email.Width = 86
        '
        'fClienteLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.CancelButton = Me.btoSair
        Me.ClientSize = New System.Drawing.Size(1057, 546)
        Me.Controls.Add(Me.btoCadastro)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.btoFiltro)
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
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "fClienteLista"
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
    Friend WithEvents btoCadastro As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents btoMalaDireta As System.Windows.Forms.Button
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtCPF As System.Windows.Forms.TextBox
    Friend WithEvents lblCPF As System.Windows.Forms.Label
    Friend WithEvents cid As DataGridViewTextBoxColumn
    Friend WithEvents Nome As DataGridViewTextBoxColumn
    Friend WithEvents Endereço As DataGridViewTextBoxColumn
    Friend WithEvents Cpf As DataGridViewTextBoxColumn
    Friend WithEvents Rg As DataGridViewTextBoxColumn
    Friend WithEvents Situacao As DataGridViewTextBoxColumn
    Friend WithEvents Ddd As DataGridViewTextBoxColumn
    Friend WithEvents Telefone As DataGridViewTextBoxColumn
    Friend WithEvents Dddcel As DataGridViewTextBoxColumn
    Friend WithEvents Celular As DataGridViewTextBoxColumn
    Friend WithEvents Email As DataGridViewTextBoxColumn
End Class
