using Modelos;

namespace APINascom.Requests
{
    public class AlterarChequeRequest
    {
        public dCheques Dados { get; set; } = null!;
        public ColecaoCheques DadosCheques { get; set; } = null!;
    }

    public class IncluirCrediarioRequest
    {
        public dCrediario Dados { get; set; } = null!;
        public ColecaoParcelas DadosParcelas { get; set; } = null!;
    }

    public class AlterarCrediarioRequest
    {
        public dCrediario Dados { get; set; } = null!;
        public ColecaoParcelas DadosParcelas { get; set; } = null!;
    }

    public class RenegociarCrediarioRequest
    {
        public dCrediario Dados { get; set; } = null!;
        public ColecaoParcelas DadosParcelas { get; set; } = null!;
    }

    public class ConsultarGradeItemProdutosRequest
    {
        public string PReferencia { get; set; } = null!;
        public dGradeItem PGradeItem { get; set; } = null!;
    }

    public class ConsultarUltimaVendaGradeRequest
    {
        public string Referencia { get; set; } = null!;
        public dGradeItem GradeItem { get; set; } = null!;
    }

    public class IncluirProdutoCompletoRequest
    {
        public dProduto Dados { get; set; } = null!;
        public ColecaoItensProdutos ColecaoItem { get; set; } = null!;
        public dUsuario Usuario { get; set; } = null!;
    }

    public class AlterarProdutoCompletoRequest
    {
        public dProduto Dados { get; set; } = null!;
        public ColecaoItensProdutos ColecaoItem { get; set; } = null!;
        public dUsuario Usuario { get; set; } = null!;
    }

    public class ExcluirProdutoRequest
    {
        public dProduto Dados { get; set; } = null!;
        public dUsuario Usuario { get; set; } = null!;
    }

    public class IncluirVendaRequest
    {
        public dVenda Dados { get; set; } = null!;
        public ColecaoVendaProduto DadosProdutos { get; set; } = null!;
    }

    public class IncluirTrocaVendaRequest
    {
        public dVenda Dados { get; set; } = null!;
        public ColecaoVendaProduto DadosProdutos { get; set; } = null!;
    }
}
