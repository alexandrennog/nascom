using System;
using nsEFD;
using ncPersistencia.nsEFD;
using ncComum.nsExcecao;

namespace ncServicos.nsEFD
{
    public class sEfdEnderecoContato
    {
        private readonly IpEfdEnderecoContato _repo;
        public sEfdEnderecoContato(IpEfdEnderecoContato repo) { _repo = repo; }

        public dEfdEnderecoContato Consultar()
        {
            try { return _repo.Consultar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar EfdEnderecoContato [" + ToString() + "] - " + ex.Message); }
        }

        public int Salvar(dEfdEnderecoContato dados)
        {
            try
            {
                var existente = _repo.Consultar();
                return existente == null ? _repo.Incluir(dados) : _repo.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Salvar EfdEnderecoContato [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir()
        {
            try { return _repo.Excluir(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir EfdEnderecoContato [" + ToString() + "] - " + ex.Message); }
        }
    }
}
