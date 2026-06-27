using System;
using nsCrediario;

namespace ncPersistencia.nsCrediario
{
    public interface IpCrediario
    {
        ColecaoCrediario Listar();
        int ConsultarMax();
        ColecaoCrediario Consultar(dCrediario dados);
        int Incluir(dCrediario dados);
        int Alterar(dCrediario dados);
        int AlterarControle(dCrediario dados);
        int Excluir(dCrediario dados);
        int ExcluirParcelas(dCrediario dados);
    }
}
