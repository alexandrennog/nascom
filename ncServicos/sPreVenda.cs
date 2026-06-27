using System;
using ncDados.nsVenda;
using ncRegras.nsVenda;
using ncComum.nsExcecao;

namespace ncServicos.nsVenda
{
    public class sPreVenda
    {
        public ColecaoVenda Listar()
        {
            try
            {
                var regra = new rPreVenda();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar PreVenda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVenda Consultar(dVenda dados)
        {
            try
            {
                var regra = new rPreVenda();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar PreVenda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ConsultarMax()
        {
            try
            {
                var regra = new rPreVenda();
                return regra.ConsultarMax();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarMax PreVenda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dVenda dados)
        {
            try
            {
                var regra = new rPreVenda();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir PreVenda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dVenda dados)
        {
            try
            {
                var regra = new rPreVenda();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar PreVenda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dVenda dados)
        {
            try
            {
                var regra = new rPreVenda();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir PreVenda [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
