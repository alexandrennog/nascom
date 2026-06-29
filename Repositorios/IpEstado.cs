using System;
using Modelos;

namespace Repositorios
{
    public interface IpEstado
    {
        ColecaoEstado Listar();
        ColecaoEstado Consultar(dEstado dados);
        int Incluir(dEstado dados);
        int Alterar(dEstado dados);
        int Excluir(dEstado dados);
    }
}
