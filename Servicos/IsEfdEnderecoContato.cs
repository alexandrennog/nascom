using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsEfdEnderecoContato
    {
        public dEfdEnderecoContato Consultar();
        public int Salvar(dEfdEnderecoContato dados);
        public int Excluir();
    }
}