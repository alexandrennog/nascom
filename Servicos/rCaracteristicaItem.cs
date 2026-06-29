using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public class rCaracteristicaItem : IsCaracteristicaItem
    {
        private readonly IpCaracteristicaItem _repo;
        public rCaracteristicaItem(IpCaracteristicaItem repo) { _repo = repo; }

        public ColecaoCaracteristicaItem Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar CaracteristicaItem [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoCaracteristicaItem Consultar(dCaracteristicaItem dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar CaracteristicaItem [" + ToString() + "] - " + ex.Message); }
        }

        public dCaracteristicaItem ConsultarPorCID(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dCaracteristicaItem { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarPorCID CaracteristicaItem [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoCaracteristicaItem ConsultarPorCaracteristica(int caracteristica_cid)
        {
            try { return _repo.Consultar(new dCaracteristicaItem { cid = caracteristica_cid }); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarPorCaracteristica CaracteristicaItem [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dCaracteristicaItem dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir CaracteristicaItem [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dCaracteristicaItem dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar CaracteristicaItem [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dCaracteristicaItem dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir CaracteristicaItem [" + ToString() + "] - " + ex.Message); }
        }

        public int ExcluirPorCID(int cid)
        {
            try { return _repo.Excluir(new dCaracteristicaItem { cid = cid }); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ExcluirPorCID CaracteristicaItem [" + ToString() + "] - " + ex.Message); }
        }
    }
}

