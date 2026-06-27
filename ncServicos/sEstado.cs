using System;
using ncDados.nsEstado;
using ncPersistencia.nsEstado;
using ncComum.nsExcecao;

namespace ncServicos.nsEstado
{
    public class sEstado
    {
        private readonly IpEstado _repo;
        public sEstado(IpEstado repo) { _repo = repo; }

        public ColecaoEstado Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Estado [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoEstado Consultar(dEstado dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Estado [" + ToString() + "] - " + ex.Message); }
        }

        public dEstado Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dEstado { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Estado [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dEstado dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Estado [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dEstado dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Estado [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dEstado dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Estado [" + ToString() + "] - " + ex.Message); }
        }
    }
}
