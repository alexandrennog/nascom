Imports ncDados.nsBackupNuvem
Imports ncPersistencia.nsBackupNuvem
Imports ncComum.nsExcecao

Namespace nsBackupNuvem

    ' Regras do historico do backup local + nuvem. O backup em si fica na
    ' biblioteca NasLibackup (C#); aqui so o controle de "um automatico por dia"
    ' e a gravacao/consulta do historico (Relatorio de Backups).
    Public Class rBackupNuvem

        ' Backup "em andamento" ha mais tempo que isso e considerado interrompido
        Public Const HorasBackupTravado As Integer = 4

        ' Backup automatico que deu errado tenta de novo no proximo login, mas no
        ' maximo isso por dia (evita repetir a falha - e o e-mail - a cada login).
        ' O botao "Fazer backup agora" nao tem limite.
        Public Const MaximoFalhasAutomaticasPorDia As Integer = 3

        Public Function TabelaExiste() As Boolean
            Try
                Return New pBackupNuvem().TabelaExiste()
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em TabelaExiste BackupNuvem [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        ' Devolve o cid da linha de historico criada, ou 0 quando e automatico e
        ' o backup de hoje ja foi feito (ou esta sendo feito) por outro terminal,
        ' ou ja deu errado MaximoFalhasAutomaticasPorDia vezes hoje.
        Public Function Iniciar(ByVal automatico As Boolean, ByVal terminal As String, ByVal computador As String,
                                ByVal usuario_cid As Nullable(Of Integer), ByVal usuarioNome As String) As Integer
            Try
                Dim persistencia As New pBackupNuvem
                persistencia.EncerrarTravados(HorasBackupTravado)
                If automatico AndAlso persistencia.FalhasAutomaticasHoje() >= MaximoFalhasAutomaticasPorDia Then
                    Return 0
                End If
                Return persistencia.Iniciar(automatico, terminal, computador, usuario_cid, usuarioNome)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Iniciar BackupNuvem [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        Public Sub Finalizar(ByVal dados As dBackupNuvem)
            Try
                If dados Is Nothing OrElse Not dados.cid.HasValue Then
                    Exit Sub
                End If
                If dados.mensagem IsNot Nothing AndAlso dados.mensagem.Length > 4000 Then
                    dados.mensagem = dados.mensagem.Substring(0, 4000)
                End If
                Dim persistencia As New pBackupNuvem
                persistencia.Finalizar(dados)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Finalizar BackupNuvem [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Sub

        Public Function Listar(ByVal dataInicial As Nullable(Of DateTime), ByVal dataFinal As Nullable(Of DateTime),
                               ByVal situacao As String) As ColecaoBackupNuvem
            Try
                Return New pBackupNuvem().Listar(dataInicial, dataFinal, situacao)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Listar BackupNuvem [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        Public Function Ultimo(ByVal somenteSucesso As Boolean) As dBackupNuvem
            Try
                Return New pBackupNuvem().Ultimo(somenteSucesso)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Ultimo BackupNuvem [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

    End Class

End Namespace
