using System;
using nsEFD;

namespace ncPersistencia.nsEFD
{
    public interface IpEfdArquivo
    {
        dEfdArquivo Consultar();
        int Excluir();
        int Incluir(dEfdArquivo dados);
        int Alterar(dEfdArquivo dados);
    }
}
