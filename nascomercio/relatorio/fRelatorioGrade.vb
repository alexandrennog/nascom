Imports ncDados.nsGradeItem
Imports ncRegras.nsGradeItem
Imports ncDados.nsFornecedor
Imports ncRegras.nsFornecedor
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante
Imports ncDados.nsGrupo
Imports ncRegras.nsGrupo
Imports ncDados.nsGradeEntrada
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsLog.cLog
Imports ncComum.nsExcecao
Imports System.Drawing.Printing
Imports ncRegras.nsParametro
Imports ncDados.nsParametro
Imports ncComum.nsConstantes

Public Class fRelatorioGrade

  Private gCont As Integer
  Private contadorRelatorio As Integer
  Private linhasRelatorio As String()
  Private fonteNormal As Font
  Private margemEsq As Single = 20
  Private margemSup As Single = 100
  Private alturaLinha As Integer = 12
  Private qtdeLinhasRelatorio As Integer = 80
  Private paginaAtual As Integer


  Private Sub fRelatorioGrade_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    CarregarComboFornecedor()
    CarregarComboFabricante()
    CarregarComboGrupo()
    rtbGrade.Tag = False

  End Sub

  Private Sub CarregarComboFornecedor()
    Dim regras As rFornecedor
    Dim colecao As ColecaoFornecedor

    Try

      cboFornecedor.DataSource = Nothing
      cboFornecedor.Items.Clear()

      regras = New rFornecedor()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then
        colecao.Insert(0, New dFornecedor())

        cboFornecedor.ValueMember = "cid"
        cboFornecedor.DisplayMember = "nome"
        cboFornecedor.DataSource = colecao
        cboFornecedor.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Fornecedor.")

    End Try
  End Sub

  Private Sub CarregarComboFabricante()
    Dim regras As rFabricante
    Dim colecao As ColecaoFabricante

    Try

      cboFabricante.DataSource = Nothing
      cboFabricante.Items.Clear()

      regras = New rFabricante()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then
        colecao.Insert(0, New dFabricante())

        cboFabricante.ValueMember = "cid"
        cboFabricante.DisplayMember = "nome"
        cboFabricante.DataSource = colecao
        cboFabricante.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Fabricante.")

    End Try
  End Sub

  Private Sub CarregarComboGrupo()
    Dim regras As rGrupo
    Dim colecao As ColecaoGrupo

    Try

      cboGrupo.DataSource = Nothing
      cboGrupo.Items.Clear()

      regras = New rGrupo()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then
        colecao.Insert(0, New dGrupo())

        cboGrupo.ValueMember = "cid"
        cboGrupo.DisplayMember = "nome"
        cboGrupo.DataSource = colecao
        cboGrupo.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Grupo.")

    End Try
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    Me.Close()
  End Sub

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    Pesquisar()
  End Sub

  Private Function Validar() As Boolean

    If ((cboFornecedor.SelectedValue Is Nothing) OrElse (String.IsNullOrEmpty(cboFornecedor.SelectedValue.ToString()))) And _
        ((cboFabricante.SelectedValue Is Nothing) OrElse (String.IsNullOrEmpty(cboFabricante.SelectedValue.ToString()))) Then
      MessageBox.Show("É necessário selecionar um Fabricante ou um Fornecedor!", "Grade", MessageBoxButtons.OK)
      Return False
    End If

    Return True

  End Function

  Private Sub Pesquisar()
    Dim regras As rGradeItem
    Dim colReferencia As ColecaoGradeItem
    Dim colProdutos As ColecaoGradeItem
    Dim colItens As ColecaoGradeItem
    Dim filtro As dGradeItem
    Dim ultimaVenda As dGradeItem
    Dim linhaTamanho As String
    Dim linhaEstoque As String
    Dim linhaEntrada As String
        Dim somaEstoque As Decimal
        Dim somaEntrada As Decimal
    Dim totalRef As Integer
        Dim totalGeral As Integer
        Dim dadosParametro As dParametro
        Dim regraParametro As rParametro
        Dim ehDecimal As String = Nothing

        If Not rtbGrade.Tag Then
      rtbGrade.Tag = True
      Try
        If (Validar()) Then

          rtbGrade.Clear()

          regras = New rGradeItem()
          filtro = New dGradeItem()

          filtro.fabricante_cid = cboFabricante.SelectedValue
          filtro.fornecedor_cid = cboFornecedor.SelectedValue
          filtro.grupo_cid = cboGrupo.SelectedValue
          filtro.ordem = chkOrdem.Checked

                    colReferencia = regras.ConsultarReferencia(filtro)

                    If colReferencia Is Nothing Then
                        MessageBox.Show("Não foram encontrados registros para os filtros informados.", "Grade", MessageBoxButtons.OK)
                        Return
                    End If

                    pbGrade.Step = 1
                        pbGrade.Minimum = 0
                        pbGrade.Maximum = colReferencia.Count
                        pbGrade.Value = 0

                        If Not IsNothing(colReferencia) Then
                            totalGeral = 0
                            pbGrade.Show()
                            For Each itemRef As dGradeItem In colReferencia

                                pbGrade.PerformStep()
                                'ultimaVenda = regras.ConsultarUltimaVenda(itemRef.referencia)
                                ultimaVenda = regras.ConsultarUltimaVenda(itemRef.referencia, filtro)

                                regraParametro = New rParametro()
                                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.IsDecimal)

                                ' Consultar chave de acesso/validação
                                If Not IsNothing(dadosParametro) Then
                                    ehDecimal = dadosParametro.valor
                                End If


                                AlterarFundoCinza(True)
                                AlterarNegrito()
                                If Not IsNothing(itemRef.descricao) Then
                                    rtbGrade.AppendText("REF: " & itemRef.referencia.PadRight(15, " ") & " " & itemRef.descricao.PadRight(40, " ").Substring(0, 40))
                                Else
                                    rtbGrade.AppendText("REF: " & itemRef.referencia.PadRight(15, " ") & " " & New String(" ", 40))
                                End If
                                If ultimaVenda IsNot Nothing Then
                                    rtbGrade.AppendText(" ULT. VENDA: " & FormatarDataBarras(RetornarTexto(ultimaVenda.dataUltimaVenda)) & "      " & ultimaVenda.corMaterial.PadRight(15, " ").Substring(0, 15))
                                Else
                                    rtbGrade.AppendText(" ULT. VENDA:                                ")
                                End If
                                rtbGrade.AppendText(vbCrLf)

                                'colProdutos = regras.ConsultarProdutos(itemRef.referencia, filtro.ordem)
                                colProdutos = regras.ConsultarProdutos(itemRef.referencia, filtro)

                                If Not IsNothing(colProdutos) Then
                                    totalRef = 0

                                    For Each itemPro As dGradeItem In colProdutos

                                        colItens = regras.ConsultarItens(itemPro.produto_cid)

                                        If Not IsNothing(colItens) Then
                                            linhaTamanho = ""
                                            linhaEstoque = " " & itemPro.corMaterial.PadRight(18, " ").Substring(0, 18) & "|"
                                            linhaEntrada = ""

                                            somaEstoque = 0
                                            somaEntrada = 0

                                            For Each itemItem As dGradeItem In colItens
                                                If linhaEntrada = "" Then
                                                    If RetornarTexto(itemItem.dataEntrada) = "" Then
                                                        linhaEntrada = "                   |"
                                                    Else
                                                        linhaEntrada = " " & FormatarDataBarras(RetornarTexto(itemItem.dataEntrada)) & "        |"
                                                    End If
                                                End If

                                                If itemItem.quantidade.Equals(Nothing) Then
                                                    linhaEntrada = linhaEntrada & "      |"
                                                Else
                                                    linhaEntrada = linhaEntrada & cFuncoes.FormatarTextoDecimal(itemItem.quantidade, ehDecimal).PadLeft(5, " ") & " |"
                                                    somaEntrada = somaEntrada + Convert.ToDecimal(itemItem.quantidade)
                                                End If

                                                If Not String.IsNullOrEmpty(itemItem.estoque) Then
                                                    somaEstoque = somaEstoque + Convert.ToDecimal(itemItem.estoque)
                                                    linhaEstoque = linhaEstoque & cFuncoes.FormatarTextoDecimal(itemItem.estoque, ehDecimal).PadLeft(5, " ") & " |"
                                                Else
                                                    linhaEstoque = linhaEstoque & "      |"
                                                End If


                                                If Not String.IsNullOrEmpty(itemItem.tamanho) Then
                                                    linhaTamanho = linhaTamanho & itemItem.tamanho.PadLeft(5, " ") & " |"
                                                Else
                                                    linhaTamanho = linhaTamanho & "      |"
                                                End If
                                            Next

                                            AlterarSublinhado()
                                            rtbGrade.AppendText(("                         |" & linhaTamanho.PadLeft(5, " ") & " ").PadRight(105, " "))
                                            rtbGrade.AppendText(vbCrLf)
                                            AlterarNegrito()
                                            rtbGrade.AppendText(" " & cFuncoes.FormatarTextoDecimal(somaEstoque, ehDecimal).ToString().PadLeft(4, " ") & " " & linhaEstoque)
                                            rtbGrade.AppendText(vbCrLf)
                                            AlterarVermelho()
                                            AlterarNegrito()
                                            rtbGrade.AppendText(" " & cFuncoes.FormatarTextoDecimal(somaEntrada, ehDecimal).ToString().PadLeft(4, " ") & " " & linhaEntrada)
                                            rtbGrade.AppendText(vbCrLf)
                                            totalRef = totalRef + somaEstoque
                                        End If

                                        rtbGrade.AppendText(vbCrLf)
                                    Next
                                    totalGeral = totalGeral + totalRef
                                End If

                                rtbGrade.AppendText(" TOTAL = " & cFuncoes.FormatarTextoDecimal(totalRef.ToString(), ehDecimal))
                                rtbGrade.AppendText(vbCrLf)
                                rtbGrade.AppendText(vbCrLf)
                                Application.DoEvents()
                            Next
                            pbGrade.Hide()

                            rtbGrade.AppendText(" TOTAL GERAL = " & cFuncoes.FormatarTextoDecimal(totalGeral.ToString(), ehDecimal))
                            rtbGrade.AppendText(vbCrLf)
                            rtbGrade.AppendText(vbCrLf)
                        End If

                    End If

      Catch nex As ExcecaoNascomercio

        MessageBox.Show(nex.Message)

      Catch ex As Exception

        MessageBox.Show("Erro na consulta da lista de produtos da grade.")

      End Try
      rtbGrade.Tag = False
    End If
  End Sub

  Private Sub btoImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoImprimir.Click
    Imprimir()
  End Sub

  Private Sub Imprimir()

    If Not String.IsNullOrEmpty(rtbGrade.Text) Then
      contadorRelatorio = 0
      paginaAtual = 1
      linhasRelatorio = rtbGrade.Text.Split(vbLf)

      'PrintPreviewDialog1.Document = PrintDocument1
      'PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
      'PrintPreviewDialog1.ShowDialog()

      PrintDocument1.Print()
    End If

  End Sub

  Private Sub ImprimirLinha(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintPageEventArgs)
    Dim fonteNormal As Font
    Dim posicaoDaLinha As Integer
    Dim margemEsq As Single = 10 'Relatorio.MarginBounds.Left

    fonteNormal = New Font("Courier New", 8)

    Relatorio.Graphics.DrawString(rtbGrade.Text, fonteNormal, Brushes.Black, margemEsq, posicaoDaLinha, New StringFormat())
  End Sub

  Private Sub Sair()
    If Me.Modal = True Then
      Me.Close()
    Else
      If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        mdiPrincipal.FecharTela()
      End If
    End If
  End Sub

  Private Sub fRelatorioGrade_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        Sair()
      Case Keys.F8
        Imprimir()
      Case Keys.F5
        Pesquisar()
    End Select
  End Sub

  Private Sub AlterarNegrito()
    If rtbGrade.SelectionFont.Style = FontStyle.Bold Then
      rtbGrade.SelectionFont = New Font(rtbGrade.SelectionFont, FontStyle.Regular)
    Else
      rtbGrade.SelectionFont = New Font(rtbGrade.SelectionFont, FontStyle.Bold)
    End If
  End Sub

  Private Sub AlterarVermelho()
    If rtbGrade.SelectionColor = Color.Black Then
      rtbGrade.SelectionColor = Color.Red
    Else
      rtbGrade.SelectionColor = Color.Black
    End If
  End Sub

  Private Sub AlterarSublinhado()
    If rtbGrade.SelectionFont.Style = FontStyle.Underline Then
      rtbGrade.SelectionFont = New Font(rtbGrade.SelectionFont, FontStyle.Regular)
    Else
      rtbGrade.SelectionFont = New Font(rtbGrade.SelectionFont, FontStyle.Underline)
    End If
  End Sub

  Private Sub AlterarFundoCinza(ByVal i As Boolean)
    If i = True Then
      rtbGrade.SelectionBackColor = Color.LightGray
    Else
      rtbGrade.SelectionBackColor = Color.White
    End If
  End Sub

  Private Sub AlterarFundoCinzaClaro(ByVal i As Boolean)
    If i = True Then
      rtbGrade.SelectionBackColor = Color.FromArgb(255, 240, 240, 240)
    Else
      rtbGrade.SelectionBackColor = Color.White
    End If
  End Sub

  Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
    fonteNormal = New Font("Courier New", 8)

    Do While contadorRelatorio < linhasRelatorio.Length
      Dim altura As Integer

      altura = ((((qtdeLinhasRelatorio + contadorRelatorio) Mod qtdeLinhasRelatorio) + 1) * alturaLinha) + margemSup

      If contadorRelatorio = 1 Then
        e.Graphics.DrawString("Relatório de Grade de Produtos", New Font("Arial", 14, FontStyle.Bold), Brushes.Red, margemEsq, 8)
      End If

      e.Graphics.DrawString(linhasRelatorio(contadorRelatorio), fonteNormal, Brushes.Black, margemEsq, altura)

      contadorRelatorio = contadorRelatorio + 1

      If contadorRelatorio Mod qtdeLinhasRelatorio = 0 Then
        Exit Do
      End If
    Loop

    e.Graphics.DrawString("Página " + paginaAtual.ToString(), New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 720, 1050)
    paginaAtual = paginaAtual + 1

    If contadorRelatorio >= linhasRelatorio.Length Then
      e.HasMorePages = False
    Else
      e.HasMorePages = True
    End If
  End Sub

End Class