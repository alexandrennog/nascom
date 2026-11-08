<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fBackup
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
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.btoBanco = New System.Windows.Forms.Button()
        Me.txtBanco = New System.Windows.Forms.TextBox()
        Me.btoRestaurar = New System.Windows.Forms.Button()
        Me.btoCopiar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNomeBanco = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.lblNuvemTitulo = New System.Windows.Forms.Label()
        Me.lblUltimoBackup = New System.Windows.Forms.Label()
        Me.btoBackupNuvem = New System.Windows.Forms.Button()
        Me.btoRelatorioBackups = New System.Windows.Forms.Button()
        Me.lblProgresso = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofd
        '
        Me.ofd.FileName = "OpenFileDialog1"
        '
        'btoBanco
        '
        Me.btoBanco.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoBanco.Location = New System.Drawing.Point(445, 131)
        Me.btoBanco.Name = "btoBanco"
        Me.btoBanco.Size = New System.Drawing.Size(25, 23)
        Me.btoBanco.TabIndex = 14
        Me.btoBanco.Text = "..."
        Me.btoBanco.UseVisualStyleBackColor = True
        '
        'txtBanco
        '
        Me.txtBanco.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtBanco.Location = New System.Drawing.Point(9, 131)
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.Size = New System.Drawing.Size(430, 20)
        Me.txtBanco.TabIndex = 13
        '
        'btoRestaurar
        '
        Me.btoRestaurar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoRestaurar.Location = New System.Drawing.Point(476, 131)
        Me.btoRestaurar.Name = "btoRestaurar"
        Me.btoRestaurar.Size = New System.Drawing.Size(86, 23)
        Me.btoRestaurar.TabIndex = 15
        Me.btoRestaurar.Text = "Restore"
        Me.btoRestaurar.UseVisualStyleBackColor = True
        '
        'btoCopiar
        '
        Me.btoCopiar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btoCopiar.Location = New System.Drawing.Point(445, 102)
        Me.btoCopiar.Name = "btoCopiar"
        Me.btoCopiar.Size = New System.Drawing.Size(117, 23)
        Me.btoCopiar.TabIndex = 16
        Me.btoCopiar.Text = "Backup"
        Me.btoCopiar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(10, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 19)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Banco de Dados:"
        '
        'lblNomeBanco
        '
        Me.lblNomeBanco.AutoSize = True
        Me.lblNomeBanco.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblNomeBanco.Location = New System.Drawing.Point(158, 107)
        Me.lblNomeBanco.Name = "lblNomeBanco"
        Me.lblNomeBanco.Size = New System.Drawing.Size(116, 19)
        Me.lblNomeBanco.TabIndex = 18
        Me.lblNomeBanco.Text = "NOMEBANCO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(59, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 24)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Banco de Dados"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.imgLogo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btoSair)
        Me.Panel1.Controls.Add(Me.lblNomeBanco)
        Me.Panel1.Controls.Add(Me.btoCopiar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtBanco)
        Me.Panel1.Controls.Add(Me.btoBanco)
        Me.Panel1.Controls.Add(Me.btoRestaurar)
        Me.Panel1.Controls.Add(Me.lblNuvemTitulo)
        Me.Panel1.Controls.Add(Me.lblUltimoBackup)
        Me.Panel1.Controls.Add(Me.btoBackupNuvem)
        Me.Panel1.Controls.Add(Me.btoRelatorioBackups)
        Me.Panel1.Controls.Add(Me.lblProgresso)
        Me.Panel1.Location = New System.Drawing.Point(2, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(575, 356)
        Me.Panel1.TabIndex = 20
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.ferramentas1
        Me.imgLogo.Location = New System.Drawing.Point(3, 3)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 95
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
        Me.btoSair.Location = New System.Drawing.Point(482, 3)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(88, 72)
        Me.btoSair.TabIndex = 94
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'lblNuvemTitulo
        '
        ' Backup local + nuvem (biblioteca NasLibackup). Os dados da AWS e do
        ' e-mail de falha ficam no app.config (chaves Backup...).
        Me.lblNuvemTitulo.AutoSize = True
        Me.lblNuvemTitulo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblNuvemTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblNuvemTitulo.Location = New System.Drawing.Point(8, 170)
        Me.lblNuvemTitulo.Name = "lblNuvemTitulo"
        Me.lblNuvemTitulo.Size = New System.Drawing.Size(230, 19)
        Me.lblNuvemTitulo.TabIndex = 21
        Me.lblNuvemTitulo.Text = "Backup local + nuvem (AWS)"
        '
        'lblUltimoBackup
        '
        Me.lblUltimoBackup.BackColor = System.Drawing.Color.White
        Me.lblUltimoBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUltimoBackup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUltimoBackup.Location = New System.Drawing.Point(9, 196)
        Me.lblUltimoBackup.Name = "lblUltimoBackup"
        Me.lblUltimoBackup.Padding = New System.Windows.Forms.Padding(4)
        Me.lblUltimoBackup.Size = New System.Drawing.Size(553, 80)
        Me.lblUltimoBackup.TabIndex = 22
        Me.lblUltimoBackup.Text = "-"
        '
        'btoBackupNuvem
        '
        Me.btoBackupNuvem.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btoBackupNuvem.Location = New System.Drawing.Point(9, 282)
        Me.btoBackupNuvem.Name = "btoBackupNuvem"
        Me.btoBackupNuvem.Size = New System.Drawing.Size(272, 38)
        Me.btoBackupNuvem.TabIndex = 23
        Me.btoBackupNuvem.Text = "Fazer backup agora (local + nuvem)"
        Me.btoBackupNuvem.UseVisualStyleBackColor = True
        '
        'btoRelatorioBackups
        '
        Me.btoRelatorioBackups.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btoRelatorioBackups.Location = New System.Drawing.Point(290, 282)
        Me.btoRelatorioBackups.Name = "btoRelatorioBackups"
        Me.btoRelatorioBackups.Size = New System.Drawing.Size(272, 38)
        Me.btoRelatorioBackups.TabIndex = 24
        Me.btoRelatorioBackups.Text = "Relatório de Backups"
        Me.btoRelatorioBackups.UseVisualStyleBackColor = True
        '
        'lblProgresso
        '
        Me.lblProgresso.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)
        Me.lblProgresso.ForeColor = System.Drawing.Color.DimGray
        Me.lblProgresso.Location = New System.Drawing.Point(9, 326)
        Me.lblProgresso.Name = "lblProgresso"
        Me.lblProgresso.Size = New System.Drawing.Size(553, 22)
        Me.lblProgresso.TabIndex = 25
        Me.lblProgresso.Text = ""
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'fBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(577, 360)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fBackup"
        Me.Text = "Backup"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
  Friend WithEvents btoBanco As System.Windows.Forms.Button
  Friend WithEvents txtBanco As System.Windows.Forms.TextBox
  Friend WithEvents btoRestaurar As System.Windows.Forms.Button
  Friend WithEvents btoCopiar As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents lblNomeBanco As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents lblNuvemTitulo As System.Windows.Forms.Label
    Friend WithEvents lblUltimoBackup As System.Windows.Forms.Label
    Friend WithEvents btoBackupNuvem As System.Windows.Forms.Button
    Friend WithEvents btoRelatorioBackups As System.Windows.Forms.Button
    Friend WithEvents lblProgresso As System.Windows.Forms.Label
End Class
