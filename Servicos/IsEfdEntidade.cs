using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsEfdEntidade
    {
        public dEfdEntidade Consultar();
        public int Salvar(dEfdEntidade dados);
        public int Excluir();
    }
}