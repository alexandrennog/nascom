using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsEfdArquivo
    {
        public dEfdArquivo Consultar();
        public int Salvar(dEfdArquivo dados);
        public int Excluir();
    }
}