Imports ncDados.nsImpostoIcms
Imports ncDados.nsImpostoPis
Imports ncDados.nsImpostoCofins
Imports ncDados.nsImpostoIpi
Imports ncDados.nsImpostoIbsCbs
Imports ncDados.nsRegraCfop

Namespace nsDadosImpostos

    Public Class dDadosImpostos

        Private _regra_cid As Nullable(Of Integer)
        Private _icms As dImpostoIcms
        Private _pis As dImpostoPis
        Private _cofins As dImpostoCofins
        Private _ipi As dImpostoIpi
        Private _ibsCbs As dImpostoIbsCbs
        Private _cfop As dRegraCfop

        Public Property regra_cid() As Nullable(Of Integer)
            Get
                Return _regra_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _regra_cid = value
            End Set
        End Property

        Public Property icms() As dImpostoIcms
            Get
                Return _icms
            End Get
            Set(ByVal value As dImpostoIcms)
                _icms = value
            End Set
        End Property

        Public Property pis() As dImpostoPis
            Get
                Return _pis
            End Get
            Set(ByVal value As dImpostoPis)
                _pis = value
            End Set
        End Property

        Public Property cofins() As dImpostoCofins
            Get
                Return _cofins
            End Get
            Set(ByVal value As dImpostoCofins)
                _cofins = value
            End Set
        End Property

        Public Property ipi() As dImpostoIpi
            Get
                Return _ipi
            End Get
            Set(ByVal value As dImpostoIpi)
                _ipi = value
            End Set
        End Property

        Public Property ibsCbs() As dImpostoIbsCbs
            Get
                Return _ibsCbs
            End Get
            Set(ByVal value As dImpostoIbsCbs)
                _ibsCbs = value
            End Set
        End Property

        Public Property cfop() As dRegraCfop
            Get
                Return _cfop
            End Get
            Set(ByVal value As dRegraCfop)
                _cfop = value
            End Set
        End Property

    End Class

End Namespace
