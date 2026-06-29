using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsEfdTipoAtividade
    {
        public ColecaoEfdTipoAtividade Listar();
    }
}