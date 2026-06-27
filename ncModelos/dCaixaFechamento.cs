using System;
using System.Collections.Generic;

public class ColecaoCaixaFechamento : List<dCaixaFechamento>
{
}

public class dCaixaFechamento
{
    private int? _cid;
    private string _nome;
    private string _situacao;
    private DateTime _data;
    private string _usuario;
    private decimal _valor;
    private int _quantidade;

    public int? cid
    {
        get => _cid;
        set => _cid = value;
    }

    public string nome
    {
        get => _nome;
        set => _nome = value;
    }

    public string situacao
    {
        get => _situacao;
        set => _situacao = value;
    }

    public DateTime Data
    {
        get => _data;
        set => _data = value;
    }

    public string usuario
    {
        get => _usuario;
        set => _usuario = value;
    }

    public decimal valor
    {
        get => _valor;
        set => _valor = value;
    }

    public int quantidade
    {
        get => _quantidade;
        set => _quantidade = value;
    }
}
