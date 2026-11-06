Imports ncDados
Imports ncPersistencia
Imports ncComum.nsExcecao

Public Class rPixConfig
    Public Function fIncluir(ByVal dados As dPixConfig) As Integer

        Dim retorno As Integer
        Dim persistencia As pPix

        Try

            persistencia = New pPix
            retorno = persistencia.IncluirPixConfig(dados)

        Catch ex As Exception

            retorno = Nothing
            Throw New ExcecaoNascomercio("Erro em fIncluir pix [" & Me.ToString() & "] - " & ex.Message, ex)

        End Try

        fIncluir = retorno

    End Function

    Public Function fConsultar() As dPixConfig

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
            Throw New ExcecaoNascomercio("Erro em fConsultar Pix [" & Me.ToString() & "] - " & ex.Message, ex)

        End Try

        fConsultar = retorno

    End Function



End Class
