<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fChequesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fChequesForm))
        Me.lblCliCadastro = New System.Windows.Forms.Label
        Me.txtControle = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.dgvCheques = New System.Windows.Forms.DataGridView
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataEmissao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vencimento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Banco = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Agencia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Conta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblVendedor = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblFalta = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.lblLoja = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btoIncluirItem = New System.Windows.Forms.Button
        Me.btoExcluirItem = New System.Windows.Forms.Button
        Me.imgCliLogo = New System.Windows.Forms.PictureBox
        Me.btoSair = New System.Windows.Forms.Button
        Me.btoSalvar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        CType(Me.dgvCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCliCadastro
        '
        Me.lblCliCadastro.AutoSize = True
        Me.lblCliCadastro.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblCliCadastro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCliCadastro.Location = New System.Drawing.Point(64, 8)
        Me.lblCliCadastro.Name = "lblCliCadastro"
        Me.lblCliCadastro.Size = New System.Drawing.Size(100, 24)
        Me.lblCliCadastro.TabIndex = 230
        Me.lblCliCadastro.Text = "Cheques"
        '
        'txtControle
        '
        Me.txtControle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtControle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtControle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtControle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtControle.Location = New System.Drawing.Point(128, 108)
        Me.txtControle.Name = "txtControle"
        Me.txtControle.ReadOnly = True
        Me.txtControle.Size = New System.Drawing.Size(174, 18)
        Me.txtControle.TabIndex = 1
        Me.txtControle.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(48, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 18)
        Me.Label3.TabIndex = 176
        Me.Label3.Text = "Controle"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(11, 141)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(105, 18)
        Me.Label23.TabIndex = 289
        Me.Label23.Text = "Valor Total R$"
        '
        'dgvCheques
        '
        Me.dgvCheques.AllowUserToAddRows = False
        Me.dgvCheques.AllowUserToResizeColumns = False
        Me.dgvCheques.AllowUserToResizeRows = False
        Me.dgvCheques.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvCheques.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvCheques.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCheques.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCheques.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.DataEmissao, Me.Vencimento, Me.Valor, Me.Banco, Me.Agencia, Me.Conta, Me.Numero})
        Me.dgvCheques.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.dgvCheques.Location = New System.Drawing.Point(14, 208)
        Me.dgvCheques.Name = "dgvCheques"
        Me.dgvCheques.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvCheques.RowHeadersVisible = False
        Me.dgvCheques.Size = New System.Drawing.Size(744, 372)
        Me.dgvCheques.TabIndex = 5
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 84
        '
        'DataEmissao
        '
        Me.DataEmissao.HeaderText = "Data Emissão"
        Me.DataEmissao.Name = "DataEmissao"
        Me.DataEmissao.ReadOnly = True
        Me.DataEmissao.Width = 117
        '
        'Vencimento
        '
        Me.Vencimento.HeaderText = "Data Depósito"
        Me.Vencimento.Name = "Vencimento"
        Me.Vencimento.Width = 122
        '
        'Valor
        '
        Me.Valor.HeaderText = "Valor"
        Me.Valor.Name = "Valor"
        Me.Valor.Width = 68
        '
        'Banco
        '
        Me.Banco.HeaderText = "Banco"
        Me.Banco.Name = "Banco"
        Me.Banco.Width = 78
        '
        'Agencia
        '
        Me.Agencia.HeaderText = "Agência"
        Me.Agencia.Name = "Agencia"
        Me.Agencia.Width = 89
        '
        'Conta
        '
        Me.Conta.HeaderText = "Conta"
        Me.Conta.Name = "Conta"
        Me.Conta.Width = 75
        '
        'Numero
        '
        Me.Numero.HeaderText = "Número"
        Me.Numero.Name = "Numero"
        Me.Numero.Width = 89
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendedor.ForeColor = System.Drawing.Color.Blue
        Me.lblVendedor.Location = New System.Drawing.Point(124, 77)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(30, 19)
        Me.lblVendedor.TabIndex = 300
        Me.lblVendedor.Text = "Eu"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(34, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 19)
        Me.Label5.TabIndex = 299
        Me.Label5.Text = "Vendedor"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCliente.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCliente.Location = New System.Drawing.Point(402, 109)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(184, 18)
        Me.txtCliente.TabIndex = 298
        Me.txtCliente.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(333, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 18)
        Me.Label2.TabIndex = 297
        Me.Label2.Text = "Cliente"
        '
        'lblFalta
        '
        Me.lblFalta.AutoSize = True
        Me.lblFalta.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFalta.ForeColor = System.Drawing.Color.Red
        Me.lblFalta.Location = New System.Drawing.Point(397, 140)
        Me.lblFalta.Name = "lblFalta"
        Me.lblFalta.Size = New System.Drawing.Size(79, 19)
        Me.lblFalta.TabIndex = 295
        Me.lblFalta.Text = "11.123,45"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(320, 140)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 19)
        Me.Label13.TabIndex = 294
        Me.Label13.Text = "Falta R$"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Blue
        Me.lblTotal.Location = New System.Drawing.Point(124, 141)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(87, 19)
        Me.lblTotal.TabIndex = 293
        Me.lblTotal.Text = "111.000,00"
        '
        'lblLoja
        '
        Me.lblLoja.AutoSize = True
        Me.lblLoja.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoja.ForeColor = System.Drawing.Color.Blue
        Me.lblLoja.Location = New System.Drawing.Point(398, 78)
        Me.lblLoja.Name = "lblLoja"
        Me.lblLoja.Size = New System.Drawing.Size(41, 19)
        Me.lblLoja.TabIndex = 302
        Me.lblLoja.Text = "ADJ"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(350, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 19)
        Me.Label9.TabIndex = 301
        Me.Label9.Text = "Loja"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(795, 241)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 14)
        Me.Label4.TabIndex = 307
        Me.Label4.Text = "Excluir Item [F2]"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(795, 218)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 14)
        Me.Label6.TabIndex = 306
        Me.Label6.Text = "Incluir Item [F1]"
        '
        'btoIncluirItem
        '
        Me.btoIncluirItem.BackColor = System.Drawing.Color.Transparent
        Me.btoIncluirItem.BackgroundImage = CType(resources.GetObject("btoIncluirItem.BackgroundImage"), System.Drawing.Image)
        Me.btoIncluirItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoIncluirItem.FlatAppearance.BorderSize = 0
        Me.btoIncluirItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoIncluirItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoIncluirItem.ForeColor = System.Drawing.Color.White
        Me.btoIncluirItem.Location = New System.Drawing.Point(764, 210)
        Me.btoIncluirItem.Name = "btoIncluirItem"
        Me.btoIncluirItem.Size = New System.Drawing.Size(25, 25)
        Me.btoIncluirItem.TabIndex = 304
        Me.btoIncluirItem.TabStop = False
        Me.btoIncluirItem.UseVisualStyleBackColor = False
        '
        'btoExcluirItem
        '
        Me.btoExcluirItem.BackColor = System.Drawing.Color.Transparent
        Me.btoExcluirItem.BackgroundImage = CType(resources.GetObject("btoExcluirItem.BackgroundImage"), System.Drawing.Image)
        Me.btoExcluirItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btoExcluirItem.FlatAppearance.BorderSize = 0
        Me.btoExcluirItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btoExcluirItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btoExcluirItem.ForeColor = System.Drawing.Color.White
        Me.btoExcluirItem.Location = New System.Drawing.Point(764, 241)
        Me.btoExcluirItem.Name = "btoExcluirItem"
        Me.btoExcluirItem.Size = New System.Drawing.Size(25, 25)
        Me.btoExcluirItem.TabIndex = 305
        Me.btoExcluirItem.TabStop = False
        Me.btoExcluirItem.UseVisualStyleBackColor = False
        '
        'imgCliLogo
        '
        Me.imgCliLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgCliLogo.Image = Global.nascomercio.My.Resources.Resources.cheque
        Me.imgCliLogo.Location = New System.Drawing.Point(8, 8)
        Me.imgCliLogo.Name = "imgCliLogo"
        Me.imgCliLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgCliLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCliLogo.TabIndex = 211
        Me.imgCliLogo.TabStop = False
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
        Me.btoSair.Location = New System.Drawing.Point(769, 12)
        Me.btoSair.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(88, 72)
        Me.btoSair.TabIndex = 8
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
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
        Me.btoSalvar.Location = New System.Drawing.Point(342, 600)
        Me.btoSalvar.Name = "btoSalvar"
        Me.btoSalvar.Size = New System.Drawing.Size(102, 72)
        Me.btoSalvar.TabIndex = 6
        Me.btoSalvar.Text = "Salvar <Enter>"
        Me.btoSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSalvar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btoIncluirItem)
        Me.Panel1.Controls.Add(Me.lblTotal)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblFalta)
        Me.Panel1.Controls.Add(Me.btoExcluirItem)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.txtControle)
        Me.Panel1.Controls.Add(Me.lblVendedor)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dgvCheques)
        Me.Panel1.Controls.Add(Me.btoSair)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(898, 680)
        Me.Panel1.TabIndex = 308
        '
        'fChequesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(900, 680)
        Me.Controls.Add(Me.lblLoja)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblCliCadastro)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.imgCliLogo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btoSalvar)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "fChequesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cheques"
        CType(Me.dgvCheques, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgCliLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
  Friend WithEvents lblCliCadastro As System.Windows.Forms.Label
  Friend WithEvents btoSalvar As System.Windows.Forms.Button
  Friend WithEvents imgCliLogo As System.Windows.Forms.PictureBox
  Friend WithEvents txtControle As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents btoSair As System.Windows.Forms.Button
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents dgvCheques As System.Windows.Forms.DataGridView
  Friend WithEvents lblTotal As System.Windows.Forms.Label
  Friend WithEvents lblFalta As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtCliente As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents lblVendedor As System.Windows.Forms.Label
  Friend WithEvents lblLoja As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents btoIncluirItem As System.Windows.Forms.Button
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents btoExcluirItem As System.Windows.Forms.Button
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents DataEmissao As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Vencimento As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Banco As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Agencia As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Conta As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
