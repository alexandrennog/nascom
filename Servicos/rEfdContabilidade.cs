using System;
using Comum;
using Repositorios;
using Modelos;



namespace Servicos
{
    public class rEfdContabilidade
    {
        private readonly IpEfdContabilidade _repo;
        public rEfdContabilidade(IpEfdContabilidade repo) { _repo = repo; }

        public dEfdContabilidade Consultar()
        {
            try { return _repo.Consultar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar EfdContabilidade [" + ToString() + "] - " + ex.Message); }
        }

        public int Salvar(dEfdContabilidade dados)
        {
            try
            {
                var existente = _repo.Consultar();
                return existente == null ? _repo.Incluir(dados) : _repo.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Salvar EfdContabilidade [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir()
        {
            try { return _repo.Excluir(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir EfdContabilidade [" + ToString() + "] - " + ex.Message); }
        }
    }
}
