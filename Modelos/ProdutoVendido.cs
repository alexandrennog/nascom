namespace Modelos
{
    public class ProdutoVendido
    {
        public int controle { get; set; }
        public int produtoId { get; set; }
        public int itemId { get; set; }
        public decimal quantidade { get; set; }
        public decimal valor { get; set; }
        public string codigobarras { get; set; }
        public string descricao { get; set; }
        public string referencia { get; set; }
        public string aliquota { get; set; }

        public decimal valorTributacao { get; set; }

    }
}
