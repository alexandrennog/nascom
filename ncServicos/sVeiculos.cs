using System;
using ncDados.nsVeiculos;
using ncPersistencia.nsVeiculos;
using ncComum.nsExcecao;

namespace ncServicos.nsVeiculos
{
    public class sVeiculos
    {
        private readonly IpVeiculos _repo;
        public sVeiculos(IpVeiculos repo) { _repo = repo; }

        public ColecaoVeiculos Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Veiculos [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoVeiculos Consultar(dVeiculos dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Veiculos [" + ToString() + "] - " + ex.Message); }
        }

        public dVeiculos ConsultarPorCID(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dVeiculos { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarPorCID Veiculos [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(ColecaoVeiculos dadosVeiculos)
        {
            try
            {
                foreach (var v in dadosVeiculos)
                    _repo.Incluir(v);
                return 1;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Veiculos [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dVeiculos dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Veiculos [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(ColecaoVeiculos dadosVeiculos)
        {
            try
            {
                foreach (var v in dadosVeiculos)
                    _repo.Alterar(v);
                return 1;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Veiculos [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dVeiculos dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Veiculos [" + ToString() + "] - " + ex.Message); }
        }

        public int ExcluirVeiculosCliente(dVeiculos dados)
        {
            try { return _repo.ExcluirVeiculosCliente(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ExcluirVeiculosCliente Veiculos [" + ToString() + "] - " + ex.Message); }
        }
    }
}
