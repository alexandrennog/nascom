<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProdutoItemForm
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fProdutoItemForm))
    Me.dgvItem = New System.Windows.Forms.DataGridView
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.btoSalvar = New System.Windows.Forms.Button
    Me.btoSair = New System.Windows.Forms.Button
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.txtDescricao = New System.Windows.Forms.TextBox
    Me.lblTipo = New System.Windows.Forms.Label
    Me.lblDescricao = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtTipo = New System.Windows.Forms.TextBox
    Me.txtCID = New System.Windows.Forms.TextBox
    Me.lblCID = New System.Windows.Forms.Label
    Me.btoIncluirItem = New System.Windows.Forms.Button
    Me.Label4 = New System.Windows.Forms.Label
    Me.btoExcluirItem = New System.Windows.Forms.Button
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dgvItem
    '
    Me.dgvItem.AllowUserToAddRows = False
    Me.dgvItem.AllowUserToDeleteRows = False
    Me.dgvItem.AllowUserToOrderColumns = True
    Me.dgvItem.AllowUserToResizeColumns = False
    Me.dgvItem.AllowUserToResizeRows = False
    Me.dgvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
    Me.dgvItem.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvItem.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.dgvItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    Me.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgvItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
    Me.dgvItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvItem.Location = New System.Drawing.Point(8, 180)
    Me.dgvItem.Name = "dgvItem"
    Me.dgvItem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    Me.dgvItem.RowHeadersVisible = False
    Me.dgvItem.Size = New System.Drawing.Size(636, 132)
    Me.dgvItem.TabIndex = 4
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
    Me.lblSubTitulo.TabIndex = 171
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
    Me.lblTitulo.Size = New System.Drawing.Size(178, 24)
    Me.lblTitulo.TabIndex = 168
    Me.lblTitulo.Text = "Itens do Produto"
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
    Me.btoSalvar.Location = New System.Drawing.Point(312, 340)
    Me.btoSalvar.Name = "btoSalvar"
    Me.btoSalvar.Size = New System.Drawing.Size(96, 72)
    Me.btoSalvar.TabIndex = 7
    Me.btoSalvar.TabStop = False
    Me.btoSalvar.Text = "Salvar <Enter>"
    Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSalvar.UseVisualStyleBackColor = False
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
    Me.btoSair.Location = New System.Drawing.Point(624, 4)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(86, 72)
    Me.btoSair.TabIndex = 8
    Me.btoSair.TabStop = False
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSair.UseVisualStyleBackColor = False
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.tipo_de_produto
    Me.imgLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 170
    Me.imgLogo.TabStop = False
    '
    'txtDescricao
    '
    Me.txtDescricao.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDescricao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtDescricao.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    Me.txtDescricao.Location = New System.Drawing.Point(92, 104)
    Me.txtDescricao.MaxLength = 100
    Me.txtDescricao.Name = "txtDescricao"
    Me.txtDescricao.ReadOnly = True
    Me.txtDescricao.Size = New System.Drawing.Size(400, 18)
    Me.txtDescricao.TabIndex = 2
    Me.txtDescricao.TabStop = False
    '
    'lblTipo
    '
    Me.lblTipo.AutoSize = True
    Me.lblTipo.BackColor = System.Drawing.Color.Transparent
    Me.lblTipo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblTipo.ForeColor = System.Drawing.Color.Gray
    Me.lblTipo.Location = New System.Drawing.Point(48, 128)
    Me.lblTipo.Name = "lblTipo"
    Me.lblTipo.Size = New System.Drawing.Size(40, 18)
    Me.lblTipo.TabIndex = 187
    Me.lblTipo.Text = "Tipo"
    '
    'lblDescricao
    '
    Me.lblDescricao.AutoSize = True
    Me.lblDescricao.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblDescricao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblDescricao.ForeColor = System.Drawing.Color.Gray
    Me.lblDescricao.Location = New System.Drawing.Point(8, 104)
    Me.lblDescricao.Name = "lblDescricao"
    Me.lblDescricao.Size = New System.Drawing.Size(79, 18)
    Me.lblDescricao.TabIndex = 186
    Me.lblDescricao.Text = "Descrição"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label1.Location = New System.Drawing.Point(8, 156)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(114, 18)
    Me.Label1.TabIndex = 188
    Me.Label1.Text = "Características"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(548, 128)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(96, 14)
    Me.Label2.TabIndex = 190
    Me.Label2.Text = "Incluir Item <F1>"
    '
    'txtTipo
    '
    Me.txtTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.txtTipo.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtTipo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    Me.txtTipo.Location = New System.Drawing.Point(92, 128)
    Me.txtTipo.MaxLength = 100
    Me.txtTipo.Name = "txtTipo"
    Me.txtTipo.ReadOnly = True
    Me.txtTipo.Size = New System.Drawing.Size(188, 18)
    Me.txtTipo.TabIndex = 3
    Me.txtTipo.TabStop = False
    '
    'txtCID
    '
    Me.txtCID.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.txtCID.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCID.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtCID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    Me.txtCID.Location = New System.Drawing.Point(92, 80)
    Me.txtCID.MaxLength = 100
    Me.txtCID.Name = "txtCID"
    Me.txtCID.ReadOnly = True
    Me.txtCID.Size = New System.Drawing.Size(88, 18)
    Me.txtCID.TabIndex = 1
    Me.txtCID.TabStop = False
    '
    'lblCID
    '
    Me.lblCID.AutoSize = True
    Me.lblCID.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblCID.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCID.ForeColor = System.Drawing.Color.Gray
    Me.lblCID.Location = New System.Drawing.Point(52, 80)
    Me.lblCID.Name = "lblCID"
    Me.lblCID.Size = New System.Drawing.Size(34, 18)
    Me.lblCID.TabIndex = 195
    Me.lblCID.Text = "CID"
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
    Me.btoIncluirItem.Location = New System.Drawing.Point(524, 124)
    Me.btoIncluirItem.Name = "btoIncluirItem"
    Me.btoIncluirItem.Size = New System.Drawing.Size(25, 25)
    Me.btoIncluirItem.TabIndex = 5
    Me.btoIncluirItem.TabStop = False
    Me.btoIncluirItem.UseVisualStyleBackColor = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.BackColor = System.Drawing.Color.Transparent
    Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(548, 156)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(98, 14)
    Me.Label4.TabIndex = 199
    Me.Label4.Text = "Excluir Item <F2>"
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
    Me.btoExcluirItem.Location = New System.Drawing.Point(524, 152)
    Me.btoExcluirItem.Name = "btoExcluirItem"
    Me.btoExcluirItem.Size = New System.Drawing.Size(25, 25)
    Me.btoExcluirItem.TabIndex = 6
    Me.btoExcluirItem.TabStop = False
    Me.btoExcluirItem.UseVisualStyleBackColor = False
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(713, 414)
    Me.Panel1.TabIndex = 200
    '
    'fProdutoItemForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(713, 414)
    Me.Controls.Add(Me.btoIncluirItem)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.txtCID)
    Me.Controls.Add(Me.btoExcluirItem)
    Me.Controls.Add(Me.lblCID)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.txtTipo)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtDescricao)
    Me.Controls.Add(Me.lblTipo)
    Me.Controls.Add(Me.lblDescricao)
    Me.Controls.Add(Me.dgvItem)
    Me.Controls.Add(Me.btoSalvar)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fProdutoItemForm"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Produtos"
    CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents dgvItem As System.Windows.Forms.DataGridView
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
  Friend WithEvents lblTipo As System.Windows.Forms.Label
  Friend WithEvents lblDescricao As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtTipo As System.Windows.Forms.TextBox
  Friend WithEvents txtCID As System.Windows.Forms.TextBox
  Friend WithEvents lblCID As System.Windows.Forms.Label
  Friend WithEvents btoIncluirItem As System.Windows.Forms.Button
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents btoExcluirItem As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
