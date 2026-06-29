using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsLoja
{
    public class rLoja : IsLoja
    {
        private readonly IpLoja _repo;
        public rLoja(IpLoja repo) { _repo = repo; }

        public ColecaoLoja Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Loja [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoLoja Consultar(dLoja dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Loja [" + ToString() + "] - " + ex.Message); }
        }

        public dLoja Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dLoja { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Loja [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dLoja dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Loja [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dLoja dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Loja [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dLoja dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Loja [" + ToString() + "] - " + ex.Message); }
        }
    }
}

