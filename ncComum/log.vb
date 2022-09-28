Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsLog

  Public Class cLog

    Public Shared Sub GravarLog(ByVal usuario As String, ByVal descricao As String)

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String
      Dim dataHora As DateTime
      Dim dataHoraFormatada As String

      Try

        acessoBanco = New cAcessoBD

        dataHora = Now()
        dataHoraFormatada = dataHora.Year.ToString().PadLeft(4, "0"c) & "-" & _
                            dataHora.Month.ToString().PadLeft(2, "0"c) & "-" & _
                            dataHora.Day.ToString().PadLeft(2, "0"c) & " " & _
                            dataHora.Hour.ToString().PadLeft(2, "0"c) & ":" & _
                            dataHora.Minute.ToString().PadLeft(2, "0"c) & ":" & _
                            dataHora.Second.ToString().PadLeft(2, "0"c)

        comandoSQL = " INSERT INTO " & _
            " log ( data, descricao, usuario ) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dataHoraFormatada) & "," & _
            cFuncoes.PersistirTexto(descricao) & "," & _
            cFuncoes.PersistirTexto(usuario) & ")"

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception



      End Try

    End Sub

    Public Shared Sub GravarLogTransferencia(ByVal origemCID As Integer, ByVal origemRazao As String, _
        ByVal destinoCID As Integer, ByVal destinoRazao As String, ByVal usuarioCID As Integer, ByVal usuarioNome As String, _
        ByVal produtoCID As Integer, ByVal codigoBarras As String, ByVal quantidade As Integer)

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String
      Dim dataHora As DateTime
      Dim dataHoraFormatada As String

      Try

        acessoBanco = New cAcessoBD

        dataHora = Now()
        dataHoraFormatada = dataHora.Year.ToString().PadLeft(4, "0"c) & "-" & _
                            dataHora.Month.ToString().PadLeft(2, "0"c) & "-" & _
                            dataHora.Day.ToString().PadLeft(2, "0"c) & " " & _
                            dataHora.Hour.ToString().PadLeft(2, "0"c) & ":" & _
                            dataHora.Minute.ToString().PadLeft(2, "0"c) & ":" & _
                            dataHora.Second.ToString().PadLeft(2, "0"c)

        comandoSQL = " INSERT INTO " & _
            " logtransferencia ( data, usuario_cid, usuario_nomeCompleto, lojaOrigem_cid, lojaOrigem_razaoSocial, " & _
            " lojaDestino_cid, lojaDestino_razaoSocial, produto_cid, produtoItem_codigoBarras, quantidade ) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dataHoraFormatada) & "," & _
            cFuncoes.PersistirInteiro(usuarioCID) & "," & _
            cFuncoes.PersistirTexto(usuarioNome) & "," & _
            cFuncoes.PersistirInteiro(origemCID) & "," & _
            cFuncoes.PersistirTexto(origemRazao) & "," & _
            cFuncoes.PersistirInteiro(destinoCID) & "," & _
            cFuncoes.PersistirTexto(destinoRazao) & "," & _
            cFuncoes.PersistirInteiro(produtoCID) & "," & _
            cFuncoes.PersistirTexto(codigoBarras) & "," & _
            cFuncoes.PersistirInteiro(quantidade) & ")"

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

      End Try

    End Sub

    Public Shared Sub GravarLogEstoque(ByVal usuarioCID As Integer, ByVal usuarioNome As String, _
        ByVal produtoCID As Integer, ByVal codigoBarras As String, ByVal quantidade As Integer, _
        ByVal notaFiscalNumero As String, ByVal notaFiscalSerie As String)

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String
      Dim dataHora As DateTime
      Dim dataHoraFormatada As String

      Try

        acessoBanco = New cAcessoBD

        dataHora = Now()
        dataHoraFormatada = dataHora.Year.ToString().PadLeft(4, "0"c) & "-" & _
                            dataHora.Month.ToString().PadLeft(2, "0"c) & "-" & _
                            dataHora.Day.ToString().PadLeft(2, "0"c) & " " & _
                            dataHora.Hour.ToString().PadLeft(2, "0"c) & ":" & _
                            dataHora.Minute.ToString().PadLeft(2, "0"c) & ":" & _
                            dataHora.Second.ToString().PadLeft(2, "0"c)

        comandoSQL = " INSERT INTO " & _
            " logestoque ( data, usuario_cid, usuario_nomeCompleto, " & _
            " produto_cid, produtoItem_codigoBarras, quantidade, impressao, notaFiscalNumero, notaFiscalSerie ) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dataHoraFormatada) & "," & _
            cFuncoes.PersistirInteiro(usuarioCID) & "," & _
            cFuncoes.PersistirTexto(usuarioNome) & "," & _
            cFuncoes.PersistirInteiro(produtoCID) & "," & _
            cFuncoes.PersistirTexto(codigoBarras) & "," & _
            cFuncoes.PersistirInteiro(quantidade) & ",null," & _
            cFuncoes.PersistirTexto(notaFiscalNumero) & "," & _
            cFuncoes.PersistirTexto(notaFiscalSerie) & ")"

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

      End Try

    End Sub

    Public Shared Sub GravarLogBalanco(ByVal usuarioCID As Integer, ByVal usuarioNome As String, _
        ByVal produtoCID As Integer, ByVal codigoBarras As String, _
        ByVal quantidadeEstoque As Integer, ByVal quantidadeAtualizacao As Integer)

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String
      Dim dataHora As DateTime
      Dim dataHoraFormatada As String

      Try

        acessoBanco = New cAcessoBD

        dataHora = Now()
        dataHoraFormatada = dataHora.Year.ToString().PadLeft(4, "0"c) & "-" & _
                            dataHora.Month.ToString().PadLeft(2, "0"c) & "-" & _
                            dataHora.Day.ToString().PadLeft(2, "0"c) & " " & _
                            dataHora.Hour.ToString().PadLeft(2, "0"c) & ":" & _
                            dataHora.Minute.ToString().PadLeft(2, "0"c) & ":" & _
                            dataHora.Second.ToString().PadLeft(2, "0"c)

        comandoSQL = " INSERT INTO " & _
            " logbalanco ( usuario_cid, usuario_nomeCompleto, " & _
            " produto_cid, produtoItem_codigoBarras, data, " & _
            " quantidadeEstoque, quantidadeAtualizacao ) " & _
            " VALUES (" & _
            cFuncoes.PersistirInteiro(usuarioCID) & "," & _
            cFuncoes.PersistirTexto(usuarioNome) & "," & _
            cFuncoes.PersistirInteiro(produtoCID) & "," & _
            cFuncoes.PersistirTexto(codigoBarras) & "," & _
            cFuncoes.PersistirData(dataHoraFormatada) & "," & _
            cFuncoes.PersistirInteiro(quantidadeEstoque) & "," & _
            cFuncoes.PersistirInteiro(quantidadeAtualizacao) & ")"

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

      End Try

    End Sub

  End Class

End Namespace
