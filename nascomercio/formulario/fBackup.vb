Imports System.IO
Imports System.Text
Imports ncComum
Imports ncDados.nsVenda

Public Class fBackup

  Private Sub btoBanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoBanco.Click
    ofd.ShowDialog()
    txtBanco.Text = ofd.FileName
  End Sub

  Private Sub btoCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCopiar.Click
    Dim usuario As String = String.Empty
    Dim senha As String = String.Empty
    Dim banco As String = String.Empty
    Dim destino As String = String.Empty
        Dim aplicativo As String = String.Empty


        usuario = System.Configuration.ConfigurationManager.AppSettings("BD_USUARIO")
        senha = decriptaPass(System.Configuration.ConfigurationManager.AppSettings("BD_SENHA"))
        banco = System.Configuration.ConfigurationManager.AppSettings("BD_NOMEBANCO")
    aplicativo = System.Configuration.ConfigurationManager.AppSettings("BD_APLICATIVO")
        If txtBanco.Text.Trim.Equals("") Then
            destino = Environment.CurrentDirectory & "\backup\nascomercio_" &
          Now().Year.ToString().PadLeft(4, "0"c) &
          Now().Month.ToString().PadLeft(2, "0"c) &
          Now().Day.ToString().PadLeft(2, "0"c) & "_" &
          Now().Hour.ToString().PadLeft(2, "0"c) &
          Now().Minute.ToString().PadLeft(2, "0"c) &
          Now().Second.ToString().PadLeft(2, "0"c) & ".sql"
        Else
            destino = txtBanco.Text & "\nascomercio_" &
          Now().Year.ToString().PadLeft(4, "0"c) &
          Now().Month.ToString().PadLeft(2, "0"c) &
          Now().Day.ToString().PadLeft(2, "0"c) & "_" &
          Now().Hour.ToString().PadLeft(2, "0"c) &
          Now().Minute.ToString().PadLeft(2, "0"c) &
          Now().Second.ToString().PadLeft(2, "0"c) & ".sql"
        End If


        Using sfd As New OpenFileDialog()

            sfd.Title = "Salvar arquivo de Vendas NFe"
            sfd.Filter = "Arquivo BAT (*.bat)|*.bat"
            sfd.FileName = "backup.bkp"
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

            If sfd.ShowDialog() = DialogResult.OK Then

                System.Diagnostics.Process.Start(sfd.FileName, """" & aplicativo & """ " & usuario & " " & senha & " " & banco & " " & destino)
                MessageBox.Show("Backup Realizado: " & destino, "Nascomercio", MessageBoxButtons.OK)

            End If

        End Using


        'System.Diagnostics.Process.Start("cmd.exe /C " & aplicativo & "mysqldump.exe", "-u " & usuario & " -p" & senha & " " & banco & " > " & destino)

    End Sub
    Private Function decriptaPass(ByVal str As String) As String
        Dim cripto As New ncComum.criptografia()
        Dim result As String
        result = Split(cripto.Descriptografar(str), vbNullChar)(0)
        cripto = Nothing

        decriptaPass = result
    End Function
    Private Sub btoRestaurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoRestaurar.Click
    Dim usuario As String = String.Empty
    Dim senha As String = String.Empty
    Dim banco As String = String.Empty
    Dim origem As String = String.Empty
    Dim aplicativo As String = String.Empty

    If MessageBox.Show("Este comando irá substituir o banco de dados. Deseja continuar?", "Nascomercio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
      usuario = System.Configuration.ConfigurationManager.AppSettings("BD_USUARIO")
            senha = decriptaPass(System.Configuration.ConfigurationManager.AppSettings("BD_SENHA"))
            banco = System.Configuration.ConfigurationManager.AppSettings("BD_NOMEBANCO")
      aplicativo = System.Configuration.ConfigurationManager.AppSettings("BD_APLICATIVO")
      origem = txtBanco.Text

      System.Diagnostics.Process.Start(Environment.CurrentDirectory & "\backup\restore.bat", """" & aplicativo & """ " & usuario & " " & senha & " " & banco & " " & origem)

      MessageBox.Show("Restauração concluída!", "Nascomercio")
    End If

  End Sub

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    lblNomeBanco.Text = System.Configuration.ConfigurationManager.AppSettings("BD_NOMEBANCO")
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

    Private Sub SaveFileBackup_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
