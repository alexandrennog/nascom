using System;
using Modelos;

namespace Repositorios
{
    public interface IpGiro
    {
        ColecaoGiro Listar();
        ColecaoGiro Consultar(dGiro dados);
        int Incluir(dGiro dados);
        int Importar(dGiro dados);
        int Alterar(dGiro dados);
        int Excluir(dGiro dados);
    }
}
