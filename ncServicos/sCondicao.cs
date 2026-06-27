using System;
using ncDados.nsCondicao;
using ncRegras.nsCondicao;
using ncComum.nsExcecao;

namespace ncServicos.nsCondicao
{
    public class sCondicao
    {
        public ColecaoCondicao Listar()
        {
            try
            {
                var regra = new rCondicao();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Condicao [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoCondicao Consultar(dCondicao dados)
        {
            try
            {
                var regra = new rCondicao();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Condicao [" + ToString() + "] - " + ex.Message);
            }
        }

        public dCondicao Consultar(int cid)
        {
            try
            {
                var regra = new rCondicao();
                return regra.Consultar(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Condicao [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dCondicao dados)
        {
            try
            {
                var regra = new rCondicao();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Condicao [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dCondicao dados)
        {
            try
            {
                var regra = new rCondicao();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Condicao [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dCondicao dados)
        {
            try
            {
                var regra = new rCondicao();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Condicao [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
