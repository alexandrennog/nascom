Imports ncDados.nsDashboardCompras
Imports ncPersistencia.nsDashboardCompras
Imports ncComum.nsExcecao

Namespace nsDashboardCompras

    Public Class rDashboardCompras

        Public Function ConsultarResumo(ByVal dataIni As String, ByVal dataFim As String) As dDashboardResumo

            Dim retorno As dDashboardResumo
            Dim persistencia As pDashboardCompras

            Try

                persistencia = New pDashboardCompras
                retorno = persistencia.ConsultarResumo(dataIni, dataFim)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em ConsultarResumo DashboardCompras [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            ConsultarResumo = retorno

        End Function

        Public Function ListarReposicao(ByVal dataIni As String, ByVal dataFim As String) As ColecaoDashboardReposicao

            Dim retorno As ColecaoDashboardReposicao
            Dim persistencia As pDashboardCompras
            Dim retornoPersistencia As ColecaoDashboardReposicao

            Try

                retorno = New ColecaoDashboardReposicao

                persistencia = New pDashboardCompras
                retornoPersistencia = persistencia.ListarReposicao(dataIni, dataFim)

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
                Throw New ExcecaoNascomercio("Erro em ListarReposicao DashboardCompras [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            ListarReposicao = retorno

        End Function

    End Class

End Namespace
