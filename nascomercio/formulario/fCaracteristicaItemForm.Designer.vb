<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fCaracteristicaItemForm
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fCaracteristicaItemForm))
    Me.lblCodigo = New System.Windows.Forms.Label
    Me.txtCodigo = New System.Windows.Forms.TextBox
    Me.txtNome = New System.Windows.Forms.TextBox
    Me.lblNome = New System.Windows.Forms.Label
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.btoSair = New System.Windows.Forms.Button
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.dgvItem = New System.Windows.Forms.DataGridView
    Me.txtItem = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.btoIncluirItem = New System.Windows.Forms.Button
    Me.Label4 = New System.Windows.Forms.Label
    Me.btoExcluirItem = New System.Windows.Forms.Button
    Me.Label2 = New System.Windows.Forms.Label
    Me.btoCaracteristica = New System.Windows.Forms.Button
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'lblCodigo
    '
    Me.lblCodigo.AutoSize = True
    Me.lblCodigo.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCodigo.ForeColor = System.Drawing.Color.Gray
    Me.lblCodigo.Location = New System.Drawing.Point(20, 73)
    Me.lblCodigo.Name = "lblCodigo"
    Me.lblCodigo.Size = New System.Drawing.Size(59, 18)
    Me.lblCodigo.TabIndex = 130
    Me.lblCodigo.Text = "Código"
    '
    'txtCodigo
    '
    Me.txtCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    Me.txtCodigo.Location = New System.Drawing.Point(84, 73)
    Me.txtCodigo.MaxLength = 20
    Me.txtCodigo.Name = "txtCodigo"
    Me.txtCodigo.ReadOnly = True
    Me.txtCodigo.Size = New System.Drawing.Size(148, 18)
    Me.txtCodigo.TabIndex = 1
    Me.txtCodigo.TabStop = False
    '
    'txtNome
    '
    Me.txtNome.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtNome.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    Me.txtNome.Location = New System.Drawing.Point(84, 97)
    Me.txtNome.MaxLength = 50
    Me.txtNome.Name = "txtNome"
    Me.txtNome.ReadOnly = True
    Me.txtNome.Size = New System.Drawing.Size(348, 18)
    Me.txtNome.TabIndex = 2
    Me.txtNome.TabStop = False
    '
    'lblNome
    '
    Me.lblNome.AutoSize = True
    Me.lblNome.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblNome.ForeColor = System.Drawing.Color.Gray
    Me.lblNome.Location = New System.Drawing.Point(28, 97)
    Me.lblNome.Name = "lblNome"
    Me.lblNome.Size = New System.Drawing.Size(49, 18)
    Me.lblNome.TabIndex = 129
    Me.lblNome.Text = "Nome"
    '
    'lblTitulo
    '
    Me.lblTitulo.AutoSize = True
    Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblTitulo.Location = New System.Drawing.Point(64, 10)
    Me.lblTitulo.Name = "lblTitulo"
    Me.lblTitulo.Size = New System.Drawing.Size(235, 24)
    Me.lblTitulo.TabIndex = 126
    Me.lblTitulo.Text = "Itens da Característica"
    '
    'lblSubTitulo
    '
    Me.lblSubTitulo.AutoSize = True
    Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblSubTitulo.Location = New System.Drawing.Point(64, 34)
    Me.lblSubTitulo.Name = "lblSubTitulo"
    Me.lblSubTitulo.Size = New System.Drawing.Size(67, 14)
    Me.lblSubTitulo.TabIndex = 127
    Me.lblSubTitulo.Text = "CADASTRO"
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
    Me.btoSair.Location = New System.Drawing.Point(580, 4)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(124, 72)
    Me.btoSair.TabIndex = 123
    Me.btoSair.TabStop = False
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSair.UseVisualStyleBackColor = False
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.tipo_de_produto
    Me.imgLogo.Location = New System.Drawing.Point(8, 10)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 125
    Me.imgLogo.TabStop = False
    '
    'dgvItem
    '
    Me.dgvItem.AllowUserToAddRows = False
    Me.dgvItem.AllowUserToDeleteRows = False
    Me.dgvItem.AllowUserToOrderColumns = True
    Me.dgvItem.AllowUserToResizeColumns = False
    Me.dgvItem.AllowUserToResizeRows = False
    Me.dgvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
    Me.dgvItem.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvItem.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.dgvItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    Me.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgvItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvItem.Location = New System.Drawing.Point(8, 148)
    Me.dgvItem.Name = "dgvItem"
    Me.dgvItem.ReadOnly = True
    Me.dgvItem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    Me.dgvItem.RowHeadersVisible = False
    Me.dgvItem.Size = New System.Drawing.Size(560, 208)
    Me.dgvItem.TabIndex = 4
    '
    'txtItem
    '
    Me.txtItem.BackColor = System.Drawing.Color.White
    Me.txtItem.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtItem.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtItem.ForeColor = System.Drawing.Color.Black
    Me.txtItem.Location = New System.Drawing.Point(84, 120)
    Me.txtItem.MaxLength = 30
    Me.txtItem.Name = "txtItem"
    Me.txtItem.Size = New System.Drawing.Size(348, 18)
    Me.txtItem.TabIndex = 3
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label1.ForeColor = System.Drawing.Color.Black
    Me.Label1.Location = New System.Drawing.Point(40, 120)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(38, 18)
    Me.Label1.TabIndex = 133
    Me.Label1.Text = "Item"
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
    Me.btoIncluirItem.Location = New System.Drawing.Point(440, 92)
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
    Me.Label4.Location = New System.Drawing.Point(464, 124)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(98, 14)
    Me.Label4.TabIndex = 203
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
    Me.btoExcluirItem.Location = New System.Drawing.Point(440, 120)
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
    Me.Label2.Location = New System.Drawing.Point(464, 96)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(96, 14)
    Me.Label2.TabIndex = 202
    Me.Label2.Text = "Incluir Item <F1>"
    '
    'btoCaracteristica
    '
    Me.btoCaracteristica.BackColor = System.Drawing.Color.Transparent
    Me.btoCaracteristica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoCaracteristica.FlatAppearance.BorderSize = 0
    Me.btoCaracteristica.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoCaracteristica.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoCaracteristica.ForeColor = System.Drawing.Color.Black
    Me.btoCaracteristica.Image = Global.nascomercio.My.Resources.Resources.caracteristicas_produtos
    Me.btoCaracteristica.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoCaracteristica.Location = New System.Drawing.Point(576, 80)
    Me.btoCaracteristica.Name = "btoCaracteristica"
    Me.btoCaracteristica.Size = New System.Drawing.Size(128, 75)
    Me.btoCaracteristica.TabIndex = 204
    Me.btoCaracteristica.TabStop = False
    Me.btoCaracteristica.Text = "Caracteristicas <F5>"
    Me.btoCaracteristica.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoCaracteristica.UseVisualStyleBackColor = False
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(708, 362)
    Me.Panel1.TabIndex = 205
    '
    'fCaracteristicaItemForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(708, 362)
    Me.Controls.Add(Me.btoCaracteristica)
    Me.Controls.Add(Me.btoIncluirItem)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.btoExcluirItem)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.txtItem)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.dgvItem)
    Me.Controls.Add(Me.lblCodigo)
    Me.Controls.Add(Me.txtCodigo)
    Me.Controls.Add(Me.txtNome)
    Me.Controls.Add(Me.lblNome)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fCaracteristicaItemForm"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "CaracteristicaItem"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lblCodigo As System.Windows.Forms.Label
  Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
  Friend WithEvents txtNome As System.Windows.Forms.TextBox
  Friend WithEvents lblNome As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents dgvItem As System.Windows.Forms.DataGridView
  Friend WithEvents txtItem As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents btoIncluirItem As System.Windows.Forms.Button
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents btoExcluirItem As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents btoCaracteristica As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
