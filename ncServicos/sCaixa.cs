using System;
using System.Transactions;
using ncDados.nsCaixa;
using ncDados.nsUsuario;
using ncRegras.nsCaixa;
using ncComum.nsExcecao;

namespace ncServicos.nsCaixa
{
    public class sCaixa
    {
        public ColecaoCaixa Listar()
        {
            try
            {
                var regra = new rCaixa();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Caixa [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoCaixa Consultar(dCaixa dados)
        {
            try
            {
                var regra = new rCaixa();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Caixa [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoFechamento ConsultarFechamento(dCaixa dados)
        {
            try
            {
                var regra = new rCaixa();
                return regra.ConsultarFechamento(dados);
            }
            catch (ExcecaoNascomercio)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarFechamento Caixa [" + ToString() + "] - " + ex.Message);
            }
        }

        public dCaixa Consultar(int cid)
        {
            try
            {
                var regra = new rCaixa();
                return regra.Consultar(cid);
            }
            catch (ExcecaoNascomercio)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Caixa [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dCaixa dados)
        {
            try
            {
                var regra = new rCaixa();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Caixa [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dCaixa dados)
        {
            try
            {
                var regra = new rCaixa();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Caixa [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dCaixa dados)
        {
            try
            {
                var regra = new rCaixa();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Caixa [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
