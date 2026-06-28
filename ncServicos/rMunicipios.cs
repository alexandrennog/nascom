using System;
using ncNComum;
using ncRepositorios;
using ncModelos;

namespace ncServicos.nsMunicipios
{
    public class rMunicipios
    {
        private readonly IpMunicipios _repo;
        public rMunicipios(IpMunicipios repo) { _repo = repo; }

        public ColecaoMunicipios Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Municipios [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoMunicipios ListarPorEstados(int estados_cid)
        {
            try { return _repo.ListarPorEstado(estados_cid); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ListarPorEstados Municipios [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoMunicipios Consultar(dMunicipios dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Municipios [" + ToString() + "] - " + ex.Message); }
        }

        public dMunicipios Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dMunicipios { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Municipios [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dMunicipios dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Municipios [" + ToString() + "] - " + ex.Message); }
        }

        public int Importar(dMunicipios dados)
        {
            try { return _repo.Importar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Importar Municipios [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dMunicipios dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Municipios [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dMunicipios dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Municipios [" + ToString() + "] - " + ex.Message); }
        }
    }
}
