Imports ncComum.nsExcecao
Imports ncDados
Imports ncPersistencia

Public Class rPix

    Public Function fIncluir(ByVal dados As dPix) As Integer

        Dim retorno As Integer
        Dim persistencia As pPix

        Try

            persistencia = New pPix
            'If dados.cid.Value > 0 Then
            'retorno = persistencia.IncluirCid(dados)
            'Else
            retorno = persistencia.Incluir(dados)
            'End If

        Catch ex As Exception

            retorno = Nothing
            Throw New ExcecaoNascomercio("Erro em fIncluir pix [" & Me.ToString() & "] - " & ex.Message)

        End Try

        fIncluir = retorno

    End Function

    Public Function fIncluirConfig(ByVal dados As dPixConfig) As Integer

        Dim retorno As Integer
        Dim persistencia As pPix

        Try

            persistencia = New pPix
            'If dados.cid.Value > 0 Then
            'retorno = persistencia.IncluirCid(dados)
            'Else
            retorno = persistencia.IncluirPixConfig(dados)
            'End If

        Catch ex As Exception

            retorno = Nothing
            Throw New ExcecaoNascomercio("Erro em fIncluir pix [" & Me.ToString() & "] - " & ex.Message)

        End Try

        fIncluirConfig = retorno

    End Function

    Public Function fAlterarConfig(ByVal dados As dPixConfig) As Integer

        Dim retorno As Integer
        Dim persistencia As pPix

        Try

            persistencia = New pPix
            'If dados.cid.Value > 0 Then
            'retorno = persistencia.IncluirCid(dados)
            'Else
            retorno = persistencia.AlterarPixConfig(dados)
            'End If

        Catch ex As Exception

            retorno = Nothing
            Throw New ExcecaoNascomercio("Erro em fAlterarConfig[" & Me.ToString() & "] - " & ex.Message)

        End Try

        fAlterarConfig = retorno

    End Function
    Public Function AlterarPix(ByVal dados As dPix) As Integer

        Dim retorno As Integer
        Dim persistencia As pPix

        Try

            persistencia = New pPix
            'If dados.cid.Value > 0 Then
            'retorno = persistencia.IncluirCid(dados)
            'Else
            retorno = persistencia.AlterarPix(dados)
            'End If

        Catch ex As Exception

            retorno = Nothing
            Throw New ExcecaoNascomercio("Erro em fAlterarConfig[" & Me.ToString() & "] - " & ex.Message)

        End Try

        AlterarPix = retorno

    End Function


    Public Function fConsultar(tx As String) As dPix

        Dim retorno As dPix
        Dim persistencia As pPix
        Dim retornoPersistencia As dPix

        Try

            retorno = New dPix

            persistencia = New pPix
            retornoPersistencia = persistencia.Consultar(tx)
            retorno = retornoPersistencia

        Catch ex As Exception

            retorno = Nothing
            Throw New ExcecaoNascomercio("Erro em fConsultar Pix [" & Me.ToString() & "] - " & ex.Message)

        End Try

        fConsultar = retorno

    End Function

    Public Function fConsultarConfig() As dPixConfig

        Dim retorno As dPixConfig
        Dim persistencia As pPix
        Dim retornoPersistencia As dPixConfig

        Try

            retorno = New dPixConfig

            persistencia = New pPix
            retornoPersistencia = persistencia.ConsultarConfig()
            retorno = retornoPersistencia

        Catch ex As Exception

            retorno = Nothing
            Throw New ExcecaoNascomercio("Erro em fConsultar Pix [" & Me.ToString() & "] - " & ex.Message)

        End Try

        fConsultarConfig = retorno

    End Function
    Public Function fConsultar(ByVal dados As dPix) As ColecaoPix

        Dim retorno As dPix
        Dim persistencia As pPix
        Dim retornoPersistencia As ColecaoPix

        Try

            retorno = New dPix

            persistencia = New pPix
            retornoPersistencia = persistencia.Consultar(dados)

        Catch ex As Exception

            retorno = Nothing
            Throw New ExcecaoNascomercio("Erro em fConsultar Pix [" & Me.ToString() & "] - " & ex.Message)

        End Try

        fConsultar = retornoPersistencia

    End Function

    Public Function Consultar(tx As String) As dPix

        Dim retorno As dPix

        Try

            retorno = fConsultar(tx)

        Catch ex As Exception

            retorno = Nothing
            Throw New ExcecaoNascomercio("Erro em Consultar Pix [" & Me.ToString() & "] - " & ex.Message)

        End Try

        Consultar = retorno

    End Function
    Public Function Consultar(ByVal dados As dPix) As ColecaoPix

        Dim retorno As ColecaoPix
        Try

            retorno = fConsultar(dados)


        Catch ex As Exception

            retorno = Nothing
            Throw New ExcecaoNascomercio("Erro em Consultar Pix [" & Me.ToString() & "] - " & ex.Message)

        End Try

        Consultar = retorno

    End Function
End Class
