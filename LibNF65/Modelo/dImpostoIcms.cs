namespace LibNF65.Modelo
{
    public class dImpostoIcms
    {
        public int? regra_cid { get; set; }
        public byte? origem { get; set; }
        public string cst { get; set; }
        public string csosn { get; set; }
        public decimal? aliquota { get; set; }
        public decimal? reducaoBase { get; set; }
        public byte? modalidadeBc { get; set; }
        public decimal? aliquotaSt { get; set; }
        public decimal? margemValorAgregado { get; set; }
    }
}
