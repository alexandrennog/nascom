Imports System.Windows.Forms

Public Class mdiPrincipal

Public Sub IniciarADM()
  fAcesso.Close()
  barraFerramentas.Show()
End Sub

Public Sub IniciarCAIXA()
  fAcesso.Close()

  fCaixa.MdiParent = Me
  fCaixa.Show()
  fCaixa.BringToFront()
End Sub

Private Sub botaoUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botaoUsuarios.Click
  fUsuario.MdiParent = Me
  fUsuario.Show()
  fUsuario.BringToFront()
End Sub

Private Sub botaoProdutos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botaoProdutos.Click
  fProduto.MdiParent = Me
  fProduto.Show()
  fProduto.BringToFront()
End Sub

  Public Sub New()

    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    fAcesso.MdiParent = Me
    fAcesso.Show()
    fAcesso.BringToFront()
  End Sub

Private Sub botaoFornecedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botaoFornecedor.Click
  fFornecedor.MdiParent = Me
  fFornecedor.Show()
  fFornecedor.BringToFront()
End Sub

End Class
