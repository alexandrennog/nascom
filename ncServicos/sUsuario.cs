using System;
using ncDados.nsUsuario;
using ncPersistencia.nsUsuario;
using ncComum.nsExcecao;

namespace ncServicos.nsUsuario
{
    public class sUsuario
    {
        private readonly IpUsuario _repo;
        public sUsuario(IpUsuario repo) { _repo = repo; }

        public ColecaoUsuario Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Usuario [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoUsuario Consultar(dUsuario dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Usuario [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoUsuario ConsultarPorADM(dUsuario dados)
        {
            try { return _repo.ConsultarADM(dados.perfil); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarPorADM Usuario [" + ToString() + "] - " + ex.Message); }
        }

        public dUsuario ConsultarPorCid(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dUsuario { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarPorCid Usuario [" + ToString() + "] - " + ex.Message); }
        }

        public dUsuario ConsultarPorEmail(string email)
        {
            try
            {
                var lista = _repo.Consultar(new dUsuario { email = email });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarPorEmail Usuario [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dUsuario dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Usuario [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dUsuario dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Usuario [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dUsuario dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Usuario [" + ToString() + "] - " + ex.Message); }
        }
    }
}
