<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
    Me.ofd = New System.Windows.Forms.OpenFileDialog
    Me.txtArquivo = New System.Windows.Forms.TextBox
    Me.btoArquivo = New System.Windows.Forms.Button
    Me.barra = New System.Windows.Forms.ProgressBar
    Me.lblTitulo = New System.Windows.Forms.Label
    Me.cboTipo = New System.Windows.Forms.ComboBox
    Me.btoImportar = New System.Windows.Forms.Button
    Me.btoValidar = New System.Windows.Forms.Button
    Me.btoImportar2 = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'ofd
    '
    Me.ofd.FileName = "OpenFileDialog1"
    '
    'txtArquivo
    '
    Me.txtArquivo.Location = New System.Drawing.Point(12, 53)
    Me.txtArquivo.Name = "txtArquivo"
    Me.txtArquivo.Size = New System.Drawing.Size(522, 20)
    Me.txtArquivo.TabIndex = 0
    '
    'btoArquivo
    '
    Me.btoArquivo.Location = New System.Drawing.Point(540, 51)
    Me.btoArquivo.Name = "btoArquivo"
    Me.btoArquivo.Size = New System.Drawing.Size(25, 23)
    Me.btoArquivo.TabIndex = 1
    Me.btoArquivo.Text = "..."
    Me.btoArquivo.UseVisualStyleBackColor = True
    '
    'barra
    '
    Me.barra.Location = New System.Drawing.Point(11, 117)
    Me.barra.Name = "barra"
    Me.barra.Size = New System.Drawing.Size(554, 18)
    Me.barra.TabIndex = 4
    '
    'lblTitulo
    '
    Me.lblTitulo.AutoSize = True
    Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblTitulo.Location = New System.Drawing.Point(9, 9)
    Me.lblTitulo.Name = "lblTitulo"
    Me.lblTitulo.Size = New System.Drawing.Size(118, 25)
    Me.lblTitulo.TabIndex = 7
    Me.lblTitulo.Text = "Importação"
    '
    'cboTipo
    '
    Me.cboTipo.FormattingEnabled = True
    Me.cboTipo.Items.AddRange(New Object() {"Cheques", "Cliente", "Cor", "Crediario", "Fabricante", "Fornecedor", "Grupo", "PRODCOR-BD", "Produto"})
    Me.cboTipo.Location = New System.Drawing.Point(11, 84)
    Me.cboTipo.Name = "cboTipo"
    Me.cboTipo.Size = New System.Drawing.Size(265, 21)
    Me.cboTipo.TabIndex = 10
    '
    'btoImportar
    '
    Me.btoImportar.Location = New System.Drawing.Point(362, 84)
    Me.btoImportar.Name = "btoImportar"
    Me.btoImportar.Size = New System.Drawing.Size(110, 23)
    Me.btoImportar.TabIndex = 11
    Me.btoImportar.Text = "Validar e Importar"
    Me.btoImportar.UseVisualStyleBackColor = True
    '
    'btoValidar
    '
    Me.btoValidar.Location = New System.Drawing.Point(282, 84)
    Me.btoValidar.Name = "btoValidar"
    Me.btoValidar.Size = New System.Drawing.Size(74, 23)
    Me.btoValidar.TabIndex = 12
    Me.btoValidar.Text = "VALIDAR"
    Me.btoValidar.UseVisualStyleBackColor = True
    '
    'btoImportar2
    '
    Me.btoImportar2.Location = New System.Drawing.Point(478, 84)
    Me.btoImportar2.Name = "btoImportar2"
    Me.btoImportar2.Size = New System.Drawing.Size(87, 23)
    Me.btoImportar2.TabIndex = 22
    Me.btoImportar2.Text = "Importar"
    Me.btoImportar2.UseVisualStyleBackColor = True
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(577, 158)
    Me.Controls.Add(Me.btoImportar2)
    Me.Controls.Add(Me.btoValidar)
    Me.Controls.Add(Me.btoImportar)
    Me.Controls.Add(Me.cboTipo)
    Me.Controls.Add(Me.lblTitulo)
    Me.Controls.Add(Me.barra)
    Me.Controls.Add(Me.btoArquivo)
    Me.Controls.Add(Me.txtArquivo)
    Me.Name = "Form1"
    Me.Text = "Importação e Backup"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
  Friend WithEvents txtArquivo As System.Windows.Forms.TextBox
  Friend WithEvents btoArquivo As System.Windows.Forms.Button
  Friend WithEvents barra As System.Windows.Forms.ProgressBar
  Friend WithEvents lblTitulo As System.Windows.Forms.Label
  Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
  Friend WithEvents btoImportar As System.Windows.Forms.Button
  Friend WithEvents btoValidar As System.Windows.Forms.Button
  Friend WithEvents btoImportar2 As System.Windows.Forms.Button

End Class
