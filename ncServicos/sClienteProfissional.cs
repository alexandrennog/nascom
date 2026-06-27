using System;
using ncDados.nsCliente;
using ncPersistencia.nsCliente;
using ncComum.nsExcecao;

namespace ncServicos.nsCliente
{
    public class sClienteProfissional
    {
        private readonly IpClienteProfissional _repo;
        public sClienteProfissional(IpClienteProfissional repo) { _repo = repo; }

        public ColecaoClienteProfissional Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar ClienteProfissional [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoClienteProfissional Consultar(dClienteProfissional dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar ClienteProfissional [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dClienteProfissional dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir ClienteProfissional [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dClienteProfissional dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar ClienteProfissional [" + ToString() + "] - " + ex.Message); }
        }

        public int ExcluirPorCliente(int cliente_cid)
        {
            try { return _repo.ExcluirPorCliente(cliente_cid); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ExcluirPorCliente ClienteProfissional [" + ToString() + "] - " + ex.Message); }
        }
    }
}
