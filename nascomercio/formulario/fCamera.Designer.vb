<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fCamera
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
    Me.picImagem = New System.Windows.Forms.PictureBox
    Me.lblCliSubTitulo = New System.Windows.Forms.Label
    Me.imgCliLogo = New System.Windows.Forms.PictureBox
    Me.lblCliCadastro = New System.Windows.Forms.Label
    Me.btoSair = New System.Windows.Forms.Button
    Me.btoSalvar = New System.Windows.Forms.Button
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.picImagem, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'picImagem
    '
    Me.picImagem.Location = New System.Drawing.Point(8, 64)
    Me.picImagem.Name = "picImagem"
    Me.picImagem.Size = New System.Drawing.Size(296, 220)
    Me.picImagem.TabIndex = 0
    Me.picImagem.TabStop = False
    '
    'lblCliSubTitulo
    '
    Me.lblCliSubTitulo.AutoSize = True
    Me.lblCliSubTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblCliSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblCliSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblCliSubTitulo.Location = New System.Drawing.Point(64, 32)
    Me.lblCliSubTitulo.Name = "lblCliSubTitulo"
    Me.lblCliSubTitulo.Size = New System.Drawing.Size(36, 14)
    Me.lblCliSubTitulo.TabIndex = 110
    Me.lblCliSubTitulo.Text = "FOTO"
    '
    'imgCliLogo
    '
    Me.imgCliLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgCliLogo.Image = Global.nascomercio.My.Resources.Resources.cliente
    Me.imgCliLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgCliLogo.Name = "imgCliLogo"
    Me.imgCliLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgCliLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgCliLogo.TabIndex = 109
    Me.imgCliLogo.TabStop = False
    '
    'lblCliCadastro
    '
    Me.lblCliCadastro.AutoSize = True
    Me.lblCliCadastro.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.lblCliCadastro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblCliCadastro.Location = New System.Drawing.Point(64, 8)
    Me.lblCliCadastro.Name = "lblCliCadastro"
    Me.lblCliCadastro.Size = New System.Drawing.Size(91, 24)
    Me.lblCliCadastro.TabIndex = 108
    Me.lblCliCadastro.Text = "Clientes"
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
    Me.btoSair.Location = New System.Drawing.Point(152, 292)
    Me.btoSair.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(106, 72)
    Me.btoSair.TabIndex = 111
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
    Me.btoSalvar.Location = New System.Drawing.Point(48, 292)
    Me.btoSalvar.Name = "btoSalvar"
    Me.btoSalvar.Size = New System.Drawing.Size(96, 72)
    Me.btoSalvar.TabIndex = 112
    Me.btoSalvar.TabStop = False
    Me.btoSalvar.Text = "Salvar <Enter>"
    Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSalvar.UseVisualStyleBackColor = False
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(311, 369)
    Me.Panel1.TabIndex = 113
    '
    'fCamera
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(311, 369)
    Me.Controls.Add(Me.btoSalvar)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.lblCliSubTitulo)
    Me.Controls.Add(Me.imgCliLogo)
    Me.Controls.Add(Me.lblCliCadastro)
    Me.Controls.Add(Me.picImagem)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.Name = "fCamera"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "fCamera"
    CType(Me.picImagem, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents picImagem As System.Windows.Forms.PictureBox
  Friend WithEvents lblCliSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgCliLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblCliCadastro As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
