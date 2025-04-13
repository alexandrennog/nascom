Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsEstado
Imports ncRegras.nsEstado
Imports ncDados.nsLoja
Imports ncRegras.nsLoja
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fLojaForm

  Public cid As Nullable(Of Integer)

  Private Sub Excluir()
    Dim dados As dLoja
    Dim regras As rLoja

    Try

      If Not Me.cid.Equals(Nothing) Then
        If Not Me.cid.ToString().Equals(String.Empty) Then
          If Not Me.cid.Equals(0) Then
            If MessageBox.Show("Confirma EXCLUSÃO das informações?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
              dados = New dLoja
              regras = New rLoja

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

      MessageBox.Show("Erro na exclusão dos dados de Loja.")

    End Try
  End Sub

  Private Function Validar() As Boolean
    Try

      If String.IsNullOrEmpty(txtCodigo.Text.Trim()) Then
        MessageBox.Show("É necessário informar o Código!")
        Return False
      End If

      If String.IsNullOrEmpty(txtNomeFantasia.Text.Trim()) Then
        MessageBox.Show("É necessário informar o Nome Fantasia!")
        Return False
      End If

    Catch ex As Exception
      Return False
    End Try

    Return True
  End Function

  Private Sub Salvar()
    Dim dados As dLoja
    Dim regras As rLoja
    Dim tipoMsg As String = String.Empty
    Dim tipoAcao As String = String.Empty
    Dim novoCID As Integer

    Try

      If Not Validar() Then
        Exit Sub
      End If

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

      If MessageBox.Show("Confirma " & tipoMsg & " das informações?", tipoMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
        dados = New dLoja
        regras = New rLoja

        dados.cid = Me.cid
        dados.nomeFantasia = cFuncoes.TratarTexto(txtNomeFantasia.Text)
        dados.logradouro = cFuncoes.TratarTexto(txtLogradouro.Text)
        dados.numero = cFuncoes.TratarInteiro(txtNumero.Text)
        dados.complemento = cFuncoes.TratarTexto(txtComplemento.Text)
        dados.bairro = cFuncoes.TratarTexto(txtBairro.Text)
        dados.cidade = cFuncoes.TratarTexto(txtCidade.Text)
        dados.estado_cid = cFuncoes.TratarInteiro(cboEstado.SelectedValue)
        dados.cep = cFuncoes.TratarInteiro(txtCep.Text)
        dados.razaoSocial = cFuncoes.TratarTexto(txtRazaoSocial.Text)
        dados.cnpj = cFuncoes.TratarTexto(txtCnpj.Text)
        dados.ddd = cFuncoes.TratarInteiro(txtDDD.Text)
        dados.telefone = cFuncoes.TratarInteiro(txtTelefone.Text)
        dados.ramal = cFuncoes.TratarInteiro(txtRamal.Text)
        dados.nomeContato = cFuncoes.TratarTexto(txtContato.Text)
        dados.codigo = cFuncoes.TratarTexto(txtCodigo.Text)
        dados.spc_codigo_associado = cFuncoes.TratarTexto(txtSpcCodigoAssociado.Text)
        dados.spc_controle_informante = cFuncoes.TratarTexto(txtSpcControleInformante.Text)
        dados.spc_nome_informante = cFuncoes.TratarTexto(txtSpcNomeInformante.Text)
        dados.situacao = cFuncoes.TratarTexto(cboSituacao.SelectedValue)
                dados.Inscestadual = cFuncoes.RetornarTexto(txtInscEstadual.Text)
                If tipoAcao.Equals("i") Then
                    novoCID = regras.Incluir(dados)

                    Me.cid = novoCID
                    ExibirInformacoesTela()
                ElseIf tipoAcao.Equals("a") Then
                    regras.Alterar(dados)

          ExibirInformacoesTela()
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na " & tipoMsg.ToLower() & " dos dados de Loja.")

    End Try
  End Sub

  Public Sub Filtrar()
    mdiPrincipal.CarregarLojaFiltro()
  End Sub

  Private Sub LimparCampos()
    txtCodigo.Text = String.Empty
    txtNomeFantasia.Text = String.Empty
    txtCnpj.Text = String.Empty
    txtRazaoSocial.Text = String.Empty
    txtLogradouro.Text = String.Empty
    txtNumero.Text = String.Empty
    txtComplemento.Text = String.Empty
    txtBairro.Text = String.Empty
    txtCidade.Text = String.Empty
    txtCep.Text = String.Empty
    txtDDD.Text = String.Empty
    txtTelefone.Text = String.Empty
    txtRamal.Text = String.Empty
    txtContato.Text = String.Empty
    txtSpcCodigoAssociado.Text = String.Empty
    txtSpcControleInformante.Text = String.Empty
        txtSpcNomeInformante.Text = String.Empty
        txtInscEstadual.Text = String.Empty
        If cboEstado.Items.Count > 0 Then
      cboEstado.SelectedIndex = 0
    End If
    If cboSituacao.Items.Count > 0 Then
      cboSituacao.SelectedIndex = 0
    End If
  End Sub

  Private Sub ExibirInformacoesTela()
    Dim regras As rLoja
    Dim dados As dLoja

    Try

      If Not Me.cid.Equals(Nothing) Then
        If Not Me.cid.Equals(0) Then

          regras = New rLoja()

          dados = regras.Consultar(Me.cid)

          If Not dados Is Nothing Then
            txtCodigo.Text = cFuncoes.RetornarTexto(dados.codigo)
            txtNomeFantasia.Text = cFuncoes.RetornarTexto(dados.nomeFantasia)
            txtCnpj.Text = cFuncoes.RetornarTexto(dados.cnpj)
            txtRazaoSocial.Text = cFuncoes.RetornarTexto(dados.razaoSocial)
            txtLogradouro.Text = cFuncoes.RetornarTexto(dados.logradouro)
            txtNumero.Text = cFuncoes.RetornarTexto(dados.numero)
            txtComplemento.Text = cFuncoes.RetornarTexto(dados.complemento)
            txtBairro.Text = cFuncoes.RetornarTexto(dados.bairro)
            txtCidade.Text = cFuncoes.RetornarTexto(dados.cidade)
            txtCep.Text = cFuncoes.RetornarTexto(dados.cep)
            txtDDD.Text = cFuncoes.RetornarTexto(dados.ddd)
            txtTelefone.Text = cFuncoes.RetornarTexto(dados.telefone)
            txtRamal.Text = cFuncoes.RetornarTexto(dados.ramal)
            txtContato.Text = cFuncoes.RetornarTexto(dados.nomeContato)
            txtSpcCodigoAssociado.Text = cFuncoes.RetornarTexto(dados.spc_codigo_associado)
            txtSpcControleInformante.Text = cFuncoes.RetornarTexto(dados.spc_controle_informante)
                        txtSpcNomeInformante.Text = cFuncoes.RetornarTexto(dados.spc_nome_informante)
                        txtInscEstadual.Text = cFuncoes.RetornarTexto(dados.Inscestadual)

                        If cboEstado.Items.Count > 0 Then
              cboEstado.SelectedIndex = 0
            End If
            If cFuncoes.ValidarValor(dados.estado_cid) Then
              cboEstado.SelectedValue = cFuncoes.RetornarInteiro(dados.estado_cid)
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

      MessageBox.Show("Erro na consulta dos dados de Loja.")

    End Try
  End Sub

  Private Sub fLojaForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

  Private Sub fLojaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    LimparCampos()
    CarregarComboSituacao()
    CarregarComboEstado()
    ExibirInformacoesTela()
  End Sub

  Private Sub CarregarComboEstado()
    Dim regras As rEstado
    Dim colecao As ColecaoEstado

    Try

      cboEstado.Items.Clear()

      regras = New rEstado()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then
        colecao.Insert(0, New dEstado())

        cboEstado.ValueMember = "cid"
        cboEstado.DisplayMember = "sigla"
        cboEstado.DataSource = colecao
        cboEstado.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Estados.")

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

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
    Salvar()
  End Sub

  Private Sub btoExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluir.Click
    Excluir()
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
      mdiPrincipal.FecharTela()
    End If
  End Sub

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    Filtrar()
  End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class