Public Class dEstoque
    ' Atributos (Propriedades) da classe Produto
    Public Property Fabricante As String
    Public Property CID As String
    Public Property Descricao As String
    Public Property Referencia As String
    Public Property Item As String
    Public Property ValorCompra As Decimal
    Public Property ValorVenda As Decimal
    Public Property Valor As Decimal

    ' Construtor padrão
    Public Sub New()
    End Sub

    ' Construtor parametrizado
    'Public Sub New(fabricante As String, cid As String, descricao As String, referencia As String, item As String, valorCompra As Decimal, valorVenda As Decimal, valor As Decimal)
    '    Me.Fabricante = fabricante
    '    Me.CID = cid
    '    Me.Descricao = descricao
    '    Me.Referencia = referencia
    '    Me.Item = item
    '    Me.ValorCompra = valorCompra
    '    Me.ValorVenda = valorVenda
    '    Me.Valor = valor
    'End Sub

    ' Método para exibir informações do produto
    Public Function ExibirInformacoes() As String
        Return $"Fabricante: {Fabricante}, CID: {CID}, Descrição: {Descricao}, Referência: {Referencia}, Item: {Item}, Valor de Compra: {ValorCompra:C}, Valor de Venda: {ValorVenda:C}, Valor: {Valor:C}"
    End Function
End Class
