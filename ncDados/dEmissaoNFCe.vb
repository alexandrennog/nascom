Imports System.Text.RegularExpressions

Namespace nsNFCe

    ' Uma emissao de NFC-e (um numero da tabela "basennf"), com o resultado.
    ' Colunas criadas pelo script "scripts\new script\44 - nfce_historico_emissao.sql".
    '
    ' situacao: E = em andamento | A = autorizada | R = rejeitada pela SEFAZ
    '           F = falha (comunicacao / erro antes de chegar na SEFAZ)
    '           C = cancelada | S = substituida (reemitida com outro numero)
    '
    ' origem:   N = numero da basennf
    '           V = venda que ficou sem NFC-e e sem numero ligado a ela
    '               (falhas anteriores ao historico) - so aparece no relatorio
    Public Class dEmissaoNFCe

        ' Emissao "em andamento" ha mais tempo que isso foi interrompida
        ' (sistema fechado / computador desligado no meio)
        Public Const MinutosEmissaoTravada As Integer = 15

        Public Property seqNFe As Nullable(Of Integer)
        Public Property chave As String
        Public Property controle As Nullable(Of Integer)
        Public Property dataEmissao As Nullable(Of DateTime)
        Public Property dataVenda As Nullable(Of DateTime)
        Public Property situacao As String
        Public Property cStat As Nullable(Of Integer)
        Public Property mensagem As String
        Public Property protocolo As String
        Public Property dataAutorizacao As Nullable(Of DateTime)
        Public Property caminhoXml As String
        Public Property cpfConsumidor As String
        Public Property valor As Nullable(Of Decimal)
        Public Property terminal As String
        Public Property computador As String
        Public Property usuario_cid As Nullable(Of Integer)
        Public Property usuarioNome As String
        Public Property tentativas As Integer
        Public Property substituidaPor As Nullable(Of Integer)
        Public Property dataAtualizacao As Nullable(Of DateTime)
        Public Property origem As String = "N"

        ' Data que vale para o relatorio (emissao; sem ela, a data da venda)
        Public ReadOnly Property dataReferencia As Nullable(Of DateTime)
            Get
                If dataEmissao.HasValue Then
                    Return dataEmissao
                End If
                Return dataVenda
            End Get
        End Property

        ' Chave de acesso de verdade (44 digitos) - "temporario"/"FALHA_EMISSAO" nao contam
        Public ReadOnly Property temChave As Boolean
            Get
                Return ChaveValida(chave)
            End Get
        End Property

        ' Ficou "em andamento" e ninguem terminou (sistema fechado no meio)
        Public ReadOnly Property interrompida As Boolean
            Get
                If situacao <> "E" Then
                    Return False
                End If
                Dim ultima As Nullable(Of DateTime) = If(dataAtualizacao.HasValue, dataAtualizacao, dataEmissao)
                Return Not ultima.HasValue OrElse ultima.Value < Now.AddMinutes(-MinutosEmissaoTravada)
            End Get
        End Property

        Public ReadOnly Property situacaoDescricao As String
            Get
                If origem = "V" Then
                    Return "Venda sem NFC-e"
                End If
                If interrompida Then
                    Return "Interrompida"
                End If
                Return DescreverSituacao(situacao)
            End Get
        End Property

        ' Codigo usado no filtro, nas cores e no relatorio: a situacao gravada
        ' (A, R, F, C, S, E) + I = interrompida e V = venda sem numero ligado
        Public ReadOnly Property codigoSituacao As String
            Get
                If origem = "V" Then
                    Return "V"
                End If
                If interrompida Then
                    Return "I"
                End If
                Return situacao
            End Get
        End Property

        ' Filtro do relatorio: "" = todas | "P" = pendentes (falha, rejeitada,
        ' interrompida, venda sem nota) | senao o codigoSituacao
        Public Function AtendeFiltro(ByVal filtro As String) As Boolean
            If String.IsNullOrEmpty(filtro) Then
                Return True
            End If
            Dim codigo As String = codigoSituacao
            If filtro = "P" Then
                Return codigo = "F" OrElse codigo = "R" OrElse codigo = "I" OrElse codigo = "V"
            End If
            Return codigo = filtro
        End Function

        ' Pode tentar emitir de novo: falhou, foi rejeitada ou ficou interrompida,
        ' e sabemos de qual venda e
        Public ReadOnly Property podeReemitir As Boolean
            Get
                If Not controle.HasValue Then
                    Return False
                End If
                If origem = "V" Then
                    Return True
                End If
                Return situacao = "F" OrElse situacao = "R" OrElse interrompida
            End Get
        End Property

        Public Shared Function DescreverSituacao(ByVal codigo As String) As String
            Select Case codigo
                Case "A" : Return "Autorizada"
                Case "R" : Return "Rejeitada"
                Case "F" : Return "Falha"
                Case "C" : Return "Cancelada"
                Case "S" : Return "Substituída"
                Case "E" : Return "Em andamento"
                Case Else : Return If(codigo, "")
            End Select
        End Function

        Public Shared Function ChaveValida(ByVal valor As String) As Boolean
            Return Not String.IsNullOrEmpty(valor) AndAlso Regex.IsMatch(valor, "^[0-9]{44}$")
        End Function

    End Class

    Public Class ColecaoEmissaoNFCe
        Inherits List(Of dEmissaoNFCe)
    End Class

    ' Formas de pagamento gravadas na venda - para montar a NFC-e de novo na reemissao
    ' (mesmos campos que a tela de Pagamento usa na emissao normal)
    Public Class dPagamentoVendaNFCe
        Public Property controle As Integer
        Public Property data As DateTime
        Public Property total As Decimal
        Public Property dinheiro As Decimal
        Public Property troco As Decimal
        Public Property pix As Decimal
        Public Property cheque As Decimal
        Public Property chequePre As Decimal
        Public Property cartaoDebito As Decimal
        Public Property cartaoCredito As Decimal
        Public Property crediario As Decimal
        Public Property troca As Decimal
        Public Property desconto As Decimal
        Public Property vale As Decimal
        Public Property defeito As Decimal
        Public Property terminal As String
        Public Property chave As String
    End Class

End Namespace
