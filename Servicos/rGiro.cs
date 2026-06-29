using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsGiro
{
    public class rGiro
    {
        private readonly IpGiro _repo;
        public rGiro(IpGiro repo) { _repo = repo; }

        public ColecaoGiro Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Giro [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoGiro Consultar(dGiro dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Giro [" + ToString() + "] - " + ex.Message); }
        }

        public dGiro Consultar(int produto_cid, string codigoBarras)
        {
            try
            {
                var lista = _repo.Consultar(new dGiro { produto_cid = produto_cid, codigoBarras = codigoBarras });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Giro [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dGiro dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Giro [" + ToString() + "] - " + ex.Message); }
        }

        public int Importar(dGiro dados)
        {
            try { return _repo.Importar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Importar Giro [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dGiro dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Giro [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dGiro dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Giro [" + ToString() + "] - " + ex.Message); }
        }
    }
}
