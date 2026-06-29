using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsEstadoCivil
    {
        public ColecaoEstadoCivil Listar();
    }
}