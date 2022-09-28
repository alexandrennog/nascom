<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mdiPrincipal
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
Me.StatusStrip = New System.Windows.Forms.StatusStrip
Me.barraFerramentas = New System.Windows.Forms.ToolStrip
Me.botaoUsuarios = New System.Windows.Forms.ToolStripButton
Me.botaoProdutos = New System.Windows.Forms.ToolStripButton
Me.botaoFornecedor = New System.Windows.Forms.ToolStripButton
Me.barraFerramentas.SuspendLayout()
Me.SuspendLayout()
'
'StatusStrip
'
Me.StatusStrip.Location = New System.Drawing.Point(0, 701)
Me.StatusStrip.Name = "StatusStrip"
Me.StatusStrip.Size = New System.Drawing.Size(950, 22)
Me.StatusStrip.TabIndex = 7
Me.StatusStrip.Text = "StatusStrip"
'
'barraFerramentas
'
Me.barraFerramentas.BackColor = System.Drawing.Color.White
Me.barraFerramentas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
Me.barraFerramentas.ImageScalingSize = New System.Drawing.Size(64, 64)
Me.barraFerramentas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.botaoUsuarios, Me.botaoProdutos, Me.botaoFornecedor})
Me.barraFerramentas.Location = New System.Drawing.Point(0, 0)
Me.barraFerramentas.Name = "barraFerramentas"
Me.barraFerramentas.Size = New System.Drawing.Size(950, 87)
Me.barraFerramentas.TabIndex = 9
Me.barraFerramentas.Text = "ToolStrip1"
Me.barraFerramentas.Visible = False
'
'botaoUsuarios
'
Me.botaoUsuarios.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.botaoUsuarios.Image = Global.abcd.My.Resources.Resources.usuarios
Me.botaoUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta
Me.botaoUsuarios.Name = "botaoUsuarios"
Me.botaoUsuarios.Size = New System.Drawing.Size(68, 84)
Me.botaoUsuarios.Text = "&Usuários"
Me.botaoUsuarios.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
Me.botaoUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'
'botaoProdutos
'
Me.botaoProdutos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.botaoProdutos.Image = Global.abcd.My.Resources.Resources.usuarios
Me.botaoProdutos.ImageTransparentColor = System.Drawing.Color.Magenta
Me.botaoProdutos.Name = "botaoProdutos"
Me.botaoProdutos.Size = New System.Drawing.Size(68, 84)
Me.botaoProdutos.Text = "&Produtos"
Me.botaoProdutos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
Me.botaoProdutos.ToolTipText = "Produtos"
'
'botaoFornecedor
'
Me.botaoFornecedor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
Me.botaoFornecedor.Image = Global.abcd.My.Resources.Resources.usuarios
Me.botaoFornecedor.ImageTransparentColor = System.Drawing.Color.Magenta
Me.botaoFornecedor.Name = "botaoFornecedor"
Me.botaoFornecedor.Size = New System.Drawing.Size(99, 84)
Me.botaoFornecedor.Text = "&Fornecedores"
Me.botaoFornecedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'
'mdiPrincipal
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.BackColor = System.Drawing.Color.White
Me.ClientSize = New System.Drawing.Size(950, 723)
Me.Controls.Add(Me.barraFerramentas)
Me.Controls.Add(Me.StatusStrip)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
Me.IsMdiContainer = True
Me.Name = "mdiPrincipal"
Me.Text = "NASCOMercio"
Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
Me.barraFerramentas.ResumeLayout(False)
Me.barraFerramentas.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents barraFerramentas As System.Windows.Forms.ToolStrip
    Friend WithEvents botaoUsuarios As System.Windows.Forms.ToolStripButton
    Friend WithEvents botaoProdutos As System.Windows.Forms.ToolStripButton
    Friend WithEvents botaoFornecedor As System.Windows.Forms.ToolStripButton

End Class
