<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDinheiro = New System.Windows.Forms.TextBox()
        Me.txtDisponivel = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblTroco = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblRecebido = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblFalta = New System.Windows.Forms.Label()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picQRCode = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.picQRCode)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtDinheiro)
        Me.Panel1.Controls.Add(Me.txtDisponivel)
        Me.Panel1.Controls.Add(Me.lblTotal)
        Me.Panel1.Controls.Add(Me.lblTroco)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.btoSair)
        Me.Panel1.Controls.Add(Me.lblRecebido)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.lblFalta)
        Me.Panel1.Location = New System.Drawing.Point(61, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(442, 398)
        Me.Panel1.TabIndex = 321
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 19)
        Me.Label6.TabIndex = 322
        Me.Label6.Text = "Valor: R$"
        '
        'txtDinheiro
        '
        Me.txtDinheiro.Enabled = False
        Me.txtDinheiro.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDinheiro.Location = New System.Drawing.Point(111, 27)
        Me.txtDinheiro.Name = "txtDinheiro"
        Me.txtDinheiro.Size = New System.Drawing.Size(101, 26)
        Me.txtDinheiro.TabIndex = 321
        Me.txtDinheiro.Text = "0,00"
        '
        'txtDisponivel
        '
        Me.txtDisponivel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDisponivel.Location = New System.Drawing.Point(439, 136)
        Me.txtDisponivel.Name = "txtDisponivel"
        Me.txtDisponivel.ReadOnly = True
        Me.txtDisponivel.Size = New System.Drawing.Size(184, 13)
        Me.txtDisponivel.TabIndex = 3
        Me.txtDisponivel.TabStop = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Blue
        Me.lblTotal.Location = New System.Drawing.Point(651, 503)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(79, 19)
        Me.lblTotal.TabIndex = 310
        Me.lblTotal.Text = "11.000,00"
        '
        'lblTroco
        '
        Me.lblTroco.AutoSize = True
        Me.lblTroco.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTroco.ForeColor = System.Drawing.Color.Blue
        Me.lblTroco.Location = New System.Drawing.Point(481, 503)
        Me.lblTroco.Name = "lblTroco"
        Me.lblTroco.Size = New System.Drawing.Size(79, 19)
        Me.lblTroco.TabIndex = 314
        Me.lblTroco.Text = "11.000,00"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(567, 503)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 19)
        Me.Label17.TabIndex = 309
        Me.Label17.Text = "Total: R$"
        '
        'lblRecebido
        '
        Me.lblRecebido.AutoSize = True
        Me.lblRecebido.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecebido.ForeColor = System.Drawing.Color.Blue
        Me.lblRecebido.Location = New System.Drawing.Point(132, 503)
        Me.lblRecebido.Name = "lblRecebido"
        Me.lblRecebido.Size = New System.Drawing.Size(79, 19)
        Me.lblRecebido.TabIndex = 312
        Me.lblRecebido.Text = "11.123,45"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(390, 503)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 19)
        Me.Label14.TabIndex = 313
        Me.Label14.Text = "Troco: R$"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(17, 503)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(113, 19)
        Me.Label16.TabIndex = 311
        Me.Label16.Text = "Recebido: R$"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(221, 503)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 19)
        Me.Label13.TabIndex = 307
        Me.Label13.Text = "Falta: R$"
        '
        'lblFalta
        '
        Me.lblFalta.AutoSize = True
        Me.lblFalta.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFalta.ForeColor = System.Drawing.Color.Blue
        Me.lblFalta.Location = New System.Drawing.Point(304, 503)
        Me.lblFalta.Name = "lblFalta"
        Me.lblFalta.Size = New System.Drawing.Size(79, 19)
        Me.lblFalta.TabIndex = 308
        Me.lblFalta.Text = "11.123,45"
        '
        'btoSair
        '
        Me.btoSair.BackColor = System.Drawing.Color.Transparent
        Me.btoSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoSair.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btoSair.FlatAppearance.BorderSize = 0
        Me.btoSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoSair.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoSair.ForeColor = System.Drawing.Color.Black
        Me.btoSair.Image = Global.nascomercio.My.Resources.Resources.fechar
        Me.btoSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoSair.Location = New System.Drawing.Point(692, 12)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(96, 72)
        Me.btoSair.TabIndex = 8
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 19)
        Me.Label1.TabIndex = 323
        Me.Label1.Text = "QR Code"
        '
        'picQRCode
        '
        Me.picQRCode.Location = New System.Drawing.Point(111, 85)
        Me.picQRCode.Name = "picQRCode"
        Me.picQRCode.Size = New System.Drawing.Size(296, 220)
        Me.picQRCode.TabIndex = 324
        Me.picQRCode.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 498)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDinheiro As TextBox
    Friend WithEvents txtDisponivel As TextBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblTroco As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents btoSair As Button
    Friend WithEvents lblRecebido As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblFalta As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents picQRCode As PictureBox
End Class
