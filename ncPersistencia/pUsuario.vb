Imports ncDados.nsUsuario
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsUsuario

  Public Class pUsuario

    Public Function Listar() As colecaoUsuario

      Dim retorno As colecaoUsuario
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dUsuario
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


                comandoSQL = " Select cid, nomeCompleto, senha, situacao, usuario, descontoProduto, descontoPedido, " & _
                    " comissao From usuarios where situacao like 'A'"

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoUsuario

              For Each row In dt.Rows
                item = New dUsuario

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.nomeCompleto = cFuncoes.RetornarTexto(row("nomeCompleto"))
                item.senha = cFuncoes.RetornarTexto(row("senha"))
                item.situacao = cFuncoes.RetornarTexto(row("situacao"))
                item.usuario = cFuncoes.RetornarTexto(row("usuario"))
                item.descontoProduto = cFuncoes.RetornarDecimal(row("descontoProduto"))
                item.descontoPedido = cFuncoes.RetornarDecimal(row("descontoPedido"))
                item.comissao = cFuncoes.RetornarDecimal(row("comissao"))

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
        Throw New ExcecaoNascomercio("Erro em Listar Usuario [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dUsuario) As ColecaoUsuario

      Dim retorno As ColecaoUsuario
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dUsuario
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD

        sqlSelect = " Select u.cid, u.nomeCompleto, u.senha, u.situacao, u.usuario, u.usuarioPerfil_cid, " & _
            " up.codigo, u.descontoPedido, u.descontoProduto, u.comissao "
        sqlWhere = String.Empty
        sqlFrom = " From usuarios u INNER JOIN usuarioperfil up " & _
            " ON up.cid = u.usuarioPerfil_cid "

        '-- cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "u.cid")

        '-- usuario
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.usuario, "u.usuario")

        '-- senha
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.senha, "u.senha")

        '-- situacao
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.situacao, "u.situacao")

        '-- nomeCompleto
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.nomeCompleto, "u.nomeCompleto")

        '-- usuarioPerfil_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.usuarioPerfil_cid, "u.usuarioPerfil_cid")

        '-- descontoProduto
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.descontoProduto, "u.descontoProduto")

        '-- descontoPedido
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.descontoPedido, "u.descontoPedido")

        '-- comissao
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.comissao, "u.comissao")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoUsuario

              For Each row In dt.Rows
                item = New dUsuario

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.nomeCompleto = cFuncoes.RetornarTexto(row("nomeCompleto"))
                item.senha = cFuncoes.RetornarTexto(row("senha"))
                item.situacao = cFuncoes.RetornarTexto(row("situacao"))
                item.usuario = cFuncoes.RetornarTexto(row("usuario"))
                item.usuarioPerfil_cid = cFuncoes.RetornarInteiro(row("usuarioPerfil_cid"))
                item.usuarioPerfil_codigo = cFuncoes.RetornarTexto(row("codigo"))
                item.descontoProduto = cFuncoes.RetornarDecimal(row("descontoProduto"))
                item.descontoPedido = cFuncoes.RetornarDecimal(row("descontoPedido"))
                item.comissao = cFuncoes.RetornarDecimal(row("comissao"))

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
        Throw ex
        Throw New ExcecaoNascomercio("Erro em Consultar Usuario [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dUsuario) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String


      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " usuarios (usuario, senha, nomeCompleto, situacao, descontoProduto, descontoPedido, " & _
            " comissao, usuarioPerfil_cid) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dados.usuario) & "," & _
            cFuncoes.PersistirTexto(dados.senha) & "," & _
            cFuncoes.PersistirTexto(dados.nomeCompleto) & "," & _
            cFuncoes.PersistirTexto(dados.situacao) & "," & _
            cFuncoes.PersistirDecimal(dados.descontoProduto) & "," & _
            cFuncoes.PersistirDecimal(dados.descontoPedido) & "," & _
            cFuncoes.PersistirDecimal(dados.comissao) & "," & _
            cFuncoes.PersistirInteiro(dados.usuarioPerfil_cid) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Usuario [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dUsuario) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String


      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " UPDATE usuarios SET " & _
            " usuario = " & cFuncoes.PersistirTexto(dados.usuario) & "," & _
            " senha = " & cFuncoes.PersistirTexto(dados.senha) & "," & _
            " nomeCompleto = " & cFuncoes.PersistirTexto(dados.nomeCompleto) & "," & _
            " situacao = " & cFuncoes.PersistirTexto(dados.situacao) & "," & _
            " descontoProduto = " & cFuncoes.PersistirDecimal(dados.descontoProduto) & "," & _
            " descontoPedido = " & cFuncoes.PersistirDecimal(dados.descontoPedido) & "," & _
            " comissao = " & cFuncoes.PersistirDecimal(dados.comissao) & "," & _
            " usuarioPerfil_cid = " & cFuncoes.PersistirInteiro(dados.usuarioPerfil_cid) & _
            " WHERE " & _
            " cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Usuario [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dUsuario) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM usuarios " & _
            " WHERE cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Usuario [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
