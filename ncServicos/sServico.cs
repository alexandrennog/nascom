using System;
using ncDados.nsServico;
using ncRegras.nsServico;
using ncComum.nsExcecao;

namespace ncServicos.nsServico
{
    public class sServico
    {
        public ColecaoServico Listar()
        {
            try
            {
                var regra = new rServico();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Servico [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoServico Consultar(dServico dados)
        {
            try
            {
                var regra = new rServico();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Servico [" + ToString() + "] - " + ex.Message);
            }
        }

        public dServico Consultar(int cid)
        {
            try
            {
                var regra = new rServico();
                return regra.Consultar(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Servico [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dServico dados)
        {
            try
            {
                var regra = new rServico();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Servico [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dServico dados)
        {
            try
            {
                var regra = new rServico();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Servico [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dServico dados)
        {
            try
            {
                var regra = new rServico();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Servico [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
