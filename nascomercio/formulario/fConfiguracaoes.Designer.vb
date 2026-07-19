<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fConfiguracaoes
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
        Me.rbtParametros = New System.Windows.Forms.RadioButton()
        Me.rbtCores = New System.Windows.Forms.RadioButton()
        Me.rbtGrupo = New System.Windows.Forms.RadioButton()
        Me.rbtTipoProduto = New System.Windows.Forms.RadioButton()
        Me.rbtCaracteristicas = New System.Windows.Forms.RadioButton()
        Me.rbtCondicoes = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbtChaveValidacao = New System.Windows.Forms.RadioButton()
        Me.btoFiltro = New System.Windows.Forms.Button()
        Me.rbtCategorias = New System.Windows.Forms.RadioButton()
        Me.rbtFabricantes = New System.Windows.Forms.RadioButton()
        Me.rbtBackup = New System.Windows.Forms.RadioButton()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.rbtPix = New System.Windows.Forms.RadioButton()
        Me.rbtEmpresas = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblSubTitulo.Size = New System.Drawing.Size(38, 14)
        Me.lblSubTitulo.TabIndex = 91
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
        Me.lblTitulo.Size = New System.Drawing.Size(158, 24)
        Me.lblTitulo.TabIndex = 89
        Me.lblTitulo.Text = "Configurações"
        '
        'rbtParametros
        '
        Me.rbtParametros.AutoSize = True
        Me.rbtParametros.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtParametros.Location = New System.Drawing.Point(66, 121)
        Me.rbtParametros.Name = "rbtParametros"
        Me.rbtParametros.Size = New System.Drawing.Size(204, 23)
        Me.rbtParametros.TabIndex = 2
        Me.rbtParametros.Text = "Parâmetros do Sistema"
        Me.rbtParametros.UseVisualStyleBackColor = True
        '
        'rbtCores
        '
        Me.rbtCores.AutoSize = True
        Me.rbtCores.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtCores.Location = New System.Drawing.Point(66, 179)
        Me.rbtCores.Name = "rbtCores"
        Me.rbtCores.Size = New System.Drawing.Size(73, 23)
        Me.rbtCores.TabIndex = 4
        Me.rbtCores.Text = "Cores"
        Me.rbtCores.UseVisualStyleBackColor = True
        '
        'rbtGrupo
        '
        Me.rbtGrupo.AutoSize = True
        Me.rbtGrupo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtGrupo.Location = New System.Drawing.Point(66, 209)
        Me.rbtGrupo.Name = "rbtGrupo"
        Me.rbtGrupo.Size = New System.Drawing.Size(90, 23)
        Me.rbtGrupo.TabIndex = 5
        Me.rbtGrupo.Text = "Estados"
        Me.rbtGrupo.UseVisualStyleBackColor = True
        '
        'rbtTipoProduto
        '
        Me.rbtTipoProduto.AutoSize = True
        Me.rbtTipoProduto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtTipoProduto.Location = New System.Drawing.Point(66, 239)
        Me.rbtTipoProduto.Name = "rbtTipoProduto"
        Me.rbtTipoProduto.Size = New System.Drawing.Size(167, 23)
        Me.rbtTipoProduto.TabIndex = 6
        Me.rbtTipoProduto.Text = "Tipos de produtos"
        Me.rbtTipoProduto.UseVisualStyleBackColor = True
        '
        'rbtCaracteristicas
        '
        Me.rbtCaracteristicas.AutoSize = True
        Me.rbtCaracteristicas.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtCaracteristicas.Location = New System.Drawing.Point(66, 269)
        Me.rbtCaracteristicas.Name = "rbtCaracteristicas"
        Me.rbtCaracteristicas.Size = New System.Drawing.Size(141, 23)
        Me.rbtCaracteristicas.TabIndex = 7
        Me.rbtCaracteristicas.Text = "Características"
        Me.rbtCaracteristicas.UseVisualStyleBackColor = True
        '
        'rbtCondicoes
        '
        Me.rbtCondicoes.AutoSize = True
        Me.rbtCondicoes.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtCondicoes.Location = New System.Drawing.Point(66, 299)
        Me.rbtCondicoes.Name = "rbtCondicoes"
        Me.rbtCondicoes.Size = New System.Drawing.Size(224, 23)
        Me.rbtCondicoes.TabIndex = 8
        Me.rbtCondicoes.Text = "Condições de Pagamento"
        Me.rbtCondicoes.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.rbtEmpresas)
        Me.Panel1.Controls.Add(Me.rbtPix)
        Me.Panel1.Controls.Add(Me.rbtChaveValidacao)
        Me.Panel1.Controls.Add(Me.btoFiltro)
        Me.Panel1.Controls.Add(Me.rbtCategorias)
        Me.Panel1.Controls.Add(Me.rbtFabricantes)
        Me.Panel1.Controls.Add(Me.rbtBackup)
        Me.Panel1.Controls.Add(Me.rbtCondicoes)
        Me.Panel1.Controls.Add(Me.rbtParametros)
        Me.Panel1.Controls.Add(Me.rbtCaracteristicas)
        Me.Panel1.Controls.Add(Me.rbtCores)
        Me.Panel1.Controls.Add(Me.rbtTipoProduto)
        Me.Panel1.Controls.Add(Me.rbtGrupo)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(586, 485)
        Me.Panel1.TabIndex = 145
        '
        'rbtChaveValidacao
        '
        Me.rbtChaveValidacao.AutoSize = True
        Me.rbtChaveValidacao.Checked = True
        Me.rbtChaveValidacao.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtChaveValidacao.Location = New System.Drawing.Point(66, 92)
        Me.rbtChaveValidacao.Name = "rbtChaveValidacao"
        Me.rbtChaveValidacao.Size = New System.Drawing.Size(177, 23)
        Me.rbtChaveValidacao.TabIndex = 1
        Me.rbtChaveValidacao.TabStop = True
        Me.rbtChaveValidacao.Text = "Chave de Validação"
        Me.rbtChaveValidacao.UseVisualStyleBackColor = True
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
        Me.btoFiltro.Location = New System.Drawing.Point(233, 400)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(120, 73)
        Me.btoFiltro.TabIndex = 11
        Me.btoFiltro.Text = "Selecionar <Enter>"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
        '
        'rbtCategorias
        '
        Me.rbtCategorias.AutoSize = True
        Me.rbtCategorias.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtCategorias.Location = New System.Drawing.Point(66, 358)
        Me.rbtCategorias.Name = "rbtCategorias"
        Me.rbtCategorias.Size = New System.Drawing.Size(110, 23)
        Me.rbtCategorias.TabIndex = 10
        Me.rbtCategorias.Text = "Categorias"
        Me.rbtCategorias.UseVisualStyleBackColor = True
        '
        'rbtFabricantes
        '
        Me.rbtFabricantes.AutoSize = True
        Me.rbtFabricantes.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtFabricantes.Location = New System.Drawing.Point(66, 150)
        Me.rbtFabricantes.Name = "rbtFabricantes"
        Me.rbtFabricantes.Size = New System.Drawing.Size(117, 23)
        Me.rbtFabricantes.TabIndex = 3
        Me.rbtFabricantes.Text = "Fabricantes"
        Me.rbtFabricantes.UseVisualStyleBackColor = True
        '
        'rbtBackup
        '
        Me.rbtBackup.AutoSize = True
        Me.rbtBackup.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtBackup.Location = New System.Drawing.Point(66, 329)
        Me.rbtBackup.Name = "rbtBackup"
        Me.rbtBackup.Size = New System.Drawing.Size(86, 23)
        Me.rbtBackup.TabIndex = 9
        Me.rbtBackup.Text = "Backup"
        Me.rbtBackup.UseVisualStyleBackColor = True
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
        Me.btoSair.Location = New System.Drawing.Point(496, 4)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(88, 72)
        Me.btoSair.TabIndex = 12
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.ferramentas1
        Me.imgLogo.Location = New System.Drawing.Point(8, 8)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 90
        Me.imgLogo.TabStop = False
        '
        'rbtPix
        '
        Me.rbtPix.AutoSize = True
        Me.rbtPix.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtPix.Location = New System.Drawing.Point(66, 387)
        Me.rbtPix.Name = "rbtPix"
        Me.rbtPix.Size = New System.Drawing.Size(53, 23)
        Me.rbtPix.TabIndex = 12
        Me.rbtPix.Text = "PIX"
        Me.rbtPix.UseVisualStyleBackColor = True
        '
        'rbtEmpresas
        '
        Me.rbtEmpresas.AutoSize = True
        Me.rbtEmpresas.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtEmpresas.Location = New System.Drawing.Point(320, 92)
        Me.rbtEmpresas.Name = "rbtEmpresas"
        Me.rbtEmpresas.Size = New System.Drawing.Size(107, 23)
        Me.rbtEmpresas.TabIndex = 13
        Me.rbtEmpresas.Text = "Empresas"
        Me.rbtEmpresas.UseVisualStyleBackColor = True
        '
        'fConfiguracaoes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(586, 485)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fConfiguracaoes"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produtos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents rbtParametros As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCores As System.Windows.Forms.RadioButton
    Friend WithEvents btoFiltro As System.Windows.Forms.Button
    Friend WithEvents rbtGrupo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTipoProduto As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCaracteristicas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCondicoes As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbtBackup As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFabricantes As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCategorias As System.Windows.Forms.RadioButton
    Friend WithEvents rbtChaveValidacao As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPix As RadioButton
    Friend WithEvents rbtEmpresas As System.Windows.Forms.RadioButton
End Class
