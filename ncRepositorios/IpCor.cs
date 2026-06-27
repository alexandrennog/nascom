using System;
using nsCor;

namespace ncPersistencia.nsCor
{
    public interface IpCor
    {
        ColecaoCor Listar();
        ColecaoCor Consultar(dCor dados);
        int Incluir(dCor dados);
        int Importar(dCor dados);
        int Alterar(dCor dados);
        int Excluir(dCor dados);
    }
}
