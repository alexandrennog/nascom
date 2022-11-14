<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fAcesso
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
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtSenha = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btoAcessar = New System.Windows.Forms.Button()
        Me.btoRecuperar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtUsuario
        '
        Me.txtUsuario.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtUsuario.Location = New System.Drawing.Point(92, 15)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(137, 25)
        Me.txtUsuario.TabIndex = 1
        '
        'txtSenha
        '
        Me.txtSenha.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtSenha.Location = New System.Drawing.Point(92, 46)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.Size = New System.Drawing.Size(137, 25)
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
        Me.btoAcessar.Location = New System.Drawing.Point(12, 77)
        Me.btoAcessar.Name = "btoAcessar"
        Me.btoAcessar.Size = New System.Drawing.Size(95, 74)
        Me.btoAcessar.TabIndex = 3
        Me.btoAcessar.TabStop = False
        Me.btoAcessar.Text = " Entrar <Enter>"
        Me.btoAcessar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoAcessar.UseVisualStyleBackColor = False
        '
        'btoRecuperar
        '
        Me.btoRecuperar.BackColor = System.Drawing.Color.Transparent
        Me.btoRecuperar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoRecuperar.FlatAppearance.BorderSize = 0
        Me.btoRecuperar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoRecuperar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoRecuperar.ForeColor = System.Drawing.Color.Black
        Me.btoRecuperar.Image = Global.nascomercio.My.Resources.Resources.ico_pass
        Me.btoRecuperar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoRecuperar.Location = New System.Drawing.Point(120, 92)
        Me.btoRecuperar.Name = "btoRecuperar"
        Me.btoRecuperar.Size = New System.Drawing.Size(109, 59)
        Me.btoRecuperar.TabIndex = 4
        Me.btoRecuperar.TabStop = False
        Me.btoRecuperar.Text = "Recuperar Senha"
        Me.btoRecuperar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoRecuperar.UseVisualStyleBackColor = False
        '
        'fAcesso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(247, 152)
        Me.ControlBox = False
        Me.Controls.Add(Me.btoRecuperar)
        Me.Controls.Add(Me.btoAcessar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSenha)
        Me.Controls.Add(Me.txtUsuario)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fAcesso"
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
    Friend WithEvents btoRecuperar As Button
End Class
