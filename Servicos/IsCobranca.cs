using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsCobranca
    {
        public ColecaoCobranca ConsultarCobrancas(dCobrancaAutomatica dados);
    }
}