using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsSituacaoNotaFiscal
    {
        public ColecaoSituacaoNotaFiscal Listar();
        public string RetornarCodigo(int cid);
    }
}