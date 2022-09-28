Imports ncDados.nsCliente
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCliente

  Public Class pClienteEndereco

    Public Function Listar() As ColecaoClienteEndereco

      Dim retorno As ColecaoClienteEndereco
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dClienteEndereco
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " Select logradouro, numero, complemento, cidade, estado_cid, cep, " & _
            " dataInclusao, tipoResidencia, bairro, tipoEndereco, cliente_cid From clienteenderecos "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoClienteEndereco

              For Each row In dt.Rows
                item = New dClienteEndereco

                item.logradouro = cFuncoes.RetornarTexto(row("logradouro"))
                item.numero = cFuncoes.RetornarInteiro(row("numero"))
                item.complemento = cFuncoes.RetornarTexto(row("complemento"))
                item.cidade = cFuncoes.RetornarTexto(row("cidade"))
                item.estado_cid = cFuncoes.RetornarInteiro(row("estado_cid"))
                item.cep = cFuncoes.RetornarInteiro(row("cep"))
                item.dataInclusao = cFuncoes.RetornarTexto(row("dataInclusao"))
                item.tipoResidencia = cFuncoes.RetornarTexto(row("tipoResidencia"))
                item.bairro = cFuncoes.RetornarTexto(row("bairro"))
                item.tipoEndereco = cFuncoes.RetornarTexto(row("tipoEndereco"))
                item.cliente_cid = cFuncoes.RetornarInteiro(row("cliente_cid"))

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
        Throw New ExcecaoNascomercio("Erro em Listar Cliente - Endereço [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dClienteEndereco) As ColecaoClienteEndereco

      Dim retorno As ColecaoClienteEndereco
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dClienteEndereco
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " SELECT c.logradouro, c.numero, c.complemento, c.cidade, c.estado_cid, c.cep, " & _
            " c.dataInclusao, c.tipoResidencia, c.bairro, c.tipoEndereco, c.cliente_cid, e.sigla "
        sqlWhere = String.Empty
        sqlFrom = " From clienteenderecos c LEFT OUTER JOIN estados e ON c.estado_cid = e.cid "

        '-- logradouro
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.logradouro, "c.logradouro")

        '-- numero
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.numero, "c.numero")

        '-- complemento
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.complemento, "c.complemento")

        '-- cidade
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cidade, "c.cidade")

        '-- estado_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.estado_cid, "c.estado_cid")

        '-- cep
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cep, "c.cep")

        '-- dataInclusao
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.dataInclusao, "c.dataInclusao")

        '-- tipoResidencia
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.tipoResidencia, "c.tipoResidencia")

        '-- bairro
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.bairro, "c.bairro")

        '-- tipoEndereco
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.tipoEndereco, "c.tipoEndereco")

        '-- cliente_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cliente_cid, "c.cliente_cid")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoClienteEndereco

              For Each row In dt.Rows
                item = New dClienteEndereco

                item.logradouro = cFuncoes.RetornarTexto(row("logradouro"))
                item.numero = cFuncoes.RetornarInteiro(row("numero"))
                item.complemento = cFuncoes.RetornarTexto(row("complemento"))
                item.cidade = cFuncoes.RetornarTexto(row("cidade"))
                item.estado_cid = cFuncoes.RetornarInteiro(row("estado_cid"))
                item.cep = cFuncoes.RetornarInteiro(row("cep"))
                item.dataInclusao = cFuncoes.RetornarTexto(row("dataInclusao"))
                item.tipoResidencia = cFuncoes.RetornarTexto(row("tipoResidencia"))
                item.bairro = cFuncoes.RetornarTexto(row("bairro"))
                item.tipoEndereco = cFuncoes.RetornarTexto(row("tipoEndereco"))
                item.cliente_cid = cFuncoes.RetornarInteiro(row("cliente_cid"))
                item.siglaEstado = cFuncoes.RetornarTexto(row("sigla"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar Cliente - Endereço [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dClienteEndereco) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " INSERT INTO " & _
            " clienteenderecos (logradouro, numero, complemento, cidade, estado_cid, cep, " & _
            " dataInclusao, tipoResidencia, bairro, tipoEndereco, cliente_cid) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dados.logradouro) & "," & _
            cFuncoes.PersistirInteiro(dados.numero) & "," & _
            cFuncoes.PersistirTexto(dados.complemento) & "," & _
            cFuncoes.PersistirTexto(dados.cidade) & "," & _
            cFuncoes.PersistirInteiro(dados.estado_cid) & "," & _
            cFuncoes.PersistirInteiro(dados.cep) & "," & _
            cFuncoes.PersistirTexto(dados.dataInclusao) & "," & _
            cFuncoes.PersistirTexto(dados.tipoResidencia) & "," & _
            cFuncoes.PersistirTexto(dados.bairro) & "," & _
            cFuncoes.PersistirTexto(dados.tipoEndereco) & "," & _
            cFuncoes.PersistirInteiro(dados.cliente_cid) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Cliente - Endereço [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function ExcluirPorCliente(ByVal cliente_cid As Integer) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM clienteenderecos " & _
            " WHERE cliente_cid = " & cliente_cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Cliente - Endereço [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ExcluirPorCliente = retorno

    End Function

  End Class

End Namespace
