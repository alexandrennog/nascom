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
        AtualizarStatusBackupNuvem()
  End Sub

#Region "Backup local + nuvem (NasLibackup)"

    ' Mostra o ultimo backup e o ultimo com sucesso (tabela backupnuvem)
    Private Sub AtualizarStatusBackupNuvem()
        Try
            Dim regras As New ncRegras.nsBackupNuvem.rBackupNuvem

            If Not regras.TabelaExiste() Then
                lblUltimoBackup.ForeColor = Color.DarkRed
                lblUltimoBackup.Text = "Histórico de backups não encontrado neste banco." & vbCrLf &
                                       "Rode o script ""43 - backup_nuvem.sql"" no MySQL desta loja."
                Exit Sub
            End If

            Dim desativado As Boolean = Not String.Equals(System.Configuration.ConfigurationManager.AppSettings("BACKUPAUTOMATICO"), "SIM", StringComparison.OrdinalIgnoreCase)
            Dim ultimo As ncDados.nsBackupNuvem.dBackupNuvem = regras.Ultimo(False)
            Dim ultimoOk As ncDados.nsBackupNuvem.dBackupNuvem = regras.Ultimo(True)
            Dim texto As New StringBuilder()

            If ultimo Is Nothing Then
                lblUltimoBackup.ForeColor = Color.DarkRed
                lblUltimoBackup.Text = "Nenhum backup registrado ainda." & vbCrLf &
                                       "Clique em ""Fazer backup agora"" para gerar o primeiro." &
                                       If(desativado, vbCrLf & "Backup automático DESATIVADO. Talvez o seu plano não inclua essa modalidade. Fale com o suporte.", "")
                Exit Sub
            End If

            texto.Append("Último backup: ").Append(FormatarDataHora(ultimo.dataInicio)).
                  Append("  -  ").Append(ultimo.situacaoDescricao).
                  Append(" (").Append(ultimo.tipoDescricao.ToLower()).Append(")")
            If ultimo.bytesZip > 0 Then
                texto.Append("  -  ").Append(FormatarTamanho(ultimo.bytesZip))
            End If
            texto.AppendLine()

            If ultimoOk Is Nothing Then
                texto.AppendLine("Nenhum backup chegou na nuvem ainda.")
            Else
                Dim dias As Integer = CInt(Math.Floor((Today - ultimoOk.dataInicio.Value.Date).TotalDays))
                texto.Append("Último salvo na nuvem: ").Append(FormatarDataHora(ultimoOk.dataInicio)).
                      Append(If(dias <= 0, "  (hoje)", If(dias = 1, "  (ontem)", "  (há " & dias & " dias)"))).AppendLine()
            End If

            If desativado Then
                texto.AppendLine("Backup automático DESATIVADO. Talvez o seu plano não inclua essa modalidade. Fale com o suporte.")
            End If

            If ultimo.situacao <> "S" AndAlso Not String.IsNullOrEmpty(ultimo.mensagem) Then
                texto.Append("Motivo: ").Append(If(ultimo.mensagem.Length > 140, ultimo.mensagem.Substring(0, 140) & "...", ultimo.mensagem))
            End If

            ' Verde = nuvem em dia (ate 1 dia); vermelho = atrasado ou ultimo com problema
            Dim emDia As Boolean = ultimoOk IsNot Nothing AndAlso (Today - ultimoOk.dataInicio.Value.Date).TotalDays <= 1
            lblUltimoBackup.ForeColor = If(emDia AndAlso ultimo.situacao <> "F" AndAlso Not desativado, Color.DarkGreen, Color.DarkRed)
            lblUltimoBackup.Text = texto.ToString()

        Catch ex As Exception
            lblUltimoBackup.ForeColor = Color.DarkRed
            lblUltimoBackup.Text = "Não foi possível consultar o histórico de backups: " & ex.Message
        End Try
    End Sub

    Private Async Sub btoBackupNuvem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoBackupNuvem.Click
        Dim resultado As NasLibackup.ResultadoBackup

        btoBackupNuvem.Enabled = False
        lblProgresso.Text = "Fazendo backup (banco, compactação e envio para a nuvem)... Pode continuar usando o sistema."

        Try
            resultado = Await mdiPrincipal.ExecutarBackupNuvemAsync(False)
        Catch nex As ncComum.nsExcecao.ExcecaoNascomercio
            If Not Me.IsDisposed Then
                btoBackupNuvem.Enabled = True
                lblProgresso.Text = ""
            End If
            MessageBox.Show(nex.Message, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Catch ex As Exception
            If Not Me.IsDisposed Then
                btoBackupNuvem.Enabled = True
                lblProgresso.Text = ""
            End If
            MessageBox.Show("Erro ao fazer o backup: " & ex.Message, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' A tela pode ter sido fechada enquanto o backup rodava
        If Not Me.IsDisposed Then
            btoBackupNuvem.Enabled = True
            lblProgresso.Text = ""
            AtualizarStatusBackupNuvem()
        End If

        Select Case resultado.Situacao
            Case "S"
                MessageBox.Show("Backup concluído e enviado para a nuvem." & vbCrLf & vbCrLf &
                                "Cópia local: " & resultado.ArquivoLocal & vbCrLf &
                                "Tamanho: " & FormatarTamanho(resultado.BytesZip) & "  -  tempo: " & resultado.Duracao.ToString("hh\:mm\:ss"),
                                "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case "P"
                MessageBox.Show("O backup local foi gerado, mas o envio para a nuvem falhou." & vbCrLf & vbCrLf &
                                "Cópia local: " & resultado.ArquivoLocal & vbCrLf & vbCrLf & resultado.Mensagem,
                                "Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Case Else
                MessageBox.Show(resultado.Mensagem, "Backup", MessageBoxButtons.OK,
                                If(resultado.Situacao = "F", MessageBoxIcon.Error, MessageBoxIcon.Information))
        End Select
    End Sub

    Private Sub btoRelatorioBackups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoRelatorioBackups.Click
        mdiPrincipal.CarregarRelatorioBackups()
    End Sub

    Private Shared Function FormatarDataHora(ByVal valor As Nullable(Of DateTime)) As String
        Return If(valor.HasValue, valor.Value.ToString("dd/MM/yyyy HH:mm"), "-")
    End Function

    Private Shared Function FormatarTamanho(ByVal bytes As Long) As String
        If bytes >= 1024L * 1024L * 1024L Then
            Return (bytes / (1024.0 * 1024.0 * 1024.0)).ToString("N2") & " GB"
        End If
        Return (bytes / (1024.0 * 1024.0)).ToString("N1") & " MB"
    End Function

#End Region

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

    Private Sub SaveFileBackup_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
