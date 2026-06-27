using System;
using ncDados.nsCaracteristica;
using ncPersistencia.nsCaracteristica;
using ncComum.nsExcecao;

namespace ncServicos.nsCaracteristica
{
    public class sCaracteristica
    {
        private readonly IpCaracteristica _repo;
        public sCaracteristica(IpCaracteristica repo) { _repo = repo; }

        public ColecaoCaracteristica Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Caracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoCaracteristica Consultar(dCaracteristica dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Caracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public dCaracteristica ConsultarPorCID(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dCaracteristica { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarPorCID Caracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public dCaracteristica ConsultarPorNome(string nome)
        {
            try
            {
                var lista = _repo.Consultar(new dCaracteristica { nome = nome });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarPorNome Caracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public dCaracteristica ConsultarPorCodigo(string codigo)
        {
            try
            {
                var lista = _repo.Consultar(new dCaracteristica { codigo = codigo });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarPorCodigo Caracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dCaracteristica dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Caracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dCaracteristica dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Caracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dCaracteristica dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Caracteristica [" + ToString() + "] - " + ex.Message); }
        }
    }
}
