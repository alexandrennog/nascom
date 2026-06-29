using System;
using System.Transactions;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public class rCliente : IsCliente
    {
        private readonly IpCliente _repo;
        private readonly IpClienteEndereco _clienteEndereco;
        private readonly IpClienteFinanceiro _clienteFinanceiro;
        private readonly IpClienteProfissional _clienteProfissional;

        public rCliente(IpCliente repo, IpClienteEndereco clienteEndereco,
            IpClienteFinanceiro clienteFinanceiro, IpClienteProfissional clienteProfissional)
        {
            _repo = repo;
            _clienteEndereco = clienteEndereco;
            _clienteFinanceiro = clienteFinanceiro;
            _clienteProfissional = clienteProfissional;
        }

        public ColecaoCliente Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Cliente [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoCliente Consultar(dCliente dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Cliente [" + ToString() + "] - " + ex.Message); }
        }

        public dCliente ConsultarPorCID(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dCliente { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarPorCID Cliente [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dCliente dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Cliente [" + ToString() + "] - " + ex.Message); }
        }

        public int IncluirImportacao(dCliente dados)
        {
            try { return _repo.IncluirCid(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em IncluirImportacao Cliente [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dCliente dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Cliente [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dCliente dados)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    _clienteEndereco.ExcluirPorCliente((int)dados.cid);
                    _clienteFinanceiro.ExcluirPorCliente((int)dados.cid);
                    _clienteProfissional.ExcluirPorCliente((int)dados.cid);
                    int retorno = _repo.Excluir(dados);
                    ts.Complete();
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Cliente [" + ToString() + "] - " + ex.Message); }
        }
    }
}

