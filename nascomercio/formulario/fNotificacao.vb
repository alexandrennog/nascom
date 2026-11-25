Imports System.Drawing.Drawing2D

' =============================================================================
' Notificacoes no canto da tela (estilo "toast")
' =============================================================================
' Avisos discretos no canto inferior direito do sistema, que NAO roubam o foco
' (o caixa continua digitando) e somem sozinhos. Varias notificacoes ao mesmo
' tempo ficam empilhadas. Passar o mouse em cima pausa o tempo; clicar fecha.
'
' Uso em qualquer tela:
'     Notificacao.Sucesso("Venda gravada", "Cupom 1234 emitido.")
'     Notificacao.Aviso("Estoque baixo", "Restam 2 pares do produto 4829.")
'     Notificacao.Erro("Impressora", "Nao foi possivel imprimir o cupom.")
'     Notificacao.Informacao("Atualizacao", "Nova versao disponivel.", 10)
'
' Tarefa demorada (fica aberta com animacao ate voce atualizar/fechar):
'     Dim aviso As fNotificacao = Notificacao.EmAndamento("Backup", "Fazendo o backup...")
'     ...
'     aviso.Atualizar("Backup concluido", "Enviado para a nuvem.", TipoNotificacao.Sucesso, 6)
'     ' ou aviso.Fechar()
'
' Pode ser chamada de qualquer thread (troca para a thread da tela sozinha).
' =============================================================================

Public Enum TipoNotificacao
    Informacao
    Sucesso
    Aviso
    Erro
End Enum

Public NotInheritable Class Notificacao

    Private Sub New()
    End Sub

    ' Tempo padrao na tela (segundos)
    Public Const SegundosPadrao As Integer = 6

    Public Shared Function Informacao(ByVal titulo As String, ByVal mensagem As String, Optional ByVal segundos As Integer = SegundosPadrao) As fNotificacao
        Return Mostrar(titulo, mensagem, TipoNotificacao.Informacao, segundos)
    End Function

    Public Shared Function Sucesso(ByVal titulo As String, ByVal mensagem As String, Optional ByVal segundos As Integer = SegundosPadrao) As fNotificacao
        Return Mostrar(titulo, mensagem, TipoNotificacao.Sucesso, segundos)
    End Function

    Public Shared Function Aviso(ByVal titulo As String, ByVal mensagem As String, Optional ByVal segundos As Integer = 10) As fNotificacao
        Return Mostrar(titulo, mensagem, TipoNotificacao.Aviso, segundos)
    End Function

    Public Shared Function Erro(ByVal titulo As String, ByVal mensagem As String, Optional ByVal segundos As Integer = 12) As fNotificacao
        Return Mostrar(titulo, mensagem, TipoNotificacao.Erro, segundos)
    End Function

    ' Fica na tela (com animacao) ate chamar Atualizar(...) ou Fechar()
    Public Shared Function EmAndamento(ByVal titulo As String, ByVal mensagem As String) As fNotificacao
        Return Mostrar(titulo, mensagem, TipoNotificacao.Informacao, 0)
    End Function

    ' segundos = 0: nao fecha sozinha (tarefa em andamento)
    Public Shared Function Mostrar(ByVal titulo As String, ByVal mensagem As String, ByVal tipo As TipoNotificacao, ByVal segundos As Integer) As fNotificacao
        Try
            Dim tela As Form = fNotificacao.TelaPrincipal()
            If tela IsNot Nothing AndAlso Not tela.IsDisposed AndAlso tela.IsHandleCreated AndAlso tela.InvokeRequired Then
                Return CType(tela.Invoke(New Func(Of fNotificacao)(Function() Mostrar(titulo, mensagem, tipo, segundos))), fNotificacao)
            End If

            Dim aviso As New fNotificacao(titulo, mensagem, tipo, segundos)
            aviso.Exibir()
            Return aviso
        Catch
            ' Notificacao nunca pode derrubar o sistema
            Return Nothing
        End Try
    End Function

    ' Fecha todas (ex.: ao sair do sistema)
    Public Shared Sub FecharTodas()
        fNotificacao.FecharTodas()
    End Sub

End Class

