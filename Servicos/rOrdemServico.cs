using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsOrdemServico
{
    public class rOrdemServico
    {
        private readonly IpOrdemServico _repo;
        public rOrdemServico(IpOrdemServico repo) { _repo = repo; }

        public ColecaoOrdemServico Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar OrdemServico [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoOrdemServico Consultar(dOrdemServico dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar OrdemServico [" + ToString() + "] - " + ex.Message); }
        }

        public int ConsultarMax()
        {
            try { return _repo.ConsultarMax(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarMax OrdemServico [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dOrdemServico dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir OrdemServico [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dOrdemServico dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar OrdemServico [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dOrdemServico dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir OrdemServico [" + ToString() + "] - " + ex.Message); }
        }
    }
}
