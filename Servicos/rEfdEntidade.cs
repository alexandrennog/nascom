using System;
using Comum;
using Repositorios;
using Modelos;



namespace Servicos
{
    public class rEfdEntidade
    {
        private readonly IpEfdEntidade _repo;
        public rEfdEntidade(IpEfdEntidade repo) { _repo = repo; }

        public dEfdEntidade Consultar()
        {
            try { return _repo.Consultar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar EfdEntidade [" + ToString() + "] - " + ex.Message); }
        }

        public int Salvar(dEfdEntidade dados)
        {
            try
            {
                var existente = _repo.Consultar();
                return existente == null ? _repo.Incluir(dados) : _repo.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Salvar EfdEntidade [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir()
        {
            try { return _repo.Excluir(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir EfdEntidade [" + ToString() + "] - " + ex.Message); }
        }
    }
}
