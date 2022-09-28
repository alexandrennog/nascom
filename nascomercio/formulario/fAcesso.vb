Imports ncRegras.nsCrediario
Imports ncComum.nsExcecao
Imports ncRegras.nsParametro
Imports ncDados.nsParametro
Imports ncComum.nsConstantes

Public Class fAcesso

    Private Sub btoAcessar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoAcessar.Click
        Dim dadosParametro As dParametro
        Dim regraParametro As rParametro
        Dim regrasCrediario As rCrediario
        Dim result As String = Nothing
        Dim primeiroAcesso As Boolean

        txtUsuario.Text = txtUsuario.Text.Trim()
        txtSenha.Text = txtSenha.Text.Trim()
        primeiroAcesso = True

        If txtUsuario.Text.Trim() = String.Empty Then
            MessageBox.Show("É necessário informar o nome de usuário.", "Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If txtSenha.Text.Trim() = String.Empty Then
            MessageBox.Show("É necessário informar a senha de usuário.", "Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            ' Chave sistema
            regraParametro = New rParametro()
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.ChaveSistema)

            ' Consultar chave de acesso/validação
            If Not IsNothing(dadosParametro) Then
                result = dadosParametro.valor
            End If

            ' Se retornar valor, é a chave de validação/acesso; se não, é primeiro acesso
            If String.IsNullOrEmpty(result) Then
                '    result = "2015-12-21"
                primeiroAcesso = True
            Else
                'result = ncComum.EncDec.Decrypt(result, "nascom532")
                Dim cripto As New ncComum.criptografia()
                result = cripto.Descriptografar(result)
                cripto = Nothing

                result = Split(result, "#")(1)

                primeiroAcesso = False
            End If

            If primeiroAcesso = True Then
                MessageBox.Show("É necessário obter uma chave de validação!", "Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Return

                mdiPrincipal.ChaveSistema()
            Else ' Se não for primeiro acesso...
                If String.IsNullOrEmpty(result) Then
                    MessageBox.Show("Não foi possível acessar o sistema!", "Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                Else
                    If Today.CompareTo(CDate(result)) > 0 Then
                        MessageBox.Show("Tempo de uso expirado entre em contato com a Nascom para obter uma nova versão!", "Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    Else
                        For i As Integer = 6 To 0 Step -1
                            If Today.CompareTo(CDate(result).AddDays(-i)) = 0 Then
                                MessageBox.Show("Tempo de uso termina em " & i.ToString() & " dias. Entre em contato com a Nascom para obter uma nova versão!", "Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit For
                            End If
                        Next
                        regrasCrediario = New rCrediario()
                        regrasCrediario.CorrigirParcelas()

                        mdiPrincipal.Iniciar()
                    End If
                End If
            End If

        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message)
            Return
        Catch ex As Exception
            MessageBox.Show("Erro na consulta dos parâmetros.")
            Return
        End Try

    End Sub

    Private Sub txtSenha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSenha.KeyDown, txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter Then
            btoAcessar_Click(sender, e)
        ElseIf e.KeyCode = Keys.Escape Then
            mdiPrincipal.Close()
            Me.Close()
        End If
    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

End Class
