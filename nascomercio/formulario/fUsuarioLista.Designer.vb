<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fUsuarioLista
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
    Me.components = New System.ComponentModel.Container
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.btoSair = New System.Windows.Forms.Button
    Me.btoFiltro = New System.Windows.Forms.Button
    Me.btoCadastro = New System.Windows.Forms.Button
    Me.dgvUsuario = New System.Windows.Forms.DataGridView
    Me.cid = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.usuario = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.situacao = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.dgvUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
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
    Me.btoSair.Location = New System.Drawing.Point(680, 4)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(88, 72)
    Me.btoSair.TabIndex = 81
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoSair, "Sair")
    Me.btoSair.UseVisualStyleBackColor = False
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
    Me.btoFiltro.Location = New System.Drawing.Point(344, 404)
    Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
    Me.btoFiltro.Name = "btoFiltro"
    Me.btoFiltro.Size = New System.Drawing.Size(120, 74)
    Me.btoFiltro.TabIndex = 82
    Me.btoFiltro.Text = "Selecionar <Enter>"
    Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoFiltro, "Filtro")
    Me.btoFiltro.UseVisualStyleBackColor = False
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
    Me.btoCadastro.Location = New System.Drawing.Point(680, 80)
    Me.btoCadastro.Name = "btoCadastro"
    Me.btoCadastro.Size = New System.Drawing.Size(88, 71)
    Me.btoCadastro.TabIndex = 88
    Me.btoCadastro.Text = "Incluir <F5>"
    Me.btoCadastro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.ToolTip1.SetToolTip(Me.btoCadastro, "Cadastro")
    Me.btoCadastro.UseVisualStyleBackColor = False
    '
    'dgvUsuario
    '
    Me.dgvUsuario.AllowUserToAddRows = False
    Me.dgvUsuario.AllowUserToDeleteRows = False
    Me.dgvUsuario.AllowUserToOrderColumns = True
    Me.dgvUsuario.AllowUserToResizeColumns = False
    Me.dgvUsuario.AllowUserToResizeRows = False
    Me.dgvUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
    Me.dgvUsuario.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.dgvUsuario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dgvUsuario.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgvUsuario.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cid, Me.usuario, Me.Nome, Me.situacao})
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.dgvUsuario.DefaultCellStyle = DataGridViewCellStyle2
    Me.dgvUsuario.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvUsuario.Location = New System.Drawing.Point(8, 68)
    Me.dgvUsuario.Name = "dgvUsuario"
    Me.dgvUsuario.ReadOnly = True
    Me.dgvUsuario.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    Me.dgvUsuario.RowHeadersVisible = False
    Me.dgvUsuario.Size = New System.Drawing.Size(644, 315)
    Me.dgvUsuario.TabIndex = 80
    '
    'cid
    '
    Me.cid.HeaderText = "CID"
    Me.cid.Name = "cid"
    Me.cid.ReadOnly = True
    '
    'usuario
    '
    Me.usuario.HeaderText = "Usuário"
    Me.usuario.Name = "usuario"
    Me.usuario.ReadOnly = True
    '
    'Nome
    '
    Me.Nome.HeaderText = "Nome"
    Me.Nome.Name = "Nome"
    Me.Nome.ReadOnly = True
    '
    'situacao
    '
    Me.situacao.HeaderText = "Situação"
    Me.situacao.Name = "situacao"
    Me.situacao.ReadOnly = True
    '
    'lblSubTitulo
    '
    Me.lblSubTitulo.AutoSize = True
    Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblSubTitulo.Location = New System.Drawing.Point(64, 32)
    Me.lblSubTitulo.Name = "lblSubTitulo"
    Me.lblSubTitulo.Size = New System.Drawing.Size(39, 14)
    Me.lblSubTitulo.TabIndex = 79
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
    Me.lblTitulo.Size = New System.Drawing.Size(99, 24)
    Me.lblTitulo.TabIndex = 77
    Me.lblTitulo.Text = "Usuários"
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.usuario
    Me.imgLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 78
    Me.imgLogo.TabStop = False
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(771, 484)
    Me.Panel1.TabIndex = 89
    '
    'fUsuarioLista
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(771, 484)
    Me.Controls.Add(Me.btoCadastro)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.btoFiltro)
    Me.Controls.Add(Me.dgvUsuario)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fUsuarioLista"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Usuários"
    CType(Me.dgvUsuario, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents btoFiltro As System.Windows.Forms.Button
  Friend WithEvents dgvUsuario As System.Windows.Forms.DataGridView
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents btoCadastro As System.Windows.Forms.Button
  Friend WithEvents cid As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents usuario As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Nome As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents situacao As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
