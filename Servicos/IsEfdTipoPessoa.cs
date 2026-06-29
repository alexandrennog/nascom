using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsEfdTipoPessoa
    {
        public ColecaoEfdTipoPessoa Listar();
    }
}