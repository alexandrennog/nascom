Imports ncComum.nsExcecao
Imports ncDados.nsCobranca
Imports ncPersistencia
Imports ncPersistencia.nsCrediario
Namespace nsCobranca
    Public Class rCobranca

        Public Function ConsultarCobrancas(ByVal dados As dCobrancaAutomatica) As ColecaoCobranca

            Dim retorno As ColecaoCobranca
            Dim persistencia As pCobranca
            Dim retornoPersistencia As ColecaoCobranca

            Try

                retorno = New ColecaoCobranca
                persistencia = New pCobranca
                retornoPersistencia = persistencia.ListarCobrancas(dados)

                If Not retornoPersistencia Is Nothing Then
                    If retornoPersistencia.Count > 0 Then
                        retorno.AddRange(retornoPersistencia)
                    Else
                        retorno = Nothing
                    End If
                Else
                    retorno = Nothing
                End If

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Crediario [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function
    End Class
End Namespace
