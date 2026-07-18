Imports ncDados.nsEmpresa
Imports ncDados.nsEstado
Imports ncRegras.nsEstado
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fEmpresaFiltro

  Private Sub Cadastrar()
    mdiPrincipal.CarregarEmpresaForm()
  End Sub

  Private Sub Pesquisar()
    Dim filtro As dEmpresa

    filtro = New dEmpresa

    filtro.razaoSocial = cFuncoes.TratarTexto(txtRazaoSocial.Text)
    filtro.cnpj = cFuncoes.TratarTexto(txtCnpj.Text)
    filtro.uf = cFuncoes.TratarTexto(cboUf.SelectedValue)

    fEmpresaLista.filtro = filtro

    mdiPrincipal.CarregarEmpresaLista()
  End Sub

  Private Sub CarregarComboUf()
    Dim regras As rEstado
    Dim colecao As ColecaoEstado

    Try

      cboUf.DataSource = Nothing
      cboUf.Items.Clear()

      regras = New rEstado()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then
        colecao.Insert(0, New dEstado())

        cboUf.ValueMember = "sigla"
        cboUf.DisplayMember = "nome"
        cboUf.DataSource = colecao
        cboUf.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Estados.")

    End Try
  End Sub

  Private Sub btoPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoPesquisar.Click
    Pesquisar()
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
    Cadastrar()
  End Sub

  Private Sub fEmpresaFiltro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    CarregarComboUf()
  End Sub

  Private Sub fEmpresaFiltro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        mdiPrincipal.FecharTela()
      Case Keys.F5
        Cadastrar()
      Case Keys.Enter
        Pesquisar()
    End Select
  End Sub
End Class
