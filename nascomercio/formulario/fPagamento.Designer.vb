<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPagamento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fPagamento))
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
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblLoja = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtPix = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.panelPIX = New System.Windows.Forms.Panel()
        Me.btnPix = New System.Windows.Forms.Button()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtTxId = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.picQRCode = New System.Windows.Forms.PictureBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtValorPIX = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.chkPIX = New System.Windows.Forms.CheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblVale = New System.Windows.Forms.Label()
        Me.btoSalvar = New System.Windows.Forms.Button()
        Me.txtDisponivel = New System.Windows.Forms.TextBox()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.panelLista = New System.Windows.Forms.Panel()
        Me.lstFita = New System.Windows.Forms.ListBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btoCliente = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.panelPIX.SuspendLayout()
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelLista.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(91, 15)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(232, 40)
        Me.lblTitulo.TabIndex = 20
        Me.lblTitulo.Text = "PAGAMENTO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(79, 92)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 24)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Cliente :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(553, 130)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 24)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Vendedor :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(309, 130)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 24)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Emissão :"
        '
        'lblEmissao
        '
        Me.lblEmissao.AutoSize = True
        Me.lblEmissao.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmissao.ForeColor = System.Drawing.Color.Blue
        Me.lblEmissao.Location = New System.Drawing.Point(417, 130)
        Me.lblEmissao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmissao.Name = "lblEmissao"
        Me.lblEmissao.Size = New System.Drawing.Size(110, 24)
        Me.lblEmissao.TabIndex = 31
        Me.lblEmissao.Text = "03/06/2009"
        '
        'lblFalta
        '
        Me.lblFalta.AutoSize = True
        Me.lblFalta.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFalta.ForeColor = System.Drawing.Color.Red
        Me.lblFalta.Location = New System.Drawing.Point(400, 796)
        Me.lblFalta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFalta.Name = "lblFalta"
        Me.lblFalta.Size = New System.Drawing.Size(107, 26)
        Me.lblFalta.TabIndex = 36
        Me.lblFalta.Text = "11.123,45"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(287, 796)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(102, 26)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Falta: R$"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Blue
        Me.lblTotal.Location = New System.Drawing.Point(1097, 796)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(107, 26)
        Me.lblTotal.TabIndex = 40
        Me.lblTotal.Text = "11.000,00"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(983, 796)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(103, 26)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "Total: R$"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(55, 420)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 24)
        Me.Label19.TabIndex = 41
        Me.Label19.Text = "Condicao:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(55, 539)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(138, 24)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "Desconto: R$"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(65, 457)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 24)
        Me.Label23.TabIndex = 45
        Me.Label23.Text = "Parcelas:"
        '
        'txtDesconto
        '
        Me.txtDesconto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesconto.Location = New System.Drawing.Point(215, 535)
        Me.txtDesconto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDesconto.Name = "txtDesconto"
        Me.txtDesconto.ReadOnly = True
        Me.txtDesconto.Size = New System.Drawing.Size(179, 30)
        Me.txtDesconto.TabIndex = 10
        Me.txtDesconto.Text = "0,00"
        '
        'txtParcelas
        '
        Me.txtParcelas.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParcelas.Location = New System.Drawing.Point(215, 457)
        Me.txtParcelas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtParcelas.Name = "txtParcelas"
        Me.txtParcelas.Size = New System.Drawing.Size(179, 30)
        Me.txtParcelas.TabIndex = 8
        Me.txtParcelas.Text = "1"
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendedor.ForeColor = System.Drawing.Color.Blue
        Me.lblVendedor.Location = New System.Drawing.Point(675, 130)
        Me.lblVendedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(35, 24)
        Me.lblVendedor.TabIndex = 49
        Me.lblVendedor.Text = "Eu"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(61, 130)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 24)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Controle :"
        '
        'lblControle
        '
        Me.lblControle.AutoSize = True
        Me.lblControle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblControle.ForeColor = System.Drawing.Color.Blue
        Me.lblControle.Location = New System.Drawing.Point(188, 130)
        Me.lblControle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblControle.Name = "lblControle"
        Me.lblControle.Size = New System.Drawing.Size(43, 24)
        Me.lblControle.TabIndex = 25
        Me.lblControle.Text = "123"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(68, 180)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 24)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Dinheiro: R$"
        '
        'txtDinheiro
        '
        Me.txtDinheiro.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDinheiro.Location = New System.Drawing.Point(215, 176)
        Me.txtDinheiro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDinheiro.Name = "txtDinheiro"
        Me.txtDinheiro.Size = New System.Drawing.Size(179, 30)
        Me.txtDinheiro.TabIndex = 1
        Me.txtDinheiro.Text = "0,00"
        '
        'txtCheque
        '
        Me.txtCheque.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheque.Location = New System.Drawing.Point(215, 257)
        Me.txtCheque.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Size = New System.Drawing.Size(179, 30)
        Me.txtCheque.TabIndex = 3
        Me.txtCheque.Text = "0,00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(73, 260)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 24)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Cheque: R$"
        '
        'txtCartaoDebito
        '
        Me.txtCartaoDebito.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCartaoDebito.Location = New System.Drawing.Point(215, 338)
        Me.txtCartaoDebito.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCartaoDebito.Name = "txtCartaoDebito"
        Me.txtCartaoDebito.Size = New System.Drawing.Size(179, 30)
        Me.txtCartaoDebito.TabIndex = 5
        Me.txtCartaoDebito.Text = "0,00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 338)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(178, 24)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "Cartão Débito: R$"
        '
        'txtChequePre
        '
        Me.txtChequePre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChequePre.Location = New System.Drawing.Point(215, 299)
        Me.txtChequePre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtChequePre.Name = "txtChequePre"
        Me.txtChequePre.Size = New System.Drawing.Size(179, 30)
        Me.txtChequePre.TabIndex = 4
        Me.txtChequePre.Text = "0,00"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(33, 299)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(158, 24)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "Cheque Pré: R$"
        '
        'txtCartaoCredito
        '
        Me.txtCartaoCredito.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCartaoCredito.Location = New System.Drawing.Point(215, 378)
        Me.txtCartaoCredito.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCartaoCredito.Name = "txtCartaoCredito"
        Me.txtCartaoCredito.Size = New System.Drawing.Size(179, 30)
        Me.txtCartaoCredito.TabIndex = 6
        Me.txtCartaoCredito.Text = "0,00"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(5, 378)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(186, 24)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "Cartão Crédito: R$"
        '
        'txtCrediario
        '
        Me.txtCrediario.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCrediario.Location = New System.Drawing.Point(215, 495)
        Me.txtCrediario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCrediario.Name = "txtCrediario"
        Me.txtCrediario.Size = New System.Drawing.Size(179, 30)
        Me.txtCrediario.TabIndex = 9
        Me.txtCrediario.Text = "0,00"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(60, 498)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(134, 24)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "Crediário: R$"
        '
        'cboCondicao
        '
        Me.cboCondicao.DropDownWidth = 140
        Me.cboCondicao.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCondicao.FormattingEnabled = True
        Me.cboCondicao.Location = New System.Drawing.Point(215, 417)
        Me.cboCondicao.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboCondicao.Name = "cboCondicao"
        Me.cboCondicao.Size = New System.Drawing.Size(179, 32)
        Me.cboCondicao.TabIndex = 7
        Me.cboCondicao.Text = "A VISTA"
        '
        'lblTroco
        '
        Me.lblTroco.AutoSize = True
        Me.lblTroco.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTroco.ForeColor = System.Drawing.Color.Blue
        Me.lblTroco.Location = New System.Drawing.Point(641, 796)
        Me.lblTroco.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTroco.Name = "lblTroco"
        Me.lblTroco.Size = New System.Drawing.Size(107, 26)
        Me.lblTroco.TabIndex = 120
        Me.lblTroco.Text = "11.000,00"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(517, 796)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 26)
        Me.Label14.TabIndex = 119
        Me.Label14.Text = "Troco: R$"
        '
        'lblRecebido
        '
        Me.lblRecebido.AutoSize = True
        Me.lblRecebido.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecebido.ForeColor = System.Drawing.Color.Blue
        Me.lblRecebido.Location = New System.Drawing.Point(169, 796)
        Me.lblRecebido.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRecebido.Name = "lblRecebido"
        Me.lblRecebido.Size = New System.Drawing.Size(107, 26)
        Me.lblRecebido.TabIndex = 118
        Me.lblRecebido.Text = "11.123,45"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(9, 796)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(149, 26)
        Me.Label16.TabIndex = 117
        Me.Label16.Text = "Recebido: R$"
        '
        'txtDefeitos
        '
        Me.txtDefeitos.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDefeitos.Location = New System.Drawing.Point(215, 656)
        Me.txtDefeitos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDefeitos.Name = "txtDefeitos"
        Me.txtDefeitos.ReadOnly = True
        Me.txtDefeitos.Size = New System.Drawing.Size(179, 30)
        Me.txtDefeitos.TabIndex = 13
        Me.txtDefeitos.Text = "0,00"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(69, 658)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(126, 24)
        Me.Label12.TabIndex = 126
        Me.Label12.Text = "Defeitos: R$"
        '
        'txtVale
        '
        Me.txtVale.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVale.Location = New System.Drawing.Point(215, 617)
        Me.txtVale.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtVale.Name = "txtVale"
        Me.txtVale.Size = New System.Drawing.Size(179, 30)
        Me.txtVale.TabIndex = 12
        Me.txtVale.Text = "0,00"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(109, 619)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 24)
        Me.Label15.TabIndex = 125
        Me.Label15.Text = "Vale: R$"
        '
        'txtTroca
        '
        Me.txtTroca.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTroca.Location = New System.Drawing.Point(215, 577)
        Me.txtTroca.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTroca.Name = "txtTroca"
        Me.txtTroca.ReadOnly = True
        Me.txtTroca.Size = New System.Drawing.Size(179, 30)
        Me.txtTroca.TabIndex = 11
        Me.txtTroca.Text = "0,00"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(95, 577)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(102, 24)
        Me.Label18.TabIndex = 124
        Me.Label18.Text = "Troca: R$"
        '
        'txtCliente
        '
        Me.txtCliente.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(188, 89)
        Me.txtCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(484, 30)
        Me.txtCliente.TabIndex = 0
        Me.txtCliente.Text = "Consumidor"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(713, 95)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(190, 19)
        Me.Label20.TabIndex = 162
        Me.Label20.Text = "Pesquisar Cliente <F1>"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(857, 130)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 24)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Loja :"
        '
        'lblLoja
        '
        Me.lblLoja.AutoSize = True
        Me.lblLoja.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoja.ForeColor = System.Drawing.Color.Blue
        Me.lblLoja.Location = New System.Drawing.Point(927, 130)
        Me.lblLoja.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLoja.Name = "lblLoja"
        Me.lblLoja.Size = New System.Drawing.Size(48, 24)
        Me.lblLoja.TabIndex = 33
        Me.lblLoja.Text = "ADJ"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtPix)
        Me.Panel1.Controls.Add(Me.Label47)
        Me.Panel1.Controls.Add(Me.panelPIX)
        Me.Panel1.Controls.Add(Me.chkPIX)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.lblVale)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtDinheiro)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtDesconto)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.cboCondicao)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtParcelas)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtDefeitos)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.btoSalvar)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtCheque)
        Me.Panel1.Controls.Add(Me.txtDisponivel)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.txtCartaoDebito)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.lblTroco)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.txtVale)
        Me.Panel1.Controls.Add(Me.txtChequePre)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.btoSair)
        Me.Panel1.Controls.Add(Me.lblRecebido)
        Me.Panel1.Controls.Add(Me.txtCartaoCredito)
        Me.Panel1.Controls.Add(Me.txtTroca)
        Me.Panel1.Controls.Add(Me.txtCrediario)
        Me.Panel1.Controls.Add(Me.lblFalta)
        Me.Panel1.Controls.Add(Me.lblTotal)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.panelLista)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1215, 836)
        Me.Panel1.TabIndex = 170
        '
        'txtPix
        '
        Me.txtPix.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPix.Location = New System.Drawing.Point(215, 217)
        Me.txtPix.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPix.Name = "txtPix"
        Me.txtPix.Size = New System.Drawing.Size(179, 30)
        Me.txtPix.TabIndex = 2
        Me.txtPix.Text = "0,00"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(115, 220)
        Me.Label47.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(79, 24)
        Me.Label47.TabIndex = 324
        Me.Label47.Text = "PIX: R$"
        '
        'panelPIX
        '
        Me.panelPIX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelPIX.Controls.Add(Me.btnPix)
        Me.panelPIX.Controls.Add(Me.txtStatus)
        Me.panelPIX.Controls.Add(Me.Label35)
        Me.panelPIX.Controls.Add(Me.txtTxId)
        Me.panelPIX.Controls.Add(Me.Label46)
        Me.panelPIX.Controls.Add(Me.txtObs)
        Me.panelPIX.Controls.Add(Me.Label44)
        Me.panelPIX.Controls.Add(Me.picQRCode)
        Me.panelPIX.Controls.Add(Me.Label24)
        Me.panelPIX.Controls.Add(Me.Label25)
        Me.panelPIX.Controls.Add(Me.txtValorPIX)
        Me.panelPIX.Controls.Add(Me.Label26)
        Me.panelPIX.Controls.Add(Me.Label27)
        Me.panelPIX.Controls.Add(Me.Label28)
        Me.panelPIX.Controls.Add(Me.Button1)
        Me.panelPIX.Controls.Add(Me.Label29)
        Me.panelPIX.Controls.Add(Me.Label30)
        Me.panelPIX.Controls.Add(Me.Label31)
        Me.panelPIX.Controls.Add(Me.Label32)
        Me.panelPIX.Controls.Add(Me.Label33)
        Me.panelPIX.Location = New System.Drawing.Point(487, 176)
        Me.panelPIX.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panelPIX.Name = "panelPIX"
        Me.panelPIX.Size = New System.Drawing.Size(633, 483)
        Me.panelPIX.TabIndex = 322
        Me.panelPIX.Visible = False
        '
        'btnPix
        '
        Me.btnPix.BackColor = System.Drawing.Color.Transparent
        Me.btnPix.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPix.FlatAppearance.BorderSize = 0
        Me.btnPix.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPix.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPix.ForeColor = System.Drawing.Color.Black
        Me.btnPix.Image = Global.nascomercio.My.Resources.Resources.confirmar
        Me.btnPix.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPix.Location = New System.Drawing.Point(420, 1)
        Me.btnPix.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPix.Name = "btnPix"
        Me.btnPix.Size = New System.Drawing.Size(192, 81)
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
        Me.txtStatus.Location = New System.Drawing.Point(428, 246)
        Me.txtStatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(129, 30)
        Me.txtStatus.TabIndex = 336
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(423, 219)
        Me.Label35.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(78, 24)
        Me.Label35.TabIndex = 335
        Me.Label35.Text = "Status:"
        '
        'txtTxId
        '
        Me.txtTxId.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTxId.Enabled = False
        Me.txtTxId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTxId.Location = New System.Drawing.Point(148, 90)
        Me.txtTxId.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTxId.Name = "txtTxId"
        Me.txtTxId.Size = New System.Drawing.Size(428, 23)
        Me.txtTxId.TabIndex = 334
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(56, 91)
        Me.Label46.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(60, 24)
        Me.Label46.TabIndex = 333
        Me.Label46.Text = "TxID:"
        '
        'txtObs
        '
        Me.txtObs.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObs.Location = New System.Drawing.Point(148, 129)
        Me.txtObs.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(436, 63)
        Me.txtObs.TabIndex = 330
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(64, 133)
        Me.Label44.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(56, 24)
        Me.Label44.TabIndex = 329
        Me.Label44.Text = "Obs:"
        '
        'picQRCode
        '
        Me.picQRCode.Location = New System.Drawing.Point(148, 219)
        Me.picQRCode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.picQRCode.Name = "picQRCode"
        Me.picQRCode.Size = New System.Drawing.Size(267, 246)
        Me.picQRCode.TabIndex = 324
        Me.picQRCode.TabStop = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(29, 219)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(95, 24)
        Me.Label24.TabIndex = 323
        Me.Label24.Text = "QR Code"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(19, 37)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(96, 24)
        Me.Label25.TabIndex = 322
        Me.Label25.Text = "Valor: R$"
        '
        'txtValorPIX
        '
        Me.txtValorPIX.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtValorPIX.Enabled = False
        Me.txtValorPIX.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorPIX.Location = New System.Drawing.Point(148, 37)
        Me.txtValorPIX.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtValorPIX.Name = "txtValorPIX"
        Me.txtValorPIX.Size = New System.Drawing.Size(133, 30)
        Me.txtValorPIX.TabIndex = 321
        Me.txtValorPIX.Text = "0,00"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Blue
        Me.Label26.Location = New System.Drawing.Point(868, 619)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(98, 24)
        Me.Label26.TabIndex = 310
        Me.Label26.Text = "11.000,00"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Blue
        Me.Label27.Location = New System.Drawing.Point(641, 619)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(98, 24)
        Me.Label27.TabIndex = 314
        Me.Label27.Text = "11.000,00"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(756, 619)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(95, 24)
        Me.Label28.TabIndex = 309
        Me.Label28.Text = "Total: R$"
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
        Me.Button1.Location = New System.Drawing.Point(923, 15)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 89)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Fechar <Esc>"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Blue
        Me.Label29.Location = New System.Drawing.Point(176, 619)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(98, 24)
        Me.Label29.TabIndex = 312
        Me.Label29.Text = "11.123,45"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(520, 619)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(103, 24)
        Me.Label30.TabIndex = 313
        Me.Label30.Text = "Troco: R$"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(23, 619)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(136, 24)
        Me.Label31.TabIndex = 311
        Me.Label31.Text = "Recebido: R$"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(295, 619)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(94, 24)
        Me.Label32.TabIndex = 307
        Me.Label32.Text = "Falta: R$"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Blue
        Me.Label33.Location = New System.Drawing.Point(405, 619)
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(98, 24)
        Me.Label33.TabIndex = 308
        Me.Label33.Text = "11.123,45"
        '
        'chkPIX
        '
        Me.chkPIX.AutoSize = True
        Me.chkPIX.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPIX.Location = New System.Drawing.Point(403, 220)
        Me.chkPIX.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkPIX.Name = "chkPIX"
        Me.chkPIX.Size = New System.Drawing.Size(54, 22)
        Me.chkPIX.TabIndex = 174
        Me.chkPIX.Text = "PIX"
        Me.chkPIX.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(759, 796)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(96, 26)
        Me.Label22.TabIndex = 121
        Me.Label22.Text = "Vale: R$"
        '
        'lblVale
        '
        Me.lblVale.AutoSize = True
        Me.lblVale.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVale.ForeColor = System.Drawing.Color.Blue
        Me.lblVale.Location = New System.Drawing.Point(865, 796)
        Me.lblVale.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVale.Name = "lblVale"
        Me.lblVale.Size = New System.Drawing.Size(107, 26)
        Me.lblVale.TabIndex = 122
        Me.lblVale.Text = "11.000,00"
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
        Me.btoSalvar.Location = New System.Drawing.Point(916, 689)
        Me.btoSalvar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(192, 89)
        Me.btoSalvar.TabIndex = 13
        Me.btoSalvar.TabStop = False
        Me.btoSalvar.Text = "Finalizar Venda <Enter>"
        Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSalvar.UseVisualStyleBackColor = False
        '
        'txtDisponivel
        '
        Me.txtDisponivel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDisponivel.Location = New System.Drawing.Point(1012, 346)
        Me.txtDisponivel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDisponivel.Name = "txtDisponivel"
        Me.txtDisponivel.ReadOnly = True
        Me.txtDisponivel.Size = New System.Drawing.Size(245, 15)
        Me.txtDisponivel.TabIndex = 3
        Me.txtDisponivel.TabStop = False
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
        Me.btoSair.Location = New System.Drawing.Point(1083, 14)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(117, 89)
        Me.btoSair.TabIndex = 14
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'panelLista
        '
        Me.panelLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelLista.Controls.Add(Me.lstFita)
        Me.panelLista.Controls.Add(Me.TextBox3)
        Me.panelLista.Controls.Add(Me.Label36)
        Me.panelLista.Controls.Add(Me.Label37)
        Me.panelLista.Controls.Add(Me.Label38)
        Me.panelLista.Controls.Add(Me.Button2)
        Me.panelLista.Controls.Add(Me.Label39)
        Me.panelLista.Controls.Add(Me.Label40)
        Me.panelLista.Controls.Add(Me.Label41)
        Me.panelLista.Controls.Add(Me.Label42)
        Me.panelLista.Controls.Add(Me.Label43)
        Me.panelLista.Location = New System.Drawing.Point(487, 176)
        Me.panelLista.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panelLista.Name = "panelLista"
        Me.panelLista.Size = New System.Drawing.Size(633, 483)
        Me.panelLista.TabIndex = 323
        '
        'lstFita
        '
        Me.lstFita.Font = New System.Drawing.Font("Bitstream Vera Sans Mono", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFita.FormattingEnabled = True
        Me.lstFita.ItemHeight = 16
        Me.lstFita.Location = New System.Drawing.Point(17, 4)
        Me.lstFita.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lstFita.Name = "lstFita"
        Me.lstFita.Size = New System.Drawing.Size(593, 468)
        Me.lstFita.TabIndex = 315
        Me.lstFita.TabStop = False
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Location = New System.Drawing.Point(585, 167)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(245, 15)
        Me.TextBox3.TabIndex = 3
        Me.TextBox3.TabStop = False
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Blue
        Me.Label36.Location = New System.Drawing.Point(868, 619)
        Me.Label36.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(98, 24)
        Me.Label36.TabIndex = 310
        Me.Label36.Text = "11.000,00"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Blue
        Me.Label37.Location = New System.Drawing.Point(641, 619)
        Me.Label37.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(98, 24)
        Me.Label37.TabIndex = 314
        Me.Label37.Text = "11.000,00"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(756, 619)
        Me.Label38.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(95, 24)
        Me.Label38.TabIndex = 309
        Me.Label38.Text = "Total: R$"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Image = Global.nascomercio.My.Resources.Resources.fechar
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(923, 15)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(128, 89)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Fechar <Esc>"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Blue
        Me.Label39.Location = New System.Drawing.Point(176, 619)
        Me.Label39.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(98, 24)
        Me.Label39.TabIndex = 312
        Me.Label39.Text = "11.123,45"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(520, 619)
        Me.Label40.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(103, 24)
        Me.Label40.TabIndex = 313
        Me.Label40.Text = "Troco: R$"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(23, 619)
        Me.Label41.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(136, 24)
        Me.Label41.TabIndex = 311
        Me.Label41.Text = "Recebido: R$"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(295, 619)
        Me.Label42.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(94, 24)
        Me.Label42.TabIndex = 307
        Me.Label42.Text = "Falta: R$"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Blue
        Me.Label43.Location = New System.Drawing.Point(405, 619)
        Me.Label43.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(98, 24)
        Me.Label43.TabIndex = 308
        Me.Label43.Text = "11.123,45"
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.pagamento
        Me.imgLogo.Location = New System.Drawing.Point(16, 15)
        Me.imgLogo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(67, 62)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 169
        Me.imgLogo.TabStop = False
        '
        'btoCliente
        '
        Me.btoCliente.BackColor = System.Drawing.Color.Transparent
        Me.btoCliente.BackgroundImage = CType(resources.GetObject("btoCliente.BackgroundImage"), System.Drawing.Image)
        Me.btoCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoCliente.FlatAppearance.BorderSize = 0
        Me.btoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoCliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoCliente.ForeColor = System.Drawing.Color.White
        Me.btoCliente.Location = New System.Drawing.Point(681, 90)
        Me.btoCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btoCliente.Name = "btoCliente"
        Me.btoCliente.Size = New System.Drawing.Size(33, 31)
        Me.btoCliente.TabIndex = 161
        Me.btoCliente.TabStop = False
        Me.btoCliente.UseVisualStyleBackColor = False
        '
        'fPagamento
        '
        Me.AcceptButton = Me.btoSalvar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.CancelButton = Me.btoSair
        Me.ClientSize = New System.Drawing.Size(1217, 837)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.btoCliente)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblVendedor)
        Me.Controls.Add(Me.lblLoja)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblEmissao)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblControle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "fPagamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fCaixa"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.panelPIX.ResumeLayout(False)
        Me.panelPIX.PerformLayout()
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelLista.ResumeLayout(False)
        Me.panelLista.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btoCliente As System.Windows.Forms.Button
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblLoja As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblVale As System.Windows.Forms.Label
    Friend WithEvents chkPIX As CheckBox
    Friend WithEvents panelPIX As Panel
    Friend WithEvents picQRCode As PictureBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents txtDisponivel As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents panelLista As Panel
    Friend WithEvents lstFita As ListBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label39 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents txtObs As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents txtPix As TextBox
    Friend WithEvents Label47 As Label
    Friend WithEvents txtValorPIX As TextBox
    Friend WithEvents txtTxId As TextBox
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents btnPix As Button
End Class
