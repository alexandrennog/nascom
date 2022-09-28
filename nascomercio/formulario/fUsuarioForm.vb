Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsUsuario
Imports ncRegras.nsUsuario
Imports ncDados.nsUsuarioPerfil
Imports ncRegras.nsUsuarioPerfil
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fUsuarioForm

  Public cid As Nullable(Of Integer)

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    Filtrar()
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
      mdiPrincipal.FecharTela()
    End If
  End Sub

  Private Sub fUsuarioForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
          mdiPrincipal.FecharTela()
        End If
      Case Keys.F5
        Filtrar()
      Case Keys.Enter
        Salvar()
      Case Keys.F12
        Excluir()
    End Select
  End Sub

  Public Sub Filtrar()
    mdiPrincipal.CarregarUsuarioFiltro()
  End Sub

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
    Salvar()
  End Sub

  Private Sub Salvar()
    Dim dados As dUsuario
    Dim regras As rUsuario
    Dim tipoMsg As String = String.Empty
    Dim tipoAcao As String = String.Empty
    Dim novoCID As Integer
    Dim colecao As ColecaoUsuario
    Dim existeUsuario As Boolean = False

    Try

      tipoMsg = "INCLUSÃO"
      tipoAcao = "i"

      If Not Me.cid.Equals(Nothing) Then
        If Not Me.cid.ToString().Equals(String.Empty) Then
          If Not Me.cid.Equals(0) Then
            tipoMsg = "ALTERAÇÃO"
            tipoAcao = "a"
          End If
        End If
      End If

      If tipoAcao.Equals("i") Then
        dados = New dUsuario
        regras = New rUsuario

        dados.usuario = cFuncoes.TratarTexto(txtUsuario.Text)

        colecao = regras.Consultar(dados)

        If colecao IsNot Nothing Then
          If colecao.Count > 0 Then
            existeUsuario = True
            MessageBox.Show("Usuário já existe!", "Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information)
          End If
        End If
      End If

      If existeUsuario = False Then
        If MessageBox.Show("Confirma " & tipoMsg & " das informações?", tipoMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
          dados = New dUsuario
          regras = New rUsuario

          dados.cid = Me.cid
          dados.nomeCompleto = cFuncoes.TratarTexto(txtNomeCompleto.Text)
          dados.usuario = cFuncoes.TratarTexto(txtUsuario.Text)
          dados.senha = cFuncoes.TratarTexto(txtSenha.Text)
          dados.usuarioPerfil_cid = cFuncoes.TratarInteiro(cboPerfil.SelectedValue)
          dados.situacao = cFuncoes.TratarTexto(cboSituacao.SelectedValue)
          dados.descontoProduto = cFuncoes.TratarDecimal(txtDescontoProduto.Text)
          dados.descontoPedido = cFuncoes.TratarDecimal(txtDescontoPedido.Text)
          dados.comissao = cFuncoes.TratarDecimal(txtComissao.Text)

          If tipoAcao.Equals("i") Then
            novoCID = regras.Incluir(dados)

            Me.cid = novoCID
            ExibirInformacoesTela()
          ElseIf tipoAcao.Equals("a") Then
            regras.Alterar(dados)

            ExibirInformacoesTela()
          End If
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na " & tipoMsg.ToLower() & " dos dados de Usuário.")

    End Try
  End Sub

  Private Sub Excluir()
    Dim dados As dUsuario
    Dim regras As rUsuario

    Try

      If Not Me.cid.Equals(Nothing) Then
        If Not Me.cid.ToString().Equals(String.Empty) Then
          If Not Me.cid.Equals(0) Then
            If MessageBox.Show("Confirma EXCLUSÃO das informações?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
              dados = New dUsuario
              regras = New rUsuario

              dados.cid = cFuncoes.TratarInteiro(Me.cid)

              regras.Excluir(dados)

              Me.cid = Nothing
              LimparCampos()
            End If
          End If
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na exclusão dos dados de Usuário.")

    End Try
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

  Private Sub ExibirInformacoesTela()
    Dim regras As rUsuario
    Dim dados As dUsuario

    Try

      If Not Me.cid.Equals(Nothing) Then
        If Not Me.cid.Equals(0) Then

          regras = New rUsuario()

          dados = regras.ConsultarPorCid(Me.cid)

          If Not dados Is Nothing Then
            txtUsuario.Text = cFuncoes.RetornarTexto(dados.usuario)
            txtNomeCompleto.Text = cFuncoes.RetornarTexto(dados.nomeCompleto)
            txtSenha.Text = cFuncoes.RetornarTexto(dados.senha)
            txtConfirmacao.Text = cFuncoes.RetornarTexto(dados.senha)
            txtDescontoProduto.Text = cFuncoes.RetornarTexto(dados.descontoProduto)
            txtDescontoPedido.Text = cFuncoes.RetornarTexto(dados.descontoPedido)
            txtComissao.Text = cFuncoes.RetornarTexto(dados.comissao)
            If cboPerfil.Items.Count > 0 Then
              cboPerfil.SelectedIndex = 0
            End If
            If cFuncoes.ValidarValor(dados.usuarioPerfil_cid) Then
              cboPerfil.SelectedValue = cFuncoes.RetornarInteiro(dados.usuarioPerfil_cid)
            End If
            If cboSituacao.Items.Count > 0 Then
              cboSituacao.SelectedIndex = 0
            End If
            If cFuncoes.ValidarValor(dados.situacao) Then
              cboSituacao.SelectedValue = cFuncoes.RetornarTexto(dados.situacao)
            End If
          End If
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Usuário.")

    End Try
  End Sub

  Private Sub LimparCampos()
    txtUsuario.Text = String.Empty
    txtNomeCompleto.Text = String.Empty
    txtSenha.Text = String.Empty
    txtConfirmacao.Text = String.Empty
    txtDescontoPedido.Text = String.Empty
    txtDescontoProduto.Text = String.Empty
    txtComissao.Text = String.Empty
    If cboPerfil.Items.Count > 0 Then
      cboPerfil.SelectedIndex = 0
    End If
    If cboSituacao.Items.Count > 0 Then
      cboSituacao.SelectedIndex = 0
    End If
  End Sub

  Private Sub fUsuarioForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    LimparCampos()
    CarregarComboSituacao()
    CarregarComboPerfil()
    ExibirInformacoesTela()
  End Sub

  Private Sub btoExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluir.Click
    Excluir()
  End Sub

End Class