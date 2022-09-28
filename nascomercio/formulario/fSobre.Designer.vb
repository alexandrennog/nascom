<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fSobre
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
    Me.btoSair = New System.Windows.Forms.Button
    Me.Label1 = New System.Windows.Forms.Label
    Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
    Me.lblVersao = New System.Windows.Forms.Label
    Me.SuspendLayout()
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
    Me.btoSair.Location = New System.Drawing.Point(98, 130)
    Me.btoSair.Name = "btoSair"
    Me.btoSair.Size = New System.Drawing.Size(89, 73)
    Me.btoSair.TabIndex = 4
    Me.btoSair.Text = "Fechar <Esc>"
    Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoSair.UseVisualStyleBackColor = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(15, 15)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(287, 51)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Nascomercio todos os direitos reservados." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Nascom Tecnologia em Informática Ltda" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tel.: 11-2208-3656"
    '
    'LinkLabel1
    '
    Me.LinkLabel1.AutoSize = True
    Me.LinkLabel1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.LinkLabel1.Location = New System.Drawing.Point(67, 109)
    Me.LinkLabel1.Name = "LinkLabel1"
    Me.LinkLabel1.Size = New System.Drawing.Size(150, 18)
    Me.LinkLabel1.TabIndex = 5
    Me.LinkLabel1.TabStop = True
    Me.LinkLabel1.Text = "www.nascom.com.br"
    '
    'lblVersao
    '
    Me.lblVersao.AutoSize = True
    Me.lblVersao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblVersao.Location = New System.Drawing.Point(15, 76)
    Me.lblVersao.Name = "lblVersao"
    Me.lblVersao.Size = New System.Drawing.Size(108, 18)
    Me.lblVersao.TabIndex = 6
    Me.lblVersao.Text = "Versão: 1.0.0.5"
    '
    'fSobre
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(322, 215)
    Me.ControlBox = False
    Me.Controls.Add(Me.lblVersao)
    Me.Controls.Add(Me.LinkLabel1)
    Me.Controls.Add(Me.btoSair)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fSobre"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Sobre Sistema "
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents lblVersao As System.Windows.Forms.Label
End Class
