<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProdutoBalancoForm
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
        Me.dgvProduto = New System.Windows.Forms.DataGridView
        Me.btoAtualizar = New System.Windows.Forms.Button
        Me.btoSair = New System.Windows.Forms.Button
        Me.lblSubTitulo = New System.Windows.Forms.Label
        Me.imgLogo = New System.Windows.Forms.PictureBox
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.btoFiltro = New System.Windows.Forms.Button
        Me.btoTransferencia = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnExportar = New System.Windows.Forms.Button
        Me.btnImportar = New System.Windows.Forms.Button
        Me.barra = New System.Windows.Forms.ProgressBar
        CType(Me.dgvProduto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvProduto
        '
        Me.dgvProduto.AllowUserToAddRows = False
        Me.dgvProduto.AllowUserToDeleteRows = False
        Me.dgvProduto.AllowUserToOrderColumns = True
        Me.dgvProduto.AllowUserToResizeColumns = False
        Me.dgvProduto.AllowUserToResizeRows = False
        Me.dgvProduto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvProduto.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvProduto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvProduto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProduto.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProduto.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvProduto.Location = New System.Drawing.Point(12, 91)
        Me.dgvProduto.Name = "dgvProduto"
        Me.dgvProduto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvProduto.RowHeadersVisible = False
        Me.dgvProduto.Size = New System.Drawing.Size(840, 340)
        Me.dgvProduto.TabIndex = 204
        '
        'btoAtualizar
        '
        Me.btoAtualizar.BackColor = System.Drawing.Color.Transparent
        Me.btoAtualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoAtualizar.FlatAppearance.BorderSize = 0
        Me.btoAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoAtualizar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoAtualizar.ForeColor = System.Drawing.Color.Black
        Me.btoAtualizar.Image = Global.nascomercio.My.Resources.Resources.confirmar
        Me.btoAtualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoAtualizar.Location = New System.Drawing.Point(498, 451)
        Me.btoAtualizar.Name = "btoAtualizar"
        Me.btoAtualizar.Size = New System.Drawing.Size(114, 72)
        Me.btoAtualizar.TabIndex = 205
        Me.btoAtualizar.TabStop = False
        Me.btoAtualizar.Text = "Atualizar <Enter>"
        Me.btoAtualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoAtualizar.UseVisualStyleBackColor = False
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
        Me.btoSair.Location = New System.Drawing.Point(620, 451)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(88, 72)
        Me.btoSair.TabIndex = 207
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <ESC>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSubTitulo.Location = New System.Drawing.Point(62, 32)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(67, 14)
        Me.lblSubTitulo.TabIndex = 216
        Me.lblSubTitulo.Text = "CADASTRO"
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.produtos
        Me.imgLogo.Location = New System.Drawing.Point(6, 8)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 215
        Me.imgLogo.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(62, 8)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(222, 24)
        Me.lblTitulo.TabIndex = 214
        Me.lblTitulo.Text = "Balanço de Produtos"
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
        Me.btoFiltro.Location = New System.Drawing.Point(864, 12)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(88, 72)
        Me.btoFiltro.TabIndex = 217
        Me.btoFiltro.TabStop = False
        Me.btoFiltro.Text = "Filtro <F5>"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
        '
        'btoTransferencia
        '
        Me.btoTransferencia.BackColor = System.Drawing.Color.Transparent
        Me.btoTransferencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoTransferencia.FlatAppearance.BorderSize = 0
        Me.btoTransferencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoTransferencia.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoTransferencia.ForeColor = System.Drawing.Color.Black
        Me.btoTransferencia.Image = Global.nascomercio.My.Resources.Resources.entrada_saida_estoque
        Me.btoTransferencia.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoTransferencia.Location = New System.Drawing.Point(855, 83)
        Me.btoTransferencia.Margin = New System.Windows.Forms.Padding(0)
        Me.btoTransferencia.Name = "btoTransferencia"
        Me.btoTransferencia.Size = New System.Drawing.Size(100, 79)
        Me.btoTransferencia.TabIndex = 230
        Me.btoTransferencia.TabStop = False
        Me.btoTransferencia.Text = "Transferência /Estoque <F8>"
        Me.btoTransferencia.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoTransferencia.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.barra)
        Me.Panel1.Controls.Add(Me.btnImportar)
        Me.Panel1.Controls.Add(Me.btnExportar)
        Me.Panel1.Controls.Add(Me.btoAtualizar)
        Me.Panel1.Controls.Add(Me.btoSair)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(964, 530)
        Me.Panel1.TabIndex = 231
        '
        'btnExportar
        '
        Me.btnExportar.BackColor = System.Drawing.Color.Transparent
        Me.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportar.FlatAppearance.BorderSize = 0
        Me.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.ForeColor = System.Drawing.Color.Black
        Me.btnExportar.Image = Global.nascomercio.My.Resources.Resources.grade1
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExportar.Location = New System.Drawing.Point(254, 451)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(114, 72)
        Me.btnExportar.TabIndex = 206
        Me.btnExportar.TabStop = False
        Me.btnExportar.Text = "Exportar <F2>"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportar.UseVisualStyleBackColor = False
        '
        'btnImportar
        '
        Me.btnImportar.BackColor = System.Drawing.Color.Transparent
        Me.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnImportar.FlatAppearance.BorderSize = 0
        Me.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportar.ForeColor = System.Drawing.Color.Black
        Me.btnImportar.Image = Global.nascomercio.My.Resources.Resources.grade1
        Me.btnImportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImportar.Location = New System.Drawing.Point(376, 451)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(114, 72)
        Me.btnImportar.TabIndex = 207
        Me.btnImportar.TabStop = False
        Me.btnImportar.Text = "Importar <F3>"
        Me.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImportar.UseVisualStyleBackColor = False
        '
        'barra
        '
        Me.barra.Location = New System.Drawing.Point(11, 436)
        Me.barra.Name = "barra"
        Me.barra.Size = New System.Drawing.Size(840, 11)
        Me.barra.TabIndex = 208
        '
        'fProdutoBalancoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(964, 530)
        Me.Controls.Add(Me.btoTransferencia)
        Me.Controls.Add(Me.btoFiltro)
        Me.Controls.Add(Me.dgvProduto)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fProdutoBalancoForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fProdutoBalancoForm"
        CType(Me.dgvProduto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvProduto As System.Windows.Forms.DataGridView
    Friend WithEvents btoAtualizar As System.Windows.Forms.Button
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btoFiltro As System.Windows.Forms.Button
    Friend WithEvents btoTransferencia As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents barra As System.Windows.Forms.ProgressBar
End Class
