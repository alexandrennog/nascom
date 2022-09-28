<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fChaveSistema
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
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblCodigoInstalacao = New System.Windows.Forms.Label()
        Me.txtCodigoInstalacao = New System.Windows.Forms.TextBox()
        Me.txtChaveValidacao = New System.Windows.Forms.TextBox()
        Me.lblChaveValidacao = New System.Windows.Forms.Label()
        Me.lblMsgValidacao = New System.Windows.Forms.Label()
        Me.lblDataExpiracao = New System.Windows.Forms.Label()
        Me.txtDataExpiracao = New System.Windows.Forms.TextBox()
        Me.btoSalvar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(11, 9)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(194, 24)
        Me.lblTitulo.TabIndex = 90
        Me.lblTitulo.Text = "Chave do Sistema"
        '
        'lblCodigoInstalacao
        '
        Me.lblCodigoInstalacao.AutoSize = True
        Me.lblCodigoInstalacao.BackColor = System.Drawing.Color.Transparent
        Me.lblCodigoInstalacao.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoInstalacao.Location = New System.Drawing.Point(14, 74)
        Me.lblCodigoInstalacao.Name = "lblCodigoInstalacao"
        Me.lblCodigoInstalacao.Size = New System.Drawing.Size(170, 19)
        Me.lblCodigoInstalacao.TabIndex = 97
        Me.lblCodigoInstalacao.Text = "Código de Instalação"
        '
        'txtCodigoInstalacao
        '
        Me.txtCodigoInstalacao.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtCodigoInstalacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoInstalacao.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoInstalacao.Location = New System.Drawing.Point(15, 96)
        Me.txtCodigoInstalacao.MaxLength = 10
        Me.txtCodigoInstalacao.Name = "txtCodigoInstalacao"
        Me.txtCodigoInstalacao.ReadOnly = True
        Me.txtCodigoInstalacao.Size = New System.Drawing.Size(299, 35)
        Me.txtCodigoInstalacao.TabIndex = 1
        Me.txtCodigoInstalacao.TabStop = False
        Me.txtCodigoInstalacao.WordWrap = False
        '
        'txtChaveValidacao
        '
        Me.txtChaveValidacao.BackColor = System.Drawing.Color.White
        Me.txtChaveValidacao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtChaveValidacao.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChaveValidacao.Location = New System.Drawing.Point(15, 195)
        Me.txtChaveValidacao.MaxLength = 100
        Me.txtChaveValidacao.MinimumSize = New System.Drawing.Size(0, 35)
        Me.txtChaveValidacao.Name = "txtChaveValidacao"
        Me.txtChaveValidacao.Size = New System.Drawing.Size(623, 25)
        Me.txtChaveValidacao.TabIndex = 2
        Me.txtChaveValidacao.WordWrap = False
        '
        'lblChaveValidacao
        '
        Me.lblChaveValidacao.AutoSize = True
        Me.lblChaveValidacao.BackColor = System.Drawing.Color.Transparent
        Me.lblChaveValidacao.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChaveValidacao.Location = New System.Drawing.Point(11, 173)
        Me.lblChaveValidacao.Name = "lblChaveValidacao"
        Me.lblChaveValidacao.Size = New System.Drawing.Size(159, 19)
        Me.lblChaveValidacao.TabIndex = 117
        Me.lblChaveValidacao.Text = "Chave de Validação"
        '
        'lblMsgValidacao
        '
        Me.lblMsgValidacao.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblMsgValidacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgValidacao.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMsgValidacao.Location = New System.Drawing.Point(15, 278)
        Me.lblMsgValidacao.Name = "lblMsgValidacao"
        Me.lblMsgValidacao.Size = New System.Drawing.Size(623, 60)
        Me.lblMsgValidacao.TabIndex = 120
        Me.lblMsgValidacao.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDataExpiracao
        '
        Me.lblDataExpiracao.AutoSize = True
        Me.lblDataExpiracao.BackColor = System.Drawing.Color.Transparent
        Me.lblDataExpiracao.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataExpiracao.Location = New System.Drawing.Point(338, 74)
        Me.lblDataExpiracao.Name = "lblDataExpiracao"
        Me.lblDataExpiracao.Size = New System.Drawing.Size(148, 19)
        Me.lblDataExpiracao.TabIndex = 122
        Me.lblDataExpiracao.Text = "Data de Expiração"
        '
        'txtDataExpiracao
        '
        Me.txtDataExpiracao.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtDataExpiracao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDataExpiracao.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataExpiracao.Location = New System.Drawing.Point(339, 96)
        Me.txtDataExpiracao.MaxLength = 10
        Me.txtDataExpiracao.Name = "txtDataExpiracao"
        Me.txtDataExpiracao.ReadOnly = True
        Me.txtDataExpiracao.Size = New System.Drawing.Size(299, 35)
        Me.txtDataExpiracao.TabIndex = 123
        Me.txtDataExpiracao.TabStop = False
        Me.txtDataExpiracao.WordWrap = False
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
        Me.btoSalvar.Location = New System.Drawing.Point(174, 364)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(139, 73)
        Me.btoSalvar.TabIndex = 124
        Me.btoSalvar.TabStop = False
        Me.btoSalvar.Text = "Validar Chave <Enter>"
        Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSalvar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btoSair)
        Me.Panel1.Controls.Add(Me.btoSalvar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(650, 450)
        Me.Panel1.TabIndex = 146
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
        Me.btoSair.Location = New System.Drawing.Point(338, 364)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(88, 72)
        Me.btoSair.TabIndex = 125
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'fChaveSistema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(650, 450)
        Me.Controls.Add(Me.txtDataExpiracao)
        Me.Controls.Add(Me.lblDataExpiracao)
        Me.Controls.Add(Me.lblMsgValidacao)
        Me.Controls.Add(Me.txtChaveValidacao)
        Me.Controls.Add(Me.lblChaveValidacao)
        Me.Controls.Add(Me.txtCodigoInstalacao)
        Me.Controls.Add(Me.lblCodigoInstalacao)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "fChaveSistema"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "/"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblCodigoInstalacao As System.Windows.Forms.Label
    Friend WithEvents txtCodigoInstalacao As System.Windows.Forms.TextBox
    Friend WithEvents txtChaveValidacao As System.Windows.Forms.TextBox
    Friend WithEvents lblChaveValidacao As System.Windows.Forms.Label
    Friend WithEvents lblMsgValidacao As System.Windows.Forms.Label
    Friend WithEvents lblDataExpiracao As System.Windows.Forms.Label
    Friend WithEvents txtDataExpiracao As System.Windows.Forms.TextBox
    Friend WithEvents btoSalvar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btoSair As System.Windows.Forms.Button
End Class
