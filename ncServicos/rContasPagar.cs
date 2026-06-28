using System;
using ncNComum;
using ncRepositorios;
using ncModelos;

namespace ncServicos.nsContasPagar
{
    public class rContasPagar
    {
        private readonly IpContasPagar _repo;
        public rContasPagar(IpContasPagar repo) { _repo = repo; }

        public ColecaoContasPagar Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar ContasPagar [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoContasPagar Consultar(dContasPagar dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar ContasPagar [" + ToString() + "] - " + ex.Message); }
        }

        public dContasPagar Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dContasPagar { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar ContasPagar [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dContasPagar dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir ContasPagar [" + ToString() + "] - " + ex.Message); }
        }

        public int Importar(dContasPagar dados)
        {
            try { return _repo.Importar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Importar ContasPagar [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dContasPagar dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar ContasPagar [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dContasPagar dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir ContasPagar [" + ToString() + "] - " + ex.Message); }
        }
    }
}
