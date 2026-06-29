using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsTipoResidencia
    {
        public ColecaoTipoResidencia Listar();
    }
}