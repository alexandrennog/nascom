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
                Throw New ExcecaoNascomercio("Problema na conexão com o banco de dados! " & vbCrLf & vbCrLf & ex.Message)

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

            Dim cmd As MySqlCommand = Nothing
            Dim retorno As Integer

            Try

                cmd = New MySqlCommand
                cmd.Connection = ConectarBD()

                If Not cmd.Connection Is Nothing Then
                    cmd.CommandText = comandoSQL
                    cmd.CommandType = CommandType.Text
                    retorno = cmd.ExecuteNonQuery()
                Else
                    retorno = 0
                End If

            Catch nex As ExcecaoNascomercio

                Throw nex

            Catch ex As Exception

                If ex.Message.ToUpper().Contains("FOREIGN KEY") Then
                    Throw New ExcecaoNascomercio("NÃO FOI POSSÍVEL EXCLUIR POR EXISTIR REGISTROS RELACIONADOS: " & ex.Message)
                Else
                    Throw New ExcecaoNascomercio("Erro ao executar comando [" & Me.ToString() & "] - " & ex.Message)
                End If


            Finally

                If Not cmd Is Nothing Then
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                End If

            End Try

            ExecutarINT = retorno

        End Function

        Public Function ExecutarCID(ByVal comandoSQL As String) As Integer

            Dim cmd As MySqlCommand = Nothing
            Dim retorno As Integer

            Try

                cmd = New MySqlCommand
                cmd.Connection = ConectarBD()

                If Not cmd.Connection Is Nothing Then
                    cmd.CommandText = comandoSQL
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                    retorno = cmd.LastInsertedId
                Else
                    retorno = 0
                End If

            Catch nex As ExcecaoNascomercio

                Throw nex

            Catch ex As Exception

                Throw New ExcecaoNascomercio("Erro ao executar comando [" & Me.ToString() & "] - " & ex.Message)

            Finally

                If Not cmd Is Nothing Then
                    If Not cmd.Connection Is Nothing Then
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                    End If
                End If

            End Try

            ExecutarCID = retorno

        End Function

        Public Function ExecutarDS(ByVal comandoSQL As String) As DataSet

            ExecutarDS = ExecutarDS(comandoSQL, Nothing)

        End Function
        Public Function ExecutarDSLongo(ByVal comandoSQL As String) As DataSet

            ExecutarDSLongo = ExecutarDSLongo(comandoSQL, Nothing, 300)

        End Function

        Public Function ExecutarDS(ByVal comandoSQL As String, ByVal colecaoParametro As MySqlParameterCollection) As DataSet

            Dim cmd As MySqlCommand = Nothing
            Dim da As MySqlDataAdapter
            Dim retorno As DataSet
            Dim param As MySqlParameter

            Try

                cmd = New MySqlCommand
                cmd.Connection = ConectarBD()

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
                    da = New MySqlDataAdapter
                    da.SelectCommand = cmd
                    da.Fill(retorno)

                    da.Dispose()
                Else
                    retorno = Nothing
                End If

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                cmd.Dispose()

            Catch nex As ExcecaoNascomercio

                Throw nex

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro ao executar comando: [" & Me.ToString() & "] - " & ex.Message)

            Finally

                If Not cmd Is Nothing AndAlso Not cmd.Connection Is Nothing Then
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                End If

            End Try

            Return retorno

        End Function

        Public Function ExecutarDSLongo(ByVal comandoSQL As String, ByVal colecaoParametro As MySqlParameterCollection, Optional ByVal timeoutSegundos As Integer? = Nothing) As DataSet

            Dim cmd As MySqlCommand = Nothing
            Dim da As MySqlDataAdapter
            Dim retorno As DataSet
            Dim param As MySqlParameter

            Try

                cmd = New MySqlCommand
                cmd.Connection = ConectarBD()

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
                    da = New MySqlDataAdapter
                    da.SelectCommand = cmd
                    da.Fill(retorno)

                    da.Dispose()
                Else
                    retorno = Nothing
                End If

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                cmd.Dispose()

            Catch nex As ExcecaoNascomercio

                Throw nex

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro ao executar comando: [" & Me.ToString() & "] - " & ex.Message)

            Finally

                If Not cmd Is Nothing AndAlso Not cmd.Connection Is Nothing Then
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                End If

            End Try

            Return retorno

        End Function

    End Class

End Namespace
