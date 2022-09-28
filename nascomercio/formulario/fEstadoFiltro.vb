Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsEstado
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fEstadoFiltro

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
    Cadastrar()
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

  Private Sub fEstadoFiltro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        mdiPrincipal.FecharTela()
      Case Keys.F5
        Cadastrar()
      Case Keys.Enter
        Pesquisar()
    End Select
  End Sub

  Private Sub Cadastrar()
    mdiPrincipal.CarregarEstadoForm()
  End Sub

  Private Sub btoPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoPesquisar.Click
    Pesquisar()
  End Sub

  Private Sub Pesquisar()
    Dim filtro As dEstado

    filtro = New dEstado

    filtro.nome = cFuncoes.TratarTexto(txtNome.Text)
    filtro.sigla = cFuncoes.TratarTexto(txtSigla.Text)
    filtro.situacao = cFuncoes.TratarTexto(cboSituacao.SelectedValue)

    fEstadoLista.filtro = filtro

    mdiPrincipal.CarregarEstadoLista()
  End Sub

  Private Sub CarregarComboSituacao()
    Dim regras As rSituacao
    Dim colecao As ColecaoSituacao

    Try

      cboSituacao.Items.Clear()

      regras = New rSituacao()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then


        cboSituacao.ValueMember = "codigo"
        cboSituacao.DisplayMember = "descricao"
        cboSituacao.DataSource = colecao
        cboSituacao.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Situação.")

    End Try
  End Sub

  Private Sub fEstadoFiltro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    CarregarComboSituacao()
  End Sub

End Class