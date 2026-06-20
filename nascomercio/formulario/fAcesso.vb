Imports System.Configuration
Imports System.Security.Cryptography.X509Certificates
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports ncComum.nsConstantes
Imports ncComum.nsEmail
Imports ncComum.nsExcecao
Imports ncDados.nsParametro
Imports ncDados.nsUsuario
Imports ncRegras.nsCaixa
Imports ncRegras.nsCrediario
Imports ncRegras.nsParametro
Imports Unimake.Business.Security



Public Class fAcesso

    Private Async Sub btoAcessar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoAcessar.Click
        Dim dadosParametro As dParametro
        Dim regraParametro As rParametro
        Dim regrasCrediario As rCrediario
        Dim result As String = Nothing
        Dim primeiroAcesso As Boolean

        txtUsuario.Text = txtUsuario.Text.Trim()
        txtSenha.Text = txtSenha.Text.Trim()
        primeiroAcesso = True

        Dim backupAutomatico As String = ConfigurationManager.AppSettings("BACKUPAUTOMATICO")


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

                        If backupAutomatico = "SIM" Then
                            Await mdiPrincipal.CarregarBackupAutomaticoAsync()
                        End If

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
    Private Shared Async Function CarregarCertificadoAsync(caminhoCertificado As String,
                                                       senhaCertificado As String,
                                                       certificado As CertificadoDigital) As Task(Of X509Certificate2)
        ' Executa o carregamento do certificado em uma thread separada (sem travar a UI)
        Return Await Task.Run(Function()
                                  Return certificado.CarregarCertificadoDigitalA1(caminhoCertificado, senhaCertificado)
                              End Function)
    End Function

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    'Private Sub chkRecSenha_CheckedChanged(sender As Object, e As EventArgs) Handles chkRecSenha.CheckedChanged
    '    Dim regraCaixa As New rCaixa()
    '    Dim emailAddress As String
    '    Dim corpo As String = String.Empty
    '    Dim regraUsuario As New ncRegras.nsUsuario.rUsuario
    '    Dim ret As dUsuario

    '    emailAddress = InputBox("Informe o Email", "recuperação de senha", "")

    '    If emailAddress = "" Then

    '        MessageBox.Show("É preciso informar um email")
    '        chkRecSenha.CheckState = CheckState.Unchecked
    '        Exit Sub
    '    End If

    '    If ValidarEmail(emailAddress) Then

    '        ret = regraUsuario.ConsultarPorEmail(emailAddress)

    '        Dim cripto As New ncComum.criptografia()
    '        ret.senha = cripto.Descriptografar(ret.senha)

    '        corpo += $"Olá: {ret.nomeCompleto}. Segue a sua senha: {ret.senha}" & vbCrLf
    '        Dim sendMailService As New SendMailService(ConfigurationManager.AppSettings("nascomercioMail"), emailAddress, ConfigurationManager.AppSettings("nascomercioPass"), "Recuperação de Senha", corpo)
    '        sendMailService.Send()

    '        MessageBox.Show($"A sua senha foi enviada para o email {emailAddress}")
    '    Else
    '        MessageBox.Show("É preciso informar um email válido")
    '    End If
    '    chkRecSenha.CheckState = CheckState.Unchecked
    'End Sub
    Private Function ValidarEmail(ByVal emailAddress As String) As Boolean
        ' Pattern ou mascara de verificação
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"

        ' Verifica se o email corresponde a pattern/mascara
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)

        ValidarEmail = emailAddressMatch.Success

    End Function

    Private Sub btnRecSenha_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btoRecuperar_Click(sender As Object, e As EventArgs) Handles btoRecuperar.Click
        Dim regraCaixa As New rCaixa()
        Dim emailAddress As String
        Dim corpo As String = String.Empty
        Dim regraUsuario As New ncRegras.nsUsuario.rUsuario
        Dim ret As dUsuario

        emailAddress = InputBox("Informe o Email", "recuperação de senha", "")

        If emailAddress = "" Then

            MessageBox.Show("É preciso informar um email")
            Exit Sub
        End If

        If ValidarEmail(emailAddress) Then

            ret = regraUsuario.ConsultarPorEmail(emailAddress)
            If ret Is Nothing Then
                MessageBox.Show("Email não encontrado na base de usuários")
                Exit Sub
            End If


            Dim cripto As New ncComum.criptografia()
            ret.senha = cripto.Descriptografar(ret.senha)

            corpo += $"Olá: {ret.nomeCompleto}. Segue a sua senha: {ret.senha}" & vbCrLf
            Dim sendMailService As New SendMailService(ConfigurationManager.AppSettings("nascomercioMail"), emailAddress, ConfigurationManager.AppSettings("nascomercioPass"), "Recuperação de Senha", corpo)
            sendMailService.Send()

            MessageBox.Show($"A sua senha foi enviada para o email {emailAddress}")
        Else
            MessageBox.Show("É preciso informar um email válido")
        End If
    End Sub
End Class
