using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public class rProdutoTipoCaracteristica : IsProdutoTipoCaracteristica
    {
        private readonly IpProdutoTipoCaracteristica _repo;
        public rProdutoTipoCaracteristica(IpProdutoTipoCaracteristica repo) { _repo = repo; }

        public ColecaoProdutoTipoCaracteristica Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoProdutoTipoCaracteristica Consultar(dProdutoTipoCaracteristica dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoProdutoTipoCaracteristica ConsultarPorProdutoTipo(int produtoTipo_cid)
        {
            try { return _repo.ConsultarPorProdutoTipo(produtoTipo_cid); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarPorProdutoTipo ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dProdutoTipoCaracteristica dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public int ExcluirPorProdutoTipo(int produtoTipo_cid)
        {
            try { return _repo.ExcluirPorProdutoTipo(produtoTipo_cid); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ExcluirPorProdutoTipo ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public int ExcluirPorCaracteristica(int caracteristica_cid)
        {
            try { return _repo.ExcluirPorCaracteristica(caracteristica_cid); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ExcluirPorCaracteristica ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(int cid)
        {
            try { return _repo.Excluir(cid); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message); }
        }
    }
}

