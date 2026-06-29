using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsTipoFrete
    {
        public ColecaoTipoFrete Listar();
        public string RetornarCodigo(int cid);
    }
}