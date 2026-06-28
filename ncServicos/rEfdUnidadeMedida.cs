using System;
using ncNComum;
using ncRepositorios;
using ncModelos;



namespace ncServicos
{
    public class rEfdUnidadeMedida
    {
        private readonly IpEfdUnidadeMedida _repo;
        public rEfdUnidadeMedida(IpEfdUnidadeMedida repo) { _repo = repo; }

        public ColecaoEfdUnidadeMedida Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar EfdUnidadeMedida [" + ToString() + "] - " + ex.Message); }
        }

        public dEfdUnidadeMedida Consultar(dEfdUnidadeMedida dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar EfdUnidadeMedida [" + ToString() + "] - " + ex.Message); }
        }

        public int Salvar(dEfdUnidadeMedida dados)
        {
            try
            {
                var existente = _repo.Consultar(dados);
                return existente == null ? _repo.Incluir(dados) : _repo.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Salvar EfdUnidadeMedida [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dEfdUnidadeMedida dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir EfdUnidadeMedida [" + ToString() + "] - " + ex.Message); }
        }
    }
}
