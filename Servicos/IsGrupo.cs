using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsGrupo
    {
        public ColecaoGrupo Listar();
        public ColecaoGrupo Consultar(dGrupo dados);
        public dGrupo Consultar(int cid);
        public int Incluir(dGrupo dados);
        public int Importar(dGrupo dados);
        public int Alterar(dGrupo dados);
        public int Excluir(dGrupo dados);
    }
}