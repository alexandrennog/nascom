Imports ncDados.nsProduto
Imports ncRegras.nsProduto
Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsGiro
Imports ncRegras.nsGiro
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Public Class fGiroForm

  Public produto_cid As Nullable(Of Integer)
  Public item As Nullable(Of Integer)

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
    Salvar()
  End Sub

  Private Function Validar() As Boolean
    If Not ValidarInteiro(txtQuantidade.Text) Then
      MessageBox.Show("Quantidade de Produtos inválido!", "Giro de Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
      txtQuantidade.Focus()
      Return False
    End If
    If Not ValidarData(txtDataInicio.Text) Then
      MessageBox.Show("Data inicial inválida!", "Giro de Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
      txtDataInicio.Focus()
      Return False
    End If
    If Not ValidarInteiro(txtDias.Text) Then
      MessageBox.Show("Quantidade de Dias inválido!", "Giro de Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
      txtDias.Focus()
      Return False
    End If
    If Not ValidarData(txtDataFim.Text) Then
      MessageBox.Show("Data final inválida!", "Giro de Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
      txtDataFim.Focus()
      Return False
    End If
    If txtDataFim.Text < txtDataInicio.Text Then
      MessageBox.Show("Data Final não pode ser anterior a Data Inicial!", "Giro de Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
      txtDataInicio.Focus()
      Return False
    End If

    Return True
  End Function

  Private Sub Salvar()
    Dim dados As dGiro
    Dim regras As rGiro

    Try

      If Validar() Then
        dados = New dGiro
        regras = New rGiro

        dados.produto_cid = Me.produto_cid
        dados.codigoBarras = TratarTexto(txtCodigoBarras.Text)
        dados.quantidade = TratarInteiro(txtQuantidade.Text)
        dados.dataInicio = TratarTexto(FormatarData(txtDataInicio.Text))
        dados.dataFim = TratarTexto(FormatarData(txtDataFim.Text))
        dados.dias = TratarTexto(txtDias.Text)
        dados.usuario_cid = TratarInteiro(mdiPrincipal.gUsuario.cid)
        dados.usuario_nomeCompleto = TratarTexto(mdiPrincipal.gUsuario.nomeCompleto)
        dados.dataAtual = TratarTexto(FormatarData(Now().ToString()))
        dados.situacao = "A"

        regras.Excluir(dados)
        regras.Incluir(dados)

        MessageBox.Show("Atualização dos dados de Giro efetuada com sucesso!", "Giro de Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LimparTela()
        CarregarDadosGiro()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message, "Giro de Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)

    Catch ex As Exception

      MessageBox.Show("Erro na atualização dos dados de Giro.", "Giro de Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Try
  End Sub

  Private Sub btoExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluir.Click
    Excluir()
  End Sub

  Private Sub Excluir()
    Dim dados As dGiro
    Dim regras As rGiro

    Try

      dados = New dGiro
      regras = New rGiro

      dados.produto_cid = Me.produto_cid
      dados.codigoBarras = txtCodigoBarras.Text

      regras.Excluir(dados)

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na exclusão dos dados de Giro.")

    End Try
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    Me.Close()
  End Sub

  Private Sub fGiroForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        Me.Close()
      Case Keys.Enter
        Salvar()
      Case Keys.F12
        Excluir()
    End Select
  End Sub

  Private Sub LimparTela()
    txtQuantidade.Clear()
    txtDataInicio.Clear()
    txtDataFim.Clear()
    txtDias.Clear()
  End Sub

  Private Sub fGiroForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    LimparTela()
    CarregarDadosProdutoItem()
    CarregarDadosGiro()
  End Sub

  Private Sub CarregarDadosGiro()
    Dim dados As dGiro
    Dim regras As rGiro
    Dim colecao As ColecaoGiro

    Try

      dados = New dGiro
      regras = New rGiro

      dados.produto_cid = Me.produto_cid
      dados.codigoBarras = txtCodigoBarras.Text

      colecao = regras.Consultar(dados)

      If colecao IsNot Nothing Then
        If colecao.Count = 1 Then
          txtQuantidade.Text = RetornarTexto(colecao(0).quantidade)
          txtDataInicio.Text = RetornarTexto(FormatarData(colecao(0).dataInicio))
          txtDataFim.Text = RetornarTexto(FormatarData(colecao(0).dataFim))
          txtDias.Text = RetornarTexto(colecao(0).dias)
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Giro.")

    End Try
  End Sub

  Private Sub CarregarDadosProdutoItem()
    Dim regras As rProduto
    Dim dados As dProduto
    Dim regrasItem As rProdutoItem
    Dim dadosItem As dProdutoItem
    Dim colecao As ColecaoProdutoItem

    Try

      If Not Me.produto_cid.Equals(Nothing) Then
        If Not Me.produto_cid.Equals(0) Then

          regras = New rProduto()

          dados = regras.Consultar(Me.produto_cid)

          txtProduto.Text = dados.descricao
        End If
      End If

      If Not Me.item.Equals(Nothing) Then
        regrasItem = New rProdutoItem()
        dadosItem = New dProdutoItem()

        dadosItem.produtos_cid = Me.produto_cid
        dadosItem.item = Me.item

        colecao = regrasItem.Consultar(dadosItem)

        For Each dadosItem In colecao
          If dadosItem.caracteristicas_codigo.Equals("codigoBarras") Then
            txtCodigoBarras.Text = dadosItem.valor
          End If
        Next
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Giro de Produto.")

    End Try
  End Sub

  Private Sub txtDataInicio_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDataInicio.Leave
    Try
      If ValidarData(txtDataInicio.Text) Then
        If Not String.IsNullOrEmpty(txtDias.Text.Trim()) Then
          If ValidarInteiro(txtDias.Text) Then
            txtDataFim.Text = FormatarData(DateAdd(DateInterval.Day, Convert.ToInt32(txtDias.Text), RetornarDataValida(FormatarData(txtDataInicio.Text))))
          End If
        Else
          If ValidarData(txtDataFim.Text) Then
            txtDias.Text = DateDiff(DateInterval.Day, RetornarDataValida(FormatarData(txtDataInicio.Text)), RetornarDataValida(FormatarData(txtDataFim.Text)))
          End If
        End If
      End If
    Catch ex As Exception

    End Try
  End Sub

  Private Sub txtDataFim_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDataFim.Leave
    Try
      If ValidarData(txtDataFim.Text) Then
        If Not String.IsNullOrEmpty(txtDias.Text.Trim()) Then
          If ValidarInteiro(txtDias.Text) Then
            txtDataInicio.Text = FormatarData(DateAdd(DateInterval.Day, Convert.ToInt32(txtDias.Text) * -1, RetornarDataValida(FormatarData(txtDataFim.Text))))
          End If
        Else
          If ValidarData(txtDataInicio.Text) Then
            txtDias.Text = DateDiff(DateInterval.Day, RetornarDataValida(FormatarData(txtDataInicio.Text)), RetornarDataValida(FormatarData(txtDataFim.Text)))
          End If
        End If
      End If
    Catch ex As Exception

    End Try
  End Sub

  Private Sub txtDias_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDias.Leave
    Try
      If ValidarInteiro(txtDias.Text) Then
        If Not String.IsNullOrEmpty(txtDataInicio.Text.Trim()) Then
          If ValidarData(txtDataInicio.Text) Then
            txtDataFim.Text = FormatarData(DateAdd(DateInterval.Day, Convert.ToInt32(txtDias.Text), RetornarDataValida(FormatarData(txtDataInicio.Text))))
          End If
        Else
          If ValidarData(txtDataFim.Text) Then
            txtDataInicio.Text = FormatarData(DateAdd(DateInterval.Day, Convert.ToInt32(txtDias.Text) * -1, RetornarDataValida(FormatarData(txtDataFim.Text))))
          End If
        End If
      End If
    Catch ex As Exception

    End Try
  End Sub

End Class