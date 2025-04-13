<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fGradeForm
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
    Me.btoSalvar = New System.Windows.Forms.Button
    Me.btoSair = New System.Windows.Forms.Button
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.gpbTipoGrade = New System.Windows.Forms.GroupBox
    Me.rdoTipoTexto = New System.Windows.Forms.RadioButton
    Me.rdoTipoNumero = New System.Windows.Forms.RadioButton
    Me.rdoTipoUnico = New System.Windows.Forms.RadioButton
    Me.gpbNumero = New System.Windows.Forms.GroupBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.txtAte = New System.Windows.Forms.MaskedTextBox
    Me.lblCodigo = New System.Windows.Forms.Label
    Me.txtDe = New System.Windows.Forms.MaskedTextBox
    Me.rdoNumeroImpar = New System.Windows.Forms.RadioButton
    Me.rdoNumeroPar = New System.Windows.Forms.RadioButton
    Me.rdoNumeroTodos = New System.Windows.Forms.RadioButton
    Me.txtTexto = New System.Windows.Forms.TextBox
    Me.gpbTexto = New System.Windows.Forms.GroupBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.gpbTamanhoUnico = New System.Windows.Forms.GroupBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.txtTamanhoUnico = New System.Windows.Forms.TextBox
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpbTipoGrade.SuspendLayout()
    Me.gpbNumero.SuspendLayout()
    Me.gpbTexto.SuspendLayout()
    Me.gpbTamanhoUnico.SuspendLayout()
    Me.SuspendLayout()
    '
    'lblSubTitulo
    '
    Me.lblSubTitulo.AutoSize = True
    Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblSubTitulo.Location = New System.Drawing.Point(60, 32)
    Me.lblSubTitulo.Name = "lblSubTitulo"
    Me.lblSubTitulo.Size = New System.Drawing.Size(80, 14)
    Me.lblSubTitulo.TabIndex = 128
    Me.lblSubTitulo.Text = "Configuração"
    '
    'lblTitulo
    '
    Me.lblTitulo.AutoSize = True
    Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblTitulo.Location = New System.Drawing.Point(60, 8)
    Me.lblTitulo.Name = "lblTitulo"
    Me.lblTitulo.Size = New System.Drawing.Size(71, 24)
    Me.lblTitulo.TabIndex = 126
    Me.lblTitulo.Text = "Grade"
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
    Me.btoSalvar.Location = New System.Drawing.Point(60, 192)
    Me.btoSalvar.Name = "btoSalvar"
    Me.btoSalvar.Size = New System.Drawing.Size(116, 68)
    Me.btoSalvar.TabIndex = 11
    Me.btoSalvar.TabStop = False
    Me.btoSalvar.Text = "Confirmar <Enter>"
    Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSalvar.UseVisualStyleBackColor = False
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
    Me.btoSair.Location = New System.Drawing.Point(180, 192)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(100, 68)
    Me.btoSair.TabIndex = 12
    Me.btoSair.TabStop = False
    Me.btoSair.Text = "Cancelar <ESC>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSair.UseVisualStyleBackColor = False
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.grade1
    Me.imgLogo.Location = New System.Drawing.Point(5, 5)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.imgLogo.TabIndex = 127
    Me.imgLogo.TabStop = False
    '
    'gpbTipoGrade
    '
    Me.gpbTipoGrade.Controls.Add(Me.rdoTipoTexto)
    Me.gpbTipoGrade.Controls.Add(Me.rdoTipoNumero)
    Me.gpbTipoGrade.Controls.Add(Me.rdoTipoUnico)
    Me.gpbTipoGrade.Location = New System.Drawing.Point(8, 68)
    Me.gpbTipoGrade.Name = "gpbTipoGrade"
    Me.gpbTipoGrade.Size = New System.Drawing.Size(140, 92)
    Me.gpbTipoGrade.TabIndex = 135
    Me.gpbTipoGrade.TabStop = False
    Me.gpbTipoGrade.Text = "Tipo de Grade"
    '
    'rdoTipoTexto
    '
    Me.rdoTipoTexto.AutoSize = True
    Me.rdoTipoTexto.Location = New System.Drawing.Point(12, 44)
    Me.rdoTipoTexto.Name = "rdoTipoTexto"
    Me.rdoTipoTexto.Size = New System.Drawing.Size(52, 17)
    Me.rdoTipoTexto.TabIndex = 2
    Me.rdoTipoTexto.TabStop = True
    Me.rdoTipoTexto.Text = "Texto"
    Me.rdoTipoTexto.UseVisualStyleBackColor = True
    '
    'rdoTipoNumero
    '
    Me.rdoTipoNumero.AutoSize = True
    Me.rdoTipoNumero.Location = New System.Drawing.Point(12, 64)
    Me.rdoTipoNumero.Name = "rdoTipoNumero"
    Me.rdoTipoNumero.Size = New System.Drawing.Size(62, 17)
    Me.rdoTipoNumero.TabIndex = 3
    Me.rdoTipoNumero.TabStop = True
    Me.rdoTipoNumero.Text = "Número"
    Me.rdoTipoNumero.UseVisualStyleBackColor = True
    '
    'rdoTipoUnico
    '
    Me.rdoTipoUnico.AutoSize = True
    Me.rdoTipoUnico.Location = New System.Drawing.Point(12, 24)
    Me.rdoTipoUnico.Name = "rdoTipoUnico"
    Me.rdoTipoUnico.Size = New System.Drawing.Size(101, 17)
    Me.rdoTipoUnico.TabIndex = 1
    Me.rdoTipoUnico.TabStop = True
    Me.rdoTipoUnico.Text = "Tamanho Único"
    Me.rdoTipoUnico.UseVisualStyleBackColor = True
    '
    'gpbNumero
    '
    Me.gpbNumero.Controls.Add(Me.Label1)
    Me.gpbNumero.Controls.Add(Me.txtAte)
    Me.gpbNumero.Controls.Add(Me.lblCodigo)
    Me.gpbNumero.Controls.Add(Me.txtDe)
    Me.gpbNumero.Controls.Add(Me.rdoNumeroImpar)
    Me.gpbNumero.Controls.Add(Me.rdoNumeroPar)
    Me.gpbNumero.Controls.Add(Me.rdoNumeroTodos)
    Me.gpbNumero.Location = New System.Drawing.Point(160, 68)
    Me.gpbNumero.Name = "gpbNumero"
    Me.gpbNumero.Size = New System.Drawing.Size(184, 92)
    Me.gpbNumero.TabIndex = 138
    Me.gpbNumero.TabStop = False
    Me.gpbNumero.Text = "Número"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label1.Location = New System.Drawing.Point(12, 56)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(31, 18)
    Me.Label1.TabIndex = 143
    Me.Label1.Text = "Até"
    '
    'txtAte
    '
    Me.txtAte.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtAte.Culture = New System.Globalization.CultureInfo("")
    Me.txtAte.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtAte.Location = New System.Drawing.Point(48, 56)
    Me.txtAte.Mask = "000"
    Me.txtAte.Name = "txtAte"
    Me.txtAte.Size = New System.Drawing.Size(40, 18)
    Me.txtAte.TabIndex = 5
    Me.txtAte.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'lblCodigo
    '
    Me.lblCodigo.AutoSize = True
    Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
    Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblCodigo.Location = New System.Drawing.Point(16, 28)
    Me.lblCodigo.Name = "lblCodigo"
    Me.lblCodigo.Size = New System.Drawing.Size(28, 18)
    Me.lblCodigo.TabIndex = 141
    Me.lblCodigo.Text = "De"
    '
    'txtDe
    '
    Me.txtDe.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDe.Culture = New System.Globalization.CultureInfo("")
    Me.txtDe.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtDe.Location = New System.Drawing.Point(48, 28)
    Me.txtDe.Mask = "000"
    Me.txtDe.Name = "txtDe"
    Me.txtDe.Size = New System.Drawing.Size(40, 18)
    Me.txtDe.TabIndex = 4
    Me.txtDe.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'rdoNumeroImpar
    '
    Me.rdoNumeroImpar.AutoSize = True
    Me.rdoNumeroImpar.Location = New System.Drawing.Point(112, 64)
    Me.rdoNumeroImpar.Name = "rdoNumeroImpar"
    Me.rdoNumeroImpar.Size = New System.Drawing.Size(62, 17)
    Me.rdoNumeroImpar.TabIndex = 8
    Me.rdoNumeroImpar.Text = "Ímpares"
    Me.rdoNumeroImpar.UseVisualStyleBackColor = True
    '
    'rdoNumeroPar
    '
    Me.rdoNumeroPar.AutoSize = True
    Me.rdoNumeroPar.Location = New System.Drawing.Point(112, 44)
    Me.rdoNumeroPar.Name = "rdoNumeroPar"
    Me.rdoNumeroPar.Size = New System.Drawing.Size(52, 17)
    Me.rdoNumeroPar.TabIndex = 7
    Me.rdoNumeroPar.Text = "Pares"
    Me.rdoNumeroPar.UseVisualStyleBackColor = True
    '
    'rdoNumeroTodos
    '
    Me.rdoNumeroTodos.AutoSize = True
    Me.rdoNumeroTodos.Checked = True
    Me.rdoNumeroTodos.Location = New System.Drawing.Point(112, 24)
    Me.rdoNumeroTodos.Name = "rdoNumeroTodos"
    Me.rdoNumeroTodos.Size = New System.Drawing.Size(55, 17)
    Me.rdoNumeroTodos.TabIndex = 6
    Me.rdoNumeroTodos.TabStop = True
    Me.rdoNumeroTodos.Text = "Todos"
    Me.rdoNumeroTodos.UseVisualStyleBackColor = True
    '
    'txtTexto
    '
    Me.txtTexto.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtTexto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtTexto.Location = New System.Drawing.Point(12, 80)
    Me.txtTexto.MaxLength = 20
    Me.txtTexto.Name = "txtTexto"
    Me.txtTexto.Size = New System.Drawing.Size(164, 18)
    Me.txtTexto.TabIndex = 10
    '
    'gpbTexto
    '
    Me.gpbTexto.Controls.Add(Me.Label2)
    Me.gpbTexto.Controls.Add(Me.txtTexto)
    Me.gpbTexto.Location = New System.Drawing.Point(160, 68)
    Me.gpbTexto.Name = "gpbTexto"
    Me.gpbTexto.Size = New System.Drawing.Size(184, 108)
    Me.gpbTexto.TabIndex = 140
    Me.gpbTexto.TabStop = False
    Me.gpbTexto.Text = "Texto"
    '
    'Label2
    '
    Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(210, Byte), Integer))
    Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(12, 24)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(164, 48)
    Me.Label2.TabIndex = 142
    Me.Label2.Text = "Informe os tamanhos desejados separados por ; (ponto e vírgula)"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'gpbTamanhoUnico
    '
    Me.gpbTamanhoUnico.Controls.Add(Me.Label3)
    Me.gpbTamanhoUnico.Controls.Add(Me.txtTamanhoUnico)
    Me.gpbTamanhoUnico.Location = New System.Drawing.Point(160, 68)
    Me.gpbTamanhoUnico.Name = "gpbTamanhoUnico"
    Me.gpbTamanhoUnico.Size = New System.Drawing.Size(184, 92)
    Me.gpbTamanhoUnico.TabIndex = 141
    Me.gpbTamanhoUnico.TabStop = False
    Me.gpbTamanhoUnico.Text = "Tamanho Único"
    '
    'Label3
    '
    Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(210, Byte), Integer))
    Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(12, 24)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(164, 32)
    Me.Label3.TabIndex = 142
    Me.Label3.Text = "Informe o tamanho desejado"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'txtTamanhoUnico
    '
    Me.txtTamanhoUnico.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtTamanhoUnico.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtTamanhoUnico.Location = New System.Drawing.Point(12, 64)
    Me.txtTamanhoUnico.MaxLength = 20
    Me.txtTamanhoUnico.Name = "txtTamanhoUnico"
    Me.txtTamanhoUnico.Size = New System.Drawing.Size(164, 18)
    Me.txtTamanhoUnico.TabIndex = 9
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(351, 262)
    Me.Panel1.TabIndex = 142
    '
    'fGradeForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(351, 262)
    Me.Controls.Add(Me.gpbTipoGrade)
    Me.Controls.Add(Me.btoSalvar)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.gpbTexto)
    Me.Controls.Add(Me.gpbNumero)
    Me.Controls.Add(Me.gpbTamanhoUnico)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fGradeForm"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "fGradeForm"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpbTipoGrade.ResumeLayout(False)
    Me.gpbTipoGrade.PerformLayout()
    Me.gpbNumero.ResumeLayout(False)
    Me.gpbNumero.PerformLayout()
    Me.gpbTexto.ResumeLayout(False)
    Me.gpbTexto.PerformLayout()
    Me.gpbTamanhoUnico.ResumeLayout(False)
    Me.gpbTamanhoUnico.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents gpbTipoGrade As System.Windows.Forms.GroupBox
  Friend WithEvents rdoTipoTexto As System.Windows.Forms.RadioButton
  Friend WithEvents rdoTipoNumero As System.Windows.Forms.RadioButton
  Friend WithEvents rdoTipoUnico As System.Windows.Forms.RadioButton
  Friend WithEvents gpbNumero As System.Windows.Forms.GroupBox
  Friend WithEvents rdoNumeroImpar As System.Windows.Forms.RadioButton
  Friend WithEvents rdoNumeroPar As System.Windows.Forms.RadioButton
  Friend WithEvents rdoNumeroTodos As System.Windows.Forms.RadioButton
  Friend WithEvents txtTexto As System.Windows.Forms.TextBox
  Friend WithEvents txtDe As System.Windows.Forms.MaskedTextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtAte As System.Windows.Forms.MaskedTextBox
  Friend WithEvents lblCodigo As System.Windows.Forms.Label
  Friend WithEvents gpbTexto As System.Windows.Forms.GroupBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents gpbTamanhoUnico As System.Windows.Forms.GroupBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtTamanhoUnico As System.Windows.Forms.TextBox
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
