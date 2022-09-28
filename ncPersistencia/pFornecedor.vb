Imports ncDados.nsFornecedor
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Namespace nsFornecedor

  Public Class pFornecedor

    Public Function Listar() As ColecaoFornecedor

      Dim retorno As ColecaoFornecedor
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dFornecedor
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select cid, nome, logradouro, numero, complemento, bairro, cidade_cid, estado_cid, " & _
            " cep, inscricaoEstadual, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao From fornecedores " & _
            " order by nome "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoFornecedor

              For Each row In dt.Rows
                item = New dFornecedor

                item.cid = RetornarInteiro(row("cid"))
                item.codigo = RetornarTexto(row("codigo"))
                item.nome = RetornarTexto(row("nome"))
                item.logradouro = RetornarTexto(row("logradouro"))
                item.numero = RetornarInteiro(row("numero"))
                item.complemento = RetornarTexto(row("complemento"))
                item.bairro = RetornarTexto(row("bairro"))
                item.cidade_cid = RetornarInteiro(row("cidade_cid"))
                item.estado_cid = RetornarInteiro(row("estado_cid"))
                item.cep = RetornarInteiro(row("cep"))
                item.inscricaoEstadual = RetornarTexto(row("inscricaoEstadual"))
                item.cnpj = RetornarTexto(row("cnpj"))
                item.ddd = RetornarInteiro(row("ddd"))
                item.telefone = RetornarTexto(row("telefone"))
                item.ramal = RetornarInteiro(row("ramal"))
                item.nomeContato = RetornarTexto(row("nomeContato"))
                item.situacao = RetornarTexto(row("situacao"))

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
        Throw New ExcecaoNascomercio("Erro em Listar Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dFornecedor) As ColecaoFornecedor

      Dim retorno As ColecaoFornecedor
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dFornecedor
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select cid, nome, logradouro, numero, complemento, bairro, cidade_cid, estado_cid, " & _
            " cep, inscricaoEstadual, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao "
        sqlWhere = String.Empty
        sqlFrom = " From fornecedores "

        '-- cid
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid")

        '-- codigo
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.codigo, "codigo")

        '-- nome
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.nome, "nome")

        '-- logradouro
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.logradouro, "logradouro")

        '-- numero
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.numero, "numero")

        '-- complemento
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.complemento, "complemento")

        '-- bairro
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.bairro, "bairro")

        '-- cidade
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.cidade_cid, "cidade_cid")

        '-- estado_cid
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.estado_cid, "estado_cid")

        '-- cep
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.cep, "cep")

        '-- inscricaoestadual
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.inscricaoEstadual, "inscricaoEstadual")

        '-- cnpj
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.cnpj, "cnpj")

        '-- ddd
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.ddd, "ddd")

        '-- telefone
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.telefone, "telefone")

        '-- ramal
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.ramal, "ramal")

        '-- nomecontato
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.nomeContato, "nomeContato")

        '-- situacao
        sqlWhere = MontarParametrosSQL(sqlWhere, dados.situacao, "situacao")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoFornecedor

              For Each row In dt.Rows
                item = New dFornecedor

                item.cid = RetornarInteiro(row("cid"))
                item.codigo = RetornarTexto(row("codigo"))
                item.nome = RetornarTexto(row("nome"))
                item.logradouro = RetornarTexto(row("logradouro"))
                item.numero = RetornarInteiro(row("numero"))
                item.complemento = RetornarTexto(row("complemento"))
                item.bairro = RetornarTexto(row("bairro"))
                item.cidade_cid = RetornarInteiro(row("cidade_cid"))
                item.estado_cid = RetornarInteiro(row("estado_cid"))
                item.cep = RetornarInteiro(row("cep"))
                item.inscricaoEstadual = RetornarTexto(row("inscricaoEstadual"))
                item.cnpj = RetornarTexto(row("cnpj"))
                item.ddd = RetornarInteiro(row("ddd"))
                item.telefone = RetornarTexto(row("telefone"))
                item.ramal = RetornarInteiro(row("ramal"))
                item.nomeContato = RetornarTexto(row("nomeContato"))
                item.situacao = RetornarTexto(row("situacao"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dFornecedor) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " fornecedores ( nome, logradouro, numero, complemento, bairro, cidade_cid, estado_cid, " & _
            " cep, inscricaoEstadual, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao ) " & _
            " VALUES (" & _
            PersistirTexto(dados.nome) & "," & _
            PersistirTexto(dados.logradouro) & "," & _
            PersistirInteiro(dados.numero) & "," & _
            PersistirTexto(dados.complemento) & "," & _
            PersistirTexto(dados.bairro) & "," & _
            PersistirInteiro(dados.cidade_cid) & "," & _
            PersistirInteiro(dados.estado_cid) & "," & _
            PersistirInteiro(dados.cep) & "," & _
            PersistirTexto(dados.inscricaoEstadual) & "," & _
            PersistirTexto(dados.cnpj) & "," & _
            PersistirInteiro(dados.ddd) & "," & _
            PersistirTexto(dados.telefone) & "," & _
            PersistirInteiro(dados.ramal) & "," & _
            PersistirTexto(dados.nomeContato) & "," & _
            PersistirTexto(dados.codigo) & "," & _
            PersistirTexto(dados.situacao) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Importar(ByVal dados As dFornecedor) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " INSERT INTO " & _
            " fornecedores ( cid, nome, logradouro, numero, complemento, bairro, cidade_cid, estado_cid, " & _
            " cep, inscricaoEstadual, cnpj, ddd, telefone, ramal, nomeContato, codigo, situacao ) " & _
            " VALUES (" & _
            PersistirInteiro(dados.cid) & "," & _
            PersistirTexto(dados.nome) & "," & _
            PersistirTexto(dados.logradouro) & "," & _
            PersistirInteiro(dados.numero) & "," & _
            PersistirTexto(dados.complemento) & "," & _
            PersistirTexto(dados.bairro) & "," & _
            PersistirInteiro(dados.cidade_cid) & "," & _
            PersistirInteiro(dados.estado_cid) & "," & _
            PersistirInteiro(dados.cep) & "," & _
            PersistirTexto(dados.inscricaoEstadual) & "," & _
            PersistirTexto(dados.cnpj) & "," & _
            PersistirInteiro(dados.ddd) & "," & _
            PersistirTexto(dados.telefone) & "," & _
            PersistirInteiro(dados.ramal) & "," & _
            PersistirTexto(dados.nomeContato) & "," & _
            PersistirTexto(dados.codigo) & "," & _
            PersistirTexto(dados.situacao) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Importar Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Importar = retorno

    End Function

    Public Function Alterar(ByVal dados As dFornecedor) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " UPDATE fornecedores SET " & _
            " nome = " & PersistirTexto(dados.nome) & "," & _
            " logradouro = " & PersistirTexto(dados.logradouro) & "," & _
            " numero = " & PersistirInteiro(dados.numero) & "," & _
            " complemento = " & PersistirTexto(dados.complemento) & "," & _
            " bairro = " & PersistirTexto(dados.bairro) & "," & _
            " cidade_cid = " & PersistirInteiro(dados.cidade_cid) & "," & _
            " estado_cid = " & PersistirInteiro(dados.estado_cid) & "," & _
            " cep = " & PersistirInteiro(dados.cep) & "," & _
            " inscricaoEstadual = " & PersistirTexto(dados.inscricaoEstadual) & "," & _
            " cnpj = " & PersistirTexto(dados.cnpj) & "," & _
            " ddd = " & PersistirInteiro(dados.ddd) & "," & _
            " telefone = " & PersistirTexto(dados.telefone) & "," & _
            " ramal = " & PersistirInteiro(dados.ramal) & "," & _
            " nomeContato = " & PersistirTexto(dados.nomeContato) & "," & _
            " codigo = " & PersistirTexto(dados.codigo) & "," & _
            " situacao = " & PersistirTexto(dados.situacao) & _
            " WHERE " & _
            " cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dFornecedor) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM fornecedores " & _
            " WHERE cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Fornecedor [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
