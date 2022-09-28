Imports ncDados.nsCliente
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCliente

  Public Class pClienteProfissional

    Public Function Listar() As ColecaoClienteProfissional

      Dim retorno As ColecaoClienteProfissional
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dClienteProfissional
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " Select empresa, logradouro, numero, complemento, cidade, estado_cid, cep, " & _
            " bairro, cliente_cid, ddd, telefone, ramal, dataAdmissao, cargo, salario From clienteprofissional "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoClienteProfissional

              For Each row In dt.Rows
                item = New dClienteProfissional

                item.empresa = cFuncoes.RetornarTexto(row("empresa"))
                item.logradouro = cFuncoes.RetornarTexto(row("logradouro"))
                item.numero = cFuncoes.RetornarInteiro(row("numero"))
                item.complemento = cFuncoes.RetornarTexto(row("complemento"))
                item.cidade = cFuncoes.RetornarTexto(row("cidade"))
                item.estado_cid = cFuncoes.RetornarInteiro(row("estado_cid"))
                item.cep = cFuncoes.RetornarInteiro(row("cep"))
                item.bairro = cFuncoes.RetornarTexto(row("bairro"))
                item.cliente_cid = cFuncoes.RetornarInteiro(row("cliente_cid"))
                item.telefone = cFuncoes.RetornarInteiro(row("telefone"))
                item.ddd = cFuncoes.RetornarInteiro(row("ddd"))
                item.ramal = cFuncoes.RetornarInteiro(row("ramal"))
                item.dataAdmissao = cFuncoes.RetornarTexto(row("dataAdmissao"))
                item.salario = cFuncoes.RetornarDecimal(row("salario"))
                item.cargo = cFuncoes.RetornarInteiro(row("cargo"))

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
        Throw New ExcecaoNascomercio("Erro em Listar Cliente - Profissional [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dClienteProfissional) As ColecaoClienteProfissional

      Dim retorno As ColecaoClienteProfissional
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dClienteProfissional
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select empresa, logradouro, numero, complemento, cidade, estado_cid, cep, " & _
            " bairro, cliente_cid, ddd, telefone, ramal, dataAdmissao, cargo, salario "
        sqlWhere = String.Empty
        sqlFrom = " From clienteprofissional "

        '-- empresa
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.empresa, "empresa")

        '-- logradouro
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.logradouro, "logradouro")

        '-- numero
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.numero, "numero")

        '-- complemento
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.complemento, "complemento")

        '-- cidade
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cidade, "cidade")

        '-- estado_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.estado_cid, "estado_cid")

        '-- cep
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cep, "cep")

        '-- bairro
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.bairro, "bairro")

        '-- cliente_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cliente_cid, "cliente_cid")

        '-- ddd
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.ddd, "ddd")

        '-- telefone
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.telefone, "telefone")

        '-- ramal
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.ramal, "ramal")

        '-- dataAdmissao
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.dataAdmissao, "dataAdmissao")

        '-- salario
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.salario, "salario")

        '-- cargo
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cargo, "cargo")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoClienteProfissional

              For Each row In dt.Rows
                item = New dClienteProfissional

                item.empresa = cFuncoes.RetornarTexto(row("empresa"))
                item.logradouro = cFuncoes.RetornarTexto(row("logradouro"))
                item.numero = cFuncoes.RetornarInteiro(row("numero"))
                item.complemento = cFuncoes.RetornarTexto(row("complemento"))
                item.cidade = cFuncoes.RetornarTexto(row("cidade"))
                item.estado_cid = cFuncoes.RetornarInteiro(row("estado_cid"))
                item.cep = cFuncoes.RetornarInteiro(row("cep"))
                item.bairro = cFuncoes.RetornarTexto(row("bairro"))
                item.cliente_cid = cFuncoes.RetornarInteiro(row("cliente_cid"))
                item.telefone = cFuncoes.RetornarTexto(row("telefone"))
                item.ddd = cFuncoes.RetornarTexto(row("ddd"))
                item.ramal = cFuncoes.RetornarTexto(row("ramal"))
                item.dataAdmissao = cFuncoes.RetornarTexto(row("dataAdmissao"))
                item.salario = cFuncoes.RetornarDecimal(row("salario"))
                item.cargo = cFuncoes.RetornarTexto(row("cargo"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar Cliente - Profissional [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dClienteProfissional) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " INSERT INTO " & _
            " clienteprofissional (empresa, logradouro, numero, complemento, cidade, estado_cid, cep, " & _
            " bairro, cliente_cid, ddd, telefone, ramal, dataAdmissao, cargo, salario) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dados.empresa) & "," & _
            cFuncoes.PersistirTexto(dados.logradouro) & "," & _
            cFuncoes.PersistirInteiro(dados.numero) & "," & _
            cFuncoes.PersistirTexto(dados.complemento) & "," & _
            cFuncoes.PersistirTexto(dados.cidade) & "," & _
            cFuncoes.PersistirInteiro(dados.estado_cid) & "," & _
            cFuncoes.PersistirInteiro(dados.cep) & "," & _
            cFuncoes.PersistirTexto(dados.bairro) & "," & _
            cFuncoes.PersistirInteiro(dados.cliente_cid) & "," & _
            cFuncoes.PersistirTexto(dados.ddd) & "," & _
            cFuncoes.PersistirTexto(dados.telefone) & "," & _
            cFuncoes.PersistirTexto(dados.ramal) & "," & _
            cFuncoes.PersistirData(dados.dataAdmissao) & "," & _
            cFuncoes.PersistirTexto(dados.cargo) & "," & _
            cFuncoes.PersistirDecimal(dados.salario) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Cliente - Profissional [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dClienteProfissional) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " UPDATE clienteprofissional SET " & _
            " empresa = " & cFuncoes.PersistirTexto(dados.empresa) & "," & _
            " logradouro = " & cFuncoes.PersistirTexto(dados.logradouro) & "," & _
            " numero = " & cFuncoes.PersistirInteiro(dados.numero) & "," & _
            " complemento = " & cFuncoes.PersistirTexto(dados.complemento) & "," & _
            " cidade = " & cFuncoes.PersistirTexto(dados.cidade) & "," & _
            " estado_cid = " & cFuncoes.PersistirInteiro(dados.estado_cid) & "," & _
            " cep = " & cFuncoes.PersistirInteiro(dados.cep) & "," & _
            " bairro = " & cFuncoes.PersistirTexto(dados.bairro) & "," & _
            " ddd = " & cFuncoes.PersistirTexto(dados.ddd) & "," & _
            " telefone = " & cFuncoes.PersistirTexto(dados.telefone) & "," & _
            " ramal = " & cFuncoes.PersistirTexto(dados.ramal) & "," & _
            " cargo = " & cFuncoes.PersistirTexto(dados.cargo) & "," & _
            " dataAdmissao = " & cFuncoes.PersistirData(dados.dataAdmissao) & "," & _
            " salario = " & cFuncoes.PersistirDecimal(dados.salario) & _
            " WHERE " & _
            " cliente_cid = " & cFuncoes.PersistirInteiro(dados.cliente_cid)

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Cliente - Profissional [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function ExcluirPorCliente(ByVal cliente_cid As Integer) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM clienteprofissional " & _
            " WHERE cliente_cid = " & cliente_cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Cliente - Profissional [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ExcluirPorCliente = retorno

    End Function

  End Class

End Namespace
