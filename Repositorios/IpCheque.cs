using System;
using Modelos;


namespace Repositorios
{
    public interface IpCheques
    {
        ColecaoCheques Listar();
        ColecaoCheques Consultar(dCheques dados);
        int Incluir(dCheques dados);
        int Alterar(dCheques dados);
        int Baixar();
        int Excluir(dCheques dados);
    }
}
