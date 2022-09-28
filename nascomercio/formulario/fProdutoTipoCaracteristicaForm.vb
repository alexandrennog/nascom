Imports ncDados.nsCaracteristica
Imports ncRegras.nsCaracteristica
Imports ncDados.nsProduto
Imports ncRegras.nsProduto
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Public Class fProdutoTipoCaracteristicaForm

  Public produtoTipo_cid As Nullable(Of Integer)

  Private Sub CarregarProdutoTipo()
    mdiPrincipal.CarregarProdutoTipoForm()
  End Sub

  Private Sub Salvar()

  End Sub

  Private Sub IncluirItem()
    Dim regras As rProdutoTipoCaracteristica
    Dim dados As dProdutoTipoCaracteristica
    Dim colecao As ColecaoProdutoTipoCaracteristica
    Dim caracteristica_cid As Integer
    Dim existe As Boolean = False

    Try

      If cboCaracteristica.Items.Count > 0 Then
        caracteristica_cid = cboCaracteristica.SelectedValue

        dados = New dProdutoTipoCaracteristica
        regras = New rProdutoTipoCaracteristica

        dados.produtoTipo_cid = Me.produtoTipo_cid
        dados.caracteristica_cid = caracteristica_cid

        colecao = regras.Consultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            existe = True
          End If
        End If

        If existe = False Then
          regras.Incluir(dados)

          CarregarListaCaracteristicas()
        Else
          MessageBox.Show("Característica já está cadastrada para esse Tipo de Produto.", "Cadastro de Característica", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na inclusão da característica.")

    End Try

  End Sub

  Private Sub ExcluirItem()
    Dim regras As rProdutoTipoCaracteristica
    Dim codigo As Integer

    Try

      If dgvCaracteristicas.Rows.Count > 0 Then
        regras = New rProdutoTipoCaracteristica()

        codigo = Convert.ToInt32(dgvCaracteristicas.Rows(dgvCaracteristicas.CurrentRow.Index).Cells("cid").Value)

        regras.Excluir(codigo)

        CarregarListaCaracteristicas()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na exclusão da característica.")

    End Try
  End Sub

  Private Sub CarregarComboCaracteristicas()
    Dim regras As rCaracteristica
    Dim colecao As ColecaoCaracteristica

    Try

      cboCaracteristica.Items.Clear()

      regras = New rCaracteristica()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then
        cboCaracteristica.ValueMember = "cid"
        cboCaracteristica.DisplayMember = "nome"
        cboCaracteristica.DataSource = colecao
        cboCaracteristica.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Características.")

    End Try
  End Sub

  Private Sub CarregarListaCaracteristicas()
    Dim regras As rProdutoTipoCaracteristica
    Dim colecao As ColecaoProdutoTipoCaracteristica

    Try

      dgvCaracteristicas.DataSource = Nothing
      dgvCaracteristicas.Rows.Clear()
      dgvCaracteristicas.Columns.Clear()
      dgvCaracteristicas.Refresh()

      regras = New rProdutoTipoCaracteristica()

      colecao = regras.ConsultarPorProdutoTipo(Me.produtoTipo_cid)

      dgvCaracteristicas.DataSource = colecao
      dgvCaracteristicas.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta da lista de Características.")

    End Try
  End Sub

  Private Sub CarregarDadosTipoProduto()
    Dim regras As rProdutoTipo
    Dim dados As dProdutoTipo

    Try

      regras = New rProdutoTipo()
      dados = regras.Consultar(Me.produtoTipo_cid)

      If Not dados Is Nothing Then
        txtTipo.Text = RetornarTexto(dados.nome)
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Tipo de Produto.")

    End Try
  End Sub

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Salvar()
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

  Private Sub fProdutoTipoCaracteristica_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        mdiPrincipal.FecharTela()
      Case Keys.F1
        IncluirItem()
      Case Keys.F2
        ExcluirItem()
      Case Keys.F5
        CarregarProdutoTipo()
      Case Keys.Enter
        Salvar()
    End Select
  End Sub

  Private Sub fProdutoTipoCaracteristica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    CarregarComboCaracteristicas()
    CarregarDadosTipoProduto()
    CarregarListaCaracteristicas()
  End Sub

  Private Sub btoIncluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoIncluirItem.Click
    IncluirItem()
  End Sub

  Private Sub btoExcluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluirItem.Click
    ExcluirItem()
  End Sub

  Private Sub btoTipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoTipo.Click
    fProdutoTipoForm.cid = Me.produtoTipo_cid
    CarregarProdutoTipo()
  End Sub

End Class