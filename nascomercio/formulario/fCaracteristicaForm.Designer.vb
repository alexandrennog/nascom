<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fCaracteristicaForm
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
        Me.txtNome = New System.Windows.Forms.TextBox
        Me.cboSituacao = New System.Windows.Forms.ComboBox
        Me.lblSubTitulo = New System.Windows.Forms.Label
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.lblNome = New System.Windows.Forms.Label
        Me.lblSituacao = New System.Windows.Forms.Label
        Me.btoItem = New System.Windows.Forms.Button
        Me.btoSalvar = New System.Windows.Forms.Button
        Me.btoFiltro = New System.Windows.Forms.Button
        Me.btoSair = New System.Windows.Forms.Button
        Me.imgLogo = New System.Windows.Forms.PictureBox
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNome
        '
        Me.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNome.Location = New System.Drawing.Point(84, 96)
        Me.txtNome.MaxLength = 30
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(284, 18)
        Me.txtNome.TabIndex = 2
        '
        'cboSituacao
        '
        Me.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboSituacao.FormattingEnabled = True
        Me.cboSituacao.Items.AddRange(New Object() {"S", "N"})
        Me.cboSituacao.Location = New System.Drawing.Point(83, 120)
        Me.cboSituacao.Name = "cboSituacao"
        Me.cboSituacao.Size = New System.Drawing.Size(100, 26)
        Me.cboSituacao.TabIndex = 3
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSubTitulo.Location = New System.Drawing.Point(64, 33)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(67, 14)
        Me.lblSubTitulo.TabIndex = 110
        Me.lblSubTitulo.Text = "CADASTRO"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(64, 9)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(161, 24)
        Me.lblTitulo.TabIndex = 109
        Me.lblTitulo.Text = "Características"
        '
        'txtCodigo
        '
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(84, 72)
        Me.txtCodigo.MaxLength = 20
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(148, 18)
        Me.txtCodigo.TabIndex = 1
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblCodigo.Location = New System.Drawing.Point(20, 72)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(59, 18)
        Me.lblCodigo.TabIndex = 123
        Me.lblCodigo.Text = "Código"
        '
        'lblNome
        '
        Me.lblNome.AutoSize = True
        Me.lblNome.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblNome.Location = New System.Drawing.Point(28, 96)
        Me.lblNome.Name = "lblNome"
        Me.lblNome.Size = New System.Drawing.Size(49, 18)
        Me.lblNome.TabIndex = 122
        Me.lblNome.Text = "Nome"
        '
        'lblSituacao
        '
        Me.lblSituacao.AutoSize = True
        Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
        Me.lblSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblSituacao.Location = New System.Drawing.Point(8, 124)
        Me.lblSituacao.Name = "lblSituacao"
        Me.lblSituacao.Size = New System.Drawing.Size(69, 18)
        Me.lblSituacao.TabIndex = 121
        Me.lblSituacao.Text = "Situação"
        '
        'btoItem
        '
        Me.btoItem.BackColor = System.Drawing.Color.Transparent
        Me.btoItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoItem.FlatAppearance.BorderSize = 0
        Me.btoItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoItem.ForeColor = System.Drawing.Color.Black
        Me.btoItem.Image = Global.nascomercio.My.Resources.Resources.tipo_de_produto
        Me.btoItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoItem.Location = New System.Drawing.Point(412, 152)
        Me.btoItem.Name = "btoItem"
        Me.btoItem.Size = New System.Drawing.Size(100, 72)
        Me.btoItem.TabIndex = 124
        Me.btoItem.TabStop = False
        Me.btoItem.Text = "Itens <F6>"
        Me.btoItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoItem.UseVisualStyleBackColor = False
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
        Me.btoSalvar.Location = New System.Drawing.Point(208, 280)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(92, 72)
        Me.btoSalvar.TabIndex = 119
        Me.btoSalvar.TabStop = False
        Me.btoSalvar.Text = "Salvar <Enter>"
        Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSalvar.UseVisualStyleBackColor = False
        '
        'btoFiltro
        '
        Me.btoFiltro.BackColor = System.Drawing.Color.Transparent
        Me.btoFiltro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoFiltro.FlatAppearance.BorderSize = 0
        Me.btoFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoFiltro.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoFiltro.ForeColor = System.Drawing.Color.Black
        Me.btoFiltro.Image = Global.nascomercio.My.Resources.Resources.pesquisar
        Me.btoFiltro.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoFiltro.Location = New System.Drawing.Point(412, 76)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(100, 69)
        Me.btoFiltro.TabIndex = 7
        Me.btoFiltro.TabStop = False
        Me.btoFiltro.Text = "Pesquisar <F5>"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
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
        Me.btoSair.Location = New System.Drawing.Point(412, 4)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(100, 68)
        Me.btoSair.TabIndex = 6
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.caracteristicas_produtos
        Me.imgLogo.Location = New System.Drawing.Point(8, 9)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 108
        Me.imgLogo.TabStop = False
        '
        'fCaracteristicaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(515, 356)
        Me.Controls.Add(Me.btoItem)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.lblNome)
        Me.Controls.Add(Me.btoSalvar)
        Me.Controls.Add(Me.lblSituacao)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.btoFiltro)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.cboSituacao)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fCaracteristicaForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Caracteristica"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
  Friend WithEvents btoFiltro As System.Windows.Forms.Button
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents txtNome As System.Windows.Forms.TextBox
  Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
  Friend WithEvents btoItem As System.Windows.Forms.Button
  Friend WithEvents lblCodigo As System.Windows.Forms.Label
  Friend WithEvents lblNome As System.Windows.Forms.Label
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents lblSituacao As System.Windows.Forms.Label
End Class
