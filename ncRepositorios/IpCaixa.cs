using System;
using nsCaixa;

namespace ncPersistencia.nsCaixa
{
    public interface IpCaixa
    {
        ColecaoCaixa Listar();
        ColecaoCaixa Consultar(dCaixa dados);
        ColecaoFechamento ConsultarFechamento(dCaixa dados);
        int Incluir(dCaixa dados);
        int Alterar(dCaixa dados);
        int Excluir(dCaixa dados);
    }
}
