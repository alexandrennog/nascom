<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fAcessoGerente
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
    Me.txtUsuario = New System.Windows.Forms.TextBox
    Me.txtSenha = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.btoAcessar = New System.Windows.Forms.Button
    Me.btoSair = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'txtUsuario
    '
    Me.txtUsuario.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtUsuario.Location = New System.Drawing.Point(92, 15)
    Me.txtUsuario.Name = "txtUsuario"
    Me.txtUsuario.Size = New System.Drawing.Size(143, 25)
    Me.txtUsuario.TabIndex = 1
    '
    'txtSenha
    '
    Me.txtSenha.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.txtSenha.Location = New System.Drawing.Point(92, 46)
    Me.txtSenha.Name = "txtSenha"
    Me.txtSenha.Size = New System.Drawing.Size(143, 25)
    Me.txtSenha.TabIndex = 2
    Me.txtSenha.UseSystemPasswordChar = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label1.Location = New System.Drawing.Point(19, 15)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(63, 18)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Usuário"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label2.Location = New System.Drawing.Point(19, 49)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(53, 18)
    Me.Label2.TabIndex = 4
    Me.Label2.Text = "Senha"
    '
    'btoAcessar
    '
    Me.btoAcessar.BackColor = System.Drawing.Color.Transparent
    Me.btoAcessar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoAcessar.FlatAppearance.BorderSize = 0
    Me.btoAcessar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoAcessar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoAcessar.ForeColor = System.Drawing.Color.Black
    Me.btoAcessar.Image = Global.nascomercio.My.Resources.Resources.confirmar
    Me.btoAcessar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoAcessar.Location = New System.Drawing.Point(32, 88)
    Me.btoAcessar.Name = "btoAcessar"
    Me.btoAcessar.Size = New System.Drawing.Size(97, 73)
    Me.btoAcessar.TabIndex = 3
    Me.btoAcessar.TabStop = False
    Me.btoAcessar.Text = " Entrar <Enter>"
    Me.btoAcessar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoAcessar.UseVisualStyleBackColor = False
    '
    'btoSair
    '
    Me.btoSair.BackColor = System.Drawing.Color.Transparent
    Me.btoSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoSair.FlatAppearance.BorderSize = 0
    Me.btoSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoSair.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
    Me.btoSair.ForeColor = System.Drawing.Color.Black
    Me.btoSair.Image = Global.nascomercio.My.Resources.Resources.fechar
    Me.btoSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoSair.Location = New System.Drawing.Point(136, 88)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(89, 73)
    Me.btoSair.TabIndex = 4
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSair.UseVisualStyleBackColor = False
    '
    'fAcessoGerente
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(257, 165)
    Me.ControlBox = False
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.btoAcessar)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtSenha)
    Me.Controls.Add(Me.txtUsuario)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fAcessoGerente"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Sistema - Identificação"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
  Friend WithEvents txtSenha As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents btoAcessar As System.Windows.Forms.Button
  Friend WithEvents btoSair As System.Windows.Forms.Button
End Class
