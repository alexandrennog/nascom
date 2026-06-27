using System;
using nsEFD;

namespace ncPersistencia.nsEFD
{
    public interface IpEfdEntidade
    {
        dEfdEntidade Consultar();
        int Excluir();
        int Incluir(dEfdEntidade dados);
        int Alterar(dEfdEntidade dados);
    }
}
