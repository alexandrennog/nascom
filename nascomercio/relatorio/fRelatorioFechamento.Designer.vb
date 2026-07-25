<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fRelatorioFechamento
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.v_fechamentoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.nascomercioDataSet = New nascomercio.nascomercioDataSet()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btoFiltro = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.rptFechamento = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCaixa = New System.Windows.Forms.TextBox()
        Me.lblProduto = New System.Windows.Forms.Label()
        Me.v_fechamentoTableAdapter = New nascomercio.nascomercioDataSetTableAdapters.v_fechamentoTableAdapter()
        Me.txtDataInicial = New System.Windows.Forms.MaskedTextBox()
        Me.txtDataFinal = New System.Windows.Forms.MaskedTextBox()
        CType(Me.v_fechamentoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nascomercioDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'v_fechamentoBindingSource
        '
        Me.v_fechamentoBindingSource.DataMember = "v_fechamento"
        Me.v_fechamentoBindingSource.DataSource = Me.nascomercioDataSet
        '
        'nascomercioDataSet
        '
        Me.nascomercioDataSet.DataSetName = "nascomercioDataSet"
        Me.nascomercioDataSet.EnforceConstraints = False
        Me.nascomercioDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSubTitulo.Location = New System.Drawing.Point(64, 34)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(38, 14)
        Me.lblSubTitulo.TabIndex = 138
        Me.lblSubTitulo.Text = "LISTA"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(64, 10)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(357, 24)
        Me.lblTitulo.TabIndex = 136
        Me.lblTitulo.Text = "Relatório de Fechamento do Caixa"
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
        Me.btoFiltro.Location = New System.Drawing.Point(819, 12)
        Me.btoFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.btoFiltro.Name = "btoFiltro"
        Me.btoFiltro.Size = New System.Drawing.Size(72, 84)
        Me.btoFiltro.TabIndex = 139
        Me.btoFiltro.Text = "Pesquisar [F5]"
        Me.btoFiltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoFiltro.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.Transparent
        Me.imgLogo.Image = Global.nascomercio.My.Resources.Resources.relatorio
        Me.imgLogo.Location = New System.Drawing.Point(8, 10)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(50, 50)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 137
        Me.imgLogo.TabStop = False
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
        Me.btoSair.Location = New System.Drawing.Point(894, 12)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(57, 84)
        Me.btoSair.TabIndex = 134
        Me.btoSair.Text = "Fechar <Esc>"
        Me.btoSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btoSair.UseVisualStyleBackColor = False
        '
        'rptFechamento
        '
        ReportDataSource1.Name = "nascomercioDataSet_v_fechamento"
        ReportDataSource1.Value = Me.v_fechamentoBindingSource
        Me.rptFechamento.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rptFechamento.LocalReport.ReportEmbeddedResource = "nascomercio.Fechamento.rdlc"
        Me.rptFechamento.Location = New System.Drawing.Point(3, 106)
        Me.rptFechamento.Name = "rptFechamento"
        Me.rptFechamento.ServerReport.BearerToken = Nothing
        Me.rptFechamento.Size = New System.Drawing.Size(950, 489)
        Me.rptFechamento.TabIndex = 140
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(65, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 18)
        Me.Label4.TabIndex = 204
        Me.Label4.Text = "Período: de"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(267, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 18)
        Me.Label1.TabIndex = 206
        Me.Label1.Text = "até"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCaixa
        '
        Me.txtCaixa.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCaixa.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCaixa.Location = New System.Drawing.Point(519, 80)
        Me.txtCaixa.MaxLength = 20
        Me.txtCaixa.Name = "txtCaixa"
        Me.txtCaixa.Size = New System.Drawing.Size(212, 18)
        Me.txtCaixa.TabIndex = 208
        '
        'lblProduto
        '
        Me.lblProduto.AutoSize = True
        Me.lblProduto.BackColor = System.Drawing.Color.Transparent
        Me.lblProduto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblProduto.Location = New System.Drawing.Point(462, 80)
        Me.lblProduto.Name = "lblProduto"
        Me.lblProduto.Size = New System.Drawing.Size(51, 18)
        Me.lblProduto.TabIndex = 209
        Me.lblProduto.Text = "Caixa:"
        '
        'v_fechamentoTableAdapter
        '
        Me.v_fechamentoTableAdapter.ClearBeforeFill = True
        '
        'txtDataInicial
        '
        Me.txtDataInicial.Location = New System.Drawing.Point(161, 78)
        Me.txtDataInicial.Mask = "00/00/0000"
        Me.txtDataInicial.Name = "txtDataInicial"
        Me.txtDataInicial.Size = New System.Drawing.Size(100, 20)
        Me.txtDataInicial.TabIndex = 210
        Me.txtDataInicial.ValidatingType = GetType(Date)
        '
        'txtDataFinal
        '
        Me.txtDataFinal.Location = New System.Drawing.Point(303, 78)
        Me.txtDataFinal.Mask = "00/00/0000"
        Me.txtDataFinal.Name = "txtDataFinal"
        Me.txtDataFinal.Size = New System.Drawing.Size(100, 20)
        Me.txtDataFinal.TabIndex = 211
        Me.txtDataFinal.ValidatingType = GetType(Date)
        '
        'fRelatorioFechamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(968, 610)
        Me.Controls.Add(Me.txtDataFinal)
        Me.Controls.Add(Me.txtDataInicial)
        Me.Controls.Add(Me.txtCaixa)
        Me.Controls.Add(Me.lblProduto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.rptFechamento)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.btoFiltro)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.btoSair)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fRelatorioFechamento"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fFabricanteLista"
        CType(Me.v_fechamentoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nascomercioDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents btoFiltro As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btoSair As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCaixa As System.Windows.Forms.TextBox
    Friend WithEvents lblProduto As System.Windows.Forms.Label
    Friend WithEvents v_fechamentoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents nascomercioDataSet As nascomercio.nascomercioDataSet
    Friend WithEvents v_fechamentoTableAdapter As nascomercio.nascomercioDataSetTableAdapters.v_fechamentoTableAdapter
    Private WithEvents rptFechamento As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents txtDataInicial As MaskedTextBox
    Friend WithEvents txtDataFinal As MaskedTextBox
End Class
