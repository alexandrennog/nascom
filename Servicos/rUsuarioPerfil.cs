using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public class rUsuarioPerfil : IsUsuarioPerfil
    {
        private readonly IpUsuarioPerfil _repo;
        public rUsuarioPerfil(IpUsuarioPerfil repo) { _repo = repo; }

        public ColecaoUsuarioPerfil Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar UsuarioPerfil [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoUsuarioPerfil Consultar(dUsuarioPerfil dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar UsuarioPerfil [" + ToString() + "] - " + ex.Message); }
        }

        public dUsuarioPerfil Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dUsuarioPerfil { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar UsuarioPerfil [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dUsuarioPerfil dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir UsuarioPerfil [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dUsuarioPerfil dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar UsuarioPerfil [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dUsuarioPerfil dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir UsuarioPerfil [" + ToString() + "] - " + ex.Message); }
        }
    }
}

