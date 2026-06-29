using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsEfdPerfilArquivoFiscal
    {
        public ColecaoEfdPerfilArquivoFiscal Listar();
    }
}