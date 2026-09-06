<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fRelatorioEstoque
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
        Me.btoFiltro = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.cboFornecedor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboFabricante = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProduto = New System.Windows.Forms.TextBox()
        Me.chkEstoque = New System.Windows.Forms.CheckBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.lblDataCadastro = New System.Windows.Forms.Label()
        Me.txtDataCadastroInicio = New System.Windows.Forms.MaskedTextBox()
        Me.lblDataCadastroAte = New System.Windows.Forms.Label()
        Me.txtDataCadastroFim = New System.Windows.Forms.MaskedTextBox()
        Me.lstEstoque = New System.Windows.Forms.ListView()
        Me.btnPrint = New System.Windows.Forms.Button()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSubTitulo.Location = New System.Drawing.Point(64, 34)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(38, 14)
        Me.lblSubTitulo.TabIndex = 138
        Me.lblSubTitulo.Text = "LISTA"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(64, 10)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(221, 24)
        Me.lblTitulo.TabIndex = 136
        Me.lblTitulo.Text = "Relatório de Estoque"
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
        Me.btoFiltro.Location = New System.Drawing.Point(761, 12)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(71, 86)
        Me.btoFiltro.TabIndex = 139
        Me.btoFiltro.Text = "Pesquisar [F5]"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.relatorio
        Me.imgLogo.Location = New System.Drawing.Point(8, 10)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 137
        Me.imgLogo.TabStop = False
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
        Me.btoSair.Location = New System.Drawing.Point(945, 12)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(54, 86)
        Me.btoSair.TabIndex = 134
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'cboFornecedor
        '
        Me.cboFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFornecedor.FormattingEnabled = True
        Me.cboFornecedor.Location = New System.Drawing.Point(111, 100)
        Me.cboFornecedor.Name = "cboFornecedor"
        Me.cboFornecedor.Size = New System.Drawing.Size(210, 21)
        Me.cboFornecedor.TabIndex = 227
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(10, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 18)
        Me.Label3.TabIndex = 228
        Me.Label3.Text = "Fornecedor:"
        '
        'cboFabricante
        '
        Me.cboFabricante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFabricante.FormattingEnabled = True
        Me.cboFabricante.Location = New System.Drawing.Point(420, 100)
        Me.cboFabricante.Name = "cboFabricante"
        Me.cboFabricante.Size = New System.Drawing.Size(212, 21)
        Me.cboFabricante.TabIndex = 229
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(327, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 18)
        Me.Label1.TabIndex = 230
        Me.Label1.Text = "Fabricante:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(341, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 18)
        Me.Label2.TabIndex = 240
        Me.Label2.Text = "Produto: "
        '
        'txtProduto
        '
        Me.txtProduto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtProduto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProduto.Location = New System.Drawing.Point(420, 136)
        Me.txtProduto.MaxLength = 20
        Me.txtProduto.Name = "txtProduto"
        Me.txtProduto.Size = New System.Drawing.Size(318, 18)
        Me.txtProduto.TabIndex = 241
        '
        'chkEstoque
        '
        Me.chkEstoque.AutoSize = True
        Me.chkEstoque.Checked = True
        Me.chkEstoque.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEstoque.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEstoque.Location = New System.Drawing.Point(667, 104)
        Me.chkEstoque.Name = "chkEstoque"
        Me.chkEstoque.Size = New System.Drawing.Size(210, 19)
        Me.chkEstoque.TabIndex = 242
        Me.chkEstoque.Text = "Somente Produtos Com Estoque"
        Me.chkEstoque.UseVisualStyleBackColor = True
        '
        'cboGrupo
        '
        Me.cboGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(111, 136)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(210, 21)
        Me.cboGrupo.TabIndex = 243
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.BackColor = System.Drawing.Color.Transparent
        Me.lblGrupo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblGrupo.Location = New System.Drawing.Point(10, 139)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(57, 18)
        Me.lblGrupo.TabIndex = 244
        Me.lblGrupo.Text = "Grupo:"
        '
        'lblDataCadastro
        '
        Me.lblDataCadastro.AutoSize = True
        Me.lblDataCadastro.BackColor = System.Drawing.Color.Transparent
        Me.lblDataCadastro.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblDataCadastro.Location = New System.Drawing.Point(10, 175)
        Me.lblDataCadastro.Name = "lblDataCadastro"
        Me.lblDataCadastro.Size = New System.Drawing.Size(130, 18)
        Me.lblDataCadastro.TabIndex = 247
        Me.lblDataCadastro.Text = "Cadastro de:"
        '
        'txtDataCadastroInicio
        '
        Me.txtDataCadastroInicio.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataCadastroInicio.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataCadastroInicio.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataCadastroInicio.Location = New System.Drawing.Point(141, 173)
        Me.txtDataCadastroInicio.Mask = "00/00/0000"
        Me.txtDataCadastroInicio.Name = "txtDataCadastroInicio"
        Me.txtDataCadastroInicio.Size = New System.Drawing.Size(78, 18)
        Me.txtDataCadastroInicio.TabIndex = 248
        Me.txtDataCadastroInicio.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'lblDataCadastroAte
        '
        Me.lblDataCadastroAte.AutoSize = True
        Me.lblDataCadastroAte.BackColor = System.Drawing.Color.Transparent
        Me.lblDataCadastroAte.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblDataCadastroAte.Location = New System.Drawing.Point(228, 175)
        Me.lblDataCadastroAte.Name = "lblDataCadastroAte"
        Me.lblDataCadastroAte.Size = New System.Drawing.Size(35, 18)
        Me.lblDataCadastroAte.TabIndex = 249
        Me.lblDataCadastroAte.Text = "ate:"
        '
        'txtDataCadastroFim
        '
        Me.txtDataCadastroFim.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataCadastroFim.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataCadastroFim.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataCadastroFim.Location = New System.Drawing.Point(267, 173)
        Me.txtDataCadastroFim.Mask = "00/00/0000"
        Me.txtDataCadastroFim.Name = "txtDataCadastroFim"
        Me.txtDataCadastroFim.Size = New System.Drawing.Size(78, 18)
        Me.txtDataCadastroFim.TabIndex = 250
        Me.txtDataCadastroFim.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'lstEstoque
        '
        Me.lstEstoque.HideSelection = False
        Me.lstEstoque.Location = New System.Drawing.Point(13, 209)
        Me.lstEstoque.Name = "lstEstoque"
        Me.lstEstoque.Size = New System.Drawing.Size(914, 401)
        Me.lstEstoque.TabIndex = 245
        Me.lstEstoque.UseCompatibleStateImageBehavior = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.Transparent
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.Black
        Me.btnPrint.Image = Global.nascomercio.My.Resources.Resources.print_design
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrint.Location = New System.Drawing.Point(844, 9)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 84)
        Me.btnPrint.TabIndex = 246
        Me.btnPrint.Text = "Imprimir [F8]"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'fRelatorioEstoque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1011, 634)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lstEstoque)
        Me.Controls.Add(Me.cboGrupo)
        Me.Controls.Add(Me.lblGrupo)
        Me.Controls.Add(Me.lblDataCadastro)
        Me.Controls.Add(Me.txtDataCadastroInicio)
        Me.Controls.Add(Me.lblDataCadastroAte)
        Me.Controls.Add(Me.txtDataCadastroFim)
        Me.Controls.Add(Me.chkEstoque)
        Me.Controls.Add(Me.txtProduto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboFabricante)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboFornecedor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.btoFiltro)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.btoSair)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fRelatorioEstoque"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatório de Estoque"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents btoFiltro As System.Windows.Forms.Button
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents cboFornecedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFabricante As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProduto As System.Windows.Forms.TextBox
    Friend WithEvents chkEstoque As System.Windows.Forms.CheckBox
    Friend WithEvents cboGrupo As ComboBox
    Friend WithEvents lblGrupo As Label
    Friend WithEvents lblDataCadastro As System.Windows.Forms.Label
    Friend WithEvents txtDataCadastroInicio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDataCadastroAte As System.Windows.Forms.Label
    Friend WithEvents txtDataCadastroFim As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lstEstoque As ListView
    Friend WithEvents btnPrint As Button
End Class
