using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsVenda
{
    public class rPreVendaProduto : IsPreVendaProduto
    {
        private readonly IpPreVendaProduto _repo;
        public rPreVendaProduto(IpPreVendaProduto repo) { _repo = repo; }

        public ColecaoVendaProduto Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar PreVendaProduto [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoVendaProduto Consultar(dVendaProduto dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar PreVendaProduto [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dVendaProduto dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir PreVendaProduto [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dVendaProduto dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar PreVendaProduto [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dVendaProduto dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir PreVendaProduto [" + ToString() + "] - " + ex.Message); }
        }
    }
}

