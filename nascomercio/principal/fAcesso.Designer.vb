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
Me.btoADM = New System.Windows.Forms.Button
Me.TextBox1 = New System.Windows.Forms.TextBox
Me.TextBox2 = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.btoCAIXA = New System.Windows.Forms.Button
Me.SuspendLayout()
'
'btoADM
'
Me.btoADM.Location = New System.Drawing.Point(139, 70)
Me.btoADM.Name = "btoADM"
Me.btoADM.Size = New System.Drawing.Size(75, 23)
Me.btoADM.TabIndex = 0
Me.btoADM.Text = "Adm"
Me.btoADM.UseVisualStyleBackColor = True
'
'TextBox1
'
Me.TextBox1.Location = New System.Drawing.Point(71, 12)
Me.TextBox1.Name = "TextBox1"
Me.TextBox1.Size = New System.Drawing.Size(143, 20)
Me.TextBox1.TabIndex = 1
'
'TextBox2
'
Me.TextBox2.Location = New System.Drawing.Point(71, 38)
Me.TextBox2.Name = "TextBox2"
Me.TextBox2.Size = New System.Drawing.Size(143, 20)
Me.TextBox2.TabIndex = 2
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(19, 15)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(46, 13)
Me.Label1.TabIndex = 3
Me.Label1.Text = "Usuário:"
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(19, 41)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(41, 13)
Me.Label2.TabIndex = 4
Me.Label2.Text = "Senha:"
'
'btoCAIXA
'
Me.btoCAIXA.Location = New System.Drawing.Point(22, 70)
Me.btoCAIXA.Name = "btoCAIXA"
Me.btoCAIXA.Size = New System.Drawing.Size(75, 23)
Me.btoCAIXA.TabIndex = 5
Me.btoCAIXA.Text = "CAIXA"
Me.btoCAIXA.UseVisualStyleBackColor = True
'
'fAcesso
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
Me.ClientSize = New System.Drawing.Size(237, 105)
Me.ControlBox = False
Me.Controls.Add(Me.btoCAIXA)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TextBox2)
Me.Controls.Add(Me.TextBox1)
Me.Controls.Add(Me.btoADM)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "fAcesso"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "NASCOMercio - Identificação"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents btoADM As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btoCAIXA As System.Windows.Forms.Button
End Class
