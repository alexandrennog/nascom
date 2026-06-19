
Namespace nsCurvaABC
    Public Class ColecaodVendasABC
        Inherits List(Of dCurvaAbc)
    End Class
    Public Class dCurvaAbc

        Public Property PeriodoIni As String
        Public Property PeriodoFim As String
        Public Property Fabricante As String
        Public Property valor As String
        Public Property PercReceita As Decimal
        Public Property PercAcumulado As Decimal
        Public Property ClasseAbc As String
        Public Property Estrategia As String
    End Class

End Namespace