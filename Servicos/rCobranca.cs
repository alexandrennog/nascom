using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsCobranca
{
    public class rCobranca
    {
        private readonly IpCobranca _repo;
        public rCobranca(IpCobranca repo) { _repo = repo; }

        public ColecaoCobranca ConsultarCobrancas(dCobrancaAutomatica dados)
        {
            try { return _repo.ListarCobrancas(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarCobrancas Cobranca [" + ToString() + "] - " + ex.Message); }
        }
    }
}
