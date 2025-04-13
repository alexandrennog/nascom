<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fOrdemServico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fOrdemServico))
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblEmissao = New System.Windows.Forms.Label
        Me.lblVendedor = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblLoja = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblSituacao = New System.Windows.Forms.Label
        Me.cboSituacao = New System.Windows.Forms.ComboBox
        Me.txtControle = New System.Windows.Forms.TextBox
        Me.btoSair = New System.Windows.Forms.Button
        Me.btoEtiqueta = New System.Windows.Forms.Button
        Me.btoVeiculos = New System.Windows.Forms.Button
        Me.btoClientes = New System.Windows.Forms.Button
        Me.txtObservacao = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtVeiculo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btoSalvar = New System.Windows.Forms.Button
        Me.imgLogo = New System.Windows.Forms.PictureBox
        Me.Panel1.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(68, 12)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(252, 32)
        Me.lblTitulo.TabIndex = 20
        Me.lblTitulo.Text = "Ordem de Serviço"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(58, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 19)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Cliente :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(396, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 19)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Vendedor :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(210, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 19)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Emissão :"
        '
        'lblEmissao
        '
        Me.lblEmissao.AutoSize = True
        Me.lblEmissao.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmissao.ForeColor = System.Drawing.Color.Blue
        Me.lblEmissao.Location = New System.Drawing.Point(301, 73)
        Me.lblEmissao.Name = "lblEmissao"
        Me.lblEmissao.Size = New System.Drawing.Size(89, 19)
        Me.lblEmissao.TabIndex = 31
        Me.lblEmissao.Text = "03/06/2009"
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendedor.ForeColor = System.Drawing.Color.Blue
        Me.lblVendedor.Location = New System.Drawing.Point(496, 71)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(30, 19)
        Me.lblVendedor.TabIndex = 49
        Me.lblVendedor.Text = "Eu"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 19)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Controle :"
        '
        'txtCliente
        '
        Me.txtCliente.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(140, 101)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(460, 26)
        Me.txtCliente.TabIndex = 0
        Me.txtCliente.Text = "Consumidor"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(325, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 19)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Loja :"
        '
        'lblLoja
        '
        Me.lblLoja.AutoSize = True
        Me.lblLoja.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoja.ForeColor = System.Drawing.Color.Blue
        Me.lblLoja.Location = New System.Drawing.Point(383, 21)
        Me.lblLoja.Name = "lblLoja"
        Me.lblLoja.Size = New System.Drawing.Size(41, 19)
        Me.lblLoja.TabIndex = 33
        Me.lblLoja.Text = "ADJ"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(637, 106)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(146, 16)
        Me.Label20.TabIndex = 171
        Me.Label20.Text = "Pesquisar Cliente [F1]"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblSituacao)
        Me.Panel1.Controls.Add(Me.cboSituacao)
        Me.Panel1.Controls.Add(Me.txtControle)
        Me.Panel1.Controls.Add(Me.btoSair)
        Me.Panel1.Controls.Add(Me.btoEtiqueta)
        Me.Panel1.Controls.Add(Me.btoVeiculos)
        Me.Panel1.Controls.Add(Me.btoClientes)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtObservacao)
        Me.Panel1.Controls.Add(Me.txtCliente)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtVeiculo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblVendedor)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.btoSalvar)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.lblEmissao)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblLoja)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(889, 553)
        Me.Panel1.TabIndex = 172
        '
        'lblSituacao
        '
        Me.lblSituacao.AutoSize = True
        Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
        Me.lblSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblSituacao.Location = New System.Drawing.Point(139, 447)
        Me.lblSituacao.Name = "lblSituacao"
        Me.lblSituacao.Size = New System.Drawing.Size(69, 18)
        Me.lblSituacao.TabIndex = 337
        Me.lblSituacao.Text = "Situação"
        '
        'cboSituacao
        '
        Me.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboSituacao.FormattingEnabled = True
        Me.cboSituacao.Items.AddRange(New Object() {"Aberta", "Fechada"})
        Me.cboSituacao.Location = New System.Drawing.Point(214, 444)
        Me.cboSituacao.Name = "cboSituacao"
        Me.cboSituacao.Size = New System.Drawing.Size(100, 26)
        Me.cboSituacao.TabIndex = 336
        '
        'txtControle
        '
        Me.txtControle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtControle.Location = New System.Drawing.Point(136, 68)
        Me.txtControle.MaxLength = 8
        Me.txtControle.Name = "txtControle"
        Me.txtControle.Size = New System.Drawing.Size(68, 26)
        Me.txtControle.TabIndex = 335
        Me.txtControle.Text = "1"
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
        Me.btoSair.Location = New System.Drawing.Point(791, 11)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(88, 72)
        Me.btoSair.TabIndex = 14
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'btoEtiqueta
        '
        Me.btoEtiqueta.BackColor = System.Drawing.Color.Transparent
        Me.btoEtiqueta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoEtiqueta.FlatAppearance.BorderSize = 0
        Me.btoEtiqueta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoEtiqueta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoEtiqueta.ForeColor = System.Drawing.Color.Black
        Me.btoEtiqueta.Image = Global.nascomercio.My.Resources.Resources.print_design
        Me.btoEtiqueta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoEtiqueta.Location = New System.Drawing.Point(786, 101)
        Me.btoEtiqueta.Margin = New System.Windows.Forms.Padding(0)
        Me.btoEtiqueta.Name = "btoEtiqueta"
        Me.btoEtiqueta.Size = New System.Drawing.Size(96, 72)
        Me.btoEtiqueta.TabIndex = 334
        Me.btoEtiqueta.TabStop = False
        Me.btoEtiqueta.Text = "Imprimir <F7>"
        Me.btoEtiqueta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoEtiqueta.UseVisualStyleBackColor = False
        '
        'btoVeiculos
        '
        Me.btoVeiculos.BackColor = System.Drawing.Color.Transparent
        Me.btoVeiculos.BackgroundImage = CType(resources.GetObject("btoVeiculos.BackgroundImage"), System.Drawing.Image)
        Me.btoVeiculos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoVeiculos.FlatAppearance.BorderSize = 0
        Me.btoVeiculos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoVeiculos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoVeiculos.ForeColor = System.Drawing.Color.White
        Me.btoVeiculos.Location = New System.Drawing.Point(604, 134)
        Me.btoVeiculos.Name = "btoVeiculos"
        Me.btoVeiculos.Size = New System.Drawing.Size(25, 25)
        Me.btoVeiculos.TabIndex = 327
        Me.btoVeiculos.TabStop = False
        Me.btoVeiculos.UseVisualStyleBackColor = False
        '
        'btoClientes
        '
        Me.btoClientes.BackColor = System.Drawing.Color.Transparent
        Me.btoClientes.BackgroundImage = CType(resources.GetObject("btoClientes.BackgroundImage"), System.Drawing.Image)
        Me.btoClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoClientes.FlatAppearance.BorderSize = 0
        Me.btoClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoClientes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoClientes.ForeColor = System.Drawing.Color.White
        Me.btoClientes.Location = New System.Drawing.Point(606, 102)
        Me.btoClientes.Name = "btoClientes"
        Me.btoClientes.Size = New System.Drawing.Size(25, 25)
        Me.btoClientes.TabIndex = 326
        Me.btoClientes.TabStop = False
        Me.btoClientes.UseVisualStyleBackColor = False
        '
        'txtObservacao
        '
        Me.txtObservacao.AcceptsReturn = True
        Me.txtObservacao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtObservacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtObservacao.Location = New System.Drawing.Point(140, 165)
        Me.txtObservacao.MaxLength = 1000
        Me.txtObservacao.Multiline = True
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacao.Size = New System.Drawing.Size(643, 273)
        Me.txtObservacao.TabIndex = 324
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(19, 165)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(111, 18)
        Me.Label16.TabIndex = 325
        Me.Label16.Text = "Observações :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(635, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 16)
        Me.Label2.TabIndex = 174
        Me.Label2.Text = "Pesquisar Veículo [F2]"
        '
        'txtVeiculo
        '
        Me.txtVeiculo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVeiculo.Location = New System.Drawing.Point(140, 133)
        Me.txtVeiculo.Name = "txtVeiculo"
        Me.txtVeiculo.ReadOnly = True
        Me.txtVeiculo.Size = New System.Drawing.Size(458, 26)
        Me.txtVeiculo.TabIndex = 172
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(55, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 19)
        Me.Label4.TabIndex = 173
        Me.Label4.Text = "Veículo :"
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
        Me.btoSalvar.Location = New System.Drawing.Point(381, 463)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(108, 72)
        Me.btoSalvar.TabIndex = 13
        Me.btoSalvar.TabStop = False
        Me.btoSalvar.Text = "Salvar <Enter>"
        Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSalvar.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.cliente_financeiro
        Me.imgLogo.Location = New System.Drawing.Point(12, 12)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 169
        Me.imgLogo.TabStop = False
        '
        'fOrdemServico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.CancelButton = Me.btoSair
        Me.ClientSize = New System.Drawing.Size(892, 554)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fOrdemServico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fCaixa"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblEmissao As System.Windows.Forms.Label
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents lblVendedor As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btoSalvar As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblLoja As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtObservacao As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btoClientes As System.Windows.Forms.Button
    Friend WithEvents btoEtiqueta As System.Windows.Forms.Button
    Friend WithEvents btoVeiculos As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVeiculo As System.Windows.Forms.TextBox
    Friend WithEvents txtControle As System.Windows.Forms.TextBox
    Friend WithEvents lblSituacao As System.Windows.Forms.Label
    Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
End Class
