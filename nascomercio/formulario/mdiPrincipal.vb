Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports NasLibackup
Imports ncComum.nsConstantes
Imports ncComum.nsExcecao
Imports ncComum.nsLog.cLog
Imports ncDados.nsLoja
Imports ncDados.nsParametro
Imports ncDados.nsUsuario
Imports ncDados.nsUsuarioPerfil
Imports ncRegras.nsLoja
Imports ncRegras.nsParametro
Imports ncRegras.nsUsuario
Imports ncRegras.nsUsuarioPerfil

Public Class mdiPrincipal

    '-- Par�metros globais
    Public gUsuario As New dUsuario
    Public gLoja As New dLoja
    Public formulario As New Form
    Public formularioModal As New Form
    Private tela As Boolean = True

    Public Sub New()

        '-- This call is required by the Windows Form Designer.
        InitializeComponent()

        '-- Add any initialization after the InitializeComponent() call.
        Acesso()
    End Sub

    Private Function VerificarChaveSistema() As Boolean
        Dim dadosParametro As dParametro
        Dim regraParametro As rParametro
        Dim retorno As Boolean

        retorno = False

        ' Chave sistema
        regraParametro = New rParametro()
        dadosParametro = regraParametro.Consultar(cConstantes.Parametros.ChaveSistema)

        ' Verificar se existe chave de acesso/valida��o
        If Not IsNothing(dadosParametro) Then
            If Not String.IsNullOrEmpty(dadosParametro.valor) Then
                If dadosParametro.valor.Trim() <> "" Then
                    retorno = True
                End If
            End If
        End If

        VerificarChaveSistema = retorno
    End Function

    Public Sub Acesso()
        If VerificarChaveSistema() = True Then
            IdentificacaoSistema()
        Else
            ChaveSistema()
        End If
    End Sub

    Public Sub IdentificacaoSistema()
        'fAcesso.MdiParent = Me
        'fAcesso.Show()
        'fAcesso.BringToFront()

        CarregarIdentificacaoSistema()
    End Sub

    Public Sub ChaveSistema()
        'fChaveSistema.MdiParent = Me
        'fChaveSistema.Show()
        'fChaveSistema.BringToFront()

        CarregarChaveValidacao()
    End Sub

    Public Sub Iniciar()
        CarregarUsuario()
    End Sub
    Public Async Function CarregarBackupAutomaticoAsync() As Task
        Await ExecutarBackup()
    End Function
    Private Async Function ExecutarBackup() As Task
        ' TODO: NasLibackup não disponível nesta cópia do projeto — backup automático desativado temporariamente
        'Await Libackup.RotinaDeCriarBackup()
        Await Task.CompletedTask

    End Function

    Private Function CarregarUsuario() As Boolean
        Dim regrasUsuario As rUsuario
        Dim dadosUsuario As dUsuario
        Dim regrasPerfil As rUsuarioPerfil
        Dim dadosPerfil As dUsuarioPerfil
        Dim retorno As ColecaoUsuario
        Dim regrasLoja As rLoja
        Dim valido As Boolean = False
        Dim mensagem As String = String.Empty
        Dim emExecucao As Integer
        Dim regraParametro As New rParametro
        Dim dadosParametro As dParametro

        '1- verificando quantos elementos o array possui , se possuir mais de um ent�o existe duas inst�ncias
        emExecucao = Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length

        '2- verificando o limite superior do array , se for  maior que zero ent�o existe duas inst�ncias
        'emExecucao = Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).GetUpperBound(0) > 0

        dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Instancias)

        If emExecucao > CInt(dadosParametro.valor) Then
            MsgBox("A quantidade de Cópias do sistema executando simultaneamente, atingiu o limite configurado")
            Me.Close()
        End If
        'If emExecucao Then
        '    MsgBox("Existe mais de um programa aberto, por favor feche o outro antes de continuar.")
        '    Me.Close()
        'End If

        Try

            regrasUsuario = New rUsuario
            dadosUsuario = New dUsuario
            Dim cripto As New ncComum.criptografia()

            dadosUsuario.usuario = fAcesso.txtUsuario.Text.Trim()
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Secure)
            If dadosParametro.valor = "0" Then
                dadosUsuario.senha = fAcesso.txtSenha.Text.Trim()
            Else
                dadosUsuario.senha = cripto.Criptografar(fAcesso.txtSenha.Text.Trim())
            End If
            retorno = regrasUsuario.Consultar(dadosUsuario)

            If IsNothing(retorno) Then
                valido = False
                mensagem = "Usuário/Senha inválido(s)."
                GravarLog("", "Tentativa de acesso inválido ao sistema - Usuario [" & dadosUsuario.usuario & "]")
            Else
                If retorno.Count <> 1 Then
                    valido = False
                    mensagem = "Usuário/Senha inválido(s)."
                    GravarLog("", "Tentativa de acesso inválido ao sistema - Usuario [" & dadosUsuario.usuario & "]")
                Else
                    valido = True

                    'Encripta asenhas de Usuários caso ainda não tenham sido encriptadas
                    EncriptarSenhas()
                End If
            End If

            If valido = True Then
                fAcesso.Close()

                gUsuario = retorno(0)

                GravarLog(gUsuario.usuario, "Acesso ao sistema")

                regrasPerfil = New rUsuarioPerfil

                dadosPerfil = regrasPerfil.Consultar(gUsuario.usuarioPerfil_cid)

                regrasLoja = New rLoja()

                gLoja = regrasLoja.Consultar(1)

                Me.lblLoja.Text = gLoja.nomeFantasia

                Me.lblUsuario.Text = gUsuario.nomeCompleto & " [" & dadosPerfil.nome & "]"

                Me.lblTerminal.Text = System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL")

                If System.Configuration.ConfigurationManager.AppSettings("TIPO_TERMINAL") = "CAIXA" Then
                    Select Case gUsuario.usuarioPerfil_codigo
                        Case "c", "a", "g"
                            IniciarCaixa(True)
                        Case Else
                            MessageBox.Show("Tipo de Usuário não encontrado.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Select
                Else
                    Select Case gUsuario.usuarioPerfil_codigo
                        Case "v"
                            IniciarCaixa(False)
                            'IniciarVendedor()
                        Case "c"
                            IniciarCaixa(False)
                        Case "g"
                            IniciarGerente()
                        Case "a"
                            IniciarAdministrador()
                        Case Else
                            MessageBox.Show("Tipo de Usuário não encontrado.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Select
                End If

            Else
                MessageBox.Show(mensagem, "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Information)

                fAcesso.txtUsuario.Text = String.Empty
                fAcesso.txtSenha.Text = String.Empty
                fAcesso.txtUsuario.Focus()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Function
    Private Sub EncriptarSenhas()
        Dim dadosParametro As dParametro
        Dim dUsuario As dUsuario
        Dim regrasUsuario As rUsuario
        Dim dadosUsuario As dUsuario
        Dim regraParametro As New rParametro

        regrasUsuario = New rUsuario
        dadosUsuario = New dUsuario

        Dim cripto As New ncComum.criptografia()

        Try

            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Secure)
            If dadosParametro.valor = "0" Then
                Dim retUsuarios = regrasUsuario.Listar()
                For Each dUsuario In retUsuarios
                    If Not dUsuario.senha Is Nothing Then
                        dUsuario.senha = cripto.Criptografar(dUsuario.senha)
                        regrasUsuario.Alterar(dUsuario)
                    End If
                Next

                dadosParametro.valor = "1"
                regraParametro.Alterar(dadosParametro)

            End If
        Catch ex As Exception
            MessageBox.Show("Ao atualizar o esquema de criptografia ocorreu um erro")
        End Try
    End Sub

    Public Sub IniciarCaixa(ByVal vendadireta As Boolean)
        CarregarCaixa(vendadireta)
    End Sub

    Public Sub IniciarVendedor()
        pnlMenu.Visible = True
        ExibirBotoes()
    End Sub

    Public Sub IniciarGerente()
        pnlMenu.Visible = True
        ExibirBotoes()
    End Sub

    Public Sub IniciarAdministrador()
        pnlMenu.Visible = True
        ExibirBotoes()
    End Sub

    Private Sub ExibirBotoes()
        Dim esquerda As Integer = 0

        If System.Configuration.ConfigurationManager.AppSettings("TIPO_TERMINAL") = "CAIXA" Then
            btoCaixa.Text = "Caixa" & vbCrLf & "[F9]"
        ElseIf System.Configuration.ConfigurationManager.AppSettings("TIPO_TERMINAL") = "VENDAS" Then
            btoCaixa.Text = "Vendas" & vbCrLf & "[F9]"
        Else
            btoCaixa.Text = "Orçamento" & vbCrLf & "[F9]"
        End If

        If System.Configuration.ConfigurationManager.AppSettings("ORDEM_SERVIÇO") = "SIM" Then
            btoOrdemServico.Visible = True
        Else
            btoOrdemServico.Visible = False
        End If

        btoUsuario.Visible = False
        btoContasPagar.Visible = False
        btoFornecedor.Visible = False
        btoCliente.Visible = False
        btoEstado.Visible = False
        btoProduto.Visible = False
        btoFabricante.Visible = False
        btoCaixa.Visible = False
        btoLoja.Visible = False
        btoRelatorio.Visible = False
        btoConfigurar.Visible = False
        btoESProduto.Visible = False

        ' Administrador
        If gUsuario.usuarioPerfil_codigo = "a" Then
            btoContasPagar.Visible = True
            btoLoja.Visible = True
            btoConfigurar.Visible = True
        End If

        ' Gerente
        If gUsuario.usuarioPerfil_codigo = "a" Or
            gUsuario.usuarioPerfil_codigo = "g" Then

            btoUsuario.Visible = True
            btoFornecedor.Visible = True
            btoEstado.Visible = True
            btoProduto.Visible = True
            btoFabricante.Visible = True
        End If

        If gUsuario.usuarioPerfil_codigo = "a" Or
            gUsuario.usuarioPerfil_codigo = "g" Or
            gUsuario.usuarioPerfil_codigo = "c" Then

            btoCliente.Visible = True
            btoProduto.Visible = True
            btoESProduto.Visible = True
            btoRelatorio.Visible = True
        End If

        If gUsuario.usuarioPerfil_codigo = "a" Or
            gUsuario.usuarioPerfil_codigo = "g" Or
            gUsuario.usuarioPerfil_codigo = "c" Or
            gUsuario.usuarioPerfil_codigo = "v" Then

            btoCaixa.Visible = True
        End If

    End Sub

    Public Function RetornaNumeroControle() As Integer
        Dim vendas As New ncRegras.nsVenda.rPreVenda
        Dim vendas2 As New ncRegras.nsVenda.rVenda
        Dim controle As Integer
        Dim controle2 As Integer

        controle = vendas.ConsultarMax()
        controle2 = vendas2.ConsultarMax()

        If controle > controle2 Then
            Return (controle + 1)
        Else
            Return (controle2 + 1)
        End If

    End Function

    Private Sub mdiPrincipal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If tela = True Then
            Select Case e.KeyCode
                Case Keys.F1
                    If btoContasPagar.Visible = True Then
                        CarregarContasPagarFiltro()
                    End If
                Case Keys.F2
                    If btoUsuario.Visible = True Then
                        CarregarUsuarioFiltro()
                    End If
                Case Keys.F3
                    If btoFornecedor.Visible = True Then
                        CarregarFornecedorFiltro()
                    End If
                Case Keys.F4
                    If btoCliente.Visible = True Then
                        CarregarClienteFiltro()
                    End If
                Case Keys.F5
                    If btoEstado.Visible = True Then
                        CarregarGrupoFiltro()
                    End If
                Case Keys.F6
                    If btoProduto.Visible = True Then
                        CarregarProdutoFiltro()
                    End If
                Case Keys.F7
                    If btoFabricante.Visible = True Then
                        CarregarFabricanteFiltro()
                    End If
                Case Keys.F8
                    If btoLoja.Visible = True Then
                        CarregarLojaFiltro()
                    End If
                Case Keys.F9
                    If btoCaixa.Visible = True Then
                        If System.Configuration.ConfigurationManager.AppSettings("TIPO_TERMINAL") = "CAIXA" Then
                            IniciarCaixa(True)
                        Else
                            IniciarCaixa(False)
                        End If
                    End If
                Case Keys.F10
                    If btoRelatorio.Visible = True Then
                        CarregarRelatorio()
                    End If
                Case Keys.F11
                    If btoESProduto.Visible = True Then
                        CarregarProdutoEntradaSaidaFiltro()
                    End If
                Case Keys.F12
                    If btoConfigurar.Visible = True Then
                        CarregarMenuConfiguraoes()
                    End If
                Case Keys.Escape
                    Me.Close()
            End Select
        End If
    End Sub

    Private Sub btoUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoUsuario.Click
        CarregarUsuarioFiltro()
    End Sub

    Private Sub btoFornecedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFornecedor.Click
        CarregarFornecedorFiltro()
    End Sub

    Private Sub btoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCliente.Click
        CarregarClienteFiltro()
    End Sub

    Private Sub btoUsuarioPerfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CarregarUsuarioPerfilFiltro()
    End Sub

    Private Sub btoEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoEstado.Click
        CarregarGrupoFiltro()
    End Sub

    Private Sub btoProduto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoProduto.Click
        CarregarProdutoFiltro()
    End Sub

    Private Sub btoFabricante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CarregarFabricanteFiltro()
    End Sub

    Private Sub btoProdutoTipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CarregarProdutoTipoFiltro()
    End Sub

    Private Sub btoCaracteristicas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CarregarCaracteristicaFiltro()
    End Sub

    Public Sub FecharTela()

        If Not formulario Is Nothing Then
            If formulario.Equals(fCaixa) Then
                pnlMenu.Visible = True
                ExibirBotoes()
            End If
            formulario.Close()
            formulario = Nothing
        End If

        tela = True
    End Sub

    Public Sub FecharTelaLogin()

        pnlMenu.Visible = False
        If Not formulario Is Nothing Then
            formulario.Close()
            formulario = Nothing
        End If

        Acesso()

        tela = True
    End Sub

    Public Sub AbrirTela()
        tela = False

        formulario.MdiParent = Me
        formulario.Show()
        formulario.BringToFront()
    End Sub

    Private Sub AbrirTelaModal()
        tela = False

        formularioModal.MdiParent = Me
        formularioModal.Show()
        formularioModal.BringToFront()
    End Sub

    Private Sub FecharTelaModal()
        If Not formularioModal Is Nothing Then
            formularioModal.Close()
            formularioModal = Nothing
        End If

        tela = True
    End Sub

    Public Sub CarregarFornecedorForm()
        FecharTela()
        formulario = fFornecedorForm
        AbrirTela()
    End Sub

    Public Sub CarregarPixForm()
        FecharTela()
        formulario = fPix
        AbrirTela()
    End Sub

    Public Sub CarregarFornecedorFiltro()
        FecharTela()
        formulario = fFornecedorFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarFornecedorLista()
        FecharTela()
        formulario = fFornecedorLista
        AbrirTela()
    End Sub

    Public Sub CarregarEstadoForm()
        FecharTela()
        formulario = fEstadoForm
        AbrirTela()
    End Sub

    Public Sub CarregarEstadoFiltro()
        FecharTela()
        formulario = fEstadoFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarEstadoLista()
        FecharTela()
        formulario = fEstadoLista
        AbrirTela()
    End Sub

    Public Sub CarregarUsuarioForm()
        FecharTela()
        formulario = fUsuarioForm
        AbrirTela()
    End Sub

    Public Sub CarregarUsuarioFiltro()
        FecharTela()
        formulario = fUsuarioFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarUsuarioLista()
        FecharTela()
        formulario = fUsuarioLista
        AbrirTela()
    End Sub

    Public Sub CarregarClienteForm()
        FecharTela()
        formulario = fClienteForm
        AbrirTela()
    End Sub
    Public Sub CarregarClienteFiltro()
        FecharTela()
        formulario = fClienteFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarClienteLista()
        FecharTela()
        formulario = fClienteLista
        AbrirTela()
    End Sub

    Public Sub CarregarUsuarioPerfilForm()
        FecharTela()
        formulario = fUsuarioPerfilForm
        AbrirTela()
    End Sub

    Public Sub CarregarUsuarioPerfilFiltro()
        FecharTela()
        formulario = fUsuarioPerfilFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarUsuarioPerfilLista()
        FecharTela()
        formulario = fUsuarioPerfilLista
        AbrirTela()
    End Sub

    Public Sub CarregarProdutoForm()
        FecharTela()
        formulario = fProdutoForm
        AbrirTela()
    End Sub

    Public Sub CarregarProdutoFiltro()
        FecharTela()
        formulario = fProdutoFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarProdutoLista()
        FecharTela()
        formulario = fProdutoLista
        AbrirTela()
    End Sub

    Public Sub CarregarClienteEnderecoForm()
        FecharTela()
        formulario = fClienteEnderecoForm
        AbrirTela()
    End Sub

    Public Sub CarregarClienteProfissionalForm()
        FecharTela()
        formulario = fClienteProfissionalForm
        AbrirTela()
    End Sub

    Public Sub CarregarClienteFinanceiroForm()
        FecharTela()
        formulario = fClienteFinanceiroForm
        AbrirTela()
    End Sub

    Public Sub CarregarClienteCrediarioForm()
        FecharTela()
        formulario = fClienteCrediarioForm
        AbrirTela()
    End Sub

    Public Sub CarregarFabricanteForm()
        FecharTela()
        formulario = fFabricanteForm
        AbrirTela()
    End Sub

    Public Sub CarregarFabricanteFiltro()
        FecharTela()
        formulario = fFabricanteFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarFabricanteLista()
        FecharTela()
        formulario = fFabricanteLista
        AbrirTela()
    End Sub

    Public Sub CarregarCorForm()
        FecharTela()
        formulario = fCorForm
        AbrirTela()
    End Sub

    Public Sub CarregarCorFiltro()
        FecharTela()
        formulario = fCorFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarCorLista()
        FecharTela()
        formulario = fCorLista
        AbrirTela()
    End Sub

    Public Sub CarregarCategoriaForm()
        FecharTela()
        formulario = fCategoriaForm
        AbrirTela()
    End Sub

    Public Sub CarregarCategoriaFiltro()
        FecharTela()
        formulario = fCategoriaFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarCategoriaLista()
        FecharTela()
        formulario = fCategoriaLista
        AbrirTela()
    End Sub

    Public Sub CarregarGrupoForm()
        FecharTela()
        formulario = fGrupoForm
        AbrirTela()
    End Sub

    Public Sub CarregarGrupoFiltro()
        FecharTela()
        formulario = fGrupoFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarGrupoLista()
        FecharTela()
        formulario = fGrupoLista
        AbrirTela()
    End Sub

    Public Sub CarregarProdutoTipoForm()
        FecharTela()
        formulario = fProdutoTipoForm
        AbrirTela()
    End Sub

    Public Sub CarregarProdutoTipoFiltro()
        FecharTela()
        formulario = fProdutoTipoFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarProdutoTipoLista()
        FecharTela()
        formulario = fProdutoTipoLista
        AbrirTela()
    End Sub

    Public Sub CarregarCaracteristicaForm()
        FecharTela()
        formulario = fCaracteristicaForm
        AbrirTela()
    End Sub

    Public Sub CarregarCaracteristicaFiltro()
        FecharTela()
        formulario = fCaracteristicaFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarCaracteristicaLista()
        FecharTela()
        formulario = fCaracteristicaLista
        AbrirTela()
    End Sub

    Public Sub CarregarBackup()
        FecharTela()
        formulario = fBackup
        AbrirTela()
    End Sub

    Public Sub CarregarCondicaoForm()
        FecharTela()
        formulario = fCondicaoForm
        AbrirTela()
    End Sub

    Public Sub CarregarCondicaoFiltro()
        FecharTela()
        formulario = fCondicaoFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarCondicaoLista()
        FecharTela()
        formulario = fCondicaoLista
        AbrirTela()
    End Sub

    Public Sub CarregarLojaForm()
        FecharTela()
        formulario = fLojaForm
        AbrirTela()
    End Sub

    Public Sub CarregarLojaFiltro()
        FecharTela()
        formulario = fLojaFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarLojaLista()
        FecharTela()
        formulario = fFechamento
        AbrirTela()
    End Sub

    Public Sub CarregarCaracteristicaItemForm()
        FecharTela()
        formulario = fCaracteristicaItemForm
        AbrirTela()
    End Sub

    Public Sub CarregarProdutoTipoCaracteristicaForm()
        FecharTela()
        formulario = fProdutoTipoCaracteristicaForm
        AbrirTela()
    End Sub

    Public Sub CarregarRelatorio()
        FecharTela()
        formulario = fRelatorio
        AbrirTela()
    End Sub

    Public Sub CarregarMenuConfiguraoes()
        FecharTela()
        formulario = fConfiguracaoes
        AbrirTela()
    End Sub

    Public Sub CarregarProdutoEntradaSaidaFiltro()
        FecharTela()
        formulario = fProdutoEntradaSaidaFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarProdutoEntradaSaidaLista()
        FecharTela()
        formulario = fProdutoEntradaSaidaLista
        AbrirTela()
    End Sub

    Public Sub CarregarProdutoBalancoFiltro()
        FecharTela()
        formulario = fProdutoBalancoFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarProdutoBalancoForm()
        FecharTela()
        formulario = fProdutoBalancoForm
        AbrirTela()
    End Sub

    Public Sub CarregarCaixa(ByVal vendadireta As Boolean)
        pnlMenu.Visible = False

        FecharTela()
        formulario = fCaixa
        formulario.Tag = vendadireta
        AbrirTela()
    End Sub

    Public Sub ImportarArquivos()
        FecharTela()
        formulario = fImportarArquivos
        AbrirTela()
    End Sub

    Public Sub CarregarParametros()
        FecharTela()
        formulario = fParametros
        AbrirTela()
    End Sub

    Public Sub CarregarFechamento()
        FecharTela()
        formulario = fRelatorioFechamento
        AbrirTela()
    End Sub

    Public Sub CarregarEstoque()
        FecharTela()
        formulario = fRelatorioEstoque
        AbrirTela()
    End Sub

    Public Sub CarregarClientes()
        FecharTela()
        formulario = fRelatorioClientes
        AbrirTela()
    End Sub

    Public Sub CarregarClientesNegativar()
        FecharTela()
        formulario = fClienteNegativar
        AbrirTela()
    End Sub

    Public Sub CarregarVendas(ByVal cliente As String)
        FecharTela()
        formulario = fRelatorioVendas
        CType(formulario, fRelatorioVendas).txtCliente.Text = cliente
        AbrirTela()
    End Sub

    Public Sub CarregarVendasSintetico(ByVal cliente As String)
        FecharTela()
        formulario = fRelatorioVendasSintetico
        CType(formulario, fRelatorioVendasSintetico).txtCliente.Text = cliente
        AbrirTela()
    End Sub

    Public Sub CarregarVendasVendedor(ByVal vendedor As String)
        FecharTela()
        formulario = fRelatorioVendasVendedor
        CType(formulario, fRelatorioVendasVendedor).txtVendedor.Text = vendedor
        AbrirTela()
    End Sub

    Public Sub CarregarVendasPendentes()
        FecharTela()
        formulario = fRelatorioVendasPendentes
        AbrirTela()
    End Sub

    Public Sub CarregarCheques(ByVal cliente As String)
        FecharTela()
        formulario = fRelatorioCheques
        CType(formulario, fRelatorioCheques).txtCliente.Text = cliente
        AbrirTela()
    End Sub

    Public Sub CarregarAuditoria()
        FecharTela()
        formulario = fRelatorioAuditoria
        AbrirTela()
    End Sub
    Public Sub CarregarGrupoProduto()
        FecharTela()
        formulario = fRelatorioGrupoProduto
        AbrirTela()
    End Sub
    Public Sub CarregarTransferencia()
        FecharTela()
        formulario = fRelatorioTransferencia
        AbrirTela()
    End Sub
    Public Sub CarregarVendaSAT()
        FecharTela()
        formulario = fRelatorioFechamentoSAT
        AbrirTela()
    End Sub
    Public Sub CarregarRelatorioGrade()
        FecharTela()
        formulario = fRelatorioGrade
        AbrirTela()
    End Sub
    Public Sub CarregarRelatorioBalanco()
        FecharTela()
        formulario = fRelatorioBalanco
        AbrirTela()
    End Sub

    Public Sub CarregarServicoFiltro()
        FecharTela()
        formulario = fServicoFiltro
        AbrirTela()
    End Sub
    Public Sub CarregarServicoForm()
        FecharTela()
        formulario = fServicoForm
        AbrirTela()
    End Sub
    Public Sub CarregarServicoLista()
        FecharTela()
        formulario = fServicoLista
        AbrirTela()
    End Sub
    Public Sub CarregarOrdemServico()
        FecharTela()
        formulario = fOrdemServico
        AbrirTela()
    End Sub
    Public Sub CarregarClienteVeiculoForm()
        FecharTela()
        formulario = fClienteVeiculoForm
        AbrirTela()
    End Sub
    Public Sub CarregarVendasFornecedores()
        FecharTela()
        formulario = fRelatorioVendasFornecedor
        AbrirTela()
    End Sub

    Public Sub Crediario()
        FecharTela()
        formulario = fRelatorioCrediario
        AbrirTela()
    End Sub
    Public Sub CarregarRelCrediPix()
        FecharTela()
        formulario = fRelatorioCrediarioPix
        AbrirTela()
    End Sub
    Public Sub CarregarRelCobrancaCrediarioPix()
        FecharTela()
        formulario = fRelatorioCobrancaAutomatica
        AbrirTela()
    End Sub
    Public Sub CarregarRelPix()
        FecharTela()
        formulario = fRelatorioPix
        AbrirTela()
    End Sub
    Public Sub CarregarProdutoEntradaSaidaTransferencia()
        FecharTela()
        formulario = fProdutoEntradaSaidaTransferencia
        AbrirTela()
    End Sub

    Public Sub CarregarProdutoEntradaSaidaEstoque()
        FecharTela()
        formulario = fProdutoEntradaSaidaEstoque
        AbrirTela()
    End Sub

    Public Sub CarregarCamera()
        FecharTela()
        formulario = fCamera
        AbrirTela()
    End Sub

    Public Sub CarregarNotaFiscalFornecedorLista(ByVal codigoProduto As String)
        FecharTelaModal()
        formularioModal = fNotaFiscalFornecedorLista
        CType(formularioModal, fNotaFiscalFornecedorLista).txtCodigo.Text = codigoProduto
        AbrirTelaModal()
    End Sub

    Public Sub CarregarNotaFiscalFornecedorForm()
        FecharTelaModal()
        formularioModal = fNotaFiscalFornecedorForm
        AbrirTelaModal()
    End Sub

    Public Sub CarregarContasPagarLista()
        FecharTela()
        formulario = fContasPagarLista
        AbrirTela()
    End Sub

    Public Sub CarregarContasPagarForm()
        FecharTela()
        formulario = fContasPagarForm
        AbrirTela()
    End Sub

    Public Sub CarregarContasPagarFiltro()
        FecharTela()
        formulario = fContasPagarFiltro
        AbrirTela()
    End Sub

    Public Sub CarregarTelaSPED()
        FecharTela()
        formulario = fSPEDForm
        AbrirTela()
    End Sub

    Public Sub CarregarTelaNFe()
        FecharTela()
        formulario = fNFeForm
        AbrirTela()
    End Sub

    Public Sub ConsultaVendas()
        FecharTela()
        formulario = fCaixaConsulta
        AbrirTela()
    End Sub

    Public Sub CarregarChaveValidacao()
        FecharTela()
        formulario = fChaveSistema
        AbrirTela()
    End Sub

    Public Sub CarregarPix()
        FecharTela()
        formulario = fConfigPix
        AbrirTela()
    End Sub
    Public Sub CarregarIdentificacaoSistema()
        FecharTela()
        formulario = fAcesso
        AbrirTela()
    End Sub

    Public Sub CarregarRelVendasPorVendedor()
        FecharTela()
        formulario = fRelatorioPorVendedor
        AbrirTela()
    End Sub
    Public Sub CarregarRelVendasPorLoja()
        FecharTela()
        formulario = fRelatorioPorLoja
        AbrirTela()
    End Sub

    Public Sub CarregarRelVendasNFe()
        FecharTela()
        formulario = fRelatorioVendasNfe
        AbrirTela()
    End Sub
    Public Sub CarregarRelVendasABC()
        FecharTela()
        formulario = fRelatorioVendasABC
        AbrirTela()
    End Sub

    Private Sub btoCaixa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCaixa.Click
        If System.Configuration.ConfigurationManager.AppSettings("TIPO_TERMINAL") = "CAIXA" Then
            CarregarCaixa(True)
        Else
            CarregarCaixa(False)
        End If
    End Sub

    Private Sub btoLoja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoLoja.Click
        CarregarLojaFiltro()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fProdutoItemPesquisa.Show()
    End Sub

    Private Sub btoRelatorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoRelatorio.Click
        CarregarRelatorio()
    End Sub

    Private Sub btoESProduto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoESProduto.Click
        CarregarProdutoEntradaSaidaFiltro()
    End Sub

    Private Sub btoConfigurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoConfigurar.Click
        CarregarMenuConfiguraoes()
    End Sub

    Private Sub mdiPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.BackgroundImage = System.Drawing.Bitmap.FromFile("fundo.jpg")
        Catch ex As Exception
            MessageBox.Show("Imagem de fundo não encontrada: 'fundo.jpg'.")
        End Try
    End Sub

    Private Sub btoSobre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSobre.Click
        FecharTela()
        formulario = fSobre
        AbrirTela()
    End Sub

    Private Sub btoContasPagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoContasPagar.Click
        CarregarContasPagarFiltro()
    End Sub

    Private Sub btoServico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFabricante.Click
        CarregarFabricanteFiltro()
    End Sub

    Private Sub btoOrdemServico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoOrdemServico.Click
        CarregarOrdemServico()
    End Sub
End Class
