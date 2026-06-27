using System;
using ncDados.nsCategoria;
using ncPersistencia.nsCategoria;
using ncComum.nsExcecao;

namespace ncServicos.nsCategoria
{
    public class sCategoria
    {
        private readonly IpCategoria _repo;
        public sCategoria(IpCategoria repo) { _repo = repo; }

        public ColecaoCategoria Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Categoria [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoCategoria Consultar(dCategoria dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Categoria [" + ToString() + "] - " + ex.Message); }
        }

        public dCategoria Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dCategoria { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Categoria [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dCategoria dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Categoria [" + ToString() + "] - " + ex.Message); }
        }

        public int Importar(dCategoria dados)
        {
            try { return _repo.Importar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Importar Categoria [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dCategoria dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Categoria [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dCategoria dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Categoria [" + ToString() + "] - " + ex.Message); }
        }
    }
}
