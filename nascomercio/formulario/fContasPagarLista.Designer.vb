<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fContasPagarLista
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.dgvContasPagar = New System.Windows.Forms.DataGridView()
        Me.btoSelecionar = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btoCadastro = New System.Windows.Forms.Button()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvContasPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSubTitulo.Location = New System.Drawing.Point(67, 33)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(38, 14)
        Me.lblSubTitulo.TabIndex = 145
        Me.lblSubTitulo.Text = "LISTA"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(67, 9)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(165, 24)
        Me.lblTitulo.TabIndex = 143
        Me.lblTitulo.Text = "Contas a Pagar"
        '
        'dgvContasPagar
        '
        Me.dgvContasPagar.AllowUserToAddRows = False
        Me.dgvContasPagar.AllowUserToDeleteRows = False
        Me.dgvContasPagar.AllowUserToOrderColumns = True
        Me.dgvContasPagar.AllowUserToResizeColumns = False
        Me.dgvContasPagar.AllowUserToResizeRows = False
        Me.dgvContasPagar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvContasPagar.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvContasPagar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvContasPagar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvContasPagar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvContasPagar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContasPagar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cid, Me.codigo, Me.valor, Me.data})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvContasPagar.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvContasPagar.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvContasPagar.Location = New System.Drawing.Point(11, 69)
        Me.dgvContasPagar.Name = "dgvContasPagar"
        Me.dgvContasPagar.ReadOnly = True
        Me.dgvContasPagar.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvContasPagar.RowHeadersVisible = False
        Me.dgvContasPagar.Size = New System.Drawing.Size(640, 274)
        Me.dgvContasPagar.TabIndex = 1
        '
        'btoSelecionar
        '
        Me.btoSelecionar.BackColor = System.Drawing.Color.Transparent
        Me.btoSelecionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoSelecionar.FlatAppearance.BorderSize = 0
        Me.btoSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoSelecionar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoSelecionar.ForeColor = System.Drawing.Color.Black
        Me.btoSelecionar.Image = Global.nascomercio.My.Resources.Resources.pesquisar
        Me.btoSelecionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoSelecionar.Location = New System.Drawing.Point(331, 379)
        Me.btoSelecionar.Margin = New System.Windows.Forms.Padding(0)
        Me.btoSelecionar.Name = "btoSelecionar"
        Me.btoSelecionar.Size = New System.Drawing.Size(120, 72)
        Me.btoSelecionar.TabIndex = 2
        Me.btoSelecionar.Text = "Selecionar <Enter>"
        Me.btoSelecionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSelecionar.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.cifrao_peq
        Me.imgLogo.Location = New System.Drawing.Point(11, 9)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 144
        Me.imgLogo.TabStop = False
        '
        'btoCadastro
        '
        Me.btoCadastro.BackColor = System.Drawing.Color.Transparent
        Me.btoCadastro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoCadastro.FlatAppearance.BorderSize = 0
        Me.btoCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoCadastro.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoCadastro.ForeColor = System.Drawing.Color.Black
        Me.btoCadastro.Image = Global.nascomercio.My.Resources.Resources.incluir
        Me.btoCadastro.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoCadastro.Location = New System.Drawing.Point(671, 83)
        Me.btoCadastro.Name = "btoCadastro"
        Me.btoCadastro.Size = New System.Drawing.Size(88, 72)
        Me.btoCadastro.TabIndex = 4
        Me.btoCadastro.Text = "Incluir <F5>"
        Me.btoCadastro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoCadastro.UseVisualStyleBackColor = False
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
        Me.btoSair.Location = New System.Drawing.Point(671, 7)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(88, 72)
        Me.btoSair.TabIndex = 3
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(770, 461)
        Me.Panel1.TabIndex = 171
        '
        'cid
        '
        Me.cid.HeaderText = "CID"
        Me.cid.Name = "cid"
        Me.cid.ReadOnly = True
        Me.cid.Width = 55
        '
        'codigo
        '
        Me.codigo.FillWeight = 120.0!
        Me.codigo.HeaderText = "Descrição"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Width = 95
        '
        'valor
        '
        Me.valor.HeaderText = "Valor"
        Me.valor.Name = "valor"
        Me.valor.ReadOnly = True
        Me.valor.Width = 66
        '
        'data
        '
        Me.data.HeaderText = "Data"
        Me.data.Name = "data"
        Me.data.ReadOnly = True
        Me.data.Width = 62
        '
        'fContasPagarLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(770, 461)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.btoSelecionar)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.dgvContasPagar)
        Me.Controls.Add(Me.btoCadastro)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fContasPagarLista"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fContasPagarLista"
        CType(Me.dgvContasPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents btoSelecionar As System.Windows.Forms.Button
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents dgvContasPagar As System.Windows.Forms.DataGridView
  Friend WithEvents btoCadastro As System.Windows.Forms.Button
  Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
