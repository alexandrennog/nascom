using System;
using ncDados.nsFabricante;
using ncPersistencia.nsFabricante;
using ncComum.nsExcecao;

namespace ncServicos.nsFabricante
{
    public class sFabricante
    {
        private readonly IpFabricante _repo;
        public sFabricante(IpFabricante repo) { _repo = repo; }

        public ColecaoFabricante Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Fabricante [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoFabricante Consultar(dFabricante dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Fabricante [" + ToString() + "] - " + ex.Message); }
        }

        public dFabricante Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dFabricante { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Fabricante [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dFabricante dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Fabricante [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dFabricante dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Fabricante [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dFabricante dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Fabricante [" + ToString() + "] - " + ex.Message); }
        }
    }
}
