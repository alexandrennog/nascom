using System;
using ncDados.nsMunicipios;
using ncRegras.nsMunicipios;
using ncComum.nsExcecao;

namespace ncServicos.nsMunicipios
{
    public class sMunicipios
    {
        public ColecaoMunicipios Listar()
        {
            try
            {
                var regra = new rMunicipios();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Municipios [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoMunicipios ListarPorEstados(int estados_cid)
        {
            try
            {
                var regra = new rMunicipios();
                return regra.ListarPorEstados(estados_cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ListarPorEstados Municipios [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoMunicipios Consultar(dMunicipios dados)
        {
            try
            {
                var regra = new rMunicipios();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Municipios [" + ToString() + "] - " + ex.Message);
            }
        }

        public dMunicipios Consultar(int cid)
        {
            try
            {
                var regra = new rMunicipios();
                return regra.Consultar(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Municipios [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dMunicipios dados)
        {
            try
            {
                var regra = new rMunicipios();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Municipios [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Importar(dMunicipios dados)
        {
            try
            {
                var regra = new rMunicipios();
                return regra.Importar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Importar Municipios [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dMunicipios dados)
        {
            try
            {
                var regra = new rMunicipios();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Municipios [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dMunicipios dados)
        {
            try
            {
                var regra = new rMunicipios();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Municipios [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
