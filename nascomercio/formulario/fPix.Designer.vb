<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPix
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
        Me.panelPIX = New System.Windows.Forms.Panel()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.btnListar = New System.Windows.Forms.Button()
        Me.txtUrlPix = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.btnPix = New System.Windows.Forms.Button()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtTxId = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.picQRCode = New System.Windows.Forms.PictureBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtValorPIX = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnCopiar = New System.Windows.Forms.Button()
        Me.PanelListPix = New System.Windows.Forms.Panel()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.lstPix = New System.Windows.Forms.ListView()
        Me.panelPIX.SuspendLayout()
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelListPix.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelPIX
        '
        Me.panelPIX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelPIX.Controls.Add(Me.btoSair)
        Me.panelPIX.Controls.Add(Me.btnListar)
        Me.panelPIX.Controls.Add(Me.txtUrlPix)
        Me.panelPIX.Controls.Add(Me.Label34)
        Me.panelPIX.Controls.Add(Me.btnPix)
        Me.panelPIX.Controls.Add(Me.txtStatus)
        Me.panelPIX.Controls.Add(Me.Label35)
        Me.panelPIX.Controls.Add(Me.txtTxId)
        Me.panelPIX.Controls.Add(Me.Label46)
        Me.panelPIX.Controls.Add(Me.txtObs)
        Me.panelPIX.Controls.Add(Me.Label44)
        Me.panelPIX.Controls.Add(Me.picQRCode)
        Me.panelPIX.Controls.Add(Me.Label25)
        Me.panelPIX.Controls.Add(Me.txtValorPIX)
        Me.panelPIX.Controls.Add(Me.Button1)
        Me.panelPIX.Controls.Add(Me.btnCopiar)
        Me.panelPIX.Location = New System.Drawing.Point(26, 12)
        Me.panelPIX.Name = "panelPIX"
        Me.panelPIX.Size = New System.Drawing.Size(752, 484)
        Me.panelPIX.TabIndex = 323
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
        Me.btoSair.Location = New System.Drawing.Point(637, 12)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(88, 72)
        Me.btoSair.TabIndex = 324
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'btnListar
        '
        Me.btnListar.BackColor = System.Drawing.Color.Transparent
        Me.btnListar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnListar.FlatAppearance.BorderSize = 0
        Me.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnListar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnListar.ForeColor = System.Drawing.Color.Black
        Me.btnListar.Image = Global.nascomercio.My.Resources.Resources.lista
        Me.btnListar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnListar.Location = New System.Drawing.Point(417, 346)
        Me.btnListar.Name = "btnListar"
        Me.btnListar.Size = New System.Drawing.Size(88, 60)
        Me.btnListar.TabIndex = 341
        Me.btnListar.TabStop = False
        Me.btnListar.Text = "Listar PIX"
        Me.btnListar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnListar.UseVisualStyleBackColor = False
        '
        'txtUrlPix
        '
        Me.txtUrlPix.Location = New System.Drawing.Point(88, 209)
        Me.txtUrlPix.Multiline = True
        Me.txtUrlPix.Name = "txtUrlPix"
        Me.txtUrlPix.Size = New System.Drawing.Size(328, 104)
        Me.txtUrlPix.TabIndex = 339
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(41, 209)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(41, 19)
        Me.Label34.TabIndex = 338
        Me.Label34.Text = "PIX:"
        '
        'btnPix
        '
        Me.btnPix.BackColor = System.Drawing.Color.Transparent
        Me.btnPix.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPix.FlatAppearance.BorderSize = 0
        Me.btnPix.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPix.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPix.ForeColor = System.Drawing.Color.Black
        Me.btnPix.Image = Global.nascomercio.My.Resources.Resources.cobrar
        Me.btnPix.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPix.Location = New System.Drawing.Point(197, 3)
        Me.btnPix.Name = "btnPix"
        Me.btnPix.Size = New System.Drawing.Size(101, 66)
        Me.btnPix.TabIndex = 337
        Me.btnPix.TabStop = False
        Me.btnPix.Text = "Cobrar <Enter>"
        Me.btnPix.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPix.UseVisualStyleBackColor = False
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtStatus.Enabled = False
        Me.txtStatus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(88, 43)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(98, 26)
        Me.txtStatus.TabIndex = 336
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(17, 43)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(64, 19)
        Me.Label35.TabIndex = 335
        Me.Label35.Text = "Status:"
        '
        'txtTxId
        '
        Me.txtTxId.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTxId.Enabled = False
        Me.txtTxId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTxId.Location = New System.Drawing.Point(88, 75)
        Me.txtTxId.Name = "txtTxId"
        Me.txtTxId.Size = New System.Drawing.Size(214, 20)
        Me.txtTxId.TabIndex = 334
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(31, 75)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(50, 19)
        Me.Label46.TabIndex = 333
        Me.Label46.Text = "TxID:"
        '
        'txtObs
        '
        Me.txtObs.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObs.Location = New System.Drawing.Point(88, 101)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(214, 102)
        Me.txtObs.TabIndex = 330
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(35, 101)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(46, 19)
        Me.Label44.TabIndex = 329
        Me.Label44.Text = "Obs:"
        '
        'picQRCode
        '
        Me.picQRCode.Location = New System.Drawing.Point(308, 3)
        Me.picQRCode.Name = "picQRCode"
        Me.picQRCode.Size = New System.Drawing.Size(200, 200)
        Me.picQRCode.TabIndex = 324
        Me.picQRCode.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(2, 12)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(79, 19)
        Me.Label25.TabIndex = 322
        Me.Label25.Text = "Valor: R$"
        '
        'txtValorPIX
        '
        Me.txtValorPIX.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtValorPIX.Enabled = False
        Me.txtValorPIX.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorPIX.Location = New System.Drawing.Point(88, 12)
        Me.txtValorPIX.Name = "txtValorPIX"
        Me.txtValorPIX.Size = New System.Drawing.Size(101, 26)
        Me.txtValorPIX.TabIndex = 321
        Me.txtValorPIX.Text = "0,00"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = Global.nascomercio.My.Resources.Resources.fechar
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(629, 12)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 72)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Fechar <Esc>"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnCopiar
        '
        Me.btnCopiar.BackColor = System.Drawing.Color.Transparent
        Me.btnCopiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCopiar.FlatAppearance.BorderSize = 0
        Me.btnCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopiar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopiar.ForeColor = System.Drawing.Color.Black
        Me.btnCopiar.Image = Global.nascomercio.My.Resources.Resources.copy
        Me.btnCopiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCopiar.Location = New System.Drawing.Point(406, 209)
        Me.btnCopiar.Name = "btnCopiar"
        Me.btnCopiar.Size = New System.Drawing.Size(88, 53)
        Me.btnCopiar.TabIndex = 340
        Me.btnCopiar.TabStop = False
        Me.btnCopiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCopiar.UseVisualStyleBackColor = False
        '
        'PanelListPix
        '
        Me.PanelListPix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelListPix.Controls.Add(Me.Label24)
        Me.PanelListPix.Controls.Add(Me.btnSair)
        Me.PanelListPix.Controls.Add(Me.lstPix)
        Me.PanelListPix.Location = New System.Drawing.Point(26, 12)
        Me.PanelListPix.Name = "PanelListPix"
        Me.PanelListPix.Size = New System.Drawing.Size(752, 480)
        Me.PanelListPix.TabIndex = 326
        Me.PanelListPix.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(17, 6)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(133, 19)
        Me.Label24.TabIndex = 343
        Me.Label24.Text = "Cobranças PIX :"
        '
        'btnSair
        '
        Me.btnSair.BackColor = System.Drawing.Color.Transparent
        Me.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSair.FlatAppearance.BorderSize = 0
        Me.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSair.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSair.ForeColor = System.Drawing.Color.Black
        Me.btnSair.Image = Global.nascomercio.My.Resources.Resources.sair
        Me.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSair.Location = New System.Drawing.Point(420, 338)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(88, 60)
        Me.btnSair.TabIndex = 342
        Me.btnSair.TabStop = False
        Me.btnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSair.UseVisualStyleBackColor = False
        '
        'lstPix
        '
        Me.lstPix.HideSelection = False
        Me.lstPix.Location = New System.Drawing.Point(13, 31)
        Me.lstPix.Name = "lstPix"
        Me.lstPix.Size = New System.Drawing.Size(495, 301)
        Me.lstPix.TabIndex = 211
        Me.lstPix.UseCompatibleStateImageBehavior = False
        '
        'fPix
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(827, 680)
        Me.Controls.Add(Me.panelPIX)
        Me.Controls.Add(Me.PanelListPix)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fPix"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fPix"
        Me.panelPIX.ResumeLayout(False)
        Me.panelPIX.PerformLayout()
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelListPix.ResumeLayout(False)
        Me.PanelListPix.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelPIX As Panel
    Friend WithEvents btnListar As Button
    Friend WithEvents txtUrlPix As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents btnPix As Button
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents txtTxId As TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents txtObs As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents picQRCode As PictureBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtValorPIX As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnCopiar As Button
    Friend WithEvents btoSair As Button
    Friend WithEvents PanelListPix As Panel
    Friend WithEvents Label24 As Label
    Friend WithEvents btnSair As Button
    Friend WithEvents lstPix As ListView
End Class
