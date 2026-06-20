Imports LibNF65
Imports LibNF65.Modelo
Imports System.Diagnostics

Namespace nsComum

    Public Class cComum

        Public Function RecuperarConfig() As PixConfig
            Try
                ' Retrieve configuration from the NFCe65 API and return it.
                Return NFCe65.ConsultarConfig()
            Catch ex As Exception
                ' Log the exception for diagnostics and return Nothing to indicate failure.
                Trace.TraceError("cComum.RecuperarConfig error: " & ex.ToString())
                Return Nothing
            End Try
        End Function

    End Class

End Namespace

