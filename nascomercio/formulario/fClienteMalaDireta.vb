Imports ncRegras.nsCliente
Imports ncDados.nsCliente
Imports ncComum.nsExcecao

Imports ncComum.nsEtiqueta
Imports System.Drawing.Printing

Public Class fClienteMalaDireta

  Public filtro As dCliente
  Public listaClientes As ColecaoCliente
  Private paginaAtual As Integer = 1
  Private linhaGridAtual As Integer = -1
  Private colecaoEtiquetaMalaDireta As New ColecaoEtiquetaMalaDireta

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    If Me.Modal Then
      Me.Close()
    Else
      mdiPrincipal.FecharTela()
    End If
  End Sub

  Private Sub Cadastrar()
    mdiPrincipal.CarregarClienteForm()
  End Sub

  Private Sub Filtrar()
    If Me.Modal Then
      filtro.nome = txtCliente.Text
      If txtCliente.Text.Length < 3 Then
        MessageBox.Show("Informe o nome do cliente!")
      Else
        CarregarClientes()
      End If
    Else
      mdiPrincipal.CarregarClienteFiltro()
    End If

  End Sub

  Private Sub fClienteLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        If Me.Modal Then
          Me.Close()
        Else
          mdiPrincipal.FecharTela()
        End If
        'Case Keys.F5
        '  If Me.Modal Then
        '    Me.Close()
        '  End If
        '  Cadastrar()
      Case Keys.F6
        Filtrar()
      Case Keys.Enter
        If Me.Modal Then
          If Me.dgvCliente.Rows.Count > 0 Then
            SelecionarItemCaixa()
            Me.Close()
          Else
            Filtrar()
          End If
        Else
          SelecionarItem()
        End If
    End Select
  End Sub

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Cadastrar()
  End Sub

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    Filtrar()
  End Sub

  Private Sub fClienteLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If Me.Modal Then
      lblCliente.Visible = True
      txtCliente.Visible = True
      'btoCadastro.Visible = False
    Else
      lblCliente.Visible = False
      txtCliente.Visible = False
      'btoCadastro.Visible = True
      CarregarClientes()
    End If

  End Sub

  Private Sub dgvCliente_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCliente.CellDoubleClick
    If Me.Modal Then
      SelecionarItemCaixa()
      Me.Close()
    Else
      SelecionarItem()
    End If
  End Sub

  Private Sub SelecionarItemCaixa()
    Dim indice As Integer
    Dim linha As DataGridViewRow
    indice = dgvCliente.CurrentRow.Index
    linha = dgvCliente.Rows(indice)
    Me.filtro.cid = linha.Cells("cid").Value
    Me.filtro.nome = linha.Cells("nome").Value
    Me.filtro.situacao = IIf(linha.Cells("cid").Style.ForeColor = Color.Red, "N", "A")

  End Sub

  Private Sub SelecionarItem()
    Dim indice As Integer
    Dim linha As DataGridViewRow
    Dim cid As Nullable(Of Integer)

    Try
      If dgvCliente.Rows.Count > 0 Then

        indice = dgvCliente.CurrentRow.Index

        linha = dgvCliente.Rows(indice)

        cid = linha.Cells("cid").Value

      End If
    Catch ex As Exception

      cid = Nothing

    End Try

    fClienteForm.cid = cid

    mdiPrincipal.CarregarClienteForm()
  End Sub

  Private Sub CarregarClientes()
    Dim regras As rCliente
    Dim regrasFinanceiro As rClienteFinanceiro
    'Dim clientes As ColecaoCliente
    Dim clientefinanceiro As ColecaoClienteFinanceiro
    Dim dadosFinanceiros As dClienteFinanceiro
    Dim linha As DataGridViewRow

    Try

      dgvCliente.Rows.Clear()

      regras = New rCliente
      regrasFinanceiro = New rClienteFinanceiro

      'listaClientes = regras.Consultar(filtro)

      If Not IsNothing(listaClientes) Then
        For Each cliente As dCliente In listaClientes
          dadosFinanceiros = New dClienteFinanceiro()
          dadosFinanceiros.cliente_cid = cliente.cid
          clientefinanceiro = regrasFinanceiro.Consultar(dadosFinanceiros)
          If Me.Modal Then
            linha = dgvCliente.Rows(dgvCliente.Rows.Add())
            If Not IsNothing(clientefinanceiro) Then
              If clientefinanceiro(0).situacaoCrediario = "N" Then
                linha.Cells("cid").Style.ForeColor = Color.Red
                linha.Cells("Nome").Style.ForeColor = Color.Red
              End If
            End If
            linha.Cells("cid").Value = cliente.cid
            linha.Cells("Nome").Value = cliente.nome
            linha.Cells("Cpf").Value = cliente.cpf
            linha.Cells("Rg").Value = cliente.rg
            linha.Cells("Situacao").Value = cliente.situacao
            linha.Cells("Ddd").Value = cliente.ddd
            linha.Cells("Telefone").Value = cliente.telefone
            linha.Cells("Email").Value = cliente.email
          Else
            If cliente.cid.Value > 1 Then
              linha = dgvCliente.Rows(dgvCliente.Rows.Add())
              If Not IsNothing(clientefinanceiro) Then
                If clientefinanceiro(0).situacaoCrediario = "N" Then
                  linha.Cells("cid").Style.ForeColor = Color.Red
                  linha.Cells("Nome").Style.ForeColor = Color.Red
                End If
              End If
              linha.Cells("cid").Value = cliente.cid
              linha.Cells("Nome").Value = cliente.nome
              linha.Cells("Cpf").Value = cliente.cpf
              linha.Cells("Rg").Value = cliente.rg
              linha.Cells("Situacao").Value = cliente.situacao
              linha.Cells("Ddd").Value = cliente.ddd
              linha.Cells("Telefone").Value = cliente.telefone
              linha.Cells("Email").Value = cliente.email
            End If
          End If
        Next
      End If

      dgvCliente.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta da lista de Clientes.")

    End Try
  End Sub
  Public Sub New()

    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.

  End Sub

  Private Sub btoImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoImprimir.Click
    linhaGridAtual = -1
    Dim clienteEndereco As New dClienteEndereco
    Dim cliente As New dCliente
    Dim rCE As rClienteEndereco = New rClienteEndereco()
    Dim rC As rCliente = New rCliente()
    Dim etiqueta As New dEtiquetaMalaDireta
    Dim cep As String = ""


    colecaoEtiquetaMalaDireta.RemoveRange(0, colecaoEtiquetaMalaDireta.Count)

    For Each linha As DataGridViewRow In dgvCliente.Rows
      If linha.Cells("check").Value = True Then
        cliente.cid = linha.Cells("cid").Value
        'For Each cli As dCliente In listaClientes
        cliente = rC.ConsultarPorCID(cliente.cid)
        clienteEndereco = rCE.ConsultarPorCID(cliente.cid)
        If Not IsNothing(clienteEndereco) Then
          If Not IsNothing(clienteEndereco.logradouro) Then
            If clienteEndereco.cep.HasValue Then
              cep = clienteEndereco.cep.Value
            Else
              cep = ""
            End If
            If cep.Length < 8 Then
              cep = Strings.Right("0000" & cep, 8)
            End If
            'IIf((cep.Length < 8), cep = Strings.Right("0000" & cep, 8), cep = cep)
            colecaoEtiquetaMalaDireta.Add(New dEtiquetaMalaDireta(cliente.nome.Replace("*", ""), clienteEndereco.logradouro, IIf(IsNothing(clienteEndereco.numero), "", clienteEndereco.numero), IIf(IsNothing(clienteEndereco.complemento), "", clienteEndereco.complemento), clienteEndereco.bairro, clienteEndereco.cidade, clienteEndereco.siglaEstado, cep))
          End If
        End If
      End If
    Next

    If imprimirArgoxRadioButton.Checked Then
      etiqueta.ImprimirEtiquetaMalaDireta(colecaoEtiquetaMalaDireta)
    ElseIf imprimirEJT30RadioButton.Checked Then
      Try
        linhaGridAtual = -1


        'cria um novo documento para impressão
        Dim pd As PrintDocument = New PrintDocument()
        'relaciona o objeto pd ao procedimento rptProdutos
        AddHandler pd.PrintPage, AddressOf Me.rptClientes
        'cria uma nova instância do objeto PrintPreviewDialog()
        'Dim objPrintPreview = New PrintPreviewDialog()
        'define algumas propriedades do obejto
        'tire o botão padrão de imrpimir
        ''DirectCast((objPrintPreview.Controls(1)), ToolStrip).Items.RemoveAt(0)
        'coloca botão para configurar impressão
        ''DirectCast((objPrintPreview.Controls(1)), ToolStrip).Items.Insert(0, Me.PrintToolStripButton)
        ''Me.MainToolStrip.Items.Insert(5, DirectCast((objPrintPreview.Controls(1)), ToolStrip).Items(0))
        'With objPrintPreview
        '  'indica qual o documento vai ser visualizado
        '  .Document = pd
        '  .WindowState = FormWindowState.Maximized
        '  .PrintPreviewControl.Zoom = 1   'maxima a visualização
        '  .Text = "Mala Direta" + paginaAtual.ToString
        '  'exibe a janela de visualização para o usuário
        '  .ShowDialog()
        'End With
        'MessageBox.Show(strCliente)
        pd.Print()

      Catch ex As Exception

        MessageBox.Show(ex.Message)

      End Try

    ElseIf imprimirEJT20RadioButton.Checked Then
      Try
        linhaGridAtual = -1
        'cria um novo documento para impressão
        Dim pd As PrintDocument = New PrintDocument()
        'relaciona o objeto pd ao procedimento rptProdutos
        AddHandler pd.PrintPage, AddressOf Me.criarEtiquetas2X10
        'cria uma nova instância do objeto PrintPreviewDialog()
        'Dim objPrintPreview = New PrintPreviewDialog()
        'define algumas propriedades do obejto
        'tire o botão padrão de imrpimir
        ''DirectCast((objPrintPreview.Controls(1)), ToolStrip).Items.RemoveAt(0)
        'coloca botão para configurar impressão
        ''DirectCast((objPrintPreview.Controls(1)), ToolStrip).Items.Insert(0, Me.PrintToolStripButton)
        ''Me.MainToolStrip.Items.Insert(5, DirectCast((objPrintPreview.Controls(1)), ToolStrip).Items(0))
        'With objPrintPreview
        '  'indica qual o documento vai ser visualizado
        '  .Document = pd
        '  .WindowState = FormWindowState.Maximized
        '  .PrintPreviewControl.Zoom = 1   'maxima a visualização
        '  .Text = "Mala Direta" + paginaAtual.ToString
        '  'exibe a janela de visualização para o usuário
        '  .ShowDialog()
        'End With
        'MessageBox.Show(strCliente)
        pd.Print()

      Catch ex As Exception

        MessageBox.Show(ex.Message)

      End Try

    End If




  End Sub
  Private Sub rptClientes(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintPageEventArgs)
    Dim margemEsq As Single = 10  'Relatorio.MarginBounds.Left
    Dim margemSup As Single = 10  'Relatorio.MarginBounds.Top
    Dim margemDir As Single = 0.5 'Relatorio.MarginBounds.Right
    Dim margemInf As Single = 1   'Relatorio.MarginBounds.Bottom
    Dim fonteTitulo As Font
    Dim fonteRodape As Font
    Dim fonteNormal As Font
    Dim linhaAtual As Integer = 4
    Dim linhasPorPagina As Integer
    Dim posicaoDaLinha As Integer

    fonteTitulo = New Font("Verdana", 15, FontStyle.Bold)
    fonteRodape = New Font("Verdana", 6)
    fonteNormal = New Font("Verdana", 8)

    'Relatorio.Graphics.DrawLine(Pens.Blue, margemEsq, 160, margemDir, 160)
    'Relatorio.Graphics.DrawString("Mala Direta", fonteTitulo, Brushes.Blue, margemEsq + 275, 80, New StringFormat())

    'define o número de linhas por página
    'para isto faço a divisão da área de impressão pelo tamanho da fonte subtraido do valor 10
    linhasPorPagina = Relatorio.MarginBounds.Height / fonteNormal.GetHeight(Relatorio.Graphics) - 10

    Dim rCE As rClienteEndereco = New rClienteEndereco()
    Dim rC As rCliente = New rCliente()
    Dim clienteFinanceiro As New dClienteFinanceiro
    Dim clienteEndereco As New dClienteEndereco

    Dim cliente As New dCliente
    Dim coluna As Integer = 1
    Dim quantidadeClientes As Integer
    Dim etiquetaVertical As Integer = 1
    Dim cep As String = ""

    quantidadeClientes = dgvCliente.Rows.Count
    'acompanha a posição da linha atual
    posicaoDaLinha = margemSup + (linhaAtual * fonteNormal.GetHeight(Relatorio.Graphics))

    For Each linha As DataGridViewRow In dgvCliente.Rows
      If linhaGridAtual <= linha.Index Then
        linhaGridAtual += 1

        'verifica se é para imprimir etiqueta com o usuário e se ainda podemos imprimir , ou seja , se a linha atual é menor que o número
        'de linhas permitido pela página. Se for continuamos a atribuir os dados e a imprimir
        If linha.Cells("check").Value = True Then
          cliente.cid = linha.Cells("cid").Value
          'For Each cli As dCliente In listaClientes
          cliente = rC.ConsultarPorCID(cliente.cid)
          clienteEndereco = rCE.ConsultarPorCID(cliente.cid)
          If Not IsNothing(clienteEndereco) Then

            If Not IsNothing(clienteEndereco.logradouro) Then

              'imprime os dados relativo ao codigo , nome do produto e preço do produto
              Relatorio.Graphics.DrawString(cliente.nome, fonteNormal, Brushes.Black, margemEsq, posicaoDaLinha, New StringFormat())
              'faz o incremento no número de linha
              linhaAtual += 1
              posicaoDaLinha = margemSup + (linhaAtual * fonteNormal.GetHeight(Relatorio.Graphics)) + etiquetaVertical * 3
              Relatorio.Graphics.DrawString(clienteEndereco.logradouro + ", " + IIf(IsNothing(clienteEndereco.numero), "", clienteEndereco.numero) + ", " + IIf(IsNothing(clienteEndereco.complemento), "", clienteEndereco.complemento), fonteNormal, Brushes.Black, margemEsq, posicaoDaLinha, New StringFormat())
              linhaAtual += 1
              posicaoDaLinha = margemSup + (linhaAtual * fonteNormal.GetHeight(Relatorio.Graphics)) + etiquetaVertical * 3
              Relatorio.Graphics.DrawString(clienteEndereco.bairro, fonteNormal, Brushes.Black, margemEsq, posicaoDaLinha, New StringFormat())
              linhaAtual += 1
              posicaoDaLinha = margemSup + (linhaAtual * fonteNormal.GetHeight(Relatorio.Graphics)) + etiquetaVertical * 3
              Relatorio.Graphics.DrawString(clienteEndereco.cidade + " - " + clienteEndereco.siglaEstado, fonteNormal, Brushes.Black, margemEsq, posicaoDaLinha, New StringFormat())
              linhaAtual += 1
              posicaoDaLinha = margemSup + (linhaAtual * fonteNormal.GetHeight(Relatorio.Graphics)) + etiquetaVertical * 3
              cep = clienteEndereco.cep.Value
              If cep.Length < 8 Then
                cep = Strings.Right("0000" & cep, 8)
              End If
              Relatorio.Graphics.DrawString(cep, fonteNormal, Brushes.Black, margemEsq, posicaoDaLinha, New StringFormat())
              linhaAtual += 3
              posicaoDaLinha = margemSup + (linhaAtual * fonteNormal.GetHeight(Relatorio.Graphics)) + etiquetaVertical * 3

              If coluna = 1 Then
                linhaAtual -= 7
                margemEsq += 280
                posicaoDaLinha = margemSup + (linhaAtual * fonteNormal.GetHeight(Relatorio.Graphics)) + etiquetaVertical * 3
                coluna = 2
              ElseIf coluna = 2 Then
                linhaAtual -= 7
                margemEsq += 280
                posicaoDaLinha = margemSup + (linhaAtual * fonteNormal.GetHeight(Relatorio.Graphics)) + etiquetaVertical * 3
                coluna = 3
              Else
                margemEsq -= 560
                coluna = 1
                etiquetaVertical += 1

                If etiquetaVertical > 10 And linhaGridAtual <= dgvCliente.Rows.Count Then
                  paginaAtual += 1

                  Relatorio.HasMorePages = True
                  'linhaAtual = 1
                  ' if (linhaAtual > linhasPorPagina * paginaAtual - 5) - antigo isso para inserir folha
                  Exit For
                End If

              End If
            End If
          End If

        End If
      End If
    Next
    'paginaAtual = 0
  End Sub

  Private Sub criarEtiquetas2X10(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintPageEventArgs)
    Dim margemEsq As Single = 10  'Relatorio.MarginBounds.Left
    Dim margemSup As Single = 10  'Relatorio.MarginBounds.Top
    Dim margemDir As Single = 0.5 'Relatorio.MarginBounds.Right
    Dim margemInf As Single = 1   'Relatorio.MarginBounds.Bottom
    Dim fonteTitulo As Font
    Dim fonteRodape As Font
    Dim fonteNormal As Font
    Dim linhaAtual As Integer = 4
    Dim linhasPorPagina As Integer
    Dim posicaoDaLinha As Integer
    Dim posicaoDalinha1 As Integer
    Dim etiqueta As dEtiquetaMalaDireta

    fonteTitulo = New Font("Verdana", 15, FontStyle.Bold)
    fonteRodape = New Font("Verdana", 6)
    fonteNormal = New Font("Verdana", 8)

    'Relatorio.Graphics.DrawLine(Pens.Blue, margemEsq, 160, margemDir, 160)
    'Relatorio.Graphics.DrawString("Mala Direta", fonteTitulo, Brushes.Blue, margemEsq + 275, 80, New StringFormat())

    'define o número de linhas por página
    'para isto faço a divisão da área de impressão pelo tamanho da fonte subtraido do valor 10
    linhasPorPagina = Relatorio.MarginBounds.Height / fonteNormal.GetHeight(Relatorio.Graphics) - 10

    Dim coluna As Integer = 1
    Dim quantidadeClientes As Integer = 0
    Dim etiquetaVertical As Integer = 1

    'acompanha a posição da linha atual
    posicaoDaLinha = 51 'margemSup + (linhaAtual * fonteNormal.GetHeight(Relatorio.Graphics))

    Do While linhaGridAtual < (colecaoEtiquetaMalaDireta.Count - 1)
      linhaGridAtual += 1
      etiqueta = colecaoEtiquetaMalaDireta(linhaGridAtual)
      posicaoDalinha1 = posicaoDaLinha
      'verifica se é para imprimir etiqueta com o usuário e se ainda podemos imprimir , ou seja , se a linha atual é menor que o número
      'de linhas permitido pela página. Se for continuamos a atribuir os dados e a imprimir

      'imprime os dados relativo ao codigo , nome do produto e preço do produto
      Relatorio.Graphics.DrawString(etiqueta.NomeCliente, fonteNormal, Brushes.Black, margemEsq, posicaoDaLinha, New StringFormat())
      'faz o incremento no número de linha
      posicaoDaLinha += fonteNormal.GetHeight(Relatorio.Graphics)
      Relatorio.Graphics.DrawString(etiqueta.Logradouro + ", " + IIf(IsNothing(etiqueta.Numero), "", etiqueta.Numero) + ", " + IIf(IsNothing(etiqueta.Complemento), "", etiqueta.Complemento), fonteNormal, Brushes.Black, margemEsq, posicaoDaLinha, New StringFormat())
      posicaoDaLinha += fonteNormal.GetHeight(Relatorio.Graphics)
      Relatorio.Graphics.DrawString(etiqueta.Bairro, fonteNormal, Brushes.Black, margemEsq, posicaoDaLinha, New StringFormat())
      posicaoDaLinha += fonteNormal.GetHeight(Relatorio.Graphics)
      Relatorio.Graphics.DrawString(etiqueta.Cidade + " - " + etiqueta.Estado, fonteNormal, Brushes.Black, margemEsq, posicaoDaLinha, New StringFormat())
      posicaoDaLinha += fonteNormal.GetHeight(Relatorio.Graphics)
      Relatorio.Graphics.DrawString(etiqueta.Cep, fonteNormal, Brushes.Black, margemEsq, posicaoDaLinha, New StringFormat())

      If coluna = 1 Then
        margemEsq += 427
        posicaoDaLinha = posicaoDalinha1
        coluna = 2
      ElseIf coluna = 2 Then
        margemEsq -= 427
        posicaoDaLinha = posicaoDalinha1 + 102
        coluna = 1
        etiquetaVertical += 1

        If etiquetaVertical > 10 And linhaGridAtual < colecaoEtiquetaMalaDireta.Count Then
          paginaAtual += 1
          Relatorio.HasMorePages = True
          Exit Do
        End If

      End If
    Loop
    'Relatorio.Graphics.DrawString("123456789012345678901234567890", fonteNormal, Brushes.Black, margemEsq, posicaoDaLinha, New StringFormat())
    'paginaAtual = 0
  End Sub
  Private Sub btnSelecionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelecionar.Click
    For Each linha As DataGridViewRow In dgvCliente.Rows
      linha.Cells("check").Value = True
    Next
  End Sub

  Private Sub btoDesmarcar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoDesmarcar.Click
    For Each linha As DataGridViewRow In dgvCliente.Rows
      linha.Cells("check").Value = False
    Next
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)




  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    linhaGridAtual = -1
    Try

      'cria um novo documento para impressão
      Dim pd As PrintDocument = New PrintDocument()
      'relaciona o objeto pd ao procedimento rptProdutos
      AddHandler pd.PrintPage, AddressOf Me.criarEtiquetas2X10
      'cria uma nova instância do objeto PrintPreviewDialog()
      'Dim objPrintPreview = New PrintPreviewDialog()
      'define algumas propriedades do obejto
      'tire o botão padrão de imrpimir
      ''DirectCast((objPrintPreview.Controls(1)), ToolStrip).Items.RemoveAt(0)
      'coloca botão para configurar impressão
      ''DirectCast((objPrintPreview.Controls(1)), ToolStrip).Items.Insert(0, Me.PrintToolStripButton)
      ''Me.MainToolStrip.Items.Insert(5, DirectCast((objPrintPreview.Controls(1)), ToolStrip).Items(0))
      'With objPrintPreview
      '  'indica qual o documento vai ser visualizado
      '  .Document = pd
      '  .WindowState = FormWindowState.Maximized
      '  .PrintPreviewControl.Zoom = 1   'maxima a visualização
      '  .Text = "Mala Direta" + paginaAtual.ToString
      '  'exibe a janela de visualização para o usuário
      '  .ShowDialog()
      'End With
      'MessageBox.Show(strCliente)
      pd.Print()

    Catch ex As Exception

      MessageBox.Show(ex.Message)

    End Try
  End Sub
End Class