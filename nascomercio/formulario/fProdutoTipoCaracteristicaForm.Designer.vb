<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProdutoTipoCaracteristicaForm
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fProdutoTipoCaracteristicaForm))
    Me.btoTipo = New System.Windows.Forms.Button
    Me.btoSair = New System.Windows.Forms.Button
    Me.txtTipo = New System.Windows.Forms.TextBox
    Me.lblTipo = New System.Windows.Forms.Label
    Me.cboCaracteristica = New System.Windows.Forms.ComboBox
    Me.lblCaracteristica = New System.Windows.Forms.Label
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.btoIncluirItem = New System.Windows.Forms.Button
    Me.Label4 = New System.Windows.Forms.Label
    Me.btoExcluirItem = New System.Windows.Forms.Button
    Me.Label2 = New System.Windows.Forms.Label
    Me.dgvCaracteristicas = New System.Windows.Forms.DataGridView
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgvCaracteristicas, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'btoTipo
    '
    Me.btoTipo.BackColor = System.Drawing.Color.Transparent
    Me.btoTipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoTipo.FlatAppearance.BorderSize = 0
    Me.btoTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoTipo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoTipo.ForeColor = System.Drawing.Color.Black
    Me.btoTipo.Image = Global.nascomercio.My.Resources.Resources.tipo_de_produto
    Me.btoTipo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoTipo.Location = New System.Drawing.Point(496, 80)
    Me.btoTipo.Name = "btoTipo"
    Me.btoTipo.Size = New System.Drawing.Size(120, 76)
    Me.btoTipo.TabIndex = 7
    Me.btoTipo.TabStop = False
    Me.btoTipo.Text = "Tipo Produtos <F5>"
    Me.btoTipo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoTipo.UseVisualStyleBackColor = False
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
    Me.btoSair.Size = New System.Drawing.Size(120, 72)
    Me.btoSair.TabIndex = 6
    Me.btoSair.TabStop = False
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSair.UseVisualStyleBackColor = False
    '
    'txtTipo
    '
    Me.txtTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.txtTipo.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtTipo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    Me.txtTipo.Location = New System.Drawing.Point(136, 84)
    Me.txtTipo.MaxLength = 50
    Me.txtTipo.Name = "txtTipo"
    Me.txtTipo.ReadOnly = True
    Me.txtTipo.Size = New System.Drawing.Size(253, 18)
    Me.txtTipo.TabIndex = 1
    Me.txtTipo.TabStop = False
    '
    'lblTipo
    '
    Me.lblTipo.AutoSize = True
    Me.lblTipo.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblTipo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblTipo.ForeColor = System.Drawing.Color.Gray
    Me.lblTipo.Location = New System.Drawing.Point(8, 84)
    Me.lblTipo.Name = "lblTipo"
    Me.lblTipo.Size = New System.Drawing.Size(123, 18)
    Me.lblTipo.TabIndex = 114
    Me.lblTipo.Text = "Tipo de Produto"
    '
    'cboCaracteristica
    '
    Me.cboCaracteristica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboCaracteristica.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cboCaracteristica.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.cboCaracteristica.FormattingEnabled = True
    Me.cboCaracteristica.Items.AddRange(New Object() {"S", "N"})
    Me.cboCaracteristica.Location = New System.Drawing.Point(136, 108)
    Me.cboCaracteristica.Name = "cboCaracteristica"
    Me.cboCaracteristica.Size = New System.Drawing.Size(208, 26)
    Me.cboCaracteristica.TabIndex = 2
    '
    'lblCaracteristica
    '
    Me.lblCaracteristica.AutoSize = True
    Me.lblCaracteristica.BackColor = System.Drawing.Color.Transparent
    Me.lblCaracteristica.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCaracteristica.Location = New System.Drawing.Point(24, 112)
    Me.lblCaracteristica.Name = "lblCaracteristica"
    Me.lblCaracteristica.Size = New System.Drawing.Size(106, 18)
    Me.lblCaracteristica.TabIndex = 113
    Me.lblCaracteristica.Text = "Característica"
    '
    'lblSubTitulo
    '
    Me.lblSubTitulo.AutoSize = True
    Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblSubTitulo.Location = New System.Drawing.Point(64, 32)
    Me.lblSubTitulo.Name = "lblSubTitulo"
    Me.lblSubTitulo.Size = New System.Drawing.Size(67, 14)
    Me.lblSubTitulo.TabIndex = 112
    Me.lblSubTitulo.Text = "CADASTRO"
    '
    'lblTitulo
    '
    Me.lblTitulo.AutoSize = True
    Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblTitulo.Location = New System.Drawing.Point(64, 8)
    Me.lblTitulo.Name = "lblTitulo"
    Me.lblTitulo.Size = New System.Drawing.Size(367, 24)
    Me.lblTitulo.TabIndex = 111
    Me.lblTitulo.Text = "Características do Tipo de Produto "
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.caracteristicas_produtos
    Me.imgLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 110
    Me.imgLogo.TabStop = False
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
    Me.btoIncluirItem.Location = New System.Drawing.Point(8, 328)
    Me.btoIncluirItem.Name = "btoIncluirItem"
    Me.btoIncluirItem.Size = New System.Drawing.Size(25, 25)
    Me.btoIncluirItem.TabIndex = 4
    Me.btoIncluirItem.TabStop = False
    Me.btoIncluirItem.UseVisualStyleBackColor = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.BackColor = System.Drawing.Color.Transparent
    Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(32, 360)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(149, 14)
    Me.Label4.TabIndex = 203
    Me.Label4.Text = "Excluir Característica <F2>"
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
    Me.btoExcluirItem.Location = New System.Drawing.Point(8, 356)
    Me.btoExcluirItem.Name = "btoExcluirItem"
    Me.btoExcluirItem.Size = New System.Drawing.Size(25, 25)
    Me.btoExcluirItem.TabIndex = 5
    Me.btoExcluirItem.TabStop = False
    Me.btoExcluirItem.UseVisualStyleBackColor = False
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(32, 332)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(147, 14)
    Me.Label2.TabIndex = 202
    Me.Label2.Text = "Incluir Característica <F1>"
    '
    'dgvCaracteristicas
    '
    Me.dgvCaracteristicas.AllowUserToAddRows = False
    Me.dgvCaracteristicas.AllowUserToDeleteRows = False
    Me.dgvCaracteristicas.AllowUserToOrderColumns = True
    Me.dgvCaracteristicas.AllowUserToResizeColumns = False
    Me.dgvCaracteristicas.AllowUserToResizeRows = False
    Me.dgvCaracteristicas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
    Me.dgvCaracteristicas.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvCaracteristicas.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.dgvCaracteristicas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    Me.dgvCaracteristicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgvCaracteristicas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
    Me.dgvCaracteristicas.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvCaracteristicas.Location = New System.Drawing.Point(8, 140)
    Me.dgvCaracteristicas.Name = "dgvCaracteristicas"
    Me.dgvCaracteristicas.ReadOnly = True
    Me.dgvCaracteristicas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    Me.dgvCaracteristicas.RowHeadersVisible = False
    Me.dgvCaracteristicas.Size = New System.Drawing.Size(464, 188)
    Me.dgvCaracteristicas.TabIndex = 3
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(618, 389)
    Me.Panel1.TabIndex = 204
    '
    'fProdutoTipoCaracteristicaForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(618, 389)
    Me.Controls.Add(Me.dgvCaracteristicas)
    Me.Controls.Add(Me.btoIncluirItem)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.btoExcluirItem)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.btoTipo)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.txtTipo)
    Me.Controls.Add(Me.lblTipo)
    Me.Controls.Add(Me.cboCaracteristica)
    Me.Controls.Add(Me.lblCaracteristica)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fProdutoTipoCaracteristicaForm"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "ProdutoTipoCaracteristica"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvCaracteristicas, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents btoTipo As System.Windows.Forms.Button
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents txtTipo As System.Windows.Forms.TextBox
  Friend WithEvents lblTipo As System.Windows.Forms.Label
  Friend WithEvents cboCaracteristica As System.Windows.Forms.ComboBox
  Friend WithEvents lblCaracteristica As System.Windows.Forms.Label
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents btoIncluirItem As System.Windows.Forms.Button
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents btoExcluirItem As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents dgvCaracteristicas As System.Windows.Forms.DataGridView
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
