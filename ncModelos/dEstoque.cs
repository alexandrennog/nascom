using System;

public class dEstoque
{
    public string Fabricante { get; set; }
    public string CID { get; set; }
    public string Descricao { get; set; }
    public string Referencia { get; set; }
    public string Item { get; set; }
    public decimal ValorCompra { get; set; }
    public decimal ValorVenda { get; set; }
    public decimal Valor { get; set; }
    public string Cor { get; set; }

    public dEstoque()
    {
    }

    public string ExibirInformacoes()
    {
        return $"Fabricante: {Fabricante}, CID: {CID}, Descrição: {Descricao}, Referência: {Referencia}, Item: {Item}, Valor de Compra: {ValorCompra:C}, Valor de Venda: {ValorVenda:C}, Valor: {Valor:C}, Cor: {Cor}";
    }
}
