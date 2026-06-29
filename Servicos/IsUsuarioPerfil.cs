using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsUsuarioPerfil
{
    public interface IsUsuarioPerfil
    {
        public ColecaoUsuarioPerfil Listar();
        public ColecaoUsuarioPerfil Consultar(dUsuarioPerfil dados);
        public dUsuarioPerfil Consultar(int cid);
        public int Incluir(dUsuarioPerfil dados);
        public int Alterar(dUsuarioPerfil dados);
        public int Excluir(dUsuarioPerfil dados);
    }
}