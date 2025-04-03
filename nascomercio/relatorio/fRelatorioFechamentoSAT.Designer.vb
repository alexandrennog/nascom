<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fRelatorioFechamentoSAT
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
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btoFiltro = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.txtDataInicial = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDataFinal = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCaixa = New System.Windows.Forms.TextBox()
        Me.lblProduto = New System.Windows.Forms.Label()
        Me.rtbGrade = New System.Windows.Forms.RichTextBox()
        Me.btoImprimir = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSubTitulo.Location = New System.Drawing.Point(85, 42)
        Me.lblSubTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(44, 16)
        Me.lblSubTitulo.TabIndex = 138
        Me.lblSubTitulo.Text = "LISTA"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(85, 12)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(431, 32)
        Me.lblTitulo.TabIndex = 136
        Me.lblTitulo.Text = "Relatório de Fechamento Fiscal"
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
        Me.btoFiltro.Location = New System.Drawing.Point(1156, 20)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(96, 103)
        Me.btoFiltro.TabIndex = 139
        Me.btoFiltro.Text = "Pesquisar [F5]"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.relatorio
        Me.imgLogo.Location = New System.Drawing.Point(11, 12)
        Me.imgLogo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(67, 62)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 137
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
        Me.btoSair.Location = New System.Drawing.Point(1256, 20)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(76, 103)
        Me.btoSair.TabIndex = 134
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'txtDataInicial
        '
        Me.txtDataInicial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataInicial.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataInicial.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataInicial.Location = New System.Drawing.Point(215, 96)
        Me.txtDataInicial.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDataInicial.Mask = "00/00/0000"
        Me.txtDataInicial.Name = "txtDataInicial"
        Me.txtDataInicial.Size = New System.Drawing.Size(113, 22)
        Me.txtDataInicial.TabIndex = 205
        Me.txtDataInicial.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(87, 96)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 22)
        Me.Label4.TabIndex = 204
        Me.Label4.Text = "Período: de"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDataFinal
        '
        Me.txtDataFinal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataFinal.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataFinal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataFinal.Location = New System.Drawing.Point(384, 96)
        Me.txtDataFinal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDataFinal.Mask = "00/00/0000"
        Me.txtDataFinal.Name = "txtDataFinal"
        Me.txtDataFinal.Size = New System.Drawing.Size(113, 22)
        Me.txtDataFinal.TabIndex = 207
        Me.txtDataFinal.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(336, 96)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 22)
        Me.Label1.TabIndex = 206
        Me.Label1.Text = "até"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCaixa
        '
        Me.txtCaixa.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCaixa.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCaixa.Location = New System.Drawing.Point(648, 96)
        Me.txtCaixa.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCaixa.MaxLength = 20
        Me.txtCaixa.Name = "txtCaixa"
        Me.txtCaixa.Size = New System.Drawing.Size(283, 22)
        Me.txtCaixa.TabIndex = 208
        Me.txtCaixa.Text = "Caixa 01"
        '
        'lblProduto
        '
        Me.lblProduto.AutoSize = True
        Me.lblProduto.BackColor = System.Drawing.Color.Transparent
        Me.lblProduto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblProduto.Location = New System.Drawing.Point(572, 96)
        Me.lblProduto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProduto.Name = "lblProduto"
        Me.lblProduto.Size = New System.Drawing.Size(69, 22)
        Me.lblProduto.TabIndex = 209
        Me.lblProduto.Text = "Caixa:"
        '
        'rtbGrade
        '
        Me.rtbGrade.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbGrade.DetectUrls = False
        Me.rtbGrade.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbGrade.Location = New System.Drawing.Point(60, 126)
        Me.rtbGrade.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rtbGrade.Name = "rtbGrade"
        Me.rtbGrade.Size = New System.Drawing.Size(1240, 558)
        Me.rtbGrade.TabIndex = 210
        Me.rtbGrade.Text = ""
        Me.rtbGrade.WordWrap = False
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
        Me.btoImprimir.Location = New System.Drawing.Point(1061, 20)
        Me.btoImprimir.Margin = New System.Windows.Forms.Padding(0)
        Me.btoImprimir.Name = "btoImprimir"
        Me.btoImprimir.Size = New System.Drawing.Size(95, 103)
        Me.btoImprimir.TabIndex = 211
        Me.btoImprimir.Text = "Imprimir [F8]"
        Me.btoImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoImprimir.UseVisualStyleBackColor = False
        '
        'PrintDocument1
        '
        '
        'fRelatorioFechamentoSAT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1355, 736)
        Me.Controls.Add(Me.btoImprimir)
        Me.Controls.Add(Me.rtbGrade)
        Me.Controls.Add(Me.txtCaixa)
        Me.Controls.Add(Me.lblProduto)
        Me.Controls.Add(Me.txtDataFinal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDataInicial)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.btoFiltro)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.btoSair)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fRelatorioFechamentoSAT"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fFabricanteLista"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents btoFiltro As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents txtDataInicial As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDataFinal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCaixa As System.Windows.Forms.TextBox
    Friend WithEvents lblProduto As System.Windows.Forms.Label
    Friend WithEvents rtbGrade As System.Windows.Forms.RichTextBox
    Friend WithEvents btoImprimir As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
