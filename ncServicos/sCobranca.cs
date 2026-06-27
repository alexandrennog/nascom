using System;
using ncDados.nsCobranca;
using ncComum.nsExcecao;

namespace ncServicos.nsCobranca
{
    public class sCobranca
    {
        private readonly IpCobranca _repo;
        public sCobranca(IpCobranca repo) { _repo = repo; }

        public ColecaoCobranca ConsultarCobrancas(dCobrancaAutomatica dados)
        {
            try { return _repo.ListarCobrancas(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarCobrancas Cobranca [" + ToString() + "] - " + ex.Message); }
        }
    }
}
