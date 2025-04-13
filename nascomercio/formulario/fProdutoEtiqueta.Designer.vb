<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProdutoEtiqueta
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
    Me.lblQuantidade = New System.Windows.Forms.Label
    Me.btoImprimir = New System.Windows.Forms.Button
    Me.btoSair = New System.Windows.Forms.Button
    Me.txtProduto = New System.Windows.Forms.TextBox
    Me.lblProduto = New System.Windows.Forms.Label
    Me.txtCodigoBarras = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.txtQuantidade = New System.Windows.Forms.MaskedTextBox
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
    Me.lblSubTitulo.Size = New System.Drawing.Size(70, 14)
    Me.lblSubTitulo.TabIndex = 128
    Me.lblSubTitulo.Text = "IMPRESSÃO"
    '
    'lblTitulo
    '
    Me.lblTitulo.AutoSize = True
    Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblTitulo.Location = New System.Drawing.Point(64, 8)
    Me.lblTitulo.Name = "lblTitulo"
    Me.lblTitulo.Size = New System.Drawing.Size(193, 24)
    Me.lblTitulo.TabIndex = 126
    Me.lblTitulo.Text = "Etiquetas Avulsas"
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.print_design
    Me.imgLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 127
    Me.imgLogo.TabStop = False
    '
    'lblQuantidade
    '
    Me.lblQuantidade.AutoSize = True
    Me.lblQuantidade.BackColor = System.Drawing.Color.Transparent
    Me.lblQuantidade.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblQuantidade.Location = New System.Drawing.Point(8, 140)
    Me.lblQuantidade.Name = "lblQuantidade"
    Me.lblQuantidade.Size = New System.Drawing.Size(90, 18)
    Me.lblQuantidade.TabIndex = 130
    Me.lblQuantidade.Text = "Quantidade"
    '
    'btoImprimir
    '
    Me.btoImprimir.BackColor = System.Drawing.Color.Transparent
    Me.btoImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoImprimir.FlatAppearance.BorderSize = 0
    Me.btoImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoImprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoImprimir.ForeColor = System.Drawing.Color.Black
    Me.btoImprimir.Image = Global.nascomercio.My.Resources.Resources.confirmar
    Me.btoImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoImprimir.Location = New System.Drawing.Point(200, 188)
    Me.btoImprimir.Name = "btoImprimir"
    Me.btoImprimir.Size = New System.Drawing.Size(108, 72)
    Me.btoImprimir.TabIndex = 131
    Me.btoImprimir.TabStop = False
    Me.btoImprimir.Text = "Imprimir <Enter>"
    Me.btoImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoImprimir.UseVisualStyleBackColor = False
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
    Me.btoSair.Location = New System.Drawing.Point(400, 4)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(88, 72)
    Me.btoSair.TabIndex = 132
    Me.btoSair.TabStop = False
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSair.UseVisualStyleBackColor = False
    '
    'txtProduto
    '
    Me.txtProduto.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.txtProduto.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtProduto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtProduto.Location = New System.Drawing.Point(104, 92)
    Me.txtProduto.MaxLength = 20
    Me.txtProduto.Name = "txtProduto"
    Me.txtProduto.ReadOnly = True
    Me.txtProduto.Size = New System.Drawing.Size(212, 18)
    Me.txtProduto.TabIndex = 133
    Me.txtProduto.TabStop = False
    '
    'lblProduto
    '
    Me.lblProduto.AutoSize = True
    Me.lblProduto.BackColor = System.Drawing.Color.Transparent
    Me.lblProduto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblProduto.Location = New System.Drawing.Point(32, 92)
    Me.lblProduto.Name = "lblProduto"
    Me.lblProduto.Size = New System.Drawing.Size(65, 18)
    Me.lblProduto.TabIndex = 134
    Me.lblProduto.Text = "Produto"
    '
    'txtCodigoBarras
    '
    Me.txtCodigoBarras.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.txtCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCodigoBarras.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtCodigoBarras.Location = New System.Drawing.Point(104, 116)
    Me.txtCodigoBarras.MaxLength = 20
    Me.txtCodigoBarras.Name = "txtCodigoBarras"
    Me.txtCodigoBarras.ReadOnly = True
    Me.txtCodigoBarras.Size = New System.Drawing.Size(212, 18)
    Me.txtCodigoBarras.TabIndex = 135
    Me.txtCodigoBarras.TabStop = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label1.Location = New System.Drawing.Point(8, 116)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(92, 18)
    Me.Label1.TabIndex = 136
    Me.Label1.Text = "Cod. Barras"
    '
    'txtQuantidade
    '
    Me.txtQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtQuantidade.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtQuantidade.Location = New System.Drawing.Point(104, 140)
    Me.txtQuantidade.Mask = "000"
    Me.txtQuantidade.Name = "txtQuantidade"
    Me.txtQuantidade.Size = New System.Drawing.Size(36, 18)
    Me.txtQuantidade.TabIndex = 1
    Me.txtQuantidade.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(489, 262)
    Me.Panel1.TabIndex = 137
    '
    'fProdutoEtiqueta
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(489, 262)
    Me.Controls.Add(Me.txtQuantidade)
    Me.Controls.Add(Me.txtCodigoBarras)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtProduto)
    Me.Controls.Add(Me.lblProduto)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.btoImprimir)
    Me.Controls.Add(Me.lblQuantidade)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fProdutoEtiqueta"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "ProdutoEtiqueta"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents lblQuantidade As System.Windows.Forms.Label
  Friend WithEvents btoImprimir As System.Windows.Forms.Button
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents txtProduto As System.Windows.Forms.TextBox
  Friend WithEvents lblProduto As System.Windows.Forms.Label
  Friend WithEvents txtCodigoBarras As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtQuantidade As System.Windows.Forms.MaskedTextBox
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
