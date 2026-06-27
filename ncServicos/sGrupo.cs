using System;
using ncDados.nsGrupo;
using ncPersistencia.nsGrupo;
using ncComum.nsExcecao;

namespace ncServicos.nsGrupo
{
    public class sGrupo
    {
        private readonly IpGrupo _repo;
        public sGrupo(IpGrupo repo) { _repo = repo; }

        public ColecaoGrupo Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Grupo [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoGrupo Consultar(dGrupo dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Grupo [" + ToString() + "] - " + ex.Message); }
        }

        public dGrupo Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dGrupo { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Grupo [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dGrupo dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Grupo [" + ToString() + "] - " + ex.Message); }
        }

        public int Importar(dGrupo dados)
        {
            try { return _repo.Importar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Importar Grupo [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dGrupo dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Grupo [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dGrupo dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Grupo [" + ToString() + "] - " + ex.Message); }
        }
    }
}
