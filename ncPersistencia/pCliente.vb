Imports ncDados.nsCliente
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCliente

    Public Class pCliente

        Public Function Listar() As ColecaoCliente

            Dim retorno As ColecaoCliente
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dCliente
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " Select cid, nome, estadoCivil, sexo, nomePai, nomeMae, dataInclusao, " & _
                    " situacao, rg, cpf, carteiraProfissional, dataNascimento, naturalidade, nacionalidade, email, " & _
                    " foto, ddd, telefone, dddcel, celular, rgOrgaoEmissor, rgUf_cid From clientes "

                ds = acessoBanco.ExecutarDS(comandoSQL)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoCliente

                            For Each row In dt.Rows
                                item = New dCliente

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.nome = cFuncoes.RetornarTexto(row("nome"))
                                item.estadoCivil = cFuncoes.RetornarTexto(row("estadoCivil"))
                                item.sexo = cFuncoes.RetornarTexto(row("sexo"))
                                item.nomePai = cFuncoes.RetornarTexto(row("nomePai"))
                                item.nomeMae = cFuncoes.RetornarTexto(row("nomeMae"))
                                item.situacao = cFuncoes.RetornarTexto(row("situacao"))
                                item.rg = cFuncoes.RetornarTexto(row("rg"))
                                item.cpf = cFuncoes.RetornarTexto(row("cpf"))
                                item.carteiraProfissional = cFuncoes.RetornarTexto(row("carteiraProfissional"))
                                item.dataNascimento = cFuncoes.RetornarTexto(row("dataNascimento"))
                                item.naturalidade = cFuncoes.RetornarTexto(row("naturalidade"))
                                item.nacionalidade = cFuncoes.RetornarTexto(row("nacionalidade"))
                                item.email = cFuncoes.RetornarTexto(row("email"))
                                item.foto = cFuncoes.RetornarTexto(row("foto"))
                                item.ddd = cFuncoes.RetornarTexto(row("ddd"))
                                item.telefone = cFuncoes.RetornarTexto(row("telefone"))
                                item.dddcel = cFuncoes.RetornarTexto(row("dddcel"))
                                item.celular = cFuncoes.RetornarTexto(row("celular"))
                                item.rgOrgaoEmissor = cFuncoes.RetornarTexto(row("rgOrgaoEmissor"))
                                item.rgUf_cid = cFuncoes.RetornarInteiro(row("rgUf_cid"))

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
                Throw New ExcecaoNascomercio("Erro em Listar Cliente [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dCliente) As ColecaoCliente

            Dim retorno As ColecaoCliente
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dCliente
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " Select c.cid, nome, logradouro, estadoCivil, sexo, nomePai, nomeMae, c.dataInclusao, " &
                    " situacao, rg, cpf, carteiraProfissional, dataNascimento, naturalidade, nacionalidade, email, " &
                    " foto, ddd, telefone, dddcel, celular, rgOrgaoEmissor, rgUf_cid "

                sqlWhere = String.Empty
                sqlFrom = " From clientes c left join veiculo v  on  v.clienteid = c.cid "

                sqlFrom += " left join clienteenderecos e on e.cliente_cid = c.cid "

                '-- cid
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "c.cid")

                '-- nome
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.nome, "nome", True)

                '-- logradouro
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.endereco, "logradouro", True)

                '-- estadoCivil
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.estadoCivil, "estadoCivil")

                '-- sexo
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.sexo, "sexo")

                '-- nomePai
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.nomePai, "nomePai", True)

                '-- nomeMae
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.nomeMae, "nomeMae", True)

                '-- dataInclusao
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.dataInclusao, "dataInclusao")

                '-- situacao
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.situacao, "situacao")

                '-- rg
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.rg, "rg")

                '-- cpf
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cpf, "cpf")

                '-- carteiraProfissional
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.carteiraProfissional, "carteiraProfissional")

                '-- dataNascimento
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.dataNascimento, "dataNascimento")

                '-- naturalidade
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.naturalidade, "naturalidade", True)

                '-- nacionalidade
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.nacionalidade, "nacionalidade")

                '-- email
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.email, "email")

                '-- foto
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.foto, "foto")

                '-- ddd
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.ddd, "ddd")

                '-- telefone
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.telefone, "telefone")

                '-- veiculo
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.veiculo, "placa")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoCliente

                            For Each row In dt.Rows
                                item = New dCliente

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.nome = cFuncoes.RetornarTexto(row("nome"))
                                item.endereco = cFuncoes.RetornarTexto(row("logradouro"))
                                item.estadoCivil = cFuncoes.RetornarTexto(row("estadoCivil"))
                                item.sexo = cFuncoes.RetornarTexto(row("sexo"))
                                item.nomePai = cFuncoes.RetornarTexto(row("nomePai"))
                                item.nomeMae = cFuncoes.RetornarTexto(row("nomeMae"))
                                item.situacao = cFuncoes.RetornarTexto(row("situacao"))
                                item.rg = cFuncoes.RetornarTexto(row("rg"))
                                item.cpf = cFuncoes.RetornarTexto(row("cpf"))
                                item.carteiraProfissional = cFuncoes.RetornarTexto(row("carteiraProfissional"))
                                item.dataNascimento = cFuncoes.RetornarTexto(row("dataNascimento"))
                                item.naturalidade = cFuncoes.RetornarTexto(row("naturalidade"))
                                item.nacionalidade = cFuncoes.RetornarTexto(row("nacionalidade"))
                                item.email = cFuncoes.RetornarTexto(row("email"))
                                item.ddd = cFuncoes.RetornarTexto(row("ddd"))
                                item.telefone = cFuncoes.RetornarTexto(row("telefone"))
                                item.dddcel = cFuncoes.RetornarTexto(row("dddcel"))
                                item.celular = cFuncoes.RetornarTexto(row("celular"))
                                item.foto = cFuncoes.RetornarTexto(row("foto"))
                                item.rgOrgaoEmissor = cFuncoes.RetornarTexto(row("rgOrgaoEmissor"))
                                item.rgUf_cid = cFuncoes.RetornarInteiro(row("rgUf_cid"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar Cliente [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Consultar = retorno

        End Function

        Public Function Incluir(ByVal dados As dCliente) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " INSERT INTO " & _
                    " clientes (nome, estadoCivil, sexo, nomePai, nomeMae, dataInclusao, " & _
                    " situacao, rg, cpf, carteiraProfissional, dataNascimento, naturalidade, nacionalidade, email, " & _
                    " foto, ddd, telefone, dddcel, celular, rgOrgaoEmissor, rgUf_cid) " & _
                    " VALUES (" & _
                    cFuncoes.PersistirTexto(dados.nome) & "," & _
                    cFuncoes.PersistirTexto(dados.estadoCivil) & "," & _
                    cFuncoes.PersistirTexto(dados.sexo) & "," & _
                    cFuncoes.PersistirTexto(dados.nomePai) & "," & _
                    cFuncoes.PersistirTexto(dados.nomeMae) & "," & _
                    cFuncoes.PersistirData(dados.dataInclusao) & "," & _
                    cFuncoes.PersistirTexto(dados.situacao) & "," & _
                    cFuncoes.PersistirTexto(dados.rg) & "," & _
                    cFuncoes.PersistirTexto(dados.cpf) & "," & _
                    cFuncoes.PersistirTexto(dados.carteiraProfissional) & "," & _
                    cFuncoes.PersistirData(dados.dataNascimento) & "," & _
                    cFuncoes.PersistirTexto(dados.naturalidade) & "," & _
                    cFuncoes.PersistirTexto(dados.nacionalidade) & "," & _
                    cFuncoes.PersistirTexto(dados.email) & "," & _
                    cFuncoes.PersistirTexto(dados.foto) & "," & _
                    cFuncoes.PersistirTexto(dados.ddd) & "," & _
                    cFuncoes.PersistirTexto(dados.telefone) & "," & _
                    cFuncoes.PersistirTexto(dados.dddcel) & "," & _
                    cFuncoes.PersistirTexto(dados.celular) & "," & _
                    cFuncoes.PersistirTexto(dados.rgOrgaoEmissor) & "," & _
                    cFuncoes.PersistirInteiro(dados.rgUf_cid) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Cliente [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function IncluirCid(ByVal dados As dCliente) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " INSERT INTO " & _
                    " clientes (cid, nome, estadoCivil, sexo, nomePai, nomeMae, dataInclusao, " & _
                    " situacao, rg, cpf, carteiraProfissional, dataNascimento, naturalidade, nacionalidade, email, " & _
                    " foto, ddd, telefone, dddcel, celular, rgOrgaoEmissor, rgUf_cid) " & _
                    " VALUES (" & _
                    cFuncoes.PersistirTexto(dados.cid) & "," & _
                    cFuncoes.PersistirTexto(dados.nome) & "," & _
                    cFuncoes.PersistirTexto(dados.estadoCivil) & "," & _
                    cFuncoes.PersistirTexto(dados.sexo) & "," & _
                    cFuncoes.PersistirTexto(dados.nomePai) & "," & _
                    cFuncoes.PersistirTexto(dados.nomeMae) & "," & _
                    cFuncoes.PersistirData(dados.dataInclusao) & "," & _
                    cFuncoes.PersistirTexto(dados.situacao) & "," & _
                    cFuncoes.PersistirTexto(dados.rg) & "," & _
                    cFuncoes.PersistirTexto(dados.cpf) & "," & _
                    cFuncoes.PersistirTexto(dados.carteiraProfissional) & "," & _
                    cFuncoes.PersistirData(dados.dataNascimento) & "," & _
                    cFuncoes.PersistirTexto(dados.naturalidade) & "," & _
                    cFuncoes.PersistirTexto(dados.nacionalidade) & "," & _
                    cFuncoes.PersistirTexto(dados.email) & "," & _
                    cFuncoes.PersistirTexto(dados.foto) & "," & _
                    cFuncoes.PersistirTexto(dados.ddd) & "," & _
                    cFuncoes.PersistirTexto(dados.telefone) & "," & _
                    cFuncoes.PersistirTexto(dados.dddcel) & "," & _
                    cFuncoes.PersistirTexto(dados.celular) & "," & _
                    cFuncoes.PersistirTexto(dados.rgOrgaoEmissor) & "," & _
                    cFuncoes.PersistirInteiro(dados.rgUf_cid) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Cliente [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function
        Public Function Alterar(ByVal dados As dCliente) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " UPDATE clientes SET " & _
                    " nome = " & cFuncoes.PersistirTexto(dados.nome) & "," & _
                    " estadoCivil = " & cFuncoes.PersistirTexto(dados.estadoCivil) & "," & _
                    " sexo = " & cFuncoes.PersistirTexto(dados.sexo) & "," & _
                    " nomePai = " & cFuncoes.PersistirTexto(dados.nomePai) & "," & _
                    " nomeMae = " & cFuncoes.PersistirTexto(dados.nomeMae) & "," & _
                    " dataInclusao = " & cFuncoes.PersistirData(dados.dataInclusao) & "," & _
                    " situacao = " & cFuncoes.PersistirTexto(dados.situacao) & "," & _
                    " rg = " & cFuncoes.PersistirTexto(dados.rg) & "," & _
                    " cpf = " & cFuncoes.PersistirTexto(dados.cpf) & "," & _
                    " carteiraProfissional = " & cFuncoes.PersistirTexto(dados.carteiraProfissional) & "," & _
                    " dataNascimento = " & cFuncoes.PersistirData(dados.dataNascimento) & "," & _
                    " naturalidade = " & cFuncoes.PersistirTexto(dados.naturalidade) & "," & _
                    " nacionalidade = " & cFuncoes.PersistirTexto(dados.nacionalidade) & "," & _
                    " email = " & cFuncoes.PersistirTexto(dados.email) & "," & _
                    " foto = " & cFuncoes.PersistirTexto(dados.foto) & "," & _
                    " ddd = " & cFuncoes.PersistirInteiro(dados.ddd) & "," & _
                    " telefone = " & cFuncoes.PersistirInteiro(dados.telefone) & "," & _
                    " dddcel = " & cFuncoes.PersistirInteiro(dados.dddcel) & "," & _
                    " celular = " & cFuncoes.PersistirInteiro(dados.celular) & "," & _
                    " rgOrgaoEmissor = " & cFuncoes.PersistirTexto(dados.rgOrgaoEmissor) & "," & _
                    " rgUf_cid = " & cFuncoes.PersistirInteiro(dados.rgUf_cid) & _
                    " WHERE " & _
                    " cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Cliente [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dCliente) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM clientes " & _
                    " WHERE cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Cliente [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Excluir = retorno

        End Function

    End Class

End Namespace
