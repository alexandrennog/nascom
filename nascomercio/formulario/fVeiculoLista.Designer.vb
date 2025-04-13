<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fVeiculoLista
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
        Me.dgvVeiculos = New System.Windows.Forms.DataGridView
        Me.Placa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Marca = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Modelo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ano = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Combustivel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.imgCliLogo = New System.Windows.Forms.PictureBox
        Me.btoSair = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
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
        Me.lblCliSubTitulo.Size = New System.Drawing.Size(38, 14)
        Me.lblCliSubTitulo.TabIndex = 224
        Me.lblCliSubTitulo.Text = "LISTA"
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
        Me.dgvVeiculos.Location = New System.Drawing.Point(55, 100)
        Me.dgvVeiculos.Name = "dgvVeiculos"
        Me.dgvVeiculos.ReadOnly = True
        Me.dgvVeiculos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvVeiculos.RowHeadersVisible = False
        Me.dgvVeiculos.Size = New System.Drawing.Size(650, 264)
        Me.dgvVeiculos.TabIndex = 5
        '
        'Placa
        '
        Me.Placa.HeaderText = "Placa"
        Me.Placa.Name = "Placa"
        Me.Placa.ReadOnly = True
        Me.Placa.Width = 71
        '
        'Marca
        '
        Me.Marca.HeaderText = "Marca"
        Me.Marca.Name = "Marca"
        Me.Marca.ReadOnly = True
        Me.Marca.Width = 76
        '
        'Modelo
        '
        Me.Modelo.HeaderText = "Modelo"
        Me.Modelo.Name = "Modelo"
        Me.Modelo.ReadOnly = True
        Me.Modelo.Width = 86
        '
        'Cor
        '
        Me.Cor.HeaderText = "Cor"
        Me.Cor.Name = "Cor"
        Me.Cor.ReadOnly = True
        Me.Cor.Width = 59
        '
        'Ano
        '
        Me.Ano.HeaderText = "Ano"
        Me.Ano.Name = "Ano"
        Me.Ano.ReadOnly = True
        Me.Ano.Width = 60
        '
        'Combustivel
        '
        Me.Combustivel.HeaderText = "Combustivel"
        Me.Combustivel.Name = "Combustivel"
        Me.Combustivel.ReadOnly = True
        Me.Combustivel.Width = 122
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
        Me.btoSair.Location = New System.Drawing.Point(655, 12)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(112, 70)
        Me.btoSair.TabIndex = 8
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dgvVeiculos)
        Me.Panel1.Controls.Add(Me.btoSair)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(772, 432)
        Me.Panel1.TabIndex = 293
        '
        'fVeiculoLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(772, 432)
        Me.Controls.Add(Me.lblCliCadastro)
        Me.Controls.Add(Me.lblCliSubTitulo)
        Me.Controls.Add(Me.imgCliLogo)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "fVeiculoLista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes - Financeiro"
        CType(Me.dgvVeiculos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCliCadastro As System.Windows.Forms.Label
    Friend WithEvents lblCliSubTitulo As System.Windows.Forms.Label
    Friend WithEvents imgCliLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents dgvVeiculos As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Placa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Marca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Modelo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ano As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Combustivel As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
