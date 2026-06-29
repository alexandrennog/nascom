using System;
using Modelos;
using Repositorios;
using Comum;

namespace Servicos
{
    public class rCaixa : IsCaixa
    {
        private readonly IpCaixa _repo;
        public rCaixa(IpCaixa repo) { _repo = repo; }

        public ColecaoCaixa Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Caixa [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoCaixa Consultar(dCaixa dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Caixa [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoFechamento ConsultarFechamento(dCaixa dados)
        {
            try { return _repo.ConsultarFechamento(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarFechamento Caixa [" + ToString() + "] - " + ex.Message); }
        }

        public dCaixa Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dCaixa { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Caixa [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dCaixa dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Caixa [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dCaixa dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Caixa [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dCaixa dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Caixa [" + ToString() + "] - " + ex.Message); }
        }
    }
}
