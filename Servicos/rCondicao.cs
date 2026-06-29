using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsCondicao
{
    public class rCondicao : IsCondicao
    {
        private readonly IpCondicao _repo;
        public rCondicao(IpCondicao repo) { _repo = repo; }

        public ColecaoCondicao Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Condicao [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoCondicao Consultar(dCondicao dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Condicao [" + ToString() + "] - " + ex.Message); }
        }

        public dCondicao Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dCondicao { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Condicao [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dCondicao dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Condicao [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dCondicao dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Condicao [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dCondicao dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Condicao [" + ToString() + "] - " + ex.Message); }
        }
    }
}

