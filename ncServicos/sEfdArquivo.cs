using System;
using nsEFD;
using ncPersistencia.nsEFD;
using ncComum.nsExcecao;

namespace ncServicos.nsEFD
{
    public class sEfdArquivo
    {
        private readonly IpEfdArquivo _repo;
        public sEfdArquivo(IpEfdArquivo repo) { _repo = repo; }

        public dEfdArquivo Consultar()
        {
            try { return _repo.Consultar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar EfdArquivo [" + ToString() + "] - " + ex.Message); }
        }

        public int Salvar(dEfdArquivo dados)
        {
            try
            {
                var existente = _repo.Consultar();
                return existente == null ? _repo.Incluir(dados) : _repo.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Salvar EfdArquivo [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir()
        {
            try { return _repo.Excluir(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir EfdArquivo [" + ToString() + "] - " + ex.Message); }
        }
    }
}
