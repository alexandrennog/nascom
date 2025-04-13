Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsCaracteristica
Imports ncRegras.nsCaracteristica
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fCaracteristicaItemForm

  Public caracteristica_cid As Integer

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

  Private Sub btoIncluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoIncluirItem.Click
    IncluirItem()
  End Sub

  Private Sub btoExcluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluirItem.Click
    ExcluirItem()
  End Sub

  Private Sub btoCaracteristica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCaracteristica.Click
    CarregarCaracteristica()
  End Sub

  Private Sub fCaracteristicaItemForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        mdiPrincipal.FecharTela()
      Case Keys.F1
        IncluirItem()
      Case Keys.F2
        ExcluirItem()
      Case Keys.F5
        CarregarCaracteristica()
    End Select
  End Sub

  Private Sub fCaracteristicaItemForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    CarregarDadosCaracteristica()
    CarregarListaItem()
  End Sub

  Private Sub CarregarDadosCaracteristica()
    Dim regras As rCaracteristica
    Dim dados As dCaracteristica

    Try

      If Not Me.caracteristica_cid.Equals(Nothing) Then
        If Not Me.caracteristica_cid.Equals(0) Then

          regras = New rCaracteristica()

          dados = regras.ConsultarPorCID(Me.caracteristica_cid)

          If Not dados Is Nothing Then
            txtNome.Text = cFuncoes.RetornarTexto(dados.nome)
            txtCodigo.Text = cFuncoes.RetornarTexto(dados.codigo)
          End If
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Caracteristica.")

    End Try
  End Sub

  Private Sub CarregarCaracteristica()
    fCaracteristicaForm.cid = Me.caracteristica_cid

    mdiPrincipal.CarregarCaracteristicaForm()
  End Sub

  Private Sub CarregarListaItem()
    Dim regras As rCaracteristicaItem

    Try

      dgvItem.DataSource = Nothing
      dgvItem.Rows.Clear()
      dgvItem.Columns.Clear()
      dgvItem.Refresh()

      regras = New rCaracteristicaItem

      dgvItem.DataSource = regras.ConsultarPorCaracteristica(Me.caracteristica_cid)
      dgvItem.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta da lista de Itens da Característica.")

    End Try
  End Sub

  Private Sub IncluirItem()
    Dim regra As rCaracteristicaItem
    Dim dados As dCaracteristicaItem

    Try

      If txtItem.Text.Trim().Equals(String.Empty) Then
        MessageBox.Show("É necessário informar o item!", "Inclusão de Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Else

        regra = New rCaracteristicaItem()
        dados = New dCaracteristicaItem()

        dados.caracteristicas_cid = Me.caracteristica_cid
        dados.valor = txtItem.Text.Trim()

        regra.Incluir(dados)

        CarregarListaItem()
      End If

    Catch ex As Exception

      MessageBox.Show("Erro na inclusão do item.")

    End Try
  End Sub

  Private Sub ExcluirItem()
    Dim regra As rCaracteristicaItem
    Dim cid As Integer

    Try

      If dgvItem.Rows.Count > 0 Then

        cid = Convert.ToInt32(dgvItem.Rows(dgvItem.CurrentRow.Index).Cells.Item("cid").Value)

        regra = New rCaracteristicaItem()

        regra.ExcluirPorCID(cid)

        CarregarListaItem()
      End If

    Catch ex As Exception

      MessageBox.Show("Erro na exclusão do item.")

    End Try
  End Sub

End Class