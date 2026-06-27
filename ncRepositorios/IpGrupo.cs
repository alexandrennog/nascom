using System;
using nsGrupo;

namespace ncPersistencia.nsGrupo
{
    public interface IpGrupo
    {
        ColecaoGrupo Listar();
        ColecaoGrupo Consultar(dGrupo dados);
        int Incluir(dGrupo dados);
        int Importar(dGrupo dados);
        int Alterar(dGrupo dados);
        int Excluir(dGrupo dados);
    }
}
