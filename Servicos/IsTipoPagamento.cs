using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsTipoPagamento
    {
        public ColecaoTipoPagamento Listar();
        public string RetornarCodigo(int cid);
    }
}