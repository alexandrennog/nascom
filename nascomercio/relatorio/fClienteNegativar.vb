Imports ncRegras.nsCliente
Imports ncDados.nsCliente
Imports ncRegras.nsCrediario
Imports ncDados.nsCrediario
Imports ncDados.nsEstado
Imports ncRegras.nsEstado
Imports ncDados.nsLoja
Imports ncRegras.nsLoja
Imports ncComum.nsExcecao
Imports ncComum.nsFuncoes
Imports ncComum.nsFuncoes.cFuncoes
Imports ncRegras.nsParametro
Imports ncDados.nsParametro
Imports ncComum.nsConstantes

Public Class fClienteNegativar

    Private arquivoCriado As Boolean = False
    Private arquivo As IO.StreamWriter = Nothing
    Private quantidade As Integer = 0
    Private loja As New dLoja()
    Private contLinha As Integer = 0
    Private clientesNegativados As ColecaoCliente
    Public filtro As New dCliente



    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        mdiPrincipal.FecharTela()
    End Sub

    Private Sub fProdutoLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                btnSelecionar_Click(Nothing, Nothing)
            Case Keys.F2
                btoDesmarcar_Click(Nothing, Nothing)
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.Enter
                SelecionarItem()
        End Select
    End Sub

    Private Sub SelecionarItem()

        Dim fClienteCrediario As New fClienteCrediarioForm

        fClienteCrediario.cliente_cid = Me.dgvProdutos.CurrentRow.Cells("codigo").Value
        fClienteCrediario.cliente_nome = Me.dgvProdutos.CurrentRow.Cells("nome").Value

        fClienteCrediario.ShowDialog()

    End Sub

    Private Sub fClienteNegativar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtDataInicial.Text = Today.AddDays(-60).ToString("dd/MM/yyyy")
        Me.txtDataFinal.Text = Today.AddDays(-30).ToString("dd/MM/yyyy")

    End Sub


    Private Sub Filtrar()
        Dim devedor As Boolean = False

        Dim regras As rCliente

        Dim regrasCrediario As rCrediario
        Dim parcelas As ColecaoParcelas
        Dim parcela As dParcelas = Nothing
        Dim filtroParcela As New dParcelas
        Dim linha As DataGridViewRow
        Dim clientes As ColecaoCliente
        Dim item As dCliente

        Dim dadosParametro As dParametro
        Dim regraParametro As New rParametro
        Dim minimo As Decimal

        Try

            regras = New rCliente()
            regrasCrediario = New rCrediario()
            clientesNegativados = New ColecaoCliente

            clientes = regras.Consultar(filtro)

            ' Minimo Negativar
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.MinimoNegativar)
            If Not IsNothing(dadosParametro) Then
                minimo = CDec(dadosParametro.valor)
            End If

            Me.ProgressBar1.Maximum = clientes.Count

            If Not IsNothing(clientes) Then

                For Each cliente As dCliente In clientes
                    devedor = False
                    Me.ProgressBar1.Increment(1)
                    If cliente.cid.Value > 1 Then
                        parcelas = regrasCrediario.ConsultarParcelasCliente(cliente.cid)
                        If Not IsNothing(parcelas) Then
                            For Each parcela In parcelas
                                If parcela.dataVecimento <= ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(Me.txtDataFinal.Text) And _
                                    parcela.dataVecimento >= ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(Me.txtDataInicial.Text) And parcela.valorReceber > 0 Then
                                    devedor = True
                                    Exit For
                                End If
                            Next
                        End If
                        If devedor Then
                            linha = dgvProdutos.Rows(dgvProdutos.Rows.Add())
                            linha.Cells("codigo").Value = cliente.cid.Value
                            linha.Cells("nome").Value = cliente.nome
                            linha.Cells("telefone").Value = cliente.ddd + " " + cliente.telefone
                            linha.Cells("valor").Value = parcela.valorReceber
                            linha.Cells("data").Value = parcela.dataVecimento
                            linha.Cells("cid").Value = parcela.cid
                            If parcela.valorReceber < minimo Then
                                linha.ReadOnly = True
                            End If
                            item = New dCliente
                            item.cid = cFuncoes.RetornarInteiro(cliente.cid.Value)
                            item.nome = cFuncoes.RetornarTexto(cliente.nome)
                            item.cpf = cFuncoes.RetornarTexto(cliente.cpf)
                            item.rg = cFuncoes.RetornarTexto(cliente.rg)
                            item.situacao = cFuncoes.RetornarTexto(cliente.situacao)
                            item.ddd = cFuncoes.RetornarTexto(cliente.ddd)
                            item.telefone = cFuncoes.RetornarTexto(cliente.telefone)
                            item.email = cFuncoes.RetornarTexto(cliente.email)
                            clientesNegativados.Add(item)
                        End If
                    End If
                Next
            End If

            Me.ProgressBar1.Value = 0

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta da lista de Clientes.")

        End Try

    End Sub

    Private Function NumeroRemessa() As Integer
        Dim regraParametro As New rParametro
        Dim dadosParametro As dParametro
        Dim valor As Integer

        Try

            ' Verifica existencia de parametro Numero Remessa
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.NumeroRemessa)
            If IsNothing(dadosParametro) Then
                dadosParametro = New dParametro()
                dadosParametro.cid = cConstantes.Parametros.NumeroRemessa
                dadosParametro.descricao = "Número de Remessa"
                dadosParametro.valor = 1
                regraParametro.Incluir(dadosParametro)
                valor = dadosParametro.valor
            Else
                dadosParametro.valor = dadosParametro.valor + 1
                regraParametro.Alterar(dadosParametro)
                valor = dadosParametro.valor
            End If
        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message)

        Catch ex As Exception
            MessageBox.Show("Erro na ALTERAÇÃO dos parâmetros.")

        End Try

        Return valor

    End Function

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        Dim rCF As rClienteFinanceiro = New rClienteFinanceiro()
        Dim rCE As rClienteEndereco = New rClienteEndereco()
        Dim rC As rCliente = New rCliente()
        Dim colFinanceiro As ColecaoClienteFinanceiro
        Dim clienteFinanceiro As New dClienteFinanceiro
        Dim clienteEndereco As New dClienteEndereco
        Dim cliente As New dCliente
        Dim dadosParcela As dParcelas
        Dim regraCrediario As rCrediario = New rCrediario()
        Dim parcelaCid As Integer
        Dim colParcelas As ColecaoParcelas

        If AbrirArquivo() = False Then
            Exit Sub
        End If

        contLinha = 0

        IncluirLinhaCabecalho()

        For Each linha As DataGridViewRow In dgvProdutos.Rows
            If linha.Cells("check").Value = True Then
                clienteFinanceiro.cliente_cid = linha.Cells("codigo").Value
                colFinanceiro = rCF.Consultar(clienteFinanceiro)
                If Not IsNothing(colFinanceiro) Then
                    For Each cf As dClienteFinanceiro In colFinanceiro
                        cf.situacaoCrediario = "N"
                        cliente = rC.ConsultarPorCID(cf.cliente_cid)
                        clienteEndereco = rCE.ConsultarPorCID(cf.cliente_cid)
                        parcelaCid = Convert.ToInt32(linha.Cells("cid").Value)

                        '-- Consultar todas as parcelas do cliente, dentro das datas especificadas, com valor a receber
                        colParcelas = regraCrediario.ConsultarParcelasVencidas(cf.cliente_cid)

                        For Each dadosParcela In colParcelas
                            If dadosParcela.valorReceber > 0 Then
                                If dadosParcela.dataVecimento <= ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(Me.txtDataFinal.Text) And _
                                      dadosParcela.dataVecimento >= ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(Me.txtDataInicial.Text) Then
                                    IncluirLinhaArquivo(cliente, cf, clienteEndereco, dadosParcela)
                                End If
                            End If
                        Next
                        rCF.Alterar(cf)
                    Next
                Else
                    MessageBox.Show("Cliente: " & clienteFinanceiro.cliente_cid.Value.ToString() & " não possui dados financeiros cadastrados. Favor cadastrar limite e gerar nova negativação.")
                End If
            End If
        Next

        IncluirLinhaRodape()

        FecharArquivo()

        MessageBox.Show("Clientes que foram selecionados NEGATIVADOS!")
    End Sub

    Private Sub btnSelecionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelecionar.Click

        For Each linha As DataGridViewRow In dgvProdutos.Rows
            If Not linha.ReadOnly Then
                linha.Cells("check").Value = True
            End If
        Next

    End Sub

    Private Sub btoDesmarcar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoDesmarcar.Click

        For Each linha As DataGridViewRow In dgvProdutos.Rows
            If Not linha.ReadOnly Then
                linha.Cells("check").Value = False
            End If
        Next

    End Sub

    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        Me.dgvProdutos.Rows.Clear()
        Me.ProgressBar1.Value = 0
        Filtrar()
    End Sub

    Private Sub IncluirLinhaArquivo(ByVal pCliente As dCliente, ByVal pClienteFinanceiro As dClienteFinanceiro, _
        ByVal pClienteEndereco As dClienteEndereco, ByVal pParcela As dParcelas)
        Dim conteudo As String = ""

        Dim rE As rEstado = New rEstado()
        Dim dE As dEstado = New dEstado()

        If IsNothing(pClienteEndereco) Then
            MessageBox.Show("Cliente: " & pCliente.codigo & " não possui endereço cadastrado.  Favor cadastrar endereço e gerar nova negativação.")
            Exit Sub
        End If

        quantidade += 1
        contLinha += 1

        conteudo += "1" '-- (1) Inclusão SCPC - 1
        conteudo += RetornarVazio(FormatarData(pCliente.dataNascimento)).PadLeft(8, "0"c) '-- Data Nascimento - DDMMAAAA - 8
        conteudo += RetornarVazio(pCliente.nome.Replace("*", "")).PadRight(50, " ").Substring(0, 50) '-- Nome Completo - sem acentuação e cedilha - 50
        If IsNothing(pCliente.cpf) Then
            conteudo += RetornarVazio("").PadLeft(11, "0"c) '-- CPF - 11
        Else
            conteudo += RetornarVazio(RetirarCaracterEspecial(pCliente.cpf)).Trim().PadLeft(11, "0"c).Substring(0, 11) '-- CPF - 11
        End If
        If IsNothing(pCliente.rg) OrElse IsNothing(pCliente.rgUf_cid) OrElse (String.IsNullOrEmpty(pCliente.rg.Trim()) OrElse pCliente.rgUf_cid.Equals(0)) Then
            conteudo += RetornarVazio("").PadLeft(11, "0"c) '-- RG - 11
            conteudo += RetornarVazio("").PadRight(2, " "c) '-- UF do RG - 2
        Else
            dE = rE.Consultar(pCliente.rgUf_cid)
            conteudo += RetornarVazio(RetirarCaracterEspecial(pCliente.rg)).Trim().PadLeft(11, "0"c).Substring(0, 11)  '-- RG - 11
            conteudo += RetornarVazio(dE.sigla).PadRight(2, " "c) '-- UF do RG - 2
        End If
        If Not pClienteEndereco.numero.HasValue Then
            conteudo += RetornarVazio(pClienteEndereco.logradouro & " " & pClienteEndereco.complemento).PadRight(50, " "c).Substring(0, 50) '-- Endereço Completo - 50
        Else
            conteudo += RetornarVazio(pClienteEndereco.logradouro & " " & pClienteEndereco.numero.Value.ToString() & " " & pClienteEndereco.complemento).PadRight(50, " "c).Substring(0, 50) '-- Endereço Completo - 50
        End If
        conteudo += RetornarVazio(pClienteEndereco.bairro).PadRight(30, " "c).Substring(0, 30) '-- Bairro - 30
        conteudo += RetornarVazio(pClienteEndereco.cidade).PadRight(30, " "c).Substring(0, 30) '-- Município - 30
        conteudo += RetornarVazio(pClienteEndereco.cep).PadLeft(8, "0"c) '-- CEP - 8
        If pClienteEndereco.estado_cid.HasValue() Then
            dE = rE.Consultar(pClienteEndereco.estado_cid.Value)
            conteudo += RetornarVazio(dE.sigla).PadRight(2, " "c) '-- UF - 2
        Else
            conteudo += New String(" "c, 2) '-- UF - 2
        End If
        conteudo += RetornarVazio("").PadRight(35, " "c) '-- Nome Conjuge - 35
        conteudo += RetornarVazio(pCliente.nomePai).PadRight(35, " "c).Substring(0, 35) '-- Nome Pai - 35
        conteudo += RetornarVazio(pCliente.nomeMae).PadRight(35, " "c).Substring(0, 35) '-- Nome Mae - 35
        conteudo += RetornarVazio(loja.spc_codigo_associado).PadLeft(8, "0"c) '-- Codigo Associado - 8
        conteudo += RetornarVazio(pCliente.codigo.PadLeft(7, " "c) + pParcela.codigoBarras.PadRight(15, " "c)).Substring(0, 22) '-- Contrato - 22
        conteudo += RetornarVazio(FormatarData(pParcela.dataVecimento.ToString())).PadLeft(8, "0"c) '-- Data Vencimento - DDMMAAAA - 8
        conteudo += RetornarVazio(FormatarData(pParcela.dataEmissao.ToString())).PadLeft(8, "0"c) '-- Data Venda - DDMMAAAA - 8
        conteudo += RetornarVazio(FormatarValorSemDecimal(pParcela.valor.ToString())).PadLeft(13, "0"c) '-- Valor - R$ 321,09 = ...032109 - 13
        conteudo += RetornarVazio("RT").PadRight(2, " "c) '-- Tipo Registro - (RT) Registro, (AV) Avalista - 2
        conteudo += RetornarVazio("").PadLeft(2, "0"c) '-- Codigo Retorno - 2
        conteudo += RetornarVazio("").PadRight(23, " "c) '-- Descrição Codigo Retorno - 23
        conteudo += RetornarVazio(contLinha).PadLeft(6, "0"c) '-- Numero Sequencia Registros - 6

        EscreverArquivo(conteudo)
    End Sub

    Private Sub IncluirLinhaCabecalho()
        Dim conteudo As String = ""
        Dim dataAtual As Date = DateTime.Now
        Dim data As String = dataAtual.Day.ToString() + "/" + dataAtual.Month.ToString() + "/" + dataAtual.Year.ToString()

        Dim cL As ColecaoLoja = Nothing
        Dim rL As rLoja = New rLoja()

        cL = rL.Consultar(loja)

        If cL IsNot Nothing Then
            loja = cL(0)
        End If

        contLinha += 1

        conteudo += "0" '-- Constante 0 - t[1]
        conteudo += RetornarVazio(loja.spc_codigo_associado).PadLeft(8, "0"c) '-- Codigo do Associado - t[8]
        conteudo += RetornarVazio(loja.spc_nome_informante).PadRight(35, " "c) '-- Nome do Informante - t[35]
        conteudo += FormatarData(data) '-- Data da Remessa - t[8]
        conteudo += RetornarVazio(NumeroRemessa()).PadLeft(8, "0"c) '-- Numero da Remessa - t[8]
        conteudo += RetornarVazio(loja.spc_controle_informante).PadRight(10, " "c) '-- Controle do Informante - t[10]
        conteudo += "REMESSA" '-- "REMESSA" - t[7]
        conteudo += "".PadLeft(317, " "c) '-- Constantes Brancos - t[317]
        conteudo += RetornarVazio(contLinha).PadLeft(6, "0"c) '-- Numero de Sequencia dos Registros - t[6]

        EscreverArquivo(conteudo)
    End Sub

    Private Sub IncluirLinhaRodape()
        Dim conteudo As String = ""

        contLinha += 1

        conteudo += "9" '-- Constante 9 - t[1]
        conteudo += RetornarVazio(quantidade.ToString()).PadLeft(6, "0"c) '-- Total de inclusões SCPC - t[6]
        conteudo += RetornarVazio("").PadLeft(6, "0"c) '-- Total de exclusões SCPC - t[6]
        conteudo += RetornarVazio("").PadLeft(6, "0"c) '-- Total de inclusões SCH - t[6]
        conteudo += RetornarVazio("").PadLeft(6, "0"c) '-- Total de exclusões SCH - t[6]
        conteudo += RetornarVazio("").PadLeft(6, "0"c) '-- Total de inclusões SPJ - t[6]
        conteudo += RetornarVazio("").PadLeft(6, "0"c) '-- Total de exclusões SPJ - t[6]
        conteudo += "".PadLeft(357, " "c) '-- Constantes Brancos - t[357]
        conteudo += RetornarVazio(contLinha).PadLeft(6, "0"c) '-- Numero de Sequencia dos Registros - t[6]

        EscreverArquivo(conteudo)
    End Sub

    Private Sub EscreverArquivo(ByVal conteudo As String)
        If arquivoCriado = False Then
            AbrirArquivo()
        End If

        arquivo.WriteLine(conteudo)
    End Sub

    Private Function AbrirArquivo() As Boolean
        Try
            '-- Criar arquivo
            Dim dataAtual As Date = DateTime.Now
            Dim data As String = dataAtual.Day.ToString() + "/" + dataAtual.Month.ToString() + "/" + dataAtual.Year.ToString()
            Dim arquivoNome As String = System.IO.Directory.GetCurrentDirectory() + "\arquivos_spc\spc_" + FormatarDataUniversal(data) + ".txt"

            quantidade = 0
            arquivo = New System.IO.StreamWriter(arquivoNome, True, System.Text.Encoding.ASCII)

            arquivoCriado = True
        Catch ex As Exception
            MessageBox.Show("Erro ao criar arquivo", "Arquivo Negativação", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return False
        End Try

        Return True
    End Function

    Private Sub FecharArquivo()
        Try
            If arquivoCriado = True Then
                '-- Finalizar arquivo
                arquivo.Close()
                arquivo.Dispose()
            End If

            quantidade = 0

        Catch ex As Exception
            '-- Finalizar arquivo
            arquivo.Close()
            arquivo.Dispose()
        End Try

        arquivoCriado = False
    End Sub

    Private Function RetirarCaracterEspecial(ByVal pValor As String) As String
        pValor = pValor.Replace(".", "")
        pValor = pValor.Replace("-", "")
        pValor = pValor.Replace("/", "")
        pValor = pValor.Replace("\", "")
        Return pValor
    End Function

    Private Sub btoMalaDireta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoMalaDireta.Click
        Dim janelaMalaDireta As New fClienteMalaDireta
        janelaMalaDireta.listaClientes = clientesNegativados
        mdiPrincipal.FecharTela()
        mdiPrincipal.formulario = janelaMalaDireta
        mdiPrincipal.AbrirTela()
    End Sub
End Class
