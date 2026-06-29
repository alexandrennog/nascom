using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsSituacao
    {
        public ColecaoSituacao Listar();
        public ColecaoSituacao ListarFinan();
    }
}