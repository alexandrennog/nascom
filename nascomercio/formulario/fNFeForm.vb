Imports ncComum.nsFuncoes.cFuncoes

Public Class fNFeForm

  Private arquivo As IO.StreamWriter = Nothing

  Private Sub fNFeForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
          mdiPrincipal.FecharTela()
        End If
    End Select
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
      mdiPrincipal.FecharTela()
    End If
  End Sub

  Private Sub btoExecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExecutar.Click
    Try
      '-- Criar arquivo
      Dim dataAtual As Date = DateTime.Now
      Dim arquivoNome As String = System.IO.Directory.GetCurrentDirectory() + "\arquivos_nfe\nfe_" + FormatarDataHoraAAAAMMDDHHMMSS(dataAtual) + ".xml"

      arquivo = New System.IO.StreamWriter(arquivoNome, False, System.Text.Encoding.UTF8)

      '-- Escrever informações
      Gravar_xml()
      Gravar_enviNFe_Abrir()
      Gravar_idLote()
      Gravar_NFe_Abrir()
      Gravar_infNFe()
      Gravar_Signature()
      Gravar_NFe_Fechar()
      Gravar_enviNFe_Fechar()

      '-- Finalizar arquivo
      arquivo.Close()
      arquivo.Dispose()

      MessageBox.Show("Arquivo criado com sucesso!", "Nota Fiscal Eletrônica", MessageBoxButtons.OK, MessageBoxIcon.Information)

    Catch ex As Exception
      MessageBox.Show("Erro ao criar arquivo", "Nota Fiscal Eletrônica", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Try
  End Sub

  Private Sub Gravar_xml()
    arquivo.WriteLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
  End Sub

  Private Sub Gravar_enviNFe_Abrir()
    arquivo.WriteLine("<enviNFe xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""1.01"">")
  End Sub

  Private Sub Gravar_enviNFe_Fechar()
    arquivo.WriteLine("</enviNFe>")
  End Sub

  Private Sub Gravar_idLote()
    arquivo.WriteLine("<idLote>123456789012345</idLote>")
  End Sub

  Private Sub Gravar_NFe_Abrir()
    arquivo.WriteLine("<NFe xmlns=""http://www.portalfiscal.inf.br/nfe"">")
  End Sub

  Private Sub Gravar_NFe_Fechar()
    arquivo.WriteLine("</NFe>")
  End Sub

  Private Sub Gravar_infNFe()
    arquivo.WriteLine("<infNFe Id=""NFe12345678901234567890123456789012345678901234"" versao=""1.01"">")
    arquivo.WriteLine("</infNFe>")
  End Sub

  Private Sub Gravar_Signature()
    arquivo.WriteLine("<Signature xmlns=""http://www.w3.org/2000/09/xmldsig#"">")
    arquivo.WriteLine("</Signature>")
  End Sub

End Class