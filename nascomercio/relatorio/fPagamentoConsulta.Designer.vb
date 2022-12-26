<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPagamentoConsulta
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblEmissao = New System.Windows.Forms.Label()
        Me.lblFalta = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtDesconto = New System.Windows.Forms.TextBox()
        Me.txtParcelas = New System.Windows.Forms.TextBox()
        Me.lblVendedor = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblControle = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDinheiro = New System.Windows.Forms.TextBox()
        Me.txtCheque = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCartaoDebito = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtChequePre = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCartaoCredito = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCrediario = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lstFita = New System.Windows.Forms.ListBox()
        Me.cboCondicao = New System.Windows.Forms.ComboBox()
        Me.lblTroco = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblRecebido = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDefeitos = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtVale = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTroca = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.btoSalvar = New System.Windows.Forms.Button()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblLoja = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblVale = New System.Windows.Forms.Label()
        Me.txtPix = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(68, 12)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(110, 32)
        Me.lblTitulo.TabIndex = 20
        Me.lblTitulo.Text = "VENDA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(59, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 19)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Cliente :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(440, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 19)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Vendedor :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(221, 105)
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
        Me.lblEmissao.Location = New System.Drawing.Point(312, 105)
        Me.lblEmissao.Name = "lblEmissao"
        Me.lblEmissao.Size = New System.Drawing.Size(89, 19)
        Me.lblEmissao.TabIndex = 31
        Me.lblEmissao.Text = "03/06/2009"
        '
        'lblFalta
        '
        Me.lblFalta.AutoSize = True
        Me.lblFalta.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFalta.ForeColor = System.Drawing.Color.Red
        Me.lblFalta.Location = New System.Drawing.Point(301, 608)
        Me.lblFalta.Name = "lblFalta"
        Me.lblFalta.Size = New System.Drawing.Size(81, 19)
        Me.lblFalta.TabIndex = 36
        Me.lblFalta.Text = "11.123,45"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(216, 608)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 19)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Falta: R$"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Blue
        Me.lblTotal.Location = New System.Drawing.Point(824, 608)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(81, 19)
        Me.lblTotal.TabIndex = 40
        Me.lblTotal.Text = "11.000,00"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(738, 608)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 19)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "Total: R$"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(61, 340)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(89, 19)
        Me.Label19.TabIndex = 41
        Me.Label19.Text = "Condicao:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(36, 433)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(114, 19)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "Desconto: R$"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(69, 372)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(81, 19)
        Me.Label23.TabIndex = 45
        Me.Label23.Text = "Parcelas:"
        '
        'txtDesconto
        '
        Me.txtDesconto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesconto.Location = New System.Drawing.Point(160, 433)
        Me.txtDesconto.Name = "txtDesconto"
        Me.txtDesconto.ReadOnly = True
        Me.txtDesconto.Size = New System.Drawing.Size(135, 26)
        Me.txtDesconto.TabIndex = 9
        Me.txtDesconto.Text = "0,00"
        '
        'txtParcelas
        '
        Me.txtParcelas.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParcelas.Location = New System.Drawing.Point(160, 369)
        Me.txtParcelas.Name = "txtParcelas"
        Me.txtParcelas.ReadOnly = True
        Me.txtParcelas.Size = New System.Drawing.Size(135, 26)
        Me.txtParcelas.TabIndex = 7
        Me.txtParcelas.Text = "1"
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendedor.ForeColor = System.Drawing.Color.Blue
        Me.lblVendedor.Location = New System.Drawing.Point(539, 105)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(30, 19)
        Me.lblVendedor.TabIndex = 49
        Me.lblVendedor.Text = "Eu"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 19)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Controle :"
        '
        'lblControle
        '
        Me.lblControle.AutoSize = True
        Me.lblControle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblControle.ForeColor = System.Drawing.Color.Blue
        Me.lblControle.Location = New System.Drawing.Point(141, 106)
        Me.lblControle.Name = "lblControle"
        Me.lblControle.Size = New System.Drawing.Size(36, 19)
        Me.lblControle.TabIndex = 25
        Me.lblControle.Text = "123"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 19)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Dinheiro: R$"
        '
        'txtDinheiro
        '
        Me.txtDinheiro.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDinheiro.Location = New System.Drawing.Point(161, 143)
        Me.txtDinheiro.Name = "txtDinheiro"
        Me.txtDinheiro.ReadOnly = True
        Me.txtDinheiro.Size = New System.Drawing.Size(135, 26)
        Me.txtDinheiro.TabIndex = 1
        Me.txtDinheiro.Text = "0,00"
        '
        'txtCheque
        '
        Me.txtCheque.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheque.Location = New System.Drawing.Point(160, 207)
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.ReadOnly = True
        Me.txtCheque.Size = New System.Drawing.Size(135, 26)
        Me.txtCheque.TabIndex = 2
        Me.txtCheque.Text = "0,00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(54, 207)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 19)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Cheque: R$"
        '
        'txtCartaoDebito
        '
        Me.txtCartaoDebito.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCartaoDebito.Location = New System.Drawing.Point(160, 273)
        Me.txtCartaoDebito.Name = "txtCartaoDebito"
        Me.txtCartaoDebito.ReadOnly = True
        Me.txtCartaoDebito.Size = New System.Drawing.Size(135, 26)
        Me.txtCartaoDebito.TabIndex = 4
        Me.txtCartaoDebito.Text = "0,00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 273)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(145, 19)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "Cartão Débito: R$"
        '
        'txtChequePre
        '
        Me.txtChequePre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChequePre.Location = New System.Drawing.Point(160, 241)
        Me.txtChequePre.Name = "txtChequePre"
        Me.txtChequePre.ReadOnly = True
        Me.txtChequePre.Size = New System.Drawing.Size(135, 26)
        Me.txtChequePre.TabIndex = 3
        Me.txtChequePre.Text = "0,00"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(20, 241)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 19)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "Cheque Pré: R$"
        '
        'txtCartaoCredito
        '
        Me.txtCartaoCredito.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCartaoCredito.Location = New System.Drawing.Point(160, 305)
        Me.txtCartaoCredito.Name = "txtCartaoCredito"
        Me.txtCartaoCredito.ReadOnly = True
        Me.txtCartaoCredito.Size = New System.Drawing.Size(135, 26)
        Me.txtCartaoCredito.TabIndex = 5
        Me.txtCartaoCredito.Text = "0,00"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(-1, 305)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(151, 19)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "Cartão Crédito: R$"
        '
        'txtCrediario
        '
        Me.txtCrediario.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCrediario.Location = New System.Drawing.Point(160, 400)
        Me.txtCrediario.Name = "txtCrediario"
        Me.txtCrediario.ReadOnly = True
        Me.txtCrediario.Size = New System.Drawing.Size(135, 26)
        Me.txtCrediario.TabIndex = 8
        Me.txtCrediario.Text = "0,00"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(40, 403)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 19)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "Crediário: R$"
        '
        'lstFita
        '
        Me.lstFita.Font = New System.Drawing.Font("Bitstream Vera Sans Mono", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFita.FormattingEnabled = True
        Me.lstFita.Location = New System.Drawing.Point(445, 144)
        Me.lstFita.Name = "lstFita"
        Me.lstFita.Size = New System.Drawing.Size(343, 381)
        Me.lstFita.TabIndex = 15
        Me.lstFita.TabStop = False
        '
        'cboCondicao
        '
        Me.cboCondicao.DropDownWidth = 140
        Me.cboCondicao.Enabled = False
        Me.cboCondicao.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCondicao.FormattingEnabled = True
        Me.cboCondicao.Location = New System.Drawing.Point(160, 337)
        Me.cboCondicao.Name = "cboCondicao"
        Me.cboCondicao.Size = New System.Drawing.Size(135, 27)
        Me.cboCondicao.TabIndex = 6
        Me.cboCondicao.Text = "A VISTA"
        '
        'lblTroco
        '
        Me.lblTroco.AutoSize = True
        Me.lblTroco.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTroco.ForeColor = System.Drawing.Color.Blue
        Me.lblTroco.Location = New System.Drawing.Point(482, 608)
        Me.lblTroco.Name = "lblTroco"
        Me.lblTroco.Size = New System.Drawing.Size(81, 19)
        Me.lblTroco.TabIndex = 120
        Me.lblTroco.Text = "11.000,00"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(389, 608)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(86, 19)
        Me.Label14.TabIndex = 119
        Me.Label14.Text = "Troco: R$"
        '
        'lblRecebido
        '
        Me.lblRecebido.AutoSize = True
        Me.lblRecebido.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecebido.ForeColor = System.Drawing.Color.Blue
        Me.lblRecebido.Location = New System.Drawing.Point(128, 608)
        Me.lblRecebido.Name = "lblRecebido"
        Me.lblRecebido.Size = New System.Drawing.Size(81, 19)
        Me.lblRecebido.TabIndex = 118
        Me.lblRecebido.Text = "11.123,45"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(8, 608)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(114, 19)
        Me.Label16.TabIndex = 117
        Me.Label16.Text = "Recebido: R$"
        '
        'txtDefeitos
        '
        Me.txtDefeitos.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDefeitos.Location = New System.Drawing.Point(160, 531)
        Me.txtDefeitos.Name = "txtDefeitos"
        Me.txtDefeitos.ReadOnly = True
        Me.txtDefeitos.Size = New System.Drawing.Size(135, 26)
        Me.txtDefeitos.TabIndex = 12
        Me.txtDefeitos.Text = "0,00"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(47, 531)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 19)
        Me.Label12.TabIndex = 126
        Me.Label12.Text = "Defeitos: R$"
        '
        'txtVale
        '
        Me.txtVale.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVale.Location = New System.Drawing.Point(160, 499)
        Me.txtVale.Name = "txtVale"
        Me.txtVale.ReadOnly = True
        Me.txtVale.Size = New System.Drawing.Size(135, 26)
        Me.txtVale.TabIndex = 11
        Me.txtVale.Text = "0,00"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(78, 499)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 19)
        Me.Label15.TabIndex = 125
        Me.Label15.Text = "Vale: R$"
        '
        'txtTroca
        '
        Me.txtTroca.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTroca.Location = New System.Drawing.Point(160, 467)
        Me.txtTroca.Name = "txtTroca"
        Me.txtTroca.ReadOnly = True
        Me.txtTroca.Size = New System.Drawing.Size(135, 26)
        Me.txtTroca.TabIndex = 10
        Me.txtTroca.Text = "0,00"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(67, 467)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 19)
        Me.Label18.TabIndex = 124
        Me.Label18.Text = "Troca: R$"
        '
        'txtCliente
        '
        Me.txtCliente.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(141, 72)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(364, 26)
        Me.txtCliente.TabIndex = 0
        Me.txtCliente.Text = "Consumidor"
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
        Me.btoSalvar.Location = New System.Drawing.Point(643, 533)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(144, 72)
        Me.btoSalvar.TabIndex = 13
        Me.btoSalvar.TabStop = False
        Me.btoSalvar.Text = "Imprimir <Enter>"
        Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSalvar.UseVisualStyleBackColor = False
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
        Me.btoSair.Location = New System.Drawing.Point(812, 11)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(88, 72)
        Me.btoSair.TabIndex = 14
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.pagamento
        Me.imgLogo.Location = New System.Drawing.Point(12, 12)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 169
        Me.imgLogo.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(675, 105)
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
        Me.lblLoja.Location = New System.Drawing.Point(734, 105)
        Me.lblLoja.Name = "lblLoja"
        Me.lblLoja.Size = New System.Drawing.Size(41, 19)
        Me.lblLoja.TabIndex = 33
        Me.lblLoja.Text = "ADJ"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtPix)
        Me.Panel1.Controls.Add(Me.Label47)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.lblVale)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.txtDinheiro)
        Me.Panel1.Controls.Add(Me.txtDesconto)
        Me.Panel1.Controls.Add(Me.cboCondicao)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.txtParcelas)
        Me.Panel1.Controls.Add(Me.txtDefeitos)
        Me.Panel1.Controls.Add(Me.btoSalvar)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtCheque)
        Me.Panel1.Controls.Add(Me.txtCartaoDebito)
        Me.Panel1.Controls.Add(Me.lblTroco)
        Me.Panel1.Controls.Add(Me.lblVendedor)
        Me.Panel1.Controls.Add(Me.txtVale)
        Me.Panel1.Controls.Add(Me.txtChequePre)
        Me.Panel1.Controls.Add(Me.lblEmissao)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.btoSair)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.lblLoja)
        Me.Panel1.Controls.Add(Me.lblRecebido)
        Me.Panel1.Controls.Add(Me.txtCartaoCredito)
        Me.Panel1.Controls.Add(Me.txtTroca)
        Me.Panel1.Controls.Add(Me.txtCrediario)
        Me.Panel1.Controls.Add(Me.lblFalta)
        Me.Panel1.Controls.Add(Me.lblTotal)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(912, 637)
        Me.Panel1.TabIndex = 170
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(570, 608)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(73, 19)
        Me.Label22.TabIndex = 121
        Me.Label22.Text = "Vale: R$"
        '
        'lblVale
        '
        Me.lblVale.AutoSize = True
        Me.lblVale.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVale.ForeColor = System.Drawing.Color.Blue
        Me.lblVale.Location = New System.Drawing.Point(650, 608)
        Me.lblVale.Name = "lblVale"
        Me.lblVale.Size = New System.Drawing.Size(81, 19)
        Me.lblVale.TabIndex = 122
        Me.lblVale.Text = "11.000,00"
        '
        'txtPix
        '
        Me.txtPix.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPix.Location = New System.Drawing.Point(160, 175)
        Me.txtPix.Name = "txtPix"
        Me.txtPix.Size = New System.Drawing.Size(135, 26)
        Me.txtPix.TabIndex = 325
        Me.txtPix.Text = "0,00"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(84, 175)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(66, 19)
        Me.Label47.TabIndex = 326
        Me.Label47.Text = "PIX: R$"
        '
        'fPagamentoConsulta
        '
        Me.AcceptButton = Me.btoSalvar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.CancelButton = Me.btoSair
        Me.ClientSize = New System.Drawing.Size(913, 637)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.lstFita)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblControle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fPagamentoConsulta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fCaixa"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents lblEmissao As System.Windows.Forms.Label
  Friend WithEvents lblFalta As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents lblTotal As System.Windows.Forms.Label
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents txtDesconto As System.Windows.Forms.TextBox
  Friend WithEvents txtParcelas As System.Windows.Forms.TextBox
  Friend WithEvents lblVendedor As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents lblControle As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtDinheiro As System.Windows.Forms.TextBox
  Friend WithEvents txtCheque As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtCartaoDebito As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents txtChequePre As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents txtCartaoCredito As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents txtCrediario As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents lstFita As System.Windows.Forms.ListBox
  Friend WithEvents cboCondicao As System.Windows.Forms.ComboBox
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents lblTroco As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents lblRecebido As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents txtDefeitos As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents txtVale As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents txtTroca As System.Windows.Forms.TextBox
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents txtCliente As System.Windows.Forms.TextBox
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents lblLoja As System.Windows.Forms.Label
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents lblVale As System.Windows.Forms.Label
    Friend WithEvents txtPix As TextBox
    Friend WithEvents Label47 As Label
End Class
