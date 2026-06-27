using System;
using ncDados.nsLoja;
using ncRegras.nsLoja;
using ncComum.nsExcecao;

namespace ncServicos.nsLoja
{
    public class sLoja
    {
        public ColecaoLoja Listar()
        {
            try
            {
                var regra = new rLoja();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Loja [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoLoja Consultar(dLoja dados)
        {
            try
            {
                var regra = new rLoja();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Loja [" + ToString() + "] - " + ex.Message);
            }
        }

        public dLoja Consultar(int cid)
        {
            try
            {
                var regra = new rLoja();
                return regra.Consultar(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Loja [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dLoja dados)
        {
            try
            {
                var regra = new rLoja();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Loja [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dLoja dados)
        {
            try
            {
                var regra = new rLoja();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Loja [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dLoja dados)
        {
            try
            {
                var regra = new rLoja();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Loja [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
