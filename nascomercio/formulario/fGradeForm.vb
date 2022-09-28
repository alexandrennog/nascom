Public Class fGradeForm

  Private Sub fGradeForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    rdoTipoUnico.Focus()
  End Sub

  Private Sub fGradeForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        Me.Close()
      Case Keys.Enter
        IncluirLinhas()
        Me.Close()
    End Select
  End Sub

  Private Sub fGradeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Esconder()
    rdoTipoNumero.Focus()
  End Sub

  Private Sub rdoTipoUnico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTipoUnico.CheckedChanged
    If rdoTipoUnico.Checked = True Then
      Esconder()
      gpbTamanhoUnico.Visible = True
      txtTamanhoUnico.Text = "Tamanho Único"
    End If
  End Sub

  Private Sub Esconder()
    gpbNumero.Visible = False
    gpbTexto.Visible = False
    gpbTamanhoUnico.Visible = False
  End Sub

  Private Sub rdoTipoNumero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTipoNumero.CheckedChanged
    If rdoTipoNumero.Checked = True Then
      Esconder()
      gpbNumero.Visible = True
      txtDe.Text = "35"
      txtAte.Text = "44"
      txtDe.Focus()
    End If
  End Sub

  Private Sub rdoTipoTexto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTipoTexto.CheckedChanged
    If rdoTipoTexto.Checked = True Then
      Esconder()
      gpbTexto.Visible = True
      txtTexto.Text = "RN;PP;P;M;G;GG;XG"
    End If
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    Me.Close()
  End Sub

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
    IncluirLinhas()
  End Sub

  Private Sub IncluirLinhas()
    If rdoTipoUnico.Checked = True Then
      IncluirLinhasUnico()
    End If
    If rdoTipoNumero.Checked = True Then
      IncluirLinhasNumero()
    End If
    If rdoTipoTexto.Checked = True Then
      IncluirLinhasTexto()
    End If

    Me.Close()
  End Sub

  Private Sub IncluirLinhasUnico()
    If Not txtTamanhoUnico.Text.Trim().Equals(String.Empty) Then
      fProdutoForm.IncluirLinhasUnico(txtTamanhoUnico.Text)
    End If
  End Sub

  Private Sub IncluirLinhasNumero()
    Dim de As Integer = 0
    Dim ate As Integer = 0
    Dim cont As Integer = 0
    Dim tamanho As Integer
    Dim lista() As Integer = Nothing

    If Integer.TryParse(txtDe.Text, de) = False Then
      Exit Sub
    End If

    If Integer.TryParse(txtAte.Text, ate) = False Then
      Exit Sub
    End If

    If de > ate Then
      Exit Sub
    End If

    For tamanho = de To ate
      If rdoNumeroTodos.Checked Then
        ReDim Preserve lista(cont)
        lista(cont) = tamanho
        cont = cont + 1
      ElseIf rdoNumeroPar.Checked Then
        If tamanho Mod 2 = 0 Then
          ReDim Preserve lista(cont)
          lista(cont) = tamanho
          cont = cont + 1
        End If
      ElseIf rdoNumeroImpar.Checked Then
        If tamanho Mod 2 <> 0 Then
          ReDim Preserve lista(cont)
          lista(cont) = tamanho
          cont = cont + 1
        End If
      End If
    Next

    fProdutoForm.IncluirLinhasNumero(lista)
  End Sub

  Private Sub IncluirLinhasTexto()
    Dim lista() As String

    If txtTexto.Text.Trim().Equals(String.Empty) Then
      Exit Sub
    End If

    lista = txtTexto.Text.Trim().Split(";"c)

    fProdutoForm.IncluirLinhasTexto(lista)
  End Sub

End Class
