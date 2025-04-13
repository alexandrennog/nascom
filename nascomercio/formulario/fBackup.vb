Imports System.IO
Imports ncComum

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
    senha = System.Configuration.ConfigurationManager.AppSettings("BD_SENHA")
    banco = System.Configuration.ConfigurationManager.AppSettings("BD_NOMEBANCO")
    aplicativo = System.Configuration.ConfigurationManager.AppSettings("BD_APLICATIVO")
    If txtBanco.Text.Trim.Equals("") Then
      destino = Environment.CurrentDirectory & "\backup\nascomercio_" & _
          Now().Year.ToString().PadLeft(4, "0"c) & _
          Now().Month.ToString().PadLeft(2, "0"c) & _
          Now().Day.ToString().PadLeft(2, "0"c) & "_" & _
          Now().Hour.ToString().PadLeft(2, "0"c) & _
          Now().Minute.ToString().PadLeft(2, "0"c) & _
          Now().Second.ToString().PadLeft(2, "0"c) & ".sql"
    Else
      destino = txtBanco.Text & "\nascomercio_" & _
          Now().Year.ToString().PadLeft(4, "0"c) & _
          Now().Month.ToString().PadLeft(2, "0"c) & _
          Now().Day.ToString().PadLeft(2, "0"c) & "_" & _
          Now().Hour.ToString().PadLeft(2, "0"c) & _
          Now().Minute.ToString().PadLeft(2, "0"c) & _
          Now().Second.ToString().PadLeft(2, "0"c) & ".sql"
    End If

    'System.Diagnostics.Process.Start("cmd.exe /C " & aplicativo & "mysqldump.exe", "-u " & usuario & " -p" & senha & " " & banco & " > " & destino)
    System.Diagnostics.Process.Start(Environment.CurrentDirectory & "\backup\backup.bat", """" & aplicativo & """ " & usuario & " " & senha & " " & banco & " " & destino)

    MessageBox.Show("Backup Realizado: " & destino, "Nascomercio", MessageBoxButtons.OK)

  End Sub

  Private Sub btoRestaurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoRestaurar.Click
    Dim usuario As String = String.Empty
    Dim senha As String = String.Empty
    Dim banco As String = String.Empty
    Dim origem As String = String.Empty
    Dim aplicativo As String = String.Empty

    If MessageBox.Show("Este comando irá substituir o banco de dados. Deseja continuar?", "Nascomercio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
      usuario = System.Configuration.ConfigurationManager.AppSettings("BD_USUARIO")
      senha = System.Configuration.ConfigurationManager.AppSettings("BD_SENHA")
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
End Class
