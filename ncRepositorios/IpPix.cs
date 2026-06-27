using System;

public interface IpPix
{
    ColecaoPix Consultar(dPix dados);
    dPix Consultar(string tx);
    dPixConfig ConsultarConfig();
    int Incluir(dPix dados);
    int IncluirPixConfig(dPixConfig dados);
    int AlterarPixConfig(dPixConfig dados);
}
