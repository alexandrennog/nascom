using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsTipoEmissao
    {
        public ColecaoTipoEmissao Listar();
        public string RetornarCodigo(int cid);
    }
}