<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fContasPagarForm
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
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblNome = New System.Windows.Forms.Label()
        Me.cboFornecedor = New System.Windows.Forms.ComboBox()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.txtCodigoBarras = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.txtDataEmissao = New System.Windows.Forms.MaskedTextBox()
        Me.txtDataVencimento = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtObservacao = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkAceite = New System.Windows.Forms.CheckBox()
        Me.txtDataPagamento = New System.Windows.Forms.MaskedTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtValorPago = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btoFiltro = New System.Windows.Forms.Button()
        Me.btoExcluir = New System.Windows.Forms.Button()
        Me.btoSalvar = New System.Windows.Forms.Button()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.gpbPago = New System.Windows.Forms.GroupBox()
        Me.chkPago = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbPago.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCodigo
        '
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(170, 83)
        Me.txtCodigo.MaxLength = 20
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(185, 18)
        Me.txtCodigo.TabIndex = 1
        '
        'lblNome
        '
        Me.lblNome.AutoSize = True
        Me.lblNome.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblNome.Location = New System.Drawing.Point(83, 82)
        Me.lblNome.Name = "lblNome"
        Me.lblNome.Size = New System.Drawing.Size(79, 18)
        Me.lblNome.TabIndex = 112
        Me.lblNome.Text = "Descrição"
        '
        'cboFornecedor
        '
        Me.cboFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFornecedor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cboFornecedor.FormattingEnabled = True
        Me.cboFornecedor.Items.AddRange(New Object() {"S", "N"})
        Me.cboFornecedor.Location = New System.Drawing.Point(170, 131)
        Me.cboFornecedor.Name = "cboFornecedor"
        Me.cboFornecedor.Size = New System.Drawing.Size(253, 26)
        Me.cboFornecedor.TabIndex = 3
        '
        'lblSituacao
        '
        Me.lblSituacao.AutoSize = True
        Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
        Me.lblSituacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblSituacao.Location = New System.Drawing.Point(73, 134)
        Me.lblSituacao.Name = "lblSituacao"
        Me.lblSituacao.Size = New System.Drawing.Size(91, 18)
        Me.lblSituacao.TabIndex = 111
        Me.lblSituacao.Text = "Fornecedor"
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSubTitulo.Location = New System.Drawing.Point(67, 33)
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
        Me.lblTitulo.Size = New System.Drawing.Size(165, 24)
        Me.lblTitulo.TabIndex = 109
        Me.lblTitulo.Text = "Contas a Pagar"
        '
        'txtCodigoBarras
        '
        Me.txtCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCodigoBarras.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoBarras.Location = New System.Drawing.Point(170, 107)
        Me.txtCodigoBarras.MaxLength = 50
        Me.txtCodigoBarras.Name = "txtCodigoBarras"
        Me.txtCodigoBarras.Size = New System.Drawing.Size(400, 18)
        Me.txtCodigoBarras.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(32, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 18)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "Código de Barras"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(39, 163)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 18)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "Data de Emissão"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(120, 211)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 18)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "Valor"
        '
        'txtValor
        '
        Me.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor.Location = New System.Drawing.Point(170, 211)
        Me.txtValor.MaxLength = 9
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(253, 18)
        Me.txtValor.TabIndex = 6
        '
        'txtDataEmissao
        '
        Me.txtDataEmissao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataEmissao.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataEmissao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataEmissao.Location = New System.Drawing.Point(170, 163)
        Me.txtDataEmissao.Mask = "00/00/0000"
        Me.txtDataEmissao.Name = "txtDataEmissao"
        Me.txtDataEmissao.Size = New System.Drawing.Size(93, 18)
        Me.txtDataEmissao.TabIndex = 4
        Me.txtDataEmissao.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtDataVencimento
        '
        Me.txtDataVencimento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataVencimento.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataVencimento.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataVencimento.Location = New System.Drawing.Point(170, 187)
        Me.txtDataVencimento.Mask = "00/00/0000"
        Me.txtDataVencimento.Name = "txtDataVencimento"
        Me.txtDataVencimento.Size = New System.Drawing.Size(93, 18)
        Me.txtDataVencimento.TabIndex = 5
        Me.txtDataVencimento.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label12.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(15, 187)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(148, 18)
        Me.Label12.TabIndex = 124
        Me.Label12.Text = "Data de Vencimento"
        '
        'txtObservacao
        '
        Me.txtObservacao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtObservacao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacao.Location = New System.Drawing.Point(170, 235)
        Me.txtObservacao.MaxLength = 150
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(495, 18)
        Me.txtObservacao.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label13.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(70, 235)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 18)
        Me.Label13.TabIndex = 130
        Me.Label13.Text = "Observação"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label14.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(112, 258)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 18)
        Me.Label14.TabIndex = 131
        Me.Label14.Text = "Aceite"
        '
        'chkAceite
        '
        Me.chkAceite.AutoSize = True
        Me.chkAceite.Location = New System.Drawing.Point(170, 261)
        Me.chkAceite.Name = "chkAceite"
        Me.chkAceite.Size = New System.Drawing.Size(15, 14)
        Me.chkAceite.TabIndex = 8
        Me.chkAceite.UseVisualStyleBackColor = True
        '
        'txtDataPagamento
        '
        Me.txtDataPagamento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDataPagamento.Culture = New System.Globalization.CultureInfo("")
        Me.txtDataPagamento.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDataPagamento.Location = New System.Drawing.Point(162, 26)
        Me.txtDataPagamento.Mask = "00/00/0000"
        Me.txtDataPagamento.Name = "txtDataPagamento"
        Me.txtDataPagamento.Size = New System.Drawing.Size(93, 18)
        Me.txtDataPagamento.TabIndex = 10
        Me.txtDataPagamento.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label15.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(11, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(145, 18)
        Me.Label15.TabIndex = 133
        Me.Label15.Text = "Data de Pagamento"
        '
        'txtValorPago
        '
        Me.txtValorPago.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorPago.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorPago.Location = New System.Drawing.Point(162, 50)
        Me.txtValorPago.MaxLength = 9
        Me.txtValorPago.Name = "txtValorPago"
        Me.txtValorPago.Size = New System.Drawing.Size(253, 18)
        Me.txtValorPago.TabIndex = 11
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label16.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(72, 50)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 18)
        Me.Label16.TabIndex = 136
        Me.Label16.Text = "Valor Pago"
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
        Me.btoFiltro.Location = New System.Drawing.Point(635, 83)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(100, 72)
        Me.btoFiltro.TabIndex = 15
        Me.btoFiltro.TabStop = False
        Me.btoFiltro.Text = "Pesquisar <F5>"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
        '
        'btoExcluir
        '
        Me.btoExcluir.BackColor = System.Drawing.Color.Transparent
        Me.btoExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoExcluir.FlatAppearance.BorderSize = 0
        Me.btoExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoExcluir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoExcluir.ForeColor = System.Drawing.Color.Black
        Me.btoExcluir.Image = Global.nascomercio.My.Resources.Resources.excluir
        Me.btoExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btoExcluir.Location = New System.Drawing.Point(388, 398)
        Me.btoExcluir.Name = "btoExcluir"
        Me.btoExcluir.Size = New System.Drawing.Size(96, 72)
        Me.btoExcluir.TabIndex = 13
        Me.btoExcluir.TabStop = False
        Me.btoExcluir.Text = "Excluir <F12>"
        Me.btoExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoExcluir.UseVisualStyleBackColor = False
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
        Me.btoSalvar.Location = New System.Drawing.Point(275, 398)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(92, 72)
        Me.btoSalvar.TabIndex = 12
        Me.btoSalvar.TabStop = False
        Me.btoSalvar.Text = "Salvar <Enter>"
        Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSalvar.UseVisualStyleBackColor = False
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
        Me.btoSair.Location = New System.Drawing.Point(635, 8)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(100, 72)
        Me.btoSair.TabIndex = 14
        Me.btoSair.TabStop = False
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.cifrao_peq
        Me.imgLogo.Location = New System.Drawing.Point(8, 8)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 108
        Me.imgLogo.TabStop = False
        '
        'gpbPago
        '
        Me.gpbPago.Controls.Add(Me.txtValorPago)
        Me.gpbPago.Controls.Add(Me.txtDataPagamento)
        Me.gpbPago.Controls.Add(Me.Label16)
        Me.gpbPago.Controls.Add(Me.Label15)
        Me.gpbPago.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.gpbPago.Location = New System.Drawing.Point(8, 298)
        Me.gpbPago.Name = "gpbPago"
        Me.gpbPago.Size = New System.Drawing.Size(727, 83)
        Me.gpbPago.TabIndex = 137
        Me.gpbPago.TabStop = False
        Me.gpbPago.Text = "Baixa / Pagamento"
        '
        'chkPago
        '
        Me.chkPago.AutoSize = True
        Me.chkPago.Location = New System.Drawing.Point(170, 282)
        Me.chkPago.Name = "chkPago"
        Me.chkPago.Size = New System.Drawing.Size(15, 14)
        Me.chkPago.TabIndex = 9
        Me.chkPago.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(120, 279)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 18)
        Me.Label2.TabIndex = 138
        Me.Label2.Text = "Pago"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblNome)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(745, 478)
        Me.Panel1.TabIndex = 171
        '
        'fContasPagarForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(745, 478)
        Me.Controls.Add(Me.chkPago)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkAceite)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtObservacao)
        Me.Controls.Add(Me.txtDataVencimento)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtDataEmissao)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.txtCodigoBarras)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btoFiltro)
        Me.Controls.Add(Me.btoExcluir)
        Me.Controls.Add(Me.btoSalvar)
        Me.Controls.Add(Me.btoSair)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.cboFornecedor)
        Me.Controls.Add(Me.lblSituacao)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.gpbPago)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fContasPagarForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fContasPagarForm"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbPago.ResumeLayout(False)
        Me.gpbPago.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
  Friend WithEvents btoFiltro As System.Windows.Forms.Button
  Friend WithEvents btoExcluir As System.Windows.Forms.Button
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
  Friend WithEvents lblNome As System.Windows.Forms.Label
  Friend WithEvents cboFornecedor As System.Windows.Forms.ComboBox
  Friend WithEvents lblSituacao As System.Windows.Forms.Label
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents txtCodigoBarras As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents txtValor As System.Windows.Forms.TextBox
  Friend WithEvents txtDataEmissao As System.Windows.Forms.MaskedTextBox
  Friend WithEvents txtDataVencimento As System.Windows.Forms.MaskedTextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents txtObservacao As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents chkAceite As System.Windows.Forms.CheckBox
  Friend WithEvents txtDataPagamento As System.Windows.Forms.MaskedTextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents txtValorPago As System.Windows.Forms.TextBox
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents gpbPago As System.Windows.Forms.GroupBox
  Friend WithEvents chkPago As System.Windows.Forms.CheckBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
