<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fRelatorio
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
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.rbtFechamento = New System.Windows.Forms.RadioButton()
        Me.rbtEstoque = New System.Windows.Forms.RadioButton()
        Me.rbtMaisVendidos = New System.Windows.Forms.RadioButton()
        Me.rbtCrediario = New System.Windows.Forms.RadioButton()
        Me.rbtClientes = New System.Windows.Forms.RadioButton()
        Me.rbtNegativar = New System.Windows.Forms.RadioButton()
        Me.rbtVendasPendentes = New System.Windows.Forms.RadioButton()
        Me.rbtCheques = New System.Windows.Forms.RadioButton()
        Me.rbtAuditoria = New System.Windows.Forms.RadioButton()
        Me.rbtGrade = New System.Windows.Forms.RadioButton()
        Me.rdbVendasSintetico = New System.Windows.Forms.RadioButton()
        Me.rbtSPED = New System.Windows.Forms.RadioButton()
        Me.rbtNFe = New System.Windows.Forms.RadioButton()
        Me.rbtConsultaVendas = New System.Windows.Forms.RadioButton()
        Me.btoFiltro = New System.Windows.Forms.Button()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.rdbVendasFabricantes = New System.Windows.Forms.RadioButton()
        Me.rbtTransferencia = New System.Windows.Forms.RadioButton()
        Me.rbtVendasVendedor = New System.Windows.Forms.RadioButton()
        Me.rbtReducaoZ = New System.Windows.Forms.RadioButton()
        Me.rbtLeituraX = New System.Windows.Forms.RadioButton()
        Me.rbtCategoria = New System.Windows.Forms.RadioButton()
        Me.rbtBalanco = New System.Windows.Forms.RadioButton()
        Me.rbtSAT = New System.Windows.Forms.RadioButton()
        Me.rbtPix = New System.Windows.Forms.RadioButton()
        Me.rbtCrediarioPix = New System.Windows.Forms.RadioButton()
        Me.rbtCobrancaPIX = New System.Windows.Forms.RadioButton()
        Me.rbtVendasPorVendedor = New System.Windows.Forms.RadioButton()
        Me.rbtVendasPorLoja = New System.Windows.Forms.RadioButton()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSubTitulo.Location = New System.Drawing.Point(96, 49)
        Me.lblSubTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(54, 19)
        Me.lblSubTitulo.TabIndex = 91
        Me.lblSubTitulo.Text = "LISTA"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(96, 12)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(175, 37)
        Me.lblTitulo.TabIndex = 89
        Me.lblTitulo.Text = "Relatórios"
        '
        'rbtFechamento
        '
        Me.rbtFechamento.AutoSize = True
        Me.rbtFechamento.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtFechamento.Location = New System.Drawing.Point(102, 112)
        Me.rbtFechamento.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtFechamento.Name = "rbtFechamento"
        Me.rbtFechamento.Size = New System.Drawing.Size(249, 33)
        Me.rbtFechamento.TabIndex = 0
        Me.rbtFechamento.TabStop = True
        Me.rbtFechamento.Text = "Fechamento Caixa"
        Me.rbtFechamento.UseVisualStyleBackColor = True
        '
        'rbtEstoque
        '
        Me.rbtEstoque.AutoSize = True
        Me.rbtEstoque.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtEstoque.Location = New System.Drawing.Point(465, 112)
        Me.rbtEstoque.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtEstoque.Name = "rbtEstoque"
        Me.rbtEstoque.Size = New System.Drawing.Size(246, 33)
        Me.rbtEstoque.TabIndex = 8
        Me.rbtEstoque.TabStop = True
        Me.rbtEstoque.Text = "Estoque Produtos"
        Me.rbtEstoque.UseVisualStyleBackColor = True
        '
        'rbtMaisVendidos
        '
        Me.rbtMaisVendidos.AutoSize = True
        Me.rbtMaisVendidos.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtMaisVendidos.Location = New System.Drawing.Point(102, 166)
        Me.rbtMaisVendidos.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtMaisVendidos.Name = "rbtMaisVendidos"
        Me.rbtMaisVendidos.Size = New System.Drawing.Size(222, 33)
        Me.rbtMaisVendidos.TabIndex = 1
        Me.rbtMaisVendidos.TabStop = True
        Me.rbtMaisVendidos.Text = "Detalhe Vendas "
        Me.rbtMaisVendidos.UseVisualStyleBackColor = True
        '
        'rbtCrediario
        '
        Me.rbtCrediario.AutoSize = True
        Me.rbtCrediario.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtCrediario.Location = New System.Drawing.Point(102, 435)
        Me.rbtCrediario.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtCrediario.Name = "rbtCrediario"
        Me.rbtCrediario.Size = New System.Drawing.Size(150, 33)
        Me.rbtCrediario.TabIndex = 5
        Me.rbtCrediario.TabStop = True
        Me.rbtCrediario.Text = "Crediário "
        Me.rbtCrediario.UseVisualStyleBackColor = True
        '
        'rbtClientes
        '
        Me.rbtClientes.AutoSize = True
        Me.rbtClientes.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtClientes.Location = New System.Drawing.Point(102, 489)
        Me.rbtClientes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtClientes.Name = "rbtClientes"
        Me.rbtClientes.Size = New System.Drawing.Size(131, 33)
        Me.rbtClientes.TabIndex = 6
        Me.rbtClientes.TabStop = True
        Me.rbtClientes.Text = "Clientes"
        Me.rbtClientes.UseVisualStyleBackColor = True
        '
        'rbtNegativar
        '
        Me.rbtNegativar.AutoSize = True
        Me.rbtNegativar.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtNegativar.Location = New System.Drawing.Point(102, 543)
        Me.rbtNegativar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtNegativar.Name = "rbtNegativar"
        Me.rbtNegativar.Size = New System.Drawing.Size(246, 33)
        Me.rbtNegativar.TabIndex = 7
        Me.rbtNegativar.TabStop = True
        Me.rbtNegativar.Text = "Clientes Negativar"
        Me.rbtNegativar.UseVisualStyleBackColor = True
        '
        'rbtVendasPendentes
        '
        Me.rbtVendasPendentes.AutoSize = True
        Me.rbtVendasPendentes.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtVendasPendentes.Location = New System.Drawing.Point(102, 274)
        Me.rbtVendasPendentes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtVendasPendentes.Name = "rbtVendasPendentes"
        Me.rbtVendasPendentes.Size = New System.Drawing.Size(250, 33)
        Me.rbtVendasPendentes.TabIndex = 3
        Me.rbtVendasPendentes.TabStop = True
        Me.rbtVendasPendentes.Text = "Vendas Pendentes"
        Me.rbtVendasPendentes.UseVisualStyleBackColor = True
        '
        'rbtCheques
        '
        Me.rbtCheques.AutoSize = True
        Me.rbtCheques.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtCheques.Location = New System.Drawing.Point(102, 382)
        Me.rbtCheques.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtCheques.Name = "rbtCheques"
        Me.rbtCheques.Size = New System.Drawing.Size(139, 33)
        Me.rbtCheques.TabIndex = 4
        Me.rbtCheques.TabStop = True
        Me.rbtCheques.Text = "Cheques"
        Me.rbtCheques.UseVisualStyleBackColor = True
        '
        'rbtAuditoria
        '
        Me.rbtAuditoria.AutoSize = True
        Me.rbtAuditoria.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtAuditoria.Location = New System.Drawing.Point(465, 328)
        Me.rbtAuditoria.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtAuditoria.Name = "rbtAuditoria"
        Me.rbtAuditoria.Size = New System.Drawing.Size(240, 33)
        Me.rbtAuditoria.TabIndex = 10
        Me.rbtAuditoria.TabStop = True
        Me.rbtAuditoria.Text = "Auditoria Usuário"
        Me.rbtAuditoria.UseVisualStyleBackColor = True
        '
        'rbtGrade
        '
        Me.rbtGrade.AutoSize = True
        Me.rbtGrade.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtGrade.Location = New System.Drawing.Point(465, 166)
        Me.rbtGrade.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtGrade.Name = "rbtGrade"
        Me.rbtGrade.Size = New System.Drawing.Size(107, 33)
        Me.rbtGrade.TabIndex = 9
        Me.rbtGrade.TabStop = True
        Me.rbtGrade.Text = "Grade"
        Me.rbtGrade.UseVisualStyleBackColor = True
        '
        'rdbVendasSintetico
        '
        Me.rdbVendasSintetico.AutoSize = True
        Me.rdbVendasSintetico.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbVendasSintetico.Location = New System.Drawing.Point(102, 220)
        Me.rdbVendasSintetico.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rdbVendasSintetico.Name = "rdbVendasSintetico"
        Me.rdbVendasSintetico.Size = New System.Drawing.Size(231, 33)
        Me.rdbVendasSintetico.TabIndex = 2
        Me.rdbVendasSintetico.TabStop = True
        Me.rdbVendasSintetico.Text = "Vendas Sintético"
        Me.rdbVendasSintetico.UseVisualStyleBackColor = True
        '
        'rbtSPED
        '
        Me.rbtSPED.AutoSize = True
        Me.rbtSPED.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtSPED.Location = New System.Drawing.Point(465, 543)
        Me.rbtSPED.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtSPED.Name = "rbtSPED"
        Me.rbtSPED.Size = New System.Drawing.Size(494, 33)
        Me.rbtSPED.TabIndex = 92
        Me.rbtSPED.TabStop = True
        Me.rbtSPED.Text = "SPED / EFD - Escrituração Fiscal Digital"
        Me.rbtSPED.UseVisualStyleBackColor = True
        '
        'rbtNFe
        '
        Me.rbtNFe.AutoSize = True
        Me.rbtNFe.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtNFe.Location = New System.Drawing.Point(465, 489)
        Me.rbtNFe.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtNFe.Name = "rbtNFe"
        Me.rbtNFe.Size = New System.Drawing.Size(356, 33)
        Me.rbtNFe.TabIndex = 94
        Me.rbtNFe.TabStop = True
        Me.rbtNFe.Text = "NFe - Nota Fiscal Eletrônica"
        Me.rbtNFe.UseVisualStyleBackColor = True
        '
        'rbtConsultaVendas
        '
        Me.rbtConsultaVendas.AutoSize = True
        Me.rbtConsultaVendas.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtConsultaVendas.Location = New System.Drawing.Point(465, 382)
        Me.rbtConsultaVendas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtConsultaVendas.Name = "rbtConsultaVendas"
        Me.rbtConsultaVendas.Size = New System.Drawing.Size(232, 33)
        Me.rbtConsultaVendas.TabIndex = 95
        Me.rbtConsultaVendas.TabStop = True
        Me.rbtConsultaVendas.Text = "Consulta Vendas"
        Me.rbtConsultaVendas.UseVisualStyleBackColor = True
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
        Me.btoFiltro.Location = New System.Drawing.Point(900, 18)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(117, 135)
        Me.btoFiltro.TabIndex = 11
        Me.btoFiltro.TabStop = False
        Me.btoFiltro.Text = "Selecionar <Enter>"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
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
        Me.btoSair.Location = New System.Drawing.Point(1046, 18)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(81, 129)
        Me.btoSair.TabIndex = 12
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.relatorio
        Me.imgLogo.Location = New System.Drawing.Point(12, 12)
        Me.imgLogo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(75, 77)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 90
        Me.imgLogo.TabStop = False
        '
        'rdbVendasFabricantes
        '
        Me.rdbVendasFabricantes.AutoSize = True
        Me.rdbVendasFabricantes.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbVendasFabricantes.Location = New System.Drawing.Point(465, 274)
        Me.rdbVendasFabricantes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rdbVendasFabricantes.Name = "rdbVendasFabricantes"
        Me.rdbVendasFabricantes.Size = New System.Drawing.Size(283, 33)
        Me.rdbVendasFabricantes.TabIndex = 96
        Me.rdbVendasFabricantes.TabStop = True
        Me.rdbVendasFabricantes.Text = "Vendas x Fabricantes"
        Me.rdbVendasFabricantes.UseVisualStyleBackColor = True
        '
        'rbtTransferencia
        '
        Me.rbtTransferencia.AutoSize = True
        Me.rbtTransferencia.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtTransferencia.Location = New System.Drawing.Point(465, 435)
        Me.rbtTransferencia.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtTransferencia.Name = "rbtTransferencia"
        Me.rbtTransferencia.Size = New System.Drawing.Size(206, 33)
        Me.rbtTransferencia.TabIndex = 97
        Me.rbtTransferencia.TabStop = True
        Me.rbtTransferencia.Text = "Transferências"
        Me.rbtTransferencia.UseVisualStyleBackColor = True
        '
        'rbtVendasVendedor
        '
        Me.rbtVendasVendedor.AutoSize = True
        Me.rbtVendasVendedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtVendasVendedor.Location = New System.Drawing.Point(102, 328)
        Me.rbtVendasVendedor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtVendasVendedor.Name = "rbtVendasVendedor"
        Me.rbtVendasVendedor.Size = New System.Drawing.Size(259, 33)
        Me.rbtVendasVendedor.TabIndex = 98
        Me.rbtVendasVendedor.TabStop = True
        Me.rbtVendasVendedor.Text = "Vendas x Vendedor"
        Me.rbtVendasVendedor.UseVisualStyleBackColor = True
        '
        'rbtReducaoZ
        '
        Me.rbtReducaoZ.AutoSize = True
        Me.rbtReducaoZ.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtReducaoZ.Location = New System.Drawing.Point(630, 597)
        Me.rbtReducaoZ.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtReducaoZ.Name = "rbtReducaoZ"
        Me.rbtReducaoZ.Size = New System.Drawing.Size(160, 33)
        Me.rbtReducaoZ.TabIndex = 99
        Me.rbtReducaoZ.TabStop = True
        Me.rbtReducaoZ.Text = "Redução Z"
        Me.rbtReducaoZ.UseVisualStyleBackColor = True
        '
        'rbtLeituraX
        '
        Me.rbtLeituraX.AutoSize = True
        Me.rbtLeituraX.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtLeituraX.Location = New System.Drawing.Point(465, 597)
        Me.rbtLeituraX.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtLeituraX.Name = "rbtLeituraX"
        Me.rbtLeituraX.Size = New System.Drawing.Size(141, 33)
        Me.rbtLeituraX.TabIndex = 100
        Me.rbtLeituraX.TabStop = True
        Me.rbtLeituraX.Text = "Leitura X"
        Me.rbtLeituraX.UseVisualStyleBackColor = True
        '
        'rbtCategoria
        '
        Me.rbtCategoria.AutoSize = True
        Me.rbtCategoria.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtCategoria.Location = New System.Drawing.Point(102, 597)
        Me.rbtCategoria.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtCategoria.Name = "rbtCategoria"
        Me.rbtCategoria.Size = New System.Drawing.Size(161, 33)
        Me.rbtCategoria.TabIndex = 101
        Me.rbtCategoria.TabStop = True
        Me.rbtCategoria.Text = "Categorias"
        Me.rbtCategoria.UseVisualStyleBackColor = True
        '
        'rbtBalanco
        '
        Me.rbtBalanco.AutoSize = True
        Me.rbtBalanco.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtBalanco.Location = New System.Drawing.Point(465, 220)
        Me.rbtBalanco.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtBalanco.Name = "rbtBalanco"
        Me.rbtBalanco.Size = New System.Drawing.Size(131, 33)
        Me.rbtBalanco.TabIndex = 102
        Me.rbtBalanco.TabStop = True
        Me.rbtBalanco.Text = "Balanço"
        Me.rbtBalanco.UseVisualStyleBackColor = True
        '
        'rbtSAT
        '
        Me.rbtSAT.AutoSize = True
        Me.rbtSAT.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtSAT.Location = New System.Drawing.Point(102, 651)
        Me.rbtSAT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtSAT.Name = "rbtSAT"
        Me.rbtSAT.Size = New System.Drawing.Size(175, 33)
        Me.rbtSAT.TabIndex = 103
        Me.rbtSAT.TabStop = True
        Me.rbtSAT.Text = "Vendas SAT"
        Me.rbtSAT.UseVisualStyleBackColor = True
        '
        'rbtPix
        '
        Me.rbtPix.AutoSize = True
        Me.rbtPix.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtPix.Location = New System.Drawing.Point(465, 651)
        Me.rbtPix.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtPix.Name = "rbtPix"
        Me.rbtPix.Size = New System.Drawing.Size(221, 33)
        Me.rbtPix.TabIndex = 104
        Me.rbtPix.TabStop = True
        Me.rbtPix.Text = "Vendas com Pix"
        Me.rbtPix.UseVisualStyleBackColor = True
        '
        'rbtCrediarioPix
        '
        Me.rbtCrediarioPix.AutoSize = True
        Me.rbtCrediarioPix.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtCrediarioPix.Location = New System.Drawing.Point(100, 711)
        Me.rbtCrediarioPix.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtCrediarioPix.Name = "rbtCrediarioPix"
        Me.rbtCrediarioPix.Size = New System.Drawing.Size(279, 33)
        Me.rbtCrediarioPix.TabIndex = 105
        Me.rbtCrediarioPix.TabStop = True
        Me.rbtCrediarioPix.Text = "Crediário Pagamento"
        Me.rbtCrediarioPix.UseVisualStyleBackColor = True
        '
        'rbtCobrancaPIX
        '
        Me.rbtCobrancaPIX.AutoSize = True
        Me.rbtCobrancaPIX.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtCobrancaPIX.Location = New System.Drawing.Point(465, 711)
        Me.rbtCobrancaPIX.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtCobrancaPIX.Name = "rbtCobrancaPIX"
        Me.rbtCobrancaPIX.Size = New System.Drawing.Size(260, 33)
        Me.rbtCobrancaPIX.TabIndex = 106
        Me.rbtCobrancaPIX.TabStop = True
        Me.rbtCobrancaPIX.Text = "Cobrança Crediario"
        Me.rbtCobrancaPIX.UseVisualStyleBackColor = True
        '
        'rbtVendasPorVendedor
        '
        Me.rbtVendasPorVendedor.AutoSize = True
        Me.rbtVendasPorVendedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtVendasPorVendedor.Location = New System.Drawing.Point(804, 274)
        Me.rbtVendasPorVendedor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtVendasPorVendedor.Name = "rbtVendasPorVendedor"
        Me.rbtVendasPorVendedor.Size = New System.Drawing.Size(285, 33)
        Me.rbtVendasPorVendedor.TabIndex = 107
        Me.rbtVendasPorVendedor.TabStop = True
        Me.rbtVendasPorVendedor.Text = "Vendas por Vendedor"
        Me.rbtVendasPorVendedor.UseVisualStyleBackColor = True
        '
        'rbtVendasPorLoja
        '
        Me.rbtVendasPorLoja.AutoSize = True
        Me.rbtVendasPorLoja.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtVendasPorLoja.Location = New System.Drawing.Point(804, 328)
        Me.rbtVendasPorLoja.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtVendasPorLoja.Name = "rbtVendasPorLoja"
        Me.rbtVendasPorLoja.Size = New System.Drawing.Size(214, 33)
        Me.rbtVendasPorLoja.TabIndex = 108
        Me.rbtVendasPorLoja.TabStop = True
        Me.rbtVendasPorLoja.Text = "Vendas da Loja"
        Me.rbtVendasPorLoja.UseVisualStyleBackColor = True
        '
        'fRelatorio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1144, 828)
        Me.Controls.Add(Me.rbtVendasPorLoja)
        Me.Controls.Add(Me.rbtVendasPorVendedor)
        Me.Controls.Add(Me.rbtCobrancaPIX)
        Me.Controls.Add(Me.rbtCrediarioPix)
        Me.Controls.Add(Me.rbtPix)
        Me.Controls.Add(Me.rbtSAT)
        Me.Controls.Add(Me.rbtBalanco)
        Me.Controls.Add(Me.rbtCategoria)
        Me.Controls.Add(Me.rbtLeituraX)
        Me.Controls.Add(Me.rbtReducaoZ)
        Me.Controls.Add(Me.rbtVendasVendedor)
        Me.Controls.Add(Me.rbtTransferencia)
        Me.Controls.Add(Me.rdbVendasFabricantes)
        Me.Controls.Add(Me.rbtConsultaVendas)
        Me.Controls.Add(Me.rbtNFe)
        Me.Controls.Add(Me.rbtSPED)
        Me.Controls.Add(Me.rdbVendasSintetico)
        Me.Controls.Add(Me.rbtGrade)
        Me.Controls.Add(Me.rbtAuditoria)
        Me.Controls.Add(Me.rbtCheques)
        Me.Controls.Add(Me.rbtVendasPendentes)
        Me.Controls.Add(Me.btoFiltro)
        Me.Controls.Add(Me.rbtNegativar)
        Me.Controls.Add(Me.rbtClientes)
        Me.Controls.Add(Me.rbtCrediario)
        Me.Controls.Add(Me.rbtMaisVendidos)
        Me.Controls.Add(Me.rbtEstoque)
        Me.Controls.Add(Me.rbtFechamento)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.lblTitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fRelatorio"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produtos"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents rbtFechamento As System.Windows.Forms.RadioButton
    Friend WithEvents rbtEstoque As System.Windows.Forms.RadioButton
    Friend WithEvents rbtMaisVendidos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCrediario As System.Windows.Forms.RadioButton
    Friend WithEvents rbtClientes As System.Windows.Forms.RadioButton
    Friend WithEvents rbtNegativar As System.Windows.Forms.RadioButton
    Friend WithEvents btoFiltro As System.Windows.Forms.Button
    Friend WithEvents rbtVendasPendentes As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCheques As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAuditoria As System.Windows.Forms.RadioButton
    Friend WithEvents rbtGrade As System.Windows.Forms.RadioButton
    Friend WithEvents rdbVendasSintetico As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSPED As System.Windows.Forms.RadioButton
    Friend WithEvents rbtNFe As System.Windows.Forms.RadioButton
    Friend WithEvents rbtConsultaVendas As System.Windows.Forms.RadioButton
    Friend WithEvents rdbVendasFabricantes As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTransferencia As System.Windows.Forms.RadioButton
    Friend WithEvents rbtVendasVendedor As System.Windows.Forms.RadioButton
    Friend WithEvents rbtReducaoZ As System.Windows.Forms.RadioButton
    Friend WithEvents rbtLeituraX As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCategoria As System.Windows.Forms.RadioButton
    Friend WithEvents rbtBalanco As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSAT As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPix As RadioButton
    Friend WithEvents rbtCrediarioPix As RadioButton
    Friend WithEvents rbtCobrancaPIX As RadioButton
    Friend WithEvents rbtVendasPorVendedor As RadioButton
    Friend WithEvents rbtVendasPorLoja As RadioButton
End Class
