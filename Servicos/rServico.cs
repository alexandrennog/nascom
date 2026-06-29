using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsServico
{
    public class rServico : IsServico
    {
        private readonly IpServico _repo;
        public rServico(IpServico repo) { _repo = repo; }

        public ColecaoServico Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Servico [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoServico Consultar(dServico dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Servico [" + ToString() + "] - " + ex.Message); }
        }

        public dServico Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dServico { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Servico [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dServico dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Servico [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dServico dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Servico [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dServico dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Servico [" + ToString() + "] - " + ex.Message); }
        }
    }
}

