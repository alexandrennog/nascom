<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fCrediarioPagamento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fCrediarioPagamento))
        Me.lblCliCadastro = New System.Windows.Forms.Label
        Me.txtControle = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btoSalvar = New System.Windows.Forms.Button
        Me.imgCliLogo = New System.Windows.Forms.PictureBox
        Me.btoSair = New System.Windows.Forms.Button
        Me.txtLimite = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtDisponivel = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvCrediario = New System.Windows.Forms.DataGridView
        Me.selecao = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataEmissao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vencimento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValorParcela = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valorreceber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valorpago = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiasAtrazo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblVendedor = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.txtDinheiro = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblTroco = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblRecebido = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblFalta = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.btoEtiqueta = New System.Windows.Forms.Button
        Me.Label20 = New System.Windows.Forms.Label
        Me.btoIncluirCliente = New System.Windows.Forms.Button
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCrediario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCliCadastro
        '
        Me.lblCliCadastro.AutoSize = True
        Me.lblCliCadastro.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblCliCadastro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCliCadastro.Location = New System.Drawing.Point(64, 8)
        Me.lblCliCadastro.Name = "lblCliCadastro"
        Me.lblCliCadastro.Size = New System.Drawing.Size(235, 24)
        Me.lblCliCadastro.TabIndex = 230
        Me.lblCliCadastro.Text = "Crediário - Pagamento"
        '
        'txtControle
        '
        Me.txtControle.BackColor = System.Drawing.SystemColors.Control
        Me.txtControle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtControle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtControle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtControle.Location = New System.Drawing.Point(147, 109)
        Me.txtControle.Name = "txtControle"
        Me.txtControle.ReadOnly = True
        Me.txtControle.Size = New System.Drawing.Size(174, 18)
        Me.txtControle.TabIndex = 1
        Me.txtControle.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(71, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 18)
        Me.Label3.TabIndex = 176
        Me.Label3.Text = "Controle"
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
        Me.btoSalvar.Location = New System.Drawing.Point(348, 600)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(116, 72)
        Me.btoSalvar.TabIndex = 6
        Me.btoSalvar.Text = "Confirmar <Enter>"
        Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSalvar.UseVisualStyleBackColor = False
        '
        'imgCliLogo
        '
        Me.imgCliLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgCliLogo.Image = Global.nascomercio.My.Resources.Resources.pagamento
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
        Me.btoSair.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btoSair.FlatAppearance.BorderSize = 0
        Me.btoSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoSair.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoSair.ForeColor = System.Drawing.Color.Black
        Me.btoSair.Image = Global.nascomercio.My.Resources.Resources.fechar
        Me.btoSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoSair.Location = New System.Drawing.Point(700, 8)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(96, 72)
        Me.btoSair.TabIndex = 8
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'txtLimite
        '
        Me.txtLimite.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLimite.Location = New System.Drawing.Point(147, 137)
        Me.txtLimite.Name = "txtLimite"
        Me.txtLimite.ReadOnly = True
        Me.txtLimite.Size = New System.Drawing.Size(174, 18)
        Me.txtLimite.TabIndex = 9
        Me.txtLimite.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(66, 136)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(74, 18)
        Me.Label18.TabIndex = 272
        Me.Label18.Text = "Limite R$"
        '
        'txtDisponivel
        '
        Me.txtDisponivel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDisponivel.Location = New System.Drawing.Point(439, 136)
        Me.txtDisponivel.Name = "txtDisponivel"
        Me.txtDisponivel.ReadOnly = True
        Me.txtDisponivel.Size = New System.Drawing.Size(184, 18)
        Me.txtDisponivel.TabIndex = 3
        Me.txtDisponivel.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(326, 136)
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
        Me.dgvCrediario.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selecao, Me.Codigo, Me.DataEmissao, Me.Vencimento, Me.ValorParcela, Me.valorreceber, Me.valorpago, Me.DiasAtrazo})
        Me.dgvCrediario.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvCrediario.Location = New System.Drawing.Point(7, 204)
        Me.dgvCrediario.Name = "dgvCrediario"
        Me.dgvCrediario.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvCrediario.RowHeadersVisible = False
        Me.dgvCrediario.Size = New System.Drawing.Size(810, 245)
        Me.dgvCrediario.TabIndex = 5
        '
        'selecao
        '
        Me.selecao.FalseValue = "False"
        Me.selecao.HeaderText = ""
        Me.selecao.IndeterminateValue = "False"
        Me.selecao.Name = "selecao"
        Me.selecao.TrueValue = "True"
        Me.selecao.Width = 5
        '
        'Codigo
        '
        Me.Codigo.FillWeight = 80.0!
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Width = 84
        '
        'DataEmissao
        '
        Me.DataEmissao.FillWeight = 80.0!
        Me.DataEmissao.HeaderText = "Data Emissão"
        Me.DataEmissao.Name = "DataEmissao"
        Me.DataEmissao.Width = 117
        '
        'Vencimento
        '
        Me.Vencimento.FillWeight = 80.0!
        Me.Vencimento.HeaderText = "Vencimento"
        Me.Vencimento.Name = "Vencimento"
        Me.Vencimento.Width = 115
        '
        'ValorParcela
        '
        Me.ValorParcela.FillWeight = 80.0!
        Me.ValorParcela.HeaderText = "Valor Parcela"
        Me.ValorParcela.Name = "ValorParcela"
        Me.ValorParcela.Width = 115
        '
        'valorreceber
        '
        Me.valorreceber.FillWeight = 80.0!
        Me.valorreceber.HeaderText = "Valor a Receber"
        Me.valorreceber.Name = "valorreceber"
        Me.valorreceber.Width = 133
        '
        'valorpago
        '
        Me.valorpago.FillWeight = 80.0!
        Me.valorpago.HeaderText = "Valor Pago"
        Me.valorpago.Name = "valorpago"
        Me.valorpago.Width = 99
        '
        'DiasAtrazo
        '
        Me.DiasAtrazo.FillWeight = 80.0!
        Me.DiasAtrazo.HeaderText = "Dias Atraso"
        Me.DiasAtrazo.Name = "DiasAtrazo"
        Me.DiasAtrazo.Width = 103
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendedor.ForeColor = System.Drawing.Color.Blue
        Me.lblVendedor.Location = New System.Drawing.Point(427, 75)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(30, 19)
        Me.lblVendedor.TabIndex = 300
        Me.lblVendedor.Text = "Eu"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(337, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 19)
        Me.Label5.TabIndex = 299
        Me.Label5.Text = "Vendedor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(64, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 22)
        Me.Label4.TabIndex = 302
        Me.Label4.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(147, 75)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(184, 22)
        Me.txtCodigo.TabIndex = 0
        '
        'txtDinheiro
        '
        Me.txtDinheiro.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDinheiro.Location = New System.Drawing.Point(128, 455)
        Me.txtDinheiro.Name = "txtDinheiro"
        Me.txtDinheiro.Size = New System.Drawing.Size(101, 26)
        Me.txtDinheiro.TabIndex = 2
        Me.txtDinheiro.Text = "0,00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 458)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 19)
        Me.Label6.TabIndex = 304
        Me.Label6.Text = "Dinheiro: R$"
        '
        'lblTroco
        '
        Me.lblTroco.AutoSize = True
        Me.lblTroco.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTroco.ForeColor = System.Drawing.Color.Blue
        Me.lblTroco.Location = New System.Drawing.Point(481, 503)
        Me.lblTroco.Name = "lblTroco"
        Me.lblTroco.Size = New System.Drawing.Size(79, 19)
        Me.lblTroco.TabIndex = 314
        Me.lblTroco.Text = "11.000,00"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(390, 503)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 19)
        Me.Label14.TabIndex = 313
        Me.Label14.Text = "Troco: R$"
        '
        'lblRecebido
        '
        Me.lblRecebido.AutoSize = True
        Me.lblRecebido.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecebido.ForeColor = System.Drawing.Color.Blue
        Me.lblRecebido.Location = New System.Drawing.Point(132, 503)
        Me.lblRecebido.Name = "lblRecebido"
        Me.lblRecebido.Size = New System.Drawing.Size(79, 19)
        Me.lblRecebido.TabIndex = 312
        Me.lblRecebido.Text = "11.123,45"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(17, 503)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(113, 19)
        Me.Label16.TabIndex = 311
        Me.Label16.Text = "Recebido: R$"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Blue
        Me.lblTotal.Location = New System.Drawing.Point(651, 503)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(79, 19)
        Me.lblTotal.TabIndex = 310
        Me.lblTotal.Text = "11.000,00"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(567, 503)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 19)
        Me.Label17.TabIndex = 309
        Me.Label17.Text = "Total: R$"
        '
        'lblFalta
        '
        Me.lblFalta.AutoSize = True
        Me.lblFalta.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFalta.ForeColor = System.Drawing.Color.Blue
        Me.lblFalta.Location = New System.Drawing.Point(304, 503)
        Me.lblFalta.Name = "lblFalta"
        Me.lblFalta.Size = New System.Drawing.Size(79, 19)
        Me.lblFalta.TabIndex = 308
        Me.lblFalta.Text = "11.123,45"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(221, 503)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 19)
        Me.Label13.TabIndex = 307
        Me.Label13.Text = "Falta: R$"
        '
        'btoEtiqueta
        '
        Me.btoEtiqueta.BackColor = System.Drawing.Color.Transparent
        Me.btoEtiqueta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoEtiqueta.FlatAppearance.BorderSize = 0
        Me.btoEtiqueta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoEtiqueta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoEtiqueta.ForeColor = System.Drawing.Color.Black
        Me.btoEtiqueta.Image = Global.nascomercio.My.Resources.Resources.print_design
        Me.btoEtiqueta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoEtiqueta.Location = New System.Drawing.Point(700, 84)
        Me.btoEtiqueta.Margin = New System.Windows.Forms.Padding(0)
        Me.btoEtiqueta.Name = "btoEtiqueta"
        Me.btoEtiqueta.Size = New System.Drawing.Size(96, 72)
        Me.btoEtiqueta.TabIndex = 315
        Me.btoEtiqueta.TabStop = False
        Me.btoEtiqueta.Text = "Etiquetas <F7>"
        Me.btoEtiqueta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoEtiqueta.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(541, 166)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(146, 16)
        Me.Label20.TabIndex = 319
        Me.Label20.Text = "Pesquisar Cliente [F1]"
        '
        'btoIncluirCliente
        '
        Me.btoIncluirCliente.BackColor = System.Drawing.Color.Transparent
        Me.btoIncluirCliente.BackgroundImage = CType(resources.GetObject("btoIncluirCliente.BackgroundImage"), System.Drawing.Image)
        Me.btoIncluirCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoIncluirCliente.FlatAppearance.BorderSize = 0
        Me.btoIncluirCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoIncluirCliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoIncluirCliente.ForeColor = System.Drawing.Color.White
        Me.btoIncluirCliente.Location = New System.Drawing.Point(517, 162)
        Me.btoIncluirCliente.Name = "btoIncluirCliente"
        Me.btoIncluirCliente.Size = New System.Drawing.Size(25, 25)
        Me.btoIncluirCliente.TabIndex = 318
        Me.btoIncluirCliente.TabStop = False
        Me.btoIncluirCliente.UseVisualStyleBackColor = False
        '
        'txtCliente
        '
        Me.txtCliente.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(147, 166)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(364, 25)
        Me.txtCliente.TabIndex = 316
        Me.txtCliente.Text = "Consumidor"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(82, 169)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 18)
        Me.Label7.TabIndex = 317
        Me.Label7.Text = "Cliente"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtDinheiro)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtDisponivel)
        Me.Panel1.Controls.Add(Me.lblTotal)
        Me.Panel1.Controls.Add(Me.lblTroco)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.lblRecebido)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.dgvCrediario)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.lblFalta)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(827, 680)
        Me.Panel1.TabIndex = 320
        '
        'fCrediarioPagamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(828, 680)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.btoIncluirCliente)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btoEtiqueta)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.lblVendedor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblCliCadastro)
        Me.Controls.Add(Me.imgCliLogo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.txtControle)
        Me.Controls.Add(Me.txtLimite)
        Me.Controls.Add(Me.btoSalvar)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "fCrediarioPagamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes - Financeiro"
        CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCrediario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCliCadastro As System.Windows.Forms.Label
    Friend WithEvents btoSalvar As System.Windows.Forms.Button
    Friend WithEvents imgCliLogo As System.Windows.Forms.PictureBox
    Friend WithEvents txtControle As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents txtLimite As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtDisponivel As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvCrediario As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblVendedor As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtDinheiro As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTroco As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblRecebido As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblFalta As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btoEtiqueta As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btoIncluirCliente As System.Windows.Forms.Button
  Friend WithEvents txtCliente As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents selecao As System.Windows.Forms.DataGridViewCheckBoxColumn
  Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents DataEmissao As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Vencimento As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ValorParcela As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents valorreceber As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents valorpago As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents DiasAtrazo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
