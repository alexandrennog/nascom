using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsEfdFinalidadeArquivo
    {
        public ColecaoEfdFinalidadeArquivo Listar();
    }
}