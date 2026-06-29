using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsCaracteristica
{
    public interface IsCaracteristicaItem
    {
        public ColecaoCaracteristicaItem Listar();
        public ColecaoCaracteristicaItem Consultar(dCaracteristicaItem dados);
        public dCaracteristicaItem ConsultarPorCID(int cid);
        public ColecaoCaracteristicaItem ConsultarPorCaracteristica(int caracteristica_cid);
        public int Incluir(dCaracteristicaItem dados);
        public int Alterar(dCaracteristicaItem dados);
        public int Excluir(dCaracteristicaItem dados);
        public int ExcluirPorCID(int cid);
    }
}