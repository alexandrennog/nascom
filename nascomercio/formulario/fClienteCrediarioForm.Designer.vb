<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fClienteCrediarioForm
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
        Me.lblCliCadastro = New System.Windows.Forms.Label
        Me.lblCliSubTitulo = New System.Windows.Forms.Label
        Me.txtNome = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtLimite = New System.Windows.Forms.TextBox
        Me.cboCrediario = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtDisponivel = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvCrediario = New System.Windows.Forms.DataGridView
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Parcelas = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valorpago = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.saldodevedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valortotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Venda = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btoFinanceiro = New System.Windows.Forms.Button
        Me.btoCadastro = New System.Windows.Forms.Button
        Me.btoProfissional = New System.Windows.Forms.Button
        Me.btoEndereco = New System.Windows.Forms.Button
        Me.btoFiltro = New System.Windows.Forms.Button
        Me.imgCliLogo = New System.Windows.Forms.PictureBox
        Me.btoSair = New System.Windows.Forms.Button
        Me.btoVendas = New System.Windows.Forms.Button
        Me.btoCheques = New System.Windows.Forms.Button
        Me.btnIncluir = New System.Windows.Forms.Button
        Me.btoSalvar = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        CType(Me.dgvCrediario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCliCadastro
        '
        Me.lblCliCadastro.AutoSize = True
        Me.lblCliCadastro.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblCliCadastro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCliCadastro.Location = New System.Drawing.Point(64, 8)
        Me.lblCliCadastro.Name = "lblCliCadastro"
        Me.lblCliCadastro.Size = New System.Drawing.Size(201, 24)
        Me.lblCliCadastro.TabIndex = 230
        Me.lblCliCadastro.Text = "Clientes - Crediário"
        '
        'lblCliSubTitulo
        '
        Me.lblCliSubTitulo.AutoSize = True
        Me.lblCliSubTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblCliSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCliSubTitulo.Location = New System.Drawing.Point(64, 32)
        Me.lblCliSubTitulo.Name = "lblCliSubTitulo"
        Me.lblCliSubTitulo.Size = New System.Drawing.Size(67, 14)
        Me.lblCliSubTitulo.TabIndex = 224
        Me.lblCliSubTitulo.Text = "CADASTRO"
        '
        'txtNome
        '
        Me.txtNome.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtNome.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNome.Location = New System.Drawing.Point(107, 67)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.ReadOnly = True
        Me.txtNome.Size = New System.Drawing.Size(491, 18)
        Me.txtNome.TabIndex = 1
        Me.txtNome.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(52, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 18)
        Me.Label3.TabIndex = 176
        Me.Label3.Text = "Nome"
        '
        'txtLimite
        '
        Me.txtLimite.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLimite.Location = New System.Drawing.Point(107, 95)
        Me.txtLimite.MaxLength = 9
        Me.txtLimite.Name = "txtLimite"
        Me.txtLimite.Size = New System.Drawing.Size(188, 18)
        Me.txtLimite.TabIndex = 2
        '
        'cboCrediario
        '
        Me.cboCrediario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCrediario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCrediario.FormattingEnabled = True
        Me.cboCrediario.Items.AddRange(New Object() {"Pagos", "A Pagar", "Todos"})
        Me.cboCrediario.Location = New System.Drawing.Point(107, 119)
        Me.cboCrediario.Name = "cboCrediario"
        Me.cboCrediario.Size = New System.Drawing.Size(140, 26)
        Me.cboCrediario.TabIndex = 4
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(32, 122)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(69, 18)
        Me.Label23.TabIndex = 289
        Me.Label23.Text = "Situação"
        '
        'txtDisponivel
        '
        Me.txtDisponivel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDisponivel.Location = New System.Drawing.Point(414, 95)
        Me.txtDisponivel.MaxLength = 9
        Me.txtDisponivel.Name = "txtDisponivel"
        Me.txtDisponivel.Size = New System.Drawing.Size(184, 18)
        Me.txtDisponivel.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(301, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 18)
        Me.Label1.TabIndex = 291
        Me.Label1.Text = "Disponível R$"
        '
        'dgvCrediario
        '
        Me.dgvCrediario.AllowUserToAddRows = False
        Me.dgvCrediario.AllowUserToDeleteRows = False
        Me.dgvCrediario.AllowUserToOrderColumns = True
        Me.dgvCrediario.AllowUserToResizeColumns = False
        Me.dgvCrediario.AllowUserToResizeRows = False
        Me.dgvCrediario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvCrediario.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvCrediario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCrediario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvCrediario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCrediario.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Data, Me.Parcelas, Me.valorpago, Me.saldodevedor, Me.valortotal, Me.Venda})
        Me.dgvCrediario.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvCrediario.Location = New System.Drawing.Point(11, 151)
        Me.dgvCrediario.Name = "dgvCrediario"
        Me.dgvCrediario.ReadOnly = True
        Me.dgvCrediario.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvCrediario.RowHeadersVisible = False
        Me.dgvCrediario.Size = New System.Drawing.Size(650, 306)
        Me.dgvCrediario.TabIndex = 5
        '
        'Data
        '
        Me.Data.HeaderText = "Data"
        Me.Data.Name = "Data"
        Me.Data.ReadOnly = True
        Me.Data.Width = 65
        '
        'Parcelas
        '
        Me.Parcelas.HeaderText = "Parcelas"
        Me.Parcelas.Name = "Parcelas"
        Me.Parcelas.ReadOnly = True
        Me.Parcelas.Width = 94
        '
        'valorpago
        '
        Me.valorpago.HeaderText = "Valor Pago"
        Me.valorpago.Name = "valorpago"
        Me.valorpago.ReadOnly = True
        Me.valorpago.Width = 99
        '
        'saldodevedor
        '
        Me.saldodevedor.HeaderText = "Saldo Devedor"
        Me.saldodevedor.Name = "saldodevedor"
        Me.saldodevedor.ReadOnly = True
        Me.saldodevedor.Width = 127
        '
        'valortotal
        '
        Me.valortotal.HeaderText = "Valor Total"
        Me.valortotal.Name = "valortotal"
        Me.valortotal.ReadOnly = True
        Me.valortotal.Width = 98
        '
        'Venda
        '
        Me.Venda.HeaderText = "Venda"
        Me.Venda.Name = "Venda"
        Me.Venda.ReadOnly = True
        Me.Venda.Width = 76
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btoVendas)
        Me.Panel1.Controls.Add(Me.dgvCrediario)
        Me.Panel1.Controls.Add(Me.btoCheques)
        Me.Panel1.Controls.Add(Me.btnIncluir)
        Me.Panel1.Controls.Add(Me.txtLimite)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.cboCrediario)
        Me.Panel1.Controls.Add(Me.txtDisponivel)
        Me.Panel1.Controls.Add(Me.txtNome)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btoSalvar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(803, 550)
        Me.Panel1.TabIndex = 293
        '
        'btoFinanceiro
        '
        Me.btoFinanceiro.BackColor = System.Drawing.Color.Transparent
        Me.btoFinanceiro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoFinanceiro.FlatAppearance.BorderSize = 0
        Me.btoFinanceiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoFinanceiro.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoFinanceiro.ForeColor = System.Drawing.Color.Black
        Me.btoFinanceiro.Image = Global.nascomercio.My.Resources.Resources.cliente_financeiro
        Me.btoFinanceiro.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoFinanceiro.Location = New System.Drawing.Point(688, 388)
        Me.btoFinanceiro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFinanceiro.Name = "btoFinanceiro"
        Me.btoFinanceiro.Size = New System.Drawing.Size(112, 70)
        Me.btoFinanceiro.TabIndex = 292
        Me.btoFinanceiro.TabStop = False
        Me.btoFinanceiro.Text = "Financeiro <F9>"
        Me.btoFinanceiro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFinanceiro.UseVisualStyleBackColor = False
        '
        'btoCadastro
        '
        Me.btoCadastro.BackColor = System.Drawing.Color.Transparent
        Me.btoCadastro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoCadastro.FlatAppearance.BorderSize = 0
        Me.btoCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoCadastro.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoCadastro.ForeColor = System.Drawing.Color.Black
        Me.btoCadastro.Image = Global.nascomercio.My.Resources.Resources.cliente
        Me.btoCadastro.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoCadastro.Location = New System.Drawing.Point(688, 160)
        Me.btoCadastro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoCadastro.Name = "btoCadastro"
        Me.btoCadastro.Size = New System.Drawing.Size(112, 70)
        Me.btoCadastro.TabIndex = 0
        Me.btoCadastro.Text = "Cadastro <F6>"
        Me.btoCadastro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoCadastro.UseVisualStyleBackColor = False
        '
        'btoProfissional
        '
        Me.btoProfissional.BackColor = System.Drawing.Color.Transparent
        Me.btoProfissional.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btoProfissional.FlatAppearance.BorderSize = 0
        Me.btoProfissional.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoProfissional.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoProfissional.ForeColor = System.Drawing.Color.Black
        Me.btoProfissional.Image = Global.nascomercio.My.Resources.Resources.cliente_profissional
        Me.btoProfissional.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoProfissional.Location = New System.Drawing.Point(688, 312)
        Me.btoProfissional.Margin = New System.Windows.Forms.Padding(0)
        Me.btoProfissional.Name = "btoProfissional"
        Me.btoProfissional.Size = New System.Drawing.Size(112, 70)
        Me.btoProfissional.TabIndex = 232
        Me.btoProfissional.Text = "Profissional <F8>"
        Me.btoProfissional.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoProfissional.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btoProfissional.UseVisualStyleBackColor = False
        '
        'btoEndereco
        '
        Me.btoEndereco.BackColor = System.Drawing.Color.Transparent
        Me.btoEndereco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoEndereco.FlatAppearance.BorderSize = 0
        Me.btoEndereco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoEndereco.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoEndereco.ForeColor = System.Drawing.Color.Black
        Me.btoEndereco.Image = Global.nascomercio.My.Resources.Resources.home_icon1
        Me.btoEndereco.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoEndereco.Location = New System.Drawing.Point(688, 236)
        Me.btoEndereco.Margin = New System.Windows.Forms.Padding(0)
        Me.btoEndereco.Name = "btoEndereco"
        Me.btoEndereco.Size = New System.Drawing.Size(112, 70)
        Me.btoEndereco.TabIndex = 231
        Me.btoEndereco.Text = "Endereço <F7>"
        Me.btoEndereco.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoEndereco.UseVisualStyleBackColor = False
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
        Me.btoFiltro.Location = New System.Drawing.Point(688, 84)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(112, 70)
        Me.btoFiltro.TabIndex = 9
        Me.btoFiltro.Text = "Pesquisar <F5>"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
        '
        'imgCliLogo
        '
        Me.imgCliLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgCliLogo.Image = Global.nascomercio.My.Resources.Resources.cliente_financeiro
        Me.imgCliLogo.Location = New System.Drawing.Point(8, 8)
        Me.imgCliLogo.Name = "imgCliLogo"
        Me.imgCliLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgCliLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCliLogo.TabIndex = 211
        Me.imgCliLogo.TabStop = False
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
        Me.btoSair.Location = New System.Drawing.Point(688, 8)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(112, 70)
        Me.btoSair.TabIndex = 8
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'btoVendas
        '
        Me.btoVendas.BackColor = System.Drawing.Color.Transparent
        Me.btoVendas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoVendas.FlatAppearance.BorderSize = 0
        Me.btoVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoVendas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoVendas.ForeColor = System.Drawing.Color.Black
        Me.btoVendas.Image = Global.nascomercio.My.Resources.Resources.caixa
        Me.btoVendas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoVendas.Location = New System.Drawing.Point(575, 467)
        Me.btoVendas.Margin = New System.Windows.Forms.Padding(0)
        Me.btoVendas.Name = "btoVendas"
        Me.btoVendas.Size = New System.Drawing.Size(112, 70)
        Me.btoVendas.TabIndex = 295
        Me.btoVendas.TabStop = False
        Me.btoVendas.Text = "Vendas <F11>"
        Me.btoVendas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoVendas.UseVisualStyleBackColor = False
        '
        'btoCheques
        '
        Me.btoCheques.BackColor = System.Drawing.Color.Transparent
        Me.btoCheques.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoCheques.FlatAppearance.BorderSize = 0
        Me.btoCheques.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoCheques.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoCheques.ForeColor = System.Drawing.Color.Black
        Me.btoCheques.Image = Global.nascomercio.My.Resources.Resources.cheque
        Me.btoCheques.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoCheques.Location = New System.Drawing.Point(687, 467)
        Me.btoCheques.Margin = New System.Windows.Forms.Padding(0)
        Me.btoCheques.Name = "btoCheques"
        Me.btoCheques.Size = New System.Drawing.Size(112, 70)
        Me.btoCheques.TabIndex = 294
        Me.btoCheques.TabStop = False
        Me.btoCheques.Text = "Cheques <F10>"
        Me.btoCheques.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoCheques.UseVisualStyleBackColor = False
        '
        'btnIncluir
        '
        Me.btnIncluir.BackColor = System.Drawing.Color.Transparent
        Me.btnIncluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnIncluir.FlatAppearance.BorderSize = 0
        Me.btnIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncluir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncluir.ForeColor = System.Drawing.Color.Black
        Me.btnIncluir.Image = Global.nascomercio.My.Resources.Resources.incluir
        Me.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnIncluir.Location = New System.Drawing.Point(315, 468)
        Me.btnIncluir.Name = "btnIncluir"
        Me.btnIncluir.Size = New System.Drawing.Size(113, 69)
        Me.btnIncluir.TabIndex = 294
        Me.btnIncluir.Text = "Incluir <F1>"
        Me.btnIncluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIncluir.UseVisualStyleBackColor = False
        '
        'btoSalvar
        '
        Me.btoSalvar.BackColor = System.Drawing.Color.Transparent
        Me.btoSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoSalvar.FlatAppearance.BorderSize = 0
        Me.btoSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoSalvar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoSalvar.ForeColor = System.Drawing.Color.Black
        Me.btoSalvar.Image = Global.nascomercio.My.Resources.Resources.pagamento
        Me.btoSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoSalvar.Location = New System.Drawing.Point(196, 467)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(113, 69)
        Me.btoSalvar.TabIndex = 6
        Me.btoSalvar.Text = "Parcelas <Enter>"
        Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSalvar.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(28, 96)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(74, 18)
        Me.Label18.TabIndex = 272
        Me.Label18.Text = "Limite R$"
        '
        'fClienteCrediarioForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(803, 550)
        Me.Controls.Add(Me.btoFinanceiro)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.btoCadastro)
        Me.Controls.Add(Me.btoProfissional)
        Me.Controls.Add(Me.btoEndereco)
        Me.Controls.Add(Me.lblCliCadastro)
        Me.Controls.Add(Me.btoFiltro)
        Me.Controls.Add(Me.lblCliSubTitulo)
        Me.Controls.Add(Me.imgCliLogo)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "fClienteCrediarioForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes - Financeiro"
        CType(Me.dgvCrediario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
  Friend WithEvents lblCliCadastro As System.Windows.Forms.Label
  Friend WithEvents btoFiltro As System.Windows.Forms.Button
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents lblCliSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgCliLogo As System.Windows.Forms.PictureBox
  Friend WithEvents txtNome As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents btoCadastro As System.Windows.Forms.Button
  Friend WithEvents btoProfissional As System.Windows.Forms.Button
  Friend WithEvents btoEndereco As System.Windows.Forms.Button
  Friend WithEvents txtLimite As System.Windows.Forms.TextBox
    Friend WithEvents cboCrediario As System.Windows.Forms.ComboBox
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents txtDisponivel As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents dgvCrediario As System.Windows.Forms.DataGridView
  Friend WithEvents btoFinanceiro As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Data As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Parcelas As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents valorpago As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents saldodevedor As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents valortotal As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Venda As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents btnIncluir As System.Windows.Forms.Button
  Friend WithEvents btoCheques As System.Windows.Forms.Button
    Friend WithEvents btoVendas As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class
