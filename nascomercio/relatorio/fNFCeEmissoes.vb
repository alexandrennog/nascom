Imports System.Globalization
Imports System.IO
Imports System.Text
Imports LibNF65
Imports ncComum.nsExcecao
Imports ncDados.nsNFCe
Imports ncRegras.nsNFCe

' NFC-e Emitidas: historico de cada emissao de NFC-e (tabela basennf -
' script "44 - nfce_historico_emissao.sql") com data/hora, resultado
' (autorizada, rejeitada, falha...), retorno da SEFAZ e onde o XML foi gravado.
' Aba "Notas": consulta/reemissao das que falharam. Aba "Relatorio para
' imprimir": o mesmo periodo no padrao dos outros relatorios.
' Acesso: Relatorios > "NFC-e Emitidas" (no lugar de "Vendas SAT" quando o
' sistema esta em FISCAL = ONLINE).
Public Class fNFCeEmissoes

    Private dtDados As New System.Data.DataTable()
    Private lista As New ColecaoEmissaoNFCe
    Private carregando As Boolean = False
    Private ocupado As Boolean = False

    Private Shared ReadOnly CorAutorizada As Color = Color.FromArgb(220, 245, 220)
    Private Shared ReadOnly CorProblema As Color = Color.FromArgb(252, 225, 225)
    Private Shared ReadOnly CorInterrompida As Color = Color.FromArgb(255, 233, 199)
    Private Shared ReadOnly CorNeutra As Color = Color.FromArgb(236, 239, 241)

    ' ---------------------------------------------------------------------
    ' Filtro
    ' ---------------------------------------------------------------------

    Private Sub CarregarComboSituacao()
        cboSituacao.Items.Clear()
        cboSituacao.Items.Add(New ItemSituacao("", "Todas"))
        cboSituacao.Items.Add(New ItemSituacao("P", "Pendentes (falha / rejeitada / sem nota)"))
        cboSituacao.Items.Add(New ItemSituacao("A", "Autorizadas"))
        cboSituacao.Items.Add(New ItemSituacao("R", "Rejeitadas pela SEFAZ"))
        cboSituacao.Items.Add(New ItemSituacao("F", "Falhas"))
        cboSituacao.Items.Add(New ItemSituacao("V", "Vendas sem NFC-e"))
        cboSituacao.Items.Add(New ItemSituacao("I", "Interrompidas"))
        cboSituacao.Items.Add(New ItemSituacao("C", "Canceladas"))
        cboSituacao.Items.Add(New ItemSituacao("S", "Substituídas"))
        cboSituacao.SelectedIndex = 0
    End Sub

    Private Function SituacaoSelecionada() As String
        Dim item As ItemSituacao = TryCast(cboSituacao.SelectedItem, ItemSituacao)
        Return If(item Is Nothing, "", item.codigo)
    End Function

    Private Function LerPeriodo(ByRef dataInicial As DateTime, ByRef dataFinal As DateTime) As Boolean
        If Not DateTime.TryParseExact(txtDataInicial.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dataInicial) Then
            MessageBox.Show("Data inicial inválida.", "NFC-e Emitidas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDataInicial.Focus()
            Return False
        End If
        If Not DateTime.TryParseExact(txtDataFinal.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dataFinal) Then
            MessageBox.Show("Data final inválida.", "NFC-e Emitidas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDataFinal.Focus()
            Return False
        End If
        If dataFinal < dataInicial Then
            MessageBox.Show("A data final é anterior à data inicial.", "NFC-e Emitidas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDataFinal.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub Filtrar(Optional ByVal manterSelecao As Boolean = False)
        Dim dataInicial As DateTime
        Dim dataFinal As DateTime

        If carregando OrElse ocupado Then
            Exit Sub
        End If
        If Not LerPeriodo(dataInicial, dataFinal) Then
            Exit Sub
        End If

        Dim selecionado As dEmissaoNFCe = If(manterSelecao, ItemSelecionado(), Nothing)

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim regras As New rEmissaoNFCe
            If Not regras.HistoricoDisponivel() Then
                MessageBox.Show("O histórico de NFC-e ainda não existe neste banco." & vbCrLf &
                                "Rode o script ""scripts\new script\44 - nfce_historico_emissao.sql"" no MySQL desta loja.",
                                "NFC-e Emitidas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            lista = regras.Listar(dataInicial, dataFinal, SituacaoSelecionada())

            PreencherGrade(selecionado)
            PreencherResumo()
            PreencherRelatorio(dataInicial, dataFinal)

        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message, "NFC-e Emitidas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar as NFC-e: " & ex.Message, "NFC-e Emitidas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ' ---------------------------------------------------------------------
    ' Aba "Notas"
    ' ---------------------------------------------------------------------

    Private Sub PreencherGrade(ByVal selecionado As dEmissaoNFCe)
        dgvNotas.Rows.Clear()

        For Each item As dEmissaoNFCe In lista
            Dim i As Integer = dgvNotas.Rows.Add(
                FormatarDataHora(item.dataReferencia),
                If(item.seqNFe.HasValue, item.seqNFe.Value.ToString(), "-"),
                If(item.controle.HasValue, item.controle.Value.ToString(), "-"),
                If(item.valor.HasValue, item.valor.Value.ToString("N2"), ""),
                item.situacaoDescricao,
                Retorno(item),
                item.terminal,
                item.usuarioNome,
                TextoXml(item),
                If(item.temChave, item.chave, ""),
                item.tentativas.ToString())

            Dim linha As DataGridViewRow = dgvNotas.Rows(i)
            linha.Tag = item
            linha.Cells(colSituacao.Index).Style.BackColor = CorDaSituacao(item.codigoSituacao)
        Next

        ' volta para a mesma nota depois de reemitir/consultar
        If selecionado IsNot Nothing Then
            For Each linha As DataGridViewRow In dgvNotas.Rows
                Dim item As dEmissaoNFCe = DirectCast(linha.Tag, dEmissaoNFCe)
                If (selecionado.seqNFe.HasValue AndAlso item.seqNFe.Equals(selecionado.seqNFe)) OrElse
                   (Not selecionado.seqNFe.HasValue AndAlso item.controle.Equals(selecionado.controle)) Then
                    linha.Selected = True
                    dgvNotas.CurrentCell = linha.Cells(0)
                    Exit For
                End If
            Next
        End If

        AtualizarDetalhe()
    End Sub

    Private Shared Function CorDaSituacao(ByVal codigo As String) As Color
        Select Case codigo
            Case "A" : Return CorAutorizada
            Case "R", "F", "V" : Return CorProblema
            Case "I", "E" : Return CorInterrompida
            Case Else : Return CorNeutra
        End Select
    End Function

    Private Shared Function Retorno(ByVal item As dEmissaoNFCe) As String
        If item.cStat.HasValue AndAlso Not String.IsNullOrEmpty(item.mensagem) AndAlso Not item.mensagem.Contains(item.cStat.Value.ToString()) Then
            Return item.cStat.Value.ToString() & " - " & item.mensagem
        End If
        If Not String.IsNullOrEmpty(item.mensagem) Then
            Return item.mensagem
        End If
        If item.situacao = "A" Then
            Return "Autorizado o uso da NF-e"
        End If
        Return ""
    End Function

    ' XML neste computador: caminho gravado (se o arquivo existe aqui) ou
    ' procura pela chave nas pastas NFs\OK, NFs\NOK e NFs
    Private Shared Function XmlNesteComputador(ByVal item As dEmissaoNFCe) As String
        Try
            If Not String.IsNullOrEmpty(item.caminhoXml) AndAlso File.Exists(item.caminhoXml) Then
                Return item.caminhoXml
            End If
            If item.temChave Then
                Return NFCe65.LocalizarXml(item.chave)
            End If
        Catch
        End Try
        Return ""
    End Function

    Private Shared Function EmitidaNesteComputador(ByVal item As dEmissaoNFCe) As Boolean
        Return String.IsNullOrEmpty(item.computador) OrElse
               String.Equals(item.computador, Environment.MachineName, StringComparison.OrdinalIgnoreCase)
    End Function

    Private Shared Function TextoXml(ByVal item As dEmissaoNFCe) As String
        If Not item.temChave Then
            Return "-"
        End If
        If XmlNesteComputador(item) <> "" Then
            Return "Sim"
        End If
        If Not EmitidaNesteComputador(item) Then
            Return "Em " & item.computador
        End If
        Return "Não"
    End Function

    Private Function ItemSelecionado() As dEmissaoNFCe
        If dgvNotas.CurrentRow Is Nothing Then
            Return Nothing
        End If
        Return TryCast(dgvNotas.CurrentRow.Tag, dEmissaoNFCe)
    End Function

    Private Sub AtualizarDetalhe()
        Dim item As dEmissaoNFCe = ItemSelecionado()

        btoReemitir.Enabled = item IsNot Nothing AndAlso item.podeReemitir
        btoConsultar.Enabled = item IsNot Nothing AndAlso item.origem = "N" AndAlso item.temChave
        btoMostrarXml.Enabled = item IsNot Nothing AndAlso XmlNesteComputador(item) <> ""
        btoReimprimir.Enabled = item IsNot Nothing AndAlso item.situacao = "A" AndAlso XmlNesteComputador(item) <> ""

        If item Is Nothing Then
            txtDetalhe.Text = If(lista.Count = 0, "Nenhuma NFC-e no período / situação escolhidos.", "")
            Exit Sub
        End If

        Dim sb As New StringBuilder()
        If item.origem = "V" Then
            sb.Append("Venda ").Append(item.controle.GetValueOrDefault()).Append(" registrada em ").Append(FormatarDataHora(item.dataVenda))
            sb.Append(" sem NFC-e e sem número de nota ligado (falha anterior ao histórico).")
            If item.valor.HasValue Then
                sb.Append("  Valor: ").Append(item.valor.Value.ToString("C"))
            End If
            sb.AppendLine().Append("Use ""Reemitir NFC-e"" para emitir a nota desta venda agora.")
            txtDetalhe.Text = sb.ToString()
            Exit Sub
        End If

        sb.Append("NFC-e nº ").Append(item.seqNFe.GetValueOrDefault())
        sb.Append("   |   Venda: ").Append(If(item.controle.HasValue, item.controle.Value.ToString(), "não identificada"))
        If item.valor.HasValue Then
            sb.Append("   |   Valor: ").Append(item.valor.Value.ToString("C"))
        End If
        sb.Append("   |   Situação: ").Append(item.situacaoDescricao)
        If item.tentativas > 1 Then
            sb.Append(" (").Append(item.tentativas).Append(" tentativas)")
        End If
        sb.AppendLine()

        sb.Append("Emissão: ").Append(FormatarDataHora(item.dataEmissao))
        If item.dataVenda.HasValue Then
            sb.Append("   |   Venda feita em: ").Append(FormatarDataHora(item.dataVenda))
        End If
        If item.dataAutorizacao.HasValue AndAlso item.situacao = "A" Then
            sb.Append("   |   Autorizada em: ").Append(FormatarDataHora(item.dataAutorizacao))
        End If
        If Not String.IsNullOrEmpty(item.protocolo) Then
            sb.Append("   |   Protocolo: ").Append(item.protocolo)
        End If
        sb.AppendLine()

        sb.Append("Retorno: ").AppendLine(If(Retorno(item) = "", "-", Retorno(item)))
        sb.Append("Chave: ").AppendLine(If(item.temChave, item.chave, "(não gerada)"))

        Dim xmlAqui As String = XmlNesteComputador(item)
        sb.Append("XML: ")
        If xmlAqui <> "" Then
            sb.Append(xmlAqui)
        ElseIf Not String.IsNullOrEmpty(item.caminhoXml) Then
            sb.Append(item.caminhoXml).Append(If(EmitidaNesteComputador(item), "  (arquivo não encontrado)", "  (no computador " & item.computador & ")"))
        Else
            sb.Append(If(item.temChave, "caminho não registrado", "-"))
        End If
        sb.AppendLine()

        sb.Append("Terminal: ").Append(If(String.IsNullOrEmpty(item.terminal), "-", item.terminal))
        If Not String.IsNullOrEmpty(item.computador) Then
            sb.Append("   |   Computador: ").Append(item.computador)
        End If
        If Not String.IsNullOrEmpty(item.usuarioNome) Then
            sb.Append("   |   Usuário: ").Append(item.usuarioNome)
        End If
        If Not String.IsNullOrEmpty(item.cpfConsumidor) Then
            sb.Append("   |   CPF/CNPJ na nota: ").Append(item.cpfConsumidor)
        End If
        If item.substituidaPor.HasValue Then
            sb.Append("   |   Reemitida com o número ").Append(item.substituidaPor.Value)
        End If

        txtDetalhe.Text = sb.ToString()
    End Sub

    Private Sub PreencherResumo()
        Dim total As Integer = 0, autorizadas As Integer = 0, rejeitadas As Integer = 0, falhas As Integer = 0
        Dim valor As Decimal = 0D

        For Each item As dEmissaoNFCe In lista
            total += 1
            ' "E" (emitindo agora em outro caixa) nao conta como falha
            Select Case item.codigoSituacao
                Case "A"
                    autorizadas += 1
                    valor += item.valor.GetValueOrDefault()
                Case "R"
                    rejeitadas += 1
                Case "F", "I", "V"
                    falhas += 1
            End Select
        Next

        lblKpiTotal.Text = "NFC-e no período" & vbCrLf & total.ToString()
        lblKpiAutorizadas.Text = "Autorizadas" & vbCrLf & autorizadas.ToString() &
                                 If(total > 0, "  (" & Math.Round(autorizadas * 100.0 / total).ToString("0") & "%)", "")
        lblKpiRejeitadas.Text = "Rejeitadas pela SEFAZ" & vbCrLf & rejeitadas.ToString()
        lblKpiFalhas.Text = "Falhas / sem nota" & vbCrLf & falhas.ToString()
        lblKpiValor.Text = "Valor autorizado" & vbCrLf & valor.ToString("C")
    End Sub

    ' ---------------------------------------------------------------------
    ' Aba "Relatorio para imprimir"
    ' ---------------------------------------------------------------------

    Private Sub MontarTabela()
        dtDados.Clear()
        dtDados.Columns.Clear()
        dtDados.Columns.Add("dataRef", GetType(DateTime))
        dtDados.Columns.Add("diaChave", GetType(String))   ' yyyy-MM-dd (agrupa/ordena o grafico)
        dtDados.Columns.Add("dia", GetType(String))        ' dd/MM
        dtDados.Columns.Add("data", GetType(String))       ' dd/MM/yyyy
        dtDados.Columns.Add("hora", GetType(String))
        dtDados.Columns.Add("numero", GetType(String))
        dtDados.Columns.Add("venda", GetType(String))
        dtDados.Columns.Add("valor", GetType(Decimal))
        dtDados.Columns.Add("situacao", GetType(String))
        dtDados.Columns.Add("situacaoDescricao", GetType(String))
        dtDados.Columns.Add("retorno", GetType(String))
        dtDados.Columns.Add("terminal", GetType(String))
        dtDados.Columns.Add("usuario", GetType(String))
        dtDados.Columns.Add("chave", GetType(String))
        dtDados.Columns.Add("protocolo", GetType(String))
        dtDados.Columns.Add("caminhoXml", GetType(String))
        dtDados.Columns.Add("tentativas", GetType(Integer))
    End Sub

    Private Sub PreencherRelatorio(ByVal dataInicial As DateTime, ByVal dataFinal As DateTime)
        MontarTabela()

        For Each item As dEmissaoNFCe In lista
            Dim linha As System.Data.DataRow = dtDados.NewRow()
            Dim data As DateTime = item.dataReferencia.GetValueOrDefault(dataInicial)

            linha("dataRef") = data
            linha("diaChave") = data.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
            linha("dia") = data.ToString("dd/MM", CultureInfo.InvariantCulture)
            linha("data") = data.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
            linha("hora") = data.ToString("HH:mm", CultureInfo.InvariantCulture)
            linha("numero") = If(item.seqNFe.HasValue, item.seqNFe.Value.ToString(), "-")
            linha("venda") = If(item.controle.HasValue, item.controle.Value.ToString(), "-")
            linha("valor") = item.valor.GetValueOrDefault()
            linha("situacao") = item.codigoSituacao
            linha("situacaoDescricao") = item.situacaoDescricao
            linha("retorno") = Retorno(item)
            linha("terminal") = item.terminal
            linha("usuario") = item.usuarioNome
            linha("chave") = If(item.temChave, item.chave, "")
            linha("protocolo") = item.protocolo
            linha("caminhoXml") = If(String.IsNullOrEmpty(item.caminhoXml), XmlNesteComputador(item), item.caminhoXml)
            linha("tentativas") = item.tentativas
            dtDados.Rows.Add(linha)
        Next

        Dim ambiente As String = If(System.Configuration.ConfigurationManager.AppSettings("TipoAmbiente") = "1", "Produção", "Homologação (teste)")

        Dim parametros(5) As Microsoft.Reporting.WinForms.ReportParameter
        parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter("DataInicial", dataInicial.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
        parametros(1) = New Microsoft.Reporting.WinForms.ReportParameter("DataFinal", dataFinal.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
        parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter("Situacao", If(SituacaoSelecionada() = "", "", cboSituacao.Text))
        parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter("Loja", mdiPrincipal.lblLoja.Text)
        parametros(4) = New Microsoft.Reporting.WinForms.ReportParameter("Ambiente", ambiente)
        parametros(5) = New Microsoft.Reporting.WinForms.ReportParameter("PastaXml", NFCe65.PastaXml())

        rptRelatorio.LocalReport.DataSources.Clear()
        rptRelatorio.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsNFCe", dtDados))
        rptRelatorio.LocalReport.SetParameters(parametros)
        rptRelatorio.RefreshReport()
    End Sub

    ' ---------------------------------------------------------------------
    ' Acoes
    ' ---------------------------------------------------------------------

    Private Function PodeReemitirComEsteUsuario() As Boolean
        Select Case mdiPrincipal.gUsuario.usuarioPerfil_codigo
            Case "a", "g"
                Return True
        End Select
        ' Caixa: precisa da senha do gerente (mesma regra de outras operacoes fiscais)
        Dim acessoGerente As New fAcessoGerente()
        acessoGerente.ShowDialog()
        Return acessoGerente.gRetorno
    End Function

    Private Sub Reemitir()
        Dim item As dEmissaoNFCe = ItemSelecionado()
        If item Is Nothing OrElse Not item.podeReemitir OrElse ocupado Then
            Exit Sub
        End If

        Dim texto As String = "Reemitir a NFC-e da venda " & item.controle.Value.ToString() &
                              If(item.valor.HasValue, " (" & item.valor.Value.ToString("C") & ")", "") & " agora?" & vbCrLf & vbCrLf &
                              If(item.origem = "N" AndAlso item.temChave,
                                 "Antes de emitir, o sistema confere na SEFAZ se a nota já não foi autorizada." & vbCrLf, "") &
                              "A nota sai com a data e hora de agora."
        If MessageBox.Show(texto, "Reemitir NFC-e", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
        End If

        If Not PodeReemitirComEsteUsuario() Then
            Exit Sub
        End If

        Dim cpf As String = InputBox("CPF/CNPJ do cliente na nota (deixe em branco para não identificar):", "Reemitir NFC-e",
                                     If(item.cpfConsumidor, "")).Trim()
        cpf = rEmissaoNFCe.SomenteDigitos(cpf)
        ' mesma validacao da tela de Pagamento
        If cpf <> "" AndAlso Not ((cpf.Length = 11 AndAlso ncComum.nsFuncoes.cFuncoes.ValidaCpf(cpf)) OrElse
                                  (cpf.Length = 14 AndAlso ncComum.nsFuncoes.cFuncoes.ValidaCnpj(cpf))) Then
            MessageBox.Show("CPF/CNPJ inválido. A reemissão foi cancelada.", "Reemitir NFC-e", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim tituloOriginal As String = mdiPrincipal.Text
        Dim resultado As NFCeReemissao.Resultado = Nothing
        ocupado = True
        Me.Enabled = False
        Cursor.Current = Cursors.WaitCursor

        Try
            mdiPrincipal.Text = "Emitindo NFC-e da venda " & item.controle.Value.ToString() & "... (aguarde)"
            Application.DoEvents()

            resultado = NFCeReemissao.Reemitir(item, cpf, chkImprimir.Checked,
                Sub(tentativaAtual, maxTentativas)
                    mdiPrincipal.Text = "Emitindo NFC-e... tentativa " & tentativaAtual.ToString() & " de " & maxTentativas.ToString() & " (aguarde)"
                    Application.DoEvents()
                End Sub,
                Sub()
                    Application.DoEvents()
                End Sub,
                AddressOf PerguntarDuplicidade)

        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message, "Reemitir NFC-e", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Erro ao reemitir a NFC-e: " & ex.Message, "Reemitir NFC-e", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            mdiPrincipal.Text = tituloOriginal
            Cursor.Current = Cursors.Default
            Me.Enabled = True
            ocupado = False
        End Try

        If resultado IsNot Nothing AndAlso Not resultado.cancelado Then
            If resultado.sucesso Then
                MessageBox.Show(resultado.mensagem, "Reemitir NFC-e", MessageBoxButtons.OK, MessageBoxIcon.Information)
                GravarLogReemissao(item, resultado)
            Else
                MessageBox.Show(resultado.mensagem, "Reemitir NFC-e", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            If Not String.IsNullOrEmpty(resultado.avisoImpressao) Then
                MessageBox.Show("A NFC-e está autorizada, mas o cupom não pôde ser impresso." & vbCrLf & vbCrLf &
                                "Detalhe: " & resultado.avisoImpressao & vbCrLf & vbCrLf & "Use ""Reimprimir cupom"".",
                                "Reemitir NFC-e", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

        Filtrar(True)
    End Sub

    ' SEFAZ recusou o numero por duplicidade: ja existe nota autorizada com ele.
    ' True = e desta venda (registrar) | False = numero novo | Nothing = cancelar
    Private Function PerguntarDuplicidade(ByVal chaveExistente As String) As Nullable(Of Boolean)
        Dim item As dEmissaoNFCe = ItemSelecionado()
        Dim numero As String = If(item Is Nothing, "", item.seqNFe.GetValueOrDefault().ToString())
        Dim valor As String = If(item Is Nothing OrElse Not item.valor.HasValue, "", " (" & item.valor.Value.ToString("C") & ")")

        If chaveExistente = "" Then
            If MessageBox.Show("A SEFAZ recusou o número " & numero & " porque ele já foi usado em outra NFC-e." & vbCrLf & vbCrLf &
                               "Emitir a nota desta venda" & valor & " com um NÚMERO NOVO?",
                               "Reemitir NFC-e", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Return False
            End If
            Return Nothing
        End If

        Dim resposta As DialogResult = MessageBox.Show(
            "A SEFAZ recusou o número " & numero & " porque JÁ EXISTE uma NFC-e autorizada com ele:" & vbCrLf &
            chaveExistente & vbCrLf & vbCrLf &
            "Normalmente é a própria nota desta venda" & valor & ", que foi autorizada e a resposta se perdeu. " &
            "Se puder, confira essa chave no portal da SEFAZ (valor e data)." & vbCrLf & vbCrLf &
            "SIM = é desta venda: registrar como autorizada (não emite outra)" & vbCrLf &
            "NÃO = é de outra venda: emitir com um número novo" & vbCrLf &
            "CANCELAR = não fazer nada agora",
            "Reemitir NFC-e - número já usado", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3)

        Select Case resposta
            Case Windows.Forms.DialogResult.Yes : Return True
            Case Windows.Forms.DialogResult.No : Return False
            Case Else : Return Nothing
        End Select
    End Function

    Private Shared Sub GravarLogReemissao(ByVal item As dEmissaoNFCe, ByVal resultado As NFCeReemissao.Resultado)
        Try
            ncComum.nsLog.cLog.GravarLog(mdiPrincipal.gUsuario.usuario,
                                         If(resultado.jaEstavaAutorizada, "NFC-e registrada como autorizada (ja existia na SEFAZ). ", "NFC-e reemitida. ") &
                                         "Venda: " & item.controle.GetValueOrDefault().ToString() &
                                         " Numero: " & resultado.numero.ToString() & " Chave: " & resultado.chave)
        Catch
        End Try
    End Sub

    Private Sub ConsultarSefaz()
        Dim item As dEmissaoNFCe = ItemSelecionado()
        If item Is Nothing OrElse Not item.temChave OrElse item.origem <> "N" OrElse ocupado Then
            Exit Sub
        End If

        Dim situacao As NFCe65.SituacaoNFCe = Nothing
        ocupado = True
        Cursor.Current = Cursors.WaitCursor
        Try
            situacao = NFCeReemissao.ConsultarEAtualizar(item, NFCeReemissao.CarregarCertificado())
        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message, "Consultar na SEFAZ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Não foi possível consultar a SEFAZ: " & ex.Message, "Consultar na SEFAZ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Cursor.Current = Cursors.Default
            ocupado = False
        End Try

        If situacao Is Nothing Then
            Exit Sub
        End If

        Dim texto As String = "NFC-e nº " & item.seqNFe.GetValueOrDefault().ToString() & vbCrLf &
                              "Resposta da SEFAZ: " & situacao.CStat.ToString() & " - " & situacao.XMotivo
        If situacao.Autorizada Then
            texto &= vbCrLf & vbCrLf & "A nota está AUTORIZADA" &
                     If(String.IsNullOrEmpty(situacao.Protocolo), "", " (protocolo " & situacao.Protocolo & ")") & "."
            If item.situacao <> "A" Then
                texto &= vbCrLf & "O histórico e a venda foram atualizados - não precisa reemitir."
            End If
        ElseIf situacao.Cancelada Then
            texto &= vbCrLf & vbCrLf & "A nota está CANCELADA na SEFAZ."
        ElseIf situacao.NaoExiste Then
            texto &= vbCrLf & vbCrLf & "Esta chave NÃO existe na SEFAZ (a nota não foi autorizada)." &
                     If(item.podeReemitir, " Pode reemitir.", "")
        End If
        MessageBox.Show(texto, "Consultar na SEFAZ", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Filtrar(True)
    End Sub

    Private Sub MostrarXml()
        Dim item As dEmissaoNFCe = ItemSelecionado()
        If item Is Nothing Then
            Exit Sub
        End If
        Dim caminho As String = XmlNesteComputador(item)
        If caminho = "" Then
            MessageBox.Show("O XML desta nota não está neste computador." &
                            If(EmitidaNesteComputador(item), "", vbCrLf & "Ela foi emitida no computador " & item.computador & " (pasta NFs dele)."),
                            "NFC-e Emitidas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try
            Process.Start("explorer.exe", "/select,""" & caminho & """")
        Catch ex As Exception
            MessageBox.Show("Não foi possível abrir a pasta: " & ex.Message & vbCrLf & caminho, "NFC-e Emitidas", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Reimprimir()
        Dim item As dEmissaoNFCe = ItemSelecionado()
        If item Is Nothing OrElse item.situacao <> "A" OrElse Not item.temChave OrElse ocupado Then
            Exit Sub
        End If
        Try
            Cursor.Current = Cursors.WaitCursor
            NFCe65.Reimprimir(item.chave)
        Catch ex As Exception
            MessageBox.Show("Não foi possível reimprimir o cupom: " & ex.Message, "NFC-e Emitidas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ' ---------------------------------------------------------------------
    ' Utilitarios
    ' ---------------------------------------------------------------------

    Private Shared Function FormatarDataHora(ByVal data As Nullable(Of DateTime)) As String
        If Not data.HasValue Then
            Return "-"
        End If
        Return data.Value.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
    End Function

    ' ---------------------------------------------------------------------
    ' Eventos
    ' ---------------------------------------------------------------------

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        mdiPrincipal.FecharTela()
    End Sub

    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        Filtrar()
    End Sub

    Private Sub cboSituacao_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSituacao.SelectionChangeCommitted
        Filtrar()
    End Sub

    Private Sub dgvNotas_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvNotas.SelectionChanged
        AtualizarDetalhe()
    End Sub

    Private Sub dgvNotas_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNotas.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim item As dEmissaoNFCe = ItemSelecionado()
            If item IsNot Nothing AndAlso item.podeReemitir Then
                Reemitir()
            End If
        End If
    End Sub

    Private Sub btoReemitir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoReemitir.Click
        Reemitir()
    End Sub

    Private Sub btoConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoConsultar.Click
        ConsultarSefaz()
    End Sub

    Private Sub btoMostrarXml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoMostrarXml.Click
        MostrarXml()
    End Sub

    Private Sub btoReimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoReimprimir.Click
        Reimprimir()
    End Sub

    Private Sub fNFCeEmissoes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.F5
                Filtrar(True)
            Case Keys.F6
                If btoReemitir.Enabled Then Reemitir()
            Case Keys.F7
                If btoConsultar.Enabled Then ConsultarSefaz()
            Case Keys.F8
                If btoMostrarXml.Enabled Then MostrarXml()
            Case Keys.F9
                If btoReimprimir.Enabled Then Reimprimir()
        End Select
    End Sub

    Private Sub fNFCeEmissoes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            carregando = True

            rptRelatorio.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

            ' Padrao: ultimos 7 dias
            Me.txtDataInicial.Text = Today.AddDays(-6).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
            Me.txtDataFinal.Text = Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)

            CarregarComboSituacao()

            carregando = False
            Filtrar()

        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message)
        Catch ex As Exception
            MessageBox.Show("Erro ao abrir NFC-e Emitidas [" & Me.ToString() & "]")
        Finally
            carregando = False
        End Try
    End Sub

    Private Class ItemSituacao
        Public ReadOnly codigo As String
        Public ReadOnly texto As String

        Public Sub New(ByVal codigo As String, ByVal texto As String)
            Me.codigo = codigo
            Me.texto = texto
        End Sub

        Public Overrides Function ToString() As String
            Return texto
        End Function
    End Class

End Class
