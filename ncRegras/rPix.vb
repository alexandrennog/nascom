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

    Public Function fConsultar(ByVal dados As dPix) As ColecaoPix

        Dim retorno As ColecaoPix
        Dim persistencia As pPix
        Dim retornoPersistencia As ColecaoPix

        Try

            retorno = New ColecaoPix

            persistencia = New pPix
            retornoPersistencia = persistencia.Consultar(dados)

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
            Throw New ExcecaoNascomercio("Erro em fConsultar Pix [" & Me.ToString() & "] - " & ex.Message)

        End Try

        fConsultar = retorno

    End Function

    Public Function Consultar(ByVal txId As String) As ColecaoPix

        Dim retorno As ColecaoPix

        Try
            Dim dados As New dPix
            dados.TxId = txId

            retorno = fConsultar(dados)

        Catch ex As Exception

            retorno = Nothing
            Throw New ExcecaoNascomercio("Erro em Consultar Pix [" & Me.ToString() & "] - " & ex.Message)

        End Try

        Consultar = retorno

    End Function
End Class
