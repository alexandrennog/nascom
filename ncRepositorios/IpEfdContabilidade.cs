using System;
using nsEFD;

namespace ncPersistencia.nsEFD
{
    public interface IpEfdContabilidade
    {
        dEfdContabilidade Consultar();
        int Excluir();
        int Incluir(dEfdContabilidade dados);
        int Alterar(dEfdContabilidade dados);
    }
}
