using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsTipoNotaFiscal
    {
        public ColecaoTipoNotaFiscal Listar();
        public string RetornarCodigo(int cid);
    }
}