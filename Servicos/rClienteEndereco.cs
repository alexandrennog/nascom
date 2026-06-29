using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsCliente
{
    public class rClienteEndereco
    {
        private readonly IpClienteEndereco _repo;
        public rClienteEndereco(IpClienteEndereco repo) { _repo = repo; }

        public ColecaoClienteEndereco Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar ClienteEndereco [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoClienteEndereco Consultar(dClienteEndereco dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar ClienteEndereco [" + ToString() + "] - " + ex.Message); }
        }

        public dClienteEndereco ConsultarPorCID(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dClienteEndereco { cliente_cid  = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarPorCID ClienteEndereco [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dClienteEndereco dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir ClienteEndereco [" + ToString() + "] - " + ex.Message); }
        }

        public int ExcluirPorCliente(int cliente_cid)
        {
            try { return _repo.ExcluirPorCliente(cliente_cid); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ExcluirPorCliente ClienteEndereco [" + ToString() + "] - " + ex.Message); }
        }
    }
}
