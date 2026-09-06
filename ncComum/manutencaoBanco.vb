Imports ncComum.nsAcessoBD

Namespace nsManutencaoBanco

    ' Cria automaticamente, se ainda nao existirem, os indices que aceleram os
    ' relatorios de vendas (Fechamento, Vendas por Vendedor, Curva ABC, etc).
    '
    ' Cada loja tem seu proprio banco local, entao esta classe roda dentro do
    ' proprio aplicativo (chamada em mdiPrincipal.Iniciar) em vez de depender de
    ' alguem rodar um script manualmente em cada banco.
    '
    ' Seguro para rodar em toda inicializacao e em varios terminais da mesma loja
    ' ao mesmo tempo: cada indice so e criado se ainda nao existir, e qualquer erro
    ' (indice ja existe, tabela ocupada por outro terminal, etc.) e ignorado sem
    ' interromper o login - indice e otimizacao, nunca requisito para o sistema
    ' funcionar.
    Public Class cManutencaoBanco

        ' {tabela, nome do indice, colunas}
        Private Shared ReadOnly IndicesRelatorios As String()() = {
            New String() {"vendas", "idx_vendas_data_vendedor", "data, vendedor"},
            New String() {"vendas", "idx_vendas_clienteid", "clienteId"},
            New String() {"vendasprodutos", "idx_vendasprodutos_controle", "controle"},
            New String() {"vendasprodutos", "idx_vendasprodutos_produto", "produto"},
            New String() {"vales", "idx_vales_data_vendedor", "data, vendedor"},
            New String() {"vales", "idx_vales_clienteid", "clienteId"},
            New String() {"valesprodutos", "idx_valesprodutos_controle", "controle"},
            New String() {"valesprodutos", "idx_valesprodutos_produto", "produto"}
        }

        ' Checagem rapida (nao cria nada) - usada so para decidir se mostra o aviso
        ' de "otimizando banco de dados" antes de comecar a criar os indices.
        Public Shared Function ExisteIndicePendente() As Boolean

            Dim acessoBanco As cAcessoBD

            Try
                For Each indice As String() In IndicesRelatorios
                    acessoBanco = New cAcessoBD

                    If Not IndiceExiste(acessoBanco, indice(0), indice(1)) Then
                        Return True
                    End If
                Next

            Catch ex As Exception

                Return False

            End Try

            Return False

        End Function

        ' Cria os indices que ainda estiverem faltando. Ver observacoes da classe
        ' sobre seguranca de rodar isso repetidamente / em paralelo.
        Public Shared Sub CriarIndicesPendentes()

            Dim acessoBanco As cAcessoBD

            For Each indice As String() In IndicesRelatorios

                Try

                    acessoBanco = New cAcessoBD

                    If Not IndiceExiste(acessoBanco, indice(0), indice(1)) Then
                        acessoBanco.ExecutarINT("CREATE INDEX " & indice(1) & " ON " & indice(0) & " (" & indice(2) & ")")
                    End If

                Catch ex As Exception

                    ' Nao interrompe o login por causa disso. Fica faltando ate a
                    ' proxima inicializacao tentar de novo.

                End Try

            Next

        End Sub

        Private Shared Function IndiceExiste(ByVal acessoBanco As cAcessoBD, ByVal tabela As String, ByVal nomeIndice As String) As Boolean

            Dim ds As DataSet
            Dim sql As String

            sql = "SELECT COUNT(*) as total FROM information_schema.STATISTICS " & _
                  "WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = '" & tabela & "' AND INDEX_NAME = '" & nomeIndice & "'"

            ds = acessoBanco.ExecutarDS(sql)

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                Return Convert.ToInt32(ds.Tables(0).Rows(0)("total")) > 0
            End If

            Return False

        End Function

    End Class

End Namespace
