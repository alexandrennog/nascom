Namespace nsFuncoes

    Public Class cFuncoes

        '-- Tratar valores para concatenar na string SQL
        '-- Da camada de dados para a de persistencia (string sql)

        Public Shared Function PersistirTexto(ByVal valor As String) As String

            PersistirTexto = PersistirTexto(valor, True)

        End Function

        Public Shared Function PersistirTexto(ByVal valor As String, ByVal haspas As Boolean) As String

            Dim retorno As String

            Try

                If valor Is Nothing Then
                    retorno = "NULL"
                Else
                    If valor.ToString().Trim().Equals(String.Empty) Then
                        retorno = "NULL"
                    Else
                        If haspas = True Then
                            retorno = "'" & valor.ToString() & "'"
                        Else
                            retorno = valor.ToString()
                        End If
                    End If
                End If

            Catch ex As Exception

                retorno = "NULL"

            End Try

            PersistirTexto = retorno

        End Function

        Public Shared Function PersistirInteiro(ByVal valor As Object) As String

            Dim retorno As String

            Try

                If valor Is Nothing Then
                    retorno = "NULL"
                Else
                    If valor.ToString().Trim().Equals(String.Empty) Then
                        retorno = "NULL"
                    Else
                        retorno = valor.ToString()
                    End If
                End If

            Catch ex As Exception

                retorno = "NULL"

            End Try

            PersistirInteiro = retorno

        End Function

        Public Shared Function PersistirBoleano(ByVal valor As Object) As String

            Dim retorno As String

            Try

                If valor Is Nothing Then
                    retorno = "NULL"
                Else
                    If valor = True Then
                        retorno = "1"
                    Else
                        retorno = "0"
                    End If
                End If

            Catch ex As Exception

                retorno = "NULL"

            End Try

            PersistirBoleano = retorno

        End Function

        Public Shared Function PersistirDecimal(ByVal valor As Object) As String

            Dim retorno As String

            Try

                If valor Is Nothing Then
                    retorno = "NULL"
                Else
                    If valor.ToString().Trim().Equals(String.Empty) Then
                        retorno = "NULL"
                    Else
                        If valor.ToString().IndexOf(",") > 0 Then
                            retorno = valor.ToString().Replace(".", "").Replace(",", ".")
                        Else
                            retorno = Format(Convert.ToDecimal(valor.ToString()), "0.00")
                            retorno = retorno.ToString().Replace(".", "").Replace(",", ".")
                        End If
                    End If
                End If

            Catch ex As Exception

                retorno = "NULL"

            End Try

            PersistirDecimal = retorno

        End Function

        Public Shared Function PersistirData(ByVal valor As Object) As String

            Dim retorno As String = "NULL"

            Dim dataEntrada As DateTime

            Try

                If valor Is Nothing Then
                    retorno = "NULL"
                Else
                    If valor.ToString().Trim().Equals(String.Empty) OrElse valor.ToString() = "000000" OrElse valor = DateTime.MinValue Then
                        retorno = "NULL"
                    Else
                        If valor.ToString().IndexOf("-") <= 0 Then
                            valor = FormatarData(valor)
                            valor = valor.Substring(4, 4) & "-" & valor.Substring(2, 2) & "-" & valor.Substring(0, 2)
                        End If

                        If DateTime.TryParse(valor, dataEntrada) Then
                            If valor.Equals(DateTime.MinValue) Then
                                retorno = "NULL"
                            Else
                                retorno = "'" & dataEntrada.ToString("yyyy-MM-dd") & "'"
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception

                retorno = "NULL"

            End Try

            PersistirData = retorno

        End Function

        Public Shared Function PersistirDataHora(ByVal valor As Object) As String

            Dim retorno As String = "NULL"

            Dim dataEntrada As DateTime

            Try

                If valor Is Nothing Then
                    retorno = "NULL"
                Else
                    If valor.ToString().Trim().Equals(String.Empty) Then
                        retorno = "NULL"
                    Else

                        If DateTime.TryParse(valor, dataEntrada) Then
                            If valor.Equals(DateTime.MinValue) Then
                                retorno = "NULL"
                            Else
                                retorno = "'" & dataEntrada.ToString("yyyy-MM-dd HH:mm:ss") & "'"
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception

                retorno = "NULL"

            End Try

            Return retorno

        End Function

        '-- Tratar valores da tela para passar para as entidades
        '-- Da camada de interface (tela) para a camada de dados

        Public Shared Function TratarTexto(ByVal valor As Object) As String

            Dim retorno As String

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor.ToString().Trim().Equals(String.Empty) Then
                        retorno = Nothing
                    Else
                        retorno = valor.ToString().Trim()
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            TratarTexto = retorno

        End Function
        Public Shared Function FormatarTextoDecimal(ByVal valor As Object, ByVal ehDecimal As String) As String

            Dim retorno As String

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor.ToString().Trim().Equals(String.Empty) Then
                        retorno = Nothing
                    Else
                        If ehDecimal = "1" Then
                            retorno = String.Format("{0:n2}", valor.ToString().Trim())
                        Else
                            retorno = valor.ToString().Trim()
                        End If

                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            FormatarTextoDecimal = retorno

        End Function

        Public Shared Function TratarInteiro(ByVal valor As Object) As Nullable(Of Integer)

            Dim retorno As Nullable(Of Integer)

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor.ToString().Trim().Equals(String.Empty) Then
                        retorno = Nothing
                    Else
                        retorno = Convert.ToInt32(valor.ToString().Trim())
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            TratarInteiro = retorno

        End Function

        Public Shared Function TratarDecimal(ByVal valor As Object) As Nullable(Of Decimal)

            Dim retorno As Nullable(Of Decimal)

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor.ToString().Trim().Equals(String.Empty) Then
                        retorno = Nothing
                    Else
                        'If valor.ToString().IndexOf(",") > 0 Then
                        '  retorno = Convert.ToDecimal(valor.ToString().Replace(".", "").Replace(",", "."))
                        'Else
                        retorno = Convert.ToDecimal(valor.ToString().Replace("R$", ""))
                        'End If

                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            TratarDecimal = retorno

        End Function

        '-- Tratar valores de retorno do banco de dados
        '-- Da camada de persistencia (banco) para a camada de dados

        Public Shared Function RetornarTexto(ByVal valor As Object) As String

            Dim retorno As String

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor Is DBNull.Value Then
                        retorno = Nothing
                    Else
                        retorno = valor.ToString()
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            RetornarTexto = retorno

        End Function

        Public Shared Function RetornarTexto(ByVal valor As Object, ByVal tamanho As Integer) As String

            Dim retorno As String

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor Is DBNull.Value Then
                        retorno = Nothing
                    Else
                        If valor.ToString().Length > tamanho Then
                            retorno = valor.ToString().Substring(0, tamanho)
                        Else
                            retorno = valor.ToString()
                        End If
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            RetornarTexto = retorno

        End Function

        Public Shared Function RetornarVazio(ByVal valor As Object) As String

            Dim retorno As String

            Try

                If valor Is Nothing Then
                    retorno = ""
                Else
                    If valor Is DBNull.Value Then
                        retorno = ""
                    Else
                        retorno = valor.ToString()
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            RetornarVazio = retorno

        End Function

        Public Shared Function RetornarInteiro(ByVal valor As Object) As Nullable(Of Integer)

            Dim retorno As Nullable(Of Integer)

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor Is DBNull.Value Then
                        retorno = Nothing
                    Else
                        retorno = Convert.ToInt32(valor.ToString())
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            RetornarInteiro = retorno

        End Function

        Public Shared Function RetornarBoleano(ByVal valor As Object) As Nullable(Of Boolean)

            Dim retorno As Nullable(Of Boolean)

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor Is DBNull.Value Then
                        retorno = Nothing
                    Else
                        retorno = Convert.ToBoolean(valor)
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            RetornarBoleano = retorno

        End Function

        Public Shared Function RetornarDecimal(ByVal valor As Object) As Nullable(Of Decimal)

            Dim retorno As Nullable(Of Decimal)

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor Is DBNull.Value Then
                        retorno = Nothing
                    Else
                        retorno = Convert.ToDecimal(valor.ToString())
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            RetornarDecimal = retorno

        End Function

        Public Shared Function RetornarData(ByVal valor As Object) As Nullable(Of DateTime)

            Dim retorno As Nullable(Of DateTime)

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor Is DBNull.Value Then
                        retorno = Nothing
                    Else
                        retorno = Convert.ToDateTime(valor.ToString())
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            RetornarData = retorno

        End Function

        Public Shared Function RetornarDataValida(ByVal valor As String) As DateTime

            Dim retorno As DateTime = DateTime.MinValue
            Dim dataFormatada As String

            Try

                If valor IsNot Nothing Then
                    If valor IsNot DBNull.Value Then
                        dataFormatada = valor.Substring(4, 4) & "-" & valor.Substring(2, 2) & "-" & valor.Substring(0, 2)
                        retorno = Convert.ToDateTime(dataFormatada)
                    End If
                End If

            Catch ex As Exception

            End Try

            RetornarDataValida = retorno

        End Function

        '-- Valida se existe valor válido, diferente de Nulo e Vazio

        Public Shared Function ValidarValor(ByVal valor As Object) As Boolean

            Dim retorno As Boolean

            Try

                If Not valor Is Nothing Then
                    If valor.ToString().Trim().Equals(String.Empty) Then
                        retorno = False
                    Else
                        retorno = True
                    End If
                Else
                    retorno = False
                End If

            Catch ex As Exception

                retorno = False

            End Try

            ValidarValor = retorno

        End Function

        '-- Verifica e monta parametros de busca do comando SQL

        Public Shared Function MontarParametrosSQL(ByVal parametros As String, ByVal valor As String) As String

            Dim retorno As String = String.Empty

            Try

                If Not String.IsNullOrEmpty(valor) Then
                    If Not String.IsNullOrEmpty(parametros) Then
                        retorno = " AND "
                    End If

                    retorno = retorno & valor
                End If

            Catch ex As Exception

                retorno = String.Empty

            End Try

            MontarParametrosSQL = parametros & retorno

        End Function

        Public Shared Function MontarParametrosSQL(ByVal parametros As String, ByVal valor As Object, ByVal nomeCampo As String) As String

            MontarParametrosSQL = MontarParametrosSQL(parametros, valor, nomeCampo, False)

        End Function

        Public Shared Function MontarParametrosSQL(ByVal parametros As String, ByVal valor As Object, ByVal nomeCampo As String, ByVal usarLike As Boolean) As String

            Dim retorno As String = String.Empty

            Try

                If ValidarValor(valor) = True Then
                    If Not parametros.Equals(String.Empty) Then
                        retorno = " AND "
                    End If

                    Select Case valor.GetType().Name.ToLower()
                        Case "int32"
                            retorno = retorno & " ( " & nomeCampo & " = " & PersistirInteiro(valor) & " ) "
                        Case "decimal"
                            retorno = retorno & " ( " & nomeCampo & " = " & PersistirDecimal(valor) & " ) "
                        Case "boolean"
                            retorno = retorno & " ( " & nomeCampo & " = " & PersistirBoleano(valor) & " ) "
                        Case Else
                            If usarLike = False Then
                                retorno = retorno & " ( " & nomeCampo & " = " & PersistirTexto(valor) & " ) "
                            Else
                                retorno = retorno & " ( " & nomeCampo & " LIKE '%" & PersistirTexto(valor, False) & "%' ) "
                            End If
                    End Select
                End If

            Catch ex As Exception

                retorno = String.Empty

            End Try

            MontarParametrosSQL = parametros & retorno

        End Function

        Public Shared Function RemoverCaracterEspecial(ByVal parametro As String)
            Return parametro.Replace("ç", "c").Replace("Ç", "C").Replace("ã", "a").Replace("Ã", "A")
        End Function

        Public Shared Function ValidarData(ByVal valor As String) As Boolean
            Dim data As DateTime
            Dim dataFormatada As String
            Dim retorno As Boolean

            retorno = False

            Try

                If valor Is Nothing Then
                    retorno = False
                Else
                    If valor.Trim() = String.Empty Then
                        retorno = False
                    Else
                        If valor.Length <> 8 Then
                            retorno = False
                        Else
                            dataFormatada = valor.Substring(4, 4) & "-" & _
                            valor.Substring(2, 2) & "-" & valor.Substring(0, 2)

                            If DateTime.TryParse(dataFormatada, data) Then
                                retorno = True
                            Else
                                retorno = False
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception

                retorno = False

            End Try

            ValidarData = retorno

        End Function

        Public Shared Function ValidarLong(ByVal valor As String) As Boolean
            Dim numero As Long
            Dim retorno As Boolean

            retorno = False

            Try

                If valor Is Nothing Then
                    retorno = False
                Else
                    If valor.Trim() = String.Empty Then
                        retorno = False
                    Else
                        If Long.TryParse(valor, numero) Then
                            retorno = True
                        Else
                            retorno = False
                        End If
                    End If
                End If

            Catch ex As Exception

                retorno = False

            End Try

            ValidarLong = retorno

        End Function

        Public Shared Function ValidarInteiro(ByVal valor As String) As Boolean
            Dim numero As Integer
            Dim retorno As Boolean

            retorno = False

            Try

                If valor Is Nothing Then
                    retorno = False
                Else
                    If valor.Trim() = String.Empty Then
                        retorno = False
                    Else
                        If Integer.TryParse(valor, numero) Then
                            retorno = True
                        Else
                            retorno = False
                        End If
                    End If
                End If

            Catch ex As Exception

                retorno = False

            End Try

            ValidarInteiro = retorno

        End Function

        Public Shared Function ValidarDecimal(ByVal valor As String) As Boolean
            Dim numero As Decimal
            Dim retorno As Boolean

            retorno = False

            Try

                If valor Is Nothing Then
                    retorno = False
                Else
                    If valor.Trim() = String.Empty Then
                        retorno = False
                    Else
                        If Decimal.TryParse(valor, numero) Then
                            retorno = True
                        Else
                            retorno = False
                        End If
                    End If
                End If

            Catch ex As Exception

                retorno = False

            End Try

            ValidarDecimal = retorno

        End Function

        Public Shared Function FormatarValorSemDecimal(ByVal valor As String) As String
            Dim retorno As String

            retorno = Nothing

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor.Trim() = String.Empty Then
                        retorno = Nothing
                    Else
                        retorno = valor.Trim().Replace(",", "").Replace(".", "")
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            FormatarValorSemDecimal = retorno

        End Function

        Public Shared Function FormatarData(ByVal valor As String) As String
            Dim data As DateTime
            Dim dataFormatada As String
            Dim dataFormatadaSep As String
            Dim retorno As String
            Dim dataAux As DateTime

            retorno = False

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor.Trim() = String.Empty Then
                        retorno = Nothing
                    Else
                        If valor.Contains("/") Then
                            dataAux = Convert.ToDateTime(valor).ToString("yyyy-MM-dd")

                            dataFormatada = dataAux.Day.ToString().PadLeft(2, "0"c) & _
                                dataAux.Month.ToString().PadLeft(2, "0"c) & _
                                dataAux.Year.ToString().PadLeft(4, "0"c)
                            dataFormatadaSep = dataAux.Year.ToString().PadLeft(4, "0"c) & "-" & _
                                dataAux.Month.ToString().PadLeft(2, "0"c) & "-" & _
                                dataAux.Day.ToString().PadLeft(2, "0"c)

                            If DateTime.TryParse(dataFormatadaSep, data) Then
                                retorno = dataFormatada
                            Else
                                retorno = Nothing
                            End If
                        Else
                            If valor.Length <> 8 Then
                                retorno = Nothing
                            Else
                                dataFormatada = valor.Substring(0, 2) & valor.Substring(2, 2) & valor.Substring(4, 4)
                                dataFormatadaSep = valor.Substring(4, 4) & "-" & valor.Substring(2, 2) & "-" & valor.Substring(0, 2)

                                If DateTime.TryParse(dataFormatadaSep, data) Then
                                    retorno = dataFormatadaSep
                                Else
                                    retorno = Nothing
                                End If
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            FormatarData = retorno

        End Function

        Public Shared Function FormatarDataHoraAAAAMMDDHHMMSS(ByVal valor As String) As String
            Dim data As DateTime
            Dim dataFormatada As String
            Dim retorno As String
            Dim dataAux As DateTime

            retorno = False

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor.Trim() = String.Empty Then
                        retorno = Nothing
                    Else
                        dataAux = Convert.ToDateTime(valor)

                        If DateTime.TryParse(dataAux, data) Then
                            dataFormatada = dataAux.Year.ToString().PadLeft(4, "0"c) & _
                                dataAux.Month.ToString().PadLeft(2, "0"c) & _
                                dataAux.Day.ToString().PadLeft(2, "0"c) & _
                                dataAux.Hour.ToString().PadLeft(2, "0"c) & _
                                dataAux.Minute.ToString().PadLeft(2, "0"c) & _
                                dataAux.Second.ToString().PadLeft(2, "0"c)

                            retorno = dataFormatada
                        Else
                            retorno = Nothing
                        End If
                    End If
                End If
            Catch ex As Exception

                retorno = Nothing

            End Try

            Return retorno

        End Function

        Public Shared Function FormatarDataDDMMAAAA(ByVal valor As String) As String
            Dim data As DateTime
            Dim dataFormatada As String
            Dim retorno As String
            Dim dataAux As DateTime

            retorno = False

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor.Trim() = String.Empty Then
                        retorno = Nothing
                    Else
                        dataAux = Convert.ToDateTime(valor)

                        If DateTime.TryParse(dataAux, data) Then
                            dataFormatada = dataAux.Day.ToString().PadLeft(2, "0"c) & _
                                dataAux.Month.ToString().PadLeft(2, "0"c) & _
                                dataAux.Year.ToString().PadLeft(4, "0"c)

                            retorno = dataFormatada
                        Else
                            retorno = Nothing
                        End If
                    End If
                End If
            Catch ex As Exception

                retorno = Nothing

            End Try

            Return retorno

        End Function

        Public Shared Function FormatarDataBarras(ByVal valor As String) As String
            Dim data As DateTime
            Dim dataFormatada As String
            Dim retorno As String
            Dim dataAux As DateTime

            retorno = False

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor.Trim() = String.Empty Then
                        retorno = Nothing
                    Else
                        If valor.Contains("/") Then
                            dataAux = Convert.ToDateTime(valor).ToString("yyyy-MM-dd")

                            dataFormatada = dataAux.Day.ToString().PadLeft(2, "0"c) & "/" & _
                                dataAux.Month.ToString().PadLeft(2, "0"c) & "/" & _
                                dataAux.Year.ToString().PadLeft(4, "0"c)

                            If DateTime.TryParse(dataFormatada, data) Then
                                retorno = dataFormatada
                            Else
                                retorno = Nothing
                            End If
                        Else
                            If valor.Length <> 8 Then
                                retorno = Nothing
                            Else
                                dataFormatada = valor.Substring(0, 2) & "/" & valor.Substring(2, 2) & "/" & valor.Substring(4, 4)

                                If DateTime.TryParse(dataFormatada, data) Then
                                    retorno = dataFormatada
                                Else
                                    retorno = Nothing
                                End If
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            Return retorno

        End Function

        Public Shared Function FormatarDataUniversal(ByVal valor As String) As String
            Dim data As DateTime
            Dim dataFormatada As String
            Dim retorno As String
            Dim dataAux As DateTime

            retorno = False

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor.Trim() = String.Empty Then
                        retorno = Nothing
                    Else
                        If valor.Contains("/") Then
                            dataAux = Convert.ToDateTime(valor).ToString("yyyy-MM-dd")

                            dataFormatada = dataAux.Year.ToString().PadLeft(4, "0"c) & "-" & _
                                dataAux.Month.ToString().PadLeft(2, "0"c) & "-" & _
                                dataAux.Day.ToString().PadLeft(2, "0"c)

                            If DateTime.TryParse(dataFormatada, data) Then
                                retorno = dataFormatada
                            Else
                                retorno = Nothing
                            End If
                        Else
                            If valor.Length <> 8 Then
                                retorno = Nothing
                            Else
                                dataFormatada = valor.Substring(4, 4) & "-" & valor.Substring(2, 2) & "-" & valor.Substring(0, 2)

                                If DateTime.TryParse(dataFormatada, data) Then
                                    retorno = dataFormatada
                                Else
                                    retorno = Nothing
                                End If
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            Return retorno

        End Function

        ' Recebe AAAA-MM-DD (string) e retorna DD/MM/AAAA (string)
        Public Shared Function FormatarDataUniversalBarras(ByVal valor As String) As String
            Dim data As DateTime
            Dim dataFormatada As String
            Dim retorno As String
            Dim dataAux As DateTime

            retorno = False

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor.Trim() = String.Empty Then
                        retorno = Nothing
                    Else
                        dataAux = Convert.ToDateTime(valor).ToString("yyyy-MM-dd")

                        If DateTime.TryParse(dataAux, data) Then
                            dataFormatada = dataAux.Day.ToString().PadLeft(2, "0"c) & "/" & _
                                dataAux.Month.ToString().PadLeft(2, "0"c) & "/" & _
                                dataAux.Year.ToString().PadLeft(4, "0"c)

                            retorno = dataFormatada
                        Else
                            retorno = Nothing
                        End If
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            Return retorno

        End Function

        ' Recebe AAAA-MM-DD (string) e retorna DATETIME
        Public Shared Function ConverterDataUniversalDATETIME(ByVal valor As String) As DateTime?
            Dim data As DateTime
            Dim retorno As DateTime?
            Dim dataAux As DateTime

            retorno = Nothing

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    If valor.Trim() = String.Empty Then
                        retorno = Nothing
                    Else
                        dataAux = Convert.ToDateTime(valor).ToString("yyyy-MM-dd")

                        If Date.TryParse(dataAux, data) Then
                            retorno = data
                        Else
                            retorno = Nothing
                        End If
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            Return retorno

        End Function

        ' Recebe DATETIME e retorna DD/MM/AAAA (string)
        Public Shared Function ConverterDATETIMEDataBarras(ByVal valor As DateTime?) As String
            Dim retorno As String
            Dim dataAux As DateTime

            retorno = Nothing

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    dataAux = Convert.ToDateTime(valor)

                    retorno = dataAux.Day.ToString().PadLeft(2, "0"c) & "/" & _
                                dataAux.Month.ToString().PadLeft(2, "0"c) & "/" & _
                                dataAux.Year.ToString().PadLeft(4, "0"c)
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            Return retorno

        End Function

        ' Recebe DATETIME e retorna AAAA-MM-DD (string)
        Public Shared Function ConverterDATETIMEDataUniversal(ByVal valor As DateTime?) As String
            Dim retorno As String
            Dim dataAux As DateTime

            retorno = Nothing

            Try

                If valor Is Nothing Then
                    retorno = Nothing
                Else
                    dataAux = Convert.ToDateTime(valor)

                    retorno = dataAux.Year.ToString().PadLeft(4, "0"c) & "-" & _
                                dataAux.Month.ToString().PadLeft(2, "0"c) & "-" & _
                                dataAux.Day.ToString().PadLeft(2, "0"c)
                End If

            Catch ex As Exception

                retorno = Nothing

            End Try

            Return retorno

        End Function

        Public Shared Function SoNumero(ByVal tecla As Char) As Boolean
            If (tecla >= "0"c And tecla <= "9"c) Or tecla = ","c Or tecla = "." Or tecla = Chr(8) Or tecla = Chr(9) Then
                Return False
            Else
                Return True
            End If

        End Function

        Public Shared Function ObterCodigoBarrasProduto(ByVal codigoBarras As String) As String
            Dim retorno As String = String.Empty
            Dim inteiro As Int64

            If Not codigoBarras.Trim().Equals(String.Empty) Then
                If Int64.TryParse(codigoBarras, inteiro) Then
                    inteiro = inteiro + 1

                    retorno = inteiro.ToString().PadLeft(14, "0"c)
                End If
            End If

            ObterCodigoBarrasProduto = retorno
        End Function

        Public Shared Function ValidaCpf(CPF As String) As Boolean
            'Esta rotina foi adaptada da revista Fórum Access
            Dim I As Integer 'utilizada nos FOR... NEXT
            Dim strcampo As String 'armazena do CPF que será utilizada para o cálculo
            Dim strCaracter As String 'armazena os digitos do CPF da direita para a esquerda
            Dim intNumero As Integer 'armazena o digito separado para cálculo (uma a um)
            Dim intMais As Integer 'armazena o digito específico multiplicado pela sua base
            Dim lngSoma As Long 'armazena a soma dos digitos multiplicados pela sua base(intmais)
            Dim dblDivisao As Double 'armazena a divisão dos digitos*base por 11
            Dim lngInteiro As Long 'armazena inteiro da divisão
            Dim intResto As Integer 'armazena o resto
            Dim intDig1 As Integer 'armazena o 1º digito verificador
            Dim intDig2 As Integer 'armazena o 2º digito verificador
            Dim strConf As String 'armazena o digito verificador

            lngSoma = 0
            intNumero = 0
            intMais = 0

            If String.IsNullOrEmpty(CPF) Then
                Return True
            End If

            strcampo = Left(CPF, 9)

            'Inicia cálculos do 1º dígito
            For I = 2 To 10
                strCaracter = Right(strcampo, I - 1)
                intNumero = Left(strCaracter, 1)
                intMais = intNumero * I
                lngSoma = lngSoma + intMais
            Next I
            dblDivisao = lngSoma / 11

            lngInteiro = Int(dblDivisao) * 11
            intResto = lngSoma - lngInteiro
            If intResto = 0 Or intResto = 1 Then
                intDig1 = 0
            Else
                intDig1 = 11 - intResto
            End If

            strcampo = strcampo & intDig1 'concatena o CPF com o primeiro digito verificador
            lngSoma = 0
            intNumero = 0
            intMais = 0
            'Inicia cálculos do 2º dígito
            For I = 2 To 11
                strCaracter = Right(strcampo, I - 1)
                intNumero = Left(strCaracter, 1)
                intMais = intNumero * I
                lngSoma = lngSoma + intMais
            Next I
            dblDivisao = lngSoma / 11
            lngInteiro = Int(dblDivisao) * 11
            intResto = lngSoma - lngInteiro
            If intResto = 0 Or intResto = 1 Then
                intDig2 = 0
            Else
                intDig2 = 11 - intResto
            End If
            strConf = intDig1 & intDig2
            'Caso o CPF esteja errado dispara a mensagem
            If strConf <> Right(CPF, 2) Then
                Return False
            Else
                Return True
            End If

        End Function

    End Class

End Namespace

