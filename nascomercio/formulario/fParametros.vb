Imports ncComum.nsExcecao
Imports ncRegras.nsParametro
Imports ncDados.nsParametro
Imports ncComum.nsConstantes

Public Class fParametros

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        mdiPrincipal.FecharTela()
    End Sub

    Private Sub fProdutoLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.Enter
                Salvar()
        End Select
    End Sub

    Private Sub Salvar()
        Dim regraParametro As New rParametro
        Dim dadosParametro As dParametro
        Dim valorDecimal As Integer
        Dim excVenda As Integer

        If MessageBox.Show("Confirma ALTERAÇÃO das informações?", "ALTERAÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

            Try

                ' Verifica existencia de parametro Juros
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.JurosDiario)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.JurosDiario
                    dadosParametro.descricao = "Juros diários"
                    dadosParametro.valor = txtJuros.Text
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.JurosDiario
                    dadosParametro.valor = txtJuros.Text
                    regraParametro.Alterar(dadosParametro)
                End If

                ' Verifica existencia de parametro Tolerancia
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.DiasTolerancia)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.DiasTolerancia
                    dadosParametro.descricao = "Dias tolerância crediário"
                    dadosParametro.valor = txtTolerancia.Text
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.DiasTolerancia
                    dadosParametro.valor = txtTolerancia.Text
                    regraParametro.Alterar(dadosParametro)
                End If

                ' Verifica existencia de parametro Cobrar tolerância
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.CobrarJurosTolerancia)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.CobrarJurosTolerancia
                    dadosParametro.descricao = "Cobrar juros tolerância crediário"
                    dadosParametro.valor = cboIncluir.SelectedText
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.CobrarJurosTolerancia
                    dadosParametro.valor = cboIncluir.Text
                    regraParametro.Alterar(dadosParametro)
                End If

                ' Verifica existencia de parametro Primeira parcela
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.TempoPrimeiraParcela)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.TempoPrimeiraParcela
                    dadosParametro.descricao = "Tempo primeira parcela"
                    dadosParametro.valor = txtTempoParcela.Text
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.TempoPrimeiraParcela
                    dadosParametro.valor = txtTempoParcela.Text
                    regraParametro.Alterar(dadosParametro)
                End If

                ' Verifica existencia de parametro Quantidade no caixa  
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.QuantidadeCaixa)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.QuantidadeCaixa
                    dadosParametro.descricao = "Entrar quantidade no caixa"
                    dadosParametro.valor = cboQuantidade.SelectedText
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.QuantidadeCaixa
                    dadosParametro.valor = cboQuantidade.Text
                    regraParametro.Alterar(dadosParametro)
                End If

                ' Verifica existencia de parametro Loja com mais de um caixa
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.LojaGrande)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.LojaGrande
                    dadosParametro.descricao = "Loja com mais de um caixa"
                    dadosParametro.valor = cboLojaGrande.SelectedText
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.LojaGrande
                    dadosParametro.valor = cboLojaGrande.Text
                    regraParametro.Alterar(dadosParametro)
                End If

                ' Verifica existencia de parametro Minimo negativar
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.MinimoNegativar)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.MinimoNegativar
                    dadosParametro.descricao = "Minimo para Negativar"
                    dadosParametro.valor = txtMinimoNegativar.Text
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.MinimoNegativar
                    dadosParametro.valor = txtMinimoNegativar.Text
                    regraParametro.Alterar(dadosParametro)
                End If

                ' Fechar tela caixa
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.FecharTelaCaixa)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.FecharTelaCaixa
                    dadosParametro.descricao = "Fechar tela caixa"
                    dadosParametro.valor = cboVenda.SelectedText
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.FecharTelaCaixa
                    dadosParametro.valor = cboVenda.Text
                    regraParametro.Alterar(dadosParametro)
                End If

                ' Mensagem
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Mensagem)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.Mensagem
                    dadosParametro.descricao = "Mensagem impressão"
                    dadosParametro.valor = txtMensagem.Text
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.Mensagem
                    dadosParametro.valor = txtMensagem.Text
                    regraParametro.Alterar(dadosParametro)
                End If

                ' Impressora cupom
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Cupom)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.Cupom
                    dadosParametro.descricao = "Impressora Cupom"
                    dadosParametro.valor = cboCupom.SelectedText
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.Cupom
                    dadosParametro.valor = cboCupom.Text
                    regraParametro.Alterar(dadosParametro)
                End If

                ' Cortar Papel
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.CortarPapel)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.CortarPapel
                    dadosParametro.descricao = "Cortar Papel"
                    dadosParametro.valor = cboCortar.SelectedText
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.CortarPapel
                    dadosParametro.valor = cboCortar.Text
                    regraParametro.Alterar(dadosParametro)
                End If

                ' Segunda Via
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.SegundaVia)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.SegundaVia
                    dadosParametro.descricao = "Segunda Via"
                    dadosParametro.valor = cboSegundaVia.SelectedText
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.SegundaVia
                    dadosParametro.valor = cboSegundaVia.Text
                    regraParametro.Alterar(dadosParametro)
                End If

                ' Impressora Etiqueta
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Etiqueta)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.Etiqueta
                    dadosParametro.descricao = "Impressora Etiqueta"
                    dadosParametro.valor = cboEtiqueta.SelectedText
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.Etiqueta
                    dadosParametro.valor = cboEtiqueta.Text
                    regraParametro.Alterar(dadosParametro)
                End If

                ' Tamanho Etiqueta
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.TamanhoEtiqueta)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.TamanhoEtiqueta
                    dadosParametro.descricao = "Tamanho Etiqueta"
                    dadosParametro.valor = cboTamanho.SelectedText
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.TamanhoEtiqueta
                    dadosParametro.valor = cboTamanho.Text
                    regraParametro.Alterar(dadosParametro)
                End If

                If cboEhDecimal.Text = "Sim" Then
                    valorDecimal = 1
                ElseIf cboEhDecimal.Text = "Não" Then
                    valorDecimal = 0
                End If


                ' Eh Decimal
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.IsDecimal)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.IsDecimal
                    dadosParametro.descricao = "Tamanho Etiqueta"
                    dadosParametro.valor = valorDecimal
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.IsDecimal
                    dadosParametro.valor = valorDecimal
                    regraParametro.Alterar(dadosParametro)
                End If

                ' Criptografia
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Secure)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.Secure
                    dadosParametro.descricao = "Tamanho Etiqueta"

                    If cboCriptografia.SelectedText = "Sim" Then
                        dadosParametro.valor = "1"
                    Else
                        dadosParametro.valor = "0"
                    End If
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.Secure
                    If cboCriptografia.Text = "Sim" Then
                        dadosParametro.valor = "1"
                    Else
                        dadosParametro.valor = "0"
                    End If
                    regraParametro.Alterar(dadosParametro)
                End If


                ' n instancias
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Instancias)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.Instancias
                    dadosParametro.descricao = "Tamanho Etiqueta"
                    dadosParametro.valor = txtNInstancias.Text
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.Instancias
                    dadosParametro.valor = txtNInstancias.Text
                    regraParametro.Alterar(dadosParametro)
                End If

                ' PIX
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.UsarPIX)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.UsarPIX
                    dadosParametro.descricao = "Ligar PIX"

                    If cboPIX.Text = "Sim" Then
                        dadosParametro.valor = "1"
                    Else
                        dadosParametro.valor = "0"
                    End If
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.UsarPIX
                    If cboPIX.Text = "Sim" Then
                        dadosParametro.valor = "1"
                    Else
                        dadosParametro.valor = "0"
                    End If
                    regraParametro.Alterar(dadosParametro)
                End If

                ' Imprime data etiqueta
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.ImprimeDataEtiqueta)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.ImprimeDataEtiqueta
                    dadosParametro.descricao = "Imprime data etiqueta"

                    If cboDataEtiqueta.Text = "Sim" Then
                        dadosParametro.valor = "1"
                    Else
                        dadosParametro.valor = "0"
                    End If
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.ImprimeDataEtiqueta
                    If cboDataEtiqueta.Text = "Sim" Then
                        dadosParametro.valor = "1"
                    Else
                        dadosParametro.valor = "0"
                    End If
                    regraParametro.Alterar(dadosParametro)
                End If


                If cboExcVenda.Text = "Sim" Then
                    excVenda = 1
                ElseIf cboExcVenda.Text = "Não" Then
                    excVenda = 0
                End If


                ' Eh Decimal
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.ExcVenda)
                If IsNothing(dadosParametro) Then
                    dadosParametro = New dParametro()
                    dadosParametro.cid = cConstantes.Parametros.ExcVenda
                    dadosParametro.descricao = "Excluir Venda"
                    dadosParametro.valor = excVenda
                    regraParametro.Incluir(dadosParametro)
                Else
                    dadosParametro.cid = cConstantes.Parametros.ExcVenda
                    dadosParametro.valor = excVenda
                    regraParametro.Alterar(dadosParametro)
                End If

                '' Chave sistema
                'dadosParametro = regraParametro.Consultar(cConstantes.Parametros.ChaveSistema)
                'If IsNothing(dadosParametro) Then
                '    dadosParametro = New dParametro()
                '    dadosParametro.cid = cConstantes.Parametros.ChaveSistema
                '    dadosParametro.descricao = "Chave Sistema"
                '    dadosParametro.valor = txtChave.Text
                '    regraParametro.Incluir(dadosParametro)
                'Else
                '    dadosParametro.cid = cConstantes.Parametros.ChaveSistema
                '    dadosParametro.valor = txtChave.Text
                '    regraParametro.Alterar(dadosParametro)
                'End If

                'Dim result As String = ncComum.EncDec.Decrypt(txtChave.Text, "nascom532")

                'Dim cripto As New ncComum.criptografia()
                'Dim result As String = cripto.Descriptografar(txtChave.Text)
                'cripto = Nothing

                MsgBox("Parâmetros Salvos")

            Catch nex As ExcecaoNascomercio

                MessageBox.Show(nex.Message)

            Catch ex As Exception


                MessageBox.Show("Erro na ALTERAÇÃO dos parâmetros.")

            End Try

        End If

    End Sub

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        Salvar()
    End Sub

    Private Sub fParametros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dadosParametro As dParametro
        Dim regraParametro As New rParametro

        Try

            ' Juros
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.JurosDiario)
            If Not IsNothing(dadosParametro) Then
                Me.txtJuros.Text = dadosParametro.valor
            End If

            ' Dias Tolerancia
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.DiasTolerancia)
            If Not IsNothing(dadosParametro) Then
                Me.txtTolerancia.Text = dadosParametro.valor
            End If

            ' Cobrar Juros Tolerancia
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.CobrarJurosTolerancia)
            If Not IsNothing(dadosParametro) Then
                Me.cboIncluir.Text = dadosParametro.valor
            End If

            ' Tempo primeira parcela
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.TempoPrimeiraParcela)
            If Not IsNothing(dadosParametro) Then
                Me.txtTempoParcela.Text = dadosParametro.valor
            End If

            ' Quantidade no caixa
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.QuantidadeCaixa)
            If Not IsNothing(dadosParametro) Then
                Me.cboQuantidade.Text = dadosParametro.valor
            End If

            ' Loja com mais de um caixa
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.LojaGrande)
            If Not IsNothing(dadosParametro) Then
                Me.cboLojaGrande.Text = dadosParametro.valor
            End If

            ' Minimo Negativar
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.MinimoNegativar)
            If Not IsNothing(dadosParametro) Then
                Me.txtMinimoNegativar.Text = dadosParametro.valor
            End If

            ' Fechar tela caixa
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.FecharTelaCaixa)
            If Not IsNothing(dadosParametro) Then
                Me.cboVenda.Text = dadosParametro.valor
            End If

            ' Criptografia
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Secure)
            If Not IsNothing(dadosParametro) Then
                If dadosParametro.valor = "1" Then
                    Me.cboPIX.Text = "Sim"
                Else
                    Me.cboPIX.Text = "Não"
                End If
            End If


            ' Criptografia
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Secure)
            If Not IsNothing(dadosParametro) Then
                If dadosParametro.valor = "1" Then
                    Me.cboCriptografia.Text = "Sim"
                Else
                    Me.cboCriptografia.Text = "Não"
                End If
            End If


            ' Usar pix?
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.UsarPIX)
            If Not IsNothing(dadosParametro) Then
                If dadosParametro.valor = "1" Then
                    Me.cboPIX.Text = "Sim"
                Else
                    Me.cboPIX.Text = "Não"
                End If
            End If


            ' Numero de instâncias
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Instancias)
            If Not IsNothing(dadosParametro) Then
                Me.txtNInstancias.Text = dadosParametro.valor
            End If



            '' Chave sistema
            'dadosParametro = regraParametro.Consultar(cConstantes.Parametros.ChaveSistema)
            'If Not IsNothing(dadosParametro) Then
            '    Me.txtChave.Text = dadosParametro.valor
            'End If

            'If String.IsNullOrEmpty(txtChave.Text) Then
            '    'cria um objeto da classe Random
            '    Dim rnd As New Random()

            '    ' gera o número aleatório na faixa
            '    ' 0 até MaxValue (2.147.483.647)
            '    Dim numero As Integer = rnd.Next()

            '    'Dim result As String = ncComum.EncDec.Encrypt(numero.ToString() & "#" & Today.AddDays(90).ToString("yyyy-MM-dd"), "nascom532")
            '    Dim cripto As New ncComum.criptografia()
            '    Dim result As String = cripto.Criptografar((numero.ToString() & "00000000").Substring(1, 9) & "#" & Today.AddDays(90).ToString("yyyy-MM-dd"))
            '    cripto = Nothing

            '    Me.txtChave.Text = result
            'End If

            ' Mensagem
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Mensagem)
            If Not IsNothing(dadosParametro) Then
                Me.txtMensagem.Text = dadosParametro.valor
            End If

            ' Cupom
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Cupom)
            If Not IsNothing(dadosParametro) Then
                Me.cboCupom.Text = dadosParametro.valor
            End If

            ' Cortar Papel
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.CortarPapel)
            If Not IsNothing(dadosParametro) Then
                Me.cboCortar.Text = dadosParametro.valor
            End If

            ' Segunda Via
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.SegundaVia)
            If Not IsNothing(dadosParametro) Then
                Me.cboSegundaVia.Text = dadosParametro.valor
            End If

            ' Etiqueta
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Etiqueta)
            If Not IsNothing(dadosParametro) Then
                Me.cboEtiqueta.Text = dadosParametro.valor
            End If

            ' Tamanho Etiqueta
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.TamanhoEtiqueta)
            If Not IsNothing(dadosParametro) Then
                Me.cboTamanho.Text = dadosParametro.valor
            End If

            ' Eh decimal
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.IsDecimal)
            If Not IsNothing(dadosParametro) Then
                If dadosParametro.valor = 1 Then
                    Me.cboEhDecimal.Text = "Sim"
                ElseIf dadosParametro.valor = 0 Then
                    Me.cboEhDecimal.Text = "Não"
                End If
            End If

            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.ExcVenda)
            If Not IsNothing(dadosParametro) Then
                If dadosParametro.valor = 1 Then
                    Me.cboExcVenda.Text = "Sim"
                ElseIf dadosParametro.valor = 0 Then
                    Me.cboExcVenda.Text = "Não"
                End If
            End If

            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.ImprimeDataEtiqueta)
            If Not IsNothing(dadosParametro) Then
                If dadosParametro.valor = 1 Then
                    Me.cboDataEtiqueta.Text = "Sim"
                ElseIf dadosParametro.valor = 0 Then
                    Me.cboDataEtiqueta.Text = "Não"
                End If
            End If

        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message)

        Catch ex As Exception
            MessageBox.Show("Erro na consulta dos parâmetros.")

        End Try

    End Sub

    Private Sub txtJuros_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtJuros.KeyPress
        e.Handled = ncComum.nsFuncoes.cFuncoes.SoNumero(e.KeyChar)

    End Sub

    Private Sub txtTolerancia_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTolerancia.KeyPress
        e.Handled = ncComum.nsFuncoes.cFuncoes.SoNumero(e.KeyChar)

    End Sub

    Private Sub txtMinimoNegativar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMinimoNegativar.KeyPress
        e.Handled = ncComum.nsFuncoes.cFuncoes.SoNumero(e.KeyChar)

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class