using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsEfdUnidadeMedida
    {
        public ColecaoEfdUnidadeMedida Listar();
        public dEfdUnidadeMedida Consultar(dEfdUnidadeMedida dados);
        public int Salvar(dEfdUnidadeMedida dados);
        public int Excluir(dEfdUnidadeMedida dados);
    }
}