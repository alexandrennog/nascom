using System;
using nsEFD;

namespace ncPersistencia.nsEFD
{
    public interface IpEfdEnderecoContato
    {
        dEfdEnderecoContato Consultar();
        int Excluir();
        int Incluir(dEfdEnderecoContato dados);
        int Alterar(dEfdEnderecoContato dados);
    }
}
