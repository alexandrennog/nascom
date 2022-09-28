<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fRelatorioGrade
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fRelatorioGrade))
        Me.lblSubTitulo = New System.Windows.Forms.Label
        Me.btoFiltro = New System.Windows.Forms.Button
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.imgLogo = New System.Windows.Forms.PictureBox
        Me.btoSair = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFornecedor = New System.Windows.Forms.ComboBox
        Me.cboFabricante = New System.Windows.Forms.ComboBox
        Me.btoImprimir = New System.Windows.Forms.Button
        Me.rtbGrade = New System.Windows.Forms.RichTextBox
        Me.cboGrupo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkOrdem = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.pbGrade = New System.Windows.Forms.ProgressBar
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSubTitulo.Location = New System.Drawing.Point(68, 36)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(39, 14)
        Me.lblSubTitulo.TabIndex = 215
        Me.lblSubTitulo.Text = "LISTA"
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
        Me.btoFiltro.Location = New System.Drawing.Point(814, 12)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(71, 84)
        Me.btoFiltro.TabIndex = 7
        Me.btoFiltro.Text = "Pesquisar [F5]"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(68, 12)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(71, 24)
        Me.lblTitulo.TabIndex = 213
        Me.lblTitulo.Text = "Grade"
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.relatorio
        Me.imgLogo.Location = New System.Drawing.Point(12, 12)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 214
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
        Me.btoSair.Location = New System.Drawing.Point(888, 12)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(54, 84)
        Me.btoSair.TabIndex = 8
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(23, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 18)
        Me.Label2.TabIndex = 224
        Me.Label2.Text = "Fabricante:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(15, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 18)
        Me.Label3.TabIndex = 226
        Me.Label3.Text = "Fornecedor:"
        '
        'cboFornecedor
        '
        Me.cboFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFornecedor.FormattingEnabled = True
        Me.cboFornecedor.Location = New System.Drawing.Point(116, 75)
        Me.cboFornecedor.Name = "cboFornecedor"
        Me.cboFornecedor.Size = New System.Drawing.Size(288, 21)
        Me.cboFornecedor.TabIndex = 1
        '
        'cboFabricante
        '
        Me.cboFabricante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFabricante.FormattingEnabled = True
        Me.cboFabricante.Location = New System.Drawing.Point(116, 99)
        Me.cboFabricante.Name = "cboFabricante"
        Me.cboFabricante.Size = New System.Drawing.Size(212, 21)
        Me.cboFabricante.TabIndex = 2
        '
        'btoImprimir
        '
        Me.btoImprimir.BackColor = System.Drawing.Color.Transparent
        Me.btoImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoImprimir.FlatAppearance.BorderSize = 0
        Me.btoImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoImprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoImprimir.ForeColor = System.Drawing.Color.Black
        Me.btoImprimir.Image = Global.nascomercio.My.Resources.Resources.print_design
        Me.btoImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoImprimir.Location = New System.Drawing.Point(743, 12)
        Me.btoImprimir.Margin = New System.Windows.Forms.Padding(0)
        Me.btoImprimir.Name = "btoImprimir"
        Me.btoImprimir.Size = New System.Drawing.Size(71, 84)
        Me.btoImprimir.TabIndex = 6
        Me.btoImprimir.Text = "Imprimir [F8]"
        Me.btoImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoImprimir.UseVisualStyleBackColor = False
        '
        'rtbGrade
        '
        Me.rtbGrade.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbGrade.DetectUrls = False
        Me.rtbGrade.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbGrade.Location = New System.Drawing.Point(12, 126)
        Me.rtbGrade.Name = "rtbGrade"
        Me.rtbGrade.Size = New System.Drawing.Size(930, 453)
        Me.rtbGrade.TabIndex = 5
        Me.rtbGrade.Text = ""
        Me.rtbGrade.WordWrap = False
        '
        'cboGrupo
        '
        Me.cboGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(473, 75)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(218, 21)
        Me.cboGrupo.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(410, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 18)
        Me.Label1.TabIndex = 238
        Me.Label1.Text = "Grupo:"
        '
        'chkOrdem
        '
        Me.chkOrdem.AutoSize = True
        Me.chkOrdem.Location = New System.Drawing.Point(473, 102)
        Me.chkOrdem.Name = "chkOrdem"
        Me.chkOrdem.Size = New System.Drawing.Size(15, 14)
        Me.chkOrdem.TabIndex = 4
        Me.chkOrdem.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(334, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 18)
        Me.Label4.TabIndex = 241
        Me.Label4.Text = "Ordem Alfabética:"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDocument1
        '
        Me.PrintDocument1.DocumentName = "Relatorio"
        '
        'pbGrade
        '
        Me.pbGrade.Location = New System.Drawing.Point(12, 582)
        Me.pbGrade.Name = "pbGrade"
        Me.pbGrade.Size = New System.Drawing.Size(930, 8)
        Me.pbGrade.TabIndex = 242
        Me.pbGrade.Visible = False
        '
        'fRelatorioGrade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(954, 596)
        Me.Controls.Add(Me.pbGrade)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkOrdem)
        Me.Controls.Add(Me.cboGrupo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rtbGrade)
        Me.Controls.Add(Me.btoImprimir)
        Me.Controls.Add(Me.cboFabricante)
        Me.Controls.Add(Me.cboFornecedor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.btoFiltro)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.btoSair)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fRelatorioGrade"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fRelatorioGrade"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents btoFiltro As System.Windows.Forms.Button
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents cboFornecedor As System.Windows.Forms.ComboBox
  Friend WithEvents cboFabricante As System.Windows.Forms.ComboBox
  Friend WithEvents btoImprimir As System.Windows.Forms.Button
  Friend WithEvents rtbGrade As System.Windows.Forms.RichTextBox
  Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents chkOrdem As System.Windows.Forms.CheckBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Private WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
  Private WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
  Friend WithEvents pbGrade As System.Windows.Forms.ProgressBar
End Class
