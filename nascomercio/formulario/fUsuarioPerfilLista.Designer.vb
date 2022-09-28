<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fUsuarioPerfilLista
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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.dgvUsuarioPerfil = New System.Windows.Forms.DataGridView
    Me.cid = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.situacao = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.btoCadastro = New System.Windows.Forms.Button
    Me.btoSair = New System.Windows.Forms.Button
    Me.btoFiltro = New System.Windows.Forms.Button
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.dgvUsuarioPerfil, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dgvUsuarioPerfil
    '
    Me.dgvUsuarioPerfil.AllowUserToAddRows = False
    Me.dgvUsuarioPerfil.AllowUserToDeleteRows = False
    Me.dgvUsuarioPerfil.AllowUserToOrderColumns = True
    Me.dgvUsuarioPerfil.AllowUserToResizeColumns = False
    Me.dgvUsuarioPerfil.AllowUserToResizeRows = False
    Me.dgvUsuarioPerfil.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
    Me.dgvUsuarioPerfil.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvUsuarioPerfil.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.dgvUsuarioPerfil.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dgvUsuarioPerfil.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dgvUsuarioPerfil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgvUsuarioPerfil.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cid, Me.Codigo, Me.Nome, Me.situacao})
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.dgvUsuarioPerfil.DefaultCellStyle = DataGridViewCellStyle2
    Me.dgvUsuarioPerfil.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvUsuarioPerfil.Location = New System.Drawing.Point(8, 68)
    Me.dgvUsuarioPerfil.Name = "dgvUsuarioPerfil"
    Me.dgvUsuarioPerfil.ReadOnly = True
    Me.dgvUsuarioPerfil.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dgvUsuarioPerfil.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
    Me.dgvUsuarioPerfil.RowHeadersVisible = False
    Me.dgvUsuarioPerfil.Size = New System.Drawing.Size(648, 273)
    Me.dgvUsuarioPerfil.TabIndex = 1
    '
    'cid
    '
    Me.cid.HeaderText = "CID"
    Me.cid.Name = "cid"
    Me.cid.ReadOnly = True
    '
    'Codigo
    '
    Me.Codigo.HeaderText = "Código"
    Me.Codigo.Name = "Codigo"
    Me.Codigo.ReadOnly = True
    '
    'Nome
    '
    Me.Nome.HeaderText = "Perfil"
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
    Me.lblTitulo.Size = New System.Drawing.Size(169, 24)
    Me.lblTitulo.TabIndex = 89
    Me.lblTitulo.Text = "Usuários - Perfil"
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
    Me.btoCadastro.Location = New System.Drawing.Point(672, 80)
    Me.btoCadastro.Name = "btoCadastro"
    Me.btoCadastro.Size = New System.Drawing.Size(87, 71)
    Me.btoCadastro.TabIndex = 5
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
    Me.btoSair.Location = New System.Drawing.Point(672, 4)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(87, 72)
    Me.btoSair.TabIndex = 4
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
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
    Me.btoFiltro.Location = New System.Drawing.Point(336, 368)
    Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
    Me.btoFiltro.Name = "btoFiltro"
    Me.btoFiltro.Size = New System.Drawing.Size(120, 72)
    Me.btoFiltro.TabIndex = 6
    Me.btoFiltro.Text = "Selecionar <Enter>"
    Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoFiltro.UseVisualStyleBackColor = False
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.perfio_usuario
    Me.imgLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 90
    Me.imgLogo.TabStop = False
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(763, 444)
    Me.Panel1.TabIndex = 92
    '
    'fUsuarioPerfilLista
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(763, 444)
    Me.Controls.Add(Me.btoCadastro)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.btoFiltro)
    Me.Controls.Add(Me.dgvUsuarioPerfil)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fUsuarioPerfilLista"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Usuários - Perfil"
    CType(Me.dgvUsuarioPerfil, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents btoCadastro As System.Windows.Forms.Button
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents btoFiltro As System.Windows.Forms.Button
  Friend WithEvents dgvUsuarioPerfil As System.Windows.Forms.DataGridView
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents cid As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Nome As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents situacao As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
