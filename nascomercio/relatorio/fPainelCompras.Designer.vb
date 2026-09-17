<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fPainelCompras
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlCabecalho = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlTopo = New System.Windows.Forms.Panel()
        Me.btoAtualizar = New System.Windows.Forms.Button()
        Me.txtDataFinal = New System.Windows.Forms.TextBox()
        Me.lblAte = New System.Windows.Forms.Label()
        Me.txtDataInicial = New System.Windows.Forms.TextBox()
        Me.lblDe = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlResumo = New System.Windows.Forms.TableLayoutPanel()
        Me.lblFaturamentoCaption = New System.Windows.Forms.Label()
        Me.lblFaturamentoValor = New System.Windows.Forms.Label()
        Me.lblTicketMedioCaption = New System.Windows.Forms.Label()
        Me.lblTicketMedioValor = New System.Windows.Forms.Label()
        Me.lblQtdVendasCaption = New System.Windows.Forms.Label()
        Me.lblQtdVendasValor = New System.Windows.Forms.Label()
        Me.lblMarcaValorCaption = New System.Windows.Forms.Label()
        Me.lblMarcaValorValor = New System.Windows.Forms.Label()
        Me.lblMarcaQtdCaption = New System.Windows.Forms.Label()
        Me.lblMarcaQtdValor = New System.Windows.Forms.Label()
        Me.lblReposicaoTitulo = New System.Windows.Forms.Label()
        Me.lstReposicao = New System.Windows.Forms.ListView()
        Me.pnlRodape = New System.Windows.Forms.Panel()
        Me.btoSair = New System.Windows.Forms.Button()
        Me.pnlCabecalho.SuspendLayout()
        Me.pnlTopo.SuspendLayout()
        Me.pnlResumo.SuspendLayout()
        Me.pnlRodape.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCabecalho
        '
        ' Agrupa pnlTopo, pnlResumo e lblReposicaoTitulo num TableLayoutPanel de 3
        ' linhas em vez de dar Dock=Top nos tres direto no formulario. Com 3 controles
        ' disputando a mesma borda, a ordem de empilhamento depende da ordem em que
        ' cada um foi adicionado a Controls (facil de inverter por engano); aqui, cada
        ' um tem uma linha fixa (0, 1, 2) e a posicao fica explicita, sem ambiguidade.
        Me.pnlCabecalho.ColumnCount = 1
        Me.pnlCabecalho.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlCabecalho.Controls.Add(Me.pnlTopo, 0, 0)
        Me.pnlCabecalho.Controls.Add(Me.pnlResumo, 0, 1)
        Me.pnlCabecalho.Controls.Add(Me.lblReposicaoTitulo, 0, 2)
        Me.pnlCabecalho.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecalho.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecalho.Name = "pnlCabecalho"
        Me.pnlCabecalho.RowCount = 3
        Me.pnlCabecalho.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.pnlCabecalho.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.pnlCabecalho.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.pnlCabecalho.Size = New System.Drawing.Size(760, 166)
        Me.pnlCabecalho.TabIndex = 5
        '
        'pnlTopo
        '
        Me.pnlTopo.Controls.Add(Me.btoAtualizar)
        Me.pnlTopo.Controls.Add(Me.txtDataFinal)
        Me.pnlTopo.Controls.Add(Me.lblAte)
        Me.pnlTopo.Controls.Add(Me.txtDataInicial)
        Me.pnlTopo.Controls.Add(Me.lblDe)
        Me.pnlTopo.Controls.Add(Me.lblTitulo)
        Me.pnlTopo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTopo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopo.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlTopo.Name = "pnlTopo"
        Me.pnlTopo.Size = New System.Drawing.Size(760, 56)
        Me.pnlTopo.TabIndex = 0
        '
        'btoAtualizar
        '
        Me.btoAtualizar.Location = New System.Drawing.Point(400, 16)
        Me.btoAtualizar.Name = "btoAtualizar"
        Me.btoAtualizar.Size = New System.Drawing.Size(110, 27)
        Me.btoAtualizar.TabIndex = 5
        Me.btoAtualizar.Text = "Atualizar [F5]"
        Me.btoAtualizar.UseVisualStyleBackColor = True
        '
        'txtDataFinal
        '
        Me.txtDataFinal.Location = New System.Drawing.Point(320, 18)
        Me.txtDataFinal.Name = "txtDataFinal"
        Me.txtDataFinal.Size = New System.Drawing.Size(70, 22)
        Me.txtDataFinal.TabIndex = 4
        '
        'lblAte
        '
        Me.lblAte.AutoSize = True
        Me.lblAte.Location = New System.Drawing.Point(290, 21)
        Me.lblAte.Name = "lblAte"
        Me.lblAte.Size = New System.Drawing.Size(24, 16)
        Me.lblAte.TabIndex = 3
        Me.lblAte.Text = "até"
        '
        'txtDataInicial
        '
        Me.txtDataInicial.Location = New System.Drawing.Point(210, 18)
        Me.txtDataInicial.Name = "txtDataInicial"
        Me.txtDataInicial.Size = New System.Drawing.Size(70, 22)
        Me.txtDataInicial.TabIndex = 2
        '
        'lblDe
        '
        Me.lblDe.AutoSize = True
        Me.lblDe.Location = New System.Drawing.Point(170, 21)
        Me.lblDe.Name = "lblDe"
        Me.lblDe.Size = New System.Drawing.Size(24, 16)
        Me.lblDe.TabIndex = 1
        Me.lblDe.Text = "de"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.Location = New System.Drawing.Point(12, 14)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(150, 25)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Painel de Compras"
        '
        'pnlResumo
        '
        Me.pnlResumo.ColumnCount = 5
        Me.pnlResumo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlResumo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlResumo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlResumo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlResumo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlResumo.Controls.Add(Me.lblFaturamentoCaption, 0, 0)
        Me.pnlResumo.Controls.Add(Me.lblFaturamentoValor, 0, 1)
        Me.pnlResumo.Controls.Add(Me.lblTicketMedioCaption, 1, 0)
        Me.pnlResumo.Controls.Add(Me.lblTicketMedioValor, 1, 1)
        Me.pnlResumo.Controls.Add(Me.lblQtdVendasCaption, 2, 0)
        Me.pnlResumo.Controls.Add(Me.lblQtdVendasValor, 2, 1)
        Me.pnlResumo.Controls.Add(Me.lblMarcaValorCaption, 3, 0)
        Me.pnlResumo.Controls.Add(Me.lblMarcaValorValor, 3, 1)
        Me.pnlResumo.Controls.Add(Me.lblMarcaQtdCaption, 4, 0)
        Me.pnlResumo.Controls.Add(Me.lblMarcaQtdValor, 4, 1)
        Me.pnlResumo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlResumo.Location = New System.Drawing.Point(0, 56)
        Me.pnlResumo.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlResumo.Name = "pnlResumo"
        Me.pnlResumo.Padding = New System.Windows.Forms.Padding(12, 8, 12, 8)
        Me.pnlResumo.RowCount = 2
        Me.pnlResumo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.pnlResumo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.pnlResumo.Size = New System.Drawing.Size(760, 76)
        Me.pnlResumo.TabIndex = 1
        '
        'lblFaturamentoCaption
        '
        Me.lblFaturamentoCaption.AutoSize = True
        Me.lblFaturamentoCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFaturamentoCaption.ForeColor = System.Drawing.Color.Gray
        Me.lblFaturamentoCaption.Name = "lblFaturamentoCaption"
        Me.lblFaturamentoCaption.Text = "Faturamento (R$)"
        '
        'lblFaturamentoValor
        '
        Me.lblFaturamentoValor.AutoSize = True
        Me.lblFaturamentoValor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFaturamentoValor.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblFaturamentoValor.Name = "lblFaturamentoValor"
        Me.lblFaturamentoValor.Text = "-"
        '
        'lblTicketMedioCaption
        '
        Me.lblTicketMedioCaption.AutoSize = True
        Me.lblTicketMedioCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTicketMedioCaption.ForeColor = System.Drawing.Color.Gray
        Me.lblTicketMedioCaption.Name = "lblTicketMedioCaption"
        Me.lblTicketMedioCaption.Text = "Ticket médio (R$)"
        '
        'lblTicketMedioValor
        '
        Me.lblTicketMedioValor.AutoSize = True
        Me.lblTicketMedioValor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTicketMedioValor.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTicketMedioValor.Name = "lblTicketMedioValor"
        Me.lblTicketMedioValor.Text = "-"
        '
        'lblQtdVendasCaption
        '
        Me.lblQtdVendasCaption.AutoSize = True
        Me.lblQtdVendasCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblQtdVendasCaption.ForeColor = System.Drawing.Color.Gray
        Me.lblQtdVendasCaption.Name = "lblQtdVendasCaption"
        Me.lblQtdVendasCaption.Text = "Qtd. de vendas"
        '
        'lblQtdVendasValor
        '
        Me.lblQtdVendasValor.AutoSize = True
        Me.lblQtdVendasValor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblQtdVendasValor.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtdVendasValor.Name = "lblQtdVendasValor"
        Me.lblQtdVendasValor.Text = "-"
        '
        'lblMarcaValorCaption
        '
        Me.lblMarcaValorCaption.AutoSize = True
        Me.lblMarcaValorCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMarcaValorCaption.ForeColor = System.Drawing.Color.Gray
        Me.lblMarcaValorCaption.Name = "lblMarcaValorCaption"
        Me.lblMarcaValorCaption.Text = "Marca campeã (valor)"
        '
        'lblMarcaValorValor
        '
        Me.lblMarcaValorValor.AutoSize = True
        Me.lblMarcaValorValor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMarcaValorValor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblMarcaValorValor.Name = "lblMarcaValorValor"
        Me.lblMarcaValorValor.Text = "-"
        '
        'lblMarcaQtdCaption
        '
        Me.lblMarcaQtdCaption.AutoSize = True
        Me.lblMarcaQtdCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMarcaQtdCaption.ForeColor = System.Drawing.Color.Gray
        Me.lblMarcaQtdCaption.Name = "lblMarcaQtdCaption"
        Me.lblMarcaQtdCaption.Text = "Marca campeã (pares)"
        '
        'lblMarcaQtdValor
        '
        Me.lblMarcaQtdValor.AutoSize = True
        Me.lblMarcaQtdValor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMarcaQtdValor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblMarcaQtdValor.Name = "lblMarcaQtdValor"
        Me.lblMarcaQtdValor.Text = "-"
        '
        'lblReposicaoTitulo
        '
        Me.lblReposicaoTitulo.AutoSize = True
        Me.lblReposicaoTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblReposicaoTitulo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblReposicaoTitulo.Location = New System.Drawing.Point(0, 132)
        Me.lblReposicaoTitulo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblReposicaoTitulo.Name = "lblReposicaoTitulo"
        Me.lblReposicaoTitulo.Padding = New System.Windows.Forms.Padding(12, 10, 0, 4)
        Me.lblReposicaoTitulo.Size = New System.Drawing.Size(400, 34)
        Me.lblReposicaoTitulo.TabIndex = 2
        Me.lblReposicaoTitulo.Text = "Oportunidades de reposição (vendeu bem, estoque baixo)"
        '
        'lstReposicao
        '
        Me.lstReposicao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstReposicao.FullRowSelect = True
        Me.lstReposicao.GridLines = True
        Me.lstReposicao.HideSelection = False
        Me.lstReposicao.Location = New System.Drawing.Point(0, 166)
        Me.lstReposicao.Name = "lstReposicao"
        Me.lstReposicao.Size = New System.Drawing.Size(760, 310)
        Me.lstReposicao.TabIndex = 3
        Me.lstReposicao.UseCompatibleStateImageBehavior = False
        Me.lstReposicao.View = System.Windows.Forms.View.Details
        '
        'pnlRodape
        '
        Me.pnlRodape.Controls.Add(Me.btoSair)
        Me.pnlRodape.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlRodape.Location = New System.Drawing.Point(0, 476)
        Me.pnlRodape.Name = "pnlRodape"
        Me.pnlRodape.Size = New System.Drawing.Size(760, 46)
        Me.pnlRodape.TabIndex = 4
        '
        'btoSair
        '
        Me.btoSair.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btoSair.Location = New System.Drawing.Point(650, 9)
        Me.btoSair.Name = "btoSair"
        Me.btoSair.Size = New System.Drawing.Size(98, 27)
        Me.btoSair.TabIndex = 0
        Me.btoSair.Text = "Sair [Esc]"
        Me.btoSair.UseVisualStyleBackColor = True
        '
        'fPainelCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 522)
        Me.Controls.Add(Me.lstReposicao)
        Me.Controls.Add(Me.pnlCabecalho)
        Me.Controls.Add(Me.pnlRodape)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(600, 400)
        Me.Name = "fPainelCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Painel de Compras"
        Me.pnlTopo.ResumeLayout(False)
        Me.pnlTopo.PerformLayout()
        Me.pnlResumo.ResumeLayout(False)
        Me.pnlResumo.PerformLayout()
        Me.pnlCabecalho.ResumeLayout(False)
        Me.pnlCabecalho.PerformLayout()
        Me.pnlRodape.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCabecalho As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlTopo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblDe As System.Windows.Forms.Label
    Friend WithEvents txtDataInicial As System.Windows.Forms.TextBox
    Friend WithEvents lblAte As System.Windows.Forms.Label
    Friend WithEvents txtDataFinal As System.Windows.Forms.TextBox
    Friend WithEvents btoAtualizar As System.Windows.Forms.Button
    Friend WithEvents pnlResumo As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFaturamentoCaption As System.Windows.Forms.Label
    Friend WithEvents lblFaturamentoValor As System.Windows.Forms.Label
    Friend WithEvents lblTicketMedioCaption As System.Windows.Forms.Label
    Friend WithEvents lblTicketMedioValor As System.Windows.Forms.Label
    Friend WithEvents lblQtdVendasCaption As System.Windows.Forms.Label
    Friend WithEvents lblQtdVendasValor As System.Windows.Forms.Label
    Friend WithEvents lblMarcaValorCaption As System.Windows.Forms.Label
    Friend WithEvents lblMarcaValorValor As System.Windows.Forms.Label
    Friend WithEvents lblMarcaQtdCaption As System.Windows.Forms.Label
    Friend WithEvents lblMarcaQtdValor As System.Windows.Forms.Label
    Friend WithEvents lblReposicaoTitulo As System.Windows.Forms.Label
    Friend WithEvents lstReposicao As System.Windows.Forms.ListView
    Friend WithEvents pnlRodape As System.Windows.Forms.Panel
    Friend WithEvents btoSair As System.Windows.Forms.Button

End Class
