using System;
using nsCategoria;

namespace ncPersistencia.nsCategoria
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
