
Namespace nsCurvaABC
    Public Class ColecaodVendasABC
        Inherits List(Of dCurvaAbc)
    End Class
    Public Class dCurvaAbc
        Public Property Referencia As String
        Public Property Descricao As String
        Public Property Faturamento As Decimal
        Public Property PercIndividual As Decimal
        Public Property PercAcumulado As Decimal
        Public Property ClasseAbc As String
        Public Property Fabricante As String
        Public Property Fornecedor As String
        Public Property EstoqueAtual As Integer
    End Class

End Namespace