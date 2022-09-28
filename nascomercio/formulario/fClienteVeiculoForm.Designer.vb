<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fClienteVeiculoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fClienteVeiculoForm))
        Me.lblCliCadastro = New System.Windows.Forms.Label
        Me.lblCliSubTitulo = New System.Windows.Forms.Label
        Me.txtNome = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgvVeiculos = New System.Windows.Forms.DataGridView
        Me.Placa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Marca = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Modelo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ano = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Combustivel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btoCadastro = New System.Windows.Forms.Button
        Me.btoProfissional = New System.Windows.Forms.Button
        Me.btoEndereco = New System.Windows.Forms.Button
        Me.btoFiltro = New System.Windows.Forms.Button
        Me.imgCliLogo = New System.Windows.Forms.PictureBox
        Me.btoSair = New System.Windows.Forms.Button
        Me.btoFinanceiro = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btoIncluirItem = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.btoExcluirItem = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.btoVendas = New System.Windows.Forms.Button
        Me.btoCheques = New System.Windows.Forms.Button
        Me.btnIncluir = New System.Windows.Forms.Button
        CType(Me.dgvVeiculos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblCliCadastro.Size = New System.Drawing.Size(194, 24)
        Me.lblCliCadastro.TabIndex = 230
        Me.lblCliCadastro.Text = "Clientes - Veículos"
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
        'dgvVeiculos
        '
        Me.dgvVeiculos.AllowUserToAddRows = False
        Me.dgvVeiculos.AllowUserToDeleteRows = False
        Me.dgvVeiculos.AllowUserToOrderColumns = True
        Me.dgvVeiculos.AllowUserToResizeColumns = False
        Me.dgvVeiculos.AllowUserToResizeRows = False
        Me.dgvVeiculos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvVeiculos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvVeiculos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvVeiculos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvVeiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVeiculos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Placa, Me.Marca, Me.Modelo, Me.Cor, Me.Ano, Me.Combustivel})
        Me.dgvVeiculos.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvVeiculos.Location = New System.Drawing.Point(11, 91)
        Me.dgvVeiculos.Name = "dgvVeiculos"
        Me.dgvVeiculos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvVeiculos.RowHeadersVisible = False
        Me.dgvVeiculos.Size = New System.Drawing.Size(650, 264)
        Me.dgvVeiculos.TabIndex = 5
        '
        'Placa
        '
        Me.Placa.HeaderText = "Placa"
        Me.Placa.Name = "Placa"
        Me.Placa.Width = 71
        '
        'Marca
        '
        Me.Marca.HeaderText = "Marca"
        Me.Marca.Name = "Marca"
        Me.Marca.Width = 76
        '
        'Modelo
        '
        Me.Modelo.HeaderText = "Modelo"
        Me.Modelo.Name = "Modelo"
        Me.Modelo.Width = 86
        '
        'Cor
        '
        Me.Cor.HeaderText = "Cor"
        Me.Cor.Name = "Cor"
        Me.Cor.Width = 59
        '
        'Ano
        '
        Me.Ano.HeaderText = "Ano"
        Me.Ano.Name = "Ano"
        Me.Ano.Width = 60
        '
        'Combustivel
        '
        Me.Combustivel.HeaderText = "Combustivel"
        Me.Combustivel.Name = "Combustivel"
        Me.Combustivel.Width = 122
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
        Me.imgCliLogo.Image = Global.nascomercio.My.Resources.Resources.iconeveiculos3
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btoIncluirItem)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.btoExcluirItem)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.btoVendas)
        Me.Panel1.Controls.Add(Me.dgvVeiculos)
        Me.Panel1.Controls.Add(Me.btoCheques)
        Me.Panel1.Controls.Add(Me.btnIncluir)
        Me.Panel1.Controls.Add(Me.txtNome)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(803, 550)
        Me.Panel1.TabIndex = 293
        '
        'btoIncluirItem
        '
        Me.btoIncluirItem.BackColor = System.Drawing.Color.Transparent
        Me.btoIncluirItem.BackgroundImage = CType(resources.GetObject("btoIncluirItem.BackgroundImage"), System.Drawing.Image)
        Me.btoIncluirItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoIncluirItem.FlatAppearance.BorderSize = 0
        Me.btoIncluirItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoIncluirItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoIncluirItem.ForeColor = System.Drawing.Color.White
        Me.btoIncluirItem.Location = New System.Drawing.Point(55, 468)
        Me.btoIncluirItem.Name = "btoIncluirItem"
        Me.btoIncluirItem.Size = New System.Drawing.Size(25, 25)
        Me.btoIncluirItem.TabIndex = 308
        Me.btoIncluirItem.TabStop = False
        Me.btoIncluirItem.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(79, 500)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 14)
        Me.Label4.TabIndex = 311
        Me.Label4.Text = "Excluir Item [F2]"
        '
        'btoExcluirItem
        '
        Me.btoExcluirItem.BackColor = System.Drawing.Color.Transparent
        Me.btoExcluirItem.BackgroundImage = CType(resources.GetObject("btoExcluirItem.BackgroundImage"), System.Drawing.Image)
        Me.btoExcluirItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoExcluirItem.FlatAppearance.BorderSize = 0
        Me.btoExcluirItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoExcluirItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoExcluirItem.ForeColor = System.Drawing.Color.White
        Me.btoExcluirItem.Location = New System.Drawing.Point(55, 496)
        Me.btoExcluirItem.Name = "btoExcluirItem"
        Me.btoExcluirItem.Size = New System.Drawing.Size(25, 25)
        Me.btoExcluirItem.TabIndex = 309
        Me.btoExcluirItem.TabStop = False
        Me.btoExcluirItem.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(79, 472)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 14)
        Me.Label6.TabIndex = 310
        Me.Label6.Text = "Incluir Item [F1]"
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
        Me.btnIncluir.Text = "Salvar <F1>"
        Me.btnIncluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIncluir.UseVisualStyleBackColor = False
        '
        'fClienteVeiculoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(803, 550)
        Me.Controls.Add(Me.btoFinanceiro)
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
        Me.Name = "fClienteVeiculoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes - Financeiro"
        CType(Me.dgvVeiculos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCliCadastro As System.Windows.Forms.Label
    Friend WithEvents btoFiltro As System.Windows.Forms.Button
    Friend WithEvents lblCliSubTitulo As System.Windows.Forms.Label
    Friend WithEvents imgCliLogo As System.Windows.Forms.PictureBox
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents btoCadastro As System.Windows.Forms.Button
    Friend WithEvents btoProfissional As System.Windows.Forms.Button
    Friend WithEvents btoEndereco As System.Windows.Forms.Button
    Friend WithEvents dgvVeiculos As System.Windows.Forms.DataGridView
    Friend WithEvents btoFinanceiro As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnIncluir As System.Windows.Forms.Button
    Friend WithEvents btoCheques As System.Windows.Forms.Button
    Friend WithEvents btoVendas As System.Windows.Forms.Button
    Friend WithEvents btoIncluirItem As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btoExcluirItem As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Placa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Marca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Modelo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ano As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Combustivel As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
