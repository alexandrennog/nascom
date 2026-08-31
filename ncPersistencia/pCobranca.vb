Imports ncComum.nsAcessoBD
Imports ncComum.nsExcecao
Imports ncComum.nsFuncoes
Imports ncDados.nsCobranca

Public Class pCobranca
    Public Function ListarCobrancas(ByVal dados As dCobrancaAutomatica) As ColecaoCobranca

        Dim retorno As ColecaoCobranca
        Dim acessoBanco As cAcessoBD
        Dim ds As DataSet
        Dim dt As DataTable
        Dim row As DataRow
        Dim item As dCobrancaAutomatica
        Dim comandoSQL As String

        Try
            acessoBanco = New cAcessoBD
            comandoSQL = " SELECT codigocliente, crediarioid, parcelaidid, valor, nome,  " &
                         " dddcel, celular, sucesso, pix_code, data_cobranca, datavencimento   " &
                         " FROM cobrancas_automaticas WHERE data_cobranca = '" + dados.DataCobranca.ToString("yyyy-MM-dd") + "'"
            ds = acessoBanco.ExecutarDS(comandoSQL)

            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    dt = ds.Tables(0)

                    If dt.Rows.Count > 0 Then
                        retorno = New ColecaoCobranca

                        For Each row In dt.Rows
                            item = New dCobrancaAutomatica

                            item.CodigoCliente = cFuncoes.RetornarInteiro(row("codigocliente"))
                            item.CrediarioId = cFuncoes.RetornarInteiro(row("crediarioid"))
                            item.ParcelaIdId = cFuncoes.RetornarInteiro(row("parcelaidid"))
                            item.Valor = cFuncoes.RetornarDecimal(row("valor"))
                            item.Nome = cFuncoes.RetornarTexto(row("nome"))
                            item.DDDCel = cFuncoes.RetornarTexto(row("dddcel"))
                            item.Celular = cFuncoes.RetornarTexto(row("celular"))
                            item.Sucesso = cFuncoes.RetornarTexto(row("sucesso"))
                            item.PixCode = cFuncoes.RetornarTexto(row("pix_code"))
                            item.DataCobranca = cFuncoes.RetornarData(row("data_cobranca"))
                            item.DataVencimento = cFuncoes.RetornarData(row("datavencimento"))

                            retorno.Add(item)
                        Next
                    Else
                        retorno = Nothing
                    End If
                Else
                    retorno = Nothing
                End If
            Else
                retorno = Nothing
            End If

        Catch ex As Exception

            retorno = Nothing
            Throw New ExcecaoNascomercio("Erro em Listar Cobranças [" & Me.ToString() & "] - " & ex.Message, ex)

        End Try

        ListarCobrancas = retorno

    End Function
End Class
