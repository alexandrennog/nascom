Imports ncComum.nsExcecao
Imports ncRegras.nsParametro
Imports ncDados.nsParametro
Imports ncComum.nsConstantes
Imports ncComum.nsFuncoes.cFuncoes

Public Class fChaveSistema

    Private codInst As String
    Private dataExp As DateTime?
    Private chvVal As String
    Private msgVal As String
    Private primAcesso As Boolean
    Private primMsg As Boolean

    Private Sub GerarCodigoInstalacao()

        'cria um objeto da classe Random
        Dim rnd As New Random()

        ' gera o número aleatório na faixa
        ' 0 até MaxValue (2.147.483.647)
        Dim numero As Integer = rnd.Next()

        codInst = (numero.ToString() & "000000000").Substring(0, 9)

        Me.txtCodigoInstalacao.Text = codInst

    End Sub

    Private Sub GerarPrimeiraData()

        dataExp = Date.Today.AddDays(90)

        Me.txtDataExpiracao.Text = ConverterDATETIMEDataBarras(dataExp)

    End Sub

    Private Sub GerarPrimeiraChave()

        Dim cripto As New ncComum.criptografia()
        chvVal = cripto.Criptografar(codInst & "#" & ConverterDATETIMEDataUniversal(dataExp))

        Me.txtChaveValidacao.Text = chvVal

        cripto = Nothing

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub GerarParametros()

        GerarCodigoInstalacao()
        GerarPrimeiraData()
        GerarPrimeiraChave()
        primMsg = True
        primAcesso = True

    End Sub

    Private Sub Gravar()

        Dim regraParametro As New rParametro
        Dim dadosParametro As dParametro

        Try
            ' Verifica parâmetro Código de Instalação
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.CodigoInstalacao)
            If IsNothing(dadosParametro) Then
                dadosParametro = New dParametro()
                dadosParametro.cid = cConstantes.Parametros.CodigoInstalacao
                dadosParametro.descricao = "Código de Instalação"
                dadosParametro.valor = txtCodigoInstalacao.Text
                regraParametro.Incluir(dadosParametro)
            Else
                dadosParametro.cid = cConstantes.Parametros.CodigoInstalacao
                dadosParametro.descricao = "Código de Instalação"
                dadosParametro.valor = txtCodigoInstalacao.Text
                regraParametro.Alterar(dadosParametro)
            End If

            ' Verifica parâmetro Data de Expiração
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.DataExpiracao)
            If IsNothing(dadosParametro) Then
                dadosParametro = New dParametro()
                dadosParametro.cid = cConstantes.Parametros.DataExpiracao
                dadosParametro.descricao = "Data de Expiração"
                dadosParametro.valor = FormatarDataUniversal(txtDataExpiracao.Text)
                regraParametro.Incluir(dadosParametro)
            Else
                dadosParametro.cid = cConstantes.Parametros.DataExpiracao
                dadosParametro.descricao = "Data de Expiração"
                dadosParametro.valor = FormatarDataUniversal(txtDataExpiracao.Text)
                regraParametro.Alterar(dadosParametro)
            End If

            ' Verifica parâmetro Chave de Validação
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.ChaveSistema)
            If IsNothing(dadosParametro) Then
                dadosParametro = New dParametro()
                dadosParametro.cid = cConstantes.Parametros.ChaveSistema
                dadosParametro.descricao = "Chave de Validação"
                dadosParametro.valor = txtChaveValidacao.Text
                regraParametro.Incluir(dadosParametro)
            Else
                dadosParametro.cid = cConstantes.Parametros.ChaveSistema
                dadosParametro.descricao = "Chave de Validação"
                dadosParametro.valor = txtChaveValidacao.Text
                regraParametro.Alterar(dadosParametro)
            End If

            If primMsg = True Then
                lblMsgValidacao.Text = "Bem Vindo !" & vbCrLf & "Uma Chave de Validação foi gerada automaticamente e expira em 90 dias."
            Else
                lblMsgValidacao.Text = "Chave de Validação atualizada com sucesso!"
            End If
        Catch ex As Exception
            lblMsgValidacao.Text = "Não foi possível atualizar a Chave de Validação!"
        Finally
            regraParametro = Nothing
            dadosParametro = Nothing
        End Try

    End Sub

    Private Sub CarregarParametros()

        Dim regraParametro As New rParametro
        Dim dadosParametro As dParametro

        ' Verifica parâmetro Código de Instalação
        dadosParametro = regraParametro.Consultar(cConstantes.Parametros.CodigoInstalacao)
        If Not IsNothing(dadosParametro) Then
            codInst = dadosParametro.valor
            txtCodigoInstalacao.Text = codInst
        End If

        ' Verifica parâmetro Data de Expiração
        dadosParametro = regraParametro.Consultar(cConstantes.Parametros.DataExpiracao)
        If Not IsNothing(dadosParametro) Then
            dataExp = ConverterDataUniversalDATETIME(dadosParametro.valor)

            If (Not IsNothing(dataExp)) Then
                txtDataExpiracao.Text = ConverterDATETIMEDataBarras(dataExp)
            End If
        End If

        ' Verifica parâmetro Chave de Validação
        dadosParametro = regraParametro.Consultar(cConstantes.Parametros.ChaveSistema)
        If Not IsNothing(dadosParametro) Then
            If Not IsNothing(dadosParametro.valor) Then
                If dadosParametro.valor.Trim() <> "" Then
                    chvVal = dadosParametro.valor
                    txtChaveValidacao.Text = chvVal
                End If
            End If
        End If

    End Sub

    Private Function ValidarChave() As Boolean
        Dim retorno As Boolean = False
        Dim chvCripto As String
        Dim chvDesc As String
        Dim param() As String

        Try
            '-- Obter chave
            chvCripto = txtChaveValidacao.Text

            '-- Preenchimento
            If chvCripto.Trim() = "" Then
                MessageBox.Show("É necessário informar a Chave de Validação!", "Chave do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                retorno = False
            Else
                '-- Conversão
                Dim cripto As New ncComum.criptografia()
                chvDesc = cripto.Descriptografar(chvCripto)
                cripto = Nothing

                If String.IsNullOrEmpty(chvDesc) Then
                    MessageBox.Show("Chave de Validação inválida!", "Chave do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    retorno = False
                Else
                    '-- Separar #; Quantidade partes
                    param = chvDesc.Split("#")

                    If (param.Length <> 2) Then
                        MessageBox.Show("Chave de Validação inválida!", "Chave do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        retorno = False
                    Else
                        '-- Parte 1 numérica = Código de instalação
                        If (Not IsNumeric(param(0))) Then
                            MessageBox.Show("Chave de Validação inválida!", "Chave do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            retorno = False
                        Else
                            '-- Parte 2 data válida = Data de expiração
                            If (Not IsDate(ConverterDataUniversalDATETIME(param(1)))) Then
                                MessageBox.Show("Chave de Validação inválida!", "Chave do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                retorno = False
                            Else
                                '-- Código de Instalação da chave deve ser igual Cod Inst do sistema
                                If (param(0) <> codInst) Then
                                    MessageBox.Show("Chave de Validação inválida!", "Chave do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    retorno = False
                                Else
                                    dataExp = ConverterDATETIMEDataBarras(param(1))
                                    txtDataExpiracao.Text = ConverterDATETIMEDataBarras(dataExp)

                                    retorno = True
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Chave de Validação inválida!", "Chave do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            retorno = False
        End Try

        ValidarChave = retorno
    End Function

    Private Sub SalvarDadosChave()
        primMsg = False
        lblMsgValidacao.Text = ""
        If ValidarChave() = True Then
            If MessageBox.Show("Confirma Atualização da Chave do Sistema?", "Chave do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Gravar()
            End If
        End If
    End Sub

    Private Sub fChaveSistema_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        primMsg = False
        primAcesso = False
        lblMsgValidacao.Text = ""

        ' Carregar parâmetros de validação do sistema
        CarregarParametros()

        ' Se não tem Chave de Validação, gerar parâmetros de validação do sistema
        If IsNothing(chvVal) OrElse chvVal.Trim() = "" Then
            GerarParametros()
            Gravar()
        End If

    End Sub

    Private Sub btoSalvar_Click(sender As Object, e As EventArgs) Handles btoSalvar.Click
        SalvarDadosChave()
    End Sub

    Private Sub fChaveSistema_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
                If primAcesso = True Then
                    mdiPrincipal.CarregarIdentificacaoSistema()
                End If
            Case Keys.Enter
                SalvarDadosChave()
        End Select
    End Sub

    Private Sub btoSair_Click(sender As Object, e As EventArgs) Handles btoSair.Click
        mdiPrincipal.FecharTela()
        If primAcesso = True Then
            mdiPrincipal.CarregarIdentificacaoSistema()
        End If
    End Sub
End Class
