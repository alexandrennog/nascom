Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsUsuarioPerfil
Imports ncRegras.nsUsuarioPerfil
Imports ncDados.nsUsuario
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fUsuarioFiltro

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
    Cadastrar()
  End Sub

  Private Sub fUsuarioFiltro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
    mdiPrincipal.CarregarUsuarioForm()
  End Sub

  Private Sub btoPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoPesquisar.Click
    Pesquisar()
  End Sub

  Private Sub Pesquisar()
    Dim filtro As dUsuario

    filtro = New dUsuario

    filtro.nomeCompleto = cFuncoes.TratarTexto(txtNomeCompleto.Text)
    filtro.usuario = cFuncoes.TratarTexto(txtUsuario.Text)
    filtro.usuarioPerfil_cid = cFuncoes.TratarInteiro(cboPerfil.SelectedValue)
    filtro.situacao = cFuncoes.TratarTexto(cboSituacao.SelectedValue)

    fUsuarioLista.filtro = filtro

    mdiPrincipal.CarregarUsuarioLista()
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

  Private Sub CarregarComboPerfil()
    Dim regras As rUsuarioPerfil
    Dim colecao As ColecaoUsuarioPerfil

    Try

      cboPerfil.Items.Clear()

      regras = New rUsuarioPerfil()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then
        colecao.Insert(0, New dUsuarioPerfil())

        cboPerfil.ValueMember = "cid"
        cboPerfil.DisplayMember = "nome"
        cboPerfil.DataSource = colecao
        cboPerfil.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Perfil de Usuário.")

    End Try
  End Sub

  Private Sub fUsuarioFiltro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    CarregarComboSituacao()
    CarregarComboPerfil()
  End Sub

End Class