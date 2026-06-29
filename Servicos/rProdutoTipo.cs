using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public class rProdutoTipo : IsProdutoTipo
    {
        private readonly IpProdutoTipo _repo;
        public rProdutoTipo(IpProdutoTipo repo) { _repo = repo; }

        public ColecaoProdutoTipo Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar ProdutoTipo [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoProdutoTipo Consultar(dProdutoTipo dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar ProdutoTipo [" + ToString() + "] - " + ex.Message); }
        }

        public dProdutoTipo Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dProdutoTipo { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar ProdutoTipo [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dProdutoTipo dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir ProdutoTipo [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dProdutoTipo dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar ProdutoTipo [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dProdutoTipo dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir ProdutoTipo [" + ToString() + "] - " + ex.Message); }
        }
    }
}

