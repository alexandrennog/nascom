using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsVenda
{
    public class rVendaProduto : IsVendaProduto
    {
        private readonly IpVendaProduto _repo;
        public rVendaProduto(IpVendaProduto repo) { _repo = repo; }

        public ColecaoVendaProduto Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar VendaProduto [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoVendaProduto Consultar(dVendaProduto dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar VendaProduto [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoVendaProduto ConsultarTroca(dVendaProduto dados)
        {
            try { return _repo.ConsultarTroca(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarTroca VendaProduto [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dVendaProduto dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir VendaProduto [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dVendaProduto dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar VendaProduto [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dVendaProduto dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir VendaProduto [" + ToString() + "] - " + ex.Message); }
        }

        public int ExcluirTroca(dVendaProduto dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ExcluirTroca VendaProduto [" + ToString() + "] - " + ex.Message); }
        }

        public int ExcluirControle(int controle)
        {
            try { return _repo.ExcluirControle(controle); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ExcluirControle VendaProduto [" + ToString() + "] - " + ex.Message); }
        }

        public int ExcluirControleTroca(int controle)
        {
            try { return _repo.ExcluirControleTroca(controle); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ExcluirControleTroca VendaProduto [" + ToString() + "] - " + ex.Message); }
        }
    }
}

