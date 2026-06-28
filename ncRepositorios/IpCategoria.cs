using System;
using ncModelos;

namespace ncRepositorios
{
    public interface IpCategoria
    {
        ColecaoCategoria Listar();
        ColecaoCategoria Consultar(dCategoria dados);
        int Incluir(dCategoria dados);
        int Importar(dCategoria dados);
        int Alterar(dCategoria dados);
        int Excluir(dCategoria dados);
    }
}
