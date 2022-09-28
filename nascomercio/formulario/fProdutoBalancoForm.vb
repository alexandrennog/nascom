Imports ncRegras.nsProduto
Imports ncDados.nsProduto
Imports ncComum.nsExcecao
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsLog.cLog
Imports System.IO

Public Class fProdutoBalancoForm

    Public cid As Nullable(Of Integer)
    Public produto As dProduto
    Public filtro As dProduto
    Private arquivoCriado As Boolean = False
    Private arquivo As IO.StreamWriter = Nothing
    Private quantidade As Integer = 0
    Private contLinha As Integer = 0
    Private caracs As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789. ^~`´-_&/\+[]{}(),!@#*?%:$;<>ÃÁÀÄÂÉÈËÊÍÌÏÎÕÓÒÖÔÚÙÜÛÇãáàäâéèëêíìïîõóòöôúùüûç"
    Private carEsp As String = "'µ§¦€‰" '
    Private carSub As String = "`ÃoaÉÇ " '

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            mdiPrincipal.FecharTela()
        End If
    End Sub

    Private Sub btoAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoAtualizar.Click
        Atualizar()
    End Sub

    Private Sub fProdutoBalancoForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    mdiPrincipal.FecharTela()
                End If
            Case Keys.F5
                CarregarProdutoBalancoFiltro()
            Case Keys.F8
                CarregarProdutoEntradaSaidaFiltro()
            Case Keys.Enter
                Atualizar()
        End Select
    End Sub

    Private Sub Atualizar()
        Dim regraPI As rProdutoItem = New rProdutoItem()

        If dgvProduto.Rows.Count > 0 Then

            barra.Minimum = 0
            barra.Maximum = dgvProduto.Rows.Count
            barra.Value = 0

            For Each _linha As DataGridViewRow In dgvProduto.Rows
                Dim _cid As String
                Dim _codigoBarras As String
                Dim _usuario As String
                Dim _nomeCompleto As String
                Dim _qtdeEstoque As String
                Dim _qtdeAtual As String
                Dim _item As String

                _qtdeAtual = IIf(_linha.Cells("estoqueatualizacao").Value Is DBNull.Value, Nothing, _linha.Cells("estoqueatualizacao").Value)

                If Not String.IsNullOrEmpty(_qtdeAtual) Then
                    _cid = _linha.Cells("cid").Value
                    _codigoBarras = _linha.Cells("codigobarras").Value
                    _usuario = mdiPrincipal.gUsuario.cid
                    _nomeCompleto = mdiPrincipal.gUsuario.nomeCompleto
                    _qtdeEstoque = IIf(_linha.Cells("estoque").Value Is DBNull.Value, 0, _linha.Cells("estoque").Value)
                    _item = _linha.Cells("item").Value

                    If Not _qtdeAtual.Equals(_qtdeEstoque) Then
                        GravarLogBalanco(CInt(_usuario), _nomeCompleto, CInt(_cid), _codigoBarras, CInt(_qtdeEstoque), CInt(_qtdeAtual))

                        regraPI.AlterarEstoque(_codigoBarras, CInt(_qtdeAtual), False)
                    End If

                End If

                barra.Increment(1)
                barra.Refresh()
                Me.Refresh()

            Next

            Listar()

            MessageBox.Show("Atualização efetuada com sucesso!")
        End If

    End Sub

    Private Sub fProdutoBalancoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Listar()
    End Sub

    Private Sub Listar()
        Dim regraP As rProduto = New rProduto()
        Dim regraPTC As rProdutoTipoCaracteristica = New rProdutoTipoCaracteristica()
        Dim regraPI As rProdutoItem = New rProdutoItem()
        Dim produtos As ColecaoProduto
        Dim colecaoPTC As ColecaoProdutoTipoCaracteristica
        Dim colecaoPI As ColecaoProdutoItem
        Dim tabela As DataTable = New DataTable()
        Dim coluna As DataColumn = New DataColumn()
        Dim linha As DataRow = Nothing
        Dim _item As Nullable(Of Integer) = Nothing
        Dim itensExibir As ArrayList = New ArrayList()

        Try
            dgvProduto.DataSource = Nothing
            dgvProduto.Rows.Clear()
            dgvProduto.Columns.Clear()

            barra.Minimum = 0
            barra.Value = 0

            Me.Visible = True
            Application.DoEvents()

            '-- Montar colunas do produto
            coluna = New DataColumn()
            coluna.ColumnName = "cid"
            coluna.ReadOnly = True
            tabela.Columns.Add(coluna)
            coluna = New DataColumn()
            coluna.ColumnName = "codigo"
            coluna.ReadOnly = True
            tabela.Columns.Add(coluna)
            coluna = New DataColumn()
            coluna.ColumnName = "descricao"
            coluna.ReadOnly = True
            tabela.Columns.Add(coluna)
            coluna = New DataColumn()
            coluna.ColumnName = "referencia"
            coluna.ReadOnly = True
            tabela.Columns.Add(coluna)
            coluna = New DataColumn()
            coluna.ColumnName = "cor"
            coluna.ReadOnly = True
            tabela.Columns.Add(coluna)
            coluna = New DataColumn()
            coluna.ColumnName = "grupo"
            coluna.ReadOnly = True
            tabela.Columns.Add(coluna)
            coluna = New DataColumn()
            coluna.ColumnName = "item"
            coluna.ReadOnly = True
            tabela.Columns.Add(coluna)

            itensExibir.Clear()
            itensExibir.Add("codigobarras")
            itensExibir.Add("tamanho")

            If IsNothing(filtro.produtoTipo_cid) Then
                filtro.produtoTipo_cid = 1
            End If

            '-- Montar colunas dos itens
            colecaoPTC = regraPTC.ConsultarPorProdutoTipo(filtro.produtoTipo_cid)
            For Each dadosPTC As dProdutoTipoCaracteristica In colecaoPTC
                If itensExibir.Contains(dadosPTC.caracteristica_codigo.ToLower()) Then
                    coluna = New DataColumn()
                    coluna.ColumnName = dadosPTC.caracteristica_codigo
                    coluna.Caption = dadosPTC.caracteristica_nome
                    coluna.ReadOnly = True
                    tabela.Columns.Add(coluna)
                End If
            Next

            itensExibir.Clear()
            itensExibir.Add("estoque")

            '-- Montar colunas do estoque
            colecaoPTC = regraPTC.ConsultarPorProdutoTipo(filtro.produtoTipo_cid)
            For Each dadosPTC As dProdutoTipoCaracteristica In colecaoPTC
                If itensExibir.Contains(dadosPTC.caracteristica_codigo.ToLower()) Then
                    coluna = New DataColumn()
                    coluna.ColumnName = dadosPTC.caracteristica_codigo
                    coluna.Caption = dadosPTC.caracteristica_nome
                    coluna.ReadOnly = True
                    tabela.Columns.Add(coluna)
                    Exit For
                End If
            Next

            itensExibir.Clear()
            itensExibir.Add("codigobarras")
            itensExibir.Add("tamanho")
            itensExibir.Add("estoque")

            coluna = New DataColumn()
            coluna.ColumnName = "estoqueatualizacao"
            tabela.Columns.Add(coluna)

            Application.DoEvents()

            '-- Preencher tabela
            produtos = regraP.Consultar(filtro)
            If Not IsNothing(produtos) Then

                barra.Maximum = produtos.Count

                For Each produto As dProduto In produtos

                    colecaoPI = regraPI.ConsultarPorProduto(produto.cid)
                    linha = Nothing
                    _item = Nothing
                    If Not IsNothing(colecaoPI) Then
                        For Each dadosPI As dProdutoItem In colecaoPI
                            If Not _item.Equals(dadosPI.item) Then
                                If linha IsNot Nothing Then
                                    tabela.Rows.Add(linha)
                                    linha = Nothing
                                End If

                                linha = tabela.NewRow()
                                linha("cid") = RetornarTexto(produto.cid)
                                linha("codigo") = RetornarTexto(produto.codigo)
                                linha("descricao") = RetornarTexto(produto.descricao)
                                linha("referencia") = RetornarTexto(produto.referencia)
                                linha("cor") = RetornarTexto(produto.cor)
                                linha("grupo") = RetornarTexto(produto.grupo)
                                linha("item") = RetornarTexto(dadosPI.item)
                                _item = dadosPI.item
                            End If

                            If itensExibir.Contains(dadosPI.caracteristicas_codigo.ToLower()) Then
                                linha(dadosPI.caracteristicas_codigo) = RetornarTexto(dadosPI.valor)
                            End If

                        Next

                    End If

                    Application.DoEvents()

                    barra.Increment(1)
                    barra.Refresh()
                    Me.Refresh()

                    If linha IsNot Nothing Then
                        tabela.Rows.Add(linha)
                        linha = Nothing
                    End If
                Next
            End If

            '-- Exibir dados
            dgvProduto.DataSource = tabela
            dgvProduto.Refresh()

            Application.DoEvents()

            If dgvProduto.Rows.Count > 0 Then
                dgvProduto.Columns(0).Visible = False
                dgvProduto.Columns(1).HeaderText = "Código"
                dgvProduto.Columns(2).HeaderText = "Descrição"
                dgvProduto.Columns(3).HeaderText = "Referência"
                dgvProduto.Columns(4).HeaderText = "Cor"
                dgvProduto.Columns(5).HeaderText = "Grupo"
                dgvProduto.Columns(6).Visible = False
                dgvProduto.Columns(7).HeaderText = "Código de Barras"
                dgvProduto.Columns(8).HeaderText = "Tamanho"
                dgvProduto.Columns(9).HeaderText = "Estoque Atual"
                dgvProduto.Columns(10).HeaderText = "Novo Estoque"
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta da lista de Produtos.")

        End Try
    End Sub

    Private Sub CarregarProdutoBalancoFiltro()
        mdiPrincipal.CarregarProdutoBalancoFiltro()
    End Sub

    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        CarregarProdutoBalancoFiltro()
    End Sub

    Private Sub btoTransferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoTransferencia.Click
        CarregarProdutoEntradaSaidaFiltro()
    End Sub

    Private Sub CarregarProdutoEntradaSaidaFiltro()
        mdiPrincipal.CarregarProdutoEntradaSaidaFiltro()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim contLinha As Integer = 0

        If AbrirArquivo() = False Then
            Exit Sub
        End If

        contLinha = 0

        For Each linha As DataGridViewRow In dgvProduto.Rows
            IncluirLinhaArquivo(linha)
        Next

        FecharArquivo()

        MessageBox.Show("Grade de produtos enviada para arquivo!")
    End Sub

    Private Function AbrirArquivo() As Boolean
        Try
            '-- Criar arquivo
            Dim dataAtual As Date = DateTime.Now
            Dim data As String = dataAtual.Day.ToString() + "/" + dataAtual.Month.ToString() + "/" + dataAtual.Year.ToString()
            Dim arquivoNome As String = AppDomain.CurrentDomain.BaseDirectory + "\arquivos_balanco\bal_" + FormatarDataUniversal(data) + "_" + quantidade.ToString() + ".txt"

            If System.IO.File.Exists(arquivoNome) Then
                System.IO.File.Delete(arquivoNome)
            End If

            quantidade += 1
            arquivo = New System.IO.StreamWriter(arquivoNome, True, System.Text.Encoding.ASCII)

            arquivoCriado = True
        Catch ex As Exception
            MessageBox.Show("Erro ao criar arquivo", "Arquivo Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return False
        End Try

        Return True
    End Function

    Private Sub IncluirLinhaArquivo(ByVal linha As DataGridViewRow)
        Dim conteudo As String = ""

        contLinha += 1

        conteudo += RetornarVazio(linha.Cells(7).Value).PadLeft(14, "0"c) + ";" '-- Código de barras  
        conteudo += RetornarVazio(linha.Cells("descricao").Value) + ";" '-- Descrição 
        conteudo += IIf(String.IsNullOrEmpty(RetornarVazio(linha.Cells(9).Value)), "0", RetornarVazio(linha.Cells(9).Value)) + ";" '-- Estoque atual 

        EscreverArquivo(conteudo)
    End Sub

    Private Sub EscreverArquivo(ByVal conteudo As String)
        If arquivoCriado = False Then
            AbrirArquivo()
        End If

        arquivo.WriteLine(conteudo)
    End Sub

    Private Sub FecharArquivo()
        Try
            If arquivoCriado = True Then
                '-- Finalizar arquivo
                arquivo.Close()
                arquivo.Dispose()
            End If

            contLinha = 0

        Catch ex As Exception
            '-- Finalizar arquivo
            arquivo.Close()
            arquivo.Dispose()
        End Try

        arquivoCriado = False
    End Sub

    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        If Not ValidarProduto() Then
            MessageBox.Show("Arquivo com erro!")
        End If

    End Sub

    Private Function ValidarProduto() As Boolean
        Dim conteudo As IO.StreamReader
        Dim linha As String
        Dim arquivo As IO.FileInfo
        Dim regras As rProduto = New rProduto()
        Dim numLinha As Integer = 0
        Dim OpenFileDialog1 As New Windows.Forms.OpenFileDialog
        Dim fileName As String
        Dim dadosProduto As dProduto

        Dim colunas() As String

        Try
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                fileName = OpenFileDialog1.FileName
            Else
                Exit Function
            End If

            arquivo = New FileInfo(fileName)
            barra.Minimum = 0
            barra.Maximum = arquivo.Length
            barra.Value = 0

            conteudo = New IO.StreamReader(fileName, System.Text.Encoding.Default)
            linha = conteudo.ReadLine()
            linha = conteudo.ReadLine()
            numLinha += 1

            While Not String.IsNullOrEmpty(linha)
                Application.DoEvents()

                linha = ValidarCaracteres(linha)
                colunas = linha.Split(",")

                dadosProduto = New dProduto()
                dadosProduto.codigoBarras = colunas(0)
                'dadosProduto.descricao = colunas(1)
                If IsNumeric(colunas(1)) Then
                    dadosProduto.estoqueMinimo = colunas(1)
                End If

                For Each row As DataGridViewRow In Me.dgvProduto.Rows
                    If row.Cells(7).Value.Equals(dadosProduto.codigoBarras) Then
                        If row.Cells(10).Value.Equals(DBNull.Value) Then
                            row.Cells(10).Value = dadosProduto.estoqueMinimo
                        Else
                            row.Cells(10).Value = CInt(row.Cells(10).Value) + dadosProduto.estoqueMinimo
                        End If
                        If row.Cells(10).Value.Equals(row.Cells(9).Value) Then
                            row.Cells(10).Style.ForeColor = Color.Blue
                        Else
                            row.Cells(10).Style.ForeColor = Color.Red
                        End If
                        Exit For
                    End If
                Next

                barra.Increment(linha.Length)
                linha = conteudo.ReadLine()
                numLinha += 1
                barra.Refresh()
                Me.Refresh()
            End While

            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("Validação de Produtos concluída com sucesso! [" & numLinha.ToString() & "]")
            barra.Value = barra.Maximum
        Catch ex As Exception
            If Not IsNothing(conteudo) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("Erro na validação de produtos [linha " & numLinha.ToString() & "] - " & ex.Message)
            Return False
        End Try

        Return True
    End Function

    Private Function ValidarCaracteres(ByRef linha As String) As String
        Dim _linha As String = ""
        Dim _posicao As Integer

        Try

            For i As Int32 = 0 To linha.Length - 1 Step 1
                If linha.Substring(i, 1).Equals(vbNullChar) Then
                    _linha += " "
                Else
                    If caracs.Contains(linha.Substring(i, 1)) Then
                        _linha += linha.Substring(i, 1)
                    Else
                        _posicao = carEsp.IndexOf(linha.Substring(i, 1))
                        If _posicao >= 0 Then
                            _linha += carSub.Substring(_posicao, 1)
                        Else
                            Throw New Exception("Caracter [" & linha.Substring(i, 1) & "] inválido encontrado!")
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try

        Return _linha
    End Function

    Private Function ValidarTamanhoLinha(ByRef linha As String, ByVal tamanho As Int32) As Boolean
        Try

            If linha.Length < tamanho Then
                Throw New Exception("Tamanho [" + tamanho.ToString() + "] inválido [" + linha.Length.ToString() + "]")
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return True
    End Function
End Class