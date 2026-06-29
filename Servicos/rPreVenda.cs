using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsVenda
{
    public class rPreVenda : IsPreVenda
    {
        private readonly IpPreVenda _repo;
        public rPreVenda(IpPreVenda repo) { _repo = repo; }

        public ColecaoVenda Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar PreVenda [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoVenda Consultar(dVenda dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar PreVenda [" + ToString() + "] - " + ex.Message); }
        }

        public int ConsultarMax()
        {
            try { return _repo.ConsultarMax(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarMax PreVenda [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dVenda dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir PreVenda [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dVenda dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar PreVenda [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dVenda dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir PreVenda [" + ToString() + "] - " + ex.Message); }
        }
    }
}
