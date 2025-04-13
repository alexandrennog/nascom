Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao
Imports ncComum.nsEtiqueta
Imports ncDados.nscheques

Public Class fChequesForm

  Public pago As Boolean

  Private Sub Salvar()
    Dim valido As Boolean = True
    Dim existe As Boolean = False
    Dim regrasCheques As New ncRegras.nsCheques.rCheques
    Dim cheques As New ncDados.nsCheques.ColecaoCheques
    Dim cheque As ncDados.nsCheques.dCheques

    Try

      If valido = True Then
        If MessageBox.Show("Confirma gravação das informações?", "Cheques", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then


          If Not existe = True Then
            For Each linha As DataGridViewRow In dgvCheques.Rows
              If linha.Cells(3).Value <> "" Then
                cheque = New ncDados.nsCheques.dCheques()
                cheque.cid = linha.Cells(0).Value
                cheque.dataEmissao = linha.Cells(1).Value
                cheque.dataDeposito = linha.Cells(2).Value
                cheque.valor = linha.Cells(3).Value
                cheque.bancoNome = linha.Cells(4).Value
                cheque.agencia = linha.Cells(5).Value
                cheque.conta = linha.Cells(6).Value
                cheque.Numero = linha.Cells(7).Value
                cheque.baixado = "Não"
                cheque.clienteId = txtCliente.Tag
                cheques.Add(cheque)
              End If
            Next
            regrasCheques.Incluir(cheques)

            pago = True
            Me.Close()
          End If

        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na gravação dos dados de Cliente.")

    End Try
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    Me.Close()
  End Sub


  Private Sub fClienteFinanceiroForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.F1
        IncluirItem()
      Case Keys.F2
        ExcluirItem()
      Case Keys.Enter
        btoSalvar_Click(sender, e)
      Case Keys.Escape
        Me.Close()
    End Select
  End Sub

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
    If CDec(lblFalta.Text) <> 0D Then
      MessageBox.Show("Faltam: " & lblFalta.Text)
    Else
      Salvar()
    End If
  End Sub


  Private Sub dgvcheques_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCheques.CellValueChanged
    Dim total As Decimal

    For Each linha As DataGridViewRow In dgvCheques.Rows
      total = CDec(total + linha.Cells(3).Value)
    Next

    If lblTotal.Text <> "" Then
      lblFalta.Text = CDec(CDec(lblTotal.Text) - total).ToString("N")

    End If

  End Sub

  Private Sub IncluirItem()
    If dgvCheques.Columns.Count > 0 Then
      dgvCheques.Rows.Add()

      'Insere no grid nova cheque
      dgvCheques.Rows(dgvCheques.Rows.Count - 1).Cells(0).Value = dgvCheques.Rows(dgvCheques.Rows.Count - 2).Cells(0).Value + 1
      dgvCheques.Rows(dgvCheques.Rows.Count - 1).Cells(1).Value = Today.ToString("dd/MM/yyyy")
      dgvCheques.Rows(dgvCheques.Rows.Count - 1).Cells(2).Value = CDate(dgvCheques.Rows(dgvCheques.Rows.Count - 2).Cells(2).Value).AddMonths(1).ToString("dd/MM/yyyy")
      dgvCheques.Rows(dgvCheques.Rows.Count - 1).Cells(3).Value = lblFalta.Text

      dgvCheques.Refresh()
    End If


  End Sub

  Private Sub ExcluirItem()
    If dgvCheques.Rows.Count > 0 Then
      dgvCheques.Rows.RemoveAt(dgvCheques.CurrentRow.Index)
    End If
  End Sub

  Private Sub btoIncluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoIncluirItem.Click
    IncluirItem()
  End Sub

  Private Sub btoExcluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluirItem.Click
    ExcluirItem()
  End Sub

End Class