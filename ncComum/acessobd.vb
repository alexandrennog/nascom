Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports ncComum.nsExcecao

Namespace nsAcessoBD

    Public Class cAcessoBD

        Private Function ConectarBD() As MySqlConnection

            Dim caminhoBD As String
            Dim con As MySqlConnection
            Dim conexao As ConnectionStringsSection
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

            conexao = config.ConnectionStrings

            Try

                con = New MySqlConnection()
                caminhoBD = conexao.ConnectionStrings("nascomercio").ConnectionString
                caminhoBD = ExtrairPass(caminhoBD)
                con.ConnectionString = caminhoBD
                con.Open()

            Catch ex As Exception

                con = Nothing
                Throw New ExcecaoNascomercio("Problema na conexão com o banco de dados! " & vbCrLf & vbCrLf & ex.Message, ex)

            End Try

            Return con

        End Function
        Private Function ExtrairPass(ByVal strConn As String) As String
            Dim builder As New System.Data.Common.DbConnectionStringBuilder()
            Dim cripto As New ncComum.criptografia()
            Dim result As String

            builder.ConnectionString = strConn

            Dim password As String = builder("Password").ToString()

            result = Split(cripto.Descriptografar(password), vbNullChar)(0)
            cripto = Nothing

            strConn = strConn.Replace(password, result)

            ExtrairPass = strConn
        End Function
        Public Function ExecutarINT(ByVal comandoSQL As String) As Integer

            Dim retorno As Integer

            Using cmd As New MySqlCommand()

                Try

                    cmd.Connection = ConectarBD()

                    Using cmd.Connection

                        If Not cmd.Connection Is Nothing Then
                            cmd.CommandText = comandoSQL
                            cmd.CommandType = CommandType.Text
                            retorno = cmd.ExecuteNonQuery()
                        Else
                            retorno = 0
                        End If

                    End Using

                Catch nex As ExcecaoNascomercio

                    Throw

                Catch ex As Exception

                    If ex.Message.ToUpper().Contains("FOREIGN KEY") Then
                        Throw New ExcecaoNascomercio("NÃO FOI POSSÍVEL EXCLUIR POR EXISTIR REGISTROS RELACIONADOS: " & ex.Message, ex)
                    Else
                        Throw New ExcecaoNascomercio("Erro ao executar comando [" & Me.ToString() & "] - " & ex.Message, ex)
                    End If

                End Try

            End Using

            ExecutarINT = retorno

        End Function

        Public Function ExecutarCID(ByVal comandoSQL As String) As Integer

            Dim retorno As Integer

            Using cmd As New MySqlCommand()

                Try

                    cmd.Connection = ConectarBD()

                    Using cmd.Connection

                        If Not cmd.Connection Is Nothing Then
                            cmd.CommandText = comandoSQL
                            cmd.CommandType = CommandType.Text
                            cmd.ExecuteNonQuery()
                            retorno = cmd.LastInsertedId
                        Else
                            retorno = 0
                        End If

                    End Using

                Catch nex As ExcecaoNascomercio

                    Throw

                Catch ex As Exception

                    Throw New ExcecaoNascomercio("Erro ao executar comando [" & Me.ToString() & "] - " & ex.Message, ex)

                End Try

            End Using

            ExecutarCID = retorno

        End Function

        Public Function ExecutarDS(ByVal comandoSQL As String) As DataSet

            ExecutarDS = ExecutarDS(comandoSQL, Nothing)

        End Function
        Public Function ExecutarDSLongo(ByVal comandoSQL As String) As DataSet

            ExecutarDSLongo = ExecutarDSLongo(comandoSQL, Nothing, 300)

        End Function

        ' Overload sem MySqlParameterCollection na assinatura: existe para quem
        ' chama de outro projeto (ncPersistencia) sem parametros de fato (sempre
        ' Nothing). Chamar direto a versao de 3 parametros dali de fora estoura
        ' MissingMethodException em tempo de execucao - o ncPersistencia referencia
        ' uma versao do MySql.Data.dll diferente da que o ncComum usa (ver
        ' ncPersistencia.vbproj: MySQL Connector Net 6.6.4, vs a referencia do
        ' ncComum), entao o tipo MySqlParameterCollection na assinatura nao "bate"
        ' entre as duas DLLs, mesmo o metodo existindo e o codigo compilando normal.
        ' Passando so String e Integer? (sem nenhum tipo do MySql.Data na
        ' assinatura vista de fora do ncComum) o problema nao aparece - e o mesmo
        ' motivo por que ExecutarDS(comandoSQL) de 1 parametro sempre funcionou
        ' entre esses projetos.
        Public Function ExecutarDSLongo(ByVal comandoSQL As String, ByVal timeoutSegundos As Integer?) As DataSet

            ExecutarDSLongo = ExecutarDSLongo(comandoSQL, Nothing, timeoutSegundos)

        End Function

        Public Function ExecutarDS(ByVal comandoSQL As String, ByVal colecaoParametro As MySqlParameterCollection) As DataSet

            Dim retorno As DataSet
            Dim param As MySqlParameter

            Using cmd As New MySqlCommand()

                Try

                    cmd.Connection = ConectarBD()

                    Using cmd.Connection

                        If Not cmd.Connection Is Nothing Then
                            cmd.CommandText = comandoSQL

                            If Not colecaoParametro Is Nothing Then
                                cmd.CommandType = CommandType.StoredProcedure

                                For Each param In colecaoParametro
                                    cmd.Parameters.Add(param)
                                Next
                            Else
                                cmd.CommandType = CommandType.Text
                            End If

                            retorno = New DataSet

                            Using da As New MySqlDataAdapter
                                da.SelectCommand = cmd
                                da.Fill(retorno)
                            End Using
                        Else
                            retorno = Nothing
                        End If

                    End Using

                Catch nex As ExcecaoNascomercio

                    Throw

                Catch ex As Exception

                    retorno = Nothing
                    Throw New ExcecaoNascomercio("Erro ao executar comando: [" & Me.ToString() & "] - " & ex.Message, ex)

                End Try

            End Using

            Return retorno

        End Function

        Public Function ExecutarDSLongo(ByVal comandoSQL As String, ByVal colecaoParametro As MySqlParameterCollection, Optional ByVal timeoutSegundos As Integer? = Nothing) As DataSet

            Dim retorno As DataSet
            Dim param As MySqlParameter

            Using cmd As New MySqlCommand()

                Try

                    cmd.Connection = ConectarBD()

                    Using cmd.Connection

                        If Not cmd.Connection Is Nothing Then
                            cmd.CommandText = comandoSQL
                            cmd.CommandTimeout = timeoutSegundos.Value

                            ' aplica timeout customizado se informado; caso contrario mantém o padrão da conexão
                            If timeoutSegundos.HasValue Then
                                If timeoutSegundos.Value < 0 Then
                                    Throw New ArgumentException("O timeout não pode ser negativo.", NameOf(timeoutSegundos))
                                End If

                            End If

                            If Not colecaoParametro Is Nothing Then
                                cmd.CommandType = CommandType.StoredProcedure

                                For Each param In colecaoParametro
                                    cmd.Parameters.Add(param)
                                Next
                            Else
                                cmd.CommandType = CommandType.Text
                            End If

                            retorno = New DataSet

                            Using da As New MySqlDataAdapter
                                da.SelectCommand = cmd
                                da.Fill(retorno)
                            End Using
                        Else
                            retorno = Nothing
                        End If

                    End Using

                Catch nex As ExcecaoNascomercio

                    Throw

                Catch ex As Exception

                    retorno = Nothing
                    Throw New ExcecaoNascomercio("Erro ao executar comando: [" & Me.ToString() & "] - " & ex.Message, ex)

                End Try

            End Using

            Return retorno

        End Function

        ' Executa varios comandos numa unica conexao e numa unica transacao:
        ' ou grava tudo, ou nao grava nada (usado pelo Pedido de Compra, que
        ' grava cabecalho + itens juntos).
        '
        ' comandoPrincipal (opcional): executado primeiro; o ID gerado por ele
        ' (LAST_INSERT_ID) substitui o texto "marcadorCID" em todos os comandos
        ' seguintes - e assim que os itens de um pedido novo recebem o numero do
        ' pedido que acabou de ser criado. Devolve esse ID (ou 0 se nao houver
        ' comandoPrincipal).
        '
        ' Assinatura so com String/List(Of String)/Integer de proposito: sem
        ' nenhum tipo do MySql.Data visivel de fora do ncComum (ver comentario do
        ' ExecutarDSLongo acima sobre a MissingMethodException entre projetos).
        Public Function ExecutarTransacao(ByVal comandoPrincipal As String, ByVal comandos As List(Of String), ByVal marcadorCID As String) As Integer

            Dim novoCID As Integer = 0

            Using conexao As MySqlConnection = ConectarBD()

                If conexao Is Nothing Then
                    Throw New ExcecaoNascomercio("Problema na conexão com o banco de dados!")
                End If

                Dim transacao As MySqlTransaction = conexao.BeginTransaction()

                Try

                    If Not String.IsNullOrEmpty(comandoPrincipal) Then
                        Using cmd As New MySqlCommand(comandoPrincipal, conexao, transacao)
                            cmd.CommandType = CommandType.Text
                            cmd.ExecuteNonQuery()
                            novoCID = CInt(cmd.LastInsertedId)
                        End Using
                    End If

                    If Not comandos Is Nothing Then
                        For Each comandoSQL As String In comandos
                            If Not String.IsNullOrEmpty(comandoSQL) Then
                                If Not String.IsNullOrEmpty(marcadorCID) Then
                                    comandoSQL = comandoSQL.Replace(marcadorCID, novoCID.ToString())
                                End If

                                Using cmd As New MySqlCommand(comandoSQL, conexao, transacao)
                                    cmd.CommandType = CommandType.Text
                                    cmd.ExecuteNonQuery()
                                End Using
                            End If
                        Next
                    End If

                    transacao.Commit()

                Catch ex As Exception

                    Try
                        transacao.Rollback()
                    Catch
                        ' a conexao pode ter caido; o rollback acontece no servidor de qualquer forma
                    End Try

                    Throw New ExcecaoNascomercio("Erro ao gravar (nada foi salvo) [" & Me.ToString() & "] - " & ex.Message, ex)

                End Try

            End Using

            Return novoCID

        End Function

    End Class

End Namespace
