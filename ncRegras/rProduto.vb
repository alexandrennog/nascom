Imports System.Transactions

Imports ncDados.nsUsuario
Imports ncDados.nsProduto
Imports ncDados.nsGradeItem
Imports ncDados.nsGradeEntrada
Imports ncDados.nsCaracteristica
Imports ncRegras.nsCaracteristica
Imports ncPersistencia.nsProduto
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao
Imports ncComum.nsLog.cLog

Namespace nsProduto

    Public Class rProduto

        Public _usuario As dUsuario

        '-- M�todos de controle ( V�rias chamadas; Controle de transa��o )

        Public Function Listar() As ColecaoProduto

            Dim retorno As ColecaoProduto

            Try

                retorno = fListar()

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Listar Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dProduto) As ColecaoProduto

            Dim retorno As ColecaoProduto

            Try

                retorno = fConsultar(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        'Public Function ConsultarGradeItem(ByVal dados As dProduto) As ColecaoGradeItem

        '  Dim retorno As ColecaoGradeItem

        '  Try

        '    retorno = fConsultarGradeItem(dados)

        '  Catch ex As Exception

        '    retorno = Nothing
        '    Throw New ExcecaoNascomercio("Erro em Consultar Grade Item [" & Me.ToString() & "] - " & ex.Message)

        '  End Try

        '  ConsultarGradeItem = retorno

        'End Function

        Public Function ConsultarGradeEntrada(ByVal dados As dProduto) As ColecaoGradeEntrada

            Dim retorno As ColecaoGradeEntrada

            Try

                retorno = fConsultarGradeEntrada(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Grade Entrada [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ConsultarGradeEntrada = retorno

        End Function

        Public Function Consultar(ByVal cid As Integer) As dProduto

            Dim retorno As dProduto
            Dim dados As dProduto
            Dim colecao As ColecaoProduto

            Try

                dados = New dProduto()

                dados.cid = cid

                colecao = fConsultar(dados)

                If Not colecao Is Nothing Then
                    If colecao.Count > 0 Then
                        Dim item As dProduto

                        item = colecao(0)

                        retorno = New dProduto()

                        retorno.cid = RetornarInteiro(item.cid)
                        retorno.codigo = RetornarTexto(item.codigo)
                        retorno.descricao = RetornarTexto(item.descricao)
                        retorno.situacao = RetornarTexto(item.situacao)
                        retorno.dataInclusao = RetornarTexto(item.dataInclusao)
                        retorno.valorCompra = RetornarDecimal(item.valorCompra)
                        retorno.valorVenda = RetornarDecimal(item.valorVenda)
                        retorno.produtoTipo_cid = RetornarInteiro(item.produtoTipo_cid)
                        retorno.fornecedor_cid = RetornarInteiro(item.fornecedor_cid)
                        retorno.fabricante_cid = RetornarInteiro(item.fabricante_cid)
                        retorno.referencia = RetornarTexto(item.referencia)
                        retorno.imagem = RetornarTexto(item.imagem)
                        retorno.cor_cid = RetornarInteiro(item.cor_cid)
                        retorno.grupo_cid = RetornarInteiro(item.grupo_cid)
                        retorno.estoqueMinimo = RetornarInteiro(item.estoqueMinimo)
                        retorno.aliquota = RetornarTexto(item.aliquota)
                        retorno.efdUnidadeMedidaCodigo = RetornarTexto(item.efdUnidadeMedidaCodigo)
                        retorno.efdCodigoCategoria = RetornarTexto(item.efdCodigoCategoria)
                        retorno.efdIntegracao = RetornarBoleano(item.efdIntegracao)
                        retorno.ncm = RetornarTexto(item.ncm)
                        retorno.cest = RetornarTexto(item.cest)
                    Else
                        retorno = Nothing
                    End If
                Else
                    retorno = Nothing
                End If

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Consultar = retorno

        End Function

        Public Function ConsultarProximoCID() As Integer

            Dim retorno As Integer
            Dim dados As dProduto

            Try

                dados = New dProduto()

                retorno = fConsultarProximoCID()

            Catch ex As Exception

                retorno = 0
                Throw New ExcecaoNascomercio("Erro em ConsultarProximoCID Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ConsultarProximoCID = retorno

        End Function

        Public Function Incluir(ByVal dados As dProduto) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fIncluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function Importar(ByVal dados As dProduto) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fImportar(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Importar Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Importar = retorno

        End Function

        Public Function Incluir(ByVal dados As dProduto, ByVal colecaoItem As ColecaoItensProdutos, ByVal usuario As dUsuario) As Integer

            Dim retorno As Integer
            Dim regraProdutoItem As rProdutoItem
            Dim regraCaracteristica As rCaracteristica
            Dim item As dProdutoItem
            Dim dadosCaracteristica As dCaracteristica
            Dim novoCB As String
            Dim codigoBarras As String = String.Empty
            Dim estoque As String = String.Empty
            Dim novoItem As Boolean = False

            Try

                regraProdutoItem = New rProdutoItem()
                regraCaracteristica = New rCaracteristica()
                dadosCaracteristica = New dCaracteristica()

                Using ts As New TransactionScope
                    '-- Incluir produto
                    retorno = fIncluir(dados)

                    '-- Se retornou novo cid, verifica inclus�o de itens
                    If retorno > 0 Then
                        '-- Se possuir itens, inclui
                        If Not colecaoItem Is Nothing Then
                            If colecaoItem.Count > 0 Then
                                '-- Excluir itens do produto
                                regraProdutoItem.fExcluirPorProduto(retorno)
                                GravarLog(usuario.usuario, "Exclus�o dos itens do produto cid[" & retorno.ToString() & "] - rProduto.Incluir")

                                '-- Incluir itens atualizados
                                For Each itemColecao As ColecaoProdutoItem In colecaoItem
                                    For Each item In itemColecao
                                        If Not item.caracteristicas_codigo.Trim().ToLower().Equals("estoquenovo") Then
                                            novoCB = String.Empty
                                            dadosCaracteristica = regraCaracteristica.fConsultarPorCodigo(item.caracteristicas_codigo)

                                            If Not dadosCaracteristica Is Nothing Then
                                                item.caracteristicas_cid = dadosCaracteristica.cid

                                                If dadosCaracteristica.codigo.ToLower().Equals("codigobarras") Then
                                                    If item.valor Is Nothing Then
                                                        novoCB = regraProdutoItem.fConsultarUltimoCodigoBarras()
                                                        novoCB = ObterCodigoBarrasProduto(novoCB)
                                                        item.valor = novoCB
                                                        novoItem = True
                                                    Else
                                                        If item.valor.Trim().Equals(String.Empty) Then
                                                            novoCB = regraProdutoItem.fConsultarUltimoCodigoBarras()
                                                            novoCB = ObterCodigoBarrasProduto(novoCB)
                                                            item.valor = novoCB
                                                            novoItem = True
                                                        End If
                                                    End If
                                                End If
                                            Else
                                                Throw New Exception()
                                            End If

                                            item.produtos_cid = retorno
                                            regraProdutoItem.fIncluir(item)

                                            If dadosCaracteristica.codigo.ToLower().Equals("codigobarras") Then
                                                codigoBarras = item.valor.ToString()
                                            End If

                                            If dadosCaracteristica.codigo.ToLower().Equals("estoque") Then
                                                If item.valor IsNot Nothing Then
                                                    estoque = item.valor.ToString()
                                                Else
                                                    estoque = String.Empty
                                                End If
                                            End If

                                            If (Not codigoBarras.Equals(String.Empty)) And
                                                (Not estoque.Equals(String.Empty)) Then
                                                'If novoItem = True Then
                                                '-- Gravar Log Estoque
                                                GravarLogEstoque(_usuario.cid, _usuario.nomeCompleto, item.produtos_cid, codigoBarras, Convert.ToInt32(estoque), dados.notaFiscalNumero, dados.notaFiscalSerie)
                                                GravarLog(usuario.usuario, "Inclus�o de novo item - codigoBarras[" & codigoBarras & "] - rProduto.Incluir")
                                                'End If

                                                codigoBarras = String.Empty
                                                estoque = String.Empty
                                                novoItem = False
                                            End If
                                        End If
                                    Next
                                Next
                            End If
                        End If
                    Else
                        Throw New Exception()
                    End If

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dProduto) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fAlterar(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

        Public Function Alterar(ByVal dados As dProduto, ByVal colecaoItem As ColecaoItensProdutos, ByVal usuario As dUsuario) As Integer

            Dim retorno As Integer
            Dim regraProdutoItem As rProdutoItem
            Dim regraCaracteristica As rCaracteristica
            Dim dadosCaracteristica As dCaracteristica
            Dim novoCB As String
            Dim incluiProduto As Boolean = False
            Dim _codigoBarras As String = String.Empty
            Dim _estoque As String = String.Empty
            Dim _produtos_cid As String = String.Empty

            Try

                regraProdutoItem = New rProdutoItem()
                regraCaracteristica = New rCaracteristica()
                dadosCaracteristica = New dCaracteristica()

                Using ts As New TransactionScope
                    '-- Alterar produto
                    retorno = fAlterar(dados)

                    '-- Excluir itens do produto, inclui
                    regraProdutoItem.fExcluirPorProduto(dados.cid)
                    GravarLog(usuario.usuario, "Exclus�o dos itens do produto cid[" & retorno.ToString() & "] - rProduto.Alterar")

                    '-- Se possuir itens
                    If Not colecaoItem Is Nothing Then
                        If colecaoItem.Count > 0 Then
                            '-- Incluir itens com codigobarras ( existentes / altera��o )
                            For Each itemColecao As ColecaoProdutoItem In colecaoItem
                                incluiProduto = False

                                For Each item1 As dProdutoItem In itemColecao
                                    If Not item1.caracteristicas_codigo.ToLower().Equals("estoquenovo") Then
                                        dadosCaracteristica = regraCaracteristica.fConsultarPorCodigo(item1.caracteristicas_codigo)
                                        If Not dadosCaracteristica Is Nothing Then
                                            item1.caracteristicas_cid = dadosCaracteristica.cid
                                            If dadosCaracteristica.codigo.ToLower().Equals("codigobarras") Then
                                                If Not String.IsNullOrEmpty(item1.valor) Then
                                                    incluiProduto = True
                                                    Exit For
                                                End If
                                            End If
                                        Else
                                            Throw New Exception()
                                        End If
                                    End If
                                Next

                                If incluiProduto = True Then
                                    For Each item2 As dProdutoItem In itemColecao
                                        If Not item2.caracteristicas_codigo.ToLower().Equals("estoquenovo") Then
                                            dadosCaracteristica = regraCaracteristica.fConsultarPorCodigo(item2.caracteristicas_codigo)

                                            If Not dadosCaracteristica Is Nothing Then
                                                item2.caracteristicas_cid = dadosCaracteristica.cid

                                                regraProdutoItem.fIncluir(item2)
                                                If item2.caracteristicas_codigo.ToLower().Equals("codigobarras") Then
                                                    GravarLog(usuario.usuario, "Inclus�o de item existente - codigobarras[" & item2.valor & "] - rProduto.Alterar")
                                                End If
                                            Else
                                                Throw New Exception()
                                            End If
                                        End If

                                    Next

                                    '-- LogEstoque j� foi gravado 
                                End If
                            Next

                            '-- Incluir itens sem codigobarras ( novos / inclus�o )
                            For Each itemColecao As ColecaoProdutoItem In colecaoItem
                                incluiProduto = False

                                For Each item3 As dProdutoItem In itemColecao
                                    If Not item3.caracteristicas_codigo.ToLower().Equals("estoquenovo") Then
                                        dadosCaracteristica = regraCaracteristica.fConsultarPorCodigo(item3.caracteristicas_codigo)
                                        If Not dadosCaracteristica Is Nothing Then
                                            item3.caracteristicas_cid = dadosCaracteristica.cid
                                            If dadosCaracteristica.codigo.ToLower().Equals("codigobarras") Then
                                                If String.IsNullOrEmpty(item3.valor) Then
                                                    incluiProduto = True
                                                    Exit For
                                                End If
                                            End If
                                        Else
                                            Throw New Exception()
                                        End If
                                    End If
                                Next

                                If incluiProduto = True Then
                                    For Each item4 As dProdutoItem In itemColecao
                                        If Not item4.caracteristicas_codigo.ToLower().Equals("estoquenovo") Then
                                            dadosCaracteristica = regraCaracteristica.fConsultarPorCodigo(item4.caracteristicas_codigo)

                                            If Not dadosCaracteristica Is Nothing Then
                                                item4.caracteristicas_cid = dadosCaracteristica.cid

                                                If Not dadosCaracteristica.codigo.ToLower().Equals("codigobarras") Then
                                                    regraProdutoItem.fIncluir(item4)
                                                Else
                                                    novoCB = regraProdutoItem.fConsultarUltimoCodigoBarras()
                                                    novoCB = ObterCodigoBarrasProduto(novoCB)

                                                    item4.valor = novoCB

                                                    regraProdutoItem.fIncluir(item4)
                                                    GravarLog(usuario.usuario, "Inclus�o de novo item - codigobarras[" & novoCB & "] - rProduto.Alterar")
                                                End If

                                                If dadosCaracteristica.codigo.ToLower().Equals("codigobarras") Then
                                                    _codigoBarras = item4.valor.ToString()
                                                End If
                                                _produtos_cid = item4.produtos_cid

                                            Else
                                                Throw New Exception()
                                            End If
                                        Else
                                            If (item4.valor IsNot Nothing) AndAlso (Not String.IsNullOrEmpty(item4.valor.ToString())) Then
                                                _estoque = item4.valor.ToString()
                                            End If
                                        End If
                                    Next

                                    '-- Gravar LogEstoque
                                    If (Not _codigoBarras.Equals(String.Empty)) And
                                        (Not _estoque.Equals(String.Empty)) And
                                        (Not _produtos_cid.Equals(String.Empty)) Then

                                        If _estoque > 0 Then
                                            GravarLogEstoque(_usuario.cid, _usuario.nomeCompleto, _produtos_cid, _codigoBarras, Convert.ToInt32(_estoque), dados.notaFiscalNumero, dados.notaFiscalSerie)
                                        End If

                                        _codigoBarras = String.Empty
                                        _estoque = String.Empty
                                        _produtos_cid = String.Empty
                                    End If
                                End If

                            Next
                        End If
                    End If

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dProduto, ByVal usuario As dUsuario) As Integer

            Dim retorno As Integer
            Dim regraProdutoItem As rProdutoItem
            Dim dadosItem As dProdutoItem

            Try

                regraProdutoItem = New rProdutoItem()
                dadosItem = New dProdutoItem()

                Using ts As New TransactionScope
                    '-- Excluir itens do produto
                    dadosItem.produtos_cid = dados.cid
                    regraProdutoItem.fExcluirPorProduto(dadosItem)
                    GravarLog(usuario.usuario, "Exclus�o de itens de produto - " & dados.descricao & " refer�ncia: " & dados.referencia)

                    '-- Excluir produto
                    retorno = fExcluir(dados)
                    GravarLog(usuario.usuario, "Exclus�o de produto - " & dados.descricao & " refer�ncia: " & dados.referencia)

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Excluir = retorno

        End Function

        '-- M�todos padr�o ( Incluir; Alterar; Excluir; Consultar; Listar )

        Public Function fListar() As ColecaoProduto

            Dim retorno As ColecaoProduto
            Dim persistencia As pProduto
            Dim retornoPersistencia As ColecaoProduto

            Try

                retorno = New ColecaoProduto

                persistencia = New pProduto
                retornoPersistencia = persistencia.Listar()

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
                Throw New ExcecaoNascomercio("Erro em fListar Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fListar = retorno

        End Function

        Public Function fConsultar(ByVal dados As dProduto) As ColecaoProduto

            Dim retorno As ColecaoProduto
            Dim persistencia As pProduto
            Dim retornoPersistencia As ColecaoProduto

            Try

                retorno = New ColecaoProduto

                persistencia = New pProduto
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
                Throw New ExcecaoNascomercio("Erro em fConsultar Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function fConsultarGradeEntrada(ByVal dados As dProduto) As ColecaoGradeEntrada

            Dim retorno As ColecaoGradeEntrada
            Dim persistencia As pProduto
            Dim retornoPersistencia As ColecaoGradeEntrada

            Try

                retorno = New ColecaoGradeEntrada

                persistencia = New pProduto
                retornoPersistencia = persistencia.ConsultarGradeEntrada(dados)

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
                Throw New ExcecaoNascomercio("Erro em fConsultar Grade Entrada [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fConsultarGradeEntrada = retorno

        End Function

        Public Function fConsultarProximoCID() As Integer

            Dim retorno As Integer = 0
            Dim persistencia As pProduto

            Try

                persistencia = New pProduto
                retorno = persistencia.ConsultarProximoCID()

            Catch ex As Exception

                retorno = 0
                Throw New ExcecaoNascomercio("Erro em fConsultarProximoCID Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fConsultarProximoCID = retorno

        End Function

        Public Function fIncluir(ByVal dados As dProduto) As Integer

            Dim retorno As Integer
            Dim persistencia As pProduto

            Try

                persistencia = New pProduto
                retorno = persistencia.Incluir(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fIncluir Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fIncluir = retorno

        End Function

        Public Function fImportar(ByVal dados As dProduto) As Integer

            Dim retorno As Integer
            Dim persistencia As pProduto

            Try

                persistencia = New pProduto
                retorno = persistencia.Importar(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fImportar Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fImportar = retorno

        End Function

        Public Function fAlterar(ByVal dados As dProduto) As Integer

            Dim retorno As Integer
            Dim persistencia As pProduto

            Try

                persistencia = New pProduto
                retorno = persistencia.Alterar(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fAlterar Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fAlterar = retorno

        End Function

        Public Function fExcluir(ByVal dados As dProduto) As Integer

            Dim retorno As Integer
            Dim persistencia As pProduto

            Try

                persistencia = New pProduto
                retorno = persistencia.Excluir(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fExcluir Produto [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fExcluir = retorno

        End Function

    End Class

End Namespace
