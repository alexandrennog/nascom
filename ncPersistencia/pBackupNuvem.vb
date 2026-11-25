Imports System.Globalization
Imports ncDados.nsBackupNuvem
Imports ncComum.nsAcessoBD
Imports ncComum.nsExcecao

Namespace nsBackupNuvem

    ' Historico do backup local + nuvem (tabela "backupnuvem", script
    ' "43 - backup_nuvem.sql"). Todo valor que vai para o SQL passa por
    ' SqlTexto/SqlInteiro/SqlDataHora (escape de aspas e barra invertida).
    Public Class pBackupNuvem

        ' Script 43 aplicado neste banco?
        Public Function TabelaExiste() As Boolean
            Dim acessoBanco As New cAcessoBD
            Dim ds As DataSet

            Try
                ds = acessoBanco.ExecutarDS(" SELECT COUNT(*) AS qtd FROM information_schema.tables " &
                                            "  WHERE table_schema = DATABASE() AND table_name = 'backupnuvem' ")
                Return Not ds Is Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 AndAlso
                       Convert.ToInt64(ds.Tables(0).Rows(0)("qtd"), CultureInfo.InvariantCulture) > 0
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em TabelaExiste BackupNuvem [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        ' Backup que ficou "em andamento" ha mais de X horas (sistema fechado ou
        ' computador desligado no meio) vira falha e libera a chave do dia,
        ' senao o automatico daquele dia nunca mais rodaria.
        Public Sub EncerrarTravados(ByVal horas As Integer)
            Dim acessoBanco As New cAcessoBD

            Try
                acessoBanco.ExecutarINT(" UPDATE backupnuvem " &
                                        "    SET situacao = 'F', chaveDia = NULL, dataFim = NOW(), " &
                                        "        mensagem = CONCAT(IFNULL(mensagem, ''), 'Backup interrompido (o sistema foi fechado ou o computador desligou antes de terminar).') " &
                                        "  WHERE situacao = 'E' " &
                                        "    AND dataInicio < DATE_SUB(NOW(), INTERVAL " & horas.ToString(CultureInfo.InvariantCulture) & " HOUR) ")
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em EncerrarTravados BackupNuvem [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Sub

        ' Quantas tentativas automaticas ja deram errado hoje (falha ou so local)
        Public Function FalhasAutomaticasHoje() As Integer
            Dim acessoBanco As New cAcessoBD
            Dim ds As DataSet

            Try
                ds = acessoBanco.ExecutarDS(" SELECT COUNT(*) AS qtd FROM backupnuvem " &
                                            "  WHERE tipo = 'A' AND situacao IN ('F', 'P') " &
                                            "    AND dataInicio >= CURDATE() ")
                If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                    Return 0
                End If
                Return CInt(Convert.ToInt64(ds.Tables(0).Rows(0)("qtd"), CultureInfo.InvariantCulture))
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em FalhasAutomaticasHoje BackupNuvem [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        ' Grava o inicio do backup e devolve o cid.
        ' Automatico: grava chaveDia = hoje (indice unico). Se outro terminal ja
        ' fez/esta fazendo o backup de hoje, o INSERT bate no indice unico e a
        ' funcao devolve 0 (= nao precisa rodar).
        Public Function Iniciar(ByVal automatico As Boolean, ByVal terminal As String, ByVal computador As String,
                                ByVal usuario_cid As Nullable(Of Integer), ByVal usuarioNome As String) As Integer
            Dim acessoBanco As New cAcessoBD

            Try
                Return acessoBanco.ExecutarCID(
                    " INSERT INTO backupnuvem (dataInicio, chaveDia, tipo, situacao, etapa, terminal, computador, usuario_cid, usuarioNome) " &
                    " VALUES (NOW(), " & If(automatico, "CURDATE()", "NULL") & ", " &
                    If(automatico, "'A'", "'M'") & ", 'E', 'inicio', " &
                    SqlTexto(terminal) & ", " & SqlTexto(computador) & ", " &
                    SqlInteiro(usuario_cid) & ", " & SqlTexto(usuarioNome) & ") ")

            Catch ex As Exception
                ' Indice unico de chaveDia: o backup automatico de hoje ja existe
                If automatico AndAlso ex.Message.IndexOf("Duplicate entry", StringComparison.OrdinalIgnoreCase) >= 0 Then
                    Return 0
                End If
                Throw New ExcecaoNascomercio("Erro em Iniciar BackupNuvem [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        ' Grava o resultado. Se nao foi sucesso completo, limpa a chaveDia para o
        ' proximo login tentar de novo.
        Public Sub Finalizar(ByVal dados As dBackupNuvem)
            Dim acessoBanco As New cAcessoBD

            Try
                acessoBanco.ExecutarINT(
                    " UPDATE backupnuvem SET " &
                    "        dataFim = NOW(), " &
                    "        situacao = " & SqlTexto(dados.situacao) & ", " &
                    "        chaveDia = " & If(dados.situacao = "S", "chaveDia", "NULL") & ", " &
                    "        etapa = " & SqlTexto(dados.etapa) & ", " &
                    "        arquivo = " & SqlTexto(dados.arquivo) & ", " &
                    "        bytesBanco = " & dados.bytesBanco.ToString(CultureInfo.InvariantCulture) & ", " &
                    "        bytesZip = " & dados.bytesZip.ToString(CultureInfo.InvariantCulture) & ", " &
                    "        enviadoNuvem = " & If(dados.enviadoNuvem, "'S'", "'N'") & ", " &
                    "        bucket = " & SqlTexto(dados.bucket) & ", " &
                    "        chaveNuvem = " & SqlTexto(dados.chaveNuvem) & ", " &
                    "        arquivosApagados = " & dados.arquivosApagados.ToString(CultureInfo.InvariantCulture) & ", " &
                    "        emailEnviado = " & If(dados.emailEnviado, "'S'", "'N'") & ", " &
                    "        mensagem = " & SqlTexto(dados.mensagem) &
                    "  WHERE cid = " & SqlInteiro(dados.cid))
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Finalizar BackupNuvem [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Sub

        ' Historico para o relatorio (mais recente primeiro). situacao "" = todas.
        Public Function Listar(ByVal dataInicial As Nullable(Of DateTime), ByVal dataFinal As Nullable(Of DateTime),
                               ByVal situacao As String) As ColecaoBackupNuvem
            Dim filtro As New List(Of String)

            If dataInicial.HasValue Then
                filtro.Add("b.dataInicio >= " & SqlDataHora(dataInicial.Value.Date))
            End If
            If dataFinal.HasValue Then
                ' data final inclusiva (o dia inteiro)
                filtro.Add("b.dataInicio < " & SqlDataHora(dataFinal.Value.Date.AddDays(1)))
            End If
            If Not String.IsNullOrEmpty(situacao) Then
                filtro.Add("b.situacao = " & SqlTexto(situacao))
            End If

            Return Consultar(If(filtro.Count > 0, " WHERE " & String.Join(" AND ", filtro.ToArray()), "") &
                             " ORDER BY b.dataInicio DESC, b.cid DESC ")
        End Function

        ' Ultimo backup (qualquer situacao) e ultimo com sucesso - para a tela de Backup
        Public Function Ultimo(ByVal somenteSucesso As Boolean) As dBackupNuvem
            Dim lista As ColecaoBackupNuvem = Consultar(If(somenteSucesso, " WHERE b.situacao = 'S' ", "") &
                                                        " ORDER BY b.dataInicio DESC, b.cid DESC LIMIT 1 ")
            If lista.Count = 0 Then
                Return Nothing
            End If
            Return lista(0)
        End Function

        Private Function Consultar(ByVal complemento As String) As ColecaoBackupNuvem
            Dim retorno As New ColecaoBackupNuvem
            Dim acessoBanco As New cAcessoBD
            Dim ds As DataSet

            Try
                ds = acessoBanco.ExecutarDS(
                    " SELECT b.cid, b.dataInicio, b.dataFim, b.tipo, b.situacao, b.etapa, b.terminal, b.computador, " &
                    "        b.usuario_cid, b.usuarioNome, b.arquivo, b.bytesBanco, b.bytesZip, b.enviadoNuvem, " &
                    "        b.bucket, b.chaveNuvem, b.arquivosApagados, b.emailEnviado, b.mensagem " &
                    "   FROM backupnuvem b " & complemento)

                If ds Is Nothing OrElse ds.Tables.Count = 0 Then
                    Return retorno
                End If

                For Each row As DataRow In ds.Tables(0).Rows
                    Dim item As New dBackupNuvem
                    item.cid = Convert.ToInt32(row("cid"), CultureInfo.InvariantCulture)
                    item.dataInicio = LerData(row("dataInicio"))
                    item.dataFim = LerData(row("dataFim"))
                    item.tipo = LerTexto(row("tipo"))
                    item.situacao = LerTexto(row("situacao"))
                    item.etapa = LerTexto(row("etapa"))
                    item.terminal = LerTexto(row("terminal"))
                    item.computador = LerTexto(row("computador"))
                    If Not IsDBNull(row("usuario_cid")) Then
                        item.usuario_cid = Convert.ToInt32(row("usuario_cid"), CultureInfo.InvariantCulture)
                    End If
                    item.usuarioNome = LerTexto(row("usuarioNome"))
                    item.arquivo = LerTexto(row("arquivo"))
                    item.bytesBanco = LerLong(row("bytesBanco"))
                    item.bytesZip = LerLong(row("bytesZip"))
                    item.enviadoNuvem = (LerTexto(row("enviadoNuvem")) = "S")
                    item.bucket = LerTexto(row("bucket"))
                    item.chaveNuvem = LerTexto(row("chaveNuvem"))
                    item.arquivosApagados = CInt(LerLong(row("arquivosApagados")))
                    item.emailEnviado = (LerTexto(row("emailEnviado")) = "S")
                    item.mensagem = LerTexto(row("mensagem"))
                    retorno.Add(item)
                Next

            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Consultar BackupNuvem [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try

            Return retorno
        End Function

        Private Shared Function SqlTexto(ByVal valor As String) As String
            If valor Is Nothing OrElse valor.Trim().Length = 0 Then
                Return "NULL"
            End If
            Return "'" & valor.Trim().Replace("\", "\\").Replace("'", "''") & "'"
        End Function

        Private Shared Function SqlInteiro(ByVal valor As Nullable(Of Integer)) As String
            If Not valor.HasValue Then
                Return "NULL"
            End If
            Return valor.Value.ToString(CultureInfo.InvariantCulture)
        End Function

        Private Shared Function SqlDataHora(ByVal valor As DateTime) As String
            Return "'" & valor.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "'"
        End Function

        Private Shared Function LerTexto(ByVal valor As Object) As String
            If valor Is Nothing OrElse IsDBNull(valor) Then
                Return ""
            End If
            Return valor.ToString()
        End Function

        Private Shared Function LerLong(ByVal valor As Object) As Long
            If valor Is Nothing OrElse IsDBNull(valor) Then
                Return 0
            End If
            Return Convert.ToInt64(valor, CultureInfo.InvariantCulture)
        End Function

        Private Shared Function LerData(ByVal valor As Object) As Nullable(Of DateTime)
            If valor Is Nothing OrElse IsDBNull(valor) Then
                Return Nothing
            End If
            Try
                Return Convert.ToDateTime(valor, CultureInfo.InvariantCulture)
            Catch
                ' "Allow Zero Datetime" devolve MySqlDateTime: vai pelo texto
                Dim d As DateTime
                If DateTime.TryParse(valor.ToString(), d) Then
                    Return d
                End If
                Return Nothing
            End Try
        End Function

    End Class

End Namespace
