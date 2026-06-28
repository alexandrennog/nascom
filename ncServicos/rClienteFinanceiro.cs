using System;
using ncNComum;
using ncRepositorios;
using ncModelos;

namespace ncServicos.nsCliente
{
    public class rClienteFinanceiro
    {
        private readonly IpClienteFinanceiro _repo;
        public rClienteFinanceiro(IpClienteFinanceiro repo) { _repo = repo; }

        public ColecaoClienteFinanceiro Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar ClienteFinanceiro [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoClienteFinanceiro Consultar(dClienteFinanceiro dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar ClienteFinanceiro [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dClienteFinanceiro dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir ClienteFinanceiro [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dClienteFinanceiro dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar ClienteFinanceiro [" + ToString() + "] - " + ex.Message); }
        }

        public int ExcluirPorCliente(int cliente_cid)
        {
            try { return _repo.ExcluirPorCliente(cliente_cid); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ExcluirPorCliente ClienteFinanceiro [" + ToString() + "] - " + ex.Message); }
        }
    }
}
