using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsTipoFluxo
    {
        public ColecaoTipoFluxo Listar();
        public string RetornarCodigo(int cid);
    }
}