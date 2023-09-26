Imports ncDados
Imports ncRegras
Imports ncComum.nsExcecao

Public Class fConfigPix


    Private Sub btoCadastro_Click(sender As Object, e As EventArgs)
        mdiPrincipal.CarregarCorForm()
    End Sub

    Private Sub btoSair_Click(sender As Object, e As EventArgs)
        Sair()
    End Sub
    Private Sub Sair()
        If Me.Modal = True Then
            Me.Close()
        Else
            If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                mdiPrincipal.FecharTela()
            End If
        End If
    End Sub

    Private Sub btoSalvar_Click(sender As Object, e As EventArgs) Handles btoSalvar.Click
        Salvar()
    End Sub
    Private Function Validar() As Boolean
        Try


            If cboBancos.SelectedIndex = -1 Then
                MessageBox.Show("É necessário informar um banco!")
                Return False
            End If

            If String.IsNullOrEmpty(txtCpf.Text) And String.IsNullOrEmpty(txtCnpj.Text) Then
                MessageBox.Show("É necessário informar o CPF ou o CNPJ!")
                Return False
            End If


            If String.IsNullOrEmpty(txtNome.Text) Then
                MessageBox.Show("É necessário informar o Nome!")
                Return False
            End If

            If String.IsNullOrEmpty(txtAppKey.Text) Then
                MessageBox.Show("É necessário informar o App Key!")
                Return False
            End If

            If String.IsNullOrEmpty(txtClientID.Text) Then
                MessageBox.Show("É necessário informar o Client ID!")
                Return False
            End If


            If String.IsNullOrEmpty(txtCertPath.Text) Then
                MessageBox.Show("É necessário informar o Caminho do certificado!")
                Return False
            End If

            If String.IsNullOrEmpty(txtCertPass.Text) Then
                MessageBox.Show("É necessário informar a senha do certificado!")
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function
    Private Sub Salvar()
        Dim regras As rPix
        Dim dados As dPixConfig
        Dim tipoMsg As String = String.Empty
        Dim tipoAcao As String = String.Empty
        Dim novoCID As Integer
        Dim strPath As String = String.Empty

        Try

            If Not Validar() Then
                Exit Sub
            End If

            tipoMsg = "INCLUSÃO"
            tipoAcao = "i"

            If MessageBox.Show("Confirma " & tipoMsg & " das informações?", tipoMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                regras = New rPix
                dados = New dPixConfig

                dados.Banco = cboBancos.Text
                dados.Cliente = 0
                dados.Cpf = txtCpf.Text
                dados.Cnpj = txtCnpj.Text
                dados.Nome = txtNome.Text
                dados.Chave = txtAppKey.Text
                dados.AppKey = txtAppKey.Text
                dados.ClientID = txtClientID.Text
                dados.ClientSecret = txtSecret.Text
                If txtCertPath.Text.ToString().IndexOf("\\") = -1 Then
                    strPath = txtCertPath.Text
                    strPath = strPath.Replace("\", "\\")
                    txtCertPath.Text = strPath
                End If
                dados.CertPath = txtCertPath.Text
                dados.CertPass = txtCertPass.Text

                If tipoAcao.Equals("i") Then
                    If IsNothing(regras.fConsultarConfig()) Then
                        novoCID = regras.fIncluirConfig(dados)
                    Else
                        novoCID = regras.fAlterarConfig(dados)
                    End If
                    MessageBox.Show("Configuração cadastrada!")
                    Me.Close()

                End If

            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na " & tipoMsg.ToLower() & " dos dados da Cor.")

        End Try
    End Sub

    Private Sub btoSair_Click_1(sender As Object, e As EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub
End Class