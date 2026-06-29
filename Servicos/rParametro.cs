using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsParametro
{
    public class rParametro
    {
        private readonly IpParametro _repo;
        public rParametro(IpParametro repo) { _repo = repo; }

        public ColecaoParametro Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Parametro [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoParametro Consultar(dParametro dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Parametro [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoParametroEstoque ConsultarEstoque(dParametroEstoque dados)
        {
            try { return _repo.ConsultarEstoque(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarEstoque Parametro [" + ToString() + "] - " + ex.Message); }
        }

        public dParametro Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dParametro { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Parametro [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dParametro dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Parametro [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dParametro dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Parametro [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dParametro dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Parametro [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}