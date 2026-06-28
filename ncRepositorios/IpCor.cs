using System;
using ncModelos;

namespace ncRepositorios
{
    public interface IpCor
    {
        ColecaoCor Listar();
        ColecaoCor Consultar(dCor dados);
        int Incluir(dCor dados);
        int Importar(dCor dados);
        int Alterar(dCor dados);
        int Excluir(dCor dados);
    }
}
