using System;
using ncDados.nsFabricante;
using ncRegras.nsFabricante;
using ncComum.nsExcecao;

namespace ncServicos.nsFabricante
{
    public class sFabricante
    {
        public ColecaoFabricante Listar()
        {
            try
            {
                var regra = new rFabricante();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Fabricante [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoFabricante Consultar(dFabricante dados)
        {
            try
            {
                var regra = new rFabricante();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Fabricante [" + ToString() + "] - " + ex.Message);
            }
        }

        public dFabricante Consultar(int cid)
        {
            try
            {
                var regra = new rFabricante();
                return regra.Consultar(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Fabricante [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dFabricante dados)
        {
            try
            {
                var regra = new rFabricante();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Fabricante [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dFabricante dados)
        {
            try
            {
                var regra = new rFabricante();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Fabricante [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dFabricante dados)
        {
            try
            {
                var regra = new rFabricante();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Fabricante [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
