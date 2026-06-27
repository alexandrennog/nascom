using System;
using ncDados.nsCor;
using ncPersistencia.nsCor;
using ncComum.nsExcecao;

namespace ncServicos.nsCor
{
    public class sCor
    {
        private readonly IpCor _repo;
        public sCor(IpCor repo) { _repo = repo; }

        public ColecaoCor Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Cor [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoCor Consultar(dCor dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Cor [" + ToString() + "] - " + ex.Message); }
        }

        public dCor Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dCor { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Cor [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dCor dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Cor [" + ToString() + "] - " + ex.Message); }
        }

        public int Importar(dCor dados)
        {
            try { return _repo.Importar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Importar Cor [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dCor dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Cor [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dCor dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Cor [" + ToString() + "] - " + ex.Message); }
        }
    }
}
