Namespace nsBackupNuvem

    ' Uma execucao do backup (local + nuvem). Tabela "backupnuvem", criada pelo
    ' script "scripts\new script\43 - backup_nuvem.sql".
    '
    ' tipo:     A = automatico (depois do login) | M = manual (botao na tela de Backup)
    ' situacao: E = em andamento | S = sucesso (local + nuvem)
    '           P = parcial (so local, a nuvem falhou) | F = falha
    Public Class dBackupNuvem

        Public Property cid As Nullable(Of Integer)
        Public Property dataInicio As Nullable(Of DateTime)
        Public Property dataFim As Nullable(Of DateTime)
        Public Property tipo As String
        Public Property situacao As String
        Public Property etapa As String
        Public Property terminal As String
        Public Property computador As String
        Public Property usuario_cid As Nullable(Of Integer)
        Public Property usuarioNome As String
        Public Property arquivo As String
        Public Property bytesBanco As Long
        Public Property bytesZip As Long
        Public Property enviadoNuvem As Boolean
        Public Property bucket As String
        Public Property chaveNuvem As String
        Public Property arquivosApagados As Integer
        Public Property emailEnviado As Boolean
        Public Property mensagem As String

        Public ReadOnly Property situacaoDescricao As String
            Get
                Return DescreverSituacao(situacao)
            End Get
        End Property

        Public ReadOnly Property tipoDescricao As String
            Get
                Return If(tipo = "M", "Manual", "Automático")
            End Get
        End Property

        ' Duracao em segundos (0 enquanto esta em andamento)
        Public ReadOnly Property duracaoSegundos As Integer
            Get
                If dataInicio.HasValue AndAlso dataFim.HasValue AndAlso dataFim.Value > dataInicio.Value Then
                    Return CInt((dataFim.Value - dataInicio.Value).TotalSeconds)
                End If
                Return 0
            End Get
        End Property

        Public Shared Function DescreverSituacao(ByVal codigo As String) As String
            Select Case codigo
                Case "S"
                    Return "Sucesso"
                Case "P"
                    Return "Só local"
                Case "F"
                    Return "Falha"
                Case "E"
                    Return "Em andamento"
                Case Else
                    Return codigo
            End Select
        End Function

    End Class

    Public Class ColecaoBackupNuvem
        Inherits List(Of dBackupNuvem)
    End Class

End Namespace
