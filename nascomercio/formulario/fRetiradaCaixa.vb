Imports ncRegras.nsProduto
Imports ncDados.nsProduto
Imports ncComum.nsExcecao
Imports ncComum.nsLog.cLog

Public Class fRetiradaCaixa

  Public filtro As dProduto

  Private Function Validar() As Boolean
    Dim retorno As Boolean = False

    If Not txtDinheiro.Text.Trim().Equals(String.Empty) Then
      retorno = True
    End If

    Validar = retorno
  End Function

  Private Sub fProdutoItemPesquisa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        Me.Close()
      Case Keys.Enter
        Me.btoSalvar_Click(sender, e)
    End Select
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    Me.Close()
  End Sub

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
    If Validar() Then
      IncluiVenda()
    End If
  End Sub

  Private Function IncluiVenda() As Integer
    Dim novaVenda As New ncRegras.nsVenda.rVenda
    Dim dadosVenda As New ncDados.nsVenda.dVenda
    Dim controle As Integer

    Try
      ' Inclui venda
      dadosVenda.usuarioId = Me.lblVendedor.Tag
      dadosVenda.clienteId = 1
      dadosVenda.Data = Now
      dadosVenda.Retirada = Me.txtDinheiro.Text
      dadosVenda.Terminal = System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL")
      GravarLog(mdiPrincipal.gUsuario.usuario, "Retirada realizada. Usuário: " & Me.lblVendedor.Text)
      controle = novaVenda.Incluir(dadosVenda, Nothing)

      MessageBox.Show("Retirada realizada. Controle: " & controle.ToString())
      Me.Close()
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try

    Return controle

  End Function

End Class