using nsCaracteristica;
using System;


namespace ncPersistencia.nsCaracteristica
{
    public interface IpCaracteristicaItem
    {
        ColecaoCaracteristicaItem Listar();
        ColecaoCaracteristicaItem Consultar(dCaracteristicaItem dados);
        int Incluir(dCaracteristicaItem dados);
        int Alterar(dCaracteristicaItem dados);
        int Excluir(dCaracteristicaItem dados);
    }
}
