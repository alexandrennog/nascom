<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fRelatorioVendasABC
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
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
        Me.lstPix = New System.Windows.Forms.ListView()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btoExport = New System.Windows.Forms.Button()
        Me.SaveFileVendas = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdQtde = New System.Windows.Forms.RadioButton()
        Me.rdValor = New System.Windows.Forms.RadioButton()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.lblTitulo.Size = New System.Drawing.Size(248, 24)
        Me.lblTitulo.TabIndex = 136
        Me.lblTitulo.Text = "Relatório de Curva ABC"
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
        Me.btoFiltro.Location = New System.Drawing.Point(640, 12)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(72, 84)
        Me.btoFiltro.TabIndex = 139
        Me.btoFiltro.Text = "Pesquisar [F5]"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.relatorio
        Me.imgLogo.Location = New System.Drawing.Point(8, 10)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
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
        Me.btoSair.Location = New System.Drawing.Point(799, 12)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(57, 84)
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
        Me.txtDataInicial.Location = New System.Drawing.Point(161, 78)
        Me.txtDataInicial.Mask = "00/00/0000"
        Me.txtDataInicial.Name = "txtDataInicial"
        Me.txtDataInicial.Size = New System.Drawing.Size(85, 18)
        Me.txtDataInicial.TabIndex = 205
        Me.txtDataInicial.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(65, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 18)
        Me.Label4.TabIndex = 204
        Me.Label4.Text = "Período: de"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDataFinal
        '
        Me.txtDataFinal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataFinal.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataFinal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataFinal.Location = New System.Drawing.Point(288, 78)
        Me.txtDataFinal.Mask = "00/00/0000"
        Me.txtDataFinal.Name = "txtDataFinal"
        Me.txtDataFinal.Size = New System.Drawing.Size(85, 18)
        Me.txtDataFinal.TabIndex = 207
        Me.txtDataFinal.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(252, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 18)
        Me.Label1.TabIndex = 206
        Me.Label1.Text = "até"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstPix
        '
        Me.lstPix.HideSelection = False
        Me.lstPix.Location = New System.Drawing.Point(68, 140)
        Me.lstPix.Name = "lstPix"
        Me.lstPix.Size = New System.Drawing.Size(709, 295)
        Me.lstPix.TabIndex = 210
        Me.lstPix.UseCompatibleStateImageBehavior = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.Transparent
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.Black
        Me.btnPrint.Image = Global.nascomercio.My.Resources.Resources.print_design
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrint.Location = New System.Drawing.Point(724, 12)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 84)
        Me.btnPrint.TabIndex = 211
        Me.btnPrint.Text = "Imprimir [F8]"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btoExport
        '
        Me.btoExport.BackColor = System.Drawing.Color.Transparent
        Me.btoExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoExport.FlatAppearance.BorderSize = 0
        Me.btoExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoExport.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoExport.ForeColor = System.Drawing.Color.Black
        Me.btoExport.Image = Global.nascomercio.My.Resources.Resources.grade1
        Me.btoExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoExport.Location = New System.Drawing.Point(799, 112)
        Me.btoExport.Margin = New System.Windows.Forms.Padding(0)
        Me.btoExport.Name = "btoExport"
        Me.btoExport.Size = New System.Drawing.Size(72, 84)
        Me.btoExport.TabIndex = 212
        Me.btoExport.Text = "Exportar [F6]"
        Me.btoExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoExport.UseVisualStyleBackColor = False
        Me.btoExport.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdQtde)
        Me.GroupBox1.Controls.Add(Me.rdValor)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(388, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(232, 65)
        Me.GroupBox1.TabIndex = 213
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Curva por:"
        '
        'rdQtde
        '
        Me.rdQtde.AutoSize = True
        Me.rdQtde.Location = New System.Drawing.Point(133, 25)
        Me.rdQtde.Name = "rdQtde"
        Me.rdQtde.Size = New System.Drawing.Size(61, 22)
        Me.rdQtde.TabIndex = 1
        Me.rdQtde.Text = "Qtde"
        Me.rdQtde.UseVisualStyleBackColor = True
        '
        'rdValor
        '
        Me.rdValor.AutoSize = True
        Me.rdValor.Checked = True
        Me.rdValor.Location = New System.Drawing.Point(29, 25)
        Me.rdValor.Name = "rdValor"
        Me.rdValor.Size = New System.Drawing.Size(61, 22)
        Me.rdValor.TabIndex = 0
        Me.rdValor.TabStop = True
        Me.rdValor.Text = "Valor"
        Me.rdValor.UseVisualStyleBackColor = True
        '
        'fRelatorioVendasABC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(882, 474)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btoExport)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lstPix)
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
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fRelatorioVendasABC"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fFabricanteLista"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents lstPix As ListView
    Friend WithEvents btnPrint As Button
    Friend WithEvents btoExport As Button
    Friend WithEvents SaveFileVendas As SaveFileDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdQtde As RadioButton
    Friend WithEvents rdValor As RadioButton
End Class
