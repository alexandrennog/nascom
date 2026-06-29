using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsCobranca
{
    public interface IsCobranca
    {
        public ColecaoCobranca ConsultarCobrancas(dCobrancaAutomatica dados);
    }
}