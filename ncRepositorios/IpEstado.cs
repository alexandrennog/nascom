using System;

namespace ncPersistencia.nsEstado
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
