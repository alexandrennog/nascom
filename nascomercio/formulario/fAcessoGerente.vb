Imports ncDados.nsUsuario
Imports ncRegras.nsUsuario
Imports ncDados.nsUsuarioPerfil
Imports ncRegras.nsUsuarioPerfil
Imports ncComum.nsExcecao
Imports ncComum.nsLog.cLog

Public Class fAcessoGerente

  Public gGerente As dUsuario
  Public gRetorno As Boolean
  Public gTipo As String

  Private Sub btoAcessar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoAcessar.Click

    txtUsuario.Text = txtUsuario.Text.Trim()
    txtSenha.Text = txtSenha.Text.Trim()

    If txtUsuario.Text.Trim() = String.Empty Then
      MessageBox.Show("É necessário informar o nome de usuário.", "Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Return
    End If

    If txtSenha.Text.Trim() = String.Empty Then
      MessageBox.Show("É necessário informar a senha de usuário.", "Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Return
    End If

    gRetorno = CarregarUsuario()
  End Sub

  Private Sub txtSenha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSenha.KeyDown, txtUsuario.KeyDown
    If e.KeyCode = Keys.Escape Then
      btoSair_Click(sender, e)
    ElseIf e.KeyCode = Keys.Enter Then
      btoAcessar_Click(sender, e)
    End If
  End Sub


  Public Sub New()

    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.

  End Sub

  Private Function CarregarUsuario() As Boolean
    Dim regrasUsuario As rUsuario
    Dim dadosUsuario As dUsuario
    Dim regrasPerfil As rUsuarioPerfil
    Dim dadosPerfil As dUsuarioPerfil
    Dim retorno As ColecaoUsuario
    Dim valido As Boolean = False
    Dim mensagem As String = String.Empty
    Dim dadosParametro As ncDados.nsParametro.dParametro
    Dim regraParametro As New ncRegras.nsParametro.rParametro

    Try

      regrasUsuario = New rUsuario
      dadosUsuario = New dUsuario
      Dim cripto As New ncComum.criptografia()

      dadosUsuario.usuario = Me.txtUsuario.Text.Trim()

      dadosParametro = regraParametro.Consultar(ncComum.nsConstantes.cConstantes.Parametros.Secure)
      If dadosParametro.valor = "0" Then
          dadosUsuario.senha = Me.txtSenha.Text.Trim()
      Else
          dadosUsuario.senha = cripto.Criptografar(Me.txtSenha.Text.Trim())
      End If
      retorno = regrasUsuario.Consultar(dadosUsuario)

      If IsNothing(retorno) Then
        valido = False
        mensagem = "Usuário/Senha inválido(s)."
        GravarLog("", "Tentativa de acesso inválido ao sistema - Usuario [" & dadosUsuario.usuario & "]")
      Else
        If retorno.Count <> 1 Then
          valido = False
          mensagem = "Usuário/Senha inválido(s)."
          GravarLog("", "Tentativa de acesso inválido ao sistema - Usuario [" & dadosUsuario.usuario & "]")
        Else
          valido = True
        End If
      End If

      If valido = True Then
        Me.Close()

        gGerente = retorno(0)

        GravarLog(gGerente.usuario, "Acesso ao sistema")

        regrasPerfil = New rUsuarioPerfil

        dadosPerfil = regrasPerfil.Consultar(gGerente.usuarioPerfil_cid)

        Select Case gGerente.usuarioPerfil_codigo
          Case "a", "g"
            Return True
          Case Else
            If gTipo = "Venda" Then
              Return True
            Else
              MessageBox.Show("Tipo de Usuário não permitido.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Select

      Else
        MessageBox.Show(mensagem, "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.txtUsuario.Text = String.Empty
        Me.txtSenha.Text = String.Empty
        Me.txtUsuario.Focus()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show(ex.Message)

    End Try

  End Function


  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    gRetorno = False
    Me.Close()
  End Sub
End Class
