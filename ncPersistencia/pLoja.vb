Imports ncDados.nsLoja
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsLoja

  Public Class pLoja

    Public Function Listar() As ColecaoLoja

      Dim retorno As ColecaoLoja
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dLoja
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

                comandoSQL = " Select cid, nomeFantasia, logradouro, numero, complemento, bairro, cidade, estado_cid, " &
            " cep, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao, razaoSocial, " &
            " spc_codigo_associado, spc_controle_informante, spc_nome_informante, inscestadual From lojas"

                ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoLoja

              For Each row In dt.Rows
                item = New dLoja

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.codigo = cFuncoes.RetornarTexto(row("codigo"))
                item.nomeFantasia = cFuncoes.RetornarTexto(row("nomeFantasia"))
                item.razaoSocial = cFuncoes.RetornarTexto(row("razaoSocial"))
                item.nomeContato = cFuncoes.RetornarTexto(row("nomeContato"))
                item.cnpj = cFuncoes.RetornarTexto(row("cnpj"))
                item.logradouro = cFuncoes.RetornarTexto(row("logradouro"))
                item.numero = cFuncoes.RetornarInteiro(row("numero"))
                item.complemento = cFuncoes.RetornarTexto(row("complemento"))
                item.bairro = cFuncoes.RetornarTexto(row("bairro"))
                item.cidade = cFuncoes.RetornarTexto(row("cidade"))
                item.estado_cid = cFuncoes.RetornarInteiro(row("estado_cid"))
                item.cep = cFuncoes.RetornarInteiro(row("cep"))
                item.ddd = cFuncoes.RetornarInteiro(row("ddd"))
                item.telefone = cFuncoes.RetornarInteiro(row("telefone"))
                item.ramal = cFuncoes.RetornarInteiro(row("ramal"))
                item.situacao = cFuncoes.RetornarTexto(row("situacao"))
                item.spc_codigo_associado = cFuncoes.RetornarTexto(row("spc_codigo_associado"))
                item.spc_controle_informante = cFuncoes.RetornarTexto(row("spc_controle_informante"))
                                item.spc_nome_informante = cFuncoes.RetornarTexto(row("spc_nome_informante"))
                                item.Inscestadual = cFuncoes.RetornarTexto(row("inscestadual"))

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
        Throw New ExcecaoNascomercio("Erro em Listar Lojas [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dLoja) As ColecaoLoja

      Dim retorno As ColecaoLoja
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dLoja
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD

        sqlSelect = " Select cid, nomeFantasia, logradouro, numero, complemento, bairro, cidade, estado_cid, " & _
            " cep, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao, razaoSocial, " & _
            " spc_codigo_associado, spc_controle_informante, spc_nome_informante "
        sqlWhere = String.Empty
        sqlFrom = " From lojas "

        '-- cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")

        '-- codigo
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.codigo, "codigo")

        '-- nomeFantasia
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.nomeFantasia, "nomeFantasia")

        '-- logradouro
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.logradouro, "logradouro")

        '-- numero
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.numero, "numero")

        '-- complemento
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.complemento, "complemento")

        '-- bairro
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.bairro, "bairro")

        '-- cidade
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cidade, "cidade")

        '-- estado_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.estado_cid, "estado_cid")

        '-- cep
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cep, "cep")

        '-- razaoSocial
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.razaoSocial, "razaoSocial")

        '-- cnpj
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cnpj, "cnpj")

        '-- ddd
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.ddd, "ddd")

        '-- telefone
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.telefone, "telefone")

        '-- ramal
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.ramal, "ramal")

        '-- nomecontato
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.nomeContato, "nomeContato")

        '-- situacao
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.situacao, "situacao")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoLoja

              For Each row In dt.Rows
                item = New dLoja

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.codigo = cFuncoes.RetornarTexto(row("codigo"))
                item.nomeFantasia = cFuncoes.RetornarTexto(row("nomeFantasia"))
                item.logradouro = cFuncoes.RetornarTexto(row("logradouro"))
                item.numero = cFuncoes.RetornarInteiro(row("numero"))
                item.complemento = cFuncoes.RetornarTexto(row("complemento"))
                item.bairro = cFuncoes.RetornarTexto(row("bairro"))
                item.cidade = cFuncoes.RetornarTexto(row("cidade"))
                item.estado_cid = cFuncoes.RetornarInteiro(row("estado_cid"))
                item.cep = cFuncoes.RetornarInteiro(row("cep"))
                item.razaoSocial = cFuncoes.RetornarTexto(row("razaoSocial"))
                item.cnpj = cFuncoes.RetornarTexto(row("cnpj"))
                item.ddd = cFuncoes.RetornarInteiro(row("ddd"))
                item.telefone = cFuncoes.RetornarInteiro(row("telefone"))
                item.ramal = cFuncoes.RetornarInteiro(row("ramal"))
                item.nomeContato = cFuncoes.RetornarTexto(row("nomeContato"))
                item.spc_codigo_associado = cFuncoes.RetornarTexto(row("spc_codigo_associado"))
                item.spc_controle_informante = cFuncoes.RetornarTexto(row("spc_controle_informante"))
                item.spc_nome_informante = cFuncoes.RetornarTexto(row("spc_nome_informante"))
                item.situacao = cFuncoes.RetornarTexto(row("situacao"))

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
        Throw New ExcecaoNascomercio("Erro ao Consultar Loja [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dLoja) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " INSERT INTO " & _
            " lojas ( nomeFantasia, logradouro, numero, complemento, bairro, cidade, estado_cid, " & _
            " cep, razaoSocial, cnpj, ddd, telefone, ramal, nomeContato, codigo, " & _
            " spc_codigo_associado, spc_controle_informante, spc_nome_informante, situacao ) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dados.nomeFantasia) & "," & _
            cFuncoes.PersistirTexto(dados.logradouro) & "," & _
            cFuncoes.PersistirInteiro(dados.numero) & "," & _
            cFuncoes.PersistirTexto(dados.complemento) & "," & _
            cFuncoes.PersistirTexto(dados.bairro) & "," & _
            cFuncoes.PersistirTexto(dados.cidade) & "," & _
            cFuncoes.PersistirInteiro(dados.estado_cid) & "," & _
            cFuncoes.PersistirInteiro(dados.cep) & "," & _
            cFuncoes.PersistirTexto(dados.razaoSocial) & "," & _
            cFuncoes.PersistirTexto(dados.cnpj) & "," & _
            cFuncoes.PersistirInteiro(dados.ddd) & "," & _
            cFuncoes.PersistirInteiro(dados.telefone) & "," & _
            cFuncoes.PersistirInteiro(dados.ramal) & "," & _
            cFuncoes.PersistirTexto(dados.nomeContato) & "," & _
            cFuncoes.PersistirTexto(dados.codigo) & "," & _
            cFuncoes.PersistirTexto(dados.spc_codigo_associado) & "," & _
            cFuncoes.PersistirTexto(dados.spc_controle_informante) & "," & _
            cFuncoes.PersistirTexto(dados.spc_nome_informante) & "," & _
            cFuncoes.PersistirTexto(dados.situacao) & ")"

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Loja [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dLoja) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " UPDATE lojas SET " & _
            " nomeFantasia = " & cFuncoes.PersistirTexto(dados.nomeFantasia) & "," & _
            " logradouro = " & cFuncoes.PersistirTexto(dados.logradouro) & "," & _
            " numero = " & cFuncoes.PersistirInteiro(dados.numero) & "," & _
            " complemento = " & cFuncoes.PersistirTexto(dados.complemento) & "," & _
            " bairro = " & cFuncoes.PersistirTexto(dados.bairro) & "," & _
            " cidade = " & cFuncoes.PersistirTexto(dados.cidade) & "," & _
            " estado_cid = " & cFuncoes.PersistirInteiro(dados.estado_cid) & "," & _
            " cep = " & cFuncoes.PersistirInteiro(dados.cep) & "," & _
            " razaoSocial = " & cFuncoes.PersistirTexto(dados.razaoSocial) & "," & _
            " cnpj = " & cFuncoes.PersistirTexto(dados.cnpj) & "," & _
            " ddd = " & cFuncoes.PersistirInteiro(dados.ddd) & "," & _
            " telefone = " & cFuncoes.PersistirInteiro(dados.telefone) & "," & _
            " ramal = " & cFuncoes.PersistirInteiro(dados.ramal) & "," & _
            " nomeContato = " & cFuncoes.PersistirTexto(dados.nomeContato) & "," & _
            " spc_codigo_associado = " & cFuncoes.PersistirTexto(dados.spc_codigo_associado) & "," & _
            " spc_controle_informante = " & cFuncoes.PersistirTexto(dados.spc_controle_informante) & "," & _
            " spc_nome_informante = " & cFuncoes.PersistirTexto(dados.spc_nome_informante) & "," & _
            " codigo = " & cFuncoes.PersistirTexto(dados.codigo) & "," & _
            " situacao = " & cFuncoes.PersistirTexto(dados.situacao) & _
            " WHERE " & _
            " cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Loja [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dLoja) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM lojas " & _
            " WHERE " & _
            " cid = " & cFuncoes.PersistirInteiro(dados.cid)

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Loja [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
