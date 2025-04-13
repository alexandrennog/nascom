Imports ncDados.nsUsuario
Imports ncRegras.nsUsuario
Imports ncDados.nsUsuarioPerfil
Imports ncRegras.nsUsuarioPerfil
Imports ncComum.nsExcecao
Imports ncComum.nsLog.cLog

Public Class fSobre

  Public Sub New()

    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.

  End Sub


  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    Me.Close()
  End Sub


  Private Sub fSobre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.lblVersao.Text = "Versão: " & Me.GetType().Assembly.GetName().Version.ToString()
  End Sub

End Class
