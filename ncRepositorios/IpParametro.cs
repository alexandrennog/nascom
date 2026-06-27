using System;
using nsParametro;
using nsdParametroEstoque;

namespace ncPersistencia.nsParametro
{
    public interface IpParametro
    {
        ColecaoParametro Listar();
        ColecaoParametro Consultar(dParametro dados);
        ColecaoParametroEstoque ConsultarEstoque(dParametroEstoque dados);
        int Incluir(dParametro dados);
        int Alterar(dParametro dados);
        int Excluir(dParametro dados);
    }
}
