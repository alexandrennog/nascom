using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsCaracteristica
    {
        public ColecaoCaracteristica Listar();
        public ColecaoCaracteristica Consultar(dCaracteristica dados);
        public dCaracteristica ConsultarPorCID(int cid);
        public dCaracteristica ConsultarPorNome(string nome);
        public dCaracteristica ConsultarPorCodigo(string codigo);
        public int Incluir(dCaracteristica dados);
        public int Alterar(dCaracteristica dados);
        public int Excluir(dCaracteristica dados);
    }
}