' Janela de uma notificacao. Montada em codigo (sem designer).
Public Class fNotificacao
    Inherits Form

    Private Const LARGURA As Integer = 370
    Private Const MARGEM As Integer = 12
    Private Const ESPACO As Integer = 8

    ' Notificacoes abertas, da mais antiga para a mais nova (a mais nova fica embaixo)
    Private Shared ReadOnly abertas As New List(Of fNotificacao)

    Private tipo As TipoNotificacao
    Private segundosTotal As Integer
    Private restanteMs As Integer
    Private fechando As Boolean = False
    Private mouseEmCima As Boolean = False

    Private ReadOnly faixa As New Panel()
    Private ReadOnly icone As New PictureBox()
    Private ReadOnly lblTitulo As New Label()
    Private ReadOnly lblMensagem As New Label()
    Private ReadOnly lblFechar As New Label()
    Private ReadOnly barraTempo As New Panel()
    Private ReadOnly animacao As New ProgressBar()
    Private ReadOnly relogio As New Timer()
    Private ReadOnly efeito As New Timer()

    Friend Sub New(ByVal titulo As String, ByVal mensagem As String, ByVal tipo As TipoNotificacao, ByVal segundos As Integer)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.ShowInTaskbar = False
        Me.StartPosition = FormStartPosition.Manual
        Me.BackColor = Color.White
        Me.Width = LARGURA
        Me.Opacity = 0
        Me.Font = New Font("Segoe UI", 9.0!)

        faixa.Dock = DockStyle.Left
        faixa.Width = 6

        icone.Size = New Size(28, 28)
        icone.Location = New Point(18, 12)

        lblTitulo.AutoSize = False
        lblTitulo.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)
        lblTitulo.ForeColor = Color.FromArgb(40, 40, 40)
        lblTitulo.Location = New Point(56, 10)
        lblTitulo.Size = New Size(LARGURA - 56 - 30, 20)

        lblMensagem.AutoSize = False
        lblMensagem.ForeColor = Color.FromArgb(70, 70, 70)
        lblMensagem.Location = New Point(56, 32)

        lblFechar.Text = "×"
        lblFechar.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)
        lblFechar.ForeColor = Color.Gray
        lblFechar.AutoSize = False
        lblFechar.Size = New Size(22, 22)
        lblFechar.TextAlign = ContentAlignment.MiddleCenter
        lblFechar.Location = New Point(LARGURA - 26, 4)
        lblFechar.Cursor = Cursors.Hand

        barraTempo.Height = 3

        animacao.Style = ProgressBarStyle.Marquee
        animacao.MarqueeAnimationSpeed = 30
        animacao.Height = 6

        Me.Controls.Add(lblFechar)
        Me.Controls.Add(lblTitulo)
        Me.Controls.Add(lblMensagem)
        Me.Controls.Add(icone)
        Me.Controls.Add(animacao)
        Me.Controls.Add(barraTempo)
        Me.Controls.Add(faixa)

        ' Clicar em qualquer parte fecha; mouse em cima pausa o tempo
        For Each c As Control In New Control() {Me, faixa, icone, lblTitulo, lblMensagem, lblFechar, barraTempo}
            AddHandler c.Click, AddressOf AoClicar
            AddHandler c.MouseEnter, AddressOf AoEntrarMouse
            AddHandler c.MouseLeave, AddressOf AoSairMouse
        Next

        relogio.Interval = 100
        AddHandler relogio.Tick, AddressOf AoContarTempo
        efeito.Interval = 15
        AddHandler efeito.Tick, AddressOf AoAnimar

        AplicarConteudo(titulo, mensagem, tipo, segundos)
    End Sub

    ' Nao rouba o foco da tela em que o usuario esta digitando
    Protected Overrides ReadOnly Property ShowWithoutActivation As Boolean
        Get
            Return True
        End Get
    End Property

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Const WS_EX_TOOLWINDOW As Integer = &H80
            Const WS_EX_NOACTIVATE As Integer = &H8000000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_TOOLWINDOW Or WS_EX_NOACTIVATE
            Return cp
        End Get
    End Property

    ' Borda cinza fina
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Using caneta As New Pen(Color.FromArgb(200, 200, 200))
            e.Graphics.DrawRectangle(caneta, 0, 0, Me.Width - 1, Me.Height - 1)
        End Using
    End Sub

    Friend Sub Exibir()
        abertas.Add(Me)
        ReposicionarTodas()

        ' "Dona" = tela principal: a notificacao fica por cima do sistema, mas nao
        ' por cima de outros programas, e some junto se o sistema for minimizado.
        Dim dona As Form = TelaPrincipal()

        If dona IsNot Nothing AndAlso Not dona.IsDisposed AndAlso dona.Visible Then
            Me.Show(dona)
        Else
            Me.TopMost = True
            Me.Show()
        End If

        efeito.Start()
    End Sub

    ' Troca o texto/tipo de uma notificacao ja aberta (ex.: "em andamento" -> "concluido")
    Public Sub Atualizar(ByVal titulo As String, ByVal mensagem As String, ByVal tipo As TipoNotificacao, Optional ByVal segundos As Integer = Notificacao.SegundosPadrao)
        If Me.IsDisposed Then
            Exit Sub
        End If
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Sub() Atualizar(titulo, mensagem, tipo, segundos)))
            Exit Sub
        End If

        fechando = False
        Me.Opacity = 1
        AplicarConteudo(titulo, mensagem, tipo, segundos)
        ReposicionarTodas()
    End Sub

    Public Sub Fechar()
        If Me.IsDisposed Then
            Exit Sub
        End If
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf Fechar))
            Exit Sub
        End If
        IniciarFechamento()
    End Sub

    ' A tela principal ja aberta. Nao usa "mdiPrincipal" direto porque, chamado
    ' de outra thread, o VB criaria uma tela principal nova so para aquela thread.
    Friend Shared Function TelaPrincipal() As Form
        Try
            For Each f As Form In Application.OpenForms
                If TypeOf f Is mdiPrincipal Then
                    Return f
                End If
            Next
        Catch
        End Try
        Return Nothing
    End Function

    Friend Shared Sub FecharTodas()
        For Each aviso As fNotificacao In abertas.ToArray()
            Try
                aviso.Close()
            Catch
            End Try
        Next
        abertas.Clear()
    End Sub

    Private Sub AplicarConteudo(ByVal titulo As String, ByVal mensagem As String, ByVal novoTipo As TipoNotificacao, ByVal segundos As Integer)
        tipo = novoTipo
        segundosTotal = Math.Max(0, segundos)
        restanteMs = segundosTotal * 1000

        Dim cor As Color = CorDoTipo(tipo)
        faixa.BackColor = cor
        barraTempo.BackColor = cor
        icone.Image = DesenharIcone(tipo, cor)

        lblTitulo.Text = If(titulo, "")
        lblMensagem.Text = If(mensagem, "")

        ' Altura conforme o tamanho do texto
        Dim larguraTexto As Integer = LARGURA - 56 - 16
        Dim alturaTexto As Integer = TextRenderer.MeasureText(lblMensagem.Text, lblMensagem.Font,
                                                             New Size(larguraTexto, Integer.MaxValue),
                                                             TextFormatFlags.WordBreak).Height
        lblMensagem.Size = New Size(larguraTexto, Math.Max(18, alturaTexto))

        Dim emAndamento As Boolean = (segundosTotal = 0)
        Dim fim As Integer = lblMensagem.Bottom + 10

        animacao.Visible = emAndamento
        If emAndamento Then
            animacao.SetBounds(56, fim, larguraTexto, 6)
            fim = animacao.Bottom + 10
        End If

        Me.Height = Math.Max(60, fim + 3)
        barraTempo.SetBounds(6, Me.Height - 4, LARGURA - 7, 3)
        barraTempo.Visible = Not emAndamento

        If emAndamento Then
            relogio.Stop()
        Else
            relogio.Start()
        End If
        Me.Invalidate()
    End Sub

    ' Canto inferior direito da area do sistema; a mais nova embaixo
    Private Shared Sub ReposicionarTodas()
        Dim area As Rectangle = Screen.PrimaryScreen.WorkingArea
        Try
            Dim tela As Form = TelaPrincipal()
            If tela IsNot Nothing AndAlso Not tela.IsDisposed AndAlso tela.Visible AndAlso tela.WindowState <> FormWindowState.Minimized Then
                area = tela.RectangleToScreen(tela.ClientRectangle)
            End If
        Catch
        End Try

        Dim y As Integer = area.Bottom - MARGEM
        For i As Integer = abertas.Count - 1 To 0 Step -1
            Dim aviso As fNotificacao = abertas(i)
            If aviso.IsDisposed Then
                Continue For
            End If
            y -= aviso.Height
            aviso.Location = New Point(area.Right - MARGEM - aviso.Width, y)
            y -= ESPACO
        Next
    End Sub

    Private Sub IniciarFechamento()
        If fechando Then
            Exit Sub
        End If
        fechando = True
        relogio.Stop()
        efeito.Start()
    End Sub

    Private Sub AoAnimar(ByVal sender As Object, ByVal e As EventArgs)
        If fechando Then
            Me.Opacity = Math.Max(0, Me.Opacity - 0.1)
            If Me.Opacity <= 0 Then
                efeito.Stop()
                Me.Close()
            End If
        Else
            Me.Opacity = Math.Min(1, Me.Opacity + 0.1)
            If Me.Opacity >= 1 Then
                efeito.Stop()
            End If
        End If
    End Sub

    Private Sub AoContarTempo(ByVal sender As Object, ByVal e As EventArgs)
        If segundosTotal = 0 OrElse mouseEmCima Then
            Exit Sub
        End If
        restanteMs -= relogio.Interval
        If restanteMs <= 0 Then
            IniciarFechamento()
            Exit Sub
        End If
        barraTempo.Width = CInt((LARGURA - 7) * restanteMs / (segundosTotal * 1000.0))
    End Sub

    Private Sub AoClicar(ByVal sender As Object, ByVal e As EventArgs)
        IniciarFechamento()
    End Sub

    Private Sub AoEntrarMouse(ByVal sender As Object, ByVal e As EventArgs)
        mouseEmCima = True
        lblFechar.ForeColor = Color.Black
    End Sub

    Private Sub AoSairMouse(ByVal sender As Object, ByVal e As EventArgs)
        mouseEmCima = False
        lblFechar.ForeColor = Color.Gray
    End Sub

    Protected Overrides Sub OnFormClosed(ByVal e As FormClosedEventArgs)
        relogio.Stop()
        efeito.Stop()
        abertas.Remove(Me)
        MyBase.OnFormClosed(e)
        ReposicionarTodas()
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            relogio.Dispose()
            efeito.Dispose()
            If icone.Image IsNot Nothing Then
                icone.Image.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private Shared Function CorDoTipo(ByVal tipo As TipoNotificacao) As Color
        Select Case tipo
            Case TipoNotificacao.Sucesso
                Return Color.FromArgb(67, 160, 71)
            Case TipoNotificacao.Aviso
                Return Color.FromArgb(251, 140, 0)
            Case TipoNotificacao.Erro
                Return Color.FromArgb(229, 57, 53)
            Case Else
                Return Color.FromArgb(30, 136, 229)
        End Select
    End Function

    ' Icone desenhado (circulo colorido com o simbolo) - nao depende de imagem
    Private Shared Function DesenharIcone(ByVal tipo As TipoNotificacao, ByVal cor As Color) As Bitmap
        Dim bmp As New Bitmap(28, 28)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = SmoothingMode.AntiAlias
            Using pincel As New SolidBrush(cor)
                g.FillEllipse(pincel, 1, 1, 25, 25)
            End Using
            Using caneta As New Pen(Color.White, 2.6!)
                caneta.StartCap = LineCap.Round
                caneta.EndCap = LineCap.Round
                Select Case tipo
                    Case TipoNotificacao.Sucesso
                        g.DrawLines(caneta, New PointF() {New PointF(8, 14), New PointF(12, 18), New PointF(19, 10)})
                    Case TipoNotificacao.Erro
                        g.DrawLine(caneta, 9, 9, 18, 18)
                        g.DrawLine(caneta, 18, 9, 9, 18)
                    Case TipoNotificacao.Aviso
                        g.DrawLine(caneta, 13.5!, 7, 13.5!, 15)
                        g.FillEllipse(Brushes.White, 12, 18, 3.4!, 3.4!)
                    Case Else
                        g.FillEllipse(Brushes.White, 12, 6.5!, 3.4!, 3.4!)
                        g.DrawLine(caneta, 13.5!, 12, 13.5!, 20)
                End Select
            End Using
        End Using
        Return bmp
    End Function

End Class
