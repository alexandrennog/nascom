Imports ncComum.nsExcecao
Imports ncDados.nsCliente
Imports ncRegras.nsCliente

Public Class fImportarArquivos


  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

  Private Sub fProdutoLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown, rbtImportarProduto.KeyDown, rbtImportarCrediario.KeyDown
    Select Case e.KeyCode
      Case Keys.F5
        btoFiltro_Click(sender, e)
      Case Keys.Escape
        mdiPrincipal.FecharTela()
      Case Keys.Enter
        btoSalvar_Click(sender, e)
    End Select
  End Sub

  Private Sub fImportarArquivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    OpenFileDialog1.ShowDialog()
  End Sub

  Private Function ValidarArquivo() As Boolean
    Dim fluxoTexto As System.IO.StreamReader
    Dim linhaTexto As String = Nothing
    Dim count As Integer = 0

    If IO.File.Exists(txtNome.Text) Then
      fluxoTexto = New System.IO.StreamReader(txtNome.Text)

      linhaTexto = fluxoTexto.ReadLine

      While linhaTexto <> Nothing
        If rbtImportarCliente.Checked Then
          If linhaTexto.Length <> 884 Then
            MessageBox.Show("Formato de arquivo incorreto!")
            Return False
          End If
        ElseIf rbtImportarProduto.Checked Then
          If linhaTexto.Length < 1670 Then '1673
            MessageBox.Show("Formato de arquivo incorreto!")
            Return False
          End If
        ElseIf rbtImportarCrediario.Checked Then
          If linhaTexto.Length <> 102 Then
            MessageBox.Show("Formato de arquivo incorreto!")
            Return False
          End If
        End If
        count += 1
        linhaTexto = fluxoTexto.ReadLine
      End While

      fluxoTexto.Close()

      ProgressBar1.Value = 0

      ProgressBar1.Maximum = count

      Return True

    Else
      MessageBox.Show("Arquivo não existe")
      Return False
    End If

  End Function

  Private Sub ImportarArquivo()
    Dim fluxoTexto As System.IO.StreamReader = Nothing
    Dim linhaTexto As String = Nothing

    If IO.File.Exists(txtNome.Text) Then
      Try
        fluxoTexto = New System.IO.StreamReader(txtNome.Text)

        linhaTexto = fluxoTexto.ReadLine

        While linhaTexto <> Nothing
          If rbtImportarCliente.Checked Then
            If rbtAbcd.Checked Then
              CadastrarCliente(linhaTexto)
            ElseIf rbtOutros.Checked Then
              CadastrarClienteOrange(linhaTexto)
            End If
          ElseIf rbtImportarCrediario.Checked Then
            CadastrarCrediario(linhaTexto)
          End If
          ProgressBar1.Increment(1)
          linhaTexto = fluxoTexto.ReadLine
        End While

        fluxoTexto.Close()

        MessageBox.Show("Importação Concluída")
        ProgressBar1.Value = 0

      Catch ex As Exception
        If Not IsNothing(fluxoTexto) Then
          fluxoTexto.Close()
        End If
        MessageBox.Show(ex.Message)
      End Try
    Else
      MessageBox.Show("Arquivo não existe")
    End If

  End Sub

  Private Sub CadastrarCrediario(ByVal linha As String)
    Dim regraCrediario As New ncRegras.nsCrediario.rCrediario
    Dim crediario As New ncDados.nsCrediario.dCrediario
    Dim parcela As New ncDados.nsCrediario.dParcelas
    Dim listacrediario As ncDados.nsCrediario.ColecaoCrediario

    Try
      ' Crediário
      crediario.LojaId = linha.Substring(0, 3) ' 3
      crediario.clienteId = linha.Substring(10, 6) ' 16 
      crediario.controle = linha.Substring(3, 6).Trim()  ' 9
      crediario.NotaFiscal = linha.Substring(16, 7).Trim()  ' 23 nota fiscal
      crediario.DataVenda = linha.Substring(26, 4) & "/" & linha.Substring(30, 2) & "/" & linha.Substring(32, 2) ' 34
      crediario.Terminal = linha.Substring(99, 3).Trim()
      crediario.ValorVenda = CDec(linha.Substring(34, 10)) / 100 ' 44
      listacrediario = regraCrediario.Consultar(crediario)
      If IsNothing(listacrediario) Then
        crediario.ValorTotal = CDec(linha.Substring(52, 10)) / 100 ' 62
        crediario.ValorPago = CDec(linha.Substring(70, 10)) / 100 ' 80
        crediario.SaldoDevedor = crediario.ValorTotal - crediario.ValorPago
        crediario.Parcelas = 1
        parcela.crediarioId = regraCrediario.IncluirCrediario(crediario)
      Else
        crediario = listacrediario(0)
        crediario.ValorTotal += CDec(linha.Substring(52, 10)) / 100 ' 62
        crediario.ValorPago += CDec(linha.Substring(70, 10)) / 100 ' 80
        crediario.SaldoDevedor = crediario.ValorTotal - crediario.ValorPago
        If crediario.SaldoDevedor < 0 Then
          crediario.SaldoDevedor = 0
        End If
        crediario.Parcelas += 1
        regraCrediario.AlterarCrediario(crediario)
        parcela.crediarioId = crediario.cid
      End If

      ' parcelas
      parcela.codigoBarras = linha.Substring(3, 7).Trim()  ' 10
      ' 23 + 3 = 26 loja
      parcela.dataEmissao = linha.Substring(26, 4) & "/" & linha.Substring(30, 2) & "/" & linha.Substring(32, 2) ' 34
      parcela.dataVecimento = linha.Substring(44, 4) & "/" & linha.Substring(48, 2) & "/" & linha.Substring(50, 2) ' 52
      parcela.valor = CDec(linha.Substring(52, 10)) / 100 ' 62
      If linha.Substring(62, 8).Trim() <> "00000000" Then
        parcela.dataPagamento = linha.Substring(62, 4) & "/" & linha.Substring(66, 2) & "/" & linha.Substring(68, 2) ' 70 
      End If
      parcela.valorPago = CDec(linha.Substring(70, 10)) / 100 ' 80
      parcela.situacao = linha.Substring(80, 2).Trim() ' 82
      If parcela.situacao = "00" Then
        parcela.valorReceber = parcela.valor
      End If
      ' 82 + 3 = 85 loja
      ' 85 + 6 = 91 cliente
      ' 91 + 8 = 99 vencimento

      regraCrediario.IncluirParcela(parcela)

    Catch ex As Exception
      Throw ex
    End Try

  End Sub

  Private Sub CadastrarCliente(ByVal linha As String)

    Dim regraCliente As rCliente
    Dim regraClienteEndereco As rClienteEndereco
    Dim regraClienteFinanceiro As rClienteFinanceiro
    Dim regraClienteProfissional As rClienteProfissional

    Dim estado As ncDados.nsEstado.dEstado
    Dim listaestado As ncDados.nsEstado.ColecaoEstado
    Dim regraEstado As ncRegras.nsEstado.rEstado

    Dim clienteEndereco As dClienteEndereco
    Dim cliente As New dCliente
    Dim clienteFinanceiro As New dClienteFinanceiro
    Dim clienteProfissional As New dClienteProfissional

    Try

      ' Dados do cliente
      ' 0 + 3 = 3
      cliente.cid = linha.Substring(3, 6)
      cliente.codigo = linha.Substring(3, 6)  ' 9
      cliente.nome = linha.Substring(9, 40).Trim()  ' 49
      cliente.telefone = linha.Substring(129, 12).Trim().Replace(" ", "") ' 141
      cliente.dataNascimento = linha.Substring(245, 6).Trim() ' 251
      cliente.naturalidade = linha.Substring(251, 20).Trim() & " " & linha.Substring(271, 2).Trim() ' 271' 273 
      cliente.estadoCivil = linha.Substring(273, 1).Trim() '273 + 12 ' 285
      If linha.Substring(285, 1) = "X" Then ' 286
        cliente.sexo = "M"
      ElseIf linha.Substring(286, 1) = "X" Then ' 287
        cliente.sexo = "F"
      End If
      cliente.carteiraProfissional = linha.Substring(287, 8).Trim() & " " & linha.Substring(295, 8).Trim() ' 295 ' 303
      cliente.cpf = linha.Substring(303, 14).Trim() ' 318
      cliente.rg = linha.Substring(317, 14).Trim() ' 331
      cliente.nomeMae = linha.Substring(342, 34).Trim() ' 376
      cliente.nomePai = linha.Substring(376, 34).Trim() ' 410
      cliente.dataInclusao = linha.Substring(805, 6).Trim() ' 841

      regraCliente = New rCliente()
      cliente.cid = regraCliente.Incluir(cliente)

      ' Endereço atual 
      clienteEndereco = New ncDados.nsCliente.dClienteEndereco()
      clienteEndereco.cliente_cid = cliente.cid
      clienteEndereco.tipoEndereco = ncComum.nsConstantes.cConstantes.EnderecoAtual
      clienteEndereco.logradouro = linha.Substring(49, 35).Trim() ' 84
      clienteEndereco.bairro = linha.Substring(84, 15).Trim() ' 99
      clienteEndereco.cidade = linha.Substring(99, 20).Trim() ' 119
      estado = New ncDados.nsEstado.dEstado()
      estado.sigla = linha.Substring(119, 2).Trim  ' 121
      If estado.sigla <> "" Then
        regraEstado = New ncRegras.nsEstado.rEstado
        listaestado = regraEstado.Consultar(estado)
        If Not IsNothing(listaestado) Then
          clienteEndereco.estado_cid = listaestado(0).cid
        End If
      End If
      clienteEndereco.cep = linha.Substring(121, 8).Trim() ' 129
      If linha.Substring(141, 1) = "X" Then ' 142
        clienteEndereco.tipoResidencia = "P"
      ElseIf linha.Substring(142, 1) = "X" Then ' 143
        clienteEndereco.tipoResidencia = "R"
      ElseIf linha.Substring(143, 1) = "X" Then ' 144
        clienteEndereco.tipoResidencia = "A"
      End If
      clienteEndereco.valor = CDec(linha.Substring(144, 11)) / 100 ' 155
      clienteEndereco.tempo = linha.Substring(155, 10).Trim() ' 165

      regraClienteEndereco = New rClienteEndereco()
      regraClienteEndereco.Incluir(clienteEndereco)

      ' Endereço anterior
      clienteEndereco = New ncDados.nsCliente.dClienteEndereco()
      clienteEndereco.cliente_cid = cliente.cid
      clienteEndereco.tipoEndereco = ncComum.nsConstantes.cConstantes.EnderecoAnterior
      clienteEndereco.logradouro = linha.Substring(165, 35).Trim() ' 200
      clienteEndereco.bairro = linha.Substring(200, 15).Trim() ' 215
      clienteEndereco.cidade = linha.Substring(215, 20).Trim() ' 235
      estado = New ncDados.nsEstado.dEstado()
      estado.sigla = linha.Substring(235, 2).Trim() ' 237
      If estado.sigla <> "" Then
        regraEstado = New ncRegras.nsEstado.rEstado
        listaestado = regraEstado.Consultar(estado)
        If Not IsNothing(listaestado) Then
          clienteEndereco.estado_cid = listaestado(0).cid
        End If
      End If
      clienteEndereco.cep = linha.Substring(237, 8).Trim() ' 245

      regraClienteEndereco = New rClienteEndereco()
      regraClienteEndereco.Incluir(clienteEndereco)

      ' Dados Profissionais
      clienteProfissional.cliente_cid = cliente.cid
      clienteProfissional.empresa = linha.Substring(410, 30).Trim() ' 440
      clienteProfissional.logradouro = linha.Substring(440, 30).Trim() ' 470
      clienteProfissional.bairro = linha.Substring(470, 15).Trim() ' 485
      clienteProfissional.cidade = linha.Substring(485, 15).Trim() ' 500
      estado = New ncDados.nsEstado.dEstado()
      estado.sigla = linha.Substring(500, 2).Trim() ' 502
      If estado.sigla <> "" Then
        regraEstado = New ncRegras.nsEstado.rEstado
        listaestado = regraEstado.Consultar(estado)
        If Not IsNothing(listaestado) Then
          clienteProfissional.estado_cid = listaestado(0).cid
        End If
      End If
      clienteProfissional.cep = linha.Substring(502, 8).Trim() ' 510
      clienteProfissional.telefone = linha.Substring(510, 12).Trim().Replace(" ", "")  ' 522
      clienteProfissional.ramal = linha.Substring(522, 5).Trim() ' 527
      clienteProfissional.cargo = linha.Substring(527, 15).Trim() ' 542
      clienteProfissional.dataAdmissao = linha.Substring(542, 6).Trim() ' 548
      clienteProfissional.salario = CDec(linha.Substring(548, 11)) / 100 ' 559

      regraClienteProfissional = New rClienteProfissional()
      regraClienteProfissional.Incluir(clienteProfissional)

      ' TODO: Dados conjuge '559 + 170 = 729

      ' Dados Financeiros
      clienteFinanceiro.cliente_cid = cliente.cid
      clienteFinanceiro.limite = CDec(linha.Substring(331, 10)) / 100 ' 341
      clienteFinanceiro.situacaoCrediario = linha.Substring(341, 1) ' 342
      clienteFinanceiro.observacoes = linha.Substring(729, 40).Trim() ' 769
      ' Filler 769 + 30 = 799
      clienteFinanceiro.dataNegativacao = linha.Substring(799, 6).Trim() ' 805
      clienteFinanceiro.motivo = linha.Substring(805, 30).Trim() ' 835

      regraClienteFinanceiro = New rClienteFinanceiro()
      regraClienteFinanceiro.Incluir(clienteFinanceiro)

      ' Indic Cli 841 + 3 = 844
      ' Nome Indic Cli 844 + 40 = 884
    Catch ex As Exception
      Throw ex
    End Try

  End Sub

  Private Sub CadastrarClienteOrange(ByVal linha As String)

    Dim regraCliente As rCliente
    Dim regraClienteEndereco As rClienteEndereco
    Dim regraClienteFinanceiro As rClienteFinanceiro
    Dim regraClienteProfissional As rClienteProfissional

    Dim estado As ncDados.nsEstado.dEstado
    Dim listaestado As ncDados.nsEstado.ColecaoEstado
    Dim regraEstado As ncRegras.nsEstado.rEstado

    Dim clienteEndereco As dClienteEndereco
    Dim cliente As New dCliente
    Dim clienteFinanceiro As New dClienteFinanceiro
    Dim clienteProfissional As New dClienteProfissional

    Try

      ' Dados do cliente
      ' 0 + 3 = 3
      cliente.codigo = linha.Substring(3, 6)  ' 9
      cliente.nome = linha.Substring(9, 40).Trim()  ' 49
      cliente.telefone = linha.Substring(129, 12).Trim().Replace(" ", "") ' 141
      cliente.dataNascimento = linha.Substring(245, 6).Trim() ' 251
      cliente.naturalidade = linha.Substring(251, 20).Trim() & " " & linha.Substring(271, 2).Trim() ' 271' 273 
      cliente.estadoCivil = linha.Substring(273, 1).Trim() '273 + 12 ' 285
      If linha.Substring(285, 1) = "X" Then ' 286
        cliente.sexo = "M"
      ElseIf linha.Substring(286, 1) = "X" Then ' 287
        cliente.sexo = "F"
      End If
      cliente.carteiraProfissional = linha.Substring(287, 8).Trim() & " " & linha.Substring(295, 8).Trim() ' 295 ' 303
      cliente.cpf = linha.Substring(303, 14).Trim() ' 318
      cliente.rg = linha.Substring(317, 14).Trim() ' 331
      cliente.nomeMae = linha.Substring(342, 34).Trim() ' 376
      cliente.nomePai = linha.Substring(376, 34).Trim() ' 410
      cliente.dataInclusao = linha.Substring(805, 6).Trim() ' 841

      regraCliente = New rCliente()
      cliente.cid = regraCliente.Incluir(cliente)

      ' Endereço atual 
      clienteEndereco = New ncDados.nsCliente.dClienteEndereco()
      clienteEndereco.cliente_cid = cliente.cid
      clienteEndereco.tipoEndereco = ncComum.nsConstantes.cConstantes.EnderecoAtual
      clienteEndereco.logradouro = linha.Substring(49, 35).Trim() ' 84
      clienteEndereco.bairro = linha.Substring(84, 15).Trim() ' 99
      clienteEndereco.cidade = linha.Substring(99, 20).Trim() ' 119
      estado = New ncDados.nsEstado.dEstado()
      estado.sigla = linha.Substring(119, 2).Trim  ' 121
      If estado.sigla <> "" Then
        regraEstado = New ncRegras.nsEstado.rEstado
        listaestado = regraEstado.Consultar(estado)
        If Not IsNothing(listaestado) Then
          clienteEndereco.estado_cid = listaestado(0).cid
        End If
      End If
      clienteEndereco.cep = linha.Substring(121, 8).Trim() ' 129
      If linha.Substring(141, 1) = "X" Then ' 142
        clienteEndereco.tipoResidencia = "P"
      ElseIf linha.Substring(142, 1) = "X" Then ' 143
        clienteEndereco.tipoResidencia = "R"
      ElseIf linha.Substring(143, 1) = "X" Then ' 144
        clienteEndereco.tipoResidencia = "A"
      End If
      clienteEndereco.valor = CDec(linha.Substring(144, 11)) / 100 ' 155
      clienteEndereco.tempo = linha.Substring(155, 10).Trim() ' 165

      regraClienteEndereco = New rClienteEndereco()
      regraClienteEndereco.Incluir(clienteEndereco)

      ' Endereço anterior
      clienteEndereco = New ncDados.nsCliente.dClienteEndereco()
      clienteEndereco.cliente_cid = cliente.cid
      clienteEndereco.tipoEndereco = ncComum.nsConstantes.cConstantes.EnderecoAnterior
      clienteEndereco.logradouro = linha.Substring(165, 35).Trim() ' 200
      clienteEndereco.bairro = linha.Substring(200, 15).Trim() ' 215
      clienteEndereco.cidade = linha.Substring(215, 20).Trim() ' 235
      estado = New ncDados.nsEstado.dEstado()
      estado.sigla = linha.Substring(235, 2).Trim() ' 237
      If estado.sigla <> "" Then
        regraEstado = New ncRegras.nsEstado.rEstado
        listaestado = regraEstado.Consultar(estado)
        If Not IsNothing(listaestado) Then
          clienteEndereco.estado_cid = listaestado(0).cid
        End If
      End If
      clienteEndereco.cep = linha.Substring(237, 8).Trim() ' 245

      regraClienteEndereco = New rClienteEndereco()
      regraClienteEndereco.Incluir(clienteEndereco)

      ' Dados Profissionais
      clienteProfissional.cliente_cid = cliente.cid
      clienteProfissional.empresa = linha.Substring(410, 30).Trim() ' 440
      clienteProfissional.logradouro = linha.Substring(440, 30).Trim() ' 470
      clienteProfissional.bairro = linha.Substring(470, 15).Trim() ' 485
      clienteProfissional.cidade = linha.Substring(485, 15).Trim() ' 500
      estado = New ncDados.nsEstado.dEstado()
      estado.sigla = linha.Substring(500, 2).Trim() ' 502
      If estado.sigla <> "" Then
        regraEstado = New ncRegras.nsEstado.rEstado
        listaestado = regraEstado.Consultar(estado)
        If Not IsNothing(listaestado) Then
          clienteProfissional.estado_cid = listaestado(0).cid
        End If
      End If
      clienteProfissional.cep = linha.Substring(502, 8).Trim() ' 510
      clienteProfissional.telefone = linha.Substring(510, 12).Trim().Replace(" ", "")  ' 522
      clienteProfissional.ramal = linha.Substring(522, 5).Trim() ' 527
      clienteProfissional.cargo = linha.Substring(527, 15).Trim() ' 542
      clienteProfissional.dataAdmissao = linha.Substring(542, 6).Trim() ' 548
      clienteProfissional.salario = CDec(linha.Substring(548, 11)) / 100 ' 559

      regraClienteProfissional = New rClienteProfissional()
      regraClienteProfissional.Incluir(clienteProfissional)

      ' TODO: Dados conjuge '559 + 170 = 729

      ' Dados Financeiros
      clienteFinanceiro.cliente_cid = cliente.cid
      clienteFinanceiro.limite = CDec(linha.Substring(331, 10)) / 100 ' 341
      clienteFinanceiro.situacaoCrediario = linha.Substring(341, 1) ' 342
      clienteFinanceiro.observacoes = linha.Substring(729, 40).Trim() ' 769
      ' Filler 769 + 30 = 799
      clienteFinanceiro.dataNegativacao = linha.Substring(799, 6).Trim() ' 805
      clienteFinanceiro.motivo = linha.Substring(805, 30).Trim() ' 835

      regraClienteFinanceiro = New rClienteFinanceiro()
      regraClienteFinanceiro.Incluir(clienteFinanceiro)

      ' Indic Cli 841 + 3 = 844
      ' Nome Indic Cli 844 + 40 = 884
    Catch ex As Exception
      Throw ex
    End Try

  End Sub

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
    If ValidarArquivo() Then
      ImportarArquivo()
    End If
  End Sub

  Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
    txtNome.Text = OpenFileDialog1.FileName
  End Sub

End Class