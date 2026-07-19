<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fImpostoLista
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
        Me.dgvImposto = New System.Windows.Forms.DataGridView()
        Me.colRegraCid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCrt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipoOperacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAtivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btoCadastro = New System.Windows.Forms.Button()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.dgvImposto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.lblTitulo.Size = New System.Drawing.Size(104, 24)
        Me.lblTitulo.TabIndex = 136
        Me.lblTitulo.Text = "Impostos"
        '
        'dgvImposto
        '
        Me.dgvImposto.AllowUserToAddRows = False
        Me.dgvImposto.AllowUserToDeleteRows = False
        Me.dgvImposto.AllowUserToOrderColumns = True
        Me.dgvImposto.AllowUserToResizeColumns = False
        Me.dgvImposto.AllowUserToResizeRows = False
        Me.dgvImposto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvImposto.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvImposto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvImposto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvImposto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvImposto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvImposto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRegraCid, Me.colDescricao, Me.colCrt, Me.colTipoOperacao, Me.colAtivo})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvImposto.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvImposto.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvImposto.Location = New System.Drawing.Point(20, 65)
        Me.dgvImposto.Name = "dgvImposto"
        Me.dgvImposto.ReadOnly = True
        Me.dgvImposto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvImposto.RowHeadersVisible = False
        Me.dgvImposto.Size = New System.Drawing.Size(581, 270)
        Me.dgvImposto.TabIndex = 133
        '
        'colRegraCid
        '
        Me.colRegraCid.HeaderText = "CID"
        Me.colRegraCid.Name = "colRegraCid"
        Me.colRegraCid.ReadOnly = True
        Me.colRegraCid.Visible = False
        '
        'colDescricao
        '
        Me.colDescricao.HeaderText = "Descrição"
        Me.colDescricao.Name = "colDescricao"
        Me.colDescricao.ReadOnly = True
        Me.colDescricao.Width = 94
        '
        'colCrt
        '
        Me.colCrt.HeaderText = "CRT"
        Me.colCrt.Name = "colCrt"
        Me.colCrt.ReadOnly = True
        Me.colCrt.Width = 58
        '
        'colTipoOperacao
        '
        Me.colTipoOperacao.HeaderText = "Tipo Operação"
        Me.colTipoOperacao.Name = "colTipoOperacao"
        Me.colTipoOperacao.ReadOnly = True
        Me.colTipoOperacao.Width = 115
        '
        'colAtivo
        '
        Me.colAtivo.HeaderText = "Ativo"
        Me.colAtivo.Name = "colAtivo"
        Me.colAtivo.ReadOnly = True
        Me.colAtivo.Width = 64
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.balanco
        Me.imgLogo.Location = New System.Drawing.Point(8, 10)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 137
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
        Me.btoCadastro.Location = New System.Drawing.Point(608, 84)
        Me.btoCadastro.Name = "btoCadastro"
        Me.btoCadastro.Size = New System.Drawing.Size(88, 72)
        Me.btoCadastro.TabIndex = 135
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
        Me.btoSair.Location = New System.Drawing.Point(608, 8)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(88, 72)
        Me.btoSair.TabIndex = 134
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dgvImposto)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(705, 352)
        Me.Panel1.TabIndex = 140
        '
        'fImpostoLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(700, 350)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.btoCadastro)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fImpostoLista"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fImpostoLista"
        CType(Me.dgvImposto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents dgvImposto As System.Windows.Forms.DataGridView
  Friend WithEvents btoCadastro As System.Windows.Forms.Button
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents colRegraCid As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colDescricao As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colCrt As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colTipoOperacao As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colAtivo As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
