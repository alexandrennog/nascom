<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mdiPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mdiPrincipal))
        Me.menuPrincipal = New System.Windows.Forms.ToolStrip()
        Me.menuTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.menuSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.botaoMenuUsuarios = New System.Windows.Forms.ToolStripButton()
        Me.botaoMenuProdutos = New System.Windows.Forms.ToolStripButton()
        Me.botaoMenuFornecedor = New System.Windows.Forms.ToolStripButton()
        Me.botaoMenuClientes = New System.Windows.Forms.ToolStripButton()
        Me.botaoMenuFabricantes = New System.Windows.Forms.ToolStripButton()
        Me.menuSep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.botaoMenuUsuarioPerfil = New System.Windows.Forms.ToolStripButton()
        Me.botaoMenuProdutoTipos = New System.Windows.Forms.ToolStripButton()
        Me.botaoMenuProdutoCategorias = New System.Windows.Forms.ToolStripButton()
        Me.botaoMenuEstados = New System.Windows.Forms.ToolStripButton()
        Me.botaoMenuPagamentos = New System.Windows.Forms.ToolStripButton()
        Me.pnlInformacoes = New System.Windows.Forms.Panel()
        Me.lblTerminal = New System.Windows.Forms.Label()
        Me.lblSite = New System.Windows.Forms.Label()
        Me.lblLoja = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.btoOrdemServico = New System.Windows.Forms.Button()
        Me.btoFabricante = New System.Windows.Forms.Button()
        Me.btoContasPagar = New System.Windows.Forms.Button()
        Me.btoSobre = New System.Windows.Forms.Button()
        Me.btoConfigurar = New System.Windows.Forms.Button()
        Me.btoESProduto = New System.Windows.Forms.Button()
        Me.btoRelatorio = New System.Windows.Forms.Button()
        Me.btoLoja = New System.Windows.Forms.Button()
        Me.btoCaixa = New System.Windows.Forms.Button()
        Me.btoProduto = New System.Windows.Forms.Button()
        Me.btoEstado = New System.Windows.Forms.Button()
        Me.btoCliente = New System.Windows.Forms.Button()
        Me.btoFornecedor = New System.Windows.Forms.Button()
        Me.btoUsuario = New System.Windows.Forms.Button()
        Me.btnCaixa = New System.Windows.Forms.Button()
        Me.menuPrincipal.SuspendLayout()
        Me.pnlInformacoes.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuPrincipal
        '
        Me.menuPrincipal.BackColor = System.Drawing.Color.White
        Me.menuPrincipal.Dock = System.Windows.Forms.DockStyle.None
        Me.menuPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.menuPrincipal.ImageScalingSize = New System.Drawing.Size(40, 40)
        Me.menuPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuTitulo, Me.menuSep1, Me.botaoMenuUsuarios, Me.botaoMenuProdutos, Me.botaoMenuFornecedor, Me.botaoMenuClientes, Me.botaoMenuFabricantes, Me.menuSep2, Me.botaoMenuUsuarioPerfil, Me.botaoMenuProdutoTipos, Me.botaoMenuProdutoCategorias, Me.botaoMenuEstados, Me.botaoMenuPagamentos})
        Me.menuPrincipal.Location = New System.Drawing.Point(12, 480)
        Me.menuPrincipal.Name = "menuPrincipal"
        Me.menuPrincipal.Size = New System.Drawing.Size(735, 62)
        Me.menuPrincipal.TabIndex = 9
        Me.menuPrincipal.Visible = False
        '
        'menuTitulo
        '
        Me.menuTitulo.AutoSize = False
        Me.menuTitulo.BackgroundImage = CType(resources.GetObject("menuTitulo.BackgroundImage"), System.Drawing.Image)
        Me.menuTitulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.menuTitulo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menuTitulo.Name = "menuTitulo"
        Me.menuTitulo.Size = New System.Drawing.Size(130, 50)
        '
        'menuSep1
        '
        Me.menuSep1.Name = "menuSep1"
        Me.menuSep1.Size = New System.Drawing.Size(6, 62)
        '
        'botaoMenuUsuarios
        '
        Me.botaoMenuUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.botaoMenuUsuarios.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.botaoMenuUsuarios.Image = Global.nascomercio.My.Resources.Resources.usuarios
        Me.botaoMenuUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.botaoMenuUsuarios.Name = "botaoMenuUsuarios"
        Me.botaoMenuUsuarios.Size = New System.Drawing.Size(52, 59)
        Me.botaoMenuUsuarios.Text = "&Usuários"
        Me.botaoMenuUsuarios.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.botaoMenuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'botaoMenuProdutos
        '
        Me.botaoMenuProdutos.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.botaoMenuProdutos.Image = Global.nascomercio.My.Resources.Resources.usuarios
        Me.botaoMenuProdutos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.botaoMenuProdutos.Name = "botaoMenuProdutos"
        Me.botaoMenuProdutos.Size = New System.Drawing.Size(54, 59)
        Me.botaoMenuProdutos.Text = "&Produtos"
        Me.botaoMenuProdutos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.botaoMenuProdutos.ToolTipText = "Produtos"
        '
        'botaoMenuFornecedor
        '
        Me.botaoMenuFornecedor.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.botaoMenuFornecedor.Image = Global.nascomercio.My.Resources.Resources.usuarios
        Me.botaoMenuFornecedor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.botaoMenuFornecedor.Name = "botaoMenuFornecedor"
        Me.botaoMenuFornecedor.Size = New System.Drawing.Size(77, 59)
        Me.botaoMenuFornecedor.Text = "&Fornecedores"
        Me.botaoMenuFornecedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'botaoMenuClientes
        '
        Me.botaoMenuClientes.Image = Global.nascomercio.My.Resources.Resources.usuarios
        Me.botaoMenuClientes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.botaoMenuClientes.Name = "botaoMenuClientes"
        Me.botaoMenuClientes.Size = New System.Drawing.Size(53, 59)
        Me.botaoMenuClientes.Text = "&Clientes"
        Me.botaoMenuClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'botaoMenuFabricantes
        '
        Me.botaoMenuFabricantes.Image = Global.nascomercio.My.Resources.Resources.usuarios
        Me.botaoMenuFabricantes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.botaoMenuFabricantes.Name = "botaoMenuFabricantes"
        Me.botaoMenuFabricantes.Size = New System.Drawing.Size(71, 59)
        Me.botaoMenuFabricantes.Text = "Fa&bricantes"
        Me.botaoMenuFabricantes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'menuSep2
        '
        Me.menuSep2.Name = "menuSep2"
        Me.menuSep2.Size = New System.Drawing.Size(6, 62)
        '
        'botaoMenuUsuarioPerfil
        '
        Me.botaoMenuUsuarioPerfil.Image = Global.nascomercio.My.Resources.Resources.usuarios
        Me.botaoMenuUsuarioPerfil.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.botaoMenuUsuarioPerfil.Name = "botaoMenuUsuarioPerfil"
        Me.botaoMenuUsuarioPerfil.Size = New System.Drawing.Size(44, 59)
        Me.botaoMenuUsuarioPerfil.Text = "Perfil"
        Me.botaoMenuUsuarioPerfil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'botaoMenuProdutoTipos
        '
        Me.botaoMenuProdutoTipos.Image = Global.nascomercio.My.Resources.Resources.usuarios
        Me.botaoMenuProdutoTipos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.botaoMenuProdutoTipos.Name = "botaoMenuProdutoTipos"
        Me.botaoMenuProdutoTipos.Size = New System.Drawing.Size(44, 59)
        Me.botaoMenuProdutoTipos.Text = "Tipos"
        Me.botaoMenuProdutoTipos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'botaoMenuProdutoCategorias
        '
        Me.botaoMenuProdutoCategorias.Image = Global.nascomercio.My.Resources.Resources.usuarios
        Me.botaoMenuProdutoCategorias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.botaoMenuProdutoCategorias.Name = "botaoMenuProdutoCategorias"
        Me.botaoMenuProdutoCategorias.Size = New System.Drawing.Size(67, 59)
        Me.botaoMenuProdutoCategorias.Text = "Categorias"
        Me.botaoMenuProdutoCategorias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'botaoMenuEstados
        '
        Me.botaoMenuEstados.Image = Global.nascomercio.My.Resources.Resources.usuarios
        Me.botaoMenuEstados.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.botaoMenuEstados.Name = "botaoMenuEstados"
        Me.botaoMenuEstados.Size = New System.Drawing.Size(51, 59)
        Me.botaoMenuEstados.Text = "Estados"
        Me.botaoMenuEstados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'botaoMenuPagamentos
        '
        Me.botaoMenuPagamentos.Image = Global.nascomercio.My.Resources.Resources.usuarios
        Me.botaoMenuPagamentos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.botaoMenuPagamentos.Name = "botaoMenuPagamentos"
        Me.botaoMenuPagamentos.Size = New System.Drawing.Size(77, 59)
        Me.botaoMenuPagamentos.Text = "Pagamentos"
        Me.botaoMenuPagamentos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'pnlInformacoes
        '
        Me.pnlInformacoes.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlInformacoes.Controls.Add(Me.lblTerminal)
        Me.pnlInformacoes.Controls.Add(Me.lblSite)
        Me.pnlInformacoes.Controls.Add(Me.lblLoja)
        Me.pnlInformacoes.Controls.Add(Me.lblUsuario)
        Me.pnlInformacoes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInformacoes.Location = New System.Drawing.Point(0, 712)
        Me.pnlInformacoes.Name = "pnlInformacoes"
        Me.pnlInformacoes.Size = New System.Drawing.Size(1016, 22)
        Me.pnlInformacoes.TabIndex = 28
        '
        'lblTerminal
        '
        Me.lblTerminal.AutoSize = True
        Me.lblTerminal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTerminal.Location = New System.Drawing.Point(314, 4)
        Me.lblTerminal.Name = "lblTerminal"
        Me.lblTerminal.Size = New System.Drawing.Size(59, 15)
        Me.lblTerminal.TabIndex = 3
        Me.lblTerminal.Text = "Terminal:"
        '
        'lblSite
        '
        Me.lblSite.AutoSize = True
        Me.lblSite.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSite.Location = New System.Drawing.Point(872, 4)
        Me.lblSite.Name = "lblSite"
        Me.lblSite.Size = New System.Drawing.Size(129, 15)
        Me.lblSite.TabIndex = 2
        Me.lblSite.Text = "www.nascom.com.br"
        '
        'lblLoja
        '
        Me.lblLoja.AutoSize = True
        Me.lblLoja.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoja.Location = New System.Drawing.Point(507, 4)
        Me.lblLoja.Name = "lblLoja"
        Me.lblLoja.Size = New System.Drawing.Size(34, 15)
        Me.lblLoja.TabIndex = 1
        Me.lblLoja.Text = "Loja:"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(4, 4)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(54, 15)
        Me.lblUsuario.TabIndex = 0
        Me.lblUsuario.Text = "Usuário:"
        '
        'pnlMenu
        '
        Me.pnlMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.pnlMenu.Controls.Add(Me.btoOrdemServico)
        Me.pnlMenu.Controls.Add(Me.btoFabricante)
        Me.pnlMenu.Controls.Add(Me.btoContasPagar)
        Me.pnlMenu.Controls.Add(Me.btoSobre)
        Me.pnlMenu.Controls.Add(Me.btoConfigurar)
        Me.pnlMenu.Controls.Add(Me.btoESProduto)
        Me.pnlMenu.Controls.Add(Me.btoRelatorio)
        Me.pnlMenu.Controls.Add(Me.btoLoja)
        Me.pnlMenu.Controls.Add(Me.btoCaixa)
        Me.pnlMenu.Controls.Add(Me.btoProduto)
        Me.pnlMenu.Controls.Add(Me.btoEstado)
        Me.pnlMenu.Controls.Add(Me.btoCliente)
        Me.pnlMenu.Controls.Add(Me.btoFornecedor)
        Me.pnlMenu.Controls.Add(Me.btoUsuario)
        Me.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMenu.Location = New System.Drawing.Point(0, 0)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(1016, 87)
        Me.pnlMenu.TabIndex = 39
        Me.pnlMenu.Visible = False
        '
        'btoOrdemServico
        '
        Me.btoOrdemServico.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btoOrdemServico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btoOrdemServico.FlatAppearance.BorderSize = 0
        Me.btoOrdemServico.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btoOrdemServico.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoOrdemServico.ForeColor = System.Drawing.Color.Black
        Me.btoOrdemServico.Image = Global.nascomercio.My.Resources.Resources.cliente_financeiro
        Me.btoOrdemServico.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoOrdemServico.Location = New System.Drawing.Point(949, 2)
        Me.btoOrdemServico.Margin = New System.Windows.Forms.Padding(0)
        Me.btoOrdemServico.Name = "btoOrdemServico"
        Me.btoOrdemServico.Size = New System.Drawing.Size(62, 83)
        Me.btoOrdemServico.TabIndex = 56
        Me.btoOrdemServico.Text = "Ordem Serviço"
        Me.btoOrdemServico.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoOrdemServico.UseVisualStyleBackColor = False
        '
        'btoFabricante
        '
        Me.btoFabricante.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btoFabricante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btoFabricante.FlatAppearance.BorderSize = 0
        Me.btoFabricante.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btoFabricante.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoFabricante.ForeColor = System.Drawing.Color.Black
        Me.btoFabricante.Image = Global.nascomercio.My.Resources.Resources.fabricantes
        Me.btoFabricante.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoFabricante.Location = New System.Drawing.Point(434, 2)
        Me.btoFabricante.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFabricante.Name = "btoFabricante"
        Me.btoFabricante.Size = New System.Drawing.Size(71, 83)
        Me.btoFabricante.TabIndex = 55
        Me.btoFabricante.Text = "Fabricantes [F7]"
        Me.btoFabricante.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFabricante.UseVisualStyleBackColor = False
        '
        'btoContasPagar
        '
        Me.btoContasPagar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btoContasPagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btoContasPagar.FlatAppearance.BorderSize = 0
        Me.btoContasPagar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btoContasPagar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoContasPagar.ForeColor = System.Drawing.Color.Black
        Me.btoContasPagar.Image = Global.nascomercio.My.Resources.Resources.cifrao_peq
        Me.btoContasPagar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoContasPagar.Location = New System.Drawing.Point(3, 2)
        Me.btoContasPagar.Margin = New System.Windows.Forms.Padding(0)
        Me.btoContasPagar.Name = "btoContasPagar"
        Me.btoContasPagar.Size = New System.Drawing.Size(74, 83)
        Me.btoContasPagar.TabIndex = 54
        Me.btoContasPagar.Text = "Contas a Pagar [F1]"
        Me.btoContasPagar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoContasPagar.UseVisualStyleBackColor = False
        '
        'btoSobre
        '
        Me.btoSobre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btoSobre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btoSobre.FlatAppearance.BorderSize = 0
        Me.btoSobre.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btoSobre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoSobre.ForeColor = System.Drawing.Color.Black
        Me.btoSobre.Image = Global.nascomercio.My.Resources.Resources.estados
        Me.btoSobre.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoSobre.Location = New System.Drawing.Point(886, 2)
        Me.btoSobre.Margin = New System.Windows.Forms.Padding(0)
        Me.btoSobre.Name = "btoSobre"
        Me.btoSobre.Size = New System.Drawing.Size(60, 83)
        Me.btoSobre.TabIndex = 53
        Me.btoSobre.Text = "Sobre"
        Me.btoSobre.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSobre.UseVisualStyleBackColor = False
        '
        'btoConfigurar
        '
        Me.btoConfigurar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btoConfigurar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btoConfigurar.FlatAppearance.BorderSize = 0
        Me.btoConfigurar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btoConfigurar.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoConfigurar.ForeColor = System.Drawing.Color.Black
        Me.btoConfigurar.Image = Global.nascomercio.My.Resources.Resources.ferramentas1
        Me.btoConfigurar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoConfigurar.Location = New System.Drawing.Point(799, 2)
        Me.btoConfigurar.Margin = New System.Windows.Forms.Padding(0)
        Me.btoConfigurar.Name = "btoConfigurar"
        Me.btoConfigurar.Size = New System.Drawing.Size(84, 83)
        Me.btoConfigurar.TabIndex = 52
        Me.btoConfigurar.Text = "Configurações [F12]"
        Me.btoConfigurar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoConfigurar.UseVisualStyleBackColor = False
        '
        'btoESProduto
        '
        Me.btoESProduto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btoESProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btoESProduto.FlatAppearance.BorderSize = 0
        Me.btoESProduto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btoESProduto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoESProduto.ForeColor = System.Drawing.Color.Black
        Me.btoESProduto.Image = Global.nascomercio.My.Resources.Resources.entrada_saida_estoque
        Me.btoESProduto.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoESProduto.Location = New System.Drawing.Point(721, 2)
        Me.btoESProduto.Margin = New System.Windows.Forms.Padding(0)
        Me.btoESProduto.Name = "btoESProduto"
        Me.btoESProduto.Size = New System.Drawing.Size(76, 83)
        Me.btoESProduto.TabIndex = 51
        Me.btoESProduto.Text = "Inventário" & Global.Microsoft.VisualBasic.ChrW(10) & "Produtos [F11]"
        Me.btoESProduto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoESProduto.UseVisualStyleBackColor = False
        '
        'btoRelatorio
        '
        Me.btoRelatorio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btoRelatorio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btoRelatorio.FlatAppearance.BorderSize = 0
        Me.btoRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btoRelatorio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoRelatorio.ForeColor = System.Drawing.Color.Black
        Me.btoRelatorio.Image = Global.nascomercio.My.Resources.Resources.relatorio
        Me.btoRelatorio.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoRelatorio.Location = New System.Drawing.Point(646, 2)
        Me.btoRelatorio.Margin = New System.Windows.Forms.Padding(0)
        Me.btoRelatorio.Name = "btoRelatorio"
        Me.btoRelatorio.Size = New System.Drawing.Size(73, 83)
        Me.btoRelatorio.TabIndex = 50
        Me.btoRelatorio.Text = "Relatórios" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[F10]"
        Me.btoRelatorio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoRelatorio.UseVisualStyleBackColor = False
        '
        'btoLoja
        '
        Me.btoLoja.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btoLoja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoLoja.FlatAppearance.BorderSize = 0
        Me.btoLoja.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btoLoja.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoLoja.ForeColor = System.Drawing.Color.Black
        Me.btoLoja.Image = Global.nascomercio.My.Resources.Resources.loja
        Me.btoLoja.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoLoja.Location = New System.Drawing.Point(508, 2)
        Me.btoLoja.Margin = New System.Windows.Forms.Padding(0)
        Me.btoLoja.Name = "btoLoja"
        Me.btoLoja.Size = New System.Drawing.Size(63, 83)
        Me.btoLoja.TabIndex = 49
        Me.btoLoja.Text = "Lojas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[F8]"
        Me.btoLoja.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoLoja.UseVisualStyleBackColor = False
        '
        'btoCaixa
        '
        Me.btoCaixa.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btoCaixa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btoCaixa.FlatAppearance.BorderSize = 0
        Me.btoCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btoCaixa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoCaixa.ForeColor = System.Drawing.Color.Black
        Me.btoCaixa.Image = Global.nascomercio.My.Resources.Resources.caixa
        Me.btoCaixa.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoCaixa.Location = New System.Drawing.Point(574, 2)
        Me.btoCaixa.Margin = New System.Windows.Forms.Padding(0)
        Me.btoCaixa.Name = "btoCaixa"
        Me.btoCaixa.Size = New System.Drawing.Size(69, 83)
        Me.btoCaixa.TabIndex = 48
        Me.btoCaixa.Text = "Caixa" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[F9]"
        Me.btoCaixa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoCaixa.UseVisualStyleBackColor = False
        '
        'btoProduto
        '
        Me.btoProduto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btoProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btoProduto.FlatAppearance.BorderSize = 0
        Me.btoProduto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btoProduto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoProduto.ForeColor = System.Drawing.Color.Black
        Me.btoProduto.Image = Global.nascomercio.My.Resources.Resources.produtos
        Me.btoProduto.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoProduto.Location = New System.Drawing.Point(365, 2)
        Me.btoProduto.Margin = New System.Windows.Forms.Padding(0)
        Me.btoProduto.Name = "btoProduto"
        Me.btoProduto.Size = New System.Drawing.Size(66, 83)
        Me.btoProduto.TabIndex = 40
        Me.btoProduto.Text = "Produtos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[F6]"
        Me.btoProduto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoProduto.UseVisualStyleBackColor = False
        '
        'btoEstado
        '
        Me.btoEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btoEstado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btoEstado.FlatAppearance.BorderSize = 0
        Me.btoEstado.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btoEstado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoEstado.ForeColor = System.Drawing.Color.Black
        Me.btoEstado.Image = Global.nascomercio.My.Resources.Resources.caracteristicas_produtos
        Me.btoEstado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoEstado.Location = New System.Drawing.Point(298, 2)
        Me.btoEstado.Margin = New System.Windows.Forms.Padding(0)
        Me.btoEstado.Name = "btoEstado"
        Me.btoEstado.Size = New System.Drawing.Size(64, 83)
        Me.btoEstado.TabIndex = 44
        Me.btoEstado.Text = "Grupos " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[F5]"
        Me.btoEstado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoEstado.UseVisualStyleBackColor = False
        '
        'btoCliente
        '
        Me.btoCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btoCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btoCliente.FlatAppearance.BorderSize = 0
        Me.btoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btoCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoCliente.ForeColor = System.Drawing.Color.Black
        Me.btoCliente.Image = Global.nascomercio.My.Resources.Resources.cliente
        Me.btoCliente.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoCliente.Location = New System.Drawing.Point(231, 2)
        Me.btoCliente.Margin = New System.Windows.Forms.Padding(0)
        Me.btoCliente.Name = "btoCliente"
        Me.btoCliente.Size = New System.Drawing.Size(64, 83)
        Me.btoCliente.TabIndex = 43
        Me.btoCliente.Text = "Clientes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[F4]"
        Me.btoCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoCliente.UseVisualStyleBackColor = False
        '
        'btoFornecedor
        '
        Me.btoFornecedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btoFornecedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoFornecedor.FlatAppearance.BorderSize = 0
        Me.btoFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btoFornecedor.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoFornecedor.ForeColor = System.Drawing.Color.Black
        Me.btoFornecedor.Image = Global.nascomercio.My.Resources.Resources.fornecedores
        Me.btoFornecedor.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoFornecedor.Location = New System.Drawing.Point(147, 2)
        Me.btoFornecedor.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFornecedor.Name = "btoFornecedor"
        Me.btoFornecedor.Size = New System.Drawing.Size(81, 83)
        Me.btoFornecedor.TabIndex = 42
        Me.btoFornecedor.Text = "Fornecedores [F3]"
        Me.btoFornecedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFornecedor.UseVisualStyleBackColor = False
        '
        'btoUsuario
        '
        Me.btoUsuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btoUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btoUsuario.FlatAppearance.BorderSize = 0
        Me.btoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btoUsuario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoUsuario.ForeColor = System.Drawing.Color.Black
        Me.btoUsuario.Image = Global.nascomercio.My.Resources.Resources.usuario
        Me.btoUsuario.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoUsuario.Location = New System.Drawing.Point(80, 2)
        Me.btoUsuario.Margin = New System.Windows.Forms.Padding(0)
        Me.btoUsuario.Name = "btoUsuario"
        Me.btoUsuario.Size = New System.Drawing.Size(64, 83)
        Me.btoUsuario.TabIndex = 41
        Me.btoUsuario.Text = "Usuarios [F2]"
        Me.btoUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoUsuario.UseVisualStyleBackColor = False
        '
        'btnCaixa
        '
        Me.btnCaixa.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnCaixa.BackgroundImage = CType(resources.GetObject("btnCaixa.BackgroundImage"), System.Drawing.Image)
        Me.btnCaixa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCaixa.FlatAppearance.BorderSize = 0
        Me.btnCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCaixa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnCaixa.ForeColor = System.Drawing.Color.White
        Me.btnCaixa.Location = New System.Drawing.Point(544, 4)
        Me.btnCaixa.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCaixa.Name = "btnCaixa"
        Me.btnCaixa.Size = New System.Drawing.Size(70, 60)
        Me.btnCaixa.TabIndex = 46
        Me.btnCaixa.Text = "CAIXA"
        Me.btnCaixa.UseVisualStyleBackColor = False
        '
        'mdiPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1016, 734)
        Me.Controls.Add(Me.pnlMenu)
        Me.Controls.Add(Me.pnlInformacoes)
        Me.Controls.Add(Me.menuPrincipal)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "mdiPrincipal"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sistema"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.menuPrincipal.ResumeLayout(False)
        Me.menuPrincipal.PerformLayout()
        Me.pnlInformacoes.ResumeLayout(False)
        Me.pnlInformacoes.PerformLayout()
        Me.pnlMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menuPrincipal As System.Windows.Forms.ToolStrip
    Friend WithEvents botaoMenuUsuarios As System.Windows.Forms.ToolStripButton
    Friend WithEvents botaoMenuProdutos As System.Windows.Forms.ToolStripButton
    Friend WithEvents botaoMenuFornecedor As System.Windows.Forms.ToolStripButton
    Friend WithEvents botaoMenuUsuarioPerfil As System.Windows.Forms.ToolStripButton
    Friend WithEvents menuTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents menuSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents botaoMenuProdutoCategorias As System.Windows.Forms.ToolStripButton
    Friend WithEvents menuSep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents botaoMenuClientes As System.Windows.Forms.ToolStripButton
    Friend WithEvents botaoMenuFabricantes As System.Windows.Forms.ToolStripButton
    Friend WithEvents botaoMenuProdutoTipos As System.Windows.Forms.ToolStripButton
    Friend WithEvents botaoMenuEstados As System.Windows.Forms.ToolStripButton
    Friend WithEvents botaoMenuPagamentos As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlInformacoes As System.Windows.Forms.Panel
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents btoProduto As System.Windows.Forms.Button
    Friend WithEvents btoEstado As System.Windows.Forms.Button
    Friend WithEvents btoCliente As System.Windows.Forms.Button
    Friend WithEvents btoFornecedor As System.Windows.Forms.Button
    Friend WithEvents btoUsuario As System.Windows.Forms.Button
    Friend WithEvents btnCaixa As System.Windows.Forms.Button
    Friend WithEvents btoCaixa As System.Windows.Forms.Button
    Friend WithEvents btoLoja As System.Windows.Forms.Button
    Friend WithEvents btoRelatorio As System.Windows.Forms.Button
    Friend WithEvents btoESProduto As System.Windows.Forms.Button
    Friend WithEvents btoConfigurar As System.Windows.Forms.Button
    Friend WithEvents lblLoja As System.Windows.Forms.Label
    Friend WithEvents btoSobre As System.Windows.Forms.Button
    Friend WithEvents btoContasPagar As System.Windows.Forms.Button
    Friend WithEvents lblSite As System.Windows.Forms.Label
    Friend WithEvents btoFabricante As System.Windows.Forms.Button
    Friend WithEvents btoOrdemServico As System.Windows.Forms.Button
    Friend WithEvents lblTerminal As System.Windows.Forms.Label

End Class
