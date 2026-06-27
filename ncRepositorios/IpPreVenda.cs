using System;
using nsVenda;

namespace ncPersistencia.nsVenda
{
    public interface IpPreVenda
    {
        ColecaoVenda Listar();
        ColecaoVenda Consultar(dVenda dados);
        int ConsultarMax();
        int Incluir(dVenda dados);
        int Alterar(dVenda dados);
        int Excluir(dVenda dados);
    }
}
