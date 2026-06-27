using System;
using ncDados.nsOrdemServico;
using ncRegras.nsOrdemServico;
using ncComum.nsExcecao;

namespace ncServicos.nsOrdemServico
{
    public class sOrdemServico
    {
        public ColecaoOrdemServico Listar()
        {
            try
            {
                var regra = new rOrdemServico();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar OrdemServico [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoOrdemServico Consultar(dOrdemServico dados)
        {
            try
            {
                var regra = new rOrdemServico();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar OrdemServico [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ConsultarMax()
        {
            try
            {
                var regra = new rOrdemServico();
                return regra.ConsultarMax();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarMax OrdemServico [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dOrdemServico dados)
        {
            try
            {
                var regra = new rOrdemServico();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir OrdemServico [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dOrdemServico dados)
        {
            try
            {
                var regra = new rOrdemServico();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar OrdemServico [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dOrdemServico dados)
        {
            try
            {
                var regra = new rOrdemServico();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir OrdemServico [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
