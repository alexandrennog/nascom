using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsEfdContabilidade
    {
        public dEfdContabilidade Consultar();
        public int Salvar(dEfdContabilidade dados);
        public int Excluir();
    }
}