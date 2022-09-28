<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fGiroForm
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
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.txtQuantidade = New System.Windows.Forms.MaskedTextBox
    Me.txtCodigoBarras = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.txtProduto = New System.Windows.Forms.TextBox
    Me.lblProduto = New System.Windows.Forms.Label
    Me.btoSair = New System.Windows.Forms.Button
    Me.btoSalvar = New System.Windows.Forms.Button
    Me.lblQuantidade = New System.Windows.Forms.Label
    Me.txtDataInicio = New System.Windows.Forms.MaskedTextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.txtDataFim = New System.Windows.Forms.MaskedTextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtDias = New System.Windows.Forms.MaskedTextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.btoExcluir = New System.Windows.Forms.Button
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'lblSubTitulo
    '
    Me.lblSubTitulo.AutoSize = True
    Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblSubTitulo.Location = New System.Drawing.Point(64, 32)
    Me.lblSubTitulo.Name = "lblSubTitulo"
    Me.lblSubTitulo.Size = New System.Drawing.Size(67, 14)
    Me.lblSubTitulo.TabIndex = 128
    Me.lblSubTitulo.Text = "CADASTRO"
    '
    'lblTitulo
    '
    Me.lblTitulo.AutoSize = True
    Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblTitulo.Location = New System.Drawing.Point(64, 8)
    Me.lblTitulo.Name = "lblTitulo"
    Me.lblTitulo.Size = New System.Drawing.Size(182, 24)
    Me.lblTitulo.TabIndex = 126
    Me.lblTitulo.Text = "Giro de Produtos"
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.produtos
    Me.imgLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 127
    Me.imgLogo.TabStop = False
    '
    'txtQuantidade
    '
    Me.txtQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtQuantidade.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtQuantidade.Location = New System.Drawing.Point(110, 136)
    Me.txtQuantidade.Mask = "000"
    Me.txtQuantidade.Name = "txtQuantidade"
    Me.txtQuantidade.Size = New System.Drawing.Size(35, 18)
    Me.txtQuantidade.TabIndex = 3
    Me.txtQuantidade.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'txtCodigoBarras
    '
    Me.txtCodigoBarras.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.txtCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCodigoBarras.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtCodigoBarras.Location = New System.Drawing.Point(110, 111)
    Me.txtCodigoBarras.MaxLength = 20
    Me.txtCodigoBarras.Name = "txtCodigoBarras"
    Me.txtCodigoBarras.ReadOnly = True
    Me.txtCodigoBarras.Size = New System.Drawing.Size(212, 18)
    Me.txtCodigoBarras.TabIndex = 2
    Me.txtCodigoBarras.TabStop = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label1.Location = New System.Drawing.Point(14, 111)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(92, 18)
    Me.Label1.TabIndex = 144
    Me.Label1.Text = "Cod. Barras"
    '
    'txtProduto
    '
    Me.txtProduto.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.txtProduto.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtProduto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtProduto.Location = New System.Drawing.Point(110, 87)
    Me.txtProduto.MaxLength = 20
    Me.txtProduto.Name = "txtProduto"
    Me.txtProduto.ReadOnly = True
    Me.txtProduto.Size = New System.Drawing.Size(212, 18)
    Me.txtProduto.TabIndex = 1
    Me.txtProduto.TabStop = False
    '
    'lblProduto
    '
    Me.lblProduto.AutoSize = True
    Me.lblProduto.BackColor = System.Drawing.Color.Transparent
    Me.lblProduto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblProduto.Location = New System.Drawing.Point(38, 87)
    Me.lblProduto.Name = "lblProduto"
    Me.lblProduto.Size = New System.Drawing.Size(65, 18)
    Me.lblProduto.TabIndex = 142
    Me.lblProduto.Text = "Produto"
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
    Me.btoSair.Location = New System.Drawing.Point(251, 235)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(88, 72)
    Me.btoSair.TabIndex = 9
    Me.btoSair.TabStop = False
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSair.UseVisualStyleBackColor = False
    '
    'btoSalvar
    '
    Me.btoSalvar.BackColor = System.Drawing.Color.Transparent
    Me.btoSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoSalvar.FlatAppearance.BorderSize = 0
    Me.btoSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoSalvar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoSalvar.ForeColor = System.Drawing.Color.Black
    Me.btoSalvar.Image = Global.nascomercio.My.Resources.Resources.confirmar
    Me.btoSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoSalvar.Location = New System.Drawing.Point(15, 235)
    Me.btoSalvar.Name = "btoSalvar"
    Me.btoSalvar.Size = New System.Drawing.Size(108, 72)
    Me.btoSalvar.TabIndex = 7
    Me.btoSalvar.TabStop = False
    Me.btoSalvar.Text = "Salvar <Enter>"
    Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSalvar.UseVisualStyleBackColor = False
    '
    'lblQuantidade
    '
    Me.lblQuantidade.AutoSize = True
    Me.lblQuantidade.BackColor = System.Drawing.Color.Transparent
    Me.lblQuantidade.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblQuantidade.Location = New System.Drawing.Point(14, 136)
    Me.lblQuantidade.Name = "lblQuantidade"
    Me.lblQuantidade.Size = New System.Drawing.Size(90, 18)
    Me.lblQuantidade.TabIndex = 138
    Me.lblQuantidade.Text = "Quantidade"
    '
    'txtDataInicio
    '
    Me.txtDataInicio.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDataInicio.Culture = New System.Globalization.CultureInfo("")
    Me.txtDataInicio.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtDataInicio.Location = New System.Drawing.Point(41, 187)
    Me.txtDataInicio.Mask = "00/00/0000"
    Me.txtDataInicio.Name = "txtDataInicio"
    Me.txtDataInicio.Size = New System.Drawing.Size(78, 18)
    Me.txtDataInicio.TabIndex = 4
    Me.txtDataInicio.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label4.Location = New System.Drawing.Point(40, 164)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(82, 18)
    Me.Label4.TabIndex = 146
    Me.Label4.Text = "Data Início"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'txtDataFim
    '
    Me.txtDataFim.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDataFim.Culture = New System.Globalization.CultureInfo("")
    Me.txtDataFim.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtDataFim.Location = New System.Drawing.Point(233, 187)
    Me.txtDataFim.Mask = "00/00/0000"
    Me.txtDataFim.Name = "txtDataFim"
    Me.txtDataFim.Size = New System.Drawing.Size(79, 18)
    Me.txtDataFim.TabIndex = 6
    Me.txtDataFim.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label2.Location = New System.Drawing.Point(237, 164)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(69, 18)
    Me.Label2.TabIndex = 148
    Me.Label2.Text = "Data Fim"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'txtDias
    '
    Me.txtDias.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDias.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtDias.Location = New System.Drawing.Point(157, 187)
    Me.txtDias.Mask = "000"
    Me.txtDias.Name = "txtDias"
    Me.txtDias.Size = New System.Drawing.Size(36, 18)
    Me.txtDias.TabIndex = 5
    Me.txtDias.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.BackColor = System.Drawing.Color.Transparent
    Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label3.Location = New System.Drawing.Point(156, 164)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(39, 18)
    Me.Label3.TabIndex = 150
    Me.Label3.Text = "Dias"
    '
    'btoExcluir
    '
    Me.btoExcluir.BackColor = System.Drawing.Color.Transparent
    Me.btoExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoExcluir.FlatAppearance.BorderSize = 0
    Me.btoExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoExcluir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoExcluir.ForeColor = System.Drawing.Color.Black
    Me.btoExcluir.Image = Global.nascomercio.My.Resources.Resources.excluir
    Me.btoExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoExcluir.Location = New System.Drawing.Point(130, 235)
    Me.btoExcluir.Name = "btoExcluir"
    Me.btoExcluir.Size = New System.Drawing.Size(108, 72)
    Me.btoExcluir.TabIndex = 8
    Me.btoExcluir.TabStop = False
    Me.btoExcluir.Text = "Excluir <F12>"
    Me.btoExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoExcluir.UseVisualStyleBackColor = False
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(359, 319)
    Me.Panel1.TabIndex = 151
    '
    'fGiroForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(359, 319)
    Me.Controls.Add(Me.btoExcluir)
    Me.Controls.Add(Me.txtDias)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.txtDataFim)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.txtDataInicio)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.txtQuantidade)
    Me.Controls.Add(Me.txtCodigoBarras)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtProduto)
    Me.Controls.Add(Me.lblProduto)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.btoSalvar)
    Me.Controls.Add(Me.lblQuantidade)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fGiroForm"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "fGiroForm"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents txtQuantidade As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtCodigoBarras As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtProduto As System.Windows.Forms.TextBox
  Friend WithEvents lblProduto As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents lblQuantidade As System.Windows.Forms.Label
  Friend WithEvents txtDataInicio As System.Windows.Forms.MaskedTextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtDataFim As System.Windows.Forms.MaskedTextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtDias As System.Windows.Forms.MaskedTextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents btoExcluir As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
