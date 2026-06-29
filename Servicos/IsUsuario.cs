using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsUsuario
{
    public interface IsUsuario
    {
        public ColecaoUsuario Listar();
        public ColecaoUsuario Consultar(dUsuario dados);
        public ColecaoUsuario ConsultarPorADM(dUsuario dados);
        public dUsuario ConsultarPorCid(int cid);
        public dUsuario ConsultarPorEmail(string email);
        public int Incluir(dUsuario dados);
        public int Alterar(dUsuario dados);
        public int Excluir(dUsuario dados);
    }
}