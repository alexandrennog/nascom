Imports ncRegras.nsRegraTributaria
Imports ncDados.nsRegraTributaria
Imports ncRegras.nsProdutoRegraTributaria
Imports ncDados.nsProdutoRegraTributaria
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fImpostoLista

  Public produto_cid As Nullable(Of Integer)

  Private Sub Cadastrar()
    fImpostoForm.produto_cid = Me.produto_cid
    fImpostoForm.regra_cid = Nothing
    mdiPrincipal.CarregarImpostoForm()
  End Sub

  Private Sub SelecionarItem()
    Dim indice As Integer
    Dim linha As DataGridViewRow
    Dim cid As Nullable(Of Integer)

    Try
      If dgvImposto.Rows.Count > 0 Then

        indice = dgvImposto.CurrentRow.Index

        linha = dgvImposto.Rows(indice)

        cid = cFuncoes.RetornarInteiro(linha.Cells("colRegraCid").Value)

      End If
    Catch ex As Exception

      cid = Nothing

    End Try

    If cid.HasValue Then
      fImpostoForm.produto_cid = Me.produto_cid
      fImpostoForm.regra_cid = cid
      mdiPrincipal.CarregarImpostoForm()
    End If
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
    Cadastrar()
  End Sub

  Private Sub fImpostoLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim regrasVinculo As rProdutoRegraTributaria
    Dim regrasRegra As rRegraTributaria
    Dim vinculos As ColecaoProdutoRegraTributaria
    Dim dadosRegra As dRegraTributaria
    Dim linha As DataGridViewRow

    Try

      If Not Me.produto_cid.HasValue Then
        MessageBox.Show("Nenhum produto informado para a tela de Impostos.")
        mdiPrincipal.FecharTela()
        Exit Sub
      End If

      dgvImposto.Rows.Clear()

      regrasVinculo = New rProdutoRegraTributaria
      vinculos = regrasVinculo.ListarPorProduto(Me.produto_cid.Value)

      If Not vinculos Is Nothing Then
        regrasRegra = New rRegraTributaria

        For Each vinculo As dProdutoRegraTributaria In vinculos
          dadosRegra = regrasRegra.Consultar(vinculo.regra_cid.Value)

          If Not dadosRegra Is Nothing Then
            linha = dgvImposto.Rows(dgvImposto.Rows.Add())
            linha.Cells("colRegraCid").Value = dadosRegra.cid
            linha.Cells("colDescricao").Value = dadosRegra.descricao
            linha.Cells("colCrt").Value = dadosRegra.crt
            linha.Cells("colTipoOperacao").Value = dadosRegra.tipoOperacao

            If cFuncoes.ValidarValor(dadosRegra.ativo) AndAlso dadosRegra.ativo.Value Then
              linha.Cells("colAtivo").Value = "Sim"
            Else
              linha.Cells("colAtivo").Value = "Não"
            End If
          End If
        Next
      End If

      dgvImposto.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta das Regras Tributárias do produto.")

    End Try
  End Sub

  Private Sub fImpostoLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        mdiPrincipal.FecharTela()
      Case Keys.F5
        Cadastrar()
      Case Keys.Enter
        SelecionarItem()
    End Select
  End Sub

    Private Sub dgvImposto_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvImposto.CellDoubleClick
        SelecionarItem()
    End Sub

    Private Sub dgvImposto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImposto.CellContentClick

    End Sub
End Class
