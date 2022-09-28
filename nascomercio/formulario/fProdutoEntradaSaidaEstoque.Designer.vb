<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProdutoEntradaSaidaEstoque
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fProdutoEntradaSaidaEstoque))
    Me.btoAtualizar = New System.Windows.Forms.Button
    Me.btoTransferencia = New System.Windows.Forms.Button
    Me.btoPesquisar = New System.Windows.Forms.Button
    Me.btoFechar = New System.Windows.Forms.Button
    Me.lblSubTitulo = New System.Windows.Forms.Label
    Me.imgLogo = New System.Windows.Forms.PictureBox
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.txtCodigo = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtDescricao = New System.Windows.Forms.TextBox
    Me.lblNome = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.btoClonarItem = New System.Windows.Forms.Button
    Me.btoBalanco = New System.Windows.Forms.Button
    Me.dgvProduto = New System.Windows.Forms.DataGridView
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.txtNotaFiscalSerie = New System.Windows.Forms.TextBox
    Me.txtNotaFiscalNumero = New System.Windows.Forms.TextBox
    Me.Label11 = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.btoNotaFiscal = New System.Windows.Forms.Button
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgvProduto, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'btoAtualizar
    '
    Me.btoAtualizar.BackColor = System.Drawing.Color.Transparent
    Me.btoAtualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoAtualizar.FlatAppearance.BorderSize = 0
    Me.btoAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoAtualizar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoAtualizar.ForeColor = System.Drawing.Color.Black
    Me.btoAtualizar.Image = Global.nascomercio.My.Resources.Resources.confirmar
    Me.btoAtualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoAtualizar.Location = New System.Drawing.Point(312, 368)
    Me.btoAtualizar.Margin = New System.Windows.Forms.Padding(0)
    Me.btoAtualizar.Name = "btoAtualizar"
    Me.btoAtualizar.Size = New System.Drawing.Size(108, 73)
    Me.btoAtualizar.TabIndex = 4
    Me.btoAtualizar.TabStop = False
    Me.btoAtualizar.Text = "Atualizar <Enter>"
    Me.btoAtualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoAtualizar.UseVisualStyleBackColor = False
    '
    'btoTransferencia
    '
    Me.btoTransferencia.BackColor = System.Drawing.Color.Transparent
    Me.btoTransferencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoTransferencia.FlatAppearance.BorderSize = 0
    Me.btoTransferencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoTransferencia.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoTransferencia.ForeColor = System.Drawing.Color.Black
    Me.btoTransferencia.Image = Global.nascomercio.My.Resources.Resources.entrada_saida_estoque
    Me.btoTransferencia.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoTransferencia.Location = New System.Drawing.Point(647, 160)
    Me.btoTransferencia.Margin = New System.Windows.Forms.Padding(0)
    Me.btoTransferencia.Name = "btoTransferencia"
    Me.btoTransferencia.Size = New System.Drawing.Size(120, 64)
    Me.btoTransferencia.TabIndex = 7
    Me.btoTransferencia.TabStop = False
    Me.btoTransferencia.Text = "Transferência <F6>"
    Me.btoTransferencia.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoTransferencia.UseVisualStyleBackColor = False
    '
    'btoPesquisar
    '
    Me.btoPesquisar.BackColor = System.Drawing.Color.Transparent
    Me.btoPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoPesquisar.FlatAppearance.BorderSize = 0
    Me.btoPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoPesquisar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoPesquisar.ForeColor = System.Drawing.Color.Black
    Me.btoPesquisar.Image = Global.nascomercio.My.Resources.Resources.pesquisar
    Me.btoPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoPesquisar.Location = New System.Drawing.Point(657, 84)
    Me.btoPesquisar.Margin = New System.Windows.Forms.Padding(0)
    Me.btoPesquisar.Name = "btoPesquisar"
    Me.btoPesquisar.Size = New System.Drawing.Size(100, 72)
    Me.btoPesquisar.TabIndex = 6
    Me.btoPesquisar.TabStop = False
    Me.btoPesquisar.Text = "Pesquisar <F5>"
    Me.btoPesquisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoPesquisar.UseVisualStyleBackColor = False
    '
    'btoFechar
    '
    Me.btoFechar.BackColor = System.Drawing.Color.Transparent
    Me.btoFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoFechar.FlatAppearance.BorderSize = 0
    Me.btoFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoFechar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoFechar.ForeColor = System.Drawing.Color.Black
    Me.btoFechar.Image = Global.nascomercio.My.Resources.Resources.fechar
    Me.btoFechar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoFechar.Location = New System.Drawing.Point(664, 8)
    Me.btoFechar.Margin = New System.Windows.Forms.Padding(0)
    Me.btoFechar.Name = "btoFechar"
    Me.btoFechar.Size = New System.Drawing.Size(89, 71)
    Me.btoFechar.TabIndex = 5
    Me.btoFechar.TabStop = False
    Me.btoFechar.Text = "Fechar <Esc>"
    Me.btoFechar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoFechar.UseVisualStyleBackColor = False
    '
    'lblSubTitulo
    '
    Me.lblSubTitulo.AutoSize = True
    Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblSubTitulo.Location = New System.Drawing.Point(64, 32)
    Me.lblSubTitulo.Name = "lblSubTitulo"
    Me.lblSubTitulo.Size = New System.Drawing.Size(56, 14)
    Me.lblSubTitulo.TabIndex = 230
    Me.lblSubTitulo.Text = "ESTOQUE"
    '
    'imgLogo
    '
    Me.imgLogo.BackColor = System.Drawing.Color.Transparent
    Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.entrada_saida_estoque
    Me.imgLogo.Location = New System.Drawing.Point(8, 8)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(50, 50)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 229
    Me.imgLogo.TabStop = False
    '
    'lblTitulo
    '
    Me.lblTitulo.AutoSize = True
    Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
    Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblTitulo.Location = New System.Drawing.Point(64, 8)
    Me.lblTitulo.Name = "lblTitulo"
    Me.lblTitulo.Size = New System.Drawing.Size(299, 24)
    Me.lblTitulo.TabIndex = 228
    Me.lblTitulo.Text = "Entrada e Saida de Produtos"
    '
    'txtCodigo
    '
    Me.txtCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtCodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtCodigo.Location = New System.Drawing.Point(96, 80)
    Me.txtCodigo.MaxLength = 20
    Me.txtCodigo.Name = "txtCodigo"
    Me.txtCodigo.ReadOnly = True
    Me.txtCodigo.Size = New System.Drawing.Size(184, 18)
    Me.txtCodigo.TabIndex = 1
    Me.txtCodigo.TabStop = False
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.BackColor = System.Drawing.Color.Transparent
    Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label2.Location = New System.Drawing.Point(30, 80)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(59, 18)
    Me.Label2.TabIndex = 227
    Me.Label2.Text = "Código"
    '
    'txtDescricao
    '
    Me.txtDescricao.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtDescricao.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtDescricao.Location = New System.Drawing.Point(96, 104)
    Me.txtDescricao.MaxLength = 50
    Me.txtDescricao.Name = "txtDescricao"
    Me.txtDescricao.ReadOnly = True
    Me.txtDescricao.Size = New System.Drawing.Size(528, 18)
    Me.txtDescricao.TabIndex = 2
    Me.txtDescricao.TabStop = False
    '
    'lblNome
    '
    Me.lblNome.AutoSize = True
    Me.lblNome.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblNome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.lblNome.Location = New System.Drawing.Point(27, 104)
    Me.lblNome.Name = "lblNome"
    Me.lblNome.Size = New System.Drawing.Size(65, 18)
    Me.lblNome.TabIndex = 219
    Me.lblNome.Text = "Produto"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(28, 332)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(98, 14)
    Me.Label1.TabIndex = 232
    Me.Label1.Text = "Clonar Item <F1>"
    '
    'btoClonarItem
    '
    Me.btoClonarItem.BackColor = System.Drawing.Color.Transparent
    Me.btoClonarItem.BackgroundImage = CType(resources.GetObject("btoClonarItem.BackgroundImage"), System.Drawing.Image)
    Me.btoClonarItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoClonarItem.FlatAppearance.BorderSize = 0
    Me.btoClonarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoClonarItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoClonarItem.ForeColor = System.Drawing.Color.White
    Me.btoClonarItem.Location = New System.Drawing.Point(4, 324)
    Me.btoClonarItem.Name = "btoClonarItem"
    Me.btoClonarItem.Size = New System.Drawing.Size(25, 25)
    Me.btoClonarItem.TabIndex = 231
    Me.btoClonarItem.TabStop = False
    Me.btoClonarItem.UseVisualStyleBackColor = False
    '
    'btoBalanco
    '
    Me.btoBalanco.BackColor = System.Drawing.Color.Transparent
    Me.btoBalanco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
    Me.btoBalanco.FlatAppearance.BorderSize = 0
    Me.btoBalanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoBalanco.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoBalanco.ForeColor = System.Drawing.Color.Black
    Me.btoBalanco.Image = Global.nascomercio.My.Resources.Resources.balanco
    Me.btoBalanco.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoBalanco.Location = New System.Drawing.Point(658, 234)
    Me.btoBalanco.Margin = New System.Windows.Forms.Padding(0)
    Me.btoBalanco.Name = "btoBalanco"
    Me.btoBalanco.Size = New System.Drawing.Size(98, 76)
    Me.btoBalanco.TabIndex = 233
    Me.btoBalanco.TabStop = False
    Me.btoBalanco.Text = "Balanço <F8>"
    Me.btoBalanco.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoBalanco.UseVisualStyleBackColor = False
    '
    'dgvProduto
    '
    Me.dgvProduto.AllowUserToAddRows = False
    Me.dgvProduto.AllowUserToDeleteRows = False
    Me.dgvProduto.AllowUserToOrderColumns = True
    Me.dgvProduto.AllowUserToResizeColumns = False
    Me.dgvProduto.AllowUserToResizeRows = False
    Me.dgvProduto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
    Me.dgvProduto.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvProduto.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.dgvProduto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    Me.dgvProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgvProduto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
    Me.dgvProduto.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.dgvProduto.Location = New System.Drawing.Point(8, 151)
    Me.dgvProduto.Name = "dgvProduto"
    Me.dgvProduto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    Me.dgvProduto.RowHeadersVisible = False
    Me.dgvProduto.Size = New System.Drawing.Size(608, 171)
    Me.dgvProduto.TabIndex = 3
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(775, 451)
    Me.Panel1.TabIndex = 234
    '
    'txtNotaFiscalSerie
    '
    Me.txtNotaFiscalSerie.BackColor = System.Drawing.Color.White
    Me.txtNotaFiscalSerie.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtNotaFiscalSerie.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtNotaFiscalSerie.Location = New System.Drawing.Point(283, 127)
    Me.txtNotaFiscalSerie.MaxLength = 20
    Me.txtNotaFiscalSerie.Name = "txtNotaFiscalSerie"
    Me.txtNotaFiscalSerie.Size = New System.Drawing.Size(59, 18)
    Me.txtNotaFiscalSerie.TabIndex = 239
    '
    'txtNotaFiscalNumero
    '
    Me.txtNotaFiscalNumero.BackColor = System.Drawing.Color.White
    Me.txtNotaFiscalNumero.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtNotaFiscalNumero.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtNotaFiscalNumero.Location = New System.Drawing.Point(96, 127)
    Me.txtNotaFiscalNumero.MaxLength = 20
    Me.txtNotaFiscalNumero.Name = "txtNotaFiscalNumero"
    Me.txtNotaFiscalNumero.Size = New System.Drawing.Size(133, 18)
    Me.txtNotaFiscalNumero.TabIndex = 238
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.BackColor = System.Drawing.Color.Transparent
    Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label11.Location = New System.Drawing.Point(237, 127)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(46, 18)
    Me.Label11.TabIndex = 237
    Me.Label11.Text = "Série"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.BackColor = System.Drawing.Color.Transparent
    Me.Label5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
    Me.Label5.Location = New System.Drawing.Point(5, 127)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(86, 18)
    Me.Label5.TabIndex = 236
    Me.Label5.Text = "Nota Fiscal"
    '
    'btoNotaFiscal
    '
    Me.btoNotaFiscal.BackColor = System.Drawing.Color.Transparent
    Me.btoNotaFiscal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btoNotaFiscal.FlatAppearance.BorderSize = 0
    Me.btoNotaFiscal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btoNotaFiscal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btoNotaFiscal.ForeColor = System.Drawing.Color.Black
    Me.btoNotaFiscal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btoNotaFiscal.Location = New System.Drawing.Point(350, 126)
    Me.btoNotaFiscal.Margin = New System.Windows.Forms.Padding(0)
    Me.btoNotaFiscal.Name = "btoNotaFiscal"
    Me.btoNotaFiscal.Size = New System.Drawing.Size(68, 22)
    Me.btoNotaFiscal.TabIndex = 235
    Me.btoNotaFiscal.TabStop = False
    Me.btoNotaFiscal.Tag = ""
    Me.btoNotaFiscal.Text = "<ALT+F2>"
    Me.btoNotaFiscal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btoNotaFiscal.UseVisualStyleBackColor = False
    '
    'fProdutoEntradaSaidaEstoque
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(775, 451)
    Me.Controls.Add(Me.txtNotaFiscalSerie)
    Me.Controls.Add(Me.txtNotaFiscalNumero)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.btoNotaFiscal)
    Me.Controls.Add(Me.btoBalanco)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.btoClonarItem)
    Me.Controls.Add(Me.btoAtualizar)
    Me.Controls.Add(Me.btoTransferencia)
    Me.Controls.Add(Me.btoPesquisar)
    Me.Controls.Add(Me.btoFechar)
    Me.Controls.Add(Me.lblSubTitulo)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.txtCodigo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.dgvProduto)
    Me.Controls.Add(Me.txtDescricao)
    Me.Controls.Add(Me.lblNome)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "fProdutoEntradaSaidaEstoque"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "fProdutoEntradaSaidaEstoque"
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvProduto, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents btoAtualizar As System.Windows.Forms.Button
  Friend WithEvents btoTransferencia As System.Windows.Forms.Button
  Friend WithEvents btoPesquisar As System.Windows.Forms.Button
  Friend WithEvents btoFechar As System.Windows.Forms.Button
  Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
  Friend WithEvents lblNome As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btoClonarItem As System.Windows.Forms.Button
  Friend WithEvents btoBalanco As System.Windows.Forms.Button
  Friend WithEvents dgvProduto As System.Windows.Forms.DataGridView
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents txtNotaFiscalSerie As System.Windows.Forms.TextBox
  Friend WithEvents txtNotaFiscalNumero As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents btoNotaFiscal As System.Windows.Forms.Button
End Class
